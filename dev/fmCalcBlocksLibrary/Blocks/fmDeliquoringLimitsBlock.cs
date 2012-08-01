using System.Drawing;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmDeliquoringLimitsBlock : fmBaseLimitsBlock
    {
        private readonly fmBlockLimitsParameter Dpd;
        
        private readonly fmBlockLimitsParameter hcd;

        private readonly fmBlockLimitsParameter sd;
        private readonly fmBlockLimitsParameter td;
        private readonly fmBlockLimitsParameter K;
        
        private readonly fmBlockParameterGroup sd_td_K_group = new fmBlockParameterGroup(Color.FromArgb(238, 218, 238), true);

        public fmDeliquoringLimitsBlock(
            DataGridViewCell Dpd_min_Cell, DataGridViewCell Dpd_max_Cell,
            DataGridViewCell hcd_min_Cell, DataGridViewCell hcd_max_Cell,
            DataGridViewCell sd_min_Cell, DataGridViewCell sd_max_Cell,
            DataGridViewCell td_min_Cell, DataGridViewCell td_max_Cell,
            DataGridViewCell K_min_Cell, DataGridViewCell K_max_Cell)
        {
            AddParameter(ref Dpd, fmGlobalParameter.Dp_d, Dpd_min_Cell, Dpd_max_Cell, true);
            
            AddParameter(ref hcd, fmGlobalParameter.hcd, hcd_min_Cell, hcd_max_Cell, true);

            AddParameter(ref sd, fmGlobalParameter.sd, sd_min_Cell, sd_max_Cell, true);
            AddParameter(ref td, fmGlobalParameter.td, td_min_Cell, td_max_Cell, false);
            AddParameter(ref K, fmGlobalParameter.K, K_min_Cell, K_max_Cell, false);
            
            sd.group = sd_td_K_group;
            td.group = sd_td_K_group;
            K.group = sd_td_K_group;

            UpdateCellsBackColor();

            processOnChange = true;
        }
    }
}
