namespace SampleForDeliquoringBlocks
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
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fmDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // fmDataGrid1
            // 
            this.fmDataGrid1.AllowUserToAddRows = false;
            this.fmDataGrid1.AllowUserToDeleteRows = false;
            this.fmDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fmDataGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.fmDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fmDataGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fmDataGrid1.HighLightCurrentRow = false;
            this.fmDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.fmDataGrid1.Name = "fmDataGrid1";
            this.fmDataGrid1.RowTemplate.Height = 18;
            this.fmDataGrid1.Size = new System.Drawing.Size(418, 553);
            this.fmDataGrid1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Parameter";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Units";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Value";
            this.Column3.Name = "Column3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 553);
            this.Controls.Add(this.fmDataGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fmDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private fmDataGrid.fmDataGrid fmDataGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn Column3;
    }
}

