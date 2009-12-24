using fmCalculationLibrary;
using fmCalculationLibrary.Equations;

namespace fmCalculatorsLibrary
{
    public class fmSuspensionCalculator : fmBaseCalculator
    {
        public enum CalculationOptions
        {
            RHOF_CALCULATED_CM_INPUT,
            RHOF_CALCULATED_CV_INPUT,
            RHOF_CALCULATED_C_INPUT,
            RHOS_CALCULATED_CM_INPUT,
            RHOS_CALCULATED_CV_INPUT,
            RHOS_CALCULATED_C_INPUT,
            RHOSUS_CALCULATED_CM_INPUT,
            RHOSUS_CALCULATED_CV_INPUT,
            RHOSUS_CALCULATED_C_INPUT,
            CM_CV_C_CALCULATED
        }
        public class fmVariables
        {
            public fmValue rho_f;
            public fmValue rho_s;
            public fmValue rho_sus;
            public fmValue Cm;
            public fmValue Cv;
            public fmValue C;
        }

        public CalculationOptions calculationOption;
        public fmVariables variables = new fmVariables();

        override public void DoCalculations()
        {
            bool CmIsInputed = calculationOption == CalculationOptions.RHOF_CALCULATED_CM_INPUT
                || calculationOption == CalculationOptions.RHOS_CALCULATED_CM_INPUT
                || calculationOption == CalculationOptions.RHOSUS_CALCULATED_CM_INPUT;

            bool CvIsInputed = calculationOption == CalculationOptions.RHOF_CALCULATED_CV_INPUT
                || calculationOption == CalculationOptions.RHOS_CALCULATED_CV_INPUT
                || calculationOption == CalculationOptions.RHOSUS_CALCULATED_CV_INPUT;

            bool CIsInputed = calculationOption == CalculationOptions.RHOF_CALCULATED_C_INPUT
                || calculationOption == CalculationOptions.RHOS_CALCULATED_C_INPUT
                || calculationOption == CalculationOptions.RHOSUS_CALCULATED_C_INPUT;

            switch (calculationOption)
            {
                case CalculationOptions.RHOF_CALCULATED_CM_INPUT:
                    {
                        variables.rho_f = SuspensionEquations.Eval_rho_f_From_rho_s_rho_sus_Cm(variables.rho_s, variables.rho_sus, variables.Cm);
                        break;
                    }
                case CalculationOptions.RHOF_CALCULATED_CV_INPUT:
                    {
                        variables.rho_f = SuspensionEquations.Eval_rho_f_From_rho_s_rho_sus_Cv(variables.rho_s, variables.rho_sus, variables.Cv);
                        break;
                    }
                case CalculationOptions.RHOF_CALCULATED_C_INPUT:
                    {
                        variables.rho_f = SuspensionEquations.Eval_rho_f_From_rho_s_rho_sus_C(variables.rho_s, variables.rho_sus, variables.C);
                        break;
                    }
                case CalculationOptions.RHOS_CALCULATED_CM_INPUT:
                    {
                        variables.rho_s = SuspensionEquations.Eval_rho_s_From_rho_f_rho_sus_Cm(variables.rho_f, variables.rho_sus, variables.Cm);
                        break;
                    }
                case CalculationOptions.RHOS_CALCULATED_CV_INPUT:
                    {
                        variables.rho_s = SuspensionEquations.Eval_rho_s_From_rho_f_rho_sus_Cv(variables.rho_f, variables.rho_sus, variables.Cv);
                        break;
                    }
                case CalculationOptions.RHOS_CALCULATED_C_INPUT:
                    {
                        variables.rho_s = SuspensionEquations.Eval_rho_s_From_rho_f_rho_sus_C(variables.rho_f, variables.rho_sus, variables.C);
                        break;
                    }
                case CalculationOptions.RHOSUS_CALCULATED_CM_INPUT:
                    {
                        variables.rho_sus = SuspensionEquations.Eval_rho_sus_From_rho_f_rho_s_Cm(variables.rho_f, variables.rho_s, variables.Cm);
                        break;
                    }
                case CalculationOptions.RHOSUS_CALCULATED_CV_INPUT:
                    {
                        variables.rho_sus = SuspensionEquations.Eval_rho_sus_From_rho_f_rho_s_Cv(variables.rho_f, variables.rho_s, variables.Cv);
                        break;
                    }
                case CalculationOptions.RHOSUS_CALCULATED_C_INPUT:
                    {
                        variables.rho_sus = SuspensionEquations.Eval_rho_sus_From_rho_f_rho_s_C(variables.rho_f, variables.rho_s, variables.C);
                        break;
                    }
                case CalculationOptions.CM_CV_C_CALCULATED:
                    {
                        break;
                    }
            }

            if (!CmIsInputed) variables.Cm = SuspensionEquations.Eval_Cm_From_rho(variables.rho_f, variables.rho_s, variables.rho_sus);
            if (!CvIsInputed) variables.Cv = SuspensionEquations.Eval_Cv_From_rho(variables.rho_f, variables.rho_s, variables.rho_sus);
            if (!CIsInputed) variables.C = SuspensionEquations.Eval_C_From_rho(variables.rho_f, variables.rho_s, variables.rho_sus);
        }

        public fmSuspensionCalculator(CalculationOptions defaultCalculationOption)
        {
            calculationOption = defaultCalculationOption;
        }

        static public void Process(CalculationOptions calculationOption,
            ref fmValue rho_f,
            ref fmValue rho_s,
            ref fmValue rho_sus,
            ref fmValue Cm,
            ref fmValue Cv,
            ref fmValue C)
        {
            fmSuspensionCalculator c = new fmSuspensionCalculator(calculationOption);

            c.variables.rho_f = rho_f;
            c.variables.rho_s = rho_s;
            c.variables.rho_sus = rho_sus;
            c.variables.Cm = Cm;
            c.variables.Cv = Cv;
            c.variables.C = C;
            
            c.DoCalculations();

            rho_f = c.variables.rho_f;
            rho_s = c.variables.rho_s;
            rho_sus = c.variables.rho_sus;
            Cm = c.variables.Cm;
            Cv = c.variables.Cv;
            C = c.variables.C;
        }
    }
}
