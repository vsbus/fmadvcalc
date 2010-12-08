using System;
using System.ComponentModel;
using fmCalculationLibrary;
using fmCalculationLibrary.Equations;
using System.Collections.Generic;

namespace fmCalculatorsLibrary
{
    public class fmFilterMachiningCalculator : fmBaseCalculator
    {
        public enum fmFilterMachiningCalculationOption
        {
            // Standart -- In this case we have always the area A as input 
            // and the (Qsus, Qmsus, Qms) as calculated.
            [Description("3: A, Dp, (n/tc/tr), tf")]
            STANDART3,
            [Description("4: A, (hc/Vf/Mf/Vsus/Msus/Ms), (sf/tr), (n/tc)")]
            STANDART4,
            [Description("8: A, Dp, (hc/Vf/Mf/Vsus/Msus/Ms), (n/tc/tr)")]
            STANDART8,

            // Design -- In this case we have always the (Qsus, Qmsus, Qms) as input 
            // and the filter area A is calculated 
            [Description("1: Q, Dp, hc, (n/tc/tr)")]
            DESIGN1,
            
            // Optimization -- In this case we have always the filter 
            // area A and the (Qsus, Qmsus, Qms) as input
            [Description("1: A, Q, Dp, (sf/tr)")]
            OPTIMIZATION1,
            
            // Global
            // 
            //(A, Q), Dp, (sf, sr, tr), (hc, V, M, tf, n, tc)
            [Description("Dp = const (Plain)")]
            PLAIN_DP_CONST,
            //(A, Q, Qsus_d), Dp, (sf, sr, tr), (hc, V, M, tf, n, tc)]
            [Description("Qp = const (Plain)")]
            PLAIN_QP_CONST,
            //(A, Q), (Dp, Qp), (sf, sr, tr), (hc, V, M, tf, n, tc)]
            [Description("Qp = const (Plain, volumetric pump)")]
            PLAIN_QP_CONST_VOLUMETRIC_PUMP,

            // Candle
            //
            //(A, Q), d, Dp, (sf, sr, tr), (hc, V, M, tf, n, tc)
            [Description("Dp = const (Cylindrical)")]
            CYLINDRICAL_DP_CONST,
            //(A, Q, Qsus_d), d, Dp, (sf, sr, tr), (hc, V, M, tf, n, tc)]
            [Description("Qp = const (Cylindrical)")]
            CYLINDRICAL_QP_CONST,
            //(A, Q), d, (Dp, Qp), (sf, sr, tr), (hc, V, M, tf, n, tc)]
            [Description("Qp = const (Cylindrical, volumetric pump)")]
            CYLINDRICAL_QP_CONST_VOLUMETRIC_PUMP
        }

        public fmFilterMachiningCalculationOption calculationOption = fmFilterMachiningCalculationOption.PLAIN_DP_CONST;

        public fmFilterMachiningCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }

        private static bool IsStandartKindOption(fmFilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == fmFilterMachiningCalculationOption.STANDART3
              || calculationOption == fmFilterMachiningCalculationOption.STANDART4
              || calculationOption == fmFilterMachiningCalculationOption.STANDART8
              || calculationOption == fmFilterMachiningCalculationOption.PLAIN_DP_CONST
              || calculationOption == fmFilterMachiningCalculationOption.PLAIN_QP_CONST
              || calculationOption == fmFilterMachiningCalculationOption.PLAIN_QP_CONST_VOLUMETRIC_PUMP
              || calculationOption == fmFilterMachiningCalculationOption.CYLINDRICAL_DP_CONST
              || calculationOption == fmFilterMachiningCalculationOption.CYLINDRICAL_QP_CONST
              || calculationOption == fmFilterMachiningCalculationOption.CYLINDRICAL_QP_CONST_VOLUMETRIC_PUMP;
        }

        private static bool IsDesignKindOption(fmFilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == fmFilterMachiningCalculationOption.DESIGN1
                || calculationOption == fmFilterMachiningCalculationOption.PLAIN_DP_CONST
                || calculationOption == fmFilterMachiningCalculationOption.PLAIN_QP_CONST
                || calculationOption == fmFilterMachiningCalculationOption.PLAIN_QP_CONST_VOLUMETRIC_PUMP;
        }

        private static bool IsOptimizationKindOption(fmFilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == fmFilterMachiningCalculationOption.OPTIMIZATION1;
        }

        private static bool IsStandartSubKind1DpOption(fmFilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == fmFilterMachiningCalculationOption.STANDART3;
        }

        private static bool IsStandartSubKind2HcOption(fmFilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == fmFilterMachiningCalculationOption.STANDART4;
        }

        private static bool IsStandartSubKind3DphcOption(fmFilterMachiningCalculationOption calculationOption)
        {
            return calculationOption == fmFilterMachiningCalculationOption.STANDART8;
        }

        public void DoCalculationsLimitsClue()
        {
            if (calculationOption == fmFilterMachiningCalculationOption.PLAIN_DP_CONST)
            {
                DoSubCalculationsPlainDpConst_OnlyLimitClueParams();
            }
            else if (calculationOption == fmFilterMachiningCalculationOption.PLAIN_QP_CONST)
            {
                DoSubCalculationsPlainQpConst_OnlyLimitClueParams();
            }
            else if (calculationOption == fmFilterMachiningCalculationOption.PLAIN_QP_CONST_VOLUMETRIC_PUMP)
            {
                DoSubCalculationsPlainQpConstVolumetricPump_OnlyLimitClueParams();
            }
            else if (calculationOption == fmFilterMachiningCalculationOption.CYLINDRICAL_DP_CONST)
            {
                DoSubCalculationsCylindricalDpConst_OnlyLimitClueParams();
            }
            else if (calculationOption == fmFilterMachiningCalculationOption.CYLINDRICAL_QP_CONST)
            {
                DoSubCalculationsCylindricalQpConst_OnlyLimitClueParams();
            }
            else if (calculationOption == fmFilterMachiningCalculationOption.CYLINDRICAL_QP_CONST_VOLUMETRIC_PUMP)
            {
                DoSubCalculationsCylindricalQpConstVolumetricPump_OnlyLimitClueParams();
            }
            else 
            {
                DoCalculations();
            }
        }

        private void DoSubCalculationsCylindricalQpConstVolumetricPump_OnlyLimitClueParams()
        {
            DoSubCalculationsCylindricalQpConstVolumetricPump();
        }

        private void DoSubCalculationsCylindricalQpConstVolumetricPump()
        {
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var Qp = variables[fmGlobalParameter.Qsus_d] as fmCalculationVariableParameter;
            if (Dp.isInputed)
            {
                DoSubCalculationsCylindricalQpConst();
            }
            else
            {
                Dp.isInputed = true;
                Qp.isInputed = false;

                fmValue qpValue = Qp.value;
                QpCalculatorHelperForDpInput qpCalc = new QpCalculatorHelperForDpInput(this, qpValue, QpCalculatorHelperForDpInput.AreaKind.CYLINDRICAL);
                Dp.value = fmCalculationLibrary.NumericalMethods.fmBisectionMethod.FindRoot(qpCalc, new fmValue(0), new fmValue(1e18), 80);
                qpCalc.Eval(Dp.value);
                Qp.value = qpValue;

                Dp.isInputed = false;
                Qp.isInputed = true;
            }
        }

        private void DoSubCalculationsPlainQpConstVolumetricPump_OnlyLimitClueParams()
        {
            DoSubCalculationsPlainQpConstVolumetricPump();
        }

        private void DoSubCalculationsCylindricalQpConst_OnlyLimitClueParams()
        {
            // ReSharper disable InconsistentNaming
            var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            var d0 = variables[fmGlobalParameter.d0] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            var sr = variables[fmGlobalParameter.sr] as fmCalculationVariableParameter;
            var n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            var mf = variables[fmGlobalParameter.mf] as fmCalculationVariableParameter;
            var vf = variables[fmGlobalParameter.vf] as fmCalculationVariableParameter;
            var ms = variables[fmGlobalParameter.ms] as fmCalculationVariableParameter;
            var vs = variables[fmGlobalParameter.vs] as fmCalculationVariableParameter;
            var msus = variables[fmGlobalParameter.msus] as fmCalculationVariableParameter;
            var vsus = variables[fmGlobalParameter.vsus] as fmCalculationVariableParameter;
            var mc = variables[fmGlobalParameter.mc] as fmCalculationVariableParameter;
            var vc = variables[fmGlobalParameter.vc] as fmCalculationVariableParameter;
            var Vc = variables[fmGlobalParameter.Vc] as fmCalculationVariableParameter;
            var Mc = variables[fmGlobalParameter.Mc] as fmCalculationVariableParameter;
            var Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            var Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;

            var Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
            var Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            var Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
            var Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
            var Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
            var Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            var Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            var Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;
            var Qsus_d = variables[fmGlobalParameter.Qsus_d] as fmCalculationVariableParameter;

            var eps = variables[fmGlobalParameter.eps];
            var kappa = variables[fmGlobalParameter.kappa];
            var Pc = variables[fmGlobalParameter.Pc];
            var rc = variables[fmGlobalParameter.rc];
            var a = variables[fmGlobalParameter.a];

            var eps0 = variables[fmGlobalParameter.eps0];
            var Pc0 = variables[fmGlobalParameter.Pc0];
            var eta_f = variables[fmGlobalParameter.eta_f];
            var rho_f = variables[fmGlobalParameter.rho_f];
            var rho_s = variables[fmGlobalParameter.rho_s];
            var rho_sus = variables[fmGlobalParameter.rho_sus];
            var Cv = variables[fmGlobalParameter.Cv];
            var Cm = variables[fmGlobalParameter.Cm];
            var ne = variables[fmGlobalParameter.ne];
            var nc = variables[fmGlobalParameter.nc];
            var hce = variables[fmGlobalParameter.hce0];
            // ReSharper restore InconsistentNaming

            eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = fmFilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = fmPcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            // ReSharper disable InconsistentNaming
            var isKnown_A = A.isInputed;
            var isKnown_sf = sf.isInputed;
            var isKnown_sr = sr.isInputed;
            var isKnown_n = n.isInputed;
            var isKnown_tc = tc.isInputed;
            var isKnown_tf = tf.isInputed;
            var isKnown_tr = tr.isInputed;
            var isKnown_hc = hc.isInputed;
            var isKnown_Vsus = Vsus.isInputed;
            var isKnown_Mf = Mf.isInputed;
            var isKnown_Vf = Vf.isInputed;
            var isKnown_mf = mf.isInputed;
            var isKnown_vf = vf.isInputed;
            var isKnown_ms = ms.isInputed;
            var isKnown_vs = vs.isInputed;
            var isKnown_msus = msus.isInputed;
            var isKnown_vsus = vsus.isInputed;
            var isKnown_mc = mc.isInputed;
            var isKnown_vc = vc.isInputed;
            var isKnown_Vc = Vc.isInputed;
            var isKnown_Mc = Mc.isInputed;
            var isKnown_Ms = Ms.isInputed;
            var isKnown_Vs = Vs.isInputed;
            var isKnown_Msus = Msus.isInputed;
            var isKnown_Qf = Qf.isInputed;
            var isKnown_Qs = Qs.isInputed;
            var isKnown_Qsus = Qsus.isInputed;
            var isKnown_Qc = Qc.isInputed;
            var isKnown_Qmf = Qmf.isInputed;
            var isKnown_Qms = Qms.isInputed;
            var isKnown_Qmsus = Qmsus.isInputed;
            var isKnown_Qmc = Qmc.isInputed;
            var isKnown_Qsusd = Qsus_d.isInputed;
            // ReSharper restore InconsistentNaming

            #region A0
            if (isKnown_A)
            {
                if (isKnown_Msus)
                {
                    msus.value = fmFilterMachiningEquations.Eval_m_From_M_A(Msus.value, A.value);
                    isKnown_msus = true;
                }

                if (isKnown_Ms)
                {
                    ms.value = fmFilterMachiningEquations.Eval_m_From_M_A(Ms.value, A.value);
                    isKnown_ms = true;
                }

                if (isKnown_Mc)
                {
                    mc.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mc.value, A.value);
                    isKnown_mc = true;
                }

                if (isKnown_Mf)
                {
                    mf.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mf.value, A.value);
                    isKnown_mf = true;
                }

                if (isKnown_Vsus)
                {
                    vsus.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vsus.value, A.value);
                    isKnown_vsus = true;
                }

                if (isKnown_Vs)
                {
                    vs.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vs.value, A.value);
                    isKnown_vs = true;
                }

                if (isKnown_Vc)
                {
                    vc.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vc.value, A.value);
                    isKnown_vc = true;
                }

                if (isKnown_Vf)
                {
                    vf.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vf.value, A.value);
                    isKnown_vf = true;
                }
            }
            #endregion
            #region A
            if (isKnown_ms)
            {
                vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, ms.value);
                isKnown_vs = true;
            }

            if (isKnown_vs)
            {
                vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_vsus = true;
            }

            if (isKnown_msus)
            {
                vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, msus.value);
                isKnown_vsus = true;
            }

            if (isKnown_vsus)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(vsus.value, kappa.value);
                isKnown_vf = true;
            }

            if (isKnown_mc)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_vf = true;
            }

            if (isKnown_mf)
            {
                vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, mf.value);
                isKnown_vf = true;
            }

            if (isKnown_vf)
            {
                vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(vf.value, kappa.value);
                isKnown_vc = true;
            }

            if (isKnown_vc)
            {
                hc.value = fmFilterMachiningEquations.EvalCandle_hc_From_vc_d(vc.value, d0.value);
                isKnown_hc = true;
            }

            if (isKnown_hc)
            {
                tf.value = fmFilterMachiningEquations.EvalCandle_tf_From_d_hc_hce_eta_Cv_kappa_Pc_Dp_QpConst(eps.value, d0.value, hc.value, hce.value, eta_f.value, Cv.value, kappa.value, Pc.value, Dp.value);
                isKnown_tf = true;
            }
            #endregion
            #region D
            if (isKnown_Ms)
            {
                Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                isKnown_Vs = true;
            }

            if (isKnown_Vs)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Msus)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Vsus)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(Vsus.value, kappa.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Mf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mc)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(Mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Vf = true;
            }

            if (isKnown_Vf)
            {
                Vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(Vf.value, kappa.value);
                isKnown_Vc = true;
            }

            if (isKnown_Vc && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(Vc.value, kappa.value);
                isKnown_Vf = true;
            }
            #endregion
            #region E
            if (isKnown_Qms)
            {
                Qs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
                isKnown_Qs = true;
            }

            if (isKnown_Qmsus)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Qmsus.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qs)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Qs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qsus)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_vsus_kappa(Qsus.value, kappa.value);
                isKnown_Qc = true;
            }

            if (isKnown_Qmc)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_mc_kappa_rho(Qmc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Qc = true;
            }
            #endregion
            #region F
            if (isKnown_Qmf)
            {
                Qf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Qmf.value);
                isKnown_Qf = true;
            }
            if (isKnown_Qsusd)
            {
                Qf.value = fmFilterMachiningEquations.Eval_Qf_From_Qsusd_eps_Cv(Qsus_d.value, eps.value, Cv.value);
                isKnown_Qf = true;
            }
            #endregion
            #region G
            if (isKnown_Qc && isKnown_Vc)
            {
                tc.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qc.value, Vc.value);
                isKnown_tc = true;
            }

            if (isKnown_Qf && isKnown_Vf)
            {
                tf.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qf.value, Vf.value);
                isKnown_tf = true;
            }
            #endregion
            #region B
            if (isKnown_tf)
            {
                if (isKnown_sf)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tf_sf(tf.value, sf.value);
                }
                else if (isKnown_tr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                }
                else if (isKnown_sr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_sr_tf(sr.value, tf.value);
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
                tc.value = fmFilterMachiningEquations.Eval_tc_From_n(n.value);
                isKnown_tc = true;
            }
            #region C
            if (!isKnown_tc)
            {
                throw new Exception("tc must be known in block C.");
            }

            if (!isKnown_tr && isKnown_sr)
            {
                tr.value = fmFilterMachiningEquations.Eval_tr_From_sr_tc(sr.value, tc.value);
                /*
                                isKnown_tr = true;
                */
            }

            if (!isKnown_sf)
            {
                sf.value = fmFilterMachiningEquations.Eval_sf_From_tr_tc(tr.value, tc.value);
                /*
                                isKnown_sf = true;
                */
            }
            #endregion

            if (!isKnown_tf) tf.value = fmFilterMachiningEquations.Eval_tf_From_sf_tc(sf.value, tc.value);
            if (!isKnown_hc) hc.value = fmFilterMachiningEquations.EvalCandle_hc_From_hce_d_eta_Cv_kappa_Pc_Dp_tf_QpConst(eps.value, hce.value, d0.value, eta_f.value, Cv.value, kappa.value, Pc.value, Dp.value, tf.value);

            if (!isKnown_vc) vc.value = fmFilterMachiningEquations.EvalCandle_vc_From_hc_d(hc.value, d0.value);
            if (!isKnown_vf) vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(vc.value, kappa.value);

            if (isKnown_Qf && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qf.value, tf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Qc && !isKnown_Vc)
            {
                Vc.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qc.value, tc.value);
                isKnown_Vc = true;
            }

            if (!isKnown_A && isKnown_Vf)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vf.value, vf.value);
                isKnown_A = true;
            }

            if (!isKnown_A && isKnown_Vc)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vc.value, vc.value);
                /*
                                isKnown_A = true;
                */
            }

            if (!isKnown_Qsusd) Qsus_d.value = fmFilterMachiningEquations.EvalCandle_Qsus_d_From_d_hc_hce_A_kappa_Pc_Dp_eta_QpConst(d0.value, hc.value, hce.value, A.value, kappa.value, Pc.value, Dp.value, eta_f.value);
        }

        private void DoSubCalculationsPlainQpConst_OnlyLimitClueParams()
        {
            // ReSharper disable InconsistentNaming
            var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            var sr = variables[fmGlobalParameter.sr] as fmCalculationVariableParameter;
            var n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            var mf = variables[fmGlobalParameter.mf] as fmCalculationVariableParameter;
            var vf = variables[fmGlobalParameter.vf] as fmCalculationVariableParameter;
            var ms = variables[fmGlobalParameter.ms] as fmCalculationVariableParameter;
            var vs = variables[fmGlobalParameter.vs] as fmCalculationVariableParameter;
            var msus = variables[fmGlobalParameter.msus] as fmCalculationVariableParameter;
            var vsus = variables[fmGlobalParameter.vsus] as fmCalculationVariableParameter;
            var mc = variables[fmGlobalParameter.mc] as fmCalculationVariableParameter;
            var vc = variables[fmGlobalParameter.vc] as fmCalculationVariableParameter;
            var Vc = variables[fmGlobalParameter.Vc] as fmCalculationVariableParameter;
            var Mc = variables[fmGlobalParameter.Mc] as fmCalculationVariableParameter;
            var Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            var Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;

            var Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
            var Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            var Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
            var Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
            var Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
            var Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            var Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            var Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;
            var Qsus_d = variables[fmGlobalParameter.Qsus_d] as fmCalculationVariableParameter;

            var eps = variables[fmGlobalParameter.eps];
            var kappa = variables[fmGlobalParameter.kappa];
            var Pc = variables[fmGlobalParameter.Pc];
            var rc = variables[fmGlobalParameter.rc];
            var a = variables[fmGlobalParameter.a];

            var eps0 = variables[fmGlobalParameter.eps0];
            var Pc0 = variables[fmGlobalParameter.Pc0];
            var eta_f = variables[fmGlobalParameter.eta_f];
            var rho_f = variables[fmGlobalParameter.rho_f];
            var rho_s = variables[fmGlobalParameter.rho_s];
            var rho_sus = variables[fmGlobalParameter.rho_sus];
            var Cv = variables[fmGlobalParameter.Cv];
            var Cm = variables[fmGlobalParameter.Cm];
            var ne = variables[fmGlobalParameter.ne];
            var nc = variables[fmGlobalParameter.nc];
            var hce = variables[fmGlobalParameter.hce0];
            // ReSharper restore InconsistentNaming

            eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = fmFilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = fmPcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            // ReSharper disable InconsistentNaming
            var isKnown_A = A.isInputed;
            var isKnown_sf = sf.isInputed;
            var isKnown_sr = sr.isInputed;
            var isKnown_n = n.isInputed;
            var isKnown_tc = tc.isInputed;
            var isKnown_tf = tf.isInputed;
            var isKnown_tr = tr.isInputed;
            var isKnown_hc = hc.isInputed;
            var isKnown_Vsus = Vsus.isInputed;
            var isKnown_Mf = Mf.isInputed;
            var isKnown_Vf = Vf.isInputed;
            var isKnown_mf = mf.isInputed;
            var isKnown_vf = vf.isInputed;
            var isKnown_ms = ms.isInputed;
            var isKnown_vs = vs.isInputed;
            var isKnown_msus = msus.isInputed;
            var isKnown_vsus = vsus.isInputed;
            var isKnown_mc = mc.isInputed;
            var isKnown_vc = vc.isInputed;
            var isKnown_Vc = Vc.isInputed;
            var isKnown_Mc = Mc.isInputed;
            var isKnown_Ms = Ms.isInputed;
            var isKnown_Vs = Vs.isInputed;
            var isKnown_Msus = Msus.isInputed;
            var isKnown_Qf = Qf.isInputed;
            var isKnown_Qs = Qs.isInputed;
            var isKnown_Qsus = Qsus.isInputed;
            var isKnown_Qc = Qc.isInputed;
            var isKnown_Qmf = Qmf.isInputed;
            var isKnown_Qms = Qms.isInputed;
            var isKnown_Qmsus = Qmsus.isInputed;
            var isKnown_Qmc = Qmc.isInputed;
            var isKnown_Qsusd = Qsus_d.isInputed;
            // ReSharper restore InconsistentNaming

            #region A0
            if (isKnown_A)
            {
                if (isKnown_Msus)
                {
                    msus.value = fmFilterMachiningEquations.Eval_m_From_M_A(Msus.value, A.value);
                    isKnown_msus = true;
                }

                if (isKnown_Ms)
                {
                    ms.value = fmFilterMachiningEquations.Eval_m_From_M_A(Ms.value, A.value);
                    isKnown_ms = true;
                }

                if (isKnown_Mc)
                {
                    mc.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mc.value, A.value);
                    isKnown_mc = true;
                }

                if (isKnown_Mf)
                {
                    mf.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mf.value, A.value);
                    isKnown_mf = true;
                }

                if (isKnown_Vsus)
                {
                    vsus.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vsus.value, A.value);
                    isKnown_vsus = true;
                }

                if (isKnown_Vs)
                {
                    vs.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vs.value, A.value);
                    isKnown_vs = true;
                }

                if (isKnown_Vc)
                {
                    vc.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vc.value, A.value);
                    isKnown_vc = true;
                }

                if (isKnown_Vf)
                {
                    vf.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vf.value, A.value);
                    isKnown_vf = true;
                }
            }
            #endregion
            #region A
            if (isKnown_ms)
            {
                vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, ms.value);
                isKnown_vs = true;
            }

            if (isKnown_vs)
            {
                vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_vsus = true;
            }

            if (isKnown_msus)
            {
                vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, msus.value);
                isKnown_vsus = true;
            }

            if (isKnown_vsus)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(vsus.value, kappa.value);
                isKnown_vf = true;
            }

            if (isKnown_mc)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_vf = true;
            }

            if (isKnown_mf)
            {
                vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, mf.value);
                isKnown_vf = true;
            }

            if (isKnown_vf)
            {
                vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(vf.value, kappa.value);
                isKnown_vc = true;
            }

            if (isKnown_vc)
            {
                hc.value = vc.value;
                isKnown_hc = true;
            }

            if (isKnown_hc)
            {
                tf.value = fmFilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp_QpConst(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                isKnown_tf = true;
            }
            #endregion
            #region D
            if (isKnown_Ms)
            {
                Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                isKnown_Vs = true;
            }

            if (isKnown_Vs)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Msus)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Vsus)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(Vsus.value, kappa.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Mf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mc)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(Mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Vf = true;
            }

            if (isKnown_Vf)
            {
                Vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(Vf.value, kappa.value);
                isKnown_Vc = true;
            }

            if (isKnown_Vc && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(Vc.value, kappa.value);
                isKnown_Vf = true;
            }
            #endregion
            #region E
            if (isKnown_Qms)
            {
                Qs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
                isKnown_Qs = true;
            }

            if (isKnown_Qmsus)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Qmsus.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qs)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Qs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qsus)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_vsus_kappa(Qsus.value, kappa.value);
                isKnown_Qc = true;
            }

            if (isKnown_Qmc)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_mc_kappa_rho(Qmc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Qc = true;
            }
            #endregion
            #region F
            if (isKnown_Qmf)
            {
                Qf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Qmf.value);
                isKnown_Qf = true;
            }
            if (isKnown_Qsusd)
            {
                Qf.value = fmFilterMachiningEquations.Eval_Qf_From_Qsusd_eps_Cv(Qsus_d.value, eps.value, Cv.value);
                isKnown_Qf = true;
            }
            #endregion
            #region G
            if (isKnown_Qc && isKnown_Vc)
            {
                tc.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qc.value, Vc.value);
                isKnown_tc = true;
            }

            if (isKnown_Qf && isKnown_Vf)
            {
                tf.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qf.value, Vf.value);
                isKnown_tf = true;
            }
            #endregion
            #region B
            if (isKnown_tf)
            {
                if (isKnown_sf)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tf_sf(tf.value, sf.value);
                }
                else if (isKnown_tr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                }
                else if (isKnown_sr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_sr_tf(sr.value, tf.value);
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
                tc.value = fmFilterMachiningEquations.Eval_tc_From_n(n.value);
                isKnown_tc = true;
            }
            #region C
            if (!isKnown_tc)
            {
                throw new Exception("tc must be known in block C.");
            }

            if (!isKnown_tr && isKnown_sr)
            {
                tr.value = fmFilterMachiningEquations.Eval_tr_From_sr_tc(sr.value, tc.value);
                /*
                                isKnown_tr = true;
                */
            }

            if (!isKnown_sf)
            {
                sf.value = fmFilterMachiningEquations.Eval_sf_From_tr_tc(tr.value, tc.value);
                /*
                                isKnown_sf = true;
                */
            }
            #endregion

            if (!isKnown_tf) tf.value = fmFilterMachiningEquations.Eval_tf_From_sf_tc(sf.value, tc.value);
            if (!isKnown_hc) hc.value = fmFilterMachiningEquations.Eval_hc_From_hce_Pc_kappa_Dp_tf_etaf_QpConst(hce.value, Pc.value, kappa.value, Dp.value, tf.value, eta_f.value);

            if (!isKnown_vc) vc.value = hc.value;
            if (!isKnown_vf) vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(vc.value, kappa.value);

            if (isKnown_Qf && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qf.value, tf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Qc && !isKnown_Vc)
            {
                Vc.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qc.value, tc.value);
                isKnown_Vc = true;
            }

            if (!isKnown_A && isKnown_Vf)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vf.value, vf.value);
                isKnown_A = true;
            }

            if (!isKnown_A && isKnown_Vc)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vc.value, vc.value);
                /*
                                isKnown_A = true;
                */
            }

            if (!isKnown_Qsusd) Qsus_d.value = fmFilterMachiningEquations.Eval_Qsus_d_From_A_Dp_Pc_eta_f_Cv_eps_hc_hce_QpConst(A.value, Dp.value, Pc.value, eta_f.value, Cv.value, eps.value, hc.value, hce.value);
        }
        private void DoSubCalculationsCylindricalDpConst_OnlyLimitClueParams()
        {
            // ReSharper disable InconsistentNaming
            var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            var d0 = variables[fmGlobalParameter.d0] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            var sr = variables[fmGlobalParameter.sr] as fmCalculationVariableParameter;
            var n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            var mf = variables[fmGlobalParameter.mf] as fmCalculationVariableParameter;
            var vf = variables[fmGlobalParameter.vf] as fmCalculationVariableParameter;
            var ms = variables[fmGlobalParameter.ms] as fmCalculationVariableParameter;
            var vs = variables[fmGlobalParameter.vs] as fmCalculationVariableParameter;
            var msus = variables[fmGlobalParameter.msus] as fmCalculationVariableParameter;
            var vsus = variables[fmGlobalParameter.vsus] as fmCalculationVariableParameter;
            var mc = variables[fmGlobalParameter.mc] as fmCalculationVariableParameter;
            var vc = variables[fmGlobalParameter.vc] as fmCalculationVariableParameter;
            var Vc = variables[fmGlobalParameter.Vc] as fmCalculationVariableParameter;
            var Mc = variables[fmGlobalParameter.Mc] as fmCalculationVariableParameter;
            var Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            var Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;

            var Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
            var Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            var Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
            var Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
            var Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
            var Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            var Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            var Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;

            var eps = variables[fmGlobalParameter.eps];
            var kappa = variables[fmGlobalParameter.kappa];
            var Pc = variables[fmGlobalParameter.Pc];
            var rc = variables[fmGlobalParameter.rc];
            var a = variables[fmGlobalParameter.a];

            var eps0 = variables[fmGlobalParameter.eps0];
            var Pc0 = variables[fmGlobalParameter.Pc0];
            var eta_f = variables[fmGlobalParameter.eta_f];
            var rho_f = variables[fmGlobalParameter.rho_f];
            var rho_s = variables[fmGlobalParameter.rho_s];
            var rho_sus = variables[fmGlobalParameter.rho_sus];
            var Cv = variables[fmGlobalParameter.Cv];
            var Cm = variables[fmGlobalParameter.Cm];
            var ne = variables[fmGlobalParameter.ne];
            var nc = variables[fmGlobalParameter.nc];
            var hce = variables[fmGlobalParameter.hce0];
            // ReSharper restore InconsistentNaming

            eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = fmFilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = fmPcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            // ReSharper disable InconsistentNaming
            var isKnown_A = A.isInputed;
            var isKnown_sf = sf.isInputed;
            var isKnown_sr = sr.isInputed;
            var isKnown_n = n.isInputed;
            var isKnown_tc = tc.isInputed;
            var isKnown_tf = tf.isInputed;
            var isKnown_tr = tr.isInputed;
            var isKnown_hc = hc.isInputed;
            var isKnown_Vsus = Vsus.isInputed;
            var isKnown_Mf = Mf.isInputed;
            var isKnown_Vf = Vf.isInputed;
            var isKnown_mf = mf.isInputed;
            var isKnown_vf = vf.isInputed;
            var isKnown_ms = ms.isInputed;
            var isKnown_vs = vs.isInputed;
            var isKnown_msus = msus.isInputed;
            var isKnown_vsus = vsus.isInputed;
            var isKnown_mc = mc.isInputed;
            var isKnown_vc = vc.isInputed;
            var isKnown_Vc = Vc.isInputed;
            var isKnown_Mc = Mc.isInputed;
            var isKnown_Ms = Ms.isInputed;
            var isKnown_Vs = Vs.isInputed;
            var isKnown_Msus = Msus.isInputed;
            var isKnown_Qf = Qf.isInputed;
            var isKnown_Qs = Qs.isInputed;
            var isKnown_Qsus = Qsus.isInputed;
            var isKnown_Qc = Qc.isInputed;
            var isKnown_Qmf = Qmf.isInputed;
            var isKnown_Qms = Qms.isInputed;
            var isKnown_Qmsus = Qmsus.isInputed;
            var isKnown_Qmc = Qmc.isInputed;
            // ReSharper restore InconsistentNaming

            #region A0
            if (isKnown_A)
            {
                if (isKnown_Msus)
                {
                    msus.value = fmFilterMachiningEquations.Eval_m_From_M_A(Msus.value, A.value);
                    isKnown_msus = true;
                }

                if (isKnown_Ms)
                {
                    ms.value = fmFilterMachiningEquations.Eval_m_From_M_A(Ms.value, A.value);
                    isKnown_ms = true;
                }

                if (isKnown_Mc)
                {
                    mc.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mc.value, A.value);
                    isKnown_mc = true;
                }

                if (isKnown_Mf)
                {
                    mf.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mf.value, A.value);
                    isKnown_mf = true;
                }

                if (isKnown_Vsus)
                {
                    vsus.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vsus.value, A.value);
                    isKnown_vsus = true;
                }

                if (isKnown_Vs)
                {
                    vs.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vs.value, A.value);
                    isKnown_vs = true;
                }

                if (isKnown_Vc)
                {
                    vc.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vc.value, A.value);
                    isKnown_vc = true;
                }

                if (isKnown_Vf)
                {
                    vf.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vf.value, A.value);
                    isKnown_vf = true;
                }
            }
            #endregion
            #region A
            if (isKnown_ms)
            {
                vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, ms.value);
                isKnown_vs = true;
            }

            if (isKnown_vs)
            {
                vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_vsus = true;
            }

            if (isKnown_msus)
            {
                vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, msus.value);
                isKnown_vsus = true;
            }

            if (isKnown_vsus)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(vsus.value, kappa.value);
                isKnown_vf = true;
            }

            if (isKnown_mc)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_vf = true;
            }

            if (isKnown_mf)
            {
                vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, mf.value);
                isKnown_vf = true;
            }

            if (isKnown_vf)
            {
                vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(vf.value, kappa.value);
                isKnown_vc = true;
            }

            if (isKnown_vc)
            {
                hc.value = fmFilterMachiningEquations.EvalCandle_hc_From_vc_d(vc.value, d0.value);
                isKnown_hc = true;
            }

            if (isKnown_hc)
            {
                tf.value = fmFilterMachiningEquations.EvalCandle_tf_From_d_eta_kappa_Pc_Dp_hc_hce(d0.value, eta_f.value, kappa.value, Pc.value, Dp.value, hc.value, hce.value);
                isKnown_tf = true;
            }
            #endregion
            #region D
            if (isKnown_Ms)
            {
                Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                isKnown_Vs = true;
            }

            if (isKnown_Vs)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Msus)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Vsus)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(Vsus.value, kappa.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Mf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mc)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(Mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Vf = true;
            }

            if (isKnown_Vf)
            {
                Vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(Vf.value, kappa.value);
                isKnown_Vc = true;
            }

            if (isKnown_Vc && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(Vc.value, kappa.value);
                isKnown_Vf = true;
            }
            #endregion
            #region E
            if (isKnown_Qms)
            {
                Qs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
                isKnown_Qs = true;
            }

            if (isKnown_Qmsus)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Qmsus.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qs)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Qs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qsus)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_vsus_kappa(Qsus.value, kappa.value);
                isKnown_Qc = true;
            }

            if (isKnown_Qmc)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_mc_kappa_rho(Qmc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Qc = true;
            }
            #endregion
            #region F
            if (isKnown_Qmf)
            {
                Qf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Qmf.value);
                isKnown_Qf = true;
            }
            #endregion
            #region G
            if (isKnown_Qc && isKnown_Vc)
            {
                tc.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qc.value, Vc.value);
                isKnown_tc = true;
            }

            if (isKnown_Qf && isKnown_Vf)
            {
                tf.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qf.value, Vf.value);
                isKnown_tf = true;
            }
            #endregion
            #region B
            if (isKnown_tf)
            {
                if (isKnown_sf)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tf_sf(tf.value, sf.value);
                }
                else if (isKnown_tr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                }
                else if (isKnown_sr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_sr_tf(sr.value, tf.value);
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
                tc.value = fmFilterMachiningEquations.Eval_tc_From_n(n.value);
                isKnown_tc = true;
            }
            #region C
            if (!isKnown_tc)
            {
                throw new Exception("tc must be known in block C.");
            }

            if (!isKnown_tr && isKnown_sr)
            {
                tr.value = fmFilterMachiningEquations.Eval_tr_From_sr_tc(sr.value, tc.value);
                /*
                                isKnown_tr = true;
                */
            }

            if (!isKnown_sf)
            {
                sf.value = fmFilterMachiningEquations.Eval_sf_From_tr_tc(tr.value, tc.value);
                /*
                                isKnown_sf = true;
                */
            }
            #endregion

            if (!isKnown_tf) tf.value = fmFilterMachiningEquations.Eval_tf_From_sf_tc(sf.value, tc.value);
            if (!isKnown_hc) hc.value = fmFilterMachiningEquations.EvalCandle_hc_From_tf_hce_kappa_Pc_Dp_etaf_d(tf.value, hce.value, kappa.value, Pc.value, Dp.value, eta_f.value, d0.value);

            if (!isKnown_vc) vc.value = fmFilterMachiningEquations.EvalCandle_vc_From_hc_d(hc.value, d0.value);
            if (!isKnown_vf) vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(vc.value, kappa.value);

            if (isKnown_Qf && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qf.value, tf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Qc && !isKnown_Vc)
            {
                Vc.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qc.value, tc.value);
                isKnown_Vc = true;
            }

            if (!isKnown_A && isKnown_Vf)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vf.value, vf.value);
                isKnown_A = true;
            }

            if (!isKnown_A && isKnown_Vc)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vc.value, vc.value);
                /*
                                isKnown_A = true;
                */
            }
        }
        private void DoSubCalculationsPlainDpConst_OnlyLimitClueParams()
        {
            // ReSharper disable InconsistentNaming
            var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            var sr = variables[fmGlobalParameter.sr] as fmCalculationVariableParameter;
            var n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            var mf = variables[fmGlobalParameter.mf] as fmCalculationVariableParameter;
            var vf = variables[fmGlobalParameter.vf] as fmCalculationVariableParameter;
            var ms = variables[fmGlobalParameter.ms] as fmCalculationVariableParameter;
            var vs = variables[fmGlobalParameter.vs] as fmCalculationVariableParameter;
            var msus = variables[fmGlobalParameter.msus] as fmCalculationVariableParameter;
            var vsus = variables[fmGlobalParameter.vsus] as fmCalculationVariableParameter;
            var mc = variables[fmGlobalParameter.mc] as fmCalculationVariableParameter;
            var vc = variables[fmGlobalParameter.vc] as fmCalculationVariableParameter;
            var Vc = variables[fmGlobalParameter.Vc] as fmCalculationVariableParameter;
            var Mc = variables[fmGlobalParameter.Mc] as fmCalculationVariableParameter;
            var Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            var Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;

            var Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
            var Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            var Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
            var Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
            var Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
            var Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            var Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            var Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;

            var eps = variables[fmGlobalParameter.eps];
            var kappa = variables[fmGlobalParameter.kappa];
            var Pc = variables[fmGlobalParameter.Pc];
            var rc = variables[fmGlobalParameter.rc];
            var a = variables[fmGlobalParameter.a];

            var eps0 = variables[fmGlobalParameter.eps0];
            var Pc0 = variables[fmGlobalParameter.Pc0];
            var eta_f = variables[fmGlobalParameter.eta_f];
            var rho_f = variables[fmGlobalParameter.rho_f];
            var rho_s = variables[fmGlobalParameter.rho_s];
            var rho_sus = variables[fmGlobalParameter.rho_sus];
            var Cv = variables[fmGlobalParameter.Cv];
            var Cm = variables[fmGlobalParameter.Cm];
            var ne = variables[fmGlobalParameter.ne];
            var nc = variables[fmGlobalParameter.nc];
            var hce = variables[fmGlobalParameter.hce0];
            // ReSharper restore InconsistentNaming

            eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = fmFilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = fmPcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            // ReSharper disable InconsistentNaming
            var isKnown_A = A.isInputed;
            var isKnown_sf = sf.isInputed;
            var isKnown_sr = sr.isInputed;
            var isKnown_n = n.isInputed;
            var isKnown_tc = tc.isInputed;
            var isKnown_tf = tf.isInputed;
            var isKnown_tr = tr.isInputed;
            var isKnown_hc = hc.isInputed;
            var isKnown_Vsus = Vsus.isInputed;
            var isKnown_Mf = Mf.isInputed;
            var isKnown_Vf = Vf.isInputed;
            var isKnown_mf = mf.isInputed;
            var isKnown_vf = vf.isInputed;
            var isKnown_ms = ms.isInputed;
            var isKnown_vs = vs.isInputed;
            var isKnown_msus = msus.isInputed;
            var isKnown_vsus = vsus.isInputed;
            var isKnown_mc = mc.isInputed;
            var isKnown_vc = vc.isInputed;
            var isKnown_Vc = Vc.isInputed;
            var isKnown_Mc = Mc.isInputed;
            var isKnown_Ms = Ms.isInputed;
            var isKnown_Vs = Vs.isInputed;
            var isKnown_Msus = Msus.isInputed;
            var isKnown_Qf = Qf.isInputed;
            var isKnown_Qs = Qs.isInputed;
            var isKnown_Qsus = Qsus.isInputed;
            var isKnown_Qc = Qc.isInputed;
            var isKnown_Qmf = Qmf.isInputed;
            var isKnown_Qms = Qms.isInputed;
            var isKnown_Qmsus = Qmsus.isInputed;
            var isKnown_Qmc = Qmc.isInputed;
            // ReSharper restore InconsistentNaming

            #region A0
            if (isKnown_A)
            {
                if (isKnown_Msus)
                {
                    msus.value = fmFilterMachiningEquations.Eval_m_From_M_A(Msus.value, A.value);
                    isKnown_msus = true;
                }

                if (isKnown_Ms)
                {
                    ms.value = fmFilterMachiningEquations.Eval_m_From_M_A(Ms.value, A.value);
                    isKnown_ms = true;
                }

                if (isKnown_Mc)
                {
                    mc.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mc.value, A.value);
                    isKnown_mc = true;
                }

                if (isKnown_Mf)
                {
                    mf.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mf.value, A.value);
                    isKnown_mf = true;
                }

                if (isKnown_Vsus)
                {
                    vsus.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vsus.value, A.value);
                    isKnown_vsus = true;
                }

                if (isKnown_Vs)
                {
                    vs.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vs.value, A.value);
                    isKnown_vs = true;
                }

                if (isKnown_Vc)
                {
                    vc.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vc.value, A.value);
                    isKnown_vc = true;
                }

                if (isKnown_Vf)
                {
                    vf.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vf.value, A.value);
                    isKnown_vf = true;
                }
            }
            #endregion
            #region A
            if (isKnown_ms)
            {
                vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, ms.value);
                isKnown_vs = true;
            }

            if (isKnown_vs)
            {
                vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_vsus = true;
            }

            if (isKnown_msus)
            {
                vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, msus.value);
                isKnown_vsus = true;
            }

            if (isKnown_vsus)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(vsus.value, kappa.value);
                isKnown_vf = true;
            }

            if (isKnown_mc)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_vf = true;
            }

            if (isKnown_mf)
            {
                vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, mf.value);
                isKnown_vf = true;
            }

            if (isKnown_vf)
            {
                vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(vf.value, kappa.value);
                isKnown_vc = true;
            }

            if (isKnown_vc)
            {
                hc.value = vc.value;
                isKnown_hc = true;
            }

            if (isKnown_hc)
            {
                tf.value = fmFilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                isKnown_tf = true;
            }
            #endregion
            #region D
            if (isKnown_Ms)
            {
                Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                isKnown_Vs = true;
            }

            if (isKnown_Vs)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Msus)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Vsus)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(Vsus.value, kappa.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Mf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mc)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(Mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Vf = true;
            }

            if (isKnown_Vf)
            {
                Vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(Vf.value, kappa.value);
                isKnown_Vc = true;
            }

            if (isKnown_Vc && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(Vc.value, kappa.value);
                isKnown_Vf = true;
            }
            #endregion
            #region E
            if (isKnown_Qms)
            {
                Qs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
                isKnown_Qs = true;
            }

            if (isKnown_Qmsus)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Qmsus.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qs)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Qs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qsus)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_vsus_kappa(Qsus.value, kappa.value);
                isKnown_Qc = true;
            }

            if (isKnown_Qmc)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_mc_kappa_rho(Qmc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Qc = true;
            }
            #endregion
            #region F
            if (isKnown_Qmf)
            {
                Qf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Qmf.value);
                isKnown_Qf = true;
            }
            #endregion
            #region G
            if (isKnown_Qc && isKnown_Vc)
            {
                tc.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qc.value, Vc.value);
                isKnown_tc = true;
            }

            if (isKnown_Qf && isKnown_Vf)
            {
                tf.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qf.value, Vf.value);
                isKnown_tf = true;
            }
            #endregion
            #region B
            if (isKnown_tf)
            {
                if (isKnown_sf)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tf_sf(tf.value, sf.value);
                }
                else if (isKnown_tr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                }
                else if (isKnown_sr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_sr_tf(sr.value, tf.value);
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
                tc.value = fmFilterMachiningEquations.Eval_tc_From_n(n.value);
                isKnown_tc = true;
            }
            #region C
            if (!isKnown_tc)
            {
                throw new Exception("tc must be known in block C.");
            }

            if (!isKnown_tr && isKnown_sr)
            {
                tr.value = fmFilterMachiningEquations.Eval_tr_From_sr_tc(sr.value, tc.value);
/*
                isKnown_tr = true;
*/
            }

            if (!isKnown_sf)
            {
                sf.value = fmFilterMachiningEquations.Eval_sf_From_tr_tc(tr.value, tc.value);
/*
                isKnown_sf = true;
*/
            }
            #endregion

            if (!isKnown_tf) tf.value = fmFilterMachiningEquations.Eval_tf_From_sf_tc(sf.value, tc.value);
            if (!isKnown_hc) hc.value = fmFilterMachiningEquations.Eval_hc_From_hce_Pc_kappa_Dp_tf_etaf(hce.value, Pc.value, kappa.value, Dp.value, tf.value, eta_f.value);

            if (!isKnown_vc) vc.value = hc.value;
            if (!isKnown_vf) vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(vc.value, kappa.value);

            if (isKnown_Qf && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qf.value, tf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Qc && !isKnown_Vc)
            {
                Vc.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qc.value, tc.value);
                isKnown_Vc = true;
            }

            if (!isKnown_A && isKnown_Vf)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vf.value, vf.value);
                isKnown_A = true;
            }

            if (!isKnown_A && isKnown_Vc)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vc.value, vc.value);
/*
                isKnown_A = true;
*/
            }
        }
        override public void DoCalculations()
        {
            if (calculationOption == fmFilterMachiningCalculationOption.PLAIN_DP_CONST)
            {
                DoSubCalculationsPlainDpConst();
            }
            else if (calculationOption == fmFilterMachiningCalculationOption.PLAIN_QP_CONST)
            {
                DoSubCalculationsPlainQpConst();
            }
            else if (calculationOption == fmFilterMachiningCalculationOption.PLAIN_QP_CONST_VOLUMETRIC_PUMP)
            {
                DoSubCalculationsPlainQpConstVolumetricPump();
            }
            else if (calculationOption == fmFilterMachiningCalculationOption.CYLINDRICAL_DP_CONST)
            {
                DoSubCalculationsCylindricaleDpConst();
            }
            else if (calculationOption == fmFilterMachiningCalculationOption.CYLINDRICAL_QP_CONST)
            {
                DoSubCalculationsCylindricalQpConst();
            }
            else if (calculationOption == fmFilterMachiningCalculationOption.CYLINDRICAL_QP_CONST_VOLUMETRIC_PUMP)
            {
                DoSubCalculationsCylindricalQpConstVolumetricPump();
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

                // ReSharper disable InconsistentNaming
                var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
                var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
                var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
                var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
                var hc_over_tf = variables[fmGlobalParameter.hc_over_tf] as fmCalculationVariableParameter;
                var dhc_over_dt = variables[fmGlobalParameter.dhc_over_dt] as fmCalculationVariableParameter;
                var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
                var Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
                var Qf_d = variables[fmGlobalParameter.Qf_d] as fmCalculationVariableParameter;
                var Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
                var Qs_d = variables[fmGlobalParameter.Qs_d] as fmCalculationVariableParameter;
                var Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
                var Qc_d = variables[fmGlobalParameter.Qc_d] as fmCalculationVariableParameter;
                var Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
                var Qsus_d = variables[fmGlobalParameter.Qsus_d] as fmCalculationVariableParameter;
                var Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
                var Qmsus_d = variables[fmGlobalParameter.Qmsus_d] as fmCalculationVariableParameter;
                var Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
                var Qms_d = variables[fmGlobalParameter.Qms_d] as fmCalculationVariableParameter;
                var Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
                var Qmf_d = variables[fmGlobalParameter.Qmf_d] as fmCalculationVariableParameter;
                var Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;
                var Qmc_d = variables[fmGlobalParameter.Qmc_d] as fmCalculationVariableParameter;
                var qf = variables[fmGlobalParameter.qf] as fmCalculationVariableParameter;
                var qf_d = variables[fmGlobalParameter.qf_d] as fmCalculationVariableParameter;
                var qs = variables[fmGlobalParameter.qs] as fmCalculationVariableParameter;
                var qs_d = variables[fmGlobalParameter.qs_d] as fmCalculationVariableParameter;
                var qc = variables[fmGlobalParameter.qc] as fmCalculationVariableParameter;
                var qc_d = variables[fmGlobalParameter.qc_d] as fmCalculationVariableParameter;
                var qsus = variables[fmGlobalParameter.qsus] as fmCalculationVariableParameter;
                var qsus_d = variables[fmGlobalParameter.qsus_d] as fmCalculationVariableParameter;
                var qmsus = variables[fmGlobalParameter.qmsus] as fmCalculationVariableParameter;
                var qmsus_d = variables[fmGlobalParameter.qmsus_d] as fmCalculationVariableParameter;
                var qms = variables[fmGlobalParameter.qms] as fmCalculationVariableParameter;
                var qms_d = variables[fmGlobalParameter.qms_d] as fmCalculationVariableParameter;
                var qmf = variables[fmGlobalParameter.qmf] as fmCalculationVariableParameter;
                var qmf_d = variables[fmGlobalParameter.qmf_d] as fmCalculationVariableParameter;
                var qmc = variables[fmGlobalParameter.qmc] as fmCalculationVariableParameter;
                var qmc_d = variables[fmGlobalParameter.qmc_d] as fmCalculationVariableParameter;
                var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
                var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
                var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
                var mf = variables[fmGlobalParameter.mf] as fmCalculationVariableParameter;
                var vf = variables[fmGlobalParameter.vf] as fmCalculationVariableParameter;
                var ms = variables[fmGlobalParameter.ms] as fmCalculationVariableParameter;
                var vs = variables[fmGlobalParameter.vs] as fmCalculationVariableParameter;
                var msus = variables[fmGlobalParameter.msus] as fmCalculationVariableParameter;
                var vsus = variables[fmGlobalParameter.vsus] as fmCalculationVariableParameter;
                var mc = variables[fmGlobalParameter.mc] as fmCalculationVariableParameter;
                var vc = variables[fmGlobalParameter.vc] as fmCalculationVariableParameter;
                var Vc = variables[fmGlobalParameter.Vc] as fmCalculationVariableParameter;
                var Mc = variables[fmGlobalParameter.Mc] as fmCalculationVariableParameter;
                var Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
                var Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
                var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
                var eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
                var kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
                var Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
                var eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
                var rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
                var rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
                var rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
                var Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
                var hce = variables[fmGlobalParameter.hce0] as fmCalculationConstantParameter;
                // ReSharper restore InconsistentNaming

                hc_over_tf.value = fmFilterMachiningEquations.Eval_hc_over_tf_From_hc_tf(hc.value, tf.value);
                dhc_over_dt.value = fmFilterMachiningEquations.Eval_dhc_over_dt_From_kappa_Dp_Pc_eta_hc_hce(kappa.value, Dp.value, Pc.value, eta_f.value, hc.value, hce.value);
                Mc.value = fmFilterMachiningEquations.Eval_Cake_From_Sus_Flow(Msus.value, Mf.value);
                Vc.value = fmFilterMachiningEquations.Eval_Cake_From_Sus_Flow(Vsus.value, Vf.value);
                mf.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mf.value, A.value);
                vf.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vf.value, A.value);
                msus.value = fmFilterMachiningEquations.Eval_m_From_M_A(Msus.value, A.value);
                vsus.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vsus.value, A.value);
                ms.value = fmFilterMachiningEquations.Eval_m_From_M_A(Ms.value, A.value);
                vs.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vs.value, A.value);
                mc.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mc.value, A.value);
                vc.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vc.value, A.value);
                Qsus_d.value = fmFilterMachiningEquations.Eval_Qsus_d_From_eps_A_Cv_dhcdt(eps.value, A.value, Cv.value, dhc_over_dt.value);
                Qmsus_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Qsus_d.value);
                Qs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
                Qs_d.value = fmFilterMachiningEquations.Eval_Qs_d_From_eps_A_dhcdt(eps.value, A.value, dhc_over_dt.value);
                Qms_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_s.value, Qs_d.value);
                Qmf.value = fmFilterMachiningEquations.Eval_Qm_From_M_t(Mf.value, tf.value);
                Qf.value = fmFilterMachiningEquations.Eval_Q_From_V_t(Vf.value, tf.value);
                Qf_d.value = fmFilterMachiningEquations.Eval_Qf_d_From_A_Dp_Pc_eta_hc_hce(A.value, Dp.value, Pc.value, eta_f.value, hc.value, hce.value);
                Qmf_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Qf_d.value);
                Qmc.value = fmFilterMachiningEquations.Eval_Qm_From_M_t(Mc.value, tc.value);
                Qc_d.value = fmFilterMachiningEquations.Eval_Cake_From_Sus_Flow(Qsus_d.value, Qf_d.value);
                Qmc_d.value = fmFilterMachiningEquations.Eval_Cake_From_Sus_Flow(Qmsus_d.value, Qmf_d.value);
                Qc.value = fmFilterMachiningEquations.Eval_Q_From_V_t(Vc.value, tc.value);
                qf.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qf.value, A.value);
                qf_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qf_d.value, A.value);
                qsus.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qsus.value, A.value);
                qsus_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qsus_d.value, A.value);
                qs.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qs.value, A.value);
                qs_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qs_d.value, A.value);
                qc.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qc.value, A.value);
                qc_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qc_d.value, A.value);
                qmf.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmf.value, A.value);
                qmf_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmf_d.value, A.value);
                qmsus.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmsus.value, A.value);
                qmsus_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmsus_d.value, A.value);
                qms.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qms.value, A.value);
                qms_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qms_d.value, A.value);
                qmc.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmc.value, A.value);
                qmc_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmc_d.value, A.value);
            }
        }

        private class QpCalculatorHelperForDpInput : fmCalculationLibrary.NumericalMethods.fmFunction
        {
            public enum AreaKind
            {
                PLAIN,
                CYLINDRICAL
            }
            fmFilterMachiningCalculator fmc;
            fmValue QpValue;
            AreaKind areaKind;
            public QpCalculatorHelperForDpInput(fmFilterMachiningCalculator fmc, fmValue QpValue, AreaKind areaKind)
            {
                this.fmc = fmc;
                this.QpValue = QpValue;
                this.areaKind = areaKind;
            }
            override public fmValue Eval(fmValue x)
            {
                fmc.variables[fmGlobalParameter.Dp].value = x;
                switch (areaKind) 
                {
                    case AreaKind.PLAIN:
                       fmc.DoSubCalculationsPlainQpConstVolumetricPump();
                       break;
                    case AreaKind.CYLINDRICAL:
                       fmc.DoSubCalculationsCylindricalQpConstVolumetricPump();
                       break;
                    default:
                       throw new Exception("Unhandled area kind.");
                }
                fmValue res = fmc.variables[fmGlobalParameter.Qsus_d].value - QpValue;
                return res;
            }
        };

        private void DoSubCalculationsPlainQpConstVolumetricPump()
        {
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var Qp = variables[fmGlobalParameter.Qsus_d] as fmCalculationVariableParameter;
            if (Dp.isInputed)
            {
                DoSubCalculationsPlainQpConst();
            }
            else
            {
                Dp.isInputed = true;
                Qp.isInputed = false;

                fmValue qpValue = Qp.value;
                QpCalculatorHelperForDpInput qpCalc = new QpCalculatorHelperForDpInput(this, qpValue, QpCalculatorHelperForDpInput.AreaKind.PLAIN);
                Dp.value = fmCalculationLibrary.NumericalMethods.fmBisectionMethod.FindRoot(qpCalc, new fmValue(0), new fmValue(1e18), 80);
                qpCalc.Eval(Dp.value);
                Qp.value = qpValue;

                Dp.isInputed = false;
                Qp.isInputed = true;
            }
        }

        private void DoCalculationsStandart()
        {
            if (IsStandartSubKind1DpOption(calculationOption))
            {
                DoSubCalculationsStandart123();
            }
            else if (IsStandartSubKind2HcOption(calculationOption))
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

            // ReSharper disable InconsistentNaming
            var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            var Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            var Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            var Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
            var Cm = variables[fmGlobalParameter.Cm] as fmCalculationConstantParameter;
            // ReSharper restore InconsistentNaming

            // ReSharper disable PossibleNullReferenceException
            Qsus.value = fmFilterMachiningEquations.Eval_Qsus_From_Vsus_tc(Vsus.value, tc.value);
            Qmsus.value = fmFilterMachiningEquations.Eval_Qmsus_From_Msus_tc(Msus.value, tc.value);
            Qms.value = fmFilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(Qmsus.value, Cm.value);
            // ReSharper restore PossibleNullReferenceException
        }

        private void DoCalculationsDesign()
        {
            DoSubCalculationsDesign1();
        }

        private void DoSubCalculationsCylindricalQpConst()
        {
            // ReSharper disable InconsistentNaming
            var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            var d0 = variables[fmGlobalParameter.d0] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            var sr = variables[fmGlobalParameter.sr] as fmCalculationVariableParameter;
            var n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            var mf = variables[fmGlobalParameter.mf] as fmCalculationVariableParameter;
            var vf = variables[fmGlobalParameter.vf] as fmCalculationVariableParameter;
            var ms = variables[fmGlobalParameter.ms] as fmCalculationVariableParameter;
            var vs = variables[fmGlobalParameter.vs] as fmCalculationVariableParameter;
            var msus = variables[fmGlobalParameter.msus] as fmCalculationVariableParameter;
            var vsus = variables[fmGlobalParameter.vsus] as fmCalculationVariableParameter;
            var mc = variables[fmGlobalParameter.mc] as fmCalculationVariableParameter;
            var vc = variables[fmGlobalParameter.vc] as fmCalculationVariableParameter;
            var Vc = variables[fmGlobalParameter.Vc] as fmCalculationVariableParameter;
            var Mc = variables[fmGlobalParameter.Mc] as fmCalculationVariableParameter;
            var Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            var Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;

            var Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
            var Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            var Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
            var Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
            var Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
            var Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            var Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            var Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;
            var Qsus_d = variables[fmGlobalParameter.Qsus_d] as fmCalculationVariableParameter;

            var hc_over_tf = variables[fmGlobalParameter.hc_over_tf];
            var dhc_over_dt = variables[fmGlobalParameter.dhc_over_dt];
            var Qf_d = variables[fmGlobalParameter.Qf_d];
            var Qs_d = variables[fmGlobalParameter.Qs_d];
            var Qc_d = variables[fmGlobalParameter.Qc_d];
            var Qmsus_d = variables[fmGlobalParameter.Qmsus_d];
            var Qms_d = variables[fmGlobalParameter.Qms_d];
            var Qmf_d = variables[fmGlobalParameter.Qmf_d];
            var Qmc_d = variables[fmGlobalParameter.Qmc_d];
            var qf = variables[fmGlobalParameter.qf];
            var qf_d = variables[fmGlobalParameter.qf_d];
            var qs = variables[fmGlobalParameter.qs];
            var qs_d = variables[fmGlobalParameter.qs_d];
            var qc = variables[fmGlobalParameter.qc];
            var qc_d = variables[fmGlobalParameter.qc_d];
            var qsus = variables[fmGlobalParameter.qsus];
            var qsus_d = variables[fmGlobalParameter.qsus_d];
            var qmsus = variables[fmGlobalParameter.qmsus];
            var qmsus_d = variables[fmGlobalParameter.qmsus_d];
            var qms = variables[fmGlobalParameter.qms];
            var qms_d = variables[fmGlobalParameter.qms_d];
            var qmf = variables[fmGlobalParameter.qmf];
            var qmf_d = variables[fmGlobalParameter.qmf_d];
            var qmc = variables[fmGlobalParameter.qmc];
            var qmc_d = variables[fmGlobalParameter.qmc_d];

            var eps = variables[fmGlobalParameter.eps];
            var kappa = variables[fmGlobalParameter.kappa];
            var Pc = variables[fmGlobalParameter.Pc];
            var rc = variables[fmGlobalParameter.rc];
            var a = variables[fmGlobalParameter.a];

            var eps0 = variables[fmGlobalParameter.eps0];
            var Pc0 = variables[fmGlobalParameter.Pc0];
            var eta_f = variables[fmGlobalParameter.eta_f];
            var rho_f = variables[fmGlobalParameter.rho_f];
            var rho_s = variables[fmGlobalParameter.rho_s];
            var rho_sus = variables[fmGlobalParameter.rho_sus];
            var Cv = variables[fmGlobalParameter.Cv];
            var Cm = variables[fmGlobalParameter.Cm];
            var ne = variables[fmGlobalParameter.ne];
            var nc = variables[fmGlobalParameter.nc];
            var hce = variables[fmGlobalParameter.hce0];
            // ReSharper restore InconsistentNaming

            eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = fmFilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = fmPcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            // ReSharper disable InconsistentNaming
            var isKnown_A = A.isInputed;
            var isKnown_sf = sf.isInputed;
            var isKnown_sr = sr.isInputed;
            var isKnown_n = n.isInputed;
            var isKnown_tc = tc.isInputed;
            var isKnown_tf = tf.isInputed;
            var isKnown_tr = tr.isInputed;
            var isKnown_hc = hc.isInputed;
            var isKnown_Vsus = Vsus.isInputed;
            var isKnown_Mf = Mf.isInputed;
            var isKnown_Vf = Vf.isInputed;
            var isKnown_mf = mf.isInputed;
            var isKnown_vf = vf.isInputed;
            var isKnown_ms = ms.isInputed;
            var isKnown_vs = vs.isInputed;
            var isKnown_msus = msus.isInputed;
            var isKnown_vsus = vsus.isInputed;
            var isKnown_mc = mc.isInputed;
            var isKnown_vc = vc.isInputed;
            var isKnown_Vc = Vc.isInputed;
            var isKnown_Mc = Mc.isInputed;
            var isKnown_Ms = Ms.isInputed;
            var isKnown_Vs = Vs.isInputed;
            var isKnown_Msus = Msus.isInputed;
            var isKnown_Qf = Qf.isInputed;
            var isKnown_Qs = Qs.isInputed;
            var isKnown_Qsus = Qsus.isInputed;
            var isKnown_Qc = Qc.isInputed;
            var isKnown_Qmf = Qmf.isInputed;
            var isKnown_Qms = Qms.isInputed;
            var isKnown_Qmsus = Qmsus.isInputed;
            var isKnown_Qmc = Qmc.isInputed;
            var isKnown_Qsusd = Qsus_d.isInputed;
            // ReSharper restore InconsistentNaming

            #region A0
            if (isKnown_A)
            {
                if (isKnown_Msus)
                {
                    msus.value = fmFilterMachiningEquations.Eval_m_From_M_A(Msus.value, A.value);
                    isKnown_msus = true;
                }

                if (isKnown_Ms)
                {
                    ms.value = fmFilterMachiningEquations.Eval_m_From_M_A(Ms.value, A.value);
                    isKnown_ms = true;
                }

                if (isKnown_Mc)
                {
                    mc.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mc.value, A.value);
                    isKnown_mc = true;
                }

                if (isKnown_Mf)
                {
                    mf.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mf.value, A.value);
                    isKnown_mf = true;
                }

                if (isKnown_Vsus)
                {
                    vsus.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vsus.value, A.value);
                    isKnown_vsus = true;
                }

                if (isKnown_Vs)
                {
                    vs.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vs.value, A.value);
                    isKnown_vs = true;
                }

                if (isKnown_Vc)
                {
                    vc.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vc.value, A.value);
                    isKnown_vc = true;
                }

                if (isKnown_Vf)
                {
                    vf.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vf.value, A.value);
                    isKnown_vf = true;
                }
            }
            #endregion
            #region A
            if (isKnown_ms)
            {
                vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, ms.value);
                isKnown_vs = true;
            }

            if (isKnown_vs)
            {
                vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_vsus = true;
            }

            if (isKnown_msus)
            {
                vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, msus.value);
                isKnown_vsus = true;
            }

            if (isKnown_vsus)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(vsus.value, kappa.value);
                isKnown_vf = true;
            }

            if (isKnown_mc)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_vf = true;
            }

            if (isKnown_mf)
            {
                vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, mf.value);
                isKnown_vf = true;
            }

            if (isKnown_vf)
            {
                vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(vf.value, kappa.value);
                isKnown_vc = true;
            }

            if (isKnown_vc)
            {
                hc.value = fmFilterMachiningEquations.EvalCandle_hc_From_vc_d(vc.value, d0.value);
                isKnown_hc = true;
            }

            if (isKnown_hc)
            {
                tf.value = fmFilterMachiningEquations.EvalCandle_tf_From_d_hc_hce_eta_Cv_kappa_Pc_Dp_QpConst(eps.value, d0.value, hc.value, hce.value, eta_f.value, Cv.value, kappa.value, Pc.value, Dp.value);
                isKnown_tf = true;
            }
            #endregion
            #region D
            if (isKnown_Ms)
            {
                Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                isKnown_Vs = true;
            }

            if (isKnown_Vs)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Msus)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Vsus)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(Vsus.value, kappa.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Mf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mc)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(Mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Vf = true;
            }

            if (isKnown_Vf)
            {
                Vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(Vf.value, kappa.value);
                isKnown_Vc = true;
            }

            if (isKnown_Vc && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(Vc.value, kappa.value);
                isKnown_Vf = true;
            }
            #endregion
            #region E
            if (isKnown_Qms)
            {
                Qs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
                isKnown_Qs = true;
            }

            if (isKnown_Qmsus)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Qmsus.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qs)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Qs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qsus)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_vsus_kappa(Qsus.value, kappa.value);
                isKnown_Qc = true;
            }

            if (isKnown_Qmc)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_mc_kappa_rho(Qmc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Qc = true;
            }
            #endregion
            #region F
            if (isKnown_Qmf)
            {
                Qf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Qmf.value);
                isKnown_Qf = true;
            }
            if (isKnown_Qsusd)
            {
                Qf.value = fmFilterMachiningEquations.Eval_Qf_From_Qsusd_eps_Cv(Qsus_d.value, eps.value, Cv.value);
                isKnown_Qf = true;
            }
            #endregion
            #region G
            if (isKnown_Qc && isKnown_Vc)
            {
                tc.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qc.value, Vc.value);
                isKnown_tc = true;
            }

            if (isKnown_Qf && isKnown_Vf)
            {
                tf.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qf.value, Vf.value);
                isKnown_tf = true;
            }
            #endregion
            #region B
            if (isKnown_tf)
            {
                if (isKnown_sf)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tf_sf(tf.value, sf.value);
                }
                else if (isKnown_tr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                }
                else if (isKnown_sr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_sr_tf(sr.value, tf.value);
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
                tc.value = fmFilterMachiningEquations.Eval_tc_From_n(n.value);
                isKnown_tc = true;
            }
            #region C
            if (!isKnown_tc)
            {
                throw new Exception("tc must be known in block C.");
            }

            if (!isKnown_tr && isKnown_sr)
            {
                tr.value = fmFilterMachiningEquations.Eval_tr_From_sr_tc(sr.value, tc.value);
                isKnown_tr = true;
            }

            if (!isKnown_sf)
            {
                sf.value = fmFilterMachiningEquations.Eval_sf_From_tr_tc(tr.value, tc.value);
                /*
                                isKnown_sf = true;
                */
            }
            #endregion

            if (!isKnown_n) n.value = fmFilterMachiningEquations.Eval_n_From_tc(tc.value);
            if (!isKnown_tf) tf.value = fmFilterMachiningEquations.Eval_tf_From_sf_tc(sf.value, tc.value);
            if (!isKnown_tr) tr.value = fmFilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
            if (!isKnown_sr) sr.value = fmFilterMachiningEquations.Eval_sr_From_tc_tr(tc.value, tr.value);
            if (!isKnown_hc) hc.value = fmFilterMachiningEquations.EvalCandle_hc_From_hce_d_eta_Cv_kappa_Pc_Dp_tf_QpConst(eps.value, hce.value, d0.value, eta_f.value, Cv.value, kappa.value, Pc.value, Dp.value, tf.value);
            
            if (!isKnown_vc) vc.value = fmFilterMachiningEquations.EvalCandle_vc_From_hc_d(hc.value, d0.value);
            if (!isKnown_vf) vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(vc.value, kappa.value);
            if (!isKnown_vsus) vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vf_kappa(vf.value, kappa.value);
            if (!isKnown_vs) vs.value = fmFilterMachiningEquations.Eval_vs_From_vsus_rho_Cm(vsus.value, rho_sus.value, rho_s.value, Cm.value);

            if (!isKnown_mc) mc.value = fmFilterMachiningEquations.Eval_mc_From_vf_kappa_rho(vf.value, kappa.value, rho_sus.value, rho_f.value);
            if (!isKnown_mf) mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, vf.value);
            if (!isKnown_msus) msus.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, vsus.value);
            if (!isKnown_ms) ms.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_s.value, vs.value);

            if (isKnown_Qf && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qf.value, tf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Qc && !isKnown_Vc)
            {
                Vc.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qc.value, tc.value);
                isKnown_Vc = true;
            }

            if (!isKnown_A && isKnown_Vf)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vf.value, vf.value);
                isKnown_A = true;
            }

            if (!isKnown_A && isKnown_Vc)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vc.value, vc.value);
                /*
                                isKnown_A = true;
                */
            }

            if (!isKnown_Qsusd) Qsus_d.value = fmFilterMachiningEquations.EvalCandle_Qsus_d_From_d_hc_hce_A_kappa_Pc_Dp_eta_QpConst(d0.value, hc.value, hce.value, A.value, kappa.value, Pc.value, Dp.value, eta_f.value);

            if (!isKnown_Vc) Vc.value = fmFilterMachiningEquations.Eval_V_From_v_A(vc.value, A.value);
            if (!isKnown_Vf) Vf.value = fmFilterMachiningEquations.Eval_V_From_v_A(vf.value, A.value);
            if (!isKnown_Vsus) Vsus.value = fmFilterMachiningEquations.Eval_V_From_v_A(vsus.value, A.value);
            if (!isKnown_Vs) Vs.value = fmFilterMachiningEquations.Eval_V_From_v_A(vs.value, A.value);

            if (!isKnown_Mc) Mc.value = fmFilterMachiningEquations.Eval_M_From_m_A(mc.value, A.value);
            if (!isKnown_Mf) Mf.value = fmFilterMachiningEquations.Eval_M_From_m_A(mf.value, A.value);
            if (!isKnown_Msus) Msus.value = fmFilterMachiningEquations.Eval_M_From_m_A(msus.value, A.value);
            if (!isKnown_Ms) Ms.value = fmFilterMachiningEquations.Eval_M_From_m_A(ms.value, A.value);

            if (!isKnown_Qmsus) Qmsus.value = fmFilterMachiningEquations.Eval_Qmsus_From_Msus_tc(Msus.value, tc.value);
            if (!isKnown_Qms) Qms.value = fmFilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(Qmsus.value, Cm.value);
            if (!isKnown_Qmf) Qmf.value = fmFilterMachiningEquations.Eval_Qm_From_M_t(Mf.value, tf.value);
            if (!isKnown_Qmc) Qmc.value = fmFilterMachiningEquations.Eval_Qm_From_M_t(Mc.value, tc.value);

            if (!isKnown_Qsus) Qsus.value = fmFilterMachiningEquations.Eval_Qsus_From_Vsus_tc(Vsus.value, tc.value);
            if (!isKnown_Qs) Qs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
            if (!isKnown_Qf) Qf.value = fmFilterMachiningEquations.Eval_Q_From_V_t(Vf.value, tf.value);
            if (!isKnown_Qc) Qc.value = fmFilterMachiningEquations.Eval_Q_From_V_t(Vc.value, tc.value);

            hc_over_tf.value = fmFilterMachiningEquations.Eval_hc_over_tf_From_hc_tf(hc.value, tf.value);
            dhc_over_dt.value = fmFilterMachiningEquations.Eval_dhc_over_dt_From_kappa_Dp_Pc_eta_hc_hce(kappa.value, Dp.value, Pc.value, eta_f.value, hc.value, hce.value);
            Qmsus_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Qsus_d.value);
            Qs_d.value = fmFilterMachiningEquations.Eval_Qs_d_From_eps_A_dhcdt(eps.value, A.value, dhc_over_dt.value);
            Qms_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_s.value, Qs_d.value);
            Qf_d.value = fmFilterMachiningEquations.Eval_Qf_d_From_A_Dp_Pc_eta_hc_hce(A.value, Dp.value, Pc.value, eta_f.value, hc.value, hce.value);
            Qmf_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Qf_d.value);
            Qc_d.value = fmFilterMachiningEquations.Eval_Cake_From_Sus_Flow(Qsus_d.value, Qf_d.value);
            Qmc_d.value = fmFilterMachiningEquations.Eval_Cake_From_Sus_Flow(Qmsus_d.value, Qmf_d.value);
            qf.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qf.value, A.value);
            qf_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qf_d.value, A.value);
            qsus.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qsus.value, A.value);
            qsus_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qsus_d.value, A.value);
            qs.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qs.value, A.value);
            qs_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qs_d.value, A.value);
            qc.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qc.value, A.value);
            qc_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qc_d.value, A.value);
            qmf.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmf.value, A.value);
            qmf_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmf_d.value, A.value);
            qmsus.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmsus.value, A.value);
            qmsus_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmsus_d.value, A.value);
            qms.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qms.value, A.value);
            qms_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qms_d.value, A.value);
            qmc.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmc.value, A.value);
            qmc_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmc_d.value, A.value);
        }
        private void DoSubCalculationsPlainQpConst()
        {
            // ReSharper disable InconsistentNaming
            var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            var sr = variables[fmGlobalParameter.sr] as fmCalculationVariableParameter;
            var n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            var mf = variables[fmGlobalParameter.mf] as fmCalculationVariableParameter;
            var vf = variables[fmGlobalParameter.vf] as fmCalculationVariableParameter;
            var ms = variables[fmGlobalParameter.ms] as fmCalculationVariableParameter;
            var vs = variables[fmGlobalParameter.vs] as fmCalculationVariableParameter;
            var msus = variables[fmGlobalParameter.msus] as fmCalculationVariableParameter;
            var vsus = variables[fmGlobalParameter.vsus] as fmCalculationVariableParameter;
            var mc = variables[fmGlobalParameter.mc] as fmCalculationVariableParameter;
            var vc = variables[fmGlobalParameter.vc] as fmCalculationVariableParameter;
            var Vc = variables[fmGlobalParameter.Vc] as fmCalculationVariableParameter;
            var Mc = variables[fmGlobalParameter.Mc] as fmCalculationVariableParameter;
            var Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            var Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;

            var Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
            var Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            var Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
            var Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
            var Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
            var Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            var Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            var Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;
            var Qsus_d = variables[fmGlobalParameter.Qsus_d] as fmCalculationVariableParameter;
            
            var hc_over_tf = variables[fmGlobalParameter.hc_over_tf];
            var dhc_over_dt = variables[fmGlobalParameter.dhc_over_dt];
            var Qf_d = variables[fmGlobalParameter.Qf_d];
            var Qs_d = variables[fmGlobalParameter.Qs_d];
            var Qc_d = variables[fmGlobalParameter.Qc_d];
            var Qmsus_d = variables[fmGlobalParameter.Qmsus_d];
            var Qms_d = variables[fmGlobalParameter.Qms_d];
            var Qmf_d = variables[fmGlobalParameter.Qmf_d];
            var Qmc_d = variables[fmGlobalParameter.Qmc_d];
            var qf = variables[fmGlobalParameter.qf];
            var qf_d = variables[fmGlobalParameter.qf_d];
            var qs = variables[fmGlobalParameter.qs];
            var qs_d = variables[fmGlobalParameter.qs_d];
            var qc = variables[fmGlobalParameter.qc];
            var qc_d = variables[fmGlobalParameter.qc_d];
            var qsus = variables[fmGlobalParameter.qsus];
            var qsus_d = variables[fmGlobalParameter.qsus_d];
            var qmsus = variables[fmGlobalParameter.qmsus];
            var qmsus_d = variables[fmGlobalParameter.qmsus_d];
            var qms = variables[fmGlobalParameter.qms];
            var qms_d = variables[fmGlobalParameter.qms_d];
            var qmf = variables[fmGlobalParameter.qmf];
            var qmf_d = variables[fmGlobalParameter.qmf_d];
            var qmc = variables[fmGlobalParameter.qmc];
            var qmc_d = variables[fmGlobalParameter.qmc_d];

            var eps = variables[fmGlobalParameter.eps];
            var kappa = variables[fmGlobalParameter.kappa];
            var Pc = variables[fmGlobalParameter.Pc];
            var rc = variables[fmGlobalParameter.rc];
            var a = variables[fmGlobalParameter.a];

            var eps0 = variables[fmGlobalParameter.eps0];
            var Pc0 = variables[fmGlobalParameter.Pc0];
            var eta_f = variables[fmGlobalParameter.eta_f];
            var rho_f = variables[fmGlobalParameter.rho_f];
            var rho_s = variables[fmGlobalParameter.rho_s];
            var rho_sus = variables[fmGlobalParameter.rho_sus];
            var Cv = variables[fmGlobalParameter.Cv];
            var Cm = variables[fmGlobalParameter.Cm];
            var ne = variables[fmGlobalParameter.ne];
            var nc = variables[fmGlobalParameter.nc];
            var hce = variables[fmGlobalParameter.hce0];
            // ReSharper restore InconsistentNaming

            eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = fmFilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = fmPcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            // ReSharper disable InconsistentNaming
            var isKnown_A = A.isInputed;
            var isKnown_sf = sf.isInputed;
            var isKnown_sr = sr.isInputed;
            var isKnown_n = n.isInputed;
            var isKnown_tc = tc.isInputed;
            var isKnown_tf = tf.isInputed;
            var isKnown_tr = tr.isInputed;
            var isKnown_hc = hc.isInputed;
            var isKnown_Vsus = Vsus.isInputed;
            var isKnown_Mf = Mf.isInputed;
            var isKnown_Vf = Vf.isInputed;
            var isKnown_mf = mf.isInputed;
            var isKnown_vf = vf.isInputed;
            var isKnown_ms = ms.isInputed;
            var isKnown_vs = vs.isInputed;
            var isKnown_msus = msus.isInputed;
            var isKnown_vsus = vsus.isInputed;
            var isKnown_mc = mc.isInputed;
            var isKnown_vc = vc.isInputed;
            var isKnown_Vc = Vc.isInputed;
            var isKnown_Mc = Mc.isInputed;
            var isKnown_Ms = Ms.isInputed;
            var isKnown_Vs = Vs.isInputed;
            var isKnown_Msus = Msus.isInputed;
            var isKnown_Qf = Qf.isInputed;
            var isKnown_Qs = Qs.isInputed;
            var isKnown_Qsus = Qsus.isInputed;
            var isKnown_Qc = Qc.isInputed;
            var isKnown_Qmf = Qmf.isInputed;
            var isKnown_Qms = Qms.isInputed;
            var isKnown_Qmsus = Qmsus.isInputed;
            var isKnown_Qmc = Qmc.isInputed;
            var isKnown_Qsusd = Qsus_d.isInputed;
            // ReSharper restore InconsistentNaming

            #region A0
            if (isKnown_A)
            {
                if (isKnown_Msus)
                {
                    msus.value = fmFilterMachiningEquations.Eval_m_From_M_A(Msus.value, A.value);
                    isKnown_msus = true;
                }

                if (isKnown_Ms)
                {
                    ms.value = fmFilterMachiningEquations.Eval_m_From_M_A(Ms.value, A.value);
                    isKnown_ms = true;
                }

                if (isKnown_Mc)
                {
                    mc.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mc.value, A.value);
                    isKnown_mc = true;
                }

                if (isKnown_Mf)
                {
                    mf.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mf.value, A.value);
                    isKnown_mf = true;
                }

                if (isKnown_Vsus)
                {
                    vsus.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vsus.value, A.value);
                    isKnown_vsus = true;
                }

                if (isKnown_Vs)
                {
                    vs.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vs.value, A.value);
                    isKnown_vs = true;
                }

                if (isKnown_Vc)
                {
                    vc.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vc.value, A.value);
                    isKnown_vc = true;
                }

                if (isKnown_Vf)
                {
                    vf.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vf.value, A.value);
                    isKnown_vf = true;
                }
            }
            #endregion
            #region A
            if (isKnown_ms)
            {
                vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, ms.value);
                isKnown_vs = true;
            }

            if (isKnown_vs)
            {
                vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_vsus = true;
            }

            if (isKnown_msus)
            {
                vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, msus.value);
                isKnown_vsus = true;
            }

            if (isKnown_vsus)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(vsus.value, kappa.value);
                isKnown_vf = true;
            }

            if (isKnown_mc)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_vf = true;
            }

            if (isKnown_mf)
            {
                vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, mf.value);
                isKnown_vf = true;
            }

            if (isKnown_vf)
            {
                vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(vf.value, kappa.value);
                isKnown_vc = true;
            }

            if (isKnown_vc)
            {
                hc.value = vc.value;
                isKnown_hc = true;
            }

            if (isKnown_hc)
            {
                tf.value = fmFilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp_QpConst(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                isKnown_tf = true;
            }
            #endregion
            #region D
            if (isKnown_Ms)
            {
                Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                isKnown_Vs = true;
            }

            if (isKnown_Vs)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Msus)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Vsus)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(Vsus.value, kappa.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Mf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mc)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(Mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Vf = true;
            }

            if (isKnown_Vf)
            {
                Vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(Vf.value, kappa.value);
                isKnown_Vc = true;
            }

            if (isKnown_Vc && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(Vc.value, kappa.value);
                isKnown_Vf = true;
            }
            #endregion
            #region E
            if (isKnown_Qms)
            {
                Qs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
                isKnown_Qs = true;
            }

            if (isKnown_Qmsus)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Qmsus.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qs)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Qs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qsus)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_vsus_kappa(Qsus.value, kappa.value);
                isKnown_Qc = true;
            }

            if (isKnown_Qmc)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_mc_kappa_rho(Qmc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Qc = true;
            }
            #endregion
            #region F
            if (isKnown_Qmf)
            {
                Qf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Qmf.value);
                isKnown_Qf = true;
            }
            if (isKnown_Qsusd)
            {
                Qf.value = fmFilterMachiningEquations.Eval_Qf_From_Qsusd_eps_Cv(Qsus_d.value, eps.value, Cv.value);
                isKnown_Qf = true;
            }
            #endregion
            #region G
            if (isKnown_Qc && isKnown_Vc)
            {
                tc.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qc.value, Vc.value);
                isKnown_tc = true;
            }

            if (isKnown_Qf && isKnown_Vf)
            {
                tf.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qf.value, Vf.value);
                isKnown_tf = true;
            }
            #endregion
            #region B
            if (isKnown_tf)
            {
                if (isKnown_sf)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tf_sf(tf.value, sf.value);
                }
                else if (isKnown_tr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                }
                else if (isKnown_sr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_sr_tf(sr.value, tf.value);
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
                tc.value = fmFilterMachiningEquations.Eval_tc_From_n(n.value);
                isKnown_tc = true;
            }
            #region C
            if (!isKnown_tc)
            {
                throw new Exception("tc must be known in block C.");
            }

            if (!isKnown_tr && isKnown_sr)
            {
                tr.value = fmFilterMachiningEquations.Eval_tr_From_sr_tc(sr.value, tc.value);
                isKnown_tr = true;
            }

            if (!isKnown_sf)
            {
                sf.value = fmFilterMachiningEquations.Eval_sf_From_tr_tc(tr.value, tc.value);
                /*
                                isKnown_sf = true;
                */
            }
            #endregion

            if (!isKnown_n) n.value = fmFilterMachiningEquations.Eval_n_From_tc(tc.value);
            if (!isKnown_tf) tf.value = fmFilterMachiningEquations.Eval_tf_From_sf_tc(sf.value, tc.value);
            if (!isKnown_tr) tr.value = fmFilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
            if (!isKnown_sr) sr.value = fmFilterMachiningEquations.Eval_sr_From_tc_tr(tc.value, tr.value);
            if (!isKnown_hc) hc.value = fmFilterMachiningEquations.Eval_hc_From_hce_Pc_kappa_Dp_tf_etaf_QpConst(hce.value, Pc.value, kappa.value, Dp.value, tf.value, eta_f.value);

            if (!isKnown_vc) vc.value = hc.value;
            if (!isKnown_vf) vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(vc.value, kappa.value);
            if (!isKnown_vsus) vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vf_kappa(vf.value, kappa.value);
            if (!isKnown_vs) vs.value = fmFilterMachiningEquations.Eval_vs_From_vsus_rho_Cm(vsus.value, rho_sus.value, rho_s.value, Cm.value);

            if (!isKnown_mc) mc.value = fmFilterMachiningEquations.Eval_mc_From_vf_kappa_rho(vf.value, kappa.value, rho_sus.value, rho_f.value);
            if (!isKnown_mf) mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, vf.value);
            if (!isKnown_msus) msus.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, vsus.value);
            if (!isKnown_ms) ms.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_s.value, vs.value);

            if (isKnown_Qf && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qf.value, tf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Qc && !isKnown_Vc)
            {
                Vc.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qc.value, tc.value);
                isKnown_Vc = true;
            }

            if (!isKnown_A && isKnown_Vf)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vf.value, vf.value);
                isKnown_A = true;
            }

            if (!isKnown_A && isKnown_Vc)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vc.value, vc.value);
                /*
                                isKnown_A = true;
                */
            }

            if (!isKnown_Qsusd) Qsus_d.value = fmFilterMachiningEquations.Eval_Qsus_d_From_A_Dp_Pc_eta_f_Cv_eps_hc_hce_QpConst(A.value, Dp.value, Pc.value, eta_f.value, Cv.value, eps.value, hc.value, hce.value);

            if (!isKnown_Vc) Vc.value = fmFilterMachiningEquations.Eval_V_From_v_A(vc.value, A.value);
            if (!isKnown_Vf) Vf.value = fmFilterMachiningEquations.Eval_V_From_v_A(vf.value, A.value);
            if (!isKnown_Vsus) Vsus.value = fmFilterMachiningEquations.Eval_V_From_v_A(vsus.value, A.value);
            if (!isKnown_Vs) Vs.value = fmFilterMachiningEquations.Eval_V_From_v_A(vs.value, A.value);

            if (!isKnown_Mc) Mc.value = fmFilterMachiningEquations.Eval_M_From_m_A(mc.value, A.value);
            if (!isKnown_Mf) Mf.value = fmFilterMachiningEquations.Eval_M_From_m_A(mf.value, A.value);
            if (!isKnown_Msus) Msus.value = fmFilterMachiningEquations.Eval_M_From_m_A(msus.value, A.value);
            if (!isKnown_Ms) Ms.value = fmFilterMachiningEquations.Eval_M_From_m_A(ms.value, A.value);

            if (!isKnown_Qmsus) Qmsus.value = fmFilterMachiningEquations.Eval_Qmsus_From_Msus_tc(Msus.value, tc.value);
            if (!isKnown_Qms) Qms.value = fmFilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(Qmsus.value, Cm.value);
            if (!isKnown_Qmf) Qmf.value = fmFilterMachiningEquations.Eval_Qm_From_M_t(Mf.value, tf.value);
            if (!isKnown_Qmc) Qmc.value = fmFilterMachiningEquations.Eval_Qm_From_M_t(Mc.value, tc.value);

            if (!isKnown_Qsus) Qsus.value = fmFilterMachiningEquations.Eval_Qsus_From_Vsus_tc(Vsus.value, tc.value);
            if (!isKnown_Qs) Qs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
            if (!isKnown_Qf) Qf.value = fmFilterMachiningEquations.Eval_Q_From_V_t(Vf.value, tf.value);
            if (!isKnown_Qc) Qc.value = fmFilterMachiningEquations.Eval_Q_From_V_t(Vc.value, tc.value);

            hc_over_tf.value = fmFilterMachiningEquations.Eval_hc_over_tf_From_hc_tf(hc.value, tf.value);
            dhc_over_dt.value = fmFilterMachiningEquations.Eval_dhc_over_dt_From_kappa_Dp_Pc_eta_hc_hce(kappa.value, Dp.value, Pc.value, eta_f.value, hc.value, hce.value);
            Qmsus_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Qsus_d.value);
            Qs_d.value = fmFilterMachiningEquations.Eval_Qs_d_From_eps_A_dhcdt(eps.value, A.value, dhc_over_dt.value);
            Qms_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_s.value, Qs_d.value);
            Qf_d.value = fmFilterMachiningEquations.Eval_Qf_d_From_A_Dp_Pc_eta_hc_hce(A.value, Dp.value, Pc.value, eta_f.value, hc.value, hce.value);
            Qmf_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Qf_d.value);
            Qc_d.value = fmFilterMachiningEquations.Eval_Cake_From_Sus_Flow(Qsus_d.value, Qf_d.value);
            Qmc_d.value = fmFilterMachiningEquations.Eval_Cake_From_Sus_Flow(Qmsus_d.value, Qmf_d.value);
            qf.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qf.value, A.value);
            qf_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qf_d.value, A.value);
            qsus.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qsus.value, A.value);
            qsus_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qsus_d.value, A.value);
            qs.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qs.value, A.value);
            qs_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qs_d.value, A.value);
            qc.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qc.value, A.value);
            qc_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qc_d.value, A.value);
            qmf.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmf.value, A.value);
            qmf_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmf_d.value, A.value);
            qmsus.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmsus.value, A.value);
            qmsus_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmsus_d.value, A.value);
            qms.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qms.value, A.value);
            qms_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qms_d.value, A.value);
            qmc.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmc.value, A.value);
            qmc_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmc_d.value, A.value);
        }
        private void DoSubCalculationsCylindricaleDpConst()
        {
            // ReSharper disable InconsistentNaming
            var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            var d0 = variables[fmGlobalParameter.d0] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            var sr = variables[fmGlobalParameter.sr] as fmCalculationVariableParameter;
            var n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            var mf = variables[fmGlobalParameter.mf] as fmCalculationVariableParameter;
            var vf = variables[fmGlobalParameter.vf] as fmCalculationVariableParameter;
            var ms = variables[fmGlobalParameter.ms] as fmCalculationVariableParameter;
            var vs = variables[fmGlobalParameter.vs] as fmCalculationVariableParameter;
            var msus = variables[fmGlobalParameter.msus] as fmCalculationVariableParameter;
            var vsus = variables[fmGlobalParameter.vsus] as fmCalculationVariableParameter;
            var mc = variables[fmGlobalParameter.mc] as fmCalculationVariableParameter;
            var vc = variables[fmGlobalParameter.vc] as fmCalculationVariableParameter;
            var Vc = variables[fmGlobalParameter.Vc] as fmCalculationVariableParameter;
            var Mc = variables[fmGlobalParameter.Mc] as fmCalculationVariableParameter;
            var Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            var Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;

            var Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
            var Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            var Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
            var Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
            var Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
            var Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            var Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            var Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;

            var hc_over_tf = variables[fmGlobalParameter.hc_over_tf];
            var dhc_over_dt = variables[fmGlobalParameter.dhc_over_dt];
            var Qf_d = variables[fmGlobalParameter.Qf_d];
            var Qs_d = variables[fmGlobalParameter.Qs_d];
            var Qc_d = variables[fmGlobalParameter.Qc_d];
            var Qsus_d = variables[fmGlobalParameter.Qsus_d];
            var Qmsus_d = variables[fmGlobalParameter.Qmsus_d];
            var Qms_d = variables[fmGlobalParameter.Qms_d];
            var Qmf_d = variables[fmGlobalParameter.Qmf_d];
            var Qmc_d = variables[fmGlobalParameter.Qmc_d];
            var qf = variables[fmGlobalParameter.qf];
            var qf_d = variables[fmGlobalParameter.qf_d];
            var qs = variables[fmGlobalParameter.qs];
            var qs_d = variables[fmGlobalParameter.qs_d];
            var qc = variables[fmGlobalParameter.qc];
            var qc_d = variables[fmGlobalParameter.qc_d];
            var qsus = variables[fmGlobalParameter.qsus];
            var qsus_d = variables[fmGlobalParameter.qsus_d];
            var qmsus = variables[fmGlobalParameter.qmsus];
            var qmsus_d = variables[fmGlobalParameter.qmsus_d];
            var qms = variables[fmGlobalParameter.qms];
            var qms_d = variables[fmGlobalParameter.qms_d];
            var qmf = variables[fmGlobalParameter.qmf];
            var qmf_d = variables[fmGlobalParameter.qmf_d];
            var qmc = variables[fmGlobalParameter.qmc];
            var qmc_d = variables[fmGlobalParameter.qmc_d];

            var eps = variables[fmGlobalParameter.eps];
            var kappa = variables[fmGlobalParameter.kappa];
            var Pc = variables[fmGlobalParameter.Pc];
            var rc = variables[fmGlobalParameter.rc];
            var a = variables[fmGlobalParameter.a];

            var eps0 = variables[fmGlobalParameter.eps0];
            var Pc0 = variables[fmGlobalParameter.Pc0];
            var eta_f = variables[fmGlobalParameter.eta_f];
            var rho_f = variables[fmGlobalParameter.rho_f];
            var rho_s = variables[fmGlobalParameter.rho_s];
            var rho_sus = variables[fmGlobalParameter.rho_sus];
            var Cv = variables[fmGlobalParameter.Cv];
            var Cm = variables[fmGlobalParameter.Cm];
            var ne = variables[fmGlobalParameter.ne];
            var nc = variables[fmGlobalParameter.nc];
            var hce = variables[fmGlobalParameter.hce0];
            // ReSharper restore InconsistentNaming

            eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = fmFilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = fmPcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            // ReSharper disable InconsistentNaming
            var isKnown_A = A.isInputed;
            var isKnown_sf = sf.isInputed;
            var isKnown_sr = sr.isInputed;
            var isKnown_n = n.isInputed;
            var isKnown_tc = tc.isInputed;
            var isKnown_tf = tf.isInputed;
            var isKnown_tr = tr.isInputed;
            var isKnown_hc = hc.isInputed;
            var isKnown_Vsus = Vsus.isInputed;
            var isKnown_Mf = Mf.isInputed;
            var isKnown_Vf = Vf.isInputed;
            var isKnown_mf = mf.isInputed;
            var isKnown_vf = vf.isInputed;
            var isKnown_ms = ms.isInputed;
            var isKnown_vs = vs.isInputed;
            var isKnown_msus = msus.isInputed;
            var isKnown_vsus = vsus.isInputed;
            var isKnown_mc = mc.isInputed;
            var isKnown_vc = vc.isInputed;
            var isKnown_Vc = Vc.isInputed;
            var isKnown_Mc = Mc.isInputed;
            var isKnown_Ms = Ms.isInputed;
            var isKnown_Vs = Vs.isInputed;
            var isKnown_Msus = Msus.isInputed;
            var isKnown_Qf = Qf.isInputed;
            var isKnown_Qs = Qs.isInputed;
            var isKnown_Qsus = Qsus.isInputed;
            var isKnown_Qc = Qc.isInputed;
            var isKnown_Qmf = Qmf.isInputed;
            var isKnown_Qms = Qms.isInputed;
            var isKnown_Qmsus = Qmsus.isInputed;
            var isKnown_Qmc = Qmc.isInputed;
            // ReSharper restore InconsistentNaming

            #region A0
            if (isKnown_A)
            {
                if (isKnown_Msus)
                {
                    msus.value = fmFilterMachiningEquations.Eval_m_From_M_A(Msus.value, A.value);
                    isKnown_msus = true;
                }

                if (isKnown_Ms)
                {
                    ms.value = fmFilterMachiningEquations.Eval_m_From_M_A(Ms.value, A.value);
                    isKnown_ms = true;
                }

                if (isKnown_Mc)
                {
                    mc.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mc.value, A.value);
                    isKnown_mc = true;
                }

                if (isKnown_Mf)
                {
                    mf.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mf.value, A.value);
                    isKnown_mf = true;
                }

                if (isKnown_Vsus)
                {
                    vsus.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vsus.value, A.value);
                    isKnown_vsus = true;
                }

                if (isKnown_Vs)
                {
                    vs.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vs.value, A.value);
                    isKnown_vs = true;
                }

                if (isKnown_Vc)
                {
                    vc.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vc.value, A.value);
                    isKnown_vc = true;
                }

                if (isKnown_Vf)
                {
                    vf.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vf.value, A.value);
                    isKnown_vf = true;
                }
            }
            #endregion
            #region A
            if (isKnown_ms)
            {
                vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, ms.value);
                isKnown_vs = true;
            }

            if (isKnown_vs)
            {
                vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_vsus = true;
            }

            if (isKnown_msus)
            {
                vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, msus.value);
                isKnown_vsus = true;
            }

            if (isKnown_vsus)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(vsus.value, kappa.value);
                isKnown_vf = true;
            }

            if (isKnown_mc)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_vf = true;
            }

            if (isKnown_mf)
            {
                vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, mf.value);
                isKnown_vf = true;
            }

            if (isKnown_vf)
            {
                vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(vf.value, kappa.value);
                isKnown_vc = true;
            }

            if (isKnown_vc)
            {
                hc.value = fmFilterMachiningEquations.EvalCandle_hc_From_vc_d(vc.value, d0.value);
                isKnown_hc = true;
            }

            if (isKnown_hc)
            {
                tf.value = fmFilterMachiningEquations.EvalCandle_tf_From_d_eta_kappa_Pc_Dp_hc_hce(d0.value, eta_f.value, kappa.value, Pc.value, Dp.value, hc.value, hce.value);
                isKnown_tf = true;
            }
            #endregion
            #region D
            if (isKnown_Ms)
            {
                Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                isKnown_Vs = true;
            }

            if (isKnown_Vs)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Msus)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Vsus)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(Vsus.value, kappa.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Mf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mc)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(Mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Vf = true;
            }

            if (isKnown_Vf)
            {
                Vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(Vf.value, kappa.value);
                isKnown_Vc = true;
            }

            if (isKnown_Vc && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(Vc.value, kappa.value);
                isKnown_Vf = true;
            }
            #endregion
            #region E
            if (isKnown_Qms)
            {
                Qs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
                isKnown_Qs = true;
            }

            if (isKnown_Qmsus)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Qmsus.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qs)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Qs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qsus)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_vsus_kappa(Qsus.value, kappa.value);
                isKnown_Qc = true;
            }

            if (isKnown_Qmc)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_mc_kappa_rho(Qmc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Qc = true;
            }
            #endregion
            #region F
            if (isKnown_Qmf)
            {
                Qf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Qmf.value);
                isKnown_Qf = true;
            }
            #endregion
            #region G
            if (isKnown_Qc && isKnown_Vc)
            {
                tc.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qc.value, Vc.value);
                isKnown_tc = true;
            }

            if (isKnown_Qf && isKnown_Vf)
            {
                tf.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qf.value, Vf.value);
                isKnown_tf = true;
            }
            #endregion
            #region B
            if (isKnown_tf)
            {
                if (isKnown_sf)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tf_sf(tf.value, sf.value);
                }
                else if (isKnown_tr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                }
                else if (isKnown_sr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_sr_tf(sr.value, tf.value);
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
                tc.value = fmFilterMachiningEquations.Eval_tc_From_n(n.value);
                isKnown_tc = true;
            }
            #region C
            if (!isKnown_tc)
            {
                throw new Exception("tc must be known in block C.");
            }

            if (!isKnown_tr && isKnown_sr)
            {
                tr.value = fmFilterMachiningEquations.Eval_tr_From_sr_tc(sr.value, tc.value);
                isKnown_tr = true;
            }

            if (!isKnown_sf)
            {
                sf.value = fmFilterMachiningEquations.Eval_sf_From_tr_tc(tr.value, tc.value);
                /*
                                isKnown_sf = true;
                */
            }
            #endregion

            if (!isKnown_n) n.value = fmFilterMachiningEquations.Eval_n_From_tc(tc.value);
            if (!isKnown_tf) tf.value = fmFilterMachiningEquations.Eval_tf_From_sf_tc(sf.value, tc.value);
            if (!isKnown_tr) tr.value = fmFilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
            if (!isKnown_sr) sr.value = fmFilterMachiningEquations.Eval_sr_From_tc_tr(tc.value, tr.value);
            if (!isKnown_hc) hc.value = fmFilterMachiningEquations.EvalCandle_hc_From_tf_hce_kappa_Pc_Dp_etaf_d(tf.value, hce.value, kappa.value, Pc.value, Dp.value, eta_f.value, d0.value);

            if (!isKnown_vc) vc.value = fmFilterMachiningEquations.EvalCandle_vc_From_hc_d(hc.value, d0.value);
            if (!isKnown_vf) vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(vc.value, kappa.value);
            if (!isKnown_vsus) vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vf_kappa(vf.value, kappa.value);
            if (!isKnown_vs) vs.value = fmFilterMachiningEquations.Eval_vs_From_vsus_rho_Cm(vsus.value, rho_sus.value, rho_s.value, Cm.value);

            if (!isKnown_mc) mc.value = fmFilterMachiningEquations.Eval_mc_From_vf_kappa_rho(vf.value, kappa.value, rho_sus.value, rho_f.value);
            if (!isKnown_mf) mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, vf.value);
            if (!isKnown_msus) msus.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, vsus.value);
            if (!isKnown_ms) ms.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_s.value, vs.value);

            if (isKnown_Qf && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qf.value, tf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Qc && !isKnown_Vc)
            {
                Vc.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qc.value, tc.value);
                isKnown_Vc = true;
            }

            if (!isKnown_A && isKnown_Vf)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vf.value, vf.value);
                isKnown_A = true;
            }

            if (!isKnown_A && isKnown_Vc)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vc.value, vc.value);
                /*
                                isKnown_A = true;
                */
            }

            if (!isKnown_Vc) Vc.value = fmFilterMachiningEquations.Eval_V_From_v_A(vc.value, A.value);
            if (!isKnown_Vf) Vf.value = fmFilterMachiningEquations.Eval_V_From_v_A(vf.value, A.value);
            if (!isKnown_Vsus) Vsus.value = fmFilterMachiningEquations.Eval_V_From_v_A(vsus.value, A.value);
            if (!isKnown_Vs) Vs.value = fmFilterMachiningEquations.Eval_V_From_v_A(vs.value, A.value);

            if (!isKnown_Mc) Mc.value = fmFilterMachiningEquations.Eval_M_From_m_A(mc.value, A.value);
            if (!isKnown_Mf) Mf.value = fmFilterMachiningEquations.Eval_M_From_m_A(mf.value, A.value);
            if (!isKnown_Msus) Msus.value = fmFilterMachiningEquations.Eval_M_From_m_A(msus.value, A.value);
            if (!isKnown_Ms) Ms.value = fmFilterMachiningEquations.Eval_M_From_m_A(ms.value, A.value);

            if (!isKnown_Qmsus) Qmsus.value = fmFilterMachiningEquations.Eval_Qmsus_From_Msus_tc(Msus.value, tc.value);
            if (!isKnown_Qms) Qms.value = fmFilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(Qmsus.value, Cm.value);
            if (!isKnown_Qmf) Qmf.value = fmFilterMachiningEquations.Eval_Qm_From_M_t(Mf.value, tf.value);
            if (!isKnown_Qmc) Qmc.value = fmFilterMachiningEquations.Eval_Qm_From_M_t(Mc.value, tc.value);

            if (!isKnown_Qsus) Qsus.value = fmFilterMachiningEquations.Eval_Qsus_From_Vsus_tc(Vsus.value, tc.value);
            if (!isKnown_Qs) Qs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
            if (!isKnown_Qf) Qf.value = fmFilterMachiningEquations.Eval_Q_From_V_t(Vf.value, tf.value);
            if (!isKnown_Qc) Qc.value = fmFilterMachiningEquations.Eval_Q_From_V_t(Vc.value, tc.value);

            hc_over_tf.value = fmFilterMachiningEquations.Eval_hc_over_tf_From_hc_tf(hc.value, tf.value);
            dhc_over_dt.value = fmFilterMachiningEquations.Eval_dhc_over_dt_From_kappa_Dp_Pc_eta_hc_hce(kappa.value, Dp.value, Pc.value, eta_f.value, hc.value, hce.value);
            Qsus_d.value = fmFilterMachiningEquations.Eval_Qsus_d_From_eps_A_Cv_dhcdt(eps.value, A.value, Cv.value, dhc_over_dt.value);
            Qmsus_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Qsus_d.value);
            Qs_d.value = fmFilterMachiningEquations.Eval_Qs_d_From_eps_A_dhcdt(eps.value, A.value, dhc_over_dt.value);
            Qms_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_s.value, Qs_d.value);
            Qf_d.value = fmFilterMachiningEquations.Eval_Qf_d_From_A_Dp_Pc_eta_hc_hce(A.value, Dp.value, Pc.value, eta_f.value, hc.value, hce.value);
            Qmf_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Qf_d.value);
            Qc_d.value = fmFilterMachiningEquations.Eval_Cake_From_Sus_Flow(Qsus_d.value, Qf_d.value);
            Qmc_d.value = fmFilterMachiningEquations.Eval_Cake_From_Sus_Flow(Qmsus_d.value, Qmf_d.value);
            qf.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qf.value, A.value);
            qf_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qf_d.value, A.value);
            qsus.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qsus.value, A.value);
            qsus_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qsus_d.value, A.value);
            qs.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qs.value, A.value);
            qs_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qs_d.value, A.value);
            qc.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qc.value, A.value);
            qc_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qc_d.value, A.value);
            qmf.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmf.value, A.value);
            qmf_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmf_d.value, A.value);
            qmsus.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmsus.value, A.value);
            qmsus_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmsus_d.value, A.value);
            qms.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qms.value, A.value);
            qms_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qms_d.value, A.value);
            qmc.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmc.value, A.value);
            qmc_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmc_d.value, A.value);
        }
        private void DoSubCalculationsPlainDpConst()
        {
            // ReSharper disable InconsistentNaming
            var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            var sr = variables[fmGlobalParameter.sr] as fmCalculationVariableParameter;
            var n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            var mf = variables[fmGlobalParameter.mf] as fmCalculationVariableParameter;
            var vf = variables[fmGlobalParameter.vf] as fmCalculationVariableParameter;
            var ms = variables[fmGlobalParameter.ms] as fmCalculationVariableParameter;
            var vs = variables[fmGlobalParameter.vs] as fmCalculationVariableParameter;
            var msus = variables[fmGlobalParameter.msus] as fmCalculationVariableParameter;
            var vsus = variables[fmGlobalParameter.vsus] as fmCalculationVariableParameter;
            var mc = variables[fmGlobalParameter.mc] as fmCalculationVariableParameter;
            var vc = variables[fmGlobalParameter.vc] as fmCalculationVariableParameter;
            var Vc = variables[fmGlobalParameter.Vc] as fmCalculationVariableParameter;
            var Mc = variables[fmGlobalParameter.Mc] as fmCalculationVariableParameter;
            var Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            var Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;

            var Qf = variables[fmGlobalParameter.Qf] as fmCalculationVariableParameter;
            var Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            var Qs = variables[fmGlobalParameter.Qs] as fmCalculationVariableParameter;
            var Qc = variables[fmGlobalParameter.Qc] as fmCalculationVariableParameter;
            var Qmf = variables[fmGlobalParameter.Qmf] as fmCalculationVariableParameter;
            var Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            var Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            var Qmc = variables[fmGlobalParameter.Qmc] as fmCalculationVariableParameter;
            
            var hc_over_tf = variables[fmGlobalParameter.hc_over_tf];
            var dhc_over_dt = variables[fmGlobalParameter.dhc_over_dt];
            var Qf_d = variables[fmGlobalParameter.Qf_d];
            var Qs_d = variables[fmGlobalParameter.Qs_d];
            var Qc_d = variables[fmGlobalParameter.Qc_d];
            var Qsus_d = variables[fmGlobalParameter.Qsus_d];
            var Qmsus_d = variables[fmGlobalParameter.Qmsus_d];
            var Qms_d = variables[fmGlobalParameter.Qms_d];
            var Qmf_d = variables[fmGlobalParameter.Qmf_d];
            var Qmc_d = variables[fmGlobalParameter.Qmc_d];
            var qf = variables[fmGlobalParameter.qf];
            var qf_d = variables[fmGlobalParameter.qf_d];
            var qs = variables[fmGlobalParameter.qs];
            var qs_d = variables[fmGlobalParameter.qs_d];
            var qc = variables[fmGlobalParameter.qc];
            var qc_d = variables[fmGlobalParameter.qc_d];
            var qsus = variables[fmGlobalParameter.qsus];
            var qsus_d = variables[fmGlobalParameter.qsus_d];
            var qmsus = variables[fmGlobalParameter.qmsus];
            var qmsus_d = variables[fmGlobalParameter.qmsus_d];
            var qms = variables[fmGlobalParameter.qms];
            var qms_d = variables[fmGlobalParameter.qms_d];
            var qmf = variables[fmGlobalParameter.qmf];
            var qmf_d = variables[fmGlobalParameter.qmf_d];
            var qmc = variables[fmGlobalParameter.qmc];
            var qmc_d = variables[fmGlobalParameter.qmc_d];

            var eps = variables[fmGlobalParameter.eps];
            var kappa = variables[fmGlobalParameter.kappa];
            var Pc = variables[fmGlobalParameter.Pc];
            var rc = variables[fmGlobalParameter.rc];
            var a = variables[fmGlobalParameter.a];

            var eps0 = variables[fmGlobalParameter.eps0];
            var Pc0 = variables[fmGlobalParameter.Pc0];
            var eta_f = variables[fmGlobalParameter.eta_f];
            var rho_f = variables[fmGlobalParameter.rho_f];
            var rho_s = variables[fmGlobalParameter.rho_s];
            var rho_sus = variables[fmGlobalParameter.rho_sus];
            var Cv = variables[fmGlobalParameter.Cv];
            var Cm = variables[fmGlobalParameter.Cm];
            var ne = variables[fmGlobalParameter.ne];
            var nc = variables[fmGlobalParameter.nc];
            var hce = variables[fmGlobalParameter.hce0];
            // ReSharper restore InconsistentNaming

            eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = fmFilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = fmPcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            // ReSharper disable InconsistentNaming
            var isKnown_A = A.isInputed;
            var isKnown_sf = sf.isInputed;
            var isKnown_sr = sr.isInputed;
            var isKnown_n = n.isInputed;
            var isKnown_tc = tc.isInputed;
            var isKnown_tf = tf.isInputed;
            var isKnown_tr = tr.isInputed;
            var isKnown_hc = hc.isInputed;
            var isKnown_Vsus = Vsus.isInputed;
            var isKnown_Mf = Mf.isInputed;
            var isKnown_Vf = Vf.isInputed;
            var isKnown_mf = mf.isInputed;
            var isKnown_vf = vf.isInputed;
            var isKnown_ms = ms.isInputed;
            var isKnown_vs = vs.isInputed;
            var isKnown_msus = msus.isInputed;
            var isKnown_vsus = vsus.isInputed;
            var isKnown_mc = mc.isInputed;
            var isKnown_vc = vc.isInputed;
            var isKnown_Vc = Vc.isInputed;
            var isKnown_Mc = Mc.isInputed;
            var isKnown_Ms = Ms.isInputed;
            var isKnown_Vs = Vs.isInputed;
            var isKnown_Msus = Msus.isInputed;
            var isKnown_Qf = Qf.isInputed;
            var isKnown_Qs = Qs.isInputed;
            var isKnown_Qsus = Qsus.isInputed;
            var isKnown_Qc = Qc.isInputed;
            var isKnown_Qmf = Qmf.isInputed;
            var isKnown_Qms = Qms.isInputed;
            var isKnown_Qmsus = Qmsus.isInputed;
            var isKnown_Qmc = Qmc.isInputed;
            // ReSharper restore InconsistentNaming

            #region A0
            if (isKnown_A)
            {
                if (isKnown_Msus)
                {
                    msus.value = fmFilterMachiningEquations.Eval_m_From_M_A(Msus.value, A.value);
                    isKnown_msus = true;
                }

                if (isKnown_Ms)
                {
                    ms.value = fmFilterMachiningEquations.Eval_m_From_M_A(Ms.value, A.value);
                    isKnown_ms = true;
                }

                if (isKnown_Mc)
                {
                    mc.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mc.value, A.value);
                    isKnown_mc = true;
                }

                if (isKnown_Mf)
                {
                    mf.value = fmFilterMachiningEquations.Eval_m_From_M_A(Mf.value, A.value);
                    isKnown_mf = true;
                }

                if (isKnown_Vsus)
                {
                    vsus.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vsus.value, A.value);
                    isKnown_vsus = true;
                }

                if (isKnown_Vs)
                {
                    vs.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vs.value, A.value);
                    isKnown_vs = true;
                }

                if (isKnown_Vc)
                {
                    vc.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vc.value, A.value);
                    isKnown_vc = true;
                }

                if (isKnown_Vf)
                {
                    vf.value = fmFilterMachiningEquations.Eval_v_From_V_A(Vf.value, A.value);
                    isKnown_vf = true;
                }
            }
            #endregion
            #region A
            if (isKnown_ms)
            {
                vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, ms.value);
                isKnown_vs = true;
            }

            if (isKnown_vs)
            {
                vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_vsus = true;
            }

            if (isKnown_msus)
            {
                vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, msus.value);
                isKnown_vsus = true;
            }

            if (isKnown_vsus)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(vsus.value, kappa.value);
                isKnown_vf = true;
            }

            if (isKnown_mc)
            {
                vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_vf = true;
            }

            if (isKnown_mf)
            {
                vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, mf.value);
                isKnown_vf = true;
            }

            if (isKnown_vf)
            {
                vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(vf.value, kappa.value);
                isKnown_vc = true;
            }

            if (isKnown_vc)
            {
                hc.value = vc.value;
                isKnown_hc = true;
            }

            if (isKnown_hc)
            {
                tf.value = fmFilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                isKnown_tf = true;
            }
            #endregion
            #region D
            if (isKnown_Ms)
            {
                Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                isKnown_Vs = true;
            }
            
            if (isKnown_Vs)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Vs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Vsus = true;
            }
            
            if (isKnown_Msus)
            {
                Vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                isKnown_Vsus = true;
            }

            if (isKnown_Vsus)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vsus_kappa(Vsus.value, kappa.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Mf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Mc)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_mc_kappa_rho(Mc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Vf = true;
            }

            if (isKnown_Vf)
            {
                Vc.value = fmFilterMachiningEquations.Eval_vc_From_vf_kappa(Vf.value, kappa.value);
                isKnown_Vc = true;
            }

            if (isKnown_Vc && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(Vc.value, kappa.value);
                isKnown_Vf = true;
            }
            #endregion
            #region E
            if (isKnown_Qms)
            {
                Qs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
                isKnown_Qs = true;
            }
            
            if (isKnown_Qmsus)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Qmsus.value);
                isKnown_Qsus = true;
            }
            
            if (isKnown_Qs)
            {
                Qsus.value = fmFilterMachiningEquations.Eval_vsus_From_vs_rho_Cm(Qs.value, rho_s.value, rho_sus.value, Cm.value);
                isKnown_Qsus = true;
            }

            if (isKnown_Qsus)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_vsus_kappa(Qsus.value, kappa.value);
                isKnown_Qc = true;
            }

            if (isKnown_Qmc)
            {
                Qc.value = fmFilterMachiningEquations.Eval_vc_From_mc_kappa_rho(Qmc.value, kappa.value, rho_sus.value, rho_f.value);
                isKnown_Qc = true;
            }
            #endregion
            #region F
            if (isKnown_Qmf)
            {
                Qf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Qmf.value);
                isKnown_Qf = true;
            }
            #endregion
            #region G
            if (isKnown_Qc && isKnown_Vc)
            {
                tc.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qc.value, Vc.value);
                isKnown_tc = true;
            }

            if (isKnown_Qf && isKnown_Vf)
            {
                tf.value = fmFilterMachiningEquations.Eval_t_From_Q_V(Qf.value, Vf.value);
                isKnown_tf = true;
            }
            #endregion
            #region B
            if (isKnown_tf)
            {
                if (isKnown_sf) 
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tf_sf(tf.value, sf.value);
                }
                else if (isKnown_tr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                }
                else if (isKnown_sr)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_sr_tf(sr.value, tf.value);
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
                tc.value = fmFilterMachiningEquations.Eval_tc_From_n(n.value);
                isKnown_tc = true;
            }
            #region C
            if (!isKnown_tc)
            {
                throw new Exception("tc must be known in block C.");
            }

            if (!isKnown_tr && isKnown_sr)
            {
                tr.value = fmFilterMachiningEquations.Eval_tr_From_sr_tc(sr.value, tc.value);
                isKnown_tr = true;
            }

            if (!isKnown_sf)
            {
                sf.value = fmFilterMachiningEquations.Eval_sf_From_tr_tc(tr.value, tc.value);
/*
                isKnown_sf = true;
*/
            }
            #endregion

            if (!isKnown_n) n.value = fmFilterMachiningEquations.Eval_n_From_tc(tc.value);
            if (!isKnown_tf) tf.value = fmFilterMachiningEquations.Eval_tf_From_sf_tc(sf.value, tc.value);
            if (!isKnown_tr) tr.value = fmFilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
            if (!isKnown_sr) sr.value = fmFilterMachiningEquations.Eval_sr_From_tc_tr(tc.value, tr.value);
            if (!isKnown_hc) hc.value = fmFilterMachiningEquations.Eval_hc_From_hce_Pc_kappa_Dp_tf_etaf(hce.value, Pc.value, kappa.value, Dp.value, tf.value, eta_f.value);

            if (!isKnown_vc) vc.value = hc.value;
            if (!isKnown_vf) vf.value = fmFilterMachiningEquations.Eval_vf_From_vc_kappa(vc.value, kappa.value);
            if (!isKnown_vsus) vsus.value = fmFilterMachiningEquations.Eval_vsus_From_vf_kappa(vf.value, kappa.value);
            if (!isKnown_vs) vs.value = fmFilterMachiningEquations.Eval_vs_From_vsus_rho_Cm(vsus.value, rho_sus.value, rho_s.value, Cm.value);

            if (!isKnown_mc) mc.value = fmFilterMachiningEquations.Eval_mc_From_vf_kappa_rho(vf.value, kappa.value, rho_sus.value, rho_f.value);
            if (!isKnown_mf) mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, vf.value);
            if (!isKnown_msus) msus.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, vsus.value);
            if (!isKnown_ms) ms.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_s.value, vs.value);

            if (isKnown_Qf && !isKnown_Vf)
            {
                Vf.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qf.value, tf.value);
                isKnown_Vf = true;
            }

            if (isKnown_Qc && !isKnown_Vc)
            {
                Vc.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qc.value, tc.value);
                isKnown_Vc = true;
            }

            if (!isKnown_A && isKnown_Vf)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vf.value, vf.value);
                isKnown_A = true;
            }

            if (!isKnown_A && isKnown_Vc)
            {
                A.value = fmFilterMachiningEquations.Eval_A_From_V_v(Vc.value, vc.value);
/*
                isKnown_A = true;
*/
            }

            if (!isKnown_Vc) Vc.value = fmFilterMachiningEquations.Eval_V_From_v_A(vc.value, A.value);
            if (!isKnown_Vf) Vf.value = fmFilterMachiningEquations.Eval_V_From_v_A(vf.value, A.value);
            if (!isKnown_Vsus) Vsus.value = fmFilterMachiningEquations.Eval_V_From_v_A(vsus.value, A.value);
            if (!isKnown_Vs) Vs.value = fmFilterMachiningEquations.Eval_V_From_v_A(vs.value, A.value);

            if (!isKnown_Mc) Mc.value = fmFilterMachiningEquations.Eval_M_From_m_A(mc.value, A.value);
            if (!isKnown_Mf) Mf.value = fmFilterMachiningEquations.Eval_M_From_m_A(mf.value, A.value);
            if (!isKnown_Msus) Msus.value = fmFilterMachiningEquations.Eval_M_From_m_A(msus.value, A.value);
            if (!isKnown_Ms) Ms.value = fmFilterMachiningEquations.Eval_M_From_m_A(ms.value, A.value);

            if (!isKnown_Qmsus) Qmsus.value = fmFilterMachiningEquations.Eval_Qmsus_From_Msus_tc(Msus.value, tc.value);
            if (!isKnown_Qms) Qms.value = fmFilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(Qmsus.value, Cm.value);
            if (!isKnown_Qmf) Qmf.value = fmFilterMachiningEquations.Eval_Qm_From_M_t(Mf.value, tf.value);
            if (!isKnown_Qmc) Qmc.value = fmFilterMachiningEquations.Eval_Qm_From_M_t(Mc.value, tc.value);
            
            if (!isKnown_Qsus) Qsus.value = fmFilterMachiningEquations.Eval_Qsus_From_Vsus_tc(Vsus.value, tc.value);
            if (!isKnown_Qs) Qs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Qms.value);
            if (!isKnown_Qf) Qf.value = fmFilterMachiningEquations.Eval_Q_From_V_t(Vf.value, tf.value);
            if (!isKnown_Qc) Qc.value = fmFilterMachiningEquations.Eval_Q_From_V_t(Vc.value, tc.value);
            
            hc_over_tf.value = fmFilterMachiningEquations.Eval_hc_over_tf_From_hc_tf(hc.value, tf.value);
            dhc_over_dt.value = fmFilterMachiningEquations.Eval_dhc_over_dt_From_kappa_Dp_Pc_eta_hc_hce(kappa.value, Dp.value, Pc.value, eta_f.value, hc.value, hce.value);
            Qsus_d.value = fmFilterMachiningEquations.Eval_Qsus_d_From_eps_A_Cv_dhcdt(eps.value, A.value, Cv.value, dhc_over_dt.value);
            Qmsus_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Qsus_d.value);
            Qs_d.value = fmFilterMachiningEquations.Eval_Qs_d_From_eps_A_dhcdt(eps.value, A.value, dhc_over_dt.value);
            Qms_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_s.value, Qs_d.value);
            Qf_d.value = fmFilterMachiningEquations.Eval_Qf_d_From_A_Dp_Pc_eta_hc_hce(A.value, Dp.value, Pc.value, eta_f.value, hc.value, hce.value);
            Qmf_d.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Qf_d.value);
            Qc_d.value = fmFilterMachiningEquations.Eval_Cake_From_Sus_Flow(Qsus_d.value, Qf_d.value);
            Qmc_d.value = fmFilterMachiningEquations.Eval_Cake_From_Sus_Flow(Qmsus_d.value, Qmf_d.value);
            qf.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qf.value, A.value);
            qf_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qf_d.value, A.value);
            qsus.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qsus.value, A.value);
            qsus_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qsus_d.value, A.value);
            qs.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qs.value, A.value);
            qs_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qs_d.value, A.value);
            qc.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qc.value, A.value);
            qc_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qc_d.value, A.value);
            qmf.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmf.value, A.value);
            qmf_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmf_d.value, A.value);
            qmsus.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmsus.value, A.value);
            qmsus_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmsus_d.value, A.value);
            qms.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qms.value, A.value);
            qms_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qms_d.value, A.value);
            qmc.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmc.value, A.value);
            qmc_d.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmc_d.value, A.value);
        }

        private void DoSubCalculationsDesign1()
        {
// ReSharper disable InconsistentNaming
            var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            var n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            var Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            var Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            var Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            var Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            var Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
            var eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            var kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            var Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
            var rc = variables[fmGlobalParameter.rc] as fmCalculationVariableParameter;
            var a = variables[fmGlobalParameter.a] as fmCalculationVariableParameter;
            var eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            var Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
            var eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            var rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
            var rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
            var rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
            var Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            var Cm = variables[fmGlobalParameter.Cm] as fmCalculationConstantParameter;
            var ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
            var nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
            var hce = variables[fmGlobalParameter.hce0] as fmCalculationConstantParameter;
            // ReSharper restore InconsistentNaming

            eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = fmFilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = fmPcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);
            tf.value = fmFilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);


            if (Qms.isInputed)
            {
                Qmsus.value = fmFilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(Qms.value, Cm.value);
                Qsus.value = fmFilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(Qms.value, rho_s.value, Cv.value);

            }
            else if (Qmsus.isInputed)
            {
                Qms.value = fmFilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(Qmsus.value, Cm.value);
                Qsus.value = fmFilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(Qms.value, rho_s.value, Cv.value);
            }
            else if (Qsus.isInputed)
            {
                Qms.value = fmFilterMachiningEquations.Eval_Qm_From_Qsus_rhos_Cv(Qsus.value, rho_s.value, Cv.value);
                Qmsus.value = fmFilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(Qms.value, Cm.value);
            }
            else
                throw NoQInputed_Exception();

            if (n.isInputed)
            {
                tc.value = fmFilterMachiningEquations.Eval_tc_From_n(n.value);
                tr.value = fmFilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
            }
            else if (tc.isInputed)
            {
                n.value = fmFilterMachiningEquations.Eval_n_From_tc(tc.value);
                tr.value = fmFilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
            }
            else if (tr.isInputed)
            {
                tc.value = fmFilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                n.value = fmFilterMachiningEquations.Eval_n_From_tc(tc.value);
            }
            else
                throw No_n_tc_tr_Inputed_Exception();

            A.value = fmFilterMachiningEquations.Eval_A_From_Qms_eps_rhos_hc_n(Qms.value, eps.value, rho_s.value, hc.value, n.value);
            sf.value = fmFilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
            Vf.value = fmFilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
            Vsus.value = fmFilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Msus.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
            Ms.value = fmFilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
            Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
        }

        #region exceptionTools
        // ReSharper disable InconsistentNaming
        private static Exception No_n_tc_tr_Inputed_Exception()
        {
            return new Exception("One of n, tc and tr must be inputed");
        }
        
        private static Exception NoQInputed_Exception()
        {
            return new Exception("One of Qms, Qmsus and Qsus must be inputed");
        }
        // ReSharper restore InconsistentNaming
        #endregion

        private void DoCalculationsOptimization()
        {
            // ReSharper disable InconsistentNaming
            var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            var n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            var Qsus = variables[fmGlobalParameter.Qsus] as fmCalculationVariableParameter;
            var Qmsus = variables[fmGlobalParameter.Qmsus] as fmCalculationVariableParameter;
            var Qms = variables[fmGlobalParameter.Qms] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            var Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            var Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
            var eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            var kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            var Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
            var rc = variables[fmGlobalParameter.rc] as fmCalculationVariableParameter;
            var a = variables[fmGlobalParameter.a] as fmCalculationVariableParameter;
            var eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            var Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
            var eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            var rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
            var rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
            var rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
            var Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            var Cm = variables[fmGlobalParameter.Cm] as fmCalculationConstantParameter;
            var ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
            var nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
            var hce = variables[fmGlobalParameter.hce0] as fmCalculationConstantParameter;
            // ReSharper restore InconsistentNaming

            eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = fmFilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = fmPcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            if (Qms.isInputed)
            {
                Qmsus.value = fmFilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(Qms.value, Cm.value);
                Qsus.value = fmFilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(Qms.value, rho_s.value, Cv.value);
            }
            else if (Qmsus.isInputed)
            {
                Qms.value = fmFilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(Qmsus.value, Cm.value);
                Qsus.value = fmFilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(Qms.value, rho_s.value, Cv.value);
            }
            else if (Qsus.isInputed)
            {
                Qms.value = fmFilterMachiningEquations.Eval_Qm_From_Qsus_rhos_Cv(Qsus.value, rho_s.value, Cv.value);
                Qmsus.value = fmFilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(Qms.value, Cm.value);
            }
            else
                throw NoQInputed_Exception();


            if (sf.isInputed)
            {
                hc.value = fmFilterMachiningEquations.Eval_hc_From_Pc_kappa_Dp_sf_A_rhos_eps_etaf_Qms_hce(Pc.value, kappa.value, Dp.value, sf.value, A.value, rho_s.value, eps.value, eta_f.value, Qms.value, hce.value);
                tf.value = fmFilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                tc.value = fmFilterMachiningEquations.Eval_tc_From_tf_sf(tf.value, sf.value);
                n.value = fmFilterMachiningEquations.Eval_n_From_tc(tc.value);
                tr.value = fmFilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
            }
            else if (tr.isInputed)
            {
                tf.value = fmFilterMachiningEquations.Eval_tf_From_Pc_kappa_Dp_A_rhos_eps_etaf_Qms_hce_tr(Pc.value, kappa.value, Dp.value, A.value, rho_s.value, eps.value, eta_f.value, Qms.value, hce.value, tr.value);

                hc.value = fmFilterMachiningEquations.Eval_hc_From_hce_Pc_kappa_Dp_tf_etaf(hce.value, Pc.value, kappa.value, Dp.value, tf.value, eta_f.value);
                tc.value = fmFilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                sf.value = fmFilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
                n.value = fmFilterMachiningEquations.Eval_n_From_tc(tc.value);
            }
            else
                throw GenerateExceptionForGroupWithoutInput(sf, tr);

            Vf.value = fmFilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
            Vsus.value = fmFilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Msus.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
            Ms.value = fmFilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
            Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
        }

        private static Exception GenerateExceptionForGroupWithoutInput(params fmCalculationBaseParameter [] parameters)
        {
            string parametersSet = "";
            foreach (var p in parameters)
                parametersSet += ", " + p.globalParameter.name;
            parametersSet = "{" + parametersSet.Substring(2) + "}";
            return new Exception("One of " + parametersSet + " must be inputed");
        }
        private void DoSubCalculationsStandart123()
        {
// ReSharper disable InconsistentNaming
            var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            var n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            var Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            var Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
            var eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            var kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            var Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
            var rc = variables[fmGlobalParameter.rc] as fmCalculationVariableParameter;
            var a = variables[fmGlobalParameter.a] as fmCalculationVariableParameter;
            var eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            var Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
            var eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            var rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
            var rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
            var rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
            var Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            var Cm = variables[fmGlobalParameter.Cm] as fmCalculationConstantParameter;
            var ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
            var nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
            var hce = variables[fmGlobalParameter.hce0] as fmCalculationConstantParameter;
            // ReSharper restore InconsistentNaming

            eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = fmFilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = fmPcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            if (calculationOption == fmFilterMachiningCalculationOption.STANDART3)
            {
                if (n.isInputed)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_n(n.value);
                    tr.value = fmFilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
                }
                else if (tc.isInputed)
                {
                    n.value = fmFilterMachiningEquations.Eval_n_From_tc(tc.value);
                    tr.value = fmFilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
                }
                else if (tr.isInputed)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                    n.value = fmFilterMachiningEquations.Eval_n_From_tc(tc.value);
                }

                sf.value = fmFilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
            }

            hc.value = fmFilterMachiningEquations.Eval_hc_From_hce_Pc_kappa_Dp_tf_etaf(hce.value, Pc.value, kappa.value,
                                                                                     Dp.value, tf.value, eta_f.value);
            Vf.value = fmFilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
            Vsus.value = fmFilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Msus.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
            Ms.value = fmFilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
            Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
        }
        private void DoSubCalculationsStandart456()
        {
            if (calculationOption == fmFilterMachiningCalculationOption.STANDART4)
            {
                // ReSharper disable InconsistentNaming
                var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
                var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
                var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
                var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
                var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
                var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
                var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
                var Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
                var Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
                var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
                var eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
                var kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
                var Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
                var rc = variables[fmGlobalParameter.rc] as fmCalculationVariableParameter;
                var a = variables[fmGlobalParameter.a] as fmCalculationVariableParameter;
                var eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
                var Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
                var eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
                var rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
                var rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
                var rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
                var Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
                var Cm = variables[fmGlobalParameter.Cm] as fmCalculationConstantParameter;
                var ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
                var nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
                var hce = variables[fmGlobalParameter.hce0] as fmCalculationConstantParameter;
                // ReSharper restore InconsistentNaming

                DoSubCalculationsStandart4_sf_tr_n_tc_tf();

                if (hc.isInputed)
                {
                    Dp.value = fmFilterMachiningEquations.Eval_Dp_From_etaf_Cv_Pc0_nc_eps0_ne_hc_hce_tf(eta_f.value, Cv.value, Pc0.value, nc.value, eps0.value, ne.value, hc.value, hce.value, tf.value);
                    eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
                    kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
                    Vf.value = fmFilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
                    Vsus.value = fmFilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Msus.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
                    Ms.value = fmFilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Vf.isInputed)
                {
                    Mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
                    DoSubCalculationsStandart4_Dp_eps_kappa_hc_MVsus_From_MVf();
                    Ms.value = fmFilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Mf.isInputed)
                {
                    Vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Mf.value);
                    DoSubCalculationsStandart4_Dp_eps_kappa_hc_MVsus_From_MVf();
                    Ms.value = fmFilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Vsus.isInputed)
                {
                    Msus.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
                    DoSubCalculationsStandart4_Dp_eps_kappa_hc_MVf_From_MVsus();
                    Ms.value = fmFilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Msus.isInputed)
                {
                    Vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                    DoSubCalculationsStandart4_Dp_eps_kappa_hc_MVf_From_MVsus();
                    Ms.value = fmFilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Ms.isInputed)
                {
                    Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                    Msus.value = fmFilterMachiningEquations.Eval_Msus_From_Ms_Cm(Ms.value, Cm.value);
                    Vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                    DoSubCalculationsStandart4_Dp_eps_kappa_hc_MVf_From_MVsus();
                }
                else
                    throw GenerateExceptionForGroupWithoutInput(hc, Vf, Mf, Vsus, Msus, Vs, Ms);

                Pc.value = fmFilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
                rc.value = fmPcrcaEquations.Eval_rc_From_Pc(Pc.value);
                a.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);
            }
        }


        // ReSharper disable InconsistentNaming
        private void DoSubCalculationsStandart4_Dp_eps_kappa_hc_MVf_From_MVsus()
        // ReSharper restore InconsistentNaming
        {
            // ReSharper disable InconsistentNaming
            var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            var eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            var kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            var eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            var Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
            var eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            var rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
            var Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            var ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
            var nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
            var hce = variables[fmGlobalParameter.hce0] as fmCalculationConstantParameter;
            // ReSharper restore InconsistentNaming

            Dp.value = fmFilterMachiningEquations.Eval_Dp_From_nc_ne_etaf_A_tf_Cv_eps0_Pc0_hce_Vsus(nc.value, ne.value, eta_f.value, A.value, tf.value, Cv.value, eps0.value, Pc0.value, hce.value, Vsus.value);
            eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            hc.value = fmFilterMachiningEquations.Eval_hc_From_A_Vsus_kappa(A.value, Vsus.value, kappa.value);
            Vf.value = fmFilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
        }

        // ReSharper disable InconsistentNaming
        private void DoSubCalculationsStandart4_Dp_eps_kappa_hc_MVsus_From_MVf()
        // ReSharper restore InconsistentNaming
        {
            // ReSharper disable InconsistentNaming
            var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
            var eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            var kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            var eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            var Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
            var eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            var rho_sus = variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
            var Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            var ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
            var nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
            var hce = variables[fmGlobalParameter.hce0] as fmCalculationConstantParameter;
            // ReSharper restore InconsistentNaming

            Dp.value = fmFilterMachiningEquations.Eval_Dp_From_nc_ne_etaf_A_tf_Cv_eps0_Pc0_hce_Vf(nc.value, ne.value, eta_f.value, A.value, tf.value, Cv.value, eps0.value, Pc0.value, hce.value, Vf.value);
            eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            hc.value = fmFilterMachiningEquations.Eval_hc_From_A_Vf_kappa(A.value, Vf.value, kappa.value);
            Vsus.value = fmFilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
            Msus.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
        }

        // ReSharper disable InconsistentNaming
        private void DoSubCalculationsStandart4_sf_tr_n_tc_tf()
        // ReSharper restore InconsistentNaming
        {
            var sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            var n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            
            // ReSharper disable PossibleNullReferenceException
            if (n.isInputed)
            {
                tc.value = fmFilterMachiningEquations.Eval_tc_From_n(n.value);
            }
            else if (tc.isInputed)
            {
                n.value = fmFilterMachiningEquations.Eval_n_From_tc(tc.value);
            }
            else
                throw GenerateExceptionForGroupWithoutInput(n, tc);

            if (sf.isInputed)
            {
                tf.value = fmFilterMachiningEquations.Eval_tf_From_sf_tc(sf.value, tc.value);
                tr.value = fmFilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
            }
            else if (tr.isInputed)
            {
                tf.value = fmFilterMachiningEquations.Eval_tf_From_tc_tr(tc.value, tr.value);
                sf.value = fmFilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
            }
            else
                throw GenerateExceptionForGroupWithoutInput(sf, tf, tr);
            // ReSharper restore PossibleNullReferenceException
        }

        private void DoSubCalculationsStandart78()
        {
            // ReSharper disable InconsistentNaming
            var A = variables[fmGlobalParameter.A] as fmCalculationVariableParameter;
            var Dp = variables[fmGlobalParameter.Dp] as fmCalculationVariableParameter;
            var sf = variables[fmGlobalParameter.sf] as fmCalculationVariableParameter;
            var n = variables[fmGlobalParameter.n] as fmCalculationVariableParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationVariableParameter;
            var tf = variables[fmGlobalParameter.tf] as fmCalculationVariableParameter;
            var tr = variables[fmGlobalParameter.tr] as fmCalculationVariableParameter;
            var hc = variables[fmGlobalParameter.hc] as fmCalculationVariableParameter;
            var Vsus = variables[fmGlobalParameter.Vsus] as fmCalculationVariableParameter;
            var Mf = variables[fmGlobalParameter.Mf] as fmCalculationVariableParameter;
            var Vf = variables[fmGlobalParameter.Vf] as fmCalculationVariableParameter;
            var Ms = variables[fmGlobalParameter.Ms] as fmCalculationVariableParameter;
            var Vs = variables[fmGlobalParameter.Vs] as fmCalculationVariableParameter;
            var Msus = variables[fmGlobalParameter.Msus] as fmCalculationVariableParameter;
            var eps = variables[fmGlobalParameter.eps] as fmCalculationVariableParameter;
            var kappa = variables[fmGlobalParameter.kappa] as fmCalculationVariableParameter;
            var Pc = variables[fmGlobalParameter.Pc] as fmCalculationVariableParameter;
            var rc = variables[fmGlobalParameter.rc] as fmCalculationVariableParameter;
            var a = variables[fmGlobalParameter.a] as fmCalculationVariableParameter;
            var eps0 = variables[fmGlobalParameter.eps0] as fmCalculationConstantParameter;
            var Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;
            var eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            var rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
            var rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
            var rho_sus =
                variables[fmGlobalParameter.rho_sus] as fmCalculationConstantParameter;
            var Cv = variables[fmGlobalParameter.Cv] as fmCalculationConstantParameter;
            var Cm = variables[fmGlobalParameter.Cm] as fmCalculationConstantParameter;
            var ne = variables[fmGlobalParameter.ne] as fmCalculationConstantParameter;
            var nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
            var hce = variables[fmGlobalParameter.hce0] as fmCalculationConstantParameter;
            // ReSharper restore InconsistentNaming

            eps.value = fmFilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(eps0.value, Dp.value, ne.value);
            kappa.value = fmEpsKappaEquations.Eval_kappa_From_eps_Cv(eps.value, Cv.value);
            Pc.value = fmFilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp.value, nc.value);
            rc.value = fmPcrcaEquations.Eval_rc_From_Pc(Pc.value);
            a.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(Pc.value, eps.value, rho_s.value);

            if (calculationOption == fmFilterMachiningCalculationOption.STANDART8)
            {
                if (hc.isInputed)
                {
                    Vf.value = fmFilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
                    Vsus.value = fmFilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Msus.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
                    Ms.value = fmFilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Vf.isInputed)
                {
                    hc.value = fmFilterMachiningEquations.Eval_hc_From_A_Vf_kappa(A.value, Vf.value, kappa.value);
                    Mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
                    Vsus.value = fmFilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Msus.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
                    Ms.value = fmFilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Mf.isInputed)
                {
                    Vf.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_f.value, Mf.value);
                    hc.value = fmFilterMachiningEquations.Eval_hc_From_A_Vf_kappa(A.value, Vf.value, kappa.value);
                    Vsus.value = fmFilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Msus.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
                    Ms.value = fmFilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Vsus.isInputed)
                {
                    Msus.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_sus.value, Vsus.value);
                    hc.value = fmFilterMachiningEquations.Eval_hc_From_A_Vsus_kappa(A.value, Vsus.value, kappa.value);
                    Vf.value = fmFilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
                    Ms.value = fmFilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Msus.isInputed)
                {
                    Vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                    hc.value = fmFilterMachiningEquations.Eval_hc_From_A_Vsus_kappa(A.value, Vsus.value, kappa.value);
                    Vf.value = fmFilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
                    Ms.value = fmFilterMachiningEquations.Eval_Ms_From_Msus_Cm(Msus.value, Cm.value);
                    Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                }
                else if (Ms.isInputed)
                {
                    Vs.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_s.value, Ms.value);
                    Msus.value = fmFilterMachiningEquations.Eval_Msus_From_Ms_Cm(Ms.value, Cm.value);
                    Vsus.value = fmFilterMachiningEquations.Eval_V_From_rho_M(rho_sus.value, Msus.value);
                    hc.value = fmFilterMachiningEquations.Eval_hc_From_A_Vsus_kappa(A.value, Vsus.value, kappa.value);
                    Vf.value = fmFilterMachiningEquations.Eval_Vf_From_A_hc_kappa(A.value, hc.value, kappa.value);
                    Mf.value = fmFilterMachiningEquations.Eval_M_From_rho_V(rho_f.value, Vf.value);
                }
                else
                    throw GenerateExceptionForGroupWithoutInput(hc, Vf, Mf, Vsus, Msus, Ms);
            }

            if (calculationOption == fmFilterMachiningCalculationOption.STANDART8)
            {
                if (n.isInputed)
                {
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_n(n.value);
                    tf.value = fmFilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                    sf.value = fmFilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
                    tr.value = fmFilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
                }
                else if (tc.isInputed)
                {
                    n.value = fmFilterMachiningEquations.Eval_n_From_tc(tc.value);
                    tf.value = fmFilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                    sf.value = fmFilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
                    tr.value = fmFilterMachiningEquations.Eval_tr_From_tc_tf(tc.value, tf.value);
                }
                else if (tr.isInputed)
                {
                    tf.value = fmFilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(eta_f.value, hc.value, hce.value, Pc.value, kappa.value, Dp.value);
                    tc.value = fmFilterMachiningEquations.Eval_tc_From_tr_tf(tr.value, tf.value);
                    n.value = fmFilterMachiningEquations.Eval_n_From_tc(tc.value);
                    sf.value = fmFilterMachiningEquations.Eval_sf_From_tf_tc(tf.value, tc.value);
                }
                else
                    throw GenerateExceptionForGroupWithoutInput(n, tc, tr);
            }
        }
    }
}
