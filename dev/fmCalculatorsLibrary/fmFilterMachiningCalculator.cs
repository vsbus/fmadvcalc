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
            [Description("3: A, Dp, (n/tc/tr), tf")]
            Standart3,

            [Description("4: A, (hc/Vf/Mf/Vsus/Msus/Ms), (sf/tr), (n/tc)")]
            Standart4,

            [Description("8: A, Dp, (hc/Vf/Mf/Vsus/Msus/Ms), (n/tc/tr)")]
            Standart8,

            // Design -- In this case we have always the (Qsus, Qmsus, Qms) as input 
            // and the filter area A is calculated 
            [Description("1: Q, Dp, hc, (n/tc/tr)")]
            Design1,
            //Design2,    // Q, Dp, hc, (sf/tr)           -- input 
            //Design3,    // Q, sf, (n/tc/tr), hc       -- input 
            [Description("global: (A, Q), Dp, (sf, sr, tr), (hc, V, M, tf, n, tc)")]
            StandartAndDesignGlobal,

            // Optimization -- In this case we have always the filter 
            // area A and the (Qsus, Qmsus, Qms) as input
            [Description("1: A, Q, Dp, (sf/tr)")]
            Optimization1
            //Optimization2,  // A, Q, hc, (sf/tr)           -- input
            //Optimization3   // A, Q, (n/tc), (sf/tr)       -- input
        }

        public FilterMachiningCalculationOption calculationOption = FilterMachiningCalculationOption.StandartAndDesignGlobal;

        public fmFilterMachiningCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }

        private static bool IsStandartKindOption(FilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == FilterMachiningCalculationOption.Standart3
              || calculationOption == FilterMachiningCalculationOption.Standart4
              || calculationOption == FilterMachiningCalculationOption.Standart8
              || calculationOption == FilterMachiningCalculationOption.StandartAndDesignGlobal;
        }

        private static bool IsDesignKindOption(FilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == FilterMachiningCalculationOption.Design1
                || calculationOption == FilterMachiningCalculationOption.StandartAndDesignGlobal;
        }

        private static bool IsOptimizationKindOption(FilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == FilterMachiningCalculationOption.Optimization1;
        }

        private static bool IsStandartSubKind1DpOption(FilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == FilterMachiningCalculationOption.Standart3;
        }

        private static bool IsStandartSubKind2hcOption(FilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == FilterMachiningCalculationOption.Standart4;
        }

        private static bool IsStandartSubKind3DphcOption(FilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == FilterMachiningCalculationOption.Standart8;
        }

        public void DoCalculationsLimitsClue()
        {
            if (calculationOption == FilterMachiningCalculationOption.StandartAndDesignGlobal)
            {
                DoCalculationsStandartAndDesignGlobal_OnlyLimitClueParams();
            }
            else
            {
                DoCalculations();
            }
        }

        private void DoCalculationsStandartAndDesignGlobal_OnlyLimitClueParams()
        {
            fmCalculationVariableParameter A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            fmCalculationVariableParameter sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter sr = variables[fmGlobalParameter.sr] as fmCalculationVariableParameter;
            fmCalculationVariableParameter n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            fmCalculationVariableParameter hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
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

            fmCalculationVariableParameter Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;

            fmCalculationBaseParameter eps = variables[fmGlobalParameter.eps];
            fmCalculationBaseParameter kappa = variables[fmGlobalParameter.kappa];
            fmCalculationBaseParameter Pc = variables[fmGlobalParameter.Pc];
            fmCalculationBaseParameter rc = variables[fmGlobalParameter.rc];
            fmCalculationBaseParameter a = variables[fmGlobalParameter.a];

            fmCalculationBaseParameter eps0 = variables[fmGlobalParameter.eps0];
            fmCalculationBaseParameter kappa0 = variables[fmGlobalParameter.kappa0];
            fmCalculationBaseParameter Pc0 = variables[fmGlobalParameter.Pc0];
            fmCalculationBaseParameter eta_f = variables[fmGlobalParameter.eta_f];
            fmCalculationBaseParameter rho_f = variables[fmGlobalParameter.rho_f];
            fmCalculationBaseParameter rho_s = variables[fmGlobalParameter.rho_s];
            fmCalculationBaseParameter rho_sus = variables[fmGlobalParameter.rho_sus];
            fmCalculationBaseParameter Cv = variables[fmGlobalParameter.Cv];
            fmCalculationBaseParameter Cm = variables[fmGlobalParameter.Cm];
            fmCalculationBaseParameter ne = variables[fmGlobalParameter.ne];
            fmCalculationBaseParameter nc = variables[fmGlobalParameter.nc];
            fmCalculationBaseParameter hce = variables[fmGlobalParameter.hce];

            eps.value = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = EpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = FilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = PcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            bool isKnown_A = A.isInputed;
            bool isKnown_Dp = Dp.isInputed;
            bool isKnown_sf = sf.isInputed;
            bool isKnown_sr = sr.isInputed;
            bool isKnown_n = n.isInputed;
            bool isKnown_tc = tc.isInputed;
            bool isKnown_tf = tf.isInputed;
            bool isKnown_tr = tr.isInputed;
            bool isKnown_hc = hc.isInputed;
            bool isKnown_Vsus = Vsus.isInputed;
            bool isKnown_Mf = Mf.isInputed;
            bool isKnown_Vf = Vf.isInputed;
            bool isKnown_mf = mf.isInputed;
            bool isKnown_vf = vf.isInputed;
            bool isKnown_ms = ms.isInputed;
            bool isKnown_vs = vs.isInputed;
            bool isKnown_msus = msus.isInputed;
            bool isKnown_vsus = vsus.isInputed;
            bool isKnown_mc = mc.isInputed;
            bool isKnown_vc = vc.isInputed;
            bool isKnown_Vc = Vc.isInputed;
            bool isKnown_Mc = Mc.isInputed;
            bool isKnown_Ms = Ms.isInputed;
            bool isKnown_Vs = Vs.isInputed;
            bool isKnown_Msus = Msus.isInputed;
            bool isKnown_Qf = Qf.isInputed;
            bool isKnown_Qs = Qs.isInputed;
            bool isKnown_Qsus = Qsus.isInputed;
            bool isKnown_Qc = Qc.isInputed;
            bool isKnown_Qmf = Qmf.isInputed;
            bool isKnown_Qms = Qms.isInputed;
            bool isKnown_Qmsus = Qmsus.isInputed;
            bool isKnown_Qmc = Qmc.isInputed;

            #region A0
            if (isKnown_A)
            {
                if (isKnown_Msus)
                {
                    msus.value = FilterMachiningEquations.Eval_m_From_M_A(Msus.value, A.value);
                    isKnown_msus = true;
                }

                if (isKnown_Ms)
                {
                    ms.value = FilterMachiningEquations.Eval_m_From_M_A(Ms.value, A.value);
                    isKnown_ms = true;
                }

                if (isKnown_Mc)
                {
                    mc.value = FilterMachiningEquations.Eval_m_From_M_A(Mc.value, A.value);
                    isKnown_mc = true;
                }

                if (isKnown_Mf)
                {
                    mf.value = FilterMachiningEquations.Eval_m_From_M_A(Mf.value, A.value);
                    isKnown_mf = true;
                }

                if (isKnown_Vsus)
                {
                    vsus.value = FilterMachiningEquations.Eval_v_From_V_A(Vsus.value, A.value);
                    isKnown_vsus = true;
                }

                if (isKnown_Vs)
                {
                    vs.value = FilterMachiningEquations.Eval_v_From_V_A(Vs.value, A.value);
                    isKnown_vs = true;
                }

                if (isKnown_Vc)
                {
                    vc.value = FilterMachiningEquations.Eval_v_From_V_A(Vc.value, A.value);
                    isKnown_vc = true;
                }

                if (isKnown_Vf)
                {
                    vf.value = FilterMachiningEquations.Eval_v_From_V_A(Vf.value, A.value);
                    isKnown_vf = true;
                }
            }
            #endregion
            #region A
            if (isKnown_ms)
            {
                vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, ms.value);
                isKnown_vs = true;
            }

            if (isKnown_vs)
            {
                vsus.value = FilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_vsus = true;
            }

            if (isKnown_msus)
            {
                vsus.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, msus.value);
                isKnown_vsus = true;
            }

            if (isKnown_vsus)
            {
                vf.value = FilterMachiningEquations.Eval_vf_From_vsus_kappa(vsus.value, kappa.value);
                isKnown_vf = true;
            }

            if (isKnown_mc)
            {
                vf.value = FilterMachiningEquations.Eval_vf_From_mc_kappa_rho(mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_vf = true;
            }

            if (isKnown_mf)
            {
                vf.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, mf.value);
                isKnown_vf = true;
            }

            if (isKnown_vf)
            {
                vc.value = FilterMachiningEquations.Eval_vc_From_vf_kappa(vf.value, kappa.value);
                isKnown_vc = true;
            }

            if (isKnown_vc)
            {
                hc.value = vc.value;
                isKnown_hc = true;
            }

            if (isKnown_hc)
            {
                tf.value = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                isKnown_tf = true;
            }
            #endregion
            #region D
            if (isKnown_Ms)
            {
                Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                isKnown_Vs = true;
            }

            if (isKnown_Vs)
            {
                Vsus.value = FilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Msus)
            {
                Vsus.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Vsus)
            {
                Vf.value = FilterMachiningEquations.Eval_vf_From_vsus_kappa(Vsus.value, kappa.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mf)
            {
                Vf.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Mf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mc)
            {
                Vf.value = FilterMachiningEquations.Eval_vf_From_mc_kappa_rho(Mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Vf = true;
            }

            if (isKnown_Vf)
            {
                Vc.value = FilterMachiningEquations.Eval_vc_From_vf_kappa(Vf.value, kappa.value);
                isKnown_Vc = true;
            }

            if (isKnown_Vc && !isKnown_Vf)
            {
                Vf.value = FilterMachiningEquations.Eval_vf_From_vc_kappa(Vc.value, kappa.value);
                isKnown_Vf = true;
            }
            #endregion
            #region E
            if (isKnown_Qms)
            {
                Qs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
                isKnown_Qs = true;
            }

            if (isKnown_Qmsus)
            {
                Qsus.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Qmsus.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qs)
            {
                Qsus.value = FilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Qs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qsus)
            {
                Qc.value = FilterMachiningEquations.Eval_vc_From_vsus_kappa(Qsus.value, kappa.value);
                isKnown_Qc = true;
            }

            if (isKnown_Qmc)
            {
                Qc.value = FilterMachiningEquations.Eval_vc_From_mc_kappa_rho(Qmc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Qc = true;
            }
            #endregion
            #region F
            if (isKnown_Qmf)
            {
                Qf.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Qmf.value);
                isKnown_Qf = true;
            }
            #endregion
            #region G
            if (isKnown_Qc && isKnown_Vc)
            {
                tc.value = FilterMachiningEquations.Eval_t_From_Q_V(Qc.value, Vc.value);
                isKnown_tc = true;
            }

            if (isKnown_Qf && isKnown_Vf)
            {
                tf.value = FilterMachiningEquations.Eval_t_From_Q_V(Qf.value, Vf.value);
                isKnown_tf = true;
            }
            #endregion
            #region B
            if (isKnown_tf)
            {
                if (isKnown_sf)
                {
                    tc.value = FilterMachiningEquations.Eval_tc_From_tf_sf(tf.value, sf.value);
                }
                else if (isKnown_tr)
                {
                    tc.value = FilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                }
                else if (isKnown_sr)
                {
                    tc.value = FilterMachiningEquations.Eval_tc_From_sr_tf(sr.value, tf.value);
                }
                else
                {
                    GenerateExceptionForGroupWithoutInput(sf, tr, sr);
                }
                isKnown_tc = true;
            }
            #endregion
            if (isKnown_n && !isKnown_tc)
            {
                tc.value = FilterMachiningEquations.Eval_tc_From_n(n.value);
                isKnown_tc = true;
            }
            #region C
            if (!isKnown_tc)
            {
                throw new Exception("tc must be known in block C.");
            }

            if (!isKnown_tr && isKnown_sr)
            {
                tr.value = FilterMachiningEquations.Eval_tr_From_sr_tc(sr.value, tc.value);
                isKnown_tr = true;
            }

            if (!isKnown_sf)
            {
                sf.value = FilterMachiningEquations.Eval_sf_From_tr_tc(tr.value, tc.value);
                isKnown_sf = true;
            }
            #endregion

            if (!isKnown_tf) tf.value = FilterMachiningEquations.Eval_tf_From_sf_tc(sf.value, tc.value);
            if (!isKnown_hc) hc.value = FilterMachiningEquations.Eval_hc_From_hce_Pc_kappa_Dp_tf_etaf(hce.value, Pc.value, kappa.value, Dp.value, tf.value, eta_f.value);

            if (!isKnown_vc) vc.value = hc.value;
            if (!isKnown_vf) vf.value = FilterMachiningEquations.Eval_vf_From_vc_kappa(vc.value, kappa.value);

            if (isKnown_Qf && !isKnown_Vf)
            {
                Vf.value = FilterMachiningEquations.Eval_V_From_Q_t(Qf.value, tf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Qc && !isKnown_Vc)
            {
                Vc.value = FilterMachiningEquations.Eval_V_From_Q_t(Qc.value, tc.value);
                isKnown_Vc = true;
            }

            if (!isKnown_A && isKnown_Vf)
            {
                A.value = FilterMachiningEquations.Eval_A_From_V_v(Vf.value, vf.value);
                isKnown_A = true;
            }

            if (!isKnown_A && isKnown_Vc)
            {
                A.value = FilterMachiningEquations.Eval_A_From_V_v(Vc.value, vc.value);
                isKnown_A = true;
            }
        }
        override public void DoCalculations()
        {
            if (calculationOption == FilterMachiningCalculationOption.StandartAndDesignGlobal)
            {
                DoSubCalculationsStandartAndDesignGlobal();
            }
            else
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
                qf.value = FilterMachiningEquations.Eval_q_From_Q_A(Qf.value, A.value);
                qf_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qf_d.value, A.value);
                qsus.value = FilterMachiningEquations.Eval_q_From_Q_A(Qsus.value, A.value);
                qsus_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qsus_d.value, A.value);
                qs.value = FilterMachiningEquations.Eval_q_From_Q_A(Qs.value, A.value);
                qs_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qs_d.value, A.value);
                qc.value = FilterMachiningEquations.Eval_q_From_Q_A(Qc.value, A.value);
                qc_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qc_d.value, A.value);
                qmf.value = FilterMachiningEquations.Eval_q_From_Q_A(Qmf.value, A.value);
                qmf_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qmf_d.value, A.value);
                qmsus.value = FilterMachiningEquations.Eval_q_From_Q_A(Qmsus.value, A.value);
                qmsus_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qmsus_d.value, A.value);
                qms.value = FilterMachiningEquations.Eval_q_From_Q_A(Qms.value, A.value);
                qms_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qms_d.value, A.value);
                qmc.value = FilterMachiningEquations.Eval_q_From_Q_A(Qmc.value, A.value);
                qmc_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qmc_d.value, A.value);
            }
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
            DoSubCalculationsDesign1();
        }

        private void DoSubCalculationsStandartAndDesignGlobal()
        {
            fmCalculationVariableParameter A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            fmCalculationVariableParameter sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter sr = variables[fmGlobalParameter.sr] as fmCalculationVariableParameter;
            fmCalculationVariableParameter n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            fmCalculationVariableParameter hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
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

            fmCalculationVariableParameter Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            fmCalculationVariableParameter Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;
            
            fmCalculationBaseParameter hc_over_tf = variables[fmGlobalParameter.hc_over_tf];
            fmCalculationBaseParameter dhc_over_dt = variables[fmGlobalParameter.dhc_over_dt];
            fmCalculationBaseParameter Qf_d = variables[fmGlobalParameter.Qf_d];
            fmCalculationBaseParameter Qs_d = variables[fmGlobalParameter.Qs_d];
            fmCalculationBaseParameter Qc_d = variables[fmGlobalParameter.Qc_d];
            fmCalculationBaseParameter Qsus_d = variables[fmGlobalParameter.Qsus_d];
            fmCalculationBaseParameter Qmsus_d = variables[fmGlobalParameter.Qmsus_d];
            fmCalculationBaseParameter Qms_d = variables[fmGlobalParameter.Qms_d];
            fmCalculationBaseParameter Qmf_d = variables[fmGlobalParameter.Qmf_d];
            fmCalculationBaseParameter Qmc_d = variables[fmGlobalParameter.Qmc_d];
            fmCalculationBaseParameter qf = variables[fmGlobalParameter.qf];
            fmCalculationBaseParameter qf_d = variables[fmGlobalParameter.qf_d];
            fmCalculationBaseParameter qs = variables[fmGlobalParameter.qs];
            fmCalculationBaseParameter qs_d = variables[fmGlobalParameter.qs_d];
            fmCalculationBaseParameter qc = variables[fmGlobalParameter.qc];
            fmCalculationBaseParameter qc_d = variables[fmGlobalParameter.qc_d];
            fmCalculationBaseParameter qsus = variables[fmGlobalParameter.qsus];
            fmCalculationBaseParameter qsus_d = variables[fmGlobalParameter.qsus_d];
            fmCalculationBaseParameter qmsus = variables[fmGlobalParameter.qmsus];
            fmCalculationBaseParameter qmsus_d = variables[fmGlobalParameter.qmsus_d];
            fmCalculationBaseParameter qms = variables[fmGlobalParameter.qms];
            fmCalculationBaseParameter qms_d = variables[fmGlobalParameter.qms_d];
            fmCalculationBaseParameter qmf = variables[fmGlobalParameter.qmf];
            fmCalculationBaseParameter qmf_d = variables[fmGlobalParameter.qmf_d];
            fmCalculationBaseParameter qmc = variables[fmGlobalParameter.qmc];
            fmCalculationBaseParameter qmc_d = variables[fmGlobalParameter.qmc_d];

            fmCalculationBaseParameter eps = variables[fmGlobalParameter.eps];
            fmCalculationBaseParameter kappa = variables[fmGlobalParameter.kappa];
            fmCalculationBaseParameter Pc = variables[fmGlobalParameter.Pc];
            fmCalculationBaseParameter rc = variables[fmGlobalParameter.rc];
            fmCalculationBaseParameter a = variables[fmGlobalParameter.a];

            fmCalculationBaseParameter eps0 = variables[fmGlobalParameter.eps0];
            fmCalculationBaseParameter kappa0 = variables[fmGlobalParameter.kappa0];
            fmCalculationBaseParameter Pc0 = variables[fmGlobalParameter.Pc0];
            fmCalculationBaseParameter eta_f = variables[fmGlobalParameter.eta_f];
            fmCalculationBaseParameter rho_f = variables[fmGlobalParameter.rho_f];
            fmCalculationBaseParameter rho_s = variables[fmGlobalParameter.rho_s];
            fmCalculationBaseParameter rho_sus = variables[fmGlobalParameter.rho_sus];
            fmCalculationBaseParameter Cv = variables[fmGlobalParameter.Cv];
            fmCalculationBaseParameter Cm = variables[fmGlobalParameter.Cm];
            fmCalculationBaseParameter ne = variables[fmGlobalParameter.ne];
            fmCalculationBaseParameter nc = variables[fmGlobalParameter.nc];
            fmCalculationBaseParameter hce = variables[fmGlobalParameter.hce];

            eps.value = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = EpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = FilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = PcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            bool isKnown_A = A.isInputed;
            bool isKnown_Dp = Dp.isInputed;
            bool isKnown_sf = sf.isInputed;
            bool isKnown_sr = sr.isInputed;
            bool isKnown_n = n.isInputed;
            bool isKnown_tc = tc.isInputed;
            bool isKnown_tf = tf.isInputed;
            bool isKnown_tr = tr.isInputed;
            bool isKnown_hc = hc.isInputed;
            bool isKnown_Vsus = Vsus.isInputed;
            bool isKnown_Mf = Mf.isInputed;
            bool isKnown_Vf = Vf.isInputed;
            bool isKnown_mf = mf.isInputed;
            bool isKnown_vf = vf.isInputed;
            bool isKnown_ms = ms.isInputed;
            bool isKnown_vs = vs.isInputed;
            bool isKnown_msus = msus.isInputed;
            bool isKnown_vsus = vsus.isInputed;
            bool isKnown_mc = mc.isInputed;
            bool isKnown_vc = vc.isInputed;
            bool isKnown_Vc = Vc.isInputed;
            bool isKnown_Mc = Mc.isInputed;
            bool isKnown_Ms = Ms.isInputed;
            bool isKnown_Vs = Vs.isInputed;
            bool isKnown_Msus = Msus.isInputed;
            bool isKnown_Qf = Qf.isInputed;
            bool isKnown_Qs = Qs.isInputed;
            bool isKnown_Qsus = Qsus.isInputed;
            bool isKnown_Qc = Qc.isInputed;
            bool isKnown_Qmf = Qmf.isInputed;
            bool isKnown_Qms = Qms.isInputed;
            bool isKnown_Qmsus = Qmsus.isInputed;
            bool isKnown_Qmc = Qmc.isInputed;

            #region A0
            if (isKnown_A)
            {
                if (isKnown_Msus)
                {
                    msus.value = FilterMachiningEquations.Eval_m_From_M_A(Msus.value, A.value);
                    isKnown_msus = true;
                }

                if (isKnown_Ms)
                {
                    ms.value = FilterMachiningEquations.Eval_m_From_M_A(Ms.value, A.value);
                    isKnown_ms = true;
                }

                if (isKnown_Mc)
                {
                    mc.value = FilterMachiningEquations.Eval_m_From_M_A(Mc.value, A.value);
                    isKnown_mc = true;
                }

                if (isKnown_Mf)
                {
                    mf.value = FilterMachiningEquations.Eval_m_From_M_A(Mf.value, A.value);
                    isKnown_mf = true;
                }

                if (isKnown_Vsus)
                {
                    vsus.value = FilterMachiningEquations.Eval_v_From_V_A(Vsus.value, A.value);
                    isKnown_vsus = true;
                }

                if (isKnown_Vs)
                {
                    vs.value = FilterMachiningEquations.Eval_v_From_V_A(Vs.value, A.value);
                    isKnown_vs = true;
                }

                if (isKnown_Vc)
                {
                    vc.value = FilterMachiningEquations.Eval_v_From_V_A(Vc.value, A.value);
                    isKnown_vc = true;
                }

                if (isKnown_Vf)
                {
                    vf.value = FilterMachiningEquations.Eval_v_From_V_A(Vf.value, A.value);
                    isKnown_vf = true;
                }
            }
            #endregion
            #region A
            if (isKnown_ms)
            {
                vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, ms.value);
                isKnown_vs = true;
            }

            if (isKnown_vs)
            {
                vsus.value = FilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_vsus = true;
            }

            if (isKnown_msus)
            {
                vsus.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, msus.value);
                isKnown_vsus = true;
            }

            if (isKnown_vsus)
            {
                vf.value = FilterMachiningEquations.Eval_vf_From_vsus_kappa(vsus.value, kappa.value);
                isKnown_vf = true;
            }

            if (isKnown_mc)
            {
                vf.value = FilterMachiningEquations.Eval_vf_From_mc_kappa_rho(mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_vf = true;
            }

            if (isKnown_mf)
            {
                vf.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, mf.value);
                isKnown_vf = true;
            }

            if (isKnown_vf)
            {
                vc.value = FilterMachiningEquations.Eval_vc_From_vf_kappa(vf.value, kappa.value);
                isKnown_vc = true;
            }

            if (isKnown_vc)
            {
                hc.value = vc.value;
                isKnown_hc = true;
            }

            if (isKnown_hc)
            {
                tf.value = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                isKnown_tf = true;
            }
            #endregion
            #region D
            if (isKnown_Ms)
            {
                Vs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                isKnown_Vs = true;
            }
            
            if (isKnown_Vs)
            {
                Vsus.value = FilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Vsus = true;
            }
            
            if (isKnown_Msus)
            {
                Vsus.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Vsus)
            {
                Vf.value = FilterMachiningEquations.Eval_vf_From_vsus_kappa(Vsus.value, kappa.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mf)
            {
                Vf.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Mf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mc)
            {
                Vf.value = FilterMachiningEquations.Eval_vf_From_mc_kappa_rho(Mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Vf = true;
            }

            if (isKnown_Vf)
            {
                Vc.value = FilterMachiningEquations.Eval_vc_From_vf_kappa(Vf.value, kappa.value);
                isKnown_Vc = true;
            }

            if (isKnown_Vc && !isKnown_Vf)
            {
                Vf.value = FilterMachiningEquations.Eval_vf_From_vc_kappa(Vc.value, kappa.value);
                isKnown_Vf = true;
            }
            #endregion
            #region E
            if (isKnown_Qms)
            {
                Qs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
                isKnown_Qs = true;
            }
            
            if (isKnown_Qmsus)
            {
                Qsus.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Qmsus.value);
                isKnown_Qsus = true;
            }
            
            if (isKnown_Qs)
            {
                Qsus.value = FilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Qs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qsus)
            {
                Qc.value = FilterMachiningEquations.Eval_vc_From_vsus_kappa(Qsus.value, kappa.value);
                isKnown_Qc = true;
            }

            if (isKnown_Qmc)
            {
                Qc.value = FilterMachiningEquations.Eval_vc_From_mc_kappa_rho(Qmc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Qc = true;
            }
            #endregion
            #region F
            if (isKnown_Qmf)
            {
                Qf.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Qmf.value);
                isKnown_Qf = true;
            }
            #endregion
            #region G
            if (isKnown_Qc && isKnown_Vc)
            {
                tc.value = FilterMachiningEquations.Eval_t_From_Q_V(Qc.value, Vc.value);
                isKnown_tc = true;
            }

            if (isKnown_Qf && isKnown_Vf)
            {
                tf.value = FilterMachiningEquations.Eval_t_From_Q_V(Qf.value, Vf.value);
                isKnown_tf = true;
            }
            #endregion
            #region B
            if (isKnown_tf)
            {
                if (isKnown_sf) 
                {
                    tc.value = FilterMachiningEquations.Eval_tc_From_tf_sf(tf.value, sf.value);
                }
                else if (isKnown_tr)
                {
                    tc.value = FilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                }
                else if (isKnown_sr)
                {
                    tc.value = FilterMachiningEquations.Eval_tc_From_sr_tf(sr.value, tf.value);
                }
                else
                {
                    throw new Exception("one of sf/tr must be inputed!");
                }
                isKnown_tc = true;
            }
            #endregion
            if (isKnown_n && !isKnown_tc)
            {
                tc.value = FilterMachiningEquations.Eval_tc_From_n(n.value);
                isKnown_tc = true;
            }
            #region C
            if (!isKnown_tc)
            {
                throw new Exception("tc must be known in block C.");
            }

            if (!isKnown_tr && isKnown_sr)
            {
                tr.value = FilterMachiningEquations.Eval_tr_From_sr_tc(sr.value, tc.value);
                isKnown_tr = true;
            }

            if (!isKnown_sf)
            {
                sf.value = FilterMachiningEquations.Eval_sf_From_tr_tc(tr.value, tc.value);
                isKnown_sf = true;
            }
            #endregion

            if (!isKnown_n) n.value = FilterMachiningEquations.Eval_n_From_tc(tc.value);
            if (!isKnown_tf) tf.value = FilterMachiningEquations.Eval_tf_From_sf_tc(sf.value, tc.value);
            if (!isKnown_tr) tr.value = FilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
            if (!isKnown_sr) sr.value = FilterMachiningEquations.Eval_sr_From_tc_tr(tc.value, tr.value);
            if (!isKnown_hc) hc.value = FilterMachiningEquations.Eval_hc_From_hce_Pc_kappa_Dp_tf_etaf(hce.value, Pc.value, kappa.value, Dp.value, tf.value, eta_f.value);

            if (!isKnown_vc) vc.value = hc.value;
            if (!isKnown_vf) vf.value = FilterMachiningEquations.Eval_vf_From_vc_kappa(vc.value, kappa.value);
            if (!isKnown_vsus) vsus.value = FilterMachiningEquations.Eval_vsus_From_vf_kappa(vf.value, kappa.value);
            if (!isKnown_vs) vs.value = FilterMachiningEquations.Eval_vs_From_vsus_rho_Cm(vsus.value, rho_sus.value, rho_s.value, Cm.value);

            if (!isKnown_mc) mc.value = FilterMachiningEquations.Eval_mc_From_vf_kappa_rho(vf.value, kappa.value, rho_sus.value, rho_f.value);
            if (!isKnown_mf) mf.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, vf.value);
            if (!isKnown_msus) msus.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, vsus.value);
            if (!isKnown_ms) ms.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_s.value, vs.value);

            if (isKnown_Qf && !isKnown_Vf)
            {
                Vf.value = FilterMachiningEquations.Eval_V_From_Q_t(Qf.value, tf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Qc && !isKnown_Vc)
            {
                Vc.value = FilterMachiningEquations.Eval_V_From_Q_t(Qc.value, tc.value);
                isKnown_Vc = true;
            }

            if (!isKnown_A && isKnown_Vf)
            {
                A.value = FilterMachiningEquations.Eval_A_From_V_v(Vf.value, vf.value);
                isKnown_A = true;
            }

            if (!isKnown_A && isKnown_Vc)
            {
                A.value = FilterMachiningEquations.Eval_A_From_V_v(Vc.value, vc.value);
                isKnown_A = true;
            }

            if (!isKnown_Vc) Vc.value = FilterMachiningEquations.Eval_V_From_v_A(vc.value, A.value);
            if (!isKnown_Vf) Vf.value = FilterMachiningEquations.Eval_V_From_v_A(vf.value, A.value);
            if (!isKnown_Vsus) Vsus.value = FilterMachiningEquations.Eval_V_From_v_A(vsus.value, A.value);
            if (!isKnown_Vs) Vs.value = FilterMachiningEquations.Eval_V_From_v_A(vs.value, A.value);

            if (!isKnown_Mc) Mc.value = FilterMachiningEquations.Eval_M_From_m_A(mc.value, A.value);
            if (!isKnown_Mf) Mf.value = FilterMachiningEquations.Eval_M_From_m_A(mf.value, A.value);
            if (!isKnown_Msus) Msus.value = FilterMachiningEquations.Eval_M_From_m_A(msus.value, A.value);
            if (!isKnown_Ms) Ms.value = FilterMachiningEquations.Eval_M_From_m_A(ms.value, A.value);

            if (!isKnown_Qmsus) Qmsus.value = FilterMachiningEquations.Eval_Qmsus_From_Msus_tc(Msus.value, tc.value);
            if (!isKnown_Qms) Qms.value = FilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(Qmsus.value, Cm.value);
            if (!isKnown_Qmf) Qmf.value = FilterMachiningEquations.Eval_Qm_From_M_t(Mf.value, tf.value);
            if (!isKnown_Qmc) Qmc.value = FilterMachiningEquations.Eval_Qm_From_M_t(Mc.value, tc.value);
            
            if (!isKnown_Qsus) Qsus.value = FilterMachiningEquations.Eval_Qsus_From_Vsus_tc(Vsus.value, tc.value);
            if (!isKnown_Qs) Qs.value = FilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value); ;
            if (!isKnown_Qf) Qf.value = FilterMachiningEquations.Eval_Q_From_V_t(Vf.value, tf.value);
            if (!isKnown_Qc) Qc.value = FilterMachiningEquations.Eval_Q_From_V_t(Vc.value, tc.value);
            
            hc_over_tf.value = FilterMachiningEquations.Eval_hc_over_tf_From_hc_tf(hc.value, tf.value);
            dhc_over_dt.value = FilterMachiningEquations.Eval_dhc_over_dt_From_kappa_Dp_Pc_eta_hc_hce(kappa.value, Dp.value, Pc.value, eta_f.value, hc.value, hce.value);
            Qsus_d.value = FilterMachiningEquations.Eval_Qsus_d_From_eps_A_Cv_dhcdt(eps.value, A.value, Cv.value, dhc_over_dt.value);
            Qmsus_d.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Qsus_d.value);
            Qs_d.value = FilterMachiningEquations.Eval_Qs_d_From_eps_A_dhcdt(eps.value, A.value, dhc_over_dt.value);
            Qms_d.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_s.value, Qs_d.value);
            Qf_d.value = FilterMachiningEquations.Eval_Qf_d_From_A_Dp_Pc_eta_hc_hce(A.value, Dp.value, Pc.value, eta_f.value, hc.value, hce.value);
            Qmf_d.value = FilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Qf_d.value); ;
            Qc_d.value = FilterMachiningEquations.Eval_Cake_From_Sus_Flow(Qsus_d.value, Qf_d.value);
            Qmc_d.value = FilterMachiningEquations.Eval_Cake_From_Sus_Flow(Qmsus_d.value, Qmf_d.value);
            qf.value = FilterMachiningEquations.Eval_q_From_Q_A(Qf.value, A.value);
            qf_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qf_d.value, A.value);
            qsus.value = FilterMachiningEquations.Eval_q_From_Q_A(Qsus.value, A.value);
            qsus_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qsus_d.value, A.value);
            qs.value = FilterMachiningEquations.Eval_q_From_Q_A(Qs.value, A.value);
            qs_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qs_d.value, A.value);
            qc.value = FilterMachiningEquations.Eval_q_From_Q_A(Qc.value, A.value);
            qc_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qc_d.value, A.value);
            qmf.value = FilterMachiningEquations.Eval_q_From_Q_A(Qmf.value, A.value);
            qmf_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qmf_d.value, A.value);
            qmsus.value = FilterMachiningEquations.Eval_q_From_Q_A(Qmsus.value, A.value);
            qmsus_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qmsus_d.value, A.value);
            qms.value = FilterMachiningEquations.Eval_q_From_Q_A(Qms.value, A.value);
            qms_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qms_d.value, A.value);
            qmc.value = FilterMachiningEquations.Eval_q_From_Q_A(Qmc.value, A.value);
            qmc_d.value = FilterMachiningEquations.Eval_q_From_Q_A(Qmc_d.value, A.value);
        }

        private void DoSubCalculationsDesign1()
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

            if (calculationOption == FilterMachiningCalculationOption.Standart3)
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

            if (calculationOption == FilterMachiningCalculationOption.Standart8)
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
