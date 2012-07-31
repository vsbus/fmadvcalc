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
                pList.Add(fmb.GetParameterByName(parameter.name));
            }
            var rowId = new Dictionary<fmGlobalParameter, int>();
            foreach (fmBlockVariableParameter p in pList)
            {
                if (p.globalParameter.specifiedRange != null)
                {
                    int rowIndex = CakeFormationGrid.AddRow(p.globalParameter);
                    rowId[p.globalParameter] = rowIndex;
                    CakeFormationGrid.SetRawBackColor(rowIndex, Color.LightGreen);
                }
            }

            smb = new fmSimulationLimitsBlock(
                CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.A]),
                CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.A]),
                CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.Dp]),
                CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.Dp]),
                CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.sf]),
                CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.sf]),
                CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.tc]),
                CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.tc]),
                CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.n]),
                CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.n]),
                CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.hc]),
                CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.hc]));
            foreach (var p in smb.Parameters)
            {
                p.pMin.value = new fmValue(p.globalParameter.specifiedRange.MinValue);
                p.pMax.value = new fmValue(p.globalParameter.specifiedRange.MaxValue);
                p.IsInputed = p.globalParameter.specifiedRange.IsInputed;
            }
            smb.Display();

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
                    new fmValue(p.specifiedRange.MinValue / p.unitFamily.CurrentUnit.Coef).ToString();
                grid.RangeMaxValueCell(rowIndex).Value =
                    new fmValue(p.specifiedRange.MaxValue / p.unitFamily.CurrentUnit.Coef).ToString();
                grid.SetRawBackColor(rowIndex, color);
            }
        }

// ReSharper disable InconsistentNaming
        private void buttonOK_Click(object sender, System.EventArgs e)
// ReSharper restore InconsistentNaming
        {
            foreach (var p in fmGlobalParameter.parameters)
            {
                p.specifiedRange.IsInputed = false;
            }

            var grids = new TableWithParameterRanges[]
                            {
                                MaterialParametersGrid,
                                CakeFormationGrid
                            };

            foreach (TableWithParameterRanges grid in grids)
            {
                for (int i = 0; i < grid.RowCount; ++i)
                {
                    fmBlockVariableParameter v =
                        new fmFilterMachiningBlock().GetParameterByName(grid.ParameterCell(i).Value.ToString());
                    fmGlobalParameter p = (v == null)
                                              ? fmGlobalParameter.parametersByName[
                                                  grid.ParameterCell(i).Value.ToString()]
                                              : v.globalParameter;

                    var parInBlock = smb.GetParameterByName(p.name);
                    p.specifiedRange.IsInputed = parInBlock != null && parInBlock.IsInputed;
                    p.specifiedRange.isUnlimited = false;
                    p.specifiedRange.MinValue = fmValue.ObjectToValue(grid.RangeMinValueCell(i).Value).value *
                                                p.unitFamily.CurrentUnit.Coef;
                    p.specifiedRange.MaxValue = fmValue.ObjectToValue(grid.RangeMaxValueCell(i).Value).value *
                                                p.unitFamily.CurrentUnit.Coef;
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