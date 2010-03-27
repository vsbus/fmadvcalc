using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using fmCalculationLibrary;

namespace SampleForBlocks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fmDataGrid1.Rows.Add(new object[] { "rho_f", new fmValue() });
            fmDataGrid1.Rows.Add(new object[] { "rho_s", new fmValue() });
            fmDataGrid1.Rows.Add(new object[] { "rho_sus", new fmValue() });
            fmDataGrid1.Rows.Add(new object[] { "Cm", new fmValue() });
            fmDataGrid1.Rows.Add(new object[] { "Cv", new fmValue() });
            fmDataGrid1.Rows.Add(new object[] { "C", new fmValue() });

            fmCalcBlocksLibrary.Blocks.fmSuspensionBlock susBlock = new fmCalcBlocksLibrary.Blocks.fmSuspensionBlock(
                fmDataGrid1[1, 0], fmDataGrid1[1, 1], fmDataGrid1[1, 2], fmDataGrid1[1, 3], fmDataGrid1[1, 4], fmDataGrid1[1, 5]);


            checkedListBox1.Items.Clear();
            for (int i = 1; i <= 9; ++i)
                checkedListBox1.Items.Add(i);
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //listBox1.Items.Clear();
            //foreach (object s in checkedListBox1.CheckedItems) 
            //    listBox1.Items.Add(s);
            //listBox1.Items.Add(checkedListBox1.Items[e.Index]);

            //listBox1.Items.Clear();
            //for (int i = 0; i < checkedListBox1.Items.Count; ++i)
            //{
            //    if (checkedListBox1.GetItemChecked(i) || e.Index == i)
            //        listBox1.Items.Add(checkedListBox1.Items[i]);
            //}
        }

    }
}