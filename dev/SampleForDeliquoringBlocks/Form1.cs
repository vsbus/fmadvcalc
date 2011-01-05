using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fmCalculationLibrary;
using fmCalcBlocksLibrary.Blocks;

namespace SampleForDeliquoringBlocks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void WriteParameter(int rowIndex, fmGlobalParameter p)
        {
            fmDataGrid1.Rows[rowIndex].Cells[0].Value = p.name;
            fmDataGrid1.Rows[rowIndex].Cells[1].Value = p.unitFamily.CurrentUnit.Name;
        }

        private fmEps0NeEpsBlock block1;
        private fmSigmaPke0PkePcdRcdAlphadBlock block2;

        private void Form1_Load(object sender, EventArgs e)
        {
            fmDataGrid1.RowCount = 20;

            WriteParameter(0, fmGlobalParameter.Dp);
            WriteParameter(1, fmGlobalParameter.Dp_d);

            WriteParameter(2, fmGlobalParameter.eps0_d);
            WriteParameter(3, fmGlobalParameter.ne_d);
            WriteParameter(4, fmGlobalParameter.eps_d);

            block1 = new fmEps0NeEpsBlock(
                fmDataGrid1.Rows[1].Cells[2],
                fmDataGrid1.Rows[2].Cells[2],
                fmDataGrid1.Rows[3].Cells[2],
                fmDataGrid1.Rows[4].Cells[2]);

            WriteParameter(5, fmGlobalParameter.sigma);
            WriteParameter(6, fmGlobalParameter.pke0);
            WriteParameter(7, fmGlobalParameter.pke);
            WriteParameter(8, fmGlobalParameter.pc_d);
            WriteParameter(9, fmGlobalParameter.rc_d);
            WriteParameter(10, fmGlobalParameter.alpha_d);

            block2 = new fmSigmaPke0PkePcdRcdAlphadBlock(
                fmDataGrid1.Rows[5].Cells[2],
                fmDataGrid1.Rows[6].Cells[2],
                fmDataGrid1.Rows[7].Cells[2],
                fmDataGrid1.Rows[8].Cells[2],
                fmDataGrid1.Rows[9].Cells[2],
                fmDataGrid1.Rows[10].Cells[2]);

            WriteParameter(11, fmGlobalParameter.Srem);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            block2.Dp_Value = fmValue.ObjectToValue(fmDataGrid1.Rows[0].Cells[2].Value);
            block2.Dpd_Value = block1.Dp_Value;
            block2.nc_Value = new fmValue(0.2);
            block2.eps_d_Value = block1.eps_Value;
            block2.rho_s_Value = new fmValue(1000);
            block2.CalculateAndDisplay();
        }
    }
}
