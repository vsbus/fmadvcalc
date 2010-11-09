using System;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using System.Collections.Generic;
using System.Drawing;
using fmCalculatorsLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    static public class fmCalculationOptionHelper
    {
        public static List<fmGlobalParameter> GetParametersListThatCanBeInput(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption calculationOption)
        {
            var result = new List<fmGlobalParameter>();
            switch (calculationOption)
            {
                //[Description("3: A, Dp, (n/tc/tr), tf")]
                case fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART3:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    result.Add(fmGlobalParameter.tr);
                    result.Add(fmGlobalParameter.tf);
                    break;

                //[Description("4: A, (hc/Vf/Mf/Vsus/Msus/Ms), (sf/tr), (n/tc)")]
                case fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART4:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.Vf);
                    result.Add(fmGlobalParameter.Mf);
                    result.Add(fmGlobalParameter.Vsus);
                    result.Add(fmGlobalParameter.Msus);
                    result.Add(fmGlobalParameter.Ms);
                    result.Add(fmGlobalParameter.sf);
                    result.Add(fmGlobalParameter.tr);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    break;

                //[Description("8: A, Dp, (hc/Vf/Mf/Vsus/Msus/Ms), (n/tc/tr)")]
                case fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART8:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.Vf);
                    result.Add(fmGlobalParameter.Mf);
                    result.Add(fmGlobalParameter.Vsus);
                    result.Add(fmGlobalParameter.Msus);
                    result.Add(fmGlobalParameter.Ms);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    result.Add(fmGlobalParameter.tr);
                    break;

                //[Description("global: (A, Q), Dp, (sf, sr, tr), (hc, V, M, tf, n, tc)")]
                case fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART_AND_DESIGN_GLOBAL_DP_CONST:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Qmsus);
                    result.Add(fmGlobalParameter.Qsus);
                    result.Add(fmGlobalParameter.Qmf);
                    result.Add(fmGlobalParameter.Qf);
                    result.Add(fmGlobalParameter.Qms);
                    result.Add(fmGlobalParameter.Qs);
                    result.Add(fmGlobalParameter.Qmc);
                    result.Add(fmGlobalParameter.Qc);

                    result.Add(fmGlobalParameter.Dp);

                    result.Add(fmGlobalParameter.sf);
                    result.Add(fmGlobalParameter.sr);
                    result.Add(fmGlobalParameter.tr);

                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.vc);
                    result.Add(fmGlobalParameter.vf);
                    result.Add(fmGlobalParameter.vs);
                    result.Add(fmGlobalParameter.vsus);
                    result.Add(fmGlobalParameter.Vc);
                    result.Add(fmGlobalParameter.Vf);
                    result.Add(fmGlobalParameter.Vs);
                    result.Add(fmGlobalParameter.Vsus);
                    result.Add(fmGlobalParameter.mc);
                    result.Add(fmGlobalParameter.mf);
                    result.Add(fmGlobalParameter.ms);
                    result.Add(fmGlobalParameter.msus);
                    result.Add(fmGlobalParameter.Mc);
                    result.Add(fmGlobalParameter.Mf);
                    result.Add(fmGlobalParameter.Ms);
                    result.Add(fmGlobalParameter.Msus);
                    result.Add(fmGlobalParameter.tf);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    break;

                //[Description("global: (A, Q), Dp, (sf, sr, tr), (Qsus_d, hc, V, M, tf, n, tc)")]
                case fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART_AND_DESIGN_GLOBAL_QP_CONST:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Qmsus);
                    result.Add(fmGlobalParameter.Qsus);
                    result.Add(fmGlobalParameter.Qmf);
                    result.Add(fmGlobalParameter.Qf);
                    result.Add(fmGlobalParameter.Qms);
                    result.Add(fmGlobalParameter.Qs);
                    result.Add(fmGlobalParameter.Qmc);
                    result.Add(fmGlobalParameter.Qc);

                    result.Add(fmGlobalParameter.Dp);

                    result.Add(fmGlobalParameter.sf);
                    result.Add(fmGlobalParameter.sr);
                    result.Add(fmGlobalParameter.tr);

                    result.Add(fmGlobalParameter.Qsus_d);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.vc);
                    result.Add(fmGlobalParameter.vf);
                    result.Add(fmGlobalParameter.vs);
                    result.Add(fmGlobalParameter.vsus);
                    result.Add(fmGlobalParameter.Vc);
                    result.Add(fmGlobalParameter.Vf);
                    result.Add(fmGlobalParameter.Vs);
                    result.Add(fmGlobalParameter.Vsus);
                    result.Add(fmGlobalParameter.mc);
                    result.Add(fmGlobalParameter.mf);
                    result.Add(fmGlobalParameter.ms);
                    result.Add(fmGlobalParameter.msus);
                    result.Add(fmGlobalParameter.Mc);
                    result.Add(fmGlobalParameter.Mf);
                    result.Add(fmGlobalParameter.Ms);
                    result.Add(fmGlobalParameter.Msus);
                    result.Add(fmGlobalParameter.tf);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    break;

                //[Description("1: Q, Dp, hc, (n/tc/tr)")]
                case fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.DESIGN1:
                    result.Add(fmGlobalParameter.Qms);
                    result.Add(fmGlobalParameter.Qmsus);
                    result.Add(fmGlobalParameter.Qsus);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.hc);
                    result.Add(fmGlobalParameter.n);
                    result.Add(fmGlobalParameter.tc);
                    result.Add(fmGlobalParameter.tr);
                    break;

                //[Description("1: A, Q, Dp, (sf/tr)")]
                case fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.OPTIMIZATION1:
                    result.Add(fmGlobalParameter.A);
                    result.Add(fmGlobalParameter.Qms);
                    result.Add(fmGlobalParameter.Qmsus);
                    result.Add(fmGlobalParameter.Qsus);
                    result.Add(fmGlobalParameter.Dp);
                    result.Add(fmGlobalParameter.sf);
                    result.Add(fmGlobalParameter.tr);
                    break;
            }

            return result;
        }
    }

    public class fmFilterMachiningBlock : fmBaseBlock
    {
        // ReSharper disable InconsistentNaming
        private readonly fmBlockVariableParameter A;
        private readonly fmBlockVariableParameter Dp;
        private readonly fmBlockVariableParameter sf;
        private readonly fmBlockVariableParameter sr;
        private readonly fmBlockVariableParameter n;
        private readonly fmBlockVariableParameter tc;
        private readonly fmBlockVariableParameter tf;
        private readonly fmBlockVariableParameter tr;
        private readonly fmBlockVariableParameter hc;
        private readonly fmBlockVariableParameter hc_over_tf;
        private readonly fmBlockVariableParameter dhc_over_dt;
        private readonly fmBlockVariableParameter Mf;
        private readonly fmBlockVariableParameter Vf;
        private readonly fmBlockVariableParameter mf;
        private readonly fmBlockVariableParameter vf;
        private readonly fmBlockVariableParameter ms;
        private readonly fmBlockVariableParameter vs;
        private readonly fmBlockVariableParameter msus;
        private readonly fmBlockVariableParameter vsus;
        private readonly fmBlockVariableParameter mc;
        private readonly fmBlockVariableParameter vc;
        private readonly fmBlockVariableParameter Msus;
        private readonly fmBlockVariableParameter Vsus;
        private readonly fmBlockVariableParameter Vc;
        private readonly fmBlockVariableParameter Mc;
        private readonly fmBlockVariableParameter Ms;
        private readonly fmBlockVariableParameter Vs;
        private readonly fmBlockVariableParameter Qf;
        private readonly fmBlockVariableParameter Qf_d;
        private readonly fmBlockVariableParameter Qs;
        private readonly fmBlockVariableParameter Qs_d;
        private readonly fmBlockVariableParameter Qc;
        private readonly fmBlockVariableParameter Qc_d;
        private readonly fmBlockVariableParameter Qsus;
        private readonly fmBlockVariableParameter Qsus_d;
        private readonly fmBlockVariableParameter Qmsus;
        private readonly fmBlockVariableParameter Qmsus_d;
        private readonly fmBlockVariableParameter Qms;
        private readonly fmBlockVariableParameter Qms_d;
        private readonly fmBlockVariableParameter Qmf;
        private readonly fmBlockVariableParameter Qmf_d;
        private readonly fmBlockVariableParameter Qmc;
        private readonly fmBlockVariableParameter Qmc_d;
        private readonly fmBlockVariableParameter qf;
        private readonly fmBlockVariableParameter qf_d;
        private readonly fmBlockVariableParameter qs;
        private readonly fmBlockVariableParameter qs_d;
        private readonly fmBlockVariableParameter qc;
        private readonly fmBlockVariableParameter qc_d;
        private readonly fmBlockVariableParameter qsus;
        private readonly fmBlockVariableParameter qsus_d;
        private readonly fmBlockVariableParameter qmsus;
        private readonly fmBlockVariableParameter qmsus_d;
        private readonly fmBlockVariableParameter qms;
        private readonly fmBlockVariableParameter qms_d;
        private readonly fmBlockVariableParameter qmf;
        private readonly fmBlockVariableParameter qmf_d;
        private readonly fmBlockVariableParameter qmc;
        private readonly fmBlockVariableParameter qmc_d;
        private readonly fmBlockVariableParameter eps;
        private readonly fmBlockVariableParameter kappa;
        private readonly fmBlockVariableParameter Pc;
        private readonly fmBlockVariableParameter rc;
        private readonly fmBlockVariableParameter a;
        // ReSharper restore InconsistentNaming

        /*
         * 220 200 230
         * 240 230 180
         * 180 230 230
         * 240 180 230
         * 180 240 150
         *  
         * 190 200 240
         * 250 230 150
         * 230 240 190
         * 250 240 190
         * 190 240 240
         * 
         * 160 250 250
         * 210 190 240
         * 220 240 170
         * 240 200 190
         * 250 220 150
         *
         * 259 210 130
         * 150 250 180
         */

        // ReSharper disable InconsistentNaming
        private readonly fmBlockParameterGroup A_group = new fmBlockParameterGroup(Color.FromArgb(150, 250, 180));
        private readonly fmBlockParameterGroup Dp_group = new fmBlockParameterGroup(Color.FromArgb(250, 210, 150));
        private readonly fmBlockParameterGroup sf_tr_group = new fmBlockParameterGroup(Color.FromArgb(190, 200, 150));
        private readonly fmBlockParameterGroup sf_sr_tr_group = new fmBlockParameterGroup(Color.FromArgb(190, 200, 150));
        private readonly fmBlockParameterGroup n_tc_group = new fmBlockParameterGroup(Color.FromArgb(250, 230, 150));
        private readonly fmBlockParameterGroup n_tc_tr_group = new fmBlockParameterGroup(Color.FromArgb(230, 240, 190));
        private readonly fmBlockParameterGroup tf_group = new fmBlockParameterGroup(Color.FromArgb(180, 230, 230));
        private readonly fmBlockParameterGroup hc_MV_group = new fmBlockParameterGroup(Color.FromArgb(250, 190, 220));
        private readonly fmBlockParameterGroup hc_group = new fmBlockParameterGroup(Color.FromArgb(250, 190, 220));
        private readonly fmBlockParameterGroup Q_group = new fmBlockParameterGroup(Color.FromArgb(190, 240, 240));
        private readonly fmBlockParameterGroup AQ_group = new fmBlockParameterGroup(Color.FromArgb(170, 245, 210));

        private readonly fmBlockConstantParameter hce;

        private readonly fmBlockConstantParameter Pc0;
        private readonly fmBlockConstantParameter nc;

        private readonly fmBlockConstantParameter eps0;
        private readonly fmBlockConstantParameter kappa0;
        private readonly fmBlockConstantParameter ne;

        private readonly fmBlockConstantParameter etaf;
        private readonly fmBlockConstantParameter rho_f;
        private readonly fmBlockConstantParameter rho_s;
        private readonly fmBlockConstantParameter rho_sus;
        private readonly fmBlockConstantParameter Cm;
        private readonly fmBlockConstantParameter Cv;
        // ReSharper restore InconsistentNaming

        public fmFilterMachiningCalculator.fmFilterMachiningCalculationOption calculationOption;

        #region accessors
        // ReSharper disable InconsistentNaming
        public fmValue A_Value
        {
            get { return A.value; }
            set { A.value = value; }
        }
        public fmValue Dp_Value
        {
            get { return Dp.value; }
            set { Dp.value = value; }
        }
        public fmValue sf_Value
        {
            get { return sf.value; }
            set { sf.value = value; }
        }
        public fmValue n_Value
        {
            get { return n.value; }
            set { n.value = value; }
        }
        public fmValue tc_Value
        {
            get { return tc.value; }
            set { tc.value = value; }
        }
        public fmValue tf_Value
        {
            get { return tf.value; }
            set { tf.value = value; }
        }
        public fmValue tr_Value
        {
            get { return tr.value; }
            set { tr.value = value; }
        }
        public fmValue hc_Value
        {
            get { return hc.value; }
            set { hc.value = value; }
        }
        public fmValue hc_over_tf_Value
        {
            get { return hc_over_tf.value; }
            set { hc_over_tf.value = value; }
        }
        public fmValue dhc_over_dt_Value
        {
            get { return dhc_over_dt.value; }
            set { dhc_over_dt.value = value; }
        }
        public fmValue Mf_Value
        {
            get { return Mf.value; }
            set { Mf.value = value; }
        }
        public fmValue Vf_Value
        {
            get { return Vf.value; }
            set { Vf.value = value; }
        }
        public fmValue mf_Value
        {
            get { return mf.value; }
            set { mf.value = value; }
        }
        public fmValue vf_Value
        {
            get { return vf.value; }
            set { vf.value = value; }
        }
        public fmValue ms_Value
        {
            get { return ms.value; }
            set { ms.value = value; }
        }
        public fmValue vs_Value
        {
            get { return vs.value; }
            set { vs.value = value; }
        }
        public fmValue msus_Value
        {
            get { return msus.value; }
            set { msus.value = value; }
        }
        public fmValue vsus_Value
        {
            get { return vsus.value; }
            set { vsus.value = value; }
        }
        public fmValue mc_Value
        {
            get { return mc.value; }
            set { mc.value = value; }
        }
        public fmValue vc_Value
        {
            get { return vc.value; }
            set { vc.value = value; }
        }
        public fmValue Msus_Value
        {
            get { return Msus.value; }
            set { Msus.value = value; }
        }
        public fmValue Vsus_Value
        {
            get { return Vsus.value; }
            set { Vsus.value = value; }
        }
        public fmValue Vc_Value
        {
            get { return Vc.value; }
            set { Vc.value = value; }
        }
        public fmValue Mc_Value
        {
            get { return Mc.value; }
            set { Mc.value = value; }
        }
        public fmValue Ms_Value
        {
            get { return Ms.value; }
            set { Ms.value = value; }
        }
        public fmValue Vs_Value
        {
            get { return Vs.value; }
            set { Vs.value = value; }
        }
        public fmValue Qf_Value
        {
            get { return Qf.value; }
            set { Qf.value = value; }
        }
        public fmValue Qf_d_Value
        {
            get { return Qf_d.value; }
            set { Qf_d.value = value; }
        }
        public fmValue Qs_Value
        {
            get { return Qs.value; }
            set { Qs.value = value; }
        }
        public fmValue Qs_d_Value
        {
            get { return Qs_d.value; }
            set { Qs_d.value = value; }
        }
        public fmValue Qc_Value
        {
            get { return Qc.value; }
            set { Qc.value = value; }
        }
        public fmValue Qc_d_Value
        {
            get { return Qc_d.value; }
            set { Qc_d.value = value; }
        }
        public fmValue Qsus_Value
        {
            get { return Qsus.value; }
            set { Qsus.value = value; }
        }
        public fmValue Qsus_d_Value
        {
            get { return Qsus_d.value; }
            set { Qsus_d.value = value; }
        }
        public fmValue Qmsus_Value
        {
            get { return Qmsus.value; }
            set { Qmsus.value = value; }
        }
        public fmValue Qmsus_d_Value
        {
            get { return Qmsus_d.value; }
            set { Qmsus_d.value = value; }
        }
        public fmValue Qms_Value
        {
            get { return Qms.value; }
            set { Qms.value = value; }
        }
        public fmValue Qms_d_Value
        {
            get { return Qms_d.value; }
            set { Qms_d.value = value; }
        }
        public fmValue Qmf_Value
        {
            get { return Qmf.value; }
            set { Qmf.value = value; }
        }
        public fmValue Qmf_d_Value
        {
            get { return Qmf_d.value; }
            set { Qmf_d.value = value; }
        }
        public fmValue Qmc_Value
        {
            get { return Qmc.value; }
            set { Qmc.value = value; }
        }
        public fmValue Qmc_d_Value
        {
            get { return Qmc_d.value; }
            set { Qmc_d.value = value; }
        }
        public fmValue qf_Value
        {
            get { return qf.value; }
            set { qf.value = value; }
        }
        public fmValue qf_d_Value
        {
            get { return qf_d.value; }
            set { qf_d.value = value; }
        }
        public fmValue qs_Value
        {
            get { return qs.value; }
            set { qs.value = value; }
        }
        public fmValue qs_d_Value
        {
            get { return qs_d.value; }
            set { qs_d.value = value; }
        }
        public fmValue qc_Value
        {
            get { return qc.value; }
            set { qc.value = value; }
        }
        public fmValue qc_d_Value
        {
            get { return qc_d.value; }
            set { qc_d.value = value; }
        }
        public fmValue qsus_Value
        {
            get { return qsus.value; }
            set { qsus.value = value; }
        }
        public fmValue qsus_d_Value
        {
            get { return qsus_d.value; }
            set { qsus_d.value = value; }
        }
        public fmValue qmsus_Value
        {
            get { return qmsus.value; }
            set { qmsus.value = value; }
        }
        public fmValue qmsus_d_Value
        {
            get { return qmsus_d.value; }
            set { qmsus_d.value = value; }
        }
        public fmValue qms_Value
        {
            get { return qms.value; }
            set { qms.value = value; }
        }
        public fmValue qms_d_Value
        {
            get { return qms_d.value; }
            set { qms_d.value = value; }
        }
        public fmValue qmf_Value
        {
            get { return qmf.value; }
            set { qmf.value = value; }
        }
        public fmValue qmf_d_Value
        {
            get { return qmf_d.value; }
            set { qmf_d.value = value; }
        }
        public fmValue qmc_Value
        {
            get { return qmc.value; }
            set { qmc.value = value; }
        }
        public fmValue qmc_d_Value
        {
            get { return qmc_d.value; }
            set { qmc_d.value = value; }
        }
        public fmValue hce_Value
        {
            get { return hce.value; }
            set { hce.value = value; }
        }
        public fmValue Pc0_Value
        {
            get { return Pc0.value; }
            set { Pc0.value = value; }
        }
        public fmValue eps0_Value
        {
            get { return eps0.value; }
            set { eps0.value = value; }
        }
        public fmValue nc_Value
        {
            get { return nc.value; }
            set { nc.value = value; }
        }
        public fmValue ne_Value
        {
            get { return ne.value; }
            set { ne.value = value; }
        }
        public fmValue kappa0_Value
        {
            get { return kappa0.value; }
            set { kappa0.value = value; }
        }
        public fmValue etaf_Value
        {
            get { return etaf.value; }
            set { etaf.value = value; }
        }
        public fmValue rho_f_Value
        {
            get { return rho_f.value; }
            set { rho_f.value = value; }
        }
        public fmValue rho_s_Value
        {
            get { return rho_s.value; }
            set { rho_s.value = value; }
        }
        public fmValue rho_sus_Value
        {
            get { return rho_sus.value; }
            set { rho_sus.value = value; }
        }
        public fmValue Cm_Value
        {
            get { return Cm.value; }
            set { Cm.value = value; }
        }
        public fmValue Cv_Value
        {
            get { return Cv.value; }
            set { Cv.value = value; }
        }
        // ReSharper restore InconsistentNaming
        #endregion

        override public void DoCalculations()
        {
            var filterMachinigCalculator =
                new fmFilterMachiningCalculator(AllParameters) { calculationOption = calculationOption };
            filterMachinigCalculator.DoCalculations();
        }

        public List<fmBlockVariableParameter> GetParametersByGroup(fmBlockParameterGroup group)
        {
            var result = new List<fmBlockVariableParameter>();
            if (group != null)
            {
                foreach (fmBlockVariableParameter p in parameters)
                {
                    if (p.group != null && p.group == group)
                        result.Add(p);
                }
            }
            return result;
        }

        public void UpdateCellsBackColor()
        {
            foreach (fmBlockVariableParameter p in parameters)
            {
                if (p.cell != null)
                {
                    Color color = p.group == null
                                     ? Color.White
                                     : p.group.color;
                    p.cell.Style.BackColor = color;
                }
            }
        }

        public fmFilterMachiningBlock()
            : this(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null)
        {
        }

        public fmFilterMachiningBlock(
            // ReSharper disable InconsistentNaming
            DataGridViewCell A_Cell,
            DataGridViewCell Dp_Cell,
            DataGridViewCell sf_Cell,
            DataGridViewCell sr_Cell,
            DataGridViewCell n_Cell,
            DataGridViewCell tc_Cell,
            DataGridViewCell tf_Cell,
            DataGridViewCell tr_Cell,
            DataGridViewCell hc_over_tf_Cell,
            DataGridViewCell dhc_over_dt_Cell,
            DataGridViewCell hc_Cell,
            DataGridViewCell Mf_Cell,
            DataGridViewCell Vf_Cell,
            DataGridViewCell mf_Cell,
            DataGridViewCell vf_Cell,
            DataGridViewCell ms_Cell,
            DataGridViewCell vs_Cell,
            DataGridViewCell msus_Cell,
            DataGridViewCell vsus_Cell,
            DataGridViewCell mc_Cell,
            DataGridViewCell vc_Cell,
            DataGridViewCell Msus_Cell,
            DataGridViewCell Vsus_Cell,
            DataGridViewCell Vc_Cell,
            DataGridViewCell Mc_Cell,
            DataGridViewCell Ms_Cell,
            DataGridViewCell Vs_Cell,
            DataGridViewCell Qf_Cell,
            DataGridViewCell Qf_d_Cell,
            DataGridViewCell Qs_Cell,
            DataGridViewCell Qs_d_Cell,
            DataGridViewCell Qc_Cell,
            DataGridViewCell Qc_d_Cell,
            DataGridViewCell Qsus_Cell,
            DataGridViewCell Qsus_d_Cell,
            DataGridViewCell Qmsus_Cell,
            DataGridViewCell Qmsus_d_Cell,
            DataGridViewCell Qms_Cell,
            DataGridViewCell Qms_d_Cell,
            DataGridViewCell Qmf_Cell,
            DataGridViewCell Qmf_d_Cell,
            DataGridViewCell Qmc_Cell,
            DataGridViewCell Qmc_d_Cell,
            DataGridViewCell qf_Cell,
            DataGridViewCell qf_d_Cell,
            DataGridViewCell qs_Cell,
            DataGridViewCell qs_d_Cell,
            DataGridViewCell qc_Cell,
            DataGridViewCell qc_d_Cell,
            DataGridViewCell qsus_Cell,
            DataGridViewCell qsus_d_Cell,
            DataGridViewCell qmsus_Cell,
            DataGridViewCell qmsus_d_Cell,
            DataGridViewCell qms_Cell,
            DataGridViewCell qms_d_Cell,
            DataGridViewCell qmf_Cell,
            DataGridViewCell qmf_d_Cell,
            DataGridViewCell qmc_Cell,
            DataGridViewCell qmc_d_Cell,
            DataGridViewCell eps_Cell,
            DataGridViewCell kappa_Cell,
            DataGridViewCell Pc_Cell,
            DataGridViewCell rc_Cell,
            DataGridViewCell a_Cell)
        // ReSharper restore InconsistentNaming
        {
            AddParameter(ref A, fmGlobalParameter.A, A_Cell, true);

            AddParameter(ref Dp, fmGlobalParameter.Dp, Dp_Cell, true);

            AddParameter(ref n, fmGlobalParameter.n, n_Cell, true);
            AddParameter(ref tc, fmGlobalParameter.tc, tc_Cell, false);

            AddParameter(ref tr, fmGlobalParameter.tr, tr_Cell, false);
            AddParameter(ref sf, fmGlobalParameter.sf, sf_Cell, true);
            AddParameter(ref sr, fmGlobalParameter.sr, sr_Cell, true);

            AddParameter(ref hc, fmGlobalParameter.hc, hc_Cell, false);
            AddParameter(ref tf, fmGlobalParameter.tf, tf_Cell, false);

            AddParameter(ref Msus, fmGlobalParameter.Msus, Msus_Cell, false);
            AddParameter(ref Vsus, fmGlobalParameter.Vsus, Vsus_Cell, false);
            AddParameter(ref Mf, fmGlobalParameter.Mf, Mf_Cell, false);
            AddParameter(ref Vf, fmGlobalParameter.Vf, Vf_Cell, false);
            AddParameter(ref Ms, fmGlobalParameter.Ms, Ms_Cell, false);
            AddParameter(ref Vs, fmGlobalParameter.Vs, Vs_Cell, false);
            AddParameter(ref Mc, fmGlobalParameter.Mc, Mc_Cell, false);
            AddParameter(ref Vc, fmGlobalParameter.Vc, Vc_Cell, false);

            AddParameter(ref msus, fmGlobalParameter.msus, msus_Cell, false);
            AddParameter(ref vsus, fmGlobalParameter.vsus, vsus_Cell, false);
            AddParameter(ref mf, fmGlobalParameter.mf, mf_Cell, false);
            AddParameter(ref vf, fmGlobalParameter.vf, vf_Cell, false);
            AddParameter(ref ms, fmGlobalParameter.ms, ms_Cell, false);
            AddParameter(ref vs, fmGlobalParameter.vs, vs_Cell, false);
            AddParameter(ref mc, fmGlobalParameter.mc, mc_Cell, false);
            AddParameter(ref vc, fmGlobalParameter.vc, vc_Cell, false);

            AddParameter(ref Qmsus, fmGlobalParameter.Qmsus, Qmsus_Cell, false);
            AddParameter(ref Qsus, fmGlobalParameter.Qsus, Qsus_Cell, false);
            AddParameter(ref Qmf, fmGlobalParameter.Qmf, Qmf_Cell, false);
            AddParameter(ref Qf, fmGlobalParameter.Qf, Qf_Cell, false);
            AddParameter(ref Qms, fmGlobalParameter.Qms, Qms_Cell, false);
            AddParameter(ref Qs, fmGlobalParameter.Qs, Qs_Cell, false);
            AddParameter(ref Qmc, fmGlobalParameter.Qmc, Qmc_Cell, false);
            AddParameter(ref Qc, fmGlobalParameter.Qc, Qc_Cell, false);

            AddParameter(ref qmsus, fmGlobalParameter.qmsus, qmsus_Cell, false);
            AddParameter(ref qsus, fmGlobalParameter.qsus, qsus_Cell, false);
            AddParameter(ref qmf, fmGlobalParameter.qmf, qmf_Cell, false);
            AddParameter(ref qf, fmGlobalParameter.qf, qf_Cell, false);
            AddParameter(ref qms, fmGlobalParameter.qms, qms_Cell, false);
            AddParameter(ref qs, fmGlobalParameter.qs, qs_Cell, false);
            AddParameter(ref qmc, fmGlobalParameter.qmc, qmc_Cell, false);
            AddParameter(ref qc, fmGlobalParameter.qc, qc_Cell, false);

            AddParameter(ref Qmsus_d, fmGlobalParameter.Qmsus_d, Qmsus_d_Cell, false);
            AddParameter(ref Qsus_d, fmGlobalParameter.Qsus_d, Qsus_d_Cell, false);
            AddParameter(ref Qmf_d, fmGlobalParameter.Qmf_d, Qmf_d_Cell, false);
            AddParameter(ref Qf_d, fmGlobalParameter.Qf_d, Qf_d_Cell, false);
            AddParameter(ref Qms_d, fmGlobalParameter.Qms_d, Qms_d_Cell, false);
            AddParameter(ref Qs_d, fmGlobalParameter.Qs_d, Qs_d_Cell, false);
            AddParameter(ref Qmc_d, fmGlobalParameter.Qmc_d, Qmc_d_Cell, false);
            AddParameter(ref Qc_d, fmGlobalParameter.Qc_d, Qc_d_Cell, false);

            AddParameter(ref qmsus_d, fmGlobalParameter.qmsus_d, qmsus_d_Cell, false);
            AddParameter(ref qsus_d, fmGlobalParameter.qsus_d, qsus_d_Cell, false);
            AddParameter(ref qmf_d, fmGlobalParameter.qmf_d, qmf_d_Cell, false);
            AddParameter(ref qf_d, fmGlobalParameter.qf_d, qf_d_Cell, false);
            AddParameter(ref qms_d, fmGlobalParameter.qms_d, qms_d_Cell, false);
            AddParameter(ref qs_d, fmGlobalParameter.qs_d, qs_d_Cell, false);
            AddParameter(ref qmc_d, fmGlobalParameter.qmc_d, qmc_d_Cell, false);
            AddParameter(ref qc_d, fmGlobalParameter.qc_d, qc_d_Cell, false);

            AddParameter(ref hc_over_tf, fmGlobalParameter.hc_over_tf, hc_over_tf_Cell, false);
            AddParameter(ref dhc_over_dt, fmGlobalParameter.dhc_over_dt, dhc_over_dt_Cell, false);

            AddParameter(ref eps, fmGlobalParameter.eps, eps_Cell, false);
            AddParameter(ref kappa, fmGlobalParameter.kappa, kappa_Cell, false);
            AddParameter(ref Pc, fmGlobalParameter.Pc, Pc_Cell, false);
            AddParameter(ref rc, fmGlobalParameter.rc, rc_Cell, false);
            AddParameter(ref a, fmGlobalParameter.a, a_Cell, false);

            AddConstantParameter(ref hce, fmGlobalParameter.hce0);
            AddConstantParameter(ref Pc0, fmGlobalParameter.Pc0);
            AddConstantParameter(ref nc, fmGlobalParameter.nc);
            AddConstantParameter(ref eps0, fmGlobalParameter.eps0);
            AddConstantParameter(ref kappa0, fmGlobalParameter.kappa0);
            AddConstantParameter(ref ne, fmGlobalParameter.ne);
            AddConstantParameter(ref etaf, fmGlobalParameter.eta_f);
            AddConstantParameter(ref rho_f, fmGlobalParameter.rho_f);
            AddConstantParameter(ref rho_s, fmGlobalParameter.rho_s);
            AddConstantParameter(ref rho_sus, fmGlobalParameter.rho_sus);
            AddConstantParameter(ref Cm, fmGlobalParameter.Cm);
            AddConstantParameter(ref Cv, fmGlobalParameter.Cv);

            SetCalculationOptionAndUpdateCellsStyle(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART_AND_DESIGN_GLOBAL_DP_CONST);

            processOnChange = true;
        }

        public void SetCalculationOptionAndUpdateCellsStyle(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption newCalculationOption)
        {
            calculationOption = newCalculationOption;
            UpdateGroups();
            List<fmGlobalParameter> inputedParameters = fmCalculationOptionHelper.GetParametersListThatCanBeInput(newCalculationOption);
            var groupUsed = new Dictionary<fmBlockParameterGroup, bool>();

            foreach (fmBlockVariableParameter parameter in parameters)
                if (parameter.group != null)
                    groupUsed[parameter.group] = false;

            foreach (fmBlockVariableParameter parameter in parameters)
            {
                bool found = inputedParameters.Contains(parameter.globalParameter);
                bool notUsedGroup = parameter.group == null ? true : !groupUsed[parameter.group];

                parameter.IsInputed = found && notUsedGroup;

                if (parameter.group != null)
                    groupUsed[parameter.group] = true;

                if (parameter.cell != null)
                    parameter.cell.ReadOnly = !found;
            }

            UpdateCellsBackColor();
            ReWriteParameters();
        }

        Dictionary<fmFilterMachiningCalculator.fmFilterMachiningCalculationOption, Dictionary<fmBlockVariableParameter, fmBlockParameterGroup>> m_tables;

        fmBlockParameterGroup WhatGroupOfParameterWithCalcOption(fmBlockVariableParameter parameter, fmFilterMachiningCalculator.fmFilterMachiningCalculationOption calcOption)
        {
            if (m_tables == null)
            {
                m_tables = new Dictionary<fmFilterMachiningCalculator.fmFilterMachiningCalculationOption, Dictionary<fmBlockVariableParameter, fmBlockParameterGroup>>();

                foreach (fmFilterMachiningCalculator.fmFilterMachiningCalculationOption option in Enum.GetValues(typeof(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption)))
                {
                    m_tables[option] = new Dictionary<fmBlockVariableParameter, fmBlockParameterGroup>();
                }

                SetGroupsOfStandart3(m_tables[fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART3]);
                SetGroupsOfStandart4(m_tables[fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART4]);
                SetGroupsOfStandart8(m_tables[fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART8]);

                SetGroupsOfDesign1(m_tables[fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.DESIGN1]);
                SetGroupsOfStandartAndDesignGlobalDpConst(m_tables[fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART_AND_DESIGN_GLOBAL_DP_CONST]);
                SetGroupsOfStandartQpConst(m_tables[fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART_AND_DESIGN_GLOBAL_QP_CONST]);

                SetGroupsOfOptimization1(m_tables[fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.OPTIMIZATION1]);
            }

            return m_tables[calcOption][parameter];
        }

        private void SetGroupsOfStandartAndDesignGlobalDpConst(Dictionary<fmBlockVariableParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockVariableParameter p in parameters)
                table[p] = null;

            //[Description("global: (A, Q), Dp, (sf, tr), (hc, V, M, tf, n, tc)")]
            table[A] = AQ_group;
            table[Qmsus] = AQ_group;
            table[Qsus] = AQ_group;
            table[Qmf] = AQ_group;
            table[Qf] = AQ_group;
            table[Qms] = AQ_group;
            table[Qs] = AQ_group;
            table[Qmc] = AQ_group;
            table[Qc] = AQ_group;

            table[Dp] = Dp_group;

            table[sf] = sf_sr_tr_group;
            table[sr] = sf_sr_tr_group;
            table[tr] = sf_sr_tr_group;

            table[hc] = hc_MV_group;
            table[vc] = hc_MV_group;
            table[vf] = hc_MV_group;
            table[vs] = hc_MV_group;
            table[vsus] = hc_MV_group;
            table[Vc] = hc_MV_group;
            table[Vf] = hc_MV_group;
            table[Vs] = hc_MV_group;
            table[Vsus] = hc_MV_group;
            table[mc] = hc_MV_group;
            table[mf] = hc_MV_group;
            table[ms] = hc_MV_group;
            table[msus] = hc_MV_group;
            table[Mc] = hc_MV_group;
            table[Mf] = hc_MV_group;
            table[Ms] = hc_MV_group;
            table[Msus] = hc_MV_group;
            table[tf] = hc_MV_group;
            table[n] = hc_MV_group;
            table[tc] = hc_MV_group;
        }

        private void SetGroupsOfStandartQpConst(Dictionary<fmBlockVariableParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockVariableParameter p in parameters)
                table[p] = null;

            //[Description("global: (A, Q), Dp, (sf, tr), (Qsus_d, hc, V, M, tf, n, tc)")]
            table[A] = AQ_group;
            table[Qmsus] = AQ_group;
            table[Qsus] = AQ_group;
            table[Qmf] = AQ_group;
            table[Qf] = AQ_group;
            table[Qms] = AQ_group;
            table[Qs] = AQ_group;
            table[Qmc] = AQ_group;
            table[Qc] = AQ_group;
            table[Qsus_d] = AQ_group;
            
            table[Dp] = Dp_group;

            table[sf] = sf_sr_tr_group;
            table[sr] = sf_sr_tr_group;
            table[tr] = sf_sr_tr_group;

            table[hc] = hc_MV_group;
            table[vc] = hc_MV_group;
            table[vf] = hc_MV_group;
            table[vs] = hc_MV_group;
            table[vsus] = hc_MV_group;
            table[Vc] = hc_MV_group;
            table[Vf] = hc_MV_group;
            table[Vs] = hc_MV_group;
            table[Vsus] = hc_MV_group;
            table[mc] = hc_MV_group;
            table[mf] = hc_MV_group;
            table[ms] = hc_MV_group;
            table[msus] = hc_MV_group;
            table[Mc] = hc_MV_group;
            table[Mf] = hc_MV_group;
            table[Ms] = hc_MV_group;
            table[Msus] = hc_MV_group;
            table[tf] = hc_MV_group;
            table[n] = hc_MV_group;
            table[tc] = hc_MV_group;
        }
        private void SetGroupsOfOptimization1(Dictionary<fmBlockVariableParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockVariableParameter p in parameters)
                table[p] = null;

            //[Description("1: A, Q, Dp, (sf/tr)")]
            table[A] = A_group;
            table[Qms] = Q_group;
            table[Qmsus] = Q_group;
            table[Qsus] = Q_group;
            table[Dp] = Dp_group;
            table[sf] = sf_tr_group;
            table[tr] = sf_tr_group;
        }

        private void SetGroupsOfDesign1(Dictionary<fmBlockVariableParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockVariableParameter p in parameters)
                table[p] = null;

            //[Description("1: Q, Dp, hc, (n/tc/tr)")]
            table[Qms] = Q_group;
            table[Qmsus] = Q_group;
            table[Qsus] = Q_group;
            table[Dp] = Dp_group;
            table[hc] = hc_group;
            table[n] = n_tc_tr_group;
            table[tc] = n_tc_tr_group;
            table[tr] = n_tc_tr_group;
        }

        private void SetGroupsOfStandart8(Dictionary<fmBlockVariableParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockVariableParameter p in parameters)
                table[p] = null;

            //[Description("8: A, Dp, (hc/Vf/Mf/Vsus/Msus/Ms), (n/tc/tr)")]
            table[A] = A_group;
            table[Dp] = Dp_group;
            table[hc] = hc_MV_group;
            table[Vf] = hc_MV_group;
            table[Mf] = hc_MV_group;
            table[Vsus] = hc_MV_group;
            table[Msus] = hc_MV_group;
            table[Ms] = hc_MV_group;
            table[n] = n_tc_tr_group;
            table[tc] = n_tc_tr_group;
            table[tr] = n_tc_tr_group;
        }

        private void SetGroupsOfStandart4(Dictionary<fmBlockVariableParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockVariableParameter p in parameters)
                table[p] = null;

            //[Description("4: A, (hc/Vf/Mf/Vsus/Msus/Ms), (sf/tr), (n/tc)")]
            table[A] = A_group;
            table[hc] = hc_MV_group;
            table[Vf] = hc_MV_group;
            table[Mf] = hc_MV_group;
            table[Vsus] = hc_MV_group;
            table[Msus] = hc_MV_group;
            table[Ms] = hc_MV_group;
            table[sf] = sf_tr_group;
            table[tr] = sf_tr_group;
            table[n] = n_tc_group;
            table[tc] = n_tc_group;
        }

        private void SetGroupsOfStandart3(Dictionary<fmBlockVariableParameter, fmBlockParameterGroup> table)
        {
            foreach (fmBlockVariableParameter p in parameters)
                table[p] = null;

            //[Description("3: A, Dp, (n/tc/tr), tf")]
            table[A] = A_group;
            table[Dp] = Dp_group;
            table[n] = n_tc_tr_group;
            table[tc] = n_tc_tr_group;
            table[tr] = n_tc_tr_group;
            table[tf] = tf_group;
        }

        public void UpdateGroups()
        {
            foreach (fmBlockVariableParameter p in parameters)
                p.group = WhatGroupOfParameterWithCalcOption(p, calculationOption);
        }

        public void CopyParameters(fmFilterMachiningBlock filterMachiningBlock)
        {
            if (filterMachiningBlock != null)
            {
                for (int i = 0; i < parameters.Count; ++i)
                {
                    parameters[i].value = filterMachiningBlock.parameters[i].value;
                }
            }
        }

        public void CopyConstants(fmFilterMachiningBlock filterMachiningBlock)
        {
            if (filterMachiningBlock != null)
            {
                for (int i = 0; i < constantParameters.Count; ++i)
                {
                    constantParameters[i].value = filterMachiningBlock.constantParameters[i].value;
                }
            }
        }

        public void CopyValues(fmFilterMachiningBlock filterMachiningBlock)
        {
            CopyParameters(filterMachiningBlock);
            CopyConstants(filterMachiningBlock);
        }
    }
}
