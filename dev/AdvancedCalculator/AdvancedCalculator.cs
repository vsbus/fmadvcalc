using System;
using System.IO;
using System.Windows.Forms;
using FilterSimulationWithTablesAndGraphs;
using Microsoft.Win32;

namespace AdvancedCalculator
{
    public partial class fmAdvancedCalculator : Form
    {
        private string m_Caption = string.Format("FILTRAPLUS (v.{0})", Config.Version);

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
            if (m_currentFilename != null)
            {
                SaveOnDisk(m_currentFilename);
            }
            else
            {
                SaveOnDisk();
            }
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
            string defaultFilename = Directory.GetCurrentDirectory() + "\\fmdata.dat";
            object regValue = Registry.GetValue(
                @"HKEY_CURRENT_USER\Software\NICIFOS\FiltraPlus",
                "LastFile",
                defaultFilename);
            string fileName = regValue == null ? defaultFilename : regValue.ToString();
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
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Data files (*.dat)|*.dat";
            if (m_currentFilename != null)
            {
                saveDialog.FileName = m_currentFilename;
                string path = m_currentFilename.Substring(0, m_currentFilename.LastIndexOf('\\'));
                saveDialog.InitialDirectory = path;
            }
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                SaveOnDisk(saveDialog.FileName);
                Text = m_Caption + " [" + saveDialog.FileName + "]";
                m_currentFilename = saveDialog.FileName;
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
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "Data files (*.dat)|*.dat";
            if (m_currentFilename != null)
            {
                openDialog.FileName = m_currentFilename;
                string path = m_currentFilename.Substring(0, m_currentFilename.LastIndexOf('\\'));
                openDialog.InitialDirectory = path;
            }
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                LoadFromDisk(openDialog.FileName);
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

            try
            {
                m_currentFilename = fileName;
                filterSimulationWithTablesAndGraphs1.Deserialize(input);
                Text = m_Caption + " [" + fileName + "]";
            }
            catch (Exception)
            {
                MessageBox.Show("File " + m_currentFilename + " has wrong format and impossible to open", "Error");
                m_currentFilename = null;
                Text = m_Caption;
            }

            input.Close();
        }

        private void fmAdvancedCalculator_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (filterSimulationWithTablesAndGraphs1.IsModified())
            {
                DialogResult dres = MessageBox.Show("Would you like to save data before exit?", "Confirmation",
                                                    MessageBoxButtons.YesNo);
                if (dres == DialogResult.Yes)
                {
                    if (m_currentFilename != null)
                    {
                        SaveOnDisk(m_currentFilename);
                    }
                    else
                    {
                        SaveOnDisk();
                    }
                }
                if (m_currentFilename != null)
                {
                    Registry.SetValue(
                        @"HKEY_CURRENT_USER\Software\NICIFOS\FiltraPlus",
                        "LastFile",
                        m_currentFilename,
                        RegistryValueKind.String);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}