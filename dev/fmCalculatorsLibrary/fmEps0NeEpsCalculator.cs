using System;
using System.Collections.Generic;
using System.Text;
using fmCalculationLibrary.Equations;
using fmCalculationLibrary;

namespace fmCalculatorsLibrary
{
    public class fmEps0NeEpsCalculator : fmBaseCalculator
    {
        public fmEps0NeEpsCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            var eps0 = variables[fmGlobalParameter.eps0] as fmCalculationVariableParameter;
            var ne = variables[fmGlobalParameter.ne] as fmCalculationVariableParameter;
            var eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;

            if (ne.isInputed)
            {
                eps.value = fmEpsPcFrom0Equations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            }
            else
            {
                ne.value = fmEpsPcFrom0Equations.Eval_ne_From_eps0_Dp_eps(eps0.value, Dp.value, eps.value);
            }
        }
    }
}
