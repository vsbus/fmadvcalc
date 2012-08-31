using fmFilterSimulationControl;

namespace AdvancedCalculator
{
    partial class fmUnitsOptions
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.QPanel = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.unitSchemaComboBox = new System.Windows.Forms.ComboBox();
            this.showUSUnitsCheckBox = new System.Windows.Forms.CheckBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LengthAreaTimePanel = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.massAndVolumePanel = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RhoEtaPanel = new System.Windows.Forms.Panel();
            this.GasPanel = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QPanel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Q";
            // 
            // QPanel
            // 
            this.QPanel.AutoScroll = true;
            this.QPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QPanel.Location = new System.Drawing.Point(3, 16);
            this.QPanel.Name = "QPanel";
            this.QPanel.Size = new System.Drawing.Size(331, 118);
            this.QPanel.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(535, 75);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(616, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.unitSchemaComboBox);
            this.panel2.Controls.Add(this.showUSUnitsCheckBox);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.OKButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 376);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 110);
            this.panel2.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(272, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Save As Default";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Load Default";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Units Set:";
            // 
            // unitSchemaComboBox
            // 
            this.unitSchemaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitSchemaComboBox.FormattingEnabled = true;
            this.unitSchemaComboBox.Location = new System.Drawing.Point(12, 50);
            this.unitSchemaComboBox.Name = "unitSchemaComboBox";
            this.unitSchemaComboBox.Size = new System.Drawing.Size(136, 21);
            this.unitSchemaComboBox.TabIndex = 4;
            this.unitSchemaComboBox.SelectedValueChanged += new System.EventHandler(this.unitSchemaComboBox_SelectedValueChanged);
            // 
            // showUSUnitsCheckBox
            // 
            this.showUSUnitsCheckBox.AutoSize = true;
            this.showUSUnitsCheckBox.Location = new System.Drawing.Point(12, 6);
            this.showUSUnitsCheckBox.Name = "showUSUnitsCheckBox";
            this.showUSUnitsCheckBox.Size = new System.Drawing.Size(118, 17);
            this.showUSUnitsCheckBox.TabIndex = 3;
            this.showUSUnitsCheckBox.Text = "Show also US units";
            this.showUSUnitsCheckBox.UseVisualStyleBackColor = true;
            this.showUSUnitsCheckBox.CheckedChanged += new System.EventHandler(this.showUSUnitsCheckBox_CheckedChanged);
            // 
            // topPanel
            // 
            this.topPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.topPanel.Controls.Add(this.splitContainer1);
            this.topPanel.Location = new System.Drawing.Point(12, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(679, 373);
            this.topPanel.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(679, 373);
            this.splitContainer1.SplitterDistance = 137;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LengthAreaTimePanel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(679, 127);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Length, Area, Time";
            // 
            // LengthAreaTimePanel
            // 
            this.LengthAreaTimePanel.AutoScroll = true;
            this.LengthAreaTimePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LengthAreaTimePanel.Location = new System.Drawing.Point(3, 16);
            this.LengthAreaTimePanel.Name = "LengthAreaTimePanel";
            this.LengthAreaTimePanel.Size = new System.Drawing.Size(673, 108);
            this.LengthAreaTimePanel.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(679, 137);
            this.splitContainer2.SplitterDistance = 338;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.massAndVolumePanel);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(338, 137);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Mass and Volume";
            // 
            // massAndVolumePanel
            // 
            this.massAndVolumePanel.AutoScroll = true;
            this.massAndVolumePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.massAndVolumePanel.Location = new System.Drawing.Point(3, 16);
            this.massAndVolumePanel.Name = "massAndVolumePanel";
            this.massAndVolumePanel.Size = new System.Drawing.Size(332, 118);
            this.massAndVolumePanel.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer3.Size = new System.Drawing.Size(679, 232);
            this.splitContainer3.SplitterDistance = 101;
            this.splitContainer3.TabIndex = 1;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer4.Size = new System.Drawing.Size(679, 101);
            this.splitContainer4.SplitterDistance = 338;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RhoEtaPanel);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 101);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "rho, eta";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.GasPanel);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(337, 101);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gas";
            // 
            // RhoEtaPanel
            // 
            this.RhoEtaPanel.AutoScroll = true;
            this.RhoEtaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RhoEtaPanel.Location = new System.Drawing.Point(3, 16);
            this.RhoEtaPanel.Name = "RhoEtaPanel";
            this.RhoEtaPanel.Size = new System.Drawing.Size(332, 82);
            this.RhoEtaPanel.TabIndex = 0;
            // 
            // GasPanel
            // 
            this.GasPanel.AutoScroll = true;
            this.GasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GasPanel.Location = new System.Drawing.Point(3, 16);
            this.GasPanel.Name = "GasPanel";
            this.GasPanel.Size = new System.Drawing.Size(331, 82);
            this.GasPanel.TabIndex = 0;
            // 
            // fmUnitsOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 486);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "fmUnitsOptions";
            this.Text = "UnitsOptions";
            this.Load += new System.EventHandler(this.UnitsOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel QPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox showUSUnitsCheckBox;
        private System.Windows.Forms.ComboBox unitSchemaComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel LengthAreaTimePanel;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Panel massAndVolumePanel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel RhoEtaPanel;
        private System.Windows.Forms.Panel GasPanel;
    }
}