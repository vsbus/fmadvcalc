using System;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmEpsKappaBlock : fmBaseBlock
    {
        private fmBlockParameter eps, kappa;
        private fmValue Cv_value;

        private fmBlockParameterGroup eps_kappa_group = new fmBlockParameterGroup();

        public fmValue eps_Value
        {
            get { return eps.value; }
            set { eps.value = value; }
        }
        public fmValue kappa_Value
        {
            get { return kappa.value; }
            set { kappa.value = value; }
        }
        public fmValue Cv_Value
        {
            get { return Cv_value; }
            set { Cv_value = value; }
        }
        
        override public void DoCalculations()
        {
            fmCalculatorsLibrary.fmEpsKappaCalculator.CalculationOptions calculationOption;
            if (eps.isInputed)
            {
                calculationOption = fmCalculatorsLibrary.fmEpsKappaCalculator.CalculationOptions.EPS_IS_INPUT;
            }
            else if (kappa.isInputed)
            {
                calculationOption = fmCalculatorsLibrary.fmEpsKappaCalculator.CalculationOptions.KAPPA_IS_INPUT;
            }
            else
            {
                throw new Exception("not eps neigther kappa are isInputted");
            }

            fmCalculatorsLibrary.fmEpsKappaCalculator.Process(calculationOption,
                                                              ref eps.value,
                                                              ref kappa.value,
                                                              Cv_value);
        }
       
        public fmEpsKappaBlock(
            DataGridViewCell eps_Cell,
            DataGridViewCell kappa_Cell)
        {
            AddParameter(ref eps, fmGlobalParameter.eps, eps_Cell, true);
            AddParameter(ref kappa, fmGlobalParameter.kappa, kappa_Cell, false);

            eps.group = eps_kappa_group;
            kappa.group = eps_kappa_group;

            processOnChange = true;
        }
    }
}