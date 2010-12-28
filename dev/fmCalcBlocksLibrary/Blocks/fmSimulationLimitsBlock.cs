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
        private readonly fmBlockLimitsParameter tc;
        private readonly fmBlockLimitsParameter hc;

        private readonly fmBlockParameterGroup tc_hc_group = new fmBlockParameterGroup(Color.FromArgb(238, 218, 238));

        public fmValue A_min_value
        {
            get { return A.pMin.value; }
            set { A.pMin.value = value; }
        }
        public fmValue tc_min_value
        {
            get { return tc.pMin.value; }
            set { tc.pMin.value = value; }
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
        public fmValue tc_max_value
        {
            get { return tc.pMax.value; }
            set { tc.pMax.value = value; }
        }
        public fmValue hc_max_value
        {
            get { return hc.pMax.value; }
            set { hc.pMax.value = value; }
        }

        // ReSharper disable InconsistentNaming
        public fmSimulationLimitsBlock(
            DataGridViewCell A_min_Cell, DataGridViewCell A_max_Cell,
            DataGridViewCell tc_min_Cell, DataGridViewCell tc_max_Cell,
            DataGridViewCell hc_min_Cell, DataGridViewCell hc_max_Cell)
        // ReSharper restore InconsistentNaming
        {
            AddParameter(ref A, fmGlobalParameter.A, A_min_Cell, A_max_Cell, true);
            AddParameter(ref tc, fmGlobalParameter.tc, tc_min_Cell, tc_max_Cell, true);
            AddParameter(ref hc, fmGlobalParameter.hc, hc_min_Cell, hc_max_Cell, false);

            tc.group = tc_hc_group;
            hc.group = tc_hc_group;

            UpdateCellsBackColor();

            processOnChange = true;
        }
    }
}
