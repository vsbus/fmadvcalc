using System;
using System.IO;
using System.Windows.Forms;
using FilterSimulationWithTablesAndGraphs;

namespace AdvancedCalculator
{
    public partial class fmAdvancedCalculator : Form
    {
        private string m_Caption = string.Format("AdvancedCalculator (v.{0})", Config.Version);

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
            Text = m_Caption;
            string fileName = Directory.GetCurrentDirectory() + "\\fmdata.dat";
            LoadFromDisk(fileName);
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

        private void SAveondiskToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveOnDisk();
        }

        private void SaveOnDisk()
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Data files (*.dat)|*.dat";
            if (!m_currentFilename.EndsWith("fmdata.dat"))
            {
                sfd.FileName = m_currentFilename;
                string path = m_currentFilename.Substring(0, m_currentFilename.LastIndexOf('\\'));
                sfd.InitialDirectory = path;
            }
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveOnDisk(sfd.FileName);
                Text = m_Caption + " [" + sfd.FileName + "]";
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
            var ofd = new OpenFileDialog();
            ofd.Filter = "Data files (*.dat)|*.dat";   
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadFromDisk(ofd.FileName);
            }
        }

        private string m_currentFilename;
        private void LoadFromDisk(string fileName)
        {
            TextReader input = null;
            try
            {
                input = new StreamReader(fileName);
            }
            catch (Exception)
            {
                return;
            }

            //try
            {
                m_currentFilename = fileName;
                filterSimulationWithTablesAndGraphs1.Deserialize(input);
                Text = m_Caption + " [" + fileName + "]";
            }
            /*
            catch (Exception e)
            {
                ;
            }
             * */

            input.Close();
        }

        private void fmAdvancedCalculator_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dres = MessageBox.Show("Would you like to save data before exit?", "Confirmation", MessageBoxButtons.YesNo);
            if (dres == DialogResult.Yes)
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