using fmCalculationLibrary;
using fmCalculationLibrary.Equations;
using System.Collections.Generic;
using System;

namespace fmCalculatorsLibrary
{
    public class fmRm0hceCalculator : fmBaseCalculator
    {
        public fmRm0hceCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            fmCalculationVariableParameter Rm0 = variables[fmGlobalParameter.Rm0] as fmCalculationVariableParameter;
            fmCalculationVariableParameter hce = variables[fmGlobalParameter.hce] as fmCalculationVariableParameter;
            fmCalculationConstantParameter Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;

            fmCalculationVariableParameter localRm = new fmCalculationVariableParameter(fmGlobalParameter.Rm, Rm0.value, Rm0.isInputed);
            fmCalculationVariableParameter localhce = new fmCalculationVariableParameter(fmGlobalParameter.hce, hce.value, hce.isInputed);
            fmCalculationConstantParameter localPc = new fmCalculationConstantParameter(fmGlobalParameter.Pc, Pc0.value);
            List<fmCalculationBaseParameter> parameterList = new List<fmCalculationBaseParameter>();
            parameterList.Add(localRm);
            parameterList.Add(localhce);
            parameterList.Add(localPc);
            
            fmRmhceCalculator RmHceCalculator = new fmRmhceCalculator(parameterList);
            RmHceCalculator.DoCalculations();

            Rm0.value = localRm.value;
            hce.value = localhce.value;
            Pc0.value = localPc.value;
        }
    }
}
