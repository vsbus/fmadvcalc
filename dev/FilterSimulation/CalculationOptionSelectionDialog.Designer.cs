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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Dp = const (Plain)");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Qp = const (Plain)");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Qp = const (Plain, volumetric pump)");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Plain area (Pressure leaf)", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Dp = const (Cylindrical)");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Qp = const (Cylindrical)");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Qp = const (Cylindrical, volumetric pump)");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Cylindrical (Candle filter)", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("3: A, Dp, (n/tc/tr), tf");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("4: A, (hc/Vf/Mf/Vsus/Msus/Ms), (sf/tr), (n/tc)");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("8: A, Dp, (hc/Vf/Mf/Vsus/Msus/Ms), (n/tc/tr)");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Standart", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("1: Q, Dp, hc, (n/tc/tr)");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Design", new System.Windows.Forms.TreeNode[] {
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("1: A, Q, Dp, (sf/tr)");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Optimization", new System.Windows.Forms.TreeNode[] {
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Other...", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode14,
            treeNode16});
            this.rho_f_radioButton = new System.Windows.Forms.RadioButton();
            this.rho_s_radioButton = new System.Windows.Forms.RadioButton();
            this.rho_sus_radioButton = new System.Windows.Forms.RadioButton();
            this.suspensionGroupBox = new System.Windows.Forms.GroupBox();
            this.CmCvC_radioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simulationCalculationOptionGroupBox = new System.Windows.Forms.GroupBox();
            this.fmCalculationOptionView1 = new fmCalcBlocksLibrary.Controls.fmCalculationOptionView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.etaDCheckBox = new System.Windows.Forms.CheckBox();
            this.rhoDCheckBox = new System.Windows.Forms.CheckBox();
            this.deliquoringCheckBox = new System.Windows.Forms.CheckBox();
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
            this.suspensionGroupBox.Size = new System.Drawing.Size(190, 280);
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
            this.panel1.Size = new System.Drawing.Size(463, 280);
            this.panel1.TabIndex = 2;
            // 
            // simulationCalculationOptionGroupBox
            // 
            this.simulationCalculationOptionGroupBox.Controls.Add(this.fmCalculationOptionView1);
            this.simulationCalculationOptionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simulationCalculationOptionGroupBox.Location = new System.Drawing.Point(190, 0);
            this.simulationCalculationOptionGroupBox.Name = "simulationCalculationOptionGroupBox";
            this.simulationCalculationOptionGroupBox.Size = new System.Drawing.Size(273, 181);
            this.simulationCalculationOptionGroupBox.TabIndex = 2;
            this.simulationCalculationOptionGroupBox.TabStop = false;
            this.simulationCalculationOptionGroupBox.Text = "Simulation calculation option";
            // 
            // fmCalculationOptionView1
            // 
            this.fmCalculationOptionView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fmCalculationOptionView1.Location = new System.Drawing.Point(3, 16);
            this.fmCalculationOptionView1.Name = "fmCalculationOptionView1";
            treeNode1.Name = "";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            treeNode1.Text = "Dp = const (Plain)";
            treeNode2.Name = "";
            treeNode2.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            treeNode2.Text = "Qp = const (Plain)";
            treeNode3.Name = "";
            treeNode3.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            treeNode3.Text = "Qp = const (Plain, volumetric pump)";
            treeNode4.Name = "";
            treeNode4.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            treeNode4.Text = "Plain area (Pressure leaf)";
            treeNode5.Name = "";
            treeNode5.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            treeNode5.Text = "Dp = const (Cylindrical)";
            treeNode6.Name = "";
            treeNode6.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            treeNode6.Text = "Qp = const (Cylindrical)";
            treeNode7.Name = "";
            treeNode7.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            treeNode7.Text = "Qp = const (Cylindrical, volumetric pump)";
            treeNode8.Name = "";
            treeNode8.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            treeNode8.Text = "Cylindrical (Candle filter)";
            treeNode9.Name = "";
            treeNode9.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            treeNode9.Text = "3: A, Dp, (n/tc/tr), tf";
            treeNode10.Name = "";
            treeNode10.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            treeNode10.Text = "4: A, (hc/Vf/Mf/Vsus/Msus/Ms), (sf/tr), (n/tc)";
            treeNode11.Name = "";
            treeNode11.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            treeNode11.Text = "8: A, Dp, (hc/Vf/Mf/Vsus/Msus/Ms), (n/tc/tr)";
            treeNode12.Name = "";
            treeNode12.Text = "Standart";
            treeNode13.Name = "";
            treeNode13.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            treeNode13.Text = "1: Q, Dp, hc, (n/tc/tr)";
            treeNode14.Name = "";
            treeNode14.Text = "Design";
            treeNode15.Name = "";
            treeNode15.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            treeNode15.Text = "1: A, Q, Dp, (sf/tr)";
            treeNode16.Name = "";
            treeNode16.Text = "Optimization";
            treeNode17.Name = "";
            treeNode17.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            treeNode17.Text = "Other...";
            this.fmCalculationOptionView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode8,
            treeNode17});
            this.fmCalculationOptionView1.Size = new System.Drawing.Size(267, 162);
            this.fmCalculationOptionView1.TabIndex = 0;
            this.fmCalculationOptionView1.CheckedChangedForUpdatingCalculationOptions += new System.EventHandler(this.fmCalculationOptionView1_CheckedChangedForUpdatingCalculationOptions);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.etaDCheckBox);
            this.groupBox1.Controls.Add(this.rhoDCheckBox);
            this.groupBox1.Controls.Add(this.deliquoringCheckBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(190, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 99);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deliquoring Calculation Option";
            // 
            // etaDCheckBox
            // 
            this.etaDCheckBox.AutoSize = true;
            this.etaDCheckBox.Checked = true;
            this.etaDCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.etaDCheckBox.Location = new System.Drawing.Point(17, 42);
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
            this.rhoDCheckBox.Location = new System.Drawing.Point(17, 65);
            this.rhoDCheckBox.Name = "rhoDCheckBox";
            this.rhoDCheckBox.Size = new System.Drawing.Size(151, 17);
            this.rhoDCheckBox.TabIndex = 1;
            this.rhoDCheckBox.Text = "rho_d taken equal to rho_f";
            this.rhoDCheckBox.UseVisualStyleBackColor = true;
            this.rhoDCheckBox.CheckedChanged += new System.EventHandler(this.rhoDCheckBox_CheckedChanged);
            // 
            // deliquoringCheckBox
            // 
            this.deliquoringCheckBox.AutoSize = true;
            this.deliquoringCheckBox.Checked = true;
            this.deliquoringCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.deliquoringCheckBox.Location = new System.Drawing.Point(17, 19);
            this.deliquoringCheckBox.Name = "deliquoringCheckBox";
            this.deliquoringCheckBox.Size = new System.Drawing.Size(134, 17);
            this.deliquoringCheckBox.TabIndex = 0;
            this.deliquoringCheckBox.Text = "hcd calculated from hc";
            this.deliquoringCheckBox.UseVisualStyleBackColor = true;
            this.deliquoringCheckBox.CheckedChanged += new System.EventHandler(this.deliquoringCheckBox_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.okButton);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.cancelButton);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 280);
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
            this.ClientSize = new System.Drawing.Size(463, 305);
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
        private System.Windows.Forms.CheckBox deliquoringCheckBox;
        private System.Windows.Forms.CheckBox etaDCheckBox;
        private System.Windows.Forms.CheckBox rhoDCheckBox;
    }
}