using System;
using System.Collections.Generic;
using System.Text;
using fmCalcBlocksLibrary.BlockParameter;
using System.Drawing;
using fmCalculationLibrary;
using System.Windows.Forms;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmSimulationLimitsBlock : fmBaseLimitsBlock
    {
        private readonly fmBlockLimitsParameter A;
        private readonly fmBlockLimitsParameter d0;

        private readonly fmBlockLimitsParameter Dp;
        
        private readonly fmBlockLimitsParameter hc;
        private readonly fmBlockLimitsParameter n;
        private readonly fmBlockLimitsParameter tc;

        private readonly fmBlockLimitsParameter tf;
        private readonly fmBlockLimitsParameter tr;
        private readonly fmBlockLimitsParameter sf;
        private readonly fmBlockLimitsParameter sr;

        private readonly fmBlockParameterGroup tc_n_hc_group = new fmBlockParameterGroup(Color.FromArgb(238, 218, 238), true);
        private readonly fmBlockParameterGroup tr_sf_sr_group = new fmBlockParameterGroup(Color.FromArgb(238, 238, 218), true);
        
        // ReSharper disable InconsistentNaming
        public fmSimulationLimitsBlock(
            DataGridViewCell A_min_Cell, DataGridViewCell A_max_Cell,
            DataGridViewCell d0_min_Cell, DataGridViewCell d0_max_Cell,
            DataGridViewCell Dp_min_Cell, DataGridViewCell Dp_max_Cell,
            DataGridViewCell sf_min_Cell, DataGridViewCell sf_max_Cell,
            DataGridViewCell sr_min_Cell, DataGridViewCell sr_max_Cell,
            DataGridViewCell tc_min_Cell, DataGridViewCell tc_max_Cell,
            DataGridViewCell n_min_Cell, DataGridViewCell n_max_Cell,
            DataGridViewCell hc_min_Cell, DataGridViewCell hc_max_Cell,
            DataGridViewCell tf_min_Cell, DataGridViewCell tf_max_Cell,
            DataGridViewCell tr_min_Cell, DataGridViewCell tr_max_Cell)
        // ReSharper restore InconsistentNaming
        {
            AddParameter(ref A, fmGlobalParameter.A, A_min_Cell, A_max_Cell, true);
            AddParameter(ref d0, fmGlobalParameter.d0, d0_min_Cell, d0_max_Cell, true);

            AddParameter(ref Dp, fmGlobalParameter.Dp, Dp_min_Cell, Dp_max_Cell, true);
            
            AddParameter(ref tc, fmGlobalParameter.tc, tc_min_Cell, tc_max_Cell, true);
            AddParameter(ref n, fmGlobalParameter.n, n_min_Cell, n_max_Cell, false);
            AddParameter(ref hc, fmGlobalParameter.hc, hc_min_Cell, hc_max_Cell, false);
            AddParameter(ref tf, fmGlobalParameter.tf, tf_min_Cell, tf_max_Cell, false);

            AddParameter(ref sf, fmGlobalParameter.sf, sf_min_Cell, sf_max_Cell, true);
            AddParameter(ref sr, fmGlobalParameter.sr, sr_min_Cell, sr_max_Cell, false);
            AddParameter(ref tr, fmGlobalParameter.tr, tr_min_Cell, tr_max_Cell, false);

            tc.group = tc_n_hc_group;
            n.group = tc_n_hc_group;
            hc.group = tc_n_hc_group;
            tf.group = tc_n_hc_group;

            tr.group = tr_sf_sr_group;
            sf.group = tr_sf_sr_group;
            sr.group = tr_sf_sr_group;

            UpdateCellsBackColor();

            processOnChange = true;
        }
    }
}
