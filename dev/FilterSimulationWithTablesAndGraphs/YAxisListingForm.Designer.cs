namespace FilterSimulationWithTablesAndGraphs
{
    partial class fmYAxisListingForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.assignButton = new System.Windows.Forms.Button();
            this.takeButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.filterTypeGroupComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ad0DpBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.qBigBox_dif = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.DpQpConstBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.qmBigBox_dif = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.massBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.qmSmallBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.hcBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.qSmallBox_dif = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.volumeBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.qSmallBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.epsKappaBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.qmSmallBox_dif = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.qBigBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.mBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.nTcTfBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.vBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.qmBigBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.sfSrTrBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gasParameters = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.qmDeliquoringBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.qDeliquoringBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.massFlowrateDeliquoringBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.volumeFlowrateDeliquoringBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.massDeliquoringBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.volumeDeliquoringBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.mainDeliquoringBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.materialDeliqouringBox = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.evaporationsParameters = new fmControls.fmCheckedListBoxWithCheckboxes();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.assignButton);
            this.panel1.Controls.Add(this.takeButton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.filterTypeGroupComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 618);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 50);
            this.panel1.TabIndex = 0;
            // 
            // assignButton
            // 
            this.assignButton.Location = new System.Drawing.Point(265, 21);
            this.assignButton.Name = "assignButton";
            this.assignButton.Size = new System.Drawing.Size(98, 23);
            this.assignButton.TabIndex = 3;
            this.assignButton.Text = "Save As Default";
            this.assignButton.UseVisualStyleBackColor = true;
            this.assignButton.Click += new System.EventHandler(this.Button3Click);
            // 
            // takeButton
            // 
            this.takeButton.Location = new System.Drawing.Point(161, 21);
            this.takeButton.Name = "takeButton";
            this.takeButton.Size = new System.Drawing.Size(98, 23);
            this.takeButton.TabIndex = 2;
            this.takeButton.Text = "Load Default";
            this.takeButton.UseVisualStyleBackColor = true;
            this.takeButton.Click += new System.EventHandler(this.takeButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(745, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(664, 21);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter Type – Group:";
            // 
            // filterTypeGroupComboBox
            // 
            this.filterTypeGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterTypeGroupComboBox.FormattingEnabled = true;
            this.filterTypeGroupComboBox.Location = new System.Drawing.Point(18, 21);
            this.filterTypeGroupComboBox.Name = "filterTypeGroupComboBox";
            this.filterTypeGroupComboBox.Size = new System.Drawing.Size(123, 21);
            this.filterTypeGroupComboBox.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 618);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel2Collapsed = true;
            this.splitContainer2.Size = new System.Drawing.Size(832, 618);
            this.splitContainer2.SplitterDistance = 807;
            this.splitContainer2.TabIndex = 23;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(807, 600);
            this.splitContainer1.SplitterDistance = 368;
            this.splitContainer1.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ad0DpBox);
            this.groupBox1.Controls.Add(this.qBigBox_dif);
            this.groupBox1.Controls.Add(this.DpQpConstBox);
            this.groupBox1.Controls.Add(this.qmBigBox_dif);
            this.groupBox1.Controls.Add(this.massBox);
            this.groupBox1.Controls.Add(this.qmSmallBox);
            this.groupBox1.Controls.Add(this.hcBox);
            this.groupBox1.Controls.Add(this.qSmallBox_dif);
            this.groupBox1.Controls.Add(this.volumeBox);
            this.groupBox1.Controls.Add(this.qSmallBox);
            this.groupBox1.Controls.Add(this.epsKappaBox);
            this.groupBox1.Controls.Add(this.qmSmallBox_dif);
            this.groupBox1.Controls.Add(this.qBigBox);
            this.groupBox1.Controls.Add(this.mBox);
            this.groupBox1.Controls.Add(this.nTcTfBox);
            this.groupBox1.Controls.Add(this.vBox);
            this.groupBox1.Controls.Add(this.qmBigBox);
            this.groupBox1.Controls.Add(this.sfSrTrBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 600);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cake Formation";
            // 
            // ad0DpBox
            // 
            this.ad0DpBox.CaptionText = "";
            this.ad0DpBox.Location = new System.Drawing.Point(6, 13);
            this.ad0DpBox.Name = "ad0DpBox";
            this.ad0DpBox.Size = new System.Drawing.Size(106, 85);
            this.ad0DpBox.TabIndex = 15;
            // 
            // qBigBox_dif
            // 
            this.qBigBox_dif.CaptionText = "Q,i";
            this.qBigBox_dif.Location = new System.Drawing.Point(131, 426);
            this.qBigBox_dif.Name = "qBigBox_dif";
            this.qBigBox_dif.Size = new System.Drawing.Size(106, 85);
            this.qBigBox_dif.TabIndex = 9;
            // 
            // DpQpConstBox
            // 
            this.DpQpConstBox.CaptionText = "Qp+Dp=Const";
            this.DpQpConstBox.Location = new System.Drawing.Point(6, 486);
            this.DpQpConstBox.Name = "DpQpConstBox";
            this.DpQpConstBox.Size = new System.Drawing.Size(106, 111);
            this.DpQpConstBox.TabIndex = 21;
            // 
            // qmBigBox_dif
            // 
            this.qmBigBox_dif.CaptionText = "Qm,i";
            this.qmBigBox_dif.Location = new System.Drawing.Point(243, 426);
            this.qmBigBox_dif.Name = "qmBigBox_dif";
            this.qmBigBox_dif.Size = new System.Drawing.Size(106, 85);
            this.qmBigBox_dif.TabIndex = 10;
            // 
            // massBox
            // 
            this.massBox.CaptionText = "Mass";
            this.massBox.Location = new System.Drawing.Point(243, 13);
            this.massBox.Name = "massBox";
            this.massBox.Size = new System.Drawing.Size(106, 85);
            this.massBox.TabIndex = 1;
            // 
            // qmSmallBox
            // 
            this.qmSmallBox.CaptionText = "qm";
            this.qmSmallBox.Location = new System.Drawing.Point(243, 307);
            this.qmSmallBox.Name = "qmSmallBox";
            this.qmSmallBox.Size = new System.Drawing.Size(106, 85);
            this.qmSmallBox.TabIndex = 8;
            // 
            // hcBox
            // 
            this.hcBox.CaptionText = "hc";
            this.hcBox.Location = new System.Drawing.Point(6, 264);
            this.hcBox.Name = "hcBox";
            this.hcBox.Size = new System.Drawing.Size(106, 71);
            this.hcBox.TabIndex = 19;
            // 
            // qSmallBox_dif
            // 
            this.qSmallBox_dif.CaptionText = "q,i";
            this.qSmallBox_dif.Location = new System.Drawing.Point(131, 517);
            this.qSmallBox_dif.Name = "qSmallBox_dif";
            this.qSmallBox_dif.Size = new System.Drawing.Size(106, 85);
            this.qSmallBox_dif.TabIndex = 13;
            // 
            // volumeBox
            // 
            this.volumeBox.CaptionText = "Volume";
            this.volumeBox.Location = new System.Drawing.Point(131, 13);
            this.volumeBox.Name = "volumeBox";
            this.volumeBox.Size = new System.Drawing.Size(106, 85);
            this.volumeBox.TabIndex = 2;
            // 
            // qSmallBox
            // 
            this.qSmallBox.CaptionText = "q";
            this.qSmallBox.Location = new System.Drawing.Point(131, 307);
            this.qSmallBox.Name = "qSmallBox";
            this.qSmallBox.Size = new System.Drawing.Size(106, 85);
            this.qSmallBox.TabIndex = 7;
            // 
            // epsKappaBox
            // 
            this.epsKappaBox.CaptionText = "";
            this.epsKappaBox.Location = new System.Drawing.Point(6, 341);
            this.epsKappaBox.Name = "epsKappaBox";
            this.epsKappaBox.Size = new System.Drawing.Size(106, 148);
            this.epsKappaBox.TabIndex = 18;
            // 
            // qmSmallBox_dif
            // 
            this.qmSmallBox_dif.CaptionText = "qm,i";
            this.qmSmallBox_dif.Location = new System.Drawing.Point(243, 517);
            this.qmSmallBox_dif.Name = "qmSmallBox_dif";
            this.qmSmallBox_dif.Size = new System.Drawing.Size(106, 85);
            this.qmSmallBox_dif.TabIndex = 14;
            // 
            // qBigBox
            // 
            this.qBigBox.CaptionText = "Q";
            this.qBigBox.Location = new System.Drawing.Point(131, 216);
            this.qBigBox.Name = "qBigBox";
            this.qBigBox.Size = new System.Drawing.Size(106, 85);
            this.qBigBox.TabIndex = 3;
            // 
            // mBox
            // 
            this.mBox.CaptionText = "m";
            this.mBox.Location = new System.Drawing.Point(243, 104);
            this.mBox.Name = "mBox";
            this.mBox.Size = new System.Drawing.Size(106, 85);
            this.mBox.TabIndex = 6;
            // 
            // nTcTfBox
            // 
            this.nTcTfBox.CaptionText = "";
            this.nTcTfBox.Location = new System.Drawing.Point(6, 195);
            this.nTcTfBox.Name = "nTcTfBox";
            this.nTcTfBox.Size = new System.Drawing.Size(106, 63);
            this.nTcTfBox.TabIndex = 17;
            // 
            // vBox
            // 
            this.vBox.CaptionText = "v";
            this.vBox.Location = new System.Drawing.Point(131, 104);
            this.vBox.Name = "vBox";
            this.vBox.Size = new System.Drawing.Size(106, 85);
            this.vBox.TabIndex = 5;
            // 
            // qmBigBox
            // 
            this.qmBigBox.CaptionText = "Qm";
            this.qmBigBox.Location = new System.Drawing.Point(243, 216);
            this.qmBigBox.Name = "qmBigBox";
            this.qmBigBox.Size = new System.Drawing.Size(106, 85);
            this.qmBigBox.TabIndex = 4;
            // 
            // sfSrTrBox
            // 
            this.sfSrTrBox.CaptionText = "";
            this.sfSrTrBox.Location = new System.Drawing.Point(6, 121);
            this.sfSrTrBox.Name = "sfSrTrBox";
            this.sfSrTrBox.Size = new System.Drawing.Size(106, 68);
            this.sfSrTrBox.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gasParameters);
            this.groupBox2.Controls.Add(this.qmDeliquoringBox);
            this.groupBox2.Controls.Add(this.qDeliquoringBox);
            this.groupBox2.Controls.Add(this.massFlowrateDeliquoringBox);
            this.groupBox2.Controls.Add(this.volumeFlowrateDeliquoringBox);
            this.groupBox2.Controls.Add(this.massDeliquoringBox);
            this.groupBox2.Controls.Add(this.volumeDeliquoringBox);
            this.groupBox2.Controls.Add(this.mainDeliquoringBox);
            this.groupBox2.Controls.Add(this.materialDeliqouringBox);
            this.groupBox2.Controls.Add(this.evaporationsParameters);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 600);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deliquoring";
            // 
            // gasParameters
            // 
            this.gasParameters.CaptionText = "Gas";
            this.gasParameters.Location = new System.Drawing.Point(145, 195);
            this.gasParameters.Name = "gasParameters";
            this.gasParameters.Size = new System.Drawing.Size(125, 111);
            this.gasParameters.TabIndex = 22;
            // 
            // qmDeliquoringBox
            // 
            this.qmDeliquoringBox.CaptionText = "qm";
            this.qmDeliquoringBox.Location = new System.Drawing.Point(293, 516);
            this.qmDeliquoringBox.Name = "qmDeliquoringBox";
            this.qmDeliquoringBox.Size = new System.Drawing.Size(125, 86);
            this.qmDeliquoringBox.TabIndex = 30;
            // 
            // qDeliquoringBox
            // 
            this.qDeliquoringBox.CaptionText = "q";
            this.qDeliquoringBox.Location = new System.Drawing.Point(145, 516);
            this.qDeliquoringBox.Name = "qDeliquoringBox";
            this.qDeliquoringBox.Size = new System.Drawing.Size(125, 86);
            this.qDeliquoringBox.TabIndex = 29;
            // 
            // massFlowrateDeliquoringBox
            // 
            this.massFlowrateDeliquoringBox.CaptionText = "Mass Flowrate";
            this.massFlowrateDeliquoringBox.Location = new System.Drawing.Point(293, 424);
            this.massFlowrateDeliquoringBox.Name = "massFlowrateDeliquoringBox";
            this.massFlowrateDeliquoringBox.Size = new System.Drawing.Size(125, 86);
            this.massFlowrateDeliquoringBox.TabIndex = 28;
            // 
            // volumeFlowrateDeliquoringBox
            // 
            this.volumeFlowrateDeliquoringBox.CaptionText = "Volume Flowrate";
            this.volumeFlowrateDeliquoringBox.Location = new System.Drawing.Point(145, 424);
            this.volumeFlowrateDeliquoringBox.Name = "volumeFlowrateDeliquoringBox";
            this.volumeFlowrateDeliquoringBox.Size = new System.Drawing.Size(125, 86);
            this.volumeFlowrateDeliquoringBox.TabIndex = 27;
            // 
            // massDeliquoringBox
            // 
            this.massDeliquoringBox.CaptionText = "Mass";
            this.massDeliquoringBox.Location = new System.Drawing.Point(293, 90);
            this.massDeliquoringBox.Name = "massDeliquoringBox";
            this.massDeliquoringBox.Size = new System.Drawing.Size(125, 71);
            this.massDeliquoringBox.TabIndex = 26;
            // 
            // volumeDeliquoringBox
            // 
            this.volumeDeliquoringBox.CaptionText = "Volume";
            this.volumeDeliquoringBox.Location = new System.Drawing.Point(293, 13);
            this.volumeDeliquoringBox.Name = "volumeDeliquoringBox";
            this.volumeDeliquoringBox.Size = new System.Drawing.Size(125, 71);
            this.volumeDeliquoringBox.TabIndex = 25;
            // 
            // mainDeliquoringBox
            // 
            this.mainDeliquoringBox.CaptionText = "Main Parameters";
            this.mainDeliquoringBox.Location = new System.Drawing.Point(145, 13);
            this.mainDeliquoringBox.Name = "mainDeliquoringBox";
            this.mainDeliquoringBox.Size = new System.Drawing.Size(125, 176);
            this.mainDeliquoringBox.TabIndex = 24;
            // 
            // materialDeliqouringBox
            // 
            this.materialDeliqouringBox.CaptionText = "Deliquoring Material";
            this.materialDeliqouringBox.Location = new System.Drawing.Point(6, 13);
            this.materialDeliqouringBox.Name = "materialDeliqouringBox";
            this.materialDeliqouringBox.Size = new System.Drawing.Size(125, 355);
            this.materialDeliqouringBox.TabIndex = 21;
            // 
            // evaporationsParameters
            // 
            this.evaporationsParameters.CaptionText = "Evaporation";
            this.evaporationsParameters.Location = new System.Drawing.Point(6, 367);
            this.evaporationsParameters.Name = "evaporationsParameters";
            this.evaporationsParameters.Size = new System.Drawing.Size(125, 235);
            this.evaporationsParameters.TabIndex = 23;
            // 
            // fmYAxisListingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 668);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "fmYAxisListingForm";
            this.Text = "Parameters to Display";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel panel2;
        private fmControls.fmCheckedListBoxWithCheckboxes massBox;
        private fmControls.fmCheckedListBoxWithCheckboxes volumeBox;
        private fmControls.fmCheckedListBoxWithCheckboxes qmSmallBox;
        private fmControls.fmCheckedListBoxWithCheckboxes qSmallBox;
        private fmControls.fmCheckedListBoxWithCheckboxes mBox;
        private fmControls.fmCheckedListBoxWithCheckboxes vBox;
        private fmControls.fmCheckedListBoxWithCheckboxes qmBigBox;
        private fmControls.fmCheckedListBoxWithCheckboxes qBigBox;
        private fmControls.fmCheckedListBoxWithCheckboxes qmSmallBox_dif;
        private fmControls.fmCheckedListBoxWithCheckboxes qSmallBox_dif;
        private fmControls.fmCheckedListBoxWithCheckboxes qmBigBox_dif;
        private fmControls.fmCheckedListBoxWithCheckboxes qBigBox_dif;
        private fmControls.fmCheckedListBoxWithCheckboxes epsKappaBox;
        private fmControls.fmCheckedListBoxWithCheckboxes nTcTfBox;
        private fmControls.fmCheckedListBoxWithCheckboxes sfSrTrBox;
        private fmControls.fmCheckedListBoxWithCheckboxes ad0DpBox;
        private fmControls.fmCheckedListBoxWithCheckboxes hcBox;
        private fmControls.fmCheckedListBoxWithCheckboxes DpQpConstBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private fmControls.fmCheckedListBoxWithCheckboxes materialDeliqouringBox;
        private fmControls.fmCheckedListBoxWithCheckboxes evaporationsParameters;
        private fmControls.fmCheckedListBoxWithCheckboxes gasParameters;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button assignButton;
        private System.Windows.Forms.Button takeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox filterTypeGroupComboBox;
        private fmControls.fmCheckedListBoxWithCheckboxes qDeliquoringBox;
        private fmControls.fmCheckedListBoxWithCheckboxes massFlowrateDeliquoringBox;
        private fmControls.fmCheckedListBoxWithCheckboxes volumeFlowrateDeliquoringBox;
        private fmControls.fmCheckedListBoxWithCheckboxes massDeliquoringBox;
        private fmControls.fmCheckedListBoxWithCheckboxes volumeDeliquoringBox;
        private fmControls.fmCheckedListBoxWithCheckboxes mainDeliquoringBox;
        private fmControls.fmCheckedListBoxWithCheckboxes qmDeliquoringBox;
    }
}