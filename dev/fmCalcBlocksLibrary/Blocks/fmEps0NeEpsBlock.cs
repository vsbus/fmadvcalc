using System;
using System.Collections.Generic;
using System.Text;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using System.Windows.Forms;
using fmCalculatorsLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmEps0NeEpsBlock : fmBaseBlock
    {
        // ReSharper disable InconsistentNaming
        private readonly fmBlockVariableParameter eps0;
        private readonly fmBlockVariableParameter ne;
        private readonly fmBlockVariableParameter eps;
        private readonly fmBlockVariableParameter Dp;

        private readonly fmBlockParameterGroup Dp_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup eps0_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup eps_ne_group = new fmBlockParameterGroup();

        public fmValue eps0_Value
        {
            get { return eps0.value; }
            set { eps0.value = value; }
        }
        public fmValue ne_Value
        {
            get { return ne.value; }
            set { ne.value = value; }
        }
        public fmValue eps_Value
        {
            get { return eps.value; }
            set { eps.value = value; }
        }
        public fmValue Dp_Value
        {
            get { return Dp.value; }
            set { Dp.value = value; }
        }
        // ReSharper restore InconsistentNaming

        override public void DoCalculations()
        {
            var eps0NeEpsCalculator = new fmEps0NeEpsCalculator(AllParameters);
            eps0NeEpsCalculator.DoCalculations();
        }

        // ReSharper disable InconsistentNaming
        public fmEps0NeEpsBlock(
            DataGridViewCell Dp_Cell,
            DataGridViewCell eps0_Cell,
            DataGridViewCell ne_Cell,
            DataGridViewCell eps_Cell)
        // ReSharper restore InconsistentNaming
        {
            AddParameter(ref Dp, fmGlobalParameter.Dp, Dp_Cell, true);
            AddParameter(ref eps0, fmGlobalParameter.eps0, eps0_Cell, true);
            AddParameter(ref ne, fmGlobalParameter.ne, ne_Cell, true);
            AddParameter(ref eps, fmGlobalParameter.eps, eps_Cell, true);

            Dp.group = Dp_group;

            eps0.group = eps0_group;

            ne.group = eps_ne_group;
            eps.group = eps_ne_group;

            processOnChange = true;
        }
        public fmEps0NeEpsBlock() : this(null, null, null, null) { }
    }
}
