using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FilterSimulation.fmFilterObjects;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;
using fmCalculatorsLibrary;
using Rectangle = System.Drawing.Rectangle;

namespace FilterSimulation
{
    public partial class fmFilterSimulationControl : UserControl
    {
        private readonly fmFilterSimSolution m_fSolution = new fmFilterSimSolution();
        private fmCalcBlocksLibrary.Blocks.fmFilterMachiningBlockWithLimits m_commonFilterMachiningBlock;
        private CheckBox m_ckBox;

        public fmFilterSimulationControl()
        {
            InitializeComponent();
        }

        private void SetUpToolTips()
        {
            toolTip.SetToolTip(projectCreateButton, "Create new project");
            toolTip.SetToolTip(projectKeepButton, "Save project");
            toolTip.SetToolTip(projectRestoreButton, "Restore project");
            toolTip.SetToolTip(projectDeleteButton, "Delete project");

            toolTip.SetToolTip(suspensionCreateButton, "Create new suspension");
            toolTip.SetToolTip(suspensionKeepButton, "Save suspension");
            toolTip.SetToolTip(suspensionRestoreButton, "Restore suspension");
            toolTip.SetToolTip(suspensionDeleteButton, "Delete suspension");

            toolTip.SetToolTip(simSeriesCreateButton, "Create new serie");
            toolTip.SetToolTip(simSeriesKeepButton, "Save serie");
            toolTip.SetToolTip(simSeriesRestoreButton, "Restore serie");
            toolTip.SetToolTip(simSeriesDeleteButton, "Delete serie");
            toolTip.SetToolTip(simSeriesDuplicateButton, "Duplicate serie");

            toolTip.SetToolTip(simulationCreateButton, "Create new simulation");
            toolTip.SetToolTip(simulationDuplicateButton, "Duplicate simulation");
            toolTip.SetToolTip(simulationKeepButton, "Save simulation");
            toolTip.SetToolTip(simulationRestoreButton, "Restore simulation");
            toolTip.SetToolTip(simulationDeleteButton, "Delete simulation");
        }
        private void InitializeHeaderCheckBox()
        {
            var c1 = simulationDataGrid.Columns[simulationCheckedColumn.Index] as DataGridViewCheckBoxColumn;
            m_ckBox = new CheckBox();
            if (c1 != null)
            {
                Rectangle rect = simulationDataGrid.GetCellDisplayRectangle(c1.Index, -1, true);

                m_ckBox.Checked = true;
                m_ckBox.CheckState = CheckState.Checked;
                m_ckBox.Name = "ckBox";
                m_ckBox.Text = "";
                m_ckBox.UseVisualStyleBackColor = true;

                m_ckBox.Size = new Size(15, 15);

                m_ckBox.Location = new Point(rect.Location.X + 3, rect.Location.Y + rect.Height / 2);
            }
            m_ckBox.CheckedChanged += ckBox_CheckedChanged;
            simulationDataGrid.Controls.Add(m_ckBox);
        }
        // ReSharper disable InconsistentNaming
        private void ckBox_CheckedChanged(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            for (int j = 0; j < simulationDataGrid.RowCount; j++)
            {
                if (simulationDataGrid.Rows[j].Visible)
                {
                    simulationDataGrid["simulationCheckedColumn", j].Value = m_ckBox.Checked;
                    simulationDataGrid["simulationCheckedColumn", j].Value =
                        simulationDataGrid["simulationCheckedColumn", j].FormattedValue;
                }
            }
            simulationDataGrid.EndEdit();
        }


        // ReSharper disable InconsistentNaming
        protected void FilterSimulation_Load(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            SetUpToolTips();

            m_byCheckingProjects = byCheckingProjectsCheckBox.Checked;
            m_byCheckingSuspensions = byCheckingSuspensionsCheckBox.Checked;
            m_byCheckingSimSeries = byCheckingSimSeriesCheckBox.Checked;
            byCheckingSimulations = byCheckingSimulationsCheckBox.Checked;

            ResizeAllPanels();
            DisplayMachineTypes();
            CreateLiquidTable();
            CreateEps0Kappa0Pc0Rc0Alpha0Rm0HceTable();
            UpdateUnitsAndData();
            fullSimulationInfoCheckBox_CheckedChanged(null, new EventArgs());

            simulationDataGrid.Sort(simulationDataGrid.Columns[simulationSimSeriesNameColumn.Index], ListSortDirection.Ascending);
            simSeriesDataGrid.Sort(simSeriesDataGrid.Columns[simSeriesSuspensionNameColumn.Index], ListSortDirection.Ascending);

            foreach (DataGridViewColumn col in simulationDataGrid.Columns)
            {
                if (col != simulationDataGrid.Columns[simulationSuspensionNameColumn.Index])
                {
                    col.Width = 50;
                }
            }

            var fProj = new fmFilterSimProject(m_fSolution, "Prj1");
            var fProj2 = new fmFilterSimProject(m_fSolution, "Prj2");
            var fSus = new fmFilterSimSuspension(fProj, "Susp1", "Juce", "BASF");
            var fSus2 = new fmFilterSimSuspension(fProj2, "Susp2", "MaterialX", "Henkel");
            new fmFilterSimSuspension(fProj, "Susp3", "Water", "somebody");
            var fSimSerie = new fmFilterSimSerie(fSus, "serie0", fmFilterSimMachineType.nutche, "medium1", "karapty");
            new fmFilterSimSerie(fSus2, "serie02", fmFilterSimMachineType.belt, "medium2", "izh");
            var sim = new fmFilterSimulation(fSimSerie, "simulatioN");

            // BEGIN DEBUG CODE
            sim.Parameters[fmGlobalParameter.eta_f].value = new fmValue(1 * fmUnitFamily.ViscosityFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.eta_f]).isInputed = true;

            sim.Parameters[fmGlobalParameter.rho_f].value = new fmValue(1000 * fmUnitFamily.DensityFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.rho_f]).isInputed = true;

            sim.Parameters[fmGlobalParameter.rho_s].value = new fmValue(1500 * fmUnitFamily.DensityFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.rho_s]).isInputed = true;

            sim.Parameters[fmGlobalParameter.eps0].value = new fmValue(50 * fmUnitFamily.ConcentrationFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.eps0]).isInputed = true;

            sim.Parameters[fmGlobalParameter.ne].value = new fmValue(0.02 * fmUnitFamily.NoUnitFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.ne]).isInputed = true;

            sim.Parameters[fmGlobalParameter.Pc0].value = new fmValue(1 * fmUnitFamily.PermeabilityFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.Pc0]).isInputed = true;

            sim.Parameters[fmGlobalParameter.nc].value = new fmValue(0.3 * fmUnitFamily.NoUnitFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.nc]).isInputed = true;

            sim.Parameters[fmGlobalParameter.hce].value = new fmValue(5 * fmUnitFamily.LengthFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.hce]).isInputed = true;

            sim.Parameters[fmGlobalParameter.Cm].value = new fmValue(20 * fmUnitFamily.ConcentrationFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.Cm]).isInputed = true;

            sim.Parameters[fmGlobalParameter.A].value = new fmValue(1 * fmUnitFamily.AreaFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.A]).isInputed = true;

            sim.Parameters[fmGlobalParameter.Dp].value = new fmValue(1 * fmUnitFamily.PressureFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.Dp]).isInputed = true;

            sim.Parameters[fmGlobalParameter.tr].value = new fmValue(10 * fmUnitFamily.TimeFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.tr]).isInputed = true;

            sim.Parameters[fmGlobalParameter.n].value = new fmValue(1 * fmUnitFamily.FrequencyFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.n]).isInputed = true;
            // END DEBUG CODE

            fProj.Keep();
            fProj2.Keep();

            DisplaySolution(m_fSolution);

            projectDataGrid.CurrentCell = projectDataGrid.Rows[0].Cells[projectNameColumn.Index];

            UpdateCurrentObjectAndDisplaySolution(projectDataGrid);

            InitializeHeaderCheckBox();
        }

        #region Machine Table
        private void AddMachineTypeRow(string machineTypeSymbol, string machineTypeName)
        {
            machineTypesDataGrid.Rows.Add(new object[] { "True", machineTypeSymbol, machineTypeName });
        }
        private void DisplayMachineTypes()
        {
            foreach (fmFilterSimMachineType fmt in fmFilterSimMachineType.filterTypesList)
            {
                AddMachineTypeRow(fmt.symbol, fmt.name);
            }
        }
        #endregion

        private void UpdateCurrentObjectAndDisplaySolution(DataGridView dgv)
        {
            if (m_displayingTables == false && displayingSolution == false && m_sortingTables == false)
            {
                m_displayingTables = true;

                m_fSolution.currentObjects.Project = null;

                m_fSolution.currentColumns.project = projectNameColumn.Index;
                m_fSolution.currentColumns.suspension = suspensionNameColumn.Index;
                m_fSolution.currentColumns.simSerie = simSeriesNameColumn.Index;
                m_fSolution.currentColumns.simulation = simulationNameColumn.Index;

                if (dgv == projectDataGrid)
                {
                    if (projectDataGrid.CurrentRow != null)
                    {
                        if (projectDataGrid.CurrentCell == null
                            || projectDataGrid.CurrentRow.Cells[projectGuidColumn.Index].Value == null)
                        {
                            m_displayingTables = false;
                            return;
                        }

                        var projectGuid = (Guid)projectDataGrid.CurrentRow.Cells[projectGuidColumn.Index].Value;
                        m_fSolution.currentColumns.project = projectDataGrid.Columns[projectDataGrid.CurrentCell.ColumnIndex].Index;
                        m_fSolution.currentObjects.Project = m_fSolution.FindProject(projectGuid);
                    }
                }
                else if (dgv == suspensionDataGrid)
                {
                    if (suspensionDataGrid.CurrentRow != null)
                    {
                        if (suspensionDataGrid.CurrentCell == null
                            || suspensionDataGrid.CurrentRow.Cells[suspensionGuidColumn.Index].Value == null)
                        {
                            m_displayingTables = false;
                            return;
                        }

                        var suspensionGuid = (Guid)suspensionDataGrid.CurrentRow.Cells[suspensionGuidColumn.Index].Value;
                        m_fSolution.currentColumns.suspension = suspensionDataGrid.Columns[suspensionDataGrid.CurrentCell.ColumnIndex].Index;
                        m_fSolution.currentObjects.Suspension = m_fSolution.FindSuspension(suspensionGuid);
                    }
                }
                else if (dgv == simSeriesDataGrid)
                {
                    if (simSeriesDataGrid.CurrentRow != null)
                    {
                        if (simSeriesDataGrid.CurrentCell == null
                            || simSeriesDataGrid.CurrentRow.Cells[simSeriesGuidColumn.Index].Value == null)
                        {
                            m_displayingTables = false;
                            return;
                        }

                        var simSeriesGuid = (Guid)simSeriesDataGrid.CurrentRow.Cells[simSeriesGuidColumn.Index].Value;
                        m_fSolution.currentColumns.simSerie = simSeriesDataGrid.Columns[simSeriesDataGrid.CurrentCell.ColumnIndex].Index;
                        m_fSolution.currentObjects.Serie = m_fSolution.FindSerie(simSeriesGuid);
                    }
                }
                else if (dgv == simulationDataGrid)
                {
                    if (simulationDataGrid.CurrentRow != null)
                    {
                        if (simulationDataGrid.CurrentCell == null
                            || simulationDataGrid.CurrentRow.Cells[simulationGuidColumn.Index].Value == null)
                        {
                            m_displayingTables = false;
                            return;
                        }

                        var simulationGuid = (Guid)simulationDataGrid.CurrentRow.Cells[simulationGuidColumn.Index].Value;
                        m_fSolution.currentColumns.simulation = simulationDataGrid.Columns[simulationDataGrid.CurrentCell.ColumnIndex].Index;
                        m_fSolution.currentObjects.Simulation = m_fSolution.FindSimulation(simulationGuid);
                    }
                }

                DisplaySolution(m_fSolution);

                m_displayingTables = false;
            }
        }


        public void SaveAll()
        {
            m_fSolution.Keep();
            DisplaySolution(m_fSolution);
        }

        // ReSharper disable InconsistentNaming
        private static void simulationDataGrid_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            var dg = sender as fmDataGrid.fmDataGrid;
            // ReSharper disable InconsistentNaming
            if (dg != null)
            {
                fmValue DpColumn = fmValue.StringToValue(dg.Rows[e.RowIndex1].Cells["simulation_DpColumn"].Value.ToString());
                fmValue DpColumn_2 = fmValue.StringToValue(dg.Rows[e.RowIndex2].Cells["simulation_DpColumn"].Value.ToString());
                fmValue hcColumn = fmValue.StringToValue(dg.Rows[e.RowIndex1].Cells["simulation_hcColumn"].Value.ToString());
                fmValue hcColumn_2 = fmValue.StringToValue(dg.Rows[e.RowIndex2].Cells["simulation_hcColumn"].Value.ToString());
                // ReSharper restore InconsistentNaming
                if (e.CellValue1.Equals(e.CellValue2))
                {
                    e.SortResult = DpColumn.CompareTo(DpColumn_2);
                    if (e.SortResult == 0)
                    {
                        e.SortResult = hcColumn.CompareTo(hcColumn_2);
                    }
                    e.Handled = true;
                }
            }
        }

        public void UpdateAll()
        {
            UpdateUnitsAndData();
            DisplaySolution(m_fSolution);
        }

        // ReSharper disable InconsistentNaming
        private void simulationCreateButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            fmFilterSimSerie parentSerie = m_fSolution.currentObjects.Serie;
            if (parentSerie == null)
            {
                MessageBox.Show(@"Please select serie in serie table", @"Error!", MessageBoxButtons.OK);
                return;
            }

            if (!m_byCheckingSimSeries && parentSerie.Checked == false)
            {
                MessageBox.Show(@"You try to create simulation in unchecked serie.
Please create simulations in checked series.", @"Error!", MessageBoxButtons.OK);
                return;
            }

            string simName;
            for (int i = 1; ; ++i)
            {
                simName = parentSerie.Name + "-" + i;
                if (m_fSolution.FindSimulation(simName) == null)
                {
                    break;
                }
            }

            if (m_fSolution.currentObjects.Simulation == null)
            {
                m_fSolution.currentObjects.Simulation = new fmFilterSimulation(parentSerie, simName);
            }
            else
            {
                fmFilterSimulation currentSimulation = m_fSolution.currentObjects.Simulation;
                m_fSolution.currentObjects.Simulation = new fmFilterSimulation(currentSimulation.Parent, simName);
                m_fSolution.currentObjects.Simulation.CopySuspensionParameters(currentSimulation);
                m_fSolution.currentObjects.Simulation.Keep();
            }

            m_fSolution.currentColumns.simulation = simulationNameColumn.Index;
            DisplaySolution(m_fSolution);
            SortTables();
            SelectCurrentItemsInSolution(m_fSolution);

            simulationDataGrid.BeginEdit(true);
        }

        // ReSharper disable InconsistentNaming
        private void calculationOptionChangeButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            var cosd = new fmCalculationOptionSelectionDialog
            {
                suspensionCalculationOption =
                    m_fSolution.currentObjects.Simulation.Data.suspensionCalculationOption,
                filterMachiningCalculationOption =
                    m_fSolution.currentObjects.Simulation.Data.filterMachiningCalculationOption
            };
            if (cosd.ShowDialog() == DialogResult.OK)
            {
                m_fSolution.currentObjects.Simulation.susBlock.SetCalculationOptionAndUpdateCellsStyle(cosd.suspensionCalculationOption);
                m_fSolution.currentObjects.Simulation.filterMachiningBlock.SetCalculationOptionAndUpdateCellsStyle(cosd.filterMachiningCalculationOption);
                DisplaySolution(m_fSolution);
            }
        }
    }
}