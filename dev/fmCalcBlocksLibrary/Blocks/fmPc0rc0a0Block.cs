using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmPc0Rc0A0Block : fmBaseBlock
    {
        // ReSharper disable InconsistentNaming
        private readonly fmBlockVariableParameter Pc0;
        private readonly fmBlockVariableParameter rc0;
        private readonly fmBlockVariableParameter a0;
        private readonly fmBlockConstantParameter rho_s;
        private readonly fmBlockConstantParameter eps0;

        private readonly fmBlockParameterGroup Pc_rc_a_group = new fmBlockParameterGroup();

        public fmValue Pc0_Value
        {
            get { return Pc0.value; }
            set { Pc0.value = value; }
        }
        public fmValue rc0_Value
        {
            get { return rc0.value; }
            set { rc0.value = value; }
        }
        public fmValue a0_Value
        {
            get { return a0.value; }
            set { a0.value = value; }
        }
        public fmValue rho_s_Value
        {
            get { return rho_s.value; }
            set { rho_s.value = value; }
        }
        public fmValue eps0_Value
        {
            get { return eps0.value; }
            set { eps0.value = value; }
        }
        // ReSharper restore InconsistentNaming

        override public void DoCalculations()
        {
            var pc0Rc0A0Calculator = new fmCalculatorsLibrary.fmPc0Rc0A0Calculator(AllParameters);
            pc0Rc0A0Calculator.DoCalculations();
        }

        // ReSharper disable InconsistentNaming
        public fmPc0Rc0A0Block(
            DataGridViewCell Pc_Cell,
            DataGridViewCell rc_Cell,
            DataGridViewCell a_Cell)
        {
            AddParameter(ref Pc0, fmGlobalParameter.Pc0, Pc_Cell, true);
            AddParameter(ref rc0, fmGlobalParameter.rc0, rc_Cell, false);
            AddParameter(ref a0, fmGlobalParameter.a0, a_Cell, false);

            AddConstantParameter(ref rho_s, fmGlobalParameter.rho_s);
            AddConstantParameter(ref eps0, fmGlobalParameter.eps0);

            Pc0.group = Pc_rc_a_group;
            rc0.group = Pc_rc_a_group;
            a0.group = Pc_rc_a_group;

            processOnChange = true;
        }
        // ReSharper restore InconsistentNaming

        public fmPc0Rc0A0Block() : this(null, null, null) { }
    }
}