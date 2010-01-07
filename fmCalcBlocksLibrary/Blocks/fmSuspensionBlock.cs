using System;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;
using System.Drawing;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmSuspensionBlock : fmBaseBlock
    {
        private RadioButton rBtn_rho_f;
        private RadioButton rBtn_rho_s;
        private RadioButton rBtn_rho_sus;
        private RadioButton rBtn_C;

        private fmBlockParameter rho_f;
        private fmBlockParameter rho_s;
        private fmBlockParameter rho_sus;
        private fmBlockParameter Cm;
        private fmBlockParameter Cv;
        private fmBlockParameter C;

        public fmValue rho_f_Value
        {
            get { return rho_f.value; }
            set { rho_f.value = value; }
        }
        public fmValue rho_s_Value
        {
            get { return rho_s.value; }
            set { rho_s.value = value; }
        }
        public fmValue rho_sus_Value
        {
            get { return rho_sus.value; }
            set { rho_sus.value = value; }
        }
        public fmValue Cm_Value
        {
            get { return Cm.value; }
            set { Cm.value = value; }
        }
        public fmValue Cv_Value
        {
            get { return Cv.value; }
            set { Cv.value = value; }
        }
        public fmValue C_Value
        {
            get { return C.value; }
            set { C.value = value; }
        }

        override public void DoCalculations()
        {
            fmCalculatorsLibrary.fmSuspensionCalculator.CalculationOptions calculationOption;

            if (rho_f.isInputed == false)
            {
                if (Cm.isInputed)
                {
                    calculationOption = fmCalculatorsLibrary.fmSuspensionCalculator.CalculationOptions.RHOF_CALCULATED_CM_INPUT;
                }
                else if (Cv.isInputed)
                {
                    calculationOption = fmCalculatorsLibrary.fmSuspensionCalculator.CalculationOptions.RHOF_CALCULATED_CV_INPUT;
                }
                else if (C.isInputed)
                {
                    calculationOption = fmCalculatorsLibrary.fmSuspensionCalculator.CalculationOptions.RHOF_CALCULATED_C_INPUT;
                }
                else
                {
                    throw new Exception("nothing from Cm/Cv/C are isInputed");
                }
            }
            else if (rho_s.isInputed == false)
            {
                if (Cm.isInputed)
                {
                    calculationOption = fmCalculatorsLibrary.fmSuspensionCalculator.CalculationOptions.RHOS_CALCULATED_CM_INPUT;
                }
                else if (Cv.isInputed)
                {
                    calculationOption = fmCalculatorsLibrary.fmSuspensionCalculator.CalculationOptions.RHOS_CALCULATED_CV_INPUT;
                }
                else if (C.isInputed)
                {
                    calculationOption = fmCalculatorsLibrary.fmSuspensionCalculator.CalculationOptions.RHOS_CALCULATED_C_INPUT;
                }
                else
                {
                    throw new Exception("nothing from Cm/Cv/C are isInputed");
                }
            }
            else if (rho_sus.isInputed == false)
            {
                if (Cm.isInputed)
                {
                    calculationOption = fmCalculatorsLibrary.fmSuspensionCalculator.CalculationOptions.RHOSUS_CALCULATED_CM_INPUT;
                }
                else if (Cv.isInputed)
                {
                    calculationOption = fmCalculatorsLibrary.fmSuspensionCalculator.CalculationOptions.RHOSUS_CALCULATED_CV_INPUT;
                }
                else if (C.isInputed)
                {
                    calculationOption = fmCalculatorsLibrary.fmSuspensionCalculator.CalculationOptions.RHOSUS_CALCULATED_C_INPUT;
                }
                else
                {
                    throw new Exception("nothing from Cm/Cv/C are isInputed");
                }
            }
            else
            {
                calculationOption = fmCalculatorsLibrary.fmSuspensionCalculator.CalculationOptions.CM_CV_C_CALCULATED;
            }

            fmCalculatorsLibrary.fmSuspensionCalculator.Process(calculationOption,
                                                                ref rho_f.value,
                                                                ref rho_s.value,
                                                                ref rho_sus.value,
                                                                ref Cm.value,
                                                                ref Cv.value,
                                                                ref C.value);
        }

        override public void UpdateIsInputed(fmBlockParameter enteredParameter)
        {
            if (enteredParameter == Cm)
            {
                Cm.isInputed = true;
                Cv.isInputed = false;
                C.isInputed = false;
            }
            else if (enteredParameter == Cv)
            {
                Cm.isInputed = false;
                Cv.isInputed = true;
                C.isInputed = false;
            }
            else if (enteredParameter == C)
            {
                Cm.isInputed = false;
                Cv.isInputed = false;
                C.isInputed = true;
            }
        }
        public fmSuspensionBlock(RadioButton rho_f_RadioButton,
                                 RadioButton rho_s_RadioButton,
                                 RadioButton rho_sus_RadioButton,
                                 RadioButton C_RadioButton,
                                 DataGridViewCell rho_f_Cell,
                                 DataGridViewCell rho_s_Cell,
                                 DataGridViewCell rho_sus_Cell,
                                 DataGridViewCell Cm_Cell,
                                 DataGridViewCell Cv_Cell,
                                 DataGridViewCell C_Cell)
        {
            AssignRadioButton(ref rBtn_rho_f, rho_f_RadioButton);
            AssignRadioButton(ref rBtn_rho_s, rho_s_RadioButton);
            AssignRadioButton(ref rBtn_rho_sus, rho_sus_RadioButton);
            AssignRadioButton(ref rBtn_C, C_RadioButton);

            AddParameter(ref rho_f, fmGlobalParameter.rho_f, rho_f_Cell, true);
            AddParameter(ref rho_s, fmGlobalParameter.rho_s, rho_s_Cell, true);
            AddParameter(ref rho_sus, fmGlobalParameter.rho_sus, rho_sus_Cell, true);
            AddParameter(ref Cm, fmGlobalParameter.Cm, Cm_Cell, false);
            AddParameter(ref Cv, fmGlobalParameter.Cv, Cv_Cell, false);
            AddParameter(ref C, fmGlobalParameter.C, C_Cell, false);

            processOnChange = true;

            RadioButtonCheckChanged(null, new EventArgs());
        }

        private void RadioButtonCheckChanged(object sender, EventArgs e)
        {
            if (processOnChange)
            {
                rho_f.isInputed = true;
                rho_s.isInputed = true;
                rho_sus.isInputed = true;
                Cm.isInputed = true;
                Cv.isInputed = false;
                C.isInputed = false;

                foreach (fmBlockParameter p in parameters)
                {
                    p.cell.ReadOnly = false;
                }

                if (rBtn_rho_f.Checked)
                {
                    rho_f.isInputed = false;
                    rho_f.cell.ReadOnly = true;
                }
                else if (rBtn_rho_s.Checked)
                {
                    rho_s.isInputed = false;
                    rho_s.cell.ReadOnly = true;
                }
                else if (rBtn_rho_sus.Checked)
                {
                    rho_sus.isInputed = false;
                    rho_sus.cell.ReadOnly = true;
                }
                else if (rBtn_C.Checked)
                {
                    Cm.isInputed = false;
                    Cm.cell.ReadOnly = true;
                    Cv.cell.ReadOnly = true;
                    C.cell.ReadOnly = true;
                }
            }
        }
        private void AssignRadioButton(ref RadioButton localRadioButton,
                                       RadioButton globalRadioButton)
        {
            localRadioButton = globalRadioButton;
            localRadioButton.CheckedChanged += RadioButtonCheckChanged;
        }
    }
}