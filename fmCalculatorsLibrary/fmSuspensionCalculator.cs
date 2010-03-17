using fmCalculationLibrary;
using fmCalculationLibrary.Equations;
using System.Collections.Generic;

namespace fmCalculatorsLibrary
{
    public class fmSuspensionCalculator : fmBaseCalculator
    {
        public enum SuspensionCalculationOptions
        {
            RHOF_CALCULATED,
            RHOS_CALCULATED,
            RHOSUS_CALCULATED,
            CM_CV_C_CALCULATED
        }
        public SuspensionCalculationOptions calculationOption;

        public fmSuspensionCalculator(List<fmCalculationBaseParameter> parameterList) : base(parameterList) { }

        override public void DoCalculations()
        {
            fmCalculationVariableParameter rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationVariableParameter;
            fmCalculationVariableParameter rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationVariableParameter;
            fmCalculationVariableParameter rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Cm = variables[fmGlobalParameter.Cm] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Cv = variables[fmGlobalParameter.Cv] as fmCalculationVariableParameter;
            fmCalculationVariableParameter C = variables[fmGlobalParameter.C] as fmCalculationVariableParameter;
            
            System.Exception NoCIsInputed = new System.Exception("Some of Cm, Cv or must be inputed");

            switch (calculationOption)
            {
                case SuspensionCalculationOptions.RHOF_CALCULATED:
                    {
                        if (Cm.isInputed)
                            rho_f.value = SuspensionEquations.Eval_rho_f_From_rho_s_rho_sus_Cm(rho_s.value, rho_sus.value, Cm.value);
                        else if (Cv.isInputed)
                            rho_f.value = SuspensionEquations.Eval_rho_f_From_rho_s_rho_sus_Cv(rho_s.value, rho_sus.value, Cv.value);
                        else if (C.isInputed)
                            rho_f.value = SuspensionEquations.Eval_rho_f_From_rho_s_rho_sus_C(rho_s.value, rho_sus.value, C.value);
                        else 
                            throw NoCIsInputed;
                        break;
                    }
                case SuspensionCalculationOptions.RHOS_CALCULATED:
                    {
                        if (Cm.isInputed)
                            rho_s.value = SuspensionEquations.Eval_rho_s_From_rho_f_rho_sus_Cm(rho_f.value, rho_sus.value, Cm.value);
                        else if (Cv.isInputed)
                            rho_s.value = SuspensionEquations.Eval_rho_s_From_rho_f_rho_sus_Cv(rho_f.value, rho_sus.value, Cv.value);
                        else if (C.isInputed)
                            rho_s.value = SuspensionEquations.Eval_rho_s_From_rho_f_rho_sus_C(rho_f.value, rho_sus.value, C.value);
                        else throw 
                            NoCIsInputed;
                        break;
                    }
                case SuspensionCalculationOptions.RHOSUS_CALCULATED:
                    {
                        if (Cm.isInputed)
                            rho_sus.value = SuspensionEquations.Eval_rho_sus_From_rho_f_rho_s_Cm(rho_f.value, rho_s.value, Cm.value);
                        else if (Cv.isInputed)
                            rho_sus.value = SuspensionEquations.Eval_rho_sus_From_rho_f_rho_s_Cv(rho_f.value, rho_s.value, Cv.value);
                        else if (C.isInputed)
                            rho_sus.value = SuspensionEquations.Eval_rho_sus_From_rho_f_rho_s_C(rho_f.value, rho_s.value, C.value);
                        else 
                            throw NoCIsInputed;
                        break;
                    }
                case SuspensionCalculationOptions.CM_CV_C_CALCULATED:
                    {
                        break;
                    }
                default:
                    throw new System.Exception("Unknown calculation option");
            }

            if (!Cm.isInputed) Cm.value = SuspensionEquations.Eval_Cm_From_rho(rho_f.value, rho_s.value, rho_sus.value);
            if (!Cv.isInputed) Cv.value = SuspensionEquations.Eval_Cv_From_rho(rho_f.value, rho_s.value, rho_sus.value);
            if (!C.isInputed) C.value = SuspensionEquations.Eval_C_From_rho(rho_f.value, rho_s.value, rho_sus.value);
        }
    }
}
