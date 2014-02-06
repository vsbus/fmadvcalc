using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FilterSimulation;
using fmCalculationLibrary;
using FilterSimulation.fmFilterObjects;
using System.Xml;
using fmCalculationLibrary.MeasureUnits;
using System.Drawing;

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

            SelfRef = this;
        }

        public static fmFilterSimulationWithTablesAndGraphs SelfRef
        {
            get;
            set;
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

        protected override void UpdateUnitsAndData()
        {
            base.UpdateUnitsAndData();
            UpdateUnitsInTablesAndGraphs();
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

        private void MinMaxXValueTextBoxTextChanged(object sender, EventArgs e)
        {
            if (InvolvedSeriesDataGrid.CurrentCell != null)
            {
                DataGridViewRow row = InvolvedSeriesDataGrid.CurrentCell.OwningRow;
                fmGlobalParameter xParameter = GetCurrentXAxisParameter();
                double coef = xParameter.UnitFamily.CurrentUnit.Coef;
                fmFilterSimSerie serie = m_involvedSerieFromRow[row];
                m_involvedSeries[serie] = new fmRange(
                    (fmValue.ObjectToValue(row.Cells[1].Value) * coef).value,
                    (fmValue.ObjectToValue(row.Cells[2].Value) * coef).value);
            }
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
                    if (coordinatesGrid.CurrentCell != null && m_displayingResults.XParameter != null)
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

        public void SerializeData(XmlWriter writer)
        {
            Solution.Keep();
            Solution.Serialize(writer);
        }

        public bool Clear()
        {
            var tempSolution = Solution;
            Solution = new fmFilterSimSolution();
            var dialog = new StartMachineTypeSelectionDialog(Solution, true);
            dialog.InitializeMachineTypesComboBox();
            dialog.InitCalculationsSettingsWindow(GetCurrentSerieRanges(dialog.GetSelectedType()).Ranges, RangesSchemas, GetCurrentSerieParametersToDisplay(dialog.GetSelectedType().GetFilterCycleType()), ShowHideSchemas);
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                Solution = tempSolution;
                return false;
            }

            CreateNewProject(dialog.GetProjectName());
            CreateNewSuspension(Solution.currentObjects.Project, dialog.GetSuspensionName(), dialog.GetMaterialName(), dialog.GetCustomerName());
            CreateNewSerie(Solution.currentObjects.Suspension, dialog.GetSerieName(), dialog.GetMediumName(), dialog.GetSimulationName(), dialog.GetSelectedType());
            DisplaySolution(Solution);

            var rangesCfg = new fmRangesConfiguration
            {
                AssignedMachineType = dialog.GetRangesMachineType(),
                Ranges = dialog.GetRanges()
            };

            Solution.currentObjects.Serie.Ranges = rangesCfg;
            foreach (KeyValuePair<fmGlobalParameter, fmDefaultParameterRange> range in rangesCfg.Ranges)
            {
                range.Key.SpecifiedRange = range.Value;
            }

            RangesSchemas = dialog.GetRangesSchemas();

            var parametersToDisplay = new fmParametersToDisplay(dialog.GetCheckedSchema(), dialog.GetCheckedItems());
            SetCurrentSerieParametersToDisplayOrDefault(parametersToDisplay);
            ShowHideSchemas = dialog.GetShowHideSchemas();

            UpdateAll();

            dialog.GetCalculationOptions(Solution.currentObjects.Simulation);

            return true;
        }

        public void DeserializeData(XmlNode node)
        {
            Solution = fmFilterSimSolution.Deserialize(node);
            if (Solution.projects.Count > 0 && Solution.currentObjects.Project == null)
            {
                Solution.currentObjects.Project = Solution.projects[0];
            }
            Solution.Keep();

            DisplaySolution(Solution);
            {
                bool isChecked = false;
                for (int row = 0; row < simulationDataGrid.Rows.Count; ++row)
                {
                    if ((Guid)simulationDataGrid[simulationGuidColumn.Index, row].Value == Solution.currentObjects.Simulation.Guid)
                    {
                        for (int col = 0; col < simulationDataGrid.ColumnCount; ++col)
                        {
                            if (simulationDataGrid[col, row].Visible)
                            {
                                isChecked = true;
                                {
                                    simulationDataGrid.CurrentCell = simulationDataGrid[col, row];
                                    UpdateCurrentObjectAndDisplaySolution(simulationDataGrid);
                                    break;
                                }
                            }
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
            int oldHeight = m_xyDialog == null ? 900 : m_xyDialog.Height;
            int oldWidth = m_xyDialog == null ? 600 : m_xyDialog.Width;
            m_xyDialog = new Form();
            m_xyDialog.Closing += MXyDialogClosing;
            m_xyDialog.Height = oldHeight;
            m_xyDialog.Width = oldWidth;
            m_xyDialog.Text = @"Diagram Configuration";
            m_xyDialog.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            tablesAndGraphsTopLeftPanel.Parent = m_xyDialog;
            tablesAndGraphsTopLeftPanel.Dock = DockStyle.Fill;
        }

        void MXyDialogClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PlaceTablesAndGraphsConfigurationPanelOnSeparateForm();
        }

        public bool IsModified()
        {
            return Solution.projects.Any(project => project.Modified);
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

        public fmRangesConfiguration GetCurrentSerieRanges()
        {
            if (Solution.currentObjects.Serie != null)
            {
                return new fmRangesConfiguration(Solution.currentObjects.Serie.Ranges);
            }
            return new fmRangesConfiguration();
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

        private void NoScalingCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void CopyToolStripMenuItemClick(object sender, EventArgs e)
        {
            DataGridViewCell curCell = coordinatesGrid.CurrentCell;
            coordinatesGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            coordinatesGrid.SelectAll();
            DataObject dataObj = coordinatesGrid.GetClipboardContent();
            Clipboard.SetDataObject(dataObj, true);
            coordinatesGrid.CurrentCell = curCell;
            coordinatesGrid.ClearSelection();
        }

        private void StartFromOriginCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void InvolvedSeriesDataGrid_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            MinMaxXValueTextBoxTextChanged(sender, new EventArgs());
        }

        private void LoadDefaultRangle_Click(object sender, EventArgs e)
        {
            if (InvolvedSeriesDataGrid.CurrentCell != null)
            {
                DataGridViewRow row = InvolvedSeriesDataGrid.CurrentCell.OwningRow;
                fmGlobalParameter xParameter = GetCurrentXAxisParameter();
                double coef = xParameter.UnitFamily.CurrentUnit.Coef;
                fmFilterSimSerie serie = m_involvedSerieFromRow[row];
                row.Cells[1].Value = new fmValue(serie.Ranges.Ranges[xParameter].MinValue / coef).ToString();
                row.Cells[2].Value = new fmValue(serie.Ranges.Ranges[xParameter].MaxValue / coef).ToString();
            }
            MinMaxXValueTextBoxTextChanged(sender, e);
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

            if (listBoxXAxis.SelectedItems.Count == 0 || listBoxXAxis.SelectedItems[0].Text == "")
                return;

            fmGlobalParameter xParameter = GetCurrentXAxisParameter();
            BindY2List(yParameters);

            var y2Parameters = new List<fmGlobalParameter>();
            for (int i = 0; i < listBoxY2Axis.Items.Count; ++i)
            {
                if (listBoxY2Axis.Items[i].Checked)
                {
                    y2Parameters.Add(fmGlobalParameter.ParametersByName[listBoxY2Axis.Items[i].Text]);
                }
            }

            BindCalculatedResultsToDisplayingResults(xParameter, yParameters, y2Parameters);
            BindCalculatedResultsToChartAndTable();
        }

        private void ListBoxY2AxisItemCheck(object sender, ItemCheckEventArgs e)
        {
            var yParameters = new List<fmGlobalParameter>();
            for (int i = 0; i < listBoxYAxis.Items.Count; ++i)
            {
                if (listBoxYAxis.Items[i].Checked)
                {
                    yParameters.Add(fmGlobalParameter.ParametersByName[listBoxYAxis.Items[i].Text]);
                }
            }

            var y2Parameters = new List<fmGlobalParameter>();

            var clb = sender as ListView;
            if (clb != null)
            {
                for (int i = 0; i < clb.Items.Count; ++i)
                {
                    if (i == e.Index && e.NewValue == CheckState.Checked
                        || clb.Items[i].Checked && (e.NewValue == CheckState.Checked || i != e.Index))
                    {
                        y2Parameters.Add(fmGlobalParameter.ParametersByName[clb.Items[i].Text]);
                    }
                }
            }

            if (listBoxXAxis.SelectedItems.Count == 0 || listBoxXAxis.SelectedItems[0].Text == "")
                return;

            fmGlobalParameter xParameter = GetCurrentXAxisParameter();
            BindCalculatedResultsToDisplayingResults(xParameter, yParameters, y2Parameters);
            BindCalculatedResultsToChartAndTable();
        }

        #region Serialization

        private static class fmFilterSimulationWithDiagramsSerializeTags
        {
            public const string DiagramOptions = "DiagramOptions";
            public const string XParameterName = "XParameterName";
            public const string Y1ParameterName = "Y1ParameterName";
            public const string Y2ParameterName = "Y2ParameterName";

            public const string RowsQuantity = "RowsQuantity";
            public const string CakeFormationMaterilParametersCheckBox = "CakeFormationMaterilParametersCheckBox";
            public const string CakeFormationMachininglParametersCheckBox = "CakeFormationMachininglParametersCheckBox";
            public const string DeliquoringMaterilParametersCheckBox = "DeliquoringMaterilParametersCheckBox";
            public const string DeliquoringMachininglParametersCheckBox = "DeliquoringMachininglParametersCheckBox";

            public const string NoScalingCheckBox = "NoScalingCheckBox";
            public const string StartFromOriginCheckBox = "StartFromOriginCheckBox";
            public const string XLogCheckBox = "XLogCheckBox";
            public const string YLogCheckBox = "YLogCheckBox";
            public const string Y2LogCheckBox = "Y2LogCheckBox";
            public const string UseParamsCheckBox = "UseParamsCheckBox";

            public const string MinMaxValuesOfTheXAxisParameter = "MinMax_Values_Of_The_XAxis_Parameter";            
            public const string MinMaxParameter = "MinMax_Parameter";            
        }

        override protected void SerializeDiagramOptions(XmlWriter writer)
        {
            writer.WriteStartElement(fmFilterSimulationWithDiagramsSerializeTags.DiagramOptions);
            fmGlobalParameter xParameter = GetCurrentXAxisParameter();
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.XParameterName, xParameter == null ? "" : xParameter.Name);
            foreach (ListViewItem item in listBoxYAxis.Items)
            {
                if (item.Checked)
                {
                    writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.Y1ParameterName, item.Text);
                }
            }
            foreach (ListViewItem item in listBoxY2Axis.Items)
            {
                if (item.Checked)
                {
                    writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.Y2ParameterName, item.Text);
                }
            }

            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.RowsQuantity, rowsQuantity.Text);
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.CakeFormationMaterilParametersCheckBox, cakeFormationMaterilParametersCheckBox.Checked.ToString());
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.CakeFormationMachininglParametersCheckBox, cakeFormationMachininglParametersCheckBox.Checked.ToString());
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.DeliquoringMaterilParametersCheckBox, deliquoringMaterilParametersCheckBox.Checked.ToString());
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.DeliquoringMachininglParametersCheckBox, deliquoringMachininglParametersCheckBox.Checked.ToString());
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.NoScalingCheckBox, NoScalingCheckBox.Checked.ToString());
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.StartFromOriginCheckBox, startFromOriginCheckBox.Checked.ToString());
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.XLogCheckBox, xLogCheckBox.Checked.ToString());
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.YLogCheckBox, yLogCheckBox.Checked.ToString());
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.Y2LogCheckBox, y2LogCheckBox.Checked.ToString());
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.UseParamsCheckBox, UseParamsCheckBox.Checked.ToString());

            SerializeMinMaxValuesOfTheXAxisParameter(writer);
            writer.WriteEndElement();
        }

        private fmGlobalParameter GetCurrentXAxisParameter()
        {
            if (listBoxXAxis.SelectedItems.Count == 0)
            {
                return null;
            }
            return fmGlobalParameter.ParametersByName[listBoxXAxis.SelectedItems[0].Text];
        }

        private void SerializeMinMaxValuesOfTheXAxisParameter(XmlWriter writer)
        {
            writer.WriteStartElement(fmFilterSimulationWithDiagramsSerializeTags.MinMaxValuesOfTheXAxisParameter);            
            foreach (DataGridViewRow row in InvolvedSeriesDataGrid.Rows)
            {
                writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.MinMaxParameter, row.Cells[1].Value.ToString());
                writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.MinMaxParameter, row.Cells[2].Value.ToString());
            }
            writer.WriteEndElement();
        }

        public void LoadLastMinMaxValues(XmlNode node)
        {
            node = node.SelectSingleNode(fmFilterSimulationWithDiagramsSerializeTags.DiagramOptions);
            DeserializeMinMaxValuesOfTheXAxisParameter(node.SelectSingleNode(fmFilterSimulationWithDiagramsSerializeTags.MinMaxValuesOfTheXAxisParameter));
        }

        protected void DeserializeMinMaxValuesOfTheXAxisParameter(XmlNode node)
        {
            if (node == null)
            {
                return;
            }
            XmlNodeList MinMaxParameters = node.SelectNodes(fmFilterSimulationWithDiagramsSerializeTags.MinMaxParameter);
            if (MinMaxParameters != null)
            {
                int row = 0;
                int column = 1;
                foreach (XmlNode minmaxparamater in MinMaxParameters)
                {
                    if (InvolvedSeriesDataGrid.Rows.Count <= row)
                    {
                        continue;
                    }
                    InvolvedSeriesDataGrid.Rows[row].Cells[column].Value = minmaxparamater.InnerText.ToString();
                    
                    if (column == 1)
                        ++column;
                    else
                    {
                        ++row;
                        --column;
                    }
                }
            }
            MinMaxXValueTextBoxTextChanged(null, new EventArgs());
        }

        override protected void DeserializeDiagramOptionsFromConfigFile(XmlNode node)
        {
            node = node.SelectSingleNode(fmFilterSimulationWithDiagramsSerializeTags.DiagramOptions);
            if (node == null)
            {
                return;
            }

            DeserializePartOfDiagramOptions(node);

            DeserializeXParameter(node);

            DeserializeY1NodesForProgramStarting(node);

            DeserializeY2Nodes(node);            
        }

        override protected void DeserializeDiagramOptionsFromDataFile(XmlNode node)
        {
            node = node.SelectSingleNode(fmFilterSimulationWithDiagramsSerializeTags.DiagramOptions);
            if (node == null)
            {
                return;
            }

            DeserializePartOfDiagramOptions(node);

            DeserializeXParameter(node);

            DeserializeY1NodesForMenuOpen(node);

            DeserializeY2Nodes(node);

            DeserializeMinMaxValuesOfTheXAxisParameter(node.SelectSingleNode(fmFilterSimulationWithDiagramsSerializeTags.MinMaxValuesOfTheXAxisParameter));            
        }

        public void DeserializePartOfDiagramOptions(XmlNode node)
        {
            string temp = "";
            if (fmSerializeTools.DeserializeStringProperty(
                ref temp,
                node,
                fmFilterSimulationWithDiagramsSerializeTags.RowsQuantity))
            {
                rowsQuantity.Text = temp;
            }

            if (fmSerializeTools.DeserializeStringProperty(
                ref temp,
                node,
                fmFilterSimulationWithDiagramsSerializeTags.CakeFormationMaterilParametersCheckBox))
            {
                cakeFormationMaterilParametersCheckBox.Checked = Convert.ToBoolean(temp);
            }

            if (fmSerializeTools.DeserializeStringProperty(
                ref temp,
                node,
                fmFilterSimulationWithDiagramsSerializeTags.CakeFormationMachininglParametersCheckBox))
            {
                cakeFormationMachininglParametersCheckBox.Checked = Convert.ToBoolean(temp);
            }

            if (fmSerializeTools.DeserializeStringProperty(
                ref temp,
                node,
                fmFilterSimulationWithDiagramsSerializeTags.DeliquoringMaterilParametersCheckBox))
            {
                deliquoringMaterilParametersCheckBox.Checked = Convert.ToBoolean(temp);
            }

            if (fmSerializeTools.DeserializeStringProperty(
                ref temp,
                node,
                fmFilterSimulationWithDiagramsSerializeTags.DeliquoringMachininglParametersCheckBox))
            {
                deliquoringMachininglParametersCheckBox.Checked = Convert.ToBoolean(temp);
            }

            if (fmSerializeTools.DeserializeStringProperty(
                ref temp,
                node,
                fmFilterSimulationWithDiagramsSerializeTags.NoScalingCheckBox))
            {
                NoScalingCheckBox.Checked = Convert.ToBoolean(temp);
            }

            if (fmSerializeTools.DeserializeStringProperty(
                ref temp,
                node,
                fmFilterSimulationWithDiagramsSerializeTags.StartFromOriginCheckBox))
            {
                startFromOriginCheckBox.Checked = Convert.ToBoolean(temp);
            }

            if (fmSerializeTools.DeserializeStringProperty(
                ref temp,
                node,
                fmFilterSimulationWithDiagramsSerializeTags.XLogCheckBox))
            {
                xLogCheckBox.Checked = Convert.ToBoolean(temp);
            }

            if (fmSerializeTools.DeserializeStringProperty(
                ref temp,
                node,
                fmFilterSimulationWithDiagramsSerializeTags.YLogCheckBox))
            {
                yLogCheckBox.Checked = Convert.ToBoolean(temp);
            }

            if (fmSerializeTools.DeserializeStringProperty(
                ref temp,
                node,
                fmFilterSimulationWithDiagramsSerializeTags.Y2LogCheckBox))
            {
                y2LogCheckBox.Checked = Convert.ToBoolean(temp);
            }

            if (fmSerializeTools.DeserializeStringProperty(
                ref temp,
                node,
                fmFilterSimulationWithDiagramsSerializeTags.UseParamsCheckBox))
            {
                UseParamsCheckBox.Checked = Convert.ToBoolean(temp);
            }
        }

        public void DeserializeXParameter(XmlNode node)
        {
            string xParameterName = "tf";
            fmSerializeTools.DeserializeStringProperty(ref xParameterName, node,
                                                       fmFilterSimulationWithDiagramsSerializeTags.XParameterName);
            foreach (ListViewItem item in listBoxXAxis.Items)
            {
                if (item.Text == xParameterName)
                {
                    item.Selected = true;
                }
            }
        }

        public void DeserializeY1NodesForMenuOpen(XmlNode node)
        {
            XmlNodeList y1Nodes = node.SelectNodes(fmFilterSimulationWithDiagramsSerializeTags.Y1ParameterName);
            if (y1Nodes != null)
            {
                foreach (ListViewItem item in listBoxYAxis.Items)
                {
                    item.Checked = false;
                    foreach (XmlNode y1Node in y1Nodes)
                    {
                        if (item.Text == y1Node.InnerText)
                            item.Checked = true;
                    }
                }
            }
        }

        public void DeserializeY1NodesForProgramStarting(XmlNode node)
        {
            XmlNodeList y1Nodes = node.SelectNodes(fmFilterSimulationWithDiagramsSerializeTags.Y1ParameterName);
            if (y1Nodes != null)
                foreach (XmlNode y1Node in y1Nodes)
                {
                    listBoxYAxis.Items.Add(y1Node.InnerText).Checked = true;
                }
        }

        public void DeserializeY2Nodes(XmlNode node)
        {
            XmlNodeList y2Nodes = node.SelectNodes(fmFilterSimulationWithDiagramsSerializeTags.Y2ParameterName);
            if (y2Nodes != null)
                foreach (XmlNode y2Node in y2Nodes)
                {
                    bool isFound = false;
                    foreach (ListViewItem item in listBoxY2Axis.Items)
                    {
                        if (item.Text == y2Node.InnerText)
                        {
                            item.Checked = true;
                            isFound = true;
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        listBoxY2Axis.Items.Add(y2Node.InnerText).Checked = true;
                    }
                }
        }
        
        #endregion

        private void YLogCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void Y2LogCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            if (additionalParametersTable.CurrentCell == null)
            {
                additionalParametersTable.CurrentCell = additionalParametersTable[0, 0];
            }
            int rowIdx = additionalParametersTable.CurrentCell.RowIndex;
            if (rowIdx == 0)
            {
                MessageBox.Show(@"You can't remove first row because it is always connected with the current simulation.");
            }
            else
            {
                m_localInputParametersList.RemoveAt(rowIdx);
                additionalParametersTable.Rows.RemoveAt(rowIdx);
                UpdateDiagramAfterLocalParametersRowsChanged();
            }
        }

        private fmUnitsSchema m_currentUnitSchema;

        public fmUnitsSchema GetCurrentUnitsSchema()
        {
            return m_currentUnitSchema;
        }

        public void SetCurrentUnitsSchema(fmUnitsSchema unitsSchema)
        {
            m_currentUnitSchema = unitsSchema;
        }

        private void xLogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RecalculateSimulationsWithIterationX();
            BindCalculatedResultsToDisplayingResults();
            BindCalculatedResultsToChartAndTable();
        }

        private static class fmInterfaceAdjustingTags
        {
            public const string InterfaceAdjusting = "Interface_Adjusting";
            public const string SplitterSizes = "Splitter_Sizes";            
        }

        public void SerializeInterfaceAdjusting(XmlWriter writer)
        {
            writer.WriteStartElement(fmInterfaceAdjustingTags.InterfaceAdjusting);
            SerializeSplitters(writer);
            writer.WriteEndElement();
        }       

        public void SerializeSplitters(XmlWriter writer)
        {
            writer.WriteStartElement(fmInterfaceAdjustingTags.SplitterSizes);
            SerializeSplitter(writer, projectSuspensionSplitContainer);
            SerializeSplitter(writer, projectSuspensionSerieSplitContainer);
            SerializeSplitter(writer, mainSplitContainer);
            SerializeSplitter(writer, splitContainer1);
            SerializeSplitter(writer, splitter3);
            SerializeSplitter(writer, splitContainer2);
            SerializeSplitter(writer, XYSplitContainer);
            SerializeSplitter(writer, RightSplitContainer);
            SerializeSplitter(writer, SimulationAndGraphSplitContainer);
            writer.WriteEndElement();
        }

        private static void SerializeSplitter(XmlWriter writer, SplitContainer splitContainer)
        {
            writer.WriteElementString(splitContainer.Name, splitContainer.SplitterDistance.ToString());
        }

        private static void SerializeSplitter(XmlWriter writer, Splitter splitter)
        {
            writer.WriteElementString(splitter.Name, splitter.SplitPosition.ToString());
        }

        public void DeserializeInterfaceAdjusting(XmlNode node)
        {
            DeserializeSplitters(node.SelectSingleNode(fmInterfaceAdjustingTags.InterfaceAdjusting));
        }

        public void DeserializeSplitters(XmlNode node)
        {
            if (node != null)
            {
                node = node.SelectSingleNode(fmInterfaceAdjustingTags.SplitterSizes);
                if (node == null)
                {
                    return;
                }

                DeserializeSplitter(node, projectSuspensionSerieSplitContainer);
                DeserializeSplitter(node, projectSuspensionSplitContainer);
                DeserializeSplitter(node, mainSplitContainer);
                DeserializeSplitter(node, splitContainer1);
                DeserializeSplitter(node, splitter3);
                DeserializeSplitter(node, XYSplitContainer);
                DeserializeSplitter(node, splitContainer2);
                DeserializeSplitter(node, RightSplitContainer);
                DeserializeSplitter(node, SimulationAndGraphSplitContainer);
            }
        }

        private static void DeserializeSplitter(XmlNode node, SplitContainer splitContainer)
        {
            splitContainer.SplitterDistance = Convert.ToInt32(node.SelectSingleNode(splitContainer.Name).InnerText);
        }        
        private static void DeserializeSplitter(XmlNode node, Splitter splitter)
        {
            splitter.SplitPosition = Convert.ToInt32(node.SelectSingleNode(splitter.Name).InnerText);
        }

        #region Diagram Templates

        public const string DiagramTemplatesFilename = "diagrams.tpml";

        public static class DiagramTemplatesSavingTags
        {
            public const string DiagramTemplatesFile = "Diagram_Templates_File";
            public const string FiltrationCurves = "Filtration_Curves";
            public const string DeliqCurves = "Deliq_Curves";
            public const string MixedCurves = "Mixed_Curves";
            public const string CurveName = "CurveName";
            public const string RowsQuantity = "RowsQuantity";
            public const string MinMaxParameter = "MinMax_Parameter";
            public const string XParameterName = "XParameterName";
            public const string Y1ParametersNames = "Y1ParameterName";
            public const string Y2ParametersNames = "Y2ParameterName";
            public const string TempCurve = "TempCurve";
            public const string SerieName = "SerieName";
            public const string SerieCustomer = "SerieCustomer";
            public const string SerieMaterial = "SerieMaterial";
            public const string SerieCharge = "SerieCharge";
            public const string SerieProjectName = "SerieProjectName";
            public const string SerieFilterType = "SerieFilterType";
            public const string SerieFilterMedium = "SerieFilterMedium";
        }

        private DiagramTemplatesForm newDiagramTemplatesDialog = new DiagramTemplatesForm();
        
        private void btnLoadDiagramTemplatesButton_Click(object sender, EventArgs e)
        {
            string currentDiagramTemplateName = GetCurveTemplateName();
            SaveCurrentDiagraSettingsForCancelation();
            newDiagramTemplatesDialog.GetCurrentDiagramTemplateName(currentDiagramTemplateName);
            newDiagramTemplatesDialog.ShowDialog();
            if (newDiagramTemplatesDialog.DialogResult != DialogResult.OK)
                LoadParametersFromDiagramTemplate(DiagramTemplatesSavingTags.TempCurve);           
        }

        private void SaveCurrentDiagraSettingsForCancelation()
        {
            if (GetCurrentXAxisParameter() == null || listBoxYAxis.CheckedItems.Count == 0)
                return;
            if (System.IO.File.Exists(DiagramTemplatesFilename))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(DiagramTemplatesFilename);

                foreach (XmlNode xn in doc.GetElementsByTagName(DiagramTemplatesSavingTags.TempCurve))
                {
                    foreach (XmlNode name in xn.SelectNodes(DiagramTemplatesSavingTags.CurveName)) //deliting prev tmp
                        name.ParentNode.RemoveChild(name);
                        
                    XmlNode addNode = doc.CreateElement(DiagramTemplatesSavingTags.CurveName);
                    XmlAttribute xa = doc.CreateAttribute("id");
                    xa.Value = DiagramTemplatesSavingTags.TempCurve;
                    addNode.Attributes.Append(xa);
                    SaveXParameterName(addNode, doc);
                    SaveY1ParametersNames(addNode, doc);
                    SaveY2ParametersNames(addNode, doc);
                    SaveMinMaxValues(addNode, doc);
                    xn.AppendChild(addNode);
                }

                doc.Save(DiagramTemplatesFilename);
            }
            else
            {
                var xmlSettings = new XmlWriterSettings
                {
                    Indent = true
                };
                XmlWriter writer = XmlWriter.Create(DiagramTemplatesFilename, xmlSettings);
                writer.WriteStartDocument();
                writer.WriteStartElement(DiagramTemplatesSavingTags.DiagramTemplatesFile);
                SaveFiltrationCurvesTemplates(writer);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
                SaveCurrentDiagraSettingsForCancelation();
            }
        }
        
        private void btnSaveDiagramTemplatesButton_Click(object sender, EventArgs e)
        {
            SaveDiagramTemplate();
        }

        public void LoadParametersFromDiagramTemplate(string CurveName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(DiagramTemplatesFilename);
            foreach (XmlNode xn in doc.GetElementsByTagName(DiagramTemplatesSavingTags.CurveName ))
            {
                if (xn.Attributes["id"].Value == CurveName)
                {
                    DeserializeXParameter(xn);
                    DeserializeY1NodesForMenuOpen(xn);
                    DeserializeY2Nodes(xn);
                    LoadRowsQuantity(xn);
                    LoadTemplateMinMaxValuesOfTheXAxisParameter(xn);
                    break;
                }
            }
            doc.Save(DiagramTemplatesFilename);
        }

        protected void LoadTemplateMinMaxValuesOfTheXAxisParameter(XmlNode coreNode) //load min/max X values for serie with exact name, material, etc... 
        {
            if (coreNode == null)
            {
                return;
            }

            string SerieName;
            string SerieCustomer;
            string SerieMaterial;
            string SerieCharge;
            string SerieProjectName;
            string SerieFilterType;
            string SerieFilterMedium;

            fmFilterSimSerie serie;

            XmlNodeList SeriesParameters = coreNode.SelectNodes(DiagramTemplatesSavingTags.SerieName);

            foreach (XmlNode node in SeriesParameters)
            {
                foreach (DataGridViewRow row in InvolvedSeriesDataGrid.Rows)
                {
                    serie = m_involvedSerieFromRow[row];
                    SerieName = node.Attributes["id"].Value;

                    if (SerieName == serie.GetName())
                    {
                        SerieCustomer = node.SelectSingleNode(DiagramTemplatesSavingTags.SerieCustomer).InnerText;
                        SerieMaterial = node.SelectSingleNode(DiagramTemplatesSavingTags.SerieMaterial).InnerText;
                        SerieCharge = node.SelectSingleNode(DiagramTemplatesSavingTags.SerieCharge).InnerText;
                        SerieProjectName = node.SelectSingleNode(DiagramTemplatesSavingTags.SerieProjectName).InnerText;
                        SerieFilterType = node.SelectSingleNode(DiagramTemplatesSavingTags.SerieFilterType).InnerText;
                        SerieFilterMedium = node.SelectSingleNode(DiagramTemplatesSavingTags.SerieFilterMedium).InnerText;

                        if (SerieCharge == serie.Parent.GetName() && SerieCustomer == serie.Parent.Customer.ToString() && SerieMaterial == serie.Parent.Material.ToString() && SerieProjectName == serie.Parent.Parent.GetName() && SerieFilterType == serie.MachineType.name && SerieFilterMedium == serie.FilterMedium)
                        {

                            var tmpCell = InvolvedSeriesDataGrid.CurrentCell;
                            InvolvedSeriesDataGrid.CurrentCell = null;
                            
                            XmlNodeList MinMaxParameters = node.SelectNodes(fmFilterSimulationWithDiagramsSerializeTags.MinMaxParameter);
                            int column = 1;
                            foreach (XmlNode minmaxparameter in MinMaxParameters)
                            {
                                row.Cells[column].Value = minmaxparameter.InnerText.ToString();
                                InvolvedSeriesDataGrid.CurrentCell = row.Cells[column];
                                ++column;
                                
                                MinMaxXValueTextBoxTextChanged(null, new EventArgs());
                            }
                            InvolvedSeriesDataGrid.CurrentCell = tmpCell;
                        }
                    }
                }
            }
        }

        private void LoadRowsQuantity(XmlNode node)
        {
            fmSerializeTools.DeserializeIntProperty(ref m_rowsQuantity, node, DiagramTemplatesSavingTags.RowsQuantity);
            rowsQuantity.Text = m_rowsQuantity.ToString();
        }        

        private void SaveDiagramTemplate() //Saving diagrams settings to the separate file like templates
        {
            if (GetCurrentXAxisParameter() == null || listBoxYAxis.CheckedItems.Count == 0)
                return;
            if (System.IO.File.Exists(DiagramTemplatesFilename))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(DiagramTemplatesFilename);

                foreach (XmlNode xn in doc.GetElementsByTagName(GetKindOfCurrentCurveTemplate()))
                {
                    foreach (XmlNode name in xn.SelectNodes(DiagramTemplatesSavingTags.CurveName)) //deliting templates with same name
                        if (name.Attributes["id"].Value == GetCurveTemplateName())
                        {
                            DialogResult yndiagresult = MessageBox.Show("Curve template will be overwritten!", "Curve Template Saving Warning", MessageBoxButtons.OKCancel);
                            if (yndiagresult == DialogResult.OK)
                                name.ParentNode.RemoveChild(name);
                            else
                                return;
                        }                                                                           //end of deliting

                    XmlNode addNode = doc.CreateElement(DiagramTemplatesSavingTags.CurveName);
                    XmlAttribute xa = doc.CreateAttribute("id");
                    xa.Value = GetCurveTemplateName();
                    addNode.Attributes.Append(xa);
                    SaveRowsQuantity(addNode, doc);
                    SaveXParameterName(addNode, doc);
                    SaveY1ParametersNames(addNode, doc);
                    SaveY2ParametersNames(addNode, doc);
                    SaveMinMaxValues(addNode, doc);
                    xn.AppendChild(addNode);
                }
                
                doc.Save(DiagramTemplatesFilename);
            }
            else
            {
                var xmlSettings = new XmlWriterSettings
                {
                    Indent = true
                };
                XmlWriter writer = XmlWriter.Create(DiagramTemplatesFilename, xmlSettings);
                writer.WriteStartDocument();
                writer.WriteStartElement(DiagramTemplatesSavingTags.DiagramTemplatesFile);
                SaveFiltrationCurvesTemplates(writer);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
                SaveDiagramTemplate();
            }
        }

        private string GetKindOfCurrentCurveTemplate() //Filtration, Deliq or Mixed
        {
            int flag = 0;
            if (m_xyListKind[GetCurrentXAxisParameter().Name] == fmParameterKind.MachiningSettingsCakeFormation || m_xyListKind[GetCurrentXAxisParameter().Name] == fmParameterKind.MaterialCakeFormation)
            {
                foreach (ListViewItem item in listBoxYAxis.Items)
                {
                    if (item.Checked && m_xyListKind[item.Text] != fmParameterKind.MachiningSettingsCakeFormation && m_xyListKind[item.Text] != fmParameterKind.MaterialCakeFormation)
                        ++flag;
                }

                if (flag == 0)
                    return DiagramTemplatesSavingTags.FiltrationCurves;
                else
                    return DiagramTemplatesSavingTags.MixedCurves;
            }
            else
            {
                foreach (ListViewItem item in listBoxYAxis.Items)
                {
                    if (item.Checked && m_xyListKind[item.Text] != fmParameterKind.MachiningSettingsCakeFormation && m_xyListKind[item.Text] != fmParameterKind.MaterialCakeFormation)
                        ++flag;
                }

                if (flag == 0)
                    return DiagramTemplatesSavingTags.MixedCurves;
                else
                    return DiagramTemplatesSavingTags.DeliqCurves;
            }
        }

        private string GetCurveTemplateName()
        {
            string RightPart;
            string LeftPart;            

            fmGlobalParameter xParameter = GetCurrentXAxisParameter();
            RightPart = "f(" + xParameter.Name + ")";

            var color = m_xyListKind[xParameter.Name];

            LeftPart = "";
            foreach (ListViewItem item in listBoxYAxis.Items)
            {
                if (item.Checked)
                {
                   LeftPart = LeftPart + ", "+item.Text; 
                }
            }

            LeftPart = LeftPart.Remove(0, 2);
            return LeftPart+" = "+RightPart;

        }

        private void SaveFiltrationCurvesTemplates(XmlWriter writer)
        {
            writer.WriteStartElement(DiagramTemplatesSavingTags.FiltrationCurves);            
            writer.WriteEndElement();
            writer.WriteStartElement(DiagramTemplatesSavingTags.DeliqCurves );
            writer.WriteEndElement();
            writer.WriteStartElement(DiagramTemplatesSavingTags.MixedCurves);
            writer.WriteEndElement();
            writer.WriteStartElement(DiagramTemplatesSavingTags.TempCurve);
            writer.WriteEndElement();
        }

        private void SaveXParameterName(XmlNode node,XmlDocument doc)
        {
            fmGlobalParameter xParameter = GetCurrentXAxisParameter();
            XmlNode newNode = doc.CreateElement(DiagramTemplatesSavingTags.XParameterName);
            newNode.InnerText = xParameter.Name ;
            node.AppendChild(newNode);
        }

        private void SaveY1ParametersNames(XmlNode node, XmlDocument doc)
        {
            foreach (ListViewItem item in listBoxYAxis.Items)
            {
                if (item.Checked)
                {
                    XmlNode newNode = doc.CreateElement(DiagramTemplatesSavingTags.Y1ParametersNames);
                    newNode.InnerText = item.Text;
                    node.AppendChild(newNode);
                }
            }
        }

        private void SaveY2ParametersNames(XmlNode node, XmlDocument doc)
        {
            foreach (ListViewItem item in listBoxY2Axis.Items)
            {
                if (item.Checked)
                {
                    XmlNode newNode = doc.CreateElement(DiagramTemplatesSavingTags.Y2ParametersNames);
                    newNode.InnerText = item.Text;
                    node.AppendChild(newNode);
                }
            }
        }

        private void SaveRowsQuantity(XmlNode node, XmlDocument doc)
        {
            XmlNode newNode = doc.CreateElement(DiagramTemplatesSavingTags.RowsQuantity);
            newNode.InnerText = m_rowsQuantity.ToString();
            node.AppendChild(newNode);
        }

        private void SaveMinMaxValues(XmlNode node, XmlDocument doc)
        {   
            foreach (DataGridViewRow row in InvolvedSeriesDataGrid.Rows)
            {       
                fmFilterSimSerie serie = m_involvedSerieFromRow[row];
                XmlNode newNode3 = doc.CreateElement(DiagramTemplatesSavingTags.SerieName);

                XmlAttribute IdAtr = doc.CreateAttribute("id");
                IdAtr.Value = serie.GetName();
                newNode3.Attributes.Append(IdAtr);
                node.AppendChild(newNode3);

                XmlNode newNode = doc.CreateElement(DiagramTemplatesSavingTags.MinMaxParameter);
                newNode.InnerText = row.Cells[1].Value.ToString();
                newNode3.AppendChild(newNode);
                XmlNode newNode2 = doc.CreateElement(DiagramTemplatesSavingTags.MinMaxParameter);
                newNode2.InnerText = row.Cells[2].Value.ToString();
                newNode3.AppendChild(newNode2); 

                XmlNode newNode4 = doc.CreateElement(DiagramTemplatesSavingTags.SerieCharge);
                newNode4.InnerText = serie.Parent.GetName();
                newNode3.AppendChild(newNode4);

                XmlNode newNode5 = doc.CreateElement(DiagramTemplatesSavingTags.SerieCustomer);
                newNode5.InnerText = serie.Parent.Customer.ToString();
                newNode3.AppendChild(newNode5);

                XmlNode newNode6 = doc.CreateElement(DiagramTemplatesSavingTags.SerieMaterial);
                newNode6.InnerText = serie.Parent.Material.ToString();
                newNode3.AppendChild(newNode6);

                XmlNode newNode7 = doc.CreateElement(DiagramTemplatesSavingTags.SerieProjectName);
                newNode7.InnerText = serie.Parent.Parent.GetName();
                newNode3.AppendChild(newNode7);

                XmlNode newNode8 = doc.CreateElement(DiagramTemplatesSavingTags.SerieFilterType);
                newNode8.InnerText = serie.MachineType.name;
                newNode3.AppendChild(newNode8);

                XmlNode newNode9 = doc.CreateElement(DiagramTemplatesSavingTags.SerieFilterMedium);
                newNode9.InnerText = serie.FilterMedium;
                newNode3.AppendChild(newNode9);
            }

        }
        #endregion
    }
}