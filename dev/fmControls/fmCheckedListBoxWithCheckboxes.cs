using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace fmControls
{
    public partial class fmCheckedListBoxWithCheckboxes : UserControl
    {
        public fmCheckedListBoxWithCheckboxes()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; ++i)
            {
                checkedListBox1.SetItemChecked(i, checkBox1.Checked);
            }
        }

        public bool GetItemChecked(int i)
        {
            return checkedListBox1.GetItemChecked(i);
        }

        public void SetItemChecked(int i, bool p)
        {
            checkedListBox1.SetItemChecked(i, p);
        }
    }
}
