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
            LoadFromDisk("fmdata.dat");
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
            SaveOnDisk();
        }

        private void SaveOnDisk()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            sfd.Filter = "Data files (*.dat)|*.dat";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveOnDisk(sfd.FileName);
                SaveOnDisk("fmdata.dat");
            }
        }

        private void SaveOnDisk(string fileName)
        {
            TextWriter output = new StreamWriter(fileName);
            filterSimulationWithTablesAndGraphs1.Serialize(output);
            output.Close();
        }

        private void lOADFROMDISKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            ofd.Filter = "Data files (*.dat)|*.dat";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadFromDisk(ofd.FileName);
            }
        }

        private void LoadFromDisk(string fileName)
        {
            TextReader input = null;
            try
            {
                input = new StreamReader(fileName);
            }
            catch (Exception e)
            {
                return;
            }

            try
            {
                filterSimulationWithTablesAndGraphs1.Deserialize(input);
            }
            catch (Exception e)
            {
                ;
            }

            input.Close();
        }

        private void fmAdvancedCalculator_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dres = MessageBox.Show("Do you want to exit without saving?", "Confirmation", MessageBoxButtons.YesNo);
            if (dres == DialogResult.No)
            {
                SaveOnDisk();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}