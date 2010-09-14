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
using FilterSimulation;
using fmControls;

namespace FilterSimulationWithTablesAndGraphs
{
    public partial class FilterSimulationWithTablesAndGraphs : FilterSimulation.FilterSimulation
    {
        public FilterSimulationWithTablesAndGraphs()
        {
            InitializeComponent();

            CreateColumnsInParametersTables();
            ReadUseParamsCheckBoxAndApply();
            rowsQuantity.Text = RowsQuantity.ToString();

            CreateDefaultXAxisParametersListForDisplaying();

            //// BEGIN DEBUG CODE
            //AddRow();
            //fmLocalBlocks[0].A_Value = new fmValue(1 * fmUnitFamily.AreaFamily.CurrentUnit.Coef);
            //fmLocalBlocks[0].Dp_Value = new fmValue(1 * fmUnitFamily.PressureFamily.CurrentUnit.Coef);
            //fmLocalBlocks[0].sf_Value = new fmValue(30 * fmUnitFamily.ConcentrationFamily.CurrentUnit.Coef);
            //fmLocalBlocks[0].n_Value = new fmValue(1 * fmUnitFamily.FrequencyFamily.CurrentUnit.Coef);
            //// END DEBUG CODE
        }

        private void CreateDefaultXAxisParametersListForDisplaying()
        {
            yAxisListParametersToDisplay = new List<fmGlobalParameter>();
            yAxisListParametersToDisplay.Add(fmGlobalParameter.A);
            yAxisListParametersToDisplay.Add(fmGlobalParameter.Dp);
            yAxisListParametersToDisplay.Add(fmGlobalParameter.hc);
            yAxisListParametersToDisplay.Add(fmGlobalParameter.hc_over_tf);
            yAxisListParametersToDisplay.Add(fmGlobalParameter.Mf);
            yAxisListParametersToDisplay.Add(fmGlobalParameter.Ms);
            yAxisListParametersToDisplay.Add(fmGlobalParameter.Msus);
            yAxisListParametersToDisplay.Add(fmGlobalParameter.n);
            yAxisListParametersToDisplay.Add(fmGlobalParameter.Qms);
            yAxisListParametersToDisplay.Add(fmGlobalParameter.Qmsus);
            yAxisListParametersToDisplay.Add(fmGlobalParameter.Qsus);
            yAxisListParametersToDisplay.Add(fmGlobalParameter.sf);
            yAxisListParametersToDisplay.Add(fmGlobalParameter.tc);
            yAxisListParametersToDisplay.Add(fmGlobalParameter.tf);
            yAxisListParametersToDisplay.Add(fmGlobalParameter.tr);
        }

        private void DisplayCharts(fmFilterSimSolution sol)
        {
            List<fmFilterSimulation> simList = GetSelectedSimulationsList(sol);
            fmFilterSimulation currentActiveSimulation = sol.CurrentObjects.Simulation;
            BuildCurves(simList, currentActiveSimulation);
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
            LoadDefaultXRange();
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void selectedSimulationParametersTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex == -1 && e.ColumnIndex > 0)
            //{
            //    string parameterName = GetParameterNameFromHeader(selectedSimulationParametersTable.Columns[e.ColumnIndex].HeaderText);
            //    fmInputsInfoForSelectedSimulationsTableBlock.UpdateIsInputed(
            //        fmInputsInfoForSelectedSimulationsTableBlock.GetParameterByName(parameterName));
            //    UpdateColorsForInputsAndOutputsInSelectedSimulationsTable();
            //    DrawChartAndTable();
            //}
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

        private void HighLightCurrentPoints(object sender)
        {
            HighLightCurrentPoints(sender, -1, true);
        }

        private void HighLightCurrentPoints(object sender, double x, bool isHighLight)
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
                        fmZedGraphControl1.HighlightPoints(x);
                    }
                }

                if (sender == fmZedGraphControl1)
                {
                    int columnIndex = coordinatesGrid.CurrentCell == null ? 0 : coordinatesGrid.CurrentCell.ColumnIndex;
                    int rowIndex = 0;

                    fmValue minValue = coordinatesGrid.RowCount == 0 ? new fmValue() : fmValue.ObjectToValue(coordinatesGrid.Rows[0].Cells[0].Value);
                    fmValue maxValue = coordinatesGrid.RowCount == 0 ? new fmValue() : fmValue.ObjectToValue(coordinatesGrid.Rows[coordinatesGrid.RowCount - 1].Cells[0].Value);
                    if (!isHighLight || x < minValue.Value || x > maxValue.Value)
                    {
                        coordinatesGrid.CurrentCell = null;
                    }
                    else
                    {
                        foreach (DataGridViewRow row in coordinatesGrid.Rows)
                        {
                            fmValue value = fmValue.ObjectToValue(row.Cells[0].Value);
                            fmValue bestValue = fmValue.ObjectToValue(coordinatesGrid[0, rowIndex].Value);
                            if (fmValue.Abs(value - x) < fmValue.Abs(bestValue - x))
                            {
                                rowIndex = row.Index;
                            }
                        }

                        if (coordinatesGrid.RowCount > 0 && coordinatesGrid.ColumnCount > 0)
                        {
                            DataGridViewCell newCell = coordinatesGrid[columnIndex, rowIndex];
                            if (coordinatesGrid.CurrentCell != newCell)
                            {
                                coordinatesGrid.CurrentCell = newCell;
                            }
                        }    
                    }
                }

                highLightCaller = null;
            }
        }

        private void coordinatesGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            HighLightCurrentPoints(sender);
        }

        private void fmZedGraphControl1_HighLightedPointsChanged(object sender, fmZedGraph.HighlighPointsEventArgs e)
        {
            HighLightCurrentPoints(sender, e.X, e.IsHighlight);
        }

        private void calculationOptionTandCChangeButton_Click(object sender, EventArgs e)
        {
            if (!isUseLocalParams)
            {
                CalculationOptionSelectionExpandedDialog cosd = new CalculationOptionSelectionExpandedDialog();
                cosd.suspensionCalculationOption =
                    fmCalculatorsLibrary.fmSuspensionCalculator.SuspensionCalculationOptions.RHOSUS_CALCULATED;
                cosd.filterMachiningCalculationOption =
                    fmCalculatorsLibrary.fmFilterMachiningCalculator.FilterMachiningCalculationOption.StandartAndDesignGlobal;

                if (GetCurrentActiveSelectedSimulationData() != null)
                {
                    fmSelectedSimulationData simData = GetCurrentActiveSelectedSimulationData();
                    cosd.suspensionCalculationOption = simData.internalSimulationData.suspensionCalculationOption;
                    cosd.filterMachiningCalculationOption = simData.internalSimulationData.filterMachiningCalculationOption;
                }

                if (cosd.ShowDialog() == DialogResult.OK)
                {
                    List<fmSelectedSimulationData> selectedList = new List<fmSelectedSimulationData>();

                    foreach (fmSelectedSimulationData simData in internalSelectedSimList)
                    {
                        if (cosd.ItemSelection == CalculationOptionDialogExpandedItemSelection.All
                            || (cosd.ItemSelection == CalculationOptionDialogExpandedItemSelection.Checked && simData.isChecked)
                            || (cosd.ItemSelection == CalculationOptionDialogExpandedItemSelection.Current && simData.isCurrentActive))
                        {
                            selectedList.Add(simData);
                        }
                    }


                    foreach (fmSelectedSimulationData simData in selectedList)
                    {
                        fmFilterSimulationData sim = simData.internalSimulationData;
                        fmCalculatorsLibrary.fmSuspensionCalculator.SuspensionCalculationOptions
                            suspensionCalculationOption;
                        fmCalculatorsLibrary.fmFilterMachiningCalculator.FilterMachiningCalculationOption
                            filterMachiningCalculationOption;

                        if (cosd.CalculationOptionKind == CalculationOptionDialogExpandedCalculationOptionKind.New)
                        {
                            suspensionCalculationOption = cosd.suspensionCalculationOption;
                            filterMachiningCalculationOption = cosd.filterMachiningCalculationOption;
                        }
                        else if (cosd.CalculationOptionKind ==
                                 CalculationOptionDialogExpandedCalculationOptionKind.MotherInitial)
                        {
                            suspensionCalculationOption = simData.externalSimulation.SuspensionCalculationOption;
                            filterMachiningCalculationOption =
                                simData.externalSimulation.FilterMachiningCalculationOption;
                        }
                        else
                        {
                            throw new Exception("unknown Calculation option Kind");
                        }

                        fmSuspensionBlock susBlock = new fmSuspensionBlock();
                        fmFilterSimulationData.CopyAllParametersFromSimulationToBlock(sim, susBlock);
                        susBlock.SetCalculationOptionAndUpdateCellsStyle(suspensionCalculationOption);
                        fmFilterSimulationData.CopyAllParametersFromBlockToSimulation(susBlock, sim);
                        sim.suspensionCalculationOption = suspensionCalculationOption;

                        fmFilterMachiningBlock filterMachiningBlock = new fmFilterMachiningBlock();
                        fmFilterSimulationData.CopyAllParametersFromSimulationToBlock(sim, filterMachiningBlock);
                        filterMachiningBlock.SetCalculationOptionAndUpdateCellsStyle(filterMachiningCalculationOption);
                        fmFilterSimulationData.CopyAllParametersFromBlockToSimulation(filterMachiningBlock, sim);
                        simData.internalSimulationData.filterMachiningCalculationOption =
                            filterMachiningCalculationOption;
                    }
                }

                BindBackColorToSelectedSimulationsTable();
                BindXYLists();
                SetXAxisParameterAsInputed();
            }
            else
            {
                CalculationOptionSelectionExpandedDialog cosd = new CalculationOptionSelectionExpandedDialog();
                cosd.suspensionCalculationOption =
                    fmCalculatorsLibrary.fmSuspensionCalculator.SuspensionCalculationOptions.RHOSUS_CALCULATED;
                cosd.filterMachiningCalculationOption =
                    fmCalculatorsLibrary.fmFilterMachiningCalculator.FilterMachiningCalculationOption.StandartAndDesignGlobal;

                if (GetCurrentActiveLocalParameters() != null)
                {
                    fmLocalInputParametersData localParameters = GetCurrentActiveLocalParameters();
                    cosd.filterMachiningCalculationOption = localParameters.filterMachiningBlock.calculationOption;
                }
                
                if (cosd.ShowDialog() == DialogResult.OK)
                {
                    List<fmLocalInputParametersData> selectedList = new List<fmLocalInputParametersData>();

                    foreach (fmLocalInputParametersData localParameters in localInputParametersList)
                    {
                        if (cosd.ItemSelection == CalculationOptionDialogExpandedItemSelection.All
                            || (cosd.ItemSelection == CalculationOptionDialogExpandedItemSelection.Checked && localParameters.isChecked)
                            || (cosd.ItemSelection == CalculationOptionDialogExpandedItemSelection.Current && localParameters.isCurrentActive))
                        {
                            selectedList.Add(localParameters);
                        }
                    }

                    foreach (fmLocalInputParametersData localParameters in selectedList)
                    {
                        fmFilterMachiningBlock fmb = localParameters.filterMachiningBlock;
                        fmCalculatorsLibrary.fmFilterMachiningCalculator.FilterMachiningCalculationOption
                            filterMachiningCalculationOption;

                        if (cosd.CalculationOptionKind == CalculationOptionDialogExpandedCalculationOptionKind.New)
                        {
                            filterMachiningCalculationOption = cosd.filterMachiningCalculationOption;
                        }
                        else if (cosd.CalculationOptionKind ==
                                 CalculationOptionDialogExpandedCalculationOptionKind.MotherInitial)
                        {
                            filterMachiningCalculationOption = localParameters.initialFilterMachiningCalculationOption;
                        }
                        else
                        {
                            throw new Exception("unknown Calculation option Kind");
                        }

                        fmb.SetCalculationOptionAndUpdateCellsStyle(filterMachiningCalculationOption);
                    }
                }

                UpdateVisibilityOfColumnsInLocalParametrsTable();
            }

            BindXYLists();
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private fmLocalInputParametersData GetCurrentActiveLocalParameters()
        {
            foreach (fmLocalInputParametersData localParameters in localInputParametersList)
            {
                if (localParameters.isCurrentActive)
                {
                    return localParameters;
                }
            }
            return null;
        }

        private fmSelectedSimulationData GetCurrentActiveSelectedSimulationData()
        {
            foreach (fmSelectedSimulationData simData in internalSelectedSimList)
            {
                if (simData.isCurrentActive)
                {
                    return simData;
                }
            }
            return null;
        }

        private void listBoxYAxis_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<fmGlobalParameter> yParameters = new List<fmGlobalParameter>();

            CheckedListBox clb = sender as CheckedListBox;
            for (int i = 0; i < clb.Items.Count; ++i)
            {
                if (i == e.Index && e.NewValue == CheckState.Checked
                    || clb.GetItemChecked(i) && (e.NewValue == CheckState.Checked || i != e.Index))
                {
                    yParameters.Add(fmGlobalParameter.ParametersByName[clb.Items[i].ToString()]);
                }
            }

            if (listBoxXAxis.Text == "")
                return;

            fmGlobalParameter xParameter = fmGlobalParameter.ParametersByName[listBoxXAxis.Text];
            BindCalculatedResultsToDisplayingResults(xParameter, yParameters);
            BindCalculatedResultsToChartAndTable();
        }
    }
}