using System;
using System.Collections.Generic;
using System.Text;
using fmCalculationLibrary.Equations;
using fmCalculationLibrary;

namespace fmCalculatorsLibrary
{
    public class fmEps0dNedEpsdCalculator : fmBaseCalculator
    {
        public fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption hcdCalculationOption;
        public fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption dpdInputCalculationOption;
        public object isPlainArea;

        public fmEps0dNedEpsdCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            var eps_d = variables[fmGlobalParameter.eps_d] as fmCalculationVariableParameter;
            var Dp_d = variables[fmGlobalParameter.Dp_d] as fmCalculationVariableParameter;
            var hcd = variables[fmGlobalParameter.hcd] as fmCalculationVariableParameter;

            var Dp_f = variables[fmGlobalParameter.Dp] as fmCalculationConstantParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationConstantParameter;
            var eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            var ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
            var eps = variables[fmGlobalParameter.eps] as fmCalculationConstantParameter;
            var d0 = variables[fmGlobalParameter.d0] as fmCalculationConstantParameter;

            if (dpdInputCalculationOption == fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption.CalculatedFromCakeFormation)
            {
                Dp_d.value = Dp_f.value;
            }

            if (hcdCalculationOption == fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.CalculatedFromCakeFormation)
            {
                fmValue Dp = fmValue.Max(Dp_d.value, Dp_f.value);
                eps_d.value = fmEpsPcFrom0Equations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp, ne.value);
                if ((bool)isPlainArea)
                {
                    hcd.value = fmDeliquoringEquations.Eval_hcd_from_hcf_epsf_epsd_plainArea(hc.value, eps.value, eps_d.value);
                }
                else
                {
                    hcd.value = fmDeliquoringEquations.Eval_hcd_from_hcf_epsf_epsd_cylindricalArea(hc.value, eps.value, eps_d.value, d0.value);
                }
            }
            else
            {
                if (eps_d.isInputed)
                {
                    if ((bool)isPlainArea)
                    {
                        hcd.value = fmDeliquoringEquations.Eval_hcd_from_hcf_epsf_epsd_plainArea(hc.value, eps.value, eps_d.value);
                    }
                    else
                    {
                        hcd.value = fmDeliquoringEquations.Eval_hcd_from_hcf_epsf_epsd_cylindricalArea(hc.value, eps.value, eps_d.value, d0.value);
                    }
                }
                else
                {
                    eps_d.value = fmDeliquoringEquations.Eval_epsd_from_hcf_epsf_hcd(hc.value, eps.value, hcd.value);
                }
            }
        }
    }
}
