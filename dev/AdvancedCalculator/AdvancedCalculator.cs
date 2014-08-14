using System;
using System.Diagnostics;
using System.Windows.Forms;
using FilterSimulation;
using FilterSimulationWithTablesAndGraphs;
using Microsoft.Win32;
using System.Xml;
using System.IO;
using TheCodeKing.ActiveButtons.Controls;
using System.Drawing;
using System.Reflection;
using fmControls;

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

            HideWelcomePicture();
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
            ShowWelcomePicture();

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
                        filterSimulationWithTablesAndGraphs1.DeserializeLastSelectedSimulation(cfgFileNode);
                        filterSimulationWithTablesAndGraphs1.DeserializeProgramOptions(cfgFileNode);
                        filterSimulationWithTablesAndGraphs1.DeserializeInterfaceAdjusting(cfgFileNode);
                        filterSimulationWithTablesAndGraphs1.DesirializeParametersOrderAndColumnSizesInHorizontalTable(cfgFileNode);
                        filterSimulationWithTablesAndGraphs1.hook();
                    }
                    return;
                }
            }
            CreateNewFile();
        }
        private void ShowWelcomePicture()
        {
            filterSimulationWithTablesAndGraphs1.Visible = false;//hiding main object to see welcome message
            
            string welcomeString1 = "Welcome to";
            string welcomeString2 = "FILTRAPLUS";
            string welcomeString3 = "(Vers.  14.02.2014)";
            string welcomeString4 = "Software for Industrial Filters";
            string welcomeString5 = "Design - Performance Simulation - Optimization";
            string welcomeString6 = "Copyright © by Prof. Dr. Ioannis Nicolaou, NIKIFOS Ltd.";
            float x;
            float y;

            Color color = Color.FromArgb(0, 32, 96);
            Brush brush = new SolidBrush(color);
            Font fontLarge = new Font("Arial", 48);
            Font fontBig = new Font("Arial", 36);
            Font fontMedium = new Font("Arial", 27);
            Font fontSmall = new Font("Arial", 22);
            Font fontXSmall = new Font("Arial", 20);
            Graphics Graph = this.CreateGraphics();            
            SizeF stringSize = new SizeF();
            stringSize = Graph.MeasureString(welcomeString1, fontBig);

            x = 0;
            y = stringSize.Height;
            
            x = x + (this.Width - stringSize.Width)/ 2;
            y = y + stringSize.Height;
            Graph.DrawString(welcomeString1, fontBig, brush, x, y);
            x = 0;

            stringSize = Graph.MeasureString(welcomeString2, fontLarge);
            x = x + (this.Width - stringSize.Width) / 2;
            y = y + stringSize.Height*2;
            Graph.DrawString(welcomeString2, fontLarge, brush, x, y);
            x = 0;

            stringSize = Graph.MeasureString(welcomeString3, fontXSmall);
            x = x + (this.Width - stringSize.Width) / 2;
            y = y + stringSize.Height*2;
            Graph.DrawString(welcomeString3, fontXSmall, brush, x, y);
            x = 0;

            stringSize = Graph.MeasureString(welcomeString4, fontBig);
            x = x + (this.Width - stringSize.Width) / 2;
            y = y + (stringSize.Height*(float)1.3);
            Graph.DrawString(welcomeString4, fontBig, brush, x, y);
            x = 0;

            stringSize = Graph.MeasureString(welcomeString5, fontMedium);
            x = x + (this.Width - stringSize.Width) / 2;
            y = y + stringSize.Height;
            Graph.DrawString(welcomeString5, fontMedium, brush, x, y);
            x = 0;

            stringSize = Graph.MeasureString(welcomeString6, fontSmall);
            x = x + (this.Width - stringSize.Width) / 2;
            y = y + stringSize.Height*3;
            Graph.DrawString(welcomeString6, fontSmall, brush, x, y);
            x = 0;
        }
        private void HideWelcomePicture()
        {
            filterSimulationWithTablesAndGraphs1.Visible = true;
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
                saveDialog.FileName = m_currentFilename.Substring(m_currentFilename.LastIndexOf('\\')+1);
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

            public const string FiltraplusTemporaryFile = "^_^";
            public const string SessionComments = "SessionComments";
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

        private TextBox textbox = new TextBox();
        private void LoadFromDiskToolStripMenuItemClick(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog {Filter = @"Data files (*.dat)|*.dat"};
            if (m_currentFilename != null)
            {
                openDialog.FileName = m_currentFilename;
                string path = m_currentFilename.Substring(0, m_currentFilename.LastIndexOf('\\'));
                openDialog.InitialDirectory = path;
            }

            var tmp = m_currentFilename;
            SaveOnDisk(fmFiltraplusSerializeTags.FiltraplusTemporaryFile);
            File.SetAttributes(fmFiltraplusSerializeTags.FiltraplusTemporaryFile, FileAttributes.Hidden);
            var extndOpenDialog = new FileDialogExtenders.FileDialogControlBase();

            var label = new Label();

            textbox.Text = LoadSessionCommentsFromFile(m_currentFilename);
            textbox.ReadOnly = true;
            textbox.Width = 200;
            textbox.Multiline = true;
            label.Text = "User Comments:";

            extndOpenDialog.Controls.Add(label);
            extndOpenDialog.Controls.Add(textbox);

            label.Top = 10;
            label.Left = (textbox.Width - label.Width) / 2;

            extndOpenDialog.Width = textbox.Width + 5;
            textbox.Top = label.Bottom+2;
            textbox.Height = 285;

            if (textbox.Text.Length > 672)
            {
                textbox.ScrollBars = ScrollBars.Vertical;
            }            

            extndOpenDialog.FileDlgCaption = "Open Session";
            extndOpenDialog.FileDlgOkCaption = "OK";
            extndOpenDialog.EventFileNameChanged +=new FileDialogExtenders.FileDialogControlBase.PathChangedEventHandler(extndOpenDialog_EventFileNameChanged);

            var tmpCurDir = Directory.GetCurrentDirectory();

            if (FileDialogExtenders.Extensions.ShowDialog(openDialog, extndOpenDialog, this) != DialogResult.OK)
            {
                LoadFromDiskWithLoadingMessage(fmFiltraplusSerializeTags.FiltraplusTemporaryFile);
                m_currentFilename = tmp;
                Text = m_caption + @" [" + m_currentFilename + @"]";
            }
            Directory.SetCurrentDirectory(tmpCurDir);
            File.Delete(fmFiltraplusSerializeTags.FiltraplusTemporaryFile);
        }

        private void extndOpenDialog_EventFileNameChanged(IWin32Window sender, string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            if (fi.Extension == ".dat")
            {
                textbox.Text = LoadSessionCommentsFromFile(filePath);
                LoadFromDiskWithLoadingMessage(filePath);
            }
        }

        private void LoadFromDiskWithLoadingMessage(string filePath)
        {
            string loadingString = "Loading...";
            Color color = Color.FromArgb(0, 32, 96);
            Brush brush = new SolidBrush(color);
            Font fontSmall = new Font("Arial", 22);
            Graphics Graph = this.CreateGraphics();
            float x;
            float y;
            
            SizeF stringSize = new SizeF();
            stringSize = Graph.MeasureString(loadingString, fontSmall);

            x = (this.Width - stringSize.Width) / 2;
            y = this.Height / 2;

            filterSimulationWithTablesAndGraphs1.Visible = false;
            Graph.DrawString(loadingString, fontSmall, brush, x, y);
            var tmpCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            LoadFromDisk(filePath);
            filterSimulationWithTablesAndGraphs1.Visible = true;
            this.Cursor = tmpCursor;
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
                filterSimulationWithTablesAndGraphs1.DeserializeConfigurationForMenuOpen(
                    doc.SelectSingleNode(fmFiltraplusSerializeTags.FiltraplusDataFile));
                filterSimulationWithTablesAndGraphs1.setFlagsToOpeningFromFile();
                filterSimulationWithTablesAndGraphs1.DeserializeInterfaceAdjusting(doc.SelectSingleNode(fmFiltraplusSerializeTags.FiltraplusDataFile));
                filterSimulationWithTablesAndGraphs1.hook2();
            }
            catch (Exception)
            {
                MessageBox.Show(@"File " + fileName + @" has an error in format and is impossible to open.", @"Error");
                m_currentFilename = null;
                Text = m_caption;
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
            filterSimulationWithTablesAndGraphs1.SerializeLastSelectedSimulation(writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
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
            yalForm.SetShowHideSchemas(filterSimulationWithTablesAndGraphs1.ShowHideSchemas, filterSimulationWithTablesAndGraphs1.ShowHideSchemasForEachFilterMachine);
            yalForm.CheckScheme(parametersToDisplay.AssignedSchema, filterSimulationWithTablesAndGraphs1.GetCurrentSerieMachineName());
            if (yalForm.ShowDialog() == DialogResult.OK)
            {
                parametersToDisplay = new fmParametersToDisplay(yalForm.GetCheckedSchema(), yalForm.GetCheckedItems());
                filterSimulationWithTablesAndGraphs1.SetCurrentSerieParametersToDisplay(parametersToDisplay);
                filterSimulationWithTablesAndGraphs1.ShowHideSchemas = yalForm.GetShowHideSchemas();
                filterSimulationWithTablesAndGraphs1.ShowHideSchemasForEachFilterMachine = yalForm.GetFiltersShowHideSchemas();
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
            filterSimulationWithTablesAndGraphs1.hook2();
        }

        private void calculationPrecisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var doForm = new fmDigitsOptions();
            doForm.ShowDialog();
            filterSimulationWithTablesAndGraphs1.UpdateAll();
        }

        private void filterTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tmpFilter = filterSimulationWithTablesAndGraphs1.GetCurrentSerieMachineName();
            filterSimulationWithTablesAndGraphs1.SelectMachineButtonClick(sender, e);

            if (tmpFilter != filterSimulationWithTablesAndGraphs1.GetCurrentSerieMachineName())
                filterSimulationWithTablesAndGraphs1.TakeDefaultUnitsForSerie(filterSimulationWithTablesAndGraphs1.GetCurrentSerieMachineName());
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

        private void fmAdvancedCalculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ProtectionChecker.CheckProtection())
                return;

            SaveConfigurations();
            if (filterSimulationWithTablesAndGraphs1.IsModified())
            {
                DialogResult dres = MessageBox.Show(@"Would you like to save data before exit?", @"Confirmation", MessageBoxButtons.YesNoCancel);

                if (dres == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
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

            DeleteTempFile();
        }

        private void DeleteTempFile()
        {
            string exeName = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string programPath = Assembly.GetExecutingAssembly().Location.Replace(exeName, "");
            File.Delete(programPath + fmFiltraplusSerializeTags.FiltraplusTemporaryFile);
        }

        private void commentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunSessionCommentsWindow();
        }

        private void RunSessionCommentsWindow()
        {
            var commentWindow = new CommentsWindow();
            commentWindow.SetCommentedObjectName("Session");
            commentWindow.SetCommentText(LoadSessionCommentsFromFile(m_currentFilename));
            if (commentWindow.ShowDialog() == DialogResult.OK)
            {
                SaveSessionCommentsToCurrentFile(commentWindow.GetCommentText());
            }
        }

        private void SaveSessionCommentsToCurrentFile(string commentsString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(m_currentFilename); 
            XmlNode root = doc.DocumentElement;
            //Create a new node.
            XmlElement elem = doc.CreateElement(fmFiltraplusSerializeTags.SessionComments);
            elem.InnerText = commentsString;
            //Add the node to the document.

            if (root.SelectSingleNode(fmFiltraplusSerializeTags.SessionComments) != null)
                root.RemoveChild(root.SelectSingleNode(fmFiltraplusSerializeTags.SessionComments));

            root.AppendChild(elem);
            doc.Save(m_currentFilename);
        }

        private string LoadSessionCommentsFromFile(string filePath)
        {
            if (filePath == null || filePath == "")
                return "";

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNode root = doc.DocumentElement;
            XmlNode comNode = root.SelectSingleNode(fmFiltraplusSerializeTags.SessionComments);
            doc.Save(filePath);
            if (comNode == null)
                return "";
            return comNode.InnerText;
        }
    }
}