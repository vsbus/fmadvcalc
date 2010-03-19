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
                radioButton_rho_f, radioButton_rho_s, radioButton_rho_sus, radioButton_C,
                fmDataGrid1[1, 0], fmDataGrid1[1, 1], fmDataGrid1[1, 2], fmDataGrid1[1, 3], fmDataGrid1[1, 4], fmDataGrid1[1, 5]);
        }
    }
}