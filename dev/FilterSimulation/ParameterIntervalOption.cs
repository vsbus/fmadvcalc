using System.Windows.Forms;
using fmCalcBlocksLibrary;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Blocks;
using fmCalculationLibrary;
using System.Collections.Generic;

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
            fmFilterMachiningBlock fmb = new fmFilterMachiningBlock();
            List<fmBlockVariableParameter> pList = new List<fmBlockVariableParameter>();
            pList.Add(fmb.GetParameterByName(fmGlobalParameter.A.name));
            pList.Add(fmb.GetParameterByName(fmGlobalParameter.Dp.name));
            pList.Add(fmb.GetParameterByName(fmGlobalParameter.sf.name));
            //pList.Add(fmb.GetParameterByName(fmGlobalParameter.hc.name));
            pList.Add(fmb.GetParameterByName(fmGlobalParameter.tc.name));
            //pList.Add(fmb.GetParameterByName(fmGlobalParameter.n.name));
            foreach (fmBlockVariableParameter p in pList)
            //foreach (fmBlockVariableParameter p in new fmFilterMachiningBlock().Parameters)
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
                        ParamGrid["MinRangeColumn", rowIndex].Value = p.globalParameter.chartDefaultXRange.minValue / p.globalParameter.unitFamily.CurrentUnit.Coef;
                        ParamGrid["MaxRangeColumn", rowIndex].Value = p.globalParameter.chartDefaultXRange.maxValue / p.globalParameter.unitFamily.CurrentUnit.Coef;
                    }
                }
            }
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
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
                        p.globalParameter.chartDefaultXRange.minValue = fmValue.ObjectToValue(ParamGrid.Rows[i].Cells["MinRangeColumn"].Value).value * p.globalParameter.unitFamily.CurrentUnit.Coef;
                        p.globalParameter.chartDefaultXRange.maxValue = fmValue.ObjectToValue(ParamGrid.Rows[i].Cells["MaxRangeColumn"].Value).value * p.globalParameter.unitFamily.CurrentUnit.Coef;
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

        private void ParamGrid_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            //if (ParamGrid.Columns[e.ColumnIndex].Name == "UnlimitedFlagColumn")
            //{
            //    fmGlobalParameter p = fmGlobalParameter.ParametersByName[ParamGrid["ParameterNameColumn", e.RowIndex].Value as string];
            //    bool value = (bool)ParamGrid[e.ColumnIndex, e.RowIndex].Value;
            //    if (value == false)
            //    {
            //        p.chartDefaultXRange.isUnlimited = false;
            //        ParamGrid["MinRangeColumn", e.RowIndex].Value = p.chartDefaultXRange.minValue / p.unitFamily.CurrentUnit.Coef;
            //        ParamGrid["MaxRangeColumn", e.RowIndex].Value = p.chartDefaultXRange.maxValue / p.unitFamily.CurrentUnit.Coef;
            //    }
            //    else
            //    {
            //        p.chartDefaultXRange.isUnlimited = true;
            //        ParamGrid["MinRangeColumn", e.RowIndex].Value = "";
            //        ParamGrid["MaxRangeColumn", e.RowIndex].Value = "";
            //    }
            //}
        }
    }
}