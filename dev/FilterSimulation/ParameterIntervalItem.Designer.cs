namespace FilterSimulation
{
    partial class ParameterIntervalItem
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
            this.parameterLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maxValueTextBox = new fmDataGrid.fmNumericalTextBox();
            this.minValueTextBox = new fmDataGrid.fmNumericalTextBox();
            this.SuspendLayout();
            // 
            // parameterLabel
            // 
            this.parameterLabel.AutoSize = true;
            this.parameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parameterLabel.Location = new System.Drawing.Point(3, 5);
            this.parameterLabel.Name = "parameterLabel";
            this.parameterLabel.Size = new System.Drawing.Size(55, 13);
            this.parameterLabel.TabIndex = 0;
            this.parameterLabel.Text = "Parameter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "from";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "to";
            // 
            // maxValueTextBox
            // 
            this.maxValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.maxValueTextBox.ForeColor = System.Drawing.Color.Red;
            this.maxValueTextBox.Location = new System.Drawing.Point(182, 2);
            this.maxValueTextBox.Name = "maxValueTextBox";
            this.maxValueTextBox.Size = new System.Drawing.Size(59, 20);
            this.maxValueTextBox.TabIndex = 2;
            // 
            // minValueTextBox
            // 
            this.minValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.minValueTextBox.ForeColor = System.Drawing.Color.Red;
            this.minValueTextBox.Location = new System.Drawing.Point(96, 2);
            this.minValueTextBox.Name = "minValueTextBox";
            this.minValueTextBox.Size = new System.Drawing.Size(59, 20);
            this.minValueTextBox.TabIndex = 1;
            // 
            // ParameterIntervalItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxValueTextBox);
            this.Controls.Add(this.minValueTextBox);
            this.Controls.Add(this.parameterLabel);
            this.Name = "ParameterIntervalItem";
            this.Size = new System.Drawing.Size(250, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label parameterLabel;
        private fmDataGrid.fmNumericalTextBox minValueTextBox;
        private fmDataGrid.fmNumericalTextBox maxValueTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
