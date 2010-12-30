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
        private readonly fmBlockLimitsParameter Dp;
        private readonly fmBlockLimitsParameter sf;
        private readonly fmBlockLimitsParameter tc;
        private readonly fmBlockLimitsParameter n;
        private readonly fmBlockLimitsParameter hc;

        private readonly fmBlockParameterGroup tc_n_hc_group = new fmBlockParameterGroup(Color.FromArgb(238, 218, 238), true);

        public fmValue A_min_value
        {
            get { return A.pMin.value; }
            set { A.pMin.value = value; }
        }
        public fmValue Dp_min_value
        {
            get { return Dp.pMin.value; }
            set { Dp.pMin.value = value; }
        }
        public fmValue sf_min_value
        {
            get { return sf.pMin.value; }
            set { sf.pMin.value = value; }
        }
        public fmValue tc_min_value
        {
            get { return tc.pMin.value; }
            set { tc.pMin.value = value; }
        }
        public fmValue n_min_value
        {
            get { return n.pMin.value; }
            set { n.pMin.value = value; }
        }
        public fmValue hc_min_value
        {
            get { return hc.pMin.value; }
            set { hc.pMin.value = value; }
        }
        public fmValue A_max_value
        {
            get { return A.pMax.value; }
            set { A.pMax.value = value; }
        }
        public fmValue Dp_max_value
        {
            get { return Dp.pMax.value; }
            set { Dp.pMax.value = value; }
        }
        public fmValue sf_max_value
        {
            get { return sf.pMax.value; }
            set { sf.pMax.value = value; }
        }
        public fmValue tc_max_value
        {
            get { return tc.pMax.value; }
            set { tc.pMax.value = value; }
        }
        public fmValue n_max_value
        {
            get { return n.pMax.value; }
            set { n.pMax.value = value; }
        }
        public fmValue hc_max_value
        {
            get { return hc.pMax.value; }
            set { hc.pMax.value = value; }
        }

        // ReSharper disable InconsistentNaming
        public fmSimulationLimitsBlock(
            DataGridViewCell A_min_Cell, DataGridViewCell A_max_Cell,
            DataGridViewCell Dp_min_Cell, DataGridViewCell Dp_max_Cell,
            DataGridViewCell sf_min_Cell, DataGridViewCell sf_max_Cell,
            DataGridViewCell tc_min_Cell, DataGridViewCell tc_max_Cell,
            DataGridViewCell n_min_Cell, DataGridViewCell n_max_Cell,
            DataGridViewCell hc_min_Cell, DataGridViewCell hc_max_Cell)
        // ReSharper restore InconsistentNaming
        {
            AddParameter(ref A, fmGlobalParameter.A, A_min_Cell, A_max_Cell, true);
            AddParameter(ref Dp, fmGlobalParameter.Dp, Dp_min_Cell, Dp_max_Cell, true);
            AddParameter(ref sf, fmGlobalParameter.sf, sf_min_Cell, sf_max_Cell, true);
            AddParameter(ref tc, fmGlobalParameter.tc, tc_min_Cell, tc_max_Cell, true);
            AddParameter(ref n, fmGlobalParameter.n, n_min_Cell, n_max_Cell, true);
            AddParameter(ref hc, fmGlobalParameter.hc, hc_min_Cell, hc_max_Cell, false);

            tc.group = tc_n_hc_group;
            n.group = tc_n_hc_group;
            hc.group = tc_n_hc_group;

            UpdateCellsBackColor();

            processOnChange = true;
        }
    }
}
