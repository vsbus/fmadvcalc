using System;
using System.Windows.Forms;
using FilterSimulation.fmFilterObjects;

namespace FilterSimulation
{
    public partial class FilterSimulation
    {
        #region Project Buttons
        private void projectCreateButton_Click(object sender, EventArgs e)
        {
            fSolution.CurrentObjects.Project = new fmFilterSimProject(fSolution, "Unnamed project");
            fSolution.CurrentColumns.Project = "projectNameColumn";
            DisplaySolution(fSolution);
            projectDataGrid.BeginEdit(true);
        }
        private void keepProject_Click(object sender, EventArgs e)
        {
            if (fSolution.CurrentObjects.Project != null)
            {
                fSolution.CurrentObjects.Project.Keep();
                DisplaySolution(fSolution);
            }
        }
        private void projectRestore_Click(object sender, EventArgs e)
        {
            if (fSolution.CurrentObjects.Project != null)
            {
                fSolution.CurrentObjects.Project.Restore();
                HideExtraRowsInTables(false, true, true, true);
                UpdateCurrentObjectAndDisplaySolution(projectDataGrid);
            }
        }
        private void projectDelete_Click(object sender, EventArgs e)
        {
            if (fSolution.CurrentObjects.Project != null)
            {
                fSolution.CurrentObjects.Project.Delete();
                if (!projectDataGrid.MoveCursor(1))
                    projectDataGrid.MoveCursor(-1);
                HideExtraRowsInTables(true, true, true, true);
                UpdateCurrentObjectAndDisplaySolution(projectDataGrid);
            }
        }
        #endregion
        #region Suspension Buttons
        private void keepSuspensionButton_Click(object sender, EventArgs e)
        {
            if (fSolution.CurrentObjects.Suspension != null)
            {
                fSolution.CurrentObjects.Suspension.Keep();
                DisplaySolution(fSolution);
            }
        }
        private void suspensionCreateButton_Click(object sender, EventArgs e)
        {
            fmFilterSimProject parentProject = fSolution.CurrentObjects.Project;
            if (parentProject == null)
            {
                MessageBox.Show("Please select project in project table", "Error!", MessageBoxButtons.OK);
                return;
            }

            if (!byCheckingProjects && parentProject.Checked == false)
            {
                MessageBox.Show("You try to create suspension in unchecked project.\nPlease create suspensions in checked projects.", "Error!", MessageBoxButtons.OK);
                return;
            }

            fSolution.CurrentObjects.Suspension = new fmFilterSimSuspension(parentProject, "Unnamed suspension", "Unnamed material", "Unnamed customer");
            fSolution.CurrentColumns.Suspension = "suspensionNameColumn";
            DisplaySolution(fSolution);
            suspensionDataGrid.BeginEdit(true);
        }
        private void suspensionRestoreButton_Click(object sender, EventArgs e)
        {
            if (fSolution.CurrentObjects.Suspension != null)
            {
                fSolution.CurrentObjects.Suspension.Restore();
                HideExtraRowsInTables(false, false, true, true);
                UpdateCurrentObjectAndDisplaySolution(suspensionDataGrid);
            }
        }
        private void suspensionDeleteButton_Click(object sender, EventArgs e)
        {
            if (fSolution.CurrentObjects.Suspension != null)
            {
                fSolution.CurrentObjects.Suspension.Delete();
                if (!suspensionDataGrid.MoveCursor(1))
                    suspensionDataGrid.MoveCursor(-1);
                HideExtraRowsInTables(false, true, true, true);
                UpdateCurrentObjectAndDisplaySolution(suspensionDataGrid.DisplayedRowCount(true) == 0 ? projectDataGrid : suspensionDataGrid);
            }
        }
        #endregion
        #region simSeries Buttons
        private void simSerieCreate_Click(object sender, EventArgs e)
        {
            fmFilterSimSuspension parentSuspension = fSolution.CurrentObjects.Suspension;
            if (parentSuspension == null)
            {
                MessageBox.Show("Please select suspension in suspension table", "Error!", MessageBoxButtons.OK);
                return;
            }

            if (!byCheckingSuspensions && parentSuspension.Checked == false)
            {
                MessageBox.Show("You try to create serie in unchecked suspension.\nPlease create series in checked suspensions.", "Error!", MessageBoxButtons.OK);
                return;
            }

            fmFilterSimMachineType machine = GetCurrentMachine();
            if (machine == null)
            {
                MessageBox.Show("Please select machine in machine table", "Error!", MessageBoxButtons.OK);
                return;
            }

            string serieName;
            for (int i = 1; ; ++i)
            {
                serieName = "S" + i;
                if (fSolution.FindSerie(serieName) == null)
                {
                    break;
                }
            }

            fmFilterSimulation curSim = fSolution.CurrentObjects.Simulation;

            fSolution.CurrentObjects.Serie = new fmFilterSimSerie(parentSuspension, serieName, machine, "Unnamed filter medium", "Unknown Machine Name");
            fSolution.CurrentObjects.Simulation = curSim != null ? new fmFilterSimulation(fSolution.CurrentObjects.Serie, curSim) : new fmFilterSimulation(fSolution.CurrentObjects.Serie, "");
            fSolution.CurrentObjects.Simulation.Name = fSolution.CurrentObjects.Serie.Name + "-1";
            fSolution.CurrentObjects.Serie.Keep();
            DisplaySolution(fSolution);
            SortTables();

            simSeriesDataGrid.BeginEdit(true);
        }
        private void simSeriesKeepButton_Click(object sender, EventArgs e)
        {
            if (fSolution.CurrentObjects.Serie != null)
            {
                fSolution.CurrentObjects.Serie.Keep();
                DisplaySolution(fSolution);
            }
        }
        private void simSeriesRestoreButton_Click(object sender, EventArgs e)
        {
            if (fSolution.CurrentObjects.Serie != null)
            {
                fSolution.CurrentObjects.Serie.Restore();
                HideExtraRowsInTables(false, false, false, true);
                UpdateCurrentObjectAndDisplaySolution(simSeriesDataGrid);
            }
        }
        private void simSeriesDeleteButton_Click(object sender, EventArgs e)
        {
            if (fSolution.CurrentObjects.Serie != null)
            {
                fSolution.CurrentObjects.Serie.Delete();
                if (!simSeriesDataGrid.MoveCursor(1))
                    simSeriesDataGrid.MoveCursor(-1);
                HideExtraRowsInTables(false, false, true, true);
                UpdateCurrentObjectAndDisplaySolution(simSeriesDataGrid.DisplayedRowCount(true) == 0 ? suspensionDataGrid : simSeriesDataGrid);
            }
        }
        #endregion
        #region simulation Buttons
        private void simulationDuplicateButton_Click(object sender, EventArgs e)
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
                fSolution.CurrentObjects.Simulation = new fmFilterSimulation(currentSimulation.Parent, currentSimulation);
                fSolution.CurrentObjects.Simulation.Name = simName;
                fSolution.CurrentObjects.Simulation.Keep();
            }

            fSolution.CurrentColumns.Simulation = "simulationNameColumn";
            DisplaySolution(fSolution);
            SortTables();
            SelectCurrentItemsInSolution(fSolution);

            simulationDataGrid.BeginEdit(true);
        }
        private void simulationKeepButton_Click(object sender, EventArgs e)
        {
            if (fSolution.CurrentObjects.Simulation != null)
            {
                fSolution.CurrentObjects.Simulation.Keep();
                DisplaySolution(fSolution);
            }
        }
        private void simulationRestoreButton_Click(object sender, EventArgs e)
        {
            if (fSolution.CurrentObjects.Simulation != null)
            {
                fSolution.CurrentObjects.Simulation.Restore();
                HideExtraRowsInTables(false, false, false, false);
                UpdateCurrentObjectAndDisplaySolution(simulationDataGrid);
            }
        }
        private void simulationDeleteButton_Click(object sender, EventArgs e)
        {
            if (fSolution.CurrentObjects.Simulation != null)
            {
                fSolution.CurrentObjects.Simulation.Delete();
                if (!simulationDataGrid.MoveCursor(1))
                    simulationDataGrid.MoveCursor(-1);
                HideExtraRowsInTables(false, false, false, true);
                UpdateCurrentObjectAndDisplaySolution(simulationDataGrid.DisplayedRowCount(true) == 0 ? simSeriesDataGrid : simulationDataGrid);
            }
        }
        #endregion

        private void byCheckingProjectsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            byCheckingProjects = byCheckingProjectsCheckBox.Checked;
            DisplaySolution(fSolution);
        }

        private void byCheckingSuspensionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            byCheckingSuspensions = byCheckingSuspensionsCheckBox.Checked;
            DisplaySolution(fSolution);
        }

        private void byCheckingSimSeriesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            byCheckingSimSeries = byCheckingSimSeriesCheckBox.Checked;
            DisplaySolution(fSolution);
        }
        private void byCheckingSimulationsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            byCheckingSimulations = byCheckingSimulationsCheckBox.Checked;
            DisplaySolution(fSolution);
        }

        private void fullSimulationInfoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isVisible = fullSimulationInfoCheckBox.Checked;
            simulationDataGrid.Columns["simulationProjectColumn"].Visible = isVisible;
            simulationDataGrid.Columns["simulationMaterialColumn"].Visible = isVisible;
            simulationDataGrid.Columns["simulationCustomerColumn"].Visible = isVisible;
            simulationDataGrid.Columns["simulationSuspensionNameColumn"].Visible = isVisible;
            simulationDataGrid.Columns["simulationFilterMediumColumn"].Visible = isVisible;
            simulationDataGrid.Columns["simulationMachineTypeColumn"].Visible = isVisible;
            simulationDataGrid.Columns["simulationMachineNameColumn"].Visible = isVisible;
        }

        private void duplicateSerieButton_Click(object sender, EventArgs e)
        {
            fmFilterSimSerie currentSerie = fSolution.CurrentObjects.Serie;

            if (currentSerie == null)
            {
                MessageBox.Show("Please select serie in simSeries table", "Error!", MessageBoxButtons.OK);
                return;
            }

            fSolution.CurrentObjects.Serie = new fmFilterSimSerie(currentSerie.Parent, currentSerie);
            fSolution.CurrentObjects.Serie.Name = currentSerie.Name + "d";
            fSolution.CurrentObjects.Serie.Keep();

            DisplaySolution(fSolution);
            SortTables();

            simSeriesDataGrid.BeginEdit(true);
        }

        private void unitsButton_Click(object sender, EventArgs e)
        {
            //UnitsOptions uoForm = new UnitsOptions();
            //uoForm.ShowDialog();
            //UpdateUnitsAndData();
            //DisplaySolution(fSolution);
        }

        private void DigitsOptionsbutton_Click_1(object sender, EventArgs e)
        {
            //DigitsOptions doForm = new DigitsOptions();
            //doForm.ShowDialog();
            //DisplaySolution(fSolution);
        }
    }
}
