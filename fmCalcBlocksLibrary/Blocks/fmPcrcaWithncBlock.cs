using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmPcrcaWithncBlock : fmPcrcaBlock
    {
        private fmBlockParameter nc;

        public fmValue nc_Value
        {
            get { return nc.value; }
            set { nc.value = value; }
        }

        public fmPcrcaWithncBlock(
            DataGridViewCell Pc_Cell,
            DataGridViewCell rc_Cell,
            DataGridViewCell a_Cell,
            DataGridViewCell nc_Cell)
            : base(Pc_Cell, rc_Cell, a_Cell)
        {
            AddParameter(ref nc, fmGlobalParameter.nc, nc_Cell, true);
        }
    }
}