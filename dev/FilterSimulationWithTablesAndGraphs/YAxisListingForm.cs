using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FilterSimulationWithTablesAndGraphs
{
    public partial class fmYAxisListingForm : Form
    {
        public fmYAxisListingForm()
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
            var result = new List<fmCalculationLibrary.fmGlobalParameter>();
            for (int i = 0; i < checkedListBox1.Items.Count; ++i)
                if (checkedListBox1.GetItemChecked(i))
                    result.Add(GetParameterInListBoxByIndex(i));
            return result;
        }

        private fmCalculationLibrary.fmGlobalParameter GetParameterInListBoxByIndex(int i)
        {
// ReSharper disable AssignNullToNotNullAttribute
            return fmCalculationLibrary.fmGlobalParameter.parametersByName[checkedListBox1.Items[i] as string];
// ReSharper restore AssignNullToNotNullAttribute
        }

// ReSharper disable InconsistentNaming
        private void okButton_Click(object sender, EventArgs e)
// ReSharper restore InconsistentNaming
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}