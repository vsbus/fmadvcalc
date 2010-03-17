using System;
using System.ComponentModel;
using fmCalculationLibrary;
using fmCalculationLibrary.Equations;
using System.Collections.Generic;

//fmCalculationVariableParameter A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
//fmCalculationVariableParameter sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
//fmCalculationVariableParameter n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
//fmCalculationVariableParameter tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
//fmCalculationVariableParameter tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
//fmCalculationVariableParameter tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
//fmCalculationVariableParameter hc_over_tf = variables[fmGlobalParameter.hc_over_tf] as fmCalculationVariableParameter;
//fmCalculationVariableParameter dhc_over_dt = variables[fmGlobalParameter.dhc_over_dt] as fmCalculationVariableParameter;
//fmCalculationVariableParameter hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qf_d = variables[fmGlobalParameter.Qf_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qs_d = variables[fmGlobalParameter.Qs_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qc_d = variables[fmGlobalParameter.Qc_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qsus_d = variables[fmGlobalParameter.Qsus_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qmsus_d = variables[fmGlobalParameter.Qmsus_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qms_d = variables[fmGlobalParameter.Qms_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qmf_d = variables[fmGlobalParameter.Qmf_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Qmc_d = variables[fmGlobalParameter.Qmc_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qf = variables[fmGlobalParameter.qf] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qf_d = variables[fmGlobalParameter.qf_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qs = variables[fmGlobalParameter.qs] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qs_d = variables[fmGlobalParameter.qs_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qc = variables[fmGlobalParameter.qc] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qc_d = variables[fmGlobalParameter.qc_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qsus = variables[fmGlobalParameter.qsus] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qsus_d = variables[fmGlobalParameter.qsus_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qmsus = variables[fmGlobalParameter.qmsus] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qmsus_d = variables[fmGlobalParameter.qmsus_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qms = variables[fmGlobalParameter.qms] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qms_d = variables[fmGlobalParameter.qms_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qmf = variables[fmGlobalParameter.qmf] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qmf_d = variables[fmGlobalParameter.qmf_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qmc = variables[fmGlobalParameter.qmc] as fmCalculationVariableParameter;
//fmCalculationVariableParameter qmc_d = variables[fmGlobalParameter.qmc_d] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
//fmCalculationVariableParameter mf = variables[fmGlobalParameter.mf] as fmCalculationVariableParameter;
//fmCalculationVariableParameter vf = variables[fmGlobalParameter.vf] as fmCalculationVariableParameter;
//fmCalculationVariableParameter ms = variables[fmGlobalParameter.ms] as fmCalculationVariableParameter;
//fmCalculationVariableParameter vs = variables[fmGlobalParameter.vs] as fmCalculationVariableParameter;
//fmCalculationVariableParameter msus = variables[fmGlobalParameter.msus] as fmCalculationVariableParameter;
//fmCalculationVariableParameter vsus = variables[fmGlobalParameter.vsus] as fmCalculationVariableParameter;
//fmCalculationVariableParameter mc = variables[fmGlobalParameter.mc] as fmCalculationVariableParameter;
//fmCalculationVariableParameter vc = variables[fmGlobalParameter.vc] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Vc = variables[fmGlobalParameter.Vc] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Mc = variables[fmGlobalParameter.Mc] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
//fmCalculationVariableParameter eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
//fmCalculationVariableParameter kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
//fmCalculationVariableParameter Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
//fmCalculationVariableParameter rc = variables[fmGlobalParameter.rc] as fmCalculationVariableParameter;
//fmCalculationVariableParameter a = variables[fmGlobalParameter.a] as fmCalculationVariableParameter;
//fmCalculationConstantParameter eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
//fmCalculationConstantParameter kappa0 = variables[fmGlobalParameter.kappa0] as fmCalculationConstantParameter;
//fmCalculationConstantParameter Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
//fmCalculationConstantParameter eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
//fmCalculationConstantParameter rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
//fmCalculationConstantParameter rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
//fmCalculationConstantParameter rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
//fmCalculationConstantParameter Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
//fmCalculationConstantParameter Cm = variables[fmGlobalParameter.Cm] as fmCalculationConstantParameter;
//fmCalculationConstantParameter ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
//fmCalculationConstantParameter nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
//fmCalculationConstantParameter hce = variables[fmGlobalParameter.hce] as fmCalculationConstantParameter;

namespace fmCalculatorsLibrary
{
    public class fmFilterMachiningCalculator : fmBaseCalculator
    {
        public enum FilterMachiningCalculationOption
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

        public FilterMachiningCalculationOption calculationOption;
        
        public fmFilterMachiningCalculator(List<fmCalculationBaseParameter> parameterList) : base(parameterList) { }

        private static bool IsStandartKindOption(FilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == FilterMachiningCalculationOption.Standart1
              || calculationOption == FilterMachiningCalculationOption.Standart2
              || calculationOption == FilterMachiningCalculationOption.Standart3
              || calculationOption == FilterMachiningCalculationOption.Standart4
              || calculationOption == FilterMachiningCalculationOption.Standart7
              || calculationOption == FilterMachiningCalculationOption.Standart8;
        }

        private static bool IsDesignKindOption(FilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == FilterMachiningCalculationOption.Design1;
        }

        private static bool IsOptimizationKindOption(FilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == FilterMachiningCalculationOption.Optimization1;
        }

        private static bool IsStandartSubKind1DpOption(FilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == FilterMachiningCalculationOption.Standart1
              || calculationOption == FilterMachiningCalculationOption.Standart2
              || calculationOption == FilterMachiningCalculationOption.Standart3;
        }

        private static bool IsStandartSubKind2hcOption(FilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == FilterMachiningCalculationOption.Standart4;
        }

        private static bool IsStandartSubKind3DphcOption(FilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == FilterMachiningCalculationOption.Standart7
              || calculationOption == FilterMachiningCalculationOption.Standart8;
        }

        override public void DoCalculations()
        {
            if (IsStandartKindOption(calculationOption))
            {
                DoCalculationsStandart();
            }
            else if (IsDesignKindOption(calculationOption))
            {
                DoCalculationsDesign();
            }
            else if (IsOptimizationKindOption(calculationOption))
            {
                DoCalculationsOptimization();
            }
            else
            {
                throw new Exception("Not classified calculation option kind");
            }

            fmCalculationVariableParameter A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter hc_over_tf = variables[fmGlobalParameter.hc_over_tf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter dhc_over_dt = variables[fmGlobalParameter.dhc_over_dt] as fmCalculationVariableParameter;
            fmCalculationVariableParameter hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qf_d = variables[fmGlobalParameter.Qf_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qs_d = variables[fmGlobalParameter.Qs_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qc_d = variables[fmGlobalParameter.Qc_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qsus_d = variables[fmGlobalParameter.Qsus_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmsus_d = variables[fmGlobalParameter.Qmsus_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qms_d = variables[fmGlobalParameter.Qms_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmf_d = variables[fmGlobalParameter.Qmf_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmc_d = variables[fmGlobalParameter.Qmc_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qf = variables[fmGlobalParameter.qf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qf_d = variables[fmGlobalParameter.qf_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qs = variables[fmGlobalParameter.qs] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qs_d = variables[fmGlobalParameter.qs_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qc = variables[fmGlobalParameter.qc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qc_d = variables[fmGlobalParameter.qc_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qsus = variables[fmGlobalParameter.qsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qsus_d = variables[fmGlobalParameter.qsus_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qmsus = variables[fmGlobalParameter.qmsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qmsus_d = variables[fmGlobalParameter.qmsus_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qms = variables[fmGlobalParameter.qms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qms_d = variables[fmGlobalParameter.qms_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qmf = variables[fmGlobalParameter.qmf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qmf_d = variables[fmGlobalParameter.qmf_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qmc = variables[fmGlobalParameter.qmc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qmc_d = variables[fmGlobalParameter.qmc_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter mf = variables[fmGlobalParameter.mf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter vf = variables[fmGlobalParameter.vf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter ms = variables[fmGlobalParameter.ms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter vs = variables[fmGlobalParameter.vs] as fmCalculationVariableParameter;
            fmCalculationVariableParameter msus = variables[fmGlobalParameter.msus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter vsus = variables[fmGlobalParameter.vsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter mc = variables[fmGlobalParameter.mc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter vc = variables[fmGlobalParameter.vc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vc = variables[fmGlobalParameter.Vc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Mc = variables[fmGlobalParameter.Mc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            fmCalculationVariableParameter kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
            fmCalculationConstantParameter eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            fmCalculationConstantParameter hce = variables[fmGlobalParameter.hce] as fmCalculationConstantParameter;

            hc_over_tf.value = FilterMachiningEquations.Eval_hc_over_tf_From_hc_tf(hc.value, tf.value);
            dhc_over_dt.value = FilterMachiningEquations.Eval_dhc_over_dt_From_kappa_Dp_Pc_eta_hc_hce(kappa.value, Dp.value, Pc.value, eta_f.value, hc.value, hce.value);
            Mc.value = FilterMachiningEquations.Eval_Cake_From_Sus_Flow(Msus.value, Mf.value);
            Vc.value = FilterMachiningEquations.Eval_Cake_From_Sus_Flow(Vsus.value, Vf.value);
            mf.value = FilterMachiningEquations.Eval_m_From_M_A(Mf.value, A.value);
            vf.value = FilterMachiningEquations.Eval_v_From_V_A(Vf.value, A.value);
            msus.value = FilterMachiningEquations.Eval_m_From_M_A(Msus.value, A.value);
            vsus.value = FilterMachiningEquations.Eval_v_From_V_A(Vsus.value, A.value);
            ms.value = FilterMachiningEquations.Eval_m_From_M_A(Ms.value, A.value);
            vs.value = FilterMachiningEquations.Eval_v_From_V_A(Vs.value, A.value);
            mc.value = FilterMachiningEquations.Eval_m_From_M_A(Mc.value, A.value);
            vc.value = FilterMachiningEquations.Eval_v_From_V_A(Vc.value, A.value);
            Qsus_d.value = FilterMachiningEquations.Eval_Qsus_d_From_eps_A_Cv_dhcdt(eps.value, A.value, Cv.value, dhc_over_dt.value);
            Qmsus_d.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Qsus_d.value);
            Qs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value); ;
            Qs_d.value = FilterMachiningEquations.Eval_Qs_d_From_eps_A_dhcdt(eps.value, A.value, dhc_over_dt.value);
            Qms_d.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_s.value, Qs_d.value);
            Qmf.value = FilterMachiningEquations.Eval_Qm_From_M_t(Mf.value, tf.value);
            Qf.value = FilterMachiningEquations.Eval_Q_From_V_t(Vf.value, tf.value);
            Qf_d.value = FilterMachiningEquations.Eval_Qf_d_From_A_Dp_Pc_eta_hc_hce(A.value, Dp.value, Pc.value, eta_f.value, hc.value, hce.value);
            Qmf_d.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Qf_d.value); ;
            Qmc.value = FilterMachiningEquations.Eval_Qm_From_M_t(Mc.value, tc.value);
            Qc_d.value = FilterMachiningEquations.Eval_Cake_From_Sus_Flow(Qsus_d.value, Qf_d.value);
            Qmc_d.value = FilterMachiningEquations.Eval_Cake_From_Sus_Flow(Qmsus_d.value, Qmf_d.value);
            Qc.value = FilterMachiningEquations.Eval_Q_From_V_t(Vc.value, tc.value);
            qf.value = FilterMachiningEquations.eval_q_From_Q_A(Qf.value, A.value);
            qf_d.value = FilterMachiningEquations.eval_q_From_Q_A(Qf_d.value, A.value);
            qsus.value = FilterMachiningEquations.eval_q_From_Q_A(Qsus.value, A.value);
            qsus_d.value = FilterMachiningEquations.eval_q_From_Q_A(Qsus_d.value, A.value);
            qs.value = FilterMachiningEquations.eval_q_From_Q_A(Qs.value, A.value);
            qs_d.value = FilterMachiningEquations.eval_q_From_Q_A(Qs_d.value, A.value);
            qc.value = FilterMachiningEquations.eval_q_From_Q_A(Qc.value, A.value);
            qc_d.value = FilterMachiningEquations.eval_q_From_Q_A(Qc_d.value, A.value);
            qmf.value = FilterMachiningEquations.eval_q_From_Q_A(Qmf.value, A.value);
            qmf_d.value = FilterMachiningEquations.eval_q_From_Q_A(Qmf_d.value, A.value);
            qmsus.value = FilterMachiningEquations.eval_q_From_Q_A(Qmsus.value, A.value);
            qmsus_d.value = FilterMachiningEquations.eval_q_From_Q_A(Qmsus_d.value, A.value);
            qms.value = FilterMachiningEquations.eval_q_From_Q_A(Qms.value, A.value);
            qms_d.value = FilterMachiningEquations.eval_q_From_Q_A(Qms_d.value, A.value);
            qmc.value = FilterMachiningEquations.eval_q_From_Q_A(Qmc.value, A.value);
            qmc_d.value = FilterMachiningEquations.eval_q_From_Q_A(Qmc_d.value, A.value);
        }
        private void DoCalculationsStandart()
        {
            if (IsStandartSubKind1DpOption(calculationOption))
            {
                DoSubCalculationsStandart123();
            }
            else if (IsStandartSubKind2hcOption(calculationOption))
            {
                DoSubCalculationsStandart456();
            }
            else if (IsStandartSubKind3DphcOption(calculationOption))
            {
                DoSubCalculationsStandart78();
            }
            else
            {
                throw new Exception("Not classified calculation suboption of Standart");
            }

            fmCalculationVariableParameter tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
            fmCalculationConstantParameter Cm = variables[fmGlobalParameter.Cm] as fmCalculationConstantParameter;

            Qsus.value = FilterMachiningEquations.Eval_Qsus_From_Vsus_tc(Vsus.value, tc.value);
            Qmsus.value = FilterMachiningEquations.Eval_Qmsus_From_Msus_tc(Msus.value, tc.value);
            Qms.value = FilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(Qmsus.value, Cm.value);
        }
        private void DoCalculationsDesign()
        {
            fmCalculationVariableParameter A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            fmCalculationVariableParameter sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            fmCalculationVariableParameter hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            fmCalculationVariableParameter kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter rc = variables[fmGlobalParameter.rc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter a = variables[fmGlobalParameter.a] as fmCalculationVariableParameter;
            fmCalculationConstantParameter eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
            fmCalculationConstantParameter eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Cm = variables[fmGlobalParameter.Cm] as fmCalculationConstantParameter;
            fmCalculationConstantParameter ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
            fmCalculationConstantParameter nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
            fmCalculationConstantParameter hce = variables[fmGlobalParameter.hce] as fmCalculationConstantParameter;

            eps.value = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = EpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = FilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = PcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);
            tf.value = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);


            if (Qms.isInputed)
            {
                Qmsus.value = FilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(Qms.value, Cm.value);
                Qsus.value = FilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(Qms.value, rho_s.value, Cv.value);
                
            }
            else if (Qmsus.isInputed)
            {
                Qms.value = FilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(Qmsus.value, Cm.value);
                Qsus.value = FilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(Qms.value, rho_s.value, Cv.value);
            }
            else if (Qsus.isInputed)
            {
                Qms.value = FilterMachiningEquations.Eval_Qm_From_Qsus_rhos_Cv(Qsus.value, rho_s.value, Cv.value);
                Qmsus.value = FilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(Qms.value, Cm.value);
            }
            else
                throw NoQInputed();

            if (n.isInputed)
            {
                tc.value = FilterMachiningEquations.Eval_tc_From_n(n.value);
                tr.value = FilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
            }
            else if (tc.isInputed)
            {
                n.value = FilterMachiningEquations.Eval_n_From_tc(tc.value);
                tr.value = FilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
            }
            else if (tr.isInputed)
            {
                tc.value = FilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                n.value = FilterMachiningEquations.Eval_n_From_tc(tc.value);
            }
            else
                throw No_n_tc_tr_Inputed();

            A.value = FilterMachiningEquations.Eval_A_From_Qms_eps_rhos_hc_n(Qms.value, eps.value, rho_s.value, hc.value, n.value);
            sf.value = FilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
            Vf.value = FilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Mf.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
            Vsus.value = FilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Msus.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
            Ms.value = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
            Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
        }

        private Exception No_n_tc_tr_Inputed()
        {
            return new Exception("One of n, tc and tr must be inputed");
        }

        private Exception NoQInputed()
        {
            return new Exception("One of Qms, Qmsus and Qsus must be inputed");
        }

        private void DoCalculationsOptimization()
        {
            fmCalculationVariableParameter A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            fmCalculationVariableParameter sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            fmCalculationVariableParameter hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            fmCalculationVariableParameter kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter rc = variables[fmGlobalParameter.rc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter a = variables[fmGlobalParameter.a] as fmCalculationVariableParameter;
            fmCalculationConstantParameter eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
            fmCalculationConstantParameter eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Cm = variables[fmGlobalParameter.Cm] as fmCalculationConstantParameter;
            fmCalculationConstantParameter ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
            fmCalculationConstantParameter nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
            fmCalculationConstantParameter hce = variables[fmGlobalParameter.hce] as fmCalculationConstantParameter;

            eps.value = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = EpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = FilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = PcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            if (Qms.isInputed)
            {
                Qmsus.value = FilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(Qms.value, Cm.value);
                Qsus.value = FilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(Qms.value, rho_s.value, Cv.value);
            }
            else if (Qmsus.isInputed)
            {
                Qms.value = FilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(Qmsus.value, Cm.value);
                Qsus.value = FilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(Qms.value, rho_s.value, Cv.value);
            }
            else if (Qsus.isInputed)
            {
                Qms.value = FilterMachiningEquations.Eval_Qm_From_Qsus_rhos_Cv(Qsus.value, rho_s.value, Cv.value);
                Qmsus.value = FilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(Qms.value, Cm.value);
            }
            else
                throw NoQInputed();


            if (sf.isInputed)
            {
                hc.value = FilterMachiningEquations.Eval_hc_From_Pc_kappa_Dp_sf_A_rhos_eps_etaf_Qms_hce(Pc.value, kappa.value, Dp.value, sf.value, A.value, rho_s.value, eps.value, eta_f.value, Qms.value, hce.value);
                tf.value = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                tc.value = FilterMachiningEquations.Eval_tc_From_tf_sf(tf.value, sf.value);
                n.value = FilterMachiningEquations.Eval_n_From_tc(tc.value);
                tr.value = FilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
            }
            else if (tr.isInputed)
            {
                tf.value = FilterMachiningEquations.Eval_tf_From_Pc_kappa_Dp_A_rhos_eps_etaf_Qms_hce_tr(Pc.value, kappa.value, Dp.value, A.value, rho_s.value, eps.value, eta_f.value, Qms.value, hce.value, tr.value);

                hc.value = FilterMachiningEquations.Eval_hc_From_hce_Pc_kappa_Dp_tf_etaf(hce.value, Pc.value, kappa.value, Dp.value, tf.value, eta_f.value);
                tc.value = FilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                sf.value = FilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
                n.value = FilterMachiningEquations.Eval_n_From_tc(tc.value);
            }
            else
                throw GenerateExceptionForGroupWithoutInput(sf, tr);

            Vf.value = FilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Mf.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
            Vsus.value = FilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Msus.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
            Ms.value = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
            Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
        }

        private static Exception GenerateExceptionForGroupWithoutInput(params fmCalculationBaseParameter [] parameters)
        {
            string parametersSet = "";
            foreach (fmCalculationBaseParameter p in parameters)
                parametersSet += ", " + p.globalParameter.name;
            parametersSet = "{" + parametersSet.Substring(2) + "}";
            return new Exception("One of " + parametersSet + " must be inputed");
        }
        private void DoSubCalculationsStandart123()
        {
            fmCalculationVariableParameter A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            fmCalculationVariableParameter sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            fmCalculationVariableParameter hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            fmCalculationVariableParameter kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter rc = variables[fmGlobalParameter.rc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter a = variables[fmGlobalParameter.a] as fmCalculationVariableParameter;
            fmCalculationConstantParameter eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
            fmCalculationConstantParameter eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Cm = variables[fmGlobalParameter.Cm] as fmCalculationConstantParameter;
            fmCalculationConstantParameter ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
            fmCalculationConstantParameter nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
            fmCalculationConstantParameter hce = variables[fmGlobalParameter.hce] as fmCalculationConstantParameter;

            eps.value = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = EpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = FilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = PcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            if (calculationOption == FilterMachiningCalculationOption.Standart1)
            {
                if (n.isInputed)
                {
                    tc.value = FilterMachiningEquations.Eval_tc_From_n(n.value);
                }
                else if (tc.isInputed)
                {
                    n.value = FilterMachiningEquations.Eval_n_From_tc(tc.value);
                }
                else 
                    throw GenerateExceptionForGroupWithoutInput(tc, n);

                if (sf.isInputed)
                {
                    tf.value = FilterMachiningEquations.Eval_tf_From_sf_tc(sf.value, tc.value);
                    tr.value = FilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
                }
                else if (tr.isInputed)
                {
                    tf.value = FilterMachiningEquations.Eval_tf_From_tc_tr(tc.value, tr.value);
                    sf.value = FilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
                }
                else 
                    throw GenerateExceptionForGroupWithoutInput(tf, sf);
            }
            else if (calculationOption == FilterMachiningCalculationOption.Standart2)
            {
                if (sf.isInputed)
                {
                    tc.value = FilterMachiningEquations.Eval_tc_From_tf_sf(tf.value, sf.value);
                    tr.value = FilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
                }
                else if (tr.isInputed)
                {
                    tc.value = FilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                    sf.value = FilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
                }
                else
                    throw GenerateExceptionForGroupWithoutInput(sf, tr);

                n.value = FilterMachiningEquations.Eval_n_From_tc(tc.value);
            }
            else if (calculationOption == FilterMachiningCalculationOption.Standart3)
            {
                if (n.isInputed)
                {
                    tc.value = FilterMachiningEquations.Eval_tc_From_n(n.value);
                    tr.value = FilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
                }
                else if (tc.isInputed)
                {
                    n.value = FilterMachiningEquations.Eval_n_From_tc(tc.value);
                    tr.value = FilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
                }
                else if (tr.isInputed)
                {
                    tc.value = FilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                    n.value = FilterMachiningEquations.Eval_n_From_tc(tc.value);
                }

                sf.value = FilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
            }

            hc.value = FilterMachiningEquations.Eval_hc_From_hce_Pc_kappa_Dp_tf_etaf(hce.value, Pc.value, kappa.value,
                                                                                     Dp.value, tf.value, eta_f.value);
            Vf.value = FilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Mf.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
            Vsus.value = FilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Msus.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
            Ms.value = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
            Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
        }
        private void DoSubCalculationsStandart456()
        {
            if (calculationOption == FilterMachiningCalculationOption.Standart4)
            {
                fmCalculationVariableParameter A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
fmCalculationVariableParameter Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
fmCalculationVariableParameter sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
fmCalculationVariableParameter n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
fmCalculationVariableParameter tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
fmCalculationVariableParameter tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
fmCalculationVariableParameter tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
fmCalculationVariableParameter hc_over_tf = variables[fmGlobalParameter.hc_over_tf] as fmCalculationVariableParameter;
fmCalculationVariableParameter dhc_over_dt = variables[fmGlobalParameter.dhc_over_dt] as fmCalculationVariableParameter;
fmCalculationVariableParameter hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qf_d = variables[fmGlobalParameter.Qf_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qs_d = variables[fmGlobalParameter.Qs_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qc_d = variables[fmGlobalParameter.Qc_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qsus_d = variables[fmGlobalParameter.Qsus_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qmsus_d = variables[fmGlobalParameter.Qmsus_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qms_d = variables[fmGlobalParameter.Qms_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qmf_d = variables[fmGlobalParameter.Qmf_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;
fmCalculationVariableParameter Qmc_d = variables[fmGlobalParameter.Qmc_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter qf = variables[fmGlobalParameter.qf] as fmCalculationVariableParameter;
fmCalculationVariableParameter qf_d = variables[fmGlobalParameter.qf_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter qs = variables[fmGlobalParameter.qs] as fmCalculationVariableParameter;
fmCalculationVariableParameter qs_d = variables[fmGlobalParameter.qs_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter qc = variables[fmGlobalParameter.qc] as fmCalculationVariableParameter;
fmCalculationVariableParameter qc_d = variables[fmGlobalParameter.qc_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter qsus = variables[fmGlobalParameter.qsus] as fmCalculationVariableParameter;
fmCalculationVariableParameter qsus_d = variables[fmGlobalParameter.qsus_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter qmsus = variables[fmGlobalParameter.qmsus] as fmCalculationVariableParameter;
fmCalculationVariableParameter qmsus_d = variables[fmGlobalParameter.qmsus_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter qms = variables[fmGlobalParameter.qms] as fmCalculationVariableParameter;
fmCalculationVariableParameter qms_d = variables[fmGlobalParameter.qms_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter qmf = variables[fmGlobalParameter.qmf] as fmCalculationVariableParameter;
fmCalculationVariableParameter qmf_d = variables[fmGlobalParameter.qmf_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter qmc = variables[fmGlobalParameter.qmc] as fmCalculationVariableParameter;
fmCalculationVariableParameter qmc_d = variables[fmGlobalParameter.qmc_d] as fmCalculationVariableParameter;
fmCalculationVariableParameter Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
fmCalculationVariableParameter Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
fmCalculationVariableParameter Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
fmCalculationVariableParameter mf = variables[fmGlobalParameter.mf] as fmCalculationVariableParameter;
fmCalculationVariableParameter vf = variables[fmGlobalParameter.vf] as fmCalculationVariableParameter;
fmCalculationVariableParameter ms = variables[fmGlobalParameter.ms] as fmCalculationVariableParameter;
fmCalculationVariableParameter vs = variables[fmGlobalParameter.vs] as fmCalculationVariableParameter;
fmCalculationVariableParameter msus = variables[fmGlobalParameter.msus] as fmCalculationVariableParameter;
fmCalculationVariableParameter vsus = variables[fmGlobalParameter.vsus] as fmCalculationVariableParameter;
fmCalculationVariableParameter mc = variables[fmGlobalParameter.mc] as fmCalculationVariableParameter;
fmCalculationVariableParameter vc = variables[fmGlobalParameter.vc] as fmCalculationVariableParameter;
fmCalculationVariableParameter Vc = variables[fmGlobalParameter.Vc] as fmCalculationVariableParameter;
fmCalculationVariableParameter Mc = variables[fmGlobalParameter.Mc] as fmCalculationVariableParameter;
fmCalculationVariableParameter Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
fmCalculationVariableParameter Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
fmCalculationVariableParameter Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
fmCalculationVariableParameter eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
fmCalculationVariableParameter kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
fmCalculationVariableParameter Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
fmCalculationVariableParameter rc = variables[fmGlobalParameter.rc] as fmCalculationVariableParameter;
fmCalculationVariableParameter a = variables[fmGlobalParameter.a] as fmCalculationVariableParameter;
fmCalculationConstantParameter eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
fmCalculationConstantParameter kappa0 = variables[fmGlobalParameter.kappa0] as fmCalculationConstantParameter;
fmCalculationConstantParameter Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
fmCalculationConstantParameter eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
fmCalculationConstantParameter rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
fmCalculationConstantParameter rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
fmCalculationConstantParameter rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
fmCalculationConstantParameter Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
fmCalculationConstantParameter Cm = variables[fmGlobalParameter.Cm] as fmCalculationConstantParameter;
fmCalculationConstantParameter ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
fmCalculationConstantParameter nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
fmCalculationConstantParameter hce = variables[fmGlobalParameter.hce] as fmCalculationConstantParameter;

                DoSubCalculationsStandart4_sf_tr_n_tc_tf();

                if (hc.isInputed)
                {
                    Dp.value = FilterMachiningEquations.Eval_Dp_From_etaf_Cv_Pc0_nc_eps0_ne_hc_hce_tf(eta_f.value, Cv.value, Pc0.value, nc.value, eps0.value, ne.value, hc.value, hce.value, tf.value);
                    eps.value = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
                    kappa.value = EpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
                    Vf.value = FilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Mf.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
                    Vsus.value = FilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Msus.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
                    Ms.value = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Vf.isInputed)
                {
                    Mf.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
                    DoSubCalculationsStandart4_Dp_eps_kappa_hc_MVsus_From_MVf();
                    Ms.value = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Mf.isInputed)
                {
                    Vf.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Mf.value);
                    DoSubCalculationsStandart4_Dp_eps_kappa_hc_MVsus_From_MVf();
                    Ms.value = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Vsus.isInputed)
                {
                    Msus.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
                    DoSubCalculationsStandart4_Dp_eps_kappa_hc_MVf_From_MVsus();
                    Ms.value = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Msus.isInputed)
                {
                    Vsus.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                    DoSubCalculationsStandart4_Dp_eps_kappa_hc_MVf_From_MVsus();
                    Ms.value = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Ms.isInputed)
                {
                    Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                    Msus.value = FilterMachiningEquations.Eval_Msus_From_Ms_Cm(Ms.value, Cm.value);
                    Vsus.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                    DoSubCalculationsStandart4_Dp_eps_kappa_hc_MVf_From_MVsus();
                }
                else
                    throw GenerateExceptionForGroupWithoutInput(hc, Vf, Mf, Vsus, Msus, Vs, Ms);

                Pc.value = FilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
                rc.value = PcrcaEquations.Eval_rc_From_Pc(Pc.value);
                a.value = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);
            }
        }


        private void DoSubCalculationsStandart4_Dp_eps_kappa_hc_MVf_From_MVsus()
        {
            fmCalculationVariableParameter A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            fmCalculationVariableParameter kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            fmCalculationConstantParameter eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
            fmCalculationConstantParameter eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            fmCalculationConstantParameter ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
            fmCalculationConstantParameter nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
            fmCalculationConstantParameter hce = variables[fmGlobalParameter.hce] as fmCalculationConstantParameter;

            Dp.value = FilterMachiningEquations.Eval_Dp_From_nc_ne_etaf_A_tf_Cv_eps0_Pc0_hce_Vsus(nc.value, ne.value, eta_f.value, A.value, tf.value, Cv.value, eps0.value, Pc0.value, hce.value, Vsus.value);
            eps.value = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = EpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            hc.value = FilterMachiningEquations.Eval_hc_From_A_Vsus_kappa(A.value, Vsus.value, kappa.value);
            Vf.value = FilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Mf.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
        }

        private void DoSubCalculationsStandart4_Dp_eps_kappa_hc_MVsus_From_MVf()
        {
            fmCalculationVariableParameter A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            fmCalculationVariableParameter kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            fmCalculationConstantParameter eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
            fmCalculationConstantParameter eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            fmCalculationConstantParameter ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
            fmCalculationConstantParameter nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
            fmCalculationConstantParameter hce = variables[fmGlobalParameter.hce] as fmCalculationConstantParameter;

            Dp.value = FilterMachiningEquations.Eval_Dp_From_nc_ne_etaf_A_tf_Cv_eps0_Pc0_hce_Vf(nc.value, ne.value, eta_f.value, A.value, tf.value, Cv.value, eps0.value, Pc0.value, hce.value, Vf.value);
            eps.value = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = EpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            hc.value = FilterMachiningEquations.Eval_hc_From_A_Vf_kappa(A.value, Vf.value, kappa.value);
            Vsus.value = FilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Msus.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
        }

        private void DoSubCalculationsStandart4_sf_tr_n_tc_tf()
        {
            fmCalculationVariableParameter sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            
            if (n.isInputed)
            {
                tc.value = FilterMachiningEquations.Eval_tc_From_n(n.value);
            }
            else if (tc.isInputed)
            {
                n.value = FilterMachiningEquations.Eval_n_From_tc(tc.value);
            }
            else
                throw GenerateExceptionForGroupWithoutInput(n, tc);

            if (sf.isInputed)
            {
                tf.value = FilterMachiningEquations.Eval_tf_From_sf_tc(sf.value, tc.value);
                tr.value = FilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
            }
            else if (tr.isInputed)
            {
                tf.value = FilterMachiningEquations.Eval_tf_From_tc_tr(tc.value, tr.value);
                sf.value = FilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
            }
            else
                throw GenerateExceptionForGroupWithoutInput(sf, tf, tr);
        }

        private void DoSubCalculationsStandart78()
        {
            fmCalculationVariableParameter A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            fmCalculationVariableParameter sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            fmCalculationVariableParameter hc_over_tf =
                variables[fmGlobalParameter.hc_over_tf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter dhc_over_dt =
                variables[fmGlobalParameter.dhc_over_dt] as fmCalculationVariableParameter;
            fmCalculationVariableParameter hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qf_d = variables[fmGlobalParameter.Qf_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qs_d = variables[fmGlobalParameter.Qs_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qc_d = variables[fmGlobalParameter.Qc_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qsus_d =
                variables[fmGlobalParameter.Qsus_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmsus_d =
                variables[fmGlobalParameter.Qmsus_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qms_d = variables[fmGlobalParameter.Qms_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmf_d = variables[fmGlobalParameter.Qmf_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmc_d = variables[fmGlobalParameter.Qmc_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qf = variables[fmGlobalParameter.qf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qf_d = variables[fmGlobalParameter.qf_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qs = variables[fmGlobalParameter.qs] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qs_d = variables[fmGlobalParameter.qs_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qc = variables[fmGlobalParameter.qc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qc_d = variables[fmGlobalParameter.qc_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qsus = variables[fmGlobalParameter.qsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qsus_d =
                variables[fmGlobalParameter.qsus_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qmsus = variables[fmGlobalParameter.qmsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qmsus_d =
                variables[fmGlobalParameter.qmsus_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qms = variables[fmGlobalParameter.qms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qms_d = variables[fmGlobalParameter.qms_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qmf = variables[fmGlobalParameter.qmf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qmf_d = variables[fmGlobalParameter.qmf_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qmc = variables[fmGlobalParameter.qmc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter qmc_d = variables[fmGlobalParameter.qmc_d] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter mf = variables[fmGlobalParameter.mf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter vf = variables[fmGlobalParameter.vf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter ms = variables[fmGlobalParameter.ms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter vs = variables[fmGlobalParameter.vs] as fmCalculationVariableParameter;
            fmCalculationVariableParameter msus = variables[fmGlobalParameter.msus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter vsus = variables[fmGlobalParameter.vsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter mc = variables[fmGlobalParameter.mc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter vc = variables[fmGlobalParameter.vc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vc = variables[fmGlobalParameter.Vc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Mc = variables[fmGlobalParameter.Mc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            fmCalculationVariableParameter kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter rc = variables[fmGlobalParameter.rc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter a = variables[fmGlobalParameter.a] as fmCalculationVariableParameter;
            fmCalculationConstantParameter eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            fmCalculationConstantParameter kappa0 =
                variables[fmGlobalParameter.kappa0] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
            fmCalculationConstantParameter eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
            fmCalculationConstantParameter rho_sus =
                variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            fmCalculationConstantParameter Cm = variables[fmGlobalParameter.Cm] as fmCalculationConstantParameter;
            fmCalculationConstantParameter ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
            fmCalculationConstantParameter nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
            fmCalculationConstantParameter hce = variables[fmGlobalParameter.hce] as fmCalculationConstantParameter;

            eps.value = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = EpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = FilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = PcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            if (calculationOption == FilterMachiningCalculationOption.Standart7
                || calculationOption == FilterMachiningCalculationOption.Standart8)
            {
                if (hc.isInputed)
                {
                    Vf.value = FilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Mf.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
                    Vsus.value = FilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Msus.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
                    Ms.value = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Vf.isInputed)
                {
                    hc.value = FilterMachiningEquations.Eval_hc_From_A_Vf_kappa(A.value, Vf.value, kappa.value);
                    Mf.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
                    Vsus.value = FilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Msus.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
                    Ms.value = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Mf.isInputed)
                {
                    Vf.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Mf.value);
                    hc.value = FilterMachiningEquations.Eval_hc_From_A_Vf_kappa(A.value, Vf.value, kappa.value);
                    Vsus.value = FilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Msus.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
                    Ms.value = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Vsus.isInputed)
                {
                    Msus.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
                    hc.value = FilterMachiningEquations.Eval_hc_From_A_Vsus_kappa(A.value, Vsus.value, kappa.value);
                    Vf.value = FilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Mf.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
                    Ms.value = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Msus.isInputed)
                {
                    Vsus.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                    hc.value = FilterMachiningEquations.Eval_hc_From_A_Vsus_kappa(A.value, Vsus.value, kappa.value);
                    Vf.value = FilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Mf.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
                    Ms.value = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Ms.isInputed)
                {
                    Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                    Msus.value = FilterMachiningEquations.Eval_Msus_From_Ms_Cm(Ms.value, Cm.value);
                    Vsus.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                    hc.value = FilterMachiningEquations.Eval_hc_From_A_Vsus_kappa(A.value, Vsus.value, kappa.value);
                    Vf.value = FilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Mf.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
                }
                else
                    throw GenerateExceptionForGroupWithoutInput(hc, Vf, Mf, Vsus, Msus, Ms);
            }

            if (calculationOption == FilterMachiningCalculationOption.Standart7)
            {
                tf.value = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                tc.value = FilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                n.value = FilterMachiningEquations.Eval_n_From_tc(tc.value);
                    
                if (sf.isInputed)
                {
                    tr.value = FilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
                }
                else if (tr.isInputed)
                {
                    sf.value = FilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
                }
                else
                    throw GenerateExceptionForGroupWithoutInput(sf, tr);
            }

            if (calculationOption == FilterMachiningCalculationOption.Standart8)
            {
                if (n.isInputed)
                {
                    tc.value = FilterMachiningEquations.Eval_tc_From_n(n.value);
                    tf.value = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                    sf.value = FilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
                    tr.value = FilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
                }
                else if (tc.isInputed)
                {
                    n.value = FilterMachiningEquations.Eval_n_From_tc(tc.value);
                    tf.value = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                    sf.value = FilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
                    tr.value = FilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
                }
                else if (tr.isInputed)
                {
                    tf.value = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                    tc.value = FilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                    n.value = FilterMachiningEquations.Eval_n_From_tc(tc.value);
                    sf.value = FilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
                }
                else
                    throw GenerateExceptionForGroupWithoutInput(n, tc, tr);
            }
        }
    }
}
