using fmCalculationLibrary;
using System.Collections.Generic;

namespace fmCalculatorsLibrary
{
    public class fmRm0HceCalculator : fmBaseCalculator
    {
        public fmRm0HceCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            // ReSharper disable InconsistentNaming
            var Rm0 = variables[fmGlobalParameter.Rm0] as fmCalculationVariableParameter;
            var hce = variables[fmGlobalParameter.hce0] as fmCalculationVariableParameter;
            var Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
            // ReSharper restore InconsistentNaming

            // ReSharper disable PossibleNullReferenceException
            var localRm = new fmCalculationVariableParameter(fmGlobalParameter.Rm, Rm0.value, Rm0.isInputed);
            var localhce = new fmCalculationVariableParameter(fmGlobalParameter.hce0, hce.value, hce.isInputed);
            var localPc = new fmCalculationConstantParameter(fmGlobalParameter.Pc, Pc0.value);
            var parameterList = new List<fmCalculationBaseParameter> {localRm, localhce, localPc};

            var rmHceCalculator = new fmRmhceCalculator(parameterList);
            rmHceCalculator.DoCalculations();

            Rm0.value = localRm.value;
            hce.value = localhce.value;
            Pc0.value = localPc.value;
            // ReSharper restore PossibleNullReferenceException
        }
    }
}
