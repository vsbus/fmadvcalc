using System;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmPc0rc0a0Block : fmBaseBlock
    {
        private fmBlockParameter Pc0, rc0, a0;
        private fmBlockConstantParameter rho_s;
        private fmBlockConstantParameter eps;

        private fmBlockParameterGroup Pc_rc_a_group = new fmBlockParameterGroup();

        public fmValue Pc_Value
        {
            get { return Pc0.value; }
            set { Pc0.value = value; }
        }
        public fmValue rc_Value
        {
            get { return rc0.value; }
            set { rc0.value = value; }
        }
        public fmValue a_Value
        {
            get { return a0.value; }
            set { a0.value = value; }
        }
        public fmValue rho_s_Value
        {
            get { return rho_s.value; }
            set { rho_s.value = value; }
        }
        public fmValue eps_Value
        {
            get { return eps.value; }
            set { eps.value = value; }
        }

        override public void DoCalculations()
        {
            fmCalculatorsLibrary.fmPcrcaCalculator.CalculationOptions calculationOptions;

            if (Pc0.isInputed)
            {
                calculationOptions = fmCalculatorsLibrary.fmPcrcaCalculator.CalculationOptions.PC_INPUT;
            }
            else if (rc0.isInputed)
            {
                calculationOptions = fmCalculatorsLibrary.fmPcrcaCalculator.CalculationOptions.RC_INPUT;
            }
            else if (a0.isInputed)
            {
                calculationOptions = fmCalculatorsLibrary.fmPcrcaCalculator.CalculationOptions.A_INPUT;
            }
            else
            {
                throw new Exception("nothing is inputed");
            }

            fmCalculatorsLibrary.fmPcrcaCalculator.Process(calculationOptions,
                                                           ref Pc0.value,
                                                           ref rc0.value,
                                                           ref a0.value,
                                                           rho_s.value,
                                                           eps.value);
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
            AddConstantParameter(ref eps, fmGlobalParameter.eps);

            Pc0.group = Pc_rc_a_group;
            rc0.group = Pc_rc_a_group;
            a0.group = Pc_rc_a_group;

            processOnChange = true;
        }
    }
}