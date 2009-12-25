using System.Collections.Generic;
using fmMathEquations=fmCalculationLibrary.Equations.fmMathEquations;

namespace fmCalculationLibrary.Equations
{
    public class FilterMachiningEquations
    {
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
            fmValue bar = new fmValue(1e5);
            fmValue c = -eta_f * hc * (hc + 2 * hce) / (2 * Pc0 * Cv);
            fmValue c1 = c * (Cv - 1) / fmValue.Pow(bar, nc);
            fmValue c2 = c * eps0 / fmValue.Pow(bar, nc - ne);
            fmValue c3 = -tf;

            List<fmValue> roots = fmMathEquations.SolveC1xp1C2xp2C3(c1, p1, c2, p2, c3);

            if (roots.Count == 1)
            {
                return roots[0];
            }

            fmValue minLimit = 0.1 * bar;
            fmValue maxLimit = 20 * bar;

            if (roots[0] < minLimit)
            {
                return roots[1];
            }

            return roots[0];
        }

        public static fmValue Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(fmValue eta_f, fmValue hc, fmValue hce, fmValue Pc, fmValue kappa, fmValue Dp)
        {
            return eta_f * (hc * hc + 2 * hc * hce) / (2 * Pc * kappa * Dp);
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
            return tc - tf;
        }
    }
}