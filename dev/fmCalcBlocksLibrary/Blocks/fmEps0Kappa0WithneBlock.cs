using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmEps0Kappa0WithneBlock : fmEps0Kappa0Block
    {
        private fmBlockVariableParameter ne;

        public fmValue ne_Value
        {
            get { return ne.value; }
            set { ne.value = value; }
        }

        public fmEps0Kappa0WithneBlock(
            DataGridViewCell eps0_Cell,
            DataGridViewCell kappa0_Cell,
            DataGridViewCell ne_Cell)
            : base(eps0_Cell, kappa0_Cell)
        {
            AddParameter(ref ne, fmGlobalParameter.ne, ne_Cell, true);
        }
    }
}