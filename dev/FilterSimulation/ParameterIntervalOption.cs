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
        private fmSimulationLimitsBlock smb;

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
                                           p.specifiedRange.isUnlimited,
                                       });

                if (p.specifiedRange.isUnlimited == false)
                {
                    ParamGrid["MinRangeColumn", rowIndex].Value = new fmValue(p.specifiedRange.MinValue / p.unitFamily.CurrentUnit.Coef).ToString();
                    ParamGrid["MaxRangeColumn", rowIndex].Value = new fmValue(p.specifiedRange.MaxValue / p.unitFamily.CurrentUnit.Coef).ToString();
                }

                fmFilterSimulationControl.SetRowBackColor(ParamGrid.Rows[rowIndex], Color.LightBlue);
            }

            var fmb = new fmFilterMachiningBlock();
            var pList = new List<fmBlockVariableParameter>
                            {
                                fmb.GetParameterByName(fmGlobalParameter.A.name),
                                fmb.GetParameterByName(fmGlobalParameter.Dp.name),
                                fmb.GetParameterByName(fmGlobalParameter.sf.name),
                                fmb.GetParameterByName(fmGlobalParameter.tc.name),
                                fmb.GetParameterByName(fmGlobalParameter.hc.name)
                            };
            Dictionary<fmGlobalParameter, int> rowId = new Dictionary<fmGlobalParameter, int>();
            foreach (fmBlockVariableParameter p in pList)
            {
                if (p.globalParameter.specifiedRange != null)
                {
                    int rowIndex = ParamGrid.Rows.Add(new object[]
                                           {
                                               p.globalParameter.name,
                                               p.globalParameter.unitFamily.CurrentUnit.Name,
                                               p.globalParameter.specifiedRange.isUnlimited,
                                           });
                    rowId[p.globalParameter] = rowIndex;
                    //if (p.globalParameter.validRange.isUnlimited == false)
                    //{
                    //    ParamGrid["MinRangeColumn", rowIndex].Value = p.globalParameter.validRange.MinValue / p.globalParameter.unitFamily.CurrentUnit.Coef;
                    //    ParamGrid["MaxRangeColumn", rowIndex].Value = p.globalParameter.validRange.MaxValue / p.globalParameter.unitFamily.CurrentUnit.Coef;
                    //}

                    fmFilterSimulationControl.SetRowBackColor(ParamGrid.Rows[rowIndex], Color.LightGreen);
                }
            }

            smb = new fmSimulationLimitsBlock(
                ParamGrid[3, rowId[fmGlobalParameter.A]], ParamGrid[4, rowId[fmGlobalParameter.A]], 
                ParamGrid[3, rowId[fmGlobalParameter.Dp]], ParamGrid[4, rowId[fmGlobalParameter.Dp]], 
                ParamGrid[3, rowId[fmGlobalParameter.sf]], ParamGrid[4, rowId[fmGlobalParameter.sf]], 
                ParamGrid[3, rowId[fmGlobalParameter.tc]], ParamGrid[4, rowId[fmGlobalParameter.tc]], 
                ParamGrid[3, rowId[fmGlobalParameter.hc]], ParamGrid[4, rowId[fmGlobalParameter.hc]]
                );
            foreach (var p in smb.Parameters)
            {
                p.pMin.value = new fmValue(p.globalParameter.specifiedRange.MinValue);
                p.pMax.value = new fmValue(p.globalParameter.specifiedRange.MaxValue);
                p.IsInputed = p.globalParameter.specifiedRange.IsInputed;
            }
            smb.Display();
        }

// ReSharper disable InconsistentNaming
        private void buttonOK_Click(object sender, System.EventArgs e)
// ReSharper restore InconsistentNaming
        {
            foreach (var p in fmGlobalParameter.parameters)
            {
                p.specifiedRange.IsInputed = false;
            }

            for (int i = 0; i < ParamGrid.Rows.Count; ++i)
            {
                fmBlockVariableParameter v = new fmFilterMachiningBlock().GetParameterByName(ParamGrid.Rows[i].Cells["ParameterNameColumn"].Value.ToString());
                fmGlobalParameter p = (v == null) 
                    ? fmGlobalParameter.parametersByName[ParamGrid.Rows[i].Cells["ParameterNameColumn"].Value.ToString()]
                    : v.globalParameter;

                var parInBlock = smb.GetParameterByName(p.name);
                p.specifiedRange.IsInputed = (parInBlock != null && parInBlock.IsInputed == true);
                if ((bool)ParamGrid.Rows[i].Cells["UnlimitedFlagColumn"].Value == false)
                {
                    p.specifiedRange.isUnlimited = false;
                    p.specifiedRange.MinValue = fmValue.ObjectToValue(ParamGrid.Rows[i].Cells["MinRangeColumn"].Value).value * p.unitFamily.CurrentUnit.Coef;
                    p.specifiedRange.MaxValue = fmValue.ObjectToValue(ParamGrid.Rows[i].Cells["MaxRangeColumn"].Value).value * p.unitFamily.CurrentUnit.Coef;
                }
                else
                {
                    p.specifiedRange.isUnlimited = true;
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