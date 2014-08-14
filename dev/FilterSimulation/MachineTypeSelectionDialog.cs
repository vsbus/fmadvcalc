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
            machineTypesListView.MouseWheel += new MouseEventHandler(panel1_MouseWheel);
        }

        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta<0)
            {
                if (machineTypesListView.SelectedItems[0].Index < machineTypesListView.Items.Count - 1)
                {
                    int newSelectedItemIndex = machineTypesListView.SelectedItems[0].Index + 1;
                    machineTypesListView.Items[newSelectedItemIndex].Selected = true;
                }
            }
            if (e.Delta > 0)
            {
                if (machineTypesListView.SelectedItems[0].Index > 0)
                {
                    int newSelectedItemIndex = machineTypesListView.SelectedItems[0].Index - 1;
                    machineTypesListView.Items[newSelectedItemIndex].Selected = true;
                }
            }   
        }

        private void InitCombobox()
        {            
            foreach (fmFilterSimMachineType machine in m_machines)
            {
                machineTypesListView.Items.Add(machine.name).BackColor = ControlPaint.LightLight(machine.GetMachineGroup().GetColor());                
            }
        }

        internal void AssignSerie(FilterSimulation.fmFilterObjects.fmFilterSimSerie serie)
        {
            string parentName = serie.Parent == null ? "" : " - " + serie.Parent.GetName();
            serieTextBox.Text = serie.GetName();
            
            foreach (ListViewItem item in machineTypesListView.Items)
            {
                if (item.Text == serie.MachineType.name)
                {
                    machineTypesListView.Select();
                    item.Selected = true;
                    break;
                }
            }
        }

        internal fmFilterSimMachineType GetSelectedType()
        { 
            foreach (fmFilterSimMachineType machine in m_machines)
            {
                if (machine.name == machineTypesListView.SelectedItems[0].Text)
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
