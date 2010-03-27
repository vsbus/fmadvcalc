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
            foreach (fmBlockVariableParameter p in new fmFilterMachiningBlock().Parameters)
            {
                if (p.globalParameter.chartDefaultXRange != null)
                {
                    ParamGrid.Rows.Add(new object[]
                                           {
                                               p.globalParameter.name,
                                               p.globalParameter.unitFamily.CurrentUnit.Name,
                                               p.globalParameter.chartDefaultXRange.minValue/p.globalParameter.unitFamily.CurrentUnit.Coef,
                                               p.globalParameter.chartDefaultXRange.maxValue/p.globalParameter.unitFamily.CurrentUnit.Coef
                                           });
                }
            }
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            int i = 0;
            foreach (fmBlockVariableParameter p in new fmFilterMachiningBlock().Parameters)
            {
                if (p.globalParameter.chartDefaultXRange != null)
                {
                    p.globalParameter.chartDefaultXRange.minValue = fmValue.ObjectToValue(ParamGrid.Rows[i].Cells["MinRangeColumn"].Value).Value * p.globalParameter.unitFamily.CurrentUnit.Coef;
                    p.globalParameter.chartDefaultXRange.maxValue = fmValue.ObjectToValue(ParamGrid.Rows[i].Cells["MaxRangeColumn"].Value).Value * p.globalParameter.unitFamily.CurrentUnit.Coef;
                    ++i;
                }
            }
            Close();
        }
    }
}