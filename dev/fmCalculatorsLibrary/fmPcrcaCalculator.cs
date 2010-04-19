using fmCalculationLibrary;
using fmCalculationLibrary.Equations;
using System;
using System.Collections.Generic;

namespace fmCalculatorsLibrary
{
    public class fmPcrcaCalculator : fmBaseCalculator
    {
        public fmPcrcaCalculator(List<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            fmCalculationVariableParameter Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter rc = variables[fmGlobalParameter.rc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter a = variables[fmGlobalParameter.a] as fmCalculationVariableParameter;
            fmCalculationConstantParameter eps = variables[fmGlobalParameter.eps] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;

            if (Pc.isInputed)
            {
                rc.value = PcrcaEquations.Eval_rc_From_Pc(Pc.value);
                a.value = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);
            }
            else if (rc.isInputed)
            {
                Pc.value = PcrcaEquations.Eval_Pc_From_rc(rc.value);
                a.value = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);
            }
            else if (a.isInputed)
            {
                Pc.value = PcrcaEquations.Eval_Pc_From_a_eps_rho_s(a.value, eps.value, rho_s.value);
                rc.value = PcrcaEquations.Eval_rc_From_Pc(Pc.value);
            }
            else 
                throw new Exception("One of Pc, rc or a must be inputed");
        }
    }
}
