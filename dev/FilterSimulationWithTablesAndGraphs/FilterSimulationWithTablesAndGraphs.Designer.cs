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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.maxXValueTextBox = new fmDataGrid.fmNumericalTextBox();
            this.minXValueTextBox = new fmDataGrid.fmNumericalTextBox();
            this.xRangeLabel = new System.Windows.Forms.Label();
            this.fmZedGraphControl1 = new fmZedGraph.fmZedGraphControl();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.UseParamsCheckBox = new System.Windows.Forms.CheckBox();
            this.coordinatesGrid = new fmDataGrid.fmDataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.rowsQuantity = new fmDataGrid.fmNumericalTextBox();
            this.selectedSimulationParametersTable = new fmDataGrid.fmDataGrid();
            this.SelectedSimulationParametersCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GridPanel = new System.Windows.Forms.Panel();
            this.additionalParametersTable = new fmDataGrid.fmDataGrid();
            this.DeleteButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AdditionalParametersCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ParamsControlsPanel4 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tablesAndGraphsTopLeftPanel = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.XYSplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxXAxis = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxYAxis = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel11 = new System.Windows.Forms.Panel();
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
            this.groupBox1.SuspendLayout();
            this.panel11.SuspendLayout();
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
            this.toolTip.SetToolTip(this.projectCreateButton, "Create new project");
            // 
            // suspensionCreateButton
            // 
            this.suspensionCreateButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.suspensionCreateButton, "Create new suspension");
            // 
            // simSeriesCreateButton
            // 
            this.simSeriesCreateButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.simSeriesCreateButton, "Create new serie");
            // 
            // projectRestoreButton
            // 
            this.projectRestoreButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.projectRestoreButton, "Restore project");
            // 
            // projectDeleteButton
            // 
            this.projectDeleteButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.projectDeleteButton, "Delete project");
            // 
            // suspensionRestoreButton
            // 
            this.suspensionRestoreButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.suspensionRestoreButton, "Restore suspension");
            // 
            // suspensionDeleteButton
            // 
            this.suspensionDeleteButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.suspensionDeleteButton, "Delete suspension");
            // 
            // simSeriesRestoreButton
            // 
            this.simSeriesRestoreButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.simSeriesRestoreButton, "Restore serie");
            // 
            // simSeriesDeleteButton
            // 
            this.simSeriesDeleteButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.simSeriesDeleteButton, "Delete serie");
            // 
            // simulationDuplicateButton
            // 
            this.simulationDuplicateButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.simulationDuplicateButton, "Duplicate externalSimulation");
            // 
            // simulationRestoreButton
            // 
            this.simulationRestoreButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.simulationRestoreButton, "Restore externalSimulation");
            // 
            // simulationDeleteButton
            // 
            this.simulationDeleteButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.simulationDeleteButton, "Delete externalSimulation");
            // 
            // panelLeft
            // 
            this.panelLeft.Size = new System.Drawing.Size(897, 266);
            // 
            // topPanel
            // 
            this.topPanel.Size = new System.Drawing.Size(897, 115);
            // 
            // projectPanel
            // 
            this.projectPanel.Size = new System.Drawing.Size(175, 115);
            // 
            // suspensionPanel
            // 
            this.suspensionPanel.Size = new System.Drawing.Size(221, 115);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Size = new System.Drawing.Size(3, 115);
            // 
            // machinePanel
            // 
            this.machinePanel.Size = new System.Drawing.Size(490, 115);
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(0, 115);
            this.splitter3.Size = new System.Drawing.Size(897, 3);
            // 
            // secondFromTopPanel
            // 
            this.secondFromTopPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.secondFromTopPanel.Controls.Add(this.splitter11);
            this.secondFromTopPanel.Location = new System.Drawing.Point(0, 118);
            this.secondFromTopPanel.Size = new System.Drawing.Size(897, 148);
            this.secondFromTopPanel.Controls.SetChildIndex(this.simSeriesPanel, 0);
            this.secondFromTopPanel.Controls.SetChildIndex(this.splitter11, 0);
            // 
            // simSeriesDuplicateButton
            // 
            this.simSeriesDuplicateButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.simSeriesDuplicateButton, "Duplicate serie");
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(897, 266);
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(897, 731);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(171, 20);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(217, 20);
            // 
            // panel3
            // 
            this.panel3.Size = new System.Drawing.Size(486, 20);
            // 
            // panel5
            // 
            this.panel5.Size = new System.Drawing.Size(893, 20);
            // 
            // simulationCreateButton
            // 
            this.simulationCreateButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.simulationCreateButton, "Create new externalSimulation");
            // 
            // simSeriesPanel
            // 
            this.simSeriesPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.simSeriesPanel.Size = new System.Drawing.Size(897, 148);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Size = new System.Drawing.Size(897, 731);
            this.splitContainer1.SplitterDistance = 266;
            // 
            // mainSplitContainer
            // 
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.panel8);
            this.mainSplitContainer.Panel2Collapsed = false;
            this.mainSplitContainer.Size = new System.Drawing.Size(1275, 731);
            this.mainSplitContainer.SplitterDistance = 897;
            // 
            // projectSuspensionSerieSplitContainer
            // 
            this.projectSuspensionSerieSplitContainer.Location = new System.Drawing.Point(3, 0);
            this.projectSuspensionSerieSplitContainer.Size = new System.Drawing.Size(894, 115);
            this.projectSuspensionSerieSplitContainer.SplitterDistance = 400;
            // 
            // projectSuspensionSplitContainer
            // 
            this.projectSuspensionSplitContainer.Size = new System.Drawing.Size(400, 115);
            this.projectSuspensionSplitContainer.SplitterDistance = 175;
            // 
            // commentSimulationButton
            // 
            this.commentSimulationButton.FlatAppearance.BorderSize = 0;
            // 
            // commentProjectButton
            // 
            this.commentProjectButton.FlatAppearance.BorderSize = 0;
            // 
            // commentSuspensionButton
            // 
            this.commentSuspensionButton.FlatAppearance.BorderSize = 0;
            // 
            // commentSerieButton
            // 
            this.commentSerieButton.FlatAppearance.BorderSize = 0;
            // 
            // maxXValueTextBox
            // 
            this.maxXValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.maxXValueTextBox.ForeColor = System.Drawing.Color.Black;
            this.maxXValueTextBox.Location = new System.Drawing.Point(67, 125);
            this.maxXValueTextBox.Name = "maxXValueTextBox";
            this.maxXValueTextBox.Size = new System.Drawing.Size(50, 20);
            this.maxXValueTextBox.TabIndex = 1;
            this.maxXValueTextBox.TextChanged += new System.EventHandler(this.minMaxXValueTextBox_TextChanged);
            // 
            // minXValueTextBox
            // 
            this.minXValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.minXValueTextBox.ForeColor = System.Drawing.Color.Black;
            this.minXValueTextBox.Location = new System.Drawing.Point(11, 125);
            this.minXValueTextBox.Name = "minXValueTextBox";
            this.minXValueTextBox.Size = new System.Drawing.Size(50, 20);
            this.minXValueTextBox.TabIndex = 0;
            this.minXValueTextBox.TextChanged += new System.EventHandler(this.minMaxXValueTextBox_TextChanged);
            // 
            // xRangeLabel
            // 
            this.xRangeLabel.AutoSize = true;
            this.xRangeLabel.Location = new System.Drawing.Point(10, 102);
            this.xRangeLabel.Name = "xRangeLabel";
            this.xRangeLabel.Size = new System.Drawing.Size(39, 13);
            this.xRangeLabel.TabIndex = 2;
            this.xRangeLabel.Text = "Range";
            // 
            // fmZedGraphControl1
            // 
            this.fmZedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.fmZedGraphControl1.Size = new System.Drawing.Size(374, 373);
            this.fmZedGraphControl1.TabIndex = 4;
            this.fmZedGraphControl1.HighLightedPointsChanged += new fmZedGraph.HighlightPointsEventHandler(this.fmZedGraphControl1_HighLightedPointsChanged);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAddRow.FlatAppearance.BorderSize = 0;
            this.buttonAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddRow.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddRow.Image")));
            this.buttonAddRow.Location = new System.Drawing.Point(125, 0);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(20, 21);
            this.buttonAddRow.TabIndex = 8;
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // UseParamsCheckBox
            // 
            this.UseParamsCheckBox.AutoSize = true;
            this.UseParamsCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.UseParamsCheckBox.Location = new System.Drawing.Point(0, 0);
            this.UseParamsCheckBox.Name = "UseParamsCheckBox";
            this.UseParamsCheckBox.Size = new System.Drawing.Size(125, 21);
            this.UseParamsCheckBox.TabIndex = 9;
            this.UseParamsCheckBox.Text = "Use local parameters";
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
            this.coordinatesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coordinatesGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.coordinatesGrid.HighLightCurrentRow = true;
            this.coordinatesGrid.Location = new System.Drawing.Point(0, 0);
            this.coordinatesGrid.Name = "coordinatesGrid";
            this.coordinatesGrid.RowHeadersVisible = false;
            this.coordinatesGrid.RowHeadersWidth = 15;
            this.coordinatesGrid.RowTemplate.Height = 18;
            this.coordinatesGrid.Size = new System.Drawing.Size(374, 179);
            this.coordinatesGrid.TabIndex = 0;
            this.coordinatesGrid.CurrentCellChanged += new System.EventHandler(this.coordinatesGrid_CurrentCellChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Desired amount of values:";
            // 
            // rowsQuantity
            // 
            this.rowsQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.rowsQuantity.ForeColor = System.Drawing.Color.Red;
            this.rowsQuantity.Location = new System.Drawing.Point(141, 158);
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
            this.selectedSimulationParametersTable.HighLightCurrentRow = true;
            this.selectedSimulationParametersTable.Location = new System.Drawing.Point(0, 57);
            this.selectedSimulationParametersTable.Name = "selectedSimulationParametersTable";
            this.selectedSimulationParametersTable.RowHeadersVisible = false;
            this.selectedSimulationParametersTable.RowTemplate.Height = 18;
            this.selectedSimulationParametersTable.Size = new System.Drawing.Size(366, 106);
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
            this.GridPanel.Size = new System.Drawing.Size(370, 167);
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
            this.DeleteButtonColumn,
            this.AdditionalParametersCheckBoxColumn});
            this.additionalParametersTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.additionalParametersTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.additionalParametersTable.HighLightCurrentRow = true;
            this.additionalParametersTable.Location = new System.Drawing.Point(0, 57);
            this.additionalParametersTable.Name = "additionalParametersTable";
            this.additionalParametersTable.RowHeadersVisible = false;
            this.additionalParametersTable.RowTemplate.Height = 18;
            this.additionalParametersTable.Size = new System.Drawing.Size(366, 106);
            this.additionalParametersTable.TabIndex = 5;
            this.additionalParametersTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.additionalParametersTable_CellContentClick);
            this.additionalParametersTable.CurrentCellChanged += new System.EventHandler(this.ParametersTable_CurrentCellChanged);
            this.additionalParametersTable.CellValueChangedByUser += new System.Windows.Forms.DataGridViewCellEventHandler(this.additionalParametersTable_CellValueChangedByUser);
            // 
            // DeleteButtonColumn
            // 
            this.DeleteButtonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "Delete";
            this.DeleteButtonColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.DeleteButtonColumn.HeaderText = "";
            this.DeleteButtonColumn.Name = "DeleteButtonColumn";
            this.DeleteButtonColumn.Width = 5;
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
            this.ParamsControlsPanel4.Controls.Add(this.buttonAddRow);
            this.ParamsControlsPanel4.Controls.Add(this.UseParamsCheckBox);
            this.ParamsControlsPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.ParamsControlsPanel4.Location = new System.Drawing.Point(0, 36);
            this.ParamsControlsPanel4.Name = "ParamsControlsPanel4";
            this.ParamsControlsPanel4.Size = new System.Drawing.Size(366, 21);
            this.ParamsControlsPanel4.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(366, 36);
            this.panel4.TabIndex = 12;
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
            this.tablesAndGraphsTopLeftPanel.Size = new System.Drawing.Size(341, 327);
            this.tablesAndGraphsTopLeftPanel.TabIndex = 7;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.XYSplitContainer);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(341, 327);
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
            this.XYSplitContainer.Panel2.Controls.Add(this.groupBox1);
            this.XYSplitContainer.Panel2.Controls.Add(this.panel11);
            this.XYSplitContainer.Size = new System.Drawing.Size(341, 327);
            this.XYSplitContainer.SplitterDistance = 112;
            this.XYSplitContainer.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxXAxis);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(112, 327);
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
            this.listBoxXAxis.Size = new System.Drawing.Size(106, 308);
            this.listBoxXAxis.TabIndex = 6;
            this.listBoxXAxis.UseCompatibleStateImageBehavior = false;
            this.listBoxXAxis.View = System.Windows.Forms.View.Details;
            this.listBoxXAxis.SelectedIndexChanged += new System.EventHandler(this.listBoxX_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "X Parameter";
            this.columnHeader1.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxYAxis);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 107);
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
            this.listBoxYAxis.Size = new System.Drawing.Size(219, 88);
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
            // panel11
            // 
            this.panel11.Controls.Add(this.deliquoringMachininglParametersCheckBox);
            this.panel11.Controls.Add(this.deselectAllButton);
            this.panel11.Controls.Add(this.cakeFormationMaterilParametersCheckBox);
            this.panel11.Controls.Add(this.deliquoringMaterilParametersCheckBox);
            this.panel11.Controls.Add(this.xRangeLabel);
            this.panel11.Controls.Add(this.cakeFormationMachininglParametersCheckBox);
            this.panel11.Controls.Add(this.label1);
            this.panel11.Controls.Add(this.minXValueTextBox);
            this.panel11.Controls.Add(this.rowsQuantity);
            this.panel11.Controls.Add(this.maxXValueTextBox);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(225, 220);
            this.panel11.TabIndex = 8;
            // 
            // deliquoringMachininglParametersCheckBox
            // 
            this.deliquoringMachininglParametersCheckBox.AutoSize = true;
            this.deliquoringMachininglParametersCheckBox.Location = new System.Drawing.Point(13, 75);
            this.deliquoringMachininglParametersCheckBox.Name = "deliquoringMachininglParametersCheckBox";
            this.deliquoringMachininglParametersCheckBox.Size = new System.Drawing.Size(187, 17);
            this.deliquoringMachininglParametersCheckBox.TabIndex = 3;
            this.deliquoringMachininglParametersCheckBox.Text = "Deliquoring Machining Parameters";
            this.deliquoringMachininglParametersCheckBox.UseVisualStyleBackColor = true;
            this.deliquoringMachininglParametersCheckBox.CheckedChanged += new System.EventHandler(this.DeliquoringMachininglParametersCheckBoxCheckedChanged);
            // 
            // deselectAllButton
            // 
            this.deselectAllButton.Location = new System.Drawing.Point(100, 192);
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
            this.cakeFormationMachininglParametersCheckBox.Size = new System.Drawing.Size(208, 17);
            this.cakeFormationMachininglParametersCheckBox.TabIndex = 2;
            this.cakeFormationMachininglParametersCheckBox.Text = "Cake Formation Machining Parameters";
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
            this.panel8.Size = new System.Drawing.Size(374, 731);
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
            this.RightSplitContainer.Size = new System.Drawing.Size(374, 731);
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
            this.SimulationAndGraphSplitContainer.Size = new System.Drawing.Size(374, 556);
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
            this.panel9.Size = new System.Drawing.Size(374, 171);
            this.panel9.TabIndex = 11;
            // 
            // fmFilterSimulationWithTablesAndGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "fmFilterSimulationWithTablesAndGraphs";
            this.Size = new System.Drawing.Size(1275, 731);
            this.Load += new System.EventHandler(this.FmFilterSimulationWithTablesAndGraphsLoad);
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
            this.groupBox1.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
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
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButtonColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AdditionalParametersCheckBoxColumn;
        private System.Windows.Forms.Panel ParamsControlsPanel4;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.CheckBox UseParamsCheckBox;
        private System.Windows.Forms.Panel tablesAndGraphsTopLeftPanel;
        private Splitter splitter11;
        private Splitter splitter6;
        private fmDataGrid.fmNumericalTextBox maxXValueTextBox;
        private fmDataGrid.fmNumericalTextBox minXValueTextBox;
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

    }
}
