using System;
using System.ComponentModel;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Controls;
using fmCalculationLibrary;
using System.Collections.Generic;
using System.Drawing;
using fmCalculatorsLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public enum CalculationOption
    {
        // Standart -- In this case we have always the area A as input 
        // and the (Qsus, Qmsus, Qms) as calculated.
        [Description("1: A, Dp, (sf/tr), (n/tc)")]
        Standart1,
        
        [Description("2: A, Dp, (sf/tr), tf")]
        Standart2,
        
        [Description("3: A, Dp, (n/tc/tr), tf")]
        Standart3,
        
        [Description("4: A, (hc/Vf/Mf), (sf/tr), (n/tc)")]
        Standart4,
        
        //Standart5,  // A, hc, (sf/tr), tf           -- input
        //Standart6,  // A, hc, (n/tc/tr), tf       -- input
        
        [Description("7: A, Dp, (hc/Vf/Mf), (sf/tr)")]
        Standart7,
        
        [Description("8: A, Dp, hc, (n/tc/tr)")]
        Standart8,
        
        // Design -- In this case we have always the (Qsus, Qmsus, Qms) as input 
        // and the filter area A is calculated 
        [Description("1: Q, Dp, hc, (n/tc/tr)")]
        Design1,
        //Design2,    // Q, Dp, hc, (sf/tr)           -- input 
        //Design3,    // Q, sf, (n/tc/tr), hc       -- input 

        // Optimization -- In this case we have always the filter 
        // area A and the (Qsus, Qmsus, Qms) as input
        [Description("1: A, Q, Dp, (sf/tr)")]
        Optimization1
        //Optimization2,  // A, Q, hc, (sf/tr)           -- input
        //Optimization3   // A, Q, (n/tc), (sf/tr)       -- input
    }
    
    static public class CalculationOptionHelper
    {
        public static List<fmGlobalParameter> GetParametersListThatCanBeInput(CalculationOption calculationOption)
        {
            List<fmGlobalParameter> result = new List<fmGlobalParameter>();
            switch (calculationOption)
            {
                //[Description("1: A, Dp, (sf/tr), (n/tc)")]
                case CalculationOption.Standart1:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.sf);
                    result.Add(fmGlobalParameter.tr);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    break;

                //[Description("2: A, Dp, (sf/tr), tf")]
                case CalculationOption.Standart2:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.sf);
                    result.Add(fmGlobalParameter.tr);
                    result.Add(fmGlobalParameter.tf);
                    break;

                //[Description("3: A, Dp, (n/tc/tr), tf")]
                case CalculationOption.Standart3:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    result.Add(fmGlobalParameter.tr);
                    result.Add(fmGlobalParameter.tf);
                    break;
        
                //[Description("4: A, (hc/Vf/Mf), (sf/tr), (n/tc)")]
                case CalculationOption.Standart4:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.Vf);
                    result.Add(fmGlobalParameter.Mf);
                    result.Add(fmGlobalParameter.sf);
                    result.Add(fmGlobalParameter.tr);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    break;
        
                //[Description("7: A, Dp, (hc/Vf/Mf), (sf/tr)")]
                case CalculationOption.Standart7:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.Vf);
                    result.Add(fmGlobalParameter.Mf);
                    result.Add(fmGlobalParameter.sf);
                    result.Add(fmGlobalParameter.tr);
                    break;
        
                //[Description("8: A, Dp, hc, (n/tc/tr)")]
                case CalculationOption.Standart8:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    result.Add(fmGlobalParameter.tr);
                    break;
        
                //[Description("1: Q, Dp, hc, (n/tc/tr)")]
                case CalculationOption.Design1:
                    result.Add(fmGlobalParameter.Qms);
                    result.Add(fmGlobalParameter.Qmsus);
                    result.Add(fmGlobalParameter.Qsus);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    result.Add(fmGlobalParameter.tr);
                    break;
        
                //[Description("1: A, Q, Dp, (sf/tr)")]
                case CalculationOption.Optimization1:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Qms);
                    result.Add(fmGlobalParameter.Qmsus);
                    result.Add(fmGlobalParameter.Qsus);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.sf);
                    result.Add(fmGlobalParameter.tr);
                    break;
            }

            return result;
        }
    }

    public class fmFilterMachiningBlock : fmBaseBlock
    {
        public readonly fmCalculationOptionView calculationOptionView;

        private readonly fmBlockParameter A;
        private readonly fmBlockParameter Dp;
        private readonly fmBlockParameter sf;
        private readonly fmBlockParameter n;
        private readonly fmBlockParameter tc;
        private readonly fmBlockParameter tf;
        private readonly fmBlockParameter tr;
        private readonly fmBlockParameter hc;
        private readonly fmBlockParameter Mf;
        private readonly fmBlockParameter Vf;
        private readonly fmBlockParameter Msus;
        private readonly fmBlockParameter Vsus;
        private readonly fmBlockParameter Ms;
        private readonly fmBlockParameter Qsus;
        private readonly fmBlockParameter Qmsus;
        private readonly fmBlockParameter Qms;
        private readonly fmBlockParameter eps;
        private readonly fmBlockParameter kappa;
        private readonly fmBlockParameter Pc;
        private readonly fmBlockParameter rc;
        private readonly fmBlockParameter a;

        /*
         * 220 200 230
         * 240 230 180
         * 180 230 230
         * 240 180 230
         * 180 240 150
         *  
         * 190 200 240
         * 250 230 150
         * 230 240 190
         * 250 240 190
         * 190 240 240
         * 
         * 160 250 250
         * 210 190 240
         * 220 240 170
         * 240 200 190
         * 250 220 150
         *
         * 259 210 130
         * 150 250 180
         */

        private readonly fmBlockParameterGroup A_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup Dp_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup sf_tr_group = new fmBlockParameterGroup(Color.FromArgb(190, 200, 240));
        private readonly fmBlockParameterGroup n_tc_group = new fmBlockParameterGroup(Color.FromArgb(250, 230, 150));
        private readonly fmBlockParameterGroup n_tc_tr_group = new fmBlockParameterGroup(Color.FromArgb(230, 240, 190));
        private readonly fmBlockParameterGroup tf_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup hc_MVf_group = new fmBlockParameterGroup(Color.FromArgb(250, 190, 220));
        private readonly fmBlockParameterGroup hc_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup Msus_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup Vsus_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup Ms_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup Q_group = new fmBlockParameterGroup(Color.FromArgb(190, 240, 240));
        //private readonly fmBlockParameterGroup eps_group = new fmBlockParameterGroup();
        //private readonly fmBlockParameterGroup kappa_group = new fmBlockParameterGroup();
        //private readonly fmBlockParameterGroup Pc_group = new fmBlockParameterGroup();
        //private readonly fmBlockParameterGroup rc_group = new fmBlockParameterGroup();
        //private readonly fmBlockParameterGroup a_group = new fmBlockParameterGroup();

        private fmValue hce_value;
        
        private fmValue Pc0_value;
        private fmValue nc_value;
        
        private fmValue eps0_value;
        private fmValue kappa0_value;
        private fmValue ne_value;
        
        private fmValue etaf_value;
        private fmValue rho_f_value;
        private fmValue rho_s_value; 
        private fmValue rho_sus_value;
        private fmValue Cm_value;
        private fmValue Cv_value;

        private CalculationOption calculationOption;

        public fmValue A_Value
        {
            get { return A.value; }
            set { A.value = value; }
        }
        public fmValue Dp_Value
        {
            get { return Dp.value; }
            set { Dp.value = value; }
        }
        public fmValue sf_Value
        {
            get { return sf.value; }
            set { sf.value = value; }
        }
        public fmValue n_Value
        {
            get { return n.value; }
            set { n.value = value; }
        }
        public fmValue tc_Value
        {
            get { return tc.value; }
            set { tc.value = value; }
        }
        public fmValue tf_Value
        {
            get { return tf.value; }
            set { tf.value = value; }
        }
        public fmValue tr_Value
        {
            get { return tr.value; }
            set { tr.value = value; }
        }
        public fmValue hc_Value
        {
            get { return hc.value; }
            set { hc.value = value; }
        }
        public fmValue Mf_Value
        {
            get { return Mf.value; }
            set { Mf.value = value; }
        }
        public fmValue Vf_Value
        {
            get { return Vf.value; }
            set { Vf.value = value; }
        }
        public fmValue Msus_Value
        {
            get { return Msus.value; }
            set { Msus.value = value; }
        }
        public fmValue Vsus_Value
        {
            get { return Vsus.value; }
            set { Vsus.value = value; }
        }
        public fmValue Ms_Value
        {
            get { return Ms.value; }
            set { Ms.value = value; }
        }
        public fmValue Qsus_Value
        {
            get { return Qsus.value; }
            set { Qsus.value = value; }
        }
        public fmValue Qmsus_Value
        {
            get { return Qmsus.value; }
            set { Qmsus.value = value; }
        }
        public fmValue Qms_Value
        {
            get { return Qms.value; }
            set { Qms.value = value; }
        }
        public fmValue hce_Value
        {
            get { return hce_value; }
            set { hce_value = value; }
        }
        public fmValue Pc0_Value
        {
            get { return Pc0_value; }
            set { Pc0_value = value; }
        }
        public fmValue eps0_Value
        {
            get { return eps0_value; }
            set { eps0_value = value; }
        }
        public fmValue nc_Value
        {
            get { return nc_value; }
            set { nc_value = value; }
        }
        public fmValue ne_Value
        {
            get { return ne_value; }
            set { ne_value = value; }
        }
        public fmValue kappa0_Value
        {
            get { return kappa0_value; }
            set { kappa0_value = value; }
        }
        public fmValue etaf_Value
        {
            get { return etaf_value; }
            set { etaf_value = value; }
        }
        public fmValue rho_f_Value
        {
            get { return rho_f_value; }
            set { rho_f_value = value; }
        }
        public fmValue rho_s_Value
        {
            get { return rho_s_value; }
            set { rho_s_value = value; }
        }
        public fmValue rho_sus_Value
        {
            get { return rho_sus_value; }
            set { rho_sus_value = value; }
        }
        public fmValue Cm_Value
        {
            get { return Cm_value; }
            set { Cm_value = value; }
        }
        public fmValue Cv_Value
        {
            get { return Cv_value; }
            set { Cv_value = value; }
        }
        public CalculationOption CalculationOption
        {
            get { return calculationOption; }
            set { calculationOption = value; }
        }

        override public void DoCalculations()
        {
            fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions calcOption = GetCalculatorCalculationOption();

            fmCalculatorsLibrary.fmFilterMachiningCalculator.Process(calcOption,
                                                                     ref A.value,
                                                                     ref Dp.value,
                                                                     ref sf.value,
                                                                     ref n.value,
                                                                     ref tc.value,
                                                                     ref tf.value,
                                                                     ref tr.value,
                                                                     ref hc.value,
                                                                     ref Qsus.value,
                                                                     ref Qmsus.value,
                                                                     ref Qms.value,
                                                                     ref Vsus.value,
                                                                     ref Mf.value,
                                                                     ref Vf.value,
                                                                     ref Ms.value,
                                                                     ref Msus.value,
                                                                     ref eps.value,
                                                                     ref kappa.value,
                                                                     ref Pc.value,
                                                                     ref rc.value,
                                                                     ref a.value,
                                                                     eps0_value,
                                                                     kappa0_value,
                                                                     Pc0_value,
                                                                     etaf_value,
                                                                     rho_f_value,
                                                                     rho_s_value,
                                                                     rho_sus_value,
                                                                     Cv_value,
                                                                     Cm_value,
                                                                     ne_value,
                                                                     nc_value,
                                                                     hce_value);
        }

        private fmFilterMachiningCalculator.CalculationOptions GetCalculatorCalculationOption()
        {
            List<fmBlockParameter> inputParameters = GetInputedParameters();

            fmFilterMachiningCalculator.CalculationOptions calcOption;

            calcOption = GetCalculatorCalculationOptionStandart();
            if (calcOption != fmFilterMachiningCalculator.CalculationOptions.UNDEFINED)
            {
                return calcOption;
            }

            calcOption = GetCalculatorCalculationOptionDesign();
            if (calcOption != fmFilterMachiningCalculator.CalculationOptions.UNDEFINED)
            {
                return calcOption;
            }

            calcOption = GetCalculatorCalculationOptionOptimization();
            if (calcOption != fmFilterMachiningCalculator.CalculationOptions.UNDEFINED)
            {
                return calcOption;
            }

            throw new Exception("Not processed combination of inputs"); 
        }

        private fmFilterMachiningCalculator.CalculationOptions GetCalculatorCalculationOptionOptimization()
        {
            List<fmBlockParameter> inputParameters = GetInputedParameters();

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Qms, Dp, sf }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.OPTIMIZATION1_A_Qms_Dp_sf_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Qsus, Dp, sf }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.OPTIMIZATION1_A_Qsus_Dp_sf_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Qmsus, Dp, sf }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.OPTIMIZATION1_A_Qmsus_Dp_sf_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Qms, Dp, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.OPTIMIZATION1_A_Qms_Dp_tr_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Qsus, Dp, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.OPTIMIZATION1_A_Qsus_Dp_tr_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Qmsus, Dp, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.OPTIMIZATION1_A_Qmsus_Dp_tr_INPUT;
            }

            return fmFilterMachiningCalculator.CalculationOptions.UNDEFINED;
        }

        private fmFilterMachiningCalculator.CalculationOptions GetCalculatorCalculationOptionDesign()
        {
            List<fmBlockParameter> inputParameters = GetInputedParameters();

            if (IsSameLists(inputParameters, new fmBlockParameter[] { Qms, Dp, hc, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qms_Dp_hc_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { Qsus, Dp, hc, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qsus_Dp_hc_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { Qmsus, Dp, hc, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qmsus_Dp_hc_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { Qms, Dp, hc, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qms_Dp_hc_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { Qsus, Dp, hc, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qsus_Dp_hc_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { Qmsus, Dp, hc, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qmsus_Dp_hc_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { Qms, Dp, hc, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qms_Dp_hc_tr_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { Qsus, Dp, hc, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qsus_Dp_hc_tr_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { Qmsus, Dp, hc, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qmsus_Dp_hc_tr_INPUT;
            }

            return fmFilterMachiningCalculator.CalculationOptions.UNDEFINED;
        }

        private fmFilterMachiningCalculator.CalculationOptions GetCalculatorCalculationOptionStandart()
        {
            fmFilterMachiningCalculator.CalculationOptions calcOption;

            calcOption = GetCalculatorCalculationOptionStandart1();
            if (calcOption != fmFilterMachiningCalculator.CalculationOptions.UNDEFINED)
            {
                return calcOption;
            }

            calcOption = GetCalculatorCalculationOptionStandart2();
            if (calcOption != fmFilterMachiningCalculator.CalculationOptions.UNDEFINED)
            {
                return calcOption;
            }

            calcOption = GetCalculatorCalculationOptionStandart3();
            if (calcOption != fmFilterMachiningCalculator.CalculationOptions.UNDEFINED)
            {
                return calcOption;
            }

            calcOption = GetCalculatorCalculationOptionStandart4();
            if (calcOption != fmFilterMachiningCalculator.CalculationOptions.UNDEFINED)
            {
                return calcOption;
            }

            calcOption = GetCalculatorCalculationOptionStandart7();
            if (calcOption != fmFilterMachiningCalculator.CalculationOptions.UNDEFINED)
            {
                return calcOption;
            }

            calcOption = GetCalculatorCalculationOptionStandart8();
            if (calcOption != fmFilterMachiningCalculator.CalculationOptions.UNDEFINED)
            {
                return calcOption;
            }

            return fmFilterMachiningCalculator.CalculationOptions.UNDEFINED;
        }

        private fmFilterMachiningCalculator.CalculationOptions GetCalculatorCalculationOptionStandart8()
        {
            List<fmBlockParameter> inputParameters = GetInputedParameters();

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, hc, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_hc_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, hc, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_hc_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, hc, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_hc_tr_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Vf, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Vf_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Vf, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Vf_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Vf, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Vf_tr_INPUT;
            }

            return fmFilterMachiningCalculator.CalculationOptions.UNDEFINED;
        }

        private fmFilterMachiningCalculator.CalculationOptions GetCalculatorCalculationOptionStandart7()
        {
            List<fmBlockParameter> inputParameters = GetInputedParameters();

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, hc, sf }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART7_A_Dp_hc_sf_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, hc, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART7_A_Dp_hc_tr_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Vf, sf }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART7_A_Dp_Vf_sf_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Vf, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART7_A_Dp_Vf_tr_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Mf, sf }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART7_A_Dp_Mf_sf_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Mf, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART7_A_Dp_Mf_tr_INPUT;
            }

            return fmFilterMachiningCalculator.CalculationOptions.UNDEFINED;
        }

        private fmFilterMachiningCalculator.CalculationOptions GetCalculatorCalculationOptionStandart4()
        {
            List<fmBlockParameter> inputParameters = GetInputedParameters();

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, hc, sf, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_hc_sf_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, hc, sf, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_hc_sf_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, hc, tr, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_hc_tr_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, hc, tr, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_hc_tr_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Vf, sf, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Vf_sf_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Vf, sf, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Vf_sf_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Vf, tr, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Vf_tr_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Vf, tr, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Vf_tr_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Mf, sf, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Mf_sf_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Mf, sf, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Mf_sf_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Mf, tr, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Mf_tr_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Mf, tr, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Mf_tr_tc_INPUT;
            }

            return fmFilterMachiningCalculator.CalculationOptions.UNDEFINED;
        }

        private fmFilterMachiningCalculator.CalculationOptions GetCalculatorCalculationOptionStandart3()
        {
            List<fmBlockParameter> inputParameters = GetInputedParameters();

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, n, tf }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART3_A_Dp_n_tf_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, tc, tf }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART3_A_Dp_tc_tf_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, tr, tf }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART3_A_Dp_tr_tf_INPUT;
            }

            return fmFilterMachiningCalculator.CalculationOptions.UNDEFINED;
        }

        private fmFilterMachiningCalculator.CalculationOptions GetCalculatorCalculationOptionStandart2()
        {
            List<fmBlockParameter> inputParameters = GetInputedParameters();

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, sf, tf }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART2_A_Dp_sf_tf_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, tr, tf }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART2_A_Dp_tr_tf_INPUT;
            }

            return fmFilterMachiningCalculator.CalculationOptions.UNDEFINED;
        }

        private fmFilterMachiningCalculator.CalculationOptions GetCalculatorCalculationOptionStandart1()
        {
            List<fmBlockParameter> inputParameters = GetInputedParameters();

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, sf, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART1_A_Dp_sf_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, tr, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART1_A_Dp_tr_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, sf, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART1_A_Dp_sf_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, tr, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART1_A_Dp_tr_tc_INPUT;
            }

            return fmFilterMachiningCalculator.CalculationOptions.UNDEFINED;
        }

        private bool IsSameLists(List<fmBlockParameter> a, fmBlockParameter [] b)
        {
            return IsSameLists(a, GetParametersListFromArray(b));
        }

        private bool IsSameLists(List<fmBlockParameter> a, List<fmBlockParameter> b)
        {
            if (a.Count != b.Count)
            {
                return false;
            }

            for (int i = 0; i < a.Count; ++i)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        private List<fmBlockParameter> GetParametersListFromArray(fmBlockParameter[] array)
        {
            List<fmBlockParameter> list = new List<fmBlockParameter>();
            foreach (fmBlockParameter p in array)
            {
                list.Add(p);
            }

            List<fmBlockParameter> result = new List<fmBlockParameter>();
            foreach (fmBlockParameter p in parameters)
            {
                if (list.Contains(p))
                {
                    result.Add(p);
                }
            }

            return result;
        }

        private List<fmBlockParameter> GetInputedParameters()
        {
            List<fmBlockParameter> result = new List<fmBlockParameter>();
            foreach (fmBlockParameter p in parameters)
            {
                if (p.isInputed)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        private CalculationOption GetBlockCalculationOption()
        {
            return calculationOptionView.GetSelectedOption();
        }

        public void UpdateCellsBackColor()
        {
            foreach (fmBlockParameter p in parameters)
            {
                if (p.cell != null)
                {
                    Color color = p.group == null
                                     ? Color.White
                                     : p.group.color;
                    p.cell.Style.BackColor = color;
                }
            }
        }

        public fmFilterMachiningBlock(
            fmCalculationOptionView calculationOptionView)
            : this(calculationOptionView, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                                           null, null, null, null, null, null, null)
        {
        }
        
        public fmFilterMachiningBlock(
            fmCalculationOptionView calculationOptionView,
            DataGridViewCell A_Cell,
            DataGridViewCell Dp_Cell,
            DataGridViewCell sf_Cell,
            DataGridViewCell n_Cell,
            DataGridViewCell tc_Cell,
            DataGridViewCell tf_Cell,
            DataGridViewCell tr_Cell,
            DataGridViewCell hc_Cell,
            DataGridViewCell Mf_Cell,
            DataGridViewCell Vf_Cell,
            DataGridViewCell Msus_Cell,
            DataGridViewCell Vsus_Cell,
            DataGridViewCell Ms_Cell,
            DataGridViewCell Qsus_Cell,
            DataGridViewCell Qmsus_Cell,
            DataGridViewCell Qms_Cell,
            DataGridViewCell eps_Cell,
            DataGridViewCell kappa_Cell,
            DataGridViewCell Pc_Cell,
            DataGridViewCell rc_Cell,
            DataGridViewCell a_Cell)
        {
            AssignCalculationOptionView(ref this.calculationOptionView, calculationOptionView);

            AddParameter(ref A, fmGlobalParameter.A, A_Cell, true);
            AddParameter(ref Dp, fmGlobalParameter.Dp, Dp_Cell, true);
            AddParameter(ref sf, fmGlobalParameter.sf, sf_Cell, true);
            AddParameter(ref n, fmGlobalParameter.n, n_Cell, true);
            AddParameter(ref tc, fmGlobalParameter.tc, tc_Cell, false);
            AddParameter(ref tf, fmGlobalParameter.tf, tf_Cell, false);
            AddParameter(ref tr, fmGlobalParameter.tr, tr_Cell, false);
            AddParameter(ref hc, fmGlobalParameter.hc, hc_Cell, false);
            AddParameter(ref Mf, fmGlobalParameter.Mf, Mf_Cell, false);
            AddParameter(ref Vf, fmGlobalParameter.Vf, Vf_Cell, false);
            AddParameter(ref Msus, fmGlobalParameter.Msus, Msus_Cell, false);
            AddParameter(ref Vsus, fmGlobalParameter.Vsus, Vsus_Cell, false);
            AddParameter(ref Ms, fmGlobalParameter.Ms, Ms_Cell, false);
            AddParameter(ref Qsus, fmGlobalParameter.Qsus, Qsus_Cell, false);
            AddParameter(ref Qmsus, fmGlobalParameter.Qmsus, Qmsus_Cell, false);
            AddParameter(ref Qms, fmGlobalParameter.Qms, Qms_Cell, false);
            AddParameter(ref eps, fmGlobalParameter.eps, eps_Cell, false);
            AddParameter(ref kappa, fmGlobalParameter.kappa, kappa_Cell, false);
            AddParameter(ref Pc, fmGlobalParameter.Pc, Pc_Cell, false);
            AddParameter(ref rc, fmGlobalParameter.rc, rc_Cell, false);
            AddParameter(ref a, fmGlobalParameter.a, a_Cell, false);

            processOnChange = true;
            CalculationOptionViewCheckChanged(null, new EventArgs());
        }

        private void CalculationOptionViewCheckChanged(object sender, EventArgs e)
        {
            if (processOnChange && calculationOptionView != null)
            {
                UpdateGroups();

                CalculationOption calcOption = calculationOptionView.GetSelectedOption();
                List<fmGlobalParameter> inputedParameters = CalculationOptionHelper.GetParametersListThatCanBeInput(calcOption);
                Dictionary<fmBlockParameterGroup, bool> groupUsed = new Dictionary<fmBlockParameterGroup, bool>();

                foreach (fmBlockParameter parameter in parameters)
                {
                    if (parameter.group != null)
                    {
                        groupUsed[parameter.group] = false;
                    }
                }

                foreach (fmBlockParameter parameter in parameters)
                {
                    bool found = inputedParameters.Contains(parameter.globalParameter);
                    bool notUsedGroup = parameter.group == null ? true : !groupUsed[parameter.group];
                    
                    parameter.isInputed = found && notUsedGroup;
                    
                    if (parameter.group != null)
                    {
                        groupUsed[parameter.group] = true;
                    }
                    
                    if (parameter.cell != null)
                    {
                        parameter.cell.ReadOnly = !found;
                    }
                }

                UpdateCellsBackColor();
                ReWriteParameters();
            }
        }

        fmBlockParameterGroup WhatGroupOfParameterWithCalcOption(fmBlockParameter parameter, CalculationOption calcOption)
        {
            Dictionary< CalculationOption, Dictionary<fmBlockParameter, fmBlockParameterGroup> > table = new Dictionary<CalculationOption, Dictionary<fmBlockParameter, fmBlockParameterGroup>>();
            foreach (CalculationOption option in Enum.GetValues(typeof(CalculationOption)))
            {
                table[option] = new Dictionary<fmBlockParameter, fmBlockParameterGroup>();
            }

            SetGroupsOfStandart1(table[CalculationOption.Standart1]);
            SetGroupsOfStandart2(table[CalculationOption.Standart2]);
            SetGroupsOfStandart3(table[CalculationOption.Standart3]);
            SetGroupsOfStandart4(table[CalculationOption.Standart4]);
            SetGroupsOfStandart7(table[CalculationOption.Standart7]);
            SetGroupsOfStandart8(table[CalculationOption.Standart8]);
            SetGroupsOfDesign1(table[CalculationOption.Design1]);
            SetGroupsOfOptimization1(table[CalculationOption.Optimization1]);

            return table[calcOption][parameter];
        }

        private void SetGroupsOfOptimization1(Dictionary<fmBlockParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockParameter p in parameters)
                table[p] = null;

            //[Description("1: A, Q, Dp, (sf/tr)")]
            table[A] = A_group;
            table[Qms] = Q_group;
            table[Qmsus] = Q_group;
            table[Qsus] = Q_group;
            table[sf] = sf_tr_group;
            table[tr] = sf_tr_group;
        }

        private void SetGroupsOfDesign1(Dictionary<fmBlockParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockParameter p in parameters)
                table[p] = null;

            //[Description("1: Q, Dp, hc, (n/tc/tr)")]
            table[Qms] = Q_group;
            table[Qmsus] = Q_group;
            table[Qsus] = Q_group;
            table[Dp] = Dp_group;
            table[hc] = hc_group;
            table[n] = n_tc_tr_group;
            table[tc] = n_tc_tr_group;
            table[tr] = n_tc_tr_group;
        }

        private void SetGroupsOfStandart8(Dictionary<fmBlockParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockParameter p in parameters)
                table[p] = null;

            //[Description("8: A, Dp, hc, (n/tc/tr)")]
            table[A] = A_group;
            table[Dp] = Dp_group;
            table[hc] = hc_group;
            table[n] = n_tc_tr_group;
            table[tc] = n_tc_tr_group;
            table[tr] = n_tc_tr_group;
        }

        private void SetGroupsOfStandart7(Dictionary<fmBlockParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockParameter p in parameters)
                table[p] = null;

            //[Description("7: A, Dp, (hc/Vf/Mf), (sf/tr)")]
            table[A] = A_group;
            table[hc] = hc_MVf_group;
            table[Vf] = hc_MVf_group;
            table[Mf] = hc_MVf_group;
            table[sf] = sf_tr_group;
            table[tr] = sf_tr_group;
        }

        private void SetGroupsOfStandart4(Dictionary<fmBlockParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockParameter p in parameters)
                table[p] = null;

            //[Description("4: A, (hc/Vf/Mf), (sf/tr), (n/tc)")]
            table[A] = A_group;
            table[hc] = hc_MVf_group;
            table[Vf] = hc_MVf_group;
            table[Mf] = hc_MVf_group;
            table[sf] = sf_tr_group;
            table[tr] = sf_tr_group;
            table[n] = n_tc_group;
            table[tc] = n_tc_group;
        }

        private void SetGroupsOfStandart3(Dictionary<fmBlockParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockParameter p in parameters)
                table[p] = null;

            //[Description("3: A, Dp, (n/tc/tr), tf")]
            table[A] = A_group;
            table[Dp] = Dp_group;
            table[n] = n_tc_tr_group;
            table[tc] = n_tc_tr_group;
            table[tr] = n_tc_tr_group;
            table[tf] = tf_group;
        }

        private void SetGroupsOfStandart2(Dictionary<fmBlockParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockParameter p in parameters)
                table[p] = null;

            //[Description("2: A, Dp, (sf/tr), tf")]
            table[A] = A_group;
            table[Dp] = Dp_group;
            table[sf] = sf_tr_group;
            table[tr] = sf_tr_group;
            table[tf] = tf_group;
        }

        private void SetGroupsOfStandart1(Dictionary<fmBlockParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockParameter p in parameters)
                table[p] = null;

            //[Description("1: A, Dp, (sf/tr), (n/tc)")]
            table[A] = A_group;
            table[Dp] = Dp_group;
            table[sf] = sf_tr_group;
            table[tr] = sf_tr_group; 
            table[n] = n_tc_group;
            table[tc] = n_tc_group;
        }

        private void UpdateGroups()
        {
            CalculationOption calcOption = GetBlockCalculationOption();
            foreach (fmBlockParameter p in parameters)
            {
                p.group = WhatGroupOfParameterWithCalcOption(p, calcOption);
            }
        }
        
        private void AssignCalculationOptionView(ref fmCalculationOptionView localCalculationOptionView,
                                                 fmCalculationOptionView globalCalculationOptionView)
        {
            localCalculationOptionView = globalCalculationOptionView;
            if (localCalculationOptionView != null)
            {
                localCalculationOptionView.CheckedChangedForUpdatingCalculationOptions += CalculationOptionViewCheckChanged;
            }
        }

        public void CopyParameters(fmFilterMachiningBlock filterMachiningBlock)
        {
            if (filterMachiningBlock != null)
            {
                for (int i = 0; i < parameters.Count; ++i)
                {
                    parameters[i].value = filterMachiningBlock.parameters[i].value;
                }
            }
        }

        public void CopyConstants(fmFilterMachiningBlock filterMachiningBlock)
        {
            if (filterMachiningBlock != null)
            {
                hce_value = filterMachiningBlock.hce_value;

                Pc0_value = filterMachiningBlock.Pc0_value;
                nc_value = filterMachiningBlock.nc_value;

                eps0_value = filterMachiningBlock.eps0_value;
                kappa0_value = filterMachiningBlock.kappa0_value;
                ne_value = filterMachiningBlock.ne_value;

                etaf_value = filterMachiningBlock.etaf_value;
                rho_f_value = filterMachiningBlock.rho_f_value;
                rho_s_value = filterMachiningBlock.rho_s_value;
                rho_sus_value = filterMachiningBlock.rho_sus_value;
                Cm_value = filterMachiningBlock.Cm_value;
                Cv_value = filterMachiningBlock.Cv_value;
            }
        }

        public void CopyValues(fmFilterMachiningBlock filterMachiningBlock)
        {
            CopyParameters(filterMachiningBlock);
            CopyConstants(filterMachiningBlock);
        }
    }
}
