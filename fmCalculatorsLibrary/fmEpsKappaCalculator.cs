using fmCalculationLibrary;
using fmCalculationLibrary.Equations;

namespace fmCalculatorsLibrary
{
    public class fmEpsKappaCalculator : fmBaseCalculator
    {
        public enum CalculationOptions
        {
            EPS_IS_INPUT,
            KAPPA_IS_INPUT
        }
        public class fmConstants
        {
            public fmValue Cv;
        }
        public class fmVariables
        {
            public fmValue eps;
            public fmValue kappa;
        }

        public CalculationOptions calculationOption;
        public fmConstants constants = new fmConstants();
        public fmVariables variables = new fmVariables();

        override public void DoCalculations()
        {
            switch (calculationOption)
            {
                case CalculationOptions.EPS_IS_INPUT:
                    {
                        variables.kappa = EpsKappaEquations.Eval_kappa_From_eps_Cv(variables.eps, constants.Cv);
                    }
                    break;
                case CalculationOptions.KAPPA_IS_INPUT:
                    {
                        variables.eps = EpsKappaEquations.Eval_eps_From_kappa_Cv(variables.kappa, constants.Cv);
                    }
                    break;
            }
        }

        public fmEpsKappaCalculator(CalculationOptions defaultCalculationOption)
        {
            calculationOption = defaultCalculationOption;
        }

        static public void Process(CalculationOptions calculationOption,
            ref fmValue eps,
            ref fmValue kappa,
            fmValue Cv)
        {
            fmEpsKappaCalculator c = new fmEpsKappaCalculator(calculationOption);

            c.variables.eps = eps;
            c.variables.kappa = kappa;
            c.constants.Cv = Cv;

            c.DoCalculations();

            eps = c.variables.eps;
            kappa = c.variables.kappa;
        }

    }
}
