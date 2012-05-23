using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using FilterSimulation.fmFilterObjects;
using fmCalcBlocksLibrary.Blocks;
using System.Windows.Forms;
using fmCalculationLibrary;
using fmCalcBlocksLibrary.BlockParameter;
using ZedGraph;
using fmDataGrid;
using fmCalculatorsLibrary;

namespace FilterSimulationWithTablesAndGraphs
{
    class fmDisplayingArray
    {
        private fmValue[] m_values;
        private fmValue m_scale;

        public fmGlobalParameter Parameter { get; set; }

        public fmValue[] Values
        {
            get
            {
                return m_values;
            }
            set
            {
                m_values = value;
            }
        }
        public fmValue Scale
        {
            get
            {
                return m_scale;
            }
            set
            {
                m_scale = value;
            }
        }
        public double[] ValuesInDoubles
        {
            get
            {
                var result = new double[m_values.Length];
                for (int i = 0; i < m_values.Length; ++i)
                    result[i] = m_values[i].value;
                return result;
            }
        }
        public double[] ScaledValuesInDoubles
        {
            get
            {
                var result = new double[m_values.Length];
                for (int i = 0; i < m_values.Length; ++i)
                    result[i] = m_values[i].value * m_scale.value;
                return result;
            }
        }

        public Color Color { get; set; }

        public bool IsY2Axis { get; set; }

        public bool Bold { get; set; }
    }
    class fmDisplayingYListOfArrays
    {
        public fmGlobalParameter Parameter { get; set; }

        public List<fmDisplayingArray> Arrays { get; set; }
    }
    class fmDisplayingResults
    {
        public fmDisplayingArray XParameter { get; set; }

        public List<fmDisplayingYListOfArrays> YParameters { get; set; }
    }
    public class fmSelectedSimulationData
    {
        public bool isChecked;
        public bool isCurrentActive;
        public fmFilterSimulation externalSimulation;
        public fmFilterSimulationData internalSimulationData;
        public List<fmFilterSimulationData> calculatedDataList = new List<fmFilterSimulationData>();
        public fmSelectedSimulationData(bool isChecked, fmFilterSimulation externalSimulation)
        {
            this.isChecked = isChecked;
            isCurrentActive = false;
            this.externalSimulation = externalSimulation;
            internalSimulationData = new fmFilterSimulationData();
            internalSimulationData.CopyFrom(externalSimulation.Data);
        }
    }
    public class fmLocalInputParametersData
    {
        public bool isChecked;
        public bool isCurrentActive;
        public fmFilterMachiningBlock filterMachiningBlock;
        public fmFilterMachiningCalculator.fmFilterMachiningCalculationOption initialFilterMachiningCalculationOption;
        public List<List<fmFilterSimulationData>> calculatedDataLists = new List<List<fmFilterSimulationData>>();
        public fmLocalInputParametersData(bool isChecked, fmFilterMachiningBlock filterMachiningBlock, fmFilterMachiningCalculator.fmFilterMachiningCalculationOption initialFilterMachiningCalculationOption)
        {
            this.isChecked = isChecked;
            isCurrentActive = false;
            this.filterMachiningBlock = filterMachiningBlock;
            this.initialFilterMachiningCalculationOption = initialFilterMachiningCalculationOption;
        }
    }

    public partial class fmFilterSimulationWithTablesAndGraphs
    {
        private List<fmFilterSimulation> m_externalSimList;
        private fmFilterSimulation m_externalCurrentActiveSimulation;
        private List<fmSelectedSimulationData> m_internalSelectedSimList;
        private readonly List<fmLocalInputParametersData> m_localInputParametersList = new List<fmLocalInputParametersData>();
        private bool m_isUseLocalParams;
        private int m_rowsQuantity = 30;
        private bool m_loadingXRange;
        private readonly fmDisplayingResults m_displayingResults = new fmDisplayingResults();
        private object m_highLightCaller;

        private static void FillListBox(IList listBoxItems, List<string> strings)
        {
            for (int i = listBoxItems.Count - 1; i >= 0; --i)
            {
                object item = listBoxItems[i];
                string itemText = (item is ListViewItem) ? (item as ListViewItem).Text : item.ToString();
                if (!strings.Contains(itemText))
                    listBoxItems.RemoveAt(i);
            }

            for (int i = 0, j = 0; j < strings.Count; ++i, ++j)
            {
                bool isAdd = false;
                if (i == listBoxItems.Count)
                {
                    isAdd = true;
                }
                else
                {
                    object item = listBoxItems[i];
                    string itemText = (item is ListViewItem) ? (item as ListViewItem).Text : item.ToString();
                    if (itemText != strings[j])
                    {
                        isAdd = true;
                    }
                }
                
                if (isAdd)
                {
                    listBoxItems.Insert(i, strings[j]);
                }
            }
        }

        private void CreateColumnsInParametersTables()
        {
            var allSimParams = new List<fmGlobalParameter>((new fmFilterSimulation()).Parameters.Keys);

            foreach (fmGlobalParameter p in allSimParams)
            {
                {
                    DataGridViewColumn col = additionalParametersTable.AddColumn<fmDataGridViewNumericalTextBoxColumn>(p.name);
                    col.Width = 50;
                }

                {
                    DataGridViewColumn col = selectedSimulationParametersTable.AddColumn<fmDataGridViewNumericalTextBoxColumn>(p.name);
                    col.Width = 50;
                    col.ReadOnly = true;
                }
            }

            UpdateUnitsInTablesAndGraphs();
        }

        private void AddRow()
        {
            additionalParametersTable.Rows.Add();
            DataGridViewRow row = additionalParametersTable.Rows[additionalParametersTable.Rows.Count - 1];
            row.Cells["AdditionalParametersCheckBoxColumn"].Value = true;
            var fmb = new fmFilterMachiningBlock(
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.A.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.d0.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Dp.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.sf.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.sr.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.n.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.tc.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.tf.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.tr.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.hc_over_tf.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.dhc_over_dt.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.hc.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Mf.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Vf.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.mf.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.vf.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.ms.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.vs.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.msus.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.vsus.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.mc.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.vc.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Msus.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Vsus.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Vc.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Mc.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Ms.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Vs.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qf.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qf_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qs.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qs_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qc.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qc_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qsus.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qsus_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmsus.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmsus_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qms.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qms_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmf.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmf_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmc.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmc_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qf.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qf_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qs.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qs_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qc.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qc_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qsus.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qsus_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmsus.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmsus_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qms.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qms_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmf.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmf_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmc.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmc_d.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.eps.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.kappa.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Pc.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.rc.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.a.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.t1.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.h1.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.t1_over_tf.name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.h1_over_hc.name)]);
            fmb.ValuesChangedByUser += fmb_ValuesChangedByUser;
            m_localInputParametersList.Add(new fmLocalInputParametersData(true, fmb, m_externalCurrentActiveSimulation.FilterMachiningCalculationOption));

            fmb.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.FilterMachiningCalculationOption);
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(m_externalCurrentActiveSimulation, fmb);
            fmb.CalculateAndDisplay();
        }

        // ReSharper disable InconsistentNaming
        void fmb_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void BindSelectedSimulationListToTable()
        {
            UpdateInternalSelectedSimList(m_externalSimList);

            selectedSimulationParametersTable.Rows.Clear();

            for (int i = 0; i < m_internalSelectedSimList.Count; i++)
            {
                fmFilterSimulationData tempSim = m_internalSelectedSimList[i].internalSimulationData;

                DataGridViewRow row =
                    selectedSimulationParametersTable.Rows[selectedSimulationParametersTable.Rows.Add()];
                row.Cells["SelectedSimulationParametersCheckBoxColumn"].Value = m_internalSelectedSimList[i].isChecked;

                foreach (fmGlobalParameter param in tempSim.parameters.Keys)
                {
                    int idx = GetColumnIndexByHeader(selectedSimulationParametersTable, param.name);
                    if (idx != -1)
                    {
                        row.Cells[idx].Value = tempSim.parameters[param].value / param.unitFamily.CurrentUnit.Coef;
                    }
                }

                if (m_externalCurrentActiveSimulation == m_internalSelectedSimList[i].externalSimulation)
                {
                    selectedSimulationParametersTable.CurrentCell = row.Cells[0];
                }
            }

            BindBackColorToSelectedSimulationsTable();
            BindForeColorToSelectedSimulationsTable();
            UpdateVisibilityOfColumnsInSelectedSimulationsTable();
        }

        private void BindBackColorToSelectedSimulationsTable()
        {
            for (int i = 0; i < m_internalSelectedSimList.Count; i++)
            {
                fmFilterSimulationData tempSim = m_internalSelectedSimList[i].internalSimulationData;
                DataGridViewRow row = selectedSimulationParametersTable.Rows[i];

                var tempBlock = new fmFilterMachiningBlock
                {
                    calculationOption = tempSim.filterMachiningCalculationOption
                };
                tempBlock.UpdateGroups();

                foreach (fmBlockVariableParameter param in tempBlock.Parameters)
                {
                    int idx = GetColumnIndexByHeader(selectedSimulationParametersTable, param.globalParameter.name);
                    if (idx != -1)
                    {
                        if (param.group != null)
                        {
                            row.Cells[idx].Style.BackColor = param.group.color;
                        }
                    }
                }
            }
        }

        private void BindForeColorToSelectedSimulationsTable()
        {
            for (int i = 0; i < m_internalSelectedSimList.Count; i++)
            {
                fmFilterSimulationData tempSim = m_internalSelectedSimList[i].internalSimulationData;
                DataGridViewRow row = selectedSimulationParametersTable.Rows[i];

                foreach (fmGlobalParameter param in tempSim.parameters.Keys)
                {
                    int idx = GetColumnIndexByHeader(selectedSimulationParametersTable, param.name);
                    if (idx != -1)
                    {
                        Color cellForeColor = Color.Black;
                        if (tempSim.parameters[param] is fmCalculationVariableParameter)
                        {
                            if (((fmCalculationVariableParameter)tempSim.parameters[param]).isInputed)
                                cellForeColor = Color.Blue;
                        }
                        if (cellForeColor == Color.Black)
                        {
                            row.Cells[idx].Value = "-";
                        }
                        else if (row.Cells[idx].Value.ToString() == "-")
                        {
                            row.Cells[idx].Value = tempSim.parameters[param].ValueInUnits;
                        }
                        row.Cells[idx].Style.ForeColor = cellForeColor;
                    }
                }
            }
        }

        private void UpdateVisibilityOfColumnsInSelectedSimulationsTable()
        {
            var inputs = new List<fmGlobalParameter>();
            foreach (var p in new fmFilterMachiningBlock().Parameters)
            {
                inputs.Add(p.globalParameter);
            }

            foreach (DataGridViewColumn col in selectedSimulationParametersTable.Columns)
            {
                string parName = GetParameterNameFromHeader(col.HeaderText);
                if (fmGlobalParameter.parametersByName.ContainsKey(parName))
                {
                    fmGlobalParameter par = fmGlobalParameter.parametersByName[parName];
                    col.Visible = false;
                    if (inputs.Contains(par))
                    {
                        foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
                            if (simData.internalSimulationData.parameters[par] is fmCalculationVariableParameter
                                && ((fmCalculationVariableParameter)simData.internalSimulationData.parameters[par]).isInputed)
                            {
                                var fmb = new fmFilterMachiningBlock();
                                fmb.SetCalculationOptionAndRewriteData(simData.internalSimulationData.filterMachiningCalculationOption);
                                var xParameter = fmb.GetParameterByName(listBoxXAxis.Text);
                                if (xParameter == null || fmb.GetParameterByName(parName).group != xParameter.group)
                                {
                                    col.Visible = true;
                                    break;
                                }
                            }
                    }
                }
            }
        }

        private static int GetColumnIndexByHeader(DataGridView grid, string header)
        {
            for (int i = grid.Columns.Count - 1; i >= 0; i--)
            {
                if (GetParameterNameFromHeader(grid.Columns[i].HeaderText) == header)
                    return i;
            }
            return -1;
        }

        #region events

        // ReSharper disable InconsistentNaming
        private void additionalParametersTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            if (additionalParametersTable.Rows.Count > 1
                && additionalParametersTable.Columns[e.ColumnIndex].Name == "DeleteButtonColumn")
            {
                m_localInputParametersList.RemoveAt(e.RowIndex);
                additionalParametersTable.Rows.RemoveAt(e.RowIndex);
                UpdateVisibilityOfColumnsInLocalParametrsTable();
                BindXYLists();
                RecalculateSimulationsWithIterationX();
                BindCalculatedResultsToDisplayingResults();
                BindCalculatedResultsToChartAndTable();
            }
        }

        // ReSharper disable InconsistentNaming
        private void listBoxX_SelectedIndexChanged(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            SetXAxisParameterAsInputed();
        }

        private void SetXAxisParameterAsInputed()
        {
            if (listBoxXAxis.Text != "")
                UpdateIsInputed(fmGlobalParameter.parametersByName[listBoxXAxis.Text]);
            BindForeColorToSelectedSimulationsTable();
            UpdateVisibilityOfColumnsInSelectedSimulationsTable();
            LoadCurrentXRange();
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void UpdateIsInputed(fmGlobalParameter inputedParameter)
        {
            if (m_isUseLocalParams)
            {
                foreach (fmLocalInputParametersData localParameters in m_localInputParametersList)
                {
                    localParameters.filterMachiningBlock.UpdateIsInputed(localParameters.filterMachiningBlock.GetParameterByName(inputedParameter.name));
                }
            }
            else
            {
                foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
                {
                    foreach (var p in simData.externalSimulation.Parameters.Values)
                    {
                        if (p is fmCalculationVariableParameter)
                        {
                            ((fmCalculationVariableParameter)simData.internalSimulationData.parameters[p.globalParameter]).isInputed = ((fmCalculationVariableParameter)p).isInputed;
                        }
                    }
                    simData.internalSimulationData.filterMachiningCalculationOption = simData.externalSimulation.FilterMachiningCalculationOption;
                    simData.internalSimulationData.hcdEpsdCalculationOption = simData.externalSimulation.HcdEpsdCalculationOption;
                    simData.internalSimulationData.rhoDCalculationOption = simData.externalSimulation.RhoDetaDCalculationOption;
                    simData.internalSimulationData.PcDCalculationOption = simData.externalSimulation.PcDCalculationOption;
                    simData.internalSimulationData.suspensionCalculationOption = simData.externalSimulation.SuspensionCalculationOption;
                    simData.internalSimulationData.UpdateIsInputed(inputedParameter);
                }
            }
        }

        private void LoadCurrentXRange()
        {
            if (listBoxXAxis.Text == "")
                return;

            m_loadingXRange = true;
            fmGlobalParameter xParameter = fmGlobalParameter.parametersByName[listBoxXAxis.Text];
            double coef = xParameter.unitFamily.CurrentUnit.Coef;
            fmRange range = xParameter.chartCurretXRange;
            minXValueTextBox.Text = (range.MinValue / coef).ToString();
            maxXValueTextBox.Text = (range.MaxValue / coef).ToString();
            m_loadingXRange = false;
        }

        private void LoadvalidRange()
        {
            if (listBoxXAxis.Text == "")
            {
                return;
            }
            m_loadingXRange = true;
            fmGlobalParameter xParameter = fmGlobalParameter.parametersByName[listBoxXAxis.Text];
            double coef = xParameter.unitFamily.CurrentUnit.Coef;
            fmRange defaultRange = xParameter.validRange;
            fmRange range = xParameter.chartCurretXRange;
            range.MinValue = defaultRange.MinValue;
            range.MaxValue = defaultRange.MaxValue;
            minXValueTextBox.Text = (range.MinValue / coef).ToString();
            maxXValueTextBox.Text = (range.MaxValue / coef).ToString();
            m_loadingXRange = false;
        }

        // ReSharper disable InconsistentNaming
        private void buttonAddRow_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            AddRow();
            UpdateVisibilityOfColumnsInLocalParametrsTable();
            UpdateIsCurrentActiveProperty(additionalParametersTable.CurrentRow == null ? -1 : additionalParametersTable.CurrentRow.Index);
            BindXYLists();
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        // ReSharper disable InconsistentNaming
        private void UseParamsCheckBox_CheckedChanged(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            ReadUseParamsCheckBoxAndApply();
            UpdateVisibilityOfColumnsInLocalParametrsTable();
            BindXYLists();
            LoadCurrentXRange();
            if (listBoxXAxis.Text != "")
                UpdateIsInputed(fmGlobalParameter.parametersByName[listBoxXAxis.Text]);
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void ReadUseParamsCheckBoxAndApply()
        {
            m_isUseLocalParams = UseParamsCheckBox.Checked;
            additionalParametersTable.Visible = m_isUseLocalParams;
            buttonAddRow.Visible = m_isUseLocalParams;
            selectedSimulationParametersTable.Visible = !m_isUseLocalParams;
            selectedSimulationParametersTable.Dock = (!m_isUseLocalParams) ? DockStyle.Fill : DockStyle.None;
            additionalParametersTable.Dock = (m_isUseLocalParams) ? DockStyle.Fill : DockStyle.None;
        }

        // ReSharper disable InconsistentNaming
        private void ParametersTable_CurrentCellChanged(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            var dgv = sender as DataGridView;
            if (dgv != null && dgv.CurrentCell != null)
            {
                BindCalculatedResultsToDisplayingResults();
                BindCalculatedResultsToChartAndTable();
            }

            if (dgv != null)
            {
                UpdateIsCurrentActiveProperty(dgv.CurrentRow != null ? dgv.CurrentRow.Index : -1);
            }
        }

        private void UpdateIsCurrentActiveProperty(int currentRowIndex)
        {
            if (!m_isUseLocalParams)
            {
                for (int i = 0; i < m_internalSelectedSimList.Count; ++i)
                {
                    m_internalSelectedSimList[i].isCurrentActive = i == currentRowIndex;
                }
            }
            else
            {
                for (int i = 0; i < m_localInputParametersList.Count; ++i)
                {
                    m_localInputParametersList[i].isCurrentActive = i == currentRowIndex;
                }
            }
        }

        // ReSharper disable InconsistentNaming
        private void selectedSimulationParametersTable_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            if (selectedSimulationParametersTable.Columns[e.ColumnIndex].Name == "SelectedSimulationParametersCheckBoxColumn"
                && m_internalSelectedSimList.Count > e.RowIndex)
            {
                m_internalSelectedSimList[e.RowIndex].isChecked = (bool)selectedSimulationParametersTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                BindCalculatedResultsToDisplayingResults();
                BindCalculatedResultsToChartAndTable();
            }
        }

        // ReSharper disable InconsistentNaming
        private void additionalParametersTable_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            if (additionalParametersTable.Columns[e.ColumnIndex].Name == "AdditionalParametersCheckBoxColumn"
                && m_localInputParametersList.Count > e.RowIndex)
            {
                m_localInputParametersList[e.RowIndex].isChecked = (bool)additionalParametersTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                RecalculateSimulationsWithIterationX();
                BindCalculatedResultsToDisplayingResults();
                BindCalculatedResultsToChartAndTable();
            }
        }

        // ReSharper disable InconsistentNaming
        private void rowsQuantity_TextChanged(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            if (!string.IsNullOrEmpty(rowsQuantity.Text))
            {
                m_rowsQuantity = (int)fmValue.StringToValue(rowsQuantity.Text).value;
                rowsQuantity.Text = m_rowsQuantity.ToString();
                rowsQuantity.Focus();
                RecalculateSimulationsWithIterationX();
                BindCalculatedResultsToDisplayingResults();
                BindCalculatedResultsToChartAndTable();
            }
        }

        #endregion

        public void UpdateUnitsInTablesAndGraphs()
        {
            foreach (DataGridViewColumn col in additionalParametersTable.Columns)
            {
                string parName = GetParameterNameFromHeader(col.HeaderText);
                if (fmGlobalParameter.parametersByName.ContainsKey(parName))
                {
                    fmGlobalParameter p = fmGlobalParameter.parametersByName[parName];
                    col.HeaderText = p.name + @" (" + p.UnitName + @")";
                }
            }

            foreach (DataGridViewColumn col in selectedSimulationParametersTable.Columns)
            {
                string parName = GetParameterNameFromHeader(col.HeaderText);
                if (fmGlobalParameter.parametersByName.ContainsKey(parName))
                {
                    fmGlobalParameter p = fmGlobalParameter.parametersByName[parName];
                    col.HeaderText = p.name + @" (" + p.UnitName + @")";
                }
            }
        }

        public void BuildCurves(List<fmFilterSimulation> simList, fmFilterSimulation currentActiveSimulation)
        {
            m_externalSimList = simList;
            m_externalCurrentActiveSimulation = currentActiveSimulation;
            BindSelectedSimulationListToTable();
            UpdateVisibilityOfColumnsInLocalParametrsTable();
            BindXYLists();
            LoadCurrentXRange();
            if (listBoxXAxis.Text != "")
                UpdateIsInputed(fmGlobalParameter.parametersByName[listBoxXAxis.Text]);
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void UpdateVisibilityOfColumnsInLocalParametrsTable()
        {
            var inputs = new List<fmGlobalParameter>();
            foreach (fmLocalInputParametersData localParameters in m_localInputParametersList)
            {
                inputs = ParametersListsUnion(inputs, fmCalculationOptionHelper.GetParametersListThatCanBeInput(localParameters.filterMachiningBlock.calculationOption));
            }

            foreach (DataGridViewColumn col in additionalParametersTable.Columns)
            {
                string parName = GetParameterNameFromHeader(col.HeaderText);
                if (fmGlobalParameter.parametersByName.ContainsKey(parName))
                {
                    col.Visible = inputs.Contains(fmGlobalParameter.parametersByName[parName]);
                }
            }
        }

        private void BindCalculatedResultsToTable()
        {
            int yParametersCount = m_displayingResults.YParameters == null ? 0 : m_displayingResults.YParameters.Count;
            
            coordinatesGrid.ColumnCount = 1;
            for (int i = 0; i < yParametersCount; ++i)
            {
                // ReSharper disable PossibleNullReferenceException
                coordinatesGrid.ColumnCount += m_displayingResults.YParameters[i].Arrays.Count;
                // ReSharper restore PossibleNullReferenceException
            }

            if (m_displayingResults.XParameter == null)
            {
                coordinatesGrid.Columns.Clear();
                return;
            }

            // x-axis column
            {
                string parameterNameAndUnits = m_displayingResults.XParameter.Parameter.name + " (" + m_displayingResults.XParameter.Parameter.UnitName + ")";
                coordinatesGrid.Columns[0].HeaderText = parameterNameAndUnits;
                coordinatesGrid.Columns[0].ReadOnly = true;
                coordinatesGrid.Columns[0].Width = 50;
                coordinatesGrid.RowCount = m_displayingResults.XParameter.Values.Length;
                for (int i = 0; i < coordinatesGrid.RowCount; ++i)
                {
                    coordinatesGrid[0, i].Value = m_displayingResults.XParameter.Values[i];
                }
            }

            if (m_displayingResults.YParameters == null)
            {
                fmZedGraphControl1.Refresh();
                return;
            }

            int yCol = 0;

            foreach (fmDisplayingYListOfArrays yArrays in m_displayingResults.YParameters)
            {
                fmGlobalParameter yParameter = yArrays.Parameter;
                string parameterNameAndUnits = yParameter.name + " (" + yParameter.UnitName + ")";

                foreach (fmDisplayingArray dispArray in yArrays.Arrays)
                {
                    ++yCol;
                    if (coordinatesGrid.Columns.Count > yCol)
                    {
                        coordinatesGrid.Columns[yCol].HeaderText = parameterNameAndUnits;
                        coordinatesGrid.Columns[yCol].ReadOnly = true;
                        coordinatesGrid.Columns[yCol].Width = 50;


                        if (dispArray.Values.Length == coordinatesGrid.RowCount)
                        {
                            for (int i = 0; i < coordinatesGrid.RowCount; ++i)
                            {
                                coordinatesGrid[yCol, i].Value = dispArray.Values[i];
                            }
                        }
                    }
                }
            }
        }

        private void BindCalculatedResultsToChart()
        {
            fmZedGraphControl1.GraphPane.CurveList.Clear();

            if (m_displayingResults.YParameters == null || m_displayingResults.XParameter == null)
            {
                return;
            }

            foreach (fmDisplayingYListOfArrays yArrays in m_displayingResults.YParameters)
            {
                foreach (fmDisplayingArray dispArray in yArrays.Arrays)
                {
                    string scaleString = dispArray.Scale.value == 1 ? "" : " * " + (1 / dispArray.Scale);
                    LineItem curve = fmZedGraphControl1.GraphPane.AddCurve(dispArray.Parameter.name + scaleString + " (" + dispArray.Parameter.UnitName + ")",
                        m_displayingResults.XParameter.ValuesInDoubles,
                        RemoveNoise(dispArray.ScaledValuesInDoubles),
                        dispArray.Color,
                        SymbolType.None);
                    curve.Line.IsAntiAlias = true;
                    curve.Line.Width = dispArray.Bold ? 2 : 1;
                    curve.IsY2Axis = dispArray.IsY2Axis;
                }
            }

            fmGlobalParameter xParameter = m_displayingResults.XParameter.Parameter;
            fmZedGraphControl1.GraphPane.XAxis.Title.Text = xParameter.name + " (" + xParameter.UnitName + ")";
            fmZedGraphControl1.GraphPane.Legend.IsVisible = false;
            fmZedGraphControl1.GraphPane.Y2Axis.IsVisible = false;

            if (m_displayingResults.YParameters.Count == 1)
            {
                fmGlobalParameter yParameter = m_displayingResults.YParameters[0].Parameter;
                fmZedGraphControl1.GraphPane.YAxis.Title.Text = yParameter.name + " (" + yParameter.UnitName + ")";
                if (m_displayingResults.YParameters[0].Arrays.Count > 0)
                {
                    fmZedGraphControl1.GraphPane.YAxis.Title.FontSpec.FontColor = m_displayingResults.YParameters[0].Arrays[0].Color;
                }
            }
            else if (m_displayingResults.YParameters.Count == 2)
            {
                fmZedGraphControl1.GraphPane.Y2Axis.IsVisible = true;

                fmGlobalParameter y1Parameter = m_displayingResults.YParameters[0].Parameter;
                fmGlobalParameter y2Parameter = m_displayingResults.YParameters[1].Parameter;
                fmZedGraphControl1.GraphPane.YAxis.Title.Text = y1Parameter.name + " (" + y1Parameter.UnitName + ")";
                if (m_displayingResults.YParameters[0].Arrays.Count > 0)
                {
                    fmZedGraphControl1.GraphPane.YAxis.Title.FontSpec.FontColor = m_displayingResults.YParameters[0].Arrays[0].Color;
                }

                fmZedGraphControl1.GraphPane.Y2Axis.Title.Text = y2Parameter.name + " (" + y2Parameter.UnitName + ")";
                if (m_displayingResults.YParameters[1].Arrays.Count > 0)
                {
                    fmZedGraphControl1.GraphPane.Y2Axis.Title.FontSpec.FontColor = m_displayingResults.YParameters[1].Arrays[0].Color;
                }
            }
            else
            {
                fmZedGraphControl1.GraphPane.YAxis.Title.Text = "";
                fmZedGraphControl1.GraphPane.Legend.IsVisible = true;
            }

            fmZedGraphControl1.GraphPane.Title.Text = "";
            fmZedGraphControl1.GraphPane.AxisChange();
            fmZedGraphControl1.Refresh();
        }

        private static double[] RemoveNoise(double[] points)
        {
            var p = new double[points.Length];
            for (int i = 0; i < p.Length; ++i)
            {
                p[i] = points[i];
            }

            double maxAbsValue = 0;
            for (int i = 0; i < p.Length; ++i)
            {
                maxAbsValue = Math.Max(maxAbsValue, Math.Abs(p[i]));
            }
            double eps = maxAbsValue > 1 ? 1e-9*maxAbsValue : 1e-9;
            for (int i = 1; i < p.Length; ++i)
            {
                if (Math.Abs(p[i] - p[0]) <= eps)
                {
                    p[i] = p[0];
                }
            }

            return p;
        }

        private void BindCalculatedResultsToChartAndTable()
        {
            BindCalculatedResultsToChart();
            BindCalculatedResultsToTable();
        }

        private void BindCalculatedResultsToDisplayingResults()
        {
            if (listBoxXAxis.Text == "")
            {
                m_displayingResults.XParameter = null;
                m_displayingResults.YParameters = null;
                return;
            }

            fmGlobalParameter xParameter = fmGlobalParameter.parametersByName[listBoxXAxis.Text];
            var yParameters = new List<fmGlobalParameter>();
            foreach (ListViewItem item in listBoxYAxis.CheckedItems)
            {
                yParameters.Add(fmGlobalParameter.parametersByName[item.Text]);
            }

            BindCalculatedResultsToDisplayingResults(xParameter, yParameters);
        }
        private void BindCalculatedResultsToDisplayingResults(fmGlobalParameter xParameter, List<fmGlobalParameter> yParameters)
        {
            if (!m_isUseLocalParams)
            {
                m_displayingResults.YParameters = new List<fmDisplayingYListOfArrays>();

                if (m_internalSelectedSimList.Count == 0)
                {
                    return;
                }

                var xArray = new fmDisplayingArray();
                m_displayingResults.XParameter = xArray;

                xArray.Parameter = xParameter;
                xArray.Values = new fmValue[m_internalSelectedSimList[0].calculatedDataList.Count];
                for (int i = 0; i < m_internalSelectedSimList[0].calculatedDataList.Count; ++i)
                {
                    xArray.Values[i] =
                        m_internalSelectedSimList[0].calculatedDataList[i].parameters[xParameter].ValueInUnits;
                }

                Dictionary<fmGlobalParameter, fmValue> degreeOffset = CreateDegreeOffsets(yParameters);

                var colors = new[] { Color.Blue, Color.Green, Color.Red, Color.Black };
                int colorId = 0;

                foreach (fmGlobalParameter yParameter in yParameters)
                {
                    var yListOfArrays = new fmDisplayingYListOfArrays
                    {
                        Parameter = yParameter,
                        Arrays = new List<fmDisplayingArray>()
                    };

                    foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
                    {
                        if (!simData.isChecked)
                            continue;

                        var yArray = new fmDisplayingArray
                        {
                            Parameter = yParameter,
                            Values = new fmValue[simData.calculatedDataList.Count],
                            Scale = yParameters.Count > 2 ? degreeOffset[yParameter] : new fmValue(1),
                            IsY2Axis = colorId == 1 && yParameters.Count == 2,
                            Color = colors[colorId],
                            Bold = selectedSimulationParametersTable.CurrentCell != null
                                   &&
                                   m_internalSelectedSimList.IndexOf(simData) ==
                                   selectedSimulationParametersTable.CurrentCell.RowIndex
                        };

                        for (int i = 0; i < simData.calculatedDataList.Count; ++i)
                        {
                            yArray.Values[i] = simData.calculatedDataList[i].parameters[yParameter].ValueInUnits;
                        }

                        yListOfArrays.Arrays.Add(yArray);
                    }

                    if (++colorId == colors.Length) colorId = 0;

                    m_displayingResults.YParameters.Add(yListOfArrays);
                }
            }
            else
            {
                m_displayingResults.YParameters = new List<fmDisplayingYListOfArrays>();

                if (m_localInputParametersList.Count == 0
                    || m_localInputParametersList[0].calculatedDataLists.Count == 0)
                {
                    return;
                }

                var xArray = new fmDisplayingArray();
                m_displayingResults.XParameter = xArray;

                xArray.Parameter = xParameter;
                int pointsCount = m_localInputParametersList[0].calculatedDataLists[0].Count;
                xArray.Values = new fmValue[pointsCount];
                for (int i = 0; i < pointsCount; ++i)
                {
                    xArray.Values[i] =
                        m_localInputParametersList[0].calculatedDataLists[0][i].parameters[xParameter].ValueInUnits;
                }

                Dictionary<fmGlobalParameter, fmValue> degreeOffset = CreateDegreeOffsets(yParameters);

                var colors = new[] { Color.Blue, Color.Green, Color.Red, Color.Black };
                int colorId = 0;

                foreach (fmGlobalParameter yParameter in yParameters)
                {
                    var yListOfArrays = new fmDisplayingYListOfArrays
                    {
                        Parameter = yParameter,
                        Arrays = new List<fmDisplayingArray>()
                    };

                    foreach (fmLocalInputParametersData localParameters in m_localInputParametersList)
                    {
                        if (!localParameters.isChecked)
                            continue;

                        foreach (List<fmFilterSimulationData> list in localParameters.calculatedDataLists)
                        {
                            var yArray = new fmDisplayingArray
                            {
                                Parameter = yParameter,
                                Values = new fmValue[pointsCount],
                                Scale = yParameters.Count > 2 ? degreeOffset[yParameter] : new fmValue(1),
                                IsY2Axis = colorId == 1 && yParameters.Count == 2,
                                Color = colors[colorId],
                                Bold = additionalParametersTable.CurrentCell != null
                                       && m_localInputParametersList.IndexOf(localParameters) ==
                                       additionalParametersTable.CurrentCell.RowIndex
                            };

                            for (int i = 0; i < list.Count; ++i)
                            {
                                yArray.Values[i] = list[i].parameters[yParameter].ValueInUnits;
                            }

                            yListOfArrays.Arrays.Add(yArray);
                        }
                    }

                    if (++colorId == colors.Length) colorId = 0;
                    m_displayingResults.YParameters.Add(yListOfArrays);
                }
            }
        }

        private Dictionary<fmGlobalParameter, fmValue> CreateDegreeOffsets(IEnumerable<fmGlobalParameter> yParameters)
        {
            var degreeOffset = new Dictionary<fmGlobalParameter, fmValue>();
            var degreeOffsetCount = new Dictionary<fmValue, int>();

            foreach (fmGlobalParameter yParameter in yParameters)
            {
                fmValue maxY = -fmValue.Infinity();
                foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
                {
                    for (int i = 0; i < simData.calculatedDataList.Count; ++i)
                    {
                        fmValue curVal = fmValue.Abs(simData.calculatedDataList[i].parameters[yParameter].ValueInUnits);
                        maxY = fmValue.Max(maxY, curVal);
                    }
                }

                fmValue degreeOffsetvalue = (maxY.value > 0)
                    ? new fmValue(Math.Pow(10.0, -Math.Ceiling(Math.Log(maxY.value, 10.0) + 1e-10)))
                    : new fmValue(1);
                degreeOffset[yParameter] = degreeOffsetvalue;
                if (!degreeOffsetCount.ContainsKey(degreeOffsetvalue))
                {
                    degreeOffsetCount[degreeOffsetvalue] = 1;
                }
                else
                {
                    ++degreeOffsetCount[degreeOffsetvalue];
                }
            }

            int bestValue = 0;
            var bestDegreeOffset = new fmValue(1);
            foreach (KeyValuePair<fmValue, int> pair in degreeOffsetCount)
            {
                if (pair.Value > bestValue)
                {
                    bestValue = pair.Value;
                    bestDegreeOffset = pair.Key;
                }
            }

            var resultDegreeOffset = new Dictionary<fmGlobalParameter, fmValue>();
            foreach (fmGlobalParameter p in degreeOffset.Keys)
            {
                resultDegreeOffset[p] = degreeOffset[p] / bestDegreeOffset;
            }

            return resultDegreeOffset;
        }

        private void RecalculateSimulationsWithIterationX()
        {
            if (listBoxXAxis.Text == "")
            {
                return;
            }

            fmGlobalParameter xParameter = fmGlobalParameter.parametersByName[listBoxXAxis.Text];

            if (!m_isUseLocalParams)
            {
                foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
                {
                    double xStart = xParameter.chartCurretXRange.MinValue
                        / xParameter.unitFamily.CurrentUnit.Coef;
                    double xEnd = xParameter.chartCurretXRange.MaxValue
                        / xParameter.unitFamily.CurrentUnit.Coef;

                    IEnumerable<double> xList = CreateXValues(xStart, xEnd, m_rowsQuantity);

                    simData.calculatedDataList = new List<fmFilterSimulationData>();

                    foreach (double x in xList)
                    {
                        var tempSim = new fmFilterSimulationData();
                        tempSim.CopyIsInputedFrom(simData.internalSimulationData);
                        tempSim.CopyValuesFrom(simData.externalSimulation.Data);
                        tempSim.parameters[xParameter].value = new fmValue(x * xParameter.unitFamily.CurrentUnit.Coef);

                        var suspensionCalculator = new fmSuspensionCalculator(tempSim.parameters.Values)
                        {
                            calculationOption =
                                simData.internalSimulationData.
                                suspensionCalculationOption
                        };
                        suspensionCalculator.DoCalculations();

                        var eps0Kappa0Calculator = new fmEps0Kappa0Calculator(tempSim.parameters.Values);
                        eps0Kappa0Calculator.DoCalculations();

                        var pc0Rc0A0Calculator = new fmPc0Rc0A0Calculator(tempSim.parameters.Values);
                        pc0Rc0A0Calculator.DoCalculations();

                        var rm0HceCalculator = new fmRm0HceCalculator(tempSim.parameters.Values);
                        rm0HceCalculator.DoCalculations();

                        var filterMachiningCalculator =
                            new fmFilterMachiningCalculator(tempSim.parameters.Values)
                                {
                                    calculationOption =
                                        simData.internalSimulationData.
                                        filterMachiningCalculationOption
                                };
                        filterMachiningCalculator.DoCalculations();

                        var eps0dNedEpsdCalculator = new fmEps0dNedEpsdCalculator(tempSim.parameters.Values);
                        eps0dNedEpsdCalculator.DoCalculations();

                        var sigmaPke0PkePcdRcdAlphadCalculator = new fmSigmaPke0PkePcdRcdAlphadCalculator(tempSim.parameters.Values);
                        sigmaPke0PkePcdRcdAlphadCalculator.DoCalculations();

                        var deliquoringSimualtionCalculator = new fmDeliquoringSimualtionCalculator(tempSim.parameters.Values);
                        deliquoringSimualtionCalculator.DoCalculations();

                        simData.calculatedDataList.Add(tempSim);
                    }
                }
            }
            else
            {
                foreach (fmLocalInputParametersData localParameters in m_localInputParametersList)
                {
                    localParameters.calculatedDataLists = new List<List<fmFilterSimulationData>>();
                    foreach (fmFilterSimulation sim in m_externalSimList)
                    {
                        double xStart = xParameter.chartCurretXRange.MinValue
                            / xParameter.unitFamily.CurrentUnit.Coef;
                        double xEnd = xParameter.chartCurretXRange.MaxValue
                            / xParameter.unitFamily.CurrentUnit.Coef;

                        IEnumerable<double> xList = CreateXValues(xStart, xEnd, m_rowsQuantity);

                        var calculatedDataList = new List<fmFilterSimulationData>();

                        foreach (double x in xList)
                        {
                            var tempSim = new fmFilterSimulationData();
                            fmFilterSimulationData.CopyAllParametersFromBlockToSimulation(localParameters.filterMachiningBlock, tempSim);
                            tempSim.CopyMaterialParametersValuesFrom(sim.Data);
                            tempSim.parameters[xParameter].value = new fmValue(x * xParameter.unitFamily.CurrentUnit.Coef);

                            var filterMachiningCalculator = new fmFilterMachiningCalculator(tempSim.parameters.Values)
                            {
                                calculationOption =
                                    localParameters.filterMachiningBlock.
                                    calculationOption
                            };
                            filterMachiningCalculator.DoCalculations();

                            calculatedDataList.Add(tempSim);
                        }

                        localParameters.calculatedDataLists.Add(calculatedDataList);
                    }
                }
            }
        }

        private static IEnumerable<double> CreateXValues(double xStart, double xEnd, int minimalNodesAmount)
        {
            double[] goodNumbers = { 1, 1.25, 2, 2.5, 5 };
            const double eps = 1e-9;

            const int maxPower = 15;

            for (int power = maxPower; power >= -maxPower; --power)
                for (int xIndex = goodNumbers.Length - 1; xIndex >= 0; --xIndex)
                {
                    double x = goodNumbers[xIndex];
                    double dx = x * Math.Pow(10.0, power);
                    double nodesCount = 2 + Math.Floor(xEnd / dx - eps) - Math.Floor(xStart / dx + eps);
                    if (nodesCount >= minimalNodesAmount)
                    {
                        var result = new List<double> { xStart };
                        for (int i = 1; i < nodesCount - 1; ++i)
                        {
                            result.Add((Math.Floor(xStart / dx + eps) + i) * dx);
                        }
                        result.Add(xEnd);
                        return result;
                    }
                }

            return new List<double>();
        }

        private void BindXYLists()
        {
            var inputNames = new List<string>();

            IEnumerable<fmGlobalParameter> simInputParameters = GetCommonInputParametersList();

            foreach (fmGlobalParameter p in simInputParameters)
            {
                inputNames.Add(p.name);
            }

            FillListBox(listBoxXAxis.Items, inputNames);
            if (listBoxXAxis.Text == "" && inputNames.Contains(fmGlobalParameter.tf.name))
            {
                listBoxXAxis.Text = fmGlobalParameter.tf.name;
            }

            var outputNames = new List<string>();

            foreach (fmGlobalParameter p in fmGlobalParameter.parameters)
            {
                if (parametersToDisplay.Contains(p))
                {
                    outputNames.Add(p.name);
                }
            }

            FillListBox(listBoxYAxis.Items, outputNames);

            if (listBoxYAxis.CheckedItems.Count == 0)
            {
                if (outputNames.Contains(fmGlobalParameter.hc.name))
                {
                    listBoxYAxis.Items[outputNames.IndexOf(fmGlobalParameter.hc.name)].Checked = true;
                }
            }
        }

        private IEnumerable<fmGlobalParameter> GetCommonInputParametersList()
        {
            if (!m_isUseLocalParams)
            {
                var simInputParameters = new List<fmGlobalParameter>(fmGlobalParameter.parameters);
                foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
                    //if (simData.isChecked)
                    simInputParameters = ParametersListsIntersection(simInputParameters,
                                                                     simData.internalSimulationData.
                                                                         GetParametersThatCanBeInputedList());
                return simInputParameters;
            }
            else
            {
                var simInputParameters = new List<fmGlobalParameter>(fmGlobalParameter.parameters);
                foreach (fmLocalInputParametersData localParameters in m_localInputParametersList)
                    simInputParameters = ParametersListsIntersection(simInputParameters,
                                                              fmCalculationOptionHelper.GetParametersListThatCanBeInput(
                                                                  localParameters.filterMachiningBlock.calculationOption));
                return simInputParameters;
            }
        }

        private static List<fmGlobalParameter> ParametersListsIntersection(List<fmGlobalParameter> a, List<fmGlobalParameter> b)
        {
            var result = new List<fmGlobalParameter>();
            foreach (fmGlobalParameter p in fmGlobalParameter.parameters)
                if (a.Contains(p) && b.Contains(p))
                    result.Add(p);
            return result;
        }

        private static List<fmGlobalParameter> ParametersListsUnion(List<fmGlobalParameter> a, List<fmGlobalParameter> b)
        {
            var result = new List<fmGlobalParameter>();
            foreach (fmGlobalParameter p in fmGlobalParameter.parameters)
                if (a.Contains(p) || b.Contains(p))
                    result.Add(p);
            return result;
        }

        private void UpdateInternalSelectedSimList(IEnumerable<fmFilterSimulation> simList)
        {
            var newInternalSelectedSimList = new List<fmSelectedSimulationData>();
            foreach (fmFilterSimulation sim in simList)
            {
                fmSelectedSimulationData newSelectedSim = null;
                foreach (fmSelectedSimulationData checkedSim in m_internalSelectedSimList)
                {
                    if (checkedSim.externalSimulation == sim)
                    {
                        newSelectedSim = checkedSim;
                        newSelectedSim.internalSimulationData.CopyValuesFrom(sim.Data);
                    }
                }
                if (newSelectedSim == null)
                {
                    newSelectedSim = new fmSelectedSimulationData(true, sim);
                }
                newInternalSelectedSimList.Add(newSelectedSim);
            }
            m_internalSelectedSimList = newInternalSelectedSimList;
        }
    }
}
