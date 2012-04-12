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

        private void WriteParameter2(int rowIndex, fmGlobalParameter p)
        {
            fmDataGrid1.Rows[rowIndex].Cells[0 + 3].Value = p.name;
            fmDataGrid1.Rows[rowIndex].Cells[1 + 3].Value = p.unitFamily.CurrentUnit.Name;
        }

        private fmEps0dNedEpsdBlock block1;
        private fmSigmaPke0PkePcdRcdAlphadBlock block2;
        private fmSremTettaAdAgDHRmMmoleFPeqBlock block3;
        //private fmDeliquoringSimualtionBlock block4;

        private void Form1_Load(object sender, EventArgs e)
        {
            fmDataGrid1.RowCount = 40;

            WriteParameter(0, fmGlobalParameter.Dp);
            WriteParameter(1, fmGlobalParameter.Dp_d);

            WriteParameter(2, fmGlobalParameter.eps_d);

            block1 = new fmEps0dNedEpsdBlock(
                fmDataGrid1.Rows[1].Cells[2],
                fmDataGrid1.Rows[2].Cells[2],
                fmDataGrid1.Rows[3].Cells[2]);

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
                fmDataGrid1.Rows[10].Cells[2],
                fmDataGrid1.Rows[11].Cells[2],
                fmDataGrid1.Rows[12].Cells[2]);

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

            block3 = new fmSremTettaAdAgDHRmMmoleFPeqBlock(
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

            WriteParameter2(0, fmGlobalParameter.hcd);
            WriteParameter2(1, fmGlobalParameter.sd);
            WriteParameter2(2, fmGlobalParameter.td);
            WriteParameter2(3, fmGlobalParameter.K);
            WriteParameter2(4, fmGlobalParameter.Smech);
            WriteParameter2(5, fmGlobalParameter.S);
            WriteParameter2(6, fmGlobalParameter.Rfmech);
            WriteParameter2(7, fmGlobalParameter.Rf);
            WriteParameter2(9, fmGlobalParameter.Qgi);
            WriteParameter2(10, fmGlobalParameter.Qg);
            WriteParameter2(11, fmGlobalParameter.vg);
            WriteParameter2(12, fmGlobalParameter.Mfd);
            WriteParameter2(13, fmGlobalParameter.Vfd);
            WriteParameter2(14, fmGlobalParameter.Mlcd);
            WriteParameter2(15, fmGlobalParameter.Vlcd);
            WriteParameter2(16, fmGlobalParameter.Mcd);
            WriteParameter2(17, fmGlobalParameter.Vcd);
            WriteParameter2(18, fmGlobalParameter.rho_bulk);
            WriteParameter2(19, fmGlobalParameter.Qmfid);
            WriteParameter2(20, fmGlobalParameter.Qfid);
            WriteParameter2(21, fmGlobalParameter.Qmcd);
            WriteParameter2(22, fmGlobalParameter.Qcd);
            WriteParameter2(23, fmGlobalParameter.qmfid);
            WriteParameter2(24, fmGlobalParameter.qfid);
            WriteParameter2(25, fmGlobalParameter.qmcd);
            WriteParameter2(26, fmGlobalParameter.qcd);

//             block4 = new fmDeliquoringSimualtionBlock(
//                 fmDataGrid1.Rows[0].Cells[5],
//                 fmDataGrid1.Rows[1].Cells[5],
//                 fmDataGrid1.Rows[2].Cells[5],
//                 fmDataGrid1.Rows[3].Cells[5],
//                 fmDataGrid1.Rows[4].Cells[5],
//                 fmDataGrid1.Rows[5].Cells[5],
//                 fmDataGrid1.Rows[6].Cells[5],
//                 fmDataGrid1.Rows[7].Cells[5],
//                 fmDataGrid1.Rows[8].Cells[5],
//                 fmDataGrid1.Rows[9].Cells[5],
//                 fmDataGrid1.Rows[10].Cells[5],
//                 fmDataGrid1.Rows[11].Cells[5],
//                 fmDataGrid1.Rows[12].Cells[5],
//                 fmDataGrid1.Rows[13].Cells[5],
//                 fmDataGrid1.Rows[14].Cells[5],
//                 fmDataGrid1.Rows[15].Cells[5],
//                 fmDataGrid1.Rows[16].Cells[5],
//                 fmDataGrid1.Rows[17].Cells[5],
//                 fmDataGrid1.Rows[18].Cells[5],
//                 fmDataGrid1.Rows[19].Cells[5],
//                 fmDataGrid1.Rows[20].Cells[5],
//                 fmDataGrid1.Rows[21].Cells[5],
//                 fmDataGrid1.Rows[22].Cells[5],
//                 fmDataGrid1.Rows[23].Cells[5],
//                 fmDataGrid1.Rows[24].Cells[5],
//                 fmDataGrid1.Rows[25].Cells[5],
//                 fmDataGrid1.Rows[26].Cells[5]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            block2.Dp_Value = fmValue.ObjectToValue(fmDataGrid1.Rows[0].Cells[2].Value);
            block2.Dpd_Value = block1.Dp_Value;
            block2.nc_Value = new fmValue(0.2);
            block2.eps_d_Value = block1.epsd_Value;
            block2.rho_s_Value = new fmValue(1000);
            block2.CalculateAndDisplay();

            //block4.hc_Value = new fmValue(20e-3);
            //block4.eps_Value = new fmValue(0.3);
            //block4.epsd_Value = block1.epsd_Value;
            //block4.A_Value = new fmValue(1.0);
            //block4.ad1_Value = new fmValue(0.1);
            //block4.ad2_Value = new fmValue(0.2);
            //block4.ag1_Value = new fmValue(0.31);
            //block4.ag2_Value = new fmValue(0.32);
            //block4.ag3_Value = new fmValue(0.33);
            //block4.Dpd_Value = block1.Dp_Value;
            //block4.etaf_Value = new fmValue(1);
            //block4.etag_Value = new fmValue(2);
            //block4.f_Value = new fmValue(1.1);
            //block4.hce_Value = new fmValue(5e-3);
            //block4.Mmole_Value = new fmValue(18);
            //block4.pcd_Value = new fmValue(0.1);
            //block4.peq_Value = new fmValue(0.2);
            //block4.pke_Value = new fmValue(0.3);
            //block4.rhof_Value = new fmValue(1000);
            //block4.rhos_Value = new fmValue(2250);
            //block4.Srem_Value = new fmValue(0.5);
            //block4.tc_Value = new fmValue(100);
            //block4.Tetta_Value = new fmValue(20);
            //block4.CalculateAndDisplay();
        }
    }
}
