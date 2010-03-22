using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using fmCalcBlocksLibrary;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;
using FilterSimulation.fmFilterObjects;
using fmCalcBlocksLibrary.Blocks;

namespace FilterSimulationWithTablesAndGraphs
{
    public partial class FilterSimulationWithTablesAndGraphs : FilterSimulation.FilterSimulation
    {
        public FilterSimulationWithTablesAndGraphs()
        {
            InitializeComponent();

            //fmInputsInfoForSelectedSimulationsTableBlock = new fmFilterMachiningBlock(calculationOptionViewInTablesAndGraphs);

            CreateColumnsInParametersTables();
            ReadUseParamsCheckBoxAndApply();
            rowsQuantity.Text = RowsQuantity.ToString();

            //calculationOptionViewInTablesAndGraphs_CheckedChanged(null, new EventArgs());

            //// BEGIN DEBUG CODE
            //AddRow();
            //fmLocalBlocks[0].A_Value = new fmValue(1 * fmUnitFamily.AreaFamily.CurrentUnit.Coef);
            //fmLocalBlocks[0].Dp_Value = new fmValue(1 * fmUnitFamily.PressureFamily.CurrentUnit.Coef);
            //fmLocalBlocks[0].sf_Value = new fmValue(30 * fmUnitFamily.ConcentrationFamily.CurrentUnit.Coef);
            //fmLocalBlocks[0].n_Value = new fmValue(1 * fmUnitFamily.FrequencyFamily.CurrentUnit.Coef);
            //// END DEBUG CODE
        }

        private void DisplayCharts(fmFilterSimSolution sol)
        {
            List<fmFilterSimulation> simList = GetSelectedSimulationsList(sol);

            //List<fmFilterMachiningBlock> fmbList = new List<fmFilterMachiningBlock>();

            //if (byCheckingSimulations)
            //{
            //    if (sol.CurrentObjects.Simulation != null)
            //    {
            //        fmbList.Add(sol.CurrentObjects.Simulation.filterMachiningBlock);
            //    }
            //}
            //else
            //{
            //    foreach (DataGridViewRow row in simulationDataGrid.Rows)
            //    {
            //        if (row.Visible)
            //        {
            //            fmFilterSimulation sim = sol.FindSimulation(new Guid(row.Cells[simulationGuidColumn.Name].Value.ToString()));
            //            if (sim.Checked)
            //            {
            //                fmbList.Add(sim.filterMachiningBlock);
            //            }
            //        }
            //    }
            //}

            //currentSimFMB = sol.CurrentObjects.Simulation == null ? null : sol.CurrentObjects.Simulation.filterMachiningBlock;

            BuildCurves(simList);
        }

        private List<fmFilterSimulation> GetSelectedSimulationsList(fmFilterSimSolution sol)
        {
            List<fmFilterSimulation> simList = new List<fmFilterSimulation>();

            if (byCheckingSimulations)
            {
                if (sol.CurrentObjects.Simulation != null)
                {
                    simList.Add(sol.CurrentObjects.Simulation);
                }
            }
            else
            {
                foreach (DataGridViewRow row in simulationDataGrid.Rows)
                {
                    if (row.Visible)
                    {
                        fmFilterSimulation sim = sol.FindSimulation(new Guid(row.Cells[simulationGuidColumn.Name].Value.ToString()));
                        if (sim.Checked)
                        {
                            simList.Add(sim);
                        }
                    }
                }
            }

            return simList;
        }

        override protected void DisplaySolution(fmFilterSimSolution sol)
        {
            base.DisplaySolution(sol);
            if (displayingSolution == false)
            {
                displayingSolution = true;
                DisplayCharts(sol);
                displayingSolution = false;
            }
        }
        override protected void UpdateUnitsAndData()
        {
            base.UpdateUnitsAndData();
            //UpdateUnitsInTablesAndGraphs();
        }

        private void ReadMinMaxXValues()
        {
            if (loadingXRange == false)
            {
                double minXValue = fmValue.StringToValue(minXValueTextBox.Text).Value;
                double maxXValue = fmValue.StringToValue(maxXValueTextBox.Text).Value;

                fmGlobalParameter xParameter = fmGlobalParameter.ParametersByName[listBoxXAxis.Text];
                double coef = xParameter.unitFamily.CurrentUnit.Coef;
                fmRange range = xParameter.chartCurretXRange;

                range.minValue = minXValue * coef;
                range.maxValue = maxXValue * coef;
            }
        }

        private void minMaxXValueTextBox_TextChanged(object sender, EventArgs e)
        {
            ReadMinMaxXValues();
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void useDefaultRangesButton_Click(object sender, EventArgs e)
        {
            //LoadDefaultXRange();
            //DrawChartAndTable();
        }

        private void selectedSimulationParametersTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        //    if (e.RowIndex == -1 && e.ColumnIndex > 0)
        //    {
        //        string parameterName = GetParameterNameFromHeader(selectedSimulationParametersTable.Columns[e.ColumnIndex].HeaderText);
        //        fmInputsInfoForSelectedSimulationsTableBlock.UpdateIsInputed(
        //            fmInputsInfoForSelectedSimulationsTableBlock.GetParameterByName(parameterName));
        //        UpdateColorsForInputsAndOutputsInSelectedSimulationsTable();
        //        DrawChartAndTable();
        //    }
        }

        private void selectedSimulationParametersTable_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
        //    if (e.RowIndex == -1 && e.ColumnIndex > 0)
        //    {
        //        selectedSimulationParametersTable.Columns[e.ColumnIndex].HeaderCell.Style.BackColor = Color.FromKnownColor(KnownColor.ButtonShadow);
        //    }
        }

        private void selectedSimulationParametersTable_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
        //    if (e.RowIndex == -1 && e.ColumnIndex > 0)
        //    {
        //        selectedSimulationParametersTable.Columns[e.ColumnIndex].HeaderCell.Style.BackColor = Color.FromKnownColor(KnownColor.ButtonFace);
        //    }
        }

        private void listBoxYAxis_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            fmGlobalParameter xParameter = fmGlobalParameter.ParametersByName[listBoxXAxis.Text];
            List<fmGlobalParameter> yParameters = new List<fmGlobalParameter>();

            CheckedListBox clb = sender as CheckedListBox;
            for (int i = 0; i < clb.Items.Count; ++i)
            {
                if (clb.GetItemChecked(i) ^ (e.Index == i))
                    yParameters.Add(fmGlobalParameter.ParametersByName[clb.Items[i].ToString()]);        
            }
            BindCalculatedResultsToDisplayingResults(xParameter, yParameters);
            BindCalculatedResultsToChartAndTable();
        }

        private void HighLightCurrentPoints(object sender)
        {
            HighLightCurrentPoints(sender, -1);
        }

        private void HighLightCurrentPoints(object sender, double x)
        {
            if (highLightCaller == null)
            {
                highLightCaller = sender;
                
                if (sender == coordinatesGrid)
                {
                    if (coordinatesGrid.CurrentCell != null)
                    {
                        int index = coordinatesGrid.CurrentCell.RowIndex;
                        x = displayingResults.xParameter.Values[index].Value;
                        fmZedGraphControl1.HighLightPoints(x);
                    }
                }

                if (sender == fmZedGraphControl1)
                {
                    int columnIndex = coordinatesGrid.CurrentCell == null ? 0 : coordinatesGrid.CurrentCell.ColumnIndex;
                    //int xx = fmZedGraphControl1.MousePosition.X;
                    //fmZedGraphControl1.GraphPane.XAxis.Scale.ReverseTransform(e.Location.X);
                    int rowIndex = 0;

                    foreach (DataGridViewRow row in coordinatesGrid.Rows)
                    {
                        fmValue value = fmValue.ObjectToValue(row.Cells[0].Value);
                        fmValue bestValue = fmValue.ObjectToValue(coordinatesGrid[0, rowIndex].Value);
                        if (fmValue.Abs(value - x) < fmValue.Abs(bestValue - x))
                        {
                            rowIndex = row.Index;
                        }
                    }

                    DataGridViewCell newCell = coordinatesGrid[columnIndex, rowIndex];
                    if (coordinatesGrid.CurrentCell != newCell)
                    {
                        coordinatesGrid.CurrentCell = newCell;
                    }
                }

                highLightCaller = null;
            }
        }

        private void coordinatesGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            HighLightCurrentPoints(sender);
        }

        private void fmZedgraphControl1_HighlightedPointsChanged(object sender, fmZedGraph.HighlighPointsEventArgs e)
        {
            HighLightCurrentPoints(sender, e.X);
        }
    }
}