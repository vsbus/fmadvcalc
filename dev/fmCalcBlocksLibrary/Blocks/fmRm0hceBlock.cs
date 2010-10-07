using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculatorsLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmRm0HceBlock : fmBaseBlock
    {
        // ReSharper disable InconsistentNaming
        private readonly fmBlockVariableParameter Rm0;
        private readonly fmBlockVariableParameter hce;
        private readonly fmBlockConstantParameter Pc0;
        private readonly fmBlockParameterGroup Rm0_hce_group = new fmBlockParameterGroup();

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
        // ReSharper restore InconsistentNaming

        override public void DoCalculations()
        {
            var rm0HceCalculator = new fmRm0HceCalculator(AllParameters);
            rm0HceCalculator.DoCalculations();
        }

        // ReSharper disable InconsistentNaming
        public fmRm0HceBlock(
            DataGridViewCell Rm0_Cell,
            DataGridViewCell hce_Cell)
        {
            AddParameter(ref Rm0, fmGlobalParameter.Rm0, Rm0_Cell, false);
            AddParameter(ref hce, fmGlobalParameter.hce0, hce_Cell, true);

            AddConstantParameter(ref Pc0, fmGlobalParameter.Pc0);

            Rm0.group = Rm0_hce_group;
            hce.group = Rm0_hce_group;

            processOnChange = true;
        }
        // ReSharper restore InconsistentNaming

        public fmRm0HceBlock() : this(null, null) { }
    }
}