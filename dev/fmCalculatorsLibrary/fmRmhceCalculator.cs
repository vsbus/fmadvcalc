using fmCalculationLibrary;
using fmCalculationLibrary.Equations;
using System.Collections.Generic;
using System;

namespace fmCalculatorsLibrary
{
    public class fmRmhceCalculator : fmBaseCalculator
    {
        public fmRmhceCalculator(List<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            fmCalculationVariableParameter Rm = variables[fmGlobalParameter.Rm] as fmCalculationVariableParameter;
            fmCalculationVariableParameter hce = variables[fmGlobalParameter.hce] as fmCalculationVariableParameter;
            fmCalculationConstantParameter Pc = variables[fmGlobalParameter.Pc] as fmCalculationConstantParameter;

            if (Rm.isInputed)
                hce.value = RmhceEquations.Eval_hce_From_Rm_Pc(Rm.value, Pc.value);
            else if (hce.isInputed)
                Rm.value = RmhceEquations.Eval_Rm_From_hce_Pc(hce.value, Pc.value);
            else
                throw new Exception("Rm or hce must be inputed");
        }
    }
}
