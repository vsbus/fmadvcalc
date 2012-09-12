using System;
using System.Windows.Forms;
using FilterSimulation.fmFilterObjects;
using fmMisc;

namespace FilterSimulation
{
    public partial class fmFilterSimulationControl
    {
        #region Project Buttons
        // ReSharper disable InconsistentNaming
        private void projectCreateButton_Click(object sender, EventArgs e)
        {
            CreateNewProject();
            CreateNewSuspension(Solution.currentObjects.Project);
            CreateNewSerie(Solution.currentObjects.Suspension);
            
            DisplaySolution(Solution);
            projectDataGrid.BeginEdit(true);
        }

        protected void CreateNewProject()
        {
            Solution.currentObjects.Project = new fmFilterSimProject(Solution, "n/a");
            Solution.currentColumns.project = projectNameColumn.Index;
        }
        private void keepProject_Click(object sender, EventArgs e)
        {
            if (Solution.currentObjects.Project != null)
            {
                Solution.currentObjects.Project.Keep();
                DisplaySolution(Solution);
            }
        }
        private void projectRestore_Click(object sender, EventArgs e)
        {
            if (Solution.currentObjects.Project != null)
            {
                Solution.currentObjects.Project.Restore();
                HideExtraRowsInTables(false, true, true, true);
                UpdateCurrentObjectAndDisplaySolution(projectDataGrid);
            }
        }
        private void projectDelete_Click(object sender, EventArgs e)
        {
            if (Solution.currentObjects.Project != null)
            {
                Solution.currentObjects.Project.Delete();
                if (!projectDataGrid.MoveCursor(1))
                    projectDataGrid.MoveCursor(-1);
                HideExtraRowsInTables(true, true, true, true);
                UpdateCurrentObjectAndDisplaySolution(projectDataGrid);
            }
        }
        // ReSharper restore InconsistentNaming
        #endregion
        #region Suspension Buttons
        // ReSharper disable InconsistentNaming
        private void keepSuspensionButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            if (Solution.currentObjects.Suspension != null)
            {
                Solution.currentObjects.Suspension.Keep();
                DisplaySolution(Solution);
            }
        }
        
        private void suspensionCreateButton_Click(object sender, EventArgs e)
        {
            fmFilterSimProject parentProject = Solution.currentObjects.Project;
            if (parentProject == null)
            {
                MessageBox.Show(@"Please select project in project table", @"Error!", MessageBoxButtons.OK);
                return;
            }

            if (!m_byCheckingProjects && parentProject.Checked == false)
            {
                MessageBox.Show(@"You try to create suspension in unchecked project.
Please create suspensions in checked projects.", @"Error!", MessageBoxButtons.OK);
                return;
            }

            int currentCol = -1;
            if (suspensionDataGrid.CurrentCell != null)
            {
                currentCol = suspensionDataGrid.CurrentCell.ColumnIndex;
            }
            
            CreateNewSuspension(parentProject);
            CreateNewSerie(Solution.currentObjects.Suspension);

            DisplaySolution(Solution);
            if (currentCol != -1 && suspensionDataGrid.CurrentCell != null)
            {
                suspensionDataGrid.CurrentCell = suspensionDataGrid[currentCol, suspensionDataGrid.CurrentCell.RowIndex];
            }
        }

        protected void CreateNewSuspension(fmFilterSimProject parentProject)
        {
            Solution.currentObjects.Suspension = new fmFilterSimSuspension(parentProject, "n/a", "n/a", "n/a");
            Solution.currentColumns.suspension = suspensionNameColumn.Index;
        }
        // ReSharper disable InconsistentNaming
        private void suspensionRestoreButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            if (Solution.currentObjects.Suspension != null)
            {
                Solution.currentObjects.Suspension.Restore();
                HideExtraRowsInTables(false, false, true, true);
                UpdateCurrentObjectAndDisplaySolution(suspensionDataGrid);
            }
        }
        // ReSharper disable InconsistentNaming
        private void suspensionDeleteButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            if (Solution.currentObjects.Suspension != null)
            {
                Solution.currentObjects.Suspension.Delete();
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
            fmFilterSimSuspension parentSuspension = Solution.currentObjects.Suspension;
            if (parentSuspension == null)
            {
                MessageBox.Show(@"Please select suspension in suspension table", @"Error!", MessageBoxButtons.OK);
                return;
            }

            if (!m_byCheckingSuspensions && parentSuspension.Checked == false)
            {
                MessageBox.Show(@"You try to create serie in unchecked suspension.
Please create series in checked suspensions.", @"Error!", MessageBoxButtons.OK);
                return;
            }

            if (!CreateNewSerie(parentSuspension))
            {
                return;
            }

            DisplaySolution(Solution);
            SortTables();

            simSeriesDataGrid.BeginEdit(true);
        }

        protected bool CreateNewSerie(fmFilterSimSuspension parentSuspension)
        {
            fmFilterSimMachineType machine = fmFilterSimMachineType.filterTypesList[0];
            string serieName;
            for (int i = 1; ; ++i)
            {
                serieName = "S" + i;
                if (Solution.FindSerie(serieName) == null)
                {
                    break;
                }
            }
            var fakeSerie = new fmFilterSimSerie(null, serieName, machine, "n/a", "n/a");

            var dialog = new MachineTypeSelectionDialog();
            dialog.AssignSerie(fakeSerie);
            dialog.ShowDialog();
            if (dialog.DialogResult != DialogResult.OK)
            {
                return false;
            }
            
            machine = dialog.GetSelectedType();
            fmFilterSimulation curSim = Solution.currentObjects.Simulation;
            Solution.currentObjects.Serie = new fmFilterSimSerie(parentSuspension, serieName, machine, "n/a", "n/a");
            Solution.currentObjects.Simulation = new fmFilterSimulation(Solution.currentObjects.Serie, "Sim");
            Solution.currentObjects.Simulation.SetName(Solution.currentObjects.Serie.GetName() + "-1");

            fmFilterSimMachineType.FilterCycleType value = machine.GetFilterCycleType();
            if (ShowHideSchemas.ContainsKey(value))
            {
                Solution.currentObjects.Serie.ParametersToDisplay =
                    new fmParametersToDisplay(value, ShowHideSchemas[value]);
            }
            if (RangesSchemas.ContainsKey(machine))
            {
                Solution.currentObjects.Serie.Ranges = 
                    new fmRangesConfiguration(machine, RangesSchemas[machine]);
            }

            Solution.currentObjects.Serie.Keep();

            return true;
        }
        // ReSharper disable InconsistentNaming
        private void simSeriesKeepButton_Click(object sender, EventArgs e)
        {
            if (Solution.currentObjects.Serie != null)
            {
                Solution.currentObjects.Serie.Keep();
                DisplaySolution(Solution);
            }
        }
        private void simSeriesRestoreButton_Click(object sender, EventArgs e)
        {
            if (Solution.currentObjects.Serie != null)
            {
                Solution.currentObjects.Serie.Restore();
                HideExtraRowsInTables(false, false, false, true);
                UpdateCurrentObjectAndDisplaySolution(simSeriesDataGrid);
            }
        }
        private void simSeriesDeleteButton_Click(object sender, EventArgs e)
        {
            if (Solution.currentObjects.Serie != null)
            {
                Solution.currentObjects.Serie.Delete();
                if (!simSeriesDataGrid.MoveCursor(1))
                    simSeriesDataGrid.MoveCursor(-1);
                HideExtraRowsInTables(false, false, true, true);
                UpdateCurrentObjectAndDisplaySolution(simSeriesDataGrid.DisplayedRowCount(true) == 0 ? suspensionDataGrid : simSeriesDataGrid);
            }
        }
        // ReSharper restore InconsistentNaming
        #endregion
        #region simulation Buttons
        // ReSharper disable InconsistentNaming
        private void simulationDuplicateButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            fmFilterSimSerie parentSerie = Solution.currentObjects.Serie;
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

            if (Solution.currentObjects.Simulation == null)
            {
                return;
            }
            else
            {
                string simName = Solution.currentObjects.Simulation.GetName() + "c";
                fmFilterSimulation currentSimulation = Solution.currentObjects.Simulation;
                Solution.currentObjects.Simulation = new fmFilterSimulation(currentSimulation.Parent, currentSimulation);
                Solution.currentObjects.Simulation.SetName(simName);
                Solution.currentObjects.Simulation.Keep();
            }

            Solution.currentColumns.simulation = simulationNameColumn.Index;
            DisplaySolution(Solution);
            SortTables();
            SelectCurrentItemsInSolution(Solution);

            simulationDataGrid.BeginEdit(true);
        }
        // ReSharper disable InconsistentNaming
        private void simulationKeepButton_Click(object sender, EventArgs e)
        {
            if (Solution.currentObjects.Simulation != null)
            {
                Solution.currentObjects.Simulation.Keep();
                DisplaySolution(Solution);
            }
        }
        private void simulationRestoreButton_Click(object sender, EventArgs e)
        {
            if (Solution.currentObjects.Simulation != null)
            {
                Solution.currentObjects.Simulation.Restore();
                HideExtraRowsInTables(false, false, false, false);
                UpdateCurrentObjectAndDisplaySolution(simulationDataGrid);
            }
        }
        private void simulationDeleteButton_Click(object sender, EventArgs e)
        {
            if (Solution.currentObjects.Simulation != null)
            {
                Solution.currentObjects.Simulation.Delete();
                if (!simulationDataGrid.MoveCursor(1))
                    simulationDataGrid.MoveCursor(-1);
                HideExtraRowsInTables(false, false, false, true);
                UpdateCurrentObjectAndDisplaySolution(simulationDataGrid.DisplayedRowCount(true) == 0 ? simSeriesDataGrid : simulationDataGrid);
            }
        }
        #endregion

        private void byCheckingProjectsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_byCheckingProjects = byCheckingProjectsCheckBox.Checked;
            DisplaySolution(Solution);
        }

        private void byCheckingSuspensionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_byCheckingSuspensions = byCheckingSuspensionsCheckBox.Checked;
            DisplaySolution(Solution);
        }

        private void byCheckingSimSeriesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_byCheckingSimSeries = byCheckingSimSeriesCheckBox.Checked;
            DisplaySolution(Solution);
        }
        private void byCheckingSimulationsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            byCheckingSimulations = byCheckingSimulationsCheckBox.Checked;
            DisplaySolution(Solution);
        }

        private void fullSimulationInfoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isVisible = fullSimulationInfoCheckBox.Checked;
            simulationDataGrid.Columns[simulationProjectColumn.Index].Visible = isVisible;
            simulationDataGrid.Columns[simulationSuspensionNameColumn.Index].Visible = isVisible;
            simulationDataGrid.Columns[simulationFilterMediumColumn.Index].Visible = isVisible;
            simulationDataGrid.Columns[simulationMachineTypeColumn.Index].Visible = isVisible;
            simulationDataGrid.Columns[simulationMachineNameColumn.Index].Visible = isVisible;
        }

        private void duplicateSerieButton_Click(object sender, EventArgs e)
        {
            fmFilterSimSerie currentSerie = Solution.currentObjects.Serie;

            if (currentSerie == null)
            {
                MessageBox.Show(@"Please select serie in simSeries table", @"Error!", MessageBoxButtons.OK);
                return;
            }

            Solution.currentObjects.Serie = new fmFilterSimSerie(currentSerie.Parent, currentSerie)
                                                   {
                                                       ParametersToDisplay = currentSerie.ParametersToDisplay
                                                   };
            Solution.currentObjects.Serie.SetName(currentSerie.GetName() + "d");
            Solution.currentObjects.Serie.Keep();

            DisplaySolution(Solution);
            SortTables();

            simSeriesDataGrid.BeginEdit(true);
        }
        // ReSharper restore InconsistentNaming
    }
}
