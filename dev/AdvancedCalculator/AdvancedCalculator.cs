using System;
using System.Diagnostics;
using System.Windows.Forms;
using FilterSimulation;
using FilterSimulationWithTablesAndGraphs;
using Microsoft.Win32;
using System.Xml;

namespace AdvancedCalculator
{
    public partial class fmAdvancedCalculator : Form
    {
        private readonly string m_caption = string.Format("FILTRAPLUS (v.{0})", Config.Version);

        public fmAdvancedCalculator()
        {
            InitializeComponent();
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

        private void AdvancedCalculatorLoad(object sender, EventArgs e)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(FiltraplusConfigFilename);
                filterSimulationWithTablesAndGraphs1.DeserializeConfiguration(
                    doc.SelectSingleNode(fmFiltraplusSerializeTags.FiltraplusConfigFile));
            }
            catch
            {
            }

            
            Text = m_caption;
            object regValue = Registry.GetValue(
                @"HKEY_CURRENT_USER\Software\NICIFOS\FiltraPlus",
                "LastFile",
                "");
            if (regValue != null)
            {
                LoadFromDisk(regValue.ToString());
            }
        }

        private void SaveOnDiskToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveOnDisk();
        }

        private void SaveOnDisk()
        {
            var saveDialog = new SaveFileDialog {Filter = @"Data files (*.dat)|*.dat"};
            if (m_currentFilename != null)
            {
                saveDialog.FileName = m_currentFilename;
                string path = m_currentFilename.Substring(0, m_currentFilename.LastIndexOf('\\'));
                saveDialog.InitialDirectory = path;
            }
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                SaveOnDisk(saveDialog.FileName);
                Text = m_caption + @" [" + saveDialog.FileName + @"]";
                m_currentFilename = saveDialog.FileName;
            }
        }

        private static class fmFiltraplusSerializeTags
        {
            public const string FiltraplusDataFile = "Filtraplus_Data_File";
            public const string FiltraplusConfigFile = "Filtraplus_Config_File";
        }

        private void SaveOnDisk(string fileName)
        {
            var xmlSettings = new XmlWriterSettings
                                  {
                                      Indent = true
                                  };
            XmlWriter writer = XmlWriter.Create(fileName, xmlSettings);
            writer.WriteStartDocument();
            writer.WriteStartElement(fmFiltraplusSerializeTags.FiltraplusDataFile);
            filterSimulationWithTablesAndGraphs1.SerializeData(writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private void LoadFromDiskToolStripMenuItemClick(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog {Filter = @"Data files (*.dat)|*.dat"};
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
                var doc = new XmlDocument();
                doc.Load(fileName);

                m_currentFilename = fileName;
                filterSimulationWithTablesAndGraphs1.DeserializeData(
                    doc.SelectSingleNode(fmFiltraplusSerializeTags.FiltraplusDataFile));
                Text = m_caption + @" [" + fileName + @"]";
            }
            catch (Exception)
            {
                MessageBox.Show(@"File " + fileName + @" has an error in format and is impossible to open.", @"Error");
                m_currentFilename = null;
                Text = m_caption;
            }
        }

        private void FmAdvancedCalculatorFormClosed(object sender, FormClosedEventArgs e)
        {
            SaveConfigurations();
            if (filterSimulationWithTablesAndGraphs1.IsModified())
            {
                DialogResult dres = MessageBox.Show(@"Would you like to save data before exit?", @"Confirmation",
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

        private const string FiltraplusConfigFilename = "filtraplus.cfg";

        private void SaveConfigurations()
        {
            var xmlSettings = new XmlWriterSettings
            {
                Indent = true
            };
            XmlWriter writer = XmlWriter.Create(FiltraplusConfigFilename, xmlSettings);
            writer.WriteStartDocument();
            writer.WriteStartElement(fmFiltraplusSerializeTags.FiltraplusConfigFile);
            filterSimulationWithTablesAndGraphs1.SerializeConfiguration(writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void unitsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var uoForm = new fmUnitsOptions();
            uoForm.ShowDialog();
            filterSimulationWithTablesAndGraphs1.UpdateAll();
        }

        private void RangesToolStripMenuItem1Click(object sender, EventArgs e)
        {
            var proForm = new fmParameterIntervalOption();
            proForm.SetRanges(filterSimulationWithTablesAndGraphs1.GetCurrentSerieRanges().Ranges);
            proForm.CheckMachineType(filterSimulationWithTablesAndGraphs1.GetCurrentSerieRanges().AssignedMachineType);
            proForm.SetRangesSchemas(filterSimulationWithTablesAndGraphs1.RangesSchemas);
            if (proForm.ShowDialog() == DialogResult.OK)
            {
                var rangesCfg = new fmRangesConfiguration
                                    {
                                        AssignedMachineType = proForm.GetRangesMachineType(),
                                        Ranges = proForm.GetRanges()
                                    };
                filterSimulationWithTablesAndGraphs1.SetCurrentSerieRanges(rangesCfg);
                filterSimulationWithTablesAndGraphs1.RangesSchemas = proForm.GetRangesSchemas();
                filterSimulationWithTablesAndGraphs1.UpdateAll();
            }
        }

        private void ParametersToDisplayToolStripMenuItemClick(object sender, EventArgs e)
        {
            var yalForm = new fmYAxisListingForm
                              {
                                  CurrentSerieMachineName =
                                      filterSimulationWithTablesAndGraphs1.GetCurrentSerieMachineName()
                              };
            fmParametersToDisplay parametersToDisplay =
                filterSimulationWithTablesAndGraphs1.GetCurrentSerieParametersToDisplay();
            yalForm.CheckItems(parametersToDisplay.ParametersList);
            yalForm.SetShowHideSchemas(filterSimulationWithTablesAndGraphs1.ShowHideSchemas);
            yalForm.CheckScheme(parametersToDisplay.AssignedSchema);
            if (yalForm.ShowDialog() == DialogResult.OK)
            {
                parametersToDisplay = new fmParametersToDisplay(yalForm.GetCheckedSchema(), yalForm.GetCheckedItems());
                filterSimulationWithTablesAndGraphs1.SetCurrentSerieParametersToDisplay(parametersToDisplay);
                filterSimulationWithTablesAndGraphs1.ShowHideSchemas = yalForm.GetShowHideSchemas();
                filterSimulationWithTablesAndGraphs1.UpdateAll();
            }
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("FiltrationCalculator.exe");
        }
    }
}