using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using FilterSimulation.fmFilterObjects;
using fmCalcBlocksLibrary.Blocks;
using System.Windows.Forms;
using fmCalcBlocksLibrary.Controls;
using fmCalculationLibrary;
using fmCalcBlocksLibrary.BlockParameter;
using fmZedGraph;
using ZedGraph;
using fmDataGrid;
using fmCalcBlocksLibrary;
using fmCalculatorsLibrary;

namespace FilterSimulationWithTablesAndGraphs
{
    class fmDisplayingArray
    {
        private fmGlobalParameter parameter;
        private Color color;
        private bool isY2Axis;
        private fmValue [] values;
        private fmValue scale;
        private bool bold;

        public fmGlobalParameter Parameter
        {
            get
            {
                return parameter;
            }
            set
            {
                parameter = value;
            }
        }
        public fmValue[] Values
        {
            get
            {
                return values;
            }
            set
            {
                values = value;
            }
        }
        public fmValue Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
            }
        }
        public double[] ValuesInDoubles
        {
            get
            {
                double [] result = new double[values.Length];
                for (int i = 0; i < values.Length; ++i)
                    result[i] = values[i].value;
                return result;
            }
        }
        public double[] ScaledValuesInDoubles
        {
            get
            {
                double[] result = new double[values.Length];
                for (int i = 0; i < values.Length; ++i)
                    result[i] = values[i].value * scale.value;
                return result;
            }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public bool IsY2Axis
        {
            get { return isY2Axis; }
            set { isY2Axis = value; }
        }
        public bool Bold
        {
            get
            {
                return bold;
            }
            set
            {
                bold = value;
            }
        }
    }
    class fmDisplayingYListOfArrays
    {
        private fmGlobalParameter parameter;
        private List<fmDisplayingArray> arrays;
        
        public fmGlobalParameter Parameter
        {
            get { return parameter; }
            set { parameter = value; }
        }
        public List<fmDisplayingArray> Arrays
        {
            get { return arrays; }
            set { arrays = value; }
        }
    }
    class fmDisplayingResults
    {
        private fmDisplayingArray x;
        private List<fmDisplayingYListOfArrays> y;
        public fmDisplayingArray xParameter
        {
            get { return x; }
            set { x = value; }
        }
        public List<fmDisplayingYListOfArrays> yParameters
        {
            get { return y; }
            set { y = value; }
        }
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
            this.isCurrentActive = false;
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
            this.isCurrentActive = false;
            this.filterMachiningBlock = filterMachiningBlock;
            this.initialFilterMachiningCalculationOption = initialFilterMachiningCalculationOption;
        }
    }

    public partial class FilterSimulationWithTablesAndGraphs
    {
        private List<fmFilterSimulation> externalSimList;
        private fmFilterSimulation externalCurrentActiveSimulation;
        private List<fmSelectedSimulationData> internalSelectedSimList;
        private List<fmLocalInputParametersData> localInputParametersList = new List<fmLocalInputParametersData>();
        private bool isUseLocalParams;
        private int RowsQuantity = 30;
        private bool loadingXRange = false;
        private fmDisplayingResults displayingResults = new fmDisplayingResults();
        private object highLightCaller = null;
        public List<fmGlobalParameter> yAxisListParametersToDisplay;
        
        private void FillListBox(ListBox listBox, List<string> strings)
        {
            for (int i = listBox.Items.Count - 1; i >= 0; --i)
                if (!strings.Contains(listBox.Items[i].ToString()))
                    listBox.Items.RemoveAt(i);

            for (int i = 0, j = 0; j < strings.Count; ++i, ++j)
            {
                if (i == listBox.Items.Count
                    || listBox.Items[i].ToString() != strings[j])
                {
                    listBox.Items.Insert(i, strings[j]);
                }
            }
        }

        private void CreateColumnsInParametersTables()
        {
            List<fmGlobalParameter> allSimParams = new List<fmGlobalParameter>((new fmFilterSimulation()).Parameters.Keys);

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
            fmFilterMachiningBlock fmb = new fmFilterMachiningBlock(row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.A.name)],
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
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.a.name)]);
            fmb.ValuesChangedByUser += fmb_ValuesChangedByUser;
            localInputParametersList.Add(new fmLocalInputParametersData(true, fmb, externalCurrentActiveSimulation.FilterMachiningCalculationOption));

            fmb.SetCalculationOptionAndUpdateCellsStyle(externalCurrentActiveSimulation.FilterMachiningCalculationOption);
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(externalCurrentActiveSimulation, fmb);
            fmb.CalculateAndDisplay();

            //UpdateIsInputedForParametersBlocks();
        }

        void fmb_ValuesChangedByUser(object sender, fmBlockParameterEvetArgs e)
        {
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();   
        }

        //private void UpdateParametersTablesColumnsVisibility()
        //{
        //    List<fmBlockParameter> blockParameterList =
        //        new fmFilterMachiningBlock(calculationOptionViewInTablesAndGraphs).Parameters;
        //    List<fmGlobalParameter> inputParameters =
        //        CalculationOptionHelper.GetParametersListThatCanBeInput(calculationOptionViewInTablesAndGraphs.GetSelectedOption());

        //    foreach (fmBlockParameter p in blockParameterList)
        //    {
        //        int index = GetColumnIndexByHeader(additionalParametersTable, p.name);
        //        additionalParametersTable.Columns[index].Visible = inputParameters.Contains(p.globalParameter);
        //        index = GetColumnIndexByHeader(selectedSimulationParametersTable, p.name);
        //        selectedSimulationParametersTable.Columns[index].Visible = inputParameters.Contains(p.globalParameter);
        //    }
        //}

        //private bool IsAlmostEqual(double val1, double val2)
        //{
        //    return Math.Abs(val1 - val2) < 1e-12 * (Math.Abs(val1) + Math.Abs(val2));
        //}

        //private void SetUpChartAxis(int xAxisParameterIndex, int yAxisParameterIndex, int y2AxisParameterIndex)
        //{
        //    GraphPane myPane = fmZedGraphControl1.GraphPane;
        //    myPane.CurveList.Clear();
        //    fmAdditionalFilterMachiningBlock tmp = new fmAdditionalFilterMachiningBlock(true, calculationOptionViewInTablesAndGraphs);

        //    if (xAxisParameterIndex != -1)
        //    {
        //        myPane.XAxis.Title.Text = tmp.Parameters[xAxisParameterIndex].name + " (" + tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Name + ")";
        //    }
        //    if (yAxisParameterIndex != -1)
        //    {
        //        myPane.YAxis.Title.Text = tmp.Parameters[yAxisParameterIndex].name + " (" + tmp.Parameters[yAxisParameterIndex].unitFamily.CurrentUnit.Name + ")";
        //        myPane.YAxis.Scale.FontSpec.FontColor = Y1AxColor;
        //        myPane.YAxis.Title.FontSpec.FontColor = Y1AxColor;
        //        myPane.YAxis.Color = Y1AxColor;
        //    }
        //    if (y2AxisParameterIndex != -1)
        //    {
        //        myPane.Y2Axis.Title.Text = tmp.Parameters[y2AxisParameterIndex].name + " (" + tmp.Parameters[y2AxisParameterIndex].unitFamily.CurrentUnit.Name + ")";
        //        myPane.Y2Axis.Title.FontSpec.FontColor = Y2AxColor;
        //        myPane.Y2Axis.IsVisible = true;
        //        myPane.Y2Axis.Color = Y2AxColor;
        //        myPane.Y2Axis.Scale.FontSpec.FontColor = Y2AxColor;
        //    }
        //    else
        //    {
        //        myPane.Y2Axis.IsVisible = false;
        //    }

        //    fmZedGraphControl1.GraphPane.Title.Text = "Curves";
        //    fmZedGraphControl1.GraphPane.Legend.IsVisible = false;
        //}

        //private void CreateValuesForGrid(fmFilterMachiningBlock tmp, int xAxisParameterIndex, int yAxisParameterIndex, out fmValue[] aax1, out fmValue[] aay1)
        //{
        //    aax1 = aay1 = null;

        //    if (xAxisParameterIndex == -1 || yAxisParameterIndex == -1)
        //        return;

        //    List<fmValue> ax1 = new List<fmValue>();
        //    List<fmValue> ay1 = new List<fmValue>();

        //    double xStart = tmp.Parameters[xAxisParameterIndex].globalParameter.chartCurretXRange.minValue
        //        / tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Coef;
        //    double xEnd = tmp.Parameters[xAxisParameterIndex].globalParameter.chartCurretXRange.maxValue
        //        / tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Coef;

        //    double dx, x1;
        //    FindDxForKIntermediatePoints(xStart, xEnd, RowsQuantity - 2, out dx, out x1);

        //    ax1.Add(new fmValue(xStart));
        //    for (double x = x1; x * (1 + 1e-8) < xEnd; x += dx)
        //    {
        //        ax1.Add(new fmValue(x));
        //    }
        //    ax1.Add(new fmValue(xEnd));

        //    for (int i = 0; i < ax1.Count; ++i)
        //    {
        //        tmp.Parameters[xAxisParameterIndex].value = ax1[i] * tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Coef;
        //        tmp.DoCalculations();
        //        ax1[i] = (tmp.Parameters[xAxisParameterIndex].value /
        //                tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Coef);
        //        ay1.Add(tmp.Parameters[yAxisParameterIndex].value /
        //                tmp.Parameters[yAxisParameterIndex].unitFamily.CurrentUnit.Coef);
        //    }

        //    aax1 = new fmValue[ax1.Count];
        //    aay1 = new fmValue[ay1.Count];
        //    for (int i = 0; i < ax1.Count; ++i)
        //    {
        //        aax1[i] = ax1[i];
        //        aay1[i] = ay1[i];
        //    }
        //}

        //private void UpdatefmSelectedBlocks()
        //{
        //    if (selectedSimulationParametersTable.CurrentRow != null)
        //    {
        //        currentBlock = fmSelectedBlocks[selectedSimulationParametersTable.CurrentRow.Index];
        //    }
        //    List<fmSelectedFilterMachiningBlock> tempSelectedBlock = new List<fmSelectedFilterMachiningBlock>();
        //    for (int i = 0; i < fmGlobalBlocks.Count; i++)
        //    {
        //        fmFilterMachiningBlock fmb = fmGlobalBlocks[i];
        //        fmSelectedFilterMachiningBlock selectedBlock = fmSelectedBlocks.Find(ByFilterMachiningBlock(fmb));
        //        if (selectedBlock != null)
        //        {
        //            tempSelectedBlock.Add(selectedBlock);
        //            if (fmb == currentSimFMB)
        //            {
        //                currentBlock = new fmSelectedFilterMachiningBlock();
        //                currentBlock.filterMachiningBlock = fmb;
        //                currentBlock.IsChecked = selectedBlock.IsChecked;
        //            }
        //        }
        //        else
        //        {
        //            fmSelectedFilterMachiningBlock sfmb = new fmSelectedFilterMachiningBlock();
        //            sfmb.filterMachiningBlock = fmb;
        //            sfmb.IsChecked = true;
        //            tempSelectedBlock.Add(sfmb);
        //            if (fmb == currentSimFMB)
        //            {
        //                currentBlock = new fmSelectedFilterMachiningBlock();
        //                currentBlock.filterMachiningBlock = fmb;
        //                currentBlock.IsChecked = true;
        //            }
        //        }
        //    }
        //    fmSelectedBlocks = tempSelectedBlock;
        //}

        //private void UpdateIsInputedForParametersBlocks()
        //{
        //    foreach (fmFilterMachiningBlock localFMB in fmLocalBlocks)
        //        foreach (fmBlockParameter p in localFMB.Parameters)
        //            if (p.name == listBoxXAxis.Text)
        //                localFMB.UpdateIsInputed(p);
        //}

        private void BindSelectedSimulationListToTable()
        {
            UpdateInternalSelectedSimList(externalSimList);

            selectedSimulationParametersTable.Rows.Clear();

            for (int i = 0; i < internalSelectedSimList.Count; i++)
            {
                fmFilterSimulationData tempSim = internalSelectedSimList[i].internalSimulationData;

                DataGridViewRow row =
                    selectedSimulationParametersTable.Rows[selectedSimulationParametersTable.Rows.Add()];
                row.Cells["SelectedSimulationParametersCheckBoxColumn"].Value = internalSelectedSimList[i].isChecked;

                foreach (fmGlobalParameter param in tempSim.parameters.Keys)
                {
                    int idx = GetColumnIndexByHeader(selectedSimulationParametersTable, param.name);
                    row.Cells[idx].Value = tempSim.parameters[param].value / param.unitFamily.CurrentUnit.Coef;
                }
            }

            BindBackColorToSelectedSimulationsTable();
            BindForeColorToSelectedSimulationsTable();
            UpdateVisibilityOfColumnsInSelectedSimulationsTable();
        }

        private void BindBackColorToSelectedSimulationsTable()
        {
            for (int i = 0; i < internalSelectedSimList.Count; i++)
            {
                fmFilterSimulationData tempSim = internalSelectedSimList[i].internalSimulationData;
                DataGridViewRow row = selectedSimulationParametersTable.Rows[i];

                fmFilterMachiningBlock tempBlock = new fmFilterMachiningBlock();
                tempBlock.calculationOption = tempSim.filterMachiningCalculationOption;
                tempBlock.UpdateGroups();

                foreach (fmBlockVariableParameter param in tempBlock.Parameters)
                {
                    int idx = GetColumnIndexByHeader(selectedSimulationParametersTable, param.globalParameter.name);
                    if (param.group != null)
                    {
                        row.Cells[idx].Style.BackColor = param.group.color;
                    }
                }
            }
        }

        private void BindForeColorToSelectedSimulationsTable()
        {
            for (int i = 0; i < internalSelectedSimList.Count; i++)
            {
                fmFilterSimulationData tempSim = internalSelectedSimList[i].internalSimulationData;
                DataGridViewRow row = selectedSimulationParametersTable.Rows[i];

                foreach (fmGlobalParameter param in tempSim.parameters.Keys)
                {
                    int idx = GetColumnIndexByHeader(selectedSimulationParametersTable, param.name);
                    Color cellForeColor = Color.Black;
                    if (tempSim.parameters[param] is fmCalculationVariableParameter)
                    {
                        if ((tempSim.parameters[param] as fmCalculationVariableParameter).isInputed)
                            cellForeColor = Color.Blue;
                    }
                    row.Cells[idx].Style.ForeColor = cellForeColor;
                }
            }
        }

        private void UpdateVisibilityOfColumnsInSelectedSimulationsTable()
        {
            List<fmGlobalParameter> inputs = new List<fmGlobalParameter>(fmGlobalParameter.Parameters);
            inputs.Remove(fmGlobalParameter.eta_f);
            inputs.Remove(fmGlobalParameter.rho_f);
            inputs.Remove(fmGlobalParameter.rho_s);
            inputs.Remove(fmGlobalParameter.rho_sus);
            inputs.Remove(fmGlobalParameter.ne);
            inputs.Remove(fmGlobalParameter.nc);
            
            foreach (DataGridViewColumn col in selectedSimulationParametersTable.Columns)
            {
                string parName = GetParameterNameFromHeader(col.HeaderText);
                if (fmGlobalParameter.ParametersByName.ContainsKey(parName))
                {
                    fmGlobalParameter par = fmGlobalParameter.ParametersByName[parName];
                    col.Visible = false;
                    if (inputs.Contains(par))
                    {
                        foreach (fmSelectedSimulationData simData in internalSelectedSimList)
                            if (simData.internalSimulationData.parameters[par] is fmCalculationVariableParameter
                                && (simData.internalSimulationData.parameters[par] as fmCalculationVariableParameter).isInputed)
                            {
                                col.Visible = true;
                                break;
                            }
                    }
                }
            }
        }

        private static string GetParameterNameFromHeader(string headerText)
        {
            string[] s = headerText.Split('(');
            return s[0].Trim();
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

        private void additionalParametersTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (additionalParametersTable.Rows.Count > 1
                && additionalParametersTable.Columns[e.ColumnIndex].Name == "DeleteButtonColumn")
            {
                localInputParametersList.RemoveAt(e.RowIndex);
                additionalParametersTable.Rows.RemoveAt(e.RowIndex);
                UpdateVisibilityOfColumnsInLocalParametrsTable();
                BindXYLists();
                RecalculateSimulationsWithIterationX();
                BindCalculatedResultsToDisplayingResults();
                BindCalculatedResultsToChartAndTable();
            }
        }

        private void calculationOptionViewInTablesAndGraphs_CheckedChanged(object sender, EventArgs e)
        {
        //    processingCalculationOptionViewCheckChanged = true;
        //    List<string> inputNames = new List<string>();
        //    List<string> outputNames = new List<string>();
        //    List<fmGlobalParameter> inputParameters = CalculationOptionHelper.GetParametersListThatCanBeInput(calculationOptionViewInTablesAndGraphs.GetSelectedOption());
        //    fmFilterMachiningBlock machiningBlock = new fmFilterMachiningBlock(calculationOptionViewInTablesAndGraphs);
        //    List<fmBlockParameter> blockParameterList = machiningBlock.Parameters;
        //    foreach (fmBlockParameter p in blockParameterList)
        //    {
        //        //(inputParameters.Contains(p.globalParameter) ? inputNames : outputNames).Add(p.name);
        //        if (!inputParameters.Contains(p.globalParameter))
        //        {
        //            outputNames.Add(p.name);
        //        }
        //        else
        //        {
        //            List<fmBlockParameter> list = machiningBlock.GetParametersByGroup(p.group);
        //            if(list.Count <= 1)
        //            {
        //                inputNames.Add(p.name);
        //            }
        //            else if(list.Count>1)
        //            {
        //                foreach(fmBlockParameter param in list)
        //                {
        //                    if (!inputNames.Contains(param.name))
        //                    {
        //                        inputNames.Add(param.name);
        //                    }
        //                    if (!outputNames.Contains(param.name))
        //                    {
        //                        outputNames.Add(param.name);
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    FillListBox(listBoxXAxis, inputNames);
        //    int indexX = listBoxXAxis.Items.IndexOf("n");
        //    if (indexX == -1) indexX = 0;
        //    listBoxXAxis.SelectedItem = listBoxXAxis.Items[indexX];

        //    FillListBox(listBoxYAxis, outputNames);
        //    int indexY = listBoxYAxis.Items.IndexOf("hc");
        //    if (indexY == -1) indexY = 0;
        //    listBoxYAxis.SelectedItem = listBoxYAxis.Items[indexY];

        //    FillListBox(listBoxY2Axis, outputNames);
        //    listBoxY2Axis.Items.Insert(0, "<none>");
        //    listBoxY2Axis.SelectedItem = listBoxY2Axis.Items[0];

        //    UpdateParametersTablesColumnsVisibility();
        //    UpdateIsInputedForParametersBlocks();

        //    processingCalculationOptionViewCheckChanged = false;

        //    DrawChartAndTable();
        }

        private void listBoxX_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetXAxisParameterAsInputed();
        }

        private void SetXAxisParameterAsInputed()
        {
            if (listBoxXAxis.Text != "")
                UpdateIsInputed(fmGlobalParameter.ParametersByName[listBoxXAxis.Text]);
            BindForeColorToSelectedSimulationsTable();
            UpdateVisibilityOfColumnsInSelectedSimulationsTable();
            LoadCurrentXRange();
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void UpdateIsInputed(fmGlobalParameter inputedParameter)
        {
            if (!isUseLocalParams)
            {
                foreach (fmSelectedSimulationData simData in internalSelectedSimList)
                {
                    simData.internalSimulationData.UpdateIsInputed(inputedParameter);
                }
            }
            else
            {
                foreach (fmLocalInputParametersData localParameters in localInputParametersList)
                {
                    localParameters.filterMachiningBlock.UpdateIsInputed(localParameters.filterMachiningBlock.GetParameterByName(inputedParameter.name));
                }
            }
        }

        private void LoadCurrentXRange()
        {
            if (listBoxXAxis.Text == "")
                return;

            loadingXRange = true;
            fmGlobalParameter xParameter = fmGlobalParameter.ParametersByName[listBoxXAxis.Text];
            double coef = xParameter.unitFamily.CurrentUnit.Coef;
            fmRange range = xParameter.chartCurretXRange;
            minXValueTextBox.Text = (range.MinValue / coef).ToString();
            maxXValueTextBox.Text = (range.MaxValue / coef).ToString();
            loadingXRange = false;
        }

        private void LoadDefaultXRange()
        {
            if (listBoxXAxis.Text == "")
            {
                return;
            }
            loadingXRange = true;
            fmGlobalParameter xParameter = fmGlobalParameter.ParametersByName[listBoxXAxis.Text];
            double coef = xParameter.unitFamily.CurrentUnit.Coef;
            fmRange defaultRange = xParameter.chartDefaultXRange;
            fmRange range = xParameter.chartCurretXRange;
            range.MinValue = defaultRange.MinValue;
            range.MaxValue = defaultRange.MaxValue;
            minXValueTextBox.Text = (range.MinValue / coef).ToString();
            maxXValueTextBox.Text = (range.MaxValue / coef).ToString();
            loadingXRange = false;
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            AddRow();
            UpdateVisibilityOfColumnsInLocalParametrsTable();
            UpdateIsCurrentActiveProperty(additionalParametersTable.CurrentRow == null ? -1 : additionalParametersTable.CurrentRow.Index);
            BindXYLists();
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void UseParamsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ReadUseParamsCheckBoxAndApply();
            UpdateVisibilityOfColumnsInLocalParametrsTable();
            BindXYLists();
            LoadCurrentXRange();
            if (listBoxXAxis.Text != "")
                UpdateIsInputed(fmGlobalParameter.ParametersByName[listBoxXAxis.Text]);
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void ReadUseParamsCheckBoxAndApply()
        {
            isUseLocalParams = UseParamsCheckBox.Checked;
            additionalParametersTable.Visible = isUseLocalParams;
            buttonAddRow.Visible = isUseLocalParams;
            selectedSimulationParametersTable.Visible = !isUseLocalParams;
            selectedSimulationParametersTable.Dock = (!isUseLocalParams) ? DockStyle.Fill : DockStyle.None;
            additionalParametersTable.Dock = (isUseLocalParams) ? DockStyle.Fill : DockStyle.None;
        }

        private void ParametersTable_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
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
            if (!isUseLocalParams)
            {
                for (int i = 0; i < internalSelectedSimList.Count; ++i)
                {
                    internalSelectedSimList[i].isCurrentActive = i == currentRowIndex;
                }
            }
            else
            {
                for (int i = 0; i < localInputParametersList.Count; ++i)
                {
                    localInputParametersList[i].isCurrentActive = i == currentRowIndex;
                }
            }
        }

        private void selectedSimulationParametersTable_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            if (selectedSimulationParametersTable.Columns[e.ColumnIndex].Name == "SelectedSimulationParametersCheckBoxColumn"
                && internalSelectedSimList.Count > e.RowIndex)
            {
                internalSelectedSimList[e.RowIndex].isChecked = (bool)selectedSimulationParametersTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                BindCalculatedResultsToDisplayingResults();
                BindCalculatedResultsToChartAndTable();
            }
        }

        private void additionalParametersTable_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            if (additionalParametersTable.Columns[e.ColumnIndex].Name == "AdditionalParametersCheckBoxColumn"
                && localInputParametersList.Count > e.RowIndex)
            {
                localInputParametersList[e.RowIndex].isChecked = (bool)additionalParametersTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                RecalculateSimulationsWithIterationX();
                BindCalculatedResultsToDisplayingResults();
                BindCalculatedResultsToChartAndTable();
            }
        }

        private void rowsQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rowsQuantity.Text))
            {
                RowsQuantity = (int)fmValue.StringToValue(rowsQuantity.Text).value;
                rowsQuantity.Text = RowsQuantity.ToString();
                rowsQuantity.Focus();
                RecalculateSimulationsWithIterationX();
                BindCalculatedResultsToDisplayingResults();
                BindCalculatedResultsToChartAndTable();
            }
        }

        #endregion
        public void UpdateUnitsInTablesAndGraphs()
        {
            //List<fmBlockParameter> blockParameterList = new fmFilterMachiningBlock(calculationOptionViewInTablesAndGraphs).Parameters;

            //foreach (fmBlockParameter p in blockParameterList)
            //{
            //    int index = GetColumnIndexByHeader(additionalParametersTable, p.name);
            //    additionalParametersTable.Columns[index].HeaderText = p.name + " (" + p.unitFamily.CurrentUnit.Name + ")";
            //    index = GetColumnIndexByHeader(selectedSimulationParametersTable, p.name);
            //    selectedSimulationParametersTable.Columns[index].HeaderText = p.name + " (" + p.unitFamily.CurrentUnit.Name + ")";
            //}
            foreach (DataGridViewColumn col in additionalParametersTable.Columns)
            {
                string parName = GetParameterNameFromHeader(col.HeaderText);
                if (fmGlobalParameter.ParametersByName.ContainsKey(parName))
                {
                    fmGlobalParameter p = fmGlobalParameter.ParametersByName[parName];
                    col.HeaderText = p.name + " (" + p.UnitName + ")";
                }
            }

            foreach (DataGridViewColumn col in selectedSimulationParametersTable.Columns)
            {
                string parName = GetParameterNameFromHeader(col.HeaderText);
                if (fmGlobalParameter.ParametersByName.ContainsKey(parName))
                {
                    fmGlobalParameter p = fmGlobalParameter.ParametersByName[parName];
                    col.HeaderText = p.name + " (" + p.UnitName + ")";
                }
            }
        }

        public void BuildCurves(List<fmFilterSimulation> simList, fmFilterSimulation currentActiveSimulation)
        {
            this.externalSimList = simList;
            this.externalCurrentActiveSimulation = currentActiveSimulation;
            BindSelectedSimulationListToTable();
            UpdateVisibilityOfColumnsInLocalParametrsTable();
            BindXYLists();
            LoadCurrentXRange();
            if (listBoxXAxis.Text != "")
                UpdateIsInputed(fmGlobalParameter.ParametersByName[listBoxXAxis.Text]);
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        //private void BindLocalParametersListToTable()
        //{
        //    additionalParametersTable.Rows.Clear();

        //    for (int i = 0; i < localInputParametersList.Count; i++)
        //    {
        //        //fmFilterSimulationData tempSim = localInputParametersList[i].internalSimulationData;

        //        DataGridViewRow row =
        //            additionalParametersTable.Rows[additionalParametersTable.Rows.Add()];
        //        row.Cells["AdditionalParametersCheckBoxColumn"].Value = localInputParametersList[i].isChecked;

        //        fmCalcBlocksLibrary.Blocks.fmFilterMachiningBlock fmb = new fmFilterMachiningBlock(
        //            GetLocalInputParametersCell(row, fmGlobalParameter.A),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Dp),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.sf),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.n),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.tc),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.tf),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.tr),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.hc_over_tf),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.dhc_over_dt),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.hc),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Mf),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Vf),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.mf),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.vf),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.ms),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.vs),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.msus),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.vsus),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.mc),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.vc),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Msus),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Vsus),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Vc),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Mc),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Ms),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Vs),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qf),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qf_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qs),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qs_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qc),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qc_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qsus),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qsus_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qmsus),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qmsus_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qms),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qms_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qmf),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qmf_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qmc),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Qmc_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qf),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qf_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qs),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qs_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qc),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qc_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qsus),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qsus_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qmsus),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qmsus_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qms),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qms_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qmf),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qmf_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qms),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.qmc_d),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.eps),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.kappa),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.Pc),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.rc),
        //            GetLocalInputParametersCell(row, fmGlobalParameter.a));

        //        foreach (fmGlobalParameter param in tempSim.parameters.Keys)
        //        {
        //            int idx = GetColumnIndexByHeader(additionalParametersTable, param.name);
        //            row.Cells[idx].Value = tempSim.parameters[param].value / param.unitFamily.CurrentUnit.Coef;
        //        }
        //    }

        //    UpdateVisibilityOfColumnsInLocalParametrsTable();
        //}

        private void UpdateVisibilityOfColumnsInLocalParametrsTable()
        {
            List<fmGlobalParameter> inputs = new List<fmGlobalParameter>();
            foreach (fmLocalInputParametersData localParameters in localInputParametersList)
            {
                inputs = ParametersListsUnion(inputs, CalculationOptionHelper.GetParametersListThatCanBeInput(localParameters.filterMachiningBlock.calculationOption));
            }

            foreach (DataGridViewColumn col in additionalParametersTable.Columns)
            {
                string parName = GetParameterNameFromHeader(col.HeaderText);
                if (fmGlobalParameter.ParametersByName.ContainsKey(parName))
                {
                    col.Visible = inputs.Contains(fmGlobalParameter.ParametersByName[parName]);
                }
            }
        }

        private DataGridViewCell GetLocalInputParametersCell(DataGridViewRow row, fmGlobalParameter parameter)
        {
            return row.Cells[GetColumnIndexByHeader(additionalParametersTable, parameter.name)];
        }

        private void BindCalculatedResultsToTable()
        {
            int yParametersCount = displayingResults.yParameters == null ? 0 : displayingResults.yParameters.Count;
            coordinatesGrid.ColumnCount = 1 + yParametersCount;

            if (displayingResults.xParameter == null)
            {
                coordinatesGrid.Columns.Clear();
                return;
            }

            // x-axis column
            {
                string parameterNameAndUnits = displayingResults.xParameter.Parameter.name + " (" + displayingResults.xParameter.Parameter.UnitName + ")";
                coordinatesGrid.Columns[0].HeaderText = parameterNameAndUnits;
                coordinatesGrid.Columns[0].ReadOnly = true;
                coordinatesGrid.Columns[0].Width = 50;
                coordinatesGrid.RowCount = displayingResults.xParameter.Values.Length;
                for (int i = 0; i < coordinatesGrid.RowCount; ++i)
                {
                    coordinatesGrid[0, i].Value = displayingResults.xParameter.Values[i];
                }
            }

            if (displayingResults.yParameters == null)
            {
                fmZedGraphControl1.Refresh();
                return;
            }

            int yCol = 0;

            foreach (fmDisplayingYListOfArrays yArrays in displayingResults.yParameters)
            {
                fmGlobalParameter yParameter = yArrays.Parameter;
                string parameterNameAndUnits = yParameter.name + " (" + yParameter.UnitName + ")";

                foreach (fmDisplayingArray dispArray in yArrays.Arrays)
                {
                    ++yCol;
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

        private void BindCalculatedResultsToChart()
        {
            fmZedGraphControl1.GraphPane.CurveList.Clear();

            if (displayingResults.yParameters == null)
            {
                return;
            }
            
            foreach (fmDisplayingYListOfArrays yArrays in displayingResults.yParameters)
            {
                fmGlobalParameter yParameter = yArrays.Parameter;
                string parameterNameAndUnits = yParameter.name + " (" + yParameter.UnitName + ")";

                foreach (fmDisplayingArray dispArray in yArrays.Arrays)
                {
                    string scaleString = dispArray.Scale.value == 1 ? "" : " * " + (1 / dispArray.Scale).ToString();
                    LineItem curve = fmZedGraphControl1.GraphPane.AddCurve(dispArray.Parameter.name + scaleString + " (" + dispArray.Parameter.UnitName + ")",
                        displayingResults.xParameter.ValuesInDoubles,
                        dispArray.ScaledValuesInDoubles,
                        dispArray.Color,
                        SymbolType.None);
                    curve.Line.Width = dispArray.Bold ? 2 : 1;
                    curve.IsY2Axis = dispArray.IsY2Axis;
                }
            }

            fmGlobalParameter xParameter = displayingResults.xParameter.Parameter;
            fmZedGraphControl1.GraphPane.XAxis.Title.Text = xParameter.name + " (" + xParameter.UnitName +")";
            fmZedGraphControl1.GraphPane.Legend.IsVisible = false;
            fmZedGraphControl1.GraphPane.Y2Axis.IsVisible = false;

            if (displayingResults.yParameters.Count == 1)
            {
                fmGlobalParameter yParameter = displayingResults.yParameters[0].Parameter;
                fmZedGraphControl1.GraphPane.YAxis.Title.Text = yParameter.name + " (" + yParameter.UnitName + ")";
                if (displayingResults.yParameters[0].Arrays.Count > 0)
                {
                    fmZedGraphControl1.GraphPane.YAxis.Title.FontSpec.FontColor = displayingResults.yParameters[0].Arrays[0].Color;
                }
            }
            else if (displayingResults.yParameters.Count == 2)
            {
                fmZedGraphControl1.GraphPane.Y2Axis.IsVisible = true;

                fmGlobalParameter y1Parameter = displayingResults.yParameters[0].Parameter;
                fmGlobalParameter y2Parameter = displayingResults.yParameters[1].Parameter;
                fmZedGraphControl1.GraphPane.YAxis.Title.Text = y1Parameter.name + " (" + y1Parameter.UnitName + ")";
                if (displayingResults.yParameters[0].Arrays.Count > 0)
                {
                    fmZedGraphControl1.GraphPane.YAxis.Title.FontSpec.FontColor = displayingResults.yParameters[0].Arrays[0].Color;
                }
                
                fmZedGraphControl1.GraphPane.Y2Axis.Title.Text = y2Parameter.name + " (" + y2Parameter.UnitName + ")";
                if (displayingResults.yParameters[1].Arrays.Count > 0)
                {
                    fmZedGraphControl1.GraphPane.Y2Axis.Title.FontSpec.FontColor = displayingResults.yParameters[1].Arrays[0].Color;
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

        private void BindCalculatedResultsToChartAndTable()
        {
            BindCalculatedResultsToChart();
            BindCalculatedResultsToTable();
        }

        private void BindCalculatedResultsToDisplayingResults()
        {
            if (listBoxXAxis.Text == "")
            {
                displayingResults.xParameter = null;
                displayingResults.yParameters = null;
                return;
            }

            fmGlobalParameter xParameter = fmGlobalParameter.ParametersByName[listBoxXAxis.Text];
            List<fmGlobalParameter> yParameters = new List<fmGlobalParameter>();
            foreach (string s in listBoxYAxis.CheckedItems)
            {
                yParameters.Add(fmGlobalParameter.ParametersByName[s]);
            }

            BindCalculatedResultsToDisplayingResults(xParameter, yParameters);
        }
        private void BindCalculatedResultsToDisplayingResults(fmGlobalParameter xParameter, List<fmGlobalParameter> yParameters)
        {
            if (!isUseLocalParams)
            {
                displayingResults.yParameters = new List<fmDisplayingYListOfArrays>();
                
                if (internalSelectedSimList.Count == 0)
                {
                    return;
                }

                fmDisplayingArray xArray = new fmDisplayingArray();
                displayingResults.xParameter = xArray;

                xArray.Parameter = xParameter;
                xArray.Values = new fmValue[internalSelectedSimList[0].calculatedDataList.Count];
                for (int i = 0; i < internalSelectedSimList[0].calculatedDataList.Count; ++i)
                {
                    xArray.Values[i] =
                        internalSelectedSimList[0].calculatedDataList[i].parameters[xParameter].ValueInUnits;
                }

                Dictionary<fmGlobalParameter, fmValue> degreeOffset = CreateDegreeOffsets(yParameters);

                Color[] colors = new Color[] {Color.Blue, Color.Green, Color.Red, Color.Black};
                int colorId = 0;

                foreach (fmGlobalParameter yParameter in yParameters)
                {
                    fmDisplayingYListOfArrays yListOfArrays = new fmDisplayingYListOfArrays();
                    yListOfArrays.Parameter = yParameter;
                    yListOfArrays.Arrays = new List<fmDisplayingArray>();

                    foreach (fmSelectedSimulationData simData in internalSelectedSimList)
                    {
                        if (!simData.isChecked)
                            continue;

                        fmDisplayingArray yArray = new fmDisplayingArray();
                        yArray.Parameter = yParameter;
                        yArray.Values = new fmValue[simData.calculatedDataList.Count];
                        yArray.Scale = yParameters.Count > 2 ? degreeOffset[yParameter] : new fmValue(1);
                        yArray.IsY2Axis = colorId == 1 && yParameters.Count == 2;
                        yArray.Color = colors[colorId];
                        yArray.Bold = selectedSimulationParametersTable.CurrentCell != null
                                      &&
                                      internalSelectedSimList.IndexOf(simData) ==
                                      selectedSimulationParametersTable.CurrentCell.RowIndex;

                        for (int i = 0; i < simData.calculatedDataList.Count; ++i)
                        {
                            yArray.Values[i] = simData.calculatedDataList[i].parameters[yParameter].ValueInUnits;
                        }

                        yListOfArrays.Arrays.Add(yArray);
                    }

                    if (++colorId == colors.Length) colorId = 0;

                    displayingResults.yParameters.Add(yListOfArrays);
                }
            }
            else
            {
                displayingResults.yParameters = new List<fmDisplayingYListOfArrays>();
                
                if (localInputParametersList.Count == 0
                    || localInputParametersList[0].calculatedDataLists.Count == 0)
                {
                    return;
                }

                fmDisplayingArray xArray = new fmDisplayingArray();
                displayingResults.xParameter = xArray;

                xArray.Parameter = xParameter;
                int pointsCount = localInputParametersList[0].calculatedDataLists[0].Count;
                xArray.Values = new fmValue[pointsCount];
                for (int i = 0; i < pointsCount; ++i)
                {
                    xArray.Values[i] =
                        localInputParametersList[0].calculatedDataLists[0][i].parameters[xParameter].ValueInUnits;
                }

                Dictionary<fmGlobalParameter, fmValue> degreeOffset = CreateDegreeOffsets(yParameters);

                Color[] colors = new Color[] { Color.Blue, Color.Green, Color.Red, Color.Black };
                int colorId = 0;

                foreach (fmGlobalParameter yParameter in yParameters)
                {
                    fmDisplayingYListOfArrays yListOfArrays = new fmDisplayingYListOfArrays();
                    yListOfArrays.Parameter = yParameter;
                    yListOfArrays.Arrays = new List<fmDisplayingArray>();

                    foreach (fmLocalInputParametersData localParameters in localInputParametersList)
                    {
                        if (!localParameters.isChecked)
                            continue;

                        foreach (List<fmFilterSimulationData> list in localParameters.calculatedDataLists)
                        {
                            fmDisplayingArray yArray = new fmDisplayingArray();
                            yArray.Parameter = yParameter;
                            yArray.Values = new fmValue[pointsCount];
                            yArray.Scale = yParameters.Count > 2 ? degreeOffset[yParameter] : new fmValue(1);
                            yArray.IsY2Axis = colorId == 1 && yParameters.Count == 2;
                            yArray.Color = colors[colorId];
                            yArray.Bold = additionalParametersTable.CurrentCell != null
                                          && localInputParametersList.IndexOf(localParameters) ==
                                             additionalParametersTable.CurrentCell.RowIndex;

                            for (int i = 0; i < list.Count; ++i)
                            {
                                yArray.Values[i] = list[i].parameters[yParameter].ValueInUnits;
                            }

                            yListOfArrays.Arrays.Add(yArray);
                        }
                    }

                    if (++colorId == colors.Length) colorId = 0;
                    displayingResults.yParameters.Add(yListOfArrays);
                }
            }
        }

        private Dictionary<fmGlobalParameter, fmValue> CreateDegreeOffsets(List<fmGlobalParameter> yParameters)
        {
            Dictionary<fmGlobalParameter, fmValue> degreeOffset = new Dictionary<fmGlobalParameter, fmValue>();
            Dictionary<fmValue, int> degreeOffsetCount = new Dictionary<fmValue, int>();

            foreach (fmGlobalParameter yParameter in yParameters)
            {
                fmValue maxY = -fmValue.Infinity();
                foreach (fmSelectedSimulationData simData in internalSelectedSimList)
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
            fmValue bestDegreeOffset = new fmValue(1);
            foreach (KeyValuePair<fmValue, int> pair in degreeOffsetCount)
            {
                if (pair.Value > bestValue)
                {
                    bestValue = pair.Value;
                    bestDegreeOffset = pair.Key;
                }
            }

            Dictionary<fmGlobalParameter, fmValue> resultDegreeOffset = new Dictionary<fmGlobalParameter, fmValue>();
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

            fmGlobalParameter xParameter = fmGlobalParameter.ParametersByName[listBoxXAxis.Text];

            if (!isUseLocalParams)
            {
                foreach (fmSelectedSimulationData simData in internalSelectedSimList)
                {
                    double xStart = xParameter.chartCurretXRange.MinValue
                        / xParameter.unitFamily.CurrentUnit.Coef;
                    double xEnd = xParameter.chartCurretXRange.MaxValue
                        / xParameter.unitFamily.CurrentUnit.Coef;

                    List<double> xList = CreateXValues(xStart, xEnd, RowsQuantity);

                    simData.calculatedDataList = new List<fmFilterSimulationData>();

                    foreach (double x in xList)
                    {
                        fmFilterSimulationData tempSim = new fmFilterSimulationData();
                        tempSim.CopyIsInputedFrom(simData.internalSimulationData);
                        tempSim.CopyValuesFrom(simData.externalSimulation.Data);
                        tempSim.parameters[xParameter].value = new fmValue(x * xParameter.unitFamily.CurrentUnit.Coef);

                        fmSuspensionCalculator suspensionCalculator = new fmSuspensionCalculator(tempSim.parameters.Values);
                        suspensionCalculator.calculationOption = simData.internalSimulationData.suspensionCalculationOption;
                        suspensionCalculator.DoCalculations();

                        fmEps0Kappa0Calculator eps0Kappa0Calculator = new fmEps0Kappa0Calculator(tempSim.parameters.Values);
                        eps0Kappa0Calculator.DoCalculations();

                        fmPc0Rc0A0Calculator pc0rc0a0Calculator = new fmPc0Rc0A0Calculator(tempSim.parameters.Values);
                        pc0rc0a0Calculator.DoCalculations();

                        fmRm0HceCalculator rm0hceCalculator = new fmRm0HceCalculator(tempSim.parameters.Values);
                        rm0hceCalculator.DoCalculations();

                        fmFilterMachiningCalculator filterMachiningCalculator = new fmFilterMachiningCalculator(tempSim.parameters.Values);
                        filterMachiningCalculator.calculationOption = simData.internalSimulationData.filterMachiningCalculationOption;
                        filterMachiningCalculator.DoCalculations();

                        simData.calculatedDataList.Add(tempSim);
                    }
                }
            }
            else
            {
                foreach (fmLocalInputParametersData localParameters in localInputParametersList)
                {
                    localParameters.calculatedDataLists = new List<List<fmFilterSimulationData>>();
                    foreach (fmFilterSimulation sim in externalSimList)
                    {
                        double xStart = xParameter.chartCurretXRange.MinValue
                            / xParameter.unitFamily.CurrentUnit.Coef;
                        double xEnd = xParameter.chartCurretXRange.MaxValue
                            / xParameter.unitFamily.CurrentUnit.Coef;

                        List<double> xList = CreateXValues(xStart, xEnd, RowsQuantity);

                        List<fmFilterSimulationData> calculatedDataList = new List<fmFilterSimulationData>();

                        foreach (double x in xList)
                        {
                            fmFilterSimulationData tempSim = new fmFilterSimulationData();
                            fmFilterSimulationData.CopyAllParametersFromBlockToSimulation(localParameters.filterMachiningBlock, tempSim);
                            tempSim.CopyMaterialParametersValuesFrom(sim.Data);
                            tempSim.parameters[xParameter].value = new fmValue(x * xParameter.unitFamily.CurrentUnit.Coef);

                            fmFilterMachiningCalculator filterMachiningCalculator = new fmFilterMachiningCalculator(tempSim.parameters.Values);
                            filterMachiningCalculator.calculationOption = localParameters.filterMachiningBlock.calculationOption;
                            filterMachiningCalculator.DoCalculations();

                            calculatedDataList.Add(tempSim);
                        }

                        localParameters.calculatedDataLists.Add(calculatedDataList);
                    }
                }
            }
        }

        private List<double> CreateXValues(double xStart, double xEnd, int minimalNodesAmount)
        {
            double[] X = {1, 1.25, 2, 2.5, 5};
            const double eps = 1e-9;

            const int maxPower = 15;

            for (int power = maxPower; power >= -maxPower; --power)
                for (int xIndex = X.Length - 1; xIndex >= 0; --xIndex)
                {
                    double x = X[xIndex];
                    double dx = x * Math.Pow(10.0, power);
                    double nodesCount = 2 + Math.Floor(xEnd / dx - eps) - Math.Floor(xStart / dx + eps);
                    if (nodesCount >= minimalNodesAmount)
                    {
                        List<double> result = new List<double>();
                        result.Add(xStart);
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
            List<string> inputNames = new List<string>();

            List<fmGlobalParameter> simInputParameters = GetCommonInputParametersList();
            
            foreach (fmGlobalParameter p in simInputParameters)
            {
                inputNames.Add(p.name);
            }
        
            FillListBox(listBoxXAxis, inputNames);
            //int indexX = listBoxXAxis.Items.IndexOf("n");
            //if (indexX == -1) indexX = 0;
            //if (listBoxXAxis.Items.Count > indexX)
            //    listBoxXAxis.SelectedItem = listBoxXAxis.Items[indexX];

            List<string> outputNames = new List<string>();

            foreach (fmGlobalParameter p in fmGlobalParameter.Parameters)
            {
                if (yAxisListParametersToDisplay.Contains(p))
                {
                    outputNames.Add(p.name);
                }
            }

            FillListBox(listBoxYAxis, outputNames);
            //int indexY = listBoxYAxis.Items.IndexOf("hc");
            //if (indexY == -1) indexY = 0;
            //if (listBoxYAxis.Items.Count > indexY)
            //    listBoxYAxis.SelectedItem = listBoxYAxis.Items[indexY];
        }

        private List<fmGlobalParameter> GetCommonInputParametersList()
        {
            if (!isUseLocalParams)
            {
                List<fmGlobalParameter> simInputParameters = new List<fmGlobalParameter>(fmGlobalParameter.Parameters);
                foreach (fmSelectedSimulationData simData in internalSelectedSimList)
                    //if (simData.isChecked)
                        simInputParameters = ParametersListsIntersection(simInputParameters,
                                                                         simData.internalSimulationData.
                                                                             GetParametersThatCanBeInputedList());
                return simInputParameters;
            }
            else
            {
                List<fmGlobalParameter> simInputParameters = new List<fmGlobalParameter>(fmGlobalParameter.Parameters);
                foreach (fmLocalInputParametersData localParameters in localInputParametersList)
                    simInputParameters = ParametersListsIntersection(simInputParameters,
                                                              CalculationOptionHelper.GetParametersListThatCanBeInput(
                                                                  localParameters.filterMachiningBlock.calculationOption));
                return simInputParameters;
            }
        }

        private List<fmGlobalParameter> ParametersListsIntersection(List<fmGlobalParameter> a, List<fmGlobalParameter> b)
        {
            List<fmGlobalParameter> result = new List<fmGlobalParameter>();
            foreach (fmGlobalParameter p in fmGlobalParameter.Parameters)
                if (a.Contains(p) && b.Contains(p))
                    result.Add(p);
            return result;
        }

        private List<fmGlobalParameter> ParametersListsUnion(List<fmGlobalParameter> a, List<fmGlobalParameter> b)
        {
            List<fmGlobalParameter> result = new List<fmGlobalParameter>();
            foreach (fmGlobalParameter p in fmGlobalParameter.Parameters)
                if (a.Contains(p) || b.Contains(p))
                    result.Add(p);
            return result;
        }

        private void UpdateInternalSelectedSimList(List<fmFilterSimulation> simList)
        {
            List<fmSelectedSimulationData> newInternalSelectedSimList = new List<fmSelectedSimulationData>();
            foreach (fmFilterSimulation sim in simList)
            {
                fmSelectedSimulationData newSelectedSim = null;
                foreach (fmSelectedSimulationData checkedSim in internalSelectedSimList)
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
            internalSelectedSimList = newInternalSelectedSimList;
        }
    }
}
