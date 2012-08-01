namespace FilterSimulation
{
    partial class fmParameterIntervalOption
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.MaterialParametersGrid = new FilterSimulation.TableWithParameterRanges();
            this.CakeFormationGrid = new FilterSimulation.TableWithParameterRanges();
            this.deliquoringMaterialParameterGrid = new FilterSimulation.TableWithParameterRanges();
            this.deliquoringSettingsParametersGrid = new FilterSimulation.TableWithParameterRanges();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(483, 6);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 475);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 37);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(564, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(651, 475);
            this.splitContainer1.SplitterDistance = 322;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.MaterialParametersGrid);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.CakeFormationGrid);
            this.splitContainer2.Size = new System.Drawing.Size(322, 475);
            this.splitContainer2.SplitterDistance = 260;
            this.splitContainer2.TabIndex = 3;
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
            this.splitContainer3.Panel1.Controls.Add(this.deliquoringMaterialParameterGrid);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.deliquoringSettingsParametersGrid);
            this.splitContainer3.Size = new System.Drawing.Size(325, 475);
            this.splitContainer3.SplitterDistance = 260;
            this.splitContainer3.TabIndex = 2;
            // 
            // MaterialParametersGrid
            // 
            this.MaterialParametersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaterialParametersGrid.Location = new System.Drawing.Point(0, 0);
            this.MaterialParametersGrid.Name = "MaterialParametersGrid";
            this.MaterialParametersGrid.Size = new System.Drawing.Size(322, 260);
            this.MaterialParametersGrid.TabIndex = 1;
            // 
            // CakeFormationGrid
            // 
            this.CakeFormationGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CakeFormationGrid.Location = new System.Drawing.Point(0, 0);
            this.CakeFormationGrid.Name = "CakeFormationGrid";
            this.CakeFormationGrid.Size = new System.Drawing.Size(322, 211);
            this.CakeFormationGrid.TabIndex = 2;
            // 
            // deliquoringMaterialParameterGrid
            // 
            this.deliquoringMaterialParameterGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deliquoringMaterialParameterGrid.Location = new System.Drawing.Point(0, 0);
            this.deliquoringMaterialParameterGrid.Name = "deliquoringMaterialParameterGrid";
            this.deliquoringMaterialParameterGrid.Size = new System.Drawing.Size(325, 260);
            this.deliquoringMaterialParameterGrid.TabIndex = 0;
            // 
            // deliquoringSettingsParametersGrid
            // 
            this.deliquoringSettingsParametersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deliquoringSettingsParametersGrid.Location = new System.Drawing.Point(0, 0);
            this.deliquoringSettingsParametersGrid.Name = "deliquoringSettingsParametersGrid";
            this.deliquoringSettingsParametersGrid.Size = new System.Drawing.Size(325, 211);
            this.deliquoringSettingsParametersGrid.TabIndex = 1;
            // 
            // fmParameterIntervalOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 512);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "fmParameterIntervalOption";
            this.Text = "ParameterIntervalOption";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private TableWithParameterRanges CakeFormationGrid;
        private TableWithParameterRanges MaterialParametersGrid;
        private TableWithParameterRanges deliquoringSettingsParametersGrid;
        private TableWithParameterRanges deliquoringMaterialParameterGrid;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;



    }
}