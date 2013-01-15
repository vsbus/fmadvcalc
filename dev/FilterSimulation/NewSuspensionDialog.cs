using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FilterSimulation
{
    public partial class NewSuspensionDialog : Form
    {
        public NewSuspensionDialog()
        {
            InitializeComponent();
        }

        public string GetNewSuspension()
        {
            return newMaterialNameTextBox.Text.ToString() + " - " + newCustomerNameTextBox.Text.ToString() + " - " + NewSuspensionNameTextBox.Text.ToString();
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            if (keyData == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }      
    }
}