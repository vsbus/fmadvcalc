using System;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;
using fmCalculatorsLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmRm0hceBlock : fmBaseBlock
    {
        private fmBlockVariableParameter Rm0, hce;
        private fmBlockConstantParameter Pc0;
        private fmBlockParameterGroup Rm0_hce_group = new fmBlockParameterGroup();

        public fmValue hce_Value
        {
            get { return hce.value; }
            set { hce.value = value; }
        }
        public fmValue Rm0_Value
        {
            get { return Rm0.value; }
            set { Rm0.value = value; }
        }
        public fmValue Pc0_Value
        {
            get { return Pc0.value; }
            set { Pc0.value = value; }
        }

        override public void DoCalculations()
        {
            fmRm0hceCalculator Rm0HceCalculator = new fmRm0hceCalculator(AllParameters);
            Rm0HceCalculator.DoCalculations();
        }

        public fmRm0hceBlock(
            DataGridViewCell Rm0_Cell,
            DataGridViewCell hce_Cell)
        {
            AddParameter(ref Rm0, fmGlobalParameter.Rm0, Rm0_Cell, false);
            AddParameter(ref hce, fmGlobalParameter.hce, hce_Cell, true);

            AddConstantParameter(ref Pc0, fmGlobalParameter.Pc0);

            Rm0.group = Rm0_hce_group;
            hce.group = Rm0_hce_group;

            processOnChange = true;
        }
    }
}