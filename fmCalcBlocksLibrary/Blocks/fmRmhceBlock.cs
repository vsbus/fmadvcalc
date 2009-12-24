using System;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmRmhceBlock : fmBaseBlock
    {
        private fmBlockParameter Rm, hce;
        private fmValue Pc_value;

        public fmValue hce_Value
        {
            get { return hce.value; }
            set { hce.value = value; }
        }
        public fmValue Rm_Value
        {
            get { return Rm.value; }
            set { Rm.value = value; }
        }
        public fmValue Pc_Value
        {
            get { return Pc_value; }
            set { Pc_value = value; }
        }

        override public void DoCalculations()
        {
            fmCalculatorsLibrary.fmRmhceCalculator.CalculationOptions calculationOptions;

            if (hce.isInputed)
            {
                calculationOptions = fmCalculatorsLibrary.fmRmhceCalculator.CalculationOptions.HCE_INPUT;
            }
            else if (Rm.isInputed)
            {
                calculationOptions = fmCalculatorsLibrary.fmRmhceCalculator.CalculationOptions.RM_INPUT;
            }
            else
            {
                throw new Exception("not hce neighter Rm is inputed");
            }

            fmCalculatorsLibrary.fmRmhceCalculator.Process(calculationOptions,
                                                           ref Rm.value,
                                                           ref hce.value,
                                                           Pc_value);
        }
        override public void UpdateIsInputed(fmBlockParameter enteredParameter)
        {
            if (enteredParameter == hce)
            {
                hce.isInputed = true;
                Rm.isInputed = false;
            }
            else if (enteredParameter == Rm)
            {
                hce.isInputed = false;
                Rm.isInputed = true;
            }
        }
        
        public fmRmhceBlock(
            DataGridViewCell Rm_Cell,
            DataGridViewCell hce_Cell)
        {
            AddParameter(ref Rm, fmGlobalParameter.Rm, Rm_Cell, false);
            AddParameter(ref hce, fmGlobalParameter.hce, hce_Cell, true);

            processOnChange = true;
            //ReWriteParameters();
        }
    }
}