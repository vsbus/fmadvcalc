using System.Windows.Forms;
using fmCalcBlocksLibrary;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Blocks;
using fmCalculationLibrary;

namespace FilterSimulation
{
    public partial class ParameterIntervalOption : Form
    {
        public ParameterIntervalOption()
        {
            InitializeComponent();
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            foreach (fmBlockParameter p in new fmFilterMachiningBlock(null).Parameters)
            {
                if (p.globalParameter.chartXRange != null)
                {
                    ParamGrid.Rows.Add(new object[]
                                           {
                                               p.name,
                                               p.unitFamily.CurrentUnit.Name,
                                               p.globalParameter.chartXRange.minValue/p.unitFamily.CurrentUnit.Coef,
                                               p.globalParameter.chartXRange.maxValue/p.unitFamily.CurrentUnit.Coef
                                           });
                }
            }
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            int i = 0;
            foreach (fmBlockParameter p in new fmFilterMachiningBlock(null).Parameters)
            {
                if (p.globalParameter.chartXRange != null)
                {
                    p.globalParameter.chartXRange.minValue = fmValue.ObjectToValue(ParamGrid.Rows[i].Cells["MinRangeColumn"].Value).Value * p.unitFamily.CurrentUnit.Coef;
                    p.globalParameter.chartXRange.maxValue = fmValue.ObjectToValue(ParamGrid.Rows[i].Cells["MaxRangeColumn"].Value).Value * p.unitFamily.CurrentUnit.Coef;
                    ++i;
                }
            }
            Close();
        }
    }
}