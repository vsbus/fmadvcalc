using fmCalculationLibrary;

namespace fmCalculatorsLibrary
{
    public class fmCalculationVariableParameter : fmCalculationConstantParameter
    {
        public bool isInputed;

        public fmCalculationVariableParameter(fmGlobalParameter globalParameter)
            : base(globalParameter)
        {
        }

        public fmCalculationVariableParameter(fmGlobalParameter globalParameter, bool isInputed)
            : base(globalParameter)
        {
            this.isInputed = isInputed;
        }

        public fmCalculationVariableParameter(fmGlobalParameter globalParameter, fmValue value, bool isInputed)
            : base(globalParameter, value)
        {
            this.isInputed = isInputed;
        }
    }
}
