using System;
using System.Windows.Forms;

namespace fmDataGrid
{
    public class fmDataGridViewNumericalTextBoxCell : DataGridViewTextBoxCell
    {
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            var numTextBox = DataGridView.EditingControl as fmDataGridViewNumericalTextBoxEditingControl;
            // ReSharper disable PossibleNullReferenceException
            numTextBox.Height = OwningRow.Height;
            string stringInCell = Convert.ToString(Value);
            numTextBox.Text = stringInCell;
            // ReSharper restore PossibleNullReferenceException
        }

        public override Type EditType
        {
            get
            {
                return typeof(fmDataGridViewNumericalTextBoxEditingControl);
            }
        }
    }
}
