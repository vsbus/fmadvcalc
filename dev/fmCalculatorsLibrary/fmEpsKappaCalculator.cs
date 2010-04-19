using fmCalculationLibrary;
using fmCalculationLibrary.Equations;
using System.Collections.Generic;

namespace fmCalculatorsLibrary
{
    public class fmEpsKappaCalculator : fmBaseCalculator
    {
        public fmEpsKappaCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            fmCalculationVariableParameter eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            fmCalculationVariableParameter kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            fmCalculationConstantParameter Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            if (eps.isInputed)
            {
                kappa.value = EpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            }
            else if (kappa.isInputed)
            {
                eps.value = EpsKappaEquations.Eval_eps_From_kappa_Cv(kappa.value, Cv.value);
            }
            else
            {
                throw new System.Exception("One of eps and kappa must be inputed");
            }
        }
    }
}
