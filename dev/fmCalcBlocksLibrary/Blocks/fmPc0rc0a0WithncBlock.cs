using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmPc0rc0a0WithncBlock : fmPc0rc0a0Block
    {
        private fmBlockVariableParameter nc;

        public fmValue nc_Value
        {
            get { return nc.value; }
            set { nc.value = value; }
        }

        public fmPc0rc0a0WithncBlock(
            DataGridViewCell Pc0_Cell,
            DataGridViewCell rc0_Cell,
            DataGridViewCell a0_Cell,
            DataGridViewCell nc_Cell)
            : base(Pc0_Cell, rc0_Cell, a0_Cell)
        {
            AddParameter(ref nc, fmGlobalParameter.nc, nc_Cell, true);
        }
    }
}