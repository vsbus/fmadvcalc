using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FilterSimulation;
using fmCalculationLibrary;
using FilterSimulation.fmFilterObjects;
using System.Xml;
using fmCalculationLibrary.MeasureUnits;

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

        public void Clear()
        {
            Solution = new fmFilterSimSolution();
            DisplaySolution(Solution);
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

        public void SetCurrentSerieRanges(fmRangesConfiguration ranges)
        {
            if (Solution.currentObjects.Serie != null)
            {
                Solution.currentObjects.Serie.Ranges = ranges;
            }
            foreach (KeyValuePair<fmGlobalParameter, fmDefaultParameterRange> range in ranges.Ranges)
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
            public const string YLogCheckBox = "YLogCheckBox";
            public const string Y2LogCheckBox = "Y2LogCheckBox";
            public const string UseParamsCheckBox = "UseParamsCheckBox";
        }

        override protected void SerializeDiagramOptions(XmlWriter writer)
        {
            writer.WriteStartElement(fmFilterSimulationWithDiagramsSerializeTags.DiagramOptions);
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.XParameterName, GetCurrentXAxisParameter().Name);
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
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.YLogCheckBox, yLogCheckBox.Checked.ToString());
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.Y2LogCheckBox, y2LogCheckBox.Checked.ToString());
            writer.WriteElementString(fmFilterSimulationWithDiagramsSerializeTags.UseParamsCheckBox, UseParamsCheckBox.Checked.ToString());
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

        override protected void DeserializeDiagramOptions(XmlNode node)
        {
            node = node.SelectSingleNode(fmFilterSimulationWithDiagramsSerializeTags.DiagramOptions);
            if (node == null)
            {
                return;
            }
            
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

            XmlNodeList y1Nodes = node.SelectNodes(fmFilterSimulationWithDiagramsSerializeTags.Y1ParameterName);
            if (y1Nodes != null)
                foreach (XmlNode y1Node in y1Nodes)
                {
                    listBoxYAxis.Items.Add(y1Node.InnerText).Checked = true;
                }

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
    }
}