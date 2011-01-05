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

        private void Form1_Load(object sender, EventArgs e)
        {
            fmDataGrid1.RowCount = 20;

            WriteParameter(0, fmGlobalParameter.Dp_d);

            WriteParameter(2, fmGlobalParameter.eps0_d);
            WriteParameter(3, fmGlobalParameter.ne_d);
            WriteParameter(4, fmGlobalParameter.eps_d);

            fmEps0NeEpsBlock block1 = new fmEps0NeEpsBlock(
                fmDataGrid1.Rows[0].Cells[2],
                fmDataGrid1.Rows[2].Cells[2],
                fmDataGrid1.Rows[3].Cells[2],
                fmDataGrid1.Rows[4].Cells[2]);
        }
    }
}
