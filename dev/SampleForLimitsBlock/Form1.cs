using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fmCalcBlocksLibrary.Blocks;

namespace SampleForLimitsBlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fmDataGrid1.RowCount = 10;
            fmDataGrid1.Rows[0].Cells[0].Value = "A";
            fmDataGrid1.Rows[1].Cells[0].Value = "Dp";
            fmDataGrid1.Rows[2].Cells[0].Value = "sf";
            fmDataGrid1.Rows[3].Cells[0].Value = "sr";
            fmDataGrid1.Rows[4].Cells[0].Value = "tc";
            fmDataGrid1.Rows[5].Cells[0].Value = "n";
            fmDataGrid1.Rows[6].Cells[0].Value = "hc";
            fmDataGrid1.Rows[7].Cells[0].Value = "tf";
            fmDataGrid1.Rows[8].Cells[0].Value = "tr";
            var fslb = new fmSimulationLimitsBlock(
                fmDataGrid1.Rows[0].Cells[2], fmDataGrid1.Rows[0].Cells[3],
                fmDataGrid1.Rows[1].Cells[2], fmDataGrid1.Rows[1].Cells[3],
                fmDataGrid1.Rows[2].Cells[2], fmDataGrid1.Rows[2].Cells[3],
                fmDataGrid1.Rows[3].Cells[2], fmDataGrid1.Rows[3].Cells[3],
                fmDataGrid1.Rows[4].Cells[2], fmDataGrid1.Rows[4].Cells[3],
                fmDataGrid1.Rows[5].Cells[2], fmDataGrid1.Rows[5].Cells[3],
                fmDataGrid1.Rows[6].Cells[2], fmDataGrid1.Rows[6].Cells[3],
                fmDataGrid1.Rows[7].Cells[2], fmDataGrid1.Rows[7].Cells[3],
                fmDataGrid1.Rows[8].Cells[2], fmDataGrid1.Rows[8].Cells[3]);
        }
    }
}
