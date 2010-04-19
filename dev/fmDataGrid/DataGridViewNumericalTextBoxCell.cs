using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace fmDataGrid
{
    public class DataGridViewNumericalTextBoxCell : DataGridViewTextBoxCell
    {
        public DataGridViewNumericalTextBoxCell() : base() { }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            DataGridViewNumericalTextBoxEditingControl numTextBox = this.DataGridView.EditingControl as DataGridViewNumericalTextBoxEditingControl;
            numTextBox.Height = this.OwningRow.Height;
            string stringInCell = Convert.ToString(this.Value);
            numTextBox.Text = stringInCell;
        }

        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewNumericalTextBoxEditingControl);
            }
        }
    }
}
