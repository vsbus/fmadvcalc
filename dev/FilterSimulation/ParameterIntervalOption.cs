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
        private fmSimulationLimitsBlock cakeFormationLimitsBlock;
        private fmDeliquoringLimitsBlock deliquoringLimitsBlock;

        public fmParameterIntervalOption()
        {
            InitializeComponent();
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            FillTable(MaterialParametersGrid,
                      Color.LightBlue,
                      new List<fmGlobalParameter>
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
                          });

            FillTable(deliquoringMaterialParameterGrid,
                      Color.LightPink,
                      new List<fmGlobalParameter>
                          {
                              fmGlobalParameter.eta_d,
                              fmGlobalParameter.rho_d,
                              fmGlobalParameter.sigma,
                              fmGlobalParameter.pke0,
                              fmGlobalParameter.pke,
                              fmGlobalParameter.eps_d,
                              fmGlobalParameter.pc_d,
                              fmGlobalParameter.rc_d,
                              fmGlobalParameter.alpha_d,
                              fmGlobalParameter.Srem,
                              fmGlobalParameter.ad1,
                              fmGlobalParameter.ad2,
                              fmGlobalParameter.Tetta,
                              fmGlobalParameter.eta_g,
                              fmGlobalParameter.ag1,
                              fmGlobalParameter.ag2,
                              fmGlobalParameter.ag3,
                              fmGlobalParameter.Tetta_boil,
                              fmGlobalParameter.DH,
                              fmGlobalParameter.f,
                          });

            #region Cake Formation Parameters

            {
                var cakeFormationParametersList = new List<fmGlobalParameter>
                                                      {
                                                          fmGlobalParameter.A,
                                                          fmGlobalParameter.Dp,
                                                          fmGlobalParameter.hc,
                                                          fmGlobalParameter.sf,
                                                          fmGlobalParameter.sr,
                                                          fmGlobalParameter.n,
                                                          fmGlobalParameter.tc,
                                                          fmGlobalParameter.tf,
                                                          fmGlobalParameter.tr
                                                      };

                var fmb = new fmFilterMachiningBlock();
                var pList = new List<fmBlockVariableParameter>();
                foreach (fmGlobalParameter parameter in cakeFormationParametersList)
                {
                    pList.Add(fmb.GetParameterByName(parameter.Name));
                }
                var rowId = new Dictionary<fmGlobalParameter, int>();
                foreach (fmBlockVariableParameter p in pList)
                {
                    if (p.globalParameter.SpecifiedRange != null)
                    {
                        int rowIndex = CakeFormationGrid.AddRow(p.globalParameter);
                        rowId[p.globalParameter] = rowIndex;
                        CakeFormationGrid.SetRawBackColor(rowIndex, Color.LightGreen);
                    }
                }

                cakeFormationLimitsBlock = new fmSimulationLimitsBlock(
                    CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.A]),
                    CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.A]),
                    CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.Dp]),
                    CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.Dp]),
                    CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.sf]),
                    CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.sf]),
                    CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.sr]),
                    CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.sr]),
                    CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.tc]),
                    CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.tc]),
                    CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.n]),
                    CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.n]),
                    CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.hc]),
                    CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.hc]),
                    CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.tf]),
                    CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.tf]),
                    CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.tr]),
                    CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.tr]));

                foreach (var p in cakeFormationLimitsBlock.Parameters)
                {
                    p.pMin.value = new fmValue(p.globalParameter.SpecifiedRange.MinValue);
                    p.pMax.value = new fmValue(p.globalParameter.SpecifiedRange.MaxValue);
                    p.IsInputed = p.globalParameter.SpecifiedRange.IsInputed;
                }
                cakeFormationLimitsBlock.Display();
            }

            #endregion

            #region Deliquoring Settings Parameters

            {
                var deliquoringSettingsParameters = new List<fmGlobalParameter>
                                                        {
                                                            fmGlobalParameter.Dp_d,
                                                            fmGlobalParameter.hcd,
                                                            fmGlobalParameter.sd,
                                                            fmGlobalParameter.td,
                                                            fmGlobalParameter.K
                                                        };

                var deliqBlock = new fmDeliquoringSimualtionBlock();
                var pList = new List<fmBlockVariableParameter>();
                foreach (fmGlobalParameter parameter in deliquoringSettingsParameters)
                {
                    fmBlockVariableParameter varPar = deliqBlock.GetParameterByName(parameter.Name);
                    if (varPar == null)
                    {
                        varPar = new fmBlockVariableParameter(parameter, true);
                    }
                    pList.Add(varPar);
                }
                var rowId = new Dictionary<fmGlobalParameter, int>();
                foreach (fmBlockVariableParameter p in pList)
                {
                    if (p.globalParameter.SpecifiedRange != null)
                    {
                        int rowIndex = deliquoringSettingsParametersGrid.AddRow(p.globalParameter);
                        rowId[p.globalParameter] = rowIndex;
                        deliquoringSettingsParametersGrid.SetRawBackColor(rowIndex, Color.LightGoldenrodYellow);
                    }
                }

                deliquoringLimitsBlock = new fmDeliquoringLimitsBlock(
                    deliquoringSettingsParametersGrid.RangeMinValueCell(rowId[fmGlobalParameter.Dp_d]),
                    deliquoringSettingsParametersGrid.RangeMaxValueCell(rowId[fmGlobalParameter.Dp_d]),
                    deliquoringSettingsParametersGrid.RangeMinValueCell(rowId[fmGlobalParameter.hcd]),
                    deliquoringSettingsParametersGrid.RangeMaxValueCell(rowId[fmGlobalParameter.hcd]),
                    deliquoringSettingsParametersGrid.RangeMinValueCell(rowId[fmGlobalParameter.sd]),
                    deliquoringSettingsParametersGrid.RangeMaxValueCell(rowId[fmGlobalParameter.sd]),
                    deliquoringSettingsParametersGrid.RangeMinValueCell(rowId[fmGlobalParameter.td]),
                    deliquoringSettingsParametersGrid.RangeMaxValueCell(rowId[fmGlobalParameter.td]),
                    deliquoringSettingsParametersGrid.RangeMinValueCell(rowId[fmGlobalParameter.K]),
                    deliquoringSettingsParametersGrid.RangeMaxValueCell(rowId[fmGlobalParameter.K]));

                foreach (var p in deliquoringLimitsBlock.Parameters)
                {
                    p.pMin.value = new fmValue(p.globalParameter.SpecifiedRange.MinValue);
                    p.pMax.value = new fmValue(p.globalParameter.SpecifiedRange.MaxValue);
                    p.IsInputed = p.globalParameter.SpecifiedRange.IsInputed;
                }
                deliquoringLimitsBlock.Display();
            }

            #endregion
        }

        private static void FillTable(
            TableWithParameterRanges grid,
            Color color,
            IEnumerable<fmGlobalParameter> parametersList)
        {
            foreach (fmGlobalParameter p in parametersList)
            {
                int rowIndex = grid.AddRow(p);

                grid.RangeMinValueCell(rowIndex).Value =
                    new fmValue(p.SpecifiedRange.MinValue / p.UnitFamily.CurrentUnit.Coef).ToString();
                grid.RangeMaxValueCell(rowIndex).Value =
                    new fmValue(p.SpecifiedRange.MaxValue / p.UnitFamily.CurrentUnit.Coef).ToString();
                grid.SetRawBackColor(rowIndex, color);
            }
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            foreach (var p in fmGlobalParameter.Parameters)
            {
                p.SpecifiedRange.IsInputed = false;
            }

            var grids = new TableWithParameterRanges[]
                            {
                                MaterialParametersGrid,
                                deliquoringMaterialParameterGrid,
                                deliquoringSettingsParametersGrid,
                                CakeFormationGrid
                            };

            foreach (TableWithParameterRanges grid in grids)
            {
                for (int i = 0; i < grid.RowCount; ++i)
                {
                    fmGlobalParameter p = fmGlobalParameter.ParametersByName[grid.ParameterCell(i).Value.ToString()];
                    fmBlockLimitsParameter blockLimitParameter = null;
                    
                    if (blockLimitParameter == null)
                    {
                        blockLimitParameter = cakeFormationLimitsBlock.GetParameterByName(p.Name);
                    }
                    if (blockLimitParameter == null)
                    {
                        blockLimitParameter = deliquoringLimitsBlock.GetParameterByName(p.Name);
                    }
                    p.SpecifiedRange.IsInputed = blockLimitParameter != null
                                                     ? blockLimitParameter.IsInputed
                                                     : false;
                    p.SpecifiedRange.MinValue = fmValue.ObjectToValue(grid.RangeMinValueCell(i).Value).value *
                                                p.UnitFamily.CurrentUnit.Coef;
                    p.SpecifiedRange.MaxValue = fmValue.ObjectToValue(grid.RangeMaxValueCell(i).Value).value *
                                                p.UnitFamily.CurrentUnit.Coef;
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