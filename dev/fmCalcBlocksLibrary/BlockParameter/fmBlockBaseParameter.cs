using fmCalculationLibrary;

namespace fmCalcBlocksLibrary.BlockParameter
{
    public class fmBlockBaseParameter
    {
        public fmGlobalParameter globalParameter;
        public fmValue value;
        public fmBlockBaseParameter(fmGlobalParameter globalParameter)
        {
            this.globalParameter = globalParameter;
        }
    }
}