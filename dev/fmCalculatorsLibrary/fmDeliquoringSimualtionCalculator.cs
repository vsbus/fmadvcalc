using System;
using System.Collections.Generic;
using System.Text;
using fmCalculationLibrary.Equations;
using fmCalculationLibrary;

namespace fmCalculatorsLibrary
{
    public class fmDeliquoringSimualtionCalculator : fmBaseCalculator
    {
        public fmDeliquoringSimualtionCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            var hcd = variables[fmGlobalParameter.hcd] as fmCalculationVariableParameter;
            var sd = variables[fmGlobalParameter.sd] as fmCalculationVariableParameter;
            var td = variables[fmGlobalParameter.td] as fmCalculationVariableParameter;
            var K = variables[fmGlobalParameter.K] as fmCalculationVariableParameter;
            var Smech = variables[fmGlobalParameter.Smech] as fmCalculationVariableParameter;
            var S = variables[fmGlobalParameter.S] as fmCalculationVariableParameter;
            var Rfmech = variables[fmGlobalParameter.Rfmech] as fmCalculationVariableParameter;
            var Rf = variables[fmGlobalParameter.Rf] as fmCalculationVariableParameter;
            var Rf_star = variables[fmGlobalParameter.Rf_star] as fmCalculationVariableParameter;
            var Qgi = variables[fmGlobalParameter.Qgi] as fmCalculationVariableParameter;
            var Qg = variables[fmGlobalParameter.Qg] as fmCalculationVariableParameter;
            var vg = variables[fmGlobalParameter.vg] as fmCalculationVariableParameter;
            var Mfd = variables[fmGlobalParameter.Mfd] as fmCalculationVariableParameter;
            var Vfd = variables[fmGlobalParameter.Vfd] as fmCalculationVariableParameter;
            var Mlcd = variables[fmGlobalParameter.Mlcd] as fmCalculationVariableParameter;
            var Vlcd = variables[fmGlobalParameter.Vlcd] as fmCalculationVariableParameter;
            var Mcd = variables[fmGlobalParameter.Mcd] as fmCalculationVariableParameter;
            var Vcd = variables[fmGlobalParameter.Vcd] as fmCalculationVariableParameter;
            var rho_bulk = variables[fmGlobalParameter.rho_bulk] as fmCalculationVariableParameter;
            var Qmfid = variables[fmGlobalParameter.Qmfid] as fmCalculationVariableParameter;
            var Qfid = variables[fmGlobalParameter.Qfid] as fmCalculationVariableParameter;
            var Qmcd = variables[fmGlobalParameter.Qmcd] as fmCalculationVariableParameter;
            var Qcd = variables[fmGlobalParameter.Qcd] as fmCalculationVariableParameter;
            var qmfid = variables[fmGlobalParameter.qmfid] as fmCalculationVariableParameter;
            var qfid = variables[fmGlobalParameter.qfid] as fmCalculationVariableParameter;
            var qmcd = variables[fmGlobalParameter.qmcd] as fmCalculationVariableParameter;
            var qcd = variables[fmGlobalParameter.qcd] as fmCalculationVariableParameter;

            var hc = variables[fmGlobalParameter.hc] as fmCalculationConstantParameter;
            var eps = variables[fmGlobalParameter.eps] as fmCalculationConstantParameter;
            var epsd = variables[fmGlobalParameter.eps_d] as fmCalculationConstantParameter;

            hcd.value = fmDeliquoringEquations.Eval_hcd_from_hcf_epsf_epsd(hc.value, eps.value, epsd.value);
        }
    }
}
