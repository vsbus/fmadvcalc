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
        public fmFilterSimulationData OwningSimulation;

        internal string GetTextForHeader()
        {
            string result = Parameter.Name + " (" + Parameter.UnitName + ")";
            if (OwningSimulation != null)
            {
                result += " [" + OwningSimulation.name + "]";
            }
            return result;
        }

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
        public List<List<fmFilterSimulationData>> calculatedDataLists = new List<List<fmFilterSimulationData>>();
        public fmLocalInputParametersData(bool isChecked, fmFilterMachiningBlock filterMachiningBlock)
        {
            this.isChecked = isChecked;
            isCurrentActive = false;
            this.filterMachiningBlock = filterMachiningBlock;
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
        private readonly fmDisplayingResults m_displayingResults = new fmDisplayingResults();
        private object m_highLightCaller;

        private enum parameterKind
        {
            MaterialCakeFormation,
            MachiningSettingsCakeFormation,
            MaterialDeliquoring,
            MachiningSettingsDeliquoring
        }

        struct ParameterKindProperties
        {
            public Color Color { get; set; }
            public CheckBox Checkbox { get; set; }
        }

        private Dictionary<string, parameterKind> m_XYListKind;

        private Dictionary<parameterKind, ParameterKindProperties> m_parameterKindProperties;

        void AddColors(parameterKind kind, fmGlobalParameter[] parameters)
        {
            foreach (fmGlobalParameter p in parameters)
            {
                m_XYListKind.Add(p.Name, kind);
            }
        }

        void InitXYParametersProperties()
        {
            m_parameterKindProperties = new Dictionary<parameterKind, ParameterKindProperties>()
                                            {
                                                {
                                                    parameterKind.MaterialCakeFormation,
                                                    new ParameterKindProperties()
                                                        {
                                                            Color = Color.Green,
                                                            Checkbox = cakeFormationMaterilParametersCheckBox
                                                        }
                                                    },
                                                {
                                                    parameterKind.MachiningSettingsCakeFormation,
                                                    new ParameterKindProperties()
                                                        {
                                                            Color = Color.BlueViolet,
                                                            Checkbox = cakeFormationMachininglParametersCheckBox
                                                        }
                                                    },
                                                {
                                                    parameterKind.MaterialDeliquoring,
                                                    new ParameterKindProperties()
                                                        {
                                                            Color = Color.Coral,
                                                            Checkbox = deliquoringMaterilParametersCheckBox
                                                        }
                                                    },
                                                {
                                                    parameterKind.MachiningSettingsDeliquoring,
                                                    new ParameterKindProperties()
                                                        {
                                                            Color = Color.IndianRed,
                                                            Checkbox = deliquoringMachininglParametersCheckBox
                                                        }
                                                    }
                                            };


            m_XYListKind = new Dictionary<string, parameterKind>();

            AddColors(parameterKind.MaterialCakeFormation, fmGlobalParameter.GetMaterialCakeParameters());
            AddColors(parameterKind.MachiningSettingsCakeFormation, fmGlobalParameter.GetMachineSettingsCakeParameters());
            AddColors(parameterKind.MaterialDeliquoring, fmGlobalParameter.GetMaterialDeliquoringParameters());
            AddColors(parameterKind.MachiningSettingsDeliquoring, fmGlobalParameter.GetMachineSettingsDeliquoringParameters());
        }

        private void FillListBox(IList listBoxItems, List<string> strings)
        {
            if (m_XYListKind == null)
            {
                InitXYParametersProperties();
            }

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

                    if (m_XYListKind.ContainsKey(strings[j]))
                    {
                        Color color = m_parameterKindProperties[m_XYListKind[strings[j]]].Color;
                        object item = listBoxItems[i];
                        if (item is ListViewItem)
                        {
                            var listViewItem = item as ListViewItem;
                            if (listViewItem.ListView.View == View.List)
                            {
                                listViewItem.ForeColor = Color.FromArgb(color.R, color.G, color.B);
                            }
                            else
                            {
                                Color lightColor = Color.FromArgb((color.R + 255) / 2, (color.G + 255) / 2, (color.B + 255) / 2);
                                listViewItem.BackColor = lightColor;
                            }
                        }
                    }
                }
            }
        }

        private void CreateColumnsInParametersTables()
        {
            var allSimParams = new List<fmGlobalParameter>();
            allSimParams.AddRange(fmGlobalParameter.GetMachineSettingsCakeParameters());
            allSimParams.AddRange(fmGlobalParameter.GetMachineSettingsDeliquoringParameters());

            foreach (fmGlobalParameter p in allSimParams)
            {
                {
                    DataGridViewColumn col = additionalParametersTable.AddColumn<fmDataGridViewNumericalTextBoxColumn>(p.Name);
                    col.Width = 50;
                }

                {
                    DataGridViewColumn col = selectedSimulationParametersTable.AddColumn<fmDataGridViewNumericalTextBoxColumn>(p.Name);
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
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.A.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.d0.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Dp.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.sf.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.sr.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.n.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.tc.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.tf.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.tr.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.hc_over_tf.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.dhc_over_dt.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.hc.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Mf.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Vf.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.mf.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.vf.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.ms.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.vs.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.msus.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.vsus.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.mc.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.vc.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Msus.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Vsus.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Vc.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Mc.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Ms.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Vs.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qf.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qf_i.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qs.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qs_i.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qc.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qc_i.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qsus.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qp.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmsus.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmsus_i.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qms.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qms_i.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmf.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmf_i.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmc.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmc_i.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qf.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qf_i.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qs.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qs_i.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qc.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qc_i.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qsus.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qp.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmsus.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmsus_i.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qms.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qms_i.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmf.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmf_i.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmc.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmc_i.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.eps.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.kappa.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Pc.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.rc.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.a.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.t1.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.h1.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.t1_over_tf.Name)],
                row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.h1_over_hc.Name)]);
            fmb.ValuesChangedByUser += fmb_ValuesChangedByUser;
            
            m_localInputParametersList.Add(new fmLocalInputParametersData(true, fmb));

            fmb.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.FilterMachiningCalculationOption);
            fmb.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.DeliquoringUsedCalculationOption);
            fmb.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.GasFlowrateUsedCalculationOption);
            fmb.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.EvaporationUsedCalculationOption);
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
                    int idx = GetColumnIndexByHeader(selectedSimulationParametersTable, param.Name);
                    if (idx != -1)
                    {
                        row.Cells[idx].Value = tempSim.parameters[param].value / param.UnitFamily.CurrentUnit.Coef;
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
                    filterMachiningCalculationOption = tempSim.filterMachiningCalculationOption,
                    deliquoringUsedCalculationOption = tempSim.deliquoringUsedCalculationOption,
                    gasFlowrateUsedCalculationOption = tempSim.gasFlowrateUsedCalculationOption,
                    evaporationUsedCalculationOption = tempSim.evaporationUsedCalculationOption
                };
                tempBlock.UpdateGroups();

                foreach (fmBlockVariableParameter param in tempBlock.Parameters)
                {
                    int idx = GetColumnIndexByHeader(selectedSimulationParametersTable, param.globalParameter.Name);
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
                    int idx = GetColumnIndexByHeader(selectedSimulationParametersTable, param.Name);
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
            var cakeFormationParameters =
                new List<fmGlobalParameter>(fmGlobalParameter.GetMachineSettingsCakeParameters());
            var deliquoringParameters =
                new List<fmGlobalParameter>(fmGlobalParameter.GetMachineSettingsDeliquoringParameters());
            var inputs = new List<fmGlobalParameter>();
            inputs.AddRange(cakeFormationParameters);
            inputs.AddRange(deliquoringParameters);

            foreach (DataGridViewColumn col in selectedSimulationParametersTable.Columns)
            {
                string parName = GetParameterNameFromHeader(col.HeaderText);
                if (fmGlobalParameter.ParametersByName.ContainsKey(parName))
                {
                    fmGlobalParameter par = fmGlobalParameter.ParametersByName[parName];
                    col.Visible = false;
                    if (inputs.Contains(par))
                    {
                        foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
                            if (simData.internalSimulationData.parameters.ContainsKey(par)
                                && simData.internalSimulationData.parameters[par] is fmCalculationVariableParameter
                                && ((fmCalculationVariableParameter)simData.internalSimulationData.parameters[par]).isInputed)
                            {
                                var fmb = new fmFilterMachiningBlock();
                                fmb.SetCalculationOptionAndRewriteData(simData.internalSimulationData.filterMachiningCalculationOption);
                                fmb.SetCalculationOptionAndRewriteData(simData.internalSimulationData.deliquoringUsedCalculationOption);
                                fmb.SetCalculationOptionAndRewriteData(simData.internalSimulationData.gasFlowrateUsedCalculationOption);
                                fmb.SetCalculationOptionAndRewriteData(simData.internalSimulationData.evaporationUsedCalculationOption);

                                var deliq = new fmDeliquoringSimualtionBlock();

                                fmBlockVariableParameter xParameter = null;
                                if (listBoxXAxis.SelectedItems.Count != 0)
                                {
                                    fmGlobalParameter p = fmGlobalParameter.ParametersByName[listBoxXAxis.SelectedItems[0].Text];
                                    xParameter = (cakeFormationParameters.Contains(p)
                                        ? (fmBaseBlock) fmb
                                        : (fmBaseBlock) deliq).GetParameterByName(p.Name);
                                }

                                fmBlockVariableParameter yParameter = null;
                                {
                                    fmGlobalParameter p = fmGlobalParameter.ParametersByName[parName];
                                    yParameter = (cakeFormationParameters.Contains(p)
                                        ? (fmBaseBlock) fmb
                                        : (fmBaseBlock) deliq).GetParameterByName(p.Name);
                                }
                                if (xParameter == null || yParameter == null || yParameter.group != xParameter.group)
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
            if (listBoxXAxis.SelectedItems.Count == 0)
                return;

            if (listBoxXAxis.SelectedItems[0].Text != "")
                UpdateIsInputed(fmGlobalParameter.ParametersByName[listBoxXAxis.SelectedItems[0].Text]);
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
				// we shouldn't change input parameter by force
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
                    simData.internalSimulationData.deliquoringUsedCalculationOption = simData.externalSimulation.DeliquoringUsedCalculationOption;
                    simData.internalSimulationData.gasFlowrateUsedCalculationOption = simData.externalSimulation.GasFlowrateUsedCalculationOption;
                    simData.internalSimulationData.evaporationUsedCalculationOption = simData.externalSimulation.EvaporationUsedCalculationOption;
                    simData.internalSimulationData.hcdEpsdCalculationOption = simData.externalSimulation.HcdEpsdCalculationOption;
                    simData.internalSimulationData.dpdInputCalculationOption = simData.externalSimulation.DpdInputCalculationOption;
                    simData.internalSimulationData.rhoDCalculationOption = simData.externalSimulation.RhoDetaDCalculationOption;
                    simData.internalSimulationData.PcDCalculationOption = simData.externalSimulation.PcDCalculationOption;
                    simData.internalSimulationData.suspensionCalculationOption = simData.externalSimulation.SuspensionCalculationOption;
                    simData.internalSimulationData.UpdateIsInputed(inputedParameter);
                }
            }
        }

        private void LoadCurrentXRange()
        {
            if (listBoxXAxis.SelectedItems.Count == 0 || listBoxXAxis.SelectedItems[0].Text == "")
                return;

            fmGlobalParameter xParameter = fmGlobalParameter.ParametersByName[listBoxXAxis.SelectedItems[0].Text];
            double coef = xParameter.UnitFamily.CurrentUnit.Coef;
            fmRange range = xParameter.SpecifiedRange;
            minXValueTextBox.Text = new fmValue(range.MinValue / coef).ToString();
            maxXValueTextBox.Text = new fmValue(range.MaxValue / coef).ToString();
        }

        // ReSharper disable InconsistentNaming
        private void buttonAddRow_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            AddRow();
            UpdateVisibilityOfColumnsInLocalParametrsTable();

            additionalParametersTable.AutoResizeColumnHeadersHeight();
            
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
            if (listBoxXAxis.SelectedItems[0].Text != "")
                UpdateIsInputed(fmGlobalParameter.ParametersByName[listBoxXAxis.SelectedItems[0].Text]);
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
                if (fmGlobalParameter.ParametersByName.ContainsKey(parName))
                {
                    fmGlobalParameter p = fmGlobalParameter.ParametersByName[parName];
                    col.HeaderText = p.Name + @" (" + p.UnitName + @")";
                }
            }

            foreach (DataGridViewColumn col in selectedSimulationParametersTable.Columns)
            {
                string parName = GetParameterNameFromHeader(col.HeaderText);
                if (fmGlobalParameter.ParametersByName.ContainsKey(parName))
                {
                    fmGlobalParameter p = fmGlobalParameter.ParametersByName[parName];
                    col.HeaderText = p.Name + @" (" + p.UnitName + @")";
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
            if (listBoxXAxis.SelectedItems.Count != 0 && listBoxXAxis.SelectedItems[0].Text != "")
                UpdateIsInputed(fmGlobalParameter.ParametersByName[listBoxXAxis.SelectedItems[0].Text]);
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void UpdateVisibilityOfColumnsInLocalParametrsTable()
        {
            var possibleInputs = new List<fmGlobalParameter>();
            foreach (fmLocalInputParametersData localParameters in m_localInputParametersList)
            {
                possibleInputs = ParametersListsUnion(possibleInputs, fmCalculationOptionHelper.GetParametersListThatCanBeInput(localParameters.filterMachiningBlock.filterMachiningCalculationOption));
            }
            var displayInputs = new List<fmGlobalParameter>();
            foreach (fmGlobalParameter p in possibleInputs)
            {
                bool isInput = false;
                foreach (fmLocalInputParametersData localParameters in m_localInputParametersList)
                {
                    fmBlockVariableParameter blockPar = localParameters.filterMachiningBlock.GetParameterByName(p.Name);
                    if (blockPar.isInputed)
                    {
                        isInput = true;
                        break;
                    }
                }
                if (isInput)
                {
                    displayInputs.Add(p);
                }
            }

            foreach (DataGridViewColumn col in additionalParametersTable.Columns)
            {
                string parName = GetParameterNameFromHeader(col.HeaderText);
                if (fmGlobalParameter.ParametersByName.ContainsKey(parName))
                {
                    col.Visible = displayInputs.Contains(fmGlobalParameter.ParametersByName[parName]);
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
                string parameterNameAndUnits = m_displayingResults.XParameter.Parameter.Name + " (" + m_displayingResults.XParameter.Parameter.UnitName + ")";
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
                foreach (fmDisplayingArray dispArray in yArrays.Arrays)
                {
                    ++yCol;
                    if (coordinatesGrid.Columns.Count > yCol)
                    {
                        coordinatesGrid.Columns[yCol].HeaderText = dispArray.GetTextForHeader();
                        if (dispArray.OwningSimulation == m_externalCurrentActiveSimulation.Data)
                        {
                            coordinatesGrid.Columns[yCol].HeaderText = "* " + coordinatesGrid.Columns[yCol].HeaderText;
                        }
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
                    LineItem curve = fmZedGraphControl1.GraphPane.AddCurve(dispArray.Parameter.Name + scaleString + " (" + dispArray.Parameter.UnitName + ")",
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
            fmZedGraphControl1.GraphPane.XAxis.Title.Text = xParameter.Name + " (" + xParameter.UnitName + ")";
            fmZedGraphControl1.GraphPane.Legend.IsVisible = false;
            fmZedGraphControl1.GraphPane.Y2Axis.IsVisible = false;

            if (m_displayingResults.YParameters.Count == 1)
            {
                fmGlobalParameter yParameter = m_displayingResults.YParameters[0].Parameter;
                fmZedGraphControl1.GraphPane.YAxis.Title.Text = yParameter.Name + " (" + yParameter.UnitName + ")";
                if (m_displayingResults.YParameters[0].Arrays.Count > 0)
                {
                    fmZedGraphControl1.GraphPane.YAxis.Title.FontSpec.FontColor = m_displayingResults.YParameters[0].Arrays[0].Color;
                }
            }
            else if (m_displayingResults.YParameters.Count == 2 && !KeepAllInY1CheckBox.Checked)
            {
                fmZedGraphControl1.GraphPane.Y2Axis.IsVisible = true;

                fmGlobalParameter y1Parameter = m_displayingResults.YParameters[0].Parameter;
                fmGlobalParameter y2Parameter = m_displayingResults.YParameters[1].Parameter;
                fmZedGraphControl1.GraphPane.YAxis.Title.Text = y1Parameter.Name + " (" + y1Parameter.UnitName + ")";
                if (m_displayingResults.YParameters[0].Arrays.Count > 0)
                {
                    fmZedGraphControl1.GraphPane.YAxis.Title.FontSpec.FontColor = m_displayingResults.YParameters[0].Arrays[0].Color;
                }

                fmZedGraphControl1.GraphPane.Y2Axis.Title.Text = y2Parameter.Name + " (" + y2Parameter.UnitName + ")";
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
            if (listBoxXAxis.SelectedItems.Count == 0 ||  listBoxXAxis.SelectedItems[0].Text == "")
            {
                m_displayingResults.XParameter = null;
                m_displayingResults.YParameters = null;
                return;
            }

            fmGlobalParameter xParameter = fmGlobalParameter.ParametersByName[listBoxXAxis.SelectedItems[0].Text];
            var yParameters = new List<fmGlobalParameter>();
            foreach (ListViewItem item in listBoxYAxis.CheckedItems)
            {
                yParameters.Add(fmGlobalParameter.ParametersByName[item.Text]);
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

                var xArray = new fmDisplayingArray
                                 {
                                     Parameter = xParameter,
                                     Values = new fmValue[m_internalSelectedSimList[0].calculatedDataList.Count]
                                 };
                m_displayingResults.XParameter = xArray;
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
                            OwningSimulation = simData.externalSimulation.Data,
                            Values = new fmValue[simData.calculatedDataList.Count],
                            Scale = (!NoScalingCheckBox.Checked && yParameters.Count > 2) ? degreeOffset[yParameter] : new fmValue(1),
                            IsY2Axis = colorId == 1 && (yParameters.Count == 2 && !KeepAllInY1CheckBox.Checked),
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
                                                 OwningSimulation = list.Count == 0 ? null : list[0],
                                                 Parameter = yParameter,
                                                 Values = new fmValue[pointsCount],
                                                 Scale =
                                                     (!NoScalingCheckBox.Checked && yParameters.Count > 2) ? degreeOffset[yParameter] : new fmValue(1),
                                                 IsY2Axis = colorId == 1 && (yParameters.Count == 2 && !KeepAllInY1CheckBox.Checked),
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
            if (listBoxXAxis.SelectedItems.Count == 0 || listBoxXAxis.SelectedItems[0].Text == "")
            {
                return;
            }

            fmGlobalParameter xParameter = fmGlobalParameter.ParametersByName[listBoxXAxis.SelectedItems[0].Text];

            if (!m_isUseLocalParams)
            {
                foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
                {
                    double xStart = fmValue.StringToValue(minXValueTextBox.Text).value;
                    double xEnd = fmValue.StringToValue(maxXValueTextBox.Text).value;

                    IEnumerable<double> xList = CreateXValues(xStart, xEnd, m_rowsQuantity);

                    simData.calculatedDataList = new List<fmFilterSimulationData>();

                    foreach (double x in xList)
                    {
                        var tempSim = new fmFilterSimulationData();
                        tempSim.CopyIsInputedFrom(simData.internalSimulationData);
                        tempSim.CopyValuesFrom(simData.externalSimulation.Data);
                        tempSim.parameters[xParameter].value = new fmValue(x * xParameter.UnitFamily.CurrentUnit.Coef);

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

                        bool isPlaneArea =
                            fmFilterMachiningCalculator.IsPlainAreaCalculationOption(
                                simData.internalSimulationData.filterMachiningCalculationOption);
                        bool isVacuumFilter =
                            fmFilterSimMachineType.IsVacuumFilter(simData.externalSimulation.Parent.MachineType);
                        double hcdCoefficient = fmFilterSimMachineType.GetHcdCoefficient(simData.externalSimulation.Parent.MachineType);

                        var eps0dNedEpsdCalculator = new fmEps0dNedEpsdCalculator(tempSim.parameters.Values);
                        eps0dNedEpsdCalculator.isPlainArea = isPlaneArea;
                        eps0dNedEpsdCalculator.DoCalculations();

                        var sigmaPke0PkePcdRcdAlphadCalculator = new fmSigmaPke0PkePcdRcdAlphadCalculator(tempSim.parameters.Values);
                        sigmaPke0PkePcdRcdAlphadCalculator.DoCalculations();

                        var deliquoringSimualtionCalculator =
                            new fmDeliquoringSimualtionCalculator(
                                new fmDeliquoringSimualtionCalculator.DeliquoringCalculatorOptions(isPlaneArea, isVacuumFilter, hcdCoefficient),
                                tempSim.parameters.Values);
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
                    fmFilterSimulation sim = m_externalCurrentActiveSimulation;
                    {
                        double xStart = fmValue.StringToValue(minXValueTextBox.Text).value;
                        double xEnd = fmValue.StringToValue(maxXValueTextBox.Text).value;

                        IEnumerable<double> xList = CreateXValues(xStart, xEnd, m_rowsQuantity);

                        var calculatedDataList = new List<fmFilterSimulationData>();

                        foreach (double x in xList)
                        {
                            var tempSim = new fmFilterSimulationData();
                            fmFilterSimulationData.CopyAllParametersFromBlockToSimulation(localParameters.filterMachiningBlock, tempSim);
                            tempSim.CopyMaterialParametersValuesFrom(sim.Data);
                            var xValue = new fmValue(x * xParameter.UnitFamily.CurrentUnit.Coef);
                            tempSim.parameters[xParameter].value = xValue;

                            var filterMachiningCalculator = new fmFilterMachiningCalculator(tempSim.parameters.Values)
                            {
                                calculationOption =
                                    localParameters.filterMachiningBlock.
                                    filterMachiningCalculationOption
                            };
                            filterMachiningCalculator.DoCalculations();

                            // after calculation the x parameter may be restored if it wasn't input
                            tempSim.parameters[xParameter].value = xValue;

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
            if (m_XYListKind == null)
            {
                InitXYParametersProperties();
            }

            var inputNames = new List<string>();

            IEnumerable<fmGlobalParameter> simInputParameters = GetCommonInputParametersList();

            foreach (fmGlobalParameter p in simInputParameters)
            {
                CheckBox paramsCheckbox = m_parameterKindProperties[m_XYListKind[p.Name]].Checkbox;
                if (paramsCheckbox == null || paramsCheckbox.Checked)
                {
                    inputNames.Add(p.Name);
                }
            }

            FillListBox(listBoxXAxis.Items, inputNames);
            if (listBoxXAxis.SelectedItems.Count == 0 && inputNames.Contains(fmGlobalParameter.tf.Name))
            {
                foreach (ListViewItem item in listBoxXAxis.Items)
                {
                    item.Selected = item.Text == fmGlobalParameter.tf.Name;
                }
            }

            var outputNames = new List<string>();

            foreach (fmGlobalParameter p in fmGlobalParameter.Parameters)
            {
                if (ParametersToDisplay.ParametersList.Contains(p))
                {
                    CheckBox paramsCheckbox = m_parameterKindProperties[m_XYListKind[p.Name]].Checkbox;
                    if (paramsCheckbox == null || paramsCheckbox.Checked)
                    {
                        outputNames.Add(p.Name);
                    }
                }
            }

            FillListBox(listBoxYAxis.Items, outputNames);

            if (listBoxYAxis.CheckedItems.Count == 0)
            {
                if (outputNames.Contains(fmGlobalParameter.hc.Name))
                {
                    listBoxYAxis.Items[outputNames.IndexOf(fmGlobalParameter.hc.Name)].Checked = true;
                }
            }
        }

        private IEnumerable<fmGlobalParameter> GetCommonInputParametersList()
        {
            if (!m_isUseLocalParams)
            {
                var simInputParameters = new List<fmGlobalParameter>(fmGlobalParameter.Parameters);
                foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
                    //if (simData.isChecked)
                    simInputParameters = ParametersListsIntersection(simInputParameters,
                                                                     simData.internalSimulationData.
                                                                         GetParametersThatCanBeInputedList());
                return simInputParameters;
            }
            else
            {
                var simInputParameters = new List<fmGlobalParameter>(fmGlobalParameter.Parameters);
                foreach (fmLocalInputParametersData localParameters in m_localInputParametersList)
                    simInputParameters = ParametersListsIntersection(simInputParameters,
                                                              fmCalculationOptionHelper.GetParametersListThatCanBeInput(
                                                                  localParameters.filterMachiningBlock.filterMachiningCalculationOption));
                return simInputParameters;
            }
        }

        private static List<fmGlobalParameter> ParametersListsIntersection(List<fmGlobalParameter> a, List<fmGlobalParameter> b)
        {
            var result = new List<fmGlobalParameter>();
            foreach (fmGlobalParameter p in fmGlobalParameter.Parameters)
                if (a.Contains(p) && b.Contains(p))
                    result.Add(p);
            return result;
        }

        private static List<fmGlobalParameter> ParametersListsUnion(List<fmGlobalParameter> a, List<fmGlobalParameter> b)
        {
            var result = new List<fmGlobalParameter>();
            foreach (fmGlobalParameter p in fmGlobalParameter.Parameters)
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
