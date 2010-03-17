using System;
using System.Collections.Generic;
using System.Text;
using fmCalculationLibrary;

namespace fmCalculatorsLibrary
{
    public class fmCalculationVariableParameter : fmCalculationBaseParameter
    {
        public bool isInputed;

        public fmCalculationVariableParameter(fmGlobalParameter globalParameter)
            : base(globalParameter)
        {
        }

        public fmCalculationVariableParameter(fmGlobalParameter globalParameter, fmValue value, bool isInputed)
            : base(globalParameter, value)
        {
            this.isInputed = isInputed;
        }
    }
}
