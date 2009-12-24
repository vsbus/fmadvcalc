using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmEpsKappaWithneBlock : fmEpsKappaBlock
    {
        private fmBlockParameter ne;

        public fmValue ne_Value
        {
            get { return ne.value; }
            set { ne.value = value; }
        }

        public fmEpsKappaWithneBlock(
            DataGridViewCell eps_Cell,
            DataGridViewCell kappa_Cell,
            DataGridViewCell ne_Cell)
            : base(eps_Cell, kappa_Cell)
        {
            AddParameter(ref ne, fmGlobalParameter.ne, ne_Cell, true);
        }
    }
}