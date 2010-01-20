using System;
using System.Windows.Forms;

namespace AdvancedCalculator
{
    public partial class AdvancedCalculator : Form
    {
        public AdvancedCalculator()
        {
            InitializeComponent();
        }

        private void AdvancedCalculator_Resize(object sender, EventArgs e)
        {
            //filterSimulation1.Width = ClientSize.Width - filterSimulation1.Left - 8;
            //filterSimulation1.Height = ClientSize.Height - filterSimulation1.Top - 8;
        }

        private void unitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitsOptions uoForm = new UnitsOptions();
            uoForm.ShowDialog();
            //filterSimulation1.UpdateAll();
            filterSimulationWithTablesAndGraphs1.UpdateAll();
        }

        private void precisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DigitsOptions doForm = new DigitsOptions();
            doForm.ShowDialog();
            //filterSimulation1.UpdateAll();
            filterSimulationWithTablesAndGraphs1.UpdateAll();
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //filterSimulation1.SaveAll();
            filterSimulationWithTablesAndGraphs1.SaveAll();
        }

        private void rangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterSimulation.ParameterIntervalOption proForm = new FilterSimulation.ParameterIntervalOption();
            proForm.ShowDialog();
            //filterSimulation1.UpdateAll();
            filterSimulationWithTablesAndGraphs1.UpdateAll();
        }

        private void AdvancedCalculator_Load(object sender, EventArgs e)
        {
           Text = string.Format("AdvancedCalculator (v.{0})", Config.Version);
        }
    }
}