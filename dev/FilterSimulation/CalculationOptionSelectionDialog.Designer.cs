namespace FilterSimulation
{
    partial class fmCalculationOptionSelectionDialog
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
            this.simulationCalculationOptionGroupBox = new System.Windows.Forms.GroupBox();
            this.fmCalculationOptionView1 = new fmCalcBlocksLibrary.Controls.fmCalculationOptionView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PcDCheckBox = new System.Windows.Forms.CheckBox();
            this.etaDCheckBox = new System.Windows.Forms.CheckBox();
            this.rhoDCheckBox = new System.Windows.Forms.CheckBox();
            this.CakeHeightInputCheckBox = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.suspensionGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.simulationCalculationOptionGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.suspensionGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.suspensionGroupBox.Location = new System.Drawing.Point(0, 0);
            this.suspensionGroupBox.Name = "suspensionGroupBox";
            this.suspensionGroupBox.Size = new System.Drawing.Size(190, 311);
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
            this.panel1.Controls.Add(this.simulationCalculationOptionGroupBox);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.suspensionGroupBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 311);
            this.panel1.TabIndex = 2;
            // 
            // simulationCalculationOptionGroupBox
            // 
            this.simulationCalculationOptionGroupBox.Controls.Add(this.fmCalculationOptionView1);
            this.simulationCalculationOptionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simulationCalculationOptionGroupBox.Location = new System.Drawing.Point(190, 0);
            this.simulationCalculationOptionGroupBox.Name = "simulationCalculationOptionGroupBox";
            this.simulationCalculationOptionGroupBox.Size = new System.Drawing.Size(273, 186);
            this.simulationCalculationOptionGroupBox.TabIndex = 2;
            this.simulationCalculationOptionGroupBox.TabStop = false;
            this.simulationCalculationOptionGroupBox.Text = "Simulation calculation option";
            // 
            // fmCalculationOptionView1
            // 
            this.fmCalculationOptionView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fmCalculationOptionView1.Location = new System.Drawing.Point(3, 16);
            this.fmCalculationOptionView1.Name = "fmCalculationOptionView1";
            this.fmCalculationOptionView1.Size = new System.Drawing.Size(267, 167);
            this.fmCalculationOptionView1.TabIndex = 0;
            this.fmCalculationOptionView1.CheckedChangedForUpdatingCalculationOptions += new System.EventHandler(this.fmCalculationOptionView1_CheckedChangedForUpdatingCalculationOptions);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PcDCheckBox);
            this.groupBox1.Controls.Add(this.etaDCheckBox);
            this.groupBox1.Controls.Add(this.rhoDCheckBox);
            this.groupBox1.Controls.Add(this.CakeHeightInputCheckBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(190, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 125);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deliquoring Calculation Option";
            // 
            // PcDCheckBox
            // 
            this.PcDCheckBox.AutoSize = true;
            this.PcDCheckBox.Location = new System.Drawing.Point(17, 42);
            this.PcDCheckBox.Name = "PcDCheckBox";
            this.PcDCheckBox.Size = new System.Drawing.Size(190, 17);
            this.PcDCheckBox.TabIndex = 3;
            this.PcDCheckBox.Text = "Cake Permeability/resistance Input";
            this.PcDCheckBox.UseVisualStyleBackColor = true;
            this.PcDCheckBox.CheckedChanged += new System.EventHandler(this.PcDCheckBox_CheckedChanged);
            // 
            // etaDCheckBox
            // 
            this.etaDCheckBox.AutoSize = true;
            this.etaDCheckBox.Checked = true;
            this.etaDCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.etaDCheckBox.Location = new System.Drawing.Point(17, 65);
            this.etaDCheckBox.Name = "etaDCheckBox";
            this.etaDCheckBox.Size = new System.Drawing.Size(151, 17);
            this.etaDCheckBox.TabIndex = 2;
            this.etaDCheckBox.Text = "eta_d taken equal to eta_f";
            this.etaDCheckBox.UseVisualStyleBackColor = true;
            this.etaDCheckBox.CheckedChanged += new System.EventHandler(this.etaDCheckBox_CheckedChanged);
            // 
            // rhoDCheckBox
            // 
            this.rhoDCheckBox.AutoSize = true;
            this.rhoDCheckBox.Checked = true;
            this.rhoDCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rhoDCheckBox.Location = new System.Drawing.Point(17, 88);
            this.rhoDCheckBox.Name = "rhoDCheckBox";
            this.rhoDCheckBox.Size = new System.Drawing.Size(151, 17);
            this.rhoDCheckBox.TabIndex = 1;
            this.rhoDCheckBox.Text = "rho_d taken equal to rho_f";
            this.rhoDCheckBox.UseVisualStyleBackColor = true;
            this.rhoDCheckBox.CheckedChanged += new System.EventHandler(this.rhoDCheckBox_CheckedChanged);
            // 
            // CakeHeightInputCheckBox
            // 
            this.CakeHeightInputCheckBox.AutoSize = true;
            this.CakeHeightInputCheckBox.Location = new System.Drawing.Point(17, 19);
            this.CakeHeightInputCheckBox.Name = "CakeHeightInputCheckBox";
            this.CakeHeightInputCheckBox.Size = new System.Drawing.Size(112, 17);
            this.CakeHeightInputCheckBox.TabIndex = 0;
            this.CakeHeightInputCheckBox.Text = "Cake Height Input";
            this.CakeHeightInputCheckBox.UseVisualStyleBackColor = true;
            this.CakeHeightInputCheckBox.CheckedChanged += new System.EventHandler(this.deliquoringCheckBox_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.okButton);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.cancelButton);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 311);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 25);
            this.panel2.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.okButton.Location = new System.Drawing.Point(293, 0);
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
            this.panel4.Location = new System.Drawing.Point(368, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 25);
            this.panel4.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.cancelButton.Location = new System.Drawing.Point(378, 0);
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
            this.panel3.Location = new System.Drawing.Point(453, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 25);
            this.panel3.TabIndex = 2;
            // 
            // fmCalculationOptionSelectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 336);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "fmCalculationOptionSelectionDialog";
            this.Text = "CalculationOptionSelectionDialog";
            this.Load += new System.EventHandler(this.CalculationOptionSelectionDialog_Load);
            this.suspensionGroupBox.ResumeLayout(false);
            this.suspensionGroupBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.simulationCalculationOptionGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rho_f_radioButton;
        private System.Windows.Forms.RadioButton rho_s_radioButton;
        private System.Windows.Forms.RadioButton rho_sus_radioButton;
        private System.Windows.Forms.GroupBox suspensionGroupBox;
        private System.Windows.Forms.RadioButton CmCvC_radioButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox simulationCalculationOptionGroupBox;
        private fmCalcBlocksLibrary.Controls.fmCalculationOptionView fmCalculationOptionView1;
        protected System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CakeHeightInputCheckBox;
        private System.Windows.Forms.CheckBox etaDCheckBox;
        private System.Windows.Forms.CheckBox rhoDCheckBox;
        private System.Windows.Forms.CheckBox PcDCheckBox;
    }
}