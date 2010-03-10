using System;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmRm0hceBlock : fmBaseBlock
    {
        private fmBlockParameter Rm0, hce;
        private fmBlockConstantParameter Pc;
        private fmBlockParameterGroup Rm_hce_group = new fmBlockParameterGroup();

        public fmValue hce_Value
        {
            get { return hce.value; }
            set { hce.value = value; }
        }
        public fmValue Rm_Value
        {
            get { return Rm0.value; }
            set { Rm0.value = value; }
        }
        public fmValue Pc_Value
        {
            get { return Pc.value; }
            set { Pc.value = value; }
        }

        override public void DoCalculations()
        {
            fmCalculatorsLibrary.fmRmhceCalculator.CalculationOptions calculationOptions;

            if (hce.isInputed)
            {
                calculationOptions = fmCalculatorsLibrary.fmRmhceCalculator.CalculationOptions.HCE_INPUT;
            }
            else if (Rm0.isInputed)
            {
                calculationOptions = fmCalculatorsLibrary.fmRmhceCalculator.CalculationOptions.RM_INPUT;
            }
            else
            {
                throw new Exception("not hce neighter Rm is inputed");
            }

            fmCalculatorsLibrary.fmRmhceCalculator.Process(calculationOptions,
                                                           ref Rm0.value,
                                                           ref hce.value,
                                                           Pc.value);
        }
        
        public fmRm0hceBlock(
            DataGridViewCell Rm_Cell,
            DataGridViewCell hce_Cell)
        {
            AddParameter(ref Rm0, fmGlobalParameter.Rm0, Rm_Cell, false);
            AddParameter(ref hce, fmGlobalParameter.hce, hce_Cell, true);

            AddConstantParameter(ref Pc, fmGlobalParameter.Pc);

            Rm0.group = Rm_hce_group;
            hce.group = Rm_hce_group;

            processOnChange = true;
        }
    }
}