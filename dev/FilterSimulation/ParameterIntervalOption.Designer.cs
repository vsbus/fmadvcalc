namespace FilterSimulation
{
    partial class ParameterIntervalOption
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.ParamGrid = new fmDataGrid.fmDataGrid();
            this.ParameterNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinRangeColumn = new fmDataGrid.DataGridViewNumericalTextBoxColumn();
            this.MaxRangeColumn = new fmDataGrid.DataGridViewNumericalTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ParamGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(324, 328);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // ParamGrid
            // 
            this.ParamGrid.AllowUserToAddRows = false;
            this.ParamGrid.AllowUserToResizeRows = false;
            this.ParamGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ParamGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ParamGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParamGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterNameColumn,
            this.UnitColumn,
            this.MinRangeColumn,
            this.MaxRangeColumn});
            this.ParamGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ParamGrid.Location = new System.Drawing.Point(0, 0);
            this.ParamGrid.Name = "ParamGrid";
            this.ParamGrid.RowHeadersVisible = false;
            this.ParamGrid.RowTemplate.Height = 18;
            this.ParamGrid.Size = new System.Drawing.Size(411, 329);
            this.ParamGrid.TabIndex = 0;
            // 
            // ParameterNameColumn
            // 
            this.ParameterNameColumn.DataPropertyName = "Name";
            this.ParameterNameColumn.HeaderText = "Parameter";
            this.ParameterNameColumn.Name = "ParameterNameColumn";
            this.ParameterNameColumn.ReadOnly = true;
            // 
            // UnitColumn
            // 
            this.UnitColumn.DataPropertyName = "Unit";
            this.UnitColumn.HeaderText = "Units";
            this.UnitColumn.Name = "UnitColumn";
            this.UnitColumn.ReadOnly = true;
            // 
            // MinRangeColumn
            // 
            this.MinRangeColumn.DataPropertyName = "MinValue";
            this.MinRangeColumn.HeaderText = "minRange";
            this.MinRangeColumn.Name = "MinRangeColumn";
            this.MinRangeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MinRangeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MaxRangeColumn
            // 
            this.MaxRangeColumn.DataPropertyName = "MaxValue";
            this.MaxRangeColumn.HeaderText = "maxRange";
            this.MaxRangeColumn.Name = "MaxRangeColumn";
            this.MaxRangeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaxRangeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ParameterIntervalOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 363);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.ParamGrid);
            this.Name = "ParameterIntervalOption";
            this.Text = "ParameterIntervalOption";
            ((System.ComponentModel.ISupportInitialize)(this.ParamGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private fmDataGrid.fmDataGrid ParamGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitColumn;
        private fmDataGrid.DataGridViewNumericalTextBoxColumn MinRangeColumn;
        private fmDataGrid.DataGridViewNumericalTextBoxColumn MaxRangeColumn;
        private System.Windows.Forms.Button buttonOK;



    }
}