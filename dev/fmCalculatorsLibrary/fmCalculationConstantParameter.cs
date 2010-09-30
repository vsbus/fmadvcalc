using fmCalculationLibrary;

namespace fmCalculatorsLibrary
{
    public class fmCalculationConstantParameter : fmCalculationBaseParameter
    {
        public fmCalculationConstantParameter(fmGlobalParameter globalParameter)
            : base(globalParameter)
        {
        }

        public fmCalculationConstantParameter(fmGlobalParameter globalParameter, fmValue value)
            : base (globalParameter, value)
        {
        }
    }
}
