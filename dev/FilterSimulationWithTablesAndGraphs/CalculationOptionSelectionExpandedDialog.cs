using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FilterSimulationWithTablesAndGraphs
{
    public partial class CalculationOptionSelectionExpandedDialog : FilterSimulation.CalculationOptionSelectionDialog
    {
        public CalculationOptionSelectionExpandedDialog()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = !radioButton2.Checked;
        }
    }
}

