namespace AdvancedCalculator
{
    partial class fmDigitsOptions
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
            this.precisionUpDown = new System.Windows.Forms.NumericUpDown();
            this.OKbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.precisionUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // precisionUpDown
            // 
            this.precisionUpDown.Location = new System.Drawing.Point(38, 43);
            this.precisionUpDown.Maximum = new decimal(new int[] {
                                                                     10,
                                                                     0,
                                                                     0,
                                                                     0});
            this.precisionUpDown.Name = "precisionUpDown";
            this.precisionUpDown.Size = new System.Drawing.Size(76, 20);
            this.precisionUpDown.TabIndex = 0;
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(152, 40);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 1;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter number of displaying digits for numeric data";
            // 
            // DigitsOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 88);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.precisionUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmDigitsOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DigitsOptions";
            ((System.ComponentModel.ISupportInitialize)(this.precisionUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown precisionUpDown;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Label label1;
    }
}