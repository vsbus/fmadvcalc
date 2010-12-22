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
                                           p.defaultXRange.isUnlimited,
                                       });

                if (p.defaultXRange.isUnlimited == false)
                {
                    ParamGrid["MinRangeColumn", rowIndex].Value = new fmValue(p.defaultXRange.MinValue / p.unitFamily.CurrentUnit.Coef).ToString();
                    ParamGrid["MaxRangeColumn", rowIndex].Value = new fmValue(p.defaultXRange.MaxValue / p.unitFamily.CurrentUnit.Coef).ToString();
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
                if (p.globalParameter.defaultXRange != null)
                {
                    int rowIndex = ParamGrid.Rows.Add(new object[]
                                           {
                                               p.globalParameter.name,
                                               p.globalParameter.unitFamily.CurrentUnit.Name,
                                               p.globalParameter.defaultXRange.isUnlimited,
                                           });

                    if (p.globalParameter.defaultXRange.isUnlimited == false)
                    {
                        ParamGrid["MinRangeColumn", rowIndex].Value = p.globalParameter.defaultXRange.MinValue / p.globalParameter.unitFamily.CurrentUnit.Coef;
                        ParamGrid["MaxRangeColumn", rowIndex].Value = p.globalParameter.defaultXRange.MaxValue / p.globalParameter.unitFamily.CurrentUnit.Coef;
                    }

                    fmFilterSimulationControl.SetRowBackColor(ParamGrid.Rows[rowIndex], Color.LightGreen);
                }
            }
        }

// ReSharper disable InconsistentNaming
        private void buttonOK_Click(object sender, System.EventArgs e)
// ReSharper restore InconsistentNaming
        {
            for (int i = 0; i < ParamGrid.Rows.Count; ++i)
            {
                fmBlockVariableParameter v = new fmFilterMachiningBlock().GetParameterByName(ParamGrid.Rows[i].Cells["ParameterNameColumn"].Value.ToString());
                fmGlobalParameter p = (v == null) 
                    ? fmGlobalParameter.parametersByName[ParamGrid.Rows[i].Cells["ParameterNameColumn"].Value.ToString()]
                    : v.globalParameter;

                if ((bool)ParamGrid.Rows[i].Cells["UnlimitedFlagColumn"].Value == false)
                {
                    p.defaultXRange.isUnlimited = false;
                    p.defaultXRange.MinValue = fmValue.ObjectToValue(ParamGrid.Rows[i].Cells["MinRangeColumn"].Value).value * p.unitFamily.CurrentUnit.Coef;
                    p.defaultXRange.MaxValue = fmValue.ObjectToValue(ParamGrid.Rows[i].Cells["MaxRangeColumn"].Value).value * p.unitFamily.CurrentUnit.Coef;
                }
                else
                {
                    p.defaultXRange.isUnlimited = true;
                }
            }
            Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}