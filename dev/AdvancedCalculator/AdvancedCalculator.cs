using System;
using System.Windows.Forms;
using FilterSimulationWithTablesAndGraphs;

namespace AdvancedCalculator
{
    public partial class AdvancedCalculator : Form
    {
        public AdvancedCalculator()
        {
            InitializeComponent();
        }

        private void unitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitsOptions uoForm = new UnitsOptions();
            uoForm.ShowDialog();
            filterSimulationWithTablesAndGraphs1.UpdateAll();
        }

        private void precisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DigitsOptions doForm = new DigitsOptions();
            doForm.ShowDialog();
            filterSimulationWithTablesAndGraphs1.UpdateAll();
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filterSimulationWithTablesAndGraphs1.SaveAll();
        }

        private void rangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterSimulation.ParameterIntervalOption proForm = new FilterSimulation.ParameterIntervalOption();
            proForm.ShowDialog();
            filterSimulationWithTablesAndGraphs1.UpdateAll();
        }

        private void AdvancedCalculator_Load(object sender, EventArgs e)
        {
           Text = string.Format("AdvancedCalculator (v.{0})", Config.Version);
        }

        private void yaxisParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmYAxisListingForm yalForm = new fmYAxisListingForm();
            yalForm.CheckItems(filterSimulationWithTablesAndGraphs1.yAxisListParametersToDisplay);
            if (yalForm.ShowDialog() == DialogResult.OK)
            {
                filterSimulationWithTablesAndGraphs1.yAxisListParametersToDisplay = yalForm.GetCheckedItems();
                filterSimulationWithTablesAndGraphs1.UpdateAll();
            }
        }
    }
}