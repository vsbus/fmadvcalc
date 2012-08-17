using System;
using System.Collections.Generic;
using System.Text;
using fmCalculationLibrary.Equations;
using fmCalculationLibrary;

namespace fmCalculatorsLibrary
{
    public class fmDeliquoringSimualtionCalculator : fmBaseCalculator
    {
        public enum fmDeliquoringHcdEpsdCalculationOption
        {
            InputedByUser,
            CalculatedFromCakeFormation
        }

        public enum fmDeliquoringDpdInputOption
        {
            InputedByUser,
            CalculatedFromCakeFormation
        }

        public class DeliquoringCalculatorOptions
        {
            private bool isPlaneArea;
            private bool isVacuumFilter;
            private double hcdCoefficient;

            public DeliquoringCalculatorOptions(bool isPlaneArea, bool isVacuumFilter, double hcdCoefficient)
            {
                this.isPlaneArea = isPlaneArea;
                this.isVacuumFilter = isVacuumFilter;
                this.hcdCoefficient = hcdCoefficient;
            }

            public bool IsPlaneArea()
            {
                return isPlaneArea;
            }

            public bool IsVacuumFilter()
            {
                return isVacuumFilter;
            }

            public double GetHcdCoefficient()
            {
                return hcdCoefficient;
            }
        }

        public DeliquoringCalculatorOptions CalculatorOptions;

        public fmDeliquoringSimualtionCalculator(
            DeliquoringCalculatorOptions calculatorOptions,
            IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList)
        {
            this.CalculatorOptions = calculatorOptions;
        }
        
        override public void DoCalculations()
        {
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

            var epsd = variables[fmGlobalParameter.eps_d] as fmCalculationConstantParameter;
            var hcd = variables[fmGlobalParameter.hcd] as fmCalculationConstantParameter;
            var tc = variables[fmGlobalParameter.tc] as fmCalculationConstantParameter;
            var pcd = variables[fmGlobalParameter.pc_d] as fmCalculationConstantParameter;
            var Dpd = variables[fmGlobalParameter.Dp_d] as fmCalculationConstantParameter;
            var pke = variables[fmGlobalParameter.pke] as fmCalculationConstantParameter;
            var etad = variables[fmGlobalParameter.eta_d] as fmCalculationConstantParameter;
            var hce = variables[fmGlobalParameter.hce0] as fmCalculationConstantParameter;
            var Srem = variables[fmGlobalParameter.Srem] as fmCalculationConstantParameter;
            var ad1 = variables[fmGlobalParameter.ad1] as fmCalculationConstantParameter;
            var ad2 = variables[fmGlobalParameter.ad2] as fmCalculationConstantParameter;
            var A = variables[fmGlobalParameter.A] as fmCalculationConstantParameter;
            var d0 = variables[fmGlobalParameter.d0] as fmCalculationConstantParameter;
            var peq = variables[fmGlobalParameter.peq] as fmCalculationConstantParameter;
            var Mmole = variables[fmGlobalParameter.Mmole] as fmCalculationConstantParameter;
            var Tetta = variables[fmGlobalParameter.Tetta] as fmCalculationConstantParameter;
            var ag1 = variables[fmGlobalParameter.ag1] as fmCalculationConstantParameter;
            var ag2 = variables[fmGlobalParameter.ag2] as fmCalculationConstantParameter;
            var ag3 = variables[fmGlobalParameter.ag3] as fmCalculationConstantParameter;
            var f = variables[fmGlobalParameter.f] as fmCalculationConstantParameter;
            var etag = variables[fmGlobalParameter.eta_g] as fmCalculationConstantParameter;
            var rhod = variables[fmGlobalParameter.rho_d] as fmCalculationConstantParameter;
            var rhos = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
            var Ms = variables[fmGlobalParameter.Ms] as fmCalculationConstantParameter;

            var Qgt = variables[fmGlobalParameter.Qgt] as fmCalculationVariableParameter;
            var Vg = variables[fmGlobalParameter.Vg] as fmCalculationVariableParameter;
            var Mev = variables[fmGlobalParameter.Mev] as fmCalculationVariableParameter;
            var Vev = variables[fmGlobalParameter.Vev] as fmCalculationVariableParameter;
            var Qmftd = variables[fmGlobalParameter.Qmftd] as fmCalculationVariableParameter;
            var Qmfd = variables[fmGlobalParameter.Qmfd] as fmCalculationVariableParameter;
            var Qftd = variables[fmGlobalParameter.Qftd] as fmCalculationVariableParameter;
            var Qfd = variables[fmGlobalParameter.Qfd] as fmCalculationVariableParameter;
            var Qmevi = variables[fmGlobalParameter.Qmevi] as fmCalculationVariableParameter;
            var Qmevt = variables[fmGlobalParameter.Qmevt] as fmCalculationVariableParameter;
            var Qmev = variables[fmGlobalParameter.Qmev] as fmCalculationVariableParameter;
            var Qevi = variables[fmGlobalParameter.Qevi] as fmCalculationVariableParameter;
            var Qevt = variables[fmGlobalParameter.Qevt] as fmCalculationVariableParameter;
            var Qev = variables[fmGlobalParameter.Qev] as fmCalculationVariableParameter;
            var qmftd = variables[fmGlobalParameter.qmftd] as fmCalculationVariableParameter;
            var qmfd = variables[fmGlobalParameter.qmfd] as fmCalculationVariableParameter;
            var qftd = variables[fmGlobalParameter.qftd] as fmCalculationVariableParameter;
            var qfd = variables[fmGlobalParameter.qfd] as fmCalculationVariableParameter;
            var qmevi = variables[fmGlobalParameter.qmevi] as fmCalculationVariableParameter;
            var qmevt = variables[fmGlobalParameter.qmevt] as fmCalculationVariableParameter;
            var qmev = variables[fmGlobalParameter.qmev] as fmCalculationVariableParameter;
            var qevi = variables[fmGlobalParameter.qevi] as fmCalculationVariableParameter;
            var qevt = variables[fmGlobalParameter.qevt] as fmCalculationVariableParameter;
            var qev = variables[fmGlobalParameter.qev] as fmCalculationVariableParameter;

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

            fmValue pmoverpn;
            if (CalculatorOptions.IsVacuumFilter())
            {
                pmoverpn = fmDeliquoringEquations.Eval_pmOverPn_vacuum_From_Dpd_VacuumFilters(Dpd.value);
            }
            else
            {
                pmoverpn = fmDeliquoringEquations.Eval_pmOverPn_vacuum_From_Dpd_PressureFilters(Dpd.value);
            }

            fmValue hcdCoefficient = new fmValue(CalculatorOptions.GetHcdCoefficient());

            fmValue Qgimax = fmDeliquoringEquations.Eval_Qgimax_From_A_pcd_pmoverpn_Dpd_etag_hcd_hce_Tetta_ag1_ag2(A.value, pcd.value, pmoverpn, Dpd.value, etag.value, hcd.value, hce.value, Tetta.value, ag1.value, ag2.value, hcdCoefficient);
            fmValue Const1 = fmDeliquoringEquations.Eval_Const1(epsd.value, etad.value, hcd.value, hce.value, pcd.value, Dpd.value, pke.value, hcdCoefficient);

            if (!isKnown_Vcd)
            {
                if (CalculatorOptions.IsPlaneArea())
                {
                    Vcd.value = fmDeliquoringEquations.Eval_Vcd_From_A_hcd_plainArea(A.value, hcd.value);
                }
                else
                {
                    Vcd.value = fmDeliquoringEquations.Eval_Vcd_From_A_hcd_cylindricalArea(A.value, hcd.value, d0.value);
                }
            }
            fmValue SC1 = fmDeliquoringEquations.Eval_SC1_From_rhof_epsd_Vcd(rhod.value, epsd.value, Vcd.value);
            fmValue SC2 = fmDeliquoringEquations.Eval_SC2_From_peq_Mmole_Tetta(peq.value, Mmole.value, Tetta.value);
            fmValue SC3 = fmDeliquoringEquations.Eval_SC3_From_A_pcd_Dpd_ag1_ag2_etag_hcd_hce(A.value, pcd.value, Dpd.value, ag1.value, ag2.value, etag.value, hcd.value, hce.value, hcdCoefficient);
            fmValue Kmax = fmDeliquoringEquations.Eval_Kmax_From_Const1_tc(Const1, tc.value);

            if (isKnown_rho_bulk)
            {
                S.value = fmDeliquoringEquations.Eval_S_From_rhof_epsd_rhos_rhobulk(rhod.value, epsd.value, rhos.value, rho_bulk.value);
                isKnown_S = true;
            }
            if (isKnown_Mlcd)
            {
                Vlcd.value = fmBasicEquations.Eval_Volume_From_rho_Mass(rhod.value, Mlcd.value);
                isKnown_Vlcd = true;
            }
            if (isKnown_Vlcd)
            {
                S.value = fmDeliquoringEquations.Eval_S_From_Vcd_epsd_Vlcd(Vcd.value, epsd.value, Vlcd.value);
                isKnown_S = true;
            }
            if (isKnown_Rf)
            {
                S.value = fmDeliquoringEquations.Eval_S_From_eps_rhos_rhof_Rf(epsd.value, rhos.value, rhod.value, Rf.value);
                isKnown_S = true;
            } 
            if (isKnown_S)
            {
                K.value = fmDeliquoringEquations.Eval_K_From_Kmax_Srem_ad1_ad2_SC1_SC2_SC3_Const1_ag3_f_S(Kmax, Srem.value, ad1.value, ad2.value, SC1, SC2, SC3, Const1, ag3.value, f.value, S.value);
                isKnown_K = true;
            }
            if (isKnown_vg)
            {
                Qg.value = fmDeliquoringEquations.Eval_Qg_From_vg_tc_Ms(vg.value, tc.value, Ms.value);
                isKnown_Qg = true;
            }
            if (isKnown_Qg)
            {
                K.value = fmDeliquoringEquations.Eval_K_From_Qg_Qgimax_AndOtherConstants(Qg.value, ag3.value, tc.value, Qgimax, Const1);
                isKnown_K = true;
            }
            if (isKnown_qmfid)
            {
                Qmfid.value = fmFilterMachiningEquations.Eval_Q_From_q_A(qmfid.value, A.value);
                isKnown_Qmfid = true;
            }
            if (isKnown_Qmfid)
            {
                Qfid.value = fmBasicEquations.Eval_Volume_From_rho_Mass(rhod.value, Qmfid.value);
                isKnown_Qfid = true;
            }
            if (isKnown_qfid)
            {
                Qfid.value = fmFilterMachiningEquations.Eval_Q_From_q_A(qfid.value, A.value);
                isKnown_Qfid = true;
            }
            if (isKnown_Qfid)
            {
                K.value = fmDeliquoringEquations.Eval_K_From_Vcd_ad1_ad2_Srem_Qfid_pcd_Dpd_pke_etaf_hcd_hce(Vcd.value, ad1.value, ad2.value, Srem.value, Qfid.value, pcd.value, Dpd.value, pke.value, etad.value, hcd.value, hce.value, hcdCoefficient);
                isKnown_K = true;
            }
            if (isKnown_Mfd)
            {
                Vfd.value = fmBasicEquations.Eval_Volume_From_rho_Mass(rhod.value, Mfd.value);
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
                Smech.value = fmDeliquoringEquations.Eval_S_From_eps_rhos_rhof_Rf(epsd.value, rhos.value, rhod.value, Rfmech.value);
                isKnown_Smech = true;
            }
            if (isKnown_Smech)
            {
                K.value = fmDeliquoringEquations.Eval_K_From_Srem_ad1_ad2_Smech(Srem.value, ad1.value, ad2.value, Smech.value);
                isKnown_K = true;
            }
            if (isKnown_K)
            {
                td.value = fmDeliquoringEquations.Eval_td_From_pcd_Dpd_pke_epsd_etaf_hcd_hce_K(pcd.value, Dpd.value, pke.value, epsd.value, etad.value, hcd.value, hce.value, K.value, hcdCoefficient);
                isKnown_td = true;
            }
            if (isKnown_td)
            {
                sd.value = fmDeliquoringEquations.Eval_sd_From_td_tc(td.value, tc.value);
                isKnown_sd = true;
            }

            if (!isKnown_td) td.value = fmDeliquoringEquations.Eval_td_From_sd_tc(sd.value, tc.value);
            fmValue Vgmaxev = fmDeliquoringEquations.Eval_Vgmaxev_From_A_pcd_Dpd_etag_hcd_hce_ag1_ag2_td(A.value, pcd.value, Dpd.value, etag.value, hcd.value, hce.value, ag1.value, ag2.value, td.value, hcdCoefficient);
            if (!isKnown_K) K.value = fmDeliquoringEquations.Eval_K_From_pcd_Dpd_pke_epsd_etaf_hcd_hce_td(pcd.value, Dpd.value, pke.value, epsd.value, etad.value, hcd.value, hce.value, td.value, hcdCoefficient);
            if (!isKnown_Smech) Smech.value = fmDeliquoringEquations.Eval_Smech_From_Srem_ad1_ad2_K(Srem.value, ad1.value, ad2.value, K.value);
            fmValue Vgev = fmDeliquoringEquations.Eval_Vgev_From_Vgmaxev_ag3_K(Vgmaxev, ag3.value, K.value);
            Mev.value = fmDeliquoringEquations.Eval_Mev_From_peq_Mmole_Tetta_Vgev_ag3_K_f(peq.value, Mmole.value, Tetta.value, Vgev, ag3.value, K.value, f.value);
            fmValue Sev = fmDeliquoringEquations.Eval_Sev_From_Mev_rhof_epsd_Vcd(Mev.value, rhod.value, epsd.value, Vcd.value);
            if (!isKnown_S) S.value = fmDeliquoringEquations.Eval_S_From_Smech_Sev(Smech.value, Sev);
            if (!isKnown_Rfmech) Rfmech.value = fmDeliquoringEquations.Eval_Rf_From_eps_rhos_rhof_S(epsd.value, rhos.value, rhod.value, Smech.value);
            if (!isKnown_Rf) Rf.value = fmDeliquoringEquations.Eval_Rf_From_eps_rhos_rhof_S(epsd.value, rhos.value, rhod.value, S.value);
            if (!isKnown_rho_bulk) rho_bulk.value = fmDeliquoringEquations.Eval_rho_bulk_From_rhof_epsd_rhos_S(rhod.value, epsd.value, rhos.value, S.value);
            if (!isKnown_Mcd) Mcd.value = fmBasicEquations.Eval_Mass_From_rho_Volume(rho_bulk.value, Vcd.value);
            if (!isKnown_Qgi) Qgi.value = fmDeliquoringEquations.Eval_Qgi_From_Qgimax_ag3_K(Qgimax, ag3.value, K.value);
            Qgt.value = fmDeliquoringEquations.Eval_Qgt_From_Qgimax_ag3_K(Qgimax, ag3.value, K.value);
            if (!isKnown_Qg) Qg.value = fmDeliquoringEquations.Eval_Qg_From_Qgt_td_tc(Qgt.value, td.value, tc.value);
            if (!isKnown_vg) vg.value = fmDeliquoringEquations.Eval_vg_From_Qgt_td_Ms(Qgt.value, td.value, Ms.value);
            if (!isKnown_Vfd) Vfd.value = fmDeliquoringEquations.Eval_Vfd_From_Vcd_epsd_Smech(Vcd.value, epsd.value, Smech.value);
            if (!isKnown_Mfd) Mfd.value = fmBasicEquations.Eval_Mass_From_rho_Volume(rhod.value, Vfd.value);
            if (!isKnown_Vlcd) Vlcd.value = fmDeliquoringEquations.Eval_Vlcd_From_Vcd_epsd_S(Vcd.value, epsd.value, S.value);
            if (!isKnown_Mlcd) Mlcd.value = fmBasicEquations.Eval_Mass_From_rho_Volume(rhod.value, Vlcd.value);
            if (!isKnown_Qfid) Qfid.value = fmDeliquoringEquations.Eval_Qfid_From_Vcd_ad1_ad2_Srem_K_pcd_Dpd_pke_etaf_hcd_hce(Vcd.value, ad1.value, ad2.value, Srem.value, K.value, pcd.value, Dpd.value, pke.value, etad.value, hcd.value, hce.value, hcdCoefficient);
            if (!isKnown_Qmfid) Qmfid.value = fmBasicEquations.Eval_Mass_From_rho_Volume(rhod.value, Qfid.value);
            if (!isKnown_Qcd) Qcd.value = fmFilterMachiningEquations.Eval_Q_From_V_t(Vcd.value, tc.value);
            if (!isKnown_Qmcd) Qmcd.value = fmFilterMachiningEquations.Eval_Qm_From_M_t(Mcd.value, tc.value);
            if (!isKnown_qmfid) qmfid.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmfid.value, A.value);
            if (!isKnown_qfid) qfid.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qfid.value, A.value);
            if (!isKnown_qmcd) qmcd.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmcd.value, A.value);
            if (!isKnown_qcd) qcd.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qcd.value, A.value);

            Vg.value = fmFilterMachiningEquations.Eval_V_From_Q_t(Qgt.value, td.value);
            Vev.value = fmBasicEquations.Eval_Volume_From_rho_Mass(rhod.value, Mev.value);
            Qftd.value = fmFilterMachiningEquations.Eval_Q_From_V_t(Vfd.value, td.value);
            Qmftd.value = fmBasicEquations.Eval_Mass_From_rho_Volume(rhod.value, Qftd.value);
            Qfd.value = fmDeliquoringEquations.Eval_Q_From_Qt_td_tc(Qftd.value, td.value, tc.value);
            Qmfd.value = fmDeliquoringEquations.Eval_Q_From_Qt_td_tc(Qmftd.value, td.value, tc.value);
            Qmevi.value = fmDeliquoringEquations.Eval_Qmevi_From_peq_Mmole_pmoverpn_ag3_K_f_Qgi(peq.value, Mmole.value, pmoverpn, ag3.value, K.value, f.value, Qgi.value);
            Qevi.value = fmBasicEquations.Eval_Volume_From_rho_Mass(rhod.value, Qmevi.value);
            Qmevt.value = fmFilterMachiningEquations.Eval_Qm_From_M_t(Mev.value, td.value);
            Qmev.value = fmDeliquoringEquations.Eval_Q_From_Qt_td_tc(Qmevt.value, td.value, tc.value);
            Qevt.value = fmBasicEquations.Eval_Volume_From_rho_Mass(rhod.value, Qmevt.value);
            Qev.value = fmDeliquoringEquations.Eval_Q_From_Qt_td_tc(Qevt.value, td.value, tc.value);
            qmftd.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmftd.value, A.value);
            qmfd.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmfd.value, A.value);
            qftd.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qftd.value, A.value);
            qfd.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qfd.value, A.value);
            qmevi.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmevi.value, A.value);
            qmevt.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmevt.value, A.value);
            qmev.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qmev.value, A.value);
            qevi.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qevi.value, A.value);
            qevt.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qevt.value, A.value);
            qev.value = fmFilterMachiningEquations.Eval_q_From_Q_A(Qev.value, A.value);
        }
    }
}



