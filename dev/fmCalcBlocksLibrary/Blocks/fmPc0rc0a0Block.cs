using System;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmPc0rc0a0Block : fmBaseBlock
    {
        private fmBlockVariableParameter Pc0, rc0, a0;
        private fmBlockConstantParameter rho_s;
        private fmBlockConstantParameter eps0;

        private fmBlockParameterGroup Pc_rc_a_group = new fmBlockParameterGroup();

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

        override public void DoCalculations()
        {
            fmCalculatorsLibrary.fmPc0rc0a0Calculator Pc0rc0a0Calculator = new fmCalculatorsLibrary.fmPc0rc0a0Calculator(AllParameters);
            Pc0rc0a0Calculator.DoCalculations();
        }

        public fmPc0rc0a0Block(
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
        public fmPc0rc0a0Block() : this(null, null, null) { }
    }
}