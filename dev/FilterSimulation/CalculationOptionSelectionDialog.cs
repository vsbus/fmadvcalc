using System;
using System.Windows.Forms;
using fmCalculatorsLibrary;

namespace FilterSimulation
{
    public partial class fmCalculationOptionSelectionDialog : Form
    {
        public fmSuspensionCalculator.fmSuspensionCalculationOptions suspensionCalculationOption;
        public fmDeliquoringSimualtionCalculator.fmDeliquoringSimualtionCalculationOption deliquoringCalculationOption;
        public fmFilterMachiningCalculator.fmFilterMachiningCalculationOption filterMachiningCalculationOption;

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

            deliquoringCheckBox.Checked = deliquoringCalculationOption ==
                                          fmDeliquoringSimualtionCalculator.fmDeliquoringSimualtionCalculationOption.
                                              HcdCalculatedFromCakeFormation;
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
            deliquoringCalculationOption = deliquoringCheckBox.Checked
                                               ? fmDeliquoringSimualtionCalculator.
                                                     fmDeliquoringSimualtionCalculationOption.
                                                     HcdCalculatedFromCakeFormation
                                               : fmDeliquoringSimualtionCalculator.
                                                     fmDeliquoringSimualtionCalculationOption.HcdInputed;
        }
        // ReSharper restore InconsistentNaming

    }
}