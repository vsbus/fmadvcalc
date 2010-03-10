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
        
        [Description("4: A, (hc/Vf/Mf/Vsus/Msus/Ms), (sf/tr), (n/tc)")]
        Standart4,
        
        //Standart5,  // A, hc, (sf/tr), tf           -- input
        //Standart6,  // A, hc, (n/tc/tr), tf       -- input

        [Description("7: A, Dp, (hc/Vf/Mf/Vsus/Msus/Ms), (sf/tr)")]
        Standart7,

        [Description("8: A, Dp, (hc/Vf/Mf/Vsus/Msus/Ms), (n/tc/tr)")]
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
        
                //[Description("4: A, (hc/Vf/Mf/Vsus/Msus/Ms), (sf/tr), (n/tc)")]
                case CalculationOption.Standart4:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.Vf);
                    result.Add(fmGlobalParameter.Mf);
                    result.Add(fmGlobalParameter.Vsus);
                    result.Add(fmGlobalParameter.Msus);
                    result.Add(fmGlobalParameter.Ms);
                    result.Add(fmGlobalParameter.sf);
                    result.Add(fmGlobalParameter.tr);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    break;
        
                //[Description("7: A, Dp, (hc/Vf/Mf/Vsus/Msus/Ms), (sf/tr)")]
                case CalculationOption.Standart7:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.Vf);
                    result.Add(fmGlobalParameter.Mf);
                    result.Add(fmGlobalParameter.Vsus);
                    result.Add(fmGlobalParameter.Msus);
                    result.Add(fmGlobalParameter.Ms);
                    result.Add(fmGlobalParameter.sf);
                    result.Add(fmGlobalParameter.tr);
                    break;
        
                //[Description("8: A, Dp, (hc/Vf/Mf/Vsus/Msus/Ms), (n/tc/tr)")]
                case CalculationOption.Standart8:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.Vf);
                    result.Add(fmGlobalParameter.Mf);
                    result.Add(fmGlobalParameter.Vsus);
                    result.Add(fmGlobalParameter.Msus);
                    result.Add(fmGlobalParameter.Ms);
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
        private readonly fmBlockParameter hc_over_tf;
        private readonly fmBlockParameter dhc_over_dt;
        private readonly fmBlockParameter Mf;
        private readonly fmBlockParameter Vf;
        private readonly fmBlockParameter mf;
        private readonly fmBlockParameter vf;
        private readonly fmBlockParameter ms;
        private readonly fmBlockParameter vs;
        private readonly fmBlockParameter msus;
        private readonly fmBlockParameter vsus;
        private readonly fmBlockParameter mc;
        private readonly fmBlockParameter vc;
        private readonly fmBlockParameter Msus;
        private readonly fmBlockParameter Vsus;
        private readonly fmBlockParameter Vc;
        private readonly fmBlockParameter Mc;
        private readonly fmBlockParameter Ms;
        private readonly fmBlockParameter Vs;
        private readonly fmBlockParameter Qf;
        private readonly fmBlockParameter Qf_d;
        private readonly fmBlockParameter Qs;
        private readonly fmBlockParameter Qs_d;
        private readonly fmBlockParameter Qc;
        private readonly fmBlockParameter Qc_d;
        private readonly fmBlockParameter Qsus;
        private readonly fmBlockParameter Qsus_d;
        private readonly fmBlockParameter Qmsus;
        private readonly fmBlockParameter Qmsus_d;
        private readonly fmBlockParameter Qms;
        private readonly fmBlockParameter Qms_d;
        private readonly fmBlockParameter Qmf;
        private readonly fmBlockParameter Qmf_d;
        private readonly fmBlockParameter Qmc;
        private readonly fmBlockParameter Qmc_d;
        private readonly fmBlockParameter qf;
        private readonly fmBlockParameter qf_d;
        private readonly fmBlockParameter qs;
        private readonly fmBlockParameter qs_d;
        private readonly fmBlockParameter qc;
        private readonly fmBlockParameter qc_d;
        private readonly fmBlockParameter qsus;
        private readonly fmBlockParameter qsus_d;
        private readonly fmBlockParameter qmsus;
        private readonly fmBlockParameter qmsus_d;
        private readonly fmBlockParameter qms;
        private readonly fmBlockParameter qms_d;
        private readonly fmBlockParameter qmf;
        private readonly fmBlockParameter qmf_d;
        private readonly fmBlockParameter qmc;
        private readonly fmBlockParameter qmc_d;
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

        private readonly fmBlockParameterGroup A_group = new fmBlockParameterGroup(Color.FromArgb(150, 250, 180));
        private readonly fmBlockParameterGroup Dp_group = new fmBlockParameterGroup(Color.FromArgb(250, 210, 150));
        private readonly fmBlockParameterGroup sf_tr_group = new fmBlockParameterGroup(Color.FromArgb(190, 200, 240));
        private readonly fmBlockParameterGroup n_tc_group = new fmBlockParameterGroup(Color.FromArgb(250, 230, 150));
        private readonly fmBlockParameterGroup n_tc_tr_group = new fmBlockParameterGroup(Color.FromArgb(230, 240, 190));
        private readonly fmBlockParameterGroup tf_group = new fmBlockParameterGroup(Color.FromArgb(180, 230, 230));
        private readonly fmBlockParameterGroup hc_MV_group = new fmBlockParameterGroup(Color.FromArgb(250, 190, 220));
        private readonly fmBlockParameterGroup hc_group = new fmBlockParameterGroup(Color.FromArgb(250, 190, 220));
        //private readonly fmBlockParameterGroup Msus_group = new fmBlockParameterGroup();
        //private readonly fmBlockParameterGroup Vsus_group = new fmBlockParameterGroup();
        //private readonly fmBlockParameterGroup Ms_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup Q_group = new fmBlockParameterGroup(Color.FromArgb(190, 240, 240));
        //private readonly fmBlockParameterGroup eps_group = new fmBlockParameterGroup();
        //private readonly fmBlockParameterGroup kappa_group = new fmBlockParameterGroup();
        //private readonly fmBlockParameterGroup Pc_group = new fmBlockParameterGroup();
        //private readonly fmBlockParameterGroup rc_group = new fmBlockParameterGroup();
        //private readonly fmBlockParameterGroup a_group = new fmBlockParameterGroup();

        //private fmValue hce_value;
        
        //private fmValue Pc0_value;
        //private fmValue nc_value;
        
        //private fmValue eps0_value;
        //private fmValue kappa0_value;
        //private fmValue ne_value;
        
        //private fmValue etaf_value;
        //private fmValue rho_f_value;
        //private fmValue rho_s_value; 
        //private fmValue rho_sus_value;
        //private fmValue Cm_value;
        //private fmValue Cv_value;

        private fmBlockConstantParameter hce;

        private fmBlockConstantParameter Pc0;
        private fmBlockConstantParameter nc;

        private fmBlockConstantParameter eps0;
        private fmBlockConstantParameter kappa0;
        private fmBlockConstantParameter ne;

        private fmBlockConstantParameter etaf;
        private fmBlockConstantParameter rho_f;
        private fmBlockConstantParameter rho_s; 
        private fmBlockConstantParameter rho_sus;
        private fmBlockConstantParameter Cm;
        private fmBlockConstantParameter Cv;
        
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
        public fmValue hc_over_tf_Value
        {
            get { return hc_over_tf.value; }
            set { hc_over_tf.value = value; }
        }
        public fmValue dhc_over_dt_Value
        {
            get { return dhc_over_dt.value; }
            set { dhc_over_dt.value = value; }
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
        public fmValue mf_Value
        {
            get { return mf.value; }
            set { mf.value = value; }
        }
        public fmValue vf_Value
        {
            get { return vf.value; }
            set { vf.value = value; }
        }
        public fmValue ms_Value
        {
            get { return ms.value; }
            set { ms.value = value; }
        }
        public fmValue vs_Value
        {
            get { return vs.value; }
            set { vs.value = value; }
        }
        public fmValue msus_Value
        {
            get { return msus.value; }
            set { msus.value = value; }
        }
        public fmValue vsus_Value
        {
            get { return vsus.value; }
            set { vsus.value = value; }
        }
        public fmValue mc_Value
        {
            get { return mc.value; }
            set { mc.value = value; }
        }
        public fmValue vc_Value
        {
            get { return vc.value; }
            set { vc.value = value; }
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
        public fmValue Vc_Value
        {
            get { return Vc.value; }
            set { Vc.value = value; }
        }
        public fmValue Mc_Value
        {
            get { return Mc.value; }
            set { Mc.value = value; }
        }
        public fmValue Ms_Value
        {
            get { return Ms.value; }
            set { Ms.value = value; }
        }
        public fmValue Vs_Value
        {
            get { return Vs.value; }
            set { Vs.value = value; }
        }
        public fmValue Qf_Value
        {
            get { return Qf.value; }
            set { Qf.value = value; }
        }
        public fmValue Qf_d_Value
        {
            get { return Qf_d.value; }
            set { Qf_d.value = value; }
        }
        public fmValue Qs_Value
        {
            get { return Qs.value; }
            set { Qs.value = value; }
        }
        public fmValue Qs_d_Value
        {
            get { return Qs_d.value; }
            set { Qs_d.value = value; }
        }
        public fmValue Qc_Value
        {
            get { return Qc.value; }
            set { Qc.value = value; }
        }
        public fmValue Qc_d_Value
        {
            get { return Qc_d.value; }
            set { Qc_d.value = value; }
        }
        public fmValue Qsus_Value
        {
            get { return Qsus.value; }
            set { Qsus.value = value; }
        }
        public fmValue Qsus_d_Value
        {
            get { return Qsus_d.value; }
            set { Qsus_d.value = value; }
        }
        public fmValue Qmsus_Value
        {
            get { return Qmsus.value; }
            set { Qmsus.value = value; }
        }
        public fmValue Qmsus_d_Value
        {
            get { return Qmsus_d.value; }
            set { Qmsus_d.value = value; }
        }
        public fmValue Qms_Value
        {
            get { return Qms.value; }
            set { Qms.value = value; }
        }
        public fmValue Qms_d_Value
        {
            get { return Qms_d.value; }
            set { Qms_d.value = value; }
        }
        public fmValue Qmf_Value
        {
            get { return Qmf.value; }
            set { Qmf.value = value; }
        }
        public fmValue Qmf_d_Value
        {
            get { return Qmf_d.value; }
            set { Qmf_d.value = value; }
        }
        public fmValue Qmc_Value
        {
            get { return Qmc.value; }
            set { Qmc.value = value; }
        }
        public fmValue Qmc_d_Value
        {
            get { return Qmc_d.value; }
            set { Qmc_d.value = value; }
        }
        public fmValue qf_Value
        {
            get { return qf.value; }
            set { qf.value = value; }
        }
        public fmValue qf_d_Value
        {
            get { return qf_d.value; }
            set { qf_d.value = value; }
        }
        public fmValue qs_Value
        {
            get { return qs.value; }
            set { qs.value = value; }
        }
        public fmValue qs_d_Value
        {
            get { return qs_d.value; }
            set { qs_d.value = value; }
        }
        public fmValue qc_Value
        {
            get { return qc.value; }
            set { qc.value = value; }
        }
        public fmValue qc_d_Value
        {
            get { return qc_d.value; }
            set { qc_d.value = value; }
        }
        public fmValue qsus_Value
        {
            get { return qsus.value; }
            set { qsus.value = value; }
        }
        public fmValue qsus_d_Value
        {
            get { return qsus_d.value; }
            set { qsus_d.value = value; }
        }
        public fmValue qmsus_Value
        {
            get { return qmsus.value; }
            set { qmsus.value = value; }
        }
        public fmValue qmsus_d_Value
        {
            get { return qmsus_d.value; }
            set { qmsus_d.value = value; }
        }
        public fmValue qms_Value
        {
            get { return qms.value; }
            set { qms.value = value; }
        }
        public fmValue qms_d_Value
        {
            get { return qms_d.value; }
            set { qms_d.value = value; }
        }
        public fmValue qmf_Value
        {
            get { return qmf.value; }
            set { qmf.value = value; }
        }
        public fmValue qmf_d_Value
        {
            get { return qmf_d.value; }
            set { qmf_d.value = value; }
        }
        public fmValue qmc_Value
        {
            get { return qmc.value; }
            set { qmc.value = value; }
        }
        public fmValue qmc_d_Value
        {
            get { return qmc_d.value; }
            set { qmc_d.value = value; }
        }
        public fmValue hce_Value
        {
            get { return hce.value; }
            set { hce.value = value; }
        }
        public fmValue Pc0_Value
        {
            get { return Pc0.value; }
            set { Pc0.value = value; }
        }
       public fmValue eps0_Value
        {
            get { return eps0.value; }
            set { eps0.value = value; }
        }
        public fmValue nc_Value
        {
            get { return nc.value; }
            set { nc.value = value; }
        }
        public fmValue ne_Value
        {
            get { return ne.value; }
            set { ne.value = value; }
        }
        public fmValue kappa0_Value
        {
            get { return kappa0.value; }
            set { kappa0.value = value; }
        }
        public fmValue etaf_Value
        {
            get { return etaf.value; }
            set { etaf.value = value; }
        }
        public fmValue rho_f_Value
        {
            get { return rho_f.value; }
            set { rho_f.value = value; }
        }
        public fmValue rho_s_Value
        {
            get { return rho_s.value; }
            set { rho_s.value = value; }
        }
        public fmValue rho_sus_Value
        {
            get { return rho_sus.value; }
            set { rho_sus.value = value; }
        }
        public fmValue Cm_Value
        {
            get { return Cm.value; }
            set { Cm.value = value; }
        }
        public fmValue Cv_Value
        {
            get { return Cv.value; }
            set { Cv.value = value; }
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
                                                                     ref hc_over_tf.value,
                                                                     ref dhc_over_dt.value,
                                                                     ref hc.value,
                                                                     ref Qf.value,
                                                                     ref Qf_d.value,
                                                                     ref Qs.value,
                                                                     ref Qs_d.value,
                                                                     ref Qc.value,
                                                                     ref Qc_d.value,
                                                                     ref Qsus.value,
                                                                     ref Qsus_d.value,
                                                                     ref Qmsus.value,
                                                                     ref Qmsus_d.value,
                                                                     ref Qms.value,
                                                                     ref Qms_d.value,
                                                                     ref Qmf.value,
                                                                     ref Qmf_d.value,
                                                                     ref Qmc.value,
                                                                     ref Qmc_d.value,
                                                                     ref qf.value,
                                                                     ref qf_d.value,
                                                                     ref qs.value,
                                                                     ref qs_d.value,
                                                                     ref qc.value,
                                                                     ref qc_d.value,
                                                                     ref qsus.value,
                                                                     ref qsus_d.value,
                                                                     ref qmsus.value,
                                                                     ref qmsus_d.value,
                                                                     ref qms.value,
                                                                     ref qms_d.value,
                                                                     ref qmf.value,
                                                                     ref qmf_d.value,
                                                                     ref qmc.value,
                                                                     ref qmc_d.value,
                                                                     ref Vsus.value,
                                                                     ref Mf.value,
                                                                     ref Vf.value,
                                                                     ref mf.value,
                                                                     ref vf.value,
                                                                     ref ms.value,
                                                                     ref vs.value,
                                                                     ref msus.value,
                                                                     ref vsus.value,
                                                                     ref mc.value,
                                                                     ref vc.value,
                                                                     ref Vc.value,
                                                                     ref Mc.value,
                                                                     ref Ms.value,
                                                                     ref Vs.value,
                                                                     ref Msus.value,
                                                                     ref eps.value,
                                                                     ref kappa.value,
                                                                     ref Pc.value,
                                                                     ref rc.value,
                                                                     ref a.value,
                                                                     eps0.value,
                                                                     kappa0.value,
                                                                     Pc0.value,
                                                                     etaf.value,
                                                                     rho_f.value,
                                                                     rho_s.value,
                                                                     rho_sus.value,
                                                                     Cv.value,
                                                                     Cm.value,
                                                                     ne.value,
                                                                     nc.value,
                                                                     hce.value);
        }

        public List<fmBlockParameter> GetParametersByGroup (fmBlockParameterGroup group)
        {
            List<fmBlockParameter> result = new List<fmBlockParameter>();
            if(group!=null)
            {
                foreach (fmBlockParameter p in parameters)
                {
                    if (p.group != null && p.group == group)
                        result.Add(p);
                }
            }
            return result;
        }



        private fmFilterMachiningCalculator.CalculationOptions GetCalculatorCalculationOption()
        {
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

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Mf, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Mf_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Mf, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Mf_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Mf, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Mf_tr_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Vsus, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Vsus_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Vsus, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Vsus_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Vsus, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Vsus_tr_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Msus, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Msus_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Msus, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Msus_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Msus, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Msus_tr_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Ms, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Ms_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Ms, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Ms_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Ms, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_Ms_tr_INPUT;
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

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Vsus, sf }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART7_A_Dp_Vsus_sf_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Vsus, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART7_A_Dp_Vsus_tr_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Msus, sf }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART7_A_Dp_Msus_sf_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Msus, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART7_A_Dp_Msus_tr_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Ms, sf }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART7_A_Dp_Ms_sf_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Dp, Ms, tr }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART7_A_Dp_Ms_tr_INPUT;
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

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Vsus, sf, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Vsus_sf_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Vsus, sf, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Vsus_sf_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Vsus, tr, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Vsus_tr_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Vsus, tr, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Vsus_tr_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Msus, sf, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Msus_sf_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Msus, sf, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Msus_sf_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Msus, tr, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Msus_tr_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Msus, tr, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Msus_tr_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Ms, sf, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Ms_sf_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Ms, sf, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Ms_sf_tc_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Ms, tr, n }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Ms_tr_n_INPUT;
            }

            if (IsSameLists(inputParameters, new fmBlockParameter[] { A, Ms, tr, tc }))
            {
                return fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_Ms_tr_tc_INPUT;
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
            : this(calculationOptionView, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,null, null, null, null, null, null, null, null, null, null, null, null, null)
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
            DataGridViewCell hc_over_tf_Cell,
            DataGridViewCell dhc_over_dt_Cell,
            DataGridViewCell hc_Cell,
            DataGridViewCell Mf_Cell,
            DataGridViewCell Vf_Cell,
            DataGridViewCell mf_Cell,
            DataGridViewCell vf_Cell,
            DataGridViewCell ms_Cell,
            DataGridViewCell vs_Cell,
            DataGridViewCell msus_Cell,
            DataGridViewCell vsus_Cell,
            DataGridViewCell mc_Cell,
            DataGridViewCell vc_Cell,
            DataGridViewCell Msus_Cell,
            DataGridViewCell Vsus_Cell,
            DataGridViewCell Vc_Cell,
            DataGridViewCell Mc_Cell,
            DataGridViewCell Ms_Cell,
            DataGridViewCell Vs_Cell,
            DataGridViewCell Qf_Cell,
            DataGridViewCell Qf_d_Cell,
            DataGridViewCell Qs_Cell,
            DataGridViewCell Qs_d_Cell,
            DataGridViewCell Qc_Cell,
            DataGridViewCell Qc_d_Cell,
            DataGridViewCell Qsus_Cell,
            DataGridViewCell Qsus_d_Cell,
            DataGridViewCell Qmsus_Cell,
            DataGridViewCell Qmsus_d_Cell,
            DataGridViewCell Qms_Cell,
            DataGridViewCell Qms_d_Cell,
            DataGridViewCell Qmf_Cell,
            DataGridViewCell Qmf_d_Cell,
            DataGridViewCell Qmc_Cell,
            DataGridViewCell Qmc_d_Cell,
            DataGridViewCell qf_Cell,
            DataGridViewCell qf_d_Cell,
            DataGridViewCell qs_Cell,
            DataGridViewCell qs_d_Cell,
            DataGridViewCell qc_Cell,
            DataGridViewCell qc_d_Cell,
            DataGridViewCell qsus_Cell,
            DataGridViewCell qsus_d_Cell,
            DataGridViewCell qmsus_Cell,
            DataGridViewCell qmsus_d_Cell,
            DataGridViewCell qms_Cell,
            DataGridViewCell qms_d_Cell,
            DataGridViewCell qmf_Cell,
            DataGridViewCell qmf_d_Cell,
            DataGridViewCell qmc_Cell,
            DataGridViewCell qmc_d_Cell,
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
            AddParameter(ref hc_over_tf, fmGlobalParameter.hc_over_tf, hc_over_tf_Cell, false);
            AddParameter(ref dhc_over_dt, fmGlobalParameter.dhc_over_dt, dhc_over_dt_Cell, false);
            AddParameter(ref hc, fmGlobalParameter.hc, hc_Cell, false);
            AddParameter(ref Mf, fmGlobalParameter.Mf, Mf_Cell, false);
            AddParameter(ref Vf, fmGlobalParameter.Vf, Vf_Cell, false);
            AddParameter(ref mf, fmGlobalParameter.mf, mf_Cell, false);
            AddParameter(ref vf, fmGlobalParameter.vf, vf_Cell, false);
            AddParameter(ref ms, fmGlobalParameter.ms, ms_Cell, false);
            AddParameter(ref vs, fmGlobalParameter.vs, vs_Cell, false);
            AddParameter(ref msus, fmGlobalParameter.msus, msus_Cell, false);
            AddParameter(ref vsus, fmGlobalParameter.vsus, vsus_Cell, false);
            AddParameter(ref mc, fmGlobalParameter.mc, mc_Cell, false);
            AddParameter(ref vc, fmGlobalParameter.vc, vc_Cell, false);
            AddParameter(ref Msus, fmGlobalParameter.Msus, Msus_Cell, false);
            AddParameter(ref Vsus, fmGlobalParameter.Vsus, Vsus_Cell, false);
            AddParameter(ref Vc, fmGlobalParameter.Vc, Vc_Cell, false);
            AddParameter(ref Mc, fmGlobalParameter.Mc, Mc_Cell, false);
            AddParameter(ref Ms, fmGlobalParameter.Ms, Ms_Cell, false);
            AddParameter(ref Vs, fmGlobalParameter.Vs, Vs_Cell, false);
            AddParameter(ref Qf, fmGlobalParameter.Qf, Qf_Cell, false);
            AddParameter(ref Qf_d, fmGlobalParameter.Qf_d, Qf_d_Cell, false);
            AddParameter(ref Qs, fmGlobalParameter.Qs, Qs_Cell, false);
            AddParameter(ref Qs_d, fmGlobalParameter.Qs_d, Qs_d_Cell, false);
            AddParameter(ref Qc, fmGlobalParameter.Qc, Qc_Cell, false);
            AddParameter(ref Qc_d, fmGlobalParameter.Qc_d, Qc_d_Cell, false);
            AddParameter(ref Qsus, fmGlobalParameter.Qsus, Qsus_Cell, false);
            AddParameter(ref Qsus_d, fmGlobalParameter.Qsus_d, Qsus_d_Cell, false);
            AddParameter(ref Qmsus, fmGlobalParameter.Qmsus, Qmsus_Cell, false);
            AddParameter(ref Qmsus_d, fmGlobalParameter.Qmsus_d, Qmsus_d_Cell, false);
            AddParameter(ref Qms, fmGlobalParameter.Qms, Qms_Cell, false);
            AddParameter(ref Qms_d, fmGlobalParameter.Qms_d, Qms_d_Cell, false);
            AddParameter(ref Qmf, fmGlobalParameter.Qmf, Qmf_Cell, false);
            AddParameter(ref Qmf_d, fmGlobalParameter.Qmf_d, Qmf_d_Cell, false);
            AddParameter(ref Qmc, fmGlobalParameter.Qmc, Qmc_Cell, false);
            AddParameter(ref Qmc_d, fmGlobalParameter.Qmc_d, Qmc_d_Cell, false);
            AddParameter(ref qf, fmGlobalParameter.qf, qf_Cell, false);
            AddParameter(ref qf_d, fmGlobalParameter.qf_d, qf_d_Cell, false);
            AddParameter(ref qs, fmGlobalParameter.qs, qs_Cell, false);
            AddParameter(ref qs_d, fmGlobalParameter.qs_d, qs_d_Cell, false);
            AddParameter(ref qc, fmGlobalParameter.qc, qc_Cell, false);
            AddParameter(ref qc_d, fmGlobalParameter.qc_d, qc_d_Cell, false);
            AddParameter(ref qsus, fmGlobalParameter.qsus, qsus_Cell, false);
            AddParameter(ref qsus_d, fmGlobalParameter.qsus_d, qsus_d_Cell, false);
            AddParameter(ref qmsus, fmGlobalParameter.qmsus, qmsus_Cell, false);
            AddParameter(ref qmsus_d, fmGlobalParameter.qmsus_d, qmsus_d_Cell, false);
            AddParameter(ref qms, fmGlobalParameter.qms, qms_Cell, false);
            AddParameter(ref qms_d, fmGlobalParameter.qms_d, qms_d_Cell, false);
            AddParameter(ref qmf, fmGlobalParameter.qmf, qmf_Cell, false);
            AddParameter(ref qmf_d, fmGlobalParameter.qmf_d, qmf_d_Cell, false);
            AddParameter(ref qmc, fmGlobalParameter.qmc, qmc_Cell, false);
            AddParameter(ref qmc_d, fmGlobalParameter.qmc_d, qmc_d_Cell, false);
            AddParameter(ref eps, fmGlobalParameter.eps, eps_Cell, false);
            AddParameter(ref kappa, fmGlobalParameter.kappa, kappa_Cell, false);
            AddParameter(ref Pc, fmGlobalParameter.Pc, Pc_Cell, false);
            AddParameter(ref rc, fmGlobalParameter.rc, rc_Cell, false);
            AddParameter(ref a, fmGlobalParameter.a, a_Cell, false);

            AddConstantParameter(ref hce, fmGlobalParameter.hce);
            AddConstantParameter(ref Pc0, fmGlobalParameter.Pc0);
            AddConstantParameter(ref nc, fmGlobalParameter.nc);
            AddConstantParameter(ref eps0, fmGlobalParameter.eps0);
            AddConstantParameter(ref kappa0, fmGlobalParameter.kappa0);
            AddConstantParameter(ref ne, fmGlobalParameter.ne);
            AddConstantParameter(ref etaf, fmGlobalParameter.eta_f);
            AddConstantParameter(ref rho_f, fmGlobalParameter.rho_f);
            AddConstantParameter(ref rho_s, fmGlobalParameter.rho_s); 
            AddConstantParameter(ref rho_sus, fmGlobalParameter.rho_sus);
            AddConstantParameter(ref Cm, fmGlobalParameter.Cm);
            AddConstantParameter(ref Cv, fmGlobalParameter.Cv);

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

        Dictionary<CalculationOption, Dictionary<fmBlockParameter, fmBlockParameterGroup>> table = null;

        fmBlockParameterGroup WhatGroupOfParameterWithCalcOption(fmBlockParameter parameter, CalculationOption calcOption)
        {
            if (table == null)
            {
                table = new Dictionary<CalculationOption, Dictionary<fmBlockParameter, fmBlockParameterGroup>>();

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
            }

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

            //[Description("8: A, Dp, (hc/Vf/Mf/Vsus/Msus/Ms), (n/tc/tr)")]
            table[A] = A_group;
            table[Dp] = Dp_group;
            table[hc] = hc_MV_group;
            table[Vf] = hc_MV_group;
            table[Mf] = hc_MV_group;
            table[Vsus] = hc_MV_group;
            table[Msus] = hc_MV_group;
            table[Ms] = hc_MV_group;
            table[n] = n_tc_tr_group;
            table[tc] = n_tc_tr_group;
            table[tr] = n_tc_tr_group;
        }

        private void SetGroupsOfStandart7(Dictionary<fmBlockParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockParameter p in parameters)
                table[p] = null;

            //[Description("7: A, Dp, (hc/Vf/Mf/Vsus/Msus/Ms), (sf/tr)")]
            table[A] = A_group;
            table[hc] = hc_MV_group;
            table[Vf] = hc_MV_group;
            table[Mf] = hc_MV_group;
            table[Vsus] = hc_MV_group;
            table[Msus] = hc_MV_group;
            table[Ms] = hc_MV_group;
            table[sf] = sf_tr_group;
            table[tr] = sf_tr_group;
        }

        private void SetGroupsOfStandart4(Dictionary<fmBlockParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockParameter p in parameters)
                table[p] = null;

            //[Description("4: A, (hc/Vf/Mf/Vsus/Msus/Ms), (sf/tr), (n/tc)")]
            table[A] = A_group;
            table[hc] = hc_MV_group;
            table[Vf] = hc_MV_group;
            table[Mf] = hc_MV_group;
            table[Vsus] = hc_MV_group;
            table[Msus] = hc_MV_group;
            table[Ms] = hc_MV_group;
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
                //    hce_value = filterMachiningBlock.hce_value;

                //    Pc0_value = filterMachiningBlock.Pc0_value;
                //    nc_value = filterMachiningBlock.nc_value;

                //    eps0_value = filterMachiningBlock.eps0_value;
                //    kappa0_value = filterMachiningBlock.kappa0_value;
                //    ne_value = filterMachiningBlock.ne_value;

                //    etaf_value = filterMachiningBlock.etaf_value;
                //    rho_f_value = filterMachiningBlock.rho_f_value;
                //    rho_s_value = filterMachiningBlock.rho_s_value;
                //    rho_sus_value = filterMachiningBlock.rho_sus_value;
                //    Cm_value = filterMachiningBlock.Cm_value;
                //    Cv_value = filterMachiningBlock.Cv_value;

                for (int i = 0; i < constantParameters.Count; ++i)
                {
                    constantParameters[i].value = filterMachiningBlock.constantParameters[i].value;
                }
            }
        }

        public void CopyValues(fmFilterMachiningBlock filterMachiningBlock)
        {
            CopyParameters(filterMachiningBlock);
            CopyConstants(filterMachiningBlock);
        }
    }
}
