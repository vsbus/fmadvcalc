using System;
using System.Collections.Generic;
using System.Text;
using fmCalculationLibrary.Equations;
using fmCalculationLibrary;

namespace fmCalculatorsLibrary
{
    public class fmEps0dNedEpsdCalculator : fmBaseCalculator
    {
        public fmEps0dNedEpsdCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            var eps0_d = variables[fmGlobalParameter.eps0_d] as fmCalculationVariableParameter;
            var ne_d = variables[fmGlobalParameter.ne_d] as fmCalculationVariableParameter;
            var eps_d = variables[fmGlobalParameter.eps_d] as fmCalculationVariableParameter;
            var Dp_d = variables[fmGlobalParameter.Dp_d] as fmCalculationVariableParameter;
            var hcd = variables[fmGlobalParameter.hcd] as fmCalculationVariableParameter;

            var hc = variables[fmGlobalParameter.hc] as fmCalculationConstantParameter;
            var eps = variables[fmGlobalParameter.eps] as fmCalculationConstantParameter;

            if (ne_d.isInputed)
            {
                eps_d.value = fmEpsPcFrom0Equations.Eval_eps_From_eps0_Dp_ne(eps0_d.value, Dp_d.value, ne_d.value);
            }
            else
            {
                ne_d.value = fmEpsPcFrom0Equations.Eval_ne_From_eps0_Dp_eps(eps0_d.value, Dp_d.value, eps_d.value);
            }

            hcd.value = fmDeliquoringEquations.Eval_hcd_from_hcf_epsf_epsd(hc.value, eps.value, eps_d.value);
        }
    }
}
