using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace fmDataGrid
{
    public class DataGridViewNumericalTextBoxEditingControl : DataGridViewTextBoxEditingControl
    {
        public DataGridViewNumericalTextBoxEditingControl()
            : base()
        {
            this.KeyPress += textBox_KeyPress;
            this.TextChanged += textBox_TextChanged;
        }

        public void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Keys key = (Keys)e.KeyChar;
            fmNumericalTextBoxHelper.CheckKey(ref key);
            e.KeyChar = (char)key;
        }

        public void textBox_TextChanged(object sender, EventArgs e)
        {
            fmNumericalTextBoxHelper.CheckTextBox(sender as TextBox);
        }
    }
}
