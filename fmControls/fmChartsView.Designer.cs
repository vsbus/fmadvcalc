namespace fmControls
{
    partial class fmChartsView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmChartsView));
            this.listBoxXAxis = new System.Windows.Forms.ListBox();
            this.listBoxYAxis = new System.Windows.Forms.ListBox();
            this.listBoxY2Axis = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fmCalculationOptionView1 = new fmCalcBlocksLibrary.Controls.fmCalculationOptionView();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.GridPanel = new System.Windows.Forms.Panel();
            this.selectedSimulationParametersTable = new fmDataGrid.fmDataGrid();
            this.SelectedSimulationParametersCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.additionalParametersTable = new fmDataGrid.fmDataGrid();
            this.DeleteButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AdditionalParametersCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ParamsControlsPanel4 = new System.Windows.Forms.Panel();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.UseParamsCheckBox = new System.Windows.Forms.CheckBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fmZedGraphControl1 = new fmZedGraph.fmZedGraphControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.coordinatesGrid = new fmDataGrid.fmDataGrid();
            this.rangePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rowsQuantity = new fmDataGrid.fmNumericalTextBox();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.GridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSimulationParametersTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.additionalParametersTable)).BeginInit();
            this.ParamsControlsPanel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coordinatesGrid)).BeginInit();
            this.rangePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxXAxis
            // 
            this.listBoxXAxis.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxXAxis.FormattingEnabled = true;
            this.listBoxXAxis.Location = new System.Drawing.Point(86, 0);
            this.listBoxXAxis.Name = "listBoxXAxis";
            this.listBoxXAxis.Size = new System.Drawing.Size(56, 134);
            this.listBoxXAxis.TabIndex = 1;
            this.listBoxXAxis.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBoxYAxis
            // 
            this.listBoxYAxis.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxYAxis.FormattingEnabled = true;
            this.listBoxYAxis.Location = new System.Drawing.Point(142, 0);
            this.listBoxYAxis.Name = "listBoxYAxis";
            this.listBoxYAxis.Size = new System.Drawing.Size(56, 134);
            this.listBoxYAxis.TabIndex = 2;
            this.listBoxYAxis.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // listBoxY2Axis
            // 
            this.listBoxY2Axis.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxY2Axis.FormattingEnabled = true;
            this.listBoxY2Axis.Location = new System.Drawing.Point(198, 0);
            this.listBoxY2Axis.Name = "listBoxY2Axis";
            this.listBoxY2Axis.Size = new System.Drawing.Size(56, 134);
            this.listBoxY2Axis.TabIndex = 3;
            this.listBoxY2Axis.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fmCalculationOptionView1);
            this.panel1.Controls.Add(this.listBoxXAxis);
            this.panel1.Controls.Add(this.listBoxYAxis);
            this.panel1.Controls.Add(this.listBoxY2Axis);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 134);
            this.panel1.TabIndex = 6;
            // 
            // fmCalculationOptionView1
            // 
            this.fmCalculationOptionView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fmCalculationOptionView1.Location = new System.Drawing.Point(0, 0);
            this.fmCalculationOptionView1.Name = "fmCalculationOptionView1";
            this.fmCalculationOptionView1.Size = new System.Drawing.Size(86, 134);
            this.fmCalculationOptionView1.TabIndex = 4;
            this.fmCalculationOptionView1.CheckedChanged += new System.EventHandler(this.fmCalculationOptionView1_CheckedChanged);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.GridPanel);
            this.panelLeft.Controls.Add(this.splitter1);
            this.panelLeft.Controls.Add(this.panel1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(254, 371);
            this.panelLeft.TabIndex = 7;
            // 
            // GridPanel
            // 
            this.GridPanel.Controls.Add(this.selectedSimulationParametersTable);
            this.GridPanel.Controls.Add(this.additionalParametersTable);
            this.GridPanel.Controls.Add(this.ParamsControlsPanel4);
            this.GridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridPanel.Location = new System.Drawing.Point(0, 137);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(254, 234);
            this.GridPanel.TabIndex = 10;
            // 
            // selectedSimulationParametersTable
            // 
            this.selectedSimulationParametersTable.AllowUserToAddRows = false;
            this.selectedSimulationParametersTable.AllowUserToDeleteRows = false;
            this.selectedSimulationParametersTable.AllowUserToResizeRows = false;
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
            this.selectedSimulationParametersTable.Size = new System.Drawing.Size(254, 213);
            this.selectedSimulationParametersTable.TabIndex = 10;
            this.selectedSimulationParametersTable.Visible = false;
            this.selectedSimulationParametersTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.selectedSimulationParametersTable_CellValueChanged);
            this.selectedSimulationParametersTable.CurrentCellChanged += new System.EventHandler(this.ParametersTable_CurrentCellChanged);
            // 
            // SelectedSimulationParametersCheckBoxColumn
            // 
            this.SelectedSimulationParametersCheckBoxColumn.HeaderText = "";
            this.SelectedSimulationParametersCheckBoxColumn.Name = "SelectedSimulationParametersCheckBoxColumn";
            this.SelectedSimulationParametersCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SelectedSimulationParametersCheckBoxColumn.Width = 20;
            // 
            // additionalParametersTable
            // 
            this.additionalParametersTable.AllowUserToAddRows = false;
            this.additionalParametersTable.AllowUserToOrderColumns = true;
            this.additionalParametersTable.AllowUserToResizeRows = false;
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
            this.additionalParametersTable.Size = new System.Drawing.Size(254, 213);
            this.additionalParametersTable.TabIndex = 5;
            this.additionalParametersTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.additionalParametersTable_CellValueChanged);
            this.additionalParametersTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.additionalParametersTable_CellContentClick);
            this.additionalParametersTable.CurrentCellChanged += new System.EventHandler(this.ParametersTable_CurrentCellChanged);
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
            this.ParamsControlsPanel4.Size = new System.Drawing.Size(254, 21);
            this.ParamsControlsPanel4.TabIndex = 11;
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
            this.UseParamsCheckBox.Checked = true;
            this.UseParamsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseParamsCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.UseParamsCheckBox.Location = new System.Drawing.Point(0, 0);
            this.UseParamsCheckBox.Name = "UseParamsCheckBox";
            this.UseParamsCheckBox.Size = new System.Drawing.Size(125, 21);
            this.UseParamsCheckBox.TabIndex = 9;
            this.UseParamsCheckBox.Text = "Use local parameters";
            this.UseParamsCheckBox.UseVisualStyleBackColor = true;
            this.UseParamsCheckBox.CheckedChanged += new System.EventHandler(this.UseParamsCheckBox_CheckedChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 134);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(254, 3);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(254, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 371);
            this.splitter2.TabIndex = 8;
            this.splitter2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fmZedGraphControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(257, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(379, 268);
            this.panel2.TabIndex = 9;
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
            this.fmZedGraphControl1.Size = new System.Drawing.Size(379, 268);
            this.fmZedGraphControl1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.coordinatesGrid);
            this.panel3.Controls.Add(this.rangePanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(257, 271);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(379, 100);
            this.panel3.TabIndex = 10;
            // 
            // coordinatesGrid
            // 
            this.coordinatesGrid.AllowUserToAddRows = false;
            this.coordinatesGrid.AllowUserToDeleteRows = false;
            this.coordinatesGrid.AllowUserToResizeRows = false;
            this.coordinatesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.coordinatesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coordinatesGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.coordinatesGrid.HighLightCurrentRow = true;
            this.coordinatesGrid.Location = new System.Drawing.Point(0, 29);
            this.coordinatesGrid.Name = "coordinatesGrid";
            this.coordinatesGrid.RowHeadersVisible = false;
            this.coordinatesGrid.RowHeadersWidth = 15;
            this.coordinatesGrid.RowTemplate.Height = 18;
            this.coordinatesGrid.Size = new System.Drawing.Size(379, 71);
            this.coordinatesGrid.TabIndex = 0;
            // 
            // rangePanel
            // 
            this.rangePanel.Controls.Add(this.label1);
            this.rangePanel.Controls.Add(this.rowsQuantity);
            this.rangePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rangePanel.Location = new System.Drawing.Point(0, 0);
            this.rangePanel.Name = "rangePanel";
            this.rangePanel.Size = new System.Drawing.Size(379, 29);
            this.rangePanel.TabIndex = 4;
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
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter3.Location = new System.Drawing.Point(257, 268);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(379, 3);
            this.splitter3.TabIndex = 11;
            this.splitter3.TabStop = false;
            // 
            // fmChartsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panelLeft);
            this.Name = "fmChartsView";
            this.Size = new System.Drawing.Size(636, 371);
            this.Load += new System.EventHandler(this.fmChartsView_Load);
            this.panel1.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.GridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedSimulationParametersTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.additionalParametersTable)).EndInit();
            this.ParamsControlsPanel4.ResumeLayout(false);
            this.ParamsControlsPanel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.coordinatesGrid)).EndInit();
            this.rangePanel.ResumeLayout(false);
            this.rangePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxXAxis;
        private System.Windows.Forms.ListBox listBoxYAxis;
        private System.Windows.Forms.ListBox listBoxY2Axis;
        private fmZedGraph.fmZedGraphControl fmZedGraphControl1;
        private fmDataGrid.fmDataGrid additionalParametersTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private fmCalcBlocksLibrary.Controls.fmCalculationOptionView fmCalculationOptionView1;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter3;
        private fmDataGrid.fmDataGrid coordinatesGrid;
        private System.Windows.Forms.Panel GridPanel;
        private System.Windows.Forms.CheckBox UseParamsCheckBox;
        private fmDataGrid.fmDataGrid selectedSimulationParametersTable;
        private System.Windows.Forms.Panel ParamsControlsPanel4;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButtonColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AdditionalParametersCheckBoxColumn;
        private System.Windows.Forms.Panel rangePanel;
        private fmDataGrid.fmNumericalTextBox rowsQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectedSimulationParametersCheckBoxColumn;


    }
}