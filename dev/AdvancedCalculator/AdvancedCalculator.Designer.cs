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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOADFROMDISKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAVEONDISKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rangesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.parametersToDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculationPrecisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterSimulationWithTablesAndGraphs1 = new FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.calculationPrecisionToolStripMenuItem,
            this.parametersToDisplayToolStripMenuItem,
            this.unitsToolStripMenuItem1,
            this.rangesToolStripMenuItem1,
            this.calculatorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(766, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // lOADFROMDISKToolStripMenuItem
            // 
            this.lOADFROMDISKToolStripMenuItem.Name = "lOADFROMDISKToolStripMenuItem";
            this.lOADFROMDISKToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.lOADFROMDISKToolStripMenuItem.Text = "Open...";
            this.lOADFROMDISKToolStripMenuItem.Click += new System.EventHandler(this.LoadFromDiskToolStripMenuItemClick);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveAllToolStripMenuItem.Text = "Save";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // sAVEONDISKToolStripMenuItem
            // 
            this.sAVEONDISKToolStripMenuItem.Name = "sAVEONDISKToolStripMenuItem";
            this.sAVEONDISKToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.sAVEONDISKToolStripMenuItem.Text = "Save As...";
            this.sAVEONDISKToolStripMenuItem.Click += new System.EventHandler(this.SaveOnDiskToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // unitsToolStripMenuItem1
            // 
            this.unitsToolStripMenuItem1.Name = "unitsToolStripMenuItem1";
            this.unitsToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.unitsToolStripMenuItem1.Text = "Units";
            this.unitsToolStripMenuItem1.Click += new System.EventHandler(this.unitsToolStripMenuItem1_Click);
            // 
            // rangesToolStripMenuItem1
            // 
            this.rangesToolStripMenuItem1.Name = "rangesToolStripMenuItem1";
            this.rangesToolStripMenuItem1.Size = new System.Drawing.Size(55, 20);
            this.rangesToolStripMenuItem1.Text = "Ranges";
            this.rangesToolStripMenuItem1.Click += new System.EventHandler(this.RangesToolStripMenuItem1Click);
            // 
            // parametersToDisplayToolStripMenuItem
            // 
            this.parametersToDisplayToolStripMenuItem.Name = "parametersToDisplayToolStripMenuItem";
            this.parametersToDisplayToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.parametersToDisplayToolStripMenuItem.Text = "Parameters to display";
            this.parametersToDisplayToolStripMenuItem.Click += new System.EventHandler(this.ParametersToDisplayToolStripMenuItemClick);
            // 
            // calculatorToolStripMenuItem
            // 
            this.calculatorToolStripMenuItem.Name = "calculatorToolStripMenuItem";
            this.calculatorToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.calculatorToolStripMenuItem.Text = "Calculator";
            this.calculatorToolStripMenuItem.Click += new System.EventHandler(this.calculatorToolStripMenuItem_Click);
            // 
            // calculationPrecisionToolStripMenuItem
            // 
            this.calculationPrecisionToolStripMenuItem.Name = "calculationPrecisionToolStripMenuItem";
            this.calculationPrecisionToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.calculationPrecisionToolStripMenuItem.Text = "Calculation Precision";
            this.calculationPrecisionToolStripMenuItem.Click += new System.EventHandler(this.calculationPrecisionToolStripMenuItem_Click);
            // 
            // filterSimulationWithTablesAndGraphs1
            // 
            this.filterSimulationWithTablesAndGraphs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterSimulationWithTablesAndGraphs1.Location = new System.Drawing.Point(0, 24);
            this.filterSimulationWithTablesAndGraphs1.Name = "filterSimulationWithTablesAndGraphs1";
            this.filterSimulationWithTablesAndGraphs1.Size = new System.Drawing.Size(766, 645);
            this.filterSimulationWithTablesAndGraphs1.TabIndex = 2;
            // 
            // fmAdvancedCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 669);
            this.Controls.Add(this.filterSimulationWithTablesAndGraphs1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "fmAdvancedCalculator";
            this.Text = "FILTRAPLUS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdvancedCalculatorLoad);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FmAdvancedCalculatorFormClosed);
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
        






    }
}

