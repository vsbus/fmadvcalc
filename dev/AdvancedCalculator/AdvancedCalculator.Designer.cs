namespace AdvancedCalculator
{
    partial class AdvancedCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedCalculator));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.precisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterSimulationWithTablesAndGraphs1 = new FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs();
            this.yaxisParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(931, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAllToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAllToolStripMenuItem.Image")));
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAllToolStripMenuItem.Text = "Save All";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unitsToolStripMenuItem,
            this.precisionToolStripMenuItem,
            this.rangesToolStripMenuItem,
            this.yaxisParametersToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // unitsToolStripMenuItem
            // 
            this.unitsToolStripMenuItem.Name = "unitsToolStripMenuItem";
            this.unitsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.unitsToolStripMenuItem.Text = "Units";
            this.unitsToolStripMenuItem.Click += new System.EventHandler(this.unitsToolStripMenuItem_Click);
            // 
            // precisionToolStripMenuItem
            // 
            this.precisionToolStripMenuItem.Name = "precisionToolStripMenuItem";
            this.precisionToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.precisionToolStripMenuItem.Text = "Precision";
            this.precisionToolStripMenuItem.Click += new System.EventHandler(this.precisionToolStripMenuItem_Click);
            // 
            // rangesToolStripMenuItem
            // 
            this.rangesToolStripMenuItem.Name = "rangesToolStripMenuItem";
            this.rangesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.rangesToolStripMenuItem.Text = "Ranges";
            this.rangesToolStripMenuItem.Click += new System.EventHandler(this.rangesToolStripMenuItem_Click);
            // 
            // filterSimulationWithTablesAndGraphs1
            // 
            this.filterSimulationWithTablesAndGraphs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterSimulationWithTablesAndGraphs1.Location = new System.Drawing.Point(0, 24);
            this.filterSimulationWithTablesAndGraphs1.Name = "filterSimulationWithTablesAndGraphs1";
            this.filterSimulationWithTablesAndGraphs1.Size = new System.Drawing.Size(931, 645);
            this.filterSimulationWithTablesAndGraphs1.TabIndex = 2;
            // 
            // yaxisParametersToolStripMenuItem
            // 
            this.yaxisParametersToolStripMenuItem.Name = "yaxisParametersToolStripMenuItem";
            this.yaxisParametersToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.yaxisParametersToolStripMenuItem.Text = "Y-axis parameters";
            this.yaxisParametersToolStripMenuItem.Click += new System.EventHandler(this.yaxisParametersToolStripMenuItem_Click);
            // 
            // AdvancedCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 669);
            this.Controls.Add(this.filterSimulationWithTablesAndGraphs1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "AdvancedCalculator";
            this.Text = "Advanced Calculator";
            this.Load += new System.EventHandler(this.AdvancedCalculator_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem precisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rangesToolStripMenuItem;
        private FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs filterSimulationWithTablesAndGraphs1;
        private System.Windows.Forms.ToolStripMenuItem yaxisParametersToolStripMenuItem;







    }
}

