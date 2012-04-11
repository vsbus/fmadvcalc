using System;
using System.Collections.Generic;
using System.Text;
using fmCalculationLibrary.Equations;
using fmCalculationLibrary;

namespace fmCalculatorsLibrary
{
    public class fmEps0dNedEpsdCalculator : fmBaseCalculator
    {
        public fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption calculationOption;

        public fmEps0dNedEpsdCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            var eps_d = variables[fmGlobalParameter.eps_d] as fmCalculationVariableParameter;
            var Dp_d = variables[fmGlobalParameter.Dp_d] as fmCalculationVariableParameter;
            var hcd = variables[fmGlobalParameter.hcd] as fmCalculationVariableParameter;

            var hc = variables[fmGlobalParameter.hc] as fmCalculationConstantParameter;
            var eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            var ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
            var eps = variables[fmGlobalParameter.eps] as fmCalculationConstantParameter;

            if (calculationOption == fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.CalculatedFromCakeFormation)
            {
                eps_d.value = fmEpsPcFrom0Equations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp_d.value, ne.value);
                hcd.value = fmDeliquoringEquations.Eval_hcd_from_hcf_epsf_epsd(hc.value, eps.value, eps_d.value);
            }
            else
            {
                if (eps_d.isInputed)
                {
                    hcd.value = fmDeliquoringEquations.Eval_hcd_from_hcf_epsf_epsd(hc.value, eps.value, eps_d.value);
                }
                else
                {
                    eps_d.value = fmDeliquoringEquations.Eval_epsd_from_hcf_epsf_hcd(hc.value, eps.value, hcd.value);
                }
            }
        }
    }
}
