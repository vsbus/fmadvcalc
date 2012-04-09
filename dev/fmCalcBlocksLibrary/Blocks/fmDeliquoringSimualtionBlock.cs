using System;
using System.Collections.Generic;
using System.Text;
using fmCalcBlocksLibrary.BlockParameter;
using System.Windows.Forms;
using fmCalculationLibrary;
using fmCalculatorsLibrary;
using System.Drawing;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmDeliquoringSimualtionBlock : fmBaseBlock
    {
        private readonly fmBlockVariableParameter hcd;
        private readonly fmBlockVariableParameter sd;
        private readonly fmBlockVariableParameter td;
        private readonly fmBlockVariableParameter K;
        private readonly fmBlockVariableParameter Smech;
        private readonly fmBlockVariableParameter S;
        private readonly fmBlockVariableParameter Rfmech;
        private readonly fmBlockVariableParameter Rf;
        private readonly fmBlockVariableParameter Qgi;
        private readonly fmBlockVariableParameter Qg;
        private readonly fmBlockVariableParameter vg;
        private readonly fmBlockVariableParameter Mfd;
        private readonly fmBlockVariableParameter Vfd;
        private readonly fmBlockVariableParameter Mlcd;
        private readonly fmBlockVariableParameter Vlcd;
        private readonly fmBlockVariableParameter Mcd;
        private readonly fmBlockVariableParameter Vcd;
        private readonly fmBlockVariableParameter rho_bulk;
        private readonly fmBlockVariableParameter Qmfid;
        private readonly fmBlockVariableParameter Qfid;
        private readonly fmBlockVariableParameter Qmcd;
        private readonly fmBlockVariableParameter Qcd;
        private readonly fmBlockVariableParameter qmfid;
        private readonly fmBlockVariableParameter qfid;
        private readonly fmBlockVariableParameter qmcd;
        private readonly fmBlockVariableParameter qcd;

        private readonly fmBlockVariableParameter Qgt;
        private readonly fmBlockVariableParameter Vg;
        private readonly fmBlockVariableParameter Mev;
        private readonly fmBlockVariableParameter Vev;
        private readonly fmBlockVariableParameter Qmftd;
        private readonly fmBlockVariableParameter Qmfd;
        private readonly fmBlockVariableParameter Qftd;
        private readonly fmBlockVariableParameter Qfd;
        private readonly fmBlockVariableParameter Qmevi;
        private readonly fmBlockVariableParameter Qmevt;
        private readonly fmBlockVariableParameter Qmev;
        private readonly fmBlockVariableParameter Qevi;
        private readonly fmBlockVariableParameter Qevt;
        private readonly fmBlockVariableParameter Qev;
        private readonly fmBlockVariableParameter qmftd;
        private readonly fmBlockVariableParameter qmfd;
        private readonly fmBlockVariableParameter qftd;
        private readonly fmBlockVariableParameter qfd;
        private readonly fmBlockVariableParameter qmevi;
        private readonly fmBlockVariableParameter qmevt;
        private readonly fmBlockVariableParameter qmev;
        private readonly fmBlockVariableParameter qevi;
        private readonly fmBlockVariableParameter qevt;
        private readonly fmBlockVariableParameter qev;

        private readonly fmBlockConstantParameter hc;
        private readonly fmBlockConstantParameter sf;
        private readonly fmBlockConstantParameter eps;
        private readonly fmBlockConstantParameter epsd;
        private readonly fmBlockConstantParameter tc;
        private readonly fmBlockConstantParameter pcd;
        private readonly fmBlockConstantParameter Dpd;
        private readonly fmBlockConstantParameter pke;
        private readonly fmBlockConstantParameter etaf;
        private readonly fmBlockConstantParameter hce;
        private readonly fmBlockConstantParameter Srem;
        private readonly fmBlockConstantParameter ad1;
        private readonly fmBlockConstantParameter ad2;
        private readonly fmBlockConstantParameter A;
        private readonly fmBlockConstantParameter peq;
        private readonly fmBlockConstantParameter Mmole;
        private readonly fmBlockConstantParameter Tetta;
        private readonly fmBlockConstantParameter ag1;
        private readonly fmBlockConstantParameter ag2;
        private readonly fmBlockConstantParameter ag3;
        private readonly fmBlockConstantParameter f;
        private readonly fmBlockConstantParameter etag;
        private readonly fmBlockConstantParameter rhof;
        private readonly fmBlockConstantParameter rhos;
        private readonly fmBlockConstantParameter Ms;

        private readonly fmBlockParameterGroup second_group = new fmBlockParameterGroup(Color.FromArgb(250, 220, 220));

        public fmValue hc_Value
        {
            get { return hc.value; }
            set { hc.value = value; }
        }
        public fmValue eps_Value
        {
            get { return eps.value; }
            set { eps.value = value; }
        }
        public fmValue epsd_Value
        {
            get { return epsd.value; }
            set { epsd.value = value; }
        }

        public fmValue tc_Value {get {return tc.value;} set {tc.value = value;}}
        public fmValue pcd_Value {get {return pcd.value;} set {pcd.value = value;}}
        public fmValue Dpd_Value {get {return Dpd.value;} set {Dpd.value = value;}}
        public fmValue pke_Value {get {return pke.value;} set {pke.value = value;}}
        public fmValue etaf_Value {get {return etaf.value;} set {etaf.value = value;}}
        public fmValue hce_Value {get {return hce.value;} set {hce.value = value;}}
        public fmValue Srem_Value {get {return Srem.value;} set {Srem.value = value;}}
        public fmValue ad1_Value {get {return ad1.value;} set {ad1.value = value;}}
        public fmValue ad2_Value {get {return ad2.value;} set {ad2.value = value;}}
        public fmValue A_Value {get {return A.value;} set {A.value = value;}}
        public fmValue peq_Value {get {return peq.value;} set {peq.value = value;}}
        public fmValue Mmole_Value {get {return Mmole.value;} set {Mmole.value = value;}}
        public fmValue Tetta_Value {get {return Tetta.value;} set {Tetta.value = value;}}
        public fmValue ag1_Value {get {return ag1.value;} set {ag1.value = value;}}
        public fmValue ag2_Value {get {return ag2.value;} set {ag2.value = value;}}
        public fmValue ag3_Value {get {return ag3.value;} set {ag3.value = value;}}
        public fmValue f_Value {get {return f.value;} set {f.value = value;}}
        public fmValue etag_Value {get {return etag.value;} set {etag.value = value;}}
        public fmValue rhof_Value {get {return rhof.value;} set {rhof.value = value;}}
        public fmValue rhos_Value {get {return rhos.value;} set {rhos.value = value;}}

        override public void DoCalculations()
        {
            var fmDeliquoringSimualtionCalculator = new fmDeliquoringSimualtionCalculator(AllParameters);
            fmDeliquoringSimualtionCalculator.DoCalculations();
        }

        // ReSharper disable InconsistentNaming
        public fmDeliquoringSimualtionBlock(
            DataGridViewCell hcd_Cell,
            DataGridViewCell sd_Cell,
            DataGridViewCell td_Cell,
            DataGridViewCell K_Cell,
            DataGridViewCell Smech_Cell,
            DataGridViewCell S_Cell,
            DataGridViewCell Rfmech_Cell,
            DataGridViewCell Rf_Cell,
            DataGridViewCell Rf_star_Cell,
            DataGridViewCell Qgi_Cell,
            DataGridViewCell Qg_Cell,
            DataGridViewCell vg_Cell,
            DataGridViewCell Mfd_Cell,
            DataGridViewCell Vfd_Cell,
            DataGridViewCell Mlcd_Cell,
            DataGridViewCell Vlcd_Cell,
            DataGridViewCell Mcd_Cell,
            DataGridViewCell Vcd_Cell,
            DataGridViewCell rho_bulk_Cell,
            DataGridViewCell Qmfid_Cell,
            DataGridViewCell Qfid_Cell,
            DataGridViewCell Qmcd_Cell,
            DataGridViewCell Qcd_Cell,
            DataGridViewCell qmfid_Cell,
            DataGridViewCell qfid_Cell,
            DataGridViewCell qmcd_Cell,
            DataGridViewCell qcd_Cell,
            DataGridViewCell Qgt_Cell,
            DataGridViewCell Vg_Cell,
            DataGridViewCell Mev_Cell,
            DataGridViewCell Vev_Cell,
            DataGridViewCell Qmftd_Cell,
            DataGridViewCell Qmfd_Cell,
            DataGridViewCell Qftd_Cell,
            DataGridViewCell Qfd_Cell,
            DataGridViewCell Qmevi_Cell,
            DataGridViewCell Qmevt_Cell,
            DataGridViewCell Qmev_Cell,
            DataGridViewCell Qevi_Cell,
            DataGridViewCell Qevt_Cell,
            DataGridViewCell Qev_Cell,
            DataGridViewCell qmftd_Cell,
            DataGridViewCell qmfd_Cell,
            DataGridViewCell qftd_Cell,
            DataGridViewCell qfd_Cell,
            DataGridViewCell qmevi_Cell,
            DataGridViewCell qmevt_Cell,
            DataGridViewCell qmev_Cell,
            DataGridViewCell qevi_Cell,
            DataGridViewCell qevt_Cell,
            DataGridViewCell qev_Cell)
        // ReSharper restore InconsistentNaming
        {
            AddParameter(ref hcd, fmGlobalParameter.hcd, hcd_Cell, false);
            AddParameter(ref sd, fmGlobalParameter.sd, sd_Cell, true);
            AddParameter(ref td, fmGlobalParameter.td, td_Cell, false);
            AddParameter(ref K, fmGlobalParameter.K, K_Cell, false);
            AddParameter(ref Smech, fmGlobalParameter.Smech, Smech_Cell, false);
            AddParameter(ref S, fmGlobalParameter.S, S_Cell, false);
            AddParameter(ref Rfmech, fmGlobalParameter.Rfmech, Rfmech_Cell, false);
            AddParameter(ref Rf, fmGlobalParameter.Rf, Rf_Cell, false);
            AddParameter(ref Qgi, fmGlobalParameter.Qgi, Qgi_Cell, false);
            AddParameter(ref Qg, fmGlobalParameter.Qg, Qg_Cell, false);
            AddParameter(ref vg, fmGlobalParameter.vg, vg_Cell, false);
            AddParameter(ref Mfd, fmGlobalParameter.Mfd, Mfd_Cell, false);
            AddParameter(ref Vfd, fmGlobalParameter.Vfd, Vfd_Cell, false);
            AddParameter(ref Mlcd, fmGlobalParameter.Mlcd, Mlcd_Cell, false);
            AddParameter(ref Vlcd, fmGlobalParameter.Vlcd, Vlcd_Cell, false);
            AddParameter(ref Mcd, fmGlobalParameter.Mcd, Mcd_Cell, false);
            AddParameter(ref Vcd, fmGlobalParameter.Vcd, Vcd_Cell, false);
            AddParameter(ref rho_bulk, fmGlobalParameter.rho_bulk, rho_bulk_Cell, false);
            AddParameter(ref Qmfid, fmGlobalParameter.Qmfid, Qmfid_Cell, false);
            AddParameter(ref Qfid, fmGlobalParameter.Qfid, Qfid_Cell, false);
            AddParameter(ref Qmcd, fmGlobalParameter.Qmcd, Qmcd_Cell, false);
            AddParameter(ref Qcd, fmGlobalParameter.Qcd, Qcd_Cell, false);
            AddParameter(ref qmfid, fmGlobalParameter.qmfid, qmfid_Cell, false);
            AddParameter(ref qfid, fmGlobalParameter.qfid, qfid_Cell, false);
            AddParameter(ref qmcd, fmGlobalParameter.qmcd, qmcd_Cell, false);
            AddParameter(ref qcd, fmGlobalParameter.qcd, qcd_Cell, false);

            AddParameter(ref Qgt, fmGlobalParameter.Qgt, Qgt_Cell, false);
            AddParameter(ref Vg, fmGlobalParameter.Vg, Vg_Cell, false);
            AddParameter(ref Mev, fmGlobalParameter.Mev, Mev_Cell, false);
            AddParameter(ref Vev, fmGlobalParameter.Vev, Vev_Cell, false);
            AddParameter(ref Qmftd, fmGlobalParameter.Qmftd, Qmftd_Cell, false);
            AddParameter(ref Qmfd, fmGlobalParameter.Qmfd, Qmfd_Cell, false);
            AddParameter(ref Qftd, fmGlobalParameter.Qftd, Qftd_Cell, false);
            AddParameter(ref Qfd, fmGlobalParameter.Qfd, Qfd_Cell, false);
            AddParameter(ref Qmevi, fmGlobalParameter.Qmevi, Qmevi_Cell, false);
            AddParameter(ref Qmevt, fmGlobalParameter.Qmevt, Qmevt_Cell, false);
            AddParameter(ref Qmev, fmGlobalParameter.Qmev, Qmev_Cell, false);
            AddParameter(ref Qevi, fmGlobalParameter.Qevi, Qevi_Cell, false);
            AddParameter(ref Qevt, fmGlobalParameter.Qevt, Qevt_Cell, false);
            AddParameter(ref Qev, fmGlobalParameter.Qev, Qev_Cell, false);
            AddParameter(ref qmftd, fmGlobalParameter.qmftd, qmftd_Cell, false);
            AddParameter(ref qmfd, fmGlobalParameter.qmfd, qmfd_Cell, false);
            AddParameter(ref qftd, fmGlobalParameter.qftd, qftd_Cell, false);
            AddParameter(ref qfd, fmGlobalParameter.qfd, qfd_Cell, false);
            AddParameter(ref qmevi, fmGlobalParameter.qmevi, qmevi_Cell, false);
            AddParameter(ref qmevt, fmGlobalParameter.qmevt, qmevt_Cell, false);
            AddParameter(ref qmev, fmGlobalParameter.qmev, qmev_Cell, false);
            AddParameter(ref qevi, fmGlobalParameter.qevi, qevi_Cell, false);
            AddParameter(ref qevt, fmGlobalParameter.qevt, qevt_Cell, false);
            AddParameter(ref qev, fmGlobalParameter.qev, qev_Cell, false);
            
            AddConstantParameter(ref hc, fmGlobalParameter.hc);
            AddConstantParameter(ref sf, fmGlobalParameter.sf);
            AddConstantParameter(ref eps, fmGlobalParameter.eps);
            AddConstantParameter(ref epsd, fmGlobalParameter.eps_d);
            AddConstantParameter(ref tc, fmGlobalParameter.tc);
            AddConstantParameter(ref pcd, fmGlobalParameter.pc_d);
            AddConstantParameter(ref Dpd, fmGlobalParameter.Dp_d);
            AddConstantParameter(ref pke, fmGlobalParameter.pke);
            AddConstantParameter(ref etaf, fmGlobalParameter.eta_f);
            AddConstantParameter(ref hce, fmGlobalParameter.hce0);
            AddConstantParameter(ref Srem, fmGlobalParameter.Srem);
            AddConstantParameter(ref ad1, fmGlobalParameter.ad1);
            AddConstantParameter(ref ad2, fmGlobalParameter.ad2);
            AddConstantParameter(ref A, fmGlobalParameter.A);
            AddConstantParameter(ref peq, fmGlobalParameter.peq);
            AddConstantParameter(ref Mmole, fmGlobalParameter.Mmole);
            AddConstantParameter(ref Tetta, fmGlobalParameter.Tetta);
            AddConstantParameter(ref ag1, fmGlobalParameter.ag1);
            AddConstantParameter(ref ag2, fmGlobalParameter.ag2);
            AddConstantParameter(ref ag3, fmGlobalParameter.ag3);
            AddConstantParameter(ref f, fmGlobalParameter.f);
            AddConstantParameter(ref etag, fmGlobalParameter.eta_g);
            AddConstantParameter(ref rhof, fmGlobalParameter.rho_f);
            AddConstantParameter(ref rhos, fmGlobalParameter.rho_s);
            AddConstantParameter(ref Ms, fmGlobalParameter.Ms);

//             foreach (fmBlockVariableParameter p in parameters)
//             {
//                 if (p.globalParameter != fmGlobalParameter.hcd
//                     && p.globalParameter != fmGlobalParameter.Vcd)
//                 {
//                     p.group = second_group;
//                 }
//             }
            sd.group = second_group;
            td.group = second_group;
            K.group = second_group;
            Smech.group = second_group;
            S.group = second_group;
            Rfmech.group = second_group;
            Rf.group = second_group;
            Qgi.group = second_group;
            Qg.group = second_group;
            vg.group = second_group;
            Mfd.group = second_group;
            Vfd.group = second_group;
            Mlcd.group = second_group;
            Vlcd.group = second_group;
            rho_bulk.group = second_group;
            Qmfid.group = second_group;
            Qfid.group = second_group;
            qmfid.group = second_group;
            qfid.group = second_group;

            UpdateCellsStyle();
            processOnChange = true;
        }

        public void UpdateCellsStyle()
        {
            var groupUsed = new Dictionary<fmBlockParameterGroup, bool>();
            foreach (fmBlockVariableParameter parameter in parameters)
                if (parameter.group != null)
                    groupUsed[parameter.group] = false;

            foreach (fmBlockVariableParameter parameter in parameters)
            {
                parameter.IsInputed = parameter.group != null && !groupUsed[parameter.group];
                if (parameter.group != null)
                {
                    groupUsed[parameter.group] = true;
                }
                if (parameter.cell != null)
                {
                    parameter.cell.ReadOnly = parameter.group == null;
                }
            }

            UpdateCellsBackColor();
            ReWriteParameters();
        }

        public fmDeliquoringSimualtionBlock() : this(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null) { }
    }
}
