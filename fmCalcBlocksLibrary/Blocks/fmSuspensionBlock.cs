using System;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;
using System.Drawing;
using fmCalculatorsLibrary;
using System.Collections.Generic;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmSuspensionBlock : fmBaseBlock
    {
        //private RadioButton rBtn_rho_f;
        //private RadioButton rBtn_rho_s;
        //private RadioButton rBtn_rho_sus;
        //private RadioButton rBtn_C;

        private fmBlockVariableParameter rho_f;
        private fmBlockVariableParameter rho_s;
        private fmBlockVariableParameter rho_sus;
        private fmBlockVariableParameter Cm;
        private fmBlockVariableParameter Cv;
        private fmBlockVariableParameter C;

        private fmBlockParameterGroup rho_f_group = new fmBlockParameterGroup();
        private fmBlockParameterGroup rho_s_group = new fmBlockParameterGroup();
        private fmBlockParameterGroup rho_sus_group = new fmBlockParameterGroup();
        private fmBlockParameterGroup C_group = new fmBlockParameterGroup();

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

        public fmSuspensionCalculator.SuspensionCalculationOptions calculationOption;

        //public fmSuspensionCalculator.SuspensionCalculationOptions GetCalculationOption()
        //{
        //    if (rBtn_rho_f.Checked)
        //    {
        //        return fmSuspensionCalculator.SuspensionCalculationOptions.RHOF_CALCULATED;
        //    }
        //    else if (rBtn_rho_s.Checked)
        //    {
        //        return fmSuspensionCalculator.SuspensionCalculationOptions.RHOS_CALCULATED;
        //    }
        //    else if (rBtn_rho_sus.Checked)
        //    {
        //        return fmSuspensionCalculator.SuspensionCalculationOptions.RHOSUS_CALCULATED;
        //    }
        //    else if (rBtn_C.Checked)
        //    {
        //        return fmSuspensionCalculator.SuspensionCalculationOptions.CM_CV_C_CALCULATED;
        //    }
        //    else
        //    {
        //        throw new Exception("No radiobuttons checked in suspension block");
        //    }
        //}

        override public void DoCalculations()
        {
            fmSuspensionCalculator suspesionCalculator =
                new fmSuspensionCalculator(AllParameters);
            //suspesionCalculator.calculationOption = GetCalculationOption();
            suspesionCalculator.calculationOption = calculationOption;
            suspesionCalculator.DoCalculations();
        }

        public fmSuspensionBlock(DataGridViewCell rho_f_Cell,
                                 DataGridViewCell rho_s_Cell,
                                 DataGridViewCell rho_sus_Cell,
                                 DataGridViewCell Cm_Cell,
                                 DataGridViewCell Cv_Cell,
                                 DataGridViewCell C_Cell)
        {
            AddParameter(ref rho_f, fmGlobalParameter.rho_f, rho_f_Cell, true);
            AddParameter(ref rho_s, fmGlobalParameter.rho_s, rho_s_Cell, true);
            AddParameter(ref rho_sus, fmGlobalParameter.rho_sus, rho_sus_Cell, true);
            AddParameter(ref Cm, fmGlobalParameter.Cm, Cm_Cell, false);
            AddParameter(ref Cv, fmGlobalParameter.Cv, Cv_Cell, false);
            AddParameter(ref C, fmGlobalParameter.C, C_Cell, false);

            rho_f.group = rho_f_group;
            rho_s.group = rho_s_group;
            rho_sus.group = rho_sus_group;
            Cm.group = C_group;
            Cv.group = C_group;
            C.group = C_group;

            processOnChange = true;

            calculationOption = fmSuspensionCalculator.SuspensionCalculationOptions.RHOSUS_CALCULATED;

            //if (rBtn_rho_f != null 
            //    || rBtn_rho_s != null
            //    || rBtn_rho_sus != null
            //    || rBtn_C != null)
            //{
            //    RadioButtonCheckChanged(null, new EventArgs());
            //}
        }

        public void SetCalculationOptionAndUpdateCellsColor(fmSuspensionCalculator.SuspensionCalculationOptions calculationOption)
        {
            this.calculationOption = calculationOption;
            UpdateCellsColorsAndReadOnly();
        }

        private void UpdateCellsColorsAndReadOnly()
        {
            if (processOnChange)
            {
                rho_f.isInputed = true;
                rho_s.isInputed = true;
                rho_sus.isInputed = true;
                Cm.isInputed = true;
                Cv.isInputed = false;
                C.isInputed = false;

                foreach (fmBlockVariableParameter p in parameters)
                {
                    p.cell.ReadOnly = false;
                }

                //if (rBtn_rho_f.Checked)
                if (calculationOption == fmSuspensionCalculator.SuspensionCalculationOptions.RHOF_CALCULATED)
                {
                    rho_f.isInputed = false;
                    rho_f.cell.ReadOnly = true;
                }
                //else if (rBtn_rho_s.Checked)
                else if (calculationOption == fmSuspensionCalculator.SuspensionCalculationOptions.RHOS_CALCULATED)
                {
                    rho_s.isInputed = false;
                    rho_s.cell.ReadOnly = true;
                }
                //else if (rBtn_rho_sus.Checked)
                else if (calculationOption == fmSuspensionCalculator.SuspensionCalculationOptions.RHOSUS_CALCULATED)
                {
                    rho_sus.isInputed = false;
                    rho_sus.cell.ReadOnly = true;
                }
                //else if (rBtn_C.Checked)
                else if (calculationOption == fmSuspensionCalculator.SuspensionCalculationOptions.CM_CV_C_CALCULATED)
                {
                    Cm.isInputed = false;
                    Cm.cell.ReadOnly = true;
                    Cv.cell.ReadOnly = true;
                    C.cell.ReadOnly = true;
                }

                CallValuesChanged();
            }
        }

        //private void RadioButtonCheckChanged(object sender, EventArgs e)
        //{
        //    if (processOnChange)
        //    {
        //        rho_f.isInputed = true;
        //        rho_s.isInputed = true;
        //        rho_sus.isInputed = true;
        //        Cm.isInputed = true;
        //        Cv.isInputed = false;
        //        C.isInputed = false;

        //        foreach (fmBlockVariableParameter p in parameters)
        //        {
        //            p.cell.ReadOnly = false;
        //        }

        //        if (rBtn_rho_f.Checked)
        //        {
        //            rho_f.isInputed = false;
        //            rho_f.cell.ReadOnly = true;
        //        }
        //        else if (rBtn_rho_s.Checked)
        //        {
        //            rho_s.isInputed = false;
        //            rho_s.cell.ReadOnly = true;
        //        }
        //        else if (rBtn_rho_sus.Checked)
        //        {
        //            rho_sus.isInputed = false;
        //            rho_sus.cell.ReadOnly = true;
        //        }
        //        else if (rBtn_C.Checked)
        //        {
        //            Cm.isInputed = false;
        //            Cm.cell.ReadOnly = true;
        //            Cv.cell.ReadOnly = true;
        //            C.cell.ReadOnly = true;
        //        }

        //        CallValuesChanged();
        //    }
        //}
        //private void AssignRadioButton(ref RadioButton localRadioButton,
        //                               RadioButton globalRadioButton)
        //{
        //    localRadioButton = globalRadioButton;
        //    if (localRadioButton != null)
        //    {
        //        localRadioButton.CheckedChanged += RadioButtonCheckChanged;
        //    }
        //}
    }
}