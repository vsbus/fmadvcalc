using fmCalculationLibrary;
using fmCalculationLibrary.Equations;
using System.Collections.Generic;
using System;

namespace fmCalculatorsLibrary
{
    public class fmRmhceCalculator : fmBaseCalculator
    {
        public fmRmhceCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            // ReSharper disable InconsistentNaming
            var Rm = variables[fmGlobalParameter.Rm] as fmCalculationVariableParameter;
            var hce = variables[fmGlobalParameter.hce0] as fmCalculationVariableParameter;
            var Pc = variables[fmGlobalParameter.Pc] as fmCalculationConstantParameter;
            // ReSharper restore InconsistentNaming

            // ReSharper disable PossibleNullReferenceException
            if (Rm.isInputed)
                hce.value = fmRmhceEquations.Eval_hce_From_Rm_Pc(Rm.value, Pc.value);
            else if (hce.isInputed)
                Rm.value = fmRmhceEquations.Eval_Rm_From_hce_Pc(hce.value, Pc.value);
            else
                throw new Exception("Rm or hce0 must be inputed");
            // ReSharper restore PossibleNullReferenceException
        }
    }
}
