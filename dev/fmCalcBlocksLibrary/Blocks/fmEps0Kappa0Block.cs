using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculatorsLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmEps0Kappa0Block : fmBaseBlock
    {
        // ReSharper disable InconsistentNaming
        private readonly fmBlockVariableParameter eps0;
        private readonly fmBlockVariableParameter kappa0;
        private readonly fmBlockConstantParameter Cv;

        private readonly fmBlockParameterGroup eps_kappa_group = new fmBlockParameterGroup();

        public fmValue eps_Value
        {
            get { return eps0.value; }
            set { eps0.value = value; }
        }
        public fmValue kappa_Value
        {
            get { return kappa0.value; }
            set { kappa0.value = value; }
        }
        public fmValue Cv_Value
        {
            get { return Cv.value; }
            set { Cv.value = value; }
        }
        // ReSharper restore InconsistentNaming

        override public void DoCalculations()
        {
            var eps0Kappa0Calculator = new fmEps0Kappa0Calculator(AllParameters);
            eps0Kappa0Calculator.DoCalculations();
        }

        // ReSharper disable InconsistentNaming
        public fmEps0Kappa0Block(
            DataGridViewCell eps_Cell,
            DataGridViewCell kappa_Cell)
        // ReSharper restore InconsistentNaming
        {
            AddParameter(ref eps0, fmGlobalParameter.eps0, eps_Cell, true);
            AddParameter(ref kappa0, fmGlobalParameter.kappa0, kappa_Cell, false);
            AddConstantParameter(ref Cv, fmGlobalParameter.Cv);

            eps0.group = eps_kappa_group;
            kappa0.group = eps_kappa_group;

            processOnChange = true;
        }
        public fmEps0Kappa0Block() : this(null, null) { }
    }
}