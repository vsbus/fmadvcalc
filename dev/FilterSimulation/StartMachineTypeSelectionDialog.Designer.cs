namespace FilterSimulation
{
    partial class StartMachineTypeSelectionDialog
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
            this.serieTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.machineTypesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.projectTextBox = new System.Windows.Forms.TextBox();
            this.suspensionTextBox = new System.Windows.Forms.TextBox();
            this.filtermediumTextBox = new System.Windows.Forms.TextBox();
            this.simulationTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.projectsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspensionsComboBox = new System.Windows.Forms.ComboBox();
            this.mediumsComboBox = new System.Windows.Forms.ComboBox();
            this.SeriesComboBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.materialTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serieTextBox
            // 
            this.serieTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.serieTextBox.Location = new System.Drawing.Point(24, 258);
            this.serieTextBox.Name = "serieTextBox";
            this.serieTextBox.Size = new System.Drawing.Size(324, 20);
            this.serieTextBox.TabIndex = 11;
            this.serieTextBox.Text = "NewSerie";
            this.serieTextBox.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Serie:";
            // 
            // machineTypesComboBox
            // 
            this.machineTypesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.machineTypesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.machineTypesComboBox.FormattingEnabled = true;
            this.machineTypesComboBox.Location = new System.Drawing.Point(24, 148);
            this.machineTypesComboBox.Name = "machineTypesComboBox";
            this.machineTypesComboBox.Size = new System.Drawing.Size(288, 21);
            this.machineTypesComboBox.TabIndex = 9;
            this.machineTypesComboBox.SelectionChangeCommitted += new System.EventHandler(this.machineTypesComboBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Filter Type:";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(273, 347);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(192, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // projectTextBox
            // 
            this.projectTextBox.Location = new System.Drawing.Point(24, 43);
            this.projectTextBox.Name = "projectTextBox";
            this.projectTextBox.Size = new System.Drawing.Size(324, 20);
            this.projectTextBox.TabIndex = 5;
            this.projectTextBox.Text = "NewProject";
            this.projectTextBox.Visible = false;
            // 
            // suspensionTextBox
            // 
            this.suspensionTextBox.Location = new System.Drawing.Point(248, 95);
            this.suspensionTextBox.Name = "suspensionTextBox";
            this.suspensionTextBox.Size = new System.Drawing.Size(100, 20);
            this.suspensionTextBox.TabIndex = 8;
            this.suspensionTextBox.Text = "NewSuspension";
            this.suspensionTextBox.Visible = false;
            // 
            // filtermediumTextBox
            // 
            this.filtermediumTextBox.Location = new System.Drawing.Point(24, 206);
            this.filtermediumTextBox.Name = "filtermediumTextBox";
            this.filtermediumTextBox.Size = new System.Drawing.Size(324, 20);
            this.filtermediumTextBox.TabIndex = 10;
            this.filtermediumTextBox.Text = "NewMedium";
            this.filtermediumTextBox.Visible = false;
            // 
            // simulationTextBox
            // 
            this.simulationTextBox.Location = new System.Drawing.Point(24, 309);
            this.simulationTextBox.Name = "simulationTextBox";
            this.simulationTextBox.Size = new System.Drawing.Size(324, 20);
            this.simulationTextBox.TabIndex = 1;
            this.simulationTextBox.Text = "NewSimulation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Project:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Suspension:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Filter Medium:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Simulation:";
            // 
            // projectsComboBox
            // 
            this.projectsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectsComboBox.FormattingEnabled = true;
            this.projectsComboBox.Location = new System.Drawing.Point(24, 43);
            this.projectsComboBox.Name = "projectsComboBox";
            this.projectsComboBox.Size = new System.Drawing.Size(288, 21);
            this.projectsComboBox.TabIndex = 5;
            // 
            // SuspensionsComboBox
            // 
            this.SuspensionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SuspensionsComboBox.FormattingEnabled = true;
            this.SuspensionsComboBox.Location = new System.Drawing.Point(24, 94);
            this.SuspensionsComboBox.Name = "SuspensionsComboBox";
            this.SuspensionsComboBox.Size = new System.Drawing.Size(288, 21);
            this.SuspensionsComboBox.TabIndex = 7;
            // 
            // mediumsComboBox
            // 
            this.mediumsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mediumsComboBox.FormattingEnabled = true;
            this.mediumsComboBox.Location = new System.Drawing.Point(24, 206);
            this.mediumsComboBox.Name = "mediumsComboBox";
            this.mediumsComboBox.Size = new System.Drawing.Size(288, 21);
            this.mediumsComboBox.TabIndex = 10;
            // 
            // SeriesComboBox
            // 
            this.SeriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SeriesComboBox.FormattingEnabled = true;
            this.SeriesComboBox.Location = new System.Drawing.Point(24, 257);
            this.SeriesComboBox.Name = "SeriesComboBox";
            this.SeriesComboBox.Size = new System.Drawing.Size(288, 21);
            this.SeriesComboBox.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(327, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(21, 21);
            this.button3.TabIndex = 6;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // customerTextBox
            // 
            this.customerTextBox.Location = new System.Drawing.Point(135, 95);
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.Size = new System.Drawing.Size(100, 20);
            this.customerTextBox.TabIndex = 7;
            this.customerTextBox.Text = "NewCust";
            this.customerTextBox.Visible = false;
            // 
            // materialTextBox
            // 
            this.materialTextBox.Location = new System.Drawing.Point(24, 95);
            this.materialTextBox.Name = "materialTextBox";
            this.materialTextBox.Size = new System.Drawing.Size(97, 20);
            this.materialTextBox.TabIndex = 6;
            this.materialTextBox.Text = "NewMaterial";
            this.materialTextBox.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Material:";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(135, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Customer:";
            this.label8.Visible = false;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(327, 95);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(21, 21);
            this.button4.TabIndex = 8;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(327, 206);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(21, 21);
            this.button5.TabIndex = 11;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(327, 258);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(21, 21);
            this.button6.TabIndex = 13;
            this.button6.Text = "+";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(24, 347);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(125, 23);
            this.button7.TabIndex = 4;
            this.button7.Text = "Calculation Settings";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button7_MouseClick);
            // 
            // StartMachineTypeSelectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 382);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.SuspensionsComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.materialTextBox);
            this.Controls.Add(this.customerTextBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.SeriesComboBox);
            this.Controls.Add(this.mediumsComboBox);
            this.Controls.Add(this.projectsComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.simulationTextBox);
            this.Controls.Add(this.filtermediumTextBox);
            this.Controls.Add(this.suspensionTextBox);
            this.Controls.Add(this.projectTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.machineTypesComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serieTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StartMachineTypeSelectionDialog";
            this.Text = "Start Configurations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serieTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox machineTypesComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox projectTextBox;
        private System.Windows.Forms.TextBox suspensionTextBox;
        private System.Windows.Forms.TextBox filtermediumTextBox;
        private System.Windows.Forms.TextBox simulationTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox projectsComboBox;
        private System.Windows.Forms.ComboBox SuspensionsComboBox;
        private System.Windows.Forms.ComboBox mediumsComboBox;
        private System.Windows.Forms.ComboBox SeriesComboBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.TextBox materialTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}