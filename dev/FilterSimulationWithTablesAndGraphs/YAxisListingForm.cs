using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FilterSimulation
{
    public partial class YAxisListingForm : Form
    {
        public YAxisListingForm()
        {
            InitializeComponent();

            checkedListBox1.Items.Clear();
            foreach (fmCalculationLibrary.fmGlobalParameter parameter in fmCalculationLibrary.fmGlobalParameter.parameters)
            {
                checkedListBox1.Items.Add(parameter.name);
            }
        }

        public void CheckItems(List<fmCalculationLibrary.fmGlobalParameter> list)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; ++i)
                if (list.Contains(GetParameterInListBoxByIndex(i)))
                    checkedListBox1.SetItemChecked(i, true);
        }

        public List<fmCalculationLibrary.fmGlobalParameter> GetCheckedItems()
        {
            List<fmCalculationLibrary.fmGlobalParameter> result = new List<fmCalculationLibrary.fmGlobalParameter>();
            for (int i = 0; i < checkedListBox1.Items.Count; ++i)
                if (checkedListBox1.GetItemChecked(i))
                    result.Add(GetParameterInListBoxByIndex(i));
            return result;
        }

        private fmCalculationLibrary.fmGlobalParameter GetParameterInListBoxByIndex(int i)
        {
            return fmCalculationLibrary.fmGlobalParameter.parametersByName[checkedListBox1.Items[i] as string];
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}