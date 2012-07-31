namespace FilterSimulation
{
    partial class TableWithParameterRanges
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
            this.fmDataGrid1 = new fmDataGrid.fmDataGrid();
            this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.MaxValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fmDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // fmDataGrid1
            // 
            this.fmDataGrid1.AllowUserToAddRows = false;
            this.fmDataGrid1.AllowUserToDeleteRows = false;
            this.fmDataGrid1.AllowUserToResizeRows = false;
            this.fmDataGrid1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.fmDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fmDataGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterColumn,
            this.UnitsColumn,
            this.MinValueColumn,
            this.MaxValueColumn});
            this.fmDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fmDataGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fmDataGrid1.HighLightCurrentRow = false;
            this.fmDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.fmDataGrid1.Name = "fmDataGrid1";
            this.fmDataGrid1.RowHeadersVisible = false;
            this.fmDataGrid1.RowTemplate.Height = 18;
            this.fmDataGrid1.Size = new System.Drawing.Size(389, 396);
            this.fmDataGrid1.TabIndex = 0;
            // 
            // ParameterColumn
            // 
            this.ParameterColumn.HeaderText = "Parameter";
            this.ParameterColumn.Name = "ParameterColumn";
            this.ParameterColumn.ReadOnly = true;
            this.ParameterColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UnitsColumn
            // 
            this.UnitsColumn.HeaderText = "Units";
            this.UnitsColumn.Name = "UnitsColumn";
            this.UnitsColumn.ReadOnly = true;
            this.UnitsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitsColumn.Width = 50;
            // 
            // MinValueColumn
            // 
            this.MinValueColumn.HeaderText = "Min Value";
            this.MinValueColumn.Name = "MinValueColumn";
            this.MinValueColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MinValueColumn.Width = 65;
            // 
            // MaxValueColumn
            // 
            this.MaxValueColumn.HeaderText = "Max Value";
            this.MaxValueColumn.Name = "MaxValueColumn";
            this.MaxValueColumn.Width = 65;
            // 
            // TableWithParameterRanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fmDataGrid1);
            this.Name = "TableWithParameterRanges";
            this.Size = new System.Drawing.Size(389, 396);
            ((System.ComponentModel.ISupportInitialize)(this.fmDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private fmDataGrid.fmDataGrid fmDataGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn MinValueColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn MaxValueColumn;
    }
}
