using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FilterSimulation;
using FilterSimulation.fmFilterObjects;
using fmMisc;
using RangesDictionary = System.Collections.Generic.Dictionary<fmCalculationLibrary.fmGlobalParameter, fmCalculationLibrary.fmDefaultParameterRange>;

using fmCalculationLibrary;

namespace FilterSimulation
{
    public partial class StartMachineTypeSelectionDialog : Form
    {
        public fmCalculationOptionSelectionDialog cosd = new fmCalculationOptionSelectionDialog();
        private fmFilterSimMachineType[] m_machines = fmFilterSimMachineType.filterTypesList.ToArray();
        private bool NewFileStarted = false;
        public struct Options
        {
            public bool CheckBox_Checked;
        };
        public Options StartOptions = new Options();
        private struct Names
        {
            public string ProjectName;
            public string SuspensionName;
            public string CustomerName;
            public string MaterialName;
            public string FilterMediumName;
            public string SerieName;
            public string SimulationName;
        }
        private Names NamesForNewSimulation = new Names();
        private AllCalculationSettingsDialog CalculationsSettingsWindow = new AllCalculationSettingsDialog();
        
        public StartMachineTypeSelectionDialog(fmFilterSimSolution StartSolution, bool StartingNew)
        {
            InitializeComponent();
            InitCombobox(StartSolution);
            AssignSolution(StartSolution);
            NewFileStarted = StartingNew;
            if (NewFileStarted)
            {
                SwitchView();
            }
            CalculationsSettingsWindow.InitCalculationOptions();
            
        }

        private void InitCombobox(fmFilterSimSolution Solution)
        {
            foreach (fmFilterSimMachineType machine in m_machines)
            {
                machineTypesComboBox.Items.Add(machine.name);
            }

            foreach (var project in Solution.projects)
            {
                projectsComboBox.Items.Add(project.GetName());

                foreach (var suspension in project.SuspensionList)
                {
                    SuspensionsComboBox.Items.Add(suspension.m_data.material + " - " + suspension.m_data.customer + " - " + suspension.m_data.name);
                    foreach (var serie in suspension.m_data.seriesList)
                    {
                        mediumsComboBox.Items.Add(serie.FilterMedium);
                        SeriesComboBox.Items.Add(serie.GetName());
                    }
                }
            }
        }

        public void InitializeMachineTypesComboBox()
        {
            m_machines = fmFilterSimMachineType.filterTypesList.ToArray();
        }

        internal void AssignSolution(fmFilterSimSolution Solution)
        {
            string material;
            foreach (var item in projectsComboBox.Items)
            {
                if (item.ToString() == Solution.currentObjects.Project.GetName())
                {
                    projectsComboBox.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in SuspensionsComboBox.Items)
            {
                material = item.ToString().Substring(0, item.ToString().IndexOf(' '));
                if (material == Solution.currentObjects.Suspension.Material)
                {
                    SuspensionsComboBox.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in mediumsComboBox.Items)
            {
                if (item.ToString() == Solution.currentObjects.Serie.FilterMedium)
                {
                    mediumsComboBox.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in SeriesComboBox.Items)
            {
                if (item.ToString() == Solution.currentObjects.Serie.GetName())
                {
                    SeriesComboBox.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in machineTypesComboBox.Items)
            {
                if (Solution.currentObjects.Serie != null)
                {
                    if (item.ToString() == Solution.currentObjects.Serie.MachineType.name)
                    {
                        machineTypesComboBox.SelectedItem = item;
                        break;
                    }
                }
                else
                {
                    machineTypesComboBox.SelectedIndex = 0;
                }
            }
        }

        private void SwitchView()
        {
            projectTextBox.Visible = true;
            suspensionTextBox.Visible = true;
            filtermediumTextBox.Visible = true;
            serieTextBox.Visible = true;
            materialTextBox.Visible = true;
            customerTextBox.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label4.Left = 248;
            projectsComboBox.Visible = false;
            SuspensionsComboBox.Visible = false;
            mediumsComboBox.Visible = false;
            SeriesComboBox.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
        }

        public fmFilterSimMachineType GetSelectedType()
        {
            foreach (fmFilterSimMachineType machine in m_machines)
            {
                if (machine.name == machineTypesComboBox.Text)
                {
                    return machine;
                }
            }
            throw new Exception("Invalid Filter Type seleced.");
        }
        public string GetProjectName()
        {
            return NamesForNewSimulation.ProjectName;
        }
        public string GetSuspensionName()
        {
            return NamesForNewSimulation.SuspensionName;
        }
        public string GetCustomerName()
        {
            return NamesForNewSimulation.CustomerName;
        }
        public string GetMaterialName()
        {
            return NamesForNewSimulation.MaterialName;
        }
        public string GetSerieName()
        {
            return NamesForNewSimulation.SerieName;
        }
        public string GetMediumName()
        {
            return NamesForNewSimulation.FilterMediumName;
        }
        public string GetSimulationName()
        {
            return NamesForNewSimulation.SimulationName;
        }

        private void GetNamesForNewSimulation()
        {
            if (NewFileStarted)
            {
                NamesForNewSimulation.ProjectName = projectTextBox.Text.ToString();
                NamesForNewSimulation.SuspensionName = suspensionTextBox.Text.ToString();
                NamesForNewSimulation.MaterialName = materialTextBox.Text.ToString();
                NamesForNewSimulation.CustomerName = customerTextBox.Text.ToString();
                NamesForNewSimulation.FilterMediumName = filtermediumTextBox.Text.ToString();
                NamesForNewSimulation.SerieName = serieTextBox.Text.ToString();
            }
            else
            {
                NamesForNewSimulation.ProjectName = projectsComboBox.SelectedItem.ToString();

                string material = SuspensionsComboBox.SelectedItem.ToString().Substring(0, SuspensionsComboBox.SelectedItem.ToString().IndexOf(' '));
                string customer = SuspensionsComboBox.SelectedItem.ToString().Remove(0, material.Length + 3);
                customer = customer.Substring(0, customer.IndexOf(' '));
                string suspension = SuspensionsComboBox.SelectedItem.ToString().Remove(0, material.Length + customer.Length + 6);

                NamesForNewSimulation.SuspensionName = suspension;
                NamesForNewSimulation.MaterialName = material;
                NamesForNewSimulation.CustomerName = customer;
                NamesForNewSimulation.FilterMediumName = mediumsComboBox.SelectedItem.ToString();
                NamesForNewSimulation.SerieName = SeriesComboBox.SelectedItem.ToString();
            }
            NamesForNewSimulation.SimulationName = simulationTextBox.Text.ToString();
        }

        public void GetCalculationOptions(fmFilterSimulation Simulation)
        {
            CalculationsSettingsWindow.GetCalculationOptions(Simulation);
        }        

        public void CheckMachineType(fmFilterSimMachineType schema)
        {
            CalculationsSettingsWindow.CheckMachineType(schema);
        }       

        public void CheckScheme(string machineName)
        {
            CalculationsSettingsWindow.CheckScheme(machineName);
        }

        public void InitCalculationsSettingsWindow(RangesDictionary ranges, Dictionary<fmFilterSimMachineType, Dictionary<fmGlobalParameter, fmDefaultParameterRange>> rangesDictionary, fmParametersToDisplay parametersToDisplay, Dictionary<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>> showHideDictionary)
        {
            InitCalculationsSettingsWindowComboboxes();
            CalculationsSettingsWindow.SetRanges(ranges);
            CalculationsSettingsWindow.SetRangesSchemas(rangesDictionary);            
            
            CalculationsSettingsWindow.CheckItems(parametersToDisplay.ParametersList);
            CalculationsSettingsWindow.SetShowHideSchemas(showHideDictionary);
            CalculationsSettingsWindow.CheckScheme(parametersToDisplay.AssignedSchema);

            CalculationsSettingsWindow.SetDefaultValues(ranges, rangesDictionary, parametersToDisplay, showHideDictionary);
        }

        private void InitCalculationsSettingsWindowComboboxes()
        {
            CheckScheme(GetSelectedType().name);
            CalculationsSettingsWindow.CurrentSerieMachineName = GetSelectedType().name;
        }

        public fmFilterSimMachineType GetRangesMachineType()
        {
            return CalculationsSettingsWindow.GetRangesMachineType();
        }

        public RangesDictionary GetRanges()
        {
            return CalculationsSettingsWindow.GetRanges();
        }

        public Dictionary<fmFilterSimMachineType, Dictionary<fmGlobalParameter, fmDefaultParameterRange>> GetRangesSchemas()
        {
            return CalculationsSettingsWindow.GetRangesSchemas();
        }

        public fmFilterSimMachineType.FilterCycleType GetCheckedSchema()
        {
            return CalculationsSettingsWindow.GetCheckedSchema();
        }

        public List<fmGlobalParameter> GetCheckedItems()
        {
            return CalculationsSettingsWindow.GetCheckedItems();
        }

        public Dictionary<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>> GetShowHideSchemas()
        {
            return CalculationsSettingsWindow.GetShowHideSchemas();
        }

        private void AcceptNewNamesAndDialogResult()
        {
            DialogResult = DialogResult.OK;
            GetNamesForNewSimulation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AcceptNewNamesAndDialogResult();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var addNewNameDialod = new NewNameDialog();
            addNewNameDialod.newNameTextBox.Text = "NewProj";
            addNewNameDialod.Text = "New Project Name";
            if (addNewNameDialod.ShowDialog() == DialogResult.OK)
            {
                projectsComboBox.Items.Add(addNewNameDialod.newNameTextBox.Text);
                projectsComboBox.SelectedIndex = projectsComboBox.Items.Count - 1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var addNewNameDialod = new NewNameDialog();
            addNewNameDialod.newNameTextBox.Text = "NewMedium";
            addNewNameDialod.Text = "New Mewdium Name";
            if (addNewNameDialod.ShowDialog() == DialogResult.OK)
            {
                mediumsComboBox.Items.Add(addNewNameDialod.newNameTextBox.Text);
                mediumsComboBox.SelectedIndex = mediumsComboBox.Items.Count - 1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var addNewNameDialod = new NewNameDialog();
            addNewNameDialod.newNameTextBox.Text = "NewSerie";
            addNewNameDialod.Text = "New Serie Name";
            if (addNewNameDialod.ShowDialog() == DialogResult.OK)
            {
                SeriesComboBox.Items.Add(addNewNameDialod.newNameTextBox.Text);
                SeriesComboBox.SelectedIndex = SeriesComboBox.Items.Count - 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var addNewSuspensionDialog = new NewSuspensionDialog();
            if (addNewSuspensionDialog.ShowDialog() == DialogResult.OK)
            {
                SuspensionsComboBox.Items.Add(addNewSuspensionDialog.GetNewSuspension());
                SuspensionsComboBox.SelectedIndex = SuspensionsComboBox.Items.Count - 1;
            }
        }

        private void button7_MouseClick(object sender, MouseEventArgs e)
        {
            this.Enabled = false;
            if (CalculationsSettingsWindow.DefaultValues.machine != GetSelectedType().name)
            {
                InitCalculationsSettingsWindowComboboxes();
                CalculationsSettingsWindow.button2_Click(sender, e);
            }
            CalculationsSettingsWindow.SetDefaultMachine(GetRangesMachineType().name);
            if (CalculationsSettingsWindow.ShowDialog() == DialogResult.OK)
            {
                CalculationsSettingsWindow.SetDefaultMachine(GetRangesMachineType().name);
                CalculationsSettingsWindow.SetDefaultValues(GetRanges(), GetRangesSchemas(), new fmParametersToDisplay(GetCheckedSchema(), GetCheckedItems()), GetShowHideSchemas()); 
            }
            else
            {
                CalculationsSettingsWindow.WindowCanceled();
            }
            this.Enabled = true;
        }        

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            if (keyData == Keys.Enter)
            {
                AcceptNewNamesAndDialogResult();
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void machineTypesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CalculationsSettingsWindow.CheckScheme(GetSelectedType().GetFilterCycleType());
            CalculationsSettingsWindow.takeButton_Click(sender, e);
        }  

    }
}
