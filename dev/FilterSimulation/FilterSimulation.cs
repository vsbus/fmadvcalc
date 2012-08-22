using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FilterSimulation.fmFilterObjects;
using FilterSimulation.fmFilterObjects.Interfaces;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;
using fmCalculatorsLibrary;
using System.Xml;
using fmControls;
using fmMisc;
using RangesDictionary = System.Collections.Generic.Dictionary<fmCalculationLibrary.fmGlobalParameter, fmCalculationLibrary.fmDefaultParameterRange>;

namespace FilterSimulation
{
    public partial class fmFilterSimulationControl : UserControl
    {
        protected fmFilterSimSolution Solution = new fmFilterSimSolution();
        private fmCalcBlocksLibrary.Blocks.fmFilterMachiningBlockWithLimits m_commonFilterMachiningBlock;
        private fmCalcBlocksLibrary.Blocks.fmDeliquoringSimualtionBlockWithLimits m_commonDeliquoringSimulationBlock;
        private CheckBox m_ckBox;
        protected fmParametersToDisplay ParametersToDisplay;
        public Dictionary<fmShowHideSchema, List<fmGlobalParameter>> ShowHideSchemas = new Dictionary<fmShowHideSchema, List<fmGlobalParameter>>();
        public Dictionary<fmFilterSimMachineType, RangesDictionary> RangesSchemas = new Dictionary<fmFilterSimMachineType, RangesDictionary>();
        private Dictionary<fmGlobalParameter, DataGridViewColumn> simulationGridColumns = new Dictionary<fmGlobalParameter, DataGridViewColumn>();

        public fmFilterSimulationControl()
        {
            InitializeComponent();

            InitializeSimulationGrid();
        }

        DataGridViewColumn AddSimulationGridColumn(fmGlobalParameter parameter)
        {
            var column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn
                                                   {
                                                       HeaderText = parameter.Name,
                                                       Name = "simulation_" + parameter.Name + "_Column",
                                                       SortMode = DataGridViewColumnSortMode.Automatic
                                                   };
            simulationGridColumns[parameter] = column;
            return column;
        }

        private void InitializeSimulationGrid()
        {
            simulationDataGrid.Columns.AddRange(new DataGridViewColumn[]
                                                    {
                                                        simulationGuidColumn,
                                                        simulationCheckedColumn,
                                                        simulationProjectColumn,
                                                        simulationSuspensionNameColumn,
                                                        simulationFilterMediumColumn,
                                                        simulationMachineTypeColumn,
                                                        simulationMachineNameColumn,
                                                        simulationSimSeriesNameColumn,
                                                        simulationNameColumn
                                                    });

            foreach (fmGlobalParameter parameter in fmGlobalParameter.GetMachineSettingsCakeParameters())
            {
                simulationDataGrid.Columns.Add(AddSimulationGridColumn(parameter));
            }

            foreach (fmGlobalParameter parameter in fmGlobalParameter.GetMachineSettingsDeliquoringParameters())
            {
                DataGridViewColumn column = AddSimulationGridColumn(parameter);
                column.ReadOnly = true;
                simulationDataGrid.Columns.Add(column);
            }
        }

        #region Serialization

        private static class fmFilterSimulationSerializeTags
        {
            public const string ShowHideSchemas = "ShowHideSchemas";
            public const string ShowHideSchema = "ShowHideSchema";
            public const string ShowHideSchemaName = "ShowHideSchemaName";
            public const string ShowHideParameter = "ShowHideParameter";

            public const string RangesSchemas = "RangesSchemas";
            public const string RangeSchema = "RangeSchema";
            public const string RangeSchemaName = "RangeSchemaName";
            public const string Range = "Range";
            public const string RangeParameterName = "RangeParameterName";
            public const string RangeMinValue = "RangeMinValue";
            public const string RangeMaxValue = "RangeMaxValue";
            public const string RangeIsInputed = "RangeIsInputed";
        }

        public void SerializeConfiguration(XmlWriter writer)
        {
            SerializeShowHideSchemas(writer);
            SerializeRangesSchemas(writer);
        }

        private void SerializeRangesSchemas(XmlWriter writer)
        {
            writer.WriteStartElement(fmFilterSimulationSerializeTags.RangesSchemas);
            foreach (KeyValuePair<fmFilterSimMachineType, RangesDictionary> rangeSchema in RangesSchemas)
            {
                writer.WriteStartElement(fmFilterSimulationSerializeTags.RangeSchema);
                writer.WriteElementString(fmFilterSimulationSerializeTags.RangeSchemaName, rangeSchema.Key.name);
                foreach (KeyValuePair<fmGlobalParameter, fmDefaultParameterRange> range in rangeSchema.Value)
                {
                    writer.WriteStartElement(fmFilterSimulationSerializeTags.Range);
                    writer.WriteElementString(fmFilterSimulationSerializeTags.RangeParameterName, range.Key.Name);
                    writer.WriteElementString(fmFilterSimulationSerializeTags.RangeMinValue, range.Value.MinValue.ToString());
                    writer.WriteElementString(fmFilterSimulationSerializeTags.RangeMaxValue, range.Value.MaxValue.ToString());
                    writer.WriteElementString(fmFilterSimulationSerializeTags.RangeIsInputed, range.Value.IsInputed.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        private void SerializeShowHideSchemas(XmlWriter writer)
        {
            writer.WriteStartElement(fmFilterSimulationSerializeTags.ShowHideSchemas);
            foreach (KeyValuePair<fmShowHideSchema, List<fmGlobalParameter>> showHideSchema in ShowHideSchemas)
            {
                writer.WriteStartElement(fmFilterSimulationSerializeTags.ShowHideSchema);
                writer.WriteElementString(fmFilterSimulationSerializeTags.ShowHideSchemaName, fmEnumUtils.GetEnumDescription(showHideSchema.Key));
                foreach (fmGlobalParameter parameter in showHideSchema.Value)
                {
                    writer.WriteElementString(fmFilterSimulationSerializeTags.ShowHideParameter, parameter.Name);
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public void DeserializeConfiguration(XmlNode node)
        {
            DeserializeShowHideSchemas(node);
            DeserializeRangesSchemas(node);
        }

        private void DeserializeRangesSchemas(XmlNode node)
        {
            node = node.SelectSingleNode(fmFilterSimulationSerializeTags.RangesSchemas);
            if (node == null)
                return;
            XmlNodeList schemasNodes = node.SelectNodes(fmFilterSimulationSerializeTags.RangeSchema);
            foreach (XmlNode schemaNode in schemasNodes)
            {
                string schemaName =
                    schemaNode.SelectSingleNode(fmFilterSimulationSerializeTags.RangeSchemaName).InnerText;
                var rangesDictionary = new RangesDictionary();
                XmlNodeList rangesList = schemaNode.SelectNodes(fmFilterSimulationSerializeTags.Range);
                foreach (XmlNode rangeNode in rangesList)
                {
                    XmlNode parameterNode = rangeNode.SelectSingleNode(fmFilterSimulationSerializeTags.RangeParameterName);
                    XmlNode minValueNode = rangeNode.SelectSingleNode(fmFilterSimulationSerializeTags.RangeMinValue);
                    XmlNode maxValueNode = rangeNode.SelectSingleNode(fmFilterSimulationSerializeTags.RangeMaxValue);
                    XmlNode IsInputedNode = rangeNode.SelectSingleNode(fmFilterSimulationSerializeTags.RangeIsInputed);
                    rangesDictionary.Add(fmGlobalParameter.ParametersByName[parameterNode.InnerText],
                                         new fmDefaultParameterRange(
                                             fmConvert.ToDouble(minValueNode.InnerText),
                                             fmConvert.ToDouble(maxValueNode.InnerText),
                                             Convert.ToBoolean(IsInputedNode.InnerText)));
                }
                RangesSchemas[fmFilterSimMachineType.GetFilterTypeByName(schemaName)] = rangesDictionary;
            }
        }

        private void DeserializeShowHideSchemas(XmlNode node)
        {
            node = node.SelectSingleNode(fmFilterSimulationSerializeTags.ShowHideSchemas);
            XmlNodeList schemasNodes = node.SelectNodes(fmFilterSimulationSerializeTags.ShowHideSchema);
            foreach (XmlNode schemaNode in schemasNodes)
            {
                string schemaName =
                    schemaNode.SelectSingleNode(fmFilterSimulationSerializeTags.ShowHideSchemaName).InnerText;
                var parametersList = new List<fmGlobalParameter>();
                XmlNodeList displayParamsList = schemaNode.SelectNodes(fmFilterSimulationSerializeTags.ShowHideParameter);
                foreach (XmlNode parameterNode in displayParamsList)
                {
                    parametersList.Add(fmGlobalParameter.ParametersByName[parameterNode.InnerText]);
                }
                ShowHideSchemas[(fmShowHideSchema)fmEnumUtils.GetEnum(typeof(fmShowHideSchema), schemaName)] = parametersList;
            }
        }

        #endregion

        private void SetUpToolTips()
        {
            toolTip.SetToolTip(projectCreateButton, "Create new project");
            toolTip.SetToolTip(projectRestoreButton, "Restore project");
            toolTip.SetToolTip(projectDeleteButton, "Delete project");

            toolTip.SetToolTip(suspensionCreateButton, "Create new suspension");
            toolTip.SetToolTip(suspensionRestoreButton, "Restore suspension");
            toolTip.SetToolTip(suspensionDeleteButton, "Delete suspension");

            toolTip.SetToolTip(simSeriesCreateButton, "Create new serie");
            toolTip.SetToolTip(simSeriesRestoreButton, "Restore serie");
            toolTip.SetToolTip(simSeriesDeleteButton, "Delete serie");
            toolTip.SetToolTip(simSeriesDuplicateButton, "Duplicate serie");

            toolTip.SetToolTip(simulationCreateButton, "Create new simulation");
            toolTip.SetToolTip(simulationDuplicateButton, "Duplicate simulation");
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
            CreateDeliquoringMaterialParametersTable();
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

            var fProj = new fmFilterSimProject(Solution, "Prj1");
            var fProj2 = new fmFilterSimProject(Solution, "Prj2");
            var fSus = new fmFilterSimSuspension(fProj, "Susp1", "Mat1", "Cust1");
            var fSus2 = new fmFilterSimSuspension(fProj2, "Susp2", "Mat2", "Cust2");
            new fmFilterSimSuspension(fProj, "Susp3", "Mat3", "Cust3");
            var fSimSerie = new fmFilterSimSerie(fSus, "serie0", fmFilterSimMachineType.VacuumNutche, "medium1", "machine0");
            new fmFilterSimSerie(fSus2, "serie02", fmFilterSimMachineType.BeltFilter, "medium2", "machine9");
            var sim = new fmFilterSimulation(fSimSerie, "sim01");

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

            sim.Parameters[fmGlobalParameter.hce0].value = new fmValue(5 * fmUnitFamily.LengthFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.hce0]).isInputed = true;

            sim.Parameters[fmGlobalParameter.Cm].value = new fmValue(20 * fmUnitFamily.ConcentrationFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.Cm]).isInputed = true;

            sim.Parameters[fmGlobalParameter.A].value = new fmValue(1 * fmUnitFamily.AreaFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.A]).isInputed = true;

            sim.Parameters[fmGlobalParameter.d0].value = new fmValue();
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.d0]).isInputed = true;

            sim.Parameters[fmGlobalParameter.Dp].value = new fmValue(1 * fmUnitFamily.PressureFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.Dp]).isInputed = true;

            sim.Parameters[fmGlobalParameter.tr].value = new fmValue(10 * fmUnitFamily.TimeFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.tr]).isInputed = true;
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.sf]).isInputed = false;

            sim.Parameters[fmGlobalParameter.n].value = new fmValue(1 * fmUnitFamily.FrequencyFamily.CurrentUnit.Coef);
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.n]).isInputed = true;
            ((fmCalculationVariableParameter)sim.Parameters[fmGlobalParameter.hc]).isInputed = false;

            // END DEBUG CODE

            fProj.Keep();
            fProj2.Keep();

            CreateDefaultListOfParametersForDisplaying();

            DisplaySolution(Solution);

            projectDataGrid.CurrentCell = projectDataGrid.Rows[0].Cells[projectNameColumn.Index];

            UpdateCurrentObjectAndDisplaySolution(projectDataGrid);

            InitializeHeaderCheckBox();

            LimitsCalculationOnOff();
        }

        private void CreateDeliquoringMaterialParametersTable()
        {
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { null, null });   // for simulation Guid
            deliquoringMaterialParametersDataGrid.Rows[0].Visible = false;

            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.Dp_d.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.hcd.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.eps_d.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.eta_d.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.rho_d.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.sigma.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.pke0.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.pke.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.pc_d.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.rc_d.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.alpha_d.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.Srem.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.ad1.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.ad2.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.Tetta.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.eta_g.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.ag1.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.ag2.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.ag3.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.Tetta_boil.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.DH.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.Mmole.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.f.Name, "" });
            deliquoringMaterialParametersDataGrid.Rows.Add(new object[] { fmGlobalParameter.peq.Name, "" });
        }

        private void CreateDefaultListOfParametersForDisplaying()
        {
            ParametersToDisplay = new fmParametersToDisplay(fmShowHideSchema.ContinuousFilters,
                                                            new[]
                                                                {
                                                                    fmGlobalParameter.A,
                                                                    fmGlobalParameter.d0,
                                                                    fmGlobalParameter.Dp,
                                                                    fmGlobalParameter.sf,
                                                                    fmGlobalParameter.sr,
                                                                    fmGlobalParameter.n,
                                                                    fmGlobalParameter.tc,
                                                                    fmGlobalParameter.tf,
                                                                    fmGlobalParameter.tr,
                                                                    fmGlobalParameter.hc,
                                                                    fmGlobalParameter.Qf,
                                                                    fmGlobalParameter.Qs,
                                                                    fmGlobalParameter.Qc,
                                                                    fmGlobalParameter.Qsus,
                                                                    fmGlobalParameter.Qmsus,
                                                                    fmGlobalParameter.Qms,
                                                                    fmGlobalParameter.Qmf,
                                                                    fmGlobalParameter.Qmc,
                                                                    fmGlobalParameter.qf,
                                                                    fmGlobalParameter.qs,
                                                                    fmGlobalParameter.qc,
                                                                    fmGlobalParameter.qsus,
                                                                    fmGlobalParameter.qmsus,
                                                                    fmGlobalParameter.qms,
                                                                    fmGlobalParameter.qmf,
                                                                    fmGlobalParameter.qmc,
                                                                    fmGlobalParameter.Vsus,
                                                                    fmGlobalParameter.Mf,
                                                                    fmGlobalParameter.Vf,
                                                                    fmGlobalParameter.Vc,
                                                                    fmGlobalParameter.Mc,
                                                                    fmGlobalParameter.Ms,
                                                                    fmGlobalParameter.Vs,
                                                                    fmGlobalParameter.Msus,
                                                                    fmGlobalParameter.Qp,
                                                                    fmGlobalParameter.qp,
                                                                    fmGlobalParameter.t1,
                                                                    fmGlobalParameter.h1,
                                                                    fmGlobalParameter.t1_over_tf,
                                                                    fmGlobalParameter.h1_over_hc,

                                                                    fmGlobalParameter.Dp_d,
                                                                    fmGlobalParameter.hcd,
                                                                    fmGlobalParameter.eps_d,
                                                                    fmGlobalParameter.eta_d,
                                                                    fmGlobalParameter.rho_d,
                                                                    fmGlobalParameter.sigma,
                                                                    fmGlobalParameter.pke0,
                                                                    fmGlobalParameter.pke,
                                                                    fmGlobalParameter.pc_d,
                                                                    fmGlobalParameter.rc_d,
                                                                    fmGlobalParameter.alpha_d,
                                                                    fmGlobalParameter.Srem,
                                                                    fmGlobalParameter.ad1,
                                                                    fmGlobalParameter.ad2,
                                                                    fmGlobalParameter.Tetta,
                                                                    fmGlobalParameter.eta_g,
                                                                    fmGlobalParameter.ag1,
                                                                    fmGlobalParameter.ag2,
                                                                    fmGlobalParameter.ag3,
                                                                    fmGlobalParameter.Tetta_boil,
                                                                    fmGlobalParameter.DH,
                                                                    fmGlobalParameter.Mmole,
                                                                    fmGlobalParameter.f,
                                                                    fmGlobalParameter.peq,

                                                                    fmGlobalParameter.sd,
                                                                    fmGlobalParameter.td,
                                                                    fmGlobalParameter.K,
                                                                    fmGlobalParameter.S,
                                                                    fmGlobalParameter.Rf,
                                                                    fmGlobalParameter.Mev,
                                                                    fmGlobalParameter.Mf,
                                                                    fmGlobalParameter.Mc,
                                                                    fmGlobalParameter.Mlcd,
                                                                    fmGlobalParameter.rho_bulk,
                                                                    fmGlobalParameter.Qgi,
                                                                    fmGlobalParameter.Qg,
                                                                    fmGlobalParameter.vg,
                                                                    fmGlobalParameter.Qmf,
                                                                    fmGlobalParameter.Qmc,
                                                                    fmGlobalParameter.qmf,
                                                                    fmGlobalParameter.qmc
                                                                });
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
                displayingSolution = true;

                Solution.currentObjects.Project = null;

                Solution.currentColumns.project = projectNameColumn.Index;
                Solution.currentColumns.suspension = suspensionNameColumn.Index;
                Solution.currentColumns.simSerie = simSeriesNameColumn.Index;
                Solution.currentColumns.simulation = simulationNameColumn.Index;

                if (dgv == projectDataGrid)
                {
                    if (projectDataGrid.CurrentCell == null
                        || projectDataGrid.CurrentRow.Cells[projectGuidColumn.Index].Value == null)
                    {
                        m_displayingTables = false;
                        displayingSolution = false;
                        return;
                    }

                    var projectGuid = (Guid)projectDataGrid.CurrentRow.Cells[projectGuidColumn.Index].Value;
                    Solution.currentColumns.project = projectDataGrid.Columns[projectDataGrid.CurrentCell.ColumnIndex].Index;

                    Solution.currentObjects.Project = Solution.FindProject(projectGuid);
                }
                else if (dgv == suspensionDataGrid)
                {
                    if (suspensionDataGrid.CurrentCell == null
                        || suspensionDataGrid.CurrentRow.Cells[suspensionGuidColumn.Index].Value == null)
                    {
                        m_displayingTables = false;
                        displayingSolution = false;
                        return;
                    }

                    var suspensionGuid = (Guid)suspensionDataGrid.CurrentRow.Cells[suspensionGuidColumn.Index].Value;
                    Solution.currentColumns.suspension = suspensionDataGrid.Columns[suspensionDataGrid.CurrentCell.ColumnIndex].Index;
                    Solution.currentObjects.Suspension = Solution.FindSuspension(suspensionGuid);
                }
                else if (dgv == simSeriesDataGrid)
                {
                    if (simSeriesDataGrid.CurrentCell == null
                        || simSeriesDataGrid.CurrentRow.Cells[simSeriesGuidColumn.Index].Value == null)
                    {
                        m_displayingTables = false;
                        displayingSolution = false;
                        return;
                    }

                    var simSeriesGuid = (Guid)simSeriesDataGrid.CurrentRow.Cells[simSeriesGuidColumn.Index].Value;
                    Solution.currentColumns.simSerie = simSeriesDataGrid.Columns[simSeriesDataGrid.CurrentCell.ColumnIndex].Index;
                    Solution.currentObjects.Serie = Solution.FindSerie(simSeriesGuid);
                }
                else if (dgv == simulationDataGrid)
                {
                    if (simulationDataGrid.CurrentCell == null
                        || simulationDataGrid.CurrentRow.Cells[simulationGuidColumn.Index].Value == null)
                    {
                        m_displayingTables = false;
                        displayingSolution = false;
                        return;
                    }

                    var simulationGuid = (Guid)simulationDataGrid.CurrentRow.Cells[simulationGuidColumn.Index].Value;
                    Solution.currentColumns.simulation = simulationDataGrid.Columns[simulationDataGrid.CurrentCell.ColumnIndex].Index;
                    Solution.currentObjects.Simulation = Solution.FindSimulation(simulationGuid);
                }

                displayingSolution = false;

                DisplaySolution(Solution);

                m_displayingTables = false;
            }
        }


        public void SaveAll()
        {
            Solution.Keep();
            DisplaySolution(Solution);
        }

        private void SimulationDataGridSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            var dg = sender as fmDataGrid.fmDataGrid;
            // ReSharper disable InconsistentNaming
            if (dg != null)
            {
                fmValue DpColumn = fmValue.StringToValue(dg.Rows[e.RowIndex1].Cells[simulationGridColumns[fmGlobalParameter.Dp].Index].Value.ToString());
                fmValue DpColumn_2 = fmValue.StringToValue(dg.Rows[e.RowIndex2].Cells[simulationGridColumns[fmGlobalParameter.Dp].Index].Value.ToString());
                fmValue hcColumn = fmValue.StringToValue(dg.Rows[e.RowIndex1].Cells[simulationGridColumns[fmGlobalParameter.hc].Index].Value.ToString());
                fmValue hcColumn_2 = fmValue.StringToValue(dg.Rows[e.RowIndex2].Cells[simulationGridColumns[fmGlobalParameter.hc].Index].Value.ToString());
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
            DisplaySolution(Solution);
        }

        // ReSharper disable InconsistentNaming
        private void simulationCreateButton_Click(object sender, EventArgs e)
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

            string simName;
            for (int i = 1; ; ++i)
            {
                simName = parentSerie.GetName() + "-" + i;
                if (Solution.FindSimulation(simName) == null)
                {
                    break;
                }
            }

            if (Solution.currentObjects.Simulation == null)
            {
                Solution.currentObjects.Simulation = new fmFilterSimulation(parentSerie, simName);
            }
            else
            {
                fmFilterSimulation currentSimulation = Solution.currentObjects.Simulation;
                Solution.currentObjects.Simulation = new fmFilterSimulation(currentSimulation.Parent, simName);
                Solution.currentObjects.Simulation.CopySuspensionParameters(currentSimulation);
                Solution.currentObjects.Simulation.Keep();
            }

            Solution.currentColumns.simulation = simulationNameColumn.Index;
            DisplaySolution(Solution);
            SortTables();
            SelectCurrentItemsInSolution(Solution);

            simulationDataGrid.BeginEdit(true);
        }

        // ReSharper disable InconsistentNaming
        private void calculationOptionChangeButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            if (Solution.currentObjects.Simulation == null)
            {
                MessageBox.Show(@"Please select a simulation to get Calculation Option dialog.");
                return;
            }

            var cosd = new fmCalculationOptionSelectionDialog
                           {
                               suspensionCalculationOption =
                                   Solution.currentObjects.Simulation.Data.suspensionCalculationOption,
                               filterMachiningCalculationOption =
                                   Solution.currentObjects.Simulation.Data.filterMachiningCalculationOption,
                               deliquoringUsedCalculationOption = 
                                   Solution.currentObjects.Simulation.Data.deliquoringUsedCalculationOption,
                               gasFlowrateUsedCalculationOption = 
                                   Solution.currentObjects.Simulation.Data.gasFlowrateUsedCalculationOption,
                               evaporationUsedCalculationOption =
                                   Solution.currentObjects.Simulation.Data.evaporationUsedCalculationOption,
                               hcdEpsdCalculationOption =
                                   Solution.currentObjects.Simulation.Data.hcdEpsdCalculationOption,
                               dpdInputCalculationOption =
                                   Solution.currentObjects.Simulation.Data.dpdInputCalculationOption,
                               rhoDCalculationOption = 
                                   Solution.currentObjects.Simulation.Data.rhoDCalculationOption,
                               PcDCalculationOption =
                                   Solution.currentObjects.Simulation.Data.PcDCalculationOption
                            };
            if (cosd.ShowDialog() == DialogResult.OK)
            {
                Solution.currentObjects.Simulation.susBlock.SetCalculationOptionAndRewrite(cosd.suspensionCalculationOption);
                Solution.currentObjects.Simulation.filterMachiningBlock.SetCalculationOptionAndRewriteData(cosd.filterMachiningCalculationOption);
                Solution.currentObjects.Simulation.filterMachiningBlock.SetCalculationOptionAndRewriteData(cosd.deliquoringUsedCalculationOption);
                Solution.currentObjects.Simulation.filterMachiningBlock.SetCalculationOptionAndRewriteData(cosd.gasFlowrateUsedCalculationOption);
                Solution.currentObjects.Simulation.filterMachiningBlock.SetCalculationOptionAndRewriteData(cosd.evaporationUsedCalculationOption);
                Solution.currentObjects.Simulation.deliquoringEps0NeEpsBlock.SetCalculationOptionAndRewrite(cosd.hcdEpsdCalculationOption);
                Solution.currentObjects.Simulation.deliquoringEps0NeEpsBlock.SetCalculationOptionAndRewrite(cosd.dpdInputCalculationOption);
                Solution.currentObjects.Simulation.deliquoringSigmaPkeBlock.SetCalculationOptionAndRewrite(cosd.rhoDCalculationOption);
                Solution.currentObjects.Simulation.deliquoringSigmaPkeBlock.SetCalculationOptionAndRewrite(cosd.PcDCalculationOption);
                DisplaySolution(Solution);
            }
        }

        private void CalculateLimitsCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            LimitsCalculationOnOff();
        }

        private void LimitsCalculationOnOff()
        {
            m_commonFilterMachiningBlock.IsLimitsDisplaying = calculateLimitsCheckBox.Checked;
            m_commonDeliquoringSimulationBlock.IsLimitsDisplaying = calculateLimitsCheckBox.Checked;
            commonCalcBlockMinLocalColumn.Visible = calculateLimitsCheckBox.Checked;
            commonCalcBlockMaxLocalColumn.Visible = calculateLimitsCheckBox.Checked;
            commonCalcBlockDataGrid.Width = calculateLimitsCheckBox.Checked ? 273 : 173;
            commonDeliquoringSimulationBlockMinColumn.Visible = calculateLimitsCheckBox.Checked;
            commonDeliquoringSimulationBlockMaxColumn.Visible = calculateLimitsCheckBox.Checked;
            commonDeliquoringSimulationBlockDataGrid.Width = calculateLimitsCheckBox.Checked ? 268 : 168;
            m_commonFilterMachiningBlock.CalculateAndDisplay();
        }

        private void SelectMachineButtonClick(object sender, EventArgs e)
        {
            var dialog = new MachineTypeSelectionDialog();
            dialog.AssignSerie(Solution.currentObjects.Serie);
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.OK)
            {
                Solution.currentObjects.Serie.MachineType = dialog.GetSelectedType();
                DisplaySolution(Solution);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RunCommentsWindow(Solution.currentObjects.Project, "Project");
        }

        private void RunCommentsWindow(IComments item, string itemIdName)
        {
            if (item == null)
            {
                MessageBox.Show("Impossible to open comments window when no " + itemIdName + " selected.");
                return;
            }

            var commentWindow = new CommentsWindow();
            commentWindow.SetCommentedObjectName(itemIdName + " " + item.GetName());
            commentWindow.SetCommentText(item.GetComments());
            if (commentWindow.ShowDialog() == DialogResult.OK)
            {
                item.SetComments(commentWindow.GetCommentText());
            }

            DisplaySolution(Solution);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RunCommentsWindow(Solution.currentObjects.Suspension, "Suspension");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunCommentsWindow(Solution.currentObjects.Serie, "Serie");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RunCommentsWindow(Solution.currentObjects.Simulation, "Simulation");
        }
    }
}