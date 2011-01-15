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

            hcd.value = fmDeliquoringEquations.Eval_hcd_from_hcf_epsf_epsd(hc.value, eps.value, epsd.value);

            td.value = fmDeliquoringEquations.Eval_td_From_sd_tc(sd.value, tc.value);
            K.value = fmDeliquoringEquations.Eval_K_From_pcd_Dpd_pke_epsd_etaf_hcd_hce_td(pcd.value, Dpd.value, pke.value, epsd.value, etaf.value, hcd.value, hce.value, td.value);
            Vcd.value = fmDeliquoringEquations.Eval_Vcd_From_A_hcd(A.value, hcd.value);
            Smech.value = fmDeliquoringEquations.Eval_Smech_From_Srem_ad1_ad2_K(Srem.value, ad1.value, ad2.value, K.value);
            fmValue Vgmaxev = fmDeliquoringEquations.Eval_Vgmaxev_From_A_pcd_Dpd_etag_hcd_hce_ag1_ag2_td(A.value, pcd.value, Dpd.value, etag.value, hcd.value, hce.value, ag1.value, ag2.value, td.value);
            fmValue Vgev = fmDeliquoringEquations.Eval_Vgev_From_Vgmaxev_ag3_K(Vgmaxev, ag3.value, K.value);
            fmValue Mev = fmDeliquoringEquations.Eval_Mev_From_peq_Mmole_Tetta_Vgev_ag3_K_f(peq.value, Mmole.value, Tetta.value, Vgev, ag3.value, K.value, f.value);
            fmValue Sev = fmDeliquoringEquations.Eval_Sev_From_Mev_rhof_epsd_Vcd(Mev, rhof.value, epsd.value, Vcd.value);
            S.value = fmDeliquoringEquations.Eval_S_From_Smech_Sev(Smech.value, Sev);
            Rfmech.value = fmDeliquoringEquations.Eval_Rf_From_eps_rhos_rhof_S(epsd.value, rhos.value, rhof.value, Smech.value);
            Rf.value = fmDeliquoringEquations.Eval_Rf_From_eps_rhos_rhof_S(epsd.value, rhos.value, rhof.value, S.value);
            rho_bulk.value = fmDeliquoringEquations.Eval_rho_bulk_From_rhof_epsd_rhos_S(rhof.value, epsd.value, rhos.value, S.value);

        }
    }
}


