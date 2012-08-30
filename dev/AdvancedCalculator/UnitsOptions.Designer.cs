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
            this.panel1 = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.unitSchemaComboBox = new System.Windows.Forms.ComboBox();
            this.showUSUnitsCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 562);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 543);
            this.panel1.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(236, 109);
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
            this.button1.Location = new System.Drawing.Point(317, 109);
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
            this.panel2.Location = new System.Drawing.Point(0, 562);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(404, 144);
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
            // fmUnitsOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 706);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "fmUnitsOptions";
            this.Text = "UnitsOptions";
            this.Load += new System.EventHandler(this.UnitsOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox showUSUnitsCheckBox;
        private System.Windows.Forms.ComboBox unitSchemaComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}