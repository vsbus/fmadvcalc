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

        private fmEps0dNedEpsdBlock block1;
        private fmSigmaPke0PkePcdRcdAlphadBlock block2;

        private void Form1_Load(object sender, EventArgs e)
        {
            fmDataGrid1.RowCount = 40;

            WriteParameter(0, fmGlobalParameter.Dp);
            WriteParameter(1, fmGlobalParameter.Dp_d);

            WriteParameter(2, fmGlobalParameter.eps0_d);
            WriteParameter(3, fmGlobalParameter.ne_d);
            WriteParameter(4, fmGlobalParameter.eps_d);

            block1 = new fmEps0dNedEpsdBlock(
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
            WriteParameter(12, fmGlobalParameter.ad1);
            WriteParameter(13, fmGlobalParameter.ad2);
            WriteParameter(14, fmGlobalParameter.Tetta);
            WriteParameter(15, fmGlobalParameter.eta_g);
            WriteParameter(16, fmGlobalParameter.ag1);
            WriteParameter(17, fmGlobalParameter.ag2);
            WriteParameter(18, fmGlobalParameter.ag3);
            WriteParameter(19, fmGlobalParameter.Tetta_boil);
            WriteParameter(20, fmGlobalParameter.DH);
            WriteParameter(21, fmGlobalParameter.Mmole);
            WriteParameter(22, fmGlobalParameter.f);
            WriteParameter(23, fmGlobalParameter.peq);

            var block3 = new fmSremTettaAdAgDHRmMmoleFPeqBlock(
                fmDataGrid1.Rows[11].Cells[2],
                fmDataGrid1.Rows[12].Cells[2],
                fmDataGrid1.Rows[13].Cells[2],
                fmDataGrid1.Rows[14].Cells[2],
                fmDataGrid1.Rows[15].Cells[2],
                fmDataGrid1.Rows[16].Cells[2],
                fmDataGrid1.Rows[17].Cells[2],
                fmDataGrid1.Rows[18].Cells[2],
                fmDataGrid1.Rows[19].Cells[2],
                fmDataGrid1.Rows[20].Cells[2],
                fmDataGrid1.Rows[21].Cells[2],
                fmDataGrid1.Rows[22].Cells[2],
                fmDataGrid1.Rows[23].Cells[2]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            block2.Dp_Value = fmValue.ObjectToValue(fmDataGrid1.Rows[0].Cells[2].Value);
            block2.Dpd_Value = block1.Dp_Value;
            block2.nc_Value = new fmValue(0.2);
            block2.eps_d_Value = block1.epsd_Value;
            block2.rho_s_Value = new fmValue(1000);
            block2.CalculateAndDisplay();
        }
    }
}
