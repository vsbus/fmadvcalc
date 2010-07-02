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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ParamGrid = new fmDataGrid.fmDataGrid();
            this.ParameterNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnlimitedFlagColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MinRangeColumn = new fmDataGrid.DataGridViewNumericalTextBoxColumn();
            this.MaxRangeColumn = new fmDataGrid.DataGridViewNumericalTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParamGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonOK.Location = new System.Drawing.Point(413, 0);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 26);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 455);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 26);
            this.panel1.TabIndex = 2;
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
            this.UnlimitedFlagColumn,
            this.MinRangeColumn,
            this.MaxRangeColumn});
            this.ParamGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParamGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ParamGrid.HighLightCurrentRow = false;
            this.ParamGrid.Location = new System.Drawing.Point(0, 0);
            this.ParamGrid.Name = "ParamGrid";
            this.ParamGrid.RowHeadersVisible = false;
            this.ParamGrid.RowTemplate.Height = 18;
            this.ParamGrid.Size = new System.Drawing.Size(488, 455);
            this.ParamGrid.TabIndex = 0;
            this.ParamGrid.CellValueChangedByUser += new System.Windows.Forms.DataGridViewCellEventHandler(this.ParamGrid_CellValueChangedByUser);
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
            // UnlimitedFlagColumn
            // 
            this.UnlimitedFlagColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UnlimitedFlagColumn.HeaderText = "Unlimited";
            this.UnlimitedFlagColumn.Name = "UnlimitedFlagColumn";
            this.UnlimitedFlagColumn.Width = 56;
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
            this.ClientSize = new System.Drawing.Size(488, 481);
            this.Controls.Add(this.ParamGrid);
            this.Controls.Add(this.panel1);
            this.Name = "ParameterIntervalOption";
            this.Text = "ParameterIntervalOption";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ParamGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private fmDataGrid.fmDataGrid ParamGrid;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UnlimitedFlagColumn;
        private fmDataGrid.DataGridViewNumericalTextBoxColumn MinRangeColumn;
        private fmDataGrid.DataGridViewNumericalTextBoxColumn MaxRangeColumn;



    }
}