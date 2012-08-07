using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FilterSimulation;
using fmCalculationLibrary;
using FilterSimulation.fmFilterObjects;
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

        // ReSharper disable InconsistentNaming
        private void minMaxXValueTextBox_TextChanged(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
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

        private void ListBoxYAxisItemCheck(object sender, ItemCheckEventArgs e)
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
                        yParameters.Add(fmGlobalParameter.ParametersByName[clb.Items[i].Text]);
                    }
                }
            }

            if (listBoxXAxis.SelectedItems[0].Text == "")
                return;

            fmGlobalParameter xParameter = fmGlobalParameter.ParametersByName[listBoxXAxis.SelectedItems[0].Text];
            BindCalculatedResultsToDisplayingResults(xParameter, yParameters);
            BindCalculatedResultsToChartAndTable();
        }

        public void SerializeData(XmlWriter writer)
        {
            Solution.Keep();
            Solution.Serialize(writer);
        }

        public void DeserializeData(XmlNode node)
        {
            Solution = fmFilterSimSolution.Deserialize(node);
            if (Solution.projects.Count > 0)
            {
                Solution.currentObjects.Project = Solution.projects[0];
            }
            Solution.Keep();

            DisplaySolution(Solution);

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

        private void FmFilterSimulationWithTablesAndGraphsLoad(object sender, EventArgs e)
        {
            if (m_xyDialog == null)
            {
                PlaceTablesAndGraphsConfigurationPanelOnSeparateForm();
            }
        }

        private Form m_xyDialog;

        private void Button1Click(object sender, EventArgs e)
        {
            if (m_xyDialog == null || m_xyDialog.IsDisposed)
            {
                PlaceTablesAndGraphsConfigurationPanelOnSeparateForm();
            }
            m_xyDialog.Show();
            m_xyDialog.Activate();
        }

        private void PlaceTablesAndGraphsConfigurationPanelOnSeparateForm()
        {
            int oldHeight = m_xyDialog == null ? 400 : m_xyDialog.Height;
            int oldWidth = m_xyDialog == null ? 320 : m_xyDialog.Width;
            m_xyDialog = new Form();
            m_xyDialog.Closing += m_XYDialog_Closing;
            m_xyDialog.Height = oldHeight;
            m_xyDialog.Width = oldWidth;
            m_xyDialog.Text = @"Diagram Configuration";
            tablesAndGraphsTopLeftPanel.Parent = m_xyDialog;
            tablesAndGraphsTopLeftPanel.Dock = DockStyle.Fill;
        }

        void m_XYDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PlaceTablesAndGraphsConfigurationPanelOnSeparateForm();
        }

        public bool IsModified()
        {
            foreach (var project in Solution.projects)
            {
                if (project.Modified)
                {
                    return true;
                }
            }
            return false;
        }

        private void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
            BindXYLists();
        }

        private void CakeFormationMachininglParametersCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            BindXYLists();
        }

        private void DeliquoringMaterilParametersCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            BindXYLists();
        }

        private void DeliquoringMachininglParametersCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            BindXYLists();
        }

        private void DeselectAllButtonClick(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listBoxYAxis.Items)
            {
                item.Checked = false;
            }
        }

        public void SetCurrentSerieParametersToDisplay(fmParametersToDisplay parametersToDisplayList)
        {
            if (Solution.currentObjects.Serie != null)
            {
                Solution.currentObjects.Serie.ParametersToDisplay = parametersToDisplayList;
            }
            ParametersToDisplay = parametersToDisplayList;
        }

        public void SetCurrentSerieRanges(Dictionary<fmGlobalParameter, fmDefaultParameterRange> ranges)
        {
            if (Solution.currentObjects.Serie != null)
            {
                Solution.currentObjects.Serie.Ranges = ranges;
            }
            foreach (KeyValuePair<fmGlobalParameter, fmDefaultParameterRange> range in ranges)
            {
                range.Key.SpecifiedRange = range.Value;
            }
        }

        public fmParametersToDisplay GetCurrentSerieParametersToDisplay()
        {
            if (Solution.currentObjects.Serie == null)
                return null;

            return Solution.currentObjects.Serie.ParametersToDisplay;
        }

        public string GetCurrentSerieMachineName()
        {
            if (Solution.currentObjects.Serie == null)
                return "";

            return Solution.currentObjects.Serie.MachineType.name;
        }
    }
}