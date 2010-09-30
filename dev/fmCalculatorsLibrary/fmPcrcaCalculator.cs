using fmCalculationLibrary;
using fmCalculationLibrary.Equations;
using System;
using System.Collections.Generic;

namespace fmCalculatorsLibrary
{
    public class fmPcrcaCalculator : fmBaseCalculator
    {
        public fmPcrcaCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            // ReSharper disable InconsistentNaming
            var Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
            var rc = variables[fmGlobalParameter.rc] as fmCalculationVariableParameter;
            var a = variables[fmGlobalParameter.a] as fmCalculationVariableParameter;
            var eps = variables[fmGlobalParameter.eps] as fmCalculationConstantParameter;
            var rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
            // ReSharper restore InconsistentNaming

            // ReSharper disable PossibleNullReferenceException
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
            // ReSharper restore PossibleNullReferenceException
        }
    }
}
