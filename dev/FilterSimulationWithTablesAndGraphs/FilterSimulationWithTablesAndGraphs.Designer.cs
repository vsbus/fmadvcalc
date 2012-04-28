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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.useDefaultRangesButton = new System.Windows.Forms.Button();
            this.maxXValueTextBox = new fmDataGrid.fmNumericalTextBox();
            this.minXValueTextBox = new fmDataGrid.fmNumericalTextBox();
            this.xRangeLabel = new System.Windows.Forms.Label();
            this.fmZedGraphControl1 = new fmZedGraph.fmZedGraphControl();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.UseParamsCheckBox = new System.Windows.Forms.CheckBox();
            this.coordinatesGrid = new fmDataGrid.fmDataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.rowsQuantity = new fmDataGrid.fmNumericalTextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rangePanel = new System.Windows.Forms.Panel();
            this.selectedSimulationParametersTable = new fmDataGrid.fmDataGrid();
            this.SelectedSimulationParametersCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GridPanel = new System.Windows.Forms.Panel();
            this.additionalParametersTable = new fmDataGrid.fmDataGrid();
            this.DeleteButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AdditionalParametersCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ParamsControlsPanel4 = new System.Windows.Forms.Panel();
            this.splitter10 = new System.Windows.Forms.Splitter();
            this.tablesAndGraphsTopLeftPanel = new System.Windows.Forms.Panel();
            this.listBoxYAxis = new System.Windows.Forms.CheckedListBox();
            this.listBoxXAxis = new System.Windows.Forms.ListBox();
            this.calculationOptionTandCChangeButton = new System.Windows.Forms.Button();
            this.splitter11 = new System.Windows.Forms.Splitter();
            this.splitter6 = new System.Windows.Forms.Splitter();
            this.panel8 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
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
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coordinatesGrid)).BeginInit();
            this.panel6.SuspendLayout();
            this.rangePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSimulationParametersTable)).BeginInit();
            this.GridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.additionalParametersTable)).BeginInit();
            this.ParamsControlsPanel4.SuspendLayout();
            this.tablesAndGraphsTopLeftPanel.SuspendLayout();
            this.panel8.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // suspensionKeepButton
            // 
            this.suspensionKeepButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.suspensionKeepButton, "Save suspension");
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
            // projectKeepButton
            // 
            this.projectKeepButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.projectKeepButton, "Save project");
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
            // simSeriesKeepButton
            // 
            this.simSeriesKeepButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.simSeriesKeepButton, "Save serie");
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
            // simulationKeepButton
            // 
            this.simulationKeepButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.simulationKeepButton, "Save externalSimulation");
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
            this.panelLeft.Size = new System.Drawing.Size(898, 266);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.splitter10);
            this.topPanel.Size = new System.Drawing.Size(898, 115);
            this.topPanel.Controls.SetChildIndex(this.projectPanel, 0);
            this.topPanel.Controls.SetChildIndex(this.splitter1, 0);
            this.topPanel.Controls.SetChildIndex(this.suspensionPanel, 0);
            this.topPanel.Controls.SetChildIndex(this.splitter2, 0);
            this.topPanel.Controls.SetChildIndex(this.machinePanel, 0);
            this.topPanel.Controls.SetChildIndex(this.splitter10, 0);
            // 
            // projectPanel
            // 
            this.projectPanel.Size = new System.Drawing.Size(170, 115);
            // 
            // suspensionPanel
            // 
            this.suspensionPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.suspensionPanel.Size = new System.Drawing.Size(226, 115);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitter2.Location = new System.Drawing.Point(399, 0);
            this.splitter2.Size = new System.Drawing.Size(3, 115);
            // 
            // machinePanel
            // 
            this.machinePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.machinePanel.Location = new System.Drawing.Point(402, 0);
            this.machinePanel.Size = new System.Drawing.Size(496, 115);
            // 
            // splitter1
            // 
            this.splitter1.Size = new System.Drawing.Size(3, 115);
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(0, 115);
            this.splitter3.Size = new System.Drawing.Size(898, 3);
            // 
            // secondFromTopPanel
            // 
            this.secondFromTopPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.secondFromTopPanel.Controls.Add(this.splitter11);
            this.secondFromTopPanel.Location = new System.Drawing.Point(0, 118);
            this.secondFromTopPanel.Size = new System.Drawing.Size(898, 148);
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
            this.panelTop.Size = new System.Drawing.Size(898, 266);
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(898, 731);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(222, 20);
            // 
            // panel3
            // 
            this.panel3.Size = new System.Drawing.Size(492, 20);
            // 
            // panel5
            // 
            this.panel5.Size = new System.Drawing.Size(894, 20);
            // 
            // simulationCreateButton
            // 
            this.simulationCreateButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.simulationCreateButton, "Create new externalSimulation");
            // 
            // simSeriesPanel
            // 
            this.simSeriesPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.simSeriesPanel.Size = new System.Drawing.Size(898, 148);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Size = new System.Drawing.Size(898, 731);
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
            this.mainSplitContainer.SplitterDistance = 898;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(472, 364);
            this.panel4.TabIndex = 14;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.useDefaultRangesButton);
            this.panel7.Controls.Add(this.maxXValueTextBox);
            this.panel7.Controls.Add(this.minXValueTextBox);
            this.panel7.Controls.Add(this.xRangeLabel);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 331);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(468, 29);
            this.panel7.TabIndex = 5;
            // 
            // useDefaultRangesButton
            // 
            this.useDefaultRangesButton.Location = new System.Drawing.Point(191, 3);
            this.useDefaultRangesButton.Name = "useDefaultRangesButton";
            this.useDefaultRangesButton.Size = new System.Drawing.Size(58, 20);
            this.useDefaultRangesButton.TabIndex = 3;
            this.useDefaultRangesButton.Text = "Default";
            this.useDefaultRangesButton.UseVisualStyleBackColor = true;
            this.useDefaultRangesButton.Click += new System.EventHandler(this.useDefaultRangesButton_Click);
            // 
            // maxXValueTextBox
            // 
            this.maxXValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.maxXValueTextBox.ForeColor = System.Drawing.Color.Black;
            this.maxXValueTextBox.Location = new System.Drawing.Point(125, 3);
            this.maxXValueTextBox.Name = "maxXValueTextBox";
            this.maxXValueTextBox.Size = new System.Drawing.Size(60, 20);
            this.maxXValueTextBox.TabIndex = 1;
            this.maxXValueTextBox.TextChanged += new System.EventHandler(this.minMaxXValueTextBox_TextChanged);
            // 
            // minXValueTextBox
            // 
            this.minXValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.minXValueTextBox.ForeColor = System.Drawing.Color.Black;
            this.minXValueTextBox.Location = new System.Drawing.Point(59, 3);
            this.minXValueTextBox.Name = "minXValueTextBox";
            this.minXValueTextBox.Size = new System.Drawing.Size(60, 20);
            this.minXValueTextBox.TabIndex = 0;
            this.minXValueTextBox.TextChanged += new System.EventHandler(this.minMaxXValueTextBox_TextChanged);
            // 
            // xRangeLabel
            // 
            this.xRangeLabel.AutoSize = true;
            this.xRangeLabel.Location = new System.Drawing.Point(4, 6);
            this.xRangeLabel.Name = "xRangeLabel";
            this.xRangeLabel.Size = new System.Drawing.Size(49, 13);
            this.xRangeLabel.TabIndex = 2;
            this.xRangeLabel.Text = "X Range";
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
            this.fmZedGraphControl1.Size = new System.Drawing.Size(373, 424);
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
            this.coordinatesGrid.Size = new System.Drawing.Size(373, 203);
            this.coordinatesGrid.TabIndex = 0;
            this.coordinatesGrid.CurrentCellChanged += new System.EventHandler(this.coordinatesGrid_CurrentCellChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "desired amount of values";
            // 
            // rowsQuantity
            // 
            this.rowsQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.rowsQuantity.ForeColor = System.Drawing.Color.Red;
            this.rowsQuantity.Location = new System.Drawing.Point(134, 3);
            this.rowsQuantity.Name = "rowsQuantity";
            this.rowsQuantity.Size = new System.Drawing.Size(38, 20);
            this.rowsQuantity.TabIndex = 2;
            this.rowsQuantity.TextChanged += new System.EventHandler(this.rowsQuantity_TextChanged);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.rangePanel);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 367);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(472, 233);
            this.panel6.TabIndex = 15;
            // 
            // rangePanel
            // 
            this.rangePanel.Controls.Add(this.label1);
            this.rangePanel.Controls.Add(this.rowsQuantity);
            this.rangePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rangePanel.Location = new System.Drawing.Point(0, 0);
            this.rangePanel.Name = "rangePanel";
            this.rangePanel.Size = new System.Drawing.Size(468, 29);
            this.rangePanel.TabIndex = 4;
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
            this.selectedSimulationParametersTable.Location = new System.Drawing.Point(0, 21);
            this.selectedSimulationParametersTable.Name = "selectedSimulationParametersTable";
            this.selectedSimulationParametersTable.RowHeadersVisible = false;
            this.selectedSimulationParametersTable.RowTemplate.Height = 18;
            this.selectedSimulationParametersTable.Size = new System.Drawing.Size(172, 75);
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
            this.GridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridPanel.Location = new System.Drawing.Point(197, 0);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(176, 100);
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
            this.additionalParametersTable.Location = new System.Drawing.Point(0, 21);
            this.additionalParametersTable.Name = "additionalParametersTable";
            this.additionalParametersTable.RowHeadersVisible = false;
            this.additionalParametersTable.RowTemplate.Height = 18;
            this.additionalParametersTable.Size = new System.Drawing.Size(172, 75);
            this.additionalParametersTable.TabIndex = 5;
            this.additionalParametersTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.additionalParametersTable_CellContentClick);
            this.additionalParametersTable.CurrentCellChanged += new System.EventHandler(this.ParametersTable_CurrentCellChanged);
            this.additionalParametersTable.CellValueChangedByUser += new System.Windows.Forms.DataGridViewCellEventHandler(this.additionalParametersTable_CellValueChangedByUser);
            // 
            // DeleteButtonColumn
            // 
            this.DeleteButtonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "Delete";
            this.DeleteButtonColumn.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.ParamsControlsPanel4.Location = new System.Drawing.Point(0, 0);
            this.ParamsControlsPanel4.Name = "ParamsControlsPanel4";
            this.ParamsControlsPanel4.Size = new System.Drawing.Size(172, 21);
            this.ParamsControlsPanel4.TabIndex = 11;
            // 
            // splitter10
            // 
            this.splitter10.Location = new System.Drawing.Point(402, 0);
            this.splitter10.Name = "splitter10";
            this.splitter10.Size = new System.Drawing.Size(3, 115);
            this.splitter10.TabIndex = 4;
            this.splitter10.TabStop = false;
            // 
            // tablesAndGraphsTopLeftPanel
            // 
            this.tablesAndGraphsTopLeftPanel.Controls.Add(this.listBoxYAxis);
            this.tablesAndGraphsTopLeftPanel.Controls.Add(this.listBoxXAxis);
            this.tablesAndGraphsTopLeftPanel.Controls.Add(this.calculationOptionTandCChangeButton);
            this.tablesAndGraphsTopLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tablesAndGraphsTopLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.tablesAndGraphsTopLeftPanel.Name = "tablesAndGraphsTopLeftPanel";
            this.tablesAndGraphsTopLeftPanel.Size = new System.Drawing.Size(197, 100);
            this.tablesAndGraphsTopLeftPanel.TabIndex = 7;
            // 
            // listBoxYAxis
            // 
            this.listBoxYAxis.CheckOnClick = true;
            this.listBoxYAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxYAxis.FormattingEnabled = true;
            this.listBoxYAxis.Location = new System.Drawing.Point(78, 0);
            this.listBoxYAxis.Name = "listBoxYAxis";
            this.listBoxYAxis.Size = new System.Drawing.Size(119, 64);
            this.listBoxYAxis.TabIndex = 4;
            this.listBoxYAxis.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listBoxYAxis_ItemCheck);
            // 
            // listBoxXAxis
            // 
            this.listBoxXAxis.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxXAxis.FormattingEnabled = true;
            this.listBoxXAxis.Location = new System.Drawing.Point(0, 0);
            this.listBoxXAxis.Name = "listBoxXAxis";
            this.listBoxXAxis.Size = new System.Drawing.Size(78, 69);
            this.listBoxXAxis.TabIndex = 1;
            this.listBoxXAxis.SelectedIndexChanged += new System.EventHandler(this.listBoxX_SelectedIndexChanged);
            // 
            // calculationOptionTandCChangeButton
            // 
            this.calculationOptionTandCChangeButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.calculationOptionTandCChangeButton.Location = new System.Drawing.Point(0, 77);
            this.calculationOptionTandCChangeButton.Name = "calculationOptionTandCChangeButton";
            this.calculationOptionTandCChangeButton.Size = new System.Drawing.Size(197, 23);
            this.calculationOptionTandCChangeButton.TabIndex = 3;
            this.calculationOptionTandCChangeButton.Text = "Calculation Option";
            this.calculationOptionTandCChangeButton.UseVisualStyleBackColor = true;
            this.calculationOptionTandCChangeButton.Click += new System.EventHandler(this.calculationOptionTandCChangeButton_Click);
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
            this.panel8.Controls.Add(this.splitContainer2);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(373, 731);
            this.panel8.TabIndex = 36;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.fmZedGraphControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.coordinatesGrid);
            this.splitContainer2.Size = new System.Drawing.Size(373, 631);
            this.splitContainer2.SplitterDistance = 424;
            this.splitContainer2.TabIndex = 12;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.GridPanel);
            this.panel9.Controls.Add(this.tablesAndGraphsTopLeftPanel);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 631);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(373, 100);
            this.panel9.TabIndex = 11;
            // 
            // fmFilterSimulationWithTablesAndGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "fmFilterSimulationWithTablesAndGraphs";
            this.Size = new System.Drawing.Size(1275, 731);
            this.Load += new System.EventHandler(this.fmFilterSimulationWithTablesAndGraphs_Load);
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
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coordinatesGrid)).EndInit();
            this.panel6.ResumeLayout(false);
            this.rangePanel.ResumeLayout(false);
            this.rangePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSimulationParametersTable)).EndInit();
            this.GridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.additionalParametersTable)).EndInit();
            this.ParamsControlsPanel4.ResumeLayout(false);
            this.ParamsControlsPanel4.PerformLayout();
            this.tablesAndGraphsTopLeftPanel.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private fmZedGraph.fmZedGraphControl fmZedGraphControl1;
        private System.Windows.Forms.Panel panel6;
        private fmDataGrid.fmDataGrid coordinatesGrid;
        private System.Windows.Forms.Panel rangePanel;
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
        private System.Windows.Forms.ListBox listBoxXAxis;
        private System.Windows.Forms.Splitter splitter10;
        private Splitter splitter11;
        private Splitter splitter6;
        private Panel panel7;
        private fmDataGrid.fmNumericalTextBox maxXValueTextBox;
        private fmDataGrid.fmNumericalTextBox minXValueTextBox;
        private Label xRangeLabel;
        private Button useDefaultRangesButton;
        private Button calculationOptionTandCChangeButton;
        private CheckedListBox listBoxYAxis;
        private Panel panel8;
        private SplitContainer splitContainer2;
        private Panel panel9;

    }
}
