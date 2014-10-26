using System;
using System.Windows.Forms;
using FilterSimulation.fmFilterObjects;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Blocks;
using fmCalculationLibrary;
using System.Collections.Generic;
using System.Drawing;
using fmMisc;
using RangesDictionary = System.Collections.Generic.Dictionary<fmCalculationLibrary.fmGlobalParameter, fmCalculationLibrary.fmDefaultParameterRange>;

namespace FilterSimulation
{
    public partial class fmParameterIntervalOption : Form
    {
        private fmSimulationLimitsBlock cakeFormationLimitsBlock;
        private fmDeliquoringLimitsBlock deliquoringLimitsBlock;
        private Dictionary<fmFilterSimMachineType, RangesDictionary> m_schemas = new Dictionary<fmFilterSimMachineType, RangesDictionary>();

        public fmParameterIntervalOption()
        {
            InitializeComponent();
            FillFilterTypeCombobox();
        }

        private void FillFilterTypeCombobox()
        {
            foreach (fmFilterSimMachineType element in fmFilterSimMachineType.filterTypesList)
            {
                filterTypeComboBox.Items.Add(element.name);
            }
            filterTypeComboBox.SelectedIndex = 0;
        }

        public void SetRanges(RangesDictionary ranges)
        {
            FillTable(MaterialParametersGrid,
                      Color.LightBlue,
                      ranges,
                      new List<fmGlobalParameter>
                          {
                              fmGlobalParameter.eta_f,
                              fmGlobalParameter.rho_f,
                              fmGlobalParameter.rho_s,
                              fmGlobalParameter.rho_sus,
                              fmGlobalParameter.Cm,
                              fmGlobalParameter.Cv,
                              fmGlobalParameter.C,

                              fmGlobalParameter.eps0,
                              fmGlobalParameter.kappa0,
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
                      ranges,
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
                                                          fmGlobalParameter.d0,
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
                CakeFormationGrid.ClearRows();
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
                    CakeFormationGrid.RangeMinValueCell(rowId[fmGlobalParameter.d0]),
                    CakeFormationGrid.RangeMaxValueCell(rowId[fmGlobalParameter.d0]),
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
                    if (ranges.ContainsKey(p.globalParameter))
                    {
                        p.pMin.value = new fmValue(ranges[p.globalParameter].MinValue);
                        p.pMax.value = new fmValue(ranges[p.globalParameter].MaxValue);
                        p.IsInputed = ranges[p.globalParameter].IsInputed;
                    }
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
                deliquoringSettingsParametersGrid.ClearRows();
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
                    if (ranges.ContainsKey(p.globalParameter))
                    {
                        p.pMin.value = new fmValue(ranges[p.globalParameter].MinValue);
                        p.pMax.value = new fmValue(ranges[p.globalParameter].MaxValue);
                        p.IsInputed = ranges[p.globalParameter].IsInputed;
                    }
                }
                deliquoringLimitsBlock.Display();
            }

            #endregion

            FillTable(moreParemetersGrid,
                     Color.LightSkyBlue,
                     ranges,
                     new List<fmGlobalParameter>
                          {
                              fmGlobalParameter.Msus,
                              fmGlobalParameter.Vsus,
                              fmGlobalParameter.Mf,
                              fmGlobalParameter.Vf,
                              fmGlobalParameter.Ms,
                              fmGlobalParameter.Vs,
                              fmGlobalParameter.Mc,
                              fmGlobalParameter.Vc,
                              fmGlobalParameter.msus,
                              fmGlobalParameter.vsus,
                              fmGlobalParameter.mf,
                              fmGlobalParameter.vf,
                              fmGlobalParameter.ms,
                              fmGlobalParameter.vs,
                              fmGlobalParameter.mc,
                              fmGlobalParameter.vc,
                              fmGlobalParameter.Qsus,
                              fmGlobalParameter.Qmsus,
                              fmGlobalParameter.Qs,
                              fmGlobalParameter.Qms,
                              fmGlobalParameter.Qc,
                              fmGlobalParameter.Qmc,
                              fmGlobalParameter.Smech,
                              fmGlobalParameter.S,
                              fmGlobalParameter.Rfmech,
                              fmGlobalParameter.Rf,
                              fmGlobalParameter.Qgi,
                              fmGlobalParameter.Qg,
                              fmGlobalParameter.vg,
                              fmGlobalParameter.Mfd,
                              fmGlobalParameter.Vfd,
                              fmGlobalParameter.Mlcd,
                              fmGlobalParameter.Vlcd,
                              fmGlobalParameter.rho_bulk,
                              fmGlobalParameter.Qmfid,
                              fmGlobalParameter.Qfid,
                              fmGlobalParameter.qmfid,
                              fmGlobalParameter.qfid
                          });
        }

        private static void FillTable(
            TableWithParameterRanges grid,
            Color color,
            RangesDictionary ranges,
            IEnumerable<fmGlobalParameter> parametersList)
        {
            grid.ClearRows();
            foreach (fmGlobalParameter p in parametersList)
            {
                int rowIndex = grid.AddRow(p);
                grid.SetRawBackColor(rowIndex, color);
                if (ranges.ContainsKey(p))
                {
                    grid.RangeMinValueCell(rowIndex).Value =
                        new fmValue(ranges[p].MinValue / p.UnitFamily.CurrentUnit.Coef).ToString();
                    grid.RangeMaxValueCell(rowIndex).Value =
                        new fmValue(ranges[p].MaxValue / p.UnitFamily.CurrentUnit.Coef).ToString();
                }
            }
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            ShowHideMoreParameters();
        }

        private void ShowHideMoreParameters()
        {
            splitContainer4.Panel2Collapsed = !checkBox1.Checked;
        }

        private void fmParameterIntervalOption_Load(object sender, System.EventArgs e)
        {
            ShowHideMoreParameters();
        }

        public RangesDictionary GetRanges()
        {
            var result = new RangesDictionary();
            foreach (var p in fmGlobalParameter.Parameters)
            {
                result.Add(p, new fmDefaultParameterRange(0, 1, false));
            }

            var grids = new TableWithParameterRanges[]
                            {
                                MaterialParametersGrid,
                                deliquoringMaterialParameterGrid,
                                deliquoringSettingsParametersGrid,
                                CakeFormationGrid,
                                moreParemetersGrid
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
                    result[p].IsInputed = blockLimitParameter != null
                                                     ? blockLimitParameter.IsInputed
                                                     : false;
                    result[p].MinValue = fmValue.ObjectToValue(grid.RangeMinValueCell(i).Value).value *
                                                p.UnitFamily.CurrentUnit.Coef;
                    result[p].MaxValue = fmValue.ObjectToValue(grid.RangeMaxValueCell(i).Value).value *
                                                p.UnitFamily.CurrentUnit.Coef;
                }
            }

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (filterTypeComboBox.Text != "")
            {
                var value = fmFilterSimMachineType.GetFilterTypeByName(filterTypeComboBox.Text);
                if (m_schemas.ContainsKey(value))
                {
                    SetRanges(m_schemas[value]);
                }
                else
                {
                    MessageBox.Show(@"Nothing assigned to the selected type.");
                }
            }
            hideOrShowD0Row();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (filterTypeComboBox.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show(
                    @"Are you sure you want to assign new show/hide configuration for the selected Filter Type – Group?",
                    @"Confirm",
                    MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    var value = fmFilterSimMachineType.GetFilterTypeByName(filterTypeComboBox.Text);
                    m_schemas[value] = GetRanges();
                }
            }
        }

        public fmFilterSimMachineType GetRangesMachineType()
        {
            return fmFilterSimMachineType.GetFilterTypeByName(filterTypeComboBox.Text);
        }

        public void SetRangesSchemas(Dictionary<fmFilterSimMachineType, Dictionary<fmGlobalParameter, fmDefaultParameterRange>> dictionary)
        {
            m_schemas = new Dictionary<fmFilterSimMachineType, RangesDictionary>(dictionary);
        }

        public Dictionary<fmFilterSimMachineType, Dictionary<fmGlobalParameter, fmDefaultParameterRange>> GetRangesSchemas()
        {
            return new Dictionary<fmFilterSimMachineType, RangesDictionary>(m_schemas);
        }

        public void CheckMachineType(fmFilterSimMachineType schema)
        {
            for (int i = 0; i < filterTypeComboBox.Items.Count; ++i)
            {
                if (filterTypeComboBox.Items[i].ToString() == schema.name)
                {
                    filterTypeComboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        public void CheckScheme(string machineName)
        {
            for (int i = 0; i < filterTypeComboBox.Items.Count; ++i)
            {
                if (filterTypeComboBox.Items[i].ToString() == machineName)
                {
                    filterTypeComboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        private void filterTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            hideOrShowD0Row();
        }

        private void hideOrShowD0Row()
        {
            if (GetRangesMachineType() != fmFilterSimMachineType.GetFilterTypeByName(fmFilterSimMachineType.FilterTypeNamesList.CandleFilter))
                CakeFormationGrid.HideD0Row();
            else
                CakeFormationGrid.ShowD0Row();
        }
    }
}