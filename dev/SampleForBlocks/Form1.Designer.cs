namespace SampleForBlocks
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fmDataGrid1 = new fmDataGrid.fmDataGrid();
            this.parameterNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minAbsLimitColumn = new fmDataGrid.DataGridViewNumericalTextBoxColumn();
            this.minLimitColumn = new fmDataGrid.DataGridViewNumericalTextBoxColumn();
            this.valueColumn = new fmDataGrid.DataGridViewNumericalTextBoxColumn();
            this.maxLimitColumn = new fmDataGrid.DataGridViewNumericalTextBoxColumn();
            this.maxAbsLimitColumn = new fmDataGrid.DataGridViewNumericalTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculationOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.precisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetInputsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.fmDataGrid1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fmDataGrid1
            // 
            this.fmDataGrid1.AllowUserToAddRows = false;
            this.fmDataGrid1.AllowUserToDeleteRows = false;
            this.fmDataGrid1.AllowUserToResizeColumns = false;
            this.fmDataGrid1.AllowUserToResizeRows = false;
            this.fmDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fmDataGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parameterNameColumn,
            this.unitsColumn,
            this.minAbsLimitColumn,
            this.minLimitColumn,
            this.valueColumn,
            this.maxLimitColumn,
            this.maxAbsLimitColumn});
            this.fmDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fmDataGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fmDataGrid1.HighLightCurrentRow = false;
            this.fmDataGrid1.Location = new System.Drawing.Point(0, 24);
            this.fmDataGrid1.Name = "fmDataGrid1";
            this.fmDataGrid1.RowHeadersVisible = false;
            this.fmDataGrid1.RowTemplate.Height = 18;
            this.fmDataGrid1.Size = new System.Drawing.Size(728, 378);
            this.fmDataGrid1.TabIndex = 0;
            // 
            // parameterNameColumn
            // 
            this.parameterNameColumn.HeaderText = "Parameter";
            this.parameterNameColumn.Name = "parameterNameColumn";
            this.parameterNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // unitsColumn
            // 
            this.unitsColumn.HeaderText = "Units";
            this.unitsColumn.Name = "unitsColumn";
            this.unitsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // minAbsLimitColumn
            // 
            this.minAbsLimitColumn.HeaderText = "MinAbs";
            this.minAbsLimitColumn.Name = "minAbsLimitColumn";
            this.minAbsLimitColumn.Width = 60;
            // 
            // minLimitColumn
            // 
            this.minLimitColumn.HeaderText = "Min";
            this.minLimitColumn.Name = "minLimitColumn";
            this.minLimitColumn.Width = 60;
            // 
            // valueColumn
            // 
            this.valueColumn.HeaderText = "Value";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.Width = 60;
            // 
            // maxLimitColumn
            // 
            this.maxLimitColumn.HeaderText = "Max";
            this.maxLimitColumn.Name = "maxLimitColumn";
            this.maxLimitColumn.Width = 60;
            // 
            // maxAbsLimitColumn
            // 
            this.maxAbsLimitColumn.HeaderText = "MaxAbs";
            this.maxAbsLimitColumn.Name = "maxAbsLimitColumn";
            this.maxAbsLimitColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.maxAbsLimitColumn.Width = 60;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rangesToolStripMenuItem,
            this.calculationOptionToolStripMenuItem,
            this.precisionToolStripMenuItem,
            this.resetInputsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(728, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rangesToolStripMenuItem
            // 
            this.rangesToolStripMenuItem.Name = "rangesToolStripMenuItem";
            this.rangesToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.rangesToolStripMenuItem.Text = "Ranges";
            this.rangesToolStripMenuItem.Click += new System.EventHandler(this.rangesToolStripMenuItem_Click);
            // 
            // calculationOptionToolStripMenuItem
            // 
            this.calculationOptionToolStripMenuItem.Name = "calculationOptionToolStripMenuItem";
            this.calculationOptionToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.calculationOptionToolStripMenuItem.Text = "Calculation Option";
            this.calculationOptionToolStripMenuItem.Click += new System.EventHandler(this.calculationOptionToolStripMenuItem_Click);
            // 
            // precisionToolStripMenuItem
            // 
            this.precisionToolStripMenuItem.Name = "precisionToolStripMenuItem";
            this.precisionToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.precisionToolStripMenuItem.Text = "Precision";
            this.precisionToolStripMenuItem.Click += new System.EventHandler(this.precisionToolStripMenuItem_Click);
            // 
            // resetInputsToolStripMenuItem
            // 
            this.resetInputsToolStripMenuItem.Name = "resetInputsToolStripMenuItem";
            this.resetInputsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.resetInputsToolStripMenuItem.Text = "Reset Inputs";
            this.resetInputsToolStripMenuItem.Click += new System.EventHandler(this.resetInputsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 402);
            this.Controls.Add(this.fmDataGrid1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fmDataGrid1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private fmDataGrid.fmDataGrid fmDataGrid1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculationOptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem precisionToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameterNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitsColumn;
        private fmDataGrid.DataGridViewNumericalTextBoxColumn minAbsLimitColumn;
        private fmDataGrid.DataGridViewNumericalTextBoxColumn minLimitColumn;
        private fmDataGrid.DataGridViewNumericalTextBoxColumn valueColumn;
        private fmDataGrid.DataGridViewNumericalTextBoxColumn maxLimitColumn;
        private fmDataGrid.DataGridViewNumericalTextBoxColumn maxAbsLimitColumn;
        private System.Windows.Forms.ToolStripMenuItem resetInputsToolStripMenuItem;
    }
}

