using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Blocks;
using fmCalculationLibrary;
using System.Collections.Generic;

namespace FilterSimulation
{
    public partial class fmParameterIntervalOption : Form
    {
        public fmParameterIntervalOption()
        {
            InitializeComponent();
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            var fmb = new fmFilterMachiningBlock();
            var pList = new List<fmBlockVariableParameter>
                            {
                                fmb.GetParameterByName(fmGlobalParameter.A.name),
                                fmb.GetParameterByName(fmGlobalParameter.Dp.name),
                                fmb.GetParameterByName(fmGlobalParameter.sf.name),
                                fmb.GetParameterByName(fmGlobalParameter.tc.name)
                            };
            foreach (fmBlockVariableParameter p in pList)
            {
                if (p.globalParameter.chartDefaultXRange != null)
                {
                    int rowIndex = ParamGrid.Rows.Add(new object[]
                                           {
                                               p.globalParameter.name,
                                               p.globalParameter.unitFamily.CurrentUnit.Name,
                                               p.globalParameter.chartDefaultXRange.isUnlimited,
                                           });

                    if (p.globalParameter.chartDefaultXRange.isUnlimited == false)
                    {
                        ParamGrid["MinRangeColumn", rowIndex].Value = p.globalParameter.chartDefaultXRange.MinValue / p.globalParameter.unitFamily.CurrentUnit.Coef;
                        ParamGrid["MaxRangeColumn", rowIndex].Value = p.globalParameter.chartDefaultXRange.MaxValue / p.globalParameter.unitFamily.CurrentUnit.Coef;
                    }
                }
            }
        }

// ReSharper disable InconsistentNaming
        private void buttonOK_Click(object sender, System.EventArgs e)
// ReSharper restore InconsistentNaming
        {
            //int i = 0;
            //foreach (fmBlockVariableParameter p in new fmFilterMachiningBlock().Parameters)
            for (int i = 0; i < ParamGrid.Rows.Count; ++i)
            {
                fmBlockVariableParameter p = new fmFilterMachiningBlock().GetParameterByName(ParamGrid.Rows[i].Cells["ParameterNameColumn"].Value.ToString());
                if (p.globalParameter.chartDefaultXRange != null)
                {
                    if ((bool)ParamGrid.Rows[i].Cells["UnlimitedFlagColumn"].Value == false)
                    {
                        p.globalParameter.chartDefaultXRange.isUnlimited = false;
                        p.globalParameter.chartDefaultXRange.MinValue = fmValue.ObjectToValue(ParamGrid.Rows[i].Cells["MinRangeColumn"].Value).value * p.globalParameter.unitFamily.CurrentUnit.Coef;
                        p.globalParameter.chartDefaultXRange.MaxValue = fmValue.ObjectToValue(ParamGrid.Rows[i].Cells["MaxRangeColumn"].Value).value * p.globalParameter.unitFamily.CurrentUnit.Coef;
                    }
                    else
                    {
                        p.globalParameter.chartDefaultXRange.isUnlimited = true;
                    }
                    //++i;
                }
            }
            Close();
        }
    }
}