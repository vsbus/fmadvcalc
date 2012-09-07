using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            if (OwningSimulation != null
                && OwningSimulation.name != null
                && OwningSimulation.name != "")
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
        public bool IsChecked;
        public bool IsCurrentActive;
        public fmFilterSimulation ExternalSimulation;
        public fmFilterSimulationData InternalSimulationData;
        public List<fmFilterSimulationData> CalculatedDataList = new List<fmFilterSimulationData>();
        public fmSelectedSimulationData(bool isChecked, fmFilterSimulation externalSimulation)
        {
            IsChecked = isChecked;
            IsCurrentActive = false;
            ExternalSimulation = externalSimulation;
            InternalSimulationData = new fmFilterSimulationData();
            InternalSimulationData.CopyFrom(externalSimulation.Data);
        }
    }
    public class fmLocalInputParametersData
    {
        public bool IsChecked;
        public bool IsCurrentActive;
        public fmFilterMachiningBlock FilterMachiningBlock;
        public fmDeliquoringSimualtionBlock DeliquoringBlock;
        public List<List<fmFilterSimulationData>> CalculatedDataLists = new List<List<fmFilterSimulationData>>();
        public fmLocalInputParametersData(bool isChecked, fmFilterMachiningBlock filterMachiningBlock, fmDeliquoringSimualtionBlock deliquoringBlock)
        {
            IsChecked = isChecked;
            IsCurrentActive = false;
            FilterMachiningBlock = filterMachiningBlock;
            DeliquoringBlock = deliquoringBlock;
        }

        internal List<fmGlobalParameter> GetParametersThatCanBeInput()
        {
            List<fmGlobalParameter> result = fmCalculationOptionHelper.GetParametersListThatCanBeInput(
                FilterMachiningBlock.filterMachiningCalculationOption);

            foreach (fmBlockVariableParameter varPar in DeliquoringBlock.Parameters)
            {
                if (varPar.isInputed || varPar.group != null)
                {
                    result.Add(varPar.globalParameter);
                }
            }

            return result;
        }

        internal fmBlockVariableParameter GetParameterBlock(fmGlobalParameter p)
        {
            fmBlockVariableParameter blockPar = null;
            if (blockPar == null)
            {
                blockPar = FilterMachiningBlock.GetParameterByName(p.Name);
            }
            if (blockPar == null)
            {
                blockPar = DeliquoringBlock.GetParameterByName(p.Name);
            }
            return blockPar;

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

        private enum fmParameterKind
        {
            MaterialCakeFormation,
            MachiningSettingsCakeFormation,
            MaterialDeliquoring,
            MachiningSettingsDeliquoring
        }

        struct fmParameterKindProperties
        {
            public Color Color { get; set; }
            public CheckBox Checkbox { get; set; }
        }

        private Dictionary<string, fmParameterKind> m_xyListKind;

        private Dictionary<fmParameterKind, fmParameterKindProperties> m_parameterKindProperties;

        void AddColors(fmParameterKind kind, IEnumerable<fmGlobalParameter> parameters)
        {
            foreach (fmGlobalParameter p in parameters)
            {
                m_xyListKind.Add(p.Name, kind);
            }
        }

        void InitXyParametersProperties()
        {
            m_parameterKindProperties = new Dictionary<fmParameterKind, fmParameterKindProperties>
                                            {
                                                {
                                                    fmParameterKind.MaterialCakeFormation,
                                                    new fmParameterKindProperties
                                                        {
                                                            Color = Color.Green,
                                                            Checkbox = cakeFormationMaterilParametersCheckBox
                                                        }
                                                    },
                                                {
                                                    fmParameterKind.MachiningSettingsCakeFormation,
                                                    new fmParameterKindProperties
                                                        {
                                                            Color = Color.BlueViolet,
                                                            Checkbox = cakeFormationMachininglParametersCheckBox
                                                        }
                                                    },
                                                {
                                                    fmParameterKind.MaterialDeliquoring,
                                                    new fmParameterKindProperties
                                                        {
                                                            Color = Color.Coral,
                                                            Checkbox = deliquoringMaterilParametersCheckBox
                                                        }
                                                    },
                                                {
                                                    fmParameterKind.MachiningSettingsDeliquoring,
                                                    new fmParameterKindProperties
                                                        {
                                                            Color = Color.IndianRed,
                                                            Checkbox = deliquoringMachininglParametersCheckBox
                                                        }
                                                    }
                                            };


            m_xyListKind = new Dictionary<string, fmParameterKind>();

            AddColors(fmParameterKind.MaterialCakeFormation, fmGlobalParameter.GetCakeFormationMaterialParameters());
            AddColors(fmParameterKind.MachiningSettingsCakeFormation, fmGlobalParameter.GetCakeFormationSettingParameters());
            AddColors(fmParameterKind.MaterialDeliquoring, fmGlobalParameter.GetDeliquoringMaterialParameters());
            AddColors(fmParameterKind.MachiningSettingsDeliquoring, fmGlobalParameter.GetDeliquoringSettingParameters());
        }

        private void FillListBox(IList listBoxItems, List<string> strings)
        {
            if (m_xyListKind == null)
            {
                InitXyParametersProperties();
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

                    if (m_xyListKind.ContainsKey(strings[j]))
                    {
                        Color color = m_parameterKindProperties[m_xyListKind[strings[j]]].Color;
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
            allSimParams.AddRange(fmGlobalParameter.GetCakeFormationSettingParameters());
            allSimParams.AddRange(fmGlobalParameter.GetDeliquoringSettingParameters());

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
            fmb.ValuesChangedByUser += fmb_deliq_ValuesChangedByUser;
            fmb.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.FilterMachiningCalculationOption);
            fmb.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.DeliquoringUsedCalculationOption);
            fmb.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.GasFlowrateUsedCalculationOption);
            fmb.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.EvaporationUsedCalculationOption);
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(m_externalCurrentActiveSimulation, fmb);

            var deliqBlock = new fmDeliquoringSimualtionBlock();
            deliqBlock.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.DeliquoringUsedCalculationOption);
            foreach (var p in deliqBlock.Parameters)
            {
                deliqBlock.AssignCell(p, row.Cells[GetColumnIndexByHeader(additionalParametersTable, p.globalParameter.Name)]);
            }

            deliqBlock.ValuesChangedByUser += fmb_deliq_ValuesChangedByUser;
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(m_externalCurrentActiveSimulation, deliqBlock);
            
            m_localInputParametersList.Add(new fmLocalInputParametersData(true, fmb, deliqBlock));

            fmb.CalculateAndDisplay();

            bool isPlainArea = fmFilterMachiningCalculator.IsPlainAreaCalculationOption(m_externalCurrentActiveSimulation.FilterMachiningCalculationOption);
            bool isVacuumFilter = fmFilterSimMachineType.IsVacuumFilter(m_externalCurrentActiveSimulation.Parent.MachineType);
            double hcdCoefficient = fmFilterSimMachineType.GetHcdCoefficient(m_externalCurrentActiveSimulation.Parent.MachineType);
            deliqBlock.deliquoringCalculatorOptions = new fmDeliquoringSimualtionCalculator.DeliquoringCalculatorOptions(isPlainArea, isVacuumFilter, hcdCoefficient);
            deliqBlock.CalculateAndDisplay();

            foreach (fmLocalInputParametersData localInputParametersData in m_localInputParametersList)
            {
                localInputParametersData.FilterMachiningBlock.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.FilterMachiningCalculationOption);
                localInputParametersData.FilterMachiningBlock.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.DeliquoringUsedCalculationOption);
                localInputParametersData.FilterMachiningBlock.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.GasFlowrateUsedCalculationOption);
                localInputParametersData.FilterMachiningBlock.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.EvaporationUsedCalculationOption);
                localInputParametersData.FilterMachiningBlock.CalculateAndDisplay();

                localInputParametersData.DeliquoringBlock.deliquoringCalculatorOptions = new fmDeliquoringSimualtionCalculator.DeliquoringCalculatorOptions(isPlainArea, isVacuumFilter, hcdCoefficient);
                localInputParametersData.DeliquoringBlock.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.DeliquoringUsedCalculationOption);
                localInputParametersData.DeliquoringBlock.CalculateAndDisplay();
            }
        }

        // ReSharper disable InconsistentNaming
        void fmb_deliq_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
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

            foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
            {
                fmFilterSimulationData tempSim = simData.InternalSimulationData;

                DataGridViewRow row =
                    selectedSimulationParametersTable.Rows[selectedSimulationParametersTable.Rows.Add()];
                row.Cells["SelectedSimulationParametersCheckBoxColumn"].Value = simData.IsChecked;

                foreach (fmGlobalParameter param in tempSim.parameters.Keys)
                {
                    int idx = GetColumnIndexByHeader(selectedSimulationParametersTable, param.Name);
                    if (idx != -1)
                    {
                        row.Cells[idx].Value = tempSim.parameters[param].value / param.UnitFamily.CurrentUnit.Coef;
                    }
                }

                if (m_externalCurrentActiveSimulation == simData.ExternalSimulation)
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
                fmFilterSimulationData tempSim = m_internalSelectedSimList[i].InternalSimulationData;
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
                fmFilterSimulationData tempSim = m_internalSelectedSimList[i].InternalSimulationData;
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
                        else if (row.Cells[idx].Value != null && row.Cells[idx].Value.ToString() == "-")
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
                new List<fmGlobalParameter>(fmGlobalParameter.GetCakeFormationSettingParameters());
            var deliquoringParameters =
                new List<fmGlobalParameter>(fmGlobalParameter.GetDeliquoringSettingParameters());
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
                            if (simData.InternalSimulationData.parameters.ContainsKey(par)
                                && simData.InternalSimulationData.parameters[par] is fmCalculationVariableParameter
                                && ((fmCalculationVariableParameter)simData.InternalSimulationData.parameters[par]).isInputed)
                            {
                                var fmb = new fmFilterMachiningBlock();
                                fmb.SetCalculationOptionAndRewriteData(simData.InternalSimulationData.filterMachiningCalculationOption);
                                fmb.SetCalculationOptionAndRewriteData(simData.InternalSimulationData.deliquoringUsedCalculationOption);
                                fmb.SetCalculationOptionAndRewriteData(simData.InternalSimulationData.gasFlowrateUsedCalculationOption);
                                fmb.SetCalculationOptionAndRewriteData(simData.InternalSimulationData.evaporationUsedCalculationOption);

                                var deliq = new fmDeliquoringSimualtionBlock();
                                deliq.SetCalculationOptionAndRewriteData(simData.InternalSimulationData.deliquoringUsedCalculationOption);

                                fmBlockVariableParameter xParameter = null;
                                if (listBoxXAxis.SelectedItems.Count != 0)
                                {
                                    fmGlobalParameter p = GetCurrentXAxisParameter();
                                    xParameter = (cakeFormationParameters.Contains(p)
                                        ? fmb
                                        : (fmBaseBlock) deliq).GetParameterByName(p.Name);
                                }

                                fmBlockVariableParameter yParameter;
                                {
                                    fmGlobalParameter p = fmGlobalParameter.ParametersByName[parName];
                                    yParameter = (cakeFormationParameters.Contains(p)
                                        ? fmb
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

        private void ListBoxXSelectedIndexChanged(object sender, EventArgs e)
        {
            SetXAxisParameterAsInputed();
        }

        private void SetXAxisParameterAsInputed()
        {
            if (listBoxXAxis.SelectedItems.Count == 0)
                return;

            if (listBoxXAxis.SelectedItems[0].Text != "")
                UpdateIsInputed(GetCurrentXAxisParameter());

            xRangeLabel.Text = @"Ranges (X-Parameter: " + listBoxXAxis.SelectedItems[0].Text + @")";

            BindForeColorToSelectedSimulationsTable();
            UpdateVisibilityOfColumnsInSelectedSimulationsTable();
            UpdateVisibilityOfColumnsInLocalParametrsTable();
            m_involvedSeries = new Dictionary<fmFilterSimSerie, fmRange>();
            LoadCurrentXRange();
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void UpdateIsInputed(fmGlobalParameter inputedParameter)
        {
            if (!m_isUseLocalParams)
            {
                foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
                {
                    //foreach (var p in simData.ExternalSimulation.Parameters.Values)
                    //{
                    //    if (p is fmCalculationVariableParameter)
                    //    {
                    //        ((fmCalculationVariableParameter)simData.InternalSimulationData.parameters[p.globalParameter]).isInputed = ((fmCalculationVariableParameter)p).isInputed;
                    //    }
                    //}
                    simData.InternalSimulationData.filterMachiningCalculationOption = simData.ExternalSimulation.FilterMachiningCalculationOption;
                    simData.InternalSimulationData.deliquoringUsedCalculationOption = simData.ExternalSimulation.DeliquoringUsedCalculationOption;
                    simData.InternalSimulationData.gasFlowrateUsedCalculationOption = simData.ExternalSimulation.GasFlowrateUsedCalculationOption;
                    simData.InternalSimulationData.evaporationUsedCalculationOption = simData.ExternalSimulation.EvaporationUsedCalculationOption;
                    simData.InternalSimulationData.hcdEpsdCalculationOption = simData.ExternalSimulation.HcdEpsdCalculationOption;
                    simData.InternalSimulationData.dpdInputCalculationOption = simData.ExternalSimulation.DpdInputCalculationOption;
                    simData.InternalSimulationData.rhoDCalculationOption = simData.ExternalSimulation.RhoDetaDCalculationOption;
                    simData.InternalSimulationData.PcDCalculationOption = simData.ExternalSimulation.PcDCalculationOption;
                    simData.InternalSimulationData.suspensionCalculationOption = simData.ExternalSimulation.SuspensionCalculationOption;
                    simData.InternalSimulationData.UpdateIsInputed(inputedParameter);
                }
            }
        }

        private Dictionary<fmFilterSimSerie, fmRange> m_involvedSeries;
        private Dictionary<DataGridViewRow, fmFilterSimSerie> m_involvedSerieFromRow;

        private void LoadCurrentXRange()
        {
            if (listBoxXAxis.SelectedItems.Count == 0 || listBoxXAxis.SelectedItems[0].Text == "")
                return;

            fmGlobalParameter xParameter = GetCurrentXAxisParameter();

            var newInvolvedSeries = new Dictionary<fmFilterSimSerie, fmRange>();
            if (!m_isUseLocalParams)
            {
                foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
                {
                    fmFilterSimSerie serie = simData.ExternalSimulation.Parent;
                    AddSerieToInvolvedSeriesList(newInvolvedSeries, serie, xParameter);
                }
            }
            else
            {
                fmFilterSimSerie serie = m_externalCurrentActiveSimulation.Parent;
                AddSerieToInvolvedSeriesList(newInvolvedSeries, serie, xParameter);
            }

            m_involvedSerieFromRow = new Dictionary<DataGridViewRow, fmFilterSimSerie>();
            InvolvedSeriesDataGrid.Rows.Clear();
            var justSeries = new List<fmFilterSimSerie>(newInvolvedSeries.Keys);
            foreach (fmFilterSimSerie serie in justSeries)
            {
                var strings = new string[3];
                strings[0] = serie.GetName();
                
                if (m_involvedSeries.ContainsKey(serie))
                {
                    newInvolvedSeries[serie] = m_involvedSeries[serie];
                }

                var coef = new fmValue(xParameter.UnitFamily.CurrentUnit.Coef);
                strings[1] = (newInvolvedSeries[serie].MinValue / coef).ToString();
                strings[2] = (newInvolvedSeries[serie].MaxValue / coef).ToString();

                int rowIdx = InvolvedSeriesDataGrid.Rows.Add(strings);
                m_involvedSerieFromRow[InvolvedSeriesDataGrid.Rows[rowIdx]] = serie;
            }

            m_involvedSeries = newInvolvedSeries;
        }

        private void AddSerieToInvolvedSeriesList(Dictionary<fmFilterSimSerie, fmRange> newInvolvedSeries, fmFilterSimSerie serie, fmGlobalParameter xParameter)
        {
            if (!newInvolvedSeries.ContainsKey(serie) && serie.Ranges.Ranges.ContainsKey(xParameter))
            {
                newInvolvedSeries.Add(serie,
                                      new fmRange(serie.Ranges.Ranges[xParameter].MinValue,
                                                  serie.Ranges.Ranges[xParameter].MaxValue));
            }
        }

        // ReSharper disable InconsistentNaming
        private void buttonAddRow_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            AddRow();
            UpdateDiagramAfterLocalParametersRowsChanged();
        }

        private void UpdateDiagramAfterLocalParametersRowsChanged()
        {
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
                UpdateIsInputed(GetCurrentXAxisParameter());
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void ReadUseParamsCheckBoxAndApply()
        {
            m_isUseLocalParams = UseParamsCheckBox.Checked;
            additionalParametersTable.Visible = m_isUseLocalParams;
            if (additionalParametersTable.Visible && additionalParametersTable.Rows.Count == 0)
            {
                buttonAddRow_Click(null, new EventArgs());
            }
            buttonAddRow.Visible = m_isUseLocalParams;
            buttonDeleteRow.Visible = m_isUseLocalParams;
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
                    m_internalSelectedSimList[i].IsCurrentActive = i == currentRowIndex;
                }
            }
            else
            {
                for (int i = 0; i < m_localInputParametersList.Count; ++i)
                {
                    m_localInputParametersList[i].IsCurrentActive = i == currentRowIndex;
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
                m_internalSelectedSimList[e.RowIndex].IsChecked = (bool)selectedSimulationParametersTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
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
                m_localInputParametersList[e.RowIndex].IsChecked = (bool)additionalParametersTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
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
                UpdateIsInputed(GetCurrentXAxisParameter());
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void UpdateVisibilityOfColumnsInLocalParametrsTable()
        {
            if (m_localInputParametersList.Count == 0)
            {
                return;
            }

            foreach (fmLocalInputParametersData localInputParametersData in m_localInputParametersList)
            {
                bool isFirstElement = localInputParametersData == m_localInputParametersList[0];

                localInputParametersData.FilterMachiningBlock.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.FilterMachiningCalculationOption);
                localInputParametersData.FilterMachiningBlock.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.DeliquoringUsedCalculationOption);
                localInputParametersData.FilterMachiningBlock.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.GasFlowrateUsedCalculationOption);
                localInputParametersData.FilterMachiningBlock.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.EvaporationUsedCalculationOption);
                foreach (fmCalculationBaseParameter parameter in localInputParametersData.FilterMachiningBlock.AllParameters)
                {
                    var parameterInSimulation =
                            (fmCalculationVariableParameter)
                            m_externalCurrentActiveSimulation.Parameters[parameter.globalParameter];
                    if (parameter is fmBlockVariableParameter)
                    {
                        ((fmBlockVariableParameter)parameter).isInputed = parameterInSimulation.isInputed;
                    }
                    if (isFirstElement)
                    {
                        parameter.value = parameterInSimulation.value;
                    }
                }
                localInputParametersData.FilterMachiningBlock.CalculateAndDisplay();

                bool isPlainArea = fmFilterMachiningCalculator.IsPlainAreaCalculationOption(m_externalCurrentActiveSimulation.FilterMachiningCalculationOption);
                bool isVacuumFilter = fmFilterSimMachineType.IsVacuumFilter(m_externalCurrentActiveSimulation.Parent.MachineType);
                double hcdCoefficient = fmFilterSimMachineType.GetHcdCoefficient(m_externalCurrentActiveSimulation.Parent.MachineType);
                localInputParametersData.DeliquoringBlock.deliquoringCalculatorOptions = new fmDeliquoringSimualtionCalculator.DeliquoringCalculatorOptions(isPlainArea, isVacuumFilter, hcdCoefficient);
                localInputParametersData.DeliquoringBlock.SetCalculationOptionAndRewriteData(m_externalCurrentActiveSimulation.DeliquoringUsedCalculationOption);
                foreach (fmCalculationBaseParameter parameter in localInputParametersData.DeliquoringBlock.AllParameters)
                {
                    var parameterInSimulation =
                        (fmCalculationVariableParameter)
                        m_externalCurrentActiveSimulation.Parameters[parameter.globalParameter];
                    if (parameter is fmBlockVariableParameter)
                    {
                        ((fmBlockVariableParameter)parameter).isInputed = parameterInSimulation.isInputed;
                    }
                    if (isFirstElement)
                    {
                        parameter.value = parameterInSimulation.value;
                    }
                }
                localInputParametersData.DeliquoringBlock.CalculateAndDisplay();
            }
            
            foreach (DataGridViewCell cell in additionalParametersTable.Rows[0].Cells)
            {
                cell.ReadOnly = true;
            }

            var possibleInputs = new List<fmGlobalParameter>();
            possibleInputs = m_localInputParametersList.Aggregate(
                possibleInputs,
                (current, localParameters) => ParametersListsUnion(current, localParameters.GetParametersThatCanBeInput()));
            var displayInputs = new List<fmGlobalParameter>();
            fmGlobalParameter xParameter = GetCurrentXAxisParameter();
            fmBlockVariableParameter xBlockPar = m_localInputParametersList[0].GetParameterBlock(xParameter);
            fmBlockParameterGroup xGroup = xBlockPar.group;
            foreach (fmGlobalParameter p in possibleInputs)
            {
                // we don't display x-parameter
                if (xGroup == m_localInputParametersList[0].GetParameterBlock(p).group)
                    continue;

                bool isInput = false;
                foreach (fmLocalInputParametersData localParameters in m_localInputParametersList)
                {
                    fmBlockVariableParameter blockPar = localParameters.GetParameterBlock(p);
                    if (blockPar.isInputed && blockPar.group != null && blockPar.group != xGroup)
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
                coordinatesGrid.ColumnCount += m_displayingResults.YParameters[i].Arrays.Count;
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
                        Color color = Color.Black;

                        bool isCurrentSelectedCurve = dispArray.OwningSimulation == m_internalSelectedSimList[selectedSimulationParametersTable.CurrentCell.RowIndex].InternalSimulationData
                            || (additionalParametersTable.CurrentCell != null
                                && dispArray.OwningSimulation == m_localInputParametersList[additionalParametersTable.CurrentCell.RowIndex].CalculatedDataLists[0][0]);
                        if (selectedSimulationParametersTable.CurrentCell != null
                            && isCurrentSelectedCurve)
                        {
                            color = Color.Blue;
                        }
                        coordinatesGrid.Columns[yCol].ReadOnly = true;
                        coordinatesGrid.Columns[yCol].Width = 50;

                        if (dispArray.Values.Length == coordinatesGrid.RowCount)
                        {
                            for (int i = 0; i < coordinatesGrid.RowCount; ++i)
                            {
                                coordinatesGrid[yCol, i].Value = dispArray.Values[i];
                                coordinatesGrid[yCol, i].Style.ForeColor = color;
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
                    if (m_displayingResults.XParameter.Values.Length != dispArray.Values.Length)
                        continue;

                    string scaleString = dispArray.Scale.value == 1 ? "" : " * " + (1 / dispArray.Scale);
                    IEnumerable<KeyValuePair<double[], double[]>> curvesData = GetCurvesDoubleArrays(m_displayingResults.XParameter, dispArray);
                    foreach (KeyValuePair<double[], double[]> pair in curvesData)
                    {
                        LineItem curve = fmZedGraphControl1.GraphPane.AddCurve(dispArray.Parameter.Name + scaleString + " (" + dispArray.Parameter.UnitName + ")",
                            pair.Key, pair.Value, dispArray.Color, SymbolType.None);
                        curve.Line.IsAntiAlias = true;
                        curve.Line.Width = dispArray.Bold ? 2 : 1;
                        curve.IsY2Axis = dispArray.IsY2Axis;
                    }
                }
            }

            fmGlobalParameter xParameter = m_displayingResults.XParameter.Parameter;
            fmZedGraphControl1.GraphPane.XAxis.Title.Text = xParameter.Name + " (" + xParameter.UnitName + ")";
            fmZedGraphControl1.GraphPane.Legend.IsVisible = false;
            fmZedGraphControl1.GraphPane.Y2Axis.IsVisible = false;
            fmZedGraphControl1.IsAntiAlias = true;

            bool isY2Involved = false;
            foreach (fmDisplayingYListOfArrays yList in m_displayingResults.YParameters)
            {
                isY2Involved = yList.Arrays.Any(displayingArray => displayingArray.IsY2Axis);
                if (isY2Involved)
                {
                    break;
                }
            }

            if (startFromOriginCheckBox.Checked)
            {
                fmZedGraphControl1.GraphPane.YAxis.Scale.Min = 0;
                fmZedGraphControl1.GraphPane.YAxis.Scale.MinAuto = false;
                fmZedGraphControl1.GraphPane.Y2Axis.Scale.Min = 0;
                fmZedGraphControl1.GraphPane.Y2Axis.Scale.MinAuto = false;
            }
            else
            {
                fmZedGraphControl1.GraphPane.YAxis.Scale.MinAuto = true;
                fmZedGraphControl1.GraphPane.Y2Axis.Scale.MinAuto = true;
            }

            fmZedGraphControl1.GraphPane.XAxis.Type = xLogCheckBox.Checked ? AxisType.Log : AxisType.Linear;
            fmZedGraphControl1.GraphPane.YAxis.Type = yLogCheckBox.Checked ? AxisType.Log : AxisType.Linear;
            fmZedGraphControl1.GraphPane.Y2Axis.Type = y2LogCheckBox.Checked ? AxisType.Log : AxisType.Linear;

            if (isY2Involved)
            {
                fmZedGraphControl1.GraphPane.Y2Axis.IsVisible = true;
            }

            fmZedGraphControl1.GraphPane.YAxis.Title.Text = "";
            fmZedGraphControl1.GraphPane.Legend.IsVisible = true;

            fmZedGraphControl1.GraphPane.Title.Text = "";
            fmZedGraphControl1.GraphPane.AxisChange();
            fmZedGraphControl1.Refresh();
        }

        private static IEnumerable<KeyValuePair<double[], double[]>> GetCurvesDoubleArrays(fmDisplayingArray xArray, fmDisplayingArray yArray)
        {
            if (xArray.Values.Length != yArray.Values.Length)
            {
                throw new Exception("xArray and yArray have different sizes.");
            }

            var result = new List<KeyValuePair<double[], double[]>>();
            var curCurve = new List<KeyValuePair<double, double>>();
            for (int i = 0; i <= yArray.Values.Length; ++i)
            {
                if (i < yArray.Values.Length && yArray.Values[i].defined)
                {
                    curCurve.Add(new KeyValuePair<double, double>(xArray.Values[i].value, yArray.Values[i].value * yArray.Scale.value));
                }
                else
                {
                    if (curCurve.Count > 0)
                    {
                        var xarray = new double[curCurve.Count];
                        var yarray = new double[curCurve.Count];
                        for (int j = 0; j < curCurve.Count; ++j)
                        {
                            xarray[j] = curCurve[j].Key;
                            yarray[j] = curCurve[j].Value;
                        }
                        result.Add(new KeyValuePair<double[], double[]>(xarray, RemoveNoise(yarray)));
                    }
                    curCurve = new List<KeyValuePair<double, double>>();
                }
            }
            return result;
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

            fmGlobalParameter xParameter = GetCurrentXAxisParameter();
            var yParameters = (from ListViewItem item in listBoxYAxis.CheckedItems
                               select fmGlobalParameter.ParametersByName[item.Text]).ToList();

            var y2Parameters = (from ListViewItem item in listBoxY2Axis.CheckedItems
                               select fmGlobalParameter.ParametersByName[item.Text]).ToList();

            BindCalculatedResultsToDisplayingResults(xParameter, yParameters, y2Parameters);
        }
        private void BindCalculatedResultsToDisplayingResults(
            fmGlobalParameter xParameter,
            IEnumerable<fmGlobalParameter> yParameters,
            List<fmGlobalParameter> y2Parameters)
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
                                     Values = new fmValue[m_internalSelectedSimList[0].CalculatedDataList.Count]
                                 };
                m_displayingResults.XParameter = xArray;
                for (int i = 0; i < m_internalSelectedSimList[0].CalculatedDataList.Count; ++i)
                {
                    xArray.Values[i] =
                        m_internalSelectedSimList[0].CalculatedDataList[i].parameters[xParameter].ValueInUnits;
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
                        if (!simData.IsChecked)
                            continue;

                        var yArray = new fmDisplayingArray
                        {
                            Parameter = yParameter,
                            OwningSimulation = simData.InternalSimulationData,
                            Values = new fmValue[simData.CalculatedDataList.Count],
                            Scale = !NoScalingCheckBox.Checked ? degreeOffset[yParameter] : new fmValue(1),
                            IsY2Axis = y2Parameters.Contains(yParameter),
                            Color = colors[colorId],
                            Bold = selectedSimulationParametersTable.CurrentCell != null
                                   &&
                                   m_internalSelectedSimList.IndexOf(simData) ==
                                   selectedSimulationParametersTable.CurrentCell.RowIndex
                        };

                        for (int i = 0; i < simData.CalculatedDataList.Count; ++i)
                        {
                            yArray.Values[i] = simData.CalculatedDataList[i].parameters[yParameter].ValueInUnits;
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

                if (m_localInputParametersList.Count == 0 || m_localInputParametersList[0].CalculatedDataLists.Count == 0)
                {
                    return;
                }

                int pointsCount = m_localInputParametersList[0].CalculatedDataLists[0].Count;

                var xArray = new fmDisplayingArray
                {
                    Parameter = xParameter,
                    Values = new fmValue[pointsCount]
                };
                m_displayingResults.XParameter = xArray;
                for (int i = 0; i < pointsCount; ++i)
                {
                    xArray.Values[i] =
                        m_localInputParametersList[0].CalculatedDataLists[0][i].parameters[xParameter].ValueInUnits;
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
                        if (!localParameters.IsChecked)
                            continue;

                        foreach (List<fmFilterSimulationData> list in localParameters.CalculatedDataLists)
                        {
                            var yArray = new fmDisplayingArray
                                             {
                                                 OwningSimulation = list.Count == 0 ? null : list[0],
                                                 Parameter = yParameter,
                                                 Values = new fmValue[pointsCount],
                                                 Scale =
                                                     !NoScalingCheckBox.Checked ? degreeOffset[yParameter] : new fmValue(1),
                                                 IsY2Axis = y2Parameters.Contains(yParameter),
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
                    for (int i = 0; i < simData.CalculatedDataList.Count; ++i)
                    {
                        fmValue curVal = fmValue.Abs(simData.CalculatedDataList[i].parameters[yParameter].ValueInUnits);
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

            fmGlobalParameter xParameter = GetCurrentXAxisParameter();

            if (!m_isUseLocalParams)
            {
                var xStarts = new List<double>();
                var xEnds = new List<double>();
                for (int i = 0; i < m_involvedSeries.Count; ++i)
                {
                    fmValue minValue = fmValue.ObjectToValue(InvolvedSeriesDataGrid[1, i].Value);
                    fmValue maxValue = fmValue.ObjectToValue(InvolvedSeriesDataGrid[2, i].Value);
                    xStarts.Add(minValue.value);
                    xEnds.Add(maxValue.value);
                }
                IEnumerable<double> xList = CreateXValues(xStarts, xEnds, m_rowsQuantity);

                foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
                {
                    if (!m_involvedSeries.ContainsKey(simData.ExternalSimulation.Parent))
                    {
                        continue;
                    }
                    fmRange range = m_involvedSeries[simData.ExternalSimulation.Parent];

                    simData.CalculatedDataList = new List<fmFilterSimulationData>();

                    foreach (double x in xList)
                    {
                        var tempSim = new fmFilterSimulationData();
                        tempSim.CopyIsInputedFrom(simData.InternalSimulationData);
                        tempSim.CopyValuesFrom(simData.ExternalSimulation.Data);
                        tempSim.parameters[xParameter].value = new fmValue(x) * xParameter.UnitFamily.CurrentUnit.Coef;

                        if (tempSim.parameters[xParameter].value.value < range.MinValue
                            || tempSim.parameters[xParameter].value.value > range.MaxValue)
                        {
                            foreach (KeyValuePair<fmGlobalParameter, fmCalculationBaseParameter> pair in tempSim.parameters)
                            {
                                if (pair.Key != xParameter)
                                {
                                    pair.Value.value = new fmValue();
                                }
                            }
                        }
                        else
                        {
                            var suspensionCalculator = new fmSuspensionCalculator(tempSim.parameters.Values)
                                                           {
                                                               calculationOption = simData.
                                                                   InternalSimulationData.suspensionCalculationOption
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
                                        calculationOption = simData.
                                            InternalSimulationData.filterMachiningCalculationOption
                                    };
                            filterMachiningCalculator.DoCalculations();

                            bool isPlaneArea =
                                fmFilterMachiningCalculator.IsPlainAreaCalculationOption(
                                    simData.InternalSimulationData.filterMachiningCalculationOption);
                            bool isVacuumFilter =
                                fmFilterSimMachineType.IsVacuumFilter(simData.ExternalSimulation.Parent.MachineType);
                            double hcdCoefficient =
                                fmFilterSimMachineType.GetHcdCoefficient(simData.ExternalSimulation.Parent.MachineType);

                            var eps0DNedEpsdCalculator = new fmEps0dNedEpsdCalculator(tempSim.parameters.Values)
                                                             {
                                                                 dpdInputCalculationOption = simData.
                                                                     InternalSimulationData.dpdInputCalculationOption,
                                                                 hcdCalculationOption = simData.
                                                                     InternalSimulationData.hcdEpsdCalculationOption,
                                                                 isPlainArea = isPlaneArea
                                                             };
                            eps0DNedEpsdCalculator.DoCalculations();

                            var sigmaPke0PkePcdRcdAlphadCalculator =
                                new fmSigmaPke0PkePcdRcdAlphadCalculator(tempSim.parameters.Values);
                            sigmaPke0PkePcdRcdAlphadCalculator.DoCalculations();

                            var deliquoringSimualtionCalculator =
                                new fmDeliquoringSimualtionCalculator(
                                    new fmCalculatorsLibrary.fmDeliquoringSimualtionCalculator.DeliquoringCalculatorOptions(
                                        isPlaneArea,
                                        isVacuumFilter,
                                        hcdCoefficient),
                                tempSim.parameters.Values);
                            deliquoringSimualtionCalculator.DoCalculations();
                        }

                        simData.CalculatedDataList.Add(tempSim);
                    }
                }
            }
            else
            {
                if (InvolvedSeriesDataGrid.Rows.Count == 0)
                {
                    return;
                }
                foreach (fmLocalInputParametersData localParameters in m_localInputParametersList)
                {
                    localParameters.CalculatedDataLists = new List<List<fmFilterSimulationData>>();
                    fmFilterSimulation sim = m_externalCurrentActiveSimulation;
                    {
                        var xStarts = new List<double>();
                        var xEnds = new List<double>();
                        fmValue minValue = fmValue.ObjectToValue(InvolvedSeriesDataGrid[1, 0].Value);
                        fmValue maxValue = fmValue.ObjectToValue(InvolvedSeriesDataGrid[2, 0].Value);
                        xStarts.Add(minValue.value);
                        xEnds.Add(maxValue.value);

                        IEnumerable<double> xList = CreateXValues(xStarts, xEnds, m_rowsQuantity);

                        var calculatedDataList = new List<fmFilterSimulationData>();

                        foreach (double x in xList)
                        {
                            var tempSim = new fmFilterSimulationData();
                            fmFilterSimulationData.CopyAllParametersFromBlockToSimulation(localParameters.FilterMachiningBlock, tempSim);
                            fmFilterSimulationData.CopyAllParametersFromBlockToSimulation(localParameters.DeliquoringBlock, tempSim);
                            tempSim.CopyMaterialParametersValuesFrom(sim.Data);
                            tempSim.UpdateIsInputed(xParameter);
                            var xValue = new fmValue(x * xParameter.UnitFamily.CurrentUnit.Coef);
                            tempSim.parameters[xParameter].value = xValue;

                            var filterMachiningCalculator = new fmFilterMachiningCalculator(tempSim.parameters.Values)
                            {
                                calculationOption =
                                    localParameters.FilterMachiningBlock.
                                    filterMachiningCalculationOption
                            };
                            filterMachiningCalculator.DoCalculations();

                            bool isPlainArea = fmFilterMachiningCalculator.IsPlainAreaCalculationOption(sim.FilterMachiningCalculationOption);
                            bool isVacuumFilter = fmFilterSimMachineType.IsVacuumFilter(sim.Parent.MachineType);
                            double hcdCoefficient = fmFilterSimMachineType.GetHcdCoefficient(sim.Parent.MachineType);
                            var deliqSimulationCalculator = new fmDeliquoringSimualtionCalculator(new fmDeliquoringSimualtionCalculator.DeliquoringCalculatorOptions(isPlainArea, isVacuumFilter, hcdCoefficient),
                                tempSim.parameters.Values);
                            deliqSimulationCalculator.DoCalculations();

                            // after calculation the x parameter may be restored if it wasn't input
                            tempSim.parameters[xParameter].value = xValue;

                            calculatedDataList.Add(tempSim);
                        }

                        localParameters.CalculatedDataLists.Add(calculatedDataList);
                    }
               }
            }
        }

        private static IEnumerable<double> CreateXValues(List<double> xStarts, List<double> xEnds, int minimalNodesAmount)
        {
            if (xStarts.Count == 0)
                return new List<double>();

            double[] goodNumbers = { 1, 1.25, 2, 2.5, 5 };
            const double eps = 1e-9;

            const int maxPower = 15;
            double xStart = fmMisc.fmArrayUtils<double>.MinElement(xStarts);
            double xEnd = fmMisc.fmArrayUtils<double>.MaxElement(xEnds);

            for (int power = maxPower; power >= -maxPower; --power)
                for (int xIndex = goodNumbers.Length - 1; xIndex >= 0; --xIndex)
                {
                    double x = goodNumbers[xIndex];
                    double dx = x * Math.Pow(10.0, power);
                    double nodesCount = Math.Floor(xEnd / dx - eps) - Math.Floor(xStart / dx + eps);
                    if (nodesCount >= minimalNodesAmount)
                    {
                        var result = new List<double>();
                        result.AddRange(xStarts);
                        result.AddRange(xEnds);
                        for (int i = 1; i < nodesCount - 1; ++i)
                        {
                            result.Add((Math.Floor(xStart / dx + eps) + i) * dx);
                        }
                        result.Add(xEnd);
                        double [] resultArray = result.ToArray();
                        Array.Sort(resultArray);
                        return resultArray.Distinct();
                    }
                }

            return new List<double>();
        }

        private void BindXYLists()
        {
            if (m_xyListKind == null)
            {
                InitXyParametersProperties();
            }

            var inputNames = new List<string>();

            IEnumerable<fmGlobalParameter> simInputParameters = GetCommonInputParametersList();

            foreach (fmGlobalParameter p in simInputParameters)
            {
                CheckBox paramsCheckbox = m_parameterKindProperties[m_xyListKind[p.Name]].Checkbox;
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
                    CheckBox paramsCheckbox = m_parameterKindProperties[m_xyListKind[p.Name]].Checkbox;
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

            BindY2List(listBoxYAxis.CheckedItems);
        }

        private void BindY2List(System.Collections.ICollection yParameters)
        {
            var y2OutputNames = new List<string>();
            foreach (object item in yParameters)
            {
                if (item is ListViewItem)
                {
                    y2OutputNames.Add(((ListViewItem)item).Text);                   
                }
                else if (item is fmGlobalParameter)
                {
                    y2OutputNames.Add(((fmGlobalParameter) item).Name);
                }
                else 
                {
                    y2OutputNames.Add(item.ToString());                    
                }
            }
            FillListBox(listBoxY2Axis.Items, y2OutputNames);
        }

        private IEnumerable<fmGlobalParameter> GetCommonInputParametersList()
        {
            if (!m_isUseLocalParams)
            {
                var simInputParameters = new List<fmGlobalParameter>(fmGlobalParameter.Parameters);
                foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
                    simInputParameters = ParametersListsIntersection(simInputParameters,
                                                                     simData.InternalSimulationData.
                                                                         GetParametersThatCanBeInputedList());
                return simInputParameters;
            }
            else
            {
                var simInputParameters = new List<fmGlobalParameter>(fmGlobalParameter.Parameters);
                foreach (fmLocalInputParametersData localParameters in m_localInputParametersList)
                    simInputParameters = ParametersListsIntersection(simInputParameters,
                        localParameters.GetParametersThatCanBeInput());
                return simInputParameters;
            }
        }

        private static List<fmGlobalParameter> ParametersListsIntersection(List<fmGlobalParameter> a, List<fmGlobalParameter> b)
        {
            return fmGlobalParameter.Parameters.Where(p => a.Contains(p) && b.Contains(p)).ToList();
        }

        private static List<fmGlobalParameter> ParametersListsUnion(List<fmGlobalParameter> a, List<fmGlobalParameter> b)
        {
            return fmGlobalParameter.Parameters.Where(p => a.Contains(p) || b.Contains(p)).ToList();
        }

        private void UpdateInternalSelectedSimList(IEnumerable<fmFilterSimulation> simList)
        {
            var newInternalSelectedSimList = new List<fmSelectedSimulationData>();
            foreach (fmFilterSimulation sim in simList)
            {
                fmSelectedSimulationData newSelectedSim = null;
                foreach (fmSelectedSimulationData checkedSim in m_internalSelectedSimList)
                {
                    if (checkedSim.ExternalSimulation == sim)
                    {
                        newSelectedSim = checkedSim;
                        newSelectedSim.InternalSimulationData.CopyValuesFrom(sim.Data);
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
