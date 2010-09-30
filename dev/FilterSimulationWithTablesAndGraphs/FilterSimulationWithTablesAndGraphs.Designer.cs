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
            this.panel4 = new System.Windows.Forms.Panel();
            this.fmZedGraphControl1 = new fmZedGraph.fmZedGraphControl();
            this.panel7 = new System.Windows.Forms.Panel();
            this.useDefaultRangesButton = new System.Windows.Forms.Button();
            this.maxXValueTextBox = new fmDataGrid.fmNumericalTextBox();
            this.minXValueTextBox = new fmDataGrid.fmNumericalTextBox();
            this.xRangeLabel = new System.Windows.Forms.Label();
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
            this.splitter7 = new System.Windows.Forms.Splitter();
            this.panelLeft.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.projectPanel.SuspendLayout();
            this.suspensionPanel.SuspendLayout();
            this.secondFromTopPanel.SuspendLayout();
            this.suspensionParametersAndCalcOptionsPanel.SuspendLayout();
            this.simulationPanel.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.simSeriesPanel.SuspendLayout();
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
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Size = new System.Drawing.Size(765, 432);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.tablesAndGraphsTopLeftPanel);
            this.topPanel.Controls.Add(this.splitter10);
            this.topPanel.Size = new System.Drawing.Size(765, 114);
            this.topPanel.Controls.SetChildIndex(this.projectPanel, 0);
            this.topPanel.Controls.SetChildIndex(this.splitter1, 0);
            this.topPanel.Controls.SetChildIndex(this.suspensionPanel, 0);
            this.topPanel.Controls.SetChildIndex(this.splitter2, 0);
            this.topPanel.Controls.SetChildIndex(this.machinePanel, 0);
            this.topPanel.Controls.SetChildIndex(this.splitter10, 0);
            this.topPanel.Controls.SetChildIndex(this.tablesAndGraphsTopLeftPanel, 0);
            // 
            // suspensionPanel
            // 
            this.suspensionPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.suspensionPanel.Size = new System.Drawing.Size(293, 114);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitter2.Location = new System.Drawing.Point(466, 0);
            // 
            // machinePanel
            // 
            this.machinePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.machinePanel.Location = new System.Drawing.Point(469, 0);
            this.machinePanel.Size = new System.Drawing.Size(121, 114);
            // 
            // splitter3
            // 
            this.splitter3.Size = new System.Drawing.Size(765, 3);
            // 
            // secondFromTopPanel
            // 
            this.secondFromTopPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.secondFromTopPanel.Controls.Add(this.GridPanel);
            this.secondFromTopPanel.Controls.Add(this.splitter11);
            this.secondFromTopPanel.Size = new System.Drawing.Size(765, 126);
            this.secondFromTopPanel.Controls.SetChildIndex(this.simSeriesPanel, 0);
            this.secondFromTopPanel.Controls.SetChildIndex(this.splitter11, 0);
            this.secondFromTopPanel.Controls.SetChildIndex(this.GridPanel, 0);
            // 
            // suspensionParametersPanel
            // 
            this.suspensionParametersPanel.Size = new System.Drawing.Size(765, 186);
            // 
            // splitter4
            // 
            this.splitter4.Location = new System.Drawing.Point(0, 243);
            this.splitter4.Size = new System.Drawing.Size(765, 3);
            // 
            // simSeriesDuplicateButton
            // 
            this.simSeriesDuplicateButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.simSeriesDuplicateButton, "Duplicate serie");
            // 
            // suspensionParametersAndCalcOptionsPanel
            // 
            this.suspensionParametersAndCalcOptionsPanel.Location = new System.Drawing.Point(0, 246);
            this.suspensionParametersAndCalcOptionsPanel.Size = new System.Drawing.Size(765, 186);
            // 
            // panelRight
            // 
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelRight.Controls.Add(this.panel6);
            this.panelRight.Controls.Add(this.splitter6);
            this.panelRight.Controls.Add(this.panel4);
            this.panelRight.Location = new System.Drawing.Point(768, 0);
            this.panelRight.Size = new System.Drawing.Size(212, 432);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.splitter7);
            this.panelTop.Controls.SetChildIndex(this.panelLeft, 0);
            this.panelTop.Controls.SetChildIndex(this.splitter7, 0);
            this.panelTop.Controls.SetChildIndex(this.panelRight, 0);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(289, 20);
            // 
            // panel3
            // 
            this.panel3.Size = new System.Drawing.Size(615, 20);
            // 
            // simulationCreateButton
            // 
            this.simulationCreateButton.FlatAppearance.BorderSize = 0;
            this.toolTip.SetToolTip(this.simulationCreateButton, "Create new externalSimulation");
            // 
            // simSeriesPanel
            // 
            this.simSeriesPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.simSeriesPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.simSeriesPanel.Size = new System.Drawing.Size(619, 126);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.fmZedGraphControl1);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(212, 229);
            this.panel4.TabIndex = 14;
            // 
            // fmZedGraphControl1
            // 
            this.fmZedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fmZedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.fmZedGraphControl1.Name = "fmZedGraphControl1";
            this.fmZedGraphControl1.ScrollGrace = 0;
            this.fmZedGraphControl1.ScrollMaxX = 0;
            this.fmZedGraphControl1.ScrollMaxY = 0;
            this.fmZedGraphControl1.ScrollMaxY2 = 0;
            this.fmZedGraphControl1.ScrollMinX = 0;
            this.fmZedGraphControl1.ScrollMinY = 0;
            this.fmZedGraphControl1.ScrollMinY2 = 0;
            this.fmZedGraphControl1.Size = new System.Drawing.Size(208, 196);
            this.fmZedGraphControl1.TabIndex = 4;
            this.fmZedGraphControl1.HighLightedPointsChanged += new fmZedGraph.HighlightPointsEventHandler(this.fmZedGraphControl1_HighLightedPointsChanged);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.useDefaultRangesButton);
            this.panel7.Controls.Add(this.maxXValueTextBox);
            this.panel7.Controls.Add(this.minXValueTextBox);
            this.panel7.Controls.Add(this.xRangeLabel);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 196);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(208, 29);
            this.panel7.TabIndex = 5;
            // 
            // useDefaultRangesButton
            // 
            this.useDefaultRangesButton.Location = new System.Drawing.Point(147, 3);
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
            this.maxXValueTextBox.Location = new System.Drawing.Point(103, 3);
            this.maxXValueTextBox.Name = "maxXValueTextBox";
            this.maxXValueTextBox.Size = new System.Drawing.Size(38, 20);
            this.maxXValueTextBox.TabIndex = 1;
            this.maxXValueTextBox.TextChanged += new System.EventHandler(this.minMaxXValueTextBox_TextChanged);
            // 
            // minXValueTextBox
            // 
            this.minXValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.minXValueTextBox.ForeColor = System.Drawing.Color.Black;
            this.minXValueTextBox.Location = new System.Drawing.Point(59, 3);
            this.minXValueTextBox.Name = "minXValueTextBox";
            this.minXValueTextBox.Size = new System.Drawing.Size(38, 20);
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
            this.coordinatesGrid.Location = new System.Drawing.Point(0, 29);
            this.coordinatesGrid.Name = "coordinatesGrid";
            this.coordinatesGrid.RowHeadersVisible = false;
            this.coordinatesGrid.RowHeadersWidth = 15;
            this.coordinatesGrid.RowTemplate.Height = 18;
            this.coordinatesGrid.Size = new System.Drawing.Size(208, 167);
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
            this.panel6.Controls.Add(this.coordinatesGrid);
            this.panel6.Controls.Add(this.rangePanel);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 232);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(212, 200);
            this.panel6.TabIndex = 15;
            // 
            // rangePanel
            // 
            this.rangePanel.Controls.Add(this.label1);
            this.rangePanel.Controls.Add(this.rowsQuantity);
            this.rangePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rangePanel.Location = new System.Drawing.Point(0, 0);
            this.rangePanel.Name = "rangePanel";
            this.rangePanel.Size = new System.Drawing.Size(208, 29);
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
            this.selectedSimulationParametersTable.Size = new System.Drawing.Size(139, 101);
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
            this.GridPanel.Location = new System.Drawing.Point(622, 0);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(143, 126);
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
            this.additionalParametersTable.Size = new System.Drawing.Size(139, 101);
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
            this.ParamsControlsPanel4.Location = new System.Drawing.Point(0, 0);
            this.ParamsControlsPanel4.Name = "ParamsControlsPanel4";
            this.ParamsControlsPanel4.Size = new System.Drawing.Size(139, 21);
            this.ParamsControlsPanel4.TabIndex = 11;
            // 
            // splitter10
            // 
            this.splitter10.Location = new System.Drawing.Point(590, 0);
            this.splitter10.Name = "splitter10";
            this.splitter10.Size = new System.Drawing.Size(3, 114);
            this.splitter10.TabIndex = 4;
            this.splitter10.TabStop = false;
            // 
            // tablesAndGraphsTopLeftPanel
            // 
            this.tablesAndGraphsTopLeftPanel.Controls.Add(this.listBoxYAxis);
            this.tablesAndGraphsTopLeftPanel.Controls.Add(this.listBoxXAxis);
            this.tablesAndGraphsTopLeftPanel.Controls.Add(this.calculationOptionTandCChangeButton);
            this.tablesAndGraphsTopLeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablesAndGraphsTopLeftPanel.Location = new System.Drawing.Point(593, 0);
            this.tablesAndGraphsTopLeftPanel.Name = "tablesAndGraphsTopLeftPanel";
            this.tablesAndGraphsTopLeftPanel.Size = new System.Drawing.Size(172, 114);
            this.tablesAndGraphsTopLeftPanel.TabIndex = 7;
            // 
            // listBoxYAxis
            // 
            this.listBoxYAxis.CheckOnClick = true;
            this.listBoxYAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxYAxis.FormattingEnabled = true;
            this.listBoxYAxis.Location = new System.Drawing.Point(78, 0);
            this.listBoxYAxis.Name = "listBoxYAxis";
            this.listBoxYAxis.Size = new System.Drawing.Size(94, 79);
            this.listBoxYAxis.TabIndex = 4;
            this.listBoxYAxis.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listBoxYAxis_ItemCheck);
            // 
            // listBoxXAxis
            // 
            this.listBoxXAxis.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxXAxis.FormattingEnabled = true;
            this.listBoxXAxis.Location = new System.Drawing.Point(0, 0);
            this.listBoxXAxis.Name = "listBoxXAxis";
            this.listBoxXAxis.Size = new System.Drawing.Size(78, 82);
            this.listBoxXAxis.TabIndex = 1;
            this.listBoxXAxis.SelectedIndexChanged += new System.EventHandler(this.listBoxX_SelectedIndexChanged);
            // 
            // calculationOptionTandCChangeButton
            // 
            this.calculationOptionTandCChangeButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.calculationOptionTandCChangeButton.Location = new System.Drawing.Point(0, 91);
            this.calculationOptionTandCChangeButton.Name = "calculationOptionTandCChangeButton";
            this.calculationOptionTandCChangeButton.Size = new System.Drawing.Size(172, 23);
            this.calculationOptionTandCChangeButton.TabIndex = 3;
            this.calculationOptionTandCChangeButton.Text = "Calculation Option";
            this.calculationOptionTandCChangeButton.UseVisualStyleBackColor = true;
            this.calculationOptionTandCChangeButton.Click += new System.EventHandler(this.calculationOptionTandCChangeButton_Click);
            // 
            // splitter11
            // 
            this.splitter11.Location = new System.Drawing.Point(619, 0);
            this.splitter11.Name = "splitter11";
            this.splitter11.Size = new System.Drawing.Size(3, 126);
            this.splitter11.TabIndex = 9;
            this.splitter11.TabStop = false;
            // 
            // splitter6
            // 
            this.splitter6.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter6.Location = new System.Drawing.Point(0, 229);
            this.splitter6.Name = "splitter6";
            this.splitter6.Size = new System.Drawing.Size(212, 3);
            this.splitter6.TabIndex = 16;
            this.splitter6.TabStop = false;
            // 
            // splitter7
            // 
            this.splitter7.Location = new System.Drawing.Point(765, 0);
            this.splitter7.Name = "splitter7";
            this.splitter7.Size = new System.Drawing.Size(3, 432);
            this.splitter7.TabIndex = 32;
            this.splitter7.TabStop = false;
            // 
            // FilterSimulationWithTablesAndGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "fmFilterSimulationWithTablesAndGraphs";
            this.panelLeft.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.projectPanel.ResumeLayout(false);
            this.suspensionPanel.ResumeLayout(false);
            this.secondFromTopPanel.ResumeLayout(false);
            this.suspensionParametersAndCalcOptionsPanel.ResumeLayout(false);
            this.simulationPanel.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
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
        private Splitter splitter7;
        private Panel panel7;
        private fmDataGrid.fmNumericalTextBox maxXValueTextBox;
        private fmDataGrid.fmNumericalTextBox minXValueTextBox;
        private Label xRangeLabel;
        private Button useDefaultRangesButton;
        private Button calculationOptionTandCChangeButton;
        private CheckedListBox listBoxYAxis;

    }
}
