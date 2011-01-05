using System;
using System.Collections.Generic;
using System.Text;
using fmCalculationLibrary;
using fmCalculationLibrary.Equations;

namespace fmCalculatorsLibrary
{
    public class fmSigmaPke0PkePcdRcdAlphadCalculator : fmBaseCalculator
    {
        public fmSigmaPke0PkePcdRcdAlphadCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            var Dpf = variables[fmGlobalParameter.Dp] as fmCalculationConstantParameter;
            var Dpd = variables[fmGlobalParameter.Dp_d] as fmCalculationConstantParameter;
            var nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
            var eps_d = variables[fmGlobalParameter.eps_d] as fmCalculationConstantParameter;
            var rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
            
            var sigma = variables[fmGlobalParameter.sigma] as fmCalculationVariableParameter;
            var pke0 = variables[fmGlobalParameter.pke0] as fmCalculationVariableParameter;
            var pke = variables[fmGlobalParameter.pke] as fmCalculationVariableParameter;
            var pcd = variables[fmGlobalParameter.pc_d] as fmCalculationVariableParameter;
            var rcd = variables[fmGlobalParameter.rc_d] as fmCalculationVariableParameter;
            var alphad = variables[fmGlobalParameter.alpha_d] as fmCalculationVariableParameter;

            fmValue Dp = Dpf.value.defined == false || (Dpd.value.defined == true && Dpd.value > Dpf.value)
                ? Dpd.value
                : Dpf.value;

            fmValue Pc0 = new fmValue(1e-13);
            pcd.value = fmEpsPcFrom0Equations.Eval_Pc_From_Pc0_Dp_nc(Pc0, Dp, nc.value);
            rcd.value = fmPcrcaEquations.Eval_rc_From_Pc(pcd.value);
            alphad.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(pcd.value, eps_d.value, rho_s.value);
            pke.value = fmDeliquoringEquations.Eval_pke_From_pke0_sigma_Pc(pke0.value, sigma.value, pcd.value);
        }
    }
}
