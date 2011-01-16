using System;
using System.Collections.Generic;
using System.Text;

namespace fmCalculationLibrary.Equations
{
    public class fmDeliquoringEquations
    {
        public static fmValue Eval_pke_From_pke0_sigma_Pc(fmValue pke0, fmValue sigma, fmValue Pc)
        {
            fmValue sigma0 = new fmValue(72 * 1e-3);
            fmValue Pc0 = new fmValue(1e-13);
            return pke0 * sigma / sigma0 * fmValue.Sqrt(Pc0 / Pc);
        }

        public static fmValue Eval_hcd_from_hcf_epsf_epsd(fmValue hcf, fmValue epsf, fmValue epsd)
        {
            return (1 - epsf) / (1 - epsd) * hcf;
        }

        public static fmValue Eval_td_From_sd_tc(fmValue sd, fmValue tc)
        {
            return sd * tc;
        }

        public static fmValue Eval_K_From_pcd_Dpd_pke_epsd_etaf_hcd_hce_td(fmValue pcd, fmValue Dpd, fmValue pke, fmValue epsd, fmValue etaf, fmValue hcd, fmValue hce, fmValue td)
        {
            return pcd * (Dpd - pke) / (epsd * etaf * hcd * (hcd + hce)) * td;
        }

        public static fmValue Eval_Smech_From_Srem_ad1_ad2_K(fmValue Srem, fmValue ad1, fmValue ad2, fmValue K)
        {
            return Srem + (1 - Srem) * fmValue.Pow(1 + ad2 * K, -ad1);
        }

        public static fmValue Eval_Vcd_From_A_hcd(fmValue A, fmValue hcd)
        {
            return A * hcd;
        }

        public static fmValue Eval_Vgmaxev_From_A_pcd_Dpd_etag_hcd_hce_ag1_ag2_td(fmValue A, fmValue pcd, fmValue Dpd, fmValue etag, fmValue hcd, fmValue hce, fmValue ag1, fmValue ag2, fmValue td)
        {
            fmValue bar = new fmValue(1e5);
            return A * pcd * Dpd / (etag * (hcd + hce)) * (ag1 + ag2 * fmValue.Log(Dpd / bar)) * td;
        }

        public static fmValue Eval_Vgev_From_Vgmaxev_ag3_K(fmValue Vgmaxev, fmValue ag3, fmValue K)
        {
            return Vgmaxev * (1 - (1 - fmValue.Exp(-ag3 * K)) / (ag3 * K));
        }

        public static fmValue Eval_Mev_From_peq_Mmole_Tetta_Vgev_ag3_K_f(fmValue peq, fmValue Mmole, fmValue Tetta, fmValue Vgev, fmValue ag3, fmValue K, fmValue f)
        {
            fmValue R0 = new fmValue(8.314);
            fmValue T = Tetta + 273;
            return peq * Mmole / (R0 * T) * Vgev * fmValue.Pow((1 - fmValue.Exp(-ag3 * K)) / (ag3 * K), f);
        }

        public static fmValue Eval_Sev_From_Mev_rhof_epsd_Vcd(fmValue Mev, fmValue rho_f, fmValue epsd, fmValue Vcd)
        {
            return Mev / (rho_f * epsd * Vcd);
        }

        public static fmValue Eval_S_From_Smech_Sev(fmValue Smech, fmValue Sev)
        {
            return Smech - Sev;
        }

        public static fmValue Eval_rho_bulk_From_rhof_epsd_rhos_S(fmValue rhof, fmValue epsd, fmValue rhos, fmValue S)
        {
            return rhof * (1 + (1 - epsd) * (rhos / rhof - 1) - epsd * (1 - S));
        }

        public static fmValue Eval_Rf_From_eps_rhos_rhof_S(fmValue epsd, fmValue rhos, fmValue rhof, fmValue S)
        {
            return 1 / (((1 - epsd) * rhos) / (epsd * rhof * S) + 1);
        }

        public static fmValue Eval_pmOverPn_vacuum_From_Dpd(fmValue Dpd)
        {
            fmValue pN = new fmValue(1e5);
            return 1 - Dpd / (2 * pN);
        }

        public static fmValue Eval_Qgimax_From_A_pcd_pmoverpn_Dpd_etag_hcd_hce_Tetta_ag1_ag2(fmValue A, fmValue pcd, fmValue pmoverpn, fmValue Dpd, fmValue etag, fmValue hcd, fmValue hce, fmValue Tetta, fmValue ag1, fmValue ag2)
        {
            fmValue bar = new fmValue(1e5);
            fmValue Tn = new fmValue(273);
            fmValue T = Tetta + Tn;
            return A * pcd * pmoverpn * Dpd * Tn / (etag * (hcd + hce) * T) * (ag1 + ag2 * fmValue.Log(Dpd / bar));
        }

        public static fmValue Eval_Qgi_From_Qgimax_ag3_K(fmValue Qgimax, fmValue ag3, fmValue K)
        {
            return Qgimax * (1 - fmValue.Exp(-ag3 * K));
        }

        public static fmValue Eval_Qgt_From_Qgimax_ag3_K(fmValue Qgimax, fmValue ag3, fmValue K)
        {
            return Qgimax * (1 - (1 - fmValue.Exp(-ag3 * K)) / (ag3 * K));
        }

        public static fmValue Eval_Qg_From_Qgt_td_tc(fmValue Qgt, fmValue td, fmValue tc)
        {
            return Qgt * td / tc;
        }

        public static fmValue Eval_vg_From_Qgt_td_Ms(fmValue Qgt, fmValue td, fmValue Ms)
        {
            return Qgt * td / Ms;
        }

        public static fmValue Eval_Vfd_From_Vcd_epsd_Smech(fmValue Vcd, fmValue epsd, fmValue Smech)
        {
            return Vcd * epsd * (1 - Smech);
        }

        public static fmValue Eval_Vlcd_From_Vcd_epsd_S(fmValue Vcd, fmValue epsd, fmValue S)
        {
            return Vcd * epsd * S;
        }

        public static fmValue Eval_Qfid_From_Vcd_ad1_ad2_Srem_K_pcd_Dpd_pke_etaf_hcd_hce(
            fmValue Vcd, fmValue ad1, fmValue ad2, fmValue Srem, fmValue K, fmValue pcd,
            fmValue Dpd, fmValue pke, fmValue etaf, fmValue hcd, fmValue hce)
        {
            return Vcd * ad1 * ad2 * (1 - Srem) * fmValue.Pow(1 + ad2 * K, -ad1 - 1) * pcd * (Dpd - pke) / (etaf * hcd * (hcd + hce));
        }
    }
}
