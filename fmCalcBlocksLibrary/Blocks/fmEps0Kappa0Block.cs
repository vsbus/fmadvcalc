using System;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;
using fmCalculatorsLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmEps0Kappa0Block : fmBaseBlock
    {
        private fmBlockVariableParameter eps0, kappa0;
        private fmBlockConstantParameter Cv;

        private fmBlockParameterGroup eps_kappa_group = new fmBlockParameterGroup();

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

        override public void DoCalculations()
        {
            fmEps0Kappa0Calculator eps0Kappa0Calculator = new fmEps0Kappa0Calculator(AllParameters);
            eps0Kappa0Calculator.DoCalculations();
        }

        public fmEps0Kappa0Block(
            DataGridViewCell eps_Cell,
            DataGridViewCell kappa_Cell)
        {
            AddParameter(ref eps0, fmGlobalParameter.eps0, eps_Cell, true);
            AddParameter(ref kappa0, fmGlobalParameter.kappa0, kappa_Cell, false);
            AddConstantParameter(ref Cv, fmGlobalParameter.Cv);

            eps0.group = eps_kappa_group;
            kappa0.group = eps_kappa_group;

            processOnChange = true;
        }
    }
}