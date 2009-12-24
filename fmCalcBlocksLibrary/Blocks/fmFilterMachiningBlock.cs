using System;
using System.ComponentModel;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Controls;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;
using System.Collections.Generic;

namespace fmCalcBlocksLibrary.Blocks
{
    public enum CalculationOption
    {
        // Standart -- In this case we have always the area A as input 
        // and the (Qsus, Qmsus, Qms) as calculated.
        [Description("1: A, Dp, sf, (n/tc)")]
        Standart1,
        [Description("2: A, Dp, sf, tf")]
        Standart2,
        [Description("3: A, Dp, (n/tc), tf")]
        Standart3,
        [Description("4: A, hc, sf, (n/tc)")]
        Standart4,
        //Standart5,  // A, hc, sf, tf           -- input
        //Standart6,  // A, hc, (n/tc), tf       -- input
        [Description("7: A, Dp, hc, sf")]
        Standart7,
        [Description("8: A, Dp, hc, (n/tc)")]
        Standart8,
        
        // Design -- In this case we have always the (Qsus, Qmsus, Qms) as input 
        // and the filter area A is calculated 
        [Description("1: Q, Dp, hc, (n/tc)")]
        Design1,
        //Design2,    // Q, Dp, hc, sf           -- input 
        //Design3,    // Q, sf, (n/tc), hc       -- input 

        // Optimization -- In this case we have always the filter 
        // area A and the (Qsus, Qmsus, Qms) as input
        [Description("1: A, Q, Dp, sf")]
        Optimization1
        //Optimization2,  // A, Q, hc, sf           -- input
        //Optimization3   // A, Q, (n/tc), sf       -- input
    }
    
    static public class CalculationOptionHelper
    {
        public static List<fmGlobalParameter> GetInputedParametersList(CalculationOption calculationOption)
        {
            List<fmGlobalParameter> result = new List<fmGlobalParameter>();
            switch (calculationOption)
            {
                //[Description("1: A, Dp, sf, (n/tc)")]
                case CalculationOption.Standart1:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.sf);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    break;

                //[Description("2: A, Dp, sf, tf")]
                case CalculationOption.Standart2:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.sf);
                    result.Add(fmGlobalParameter.tf);
                    break;

                //[Description("3: A, Dp, (n/tc), tf")]
                case CalculationOption.Standart3:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    result.Add(fmGlobalParameter.tf);
                    break;
        
                //[Description("4: A, hc, sf, (n/tc)")]
                case CalculationOption.Standart4:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.sf);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    break;
        
                //[Description("7: A, Dp, hc, sf")]
                case CalculationOption.Standart7:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.sf);
                    break;
        
                //[Description("8: A, Dp, hc, (n/tc)")]
                case CalculationOption.Standart8:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    break;
        
                //[Description("1: Q, Dp, hc, (n/tc)")]
                case CalculationOption.Design1:
                    result.Add(fmGlobalParameter.Qms);
                    result.Add(fmGlobalParameter.Qmsus);
                    result.Add(fmGlobalParameter.Qsus);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    break;
        
                //[Description("1: A, Q, Dp, sf")]
                case CalculationOption.Optimization1:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Qms);
                    result.Add(fmGlobalParameter.Qmsus);
                    result.Add(fmGlobalParameter.Qsus);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.sf);
                    break;
            }

            return result;
        }
    }

    public class fmFilterMachiningBlock : fmBaseBlock
    {
        public fmCalculationOptionView calculationOptionView;

        private fmBlockParameter A;
        private fmBlockParameter Dp;
        private fmBlockParameter sf;
        private fmBlockParameter n;
        private fmBlockParameter tc;
        private fmBlockParameter tf;
        private fmBlockParameter hc;
        private fmBlockParameter Mf;
        private fmBlockParameter Msus;
        private fmBlockParameter Vsus;
        private fmBlockParameter Ms;
        private fmBlockParameter Qsus;
        private fmBlockParameter Qmsus;
        private fmBlockParameter Qms;
        private fmBlockParameter eps;
        private fmBlockParameter kappa;
        private fmBlockParameter Pc;
        private fmBlockParameter rc;
        private fmBlockParameter a;

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
            fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions calcOption;

            if (A.isInputed && !Qms.isInputed && !Qmsus.isInputed && !Qsus.isInputed)
            {
                if (A.isInputed && Dp.isInputed && !hc.isInputed)
                {
                    if (sf.isInputed && n.isInputed)
                    {
                        calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.STANDART1_A_Dp_sf_n_INPUT;
                    }
                    else if (sf.isInputed && tc.isInputed)
                    {
                        calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.STANDART1_A_Dp_sf_tc_INPUT;
                    }
                    else if (sf.isInputed && tf.isInputed)
                    {
                        calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.STANDART2_A_Dp_sf_tf_INPUT;
                    }
                    else if (n.isInputed && tf.isInputed)
                    {
                        calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.STANDART3_A_Dp_n_tf_INPUT;
                    }
                    else if (tc.isInputed && tf.isInputed)
                    {
                        calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.STANDART3_A_Dp_tc_tf_INPUT;
                    }
                    else
                    {
                        throw new Exception("Not processed combination of inputs");
                    }
                }
                else if (A.isInputed && !Dp.isInputed && hc.isInputed)
                {
                    if (sf.isInputed && n.isInputed)
                    {
                        calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_hc_sf_n_INPUT;
                    }
                    else if (sf.isInputed && tc.isInputed)
                    {
                        calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.STANDART4_A_hc_sf_tc_INPUT;
                    }
                    else
                    {
                        throw new Exception("Not processed combination of inputs");
                    }
                }
                else if (A.isInputed && Dp.isInputed && hc.isInputed)
                {
                    if (sf.isInputed)
                    {
                        calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.STANDART7_A_Dp_hc_sf_INPUT;
                    }
                    else if (n.isInputed)
                    {
                        calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_hc_n_INPUT;
                    }
                    else if (tc.isInputed)
                    {
                        calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.STANDART8_A_Dp_hc_tc_INPUT;
                    }
                    else
                    {
                        throw new Exception("Not processed combination of inputs");
                    }
                }
                else
                {
                    throw new Exception("Not processed combination of inputs");
                }
            }
            else if ((Qms.isInputed || Qmsus.isInputed || Qsus.isInputed)
                     && !A.isInputed)
            {
                if (Qms.isInputed && Dp.isInputed && hc.isInputed && n.isInputed)
                {
                    calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qms_Dp_hc_n_INPUT;
                }
                else if (Qms.isInputed && Dp.isInputed && hc.isInputed && tc.isInputed)
                {
                    calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qms_Dp_hc_tc_INPUT;
                }
                else if (Qmsus.isInputed && Dp.isInputed && hc.isInputed && n.isInputed)
                {
                    calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qmsus_Dp_hc_n_INPUT;
                }
                else if (Qmsus.isInputed && Dp.isInputed && hc.isInputed && tc.isInputed)
                {
                    calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qmsus_Dp_hc_tc_INPUT;
                }
                else if (Qsus.isInputed && Dp.isInputed && hc.isInputed && n.isInputed)
                {
                    calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qsus_Dp_hc_n_INPUT;
                }
                else if (Qsus.isInputed && Dp.isInputed && hc.isInputed && tc.isInputed)
                {
                    calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.DESIGN1_Qsus_Dp_hc_tc_INPUT;
                }
                else
                {
                    throw new Exception("Not processed combination of inputs");
                }
            }
            else if (A.isInputed && (Qms.isInputed || Qmsus.isInputed || Qsus.isInputed))
            {
                if (Qms.isInputed && Dp.isInputed && sf.isInputed)
                {
                    calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.OPTIMIZATION1_A_Qms_Dp_sf_INPUT;
                }
                else if (Qmsus.isInputed && Dp.isInputed && sf.isInputed)
                {
                    calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.OPTIMIZATION1_A_Qmsus_Dp_sf_INPUT;
                }
                else if (Qsus.isInputed && Dp.isInputed && sf.isInputed)
                {
                    calcOption = fmCalculatorsLibrary.fmFilterMachiningCalculator.CalculationOptions.OPTIMIZATION1_A_Qsus_Dp_sf_INPUT;
                }
                else
                {
                    throw new Exception("Not processed combination of inputs");
                }
            }
            else
            {
                throw new Exception("Not processed calculation Option");
            }

            fmCalculatorsLibrary.fmFilterMachiningCalculator.Process(calcOption,
                                                                     ref A.value,
                                                                     ref Dp.value,
                                                                     ref sf.value,
                                                                     ref n.value,
                                                                     ref tc.value,
                                                                     ref tf.value,
                                                                     ref hc.value,
                                                                     ref Qsus.value,
                                                                     ref Qmsus.value,
                                                                     ref Qms.value,
                                                                     ref Vsus.value,
                                                                     ref Mf.value,
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

        override public void UpdateIsInputed(fmBlockParameter enteredParameter)
        {
            if (enteredParameter == n)
            {
                tc.isInputed = false;
                n.isInputed = true;
            }
            else if (enteredParameter == tc)
            {
                tc.isInputed = true;
                n.isInputed = false;
            }

            if (enteredParameter == Qms)
            {
                Qms.isInputed = true;
                Qmsus.isInputed = false;
                Qsus.isInputed = false;
            }
            else if (enteredParameter == Qmsus)
            {
                Qms.isInputed = false;
                Qmsus.isInputed = true;
                Qsus.isInputed = false;
            }
            else if (enteredParameter == Qsus)
            {
                Qms.isInputed = false;
                Qmsus.isInputed = false;
                Qsus.isInputed = true;
            }
        }

        public fmFilterMachiningBlock(
            fmCalculationOptionView calculationOptionView)
            : this(calculationOptionView, null, null, null, null, null, null, null, null, null, null, null, null,
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
            DataGridViewCell hc_Cell,
            DataGridViewCell Mf_Cell,
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
            AddParameter(ref hc, fmGlobalParameter.hc, hc_Cell, false);
            AddParameter(ref Mf, fmGlobalParameter.Mf, Mf_Cell, false);
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
                CalculationOption calcOption = calculationOptionView.GetSelectedOption();
                //CalculationOption = calculationOptionView.GetSelectedOption();
                List<fmGlobalParameter> inputedParameters = CalculationOptionHelper.GetInputedParametersList(calcOption);
                //List<fmGlobalParameter> inputedParameters = CalculationOptionHelper.GetInputedParametersList(CalculationOption);
                foreach (fmBlockParameter parameter in parameters)
                {
                    bool found = inputedParameters.Contains(parameter.globalParameter);
                    parameter.isInputed = found;
                    if (parameter.cell != null)
                    {
                        parameter.cell.ReadOnly = !found;
                    }
                }
                ReWriteParameters();
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


        //private void RadioButtonCheckChanged(object sender, EventArgs e)
        //{
        //    if (processOnChange)
        //    {
        //        bool standartN = rBtn_A_Dp_sf_ntc.Checked
        //            || rBtn_A_Dp_sf_tf.Checked
        //            || rBtn_A_Dp_ntc_tf.Checked
        //            || rBtn_A_hc_sf_ntc.Checked
        //            || rBtn_A_Dp_hc_sf.Checked
        //            || rBtn_A_Dp_hc_ntc.Checked;
        //        bool designN = rBtn_Q_Dp_hc_ntc.Checked;
        //        bool optimizationN = rBtn_A_Q_Dp_sf.Checked;

        //        if (standartN)
        //        {
        //            if (rBtn_A_Dp_sf_ntc.Checked)
        //            {
        //                calculationOption = CalculationOption.Standart1;

        //                Dp.isInputed = true;
        //                sf.isInputed = true;
        //                n.isInputed = true;
        //                tc.isInputed = false;
        //                tf.isInputed = false;
        //                hc.isInputed = false;

        //                Dp.cell.ReadOnly = false;
        //                sf.cell.ReadOnly = false;
        //                n.cell.ReadOnly = false;
        //                tc.cell.ReadOnly = false;
        //                tf.cell.ReadOnly = true;
        //                hc.cell.ReadOnly = true;
        //            }
        //            else if (rBtn_A_Dp_sf_tf.Checked)
        //            {
        //                calculationOption = CalculationOption.Standart2;

        //                Dp.isInputed = true;
        //                sf.isInputed = true;
        //                n.isInputed = false;
        //                tc.isInputed = false;
        //                tf.isInputed = true;
        //                hc.isInputed = false;

        //                Dp.cell.ReadOnly = false;
        //                sf.cell.ReadOnly = false;
        //                n.cell.ReadOnly = true;
        //                tc.cell.ReadOnly = true;
        //                tf.cell.ReadOnly = false;
        //                hc.cell.ReadOnly = true;
        //            }
        //            else if (rBtn_A_Dp_ntc_tf.Checked)
        //            {
        //                calculationOption = CalculationOption.Standart3;

        //                Dp.isInputed = true;
        //                sf.isInputed = false;
        //                n.isInputed = true;
        //                tc.isInputed = false;
        //                tf.isInputed = true;
        //                hc.isInputed = false;

        //                Dp.cell.ReadOnly = false;
        //                sf.cell.ReadOnly = true;
        //                n.cell.ReadOnly = false;
        //                tc.cell.ReadOnly = false;
        //                tf.cell.ReadOnly = false;
        //                hc.cell.ReadOnly = true;
        //            }
        //            else if (rBtn_A_hc_sf_ntc.Checked)
        //            {
        //                calculationOption = CalculationOption.Standart4;

        //                Dp.isInputed = false;
        //                sf.isInputed = true;
        //                n.isInputed = true;
        //                tc.isInputed = false;
        //                tf.isInputed = false;
        //                hc.isInputed = true;

        //                Dp.cell.ReadOnly = true;
        //                sf.cell.ReadOnly = false;
        //                n.cell.ReadOnly = false;
        //                tc.cell.ReadOnly = false;
        //                tf.cell.ReadOnly = true;
        //                hc.cell.ReadOnly = false;
        //            }
        //            else if (rBtn_A_Dp_hc_sf.Checked)
        //            {
        //                calculationOption = CalculationOption.Standart7;

        //                Dp.isInputed = true;
        //                sf.isInputed = true;
        //                n.isInputed = false;
        //                tc.isInputed = false;
        //                tf.isInputed = false;
        //                hc.isInputed = true;

        //                Dp.cell.ReadOnly = false;
        //                sf.cell.ReadOnly = false;
        //                n.cell.ReadOnly = true;
        //                tc.cell.ReadOnly = true;
        //                tf.cell.ReadOnly = true;
        //                hc.cell.ReadOnly = false;
        //            }
        //            else if (rBtn_A_Dp_hc_ntc.Checked)
        //            {
        //                calculationOption = CalculationOption.Standart8;

        //                Dp.isInputed = true;
        //                sf.isInputed = false;
        //                n.isInputed = true;
        //                tc.isInputed = false;
        //                tf.isInputed = false;
        //                hc.isInputed = true;

        //                Dp.cell.ReadOnly = false;
        //                sf.cell.ReadOnly = true;
        //                n.cell.ReadOnly = false;
        //                tc.cell.ReadOnly = false;
        //                tf.cell.ReadOnly = true;
        //                hc.cell.ReadOnly = false;
        //            }

        //            A.isInputed = true;
        //            Mf.isInputed = false;
        //            Msus.isInputed = false;
        //            Vsus.isInputed = false;
        //            Ms.isInputed = false;
        //            Qsus.isInputed = false;
        //            Qmsus.isInputed = false;
        //            Qms.isInputed = false;

        //            A.cell.ReadOnly = false;
        //            Mf.cell.ReadOnly = true;
        //            Msus.cell.ReadOnly = true;
        //            Vsus.cell.ReadOnly = true;
        //            Ms.cell.ReadOnly = true;
        //            Qsus.cell.ReadOnly = true;
        //            Qmsus.cell.ReadOnly = true;
        //            Qms.cell.ReadOnly = true;
        //        }
        //        else if (designN)
        //        {
        //            if (rBtn_Q_Dp_hc_ntc.Checked)
        //            {
        //                calculationOption = CalculationOption.Design1;

        //                A.isInputed = false;
        //                Mf.isInputed = false;
        //                Msus.isInputed = false;
        //                Vsus.isInputed = false;
        //                Ms.isInputed = false;
        //                Qsus.isInputed = false;
        //                Qmsus.isInputed = false;
        //                Qms.isInputed = true;
        //                Dp.isInputed = true;
        //                sf.isInputed = false;
        //                n.isInputed = true;
        //                tc.isInputed = false;
        //                tf.isInputed = false;
        //                hc.isInputed = true;

        //                Dp.cell.ReadOnly = false;
        //                sf.cell.ReadOnly = true;
        //                n.cell.ReadOnly = false;
        //                tc.cell.ReadOnly = false;
        //                tf.cell.ReadOnly = true;
        //                hc.cell.ReadOnly = false;
        //                A.cell.ReadOnly = true;
        //                Mf.cell.ReadOnly = true;
        //                Msus.cell.ReadOnly = true;
        //                Vsus.cell.ReadOnly = true;
        //                Ms.cell.ReadOnly = true;
        //                Qsus.cell.ReadOnly = false;
        //                Qmsus.cell.ReadOnly = false;
        //                Qms.cell.ReadOnly = false;
        //            }
        //        }
        //        else if (optimizationN)
        //        {
        //            if (rBtn_A_Q_Dp_sf.Checked)
        //            {
        //                calculationOption = CalculationOption.Optimization1;

        //                A.isInputed = true;
        //                Mf.isInputed = false;
        //                Msus.isInputed = false;
        //                Vsus.isInputed = false;
        //                Ms.isInputed = false;
        //                Qsus.isInputed = false;
        //                Qmsus.isInputed = false;
        //                Qms.isInputed = true;
        //                Dp.isInputed = true;
        //                sf.isInputed = true;
        //                n.isInputed = false;
        //                tc.isInputed = false;
        //                tf.isInputed = false;
        //                hc.isInputed = false;

        //                Dp.cell.ReadOnly = false;
        //                sf.cell.ReadOnly = false;
        //                n.cell.ReadOnly = true;
        //                tc.cell.ReadOnly = true;
        //                tf.cell.ReadOnly = true;
        //                hc.cell.ReadOnly = true;
        //                A.cell.ReadOnly = false;
        //                Mf.cell.ReadOnly = true;
        //                Msus.cell.ReadOnly = true;
        //                Vsus.cell.ReadOnly = true;
        //                Ms.cell.ReadOnly = true;
        //                Qsus.cell.ReadOnly = false;
        //                Qmsus.cell.ReadOnly = false;
        //                Qms.cell.ReadOnly = false;
        //            }
        //        }

        //        ReWriteParameters();
        //    }
        //}
    }
}

