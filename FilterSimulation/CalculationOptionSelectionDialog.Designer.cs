namespace FilterSimulation
{
    partial class CalculationOptionSelectionDialog
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
            this.rho_f_radioButton = new System.Windows.Forms.RadioButton();
            this.rho_s_radioButton = new System.Windows.Forms.RadioButton();
            this.rho_sus_radioButton = new System.Windows.Forms.RadioButton();
            this.suspensionGroupBox = new System.Windows.Forms.GroupBox();
            this.CmCvC_radioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.suspensionGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rho_f_radioButton
            // 
            this.rho_f_radioButton.AutoSize = true;
            this.rho_f_radioButton.Location = new System.Drawing.Point(8, 19);
            this.rho_f_radioButton.Name = "rho_f_radioButton";
            this.rho_f_radioButton.Size = new System.Drawing.Size(111, 17);
            this.rho_f_radioButton.TabIndex = 0;
            this.rho_f_radioButton.TabStop = true;
            this.rho_f_radioButton.Text = "rho_f is calculated";
            this.rho_f_radioButton.UseVisualStyleBackColor = true;
            this.rho_f_radioButton.CheckedChanged += new System.EventHandler(this.rho_f_radioButton_CheckedChanged);
            // 
            // rho_s_radioButton
            // 
            this.rho_s_radioButton.AutoSize = true;
            this.rho_s_radioButton.Location = new System.Drawing.Point(8, 42);
            this.rho_s_radioButton.Name = "rho_s_radioButton";
            this.rho_s_radioButton.Size = new System.Drawing.Size(113, 17);
            this.rho_s_radioButton.TabIndex = 1;
            this.rho_s_radioButton.TabStop = true;
            this.rho_s_radioButton.Text = "rho_s is calculated";
            this.rho_s_radioButton.UseVisualStyleBackColor = true;
            this.rho_s_radioButton.CheckedChanged += new System.EventHandler(this.rho_s_radioButton_CheckedChanged);
            // 
            // rho_sus_radioButton
            // 
            this.rho_sus_radioButton.AutoSize = true;
            this.rho_sus_radioButton.Location = new System.Drawing.Point(8, 65);
            this.rho_sus_radioButton.Name = "rho_sus_radioButton";
            this.rho_sus_radioButton.Size = new System.Drawing.Size(124, 17);
            this.rho_sus_radioButton.TabIndex = 2;
            this.rho_sus_radioButton.TabStop = true;
            this.rho_sus_radioButton.Text = "rho_sus is calculated";
            this.rho_sus_radioButton.UseVisualStyleBackColor = true;
            this.rho_sus_radioButton.CheckedChanged += new System.EventHandler(this.rho_sus_radioButton_CheckedChanged);
            // 
            // suspensionGroupBox
            // 
            this.suspensionGroupBox.Controls.Add(this.CmCvC_radioButton);
            this.suspensionGroupBox.Controls.Add(this.rho_sus_radioButton);
            this.suspensionGroupBox.Controls.Add(this.rho_s_radioButton);
            this.suspensionGroupBox.Controls.Add(this.rho_f_radioButton);
            this.suspensionGroupBox.Location = new System.Drawing.Point(12, 12);
            this.suspensionGroupBox.Name = "suspensionGroupBox";
            this.suspensionGroupBox.Size = new System.Drawing.Size(190, 117);
            this.suspensionGroupBox.TabIndex = 1;
            this.suspensionGroupBox.TabStop = false;
            this.suspensionGroupBox.Text = "Suspension calculation option";
            // 
            // CmCvC_radioButton
            // 
            this.CmCvC_radioButton.AutoSize = true;
            this.CmCvC_radioButton.Location = new System.Drawing.Point(8, 88);
            this.CmCvC_radioButton.Name = "CmCvC_radioButton";
            this.CmCvC_radioButton.Size = new System.Drawing.Size(160, 17);
            this.CmCvC_radioButton.TabIndex = 3;
            this.CmCvC_radioButton.TabStop = true;
            this.CmCvC_radioButton.Text = "Cm, Cv and C are calculated";
            this.CmCvC_radioButton.UseVisualStyleBackColor = true;
            this.CmCvC_radioButton.CheckedChanged += new System.EventHandler(this.CmCvC_radioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.suspensionGroupBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 162);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.okButton);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.cancelButton);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 25);
            this.panel2.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.okButton.Location = new System.Drawing.Point(272, 0);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 25);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(347, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 25);
            this.panel4.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.cancelButton.Location = new System.Drawing.Point(357, 0);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(6);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(432, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 25);
            this.panel3.TabIndex = 2;
            // 
            // CalculationOptionSelectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 187);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "CalculationOptionSelectionDialog";
            this.Text = "CalculationOptionSelectionDialog";
            this.Load += new System.EventHandler(this.CalculationOptionSelectionDialog_Load);
            this.suspensionGroupBox.ResumeLayout(false);
            this.suspensionGroupBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rho_f_radioButton;
        private System.Windows.Forms.RadioButton rho_s_radioButton;
        private System.Windows.Forms.RadioButton rho_sus_radioButton;
        private System.Windows.Forms.GroupBox suspensionGroupBox;
        private System.Windows.Forms.RadioButton CmCvC_radioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
    }
}