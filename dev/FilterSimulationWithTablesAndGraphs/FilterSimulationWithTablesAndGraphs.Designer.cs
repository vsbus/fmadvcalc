using fmZedGraph;
using System.Windows.Forms;

namespace FilterSimulationWithTablesAndGraphs
{
    partial class fmFilterSimulationWithTablesAndGraphs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmFilterSimulationWithTablesAndGraphs));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.xRangeLabel = new System.Windows.Forms.Label();
            this.fmZedGraphControl1 = new fmZedGraph.fmZedGraphControl();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.UseParamsCheckBox = new System.Windows.Forms.CheckBox();
            this.coordinatesGrid = new fmDataGrid.fmDataGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.rowsQuantity = new fmDataGrid.fmNumericalTextBox();
            this.selectedSimulationParametersTable = new fmDataGrid.fmDataGrid();
            this.SelectedSimulationParametersCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GridPanel = new System.Windows.Forms.Panel();
            this.additionalParametersTable = new fmDataGrid.fmDataGrid();
            this.AdditionalParametersCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ParamsControlsPanel4 = new System.Windows.Forms.Panel();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLoadDiagramTemplatesButton = new System.Windows.Forms.Button();
            this.btnSaveDiagramTemplatesButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tablesAndGraphsTopLeftPanel = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.XYSplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxXAxis = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxYAxis = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxY2Axis = new System.Windows.Forms.ListView();
            this.panel11 = new System.Windows.Forms.Panel();
            this.xLogCheckBox = new System.Windows.Forms.CheckBox();
            this.y2LogCheckBox = new System.Windows.Forms.CheckBox();
            this.yLogCheckBox = new System.Windows.Forms.CheckBox();
            this.LoadDefaultRangle = new System.Windows.Forms.Button();
            this.InvolvedSeriesDataGrid = new fmDataGrid.fmDataGrid();
            this.SerieColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.ToValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.startFromOriginCheckBox = new System.Windows.Forms.CheckBox();
            this.NoScalingCheckBox = new System.Windows.Forms.CheckBox();
            this.deliquoringMachininglParametersCheckBox = new System.Windows.Forms.CheckBox();
            this.deselectAllButton = new System.Windows.Forms.Button();
            this.cakeFormationMaterilParametersCheckBox = new System.Windows.Forms.CheckBox();
            this.deliquoringMaterilParametersCheckBox = new System.Windows.Forms.CheckBox();
            this.cakeFormationMachininglParametersCheckBox = new System.Windows.Forms.CheckBox();
            this.splitter11 = new System.Windows.Forms.Splitter();
            this.splitter6 = new System.Windows.Forms.Splitter();
            this.panel8 = new System.Windows.Forms.Panel();
            this.RightSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SimulationAndGraphSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panelLeft.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.projectPanel.SuspendLayout();
            this.suspensionPanel.SuspendLayout();
            this.machinePanel.SuspendLayout();
            this.secondFromTopPanel.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.simSeriesPanel.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.projectSuspensionSerieSplitContainer.Panel1.SuspendLayout();
            this.projectSuspensionSerieSplitContainer.Panel2.SuspendLayout();
            this.projectSuspensionSerieSplitContainer.SuspendLayout();
            this.projectSuspensionSplitContainer.Panel1.SuspendLayout();
            this.projectSuspensionSplitContainer.Panel2.SuspendLayout();
            this.projectSuspensionSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coordinatesGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSimulationParametersTable)).BeginInit();
            this.GridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.additionalParametersTable)).BeginInit();
            this.ParamsControlsPanel4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tablesAndGraphsTopLeftPanel.SuspendLayout();
            this.panel10.SuspendLayout();
            this.XYSplitContainer.Panel1.SuspendLayout();
            this.XYSplitContainer.Panel2.SuspendLayout();
            this.XYSplitContainer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InvolvedSeriesDataGrid)).BeginInit();
            this.panel8.SuspendLayout();
            this.RightSplitContainer.Panel1.SuspendLayout();
            this.RightSplitContainer.Panel2.SuspendLayout();
            this.RightSplitContainer.SuspendLayout();
            this.SimulationAndGraphSplitContainer.Panel1.SuspendLayout();
            this.SimulationAndGraphSplitContainer.Panel2.SuspendLayout();
            this.SimulationAndGraphSplitContainer.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // projectCreateButton
            // 
            this.projectCreateButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.projectCreateButton, "Project_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.projectCreateButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.projectCreateButton, true);
            this.toolTip.SetToolTip(this.projectCreateButton, "Create new project");
            // 
            // suspensionCreateButton
            // 
            this.suspensionCreateButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.suspensionCreateButton, "Suspension_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.suspensionCreateButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.suspensionCreateButton, true);
            this.toolTip.SetToolTip(this.suspensionCreateButton, "Create new suspension");
            // 
            // simSeriesCreateButton
            // 
            this.simSeriesCreateButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.simSeriesCreateButton, "Series_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.simSeriesCreateButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.simSeriesCreateButton, true);
            this.toolTip.SetToolTip(this.simSeriesCreateButton, "Create new serie");
            // 
            // projectRestoreButton
            // 
            this.projectRestoreButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.projectRestoreButton, "Project_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.projectRestoreButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.projectRestoreButton, true);
            this.toolTip.SetToolTip(this.projectRestoreButton, "Restore project");
            // 
            // projectDeleteButton
            // 
            this.projectDeleteButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.projectDeleteButton, "Project_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.projectDeleteButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.projectDeleteButton, true);
            this.toolTip.SetToolTip(this.projectDeleteButton, "Delete project");
            // 
            // suspensionRestoreButton
            // 
            this.suspensionRestoreButton.FlatAppearance.BorderSize = 0;
            this.suspensionRestoreButton.Location = new System.Drawing.Point(105, 0);
			this.helpProvider1.SetHelpKeyword(this.suspensionRestoreButton, "Suspension_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.suspensionRestoreButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.suspensionRestoreButton, true);
            this.toolTip.SetToolTip(this.suspensionRestoreButton, "Restore suspension");
            // 
            // suspensionDeleteButton
            // 
            this.suspensionDeleteButton.FlatAppearance.BorderSize = 0;
            this.suspensionDeleteButton.Location = new System.Drawing.Point(125, 0);
			this.helpProvider1.SetHelpKeyword(this.suspensionDeleteButton, "Suspension_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.suspensionDeleteButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.suspensionDeleteButton, true);
            this.toolTip.SetToolTip(this.suspensionDeleteButton, "Delete suspension");
            // 
            // simSeriesRestoreButton
            // 
            this.simSeriesRestoreButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.simSeriesRestoreButton, "Series_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.simSeriesRestoreButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.simSeriesRestoreButton, true);
            this.toolTip.SetToolTip(this.simSeriesRestoreButton, "Restore serie");
            // 
            // simSeriesDeleteButton
            // 
            this.simSeriesDeleteButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.simSeriesDeleteButton, "Series_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.simSeriesDeleteButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.simSeriesDeleteButton, true);
            this.toolTip.SetToolTip(this.simSeriesDeleteButton, "Delete serie");
            // 
            // simulationDuplicateButton
            // 
            this.simulationDuplicateButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.simulationDuplicateButton, "Simulations_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.simulationDuplicateButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.simulationDuplicateButton, true);
            this.toolTip.SetToolTip(this.simulationDuplicateButton, "Duplicate externalSimulation");
            // 
            // simulationRestoreButton
            // 
            this.simulationRestoreButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.simulationRestoreButton, "Simulations_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.simulationRestoreButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.simulationRestoreButton, true);
            this.toolTip.SetToolTip(this.simulationRestoreButton, "Restore externalSimulation");
            // 
            // simulationDeleteButton
            // 
            this.simulationDeleteButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.simulationDeleteButton, "Simulations_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.simulationDeleteButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.simulationDeleteButton, true);
            this.toolTip.SetToolTip(this.simulationDeleteButton, "Delete externalSimulation");
            // 
            // byCheckingProjectsCheckBox
            // 
            this.helpProvider1.SetHelpKeyword(this.byCheckingProjectsCheckBox, "Project_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.byCheckingProjectsCheckBox, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.byCheckingProjectsCheckBox, true);
            // 
            // byCheckingSuspensionsCheckBox
            // 
            this.helpProvider1.SetHelpKeyword(this.byCheckingSuspensionsCheckBox, "Suspension_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.byCheckingSuspensionsCheckBox, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.byCheckingSuspensionsCheckBox, true);
            // 
            // byCheckingSimSeriesCheckBox
            // 
            this.helpProvider1.SetHelpKeyword(this.byCheckingSimSeriesCheckBox, "Series_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.byCheckingSimSeriesCheckBox, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.byCheckingSimSeriesCheckBox, true);
            // 
            // byCheckingSimulationsCheckBox
            // 
            this.helpProvider1.SetHelpKeyword(this.byCheckingSimulationsCheckBox, "Simulations_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.byCheckingSimulationsCheckBox, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.byCheckingSimulationsCheckBox, true);
            // 
            // fullSimulationInfoCheckBox
            // 
            this.helpProvider1.SetHelpKeyword(this.fullSimulationInfoCheckBox, "Simulations_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.fullSimulationInfoCheckBox, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.fullSimulationInfoCheckBox, true);
            // 
            // panelLeft
            // 
            this.panelLeft.Size = new System.Drawing.Size(822, 266);
            // 
            // topPanel
            // 
            this.topPanel.Size = new System.Drawing.Size(822, 115);
            // 
            // projectPanel
            // 
            this.helpProvider1.SetHelpKeyword(this.projectPanel, "Project_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.projectPanel, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.projectPanel, true);
            this.projectPanel.Size = new System.Drawing.Size(170, 115);
            // 
            // suspensionPanel
            // 
            this.helpProvider1.SetHelpKeyword(this.suspensionPanel, "Suspension_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.suspensionPanel, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.suspensionPanel, true);
            this.suspensionPanel.Size = new System.Drawing.Size(192, 115);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Size = new System.Drawing.Size(3, 115);
            // 
            // machinePanel
            // 
            this.machinePanel.Size = new System.Drawing.Size(449, 115);
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(0, 115);
            this.splitter3.Size = new System.Drawing.Size(822, 3);
            // 
            // secondFromTopPanel
            // 
            this.secondFromTopPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.secondFromTopPanel.Controls.Add(this.splitter11);
            this.secondFromTopPanel.Location = new System.Drawing.Point(0, 118);
            this.secondFromTopPanel.Size = new System.Drawing.Size(822, 148);
            this.secondFromTopPanel.Controls.SetChildIndex(this.simSeriesPanel, 0);
            this.secondFromTopPanel.Controls.SetChildIndex(this.splitter11, 0);
            // 
            // simSeriesDuplicateButton
            // 
            this.simSeriesDuplicateButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.simSeriesDuplicateButton, "Series_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.simSeriesDuplicateButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.simSeriesDuplicateButton, true);
            this.toolTip.SetToolTip(this.simSeriesDuplicateButton, "Duplicate serie");
            // 
            // meterialInputSerieRadioButton
            // 
            this.helpProvider1.SetHelpKeyword(this.meterialInputSerieRadioButton, "General_Material_Parameters.htm");
            this.helpProvider1.SetHelpNavigator(this.meterialInputSerieRadioButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.meterialInputSerieRadioButton, true);
            // 
            // meterialInputSimualationRadioButton
            // 
            this.helpProvider1.SetHelpKeyword(this.meterialInputSimualationRadioButton, "General_Material_Parameters.htm");
            this.helpProvider1.SetHelpNavigator(this.meterialInputSimualationRadioButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.meterialInputSimualationRadioButton, true);
            // 
            // meterialInputSuspensionRadioButton
            // 
            this.helpProvider1.SetHelpKeyword(this.meterialInputSuspensionRadioButton, "General_Material_Parameters.htm");
            this.helpProvider1.SetHelpNavigator(this.meterialInputSuspensionRadioButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.meterialInputSuspensionRadioButton, true);
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(822, 266);
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(822, 731);
            // 
            // panel1
            // 
            this.helpProvider1.SetHelpKeyword(this.panel1, "Project_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.panel1, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(166, 20);
            // 
            // panel2
            // 
            this.helpProvider1.SetHelpKeyword(this.panel2, "Suspension_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.panel2, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.panel2, true);
            this.panel2.Size = new System.Drawing.Size(188, 20);
            // 
            // panel3
            // 
            this.helpProvider1.SetHelpKeyword(this.panel3, "Series_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.panel3, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.panel3, true);
            this.panel3.Size = new System.Drawing.Size(445, 20);
            // 
            // panel5
            // 
            this.helpProvider1.SetHelpKeyword(this.panel5, "Simulations_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.panel5, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.panel5, true);
            this.panel5.Size = new System.Drawing.Size(818, 20);
            // 
            // simulationCreateButton
            // 
            this.simulationCreateButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.simulationCreateButton, "Simulations_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.simulationCreateButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.simulationCreateButton, true);
            this.toolTip.SetToolTip(this.simulationCreateButton, "Create new externalSimulation");
            // 
            // simSeriesPanel
            // 
            this.simSeriesPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.simSeriesPanel.Size = new System.Drawing.Size(822, 148);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Size = new System.Drawing.Size(822, 731);
            this.splitContainer1.SplitterDistance = 266;
            // 
            // mainSplitContainer
            // 
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.panel8);
            this.mainSplitContainer.Panel2Collapsed = false;
            this.mainSplitContainer.Size = new System.Drawing.Size(1480, 731);
            this.mainSplitContainer.SplitterDistance = 822;
            // 
            // projectSuspensionSerieSplitContainer
            // 
            this.projectSuspensionSerieSplitContainer.Location = new System.Drawing.Point(3, 0);
            this.projectSuspensionSerieSplitContainer.Size = new System.Drawing.Size(819, 115);
            this.projectSuspensionSerieSplitContainer.SplitterDistance = 366;
            // 
            // projectSuspensionSplitContainer
            // 
            this.projectSuspensionSplitContainer.Size = new System.Drawing.Size(366, 115);
            this.projectSuspensionSplitContainer.SplitterDistance = 170;
            // 
            // commentSimulationButton
            // 
            this.commentSimulationButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.commentSimulationButton, "Simulations_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.commentSimulationButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.commentSimulationButton, true);
            // 
            // commentProjectButton
            // 
            this.commentProjectButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.commentProjectButton, "Project_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.commentProjectButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.commentProjectButton, true);
            // 
            // commentSuspensionButton
            // 
            this.commentSuspensionButton.FlatAppearance.BorderSize = 0;
            this.commentSuspensionButton.Location = new System.Drawing.Point(145, 0);
			this.helpProvider1.SetHelpKeyword(this.commentSuspensionButton, "Suspension_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.commentSuspensionButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.commentSuspensionButton, true);
            // 
            // commentSerieButton
            // 
            this.commentSerieButton.FlatAppearance.BorderSize = 0;
            this.helpProvider1.SetHelpKeyword(this.commentSerieButton, "Series_Table.htm");
            this.helpProvider1.SetHelpNavigator(this.commentSerieButton, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetShowHelp(this.commentSerieButton, true);
            // 
            // xRangeLabel
            // 
            this.xRangeLabel.AutoSize = true;
            this.xRangeLabel.Location = new System.Drawing.Point(10, 102);
            this.xRangeLabel.Name = "xRangeLabel";
            this.xRangeLabel.Size = new System.Drawing.Size(44, 13);
            this.xRangeLabel.TabIndex = 2;
            this.xRangeLabel.Text = "Ranges";
            // 
            // fmZedGraphControl1
            // 
            this.fmZedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpProvider1.SetHelpKeyword(this.fmZedGraphControl1, "Diagram.htm");
            this.helpProvider1.SetHelpNavigator(this.fmZedGraphControl1, System.Windows.Forms.HelpNavigator.Topic);
            this.fmZedGraphControl1.IsAntiAlias = true;
            this.fmZedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.fmZedGraphControl1.Name = "fmZedGraphControl1";
            this.fmZedGraphControl1.ScrollGrace = 0;
            this.fmZedGraphControl1.ScrollMaxX = 0;
            this.fmZedGraphControl1.ScrollMaxY = 0;
            this.fmZedGraphControl1.ScrollMaxY2 = 0;
            this.fmZedGraphControl1.ScrollMinX = 0;
            this.fmZedGraphControl1.ScrollMinY = 0;
            this.fmZedGraphControl1.ScrollMinY2 = 0;
            this.helpProvider1.SetShowHelp(this.fmZedGraphControl1, true);
            this.fmZedGraphControl1.Size = new System.Drawing.Size(654, 373);
            this.fmZedGraphControl1.TabIndex = 4;
            this.fmZedGraphControl1.HighLightedPointsChanged += new fmZedGraph.HighlightPointsEventHandler(this.fmZedGraphControl1_HighLightedPointsChanged);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAddRow.FlatAppearance.BorderSize = 0;
            this.buttonAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpKeyword(this.buttonAddRow, "Table_belonging_to_the_Diagram.htm");
            this.helpProvider1.SetHelpNavigator(this.buttonAddRow, System.Windows.Forms.HelpNavigator.Topic);
            this.buttonAddRow.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddRow.Image")));
            this.buttonAddRow.Location = new System.Drawing.Point(125, 0);
            this.buttonAddRow.Name = "buttonAddRow";
            this.helpProvider1.SetShowHelp(this.buttonAddRow, true);
            this.buttonAddRow.Size = new System.Drawing.Size(20, 21);
            this.buttonAddRow.TabIndex = 8;
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // UseParamsCheckBox
            // 
            this.UseParamsCheckBox.AutoSize = true;
            this.UseParamsCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.helpProvider1.SetHelpKeyword(this.UseParamsCheckBox, "Table_belonging_to_the_Diagram.htm");
            this.helpProvider1.SetHelpNavigator(this.UseParamsCheckBox, System.Windows.Forms.HelpNavigator.Topic);
            this.UseParamsCheckBox.Location = new System.Drawing.Point(0, 0);
            this.UseParamsCheckBox.Name = "UseParamsCheckBox";
            this.helpProvider1.SetShowHelp(this.UseParamsCheckBox, true);
            this.UseParamsCheckBox.Size = new System.Drawing.Size(125, 21);
            this.UseParamsCheckBox.TabIndex = 9;
            this.UseParamsCheckBox.Text = "Multiple Curves for Current Simulation";
            this.UseParamsCheckBox.UseVisualStyleBackColor = true;
            this.UseParamsCheckBox.CheckedChanged += new System.EventHandler(this.UseParamsCheckBox_CheckedChanged);
            // 
            // coordinatesGrid
            // 
            this.coordinatesGrid.AllowUserToAddRows = false;
            this.coordinatesGrid.AllowUserToDeleteRows = false;
            this.coordinatesGrid.AllowUserToResizeRows = false;
            this.coordinatesGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.coordinatesGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.coordinatesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.coordinatesGrid.ContextMenuStrip = this.contextMenuStrip1;
            this.coordinatesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coordinatesGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.helpProvider1.SetHelpKeyword(this.coordinatesGrid, "Table_belonging_to_the_Diagram.htm");
            this.helpProvider1.SetHelpNavigator(this.coordinatesGrid, System.Windows.Forms.HelpNavigator.Topic);
            this.coordinatesGrid.HighLightCurrentRow = true;
            this.coordinatesGrid.Location = new System.Drawing.Point(0, 0);
            this.coordinatesGrid.Name = "coordinatesGrid";
            this.coordinatesGrid.RowHeadersVisible = false;
            this.coordinatesGrid.RowHeadersWidth = 15;
            this.coordinatesGrid.RowTemplate.Height = 18;
            this.helpProvider1.SetShowHelp(this.coordinatesGrid, true);
            this.coordinatesGrid.Size = new System.Drawing.Size(654, 179);
            this.coordinatesGrid.TabIndex = 0;
            this.coordinatesGrid.CurrentCellChanged += new System.EventHandler(this.coordinatesGrid_CurrentCellChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItemClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Desired amount of values:";
            // 
            // rowsQuantity
            // 
            this.rowsQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.rowsQuantity.ForeColor = System.Drawing.Color.Red;
            this.rowsQuantity.Location = new System.Drawing.Point(141, 198);
            this.rowsQuantity.Name = "rowsQuantity";
            this.rowsQuantity.Size = new System.Drawing.Size(50, 20);
            this.rowsQuantity.TabIndex = 2;
            this.rowsQuantity.TextChanged += new System.EventHandler(this.rowsQuantity_TextChanged);
            // 
            // selectedSimulationParametersTable
            // 
            this.selectedSimulationParametersTable.AllowUserToAddRows = false;
            this.selectedSimulationParametersTable.AllowUserToDeleteRows = false;
            this.selectedSimulationParametersTable.AllowUserToResizeRows = false;
            this.selectedSimulationParametersTable.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.selectedSimulationParametersTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectedSimulationParametersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectedSimulationParametersTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectedSimulationParametersCheckBoxColumn});
            this.selectedSimulationParametersTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedSimulationParametersTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.helpProvider1.SetHelpKeyword(this.selectedSimulationParametersTable, "Table_belonging_to_the_Diagram.htm");
            this.helpProvider1.SetHelpNavigator(this.selectedSimulationParametersTable, System.Windows.Forms.HelpNavigator.Topic);
            this.selectedSimulationParametersTable.HighLightCurrentRow = true;
            this.selectedSimulationParametersTable.Location = new System.Drawing.Point(0, 57);
            this.selectedSimulationParametersTable.Name = "selectedSimulationParametersTable";
            this.selectedSimulationParametersTable.RowHeadersVisible = false;
            this.selectedSimulationParametersTable.RowTemplate.Height = 18;
            this.helpProvider1.SetShowHelp(this.selectedSimulationParametersTable, true);
            this.selectedSimulationParametersTable.Size = new System.Drawing.Size(646, 106);
            this.selectedSimulationParametersTable.TabIndex = 10;
            this.selectedSimulationParametersTable.Visible = false;
            this.selectedSimulationParametersTable.CurrentCellChanged += new System.EventHandler(this.ParametersTable_CurrentCellChanged);
            this.selectedSimulationParametersTable.CellValueChangedByUser += new System.Windows.Forms.DataGridViewCellEventHandler(this.selectedSimulationParametersTable_CellValueChangedByUser);
            // 
            // SelectedSimulationParametersCheckBoxColumn
            // 
            this.SelectedSimulationParametersCheckBoxColumn.HeaderText = "";
            this.SelectedSimulationParametersCheckBoxColumn.Name = "SelectedSimulationParametersCheckBoxColumn";
            this.SelectedSimulationParametersCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SelectedSimulationParametersCheckBoxColumn.Width = 20;
            // 
            // GridPanel
            // 
            this.GridPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridPanel.Controls.Add(this.selectedSimulationParametersTable);
            this.GridPanel.Controls.Add(this.additionalParametersTable);
            this.GridPanel.Controls.Add(this.ParamsControlsPanel4);
            this.GridPanel.Controls.Add(this.panel4);
            this.GridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridPanel.Location = new System.Drawing.Point(0, 0);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(650, 167);
            this.GridPanel.TabIndex = 10;
            // 
            // additionalParametersTable
            // 
            this.additionalParametersTable.AllowUserToAddRows = false;
            this.additionalParametersTable.AllowUserToOrderColumns = true;
            this.additionalParametersTable.AllowUserToResizeRows = false;
            this.additionalParametersTable.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.additionalParametersTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.additionalParametersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.additionalParametersTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AdditionalParametersCheckBoxColumn});
            this.additionalParametersTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.additionalParametersTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.helpProvider1.SetHelpKeyword(this.additionalParametersTable, "Table_belonging_to_the_Diagram.htm");
            this.helpProvider1.SetHelpNavigator(this.additionalParametersTable, System.Windows.Forms.HelpNavigator.Topic);
            this.additionalParametersTable.HighLightCurrentRow = true;
            this.additionalParametersTable.Location = new System.Drawing.Point(0, 57);
            this.additionalParametersTable.Name = "additionalParametersTable";
            this.additionalParametersTable.RowHeadersVisible = false;
            this.additionalParametersTable.RowTemplate.Height = 18;
            this.helpProvider1.SetShowHelp(this.additionalParametersTable, true);
            this.additionalParametersTable.Size = new System.Drawing.Size(646, 106);
            this.additionalParametersTable.TabIndex = 5;
            this.additionalParametersTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.additionalParametersTable_CellContentClick);
            this.additionalParametersTable.CurrentCellChanged += new System.EventHandler(this.ParametersTable_CurrentCellChanged);
            this.additionalParametersTable.CellValueChangedByUser += new System.Windows.Forms.DataGridViewCellEventHandler(this.additionalParametersTable_CellValueChangedByUser);
            // 
            // AdditionalParametersCheckBoxColumn
            // 
            this.AdditionalParametersCheckBoxColumn.HeaderText = "";
            this.AdditionalParametersCheckBoxColumn.IndeterminateValue = "";
            this.AdditionalParametersCheckBoxColumn.Name = "AdditionalParametersCheckBoxColumn";
            this.AdditionalParametersCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AdditionalParametersCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AdditionalParametersCheckBoxColumn.Width = 20;
            // 
            // ParamsControlsPanel4
            // 
            this.ParamsControlsPanel4.Controls.Add(this.buttonDeleteRow);
            this.ParamsControlsPanel4.Controls.Add(this.buttonAddRow);
            this.ParamsControlsPanel4.Controls.Add(this.UseParamsCheckBox);
            this.ParamsControlsPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.ParamsControlsPanel4.Location = new System.Drawing.Point(0, 36);
            this.ParamsControlsPanel4.Name = "ParamsControlsPanel4";
            this.ParamsControlsPanel4.Size = new System.Drawing.Size(646, 21);
            this.ParamsControlsPanel4.TabIndex = 11;
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonDeleteRow.FlatAppearance.BorderSize = 0;
            this.buttonDeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpKeyword(this.buttonDeleteRow, "Table_belonging_to_the_Diagram.htm");
            this.helpProvider1.SetHelpNavigator(this.buttonDeleteRow, System.Windows.Forms.HelpNavigator.Topic);
            this.buttonDeleteRow.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteRow.Image")));
            this.buttonDeleteRow.Location = new System.Drawing.Point(145, 0);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.helpProvider1.SetShowHelp(this.buttonDeleteRow, true);
            this.buttonDeleteRow.Size = new System.Drawing.Size(20, 21);
            this.buttonDeleteRow.TabIndex = 10;
            this.buttonDeleteRow.UseVisualStyleBackColor = true;
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
			this.panel4.Controls.Add(this.btnLoadDiagramTemplatesButton);
            this.panel4.Controls.Add(this.btnSaveDiagramTemplatesButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(646, 36);
            this.panel4.TabIndex = 12;
            this.panel4.Controls.SetChildIndex(this.btnSaveDiagramTemplatesButton, 0);
            this.panel4.Controls.SetChildIndex(this.btnLoadDiagramTemplatesButton, 0);
            // 
            // btnLoadDiagramTemplatesButton
            // 
            this.btnLoadDiagramTemplatesButton.Location = new System.Drawing.Point(135, 3);
            this.btnLoadDiagramTemplatesButton.Name = "btnLoadDiagramTemplatesButton";
            this.btnLoadDiagramTemplatesButton.Size = new System.Drawing.Size(121, 23);
            this.btnLoadDiagramTemplatesButton.TabIndex = 13;
            this.btnLoadDiagramTemplatesButton.Text = "Load Templates";
            this.btnLoadDiagramTemplatesButton.UseVisualStyleBackColor = true;
            this.btnLoadDiagramTemplatesButton.Click += new System.EventHandler(this.btnLoadDiagramTemplatesButton_Click);
            // 
            // btnSaveDiagramTemplatesButton
            // 
            this.btnSaveDiagramTemplatesButton.Location = new System.Drawing.Point(266, 3);
            this.btnSaveDiagramTemplatesButton.Name = "btnSaveDiagramTemplatesButton";
            this.btnSaveDiagramTemplatesButton.Size = new System.Drawing.Size(121, 23);
            this.btnSaveDiagramTemplatesButton.TabIndex = 14;
            this.btnSaveDiagramTemplatesButton.Text = "Save Templates";
            this.btnSaveDiagramTemplatesButton.UseVisualStyleBackColor = true;
            this.btnSaveDiagramTemplatesButton.Click += new System.EventHandler(this.btnSaveDiagramTemplatesButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Configure Diagram";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // tablesAndGraphsTopLeftPanel
            // 
            this.tablesAndGraphsTopLeftPanel.Controls.Add(this.panel10);
            this.tablesAndGraphsTopLeftPanel.Location = new System.Drawing.Point(18, 3);
            this.tablesAndGraphsTopLeftPanel.Name = "tablesAndGraphsTopLeftPanel";
            this.tablesAndGraphsTopLeftPanel.Size = new System.Drawing.Size(556, 327);
            this.tablesAndGraphsTopLeftPanel.TabIndex = 7;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.XYSplitContainer);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(556, 327);
            this.panel10.TabIndex = 9;
            // 
            // XYSplitContainer
            // 
            this.XYSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XYSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.XYSplitContainer.Name = "XYSplitContainer";
            // 
            // XYSplitContainer.Panel1
            // 
            this.XYSplitContainer.Panel1.Controls.Add(this.groupBox2);
            // 
            // XYSplitContainer.Panel2
            // 
            this.XYSplitContainer.Panel2.Controls.Add(this.splitContainer2);
            this.XYSplitContainer.Panel2.Controls.Add(this.panel11);
            this.XYSplitContainer.Size = new System.Drawing.Size(556, 327);
            this.XYSplitContainer.SplitterDistance = 182;
            this.XYSplitContainer.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxXAxis);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 327);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "X Axis Parameter";
            // 
            // listBoxXAxis
            // 
            this.listBoxXAxis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listBoxXAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxXAxis.FullRowSelect = true;
            this.listBoxXAxis.HideSelection = false;
            this.listBoxXAxis.Location = new System.Drawing.Point(3, 16);
            this.listBoxXAxis.MultiSelect = false;
            this.listBoxXAxis.Name = "listBoxXAxis";
            this.listBoxXAxis.Size = new System.Drawing.Size(176, 308);
            this.listBoxXAxis.TabIndex = 6;
            this.listBoxXAxis.UseCompatibleStateImageBehavior = false;
            this.listBoxXAxis.View = System.Windows.Forms.View.Details;
            this.listBoxXAxis.SelectedIndexChanged += new System.EventHandler(this.ListBoxXSelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "X Parameter";
            this.columnHeader1.Width = 80;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 220);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(370, 107);
            this.splitContainer2.SplitterDistance = 251;
            this.splitContainer2.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxYAxis);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 107);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Y Axis Parameters";
            // 
            // listBoxYAxis
            // 
            this.listBoxYAxis.CheckBoxes = true;
            this.listBoxYAxis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listBoxYAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup2";
            this.listBoxYAxis.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listBoxYAxis.Location = new System.Drawing.Point(3, 16);
            this.listBoxYAxis.Name = "listBoxYAxis";
            this.listBoxYAxis.Size = new System.Drawing.Size(245, 88);
            this.listBoxYAxis.TabIndex = 6;
            this.listBoxYAxis.UseCompatibleStateImageBehavior = false;
            this.listBoxYAxis.View = System.Windows.Forms.View.List;
            this.listBoxYAxis.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListBoxYAxisItemCheck);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Y Parameter";
            this.columnHeader2.Width = 164;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxY2Axis);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(115, 107);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Y2 Axis Parameters";
            // 
            // listBoxY2Axis
            // 
            this.listBoxY2Axis.CheckBoxes = true;
            this.listBoxY2Axis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxY2Axis.Location = new System.Drawing.Point(3, 16);
            this.listBoxY2Axis.Name = "listBoxY2Axis";
            this.listBoxY2Axis.Size = new System.Drawing.Size(109, 88);
            this.listBoxY2Axis.TabIndex = 7;
            this.listBoxY2Axis.UseCompatibleStateImageBehavior = false;
            this.listBoxY2Axis.View = System.Windows.Forms.View.List;
            this.listBoxY2Axis.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListBoxY2AxisItemCheck);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.xLogCheckBox);
            this.panel11.Controls.Add(this.y2LogCheckBox);
            this.panel11.Controls.Add(this.yLogCheckBox);
            this.panel11.Controls.Add(this.LoadDefaultRangle);
            this.panel11.Controls.Add(this.InvolvedSeriesDataGrid);
            this.panel11.Controls.Add(this.startFromOriginCheckBox);
            this.panel11.Controls.Add(this.NoScalingCheckBox);
            this.panel11.Controls.Add(this.deliquoringMachininglParametersCheckBox);
            this.panel11.Controls.Add(this.deselectAllButton);
            this.panel11.Controls.Add(this.cakeFormationMaterilParametersCheckBox);
            this.panel11.Controls.Add(this.deliquoringMaterilParametersCheckBox);
            this.panel11.Controls.Add(this.xRangeLabel);
            this.panel11.Controls.Add(this.cakeFormationMachininglParametersCheckBox);
            this.panel11.Controls.Add(this.label1);
            this.panel11.Controls.Add(this.rowsQuantity);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(370, 220);
            this.panel11.TabIndex = 8;
            // 
            // xLogCheckBox
            // 
            this.xLogCheckBox.AutoSize = true;
            this.xLogCheckBox.Location = new System.Drawing.Point(255, 52);
            this.xLogCheckBox.Name = "xLogCheckBox";
            this.xLogCheckBox.Size = new System.Drawing.Size(90, 17);
            this.xLogCheckBox.TabIndex = 12;
            this.xLogCheckBox.Text = "X Logarithmic";
            this.xLogCheckBox.UseVisualStyleBackColor = true;
            this.xLogCheckBox.CheckedChanged += new System.EventHandler(this.xLogCheckBox_CheckedChanged);
            // 
            // y2LogCheckBox
            // 
            this.y2LogCheckBox.AutoSize = true;
            this.y2LogCheckBox.Location = new System.Drawing.Point(255, 98);
            this.y2LogCheckBox.Name = "y2LogCheckBox";
            this.y2LogCheckBox.Size = new System.Drawing.Size(96, 17);
            this.y2LogCheckBox.TabIndex = 11;
            this.y2LogCheckBox.Text = "Y2 Logarithmic";
            this.y2LogCheckBox.UseVisualStyleBackColor = true;
            this.y2LogCheckBox.CheckedChanged += new System.EventHandler(this.Y2LogCheckBoxCheckedChanged);
            // 
            // yLogCheckBox
            // 
            this.yLogCheckBox.AutoSize = true;
            this.yLogCheckBox.Location = new System.Drawing.Point(255, 75);
            this.yLogCheckBox.Name = "yLogCheckBox";
            this.yLogCheckBox.Size = new System.Drawing.Size(90, 17);
            this.yLogCheckBox.TabIndex = 10;
            this.yLogCheckBox.Text = "Y Logarithmic";
            this.yLogCheckBox.UseVisualStyleBackColor = true;
            this.yLogCheckBox.CheckedChanged += new System.EventHandler(this.YLogCheckBoxCheckedChanged);
            // 
            // LoadDefaultRangle
            // 
            this.LoadDefaultRangle.Location = new System.Drawing.Point(197, 118);
            this.LoadDefaultRangle.Name = "LoadDefaultRangle";
            this.LoadDefaultRangle.Size = new System.Drawing.Size(75, 36);
            this.LoadDefaultRangle.TabIndex = 9;
            this.LoadDefaultRangle.Text = "Load Default";
            this.LoadDefaultRangle.UseVisualStyleBackColor = true;
            this.LoadDefaultRangle.Click += new System.EventHandler(this.LoadDefaultRangle_Click);
            // 
            // InvolvedSeriesDataGrid
            // 
            this.InvolvedSeriesDataGrid.AllowUserToAddRows = false;
            this.InvolvedSeriesDataGrid.AllowUserToDeleteRows = false;
            this.InvolvedSeriesDataGrid.AllowUserToResizeRows = false;
            this.InvolvedSeriesDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InvolvedSeriesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InvolvedSeriesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerieColumn,
            this.FromValueColumn,
            this.ToValueColumn});
            this.InvolvedSeriesDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.InvolvedSeriesDataGrid.HighLightCurrentRow = false;
            this.InvolvedSeriesDataGrid.Location = new System.Drawing.Point(13, 118);
            this.InvolvedSeriesDataGrid.Name = "InvolvedSeriesDataGrid";
            this.InvolvedSeriesDataGrid.RowHeadersVisible = false;
            this.InvolvedSeriesDataGrid.RowTemplate.Height = 18;
            this.InvolvedSeriesDataGrid.Size = new System.Drawing.Size(178, 76);
            this.InvolvedSeriesDataGrid.TabIndex = 8;
            this.InvolvedSeriesDataGrid.CellValueChangedByUser += new System.Windows.Forms.DataGridViewCellEventHandler(this.InvolvedSeriesDataGrid_CellValueChangedByUser);
            // 
            // SerieColumn
            // 
            this.SerieColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SerieColumn.HeaderText = "Serie";
            this.SerieColumn.Name = "SerieColumn";
            this.SerieColumn.ReadOnly = true;
            this.SerieColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FromValueColumn
            // 
            this.FromValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FromValueColumn.FillWeight = 50F;
            this.FromValueColumn.HeaderText = "From";
            this.FromValueColumn.Name = "FromValueColumn";
            // 
            // ToValueColumn
            // 
            this.ToValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ToValueColumn.FillWeight = 50F;
            this.ToValueColumn.HeaderText = "To";
            this.ToValueColumn.Name = "ToValueColumn";
            // 
            // startFromOriginCheckBox
            // 
            this.startFromOriginCheckBox.AutoSize = true;
            this.startFromOriginCheckBox.Location = new System.Drawing.Point(255, 29);
            this.startFromOriginCheckBox.Name = "startFromOriginCheckBox";
            this.startFromOriginCheckBox.Size = new System.Drawing.Size(67, 17);
            this.startFromOriginCheckBox.TabIndex = 7;
            this.startFromOriginCheckBox.Text = "Ymin = 0";
            this.startFromOriginCheckBox.UseVisualStyleBackColor = true;
            this.startFromOriginCheckBox.CheckedChanged += new System.EventHandler(this.StartFromOriginCheckBoxCheckedChanged);
            // 
            // NoScalingCheckBox
            // 
            this.NoScalingCheckBox.AutoSize = true;
            this.NoScalingCheckBox.Location = new System.Drawing.Point(255, 6);
            this.NoScalingCheckBox.Name = "NoScalingCheckBox";
            this.NoScalingCheckBox.Size = new System.Drawing.Size(78, 17);
            this.NoScalingCheckBox.TabIndex = 6;
            this.NoScalingCheckBox.Text = "No Scaling";
            this.NoScalingCheckBox.UseVisualStyleBackColor = true;
            this.NoScalingCheckBox.CheckedChanged += new System.EventHandler(this.NoScalingCheckBoxCheckedChanged);
            // 
            // deliquoringMachininglParametersCheckBox
            // 
            this.deliquoringMachininglParametersCheckBox.AutoSize = true;
            this.deliquoringMachininglParametersCheckBox.Location = new System.Drawing.Point(13, 75);
            this.deliquoringMachininglParametersCheckBox.Name = "deliquoringMachininglParametersCheckBox";
            this.deliquoringMachininglParametersCheckBox.Size = new System.Drawing.Size(171, 17);
            this.deliquoringMachininglParametersCheckBox.TabIndex = 3;
            this.deliquoringMachininglParametersCheckBox.Text = "Deliquoring Setting Parameters";
            this.deliquoringMachininglParametersCheckBox.UseVisualStyleBackColor = true;
            this.deliquoringMachininglParametersCheckBox.CheckedChanged += new System.EventHandler(this.DeliquoringMachininglParametersCheckBoxCheckedChanged);
            // 
            // deselectAllButton
            // 
            this.deselectAllButton.Location = new System.Drawing.Point(276, 192);
            this.deselectAllButton.Name = "deselectAllButton";
            this.deselectAllButton.Size = new System.Drawing.Size(91, 22);
            this.deselectAllButton.TabIndex = 4;
            this.deselectAllButton.Text = "Deselect All";
            this.deselectAllButton.UseVisualStyleBackColor = true;
            this.deselectAllButton.Click += new System.EventHandler(this.DeselectAllButtonClick);
            // 
            // cakeFormationMaterilParametersCheckBox
            // 
            this.cakeFormationMaterilParametersCheckBox.AutoSize = true;
            this.cakeFormationMaterilParametersCheckBox.Location = new System.Drawing.Point(13, 6);
            this.cakeFormationMaterilParametersCheckBox.Name = "cakeFormationMaterilParametersCheckBox";
            this.cakeFormationMaterilParametersCheckBox.Size = new System.Drawing.Size(196, 17);
            this.cakeFormationMaterilParametersCheckBox.TabIndex = 0;
            this.cakeFormationMaterilParametersCheckBox.Text = "Cake Formation Material Parameters";
            this.cakeFormationMaterilParametersCheckBox.UseVisualStyleBackColor = true;
            this.cakeFormationMaterilParametersCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
            // 
            // deliquoringMaterilParametersCheckBox
            // 
            this.deliquoringMaterilParametersCheckBox.AutoSize = true;
            this.deliquoringMaterilParametersCheckBox.Location = new System.Drawing.Point(13, 52);
            this.deliquoringMaterilParametersCheckBox.Name = "deliquoringMaterilParametersCheckBox";
            this.deliquoringMaterilParametersCheckBox.Size = new System.Drawing.Size(175, 17);
            this.deliquoringMaterilParametersCheckBox.TabIndex = 1;
            this.deliquoringMaterilParametersCheckBox.Text = "Deliquoring Material Parameters";
            this.deliquoringMaterilParametersCheckBox.UseVisualStyleBackColor = true;
            this.deliquoringMaterilParametersCheckBox.CheckedChanged += new System.EventHandler(this.DeliquoringMaterilParametersCheckBoxCheckedChanged);
            // 
            // cakeFormationMachininglParametersCheckBox
            // 
            this.cakeFormationMachininglParametersCheckBox.AutoSize = true;
            this.cakeFormationMachininglParametersCheckBox.Checked = true;
            this.cakeFormationMachininglParametersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cakeFormationMachininglParametersCheckBox.Location = new System.Drawing.Point(13, 29);
            this.cakeFormationMachininglParametersCheckBox.Name = "cakeFormationMachininglParametersCheckBox";
            this.cakeFormationMachininglParametersCheckBox.Size = new System.Drawing.Size(192, 17);
            this.cakeFormationMachininglParametersCheckBox.TabIndex = 2;
            this.cakeFormationMachininglParametersCheckBox.Text = "Cake Formation Setting Parameters";
            this.cakeFormationMachininglParametersCheckBox.UseVisualStyleBackColor = true;
            this.cakeFormationMachininglParametersCheckBox.CheckedChanged += new System.EventHandler(this.CakeFormationMachininglParametersCheckBoxCheckedChanged);
            // 
            // splitter11
            // 
            this.splitter11.Location = new System.Drawing.Point(0, 0);
            this.splitter11.Name = "splitter11";
            this.splitter11.Size = new System.Drawing.Size(3, 148);
            this.splitter11.TabIndex = 9;
            this.splitter11.TabStop = false;
            // 
            // splitter6
            // 
            this.splitter6.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter6.Location = new System.Drawing.Point(0, 364);
            this.splitter6.Name = "splitter6";
            this.splitter6.Size = new System.Drawing.Size(472, 3);
            this.splitter6.TabIndex = 16;
            this.splitter6.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.RightSplitContainer);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(654, 731);
            this.panel8.TabIndex = 36;
            // 
            // RightSplitContainer
            // 
            this.RightSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.RightSplitContainer.Name = "RightSplitContainer";
            this.RightSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // RightSplitContainer.Panel1
            // 
            this.RightSplitContainer.Panel1.Controls.Add(this.SimulationAndGraphSplitContainer);
            // 
            // RightSplitContainer.Panel2
            // 
            this.RightSplitContainer.Panel2.Controls.Add(this.panel9);
            this.RightSplitContainer.Size = new System.Drawing.Size(654, 731);
            this.RightSplitContainer.SplitterDistance = 556;
            this.RightSplitContainer.TabIndex = 1;
            // 
            // SimulationAndGraphSplitContainer
            // 
            this.SimulationAndGraphSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SimulationAndGraphSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SimulationAndGraphSplitContainer.Name = "SimulationAndGraphSplitContainer";
            this.SimulationAndGraphSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SimulationAndGraphSplitContainer.Panel1
            // 
            this.SimulationAndGraphSplitContainer.Panel1.Controls.Add(this.tablesAndGraphsTopLeftPanel);
            this.SimulationAndGraphSplitContainer.Panel1.Controls.Add(this.fmZedGraphControl1);
            // 
            // SimulationAndGraphSplitContainer.Panel2
            // 
            this.SimulationAndGraphSplitContainer.Panel2.Controls.Add(this.coordinatesGrid);
            this.SimulationAndGraphSplitContainer.Size = new System.Drawing.Size(654, 556);
            this.SimulationAndGraphSplitContainer.SplitterDistance = 373;
            this.SimulationAndGraphSplitContainer.TabIndex = 12;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.GridPanel);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(654, 171);
            this.panel9.TabIndex = 11;
            // 
            // fmFilterSimulationWithTablesAndGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.helpProvider1.SetHelpKeyword(this, "MainWindow.htm");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            this.Name = "fmFilterSimulationWithTablesAndGraphs";
            this.helpProvider1.SetShowHelp(this, true);
            this.Size = new System.Drawing.Size(1480, 731);
            this.Load += new System.EventHandler(this.FmFilterSimulationWithTablesAndGraphsLoad);
            this.Controls.SetChildIndex(this.mainSplitContainer, 0);
            this.panelLeft.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.projectPanel.ResumeLayout(false);
            this.suspensionPanel.ResumeLayout(false);
            this.machinePanel.ResumeLayout(false);
            this.secondFromTopPanel.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.simSeriesPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.ResumeLayout(false);
            this.projectSuspensionSerieSplitContainer.Panel1.ResumeLayout(false);
            this.projectSuspensionSerieSplitContainer.Panel2.ResumeLayout(false);
            this.projectSuspensionSerieSplitContainer.ResumeLayout(false);
            this.projectSuspensionSplitContainer.Panel1.ResumeLayout(false);
            this.projectSuspensionSplitContainer.Panel2.ResumeLayout(false);
            this.projectSuspensionSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.coordinatesGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedSimulationParametersTable)).EndInit();
            this.GridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.additionalParametersTable)).EndInit();
            this.ParamsControlsPanel4.ResumeLayout(false);
            this.ParamsControlsPanel4.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tablesAndGraphsTopLeftPanel.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.XYSplitContainer.Panel1.ResumeLayout(false);
            this.XYSplitContainer.Panel2.ResumeLayout(false);
            this.XYSplitContainer.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InvolvedSeriesDataGrid)).EndInit();
            this.panel8.ResumeLayout(false);
            this.RightSplitContainer.Panel1.ResumeLayout(false);
            this.RightSplitContainer.Panel2.ResumeLayout(false);
            this.RightSplitContainer.ResumeLayout(false);
            this.SimulationAndGraphSplitContainer.Panel1.ResumeLayout(false);
            this.SimulationAndGraphSplitContainer.Panel2.ResumeLayout(false);
            this.SimulationAndGraphSplitContainer.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private fmZedGraph.fmZedGraphControl fmZedGraphControl1;
        private fmDataGrid.fmDataGrid coordinatesGrid;
        private System.Windows.Forms.Label label1;
        private fmDataGrid.fmNumericalTextBox rowsQuantity;
        private System.Windows.Forms.Panel GridPanel;
        private fmDataGrid.fmDataGrid selectedSimulationParametersTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectedSimulationParametersCheckBoxColumn;
        private fmDataGrid.fmDataGrid additionalParametersTable;
        private System.Windows.Forms.Panel ParamsControlsPanel4;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.CheckBox UseParamsCheckBox;
        private System.Windows.Forms.Panel tablesAndGraphsTopLeftPanel;
        private Splitter splitter11;
        private Splitter splitter6;
        private Label xRangeLabel;
        private Panel panel8;
        private SplitContainer SimulationAndGraphSplitContainer;
        private Panel panel9;
        private Button button1;
        private Panel panel4;
        private ListView listBoxYAxis;
        private Panel panel10;
        private SplitContainer XYSplitContainer;
        private Panel panel11;
        private GroupBox groupBox1;
        private ListView listBoxXAxis;
        private GroupBox groupBox2;
        private ColumnHeader columnHeader1;
        private CheckBox cakeFormationMaterilParametersCheckBox;
        private CheckBox deliquoringMachininglParametersCheckBox;
        private CheckBox cakeFormationMachininglParametersCheckBox;
        private CheckBox deliquoringMaterilParametersCheckBox;
        private Button deselectAllButton;
        private ColumnHeader columnHeader2;
        private SplitContainer RightSplitContainer;
        private CheckBox NoScalingCheckBox;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem copyToolStripMenuItem;
        private CheckBox startFromOriginCheckBox;
        private fmDataGrid.fmDataGrid InvolvedSeriesDataGrid;
        private DataGridViewTextBoxColumn SerieColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn FromValueColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn ToValueColumn;
        private Button LoadDefaultRangle;
        private ListView listBoxY2Axis;
        private SplitContainer splitContainer2;
        private GroupBox groupBox3;
        private CheckBox y2LogCheckBox;
        private CheckBox yLogCheckBox;
        private DataGridViewCheckBoxColumn AdditionalParametersCheckBoxColumn;
        private Button buttonDeleteRow;
        private CheckBox xLogCheckBox;
        private Button btnLoadDiagramTemplatesButton;
        private Button btnSaveDiagramTemplatesButton;

    }
}
