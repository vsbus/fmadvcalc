using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using fmCalcBlocksLibrary;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Blocks;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;
using fmControls;
using fmDataGrid;
using ZedGraph;


namespace fmControls
{
    public partial class fmChartsView : UserControl
    {
        private List<fmAdditionalFilterMachiningBlock> fmGlobalBlocks;
        private List<fmAdditionalFilterMachiningBlock> fmLocalBlocks = new List<fmAdditionalFilterMachiningBlock>();
        public fmFilterMachiningBlock currentSimFMB;
        private bool isUseLocalParams = true;
        private readonly Color Y1AxColor = Color.Blue;
        private readonly Color Y2AxColor = Color.Green;
        private int RowsQuantity = 30;

        public fmChartsView()
        {
            InitializeComponent();
            CreateColumnsInParametersTables();
            rowsQuantity.Text = RowsQuantity.ToString();
            
            // BEGIN DEBUG CODE
            AddRow();
            fmLocalBlocks[0].A_Value = new fmValue(1 * fmUnitFamily.AreaFamily.CurrentUnit.Coef);
            fmLocalBlocks[0].Dp_Value = new fmValue(1 * fmUnitFamily.PressureFamily.CurrentUnit.Coef);
            fmLocalBlocks[0].sf_Value = new fmValue(30 * fmUnitFamily.ConcentrationFamily.CurrentUnit.Coef);
            fmLocalBlocks[0].n_Value = new fmValue(1 * fmUnitFamily.FrequencyFamily.CurrentUnit.Coef);
            // END DEBUG CODE
        }

        private void FillListBox(ListBox listBox, List<string> strings)
        {
            listBox.Items.Clear();
            foreach (string s in strings)
            {
                listBox.Items.Add(s);
            }
        }

        private void fmCalculationOptionView1_CheckedChanged(object sender, EventArgs e)
        {
            List<string> inputNames = new List<string>();
            List<string> outputNames = new List<string>();
            List<fmGlobalParameter> inputParameters = CalculationOptionHelper.GetInputedParametersList(fmCalculationOptionView1.GetSelectedOption());
            List<fmBlockParameter> blockParameterList = new fmFilterMachiningBlock(fmCalculationOptionView1).Parameters;
            foreach (fmBlockParameter p in blockParameterList)
            {
                (inputParameters.Contains(p.globalParameter) ? inputNames : outputNames).Add(p.name);
            }

            FillListBox(listBoxXAxis, inputNames);
            int indexX = listBoxXAxis.Items.IndexOf("n");
            if (indexX == -1) indexX = 0;
            listBoxXAxis.SelectedItem = listBoxXAxis.Items[indexX];
            
            FillListBox(listBoxYAxis, outputNames);
            int indexY = listBoxYAxis.Items.IndexOf("hc");
            if (indexY == -1) indexY = 0;
            listBoxYAxis.SelectedItem = listBoxYAxis.Items[indexY];
            
            FillListBox(listBoxY2Axis, outputNames);
            listBoxY2Axis.Items.Insert(0, "<none>");
            listBoxY2Axis.SelectedItem = listBoxY2Axis.Items[0];
            
            UpdateParametersTablesColumnsVisibility();
            UpdateIsInputedForParametersBlocks();
            DrawChartAndTable();
        }

        private void fmChartsView_Load(object sender, EventArgs e)
        {
            fmCalculationOptionView1_CheckedChanged(sender, e);
        }

        public void UpdateUnits()
        {
            List<fmBlockParameter> blockParameterList = new fmFilterMachiningBlock(fmCalculationOptionView1).Parameters;
            
            foreach (fmBlockParameter p in blockParameterList)
            {
                int index = GetColumnIndexByHeader(additionalParametersTable, p.name);
                additionalParametersTable.Columns[index].HeaderText = p.name + " (" + p.unitFamily.CurrentUnit.Name + ")";
                index = GetColumnIndexByHeader(selectedSimulationParametersTable, p.name);
                selectedSimulationParametersTable.Columns[index].HeaderText = p.name + " (" + p.unitFamily.CurrentUnit.Name + ")";
            }
        }

        private void CreateColumnsInParametersTables()
        {
            List<fmBlockParameter> blockParameterList =
                new fmFilterMachiningBlock(fmCalculationOptionView1).Parameters;
             
            foreach (fmBlockParameter p in blockParameterList)
            {
                additionalParametersTable.AddColumn<DataGridViewNumericalTextBoxColumn>(p.name).Width = 50;
                DataGridViewColumn col = selectedSimulationParametersTable.AddColumn<DataGridViewNumericalTextBoxColumn>(p.name);
                col.Width = 50;
                col.ReadOnly = true;
            }
            
            UpdateUnits();
        }

        private void AddRow()
        {
            additionalParametersTable.Rows.Add();
            DataGridViewRow row = additionalParametersTable.Rows[additionalParametersTable.Rows.Count - 1];
            row.Cells["AdditionalParametersCheckBoxColumn"].Value = true;
            fmAdditionalFilterMachiningBlock fmb = new fmAdditionalFilterMachiningBlock(true, fmCalculationOptionView1,
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.A.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Dp.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.sf.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.n.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.tc.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.tf.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.hc.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Mf.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Msus.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Vsus.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Ms.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qsus.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qmsus.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Qms.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.eps.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.kappa.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.Pc.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.rc.name)],
                                                                    row.Cells[GetColumnIndexByHeader(additionalParametersTable, fmGlobalParameter.a.name)]);
            fmb.ValuesChangedByUser += fmb_ValuesChangedByUser;
            fmLocalBlocks.Add(fmb);

            fmb.CopyValues(currentSimFMB);
            fmb.CalculateAndDisplay();

            UpdateIsInputedForParametersBlocks();
        }
        
        private void fmb_ValuesChangedByUser(object sender, fmBlockParameterEvetArgs e)
        {
            DrawChartAndTable();
        }

        private void UpdateParametersTablesColumnsVisibility()
        {
            List<fmBlockParameter> blockParameterList =
                new fmFilterMachiningBlock(fmCalculationOptionView1).Parameters;
            List<fmGlobalParameter> inputParameters =
                CalculationOptionHelper.GetInputedParametersList(fmCalculationOptionView1.GetSelectedOption());
            
            foreach (fmBlockParameter p in blockParameterList)
            {
                int index = GetColumnIndexByHeader(additionalParametersTable, p.name);
                additionalParametersTable.Columns[index].Visible = inputParameters.Contains(p.globalParameter);
                index = GetColumnIndexByHeader(selectedSimulationParametersTable, p.name);
                selectedSimulationParametersTable.Columns[index].Visible = inputParameters.Contains(p.globalParameter);
            }
        }

        private void additionalParametersTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (additionalParametersTable.Rows.Count > 1 
                && additionalParametersTable.Columns[e.ColumnIndex].Name == "DeleteButtonColumn")
            {
                fmLocalBlocks.RemoveAt(e.RowIndex);
                additionalParametersTable.Rows.RemoveAt(e.RowIndex);
                DrawChartAndTable();
            }
        }

        private static string GetParameterNameFromHeader(string header)
        {
            string[] s = header.Split('(');
            return s[0].Trim();
        }

        private static int GetColumnIndexByHeader(DataGridView grid, string header)
        {
            for (int i = grid.Columns.Count-1; i>=0; i--)
            {
                if (GetParameterNameFromHeader(grid.Columns[i].HeaderText) == header)
                    return i;
            }
            return -1;
        }

        private void AddCurve(fmValue[] aVx, fmValue[] aVy, Color color, SymbolType symbol, bool isY2Axis, bool isVisible)
        {
            List<double> lx = new List<double>();
            List<double> ly = new List<double>();
            for (int i = 0; i < aVx.Length; ++i)
            {
                if (aVx[i].Defined && aVy[i].Defined)
                {
                    lx.Add(aVx[i].Value);
                    ly.Add(aVy[i].Value);
                }
            }
            double[] ax = new double[lx.Count];
            double[] ay = new double[ly.Count];
            for (int i = 0; i < lx.Count; ++i)
            {
                ax[i] = lx[i];
                ay[i] = ly[i];
            }
            LineItem curve = fmZedGraphControl1.AddCurve("curve", ax, ay, color, symbol);
            curve.IsY2Axis = isY2Axis;
            curve.IsVisible = isVisible;
        }

        private void AddColumn(fmValue[] aVy, fmBlockParameter parameter, bool isVisible)
        {
            DataGridViewNumericalTextBoxColumn col = new DataGridViewNumericalTextBoxColumn();
            string yColId = string.Empty;
            col.HeaderText = parameter.name + yColId + " ("+ parameter.unitFamily.CurrentUnit.Name +")";
            col.ReadOnly = true;
            col.Width = 50;
            
            int idx = GetColumnIndexByHeader(coordinatesGrid, parameter.name);
            if(idx > -1)
            {
                coordinatesGrid.Columns.Insert(idx + 1,col);
            }
            else
            {
                coordinatesGrid.Columns.Add(col);
            }
      
            for (int i = 0; i < aVy.Length; i++)
            {
                if (i + 1 > coordinatesGrid.Rows.Count)
                {
                    coordinatesGrid.Rows.Add();
                }
                coordinatesGrid.Rows[i].Cells[col.Index].Value = aVy[i];
            }
            col.Visible = isVisible;
        }
        
        private void DrawChartAndTable()
        {
            if (fmGlobalBlocks == null)
            {
                return;
            }

            foreach (fmAdditionalFilterMachiningBlock localFMB in fmLocalBlocks)
            {
                localFMB.CopyConstants(currentSimFMB);
                localFMB.CalculateAndDisplay();
            }
            
            int xAxisParameterIndex = GetFilterMachiningBlockParameterIndexByName(listBoxXAxis.Text);
            int yAxisParameterIndex = GetFilterMachiningBlockParameterIndexByName(listBoxYAxis.Text);
            int y2AxisParameterIndex = GetFilterMachiningBlockParameterIndexByName(listBoxY2Axis.Text);
            
            SetUpChartAxis(xAxisParameterIndex, yAxisParameterIndex, y2AxisParameterIndex);
            fmValue currentSelectedXValue = SetUpResultTable();

            DrawCurvesAndColumnsForAxis(xAxisParameterIndex, yAxisParameterIndex, -1, SymbolType.Circle);
            DrawCurvesAndColumnsForAxis(xAxisParameterIndex, -1, y2AxisParameterIndex, SymbolType.Circle);

            if (currentSelectedXValue.Defined)
            {
                for (int i = 0; i < coordinatesGrid.RowCount; ++i)
                {
                    fmValue curValue = fmValue.ObjectToValue(coordinatesGrid.CurrentCell.Value);
                    fmValue newValue = fmValue.ObjectToValue(coordinatesGrid.Rows[i].Cells[0].Value);
                    if (newValue.Defined
                        && (!curValue.Defined || fmValue.Abs(newValue - currentSelectedXValue) < fmValue.Abs(curValue - currentSelectedXValue)))
                    {
                        coordinatesGrid.CurrentCell = coordinatesGrid.Rows[i].Cells[0];
                    }
                }
            }

            fmZedGraphControl1.AxisChange();
            fmZedGraphControl1.Refresh();
        }

        private fmValue SetUpResultTable()
        {
            DataGridViewCell currentCell = coordinatesGrid.CurrentCell;
            int currentRow = currentCell != null ? currentCell.RowIndex : -1;
            object cellValue = currentRow != -1 ? coordinatesGrid.Rows[currentRow].Cells[0].Value : null;
            fmValue result = cellValue == null ? new fmValue() : fmValue.ObjectToValue(cellValue);

            coordinatesGrid.Columns.Clear();

            return result;
        }

        private void SetUpChartAxis(int xAxisParameterIndex, int yAxisParameterIndex, int y2AxisParameterIndex)
        {
            GraphPane myPane = fmZedGraphControl1.GraphPane;
            myPane.CurveList.Clear();
            fmAdditionalFilterMachiningBlock tmp = new fmAdditionalFilterMachiningBlock(true, fmCalculationOptionView1);
            
            if (xAxisParameterIndex != -1)
            {
                myPane.XAxis.Title.Text = tmp.Parameters[xAxisParameterIndex].name + " (" + tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Name + ")";
            }
            if (yAxisParameterIndex != -1)
            {
                myPane.YAxis.Title.Text = tmp.Parameters[yAxisParameterIndex].name + " (" + tmp.Parameters[yAxisParameterIndex].unitFamily.CurrentUnit.Name + ")";
                myPane.YAxis.Scale.FontSpec.FontColor = Y1AxColor;
                myPane.YAxis.Title.FontSpec.FontColor = Y1AxColor;
                myPane.YAxis.Color = Y1AxColor;
            }
            if (y2AxisParameterIndex != -1)
            {
                myPane.Y2Axis.Title.Text = tmp.Parameters[y2AxisParameterIndex].name + " (" + tmp.Parameters[y2AxisParameterIndex].unitFamily.CurrentUnit.Name + ")";
                myPane.Y2Axis.Title.FontSpec.FontColor = Y2AxColor;
                myPane.Y2Axis.IsVisible = true;
                myPane.Y2Axis.Color = Y2AxColor;
                myPane.Y2Axis.Scale.FontSpec.FontColor = Y2AxColor;
            }
            else
            {
                myPane.Y2Axis.IsVisible = false;
            }

            fmZedGraphControl1.GraphPane.Title.Text = "Curves";
            fmZedGraphControl1.GraphPane.Legend.IsVisible = false;
        }

        private void DrawCurvesAndColumnsForAxis(int xAxisParameterIndex, int yAxisParameterIndex, int y2AxisParameterIndex, SymbolType symbol)
        {
            foreach (fmAdditionalFilterMachiningBlock globalFMB in fmGlobalBlocks)
            {
                fmAdditionalFilterMachiningBlock tmp = new fmAdditionalFilterMachiningBlock(true, fmCalculationOptionView1);
                tmp.CalculationOption = fmLocalBlocks[0].CalculationOption;
                tmp.CopyValues(globalFMB);

                if (isUseLocalParams)
                {
                    foreach (fmAdditionalFilterMachiningBlock localFMB in fmLocalBlocks)
                    {
                        tmp.IsDrawn = localFMB.IsDrawn;
                        List<fmGlobalParameter> inputParameters = CalculationOptionHelper.
                            GetInputedParametersList(fmCalculationOptionView1.GetSelectedOption());

                        for (int i = 0; i < tmp.Parameters.Count; ++i)
                        {
                            fmBlockParameter p = tmp.Parameters[i];
                            if (inputParameters.Contains(p.globalParameter))
                            {
                                p.value = localFMB.Parameters[i].value;
                            }
                            p.isInputed = localFMB.Parameters[i].isInputed;
                        }

                        DrawCurveAndColumn(xAxisParameterIndex, tmp, yAxisParameterIndex, y2AxisParameterIndex, symbol);
                        symbol++;
                    }
                }
                else
                {
                    tmp.IsDrawn = globalFMB.IsDrawn;
                    DrawCurveAndColumn(xAxisParameterIndex, tmp, yAxisParameterIndex, y2AxisParameterIndex, symbol);
                    symbol++;
                }
            }
        }

        private void DrawCurveAndColumn(int xAxisParameterIndex, fmAdditionalFilterMachiningBlock addFilterMachBlock, int yAxisParameterIndex, int y2AxisParameterIndex, SymbolType symbol)
        {
            if (xAxisParameterIndex != -1 && yAxisParameterIndex != -1)
            {
                CreateAddCurveColumn(xAxisParameterIndex, yAxisParameterIndex, addFilterMachBlock, symbol, Y1AxColor, false);
                symbol++;
            }
            if (xAxisParameterIndex != -1 && y2AxisParameterIndex != -1)
            {
                CreateAddCurveColumn(xAxisParameterIndex, y2AxisParameterIndex, addFilterMachBlock, symbol, Y2AxColor, true);
            }
        }

        private void CreateAddCurveColumn(int xAxisParameterIndex, int yAxisParameterIndex, fmAdditionalFilterMachiningBlock machiningBlock, SymbolType symbol, Color color, bool isY2Axis)
        {
            fmValue[] aVy;fmValue[] aVx;
            CountCurve(machiningBlock, xAxisParameterIndex, yAxisParameterIndex, out aVx, out aVy);
            AddCurve(aVx, aVy, color, symbol, isY2Axis, machiningBlock.IsDrawn);
            DrawColumns(machiningBlock, xAxisParameterIndex, yAxisParameterIndex);
        }

        private void DrawColumns(fmAdditionalFilterMachiningBlock machiningBlock, int xAxisParameterIndex, int yAxisParameterIndex)
        {
            fmValue[] aVx, aVy;
            CountCurve(machiningBlock, xAxisParameterIndex, yAxisParameterIndex, out aVx, out aVy);
            
            CreateValuesForGrid(machiningBlock, xAxisParameterIndex, yAxisParameterIndex, out aVx, out aVy);
            if (coordinatesGrid.Columns.Count == 0)
            {
                AddColumn(aVx, machiningBlock.Parameters[xAxisParameterIndex], true);
            }
            AddColumn(aVy, machiningBlock.Parameters[yAxisParameterIndex], machiningBlock.IsDrawn);
        }
        
        private void FindDxForKIntermediatePoints(double a, double b, int K, out double dx, out double x1)
        {
            double[] X = {1, 1.25, 2, 2.5, 5};
            const double eps = 1e-9;

            const int maxPower = 15;
            dx = Math.Pow(10.0, -maxPower - 1);
            x1 = 0;

            for (int power = -maxPower; power <= maxPower; ++power)
                foreach (double x in X)
                {
                    double newDx = x*Math.Pow(10.0, power);
                    double KCount = Math.Floor(b/newDx - eps) - Math.Floor(a/newDx + eps);
                    if (KCount < K)
                    {
                        double t = Math.Ceiling(a/dx + eps);
                        x1 = dx*t;
                        return;
                    }
                    dx = newDx;
                }
        }

        private void CreateValuesForGrid(fmFilterMachiningBlock tmp, int xAxisParameterIndex, int yAxisParameterIndex, out fmValue[] aax1, out fmValue[] aay1)
        {
            aax1 = aay1 = null;

            if (xAxisParameterIndex == -1 || yAxisParameterIndex == -1)
                return;

            List<fmValue> ax1 = new List<fmValue>();
            List<fmValue> ay1 = new List<fmValue>();

            double xStart = tmp.Parameters[xAxisParameterIndex].globalParameter.MinValue
                / tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Coef;
            double xEnd = tmp.Parameters[xAxisParameterIndex].globalParameter.MaxValue
                / tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Coef;


            double dx, x1;
            FindDxForKIntermediatePoints(xStart, xEnd, RowsQuantity - 2, out dx, out x1);

            ax1.Add(new fmValue(xStart));
            for (double x = x1; x * (1 + 1e-8) < xEnd; x += dx)
            {
                ax1.Add(new fmValue(x));
            }
            ax1.Add(new fmValue(xEnd));

            for (int i = 0; i < ax1.Count; ++i)
            {
                tmp.Parameters[xAxisParameterIndex].value = ax1[i] * tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Coef;
                tmp.DoCalculations();
                ax1[i] = (tmp.Parameters[xAxisParameterIndex].value /
                        tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Coef);
                ay1.Add(tmp.Parameters[yAxisParameterIndex].value /
                        tmp.Parameters[yAxisParameterIndex].unitFamily.CurrentUnit.Coef);
            }

                //for (double i = xStart; i < xEnd; i += step)
                //{
                //    tmp.Parameters[xAxisParameterIndex].value = new fmValue(i);
                //    tmp.DoCalculations();
                //    ax1.Add(tmp.Parameters[xAxisParameterIndex].value/
                //            tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Coef);
                //    ay1.Add(tmp.Parameters[yAxisParameterIndex].value/
                //            tmp.Parameters[yAxisParameterIndex].unitFamily.CurrentUnit.Coef);
                //}
                //if (Math.Round(ax1[ax1.Count-1].Value+1e-9) !=
                //    tmp.Parameters[xAxisParameterIndex].globalParameter.MaxValue/
                //    tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Coef)
                //{
                //    tmp.Parameters[xAxisParameterIndex].value = new fmValue(xEnd);

                //    tmp.DoCalculations();
                //    ax1.Add(tmp.Parameters[xAxisParameterIndex].value/
                //            tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Coef);
                //    ay1.Add(tmp.Parameters[yAxisParameterIndex].value/
                //            tmp.Parameters[yAxisParameterIndex].unitFamily.CurrentUnit.Coef);

                //}
            aax1 = new fmValue[ax1.Count];
            aay1 = new fmValue[ay1.Count];
            for (int i = 0; i < ax1.Count; ++i)
            {
                aax1[i] = ax1[i];
                aay1[i] = ay1[i];
            }
        }
         
        private static void CountCurve(fmFilterMachiningBlock tmp, int xAxisParameterIndex, int yAxisParameterIndex, out fmValue[] aax1, out fmValue[] aay1)
        {
            aax1 = aay1 = null;

            if (xAxisParameterIndex == -1 || yAxisParameterIndex == -1)
                return;

            List<fmValue> ax1 = new List<fmValue>();
            List<fmValue> ay1 = new List<fmValue>();
            const int steps = 30;
            double max = tmp.Parameters[xAxisParameterIndex].globalParameter.chartXRange.maxValue;
            double min = tmp.Parameters[xAxisParameterIndex].globalParameter.chartXRange.minValue;
            double diaposon = max - min;

            for (int i = 0; i < steps; ++i)
            {
                double x = min + diaposon * i / (steps - 1);
                tmp.Parameters[xAxisParameterIndex].value = new fmValue(x);
                tmp.DoCalculations();
                ax1.Add(tmp.Parameters[xAxisParameterIndex].value /
                       tmp.Parameters[xAxisParameterIndex].unitFamily.CurrentUnit.Coef);
                ay1.Add(tmp.Parameters[yAxisParameterIndex].value /
                       tmp.Parameters[yAxisParameterIndex].unitFamily.CurrentUnit.Coef);
            }

            aax1 = new fmValue[ax1.Count];
            aay1 = new fmValue[ay1.Count];
            for (int i = 0; i < ax1.Count; ++i)
            {
                aax1[i] = ax1[i];
                aay1[i] = ay1[i];
            }
        }
        private int GetFilterMachiningBlockParameterIndexByName(string parameterName)
        {
            fmFilterMachiningBlock tmp = new fmFilterMachiningBlock(fmCalculationOptionView1, null, null, null,
                                                                            null, null, null, null, null, null, null,
                                                                            null, null, null, null, null, null, null,
                                                                            null, null);
            for (int index = 0; index < tmp.Parameters.Count; ++index)
            {
                fmBlockParameter p = tmp.Parameters[index];
                if (p.name == parameterName)
                {
                    return index;
                }
            }

            return -1;
        }

        public void BuildCurves(List<fmFilterMachiningBlock> fmBlocks)
        {
            fmGlobalBlocks = new List<fmAdditionalFilterMachiningBlock>();
            fmGlobalBlocks.Clear();
            foreach(fmFilterMachiningBlock f in fmBlocks)
            {
                fmAdditionalFilterMachiningBlock t = new fmAdditionalFilterMachiningBlock(true, null);
                t.Copy(true,f);
                fmGlobalBlocks.Add(t);
            }
            DrawChartAndTable(); 
            BindSelectedSimulationParametersTableDataSource();
        }

        private void UpdateIsInputedForParametersBlocks()
        {
            foreach (fmFilterMachiningBlock localFMB in fmLocalBlocks)
                foreach (fmBlockParameter p in localFMB.Parameters)
                    if (p.name == listBoxXAxis.Text)
                        localFMB.UpdateIsInputed(p);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateIsInputedForParametersBlocks();
            DrawChartAndTable();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawChartAndTable();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawChartAndTable();
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            AddRow();
            DrawChartAndTable();
        }
        private void UseParamsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isUseLocalParams = UseParamsCheckBox.Checked;
            DrawChartAndTable();
            additionalParametersTable.Visible = isUseLocalParams;
            buttonAddRow.Visible = isUseLocalParams;
            selectedSimulationParametersTable.Visible = !isUseLocalParams;
            selectedSimulationParametersTable.Dock = (!isUseLocalParams)?DockStyle.Fill:DockStyle.None;
            additionalParametersTable.Dock = (isUseLocalParams)?DockStyle.Fill:DockStyle.None;
        }

        private void BindSelectedSimulationParametersTableDataSource()
        {
            selectedSimulationParametersTable.Rows.Clear();
            
            foreach (fmFilterMachiningBlock mb in fmGlobalBlocks)
            {
                selectedSimulationParametersTable.Rows.Add();
                DataGridViewRow row =
                    selectedSimulationParametersTable.Rows[selectedSimulationParametersTable.Rows.Count - 1];
                row.Cells["SelectedSimulationParametersCheckBoxColumn"].Value = true;
               
                foreach(fmBlockParameter param in mb.Parameters)
                {
                    int idx = GetColumnIndexByHeader(selectedSimulationParametersTable, param.name);
                    row.Cells[idx].Value = param.value/param.unitFamily.CurrentUnit.Coef;
                    
                }
            }
        }

        private void additionalParametersTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (additionalParametersTable.Columns[e.ColumnIndex].Name == "AdditionalParametersCheckBoxColumn"
                && fmLocalBlocks.Count > e.RowIndex)
            {
                fmLocalBlocks[e.RowIndex].IsDrawn = (bool) additionalParametersTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                DrawChartAndTable();
            }
        }
        private void rowsQuantity_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(rowsQuantity.Text))
            {
                RowsQuantity = (int) fmValue.StringToValue(rowsQuantity.Text).Value;
                rowsQuantity.Text = RowsQuantity.ToString();
                rowsQuantity.Focus();
                DrawChartAndTable();
            }
        }
  
        private void selectedSimulationParametersTable_CellValueChanged (object sender, DataGridViewCellEventArgs e)
        {
            if (selectedSimulationParametersTable.Columns[e.ColumnIndex].Name == "SelectedSimulationParametersCheckBoxColumn"
                && fmLocalBlocks.Count > e.RowIndex)
            {
                fmGlobalBlocks[e.RowIndex].IsDrawn = (bool) selectedSimulationParametersTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                DrawChartAndTable();
            }
        }
    }
}

//private void useRangesChB_CheckedChanged(object sender, EventArgs e)
        //{
        //    IsUseUserRanges = useRangesChB.Checked;
        //    ApplyButton.Enabled = IsUseUserRanges;
        //    maxValTB.Enabled = IsUseUserRanges;
        //    //rowsQuantity.Enabled = IsUseUserRanges;
        //    stepCBox.Enabled = IsUseUserRanges;
        //    DrawChartAndTable();
        //}

        //private void ApplyButton_Click(object sender, EventArgs e)
        //{
        //   // ValidateRangesOptions();
        //    DrawChartAndTable();
        //}
        //private void ValidateRangesOptions()
        //{
        //    int paramIndex = GetFilterMachiningBlockParameterIndexByName(listBoxXAxis.Text);
        //    fmAdditionalFilterMachiningBlock tmp = new fmAdditionalFilterMachiningBlock(true, fmCalculationOptionView1, null, null, null,
        //                                                                    null, null, null, null, null, null, null,
        //                                                                    null, null, null, null, null, null, null,
        //                                                                    null, null);
               
        //    fmBlockParameter p = tmp.Parameters[paramIndex];
        //    if(string.IsNullOrEmpty(maxValTB.Text) || fmValue.StringToValue(maxValTB.Text).Value > tmp.Parameters[paramIndex].globalParameter.MaxValue)
        //    {
        //        maxValTB.Text = (p.globalParameter.MaxValue/p.unitFamily.CurrentUnit.Coef).ToString();
        //    }
        //    if(string.IsNullOrEmpty(rowsQuantity.Text) || fmValue.StringToValue(rowsQuantity.Text).Value > tmp.Parameters[paramIndex].globalParameter.MaxValue)
        //    {
        //        rowsQuantity.Text = (p.globalParameter.MinValue/p.unitFamily.CurrentUnit.Coef).ToString();
        //    }
        //    if (fmValue.StringToValue(maxValTB.Text) < fmValue.StringToValue(rowsQuantity.Text))
        //    {
        //        string t = maxValTB.Text;
        //        maxValTB.Text = rowsQuantity.Text;
        //        rowsQuantity.Text = t;
        //    }
        //}

        //public void UpdateRangesOptions()
        //{
        //    int paramIndex = GetFilterMachiningBlockParameterIndexByName(listBoxXAxis.Text);
        //    fmAdditionalFilterMachiningBlock tmp = new fmAdditionalFilterMachiningBlock(true, fmCalculationOptionView1, null, null, null,
        //                                                                    null, null, null, null, null, null, null,
        //                                                                    null, null, null, null, null, null, null,
        //                                                                    null, null);

        //    fmBlockParameter p = tmp.Parameters[paramIndex];
            
        //    maxValTB.Text = (p.globalParameter.MaxValue/p.unitFamily.CurrentUnit.Coef).ToString();
        //    rowsQuantity.Text = (p.globalParameter.MinValue/p.unitFamily.CurrentUnit.Coef).ToString();
        //}

//private static void CreateCurve(fmFilterMachiningBlock tmp, int xAxisParameterIndex, int yAxisParameterIndex, out double[] aax1, out double[] aay1)
        //{
        //    fmValue[] ax1;
        //    fmValue[] ay1;
        //    CreateCurve(tmp, xAxisParameterIndex, yAxisParameterIndex, ax1, ay1);
        //    aax1 = new double[ax1.Length];
        //    aay1 = new double[ay1.Length];
        //    for (int i = 0; i < ax1.Length; ++i)
        //    {
        //        aax1[i] = ax1[i].Value;
        //        aay1[i] = ay1[i].Value;
        //    }
        //}
//private void BindCoordinatesGrid(List<double> ax, List<double> ay, List<double> ay2, fmGlobalParameter xParam, fmGlobalParameter yParam)
        //{
        //    //if (curves == null || curves.Count == 0)
        //    //    return;
            
        //    //coordinatesGrid.Columns.Clear();
        //    //DataGridViewNumericalTextBoxColumn col = new DataGridViewNumericalTextBoxColumn();
        //    //col.Name = "XColumn";
        //    //col.HeaderText = xParam.name+" ("+xParam.Unit+")";
        //    //col.ReadOnly = true;
        //    //col.Width = 50;
        //    //coordinatesGrid.Columns.Add(col);
        //    //for (int i = 0; i < curves.Count; i++)
        //    //{
        //    //    col = new DataGridViewNumericalTextBoxColumn();
        //    //    col.Name = "y"+i+"Column";
        //    //    col.HeaderText = yParam.name+"["+(i+1)+"]"+" ("+yParam.Unit+")";
        //    //    col.ReadOnly = true;
        //    //    col.Width = 50;
        //    //    coordinatesGrid.Columns.Add(col);
        //    //}
        //    //for (int i=0; i < curves[0].Points.Count; i++)
        //    //{
                
        //    //    coordinatesGrid.Rows.Add();
        //    //    coordinatesGrid.Rows[i].Cells[0].Value = (new fmValue(curves[0].Points[i].X)).ToString();
        //    //    for(int j=0; j<curves.Count; j++)
        //    //    {
        //    //        if(i<curves[j].Points.Count)
        //    //        {
        //    //            coordinatesGrid.Rows[i].Cells[j+1].Value = (new fmValue(curves[j].Points[i].Y)).ToString();
        //    //        }
        //    //    }
        //    //}

        //    if (curves == null || curves.Count == 0)
        //        return;

        //    coordinatesGrid.Columns.Clear();

        //    DataGridViewNumericalTextBoxColumn col = new DataGridViewNumericalTextBoxColumn();
        //    col.Name = "XColumn";
        //    col.HeaderText = xParam.name + " (" + xParam.Unit + ")";
        //    col.ReadOnly = true;
        //    col.Width = 50;
        //    coordinatesGrid.Columns.Add(col);

        //    int rowsCount = Math.Max(ax.Count, Math.Max(ay.Count, ay2.Count));

        //    for (int i = 0; i < rowsCount; i++)
        //    {
        //        coordinatesGrid.Rows.Add();
        //        if (i < ax.Count)
        //        {
        //            coordinatesGrid.Rows[i].Cells[0].Value = (new fmValue(ax[i])).ToString();
        //        }
        //    }


        //    for (int j = 0; j < curves.Count; j++)
        //    {
        //        col = new DataGridViewNumericalTextBoxColumn();
        //        col.Name = "y" + (j + 1) + "Column";
        //        col.HeaderText = yParam.name + "[" + (j + 1) + "]" + " (" + yParam.Unit + ")";
        //        col.ReadOnly = true;
        //        col.Width = 50;
        //        coordinatesGrid.Columns.Add(col);

        //        for (int i = 0; i < curves[0].Points.Count; i++)
        //        {
        //            coordinatesGrid.Rows[i].Cells[col.Index].Value = (new fmValue(curves[j].Points[i].Y)).ToString();
        //        }
        //    }
        //}