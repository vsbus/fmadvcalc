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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_rho_f = new System.Windows.Forms.RadioButton();
            this.radioButton_rho_s = new System.Windows.Forms.RadioButton();
            this.radioButton_rho_sus = new System.Windows.Forms.RadioButton();
            this.radioButton_C = new System.Windows.Forms.RadioButton();
            this.parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new fmDataGrid.DataGridViewNumericalTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fmDataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fmDataGrid1
            // 
            this.fmDataGrid1.AllowUserToAddRows = false;
            this.fmDataGrid1.AllowUserToDeleteRows = false;
            this.fmDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fmDataGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parameter,
            this.value});
            this.fmDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fmDataGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fmDataGrid1.HighLightCurrentRow = false;
            this.fmDataGrid1.Location = new System.Drawing.Point(72, 0);
            this.fmDataGrid1.Name = "fmDataGrid1";
            this.fmDataGrid1.RowTemplate.Height = 18;
            this.fmDataGrid1.Size = new System.Drawing.Size(272, 406);
            this.fmDataGrid1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_C);
            this.groupBox1.Controls.Add(this.radioButton_rho_sus);
            this.groupBox1.Controls.Add(this.radioButton_rho_s);
            this.groupBox1.Controls.Add(this.radioButton_rho_f);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(72, 406);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // radioButton_rho_f
            // 
            this.radioButton_rho_f.AutoSize = true;
            this.radioButton_rho_f.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton_rho_f.Location = new System.Drawing.Point(3, 16);
            this.radioButton_rho_f.Name = "radioButton_rho_f";
            this.radioButton_rho_f.Size = new System.Drawing.Size(66, 17);
            this.radioButton_rho_f.TabIndex = 0;
            this.radioButton_rho_f.TabStop = true;
            this.radioButton_rho_f.Text = "rho_f";
            this.radioButton_rho_f.UseVisualStyleBackColor = true;
            // 
            // radioButton_rho_s
            // 
            this.radioButton_rho_s.AutoSize = true;
            this.radioButton_rho_s.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton_rho_s.Location = new System.Drawing.Point(3, 33);
            this.radioButton_rho_s.Name = "radioButton_rho_s";
            this.radioButton_rho_s.Size = new System.Drawing.Size(66, 17);
            this.radioButton_rho_s.TabIndex = 1;
            this.radioButton_rho_s.TabStop = true;
            this.radioButton_rho_s.Text = "rho_s";
            this.radioButton_rho_s.UseVisualStyleBackColor = true;
            // 
            // radioButton_rho_sus
            // 
            this.radioButton_rho_sus.AutoSize = true;
            this.radioButton_rho_sus.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton_rho_sus.Location = new System.Drawing.Point(3, 50);
            this.radioButton_rho_sus.Name = "radioButton_rho_sus";
            this.radioButton_rho_sus.Size = new System.Drawing.Size(66, 17);
            this.radioButton_rho_sus.TabIndex = 2;
            this.radioButton_rho_sus.TabStop = true;
            this.radioButton_rho_sus.Text = "rho_sus";
            this.radioButton_rho_sus.UseVisualStyleBackColor = true;
            // 
            // radioButton_C
            // 
            this.radioButton_C.AutoSize = true;
            this.radioButton_C.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton_C.Location = new System.Drawing.Point(3, 67);
            this.radioButton_C.Name = "radioButton_C";
            this.radioButton_C.Size = new System.Drawing.Size(66, 17);
            this.radioButton_C.TabIndex = 3;
            this.radioButton_C.TabStop = true;
            this.radioButton_C.Text = "C";
            this.radioButton_C.UseVisualStyleBackColor = true;
            // 
            // parameter
            // 
            this.parameter.HeaderText = "parameter";
            this.parameter.Name = "parameter";
            this.parameter.ReadOnly = true;
            // 
            // value
            // 
            this.value.HeaderText = "value";
            this.value.Name = "value";
            this.value.ReadOnly = true;
            this.value.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 406);
            this.Controls.Add(this.fmDataGrid1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fmDataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private fmDataGrid.fmDataGrid fmDataGrid1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_rho_f;
        private System.Windows.Forms.RadioButton radioButton_C;
        private System.Windows.Forms.RadioButton radioButton_rho_sus;
        private System.Windows.Forms.RadioButton radioButton_rho_s;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameter;
        private fmDataGrid.DataGridViewNumericalTextBoxColumn value;
    }
}

