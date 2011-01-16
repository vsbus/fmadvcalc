using System;
using System.Collections.Generic;
using System.Text;
using fmCalculationLibrary.Equations;
using fmCalculationLibrary;

namespace fmCalculatorsLibrary
{
    public class fmDeliquoringSimualtionCalculator : fmBaseCalculator
    {
        public fmDeliquoringSimualtionCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            var hcd = variables[fmGlobalParameter.hcd] as fmCalculationVariableParameter;
            var sd = variables[fmGlobalParameter.sd] as fmCalculationVariableParameter;
            var td = variables[fmGlobalParameter.td] as fmCalculationVariableParameter;
            var K = variables[fmGlobalParameter.K] as fmCalculationVariableParameter;
            var Smech = variables[fmGlobalParameter.Smech] as fmCalculationVariableParameter;
            var S = variables[fmGlobalParameter.S] as fmCalculationVariableParameter;
            var Rfmech = variables[fmGlobalParameter.Rfmech] as fmCalculationVariableParameter;
            var Rf = variables[fmGlobalParameter.Rf] as fmCalculationVariableParameter;
            var Qgi = variables[fmGlobalParameter.Qgi] as fmCalculationVariableParameter;
            var Qg = variables[fmGlobalParameter.Qg] as fmCalculationVariableParameter;
            var vg = variables[fmGlobalParameter.vg] as fmCalculationVariableParameter;
            var Mfd = variables[fmGlobalParameter.Mfd] as fmCalculationVariableParameter;
            var Vfd = variables[fmGlobalParameter.Vfd] as fmCalculationVariableParameter;
            var Mlcd = variables[fmGlobalParameter.Mlcd] as fmCalculationVariableParameter;
            var Vlcd = variables[fmGlobalParameter.Vlcd] as fmCalculationVariableParameter;
            var Mcd = variables[fmGlobalParameter.Mcd] as fmCalculationVariableParameter;
            var Vcd = variables[fmGlobalParameter.Vcd] as fmCalculationVariableParameter;
            var rho_bulk = variables[fmGlobalParameter.rho_bulk] as fmCalculationVariableParameter;
            var Qmfid = variables[fmGlobalParameter.Qmfid] as fmCalculationVariableParameter;
            var Qfid = variables[fmGlobalParameter.Qfid] as fmCalculationVariableParameter;
            var Qmcd = variables[fmGlobalParameter.Qmcd] as fmCalculationVariableParameter;
            var Qcd = variables[fmGlobalParameter.Qcd] as fmCalculationVariableParameter;
            var qmfid = variables[fmGlobalParameter.qmfid] as fmCalculationVariableParameter;
            var qfid = variables[fmGlobalParameter.qfid] as fmCalculationVariableParameter;
            var qmcd = variables[fmGlobalParameter.qmcd] as fmCalculationVariableParameter;
            var qcd = variables[fmGlobalParameter.qcd] as fmCalculationVariableParameter;
            
            var hc = variables[fmGlobalParameter.hc] as fmCalculationConstantParameter;
            var eps = variables[fmGlobalParameter.eps] as fmCalculationConstantParameter;
            var epsd = variables[fmGlobalParameter.eps_d] as fmCalculationConstantParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationConstantParameter;
            var pcd = variables[fmGlobalParameter.pc_d] as fmCalculationConstantParameter;
            var Dpd = variables[fmGlobalParameter.Dp_d] as fmCalculationConstantParameter;
            var pke = variables[fmGlobalParameter.pke] as fmCalculationConstantParameter;
            var etaf = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            var hce = variables[fmGlobalParameter.hce0] as fmCalculationConstantParameter;
            var Srem = variables[fmGlobalParameter.Srem] as fmCalculationConstantParameter;
            var ad1 = variables[fmGlobalParameter.ad1] as fmCalculationConstantParameter;
            var ad2 = variables[fmGlobalParameter.ad2] as fmCalculationConstantParameter;
            var A = variables[fmGlobalParameter.A] as fmCalculationConstantParameter;
            var peq = variables[fmGlobalParameter.peq] as fmCalculationConstantParameter;
            var Mmole = variables[fmGlobalParameter.Mmole] as fmCalculationConstantParameter;
            var Tetta = variables[fmGlobalParameter.Tetta] as fmCalculationConstantParameter;
            var ag1 = variables[fmGlobalParameter.ag1] as fmCalculationConstantParameter;
            var ag2 = variables[fmGlobalParameter.ag2] as fmCalculationConstantParameter;
            var ag3 = variables[fmGlobalParameter.ag3] as fmCalculationConstantParameter;
            var f = variables[fmGlobalParameter.f] as fmCalculationConstantParameter;
            var etag = variables[fmGlobalParameter.eta_g] as fmCalculationConstantParameter;
            var rhof = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
            var rhos = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
            var Ms = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;

            hcd.value = fmDeliquoringEquations.Eval_hcd_from_hcf_epsf_epsd(hc.value, eps.value, epsd.value);

            var isKnown_sd = sd.isInputed;
            var isKnown_td = td.isInputed;
            var isKnown_K = K.isInputed;
            var isKnown_Vcd = Vcd.isInputed;
            var isKnown_Smech = Smech.isInputed;
            var isKnown_S = S.isInputed;
            var isKnown_Rfmech = Rfmech.isInputed;
            var isKnown_Rf = Rf.isInputed;
            var isKnown_rho_bulk = rho_bulk.isInputed;
            var isKnown_Mcd = Mcd.isInputed;
            var isKnown_Qgi = Qgi.isInputed;
            var isKnown_Qg = Qg.isInputed;
            var isKnown_vg = vg.isInputed;
            var isKnown_Vfd = Vfd.isInputed;
            var isKnown_Mfd = Mfd.isInputed;
            var isKnown_Vlcd = Vlcd.isInputed;
            var isKnown_Mlcd = Mlcd.isInputed;
            var isKnown_Qfid = Qfid.isInputed;
            var isKnown_Qmfid = Qmfid.isInputed;
            var isKnown_Qcd = Qcd.isInputed;
            var isKnown_Qmcd = Qmcd.isInputed;
            var isKnown_qmfid = qmfid.isInputed;
            var isKnown_qfid = qfid.isInputed;
            var isKnown_qmcd = qmcd.isInputed;
            var isKnown_qcd = qcd.isInputed;

            fmValue pmoverpn = fmDeliquoringEquations.Eval_pmOverPn_vacuum_From_Dpd(Dpd.value);
            fmValue Qgimax = fmDeliquoringEquations.Eval_Qgimax_From_A_pcd_pmoverpn_Dpd_etag_hcd_hce_Tetta_ag1_ag2(A.value, pcd.value, pmoverpn, Dpd.value, etag.value, hcd.value, hce.value, Tetta.value, ag1.value, ag2.value);

            if (isKnown_Qfid)
            {
                K.value = fmDeliquoringEquations.Eval_K_From_Vcd_ad1_ad2_Srem_Qfid_pcd_Dpd_pke_etaf_hcd_hce(Vcd.value, ad1.value, ad2.value, Srem.value, Qfid.value, pcd.value, Dpd.value, pke.value, etaf.value, hcd.value, hce.value);
                isKnown_K = true;
            }
            if (isKnown_Mfd)
            {
                Vfd.value = fmBasicEquations.Eval_Volume_From_rho_Mass(rhof.value, Mfd.value);
                isKnown_Vfd = true;
            }
            if (isKnown_Vfd)
            {
                Smech.value = fmDeliquoringEquations.Eval_Smech_From_Vcd_epsd_Vfd(Vcd.value, epsd.value, Vfd.value);
                isKnown_Smech = true;
            }
            if (isKnown_Qgi)
            {
                K.value = fmDeliquoringEquations.Eval_K_From_Qgimax_ag3_Qgi(Qgimax, ag3.value, Qgi.value);
                isKnown_K = true;
            }
            if (isKnown_Rfmech)
            {
                Smech.value = fmDeliquoringEquations.Eval_S_From_eps_rhos_rhof_Rf(epsd.value, rhos.value, rhof.value, Rfmech.value);
                isKnown_Smech = true;
            }
            if (isKnown_Smech)
            {
                K.value = fmDeliquoringEquations.Eval_K_From_Srem_ad1_ad2_Smech(Srem.value, ad1.value, ad2.value, Smech.value);
                isKnown_K = true;
            }
            if (isKnown_K)
            {
                td.value = fmDeliquoringEquations.Eval_td_From_pcd_Dpd_pke_epsd_etaf_hcd_hce_K(pcd.value, Dpd.value, pke.value, epsd.value, etaf.value, hcd.value, hce.value, K.value);
                isKnown_td = true;
            }
            if (isKnown_td)
            {
                sd.value = fmDeliquoringEquations.Eval_sd_From_td_tc(td.value, tc.value);
                isKnown_sd = true;
            }

            if (!isKnown_td) td.value = fmDeliquoringEquations.Eval_td_From_sd_tc(sd.value, tc.value);
            if (!isKnown_K) K.value = fmDeliquoringEquations.Eval_K_From_pcd_Dpd_pke_epsd_etaf_hcd_hce_td(pcd.value, Dpd.value, pke.value, epsd.value, etaf.value, hcd.value, hce.value, td.value);
            if (!isKnown_Vcd) Vcd.value = fmDeliquoringEquations.Eval_Vcd_From_A_hcd(A.value, hcd.value);
            if (!isKnown_Smech) Smech.value = fmDeliquoringEquations.Eval_Smech_From_Srem_ad1_ad2_K(Srem.value, ad1.value, ad2.value, K.value);
            fmValue Vgmaxev = fmDeliquoringEquations.Eval_Vgmaxev_From_A_pcd_Dpd_etag_hcd_hce_ag1_ag2_td(A.value, pcd.value, Dpd.value, etag.value, hcd.value, hce.value, ag1.value, ag2.value, td.value);
            fmValue Vgev = fmDeliquoringEquations.Eval_Vgev_From_Vgmaxev_ag3_K(Vgmaxev, ag3.value, K.value);
            fmValue Mev = fmDeliquoringEquations.Eval_Mev_From_peq_Mmole_Tetta_Vgev_ag3_K_f(peq.value, Mmole.value, Tetta.value, Vgev, ag3.value, K.value, f.value);
            fmValue Sev = fmDeliquoringEquations.Eval_Sev_From_Mev_rhof_epsd_Vcd(Mev, rhof.value, epsd.value, Vcd.value);
            if (!isKnown_S) S.value = fmDeliquoringEquations.Eval_S_From_Smech_Sev(Smech.value, Sev);
            if (!isKnown_Rfmech) Rfmech.value = fmDeliquoringEquations.Eval_Rf_From_eps_rhos_rhof_S(epsd.value, rhos.value, rhof.value, Smech.value);
            if (!isKnown_Rf) Rf.value = fmDeliquoringEquations.Eval_Rf_From_eps_rhos_rhof_S(epsd.value, rhos.value, rhof.value, S.value);
            if (!isKnown_rho_bulk) rho_bulk.value = fmDeliquoringEquations.Eval_rho_bulk_From_rhof_epsd_rhos_S(rhof.value, epsd.value, rhos.value, S.value);
            if (!isKnown_Mcd) Mcd.value = fmBasicEquations.Eval_Mass_From_rho_Volume(rho_bulk.value, Vcd.value);
            if (!isKnown_Qgi) Qgi.value = fmDeliquoringEquations.Eval_Qgi_From_Qgimax_ag3_K(Qgimax, ag3.value, K.value);
            fmValue Qgt = fmDeliquoringEquations.Eval_Qgt_From_Qgimax_ag3_K(Qgimax, ag3.value, K.value);
            if (!isKnown_Qg) Qg.value = fmDeliquoringEquations.Eval_Qg_From_Qgt_td_tc(Qgt, td.value, tc.value);
            if (!isKnown_vg) vg.value = fmDeliquoringEquations.Eval_vg_From_Qgt_td_Ms(Qgt, td.value, Ms.value);
            if (!isKnown_Vfd) Vfd.value = fmDeliquoringEquations.Eval_Vfd_From_Vcd_epsd_Smech(Vcd.value, epsd.value, Smech.value);
            if (!isKnown_Mfd) Mfd.value = fmBasicEquations.Eval_Mass_From_rho_Volume(rhof.value, Vfd.value);
            if (!isKnown_Vlcd) Vlcd.value = fmDeliquoringEquations.Eval_Vlcd_From_Vcd_epsd_S(Vcd.value, epsd.value, S.value);
            if (!isKnown_Mlcd) Mlcd.value = fmBasicEquations.Eval_Mass_From_rho_Volume(rhof.value, Vlcd.value);
            if (!isKnown_Qfid) Qfid.value = fmDeliquoringEquations.Eval_Qfid_From_Vcd_ad1_ad2_Srem_K_pcd_Dpd_pke_etaf_hcd_hce(Vcd.value, ad1.value, ad2.value, Srem.value, K.value, pcd.value, Dpd.value, pke.value, etaf.value, hcd.value, hce.value);
            if (!isKnown_Qmfid) Qmfid.value = fmBasicEquations.Eval_Mass_From_rho_Volume(rhof.value, Qfid.value);
            if (!isKnown_Qcd) Qcd.value = fmFilterMachiningEquations.Eval_Q_From_V_t(Vcd.value, tc.value);
            if (!isKnown_Qmcd) Qmcd.value = fmFilterMachiningEquations.Eval_Qm_From_M_t(Mcd.value, tc.value);
            if (!isKnown_qmfid) qmfid.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmfid.value, A.value);
            if (!isKnown_qfid) qfid.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qfid.value, A.value);
            if (!isKnown_qmcd) qmcd.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmcd.value, A.value);
            if (!isKnown_qcd) qcd.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qcd.value, A.value);
        }
    }
}



