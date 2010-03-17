using System.Windows.Forms;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

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