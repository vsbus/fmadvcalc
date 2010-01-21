using System;
using fmCalculationLibrary;
using fmCalculationLibrary.Equations;

namespace fmCalculatorsLibrary
{
    public class fmFilterMachiningCalculator : fmBaseCalculator
    {
        public enum CalculationOptions
        {
            UNDEFINED,

            STANDART1_A_Dp_sf_n_INPUT,
            STANDART1_A_Dp_tr_n_INPUT,
            STANDART1_A_Dp_sf_tc_INPUT,
            STANDART1_A_Dp_tr_tc_INPUT,
            
            STANDART2_A_Dp_sf_tf_INPUT,
            STANDART2_A_Dp_tr_tf_INPUT,
            
            STANDART3_A_Dp_n_tf_INPUT,
            STANDART3_A_Dp_tc_tf_INPUT,
            STANDART3_A_Dp_tr_tf_INPUT,
            
            STANDART4_A_hc_sf_n_INPUT,
            STANDART4_A_hc_sf_tc_INPUT,
            STANDART4_A_hc_tr_n_INPUT,
            STANDART4_A_hc_tr_tc_INPUT,
            STANDART4_A_Vf_sf_n_INPUT,
            STANDART4_A_Vf_sf_tc_INPUT,
            STANDART4_A_Vf_tr_n_INPUT,
            STANDART4_A_Vf_tr_tc_INPUT,
            STANDART4_A_Mf_sf_n_INPUT,
            STANDART4_A_Mf_sf_tc_INPUT,
            STANDART4_A_Mf_tr_n_INPUT,
            STANDART4_A_Mf_tr_tc_INPUT,
            
            STANDART7_A_Dp_hc_sf_INPUT,
            STANDART7_A_Dp_hc_tr_INPUT,
            STANDART7_A_Dp_Vf_sf_INPUT,
            STANDART7_A_Dp_Vf_tr_INPUT,
            STANDART7_A_Dp_Mf_sf_INPUT,
            STANDART7_A_Dp_Mf_tr_INPUT,
            
            STANDART8_A_Dp_hc_n_INPUT,
            STANDART8_A_Dp_hc_tc_INPUT,
            STANDART8_A_Dp_hc_tr_INPUT,
            STANDART8_A_Dp_Vf_n_INPUT,
            STANDART8_A_Dp_Vf_tc_INPUT,
            STANDART8_A_Dp_Vf_tr_INPUT,
            STANDART8_A_Dp_Mf_n_INPUT,
            STANDART8_A_Dp_Mf_tc_INPUT,
            STANDART8_A_Dp_Mf_tr_INPUT,

            DESIGN1_Qms_Dp_hc_n_INPUT,
            DESIGN1_Qsus_Dp_hc_n_INPUT,
            DESIGN1_Qmsus_Dp_hc_n_INPUT,
            DESIGN1_Qms_Dp_hc_tc_INPUT,
            DESIGN1_Qsus_Dp_hc_tc_INPUT,
            DESIGN1_Qmsus_Dp_hc_tc_INPUT,
            DESIGN1_Qms_Dp_hc_tr_INPUT,
            DESIGN1_Qsus_Dp_hc_tr_INPUT,
            DESIGN1_Qmsus_Dp_hc_tr_INPUT,

            OPTIMIZATION1_A_Qms_Dp_sf_INPUT,
            OPTIMIZATION1_A_Qsus_Dp_sf_INPUT,
            OPTIMIZATION1_A_Qmsus_Dp_sf_INPUT,
            OPTIMIZATION1_A_Qms_Dp_tr_INPUT,
            OPTIMIZATION1_A_Qsus_Dp_tr_INPUT,
            OPTIMIZATION1_A_Qmsus_Dp_tr_INPUT
        }

        public class fmVariables
        {
            public fmValue A;
            public fmValue Dp;
            public fmValue sf;
            public fmValue n;
            public fmValue tc;
            public fmValue tf;
            public fmValue tr;
            public fmValue hc;
            public fmValue Qsus;
            public fmValue Qmsus;
            public fmValue Qms;
            public fmValue Vsus;
            public fmValue Mf;
            public fmValue Vf;
            public fmValue Ms;
            public fmValue Msus;
            public fmValue eps;
            public fmValue kappa;
            public fmValue Pc;
            public fmValue rc;
            public fmValue a;
        }

        public class fmConstants
        {
            public fmValue eps0;
            public fmValue kappa0;
            public fmValue Pc0;
            public fmValue eta_f;
            public fmValue rho_f;
            public fmValue rho_s;
            public fmValue rho_sus;
            public fmValue Cv;
            public fmValue Cm;
            public fmValue ne;
            public fmValue nc;
            public fmValue hce;
        }

        public class fmIntermediateVariables
        {
            //public fmValue Vf;
        }

        public CalculationOptions calculationOption;
        public fmConstants constants = new fmConstants();
        public fmVariables variables = new fmVariables();
        public fmIntermediateVariables intermediateVariables = new fmIntermediateVariables();

        private bool IsStandart1Option(CalculationOptions calculationOption)
        {
            return calculationOption == CalculationOptions.STANDART1_A_Dp_sf_n_INPUT
                   || calculationOption == CalculationOptions.STANDART1_A_Dp_tr_n_INPUT
                   || calculationOption == CalculationOptions.STANDART1_A_Dp_sf_tc_INPUT
                   || calculationOption == CalculationOptions.STANDART1_A_Dp_tr_tc_INPUT;
        }

        private bool IsStandart2Option(CalculationOptions calculationOption)
        {
            return calculationOption == CalculationOptions.STANDART2_A_Dp_sf_tf_INPUT
                || calculationOption == CalculationOptions.STANDART2_A_Dp_tr_tf_INPUT;
        }

        private bool IsStandart3Option(CalculationOptions calculationOption)
        {
            return calculationOption == CalculationOptions.STANDART3_A_Dp_n_tf_INPUT
                   || calculationOption == CalculationOptions.STANDART3_A_Dp_tc_tf_INPUT
                   || calculationOption == CalculationOptions.STANDART3_A_Dp_tr_tf_INPUT;
        }

        private bool IsStandart4Option(CalculationOptions calculationOption)
        {
            return calculationOption == CalculationOptions.STANDART4_A_hc_sf_n_INPUT
                   || calculationOption == CalculationOptions.STANDART4_A_hc_sf_tc_INPUT
                   || calculationOption == CalculationOptions.STANDART4_A_hc_tr_n_INPUT
                   || calculationOption == CalculationOptions.STANDART4_A_hc_tr_tc_INPUT

                   || calculationOption == CalculationOptions.STANDART4_A_Vf_sf_n_INPUT
                   || calculationOption == CalculationOptions.STANDART4_A_Vf_sf_tc_INPUT
                   || calculationOption == CalculationOptions.STANDART4_A_Vf_tr_n_INPUT
                   || calculationOption == CalculationOptions.STANDART4_A_Vf_tr_tc_INPUT

                   || calculationOption == CalculationOptions.STANDART4_A_Mf_sf_n_INPUT
                   || calculationOption == CalculationOptions.STANDART4_A_Mf_sf_tc_INPUT
                   || calculationOption == CalculationOptions.STANDART4_A_Mf_tr_n_INPUT
                   || calculationOption == CalculationOptions.STANDART4_A_Mf_tr_tc_INPUT;
        }

        private bool IsStandart7Option(CalculationOptions calculationOption)
        {
            return calculationOption == CalculationOptions.STANDART7_A_Dp_hc_sf_INPUT
                   || calculationOption == CalculationOptions.STANDART7_A_Dp_hc_tr_INPUT
                   || calculationOption == CalculationOptions.STANDART7_A_Dp_Vf_sf_INPUT
                   || calculationOption == CalculationOptions.STANDART7_A_Dp_Vf_tr_INPUT
                   || calculationOption == CalculationOptions.STANDART7_A_Dp_Mf_sf_INPUT
                   || calculationOption == CalculationOptions.STANDART7_A_Dp_Mf_tr_INPUT;
        }

        private bool IsStandart8Option(CalculationOptions calculationOption)
        {
            return calculationOption == CalculationOptions.STANDART8_A_Dp_hc_n_INPUT
                || calculationOption == CalculationOptions.STANDART8_A_Dp_hc_tc_INPUT
                || calculationOption == CalculationOptions.STANDART8_A_Dp_hc_tr_INPUT
                || calculationOption == CalculationOptions.STANDART8_A_Dp_Vf_n_INPUT
                || calculationOption == CalculationOptions.STANDART8_A_Dp_Vf_tc_INPUT
                || calculationOption == CalculationOptions.STANDART8_A_Dp_Vf_tr_INPUT;
        }

        private bool IsStandartKindOption(CalculationOptions calculationOption)
        {
            return IsStandart1Option(calculationOption)
                   || IsStandart2Option(calculationOption)
                   || IsStandart3Option(calculationOption)
                   || IsStandart4Option(calculationOption)
                   || IsStandart7Option(calculationOption)
                   || IsStandart8Option(calculationOption);
        }

        private bool IsDesignKindOption(CalculationOptions calculationOption)
        {
            return calculationOption == CalculationOptions.DESIGN1_Qms_Dp_hc_n_INPUT
                || calculationOption == CalculationOptions.DESIGN1_Qmsus_Dp_hc_n_INPUT
                || calculationOption == CalculationOptions.DESIGN1_Qsus_Dp_hc_n_INPUT
                || calculationOption == CalculationOptions.DESIGN1_Qms_Dp_hc_tc_INPUT
                || calculationOption == CalculationOptions.DESIGN1_Qmsus_Dp_hc_tc_INPUT
                || calculationOption == CalculationOptions.DESIGN1_Qsus_Dp_hc_tc_INPUT
                || calculationOption == CalculationOptions.DESIGN1_Qms_Dp_hc_tr_INPUT
                || calculationOption == CalculationOptions.DESIGN1_Qmsus_Dp_hc_tr_INPUT
                || calculationOption == CalculationOptions.DESIGN1_Qsus_Dp_hc_tr_INPUT;
        }

        private bool IsOptimizationKindOption(CalculationOptions calculationOption)
        {
            return calculationOption == CalculationOptions.OPTIMIZATION1_A_Qms_Dp_sf_INPUT
                || calculationOption == CalculationOptions.OPTIMIZATION1_A_Qmsus_Dp_sf_INPUT
                || calculationOption == CalculationOptions.OPTIMIZATION1_A_Qsus_Dp_sf_INPUT
                || calculationOption == CalculationOptions.OPTIMIZATION1_A_Qms_Dp_tr_INPUT
                || calculationOption == CalculationOptions.OPTIMIZATION1_A_Qmsus_Dp_tr_INPUT
                || calculationOption == CalculationOptions.OPTIMIZATION1_A_Qsus_Dp_tr_INPUT;
        }

        private bool IsStandartSubKind1DpOption(CalculationOptions calculationOption)
        {
            return IsStandart1Option(calculationOption)
                   || IsStandart2Option(calculationOption)
                   || IsStandart3Option(calculationOption);
        }

        private bool IsStandartSubKind2hcOption(CalculationOptions calculationOption)
        {
            return IsStandart4Option(calculationOption);
        }

        private bool IsStandartSubKind3DphcOption(CalculationOptions calculationOption)
        {
            return IsStandart7Option(calculationOption)
                   || IsStandart8Option(calculationOption);
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

            variables.Vsus = FilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(variables.A, variables.hc, variables.kappa);
            variables.Msus = FilterMachiningEquations.Eval_M_From_rho_V(constants.rho_sus, variables.Vsus);
            variables.Ms = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(variables.Msus, constants.Cm);
            variables.Qsus = FilterMachiningEquations.Eval_Qsus_From_Vsus_tc(variables.Vsus, variables.tc);
            variables.Qmsus = FilterMachiningEquations.Eval_Qmsus_From_Msus_tc(variables.Msus, variables.tc);
            variables.Qms = FilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(variables.Qmsus, constants.Cm);
        }
        private void DoCalculationsDesign()
        {
            variables.eps = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(constants.eps0, variables.Dp, constants.ne);
            variables.kappa = EpsKappaEquations.Eval_kappa_From_eps_Cv(variables.eps, constants.Cv);
            variables.Pc = FilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(constants.Pc0, variables.Dp, constants.nc);
            variables.rc = PcrcaEquations.Eval_rc_From_Pc(variables.Pc);
            variables.a = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(variables.Pc, variables.eps, constants.rho_s);
            variables.tf = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(constants.eta_f, variables.hc, constants.hce, variables.Pc, variables.kappa, variables.Dp);


            switch (calculationOption)
            {
                case CalculationOptions.DESIGN1_Qms_Dp_hc_n_INPUT:
                    {
                        variables.Qmsus = FilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(variables.Qms, constants.Cm);
                        variables.Qsus = FilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(variables.Qms, constants.rho_s, constants.Cv);
                        variables.tc = FilterMachiningEquations.Eval_tc_From_n(variables.n);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.DESIGN1_Qmsus_Dp_hc_n_INPUT:
                    {
                        variables.Qms = FilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(variables.Qmsus, constants.Cm);
                        variables.Qsus = FilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(variables.Qms, constants.rho_s, constants.Cv);
                        variables.tc = FilterMachiningEquations.Eval_tc_From_n(variables.n);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.DESIGN1_Qsus_Dp_hc_n_INPUT:
                    {
                        variables.Qms = FilterMachiningEquations.Eval_Qm_From_Qsus_rhos_Cv(variables.Qsus, constants.rho_s, constants.Cv);
                        variables.Qmsus = FilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(variables.Qms, constants.Cm);
                        variables.tc = FilterMachiningEquations.Eval_tc_From_n(variables.n);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.DESIGN1_Qms_Dp_hc_tc_INPUT:
                    {
                        variables.Qmsus = FilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(variables.Qms, constants.Cm);
                        variables.Qsus = FilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(variables.Qms, constants.rho_s, constants.Cv);
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.DESIGN1_Qmsus_Dp_hc_tc_INPUT:
                    {
                        variables.Qms = FilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(variables.Qmsus, constants.Cm);
                        variables.Qsus = FilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(variables.Qms, constants.rho_s, constants.Cv);
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.DESIGN1_Qsus_Dp_hc_tc_INPUT:
                    {
                        variables.Qms = FilterMachiningEquations.Eval_Qm_From_Qsus_rhos_Cv(variables.Qsus, constants.rho_s, constants.Cv);
                        variables.Qmsus = FilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(variables.Qms, constants.Cm);
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.DESIGN1_Qms_Dp_hc_tr_INPUT:
                    {
                        variables.Qmsus = FilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(variables.Qms, constants.Cm);
                        variables.Qsus = FilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(variables.Qms, constants.rho_s, constants.Cv);
                        variables.tc = FilterMachiningEquations.Eval_tc_From_tr_tf(variables.tr, variables.tf);
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                    }
                    break;
                case CalculationOptions.DESIGN1_Qmsus_Dp_hc_tr_INPUT:
                    {
                        variables.Qms = FilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(variables.Qmsus, constants.Cm);
                        variables.Qsus = FilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(variables.Qms, constants.rho_s, constants.Cv);
                        variables.tc = FilterMachiningEquations.Eval_tc_From_tr_tf(variables.tr, variables.tf);
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                    }
                    break;
                case CalculationOptions.DESIGN1_Qsus_Dp_hc_tr_INPUT:
                    {
                        variables.Qms = FilterMachiningEquations.Eval_Qm_From_Qsus_rhos_Cv(variables.Qsus, constants.rho_s, constants.Cv);
                        variables.Qmsus = FilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(variables.Qms, constants.Cm);
                        variables.tc = FilterMachiningEquations.Eval_tc_From_tr_tf(variables.tr, variables.tf);
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                    }
                    break;
                default:
                    throw new Exception("not processed calculation option");
            }

            variables.A = FilterMachiningEquations.Eval_A_From_Qms_eps_rhos_hc_n(variables.Qms, variables.eps, constants.rho_s, variables.hc, variables.n);
            variables.sf = FilterMachiningEquations.Eval_sf_From_tf_tc(variables.tf, variables.tc);
            variables.Vf = FilterMachiningEquations.Eval_Vf_From_A_hc_kappa(variables.A, variables.hc, variables.kappa);
            variables.Mf = FilterMachiningEquations.Eval_M_From_rho_V(constants.rho_f, variables.Vf);
            variables.Vsus = FilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(variables.A, variables.hc, variables.kappa);
            variables.Msus = FilterMachiningEquations.Eval_M_From_rho_V(constants.rho_sus, variables.Vsus);
            variables.Ms = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(variables.Msus, constants.Cm);
        }
        private void DoCalculationsOptimization()
        {
            variables.eps = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(constants.eps0, variables.Dp, constants.ne);
            variables.kappa = EpsKappaEquations.Eval_kappa_From_eps_Cv(variables.eps, constants.Cv);
            variables.Pc = FilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(constants.Pc0, variables.Dp, constants.nc);
            variables.rc = PcrcaEquations.Eval_rc_From_Pc(variables.Pc);
            variables.a = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(variables.Pc, variables.eps, constants.rho_s);

            switch (calculationOption)
            {
                case CalculationOptions.OPTIMIZATION1_A_Qms_Dp_sf_INPUT:
                case CalculationOptions.OPTIMIZATION1_A_Qms_Dp_tr_INPUT:
                    {
                        variables.Qmsus = FilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(variables.Qms, constants.Cm);
                        variables.Qsus = FilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(variables.Qms, constants.rho_s, constants.Cv);
                    }
                    break;
                case CalculationOptions.OPTIMIZATION1_A_Qmsus_Dp_sf_INPUT:
                case CalculationOptions.OPTIMIZATION1_A_Qmsus_Dp_tr_INPUT:
                    {
                        variables.Qms = FilterMachiningEquations.Eval_Qms_From_Qmsus_Cm(variables.Qmsus, constants.Cm);
                        variables.Qsus = FilterMachiningEquations.Eval_Qsus_From_Qms_rhos_Cv(variables.Qms, constants.rho_s, constants.Cv);
                    }
                    break;
                case CalculationOptions.OPTIMIZATION1_A_Qsus_Dp_sf_INPUT:
                case CalculationOptions.OPTIMIZATION1_A_Qsus_Dp_tr_INPUT:
                    {
                        variables.Qms = FilterMachiningEquations.Eval_Qm_From_Qsus_rhos_Cv(variables.Qsus, constants.rho_s, constants.Cv);
                        variables.Qmsus = FilterMachiningEquations.Eval_Qmsus_From_Qms_Cm(variables.Qms, constants.Cm);
                    }
                    break;
                default:
                    throw new Exception("not processed calculation option");
            }


            switch (calculationOption)
            {
                case CalculationOptions.OPTIMIZATION1_A_Qms_Dp_sf_INPUT:
                case CalculationOptions.OPTIMIZATION1_A_Qmsus_Dp_sf_INPUT:
                case CalculationOptions.OPTIMIZATION1_A_Qsus_Dp_sf_INPUT:
                    {
                        variables.hc = FilterMachiningEquations.Eval_hc_From_Pc_kappa_Dp_sf_A_rhos_eps_etaf_Qms_hce(variables.Pc, variables.kappa, variables.Dp, variables.sf, variables.A, constants.rho_s, variables.eps, constants.eta_f, variables.Qms, constants.hce);
                        variables.tf = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(constants.eta_f, variables.hc, constants.hce, variables.Pc, variables.kappa, variables.Dp);
                        variables.tc = FilterMachiningEquations.Eval_tc_From_tf_sf(variables.tf, variables.sf);
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;

                case CalculationOptions.OPTIMIZATION1_A_Qms_Dp_tr_INPUT:
                case CalculationOptions.OPTIMIZATION1_A_Qmsus_Dp_tr_INPUT:
                case CalculationOptions.OPTIMIZATION1_A_Qsus_Dp_tr_INPUT:
                    {
                        variables.tf = FilterMachiningEquations.Eval_tf_From_Pc_kappa_Dp_A_rhos_eps_etaf_Qms_hce_tr(variables.Pc,
                            variables.kappa,
                            variables.Dp,
                            variables.A,
                            constants.rho_s,
                            variables.eps,
                            constants.eta_f,
                            variables.Qms,
                            constants.hce,
                            variables.tr);

                        variables.hc = FilterMachiningEquations.Eval_hc_From_hce_Pc_kappa_Dp_tf_etaf(constants.hce, variables.Pc, variables.kappa, variables.Dp, variables.tf, constants.eta_f);
                        variables.tc = FilterMachiningEquations.Eval_tc_From_tr_tf(variables.tr, variables.tf);
                        variables.sf = FilterMachiningEquations.Eval_sf_From_tf_tc(variables.tf, variables.tc);
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                    }
                    break;
                default:
                    throw new Exception("not processed calculation option");
            }

            variables.Vf = FilterMachiningEquations.Eval_Vf_From_A_hc_kappa(variables.A, variables.hc, variables.kappa);
            variables.Mf = FilterMachiningEquations.Eval_M_From_rho_V(constants.rho_f, variables.Vf);
            variables.Vsus = FilterMachiningEquations.Eval_Vsus_From_A_hc_kappa(variables.A, variables.hc, variables.kappa);
            variables.Msus = FilterMachiningEquations.Eval_M_From_rho_V(constants.rho_sus, variables.Vsus);
            variables.Ms = FilterMachiningEquations.Eval_Ms_From_Msus_Cm(variables.Msus, constants.Cm);
        }
        private void DoSubCalculationsStandart123()
        {
            variables.eps = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(constants.eps0, variables.Dp, constants.ne);
            variables.kappa = EpsKappaEquations.Eval_kappa_From_eps_Cv(variables.eps, constants.Cv);
            variables.Pc = FilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(constants.Pc0, variables.Dp, constants.nc);
            variables.rc = PcrcaEquations.Eval_rc_From_Pc(variables.Pc);
            variables.a = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(variables.Pc, variables.eps, constants.rho_s);

            switch (calculationOption)
            {
                case CalculationOptions.STANDART1_A_Dp_sf_n_INPUT:
                    {
                        variables.tc = FilterMachiningEquations.Eval_tc_From_n(variables.n);
                        variables.tf = FilterMachiningEquations.Eval_tf_From_sf_tc(variables.sf, variables.tc);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.STANDART1_A_Dp_tr_n_INPUT:
                    {
                        variables.tc = FilterMachiningEquations.Eval_tc_From_n(variables.n);
                        variables.tf = FilterMachiningEquations.Eval_tf_From_tc_tr(variables.tc, variables.tr);
                        variables.sf = FilterMachiningEquations.Eval_sf_From_tf_tc(variables.tf, variables.tc);

                    }
                    break;
                case CalculationOptions.STANDART1_A_Dp_sf_tc_INPUT:
                    {
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.tf = FilterMachiningEquations.Eval_tf_From_sf_tc(variables.sf, variables.tc);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.STANDART1_A_Dp_tr_tc_INPUT:
                    {
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.tf = FilterMachiningEquations.Eval_tf_From_tc_tr(variables.tc, variables.tr);
                        variables.sf = FilterMachiningEquations.Eval_sf_From_tf_tc(variables.tf, variables.tc);
                    }
                    break;
                case CalculationOptions.STANDART2_A_Dp_sf_tf_INPUT:
                    {
                        variables.tc = FilterMachiningEquations.Eval_tc_From_tf_sf(variables.tf, variables.sf);
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.STANDART2_A_Dp_tr_tf_INPUT:
                    {
                        variables.tc = FilterMachiningEquations.Eval_tc_From_tr_tf(variables.tr, variables.tf);
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.sf = FilterMachiningEquations.Eval_sf_From_tf_tc(variables.tf, variables.tc);
                    }
                    break;
                case CalculationOptions.STANDART3_A_Dp_n_tf_INPUT:
                    {
                        variables.tc = FilterMachiningEquations.Eval_tc_From_n(variables.n);
                        variables.sf = FilterMachiningEquations.Eval_sf_From_tf_tc(variables.tf, variables.tc);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.STANDART3_A_Dp_tc_tf_INPUT:
                    {
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.sf = FilterMachiningEquations.Eval_sf_From_tf_tc(variables.tf, variables.tc);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.STANDART3_A_Dp_tr_tf_INPUT:
                    {
                        variables.tc = FilterMachiningEquations.Eval_tc_From_tr_tf(variables.tr, variables.tf);
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.sf = FilterMachiningEquations.Eval_sf_From_tf_tc(variables.tf, variables.tc);
                    }
                    break;
                default:
                    throw new Exception("not processed calculation option");
            }

            variables.hc = FilterMachiningEquations.Eval_hc_From_hce_Pc_kappa_Dp_tf_etaf(
                            constants.hce,
                            variables.Pc,
                            variables.kappa,
                            variables.Dp,
                            variables.tf,
                            constants.eta_f);
            variables.Vf = FilterMachiningEquations.Eval_Vf_From_A_hc_kappa(variables.A, variables.hc, variables.kappa);
            variables.Mf = FilterMachiningEquations.Eval_M_From_rho_V(constants.rho_f, variables.Vf);
        }
        private void DoSubCalculationsStandart456()
        {
            switch (calculationOption)
            {
                case CalculationOptions.STANDART4_A_hc_sf_n_INPUT:
                case CalculationOptions.STANDART4_A_Vf_sf_n_INPUT:
                case CalculationOptions.STANDART4_A_Mf_sf_n_INPUT:
                    {
                        variables.tc = FilterMachiningEquations.Eval_tc_From_n(variables.n);
                        variables.tf = FilterMachiningEquations.Eval_tf_From_sf_tc(variables.sf, variables.tc);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.STANDART4_A_hc_tr_n_INPUT:
                case CalculationOptions.STANDART4_A_Vf_tr_n_INPUT:
                case CalculationOptions.STANDART4_A_Mf_tr_n_INPUT:
                    {
                        variables.tc = FilterMachiningEquations.Eval_tc_From_n(variables.n);
                        variables.tf = FilterMachiningEquations.Eval_tf_From_tc_tr(variables.tc, variables.tr);
                        variables.sf = FilterMachiningEquations.Eval_sf_From_tf_tc(variables.tf, variables.tc);
                    }
                    break;
                case CalculationOptions.STANDART4_A_hc_sf_tc_INPUT:
                case CalculationOptions.STANDART4_A_Vf_sf_tc_INPUT:
                case CalculationOptions.STANDART4_A_Mf_sf_tc_INPUT:
                    {
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.tf = FilterMachiningEquations.Eval_tf_From_sf_tc(variables.sf, variables.tc);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.STANDART4_A_hc_tr_tc_INPUT:
                case CalculationOptions.STANDART4_A_Vf_tr_tc_INPUT:
                case CalculationOptions.STANDART4_A_Mf_tr_tc_INPUT:
                    {
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.tf = FilterMachiningEquations.Eval_tf_From_tc_tr(variables.tc, variables.tr);
                        variables.sf = FilterMachiningEquations.Eval_sf_From_tf_tc(variables.tf, variables.tc);
                    }
                    break;
                default:
                    throw new Exception("not processed calculation option");
            }

            switch (calculationOption)
            {
                case CalculationOptions.STANDART4_A_hc_sf_n_INPUT:
                case CalculationOptions.STANDART4_A_hc_tr_n_INPUT:
                case CalculationOptions.STANDART4_A_hc_sf_tc_INPUT:
                case CalculationOptions.STANDART4_A_hc_tr_tc_INPUT:
                    variables.Dp = FilterMachiningEquations.Eval_Dp_From_etaf_Cv_Pc0_nc_eps0_ne_hc_hce_tf(constants.eta_f, constants.Cv, constants.Pc0, constants.nc, constants.eps0, constants.ne, variables.hc, constants.hce, variables.tf);
                    variables.eps = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(constants.eps0, variables.Dp, constants.ne);
                    variables.kappa = EpsKappaEquations.Eval_kappa_From_eps_Cv(variables.eps, constants.Cv);
                    variables.Vf = FilterMachiningEquations.Eval_Vf_From_A_hc_kappa(variables.A, variables.hc, variables.kappa);
                    variables.Mf = FilterMachiningEquations.Eval_M_From_rho_V(constants.rho_f, variables.Vf);
                    break;
                case CalculationOptions.STANDART4_A_Vf_tr_tc_INPUT:
                case CalculationOptions.STANDART4_A_Vf_sf_tc_INPUT:
                case CalculationOptions.STANDART4_A_Vf_tr_n_INPUT:
                case CalculationOptions.STANDART4_A_Vf_sf_n_INPUT:
                    variables.Mf = FilterMachiningEquations.Eval_M_From_rho_V(constants.rho_f, variables.Vf);
                    variables.Dp = FilterMachiningEquations.Eval_Dp_From_nc_ne_etaf_A_tf_Cv_eps0_Pc0_hce_Vf(constants.nc, constants.ne, constants.eta_f, variables.A, variables.tf, constants.Cv, constants.eps0, constants.Pc0, constants.hce, variables.Vf);
                    variables.eps = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(constants.eps0, variables.Dp, constants.ne);
                    variables.kappa = EpsKappaEquations.Eval_kappa_From_eps_Cv(variables.eps, constants.Cv);
                    variables.hc = FilterMachiningEquations.Eval_hc_From_A_Vf_kappa(variables.A, variables.Vf, variables.kappa);
                    break;
                case CalculationOptions.STANDART4_A_Mf_tr_tc_INPUT:
                case CalculationOptions.STANDART4_A_Mf_sf_tc_INPUT:
                case CalculationOptions.STANDART4_A_Mf_tr_n_INPUT:
                case CalculationOptions.STANDART4_A_Mf_sf_n_INPUT:
                    variables.Vf = FilterMachiningEquations.Eval_V_From_rho_M(constants.rho_f, variables.Mf);
                    variables.Dp = FilterMachiningEquations.Eval_Dp_From_nc_ne_etaf_A_tf_Cv_eps0_Pc0_hce_Vf(constants.nc, constants.ne, constants.eta_f, variables.A, variables.tf, constants.Cv, constants.eps0, constants.Pc0, constants.hce, variables.Vf);
                    variables.eps = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(constants.eps0, variables.Dp, constants.ne);
                    variables.kappa = EpsKappaEquations.Eval_kappa_From_eps_Cv(variables.eps, constants.Cv);
                    variables.hc = FilterMachiningEquations.Eval_hc_From_A_Vf_kappa(variables.A, variables.Vf, variables.kappa);
                    break;
                default:
                    throw new Exception("not processed calculation option");
            }

            variables.Pc = FilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(constants.Pc0, variables.Dp, constants.nc);
            variables.rc = PcrcaEquations.Eval_rc_From_Pc(variables.Pc);
            variables.a = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(variables.Pc, variables.eps, constants.rho_s);
        }
        private void DoSubCalculationsStandart78()
        {
            variables.eps = FilterMachiningEquations.Eval_eps_From_eps0_Dp_ne(constants.eps0, variables.Dp, constants.ne);
            variables.kappa = EpsKappaEquations.Eval_kappa_From_eps_Cv(variables.eps, constants.Cv);
            variables.Pc = FilterMachiningEquations.Eval_Pc_From_Pc0_Dp_nc(constants.Pc0, variables.Dp, constants.nc);
            variables.rc = PcrcaEquations.Eval_rc_From_Pc(variables.Pc);
            variables.a = PcrcaEquations.Eval_a_From_Pc_eps_rho_s(variables.Pc, variables.eps, constants.rho_s);

            switch (calculationOption)
            {
                case CalculationOptions.STANDART7_A_Dp_hc_sf_INPUT:
                case CalculationOptions.STANDART7_A_Dp_hc_tr_INPUT:
                case CalculationOptions.STANDART8_A_Dp_hc_n_INPUT:
                case CalculationOptions.STANDART8_A_Dp_hc_tc_INPUT:
                case CalculationOptions.STANDART8_A_Dp_hc_tr_INPUT:
                    variables.Vf = FilterMachiningEquations.Eval_Vf_From_A_hc_kappa(variables.A, variables.hc, variables.kappa);
                    variables.Mf = FilterMachiningEquations.Eval_M_From_rho_V(constants.rho_f, variables.Vf);
                    break;
                case CalculationOptions.STANDART7_A_Dp_Vf_sf_INPUT:
                case CalculationOptions.STANDART7_A_Dp_Vf_tr_INPUT:
                case CalculationOptions.STANDART8_A_Dp_Vf_n_INPUT:
                case CalculationOptions.STANDART8_A_Dp_Vf_tc_INPUT:
                case CalculationOptions.STANDART8_A_Dp_Vf_tr_INPUT:
                    variables.hc = FilterMachiningEquations.Eval_hc_From_A_Vf_kappa(variables.A, variables.Vf, variables.kappa);
                    variables.Mf = FilterMachiningEquations.Eval_M_From_rho_V(constants.rho_f, variables.Vf);
                    break;
                case CalculationOptions.STANDART7_A_Dp_Mf_sf_INPUT:
                case CalculationOptions.STANDART7_A_Dp_Mf_tr_INPUT:
                case CalculationOptions.STANDART8_A_Dp_Mf_n_INPUT:
                case CalculationOptions.STANDART8_A_Dp_Mf_tc_INPUT:
                case CalculationOptions.STANDART8_A_Dp_Mf_tr_INPUT:
                    variables.Vf = FilterMachiningEquations.Eval_V_From_rho_M(constants.rho_f, variables.Mf);
                    variables.hc = FilterMachiningEquations.Eval_hc_From_A_Vf_kappa(variables.A, variables.Vf, variables.kappa);
                    break;
                default:
                    throw new Exception("not processed calculation option");
            }

            switch (calculationOption)
            {
                case CalculationOptions.STANDART7_A_Dp_hc_sf_INPUT:
                case CalculationOptions.STANDART7_A_Dp_Vf_sf_INPUT:
                case CalculationOptions.STANDART7_A_Dp_Mf_sf_INPUT:
                    {
                        variables.tf = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(constants.eta_f, variables.hc, constants.hce, variables.Pc, variables.kappa, variables.Dp);
                        variables.tc = FilterMachiningEquations.Eval_tc_From_tf_sf(variables.tf, variables.sf);
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.STANDART7_A_Dp_hc_tr_INPUT:
                case CalculationOptions.STANDART7_A_Dp_Vf_tr_INPUT:
                case CalculationOptions.STANDART7_A_Dp_Mf_tr_INPUT:
                    {
                        variables.tf = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(constants.eta_f, variables.hc, constants.hce, variables.Pc, variables.kappa, variables.Dp);
                        variables.tc = FilterMachiningEquations.Eval_tc_From_tr_tf(variables.tr, variables.tf);
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.sf = FilterMachiningEquations.Eval_sf_From_tf_tc(variables.tf, variables.tc);
                    }
                    break;
                case CalculationOptions.STANDART8_A_Dp_hc_n_INPUT:
                case CalculationOptions.STANDART8_A_Dp_Vf_n_INPUT:
                case CalculationOptions.STANDART8_A_Dp_Mf_n_INPUT:
                    {
                        variables.tc = FilterMachiningEquations.Eval_tc_From_n(variables.n);
                        variables.tf = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(constants.eta_f, variables.hc, constants.hce, variables.Pc, variables.kappa, variables.Dp);
                        variables.sf = FilterMachiningEquations.Eval_sf_From_tf_tc(variables.tf, variables.tc);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.STANDART8_A_Dp_hc_tc_INPUT:
                case CalculationOptions.STANDART8_A_Dp_Vf_tc_INPUT:
                case CalculationOptions.STANDART8_A_Dp_Mf_tc_INPUT:
                    {
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.tf = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(constants.eta_f, variables.hc, constants.hce, variables.Pc, variables.kappa, variables.Dp);
                        variables.sf = FilterMachiningEquations.Eval_sf_From_tf_tc(variables.tf, variables.tc);
                        variables.tr = FilterMachiningEquations.Eval_tr_From_tc_tf(variables.tc, variables.tf);
                    }
                    break;
                case CalculationOptions.STANDART8_A_Dp_hc_tr_INPUT:
                case CalculationOptions.STANDART8_A_Dp_Vf_tr_INPUT:
                case CalculationOptions.STANDART8_A_Dp_Mf_tr_INPUT:
                    {
                        variables.tf = FilterMachiningEquations.Eval_tf_From_etaf_hc_hce_Pc_kappa_Dp(constants.eta_f, variables.hc, constants.hce, variables.Pc, variables.kappa, variables.Dp);
                        variables.tc = FilterMachiningEquations.Eval_tc_From_tr_tf(variables.tr, variables.tf);
                        variables.n = FilterMachiningEquations.Eval_n_From_tc(variables.tc);
                        variables.sf = FilterMachiningEquations.Eval_sf_From_tf_tc(variables.tf, variables.tc);
                    }
                    break;
                default:
                    throw new Exception("not processed calculation option");
            }
        }

        public fmFilterMachiningCalculator(CalculationOptions defaultCalculationOption)
        {
            calculationOption = defaultCalculationOption;
        }

        static public void Process(CalculationOptions calculationOption,
            ref fmValue A,
            ref fmValue Dp,
            ref fmValue sf,
            ref fmValue n,
            ref fmValue tc,
            ref fmValue tf,
            ref fmValue tr,
            ref fmValue hc,
            ref fmValue Qsus,
            ref fmValue Qmsus,
            ref fmValue Qms,
            ref fmValue Vsus,
            ref fmValue Mf,
            ref fmValue Vf,
            ref fmValue Ms,
            ref fmValue Msus,
            ref fmValue eps,
            ref fmValue kappa,
            ref fmValue Pc,
            ref fmValue rc,
            ref fmValue a,
            fmValue eps0,
            fmValue kappa0,
            fmValue Pc0,
            fmValue eta_f,
            fmValue rho_f,
            fmValue rho_s,
            fmValue rho_sus,
            fmValue Cv,
            fmValue Cm,
            fmValue ne,
            fmValue nc,
            fmValue hce)
        {
            fmFilterMachiningCalculator c = new fmFilterMachiningCalculator(calculationOption);

            c.variables.A = A;
            c.variables.Dp = Dp;
            c.variables.sf = sf;
            c.variables.n = n;
            c.variables.tc = tc;
            c.variables.tf = tf;
            c.variables.tr = tr;
            c.variables.hc = hc;
            c.variables.Qsus = Qsus;
            c.variables.Qmsus = Qmsus;
            c.variables.Qms = Qms;
            c.variables.Vsus = Vsus;
            c.variables.Mf = Mf;
            c.variables.Vf = Vf;
            c.variables.Ms = Ms;
            c.variables.Msus = Msus;
            c.variables.eps = eps;
            c.variables.kappa = kappa;
            c.variables.Pc = Pc;
            c.variables.rc = rc;
            c.variables.a = a;
            c.constants.eps0 = eps0;
            c.constants.kappa0 = kappa0;
            c.constants.Pc0 = Pc0;
            c.constants.eta_f = eta_f;
            c.constants.rho_f = rho_f;
            c.constants.rho_s = rho_s;
            c.constants.rho_sus = rho_sus;
            c.constants.Cv = Cv;
            c.constants.Cm = Cm;
            c.constants.ne = ne;
            c.constants.nc = nc;
            c.constants.hce = hce;

            c.DoCalculations();

            A = c.variables.A;
            Dp = c.variables.Dp;
            sf = c.variables.sf;
            n = c.variables.n;
            tc = c.variables.tc;
            tf = c.variables.tf;
            tr = c.variables.tr;
            hc = c.variables.hc;
            Qsus = c.variables.Qsus;
            Qmsus = c.variables.Qmsus;
            Qms = c.variables.Qms;
            Vsus = c.variables.Vsus;
            Mf = c.variables.Mf;
            Vf = c.variables.Vf;
            Ms = c.variables.Ms;
            Msus = c.variables.Msus;
            eps = c.variables.eps;
            kappa = c.variables.kappa;
            Pc = c.variables.Pc;
            rc = c.variables.rc;
            a = c.variables.a;
        }
    }
}
