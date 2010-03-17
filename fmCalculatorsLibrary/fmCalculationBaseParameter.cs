using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalculatorsLibrary
{
    public class fmCalculationBaseParameter
    {
        public fmGlobalParameter globalParameter;
        public fmValue value;

        public fmCalculationBaseParameter(fmGlobalParameter globalParameter)
        {
            this.globalParameter = globalParameter;
        }

        public fmCalculationBaseParameter(fmGlobalParameter globalParameter, fmValue value)
        {
            this.globalParameter = globalParameter;
            this.value = value;
        }
    }
}