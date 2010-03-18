using fmCalculationLibrary;
using fmCalculationLibrary.Equations;
using System;
using System.Collections.Generic;

namespace fmCalculatorsLibrary
{
    public class fmPc0rc0a0Calculator : fmBaseCalculator
    {
        public fmPc0rc0a0Calculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            fmCalculationVariableParameter Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationVariableParameter;
            fmCalculationVariableParameter rc0 = variables[fmGlobalParameter.rc0] as fmCalculationVariableParameter;
            fmCalculationVariableParameter a0 = variables[fmGlobalParameter.a0] as fmCalculationVariableParameter;
            fmCalculationConstantParameter eps = variables[fmGlobalParameter.eps] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;

            fmCalculationVariableParameter local_Pc = new fmCalculationVariableParameter(fmGlobalParameter.Pc, Pc0.value, Pc0.isInputed);
            fmCalculationVariableParameter local_rc = new fmCalculationVariableParameter(fmGlobalParameter.rc, rc0.value, rc0.isInputed);
            fmCalculationVariableParameter local_a = new fmCalculationVariableParameter(fmGlobalParameter.a, a0.value, a0.isInputed);
            fmCalculationConstantParameter local_eps = new fmCalculationConstantParameter(fmGlobalParameter.eps, eps.value);
            fmCalculationConstantParameter local_rho_s = new fmCalculationConstantParameter(fmGlobalParameter.rho_s, rho_s.value);
            List<fmCalculationBaseParameter> parameterList = new List<fmCalculationBaseParameter>();
            parameterList.Add(local_Pc);
            parameterList.Add(local_rc);
            parameterList.Add(local_a);
            parameterList.Add(local_eps);
            parameterList.Add(local_rho_s);

            fmPcrcaCalculator PcrcaCalculator = new fmPcrcaCalculator(parameterList);
            PcrcaCalculator.DoCalculations();

            Pc0.value = local_Pc.value;
            rc0.value = local_rc.value;
            a0.value = local_a.value;
            eps.value = local_eps.value;
            rho_s.value = local_rho_s.value;
        }
    }
}
