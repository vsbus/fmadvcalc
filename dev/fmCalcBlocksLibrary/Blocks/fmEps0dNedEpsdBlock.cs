using System;
using System.Collections.Generic;
using System.Text;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using System.Windows.Forms;
using fmCalculatorsLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmEps0dNedEpsdBlock : fmBaseBlock
    {
        // ReSharper disable InconsistentNaming
        private readonly fmBlockVariableParameter eps0d;
        private readonly fmBlockVariableParameter ned;
        private readonly fmBlockVariableParameter epsd;
        private readonly fmBlockVariableParameter Dpd;

        private readonly fmBlockParameterGroup Dpd_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup eps0d_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup epsd_ned_group = new fmBlockParameterGroup();

        public fmValue eps0d_Value
        {
            get { return eps0d.value; }
            set { eps0d.value = value; }
        }
        public fmValue ned_Value
        {
            get { return ned.value; }
            set { ned.value = value; }
        }
        public fmValue epsd_Value
        {
            get { return epsd.value; }
            set { epsd.value = value; }
        }
        public fmValue Dp_Value
        {
            get { return Dpd.value; }
            set { Dpd.value = value; }
        }
        // ReSharper restore InconsistentNaming

        override public void DoCalculations()
        {
            var eps0dNedEpsdCalculator = new fmEps0dNedEpsdCalculator(AllParameters);
            eps0dNedEpsdCalculator.DoCalculations();
        }

        // ReSharper disable InconsistentNaming
        public fmEps0dNedEpsdBlock(
            DataGridViewCell Dpd_Cell,
            DataGridViewCell eps0d_Cell,
            DataGridViewCell ned_Cell,
            DataGridViewCell epsd_Cell)
        // ReSharper restore InconsistentNaming
        {
            AddParameter(ref Dpd, fmGlobalParameter.Dp_d, Dpd_Cell, true);
            AddParameter(ref eps0d, fmGlobalParameter.eps0_d, eps0d_Cell, true);
            AddParameter(ref ned, fmGlobalParameter.ne_d, ned_Cell, true);
            AddParameter(ref epsd, fmGlobalParameter.eps_d, epsd_Cell, false);

            Dpd.group = Dpd_group;

            eps0d.group = eps0d_group;

            ned.group = epsd_ned_group;
            epsd.group = epsd_ned_group;

            processOnChange = true;
        }
        public fmEps0dNedEpsdBlock() : this(null, null, null, null) { }
    }
}
