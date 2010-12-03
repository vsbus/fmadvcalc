using System;
using System.Collections.Generic;
using fmCalculationLibrary.NumericalMethods;

namespace fmCalculationLibrary.Equations
{
    public class fmFilterMachiningEquations
    {
        // ReSharper disable InconsistentNaming
        static public fmValue Eval_tc_From_n(fmValue n)
        {
            return 1 / n;
        }

        static public fmValue Eval_n_From_tc(fmValue tc)
        {
            return 1 / tc;
        }

        static public fmValue Eval_tf_From_sf_tc(fmValue sf, fmValue tc)
        {
            return sf * tc;
        }

        static public fmValue Eval_hc_From_hce_Pc_kappa_Dp_tf_etaf(
            fmValue hce,
            fmValue Pc,
            fmValue kappa,
            fmValue Dp,
            fmValue tf,
            fmValue etaf)
        {
            return fmValue.Sqrt(hce * hce + 2 * Pc * kappa * Dp * tf / etaf) - hce;
        }

        static public fmValue Eval_hc_From_hce_Pc_kappa_Dp_tf_etaf_QpConst(
            fmValue hce,
            fmValue Pc,
            fmValue kappa,
            fmValue Dp,
            fmValue tf,
            fmValue etaf)
        {
            return 0.5 * (fmValue.Sqrt(hce * hce + 4 * Pc * kappa * Dp * tf / etaf) - hce);
        }

        public static fmValue Eval_M_From_rho_V(fmValue rho, fmValue V)
        {
            return rho * V;
        }

        public static fmValue Eval_Ms_From_Msus_Cm(fmValue Msus, fmValue Cm)
        {
            return Msus * Cm;
        }

        public static fmValue Eval_Qms_From_Qmsus_Cm(fmValue Qmsus, fmValue Cm)
        {
            return Qmsus * Cm;
        }

        public static fmValue Eval_Qmsus_From_Msus_tc(fmValue Msus, fmValue tc)
        {
            return Msus / tc;
        }

        public static fmValue Eval_Vf_From_A_hc_kappa(fmValue A, fmValue hc, fmValue kappa)
        {
            return A * hc / kappa;
        }

        public static fmValue Eval_Qsus_From_Vsus_tc(fmValue Vsus, fmValue tc)
        {
            return Vsus / tc;
        }

        public static fmValue Eval_Vsus_From_A_hc_kappa(fmValue A, fmValue hc, fmValue kappa)
        {
            return A * hc * (1 + kappa) / kappa;
        }

        public static fmValue Eval_tc_From_tf_sf(fmValue tf, fmValue sf)
        {
            return tf / sf;
        }

        public static fmValue Eval_sf_From_tf_tc(fmValue tf, fmValue tc)
        {
            return tf / tc;
        }

        public static fmValue Eval_eps_From_eps0_Dp_ne(fmValue eps0, fmValue Dp, fmValue ne)
        {
            return eps0 * fmValue.Pow(Dp / 1e5, -ne);
        }

        public static fmValue Eval_Pc_From_Pc0_Dp_nc(fmValue Pc0, fmValue Dp, fmValue nc)
        {
            return Pc0 * fmValue.Pow(Dp / 1e5, -nc);
        }

        public static fmValue Eval_Dp_From_etaf_Cv_Pc0_nc_eps0_ne_hc_hce_tf(fmValue eta_f, fmValue Cv, fmValue Pc0, fmValue nc, fmValue eps0, fmValue ne, fmValue hc, fmValue hce, fmValue tf)
        {
            fmValue p1 = nc - 1;
            fmValue p2 = nc - ne - 1;
            var bar = new fmValue(1e5);
            fmValue c = -eta_f * hc * (hc + 2 * hce) / (2 * Pc0 * Cv);
            fmValue c1 = c * (Cv - 1) / fmValue.Pow(bar, nc);
            fmValue c2 = c * eps0 / fmValue.Pow(bar, nc - ne);
            fmValue c3 = -tf;

            List<fmValue> roots = fmMathEquations.SolveC1Xp1C2Xp2C3(c1, p1, c2, p2, c3, new fmValue(1e10));

            return SelectBestDpRoot(roots);
        }

        private static fmValue SelectBestDpRoot(List<fmValue> roots)
        {
            var localRoots = new List<fmValue>(roots);
            localRoots.Sort();

            var bar = new fmValue(1e5);
            if (localRoots.Count == 1)
            {
                return roots[0];
            }

            fmValue minLimit = 0.1 * bar;

            while (localRoots.Count > 1 && localRoots[0] < minLimit)
                localRoots.RemoveAt(0);

            if (localRoots.Count == 0)
                return new fmValue();

            return localRoots[0];
        }

        public static fmValue Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(fmValue eta_f, fmValue hc, fmValue hce, fmValue Pc, fmValue kappa, fmValue Dp)
        {
            return eta_f * (hc * hc + 2 * hc * hce) / (2 * Pc * kappa * Dp);
        }

        public static fmValue Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp_QpConst(fmValue eta_f, fmValue hc, fmValue hce, fmValue Pc, fmValue kappa, fmValue Dp)
        {
            return eta_f * hc * (hc + hce) / (Pc * kappa * Dp);
        }

        public static fmValue Eval_Qmsus_From_Qms_Cm(fmValue Qms, fmValue Cm)
        {
            return Qms / Cm;
        }

        public static fmValue Eval_Qsus_From_Qms_rhos_Cv(fmValue Qms, fmValue rho_s, fmValue Cv)
        {
            return Qms / (rho_s * Cv);
        }

        public static fmValue Eval_Qm_From_Qsus_rhos_Cv(fmValue Qsus, fmValue rho_s, fmValue Cv)
        {
            return Qsus * rho_s * Cv;
        }

        public static fmValue Eval_A_From_Qms_eps_rhos_hc_n(fmValue Qms, fmValue eps, fmValue rho_s, fmValue hc, fmValue n)
        {
            return Qms / ((1 - eps) * rho_s * hc * n);
        }

        public static fmValue Eval_hc_From_Pc_kappa_Dp_sf_A_rhos_eps_etaf_Qms_hce(fmValue Pc, fmValue kappa, fmValue Dp, fmValue sf, fmValue A, fmValue rho_s, fmValue eps, fmValue eta_f, fmValue Qms, fmValue hce)
        {
            return 2 * Pc * kappa * Dp * sf * A * rho_s * (1 - eps) / (eta_f * Qms) - 2 * hce;
        }

        public static fmValue Eval_tr_From_tc_tf(fmValue tc, fmValue tf)
        {
            fmValue res = tc - tf;
            if (fmValue.Abs(res) <= 1e-9 * fmValue.Max(fmValue.Abs(tc), fmValue.Abs(tf)))
            {
                res.value = 0;
            }
            return res;
        }

        public static fmValue Eval_tf_From_tc_tr(fmValue tc, fmValue tr)
        {
            return tc - tr;
        }

        public static fmValue Eval_tc_From_tr_tf(fmValue tr, fmValue tf)
        {
            return tf + tr;
        }

        public static fmValue Eval_tf_From_Pc_kappa_Dp_A_rhos_eps_etaf_Qms_hce_tr(
            fmValue Pc,
            fmValue kappa,
            fmValue Dp,
            fmValue A,
            fmValue rhos,
            fmValue eps,
            fmValue etaf,
            fmValue Qms,
            fmValue hce,
            fmValue tr)
        {
            fmValue A1 = 2 * Pc * kappa * Dp * A * rhos * (1 - eps) / (etaf * Qms);
            fmValue B1 = -2 * hce;
            fmValue C1 = etaf / (2 * Pc * kappa * Dp);

            fmValue b = (-C1 * A1 * A1 - C1 * A1 * B1 + 2 * tr);
            fmValue c = tr * tr - C1 * A1 * tr * B1;
            fmValue D = b * b - 4 * c;
            fmValue x2 = (-b + fmValue.Sqrt(D)) / 2;

            return x2;
        }

        public static fmValue Eval_hc_From_A_Vf_kappa(fmValue A, fmValue Vf, fmValue kappa)
        {
            return Vf * kappa / A;
        }

        public static fmValue Eval_Dp_From_nc_ne_etaf_A_tf_Cv_eps0_Pc0_hce_Vf(
            fmValue nc, fmValue ne, fmValue eta_f, fmValue A, fmValue tf, fmValue Cv, fmValue eps0,
            fmValue Pc0, fmValue hce, fmValue Vf)
        {
            fmValue p1 = 1 - nc;
            fmValue p2 = 1 - nc - ne;
            fmValue p3 = -ne;

            var bar = new fmValue(1e5);

            fmValue C1 = eta_f / (2 * A * A);

            fmValue K1 = tf * (1 - Cv) / Cv;
            fmValue K2 = -tf * eps0 * fmValue.Pow(bar, ne) / Cv;
            fmValue K3 = 2 * C1 / Pc0 * fmValue.Pow(bar, ne - nc) * eps0 / Cv * hce * A * Vf;
            fmValue K4 = C1 * fmValue.Pow(bar, -nc) * Vf * (-Vf * Cv - 2 * hce * A * (1 - Cv)) / (Cv * Pc0);

            List<fmValue> roots = fmMathEquations.SolveC1Xp1C2Xp2C3Xp3C4(K1, p1, K2, p2, K3, p3, K4);

            return SelectBestDpRoot(roots);
        }

        public static fmValue Eval_V_From_rho_M(fmValue rho, fmValue M)
        {
            return M / rho;
        }

        public static fmValue Eval_hc_From_A_Vsus_kappa(fmValue A, fmValue Vsus, fmValue kappa)
        {
            return Vsus * kappa / (A * (1 + kappa));
        }

        public static fmValue Eval_Dp_From_nc_ne_etaf_A_tf_Cv_eps0_Pc0_hce_Vsus(fmValue nc, fmValue ne, fmValue eta_f, fmValue A, fmValue tf, fmValue Cv, fmValue eps0,
            fmValue Pc0, fmValue hce, fmValue Vsus)
        {
            var bar = new fmValue(1e5);

            fmValue K1 = tf;
            fmValue p1 = 2 * ne;

            fmValue K2 = -2 * tf * eps0 * fmValue.Pow(bar, ne);
            fmValue p2 = ne;

            fmValue K3 = -0.5 * eta_f * fmValue.Pow(bar, -nc) / (A * A) / Pc0 * Vsus * (-1 + Cv) * (-Vsus * Cv - 2 * hce * A);
            fmValue p3 = 2 * ne + nc - 1;

            fmValue K4 = -0.5 / (A * A) / Pc0 * eta_f * fmValue.Pow(bar, -nc + ne) * Vsus * eps0 * (-4 * hce * A + 2 * hce * A * Cv - Vsus * Cv);
            fmValue p4 = ne + nc - 1;

            fmValue K5 = -eta_f * fmValue.Pow(bar, -nc) / A / Pc0 * Vsus * eps0 * eps0 * fmValue.Pow(bar, ne * 2) * hce;
            fmValue p5 = nc - 1;

            fmValue K6 = tf * eps0 * eps0 * fmValue.Pow(bar, ne * 2);

            List<fmValue> roots = fmMathEquations.SolvePowerSumEquation(K6,
                                                                        new[,]
                                                                            {
                                                                                {K1, p1}, {K2, p2}, {K3, p3}, {K4, p4},
                                                                                {K5, p5}
                                                                            });

            return SelectBestDpRoot(roots);
        }

        public static fmValue Eval_Msus_From_Ms_Cm(fmValue Ms, fmValue Cm)
        {
            return Ms / Cm;
        }

        public static fmValue Eval_hc_over_tf_From_hc_tf(fmValue hc, fmValue tf)
        {
            return hc / tf;
        }

        public static fmValue Eval_dhc_over_dt_From_kappa_Dp_Pc_eta_hc_hce(fmValue kappa, fmValue Dp, fmValue Pc, fmValue eta, fmValue hc, fmValue hce)
        {
            return kappa * Dp * Pc / (eta * (hc + hce));
        }

        public static fmValue Eval_Cake_From_Sus_Flow(fmValue Sus, fmValue Flow)
        {
            return Sus - Flow;
        }

        public static fmValue Eval_m_From_M_A(fmValue M, fmValue A)
        {
            return M / A;
        }

        public static fmValue Eval_v_From_V_A(fmValue V, fmValue A)
        {
            return V / A;
        }

        public static fmValue Eval_Qsus_d_From_eps_A_Cv_dhcdt(fmValue eps, fmValue A, fmValue Cv, fmValue dhc_dt)
        {
            var one = new fmValue(1.0);
            return (one - eps) * A / Cv * dhc_dt;
        }

        public static fmValue Eval_Qs_d_From_eps_A_dhcdt(fmValue eps, fmValue A, fmValue dhc_over_dt)
        {
            return (1 - eps) * A * dhc_over_dt;
        }

        public static fmValue Eval_Qm_From_M_t(fmValue Mf, fmValue tf)
        {
            return Mf / tf;
        }

        public static fmValue Eval_Qf_d_From_A_Dp_Pc_eta_hc_hce(fmValue A, fmValue Dp, fmValue Pc, fmValue eta, fmValue hc, fmValue hce)
        {
            return A * Dp * Pc / (eta * (hc + hce));
        }

        public static fmValue Eval_Q_From_V_t(fmValue V, fmValue t)
        {
            return V / t;
        }

        public static fmValue Eval_q_From_Q_A(fmValue Q, fmValue A)
        {
            return Q / A;
        }

        public static fmValue Eval_vsus_From_vs_rho_Cm(fmValue vs, fmValue rho_s, fmValue rho_sus, fmValue Cm)
        {
            return vs * rho_s / (rho_sus * Cm);
        }

        public static fmValue Eval_vf_From_vsus_kappa(fmValue vsus, fmValue kappa)
        {
            return vsus / (1 + kappa);
        }

        public static fmValue Eval_vf_From_mc_kappa_rho(fmValue mc, fmValue kappa, fmValue rho_sus, fmValue rho_f)
        {
            return mc / ((1 + kappa) * rho_sus - rho_f);
        }

        public static fmValue Eval_vc_From_vf_kappa(fmValue vf, fmValue kappa)
        {
            return vf * kappa;
        }

        public static fmValue Eval_tf_From_sf_tr(fmValue sf, fmValue tr)
        {
            return sf * tr / (1 - sf);
        }

        public static fmValue Eval_vf_From_vc_kappa(fmValue vc, fmValue kappa)
        {
            return vc / kappa;
        }

        public static fmValue Eval_V_From_v_A(fmValue v, fmValue A)
        {
            return v * A;
        }

        public static fmValue Eval_vsus_From_vf_kappa(fmValue vf, fmValue kappa)
        {
            return vf * (1 + kappa);
        }

        public static fmValue Eval_mc_From_vf_kappa_rho(fmValue vf, fmValue kappa, fmValue rho_sus, fmValue rho_f)
        {
            return vf * ((1 + kappa) * rho_sus - rho_f);
        }

        public static fmValue Eval_vs_From_vsus_rho_Cm(fmValue vsus, fmValue rho_sus, fmValue rho_s, fmValue Cm)
        {
            return vsus * rho_sus / rho_s * Cm;
        }

        public static fmValue Eval_M_From_m_A(fmValue m, fmValue A)
        {
            return m * A;
        }

        public static fmValue Eval_tr_From_tc_sf(fmValue tc, fmValue sf)
        {
            return tc * (1 - sf);
        }

        public static fmValue Eval_sf_From_tr_tc(fmValue tr, fmValue tc)
        {
            return (tc - tr) / tc;
        }

        public static fmValue Eval_vc_From_vsus_kappa(fmValue vsus, fmValue kappa)
        {
            return kappa / (1 + kappa) * vsus;
        }

        public static fmValue Eval_vc_From_mc_kappa_rho(fmValue mc, fmValue kappa, fmValue rho_sus, fmValue rho_f)
        {
            return mc * kappa / ((1 + kappa) * rho_sus - rho_f);
        }

        public static fmValue Eval_t_From_Q_V(fmValue Q, fmValue V)
        {
            return V / Q;
        }

        public static fmValue Eval_V_From_Q_t(fmValue Q, fmValue t)
        {
            return Q * t;
        }

        public static fmValue Eval_A_From_V_v(fmValue V, fmValue v)
        {
            return V / v;
        }

        public static fmValue Eval_sr_From_tc_tr(fmValue tc, fmValue tr)
        {
            return tr / tc;
        }

        public static fmValue Eval_tc_From_sr_tf(fmValue sr, fmValue tf)
        {
            return tf / (1 - sr);
        }

        public static fmValue Eval_tr_From_sr_tc(fmValue sr, fmValue tc)
        {
            return sr * tc;
        }

        public static fmValue Eval_Qsus_d_From_A_Dp_Pc_eta_f_Cv_eps_hc_hce_QpConst(
            fmValue A, fmValue Dp, fmValue Pc, fmValue eta_f, fmValue Cv, fmValue eps, fmValue hc, fmValue hce)
        {
            fmValue one = new fmValue(1.0);
            return A * Dp * Pc / (eta_f * (one - Cv / (one - eps)) * (hc + hce));
        }
        public static fmValue Eval_Qf_From_Qsusd_eps_Cv(fmValue Qsusd, fmValue eps, fmValue Cv)
        {
            fmValue one = new fmValue(1.0);
            return Qsusd * (one - eps - Cv) / (one - eps);
        }
        // ReSharper restore InconsistentNaming

        public static fmValue EvalCandle_hc_From_vc_d(fmValue vc, fmValue d)
        {
            fmValue r = d / 2;
            return fmValue.Sqrt(r * r + 2 * vc * r) - r;
        }

        public static fmValue EvalCandle_tf_From_d_eta_kappa_Pc_Dp_hc_hce(fmValue d, fmValue eta, fmValue kappa, fmValue Pc, fmValue Dp, fmValue hc, fmValue hce)
        {
            fmValue r = d / 2;
            fmValue C1 = eta * d * d / (16 * kappa * Pc * Dp);
            fmValue hcd = hc / r;
            fmValue hced = hce / r;
            fmValue tf = C1 * (fmValue.Sqr(1 + hcd) * (2 * fmValue.Log(1 + hcd) - 1 + 2 * hced) + 1 - 2 * hced);
            return tf;
        }

        public static fmValue EvalCandle_hc_From_tf_hce_kappa_Pc_Dp_etaf_d(fmValue tf, fmValue hce, fmValue kappa, fmValue Pc, fmValue Dp, fmValue etaf, fmValue d)
        {
            fmValue r = d / 2;
            fmValue hced = hce / r;
            fmValue C = 2 * hced - 1;
            fmValue td = kappa * Pc * Dp * tf / (etaf * r * r);
            fmValue x = fmValue.Exp(0.5 * fmValue.LambertW((4 * td + C) * fmValue.Exp(C)) - 0.5 * C);
            fmValue hcd = x - 1;
            fmValue hc = hcd * r;
            return hc;
        }

        public static fmValue EvalCandle_vc_From_hc_d(fmValue hc, fmValue d)
        {
            return hc * (d + hc) / d;
        }

        public static fmValue EvalCandle_tf_From_d_hc_hce_eta_Cv_kappa_Pc_Dp_QpConst(fmValue eps, fmValue d, fmValue hc, fmValue hce, fmValue eta, fmValue Cv, fmValue kappa, fmValue Pc, fmValue Dp)
        {
            fmValue r = d / 2;
            fmValue hcd = hc / r;
            fmValue hced = hce / r;
            fmValue C1 = (1 - eps) * d * d * eta / (8 * Cv * (1 + kappa) * Pc * Dp);
            fmValue tf = C1 * hcd * (2 + hcd) * (fmValue.Log(1 + hcd) + hced);
            return tf;
        }

        private class fmCandleHcEquationWithQpConst : fmFunction
        {
            private fmValue C1;
            private fmValue C2;
            private fmValue y;
            public fmCandleHcEquationWithQpConst(fmValue C1, fmValue C2, fmValue y) 
            {
                this.C1 = C1;
                this.C2 = C2;
                this.y = y;
            }
            public override fmValue Eval(fmValue x)
            {
                return C1 * x * (2 + x) * (fmValue.Log(1 + x) + C2) - y;
            }
        };

        public static fmValue EvalCandle_hc_From_hce_d_eta_Cv_kappa_Pc_Dp_tf_QpConst(fmValue eps, fmValue hce, fmValue d, fmValue eta, fmValue Cv, fmValue kappa, fmValue Pc, fmValue Dp, fmValue tf)
        {
            fmValue r = d / 2;
            fmValue hced = hce / r;
            fmCandleHcEquationWithQpConst func = new fmCandleHcEquationWithQpConst((1 - eps) * d * d * eta / (8 * Cv * (1 + kappa) * Pc * Dp), hced, tf);
            fmValue hcd = fmCalculationLibrary.NumericalMethods.fmBisectionMethod.FindRoot(func, new fmValue(0), new fmValue(1e9), 60);
            fmValue hc = hcd * r;
            return hc;
        }

        public static fmValue EvalCandle_Qsus_d_From_d_hc_hce_A_kappa_Pc_Dp_eta_QpConst(fmValue d, fmValue hc, fmValue hce, fmValue A, fmValue kappa, fmValue Pc, fmValue Dp, fmValue eta)
        {
            fmValue r = d / 2;
            fmValue hcd = hc / r;
            fmValue hced = hce / r;
            return 2 * A * (1 + kappa) * Pc * Dp / (d * eta * (fmValue.Log(1 + hcd) + hced));
        }
    }
}