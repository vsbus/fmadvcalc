using System;
using System.Collections.Generic;
using System.Text;
using fmCalcBlocksLibrary.BlockParameter;
using System.Windows.Forms;
using fmCalculationLibrary;
using fmCalculatorsLibrary;

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
        private readonly fmBlockVariableParameter Rf_star;
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

        private readonly fmBlockConstantParameter hc;
        private readonly fmBlockConstantParameter eps;
        private readonly fmBlockConstantParameter epsd;

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
            DataGridViewCell qcd_Cell)
        // ReSharper restore InconsistentNaming
        {
            AddParameter(ref hcd, fmGlobalParameter.hcd, hcd_Cell, false);
            AddParameter(ref sd, fmGlobalParameter.sd, sd_Cell, false);
            AddParameter(ref td, fmGlobalParameter.td, td_Cell, true);
            AddParameter(ref K, fmGlobalParameter.K, K_Cell, false);
            AddParameter(ref Smech, fmGlobalParameter.Smech, Smech_Cell, false);
            AddParameter(ref S, fmGlobalParameter.S, S_Cell, false);
            AddParameter(ref Rfmech, fmGlobalParameter.Rfmech, Rfmech_Cell, false);
            AddParameter(ref Rf, fmGlobalParameter.Rf, Rf_Cell, false);
            AddParameter(ref Rf_star, fmGlobalParameter.Rf_star, Rf_star_Cell, false);
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
            
            AddConstantParameter(ref hc, fmGlobalParameter.hc);
            AddConstantParameter(ref eps, fmGlobalParameter.eps);
            AddConstantParameter(ref epsd, fmGlobalParameter.eps_d);

            processOnChange = true;
        }

        public fmDeliquoringSimualtionBlock() : this(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null) { }
    }
}
