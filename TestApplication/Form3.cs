using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            fmDataGrid1.Rows.Add(new DataGridViewRow());
            fmDataGrid1.Rows.Add(new DataGridViewRow());
            fmDataGrid1.Rows.Add(new DataGridViewRow());

            //fmDataGrid1.SetRowColor(fmDataGrid1.Rows[0], Color.Red);
            //fmDataGrid1.SetRowColor(fmDataGrid1.Rows[1], Color.Green);
            //fmDataGrid1.SetRowColor(fmDataGrid1.Rows[2], Color.Blue);
        }

        private void fmDataGrid1_SelectionChanged(object sender, EventArgs e)
        {
        }
    }
}