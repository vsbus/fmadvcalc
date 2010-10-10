using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Blocks;
using fmCalculationLibrary;
using System.Collections.Generic;
using System.Drawing;

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
            var materialParametersList = new List<fmGlobalParameter>
                            {
                                fmGlobalParameter.eta_f,
                                fmGlobalParameter.rho_f,
                                fmGlobalParameter.rho_s,
                                fmGlobalParameter.rho_sus,
                                fmGlobalParameter.Cm,
                                fmGlobalParameter.Cv,
                                fmGlobalParameter.C,
                                
                                fmGlobalParameter.eps,
                                fmGlobalParameter.kappa,
                                fmGlobalParameter.ne,
                                fmGlobalParameter.Pc0,
                                fmGlobalParameter.rc0,
                                fmGlobalParameter.a0,
                                fmGlobalParameter.nc,
                                fmGlobalParameter.hce0,
                                fmGlobalParameter.Rm0
                            };

            foreach (fmGlobalParameter p in materialParametersList)
            {
                int rowIndex = ParamGrid.Rows.Add(new object[]
                                       {
                                           p.name,
                                           p.unitFamily.CurrentUnit.Name,
                                           p.chartDefaultXRange.isUnlimited,
                                       });

                if (p.chartDefaultXRange.isUnlimited == false)
                {
                    ParamGrid["MinRangeColumn", rowIndex].Value = new fmValue(p.chartDefaultXRange.MinValue / p.unitFamily.CurrentUnit.Coef).ToString();
                    ParamGrid["MaxRangeColumn", rowIndex].Value = new fmValue(p.chartDefaultXRange.MaxValue / p.unitFamily.CurrentUnit.Coef).ToString();
                }

                fmFilterSimulationControl.SetRowBackColor(ParamGrid.Rows[rowIndex], Color.LightBlue);
            }

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

                    fmFilterSimulationControl.SetRowBackColor(ParamGrid.Rows[rowIndex], Color.LightGreen);
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
                fmBlockVariableParameter v = new fmFilterMachiningBlock().GetParameterByName(ParamGrid.Rows[i].Cells["ParameterNameColumn"].Value.ToString());
                fmGlobalParameter p = (v == null) 
                    ? fmGlobalParameter.parametersByName[ParamGrid.Rows[i].Cells["ParameterNameColumn"].Value.ToString()]
                    : v.globalParameter;

                if ((bool)ParamGrid.Rows[i].Cells["UnlimitedFlagColumn"].Value == false)
                {
                    p.chartDefaultXRange.isUnlimited = false;
                    p.chartDefaultXRange.MinValue = fmValue.ObjectToValue(ParamGrid.Rows[i].Cells["MinRangeColumn"].Value).value * p.unitFamily.CurrentUnit.Coef;
                    p.chartDefaultXRange.MaxValue = fmValue.ObjectToValue(ParamGrid.Rows[i].Cells["MaxRangeColumn"].Value).value * p.unitFamily.CurrentUnit.Coef;
                }
                else
                {
                    p.chartDefaultXRange.isUnlimited = true;
                }
            }
            Close();
        }
    }
}