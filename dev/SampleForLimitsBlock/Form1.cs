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
            var list = new[] { "A", "td", "Dp", "sf", "sr", "tc", "n", "hc", "tf", "tr" };
            fmDataGrid1.RowCount = list.Length;
            for (int i = 0; i < list.Length; ++i)
            {
                fmDataGrid1.Rows[i].Cells[0].Value = list[i];
            }
            //var fslb = new fmSimulationLimitsBlock(
            //    fmDataGrid1.Rows[0].Cells[2], fmDataGrid1.Rows[0].Cells[3],
            //    fmDataGrid1.Rows[1].Cells[2], fmDataGrid1.Rows[1].Cells[3],
            //    fmDataGrid1.Rows[2].Cells[2], fmDataGrid1.Rows[2].Cells[3],
            //    fmDataGrid1.Rows[3].Cells[2], fmDataGrid1.Rows[3].Cells[3],
            //    fmDataGrid1.Rows[4].Cells[2], fmDataGrid1.Rows[4].Cells[3],
            //    fmDataGrid1.Rows[5].Cells[2], fmDataGrid1.Rows[5].Cells[3],
            //    fmDataGrid1.Rows[6].Cells[2], fmDataGrid1.Rows[6].Cells[3],
            //    fmDataGrid1.Rows[7].Cells[2], fmDataGrid1.Rows[7].Cells[3],
            //    fmDataGrid1.Rows[8].Cells[2], fmDataGrid1.Rows[8].Cells[3],
            //    fmDataGrid1.Rows[9].Cells[2], fmDataGrid1.Rows[9].Cells[3]);
        }
    }
}
