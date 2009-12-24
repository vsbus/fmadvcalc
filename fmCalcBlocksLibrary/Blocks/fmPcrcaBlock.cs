using System;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmPcrcaBlock : fmBaseBlock
    {
        private fmBlockParameter Pc, rc, a;
        private fmValue rho_s_value, eps_value;

        public fmValue Pc_Value
        {
            get { return Pc.value; }
            set { Pc.value = value; }
        }
        public fmValue rc_Value
        {
            get { return rc.value; }
            set { rc.value = value; }
        }
        public fmValue a_Value
        {
            get { return a.value; }
            set { a.value = value; }
        }
        public fmValue rho_s_Value
        {
            get { return rho_s_value; }
            set { rho_s_value = value; }
        }
        public fmValue eps_Value
        {
            get { return eps_value; }
            set { eps_value = value; }
        }

        override public void DoCalculations()
        {
            fmCalculatorsLibrary.fmPcrcaCalculator.CalculationOptions calculationOptions;

            if (Pc.isInputed)
            {
                calculationOptions = fmCalculatorsLibrary.fmPcrcaCalculator.CalculationOptions.PC_INPUT;
            }
            else if (rc.isInputed)
            {
                calculationOptions = fmCalculatorsLibrary.fmPcrcaCalculator.CalculationOptions.RC_INPUT;
            }
            else if (a.isInputed)
            {
                calculationOptions = fmCalculatorsLibrary.fmPcrcaCalculator.CalculationOptions.A_INPUT;
            }
            else
            {
                throw new Exception("nothing is inputed");
            }

            fmCalculatorsLibrary.fmPcrcaCalculator.Process(calculationOptions,
                                                           ref Pc.value,
                                                           ref rc.value,
                                                           ref a.value,
                                                           rho_s_value,
                                                           eps_value);
        }
        override public void UpdateIsInputed(fmBlockParameter enteredParameter)
        {
            if (enteredParameter == Pc)
            {
                Pc.isInputed = true;
                rc.isInputed = false;
                a.isInputed = false;
            }
            else if (enteredParameter == rc)
            {
                Pc.isInputed = false;
                rc.isInputed = true;
                a.isInputed = false;
            }
            else if (enteredParameter == a)
            {
                Pc.isInputed = false;
                rc.isInputed = false;
                a.isInputed = true;
            }
        }
        
        public fmPcrcaBlock(
            DataGridViewCell Pc_Cell,
            DataGridViewCell rc_Cell,
            DataGridViewCell a_Cell)
        {
            AddParameter(ref Pc, fmGlobalParameter.Pc, Pc_Cell, true);
            AddParameter(ref rc, fmGlobalParameter.rc, rc_Cell, false);
            AddParameter(ref a, fmGlobalParameter.a, a_Cell, false);

            processOnChange = true;
            //ReWriteParameters();
        }
    }
}