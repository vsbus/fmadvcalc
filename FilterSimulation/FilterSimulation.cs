using System;
using System.ComponentModel;
using System.Windows.Forms;
using FilterSimulation.fmFilterObjects;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace FilterSimulation
{
    public partial class FilterSimulation : UserControl
    {
        private fmFilterSimSolution fSolution = new fmFilterSimSolution();
        
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

        private void FilterSimulation_Load(object sender, EventArgs e)
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

            simulationDataGrid.Sort(simulationDataGrid.Columns["simulationSimSeriesNameColumn"], ListSortDirection.Ascending);
            simSeriesDataGrid.Sort(simSeriesDataGrid.Columns["simSeriesSuspensionNameColumn"], ListSortDirection.Ascending);

            foreach (DataGridViewColumn col in simulationDataGrid.Columns)
            {
                col.Width = 50;
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
            sim.eta_f = new fmValue(1 * fmUnitFamily.ViscosityFamily.CurrentUnit.Coef);
            sim.rho_f = new fmValue(1000 * fmUnitFamily.DensityFamily.CurrentUnit.Coef);
            sim.rho_s = new fmValue(1500 * fmUnitFamily.DensityFamily.CurrentUnit.Coef);
            sim.eps0 = new fmValue(50 * fmUnitFamily.ConcentrationFamily.CurrentUnit.Coef);
            sim.ne = new fmValue(0.02 * fmUnitFamily.NoUnitFamily.CurrentUnit.Coef);
            sim.Pc0 = new fmValue(1 * fmUnitFamily.PermeabilityFamily.CurrentUnit.Coef);
            sim.nc = new fmValue(0.3 * fmUnitFamily.NoUnitFamily.CurrentUnit.Coef);
            sim.hce = new fmValue(5 * fmUnitFamily.LengthFamily.CurrentUnit.Coef);
            sim.Cm = new fmValue(20 * fmUnitFamily.ConcentrationFamily.CurrentUnit.Coef);
            sim.A = new fmValue(1 * fmUnitFamily.AreaFamily.CurrentUnit.Coef);
            sim.Dp = new fmValue(1 * fmUnitFamily.PressureFamily.CurrentUnit.Coef);
            sim.sf = new fmValue(30 * fmUnitFamily.ConcentrationFamily.CurrentUnit.Coef);
            sim.n = new fmValue(1 * fmUnitFamily.FrequencyFamily.CurrentUnit.Coef);
            // END DEBUG CODE
            
            fProj.Keep();
            fProj2.Keep();

            DisplaySolution(fSolution);

            projectDataGrid.CurrentCell = projectDataGrid.Rows[0].Cells["projectNameColumn"];

            UpdateCurrentObjectAndDisplaySolution(projectDataGrid);
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

                fSolution.CurrentColumns.Project = "projectNameColumn";
                fSolution.CurrentColumns.Suspension = "suspensionNameColumn";
                fSolution.CurrentColumns.SimSerie = "simSeriesNameColumn";
                fSolution.CurrentColumns.Simulation = "simulationNameColumn";

                if (dgv == projectDataGrid)
                {
                    if (projectDataGrid.CurrentCell == null 
                        || projectDataGrid.CurrentRow.Cells["projectGuidColumn"].Value == null)
                    {
                        displayingTables = false;
                        return;
                    }

                    Guid projectGuid = (Guid)projectDataGrid.CurrentRow.Cells["projectGuidColumn"].Value;
                    fSolution.CurrentColumns.Project = projectDataGrid.Columns[projectDataGrid.CurrentCell.ColumnIndex].Name;
                    
                    fSolution.CurrentObjects.Project = fSolution.FindProject(projectGuid);
                }
                else if (dgv == suspensionDataGrid)
                {
                    if (suspensionDataGrid.CurrentCell == null
                        || suspensionDataGrid.CurrentRow.Cells["suspensionGuidColumn"].Value == null)
                    {
                        displayingTables = false;
                        return;
                    }

                    Guid suspensionGuid = (Guid)suspensionDataGrid.CurrentRow.Cells["suspensionGuidColumn"].Value;
                    fSolution.CurrentColumns.Suspension = suspensionDataGrid.Columns[suspensionDataGrid.CurrentCell.ColumnIndex].Name;
                    fSolution.CurrentObjects.Suspension = fSolution.FindSuspension(suspensionGuid);
                }
                else if (dgv == simSeriesDataGrid)
                {
                    if (simSeriesDataGrid.CurrentCell == null
                        ||  simSeriesDataGrid.CurrentRow.Cells["simSeriesGuidColumn"].Value == null)
                    {
                        displayingTables = false;
                        return;
                    }

                    Guid simSeriesGuid = (Guid)simSeriesDataGrid.CurrentRow.Cells["simSeriesGuidColumn"].Value;
                    fSolution.CurrentColumns.SimSerie = simSeriesDataGrid.Columns[simSeriesDataGrid.CurrentCell.ColumnIndex].Name;
                    fSolution.CurrentObjects.Serie = fSolution.FindSerie(simSeriesGuid);
                }
                else if (dgv == simulationDataGrid)
                {
                    if (simulationDataGrid.CurrentCell == null
                        || simulationDataGrid.CurrentRow.Cells["simulationGuidColumn"].Value == null)
                    {
                        displayingTables = false;
                        return;
                    }

                    Guid simulationGuid = (Guid)simulationDataGrid.CurrentRow.Cells["simulationGuidColumn"].Value;
                    fSolution.CurrentColumns.Simulation = simulationDataGrid.Columns[simulationDataGrid.CurrentCell.ColumnIndex].Name;
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

            fSolution.CurrentColumns.Simulation = "simulationNameColumn";
            DisplaySolution(fSolution);
            SortTables();
            SelectCurrentItemsInSolution(fSolution);

            simulationDataGrid.BeginEdit(true);
        }
    }
}