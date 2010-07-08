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

        override public void DoCalculations()
        {
            fmSuspensionCalculator suspesionCalculator =
                new fmSuspensionCalculator(AllParameters);
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

            SetCalculationOptionAndUpdateCellsStyle(fmSuspensionCalculator.SuspensionCalculationOptions.RHOSUS_CALCULATED);
        }
        public fmSuspensionBlock() : this(
            null,null,null,
            null,null,null)
        {}

        public void SetCalculationOptionAndUpdateCellsStyle(fmSuspensionCalculator.SuspensionCalculationOptions calculationOption)
        {
            this.calculationOption = calculationOption;
            UpdateCellsColorsAndReadOnly();
        }

        private void SetCellReadOnlyFlag(fmBlockVariableParameter p, bool value)
        {
            if (p.cell != null)
                p.cell.ReadOnly = value;
        }

        private void UpdateCellsColorsAndReadOnly()
        {
            if (processOnChange)
            {
                rho_f.IsInputed = true;
                rho_s.IsInputed = true;
                rho_sus.IsInputed = true;
                Cm.IsInputed = true;
                Cv.IsInputed = false;
                C.IsInputed = false;

                foreach (fmBlockVariableParameter p in parameters)
                {
                    //p.cell.ReadOnly = false;
                    SetCellReadOnlyFlag(p, false);
                }

                //if (rBtn_rho_f.Checked)
                if (calculationOption == fmSuspensionCalculator.SuspensionCalculationOptions.RHOF_CALCULATED)
                {
                    rho_f.IsInputed = false;
                    //rho_f.cell.ReadOnly = true;
                    SetCellReadOnlyFlag(rho_f, true);
                }
                //else if (rBtn_rho_s.Checked)
                else if (calculationOption == fmSuspensionCalculator.SuspensionCalculationOptions.RHOS_CALCULATED)
                {
                    rho_s.IsInputed = false;
                    //rho_s.cell.ReadOnly = true;
                    SetCellReadOnlyFlag(rho_s, true);
                }
                //else if (rBtn_rho_sus.Checked)
                else if (calculationOption == fmSuspensionCalculator.SuspensionCalculationOptions.RHOSUS_CALCULATED)
                {
                    rho_sus.IsInputed = false;
                    //rho_sus.cell.ReadOnly = true;
                    SetCellReadOnlyFlag(rho_sus, true);
                }
                //else if (rBtn_C.Checked)
                else if (calculationOption == fmSuspensionCalculator.SuspensionCalculationOptions.CM_CV_C_CALCULATED)
                {
                    Cm.IsInputed = false;
                    //Cm.cell.ReadOnly = true;
                    //Cv.cell.ReadOnly = true;
                    //C.cell.ReadOnly = true;
                    SetCellReadOnlyFlag(Cm, true);
                    SetCellReadOnlyFlag(Cv, true);
                    SetCellReadOnlyFlag(C, true);
                }

                CallValuesChanged();
            }
        }
    }
}