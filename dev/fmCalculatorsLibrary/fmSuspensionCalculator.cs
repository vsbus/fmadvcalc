using fmCalculationLibrary;
using fmCalculationLibrary.Equations;
using System.Collections.Generic;

namespace fmCalculatorsLibrary
{
    public class fmSuspensionCalculator : fmBaseCalculator
    {
        public enum fmSuspensionCalculationOptions
        {
            UNDEFINED,
            RHOF_CALCULATED,
            RHOS_CALCULATED,
            RHOSUS_CALCULATED,
            CM_CV_C_CALCULATED
        }
        public fmSuspensionCalculationOptions calculationOption;

        public fmSuspensionCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }

        override public void DoCalculations()
        {
            // ReSharper disable InconsistentNaming
            var rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationVariableParameter;
            var rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationVariableParameter;
            var rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationVariableParameter;
            var Cm = variables[fmGlobalParameter.Cm] as fmCalculationVariableParameter;
            var Cv = variables[fmGlobalParameter.Cv] as fmCalculationVariableParameter;
            var C = variables[fmGlobalParameter.C] as fmCalculationVariableParameter;
            // ReSharper restore InconsistentNaming
            
            var noCIsInputedException = new System.Exception("Some of Cm, Cv or must be inputed");

            // ReSharper disable PossibleNullReferenceException
            switch (calculationOption)
            {
                case fmSuspensionCalculationOptions.RHOF_CALCULATED:
                    {
                        if (Cm.isInputed)
                            rho_f.value = fmSuspensionEquations.Eval_rho_f_From_rho_s_rho_sus_Cm(rho_s.value, rho_sus.value, Cm.value);
                        else if (Cv.isInputed)
                            rho_f.value = fmSuspensionEquations.Eval_rho_f_From_rho_s_rho_sus_Cv(rho_s.value, rho_sus.value, Cv.value);
                        else if (C.isInputed)
                            rho_f.value = fmSuspensionEquations.Eval_rho_f_From_rho_s_rho_sus_C(rho_s.value, rho_sus.value, C.value);
                        else 
                            throw noCIsInputedException;
                        break;
                    }
                case fmSuspensionCalculationOptions.RHOS_CALCULATED:
                    {
                        if (Cm.isInputed)
                            rho_s.value = fmSuspensionEquations.Eval_rho_s_From_rho_f_rho_sus_Cm(rho_f.value, rho_sus.value, Cm.value);
                        else if (Cv.isInputed)
                            rho_s.value = fmSuspensionEquations.Eval_rho_s_From_rho_f_rho_sus_Cv(rho_f.value, rho_sus.value, Cv.value);
                        else if (C.isInputed)
                            rho_s.value = fmSuspensionEquations.Eval_rho_s_From_rho_f_rho_sus_C(rho_f.value, rho_sus.value, C.value);
                        else throw 
                            noCIsInputedException;
                        break;
                    }
                case fmSuspensionCalculationOptions.RHOSUS_CALCULATED:
                    {
                        if (Cm.isInputed)
                            rho_sus.value = fmSuspensionEquations.Eval_rho_sus_From_rho_f_rho_s_Cm(rho_f.value, rho_s.value, Cm.value);
                        else if (Cv.isInputed)
                            rho_sus.value = fmSuspensionEquations.Eval_rho_sus_From_rho_f_rho_s_Cv(rho_f.value, rho_s.value, Cv.value);
                        else if (C.isInputed)
                            rho_sus.value = fmSuspensionEquations.Eval_rho_sus_From_rho_f_rho_s_C(rho_f.value, rho_s.value, C.value);
                        else 
                            throw noCIsInputedException;
                        break;
                    }
                case fmSuspensionCalculationOptions.CM_CV_C_CALCULATED:
                    {
                        break;
                    }
                default:
                    throw new System.Exception("Unknown calculation option");
            }

            if (!Cm.isInputed) Cm.value = fmSuspensionEquations.Eval_Cm_From_rho(rho_f.value, rho_s.value, rho_sus.value);
            if (!Cv.isInputed) Cv.value = fmSuspensionEquations.Eval_Cv_From_rho(rho_f.value, rho_s.value, rho_sus.value);
            if (!C.isInputed) C.value = fmSuspensionEquations.Eval_C_From_rho(rho_f.value, rho_s.value, rho_sus.value);
            // ReSharper restore PossibleNullReferenceException
        }
    }
}
