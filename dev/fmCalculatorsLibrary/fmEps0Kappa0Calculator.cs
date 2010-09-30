using fmCalculationLibrary;
using System.Collections.Generic;

namespace fmCalculatorsLibrary
{
    public class fmEps0Kappa0Calculator : fmBaseCalculator
    {
        public fmEps0Kappa0Calculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            // ReSharper disable InconsistentNaming
            var eps0 = variables[fmGlobalParameter.eps0] as fmCalculationVariableParameter;
            var kappa0 = variables[fmGlobalParameter.kappa0] as fmCalculationVariableParameter;
            var Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;

            // ReSharper disable PossibleNullReferenceException
            var local_eps = new fmCalculationVariableParameter(fmGlobalParameter.eps, eps0.value, eps0.isInputed);
            var local_kappa = new fmCalculationVariableParameter(fmGlobalParameter.kappa, kappa0.value, kappa0.isInputed);
            var parameterList = new List<fmCalculationBaseParameter> {local_eps, local_kappa, Cv};
            // ReSharper restore InconsistentNaming

            var epsKappaCalculator = new fmEpsKappaCalculator(parameterList);
            epsKappaCalculator.DoCalculations();
            eps0.value = local_eps.value;
            kappa0.value = local_kappa.value;
            // ReSharper restore PossibleNullReferenceException
        }
    }
}
