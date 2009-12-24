using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using fmCalculationLibrary.MeasureUnits;
using Event=fmCalcBlocksLibrary.BlockParameter.Event;
using fmEpsKappaBlock=fmCalcBlocksLibrary.Blocks.fmEpsKappaBlock;
using fmPcrcaBlock=fmCalcBlocksLibrary.Blocks.fmPcrcaBlock;
using fmRmhceBlock=fmCalcBlocksLibrary.Blocks.fmRmhceBlock;
using fmSuspensionWithEtafBlock=fmCalcBlocksLibrary.Blocks.fmSuspensionWithEtafBlock;

namespace TestApplication
{
    public partial class Form1 : Form
    {
        fmEpsKappaBlock epsBlock;
        fmSuspensionWithEtafBlock susBlock;
        fmPcrcaBlock pcrcaBlock;
        fmRmhceBlock rmhceBlock;
        //fmCalcBlocksLibrary.fmFilterMachiningBlock filterMachiningBlock;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fmDataGrid1.RowCount = 8;
            susBlock = new fmSuspensionWithEtafBlock(
                radioButton1, radioButton2, radioButton3, radioButton4,
                fmDataGrid1.Rows[0].Cells[0],
                fmDataGrid1.Rows[1].Cells[0],
                fmDataGrid1.Rows[2].Cells[0],
                fmDataGrid1.Rows[3].Cells[0],
                fmDataGrid1.Rows[4].Cells[0],
                fmDataGrid1.Rows[5].Cells[0],
                fmDataGrid1.Rows[6].Cells[0]);
            

            fmDataGrid2.RowCount = 2;
            fmDataGrid2.Rows[0].Cells[0].Value = "eps";
            fmDataGrid2.Rows[1].Cells[0].Value = "kappa";

            epsBlock = new fmEpsKappaBlock(
                fmDataGrid2.Rows[0].Cells[1],
                fmDataGrid2.Rows[1].Cells[1]);

            susBlock.ValuesChanged += new Event(susBlock_ValuesChanged);

            fmDataGrid3.RowCount = 3;
            fmDataGrid3.Rows[0].Cells[0].Value = "Pc";
            fmDataGrid3.Rows[1].Cells[0].Value = "rc";
            fmDataGrid3.Rows[2].Cells[0].Value = "a";
            pcrcaBlock = new fmPcrcaBlock(
                fmDataGrid3.Rows[0].Cells[1],
                fmDataGrid3.Rows[1].Cells[1],
                fmDataGrid3.Rows[2].Cells[1]);

            epsBlock.ValuesChanged += new Event(epsBlock_ValuesChanged);

            fmDataGrid4.RowCount = 2;
            fmDataGrid4.Rows[0].Cells[0].Value = "hce";
            fmDataGrid4.Rows[1].Cells[0].Value = "Rm0";

            rmhceBlock = new fmRmhceBlock(
                fmDataGrid4.Rows[0].Cells[1],
                fmDataGrid4.Rows[1].Cells[1]);

            rmhceBlock.ValuesChanged += new Event(rmhceBlock_ValuesChanged);

            pcrcaBlock.ValuesChanged += new Event(pcrcaBlock_ValuesChanged);

            fmDataGrid5.Rows.Add( new object[] { "A", "0,01" } );
            fmDataGrid5.Rows.Add(new object[] { "Dp", "1" });
            fmDataGrid5.Rows.Add(new object[] { "sf", "0,5" });
            fmDataGrid5.Rows.Add(new object[] { "n", "1000" });
            fmDataGrid5.Rows.Add(new object[] { "tc", "20" });
            fmDataGrid5.Rows.Add(new object[] { "tf", "20" });
            fmDataGrid5.Rows.Add(new object[] { "hc", "0,010" });
            fmDataGrid5.Rows.Add(new object[] { "Mf", "0,05" });
            fmDataGrid5.Rows.Add(new object[] { "Msus", "0,03" });
            fmDataGrid5.Rows.Add(new object[] { "Vsus", "0,01" });
            fmDataGrid5.Rows.Add(new object[] { "Ms", "0,02" });
            fmDataGrid5.Rows.Add(new object[] { "Qsus", "1" });
            fmDataGrid5.Rows.Add(new object[] { "Qmsus", "2" });
            fmDataGrid5.Rows.Add(new object[] { "Qms", "3" });
        }

        void rmhceBlock_ValuesChanged(object sender)
        {
        }

        void pcrcaBlock_ValuesChanged(object sender)
        {
            rmhceBlock.Pc_Value = pcrcaBlock.Pc_Value;
            rmhceBlock.CalculateAndDisplay();
        }

        void  epsBlock_ValuesChanged(object sender)
        {
            pcrcaBlock.rho_s_Value = susBlock.rho_s_Value;
            pcrcaBlock.eps_Value = epsBlock.eps_Value;
            pcrcaBlock.CalculateAndDisplay();
        }

        void susBlock_ValuesChanged(object sender)
        {
            epsBlock.Cv_Value = susBlock.Cv_Value;
            epsBlock.CalculateAndDisplay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fmUnitFamily.ConcentrationFamily.SetCurrentUnit("%");
            susBlock.CalculateAndDisplay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int deb = 0;
            deb++;
        }
    }
}