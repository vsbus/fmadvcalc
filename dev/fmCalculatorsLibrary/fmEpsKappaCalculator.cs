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
            // ReSharper disable InconsistentNaming
            var eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            var kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            var Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            // ReSharper restore InconsistentNaming

            // ReSharper disable PossibleNullReferenceException
            if (eps.isInputed)
            {
                kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            }
            else if (kappa.isInputed)
            {
                eps.value = fmEpsKappaEquations.Eval_eps_From_kappa_Cv(kappa.value, Cv.value);
            }
            else
            {
                throw new System.Exception("One of eps and kappa must be inputed");
            }
            // ReSharper restore PossibleNullReferenceException
        }
    }
}
