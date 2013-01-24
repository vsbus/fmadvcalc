namespace AdvancedCalculator
{
    partial class fmAdvancedCalculator
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOADFROMDISKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAVEONDISKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewSimulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculationPrecisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametersToDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rangesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filterTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filterSimulationWithTablesAndGraphs1 = new FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.newFileToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.createNewSimulationToolStripMenuItem,
            this.calculationPrecisionToolStripMenuItem,
            this.parametersToDisplayToolStripMenuItem,
            this.unitsToolStripMenuItem1,
            this.rangesToolStripMenuItem1,
            this.filterTypesToolStripMenuItem,
            this.calculatorToolStripMenuItem,
            this.helpStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(843, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.lOADFROMDISKToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.sAVEONDISKToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // lOADFROMDISKToolStripMenuItem
            // 
            this.lOADFROMDISKToolStripMenuItem.Name = "lOADFROMDISKToolStripMenuItem";
            this.lOADFROMDISKToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.lOADFROMDISKToolStripMenuItem.Text = "Open...";
            this.lOADFROMDISKToolStripMenuItem.Click += new System.EventHandler(this.LoadFromDiskToolStripMenuItemClick);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAllToolStripMenuItem.Text = "Save";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // sAVEONDISKToolStripMenuItem
            // 
            this.sAVEONDISKToolStripMenuItem.Name = "sAVEONDISKToolStripMenuItem";
            this.sAVEONDISKToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.sAVEONDISKToolStripMenuItem.Text = "Save As...";
            this.sAVEONDISKToolStripMenuItem.Click += new System.EventHandler(this.SaveOnDiskToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Image = global::AdvancedCalculator.Properties.Resources.page_white;
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.newFileToolStripMenuItem.ToolTipText = "Create New File";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Image = global::AdvancedCalculator.Properties.Resources.folder_open_16;
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.openFileToolStripMenuItem.ToolTipText = "Open an Existing File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::AdvancedCalculator.Properties.Resources.disk;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.saveToolStripMenuItem.ToolTipText = "Save File";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::AdvancedCalculator.Properties.Resources.disk_multiple;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.saveAsToolStripMenuItem.ToolTipText = "Save File As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // createNewSimulationToolStripMenuItem
            // 
            this.createNewSimulationToolStripMenuItem.Name = "createNewSimulationToolStripMenuItem";
            this.createNewSimulationToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.createNewSimulationToolStripMenuItem.Text = "Create new simulation";
            this.createNewSimulationToolStripMenuItem.Click += new System.EventHandler(this.createNewSimulationToolStripMenuItem_Click);
            // 
            // calculationPrecisionToolStripMenuItem
            // 
            this.calculationPrecisionToolStripMenuItem.Name = "calculationPrecisionToolStripMenuItem";
            this.calculationPrecisionToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.calculationPrecisionToolStripMenuItem.Text = "Calculation Precision";
            this.calculationPrecisionToolStripMenuItem.Click += new System.EventHandler(this.calculationPrecisionToolStripMenuItem_Click);
            // 
            // parametersToDisplayToolStripMenuItem
            // 
            this.parametersToDisplayToolStripMenuItem.Name = "parametersToDisplayToolStripMenuItem";
            this.parametersToDisplayToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.parametersToDisplayToolStripMenuItem.Text = "Parameters to display";
            this.parametersToDisplayToolStripMenuItem.Click += new System.EventHandler(this.ParametersToDisplayToolStripMenuItemClick);
            // 
            // unitsToolStripMenuItem1
            // 
            this.unitsToolStripMenuItem1.Name = "unitsToolStripMenuItem1";
            this.unitsToolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            this.unitsToolStripMenuItem1.Text = "Units";
            this.unitsToolStripMenuItem1.Click += new System.EventHandler(this.unitsToolStripMenuItem1_Click);
            // 
            // rangesToolStripMenuItem1
            // 
            this.rangesToolStripMenuItem1.Name = "rangesToolStripMenuItem1";
            this.rangesToolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
            this.rangesToolStripMenuItem1.Text = "Ranges";
            this.rangesToolStripMenuItem1.Click += new System.EventHandler(this.RangesToolStripMenuItem1Click);
            // 
            // filterTypesToolStripMenuItem
            // 
            this.filterTypesToolStripMenuItem.Name = "filterTypesToolStripMenuItem";
            this.filterTypesToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.filterTypesToolStripMenuItem.Text = "Filter Types";
            this.filterTypesToolStripMenuItem.Click += new System.EventHandler(this.filterTypesToolStripMenuItem_Click);
            // 
            // calculatorToolStripMenuItem
            // 
            this.calculatorToolStripMenuItem.Name = "calculatorToolStripMenuItem";
            this.calculatorToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.calculatorToolStripMenuItem.Text = "Calculator";
            this.calculatorToolStripMenuItem.Click += new System.EventHandler(this.calculatorToolStripMenuItem_Click);
            // 
            // helpStripMenuItem1
            // 
            this.helpStripMenuItem1.Name = "helpStripMenuItem1";
            this.helpStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.helpStripMenuItem1.Text = "Help";
            this.helpStripMenuItem1.Click += new System.EventHandler(this.helpStripMenuItem1_Click);
            // 
            // filterSimulationWithTablesAndGraphs1
            // 
            this.filterSimulationWithTablesAndGraphs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterSimulationWithTablesAndGraphs1.Location = new System.Drawing.Point(0, 24);
            this.filterSimulationWithTablesAndGraphs1.Name = "filterSimulationWithTablesAndGraphs1";
            this.filterSimulationWithTablesAndGraphs1.Size = new System.Drawing.Size(843, 645);
            this.filterSimulationWithTablesAndGraphs1.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fmAdvancedCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 669);
            this.Controls.Add(this.filterSimulationWithTablesAndGraphs1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "fmAdvancedCalculator";
            this.Text = "FILTRAPLUS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdvancedCalculatorLoad);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmAdvancedCalculator_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sAVEONDISKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lOADFROMDISKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs filterSimulationWithTablesAndGraphs1;
        private System.Windows.Forms.ToolStripMenuItem unitsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rangesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem parametersToDisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculationPrecisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterTypesToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem createNewSimulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpStripMenuItem1;
        






    }
}

