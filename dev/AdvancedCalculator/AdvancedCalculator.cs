using System;
using System.IO;
using System.Windows.Forms;
using FilterSimulation.fmFilterObjects;
using FilterSimulationWithTablesAndGraphs;
using Microsoft.Win32;
using System.Xml;

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
            object regValue = Registry.GetValue(
                @"HKEY_CURRENT_USER\Software\NICIFOS\FiltraPlus",
                "LastFile",
                "");
            if (regValue != null)
            {
                LoadFromDisk(regValue.ToString());
            }
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

        private void SaveOnDiskToolStripMenuItemClick(object sender, EventArgs e)
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
            var xmlSettings = new XmlWriterSettings()
            {
                Indent = true
            };
            XmlWriter writer = XmlWriter.Create(fileName + ".xml", xmlSettings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Filtraplus_Data_File");
            filterSimulationWithTablesAndGraphs1.Serialize(writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private void LoadFromDiskToolStripMenuItem_Click(object sender, EventArgs e)
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
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName + ".xml");

                m_currentFilename = fileName;
                filterSimulationWithTablesAndGraphs1.Deserialize(doc.SelectSingleNode("Filtraplus_Data_File"));
                Text = m_Caption + " [" + fileName + "]";
            }
            catch (Exception)
            {
                MessageBox.Show("File " + m_currentFilename + " has error in format and impossible to open", "Error");
                m_currentFilename = null;
                Text = m_Caption;
            }
        }

        private bool CheckDatFileVersion(string fileName)
        {
            throw new Exception("");
            //bool isValid = false;

            //try
            //{
            //    XmlReader reader = new StreamReader(fileName);
            //    isValid = fmFilterSimSolution.CheckDatFileVersion(input);
            //}
            //catch (Exception)
            //{
            //}

            //if (!isValid)
            //{
            //    MessageBox.Show("File " + fileName + " was created with other program version with different format and is impossible to open.", "Open File Error");
            //}
            //return isValid;
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}