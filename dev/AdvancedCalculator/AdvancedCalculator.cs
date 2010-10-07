using System;
using System.IO;
using System.Windows.Forms;
using FilterSimulationWithTablesAndGraphs;

namespace AdvancedCalculator
{
    public partial class fmAdvancedCalculator : Form
    {
        public fmAdvancedCalculator()
        {
            InitializeComponent();
        }

        // ReSharper disable InconsistentNaming
        private void unitsToolStripMenuItem_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            var uoForm = new fmUnitsOptions();
            uoForm.ShowDialog();
            filterSimulationWithTablesAndGraphs1.UpdateAll();
        }

        // ReSharper disable InconsistentNaming
        private void precisionToolStripMenuItem_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            var doForm = new fmDigitsOptions();
            doForm.ShowDialog();
            filterSimulationWithTablesAndGraphs1.UpdateAll();
        }

        // ReSharper disable InconsistentNaming
        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            filterSimulationWithTablesAndGraphs1.SaveAll();
        }

        // ReSharper disable InconsistentNaming
        private void rangesToolStripMenuItem_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            var proForm = new FilterSimulation.fmParameterIntervalOption();
            proForm.ShowDialog();
            filterSimulationWithTablesAndGraphs1.UpdateAll();
        }

        // ReSharper disable InconsistentNaming
        private void AdvancedCalculator_Load(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            Text = string.Format("AdvancedCalculator (v.{0})", Config.Version);
        }

        // ReSharper disable InconsistentNaming
        private void yaxisParametersToolStripMenuItem_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            var yalForm = new fmYAxisListingForm();
            yalForm.CheckItems(filterSimulationWithTablesAndGraphs1.parametersToDisplay);
            if (yalForm.ShowDialog() == DialogResult.OK)
            {
                filterSimulationWithTablesAndGraphs1.parametersToDisplay = yalForm.GetCheckedItems();
                filterSimulationWithTablesAndGraphs1.UpdateAll();
            }
        }

        private void sAVEONDISKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextWriter output = new StreamWriter("fmdata.dat");
            filterSimulationWithTablesAndGraphs1.Serialize(output);
            output.Close();
        }
    }
}