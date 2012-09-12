using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FilterSimulation.fmFilterObjects;
using fmMisc;

namespace FilterSimulation
{
    public partial class MachineTypeSelectionDialog : Form
    {

        private readonly fmFilterSimMachineType[] m_machines = fmFilterSimMachineType.filterTypesList.ToArray();

        public MachineTypeSelectionDialog()
        {
            InitializeComponent();
            InitCombobox();
        }

        private void InitCombobox()
        {
            foreach (fmFilterSimMachineType machine in m_machines)
            {
                machineTypesComboBox.Items.Add(machine.name);
            }
        }

        internal void AssignSerie(FilterSimulation.fmFilterObjects.fmFilterSimSerie serie)
        {
            string parentName = serie.Parent == null ? "" : " - " + serie.Parent.GetName();
            serieTextBox.Text = serie.GetName();
            foreach (var item in machineTypesComboBox.Items)
            {
                if (item.ToString() == serie.MachineType.name)
                {
                    machineTypesComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        internal fmFilterSimMachineType GetSelectedType()
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
