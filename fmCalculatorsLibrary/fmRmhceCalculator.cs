using fmCalculationLibrary;
using fmCalculationLibrary.Equations;

namespace fmCalculatorsLibrary
{
    public class fmRmhceCalculator : fmBaseCalculator
    {
        public enum CalculationOptions
        {
            RM_INPUT,
            HCE_INPUT
        }
        public class fmConstants
        {
            public fmValue Pc;
        }
        public class fmVariables
        {
            public fmValue Rm;
            public fmValue hce;
        }

        public CalculationOptions calculationOption;
        public fmConstants constants = new fmConstants();
        public fmVariables variables = new fmVariables();

        override public void DoCalculations()
        {
            switch (calculationOption)
            {
                case CalculationOptions.RM_INPUT:
                    {
                        variables.hce = RmhceEquations.Eval_hce_From_Rm_Pc(variables.Rm, constants.Pc);
                    }
                    break;
                case CalculationOptions.HCE_INPUT:
                    {
                        variables.Rm = RmhceEquations.Eval_Rm_From_hce_Pc(variables.hce, constants.Pc);
                    }
                    break;
            }
        }

        public fmRmhceCalculator(CalculationOptions defaultCalculationOption)
        {
            calculationOption = defaultCalculationOption;
        }

        static public void Process(CalculationOptions calculationOption,
            ref fmValue Rm,
            ref fmValue hce,
            fmValue Pc)
        {
            fmRmhceCalculator c = new fmRmhceCalculator(calculationOption);

            c.variables.Rm = Rm;
            c.variables.hce = hce;
            c.constants.Pc = Pc;

            c.DoCalculations();

            Rm = c.variables.Rm;
            hce = c.variables.hce;
        }
    }
}
