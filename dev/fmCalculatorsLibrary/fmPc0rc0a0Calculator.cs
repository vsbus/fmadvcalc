using fmCalculationLibrary;
using System.Collections.Generic;

namespace fmCalculatorsLibrary
{
    public class fmPc0Rc0A0Calculator : fmBaseCalculator
    {
        public fmPc0Rc0A0Calculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            // ReSharper disable InconsistentNaming
            var Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationVariableParameter;
            var rc0 = variables[fmGlobalParameter.rc0] as fmCalculationVariableParameter;
            var a0 = variables[fmGlobalParameter.a0] as fmCalculationVariableParameter;
            var eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            var rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;

            // ReSharper disable PossibleNullReferenceException
            var local_Pc = new fmCalculationVariableParameter(fmGlobalParameter.Pc, Pc0.value, Pc0.isInputed);
            var local_rc = new fmCalculationVariableParameter(fmGlobalParameter.rc, rc0.value, rc0.isInputed);
            var local_a = new fmCalculationVariableParameter(fmGlobalParameter.a, a0.value, a0.isInputed);
            var local_eps = new fmCalculationConstantParameter(fmGlobalParameter.eps, eps0.value);
            var local_rho_s = new fmCalculationConstantParameter(fmGlobalParameter.rho_s, rho_s.value);
            // ReSharper restore InconsistentNaming
            var parameterList = new List<fmCalculationBaseParameter>
                                    {
                                        local_Pc,
                                        local_rc,
                                        local_a,
                                        local_eps,
                                        local_rho_s
                                    };

            var pcrcaCalculator = new fmPcrcaCalculator(parameterList);
            pcrcaCalculator.DoCalculations();

            Pc0.value = local_Pc.value;
            rc0.value = local_rc.value;
            a0.value = local_a.value;
            eps0.value = local_eps.value;
            rho_s.value = local_rho_s.value;
            // ReSharper restore PossibleNullReferenceException
        }
    }
}
