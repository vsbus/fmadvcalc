using System;
using System.Windows.Forms;
using FilterSimulation.fmFilterObjects;

namespace FilterSimulation
{
    public partial class fmFilterSimulationControl
    {
        #region Project Buttons
        // ReSharper disable InconsistentNaming
        private void projectCreateButton_Click(object sender, EventArgs e)
        {
            m_fSolution.currentObjects.Project = new fmFilterSimProject(m_fSolution, "Unnamed project");
            m_fSolution.currentColumns.project = projectNameColumn.Index;
            DisplaySolution(m_fSolution);
            projectDataGrid.BeginEdit(true);
        }
        private void keepProject_Click(object sender, EventArgs e)
        {
            if (m_fSolution.currentObjects.Project != null)
            {
                m_fSolution.currentObjects.Project.Keep();
                DisplaySolution(m_fSolution);
            }
        }
        private void projectRestore_Click(object sender, EventArgs e)
        {
            if (m_fSolution.currentObjects.Project != null)
            {
                m_fSolution.currentObjects.Project.Restore();
                HideExtraRowsInTables(false, true, true, true);
                UpdateCurrentObjectAndDisplaySolution(projectDataGrid);
            }
        }
        private void projectDelete_Click(object sender, EventArgs e)
        {
            if (m_fSolution.currentObjects.Project != null)
            {
                m_fSolution.currentObjects.Project.Delete();
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
            if (m_fSolution.currentObjects.Suspension != null)
            {
                m_fSolution.currentObjects.Suspension.Keep();
                DisplaySolution(m_fSolution);
            }
        }
        // ReSharper disable InconsistentNaming
        private void suspensionCreateButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            fmFilterSimProject parentProject = m_fSolution.currentObjects.Project;
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

            m_fSolution.currentObjects.Suspension = new fmFilterSimSuspension(parentProject, "Unnamed suspension", "Unnamed material", "Unnamed customer");
            m_fSolution.currentColumns.suspension = suspensionNameColumn.Index;
            DisplaySolution(m_fSolution);
            suspensionDataGrid.BeginEdit(true);
        }
        // ReSharper disable InconsistentNaming
        private void suspensionRestoreButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            if (m_fSolution.currentObjects.Suspension != null)
            {
                m_fSolution.currentObjects.Suspension.Restore();
                HideExtraRowsInTables(false, false, true, true);
                UpdateCurrentObjectAndDisplaySolution(suspensionDataGrid);
            }
        }
        // ReSharper disable InconsistentNaming
        private void suspensionDeleteButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            if (m_fSolution.currentObjects.Suspension != null)
            {
                m_fSolution.currentObjects.Suspension.Delete();
                if (!suspensionDataGrid.MoveCursor(1))
                    suspensionDataGrid.MoveCursor(-1);
                HideExtraRowsInTables(false, true, true, true);
                UpdateCurrentObjectAndDisplaySolution(suspensionDataGrid.DisplayedRowCount(true) == 0 ? projectDataGrid : suspensionDataGrid);
            }
        }
        #endregion
        #region simSeries Buttons
        // ReSharper disable InconsistentNaming
        private void simSerieCreate_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            fmFilterSimSuspension parentSuspension = m_fSolution.currentObjects.Suspension;
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

            fmFilterSimMachineType machine = GetCurrentMachine();
            if (machine == null)
            {
                MessageBox.Show(@"Please select machine in machine table", @"Error!", MessageBoxButtons.OK);
                return;
            }

            string serieName;
            for (int i = 1; ; ++i)
            {
                serieName = "S" + i;
                if (m_fSolution.FindSerie(serieName) == null)
                {
                    break;
                }
            }

            fmFilterSimulation curSim = m_fSolution.currentObjects.Simulation;

            m_fSolution.currentObjects.Serie = new fmFilterSimSerie(parentSuspension, serieName, machine, "Unnamed filter medium", "Unknown Machine Name");
            m_fSolution.currentObjects.Simulation = curSim != null ? new fmFilterSimulation(m_fSolution.currentObjects.Serie, curSim) : new fmFilterSimulation(m_fSolution.currentObjects.Serie, "");
            m_fSolution.currentObjects.Simulation.Name = m_fSolution.currentObjects.Serie.Name + "-1";
            m_fSolution.currentObjects.Serie.Keep();
            DisplaySolution(m_fSolution);
            SortTables();

            simSeriesDataGrid.BeginEdit(true);
        }
        // ReSharper disable InconsistentNaming
        private void simSeriesKeepButton_Click(object sender, EventArgs e)
        {
            if (m_fSolution.currentObjects.Serie != null)
            {
                m_fSolution.currentObjects.Serie.Keep();
                DisplaySolution(m_fSolution);
            }
        }
        private void simSeriesRestoreButton_Click(object sender, EventArgs e)
        {
            if (m_fSolution.currentObjects.Serie != null)
            {
                m_fSolution.currentObjects.Serie.Restore();
                HideExtraRowsInTables(false, false, false, true);
                UpdateCurrentObjectAndDisplaySolution(simSeriesDataGrid);
            }
        }
        private void simSeriesDeleteButton_Click(object sender, EventArgs e)
        {
            if (m_fSolution.currentObjects.Serie != null)
            {
                m_fSolution.currentObjects.Serie.Delete();
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
                m_fSolution.currentObjects.Simulation = new fmFilterSimulation(currentSimulation.Parent, currentSimulation) { Name = simName };
                m_fSolution.currentObjects.Simulation.Keep();
            }

            m_fSolution.currentColumns.simulation = simulationNameColumn.Index;
            DisplaySolution(m_fSolution);
            SortTables();
            SelectCurrentItemsInSolution(m_fSolution);

            simulationDataGrid.BeginEdit(true);
        }
        // ReSharper disable InconsistentNaming
        private void simulationKeepButton_Click(object sender, EventArgs e)
        {
            if (m_fSolution.currentObjects.Simulation != null)
            {
                m_fSolution.currentObjects.Simulation.Keep();
                DisplaySolution(m_fSolution);
            }
        }
        private void simulationRestoreButton_Click(object sender, EventArgs e)
        {
            if (m_fSolution.currentObjects.Simulation != null)
            {
                m_fSolution.currentObjects.Simulation.Restore();
                HideExtraRowsInTables(false, false, false, false);
                UpdateCurrentObjectAndDisplaySolution(simulationDataGrid);
            }
        }
        private void simulationDeleteButton_Click(object sender, EventArgs e)
        {
            if (m_fSolution.currentObjects.Simulation != null)
            {
                m_fSolution.currentObjects.Simulation.Delete();
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
            DisplaySolution(m_fSolution);
        }

        private void byCheckingSuspensionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_byCheckingSuspensions = byCheckingSuspensionsCheckBox.Checked;
            DisplaySolution(m_fSolution);
        }

        private void byCheckingSimSeriesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_byCheckingSimSeries = byCheckingSimSeriesCheckBox.Checked;
            DisplaySolution(m_fSolution);
        }
        private void byCheckingSimulationsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            byCheckingSimulations = byCheckingSimulationsCheckBox.Checked;
            DisplaySolution(m_fSolution);
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
            fmFilterSimSerie currentSerie = m_fSolution.currentObjects.Serie;

            if (currentSerie == null)
            {
                MessageBox.Show(@"Please select serie in simSeries table", @"Error!", MessageBoxButtons.OK);
                return;
            }

            m_fSolution.currentObjects.Serie = new fmFilterSimSerie(currentSerie.Parent, currentSerie) { Name = currentSerie.Name + "d" };
            m_fSolution.currentObjects.Serie.Keep();

            DisplaySolution(m_fSolution);
            SortTables();

            simSeriesDataGrid.BeginEdit(true);
        }
        // ReSharper restore InconsistentNaming
    }
}
