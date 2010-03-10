using System.Windows.Forms;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary.BlockParameter
{
    public class fmBlockConstantParameter
    {
        public fmGlobalParameter globalParameter;
        public fmValue value;
        public fmBlockConstantParameter(fmGlobalParameter globalParameter)
        {
            this.globalParameter = globalParameter;
        }
    }
}