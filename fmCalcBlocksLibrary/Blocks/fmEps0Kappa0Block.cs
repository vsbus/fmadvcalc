using System;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmEps0Kappa0Block : fmBaseBlock
    {
        private fmBlockParameter eps0, kappa0;
        //private fmValue Cv_value;
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
            fmCalculatorsLibrary.fmEpsKappaCalculator.CalculationOptions calculationOption;
            if (eps0.isInputed)
            {
                calculationOption = fmCalculatorsLibrary.fmEpsKappaCalculator.CalculationOptions.EPS_IS_INPUT;
            }
            else if (kappa0.isInputed)
            {
                calculationOption = fmCalculatorsLibrary.fmEpsKappaCalculator.CalculationOptions.KAPPA_IS_INPUT;
            }
            else
            {
                throw new Exception("not eps neigther kappa are isInputted");
            }

            fmCalculatorsLibrary.fmEpsKappaCalculator.Process(calculationOption,
                                                              ref eps0.value,
                                                              ref kappa0.value,
                                                              Cv.value);
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