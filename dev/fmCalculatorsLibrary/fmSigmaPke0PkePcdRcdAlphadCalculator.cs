﻿using System;
using System.Collections.Generic;
using System.Text;
using fmCalculationLibrary;
using fmCalculationLibrary.Equations;

namespace fmCalculatorsLibrary
{
    public class fmSigmaPke0PkePcdRcdAlphadCalculator : fmBaseCalculator
    {
        public enum fmRhoDEtaDCalculationOption
        {
            InputedByUser,
            EqualToRhoF
        }
        public fmRhoDEtaDCalculationOption rhoDetaDCalculationOption;

        public enum fmPcDCalculationOption
        {
            InputedByUser,
            Calculated
        }
        public fmPcDCalculationOption PcDCalculationOption;

        public fmSigmaPke0PkePcdRcdAlphadCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            var eta_f = variables[fmGlobalParameter.eta_f] as fmCalculationConstantParameter;
            var rho_f = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;
            var Dpf = variables[fmGlobalParameter.Dp] as fmCalculationConstantParameter;
            var Dpd = variables[fmGlobalParameter.Dp_d] as fmCalculationConstantParameter;
            var nc = variables[fmGlobalParameter.nc] as fmCalculationConstantParameter;
            var eps_d = variables[fmGlobalParameter.eps_d] as fmCalculationConstantParameter;
            var rho_s = variables[fmGlobalParameter.rho_s] as fmCalculationConstantParameter;
            var Pc0 = variables[fmGlobalParameter.Pc0] as fmCalculationConstantParameter;

            var eta_d = variables[fmGlobalParameter.eta_d] as fmCalculationVariableParameter;
            var rho_d = variables[fmGlobalParameter.rho_d] as fmCalculationVariableParameter;
            var sigma = variables[fmGlobalParameter.sigma] as fmCalculationVariableParameter;
            var pke0 = variables[fmGlobalParameter.pke0] as fmCalculationVariableParameter;
            var pke = variables[fmGlobalParameter.pke] as fmCalculationVariableParameter;
            var pcd = variables[fmGlobalParameter.pc_d] as fmCalculationVariableParameter;
            var rcd = variables[fmGlobalParameter.rc_d] as fmCalculationVariableParameter;
            var alphad = variables[fmGlobalParameter.alpha_d] as fmCalculationVariableParameter;

            if (rhoDetaDCalculationOption == fmRhoDEtaDCalculationOption.EqualToRhoF)
            {
                eta_d.value = eta_f.value;
                rho_d.value = rho_f.value;
            }


            if (PcDCalculationOption == fmPcDCalculationOption.Calculated)
            {
                fmValue Dp = fmValue.Max(Dpd.value, Dpf.value);
                pcd.value = fmEpsPcFrom0Equations.Eval_Pc_From_Pc0_Dp_nc(Pc0.value, Dp, nc.value);
                rcd.value = fmPcrcaEquations.Eval_rc_From_Pc(pcd.value);
                alphad.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(pcd.value, eps_d.value, rho_s.value);
            }
            else
            {
                if (pcd.isInputed)
                {
                    rcd.value = fmPcrcaEquations.Eval_rc_From_Pc(pcd.value);
                    alphad.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(pcd.value, eps_d.value, rho_s.value);
                }
                else if (rcd.isInputed)
                {
                    pcd.value = fmPcrcaEquations.Eval_Pc_From_rc(rcd.value);
                    alphad.value = fmPcrcaEquations.Eval_a_From_Pc_eps_rho_s(pcd.value, eps_d.value, rho_s.value);
                }
                else if (alphad.isInputed)
                {
                    pcd.value = fmPcrcaEquations.Eval_Pc_From_a_eps_rho_s(alphad.value, eps_d.value, rho_s.value);
                    rcd.value = fmPcrcaEquations.Eval_rc_From_Pc(pcd.value);
                }
            }

            if (pke0.isInputed)
            {
                pke.value = fmDeliquoringEquations.Eval_pke_From_pke0_sigma_Pc(pke0.value, sigma.value, pcd.value);                
            }
            else
            {
                pke0.value = fmDeliquoringEquations.Eval_pke0_From_pke_sigma_Pc(pke.value, sigma.value, pcd.value);                
            }
        }
    }
}
