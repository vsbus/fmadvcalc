using fmCalculationLibrary;
using fmCalculationLibrary.Equations;

namespace fmCalculatorsLibrary
{
    public class fmPcrcaCalculator : fmBaseCalculator
    {
        public enum CalculationOptions
        {
            PC_INPUT,
            RC_INPUT,
            A_INPUT
        }
        public class fmVariables
        {
            public fmValue Pc;
            public fmValue rc;
            public fmValue a;
        }
        public class fmConstants
        {
            public fmValue rho_s;
            public fmValue eps;
        }

        public CalculationOptions calculationOption;
        public fmVariables variables = new fmVariables();
        public fmConstants constants = new fmConstants();

        override public void DoCalculations()
        {
            switch (calculationOption)
            {
                case CalculationOptions.PC_INPUT:
                    {
                        variables.rc = PcrcaEquations.Eval_rc_From_Pc(variables.Pc);
                        variables.a = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(variables.Pc, constants.eps, constants.rho_s);
                        break;
                    }
                case CalculationOptions.RC_INPUT:
                    {
                        variables.Pc = PcrcaEquations.Eval_Pc_From_rc(variables.rc);
                        variables.a = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(variables.Pc, constants.eps, constants.rho_s);
                        break;
                    }
                case CalculationOptions.A_INPUT:
                    {
                        variables.Pc = PcrcaEquations.Eval_Pc_From_a_eps_rho_s(variables.a, constants.eps, constants.rho_s);
                        variables.rc = PcrcaEquations.Eval_rc_From_Pc(variables.Pc);
                        break;
                    }
            }
        }

        public fmPcrcaCalculator(CalculationOptions defaultCalculationOption)
        {
            calculationOption = defaultCalculationOption;
        }

        static public void Process(CalculationOptions calculationOption,
            ref fmValue Pc,
            ref fmValue rc,
            ref fmValue a,
            fmValue rho_s,
            fmValue eps)
        {
            fmPcrcaCalculator c = new fmPcrcaCalculator(calculationOption);

            c.variables.Pc = Pc;
            c.variables.rc = rc;
            c.variables.a = a;
            c.constants.rho_s = rho_s;
            c.constants.eps = eps;

            c.DoCalculations();

            Pc = c.variables.Pc;
            rc = c.variables.rc;
            a = c.variables.a;
        }
    }
}
