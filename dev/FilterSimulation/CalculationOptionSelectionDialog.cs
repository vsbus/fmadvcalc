using System;
using System.Windows.Forms;
using fmCalculatorsLibrary;

namespace FilterSimulation
{
    public partial class fmCalculationOptionSelectionDialog : Form
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

        public fmCalculationOptionSelectionDialog()
        {
            InitializeComponent();
        }

        // ReSharper disable InconsistentNaming
        private void CalculationOptionSelectionDialog_Load(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
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
        }

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

        // ReSharper disable InconsistentNaming
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
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
        // ReSharper restore InconsistentNaming

    }
}