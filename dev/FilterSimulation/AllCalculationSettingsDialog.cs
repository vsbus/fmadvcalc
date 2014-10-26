using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using fmCalculatorsLibrary;
using FilterSimulation.fmFilterObjects;

using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Blocks;
using fmCalculationLibrary;
using fmMisc;
using RangesDictionary = System.Collections.Generic.Dictionary<fmCalculationLibrary.fmGlobalParameter, fmCalculationLibrary.fmDefaultParameterRange>;

using fmControls;
using FilterSimulation;

namespace FilterSimulation
{
    public partial class AllCalculationSettingsDialog : Form
    {
        public fmSuspensionCalculator.fmSuspensionCalculationOptions suspensionCalculationOption;
        public fmFilterMachiningCalculator.fmFilterMachiningCalculationOption filterMachiningCalculationOption;
        public fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption deliquoringUsedCalculationOption;
        public fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption gasFlowrateUsedCalculationOption;
        public fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption evaporationUsedCalculationOption;
        public fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption hcdEpsdCalculationOption;
        public fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption dpdInputCalculationOption;
        public fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption rhoDCalculationOption;
        public fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption PcDCalculationOption;

        private fmSimulationLimitsBlock cakeFormationLimitsBlock;
        private fmDeliquoringLimitsBlock deliquoringLimitsBlock;
        private Dictionary<fmFilterSimMachineType, RangesDictionary> m_schemas = new Dictionary<fmFilterSimMachineType, RangesDictionary>();

        private readonly fmFilterSimMachineType[] m_machines = fmFilterSimMachineType.filterTypesList.ToArray();
        private Dictionary<string, List<fmGlobalParameter>> m_ShowHideSchemasForEachFilterMachine = new Dictionary<string, List<fmGlobalParameter>>();

        private readonly Dictionary<fmGlobalParameter, fmCheckedListBoxWithCheckboxes> m_parameterBox = new Dictionary<fmGlobalParameter, fmCheckedListBoxWithCheckboxes>();
        public string CurrentSerieMachineName = "";
        private Dictionary<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>> m_schemas_param = new Dictionary<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>>();

        public class ValuesForCaseIfCancelClicked
        {
            public string machine;
            public RangesDictionary ranges;
            public Dictionary<fmFilterSimMachineType, Dictionary<fmGlobalParameter, fmDefaultParameterRange>> RangesDictionary;
            public fmParametersToDisplay parametersToDisplay;
            public Dictionary<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>> showHideDictionary;
            public Dictionary<string, List<fmGlobalParameter>> filtersShowHideDictionary;
            public fmSuspensionCalculator.fmSuspensionCalculationOptions suspensionCalculationOption;
            public fmFilterMachiningCalculator.fmFilterMachiningCalculationOption filterMachiningCalculationOption;
            public fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption deliquoringUsedCalculationOption;
            public fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption gasFlowrateUsedCalculationOption;
            public fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption evaporationUsedCalculationOption;
            public fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption hcdEpsdCalculationOption;
            public fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption dpdInputCalculationOption;
            public fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption rhoDCalculationOption;
            public fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption PcDCalculationOption;

        }
        public ValuesForCaseIfCancelClicked DefaultValues = new ValuesForCaseIfCancelClicked();

        public AllCalculationSettingsDialog()
        {
            InitializeComponent();
            FillRngesFilterTypeCombobox();
            FillShowHideFilterTypeCombobox();
            InitCombobox();
            AddParametersToShowHideTab();
        }
        
        private void AllCalculationSettingsDialog_Load(object sender, EventArgs e)
        {
            //for calculation option tab:
            rho_f_radioButton.Checked = suspensionCalculationOption ==
                                        fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOF_CALCULATED;
            rho_s_radioButton.Checked = suspensionCalculationOption ==
                                        fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOS_CALCULATED;
            rho_sus_radioButton.Checked = suspensionCalculationOption ==
                                          fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOSUS_CALCULATED;
            CmCvC_radioButton.Checked = suspensionCalculationOption ==
                                        fmSuspensionCalculator.fmSuspensionCalculationOptions.CM_CV_C_CALCULATED;

            fmCalculationOptionView1.SetSelectedOption(filterMachiningCalculationOption);

            CakeHeightInputCheckBox.Checked = hcdEpsdCalculationOption ==
                                              fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.
                                                  InputedByUser;

            PressureDifferenceInputCheckbox.Checked = dpdInputCalculationOption ==
                                                          fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption.
                                                              InputedByUser;

            deliquoringOptionCheckBox.Checked = deliquoringUsedCalculationOption ==
                                                fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption.Used;

            considerGasFlowrateCheckbox.Checked = gasFlowrateUsedCalculationOption ==
                                                fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption.Consider;

            considerEvaporationCheckBox.Checked = evaporationUsedCalculationOption ==
                                                fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption.Consider;

            etaDrhoDCheckBox.Checked = rhoDCalculationOption == fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption.InputedByUser;
            PcDCheckBox.Checked = PcDCalculationOption == fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption.InputedByUser;

            ShowHideSecondaryDeliquoringCheckboxes();

            //for ranges tab:
            ShowHideMoreParameters();
        }
        #region Calculation Options Tab
        private void ShowHideSecondaryDeliquoringCheckboxes()
        {
            bool isVisible = deliquoringOptionCheckBox.Checked;
            PressureDifferenceInputCheckbox.Visible = isVisible;
            CakeHeightInputCheckBox.Visible = isVisible;
            PcDCheckBox.Visible = isVisible;
            etaDrhoDCheckBox.Visible = isVisible;
            considerGasFlowrateCheckbox.Visible = isVisible;
            considerEvaporationCheckBox.Visible = isVisible && considerGasFlowrateCheckbox.Checked;
        }

        private void rho_f_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSuspensionCalculationOption();
        }

        private void rho_s_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSuspensionCalculationOption();
        }

        private void rho_sus_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSuspensionCalculationOption();
        }

        private void CmCvC_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSuspensionCalculationOption();
        }

        private void UpdateSuspensionCalculationOption()
        {
            if (rho_f_radioButton.Checked)
                suspensionCalculationOption = fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOF_CALCULATED;
            if (rho_s_radioButton.Checked)
                suspensionCalculationOption = fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOS_CALCULATED;
            if (rho_sus_radioButton.Checked)
                suspensionCalculationOption = fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOSUS_CALCULATED;
            if (CmCvC_radioButton.Checked)
                suspensionCalculationOption = fmSuspensionCalculator.fmSuspensionCalculationOptions.CM_CV_C_CALCULATED;
        }

        private void fmCalculationOptionView1_CheckedChangedForUpdatingCalculationOptions(object sender, EventArgs e)
        {
            filterMachiningCalculationOption = fmCalculationOptionView1.GetSelectedOption();
        }
        private void deliquoringCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            hcdEpsdCalculationOption = CakeHeightInputCheckBox.Checked
                                               ? fmDeliquoringSimualtionCalculator.
                                                     fmDeliquoringHcdEpsdCalculationOption.InputedByUser
                                               : fmDeliquoringSimualtionCalculator.
                                                     fmDeliquoringHcdEpsdCalculationOption.
                                                     CalculatedFromCakeFormation;
        }

        private void PressureDifferenceInputCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            dpdInputCalculationOption = PressureDifferenceInputCheckbox.Checked
                                               ? fmDeliquoringSimualtionCalculator.
                                                     fmDeliquoringDpdInputOption.InputedByUser
                                               : fmDeliquoringSimualtionCalculator.
                                                     fmDeliquoringDpdInputOption.CalculatedFromCakeFormation;
        }

        private void rhoDetaDCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            rhoDCalculationOption = etaDrhoDCheckBox.Checked
                                               ? fmSigmaPke0PkePcdRcdAlphadCalculator.
                                                     fmRhoDEtaDCalculationOption.
                                                     InputedByUser
                                               : fmSigmaPke0PkePcdRcdAlphadCalculator.
                                                     fmRhoDEtaDCalculationOption.
                                                     EqualToRhoF;
        }

        private void PcDCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PcDCalculationOption = PcDCheckBox.Checked
                                               ? fmSigmaPke0PkePcdRcdAlphadCalculator.
                                                     fmPcDCalculationOption.
                                                     InputedByUser
                                               : fmSigmaPke0PkePcdRcdAlphadCalculator.
                                                     fmPcDCalculationOption.
                                                     Calculated;
        }

        private void deliquoringOptionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            deliquoringUsedCalculationOption = deliquoringOptionCheckBox.Checked
                                                   ? fmFilterMachiningCalculator.
                                                         fmDeliquoringUsedCalculationOption.Used
                                                   : fmFilterMachiningCalculator.
                                                         fmDeliquoringUsedCalculationOption.NotUsed;

            ShowHideSecondaryDeliquoringCheckboxes();
        }

        private void considerGasFlowrateCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            gasFlowrateUsedCalculationOption = considerGasFlowrateCheckbox.Checked
                                                   ? fmFilterMachiningCalculator.
                                                         fmGasFlowrateUsedCalculationOption.Consider
                                                   : fmFilterMachiningCalculator.
                                                         fmGasFlowrateUsedCalculationOption.NotConsider;

            ShowHideSecondaryDeliquoringCheckboxes();
        }

        private void considerEvaporationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            evaporationUsedCalculationOption = considerEvaporationCheckBox.Checked
                                                 ? fmFilterMachiningCalculator.
                                                       fmEvaporationUsedCalculationOption.Consider
                                                 : fmFilterMachiningCalculator.
                                                       fmEvaporationUsedCalculationOption.NotConsider;

            ShowHideSecondaryDeliquoringCheckboxes();
        }

        public void InitCalculationOptions()
        {            
            var FakeSimulation = new fmFilterSimulation();
            suspensionCalculationOption = FakeSimulation.Data.suspensionCalculationOption;
            filterMachiningCalculationOption = FakeSimulation.Data.filterMachiningCalculationOption;
            deliquoringUsedCalculationOption = FakeSimulation.Data.deliquoringUsedCalculationOption;
            gasFlowrateUsedCalculationOption = FakeSimulation.Data.gasFlowrateUsedCalculationOption;
            evaporationUsedCalculationOption = FakeSimulation.Data.evaporationUsedCalculationOption;
            hcdEpsdCalculationOption = FakeSimulation.Data.hcdEpsdCalculationOption;
            dpdInputCalculationOption = FakeSimulation.Data.dpdInputCalculationOption;
            rhoDCalculationOption = FakeSimulation.Data.rhoDCalculationOption;
            PcDCalculationOption = FakeSimulation.Data.PcDCalculationOption;
        }

        public void UpdateDefaultCalculationOptionForSImulation(string FilterName)
        {
            if (FilterName == fmFilterSimMachineType.FilterTypeNamesList.VacuumDrumFilter ||
                FilterName == fmFilterSimMachineType.FilterTypeNamesList.VacuumDiscFilter ||                
                FilterName == fmFilterSimMachineType.FilterTypeNamesList.RotaryPressureFilter ||
                FilterName == fmFilterSimMachineType.FilterTypeNamesList.LabVacuumFilter ||
                FilterName == fmFilterSimMachineType.FilterTypeNamesList.LabPressureFilter)
            {
                suspensionCalculationOption = fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOS_CALCULATED;
                filterMachiningCalculationOption = fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_DP_CONST;
                deliquoringUsedCalculationOption = fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption.Used;
                gasFlowrateUsedCalculationOption = fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption.Consider;
                evaporationUsedCalculationOption = fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption.NotConsider;
                hcdEpsdCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.CalculatedFromCakeFormation;
                dpdInputCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption.CalculatedFromCakeFormation;
                rhoDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption.EqualToRhoF;
                PcDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption.Calculated;         
            }

            if (FilterName == fmFilterSimMachineType.FilterTypeNamesList.VacuumPanFilter ||
                FilterName == fmFilterSimMachineType.FilterTypeNamesList.VacuumBeltFilter ||
                FilterName == fmFilterSimMachineType.FilterTypeNamesList.VacuumNutche ||
                FilterName == fmFilterSimMachineType.FilterTypeNamesList.PressureNutche)
            {
                suspensionCalculationOption = fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOS_CALCULATED;
                filterMachiningCalculationOption = fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_DP_CONST;
                deliquoringUsedCalculationOption = fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption.Used;
                gasFlowrateUsedCalculationOption = fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption.Consider;
                evaporationUsedCalculationOption = fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption.NotConsider;
                hcdEpsdCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.CalculatedFromCakeFormation;
                dpdInputCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption.CalculatedFromCakeFormation;
                rhoDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption.InputedByUser;
                PcDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption.Calculated;
            }

            if (FilterName == fmFilterSimMachineType.FilterTypeNamesList.PneumaPress ||
                FilterName == fmFilterSimMachineType.FilterTypeNamesList.PressureLeafFilter)
            {
                suspensionCalculationOption = fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOS_CALCULATED;
                filterMachiningCalculationOption = fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_CENTRIPETAL_PUMP_QP_DP_CONST;
                deliquoringUsedCalculationOption = fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption.Used;
                gasFlowrateUsedCalculationOption = fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption.Consider;
                evaporationUsedCalculationOption = fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption.NotConsider;
                hcdEpsdCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.CalculatedFromCakeFormation;
                dpdInputCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption.CalculatedFromCakeFormation;
                rhoDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption.EqualToRhoF;
                PcDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption.Calculated;
            }

            if (FilterName == fmFilterSimMachineType.FilterTypeNamesList.CandleFilter)
            {
                suspensionCalculationOption = fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOS_CALCULATED;
                filterMachiningCalculationOption = fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.CYLINDRICAL_CENTRIPETAL_PUMP_QP_DP_CONST;
                deliquoringUsedCalculationOption = fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption.Used;
                gasFlowrateUsedCalculationOption = fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption.Consider;
                evaporationUsedCalculationOption = fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption.NotConsider;
                hcdEpsdCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.CalculatedFromCakeFormation;
                dpdInputCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption.CalculatedFromCakeFormation;
                rhoDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption.EqualToRhoF;
                PcDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption.Calculated;
            }

            if (FilterName == fmFilterSimMachineType.FilterTypeNamesList.FilterPress)
            {
                suspensionCalculationOption = fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOS_CALCULATED;
                filterMachiningCalculationOption = fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_CENTRIPETAL_PUMP_QP_DP_CONST;
                deliquoringUsedCalculationOption = fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption.Used;
                gasFlowrateUsedCalculationOption = fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption.Consider;
                evaporationUsedCalculationOption = fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption.NotConsider;
                hcdEpsdCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.InputedByUser;
                dpdInputCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption.InputedByUser;
                rhoDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption.EqualToRhoF;
                PcDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption.InputedByUser;                
            }

            if (FilterName == fmFilterSimMachineType.FilterTypeNamesList.FilterPressAutomat)
            {
                suspensionCalculationOption = fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOS_CALCULATED;
                filterMachiningCalculationOption = fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_CENTRIPETAL_PUMP_QP_DP_CONST;
                deliquoringUsedCalculationOption = fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption.Used;
                gasFlowrateUsedCalculationOption = fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption.Consider;
                evaporationUsedCalculationOption = fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption.NotConsider;
                hcdEpsdCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.InputedByUser;
                dpdInputCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption.InputedByUser;
                rhoDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption.InputedByUser;
                PcDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption.InputedByUser;
            }
        }

        public void GetCalculationOptions(fmFilterSimulation Simulation)
        {
             Simulation.susBlock.SetCalculationOptionAndRewrite(suspensionCalculationOption);

             Simulation.filterMachiningBlock.SetCalculationOptionAndUpdateCellsStyle(filterMachiningCalculationOption);
             Simulation.filterMachiningBlock.SetCalculationOptionAndUpdateCellsStyle(deliquoringUsedCalculationOption);
             Simulation.filterMachiningBlock.SetCalculationOptionAndUpdateCellsStyle(gasFlowrateUsedCalculationOption);
             Simulation.filterMachiningBlock.SetCalculationOptionAndRewriteData(evaporationUsedCalculationOption);

             Simulation.deliquoringEps0NeEpsBlock.SetCalculationOptionAndUpdateCellsStyle(deliquoringUsedCalculationOption);
             Simulation.deliquoringEps0NeEpsBlock.SetCalculationOptionAndUpdateCellsStyle(hcdEpsdCalculationOption);
             Simulation.deliquoringEps0NeEpsBlock.SetCalculationOptionAndRewrite(dpdInputCalculationOption);

             Simulation.deliquoringSigmaPkeBlock.SetCalculationOptionAndUpdateCellsStyle(deliquoringUsedCalculationOption);
             Simulation.deliquoringSigmaPkeBlock.SetCalculationOptionAndUpdateCellsStyle(rhoDCalculationOption);
             Simulation.deliquoringSigmaPkeBlock.SetCalculationOptionAndRewrite(PcDCalculationOption);
        }
        #endregion

        #region Ranges Tab

        private void FillRngesFilterTypeCombobox()
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideMoreParameters();
        }

        private void ShowHideMoreParameters()
        {
            splitContainer4.Panel2Collapsed = !checkBox1.Checked;
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

        public void button2_Click(object sender, EventArgs e)
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

        #endregion

        #region Parameters to display tab

        private void AddParametersToShowHideTab()
        {
            AddParameter(massBox, fmGlobalParameter.Mf);
            AddParameter(massBox, fmGlobalParameter.Ms);
            AddParameter(massBox, fmGlobalParameter.Msus);
            AddParameter(massBox, fmGlobalParameter.Mc);

            AddParameter(volumeBox, fmGlobalParameter.Vf);
            AddParameter(volumeBox, fmGlobalParameter.Vs);
            AddParameter(volumeBox, fmGlobalParameter.Vsus);
            AddParameter(volumeBox, fmGlobalParameter.Vc);

            AddParameter(mBox, fmGlobalParameter.mf);
            AddParameter(mBox, fmGlobalParameter.ms);
            AddParameter(mBox, fmGlobalParameter.msus);
            AddParameter(mBox, fmGlobalParameter.mc);

            AddParameter(vBox, fmGlobalParameter.vf);
            AddParameter(vBox, fmGlobalParameter.vs);
            AddParameter(vBox, fmGlobalParameter.vsus);
            AddParameter(vBox, fmGlobalParameter.vc);

            AddParameter(qmBigBox, fmGlobalParameter.Qmf);
            AddParameter(qmBigBox, fmGlobalParameter.Qms);
            AddParameter(qmBigBox, fmGlobalParameter.Qmsus);
            AddParameter(qmBigBox, fmGlobalParameter.Qmc);

            AddParameter(qBigBox, fmGlobalParameter.Qf);
            AddParameter(qBigBox, fmGlobalParameter.Qs);
            AddParameter(qBigBox, fmGlobalParameter.Qsus);
            AddParameter(qBigBox, fmGlobalParameter.Qc);

            AddParameter(qmSmallBox, fmGlobalParameter.qmf);
            AddParameter(qmSmallBox, fmGlobalParameter.qms);
            AddParameter(qmSmallBox, fmGlobalParameter.qmsus);
            AddParameter(qmSmallBox, fmGlobalParameter.qmc);

            AddParameter(qSmallBox, fmGlobalParameter.qf);
            AddParameter(qSmallBox, fmGlobalParameter.qs);
            AddParameter(qSmallBox, fmGlobalParameter.qsus);
            AddParameter(qSmallBox, fmGlobalParameter.qc);

            AddParameter(qmBigBox_dif, fmGlobalParameter.Qmf_i);
            AddParameter(qmBigBox_dif, fmGlobalParameter.Qms_i);
            AddParameter(qmBigBox_dif, fmGlobalParameter.Qmsus_i);
            AddParameter(qmBigBox_dif, fmGlobalParameter.Qmc_i);

            AddParameter(qBigBox_dif, fmGlobalParameter.Qf_i);
            AddParameter(qBigBox_dif, fmGlobalParameter.Qs_i);
            AddParameter(qBigBox_dif, fmGlobalParameter.Qc_i);

            AddParameter(qmSmallBox_dif, fmGlobalParameter.qmf_i);
            AddParameter(qmSmallBox_dif, fmGlobalParameter.qms_i);
            AddParameter(qmSmallBox_dif, fmGlobalParameter.qmsus_i);
            AddParameter(qmSmallBox_dif, fmGlobalParameter.qmc_i);

            AddParameter(qSmallBox_dif, fmGlobalParameter.qf_i);
            AddParameter(qSmallBox_dif, fmGlobalParameter.qs_i);
            AddParameter(qSmallBox_dif, fmGlobalParameter.qc_i);

            AddParameter(ad0DpBox, fmGlobalParameter.A);
            AddParameter(ad0DpBox, fmGlobalParameter.d0);
            AddParameter(ad0DpBox, fmGlobalParameter.Dp);

            AddParameter(sfSrTrBox, fmGlobalParameter.sf);
            AddParameter(sfSrTrBox, fmGlobalParameter.sr);
            AddParameter(sfSrTrBox, fmGlobalParameter.tr);

            AddParameter(nTcTfBox, fmGlobalParameter.n);
            AddParameter(nTcTfBox, fmGlobalParameter.tc);
            AddParameter(nTcTfBox, fmGlobalParameter.tf);

            AddParameter(hcBox, fmGlobalParameter.hc);
            AddParameter(hcBox, fmGlobalParameter.hc_over_tf);
            AddParameter(hcBox, fmGlobalParameter.dhc_over_dt);

            AddParameter(epsKappaBox, fmGlobalParameter.eps);
            AddParameter(epsKappaBox, fmGlobalParameter.kappa);
            AddParameter(epsKappaBox, fmGlobalParameter.Pc);
            AddParameter(epsKappaBox, fmGlobalParameter.rc);
            AddParameter(epsKappaBox, fmGlobalParameter.a);
            AddParameter(epsKappaBox, fmGlobalParameter.Rm);

            AddParameter(DpQpConstBox, fmGlobalParameter.Qp);
            AddParameter(DpQpConstBox, fmGlobalParameter.qp);
            AddParameter(DpQpConstBox, fmGlobalParameter.t1);
            AddParameter(DpQpConstBox, fmGlobalParameter.h1);
            AddParameter(DpQpConstBox, fmGlobalParameter.t1_over_tf);
            AddParameter(DpQpConstBox, fmGlobalParameter.h1_over_hc);

            AddParameter(materialDeliqouringBox, fmGlobalParameter.eps_d);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.eta_d);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.rho_d);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.sigma);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.pke0);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.pke);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.pc_d);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.rc_d);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.alpha_d);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.Srem);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.ad1);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.ad2);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.Tetta);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.eta_g);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.ag1);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.ag2);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.ag3);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.Tetta_boil);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.DH);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.Mmole);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.f);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.peq);

            AddParameter(gasParameters, fmGlobalParameter.Qgi);
            AddParameter(gasParameters, fmGlobalParameter.Qg);
            AddParameter(gasParameters, fmGlobalParameter.vg);
            AddParameter(gasParameters, fmGlobalParameter.Qgt);
            AddParameter(gasParameters, fmGlobalParameter.Vg);

            AddParameter(evaporationsParameters, fmGlobalParameter.Qmevi);
            AddParameter(evaporationsParameters, fmGlobalParameter.Qmevt);
            AddParameter(evaporationsParameters, fmGlobalParameter.Qmev);
            AddParameter(evaporationsParameters, fmGlobalParameter.Qevi);
            AddParameter(evaporationsParameters, fmGlobalParameter.Qevt);
            AddParameter(evaporationsParameters, fmGlobalParameter.Qev);
            AddParameter(evaporationsParameters, fmGlobalParameter.Mev);
            AddParameter(evaporationsParameters, fmGlobalParameter.Vev);
            AddParameter(evaporationsParameters, fmGlobalParameter.qmevi);
            AddParameter(evaporationsParameters, fmGlobalParameter.qmevt);
            AddParameter(evaporationsParameters, fmGlobalParameter.qmev);
            AddParameter(evaporationsParameters, fmGlobalParameter.qevi);
            AddParameter(evaporationsParameters, fmGlobalParameter.qevt);
            AddParameter(evaporationsParameters, fmGlobalParameter.qev);

            AddParameter(mainDeliquoringBox, fmGlobalParameter.Dp_d);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.hcd);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.sd);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.td);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.K);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.Smech);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.S);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.Rfmech);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.Rf);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.rho_bulk);

            AddParameter(volumeDeliquoringBox, fmGlobalParameter.Vfd);
            AddParameter(volumeDeliquoringBox, fmGlobalParameter.Vlcd);
            AddParameter(volumeDeliquoringBox, fmGlobalParameter.Vcd);

            AddParameter(massDeliquoringBox, fmGlobalParameter.Mfd);
            AddParameter(massDeliquoringBox, fmGlobalParameter.Mlcd);
            AddParameter(massDeliquoringBox, fmGlobalParameter.Mcd);

            AddParameter(volumeFlowrateDeliquoringBox, fmGlobalParameter.Qfd);
            AddParameter(volumeFlowrateDeliquoringBox, fmGlobalParameter.Qftd);
            AddParameter(volumeFlowrateDeliquoringBox, fmGlobalParameter.Qfid);
            AddParameter(volumeFlowrateDeliquoringBox, fmGlobalParameter.Qcd);

            AddParameter(massFlowrateDeliquoringBox, fmGlobalParameter.Qmfd);
            AddParameter(massFlowrateDeliquoringBox, fmGlobalParameter.Qmftd);
            AddParameter(massFlowrateDeliquoringBox, fmGlobalParameter.Qmfid);
            AddParameter(massFlowrateDeliquoringBox, fmGlobalParameter.Qmcd);

            AddParameter(qDeliquoringBox, fmGlobalParameter.qcd);
            AddParameter(qDeliquoringBox, fmGlobalParameter.qfid);
            AddParameter(qDeliquoringBox, fmGlobalParameter.qftd);
            AddParameter(qDeliquoringBox, fmGlobalParameter.qfd);

            AddParameter(qmDeliquoringBox, fmGlobalParameter.qmcd);
            AddParameter(qmDeliquoringBox, fmGlobalParameter.qmfid);
            AddParameter(qmDeliquoringBox, fmGlobalParameter.qmftd);
            AddParameter(qmDeliquoringBox, fmGlobalParameter.qmfd);
        }

        private void FillShowHideFilterTypeCombobox()
        {
            foreach (Enum element in Enum.GetValues(typeof(fmFilterSimMachineType.FilterCycleType)))
            {
                filterTypeGroupComboBox.Items.Add(fmEnumUtils.GetEnumDescription(element));
            }
            filterTypeGroupComboBox.SelectedIndex = 0;
        }

        private void AddParameter(fmCheckedListBoxWithCheckboxes box, fmGlobalParameter parameter)
        {
            m_parameterBox[parameter] = box;
            box.Items.Add(parameter.Name);
        }

        public void UncheckAll()
        {
            foreach (fmCheckedListBoxWithCheckboxes box in m_parameterBox.Values)
            {
                for (int i = 0; i < box.Items.Count; ++i)
                {
                    box.SetItemChecked(i, false);
                }
            }
        }

        public void CheckItems(List<fmGlobalParameter> list)
        {
            foreach (fmGlobalParameter p in list)
            {
                CheckItemInBox(m_parameterBox[p], p);
            }
        }

        private static void CheckItemInBox(fmCheckedListBoxWithCheckboxes box, fmGlobalParameter p)
        {
            for (int i = 0; i < box.Items.Count; ++i)
            {
                if (box.Items[i].ToString() == p.Name)
                {
                    box.SetItemChecked(i, true);
                }
            }
        }

        private static bool GetItemCheckedInBox(fmCheckedListBoxWithCheckboxes box, fmGlobalParameter p)
        {
            for (int i = 0; i < box.Items.Count; ++i)
            {
                if (box.Items[i].ToString() == p.Name)
                {
                    return box.GetItemChecked(i);
                }
            }

            throw new Exception("item was not found in box");
        }

        public List<fmGlobalParameter> GetCheckedItems()
        {
            var result = new List<fmGlobalParameter>();
            foreach (fmGlobalParameter p in fmGlobalParameter.Parameters)
            {
                if (m_parameterBox.ContainsKey(p) && GetItemCheckedInBox(m_parameterBox[p], p))
                {
                    result.Add(p);
                }
            }
            return result;
        }

        private void assignButton_Click(object sender, EventArgs e)
        {
            if (filterTypeGroupComboBox.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show(
                    @"Are you sure you want to assign new show/hide configuration for the selected Filter Type – Group?",
                    @"Confirm",
                    MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    var value = (fmFilterSimMachineType.FilterCycleType)fmEnumUtils.GetEnum(typeof(fmFilterSimMachineType.FilterCycleType), filterTypeGroupComboBox.Text);
                    m_schemas_param[value] = GetCheckedItems();

                    var selectedFilter = filterTypeByMachineComboBox.Text;
                    m_ShowHideSchemasForEachFilterMachine[selectedFilter] = GetCheckedItems();
                }
            }
        }

        public void takeButton_Click(object sender, EventArgs e)
        {
            if (filterTypeGroupComboBox.Text != "")
            {
                var value = (fmFilterSimMachineType.FilterCycleType)fmEnumUtils.GetEnum(typeof(fmFilterSimMachineType.FilterCycleType), filterTypeGroupComboBox.Text);
                var selecteFilter = filterTypeByMachineComboBox.Text;
                if (m_schemas_param.ContainsKey(value))
                {
                    UncheckAll();
                    CheckItems(m_schemas_param[value]);
                }
                if (m_ShowHideSchemasForEachFilterMachine.ContainsKey(selecteFilter))
                {
                    UncheckAll();
                    CheckItems(m_ShowHideSchemasForEachFilterMachine[selecteFilter]);
                }
                else
                {
                    MessageBox.Show(@"Nothing assigned to the selected type.");
                }
            }
        }

        public Dictionary<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>> GetShowHideSchemas()
        {
            return m_schemas_param;
        }

        public Dictionary<string, List<fmGlobalParameter>> GetFiltersShowHideSchemas()
        {
            return m_ShowHideSchemasForEachFilterMachine;
        }

        public void SetShowHideSchemas(Dictionary<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>> dictionary, Dictionary<string, List<fmGlobalParameter>> filtersDictionary)
        {
            m_schemas_param = new Dictionary<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>>();
            foreach (KeyValuePair<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>> pair in dictionary)
            {
                m_schemas_param.Add(pair.Key, pair.Value);
            }

            m_ShowHideSchemasForEachFilterMachine = new Dictionary<string, List<fmGlobalParameter>>();
            foreach (KeyValuePair<string, List<fmGlobalParameter>> pair in filtersDictionary)
            {
                m_ShowHideSchemasForEachFilterMachine.Add(pair.Key, pair.Value);
            }
        }

        public void CheckScheme(fmFilterSimMachineType.FilterCycleType schema, string serieMachineName)
        {
            for (int i = 0; i < filterTypeGroupComboBox.Items.Count; ++i)
            {
                if (filterTypeGroupComboBox.Items[i].ToString() == fmEnumUtils.GetEnumDescription(schema))
                {
                    filterTypeGroupComboBox.SelectedIndex = i;
                    break;
                }
            }

            foreach (var item in filterTypeByMachineComboBox.Items)
            {
                if (item.ToString() == serieMachineName)
                {
                    filterTypeByMachineComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        public fmFilterSimMachineType.FilterCycleType GetCheckedSchema()
        {
            return (fmFilterSimMachineType.FilterCycleType)fmEnumUtils.GetEnum(typeof(fmFilterSimMachineType.FilterCycleType), filterTypeGroupComboBox.Text);
        }

        private void InitCombobox()
        {
            foreach (fmFilterSimMachineType machine in m_machines)
            {
                filterTypeByMachineComboBox.Items.Add(machine.name);
            }

            filterTypeByMachineComboBox.SelectedIndex = 0;
        }        
        private void filterTypeByMachineComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedFilter = filterTypeByMachineComboBox.SelectedItem;
            foreach (fmFilterSimMachineType filterType in m_machines)
            {
                if (filterType.name == selectedFilter.ToString())
                {
                    for (int i = 0; i < filterTypeGroupComboBox.Items.Count; ++i)
                    {
                        var value = (fmFilterSimMachineType.FilterCycleType)fmEnumUtils.GetEnum(typeof(fmFilterSimMachineType.FilterCycleType), filterTypeGroupComboBox.Items[i].ToString());
                        if (value == filterType.GetFilterCycleType())
                        {
                            filterTypeGroupComboBox.SelectedIndex = i;
                            break;
                        }
                    }
                    break;
                }
            }
        }
        #endregion

        public void SetDefaultValues(RangesDictionary ranges, 
            Dictionary<fmFilterSimMachineType, Dictionary<fmGlobalParameter, fmDefaultParameterRange>> rangesDictionary, 
            fmParametersToDisplay parametersToDisplay, 
            Dictionary<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>> showHideDictionary,
            Dictionary<string, List<fmGlobalParameter>> filtersShowHideDictionary)
        {
            DefaultValues.deliquoringUsedCalculationOption = deliquoringUsedCalculationOption;
            DefaultValues.dpdInputCalculationOption = dpdInputCalculationOption;
            DefaultValues.evaporationUsedCalculationOption = evaporationUsedCalculationOption;
            DefaultValues.filterMachiningCalculationOption = filterMachiningCalculationOption;
            DefaultValues.gasFlowrateUsedCalculationOption = gasFlowrateUsedCalculationOption;
            DefaultValues.hcdEpsdCalculationOption = hcdEpsdCalculationOption;
            DefaultValues.PcDCalculationOption = PcDCalculationOption;
            DefaultValues.rhoDCalculationOption = rhoDCalculationOption;
            DefaultValues.suspensionCalculationOption = suspensionCalculationOption;

            DefaultValues.ranges = ranges;
            DefaultValues.RangesDictionary = rangesDictionary;

            DefaultValues.parametersToDisplay = parametersToDisplay;
            DefaultValues.showHideDictionary = showHideDictionary;
            DefaultValues.filtersShowHideDictionary = filtersShowHideDictionary;
        }

        public void SetDefaultMachine(string machine)
        {
            DefaultValues.machine = machine;            
        }

        public void WindowCanceled()
        {
            deliquoringUsedCalculationOption = DefaultValues.deliquoringUsedCalculationOption;
            dpdInputCalculationOption = DefaultValues.dpdInputCalculationOption;
            evaporationUsedCalculationOption = DefaultValues.evaporationUsedCalculationOption;
            filterMachiningCalculationOption = DefaultValues.filterMachiningCalculationOption;
            gasFlowrateUsedCalculationOption = DefaultValues.gasFlowrateUsedCalculationOption;
            hcdEpsdCalculationOption = DefaultValues.hcdEpsdCalculationOption;
            PcDCalculationOption = DefaultValues.PcDCalculationOption;
            rhoDCalculationOption = DefaultValues.rhoDCalculationOption;
            suspensionCalculationOption = DefaultValues.suspensionCalculationOption;

            CheckScheme(DefaultValues.machine);
            SetRanges(DefaultValues.ranges);
            SetRangesSchemas(DefaultValues.RangesDictionary);

            CheckItems(DefaultValues.parametersToDisplay.ParametersList);
            SetShowHideSchemas(DefaultValues.showHideDictionary, DefaultValues.filtersShowHideDictionary);
            CheckScheme(DefaultValues.parametersToDisplay.AssignedSchema, DefaultValues.machine);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            if (keyData == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }          
    }
}