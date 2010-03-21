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
    public partial class FilterSimulationWithTablesAndGraphs
    {
        private List<fmFilterSimulation> externalSimList;
        //private fmFilterSimulation externalCurrentSimulation;
        private List<fmSelectedSimulationData> internalSelectedSimList;
        //private List<fmFilterMachiningBlock> fmGlobalBlocks;
        //private List<fmAdditionalFilterMachiningBlock> fmLocalBlocks = new List<fmAdditionalFilterMachiningBlock>();
        //private List<fmSelectedFilterMachiningBlock> fmSelectedBlocks = new List<fmSelectedFilterMachiningBlock>();
        //private fmFilterMachiningBlock fmInputsInfoForSelectedSimulationsTableBlock;
        //public fmFilterMachiningBlock currentSimFMB;
        private bool isUseLocalParams;
        //private readonly Color Y1AxColor = Color.Blue;
        //private readonly Color Y2AxColor = Color.Green;
        private int RowsQuantity = 30;
        //private fmSelectedFilterMachiningBlock currentBlock;
        //private const int SOLID_CURVE_WIDTH = 2;
        //private const int CUSTOM_CURVE_WIDTH = 1;
        //private static readonly Color SELECTED_COLUMN_COLOR = Color.LightBlue;
        //private bool processingCalculationOptionViewCheckChanged = false;
        private bool loadingXRange = false;

        private void FillListBox(ListBox listBox, List<string> strings)
        {
            //listBox.Items.Clear();
            //foreach (string s in strings)
            //{
            //    listBox.Items.Add(s);
            //}
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
            //List<fmBlockParameter> blockParameterList =
              //  new fmFilterMachiningBlock(calculationOptionViewInTablesAndGraphs).Parameters;
            List<fmGlobalParameter> allSimParams = new List<fmGlobalParameter>((new fmFilterSimulation()).Parameters.Keys);

            //foreach (fmBlockParameter p in blockParameterList)
            foreach (fmGlobalParameter p in allSimParams)
            {
                {
                    DataGridViewColumn col = additionalParametersTable.AddColumn<DataGridViewNumericalTextBoxColumn>(p.name);
                    col.Width = 50;
                }

                {
                    DataGridViewColumn col = selectedSimulationParametersTable.AddColumn<DataGridViewNumericalTextBoxColumn>(p.name);
                    col.Width = 50;
                    col.ReadOnly = true;
                }
            }

            UpdateUnitsInTablesAndGraphs();
        }

        //private void AddRow()
        //{
        //    additionalParametersTable.Rows.Add();
        //    DataGridViewRow row = additionalParametersTable.Rows[additionalParametersTable.Rows.Count - 1];
        //    row.Cells["AdditionalParametersCheckBoxColumn"].Value = true;
        //    fmAdditionalFilterMachiningBlock fmb = new fmAdditionalFilterMachiningBlock(true, calculationOptionViewInTablesAndGraphs,
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.A.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Dp.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.sf.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.n.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.tc.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.tf.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.tr.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.hc_over_tf.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.dhc_over_dt.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.hc.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Mf.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Vf.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.mf.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.vf.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.ms.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.vs.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.msus.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.vsus.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.mc.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.vc.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Msus.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Vsus.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Vc.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Mc.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Ms.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Vs.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qf.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qf_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qs.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qs_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qc.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qc_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qsus.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qsus_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmsus.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmsus_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qms.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qms_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmf.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmf_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmc.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmc_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qf.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qf_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qs.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qs_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qc.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qc_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qsus.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qsus_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmsus.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmsus_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qms.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qms_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmf.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmf_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmc.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.qmc_d.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.eps.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.kappa.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Pc.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.rc.name)],
        //                                                            row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.a.name)]);
        //    fmb.ValuesChangedByUser += fmb_ValuesChangedByUser;
        //    fmLocalBlocks.Add(fmb);

        //    fmb.CopyValues(currentSimFMB);
        //    fmb.CalculateAndDisplay();

        //    UpdateIsInputedForParametersBlocks();
        //}

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

        //private void AddCurve(fmValue[] aVx, fmValue[] aVy, Color color, SymbolType symbol, bool isY2Axis, bool isVisible, bool isBold)
        //{
        //    List<double> lx = new List<double>();
        //    List<double> ly = new List<double>();
        //    for (int i = 0; i < aVx.Length; ++i)
        //    {
        //        if (aVx[i].Defined && aVy[i].Defined)
        //        {
        //            lx.Add(aVx[i].Value);
        //            ly.Add(aVy[i].Value);
        //        }
        //    }
        //    double[] ax = new double[lx.Count];
        //    double[] ay = new double[ly.Count];
        //    for (int i = 0; i < lx.Count; ++i)
        //    {
        //        ax[i] = lx[i];
        //        ay[i] = ly[i];
        //        if (i > 0 && IsAlmostEqual(ay[i - 1], ay[i]))
        //        {
        //            ay[i] = ay[i - 1];
        //        }
        //    }
        //    LineItem curve = fmZedGraphControl1.AddCurve("curve", ax, ay, color, SymbolType.None);
        //    curve.IsY2Axis = isY2Axis;
        //    curve.IsVisible = isVisible;
        //    curve.Line.Width = isBold ? SOLID_CURVE_WIDTH : CUSTOM_CURVE_WIDTH;
        //}

        //private bool IsAlmostEqual(double val1, double val2)
        //{
        //    return Math.Abs(val1 - val2) < 1e-12 * (Math.Abs(val1) + Math.Abs(val2));
        //}

        //private void AddColumn(fmValue[] aVy, fmBlockParameter parameter, bool isVisible, bool isSelected)
        //{
        //    DataGridViewNumericalTextBoxColumn col = new DataGridViewNumericalTextBoxColumn();
        //    string yColId = string.Empty;
        //    col.HeaderText = parameter.name + yColId + " (" + parameter.unitFamily.CurrentUnit.Name + ")";
        //    col.ReadOnly = true;
        //    col.Width = 50;

        //    int idx = GetColumnIndexByHeader(coordinatesGrid, parameter.name);
        //    if (idx > -1)
        //    {
        //        coordinatesGrid.Columns.Insert(idx + 1, col);
        //    }
        //    else
        //    {
        //        coordinatesGrid.Columns.Add(col);
        //    }

        //    for (int i = 0; i < aVy.Length; i++)
        //    {
        //        if (i + 1 > coordinatesGrid.Rows.Count)
        //        {
        //            coordinatesGrid.Rows.Add();
        //        }
        //        coordinatesGrid[col.Index, i].Value = aVy[i];
        //    }
        //    col.Visible = isVisible;
        //    if (isSelected)
        //    {
        //        SetColumnColor(col);
        //    }

        //}

        private void DrawChartAndTable()
        {
            //if (!processingCalculationOptionViewCheckChanged)
            //{
            //    if (fmGlobalBlocks == null)
            //    {
            //        return;
            //    }

            //    foreach (fmAdditionalFilterMachiningBlock localFMB in fmLocalBlocks)
            //    {
            //        localFMB.CopyConstants(currentSimFMB);
            //        localFMB.CalculateAndDisplay();
            //    }

            //    int xAxisParameterIndex = GetFilterMachiningBlockParameterIndexByName(listBoxXAxis.Text);
            //    int yAxisParameterIndex = GetFilterMachiningBlockParameterIndexByName(listBoxYAxis.Text);
            //    int y2AxisParameterIndex = GetFilterMachiningBlockParameterIndexByName(listBoxY2Axis.Text);

            //    SetUpChartAxis(xAxisParameterIndex, yAxisParameterIndex, y2AxisParameterIndex);
            //    fmValue currentSelectedXValue = SetUpResultTable();

            //    DrawCurvesAndColumnsForAxis(xAxisParameterIndex, yAxisParameterIndex, -1, SymbolType.Circle);
            //    DrawCurvesAndColumnsForAxis(xAxisParameterIndex, -1, y2AxisParameterIndex, SymbolType.Circle);

            //    if (currentSelectedXValue.Defined)
            //    {
            //        for (int i = 0; i < coordinatesGrid.RowCount; ++i)
            //        {
            //            fmValue curValue = coordinatesGrid.CurrentCell == null
            //                                   ? new fmValue()
            //                                   : fmValue.ObjectToValue(coordinatesGrid.CurrentCell.Value);
            //            fmValue newValue = fmValue.ObjectToValue(coordinatesGrid.Rows[i].Cells[0].Value);
            //            if (newValue.Defined
            //                && (!curValue.Defined || fmValue.Abs(newValue - currentSelectedXValue) < fmValue.Abs(curValue - currentSelectedXValue)))
            //            {
            //                coordinatesGrid.CurrentCell = coordinatesGrid.Rows[i].Cells[0];
            //            }
            //        }
            //    }
            //    fmZedGraphControl1.AxisChange();
            //    fmZedGraphControl1.Refresh();
            //}
        }

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

        //private void DrawCurvesAndColumnsForAxis(int xAxisParameterIndex, int yAxisParameterIndex, int y2AxisParameterIndex, SymbolType symbol)
        //{
        //    if (isUseLocalParams)
        //    {
        //        foreach (fmFilterMachiningBlock globalFMB in fmGlobalBlocks)
        //        {
        //            fmAdditionalFilterMachiningBlock tmp = new fmAdditionalFilterMachiningBlock(true,
        //                                                                                        calculationOptionViewInTablesAndGraphs);
        //            tmp.CalculationOption = fmLocalBlocks[0].CalculationOption;
        //            tmp.CopyValues(globalFMB);

        //            for (int j = 0; j < fmLocalBlocks.Count; j++)
        //            {
        //                fmAdditionalFilterMachiningBlock localFMB = fmLocalBlocks[j];
        //                tmp.IsDrawn = localFMB.IsDrawn;
        //                List<fmGlobalParameter> inputParameters = CalculationOptionHelper.
        //                    GetParametersListThatCanBeInput(calculationOptionViewInTablesAndGraphs.GetSelectedOption());

        //                for (int i = 0; i < tmp.Parameters.Count; ++i)
        //                {
        //                    fmBlockParameter p = tmp.Parameters[i];
        //                    if (inputParameters.Contains(p.globalParameter))
        //                    {
        //                        p.value = localFMB.Parameters[i].value;
        //                    }
        //                    p.isInputed = localFMB.Parameters[i].isInputed;
        //                }

        //                DrawCurveAndColumn(xAxisParameterIndex, tmp, yAxisParameterIndex, y2AxisParameterIndex,
        //                                   symbol, globalFMB == currentSimFMB && additionalParametersTable.CurrentCell != null && j == additionalParametersTable.CurrentCell.RowIndex);
        //                symbol++;
        //            }
        //        }
        //    }
        //    if (!isUseLocalParams)
        //    {
        //        for (int i = 0; i < fmSelectedBlocks.Count; i++)
        //        {
        //            fmSelectedFilterMachiningBlock selectedBlock = fmSelectedBlocks[i];
        //            fmAdditionalFilterMachiningBlock tempBlock = new fmAdditionalFilterMachiningBlock(true,
        //                                                                                        calculationOptionViewInTablesAndGraphs);
        //            tempBlock.CalculationOption = fmLocalBlocks[0].CalculationOption;
        //            tempBlock.CopyValues(selectedBlock.filterMachiningBlock);

        //            for (int parameterIndex = 0; parameterIndex < tempBlock.Parameters.Count; ++parameterIndex)
        //            {
        //                tempBlock.Parameters[parameterIndex].isInputed = fmInputsInfoForSelectedSimulationsTableBlock.Parameters[parameterIndex].isInputed;
        //            }

        //            //foreach (fmBlockParameter p in tempBlock.Parameters)
        //            //{
        //            //    if (p.name == listBoxXAxis.Text)
        //            //        tempBlock.UpdateIsInputed(p);
        //            //}

        //            tempBlock.IsDrawn = selectedBlock.IsChecked;
        //            DrawCurveAndColumn(xAxisParameterIndex, tempBlock, yAxisParameterIndex, y2AxisParameterIndex, symbol, selectedSimulationParametersTable.CurrentCell != null ? i == selectedSimulationParametersTable.CurrentCell.RowIndex : false);
        //            symbol++;
        //        }
        //    }
        //}

        //private void DrawCurveAndColumn(int xAxisParameterIndex, fmAdditionalFilterMachiningBlock addFilterMachBlock, int yAxisParameterIndex, int y2AxisParameterIndex, SymbolType symbol, bool isBold)
        //{
        //    if (xAxisParameterIndex != -1 && yAxisParameterIndex != -1)
        //    {
        //        CreateAddCurveColumn(xAxisParameterIndex, yAxisParameterIndex, addFilterMachBlock, symbol, Y1AxColor, false, isBold);
        //        symbol++;
        //    }
        //    if (xAxisParameterIndex != -1 && y2AxisParameterIndex != -1)
        //    {
        //        CreateAddCurveColumn(xAxisParameterIndex, y2AxisParameterIndex, addFilterMachBlock, symbol, Y2AxColor, true, isBold);
        //    }
        //}

        //private void CreateAddCurveColumn(int xAxisParameterIndex, int yAxisParameterIndex, fmAdditionalFilterMachiningBlock machiningBlock, SymbolType symbol, Color color, bool isY2Axis, bool isBold)
        //{
        //    fmValue[] aVy; fmValue[] aVx;
        //    CalculateCurve(machiningBlock, xAxisParameterIndex, yAxisParameterIndex, out aVx, out aVy);
        //    AddCurve(aVx, aVy, color, symbol, isY2Axis, machiningBlock.IsDrawn, isBold);
        //    DrawColumns(machiningBlock, xAxisParameterIndex, yAxisParameterIndex, isBold);
        //}

        //private void DrawColumns(fmAdditionalFilterMachiningBlock machiningBlock, int xAxisParameterIndex, int yAxisParameterIndex, bool isSelected)
        //{
        //    fmValue[] aVx, aVy;
        //    CalculateCurve(machiningBlock, xAxisParameterIndex, yAxisParameterIndex, out aVx, out aVy);

        //    CreateValuesForGrid(machiningBlock, xAxisParameterIndex, yAxisParameterIndex, out aVx, out aVy);
        //    if (coordinatesGrid.Columns.Count == 0)
        //    {
        //        AddColumn(aVx, machiningBlock.Parameters[xAxisParameterIndex], true, false);
        //    }
        //    AddColumn(aVy, machiningBlock.Parameters[yAxisParameterIndex], machiningBlock.IsDrawn, isSelected);
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
                fmFilterSimulation sim = internalSelectedSimList[i].externalSimulation;
                fmFilterSimulation tempSim = new fmFilterSimulation(null, sim);
                tempSim.FilterMachiningCalculationOption = calculationOptionViewInTablesAndGraphs.GetSelectedOption();

                DataGridViewRow row =
                    selectedSimulationParametersTable.Rows[selectedSimulationParametersTable.Rows.Add()];
                row.Cells["SelectedSimulationParametersCheckBoxColumn"].Value = internalSelectedSimList[i].isChecked;

                foreach (fmGlobalParameter param in tempSim.Parameters.Keys)
                {
                    int idx = GetColumnIndexByHeader(selectedSimulationParametersTable, param.name);
                    row.Cells[idx].Value = tempSim.Parameters[param].value / param.unitFamily.CurrentUnit.Coef;
                }

                fmFilterMachiningBlock tempBlock = new fmFilterMachiningBlock(null);
                tempBlock.CalculationOption = sim.FilterMachiningCalculationOption;
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
            
            //UpdateColorsForInputsAndOutputsInSelectedSimulationsTable();
            UpdateVisibilityOfColumnsInSelectedSimulationsTable();
        }

        private void UpdateVisibilityOfColumnsInSelectedSimulationsTable()
        {
            List<fmGlobalParameter> inputs = CalculationOptionHelper.GetParametersListThatCanBeInput(
                calculationOptionViewInTablesAndGraphs.GetSelectedOption());
            
            foreach (DataGridViewColumn col in selectedSimulationParametersTable.Columns)
            {
                string parName = GetParameterNameFromHeader(col.HeaderText);
                if (fmGlobalParameter.ParametersByName.ContainsKey(parName))
                {
                    fmGlobalParameter par = fmGlobalParameter.ParametersByName[parName];
                    col.Visible = inputs.Contains(par);
                }
            }
        }

        //private void UpdateColorsForInputsAndOutputsInSelectedSimulationsTable()
        //{
        //    for (int i = 0; i < fmSelectedBlocks.Count; i++)
        //    {
        //        fmAdditionalFilterMachiningBlock tempBlock = new fmAdditionalFilterMachiningBlock(true,
        //                                                                                          calculationOptionViewInTablesAndGraphs);
        //        for (int parameterIndex = 0; parameterIndex < tempBlock.Parameters.Count; ++parameterIndex)
        //        {
        //            tempBlock.Parameters[parameterIndex].isInputed = fmInputsInfoForSelectedSimulationsTableBlock.Parameters[parameterIndex].isInputed;
        //        }
        //        //foreach (fmBlockParameter p in tempBlock.Parameters)
        //        //{
        //        //    if (p.name == listBoxXAxis.Text)
        //        //        tempBlock.UpdateIsInputed(p);
        //        //}
                
        //        DataGridViewRow row = selectedSimulationParametersTable.Rows[i];
                
        //        foreach (fmBlockParameter param in tempBlock.Parameters)
        //        {
        //            int idx = GetColumnIndexByHeader(selectedSimulationParametersTable, param.name);
        //            row.Cells[idx].Style.ForeColor = param.isInputed ? Color.Blue : Color.Black;
        //        }
        //    }
        //}

        //private static void FindDxForKIntermediatePoints(double a, double b, int K, out double dx, out double x1)
        //{
        //    double[] X = { 1, 1.25, 2, 2.5, 5 };
        //    const double eps = 1e-9;

        //    const int maxPower = 15;
        //    dx = Math.Pow(10.0, -maxPower - 1);
        //    x1 = 0;

        //    for (int power = -maxPower; power <= maxPower; ++power)
        //        foreach (double x in X)
        //        {
        //            double newDx = x * Math.Pow(10.0, power);
        //            double KCount = Math.Floor(b / newDx - eps) - Math.Floor(a / newDx + eps);
        //            if (KCount < K)
        //            {
        //                double t = Math.Ceiling(a / dx + eps);
        //                x1 = dx * t;
        //                return;
        //            }
        //            dx = newDx;
        //        }
        //}

        //private void CalculateCurve(fmFilterMachiningBlock tmp, int xAxisParameterIndex, int yAxisParameterIndex, out fmValue[] aax1, out fmValue[] aay1)
        //{
        //    aax1 = aay1 = null;

        //    if (xAxisParameterIndex == -1 || yAxisParameterIndex == -1)
        //        return;

        //    List<fmValue> ax1 = new List<fmValue>();
        //    List<fmValue> ay1 = new List<fmValue>();
        //    const int steps = 30;
        //    double max = tmp.Parameters[xAxisParameterIndex].globalParameter.chartCurretXRange.maxValue;
        //    double min = tmp.Parameters[xAxisParameterIndex].globalParameter.chartCurretXRange.minValue;
        //    double diaposon = max - min;

        //    for (int i = 0; i < steps; ++i)
        //    {
        //        double x = min + diaposon * i / (steps - 1);
        //        tmp.Parameters[xAxisParameterIndex].value = new fmValue(x);
        //        tmp.DoCalculations();
        //        ax1.Add(tmp.Parameters[xAxisParameterIndex].value /
        //               tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Coef);
        //        ay1.Add(tmp.Parameters[yAxisParameterIndex].value /
        //               tmp.Parameters[yAxisParameterIndex].unitFamily.CurrentUnit.Coef);
        //    }

        //    aax1 = new fmValue[ax1.Count];
        //    aay1 = new fmValue[ay1.Count];
        //    for (int i = 0; i < ax1.Count; ++i)
        //    {
        //        aax1[i] = ax1[i];
        //        aay1[i] = ay1[i];
        //    }
        //}

        //private static void SetColumnColor(DataGridViewColumn column)
        //{
        //    column.DefaultCellStyle.BackColor = SELECTED_COLUMN_COLOR;
        //}

        private static string GetParameterNameFromHeader(string headerText)
        {
            string[] s = headerText.Split('(');
            return s[0].Trim();
        }

        //private int GetFilterMachiningBlockParameterIndexByName(string parameterName)
        //{
        //    fmFilterMachiningBlock tmp = new fmFilterMachiningBlock(calculationOptionViewInTablesAndGraphs);
        //    for (int index = 0; index < tmp.Parameters.Count; ++index)
        //    {
        //        fmBlockParameter p = tmp.Parameters[index];
        //        if (p.name == parameterName)
        //        {
        //            return index;
        //        }
        //    }
        //    return -1;
        //}

        private static int GetColumnIndexByHeader(DataGridView grid, string header)
        {
            for (int i = grid.Columns.Count - 1; i >= 0; i--)
            {
                if (GetParameterNameFromHeader(grid.Columns[i].HeaderText) == header)
                    return i;
            }
            return -1;
        }

        //private static Predicate<fmSelectedFilterMachiningBlock> ByFilterMachiningBlock(fmFilterMachiningBlock fmb)
        //{
        //    return delegate(fmSelectedFilterMachiningBlock block)
        //    {
        //        return block.filterMachiningBlock == fmb;
        //    };
        //}

        //private fmValue SetUpResultTable()
        //{
        //    DataGridViewCell currentCell = coordinatesGrid.CurrentCell;
        //    int currentRow = currentCell != null ? currentCell.RowIndex : -1;
        //    object cellValue = currentRow != -1 ? coordinatesGrid[0, currentRow].Value : null;
        //    fmValue result = cellValue == null ? new fmValue() : fmValue.ObjectToValue(cellValue);

        //    coordinatesGrid.Columns.Clear();

        //    return result;
        //}

        #region events

        //private void fmb_ValuesChangedByUser(object sender, fmBlockParameterEvetArgs e)
        //{
        //    DrawChartAndTable();
        //}

        private void additionalParametersTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        //    if (additionalParametersTable.Rows.Count > 1
        //        && additionalParametersTable.Columns[e.ColumnIndex].Name == "DeleteButtonColumn")
        //    {
        //        fmLocalBlocks.RemoveAt(e.RowIndex);
        //        additionalParametersTable.Rows.RemoveAt(e.RowIndex);
        //        DrawChartAndTable();
        //    }
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
            LoadCurrentXRange();
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToTable();
            BindCalculatedResultsToChart();
        //    UpdateIsInputedForParametersBlocks();
        //    UpdateColorsForInputsAndOutputsInSelectedSimulationsTable();
        //    LoadCurrentXRange();
        //    DrawChartAndTable();
        }

        private void LoadCurrentXRange()
        {
            if (listBoxXAxis.Text == "")
                return;

            loadingXRange = true;
            //int xAxisParameterIndex = GetFilterMachiningBlockParameterIndexByName(listBoxXAxis.Text);
            //fmFilterMachiningBlock tmpFMB = new fmFilterMachiningBlock(null);
            //fmRange range = tmpFMB.Parameters[xAxisParameterIndex].globalParameter.chartCurretXRange;
            fmGlobalParameter xParameter = fmGlobalParameter.ParametersByName[listBoxXAxis.Text];
            double coef = xParameter.unitFamily.CurrentUnit.Coef;
            fmRange range = xParameter.chartCurretXRange;
            minXValueTextBox.Text = (range.minValue / coef).ToString();
            maxXValueTextBox.Text = (range.maxValue / coef).ToString();
            loadingXRange = false;
        }

        //private void LoadDefaultXRange()
        //{
        //    loadingXRange = true;
        //    int xAxisParameterIndex = GetFilterMachiningBlockParameterIndexByName(listBoxXAxis.Text);
        //    fmFilterMachiningBlock tmpFMB = new fmFilterMachiningBlock(null);
        //    double coef = tmpFMB.Parameters[xAxisParameterIndex].globalParameter.unitFamily.CurrentUnit.Coef;
        //    fmRange defaultRange = tmpFMB.Parameters[xAxisParameterIndex].globalParameter.chartDefaultXRange;
        //    fmRange range = tmpFMB.Parameters[xAxisParameterIndex].globalParameter.chartCurretXRange;
        //    range.minValue = defaultRange.minValue;
        //    range.maxValue = defaultRange.maxValue;
        //    minXValueTextBox.Text = (range.minValue / coef).ToString();
        //    maxXValueTextBox.Text = (range.maxValue / coef).ToString();
        //    loadingXRange = false;
        //}

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
        //    AddRow();
        //    DrawChartAndTable();
        }

        private void UseParamsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ReadUseParamsCheckBoxAndApply();
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
        //    DataGridView dgv = sender as DataGridView;
        //    if (dgv != null && dgv.CurrentCell != null)
        //    {
        //        DrawChartAndTable();
        //    }
        }

        private void selectedSimulationParametersTable_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
        //    if (selectedSimulationParametersTable.Columns[e.ColumnIndex].Name == "SelectedSimulationParametersCheckBoxColumn"
        //        && fmSelectedBlocks.Count > e.RowIndex)
        //    {
        //        fmSelectedBlocks[e.RowIndex].IsChecked = (bool)selectedSimulationParametersTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        //        DrawChartAndTable();
        //    }
        }

        private void additionalParametersTable_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
        //    if (additionalParametersTable.Columns[e.ColumnIndex].Name == "AdditionalParametersCheckBoxColumn"
        //        && fmLocalBlocks.Count > e.RowIndex)
        //    {
        //        fmLocalBlocks[e.RowIndex].IsDrawn = (bool)additionalParametersTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        //        DrawChartAndTable();
        //    }
        }

        private void rowsQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rowsQuantity.Text))
            {
                RowsQuantity = (int)fmValue.StringToValue(rowsQuantity.Text).Value;
                rowsQuantity.Text = RowsQuantity.ToString();
                rowsQuantity.Focus();
                RecalculateSimulationsWithIterationX();
                BindCalculatedResultsToChart();
                BindCalculatedResultsToTable();
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

        public void BuildCurves(List<fmFilterSimulation> simList)
        {
            this.externalSimList = simList;
            BindSelectedSimulationListToTable();
            BindXYLists();
            LoadCurrentXRange();
            //DrawChartAndTable();
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToTable();
            BindCalculatedResultsToChart();
        }

        private void BindCalculatedResultsToTable()
        {
            if (listBoxXAxis.Text == ""
                || listBoxYAxis.Text == "")
            {
                return;
            }

            fmGlobalParameter xParameter = fmGlobalParameter.ParametersByName[listBoxXAxis.Text];
            fmGlobalParameter yParameter = fmGlobalParameter.ParametersByName[listBoxYAxis.Text];

            coordinatesGrid.Columns.Clear();

            foreach (fmSelectedSimulationData simData in internalSelectedSimList)
            {
                int xCol = coordinatesGrid.Columns.Add(xParameter.name, xParameter.name);
                coordinatesGrid.Columns[xCol].Width = 50;
                
                int yCol = coordinatesGrid.Columns.Add(yParameter.name, yParameter.name);
                coordinatesGrid.Columns[yCol].Width = 50;

                for (int i = 0; i < simData.calculatedDataList.Count; ++i)
                {
                    if (coordinatesGrid.RowCount< i + 1)
                    {
                        coordinatesGrid.RowCount = i + 1;
                    }
                    coordinatesGrid[xCol, i].Value = simData.calculatedDataList[i].parameters[xParameter].ValueInUnits;
                    coordinatesGrid[yCol, i].Value = simData.calculatedDataList[i].parameters[yParameter].ValueInUnits;
                }
            }
        }

        private void BindCalculatedResultsToChart()
        {
            if (listBoxXAxis.Text == ""
                || listBoxYAxis.Text == "")
            {
                return;
            }

            fmZedGraphControl1.GraphPane.CurveList.Clear();

            fmGlobalParameter xParameter = fmGlobalParameter.ParametersByName[listBoxXAxis.Text];

            Color [] colors = new Color[]{Color.Blue, Color.Green, Color.Red};
            int colorId = 0;

            foreach (string yAxisName in listBoxYAxis.CheckedItems)
            {
                fmGlobalParameter yParameter = fmGlobalParameter.ParametersByName[yAxisName];

                foreach (fmSelectedSimulationData simData in internalSelectedSimList)
                {
                    double[] ax = new double[simData.calculatedDataList.Count];
                    double[] ay = new double[simData.calculatedDataList.Count];

                    for (int i = 0; i < simData.calculatedDataList.Count; ++i)
                    {
                        ax[i] = simData.calculatedDataList[i].parameters[xParameter].ValueInUnits.Value;
                        ay[i] = simData.calculatedDataList[i].parameters[yParameter].ValueInUnits.Value;
                    }

                    LineItem curve = fmZedGraphControl1.GraphPane.AddCurve("", ax, ay, colors[colorId], SymbolType.None);
                    if (listBoxYAxis.CheckedItems.Count == 2 && colorId == 1)
                    {
                        curve.IsY2Axis = true;
                    }
                }

                if (++colorId == colors.Length) colorId = 0;
            }

            fmZedGraphControl1.GraphPane.Y2Axis.IsVisible = listBoxYAxis.CheckedItems.Count == 2;
            fmZedGraphControl1.GraphPane.AxisChange();
            fmZedGraphControl1.Refresh();
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
                    double xStart = xParameter.chartCurretXRange.minValue
                        / xParameter.unitFamily.CurrentUnit.Coef;
                    double xEnd = xParameter.chartCurretXRange.maxValue
                        / xParameter.unitFamily.CurrentUnit.Coef;

                    List<double> xList = CreateXValues(xStart, xEnd, RowsQuantity);

                    simData.calculatedDataList = new List<fmFilterSimulationData>();

                    foreach (double x in xList)
                    {
                        fmFilterSimulationData tempSim = new fmFilterSimulationData();
                        tempSim.CopyIsInputedFrom(simData.externalSimulation.Data);
                        //tempSim.filterMachinigCalculationOption = simData.internalSimulation.filterMachinigCalculationOption;
                        tempSim.CopyValuesFrom(simData.externalSimulation.Data);
                        tempSim.parameters[xParameter].value = new fmValue(x * xParameter.unitFamily.CurrentUnit.Coef);

                        fmSuspensionCalculator suspensionCalculator = new fmSuspensionCalculator(tempSim.parameters.Values);
                        suspensionCalculator.calculationOption = simData.externalSimulation.Data.suspensionCalculationOption;
                        suspensionCalculator.DoCalculations();

                        fmEps0Kappa0Calculator eps0Kappa0Calculator = new fmEps0Kappa0Calculator(tempSim.parameters.Values);
                        eps0Kappa0Calculator.DoCalculations();

                        fmPc0rc0a0Calculator pc0rc0a0Calculator = new fmPc0rc0a0Calculator(tempSim.parameters.Values);
                        pc0rc0a0Calculator.DoCalculations();

                        fmRm0hceCalculator rm0hceCalculator = new fmRm0hceCalculator(tempSim.parameters.Values);
                        rm0hceCalculator.DoCalculations();

                        fmFilterMachiningCalculator filterMachiningCalculator = new fmFilterMachiningCalculator(tempSim.parameters.Values);
                        filterMachiningCalculator.calculationOption = simData.externalSimulation.Data.filterMachinigCalculationOption;
                        filterMachiningCalculator.DoCalculations();

                        simData.calculatedDataList.Add(tempSim);
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

        //private void CopyOnlyParameterValues(fmFilterSimulation src, fmFilterSimulation dst)
        //{
        //    foreach (fmGlobalParameter p in src.Parameters.Keys)
        //        src.Parameters[p].value = dst.Parameters[p].value;
        //}

        private void BindXYLists()
        {
            List<string> inputNames = new List<string>();
            //List<fmGlobalParameter> simInputParameters = CalculationOptionHelper.GetParametersListThatCanBeInput(calculationOptionViewInTablesAndGraphs.GetSelectedOption());

            List<fmGlobalParameter> simInputParameters = new List<fmGlobalParameter>(fmGlobalParameter.Parameters);

            foreach (fmSelectedSimulationData simData in internalSelectedSimList)
                for (int i = simInputParameters.Count - 1; i >= 0; --i)
                   if (!simData.externalSimulation.Parameters.ContainsKey(simInputParameters[i]) 
                       || !(simData.externalSimulation.Parameters[simInputParameters[i]] as fmCalculationVariableParameter).isInputed)
                        simInputParameters.RemoveAt(i);

            //List<fmBlockVariableParameter> susBlockParameters = new fmSuspensionBlock(null, null, null, null, null, null, null, null, null, null).Parameters;
            //List<fmGlobalParameter> susParameters = new List<fmGlobalParameter>();
            //foreach (fmBlockVariableParameter p in susBlockParameters)
            //{
            //    susParameters.Add(p.globalParameter);
            //}
            //List<fmBlockVariableParameter> epsBlockParameters = new fmEps0Kappa0WithneBlock(null, null, null).Parameters;
            //List<fmGlobalParameter> epsParameters = new List<fmGlobalParameter>();
            //foreach (fmBlockVariableParameter p in epsBlockParameters)
            //{
            //    epsParameters.Add(p.globalParameter);
            //}
            //List<fmGlobalParameter> inputs = new List<fmGlobalParameter>();
            //inputs.AddRange(susParameters);
            //inputs.AddRange(epsParameters);
            //inputs.AddRange(simInputParameters);
            foreach (fmGlobalParameter p in simInputParameters)
            {
                inputNames.Add(p.name);
            }
            //List<fmGlobalParameter> simInputParameters = CalculationOptionHelper.GetParametersListThatCanBeInput(calculationOptionViewInTablesAndGraphs.GetSelectedOption());
            //fmFilterMachiningBlock machiningBlock = new fmFilterMachiningBlock(calculationOptionViewInTablesAndGraphs);
        
            FillListBox(listBoxXAxis, inputNames);
            int indexX = listBoxXAxis.Items.IndexOf("n");
            if (indexX == -1) indexX = 0;
            if (listBoxXAxis.Items.Count > indexX)
                listBoxXAxis.SelectedItem = listBoxXAxis.Items[indexX];

            List<string> outputNames = new List<string>();

            foreach (fmGlobalParameter p in new fmFilterSimulation().Parameters.Keys)
            {
                outputNames.Add(p.name);
            }

            FillListBox(listBoxYAxis, outputNames);
            int indexY = listBoxYAxis.Items.IndexOf("hc");
            if (indexY == -1) indexY = 0;
            if (listBoxYAxis.Items.Count > indexY)
                listBoxYAxis.SelectedItem = listBoxYAxis.Items[indexY];
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
    public class fmSelectedSimulationData
    {
        public bool isChecked;
        public fmFilterSimulation externalSimulation;
        public fmFilterSimulationData internalSimulation;
        public List<fmFilterSimulationData> calculatedDataList = new List<fmFilterSimulationData>();
        public fmSelectedSimulationData(bool isChecked, fmFilterSimulation externalSimulation)
        {
            this.isChecked = isChecked;
            this.externalSimulation = externalSimulation;
            internalSimulation = new fmFilterSimulationData();
            internalSimulation.CopyFrom(externalSimulation.Data);
        }
    }
}
