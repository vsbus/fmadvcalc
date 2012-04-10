namespace FilterSimulationWithTablesAndGraphs
{
    partial class fmCalculationOptionSelectionExpandedDialog
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.calclulationOptionKindGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.applyForGroupBox = new System.Windows.Forms.GroupBox();
            this.allItemsRadioButton = new System.Windows.Forms.RadioButton();
            this.checkedItemsRadioButton = new System.Windows.Forms.RadioButton();
            this.currentItemRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.calclulationOptionKindGroupBox.SuspendLayout();
            this.applyForGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Size = new System.Drawing.Size(495, 290);
            this.panel1.Controls.SetChildIndex(this.groupBox1, 0);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.calclulationOptionKindGroupBox);
            this.panel5.Controls.Add(this.applyForGroupBox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 290);
            this.panel5.TabIndex = 4;
            // 
            // calclulationOptionKindGroupBox
            // 
            this.calclulationOptionKindGroupBox.Controls.Add(this.radioButton2);
            this.calclulationOptionKindGroupBox.Controls.Add(this.radioButton1);
            this.calclulationOptionKindGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calclulationOptionKindGroupBox.Location = new System.Drawing.Point(0, 116);
            this.calclulationOptionKindGroupBox.Name = "calclulationOptionKindGroupBox";
            this.calclulationOptionKindGroupBox.Size = new System.Drawing.Size(200, 174);
            this.calclulationOptionKindGroupBox.TabIndex = 1;
            this.calclulationOptionKindGroupBox.TabStop = false;
            this.calclulationOptionKindGroupBox.Text = "Calclulation Option Kind";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(87, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Mother/Initial";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "New";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // applyForGroupBox
            // 
            this.applyForGroupBox.Controls.Add(this.allItemsRadioButton);
            this.applyForGroupBox.Controls.Add(this.checkedItemsRadioButton);
            this.applyForGroupBox.Controls.Add(this.currentItemRadioButton);
            this.applyForGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.applyForGroupBox.Location = new System.Drawing.Point(0, 0);
            this.applyForGroupBox.Name = "applyForGroupBox";
            this.applyForGroupBox.Size = new System.Drawing.Size(200, 116);
            this.applyForGroupBox.TabIndex = 0;
            this.applyForGroupBox.TabStop = false;
            this.applyForGroupBox.Text = "Apply For";
            // 
            // allItemsRadioButton
            // 
            this.allItemsRadioButton.AutoSize = true;
            this.allItemsRadioButton.Location = new System.Drawing.Point(6, 65);
            this.allItemsRadioButton.Name = "allItemsRadioButton";
            this.allItemsRadioButton.Size = new System.Drawing.Size(64, 17);
            this.allItemsRadioButton.TabIndex = 2;
            this.allItemsRadioButton.Text = "All Items";
            this.allItemsRadioButton.UseVisualStyleBackColor = true;
            this.allItemsRadioButton.CheckedChanged += new System.EventHandler(this.allItemsRadioButton_CheckedChanged);
            // 
            // checkedItemsRadioButton
            // 
            this.checkedItemsRadioButton.AutoSize = true;
            this.checkedItemsRadioButton.Location = new System.Drawing.Point(6, 42);
            this.checkedItemsRadioButton.Name = "checkedItemsRadioButton";
            this.checkedItemsRadioButton.Size = new System.Drawing.Size(96, 17);
            this.checkedItemsRadioButton.TabIndex = 1;
            this.checkedItemsRadioButton.Text = "Checked Items";
            this.checkedItemsRadioButton.UseVisualStyleBackColor = true;
            this.checkedItemsRadioButton.CheckedChanged += new System.EventHandler(this.checkedItemsRadioButton_CheckedChanged);
            // 
            // currentItemRadioButton
            // 
            this.currentItemRadioButton.AutoSize = true;
            this.currentItemRadioButton.Checked = true;
            this.currentItemRadioButton.Location = new System.Drawing.Point(6, 19);
            this.currentItemRadioButton.Name = "currentItemRadioButton";
            this.currentItemRadioButton.Size = new System.Drawing.Size(82, 17);
            this.currentItemRadioButton.TabIndex = 0;
            this.currentItemRadioButton.TabStop = true;
            this.currentItemRadioButton.Text = "Current Item";
            this.currentItemRadioButton.UseVisualStyleBackColor = true;
            this.currentItemRadioButton.CheckedChanged += new System.EventHandler(this.currentItemRadioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 231);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 50);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deliquoring Calculation Option";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(34, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(134, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "hcd calculated from hc";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // fmCalculationOptionSelectionExpandedDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(695, 315);
            this.Controls.Add(this.panel5);
            this.Name = "fmCalculationOptionSelectionExpandedDialog";
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.calclulationOptionKindGroupBox.ResumeLayout(false);
            this.calclulationOptionKindGroupBox.PerformLayout();
            this.applyForGroupBox.ResumeLayout(false);
            this.applyForGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox calclulationOptionKindGroupBox;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox applyForGroupBox;
        private System.Windows.Forms.RadioButton allItemsRadioButton;
        private System.Windows.Forms.RadioButton checkedItemsRadioButton;
        private System.Windows.Forms.RadioButton currentItemRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
