using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FilterSimulation.fmFilterObjects;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;
using Rectangle=System.Drawing.Rectangle;

namespace FilterSimulation
{
    public partial class FilterSimulation : UserControl
    {
        private fmFilterSimSolution fSolution = new fmFilterSimSolution();
        private fmCalcBlocksLibrary.Blocks.fmFilterMachiningBlock commonFilterMachiningBlock = null;
        private CheckBox ckBox;

        public FilterSimulation()
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
            DataGridViewCheckBoxColumn c1 = simulationDataGrid.Columns[simulationCheckedColumn.Index] as DataGridViewCheckBoxColumn;           
            ckBox = new CheckBox();
            Rectangle rect = simulationDataGrid.GetCellDisplayRectangle(c1.Index, -1, true);
            
            ckBox.Checked = true;
            ckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            ckBox.Name = "ckBox";
            ckBox.Text = "";
            ckBox.UseVisualStyleBackColor = true;
            
           ckBox.Size = new Size(15, 15);
          
            ckBox.Location = new Point(rect.Location.X +3, rect.Location.Y + rect.Height/2 );
            ckBox.CheckedChanged += new EventHandler(ckBox_CheckedChanged);
            simulationDataGrid.Controls.Add(ckBox);
        }
        private void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < simulationDataGrid.RowCount; j++)
            {
                if(simulationDataGrid.Rows[j].Visible)
                {
                    simulationDataGrid["simulationCheckedColumn", j].Value = ckBox.Checked;
                    simulationDataGrid["simulationCheckedColumn", j].Value =
                        simulationDataGrid["simulationCheckedColumn", j].FormattedValue;
                }
            }
            simulationDataGrid.EndEdit();
        }
      

        protected void FilterSimulation_Load(object sender, EventArgs e)
        {
            SetUpToolTips();

            byCheckingProjects = byCheckingProjectsCheckBox.Checked;
            byCheckingSuspensions = byCheckingSuspensionsCheckBox.Checked;
            byCheckingSimSeries = byCheckingSimSeriesCheckBox.Checked;
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

            fmFilterSimProject fProj = new fmFilterSimProject(fSolution, "Prj1");
            fmFilterSimProject fProj2 = new fmFilterSimProject(fSolution, "Prj2");
            fmFilterSimSuspension fSus = new fmFilterSimSuspension(fProj, "Susp1", "Juce", "BASF");
            fmFilterSimSuspension fSus2 = new fmFilterSimSuspension(fProj2, "Susp2", "MaterialX", "Henkel");
            new fmFilterSimSuspension(fProj, "Susp3", "Water", "somebody");
            fmFilterSimSerie fSimSerie = new fmFilterSimSerie(fSus, "serie0", fmFilterSimMachineType.Nutche, "medium1", "karapty");
            new fmFilterSimSerie(fSus2, "serie02", fmFilterSimMachineType.Belt, "medium2", "izh");
            fmFilterSimulation sim = new fmFilterSimulation(fSimSerie, "simulatioN");

            // BEGIN DEBUG CODE
            sim.Parameters[fmGlobalParameter.eta_f].value = new fmValue(1 * fmUnitFamily.ViscosityFamily.CurrentUnit.Coef);
            (sim.Parameters[fmGlobalParameter.eta_f] as fmCalculatorsLibrary.fmCalculationVariableParameter).isInputed = true;
            
            sim.Parameters[fmGlobalParameter.rho_f].value = new fmValue(1000 * fmUnitFamily.DensityFamily.CurrentUnit.Coef);
            (sim.Parameters[fmGlobalParameter.rho_f] as fmCalculatorsLibrary.fmCalculationVariableParameter).isInputed = true;
            
            sim.Parameters[fmGlobalParameter.rho_s].value = new fmValue(1500 * fmUnitFamily.DensityFamily.CurrentUnit.Coef);
            (sim.Parameters[fmGlobalParameter.rho_s] as fmCalculatorsLibrary.fmCalculationVariableParameter).isInputed = true;
            
            sim.Parameters[fmGlobalParameter.eps0].value = new fmValue(50 * fmUnitFamily.ConcentrationFamily.CurrentUnit.Coef);
            (sim.Parameters[fmGlobalParameter.eps0] as fmCalculatorsLibrary.fmCalculationVariableParameter).isInputed = true;
            
            sim.Parameters[fmGlobalParameter.ne].value = new fmValue(0.02 * fmUnitFamily.NoUnitFamily.CurrentUnit.Coef);
            (sim.Parameters[fmGlobalParameter.ne] as fmCalculatorsLibrary.fmCalculationVariableParameter).isInputed = true;
            
            sim.Parameters[fmGlobalParameter.Pc0].value = new fmValue(1 * fmUnitFamily.PermeabilityFamily.CurrentUnit.Coef);
            (sim.Parameters[fmGlobalParameter.Pc0] as fmCalculatorsLibrary.fmCalculationVariableParameter).isInputed = true;
            
            sim.Parameters[fmGlobalParameter.nc].value = new fmValue(0.3 * fmUnitFamily.NoUnitFamily.CurrentUnit.Coef);
            (sim.Parameters[fmGlobalParameter.nc] as fmCalculatorsLibrary.fmCalculationVariableParameter).isInputed = true;
            
            sim.Parameters[fmGlobalParameter.hce].value = new fmValue(5 * fmUnitFamily.LengthFamily.CurrentUnit.Coef);
            (sim.Parameters[fmGlobalParameter.hce] as fmCalculatorsLibrary.fmCalculationVariableParameter).isInputed = true;
            
            sim.Parameters[fmGlobalParameter.Cm].value = new fmValue(20 * fmUnitFamily.ConcentrationFamily.CurrentUnit.Coef);
            (sim.Parameters[fmGlobalParameter.Cm] as fmCalculatorsLibrary.fmCalculationVariableParameter).isInputed = true;
            
            sim.Parameters[fmGlobalParameter.A].value = new fmValue(1 * fmUnitFamily.AreaFamily.CurrentUnit.Coef);
            (sim.Parameters[fmGlobalParameter.A] as fmCalculatorsLibrary.fmCalculationVariableParameter).isInputed = true;
            
            sim.Parameters[fmGlobalParameter.Dp].value = new fmValue(1 * fmUnitFamily.PressureFamily.CurrentUnit.Coef);
            (sim.Parameters[fmGlobalParameter.Dp] as fmCalculatorsLibrary.fmCalculationVariableParameter).isInputed = true;
            
            sim.Parameters[fmGlobalParameter.sf].value = new fmValue(30 * fmUnitFamily.ConcentrationFamily.CurrentUnit.Coef);
            (sim.Parameters[fmGlobalParameter.sf] as fmCalculatorsLibrary.fmCalculationVariableParameter).isInputed = true;
            
            sim.Parameters[fmGlobalParameter.n].value = new fmValue(1 * fmUnitFamily.FrequencyFamily.CurrentUnit.Coef);
            (sim.Parameters[fmGlobalParameter.n] as fmCalculatorsLibrary.fmCalculationVariableParameter).isInputed = true;
            // END DEBUG CODE

            fProj.Keep();
            fProj2.Keep();

            DisplaySolution(fSolution);

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
                AddMachineTypeRow(fmt.Symbol, fmt.Name);
            }
        }
        #endregion

        private void UpdateCurrentObjectAndDisplaySolution(DataGridView dgv)
        {
            if (displayingTables == false && displayingSolution == false && sortingTables == false)
            {
                displayingTables = true;

                fSolution.CurrentObjects.Project = null;

                fSolution.CurrentColumns.Project = projectNameColumn.Index;
                fSolution.CurrentColumns.Suspension = suspensionNameColumn.Index;
                fSolution.CurrentColumns.SimSerie = simSeriesNameColumn.Index;
                fSolution.CurrentColumns.Simulation = simulationNameColumn.Index;

                if (dgv == projectDataGrid)
                {
                    if (projectDataGrid.CurrentCell == null
                        || projectDataGrid.CurrentRow.Cells[projectGuidColumn.Index].Value == null)
                    {
                        displayingTables = false;
                        return;
                    }

                    Guid projectGuid = (Guid)projectDataGrid.CurrentRow.Cells[projectGuidColumn.Index].Value;
                    fSolution.CurrentColumns.Project = projectDataGrid.Columns[projectDataGrid.CurrentCell.ColumnIndex].Index;
                    
                    fSolution.CurrentObjects.Project = fSolution.FindProject(projectGuid);
                }
                else if (dgv == suspensionDataGrid)
                {
                    if (suspensionDataGrid.CurrentCell == null
                        || suspensionDataGrid.CurrentRow.Cells[suspensionGuidColumn.Index].Value == null)
                    {
                        displayingTables = false;
                        return;
                    }
                    
                    Guid suspensionGuid = (Guid)suspensionDataGrid.CurrentRow.Cells[suspensionGuidColumn.Index].Value;
                    fSolution.CurrentColumns.Suspension = suspensionDataGrid.Columns[suspensionDataGrid.CurrentCell.ColumnIndex].Index;
                    fSolution.CurrentObjects.Suspension = fSolution.FindSuspension(suspensionGuid);
                }
                else if (dgv == simSeriesDataGrid)
                {
                    if (simSeriesDataGrid.CurrentCell == null
                        || simSeriesDataGrid.CurrentRow.Cells[simSeriesGuidColumn.Index].Value == null)
                    {
                        displayingTables = false;
                        return;
                    }

                    Guid simSeriesGuid = (Guid)simSeriesDataGrid.CurrentRow.Cells[simSeriesGuidColumn.Index].Value;
                    fSolution.CurrentColumns.SimSerie = simSeriesDataGrid.Columns[simSeriesDataGrid.CurrentCell.ColumnIndex].Index;
                    fSolution.CurrentObjects.Serie = fSolution.FindSerie(simSeriesGuid);
                }
                else if (dgv == simulationDataGrid)
                {
                    if (simulationDataGrid.CurrentCell == null
                        || simulationDataGrid.CurrentRow.Cells[simulationGuidColumn.Index].Value == null)
                    {
                        displayingTables = false;
                        return;
                    }

                    Guid simulationGuid = (Guid)simulationDataGrid.CurrentRow.Cells[simulationGuidColumn.Index].Value;
                    fSolution.CurrentColumns.Simulation = simulationDataGrid.Columns[simulationDataGrid.CurrentCell.ColumnIndex].Index;
                    fSolution.CurrentObjects.Simulation = fSolution.FindSimulation(simulationGuid);
                }

                DisplaySolution(fSolution);

                displayingTables = false;
            }
        }
        
        
        private void saveAllButton_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        public void SaveAll()
        {
            fSolution.Keep();
            DisplaySolution(fSolution);
        }

        private void simulationDataGrid_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            fmDataGrid.fmDataGrid dg = sender as fmDataGrid.fmDataGrid;
            fmValue DpColumn = fmValue.StringToValue(dg.Rows[e.RowIndex1].Cells["simulation_DpColumn"].Value.ToString());
            fmValue DpColumn_2 = fmValue.StringToValue(dg.Rows[e.RowIndex2].Cells["simulation_DpColumn"].Value.ToString());
            fmValue hcColumn = fmValue.StringToValue(dg.Rows[e.RowIndex1].Cells["simulation_hcColumn"].Value.ToString());
            fmValue hcColumn_2 = fmValue.StringToValue(dg.Rows[e.RowIndex2].Cells["simulation_hcColumn"].Value.ToString());
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

        public void UpdateAll()
        {
            UpdateUnitsAndData();
            DisplaySolution(fSolution);
        }

        private void rangesButton_Click(object sender, EventArgs e)
        {
            ParameterIntervalOption proForm = new ParameterIntervalOption();
            proForm.ShowDialog();
            DisplaySolution(fSolution);
        }

        private void simulationCreateButton_Click(object sender, EventArgs e)
        {
            fmFilterSimSerie parentSerie = fSolution.CurrentObjects.Serie;
            if (parentSerie == null)
            {
                MessageBox.Show("Please select serie in serie table", "Error!", MessageBoxButtons.OK);
                return;
            }

            if (!byCheckingSimSeries && parentSerie.Checked == false)
            {
                MessageBox.Show("You try to create simulation in unchecked serie.\nPlease create simulations in checked series.", "Error!", MessageBoxButtons.OK);
                return;
            }

            string simName;
            for (int i = 1; ; ++i)
            {
                simName = parentSerie.Name + "-" + i;
                if (fSolution.FindSimulation(simName) == null)
                {
                    break;
                }
            }

            if (fSolution.CurrentObjects.Simulation == null)
            {
                fSolution.CurrentObjects.Simulation = new fmFilterSimulation(parentSerie, simName);
            }
            else
            {
                fmFilterSimulation currentSimulation = fSolution.CurrentObjects.Simulation;
                fSolution.CurrentObjects.Simulation = new fmFilterSimulation(currentSimulation.Parent, simName);
                fSolution.CurrentObjects.Simulation.CopySuspensionParameters(currentSimulation);
                fSolution.CurrentObjects.Simulation.Keep();
            }

            fSolution.CurrentColumns.Simulation = simulationNameColumn.Index;
            DisplaySolution(fSolution);
            SortTables();
            SelectCurrentItemsInSolution(fSolution);

            simulationDataGrid.BeginEdit(true);
        }

        private void calculationOptionChangeButton_Click(object sender, EventArgs e)
        {
            CalculationOptionSelectionDialog cosd = new CalculationOptionSelectionDialog();
            cosd.suspensionCalculationOption = fSolution.CurrentObjects.Simulation.Data.suspensionCalculationOption;
            cosd.filterMachiningCalculationOption = fSolution.CurrentObjects.Simulation.Data.filterMachiningCalculationOption;
            if (cosd.ShowDialog() == DialogResult.OK)
            {
                fSolution.CurrentObjects.Simulation.susBlock.SetCalculationOptionAndUpdateCellsStyle(cosd.suspensionCalculationOption);
                fSolution.CurrentObjects.Simulation.filterMachiningBlock.SetCalculationOptionAndUpdateCellsStyle(cosd.filterMachiningCalculationOption);
                DisplaySolution(fSolution);
            }
        }
    }
}