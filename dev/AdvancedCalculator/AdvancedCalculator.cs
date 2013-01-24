using System;
using System.Diagnostics;
using System.Windows.Forms;
using FilterSimulation;
using FilterSimulationWithTablesAndGraphs;
using Microsoft.Win32;
using System.Xml;
using System.IO;
using TheCodeKing.ActiveButtons.Controls;

namespace AdvancedCalculator
{
    public partial class fmAdvancedCalculator : Form
    {
        private readonly string m_caption = string.Format("FILTRAPLUS (v.{0})", Config.Version);

        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_CONTEXTHELP = 0xf180;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        ActiveButton button = new ActiveButton();

        private static class fmUrlStringsForElements
        {
            public const string Menu_Task_Bar = "Menu_Task_Bar.htm";
        }

        public fmAdvancedCalculator()
        {
            InitializeComponent();
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AddButton("Help", Help_Click);
        }

        private void AddButton(string text, EventHandler handler)
        {
            // get an instance of IActiveMenu used to attach
            // buttons to the form
            IActiveMenu menu = ActiveMenu.GetInstance(this);

            // define a new button
            button.Text = "?";
            menu.ToolTip.SetToolTip(button, "Help");
            button.Click += handler;

            // add the button to the menu
            menu.Items.Add(button);            
        }

        private void Help_Click(object sender, EventArgs e)
        {
            button.Capture = false;
            SendMessage(this.Handle, WM_SYSCOMMAND, (IntPtr)SC_CONTEXTHELP, IntPtr.Zero);
        }

        // ReSharper disable InconsistentNaming
        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
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

        private void AdvancedCalculatorLoad(object sender, EventArgs e)
        {
            var doc = new XmlDocument();
            if (!ProtectionChecker.CheckProtectionWithDialog())
            {
                Close();
            }

            try
            {
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
            if (regValue != null && regValue.ToString() != "")
            {
                string filename = regValue.ToString();
                if (File.Exists(filename))
                {
                    LoadFromDisk(filename);
                    XmlNode cfgFileNode = doc.SelectSingleNode(fmFiltraplusSerializeTags.FiltraplusConfigFile);
                    if (cfgFileNode != null)
                    {
                        filterSimulationWithTablesAndGraphs1.LoadLastMinMaxValues(cfgFileNode);
                        filterSimulationWithTablesAndGraphs1.DeserializeInterfaceAdjusting(cfgFileNode);
                    }                         
                    return;
                }
            }
            CreateNewFile();
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
            filterSimulationWithTablesAndGraphs1.SaveAll();
            var xmlSettings = new XmlWriterSettings
                                  {
                                      Indent = true
                                  };
            XmlWriter writer = XmlWriter.Create(fileName, xmlSettings);
            writer.WriteStartDocument();
            writer.WriteStartElement(fmFiltraplusSerializeTags.FiltraplusDataFile);
            filterSimulationWithTablesAndGraphs1.SerializeData(writer);
            filterSimulationWithTablesAndGraphs1.SerializeInterfaceAdjusting(writer);
            filterSimulationWithTablesAndGraphs1.SerializeConfiguration(writer);
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
                filterSimulationWithTablesAndGraphs1.DeserializeInterfaceAdjusting(doc.SelectSingleNode(fmFiltraplusSerializeTags.FiltraplusDataFile));
                filterSimulationWithTablesAndGraphs1.DeserializeConfigurationForMenuOpen(
                    doc.SelectSingleNode(fmFiltraplusSerializeTags.FiltraplusDataFile));                
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
            if (!ProtectionChecker.CheckProtection())
                return;

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
            filterSimulationWithTablesAndGraphs1.SerializeInterfaceAdjusting(writer);
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
            uoForm.SetUsChecked(filterSimulationWithTablesAndGraphs1.GetIsUsUnitsUsed());
            uoForm.SetUnitsSchemas(filterSimulationWithTablesAndGraphs1.UnitsSchemas);
            uoForm.CheckScheme(filterSimulationWithTablesAndGraphs1.GetCurrentUnitsSchema());
            if (uoForm.ShowDialog() == DialogResult.OK)
            {
                filterSimulationWithTablesAndGraphs1.SetIsUsUnitsUsed(uoForm.GetUsChecked());
                filterSimulationWithTablesAndGraphs1.SetCurrentUnitsSchema(uoForm.GetCheckedUnitsSchema());
                filterSimulationWithTablesAndGraphs1.UnitsSchemas = uoForm.GetUnitsSchemas();
                filterSimulationWithTablesAndGraphs1.UpdateAll();
            }
        }

        private void RangesToolStripMenuItem1Click(object sender, EventArgs e)
        {
            var proForm = new fmParameterIntervalOption();
            proForm.SetRanges(filterSimulationWithTablesAndGraphs1.GetCurrentSerieRanges().Ranges);
            proForm.CheckMachineType(filterSimulationWithTablesAndGraphs1.GetCurrentSerieRanges().AssignedMachineType);
            proForm.SetRangesSchemas(filterSimulationWithTablesAndGraphs1.RangesSchemas);
            proForm.CheckScheme(filterSimulationWithTablesAndGraphs1.GetCurrentSerieMachineName());
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewFile();
        }

        private void CreateNewFile()
        {
            if (filterSimulationWithTablesAndGraphs1.Clear())
            {
                m_currentFilename = null;
                Text = m_caption;
            }
        }

        private void calculationPrecisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var doForm = new fmDigitsOptions();
            doForm.ShowDialog();
            filterSimulationWithTablesAndGraphs1.UpdateAll();
        }

        private void filterTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filterSimulationWithTablesAndGraphs1.SelectMachineButtonClick(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!ProtectionChecker.CheckProtectionWithDialog())
            {
                Close();
            }
        }

        private void createNewSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filterSimulationWithTablesAndGraphs1.newSimulationButton_Click(sender, e);
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFromDiskToolStripMenuItemClick(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAllToolStripMenuItem_Click(sender, e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveOnDiskToolStripMenuItemClick(sender, e);
        }

        private void helpStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, filterSimulationWithTablesAndGraphs1.helpProvider1.HelpNamespace, HelpNavigator.TableOfContents);
        }
    }
}