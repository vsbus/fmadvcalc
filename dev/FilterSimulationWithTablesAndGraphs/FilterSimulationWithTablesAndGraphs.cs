using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using fmCalculationLibrary;
using FilterSimulation.fmFilterObjects;
using fmCalcBlocksLibrary.Blocks;
using fmCalculatorsLibrary;
using System.Xml;

namespace FilterSimulationWithTablesAndGraphs
{
    public partial class fmFilterSimulationWithTablesAndGraphs : FilterSimulation.fmFilterSimulationControl
    {
        public fmFilterSimulationWithTablesAndGraphs()
        {
            InitializeComponent();

            CreateColumnsInParametersTables();
            ReadUseParamsCheckBoxAndApply();
            rowsQuantity.Text = m_rowsQuantity.ToString();

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
            fmFilterSimulation currentActiveSimulation = sol.currentObjects.Simulation;
            BuildCurves(simList, currentActiveSimulation);
        }

        private List<fmFilterSimulation> GetSelectedSimulationsList(fmFilterSimSolution sol)
        {
            var simList = new List<fmFilterSimulation>();

            if (byCheckingSimulations)
            {
                if (sol.currentObjects.Simulation != null)
                {
                    simList.Add(sol.currentObjects.Simulation);
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

        private void ReadMinMaxXValues()
        {
            if (m_loadingXRange == false)
            {
                double minXValue = fmValue.StringToValue(minXValueTextBox.Text).value;
                double maxXValue = fmValue.StringToValue(maxXValueTextBox.Text).value;

                fmGlobalParameter xParameter = fmGlobalParameter.parametersByName[listBoxXAxis.SelectedItems[0].Text];
                double coef = xParameter.unitFamily.CurrentUnit.Coef;
                fmRange range = xParameter.chartCurretXRange;

                range.MinValue = minXValue * coef;
                range.MaxValue = maxXValue * coef;
            }
        }

        // ReSharper disable InconsistentNaming
        private void minMaxXValueTextBox_TextChanged(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            ReadMinMaxXValues();
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        // ReSharper disable InconsistentNaming
        private void useDefaultRangesButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            LoadvalidRange();
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void HighLightCurrentPoints(object sender)
        {
            HighLightCurrentPoints(sender, -1, true);
        }

        private void HighLightCurrentPoints(object sender, double x, bool isHighLight)
        {
            if (m_highLightCaller == null)
            {
                m_highLightCaller = sender;

                if (sender == coordinatesGrid)
                {
                    if (coordinatesGrid.CurrentCell != null)
                    {
                        int index = coordinatesGrid.CurrentCell.RowIndex;
                        if (0 <= index && index < m_displayingResults.XParameter.Values.Length)
                        {
                            x = m_displayingResults.XParameter.Values[index].value;
                            fmZedGraphControl1.HighlightPoints(x);
                        }
                    }
                }

                if (sender == fmZedGraphControl1)
                {
                    int columnIndex = coordinatesGrid.CurrentCell == null ? 0 : coordinatesGrid.CurrentCell.ColumnIndex;
                    int rowIndex = 0;

                    fmValue minValue = coordinatesGrid.RowCount == 0 ? new fmValue() : fmValue.ObjectToValue(coordinatesGrid.Rows[0].Cells[0].Value);
                    fmValue maxValue = coordinatesGrid.RowCount == 0 ? new fmValue() : fmValue.ObjectToValue(coordinatesGrid.Rows[coordinatesGrid.RowCount - 1].Cells[0].Value);
                    if (!isHighLight || x < minValue.value || x > maxValue.value)
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
                            coordinatesGrid.CurrentCell = newCell;
                        }
                    }
                }

                m_highLightCaller = null;
            }
        }

        // ReSharper disable InconsistentNaming
        private void coordinatesGrid_CurrentCellChanged(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            HighLightCurrentPoints(sender);
        }

        // ReSharper disable InconsistentNaming
        private void fmZedGraphControl1_HighLightedPointsChanged(object sender, fmZedGraph.HighlighPointsEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            HighLightCurrentPoints(sender, e.X, e.IsHighlight);
        }

        // ReSharper disable InconsistentNaming
        private void calculationOptionTandCChangeButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            if (!m_isUseLocalParams)
            {
                var cosd = new fmCalculationOptionSelectionExpandedDialog
                {
                    suspensionCalculationOption =
                        fmSuspensionCalculator.fmSuspensionCalculationOptions.
                        RHOSUS_CALCULATED,
                    hcdEpsdCalculationOption = fmDeliquoringSimualtionCalculator.
                        fmDeliquoringHcdEpsdCalculationOption.
                        CalculatedFromCakeFormation,
                    dpdInputCalculationOption = fmDeliquoringSimualtionCalculator.
                        fmDeliquoringDpdInputOption.
                        CalculatedFromCakeFormation,
                    rhoDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.
                        fmRhoDEtaDCalculationOption.
                        EqualToRhoF,
                    PcDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.
                        fmPcDCalculationOption.
                        Calculated,
                    filterMachiningCalculationOption =
                        fmFilterMachiningCalculator.
                        fmFilterMachiningCalculationOption.PLAIN_DP_CONST,
                    deliquoringUsedCalculationOption =
                        fmFilterMachiningCalculator.
                        fmDeliquoringUsedCalculationOption.Used,
                    gasFlowrateUsedCalculationOption =
                        fmFilterMachiningCalculator.
                        fmGasFlowrateUsedCalculationOption.Consider,
                    evaporationUsedCalculationOption =
                        fmFilterMachiningCalculator.
                        fmEvaporationUsedCalculationOption.NotConsider
                };

                if (GetCurrentActiveSelectedSimulationData() != null)
                {
                    fmSelectedSimulationData simData = GetCurrentActiveSelectedSimulationData();
                    cosd.suspensionCalculationOption = simData.internalSimulationData.suspensionCalculationOption;
                    cosd.filterMachiningCalculationOption = simData.internalSimulationData.filterMachiningCalculationOption;
                    cosd.deliquoringUsedCalculationOption = simData.internalSimulationData.deliquoringUsedCalculationOption;
                    cosd.gasFlowrateUsedCalculationOption = simData.internalSimulationData.gasFlowrateUsedCalculationOption;
                    cosd.evaporationUsedCalculationOption = simData.internalSimulationData.evaporationUsedCalculationOption;
                    cosd.hcdEpsdCalculationOption = simData.internalSimulationData.hcdEpsdCalculationOption;
                    cosd.dpdInputCalculationOption = simData.internalSimulationData.dpdInputCalculationOption;
                    cosd.rhoDCalculationOption = simData.internalSimulationData.rhoDCalculationOption;
                    cosd.PcDCalculationOption = simData.internalSimulationData.PcDCalculationOption;
                }

                if (cosd.ShowDialog() == DialogResult.OK)
                {
                    var selectedList = new List<fmSelectedSimulationData>();

                    foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
                    {
                        if (cosd.ItemSelection == fmCalculationOptionDialogExpandedItemSelection.ALL
                            || (cosd.ItemSelection == fmCalculationOptionDialogExpandedItemSelection.CHECKED && simData.isChecked)
                            || (cosd.ItemSelection == fmCalculationOptionDialogExpandedItemSelection.CURRENT && simData.isCurrentActive))
                        {
                            selectedList.Add(simData);
                        }
                    }


                    foreach (fmSelectedSimulationData simData in selectedList)
                    {
                        fmFilterSimulationData sim = simData.internalSimulationData;
                        fmSuspensionCalculator.fmSuspensionCalculationOptions
                            suspensionCalculationOption;
                        fmFilterMachiningCalculator.fmFilterMachiningCalculationOption
                            filterMachiningCalculationOption;
                        fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption
                            deliquoringUsedCalculationOption;
                        fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption
                            gasFlowrateUsedCalculationOption;
                        fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption
                            evaporationUsedCalculationOption;
                        fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption
                            hcdEpsdCalculationOption;
                        fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption
                            dpdInputCalculationOption;
                        fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption
                            rhoDetaDCalculationOption;
                        fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption
                            PcDCalculationOption;

                        if (cosd.CalculationOptionKind == fmCalculationOptionDialogExpandedCalculationOptionKind.NEW)
                        {
                            suspensionCalculationOption = cosd.suspensionCalculationOption;
                            filterMachiningCalculationOption = cosd.filterMachiningCalculationOption;
                            deliquoringUsedCalculationOption = cosd.deliquoringUsedCalculationOption;
                            gasFlowrateUsedCalculationOption = cosd.gasFlowrateUsedCalculationOption;
                            evaporationUsedCalculationOption = cosd.evaporationUsedCalculationOption;
                            hcdEpsdCalculationOption = cosd.hcdEpsdCalculationOption;
                            dpdInputCalculationOption = cosd.dpdInputCalculationOption;
                            rhoDetaDCalculationOption = cosd.rhoDCalculationOption;
                            PcDCalculationOption = cosd.PcDCalculationOption;
                        }
                        else if (cosd.CalculationOptionKind ==
                                 fmCalculationOptionDialogExpandedCalculationOptionKind.MOTHER_INITIAL)
                        {
                            suspensionCalculationOption = simData.externalSimulation.SuspensionCalculationOption;
                            filterMachiningCalculationOption = simData.externalSimulation.FilterMachiningCalculationOption;
                            deliquoringUsedCalculationOption = simData.externalSimulation.DeliquoringUsedCalculationOption;
                            gasFlowrateUsedCalculationOption = simData.externalSimulation.GasFlowrateUsedCalculationOption;
                            evaporationUsedCalculationOption = simData.externalSimulation.EvaporationUsedCalculationOption;
                            hcdEpsdCalculationOption = simData.externalSimulation.HcdEpsdCalculationOption;
                            dpdInputCalculationOption = simData.externalSimulation.DpdInputCalculationOption;
                            rhoDetaDCalculationOption = simData.externalSimulation.RhoDetaDCalculationOption;
                            PcDCalculationOption = simData.externalSimulation.PcDCalculationOption;
                        }
                        else
                        {
                            throw new Exception("unknown Calculation option Kind");
                        }

                        var susBlock = new fmSuspensionBlock();
                        fmFilterSimulationData.CopyAllParametersFromSimulationToBlock(sim, susBlock);
                        susBlock.SetCalculationOptionAndRewrite(suspensionCalculationOption);
                        fmFilterSimulationData.CopyAllParametersFromBlockToSimulation(susBlock, sim);
                        sim.suspensionCalculationOption = suspensionCalculationOption;

                        var filterMachiningBlock = new fmFilterMachiningBlock();
                        fmFilterSimulationData.CopyAllParametersFromSimulationToBlock(sim, filterMachiningBlock);
                        filterMachiningBlock.SetCalculationOptionAndRewriteData(filterMachiningCalculationOption);
                        filterMachiningBlock.SetCalculationOptionAndRewriteData(deliquoringUsedCalculationOption);
                        filterMachiningBlock.SetCalculationOptionAndRewriteData(gasFlowrateUsedCalculationOption);
                        filterMachiningBlock.SetCalculationOptionAndRewriteData(evaporationUsedCalculationOption);
                        fmFilterSimulationData.CopyAllParametersFromBlockToSimulation(filterMachiningBlock, sim);
                        simData.internalSimulationData.filterMachiningCalculationOption =
                            filterMachiningCalculationOption;
                        simData.internalSimulationData.deliquoringUsedCalculationOption =
                            deliquoringUsedCalculationOption;
                        simData.internalSimulationData.gasFlowrateUsedCalculationOption =
                            gasFlowrateUsedCalculationOption;
                        simData.internalSimulationData.evaporationUsedCalculationOption =
                            evaporationUsedCalculationOption;

                        var eps0dNedEpsdBlock = new fmEps0dNedEpsdBlock();
                        fmFilterSimulationData.CopyAllParametersFromSimulationToBlock(sim, eps0dNedEpsdBlock);
                        eps0dNedEpsdBlock.SetCalculationOptionAndRewrite(hcdEpsdCalculationOption);
                        eps0dNedEpsdBlock.SetCalculationOptionAndRewrite(dpdInputCalculationOption);
                        fmFilterSimulationData.CopyAllParametersFromBlockToSimulation(eps0dNedEpsdBlock, sim);
                        simData.internalSimulationData.hcdEpsdCalculationOption = hcdEpsdCalculationOption;
                        simData.internalSimulationData.dpdInputCalculationOption = dpdInputCalculationOption;

                        var sigmaPke0PkePcdRcdAlphadBlock = new fmSigmaPke0PkePcdRcdAlphadBlock();
                        fmFilterSimulationData.CopyAllParametersFromSimulationToBlock(sim, sigmaPke0PkePcdRcdAlphadBlock);
                        sigmaPke0PkePcdRcdAlphadBlock.SetCalculationOptionAndRewrite(rhoDetaDCalculationOption);
                        sigmaPke0PkePcdRcdAlphadBlock.SetCalculationOptionAndRewrite(PcDCalculationOption);
                        fmFilterSimulationData.CopyAllParametersFromBlockToSimulation(sigmaPke0PkePcdRcdAlphadBlock, sim);
                        simData.internalSimulationData.rhoDCalculationOption = rhoDetaDCalculationOption;
                        simData.internalSimulationData.PcDCalculationOption = PcDCalculationOption;
                    }
                }

                BindBackColorToSelectedSimulationsTable();
                BindXYLists();
                SetXAxisParameterAsInputed();
            }
            else
            {
                var cosd = new fmCalculationOptionSelectionExpandedDialog
                               {
                                   suspensionCalculationOption =
                                       fmSuspensionCalculator.fmSuspensionCalculationOptions.
                                       RHOSUS_CALCULATED,
                                   hcdEpsdCalculationOption = fmDeliquoringSimualtionCalculator.
                                       fmDeliquoringHcdEpsdCalculationOption.
                                       CalculatedFromCakeFormation,
                                   dpdInputCalculationOption = fmDeliquoringSimualtionCalculator.
                                       fmDeliquoringDpdInputOption.
                                       CalculatedFromCakeFormation,
                                   rhoDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.
                                       fmRhoDEtaDCalculationOption.
                                       EqualToRhoF,
                                   PcDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.
                                       fmPcDCalculationOption.
                                       Calculated,
                                   filterMachiningCalculationOption =
                                       fmFilterMachiningCalculator.
                                       fmFilterMachiningCalculationOption.PLAIN_DP_CONST,
                                   deliquoringUsedCalculationOption =
                                       fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption.Used,
                                   gasFlowrateUsedCalculationOption =
                                       fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption.Consider,
                                   evaporationUsedCalculationOption =
                                       fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption.NotConsider
                               };

                if (GetCurrentActiveLocalParameters() != null)
                {
                    fmLocalInputParametersData localParameters = GetCurrentActiveLocalParameters();
                    cosd.filterMachiningCalculationOption = localParameters.filterMachiningBlock.filterMachiningCalculationOption;
                    cosd.deliquoringUsedCalculationOption = localParameters.filterMachiningBlock.deliquoringUsedCalculationOption;
                    cosd.gasFlowrateUsedCalculationOption = localParameters.filterMachiningBlock.gasFlowrateUsedCalculationOption;
                    cosd.evaporationUsedCalculationOption = localParameters.filterMachiningBlock.evaporationUsedCalculationOption;
                }

                if (cosd.ShowDialog() == DialogResult.OK)
                {
                    var selectedList = new List<fmLocalInputParametersData>();

                    foreach (fmLocalInputParametersData localParameters in m_localInputParametersList)
                    {
                        if (cosd.ItemSelection == fmCalculationOptionDialogExpandedItemSelection.ALL
                            || (cosd.ItemSelection == fmCalculationOptionDialogExpandedItemSelection.CHECKED && localParameters.isChecked)
                            || (cosd.ItemSelection == fmCalculationOptionDialogExpandedItemSelection.CURRENT && localParameters.isCurrentActive))
                        {
                            selectedList.Add(localParameters);
                        }
                    }

                    foreach (fmLocalInputParametersData localParameters in selectedList)
                    {
                        fmFilterMachiningBlock fmb = localParameters.filterMachiningBlock;
                        fmCalculatorsLibrary.fmFilterMachiningCalculator.fmFilterMachiningCalculationOption
                            filterMachiningCalculationOption;

                        if (cosd.CalculationOptionKind == fmCalculationOptionDialogExpandedCalculationOptionKind.NEW)
                        {
                            filterMachiningCalculationOption = cosd.filterMachiningCalculationOption;
                        }
                        else if (cosd.CalculationOptionKind ==
                                 fmCalculationOptionDialogExpandedCalculationOptionKind.MOTHER_INITIAL)
                        {
                            filterMachiningCalculationOption = localParameters.initialFilterMachiningCalculationOption;
                        }
                        else
                        {
                            throw new Exception("unknown Calculation option Kind");
                        }

                        fmb.SetCalculationOptionAndRewriteData(filterMachiningCalculationOption);
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
            foreach (fmLocalInputParametersData localParameters in m_localInputParametersList)
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
            foreach (fmSelectedSimulationData simData in m_internalSelectedSimList)
            {
                if (simData.isCurrentActive)
                {
                    return simData;
                }
            }
            return null;
        }

        // ReSharper disable InconsistentNaming
        private void listBoxYAxis_ItemCheck(object sender, ItemCheckEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            var yParameters = new List<fmGlobalParameter>();

            var clb = sender as ListView;
            if (clb != null)
            {
                for (int i = 0; i < clb.Items.Count; ++i)
                {
                    if (i == e.Index && e.NewValue == CheckState.Checked
                        || clb.Items[i].Checked && (e.NewValue == CheckState.Checked || i != e.Index))
                    {
                        yParameters.Add(fmGlobalParameter.parametersByName[clb.Items[i].Text]);
                    }
                }
            }

            if (listBoxXAxis.SelectedItems[0].Text == "")
                return;

            fmGlobalParameter xParameter = fmGlobalParameter.parametersByName[listBoxXAxis.SelectedItems[0].Text];
            BindCalculatedResultsToDisplayingResults(xParameter, yParameters);
            BindCalculatedResultsToChartAndTable();
        }

        public void Serialize(XmlWriter writer)
        {
            m_fSolution.Keep();
            m_fSolution.Serialize(writer);
        }

        public void Deserialize(XmlNode node)
        {
            fmFilterSimSolution.CheckDatFileVersion(node);
            m_fSolution = fmFilterSimSolution.Deserialize(node);
            if (m_fSolution.projects.Count > 0)
            {
                m_fSolution.currentObjects.Project = m_fSolution.projects[0];
            }
            m_fSolution.Keep();

            DisplaySolution(m_fSolution);

            {
                bool isChecked = false;
                for (int row = 0; row < projectDataGrid.Rows.Count; ++row)
                {
                    for (int col = 0; col < projectDataGrid.ColumnCount; ++col)
                    {
                        if (projectDataGrid[col, row].Visible)
                        {
                            isChecked = true;
                            projectDataGrid.CurrentCell = projectDataGrid[col, row];
                            break;
                        }
                    }
                    if (isChecked)
                    {
                        break;
                    }
                }
            }
        }

        private void fmFilterSimulationWithTablesAndGraphs_Load(object sender, EventArgs e)
        {
            if (m_XYDialog == null)
            {
                PlaceTablesAndGraphsConfigurationPanelOnSeparateForm();
            }
        }

        private Form m_XYDialog;

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_XYDialog == null || m_XYDialog.IsDisposed)
            {
                PlaceTablesAndGraphsConfigurationPanelOnSeparateForm();
            }
            m_XYDialog.Show();
            m_XYDialog.Activate();
        }

        private void PlaceTablesAndGraphsConfigurationPanelOnSeparateForm()
        {
            int oldHeight = m_XYDialog == null ? 400 : m_XYDialog.Height;
            int oldWidth = m_XYDialog == null ? 320 : m_XYDialog.Width;
            m_XYDialog = new Form();
            m_XYDialog.Closing += new System.ComponentModel.CancelEventHandler(m_XYDialog_Closing);
            m_XYDialog.Height = oldHeight;
            m_XYDialog.Width = oldWidth;
            m_XYDialog.Text = "Diagram Configuration";
            tablesAndGraphsTopLeftPanel.Parent = m_XYDialog;
            tablesAndGraphsTopLeftPanel.Dock = DockStyle.Fill;
        }

        void m_XYDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PlaceTablesAndGraphsConfigurationPanelOnSeparateForm();
        }

        public bool IsModified()
        {
            foreach (var project in m_fSolution.projects)
            {
                if (project.Modified)
                {
                    return true;
                }
            }
            return false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            BindXYLists();
        }

        private void cakeFormationMachininglParametersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BindXYLists();
        }

        private void deliquoringMaterilParametersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BindXYLists();
        }

        private void deliquoringMachininglParametersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BindXYLists();
        }

        private void deselectAllButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listBoxYAxis.Items)
            {
                item.Checked = false;
            }
        }
    }
}