using fmCalculationLibrary;
using fmCalculationLibrary.Equations;
using System.Collections.Generic;

namespace fmCalculatorsLibrary
{
    public class fmEps0Kappa0Calculator : fmBaseCalculator
    {
        public fmEps0Kappa0Calculator(List<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            fmCalculationVariableParameter eps0 = variables[fmGlobalParameter.eps0] as fmCalculationVariableParameter;
            fmCalculationVariableParameter kappa0 = variables[fmGlobalParameter.kappa0] as fmCalculationVariableParameter;
            fmCalculationConstantParameter Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;

            fmCalculationVariableParameter local_eps = new fmCalculationVariableParameter(fmGlobalParameter.eps, eps0.value, eps0.isInputed);
            fmCalculationVariableParameter local_kappa = new fmCalculationVariableParameter(fmGlobalParameter.kappa, kappa0.value, kappa0.isInputed);
            List<fmCalculationBaseParameter> parameterList = new List<fmCalculationBaseParameter>();
            parameterList.Add(local_eps);
            parameterList.Add(local_kappa);
            parameterList.Add(Cv);

            fmEpsKappaCalculator epsKappaCalculator = new fmEpsKappaCalculator(parameterList);
            epsKappaCalculator.DoCalculations();
            eps0.value = local_eps.value;
            kappa0.value = local_kappa.value;
        }
    }
}
