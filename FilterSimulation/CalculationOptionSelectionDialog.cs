using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using fmCalculatorsLibrary;

namespace FilterSimulation
{
    public partial class CalculationOptionSelectionDialog : Form
    {
        public fmSuspensionCalculator.SuspensionCalculationOptions suspensionCalculationOption;
        public fmFilterMachiningCalculator.FilterMachiningCalculationOption simulationCalculationOption;

        public CalculationOptionSelectionDialog()
        {
            InitializeComponent();
        }

        private void CalculationOptionSelectionDialog_Load(object sender, EventArgs e)
        {
            rho_f_radioButton.Checked = suspensionCalculationOption ==
                                        fmSuspensionCalculator.SuspensionCalculationOptions.RHOF_CALCULATED;
            rho_s_radioButton.Checked = suspensionCalculationOption ==
                                        fmSuspensionCalculator.SuspensionCalculationOptions.RHOS_CALCULATED;
            rho_sus_radioButton.Checked = suspensionCalculationOption ==
                                          fmSuspensionCalculator.SuspensionCalculationOptions.RHOSUS_CALCULATED;
            CmCvC_radioButton.Checked = suspensionCalculationOption ==
                                        fmSuspensionCalculator.SuspensionCalculationOptions.CM_CV_C_CALCULATED;

            fmCalculationOptionView1.SetSelectedOption(simulationCalculationOption);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
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
                suspensionCalculationOption = fmSuspensionCalculator.SuspensionCalculationOptions.RHOF_CALCULATED;
            if (rho_s_radioButton.Checked)
                suspensionCalculationOption = fmSuspensionCalculator.SuspensionCalculationOptions.RHOS_CALCULATED;
            if (rho_sus_radioButton.Checked)
                suspensionCalculationOption = fmSuspensionCalculator.SuspensionCalculationOptions.RHOSUS_CALCULATED;
            if (CmCvC_radioButton.Checked)
                suspensionCalculationOption = fmSuspensionCalculator.SuspensionCalculationOptions.CM_CV_C_CALCULATED;
        }

        private void fmCalculationOptionView1_CheckedChangedForUpdatingCalculationOptions(object sender, EventArgs e)
        {
            simulationCalculationOption = fmCalculationOptionView1.GetSelectedOption();
        }
    }
}