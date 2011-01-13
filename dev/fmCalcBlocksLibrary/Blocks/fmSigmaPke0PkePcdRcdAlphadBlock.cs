using System;
using System.Collections.Generic;
using System.Text;
using fmCalcBlocksLibrary.BlockParameter;
using System.Windows.Forms;
using fmCalculationLibrary;
using fmCalculatorsLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmSigmaPke0PkePcdRcdAlphadBlock : fmBaseBlock
    {
        private readonly fmBlockVariableParameter sigma;
        private readonly fmBlockVariableParameter pke0;
        private readonly fmBlockVariableParameter pke;
        private readonly fmBlockVariableParameter pcd;
        private readonly fmBlockVariableParameter rcd;
        private readonly fmBlockVariableParameter alphad;

        private readonly fmBlockConstantParameter Dp;
        private readonly fmBlockConstantParameter Dpd;
        private readonly fmBlockConstantParameter nc;
        private readonly fmBlockConstantParameter eps_d;
        private readonly fmBlockConstantParameter rho_s;
        private readonly fmBlockConstantParameter Pc0;
        
        public fmValue Dp_Value
        {
            get { return Dp.value; }
            set { Dp.value = value; }
        }
        public fmValue Dpd_Value
        {
            get { return Dpd.value; }
            set { Dpd.value = value; }
        }
        public fmValue nc_Value
        {
            get { return nc.value; }
            set { nc.value = value; }
        }
        public fmValue eps_d_Value
        {
            get { return eps_d.value; }
            set { eps_d.value = value; }
        }
        public fmValue rho_s_Value
        {
            get { return rho_s.value; }
            set { rho_s.value = value; }
        }
        
        private readonly fmBlockParameterGroup sigma_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup pke0_group = new fmBlockParameterGroup();

        override public void DoCalculations()
        {
            var fmSigmaPke0PkePcdRcdAlphadCalculator = new fmSigmaPke0PkePcdRcdAlphadCalculator(AllParameters);
            fmSigmaPke0PkePcdRcdAlphadCalculator.DoCalculations();
        }

        // ReSharper disable InconsistentNaming
        public fmSigmaPke0PkePcdRcdAlphadBlock(
            DataGridViewCell sigma_Cell,
            DataGridViewCell pke0_Cell,
            DataGridViewCell pke_Cell,
            DataGridViewCell pcd_Cell,
            DataGridViewCell rcd_Cell,
            DataGridViewCell alphad_Cell)
        // ReSharper restore InconsistentNaming
        {
            AddParameter(ref sigma, fmGlobalParameter.sigma, sigma_Cell, true);
            AddParameter(ref pke0, fmGlobalParameter.pke0, pke0_Cell, true);
            AddParameter(ref pke, fmGlobalParameter.pke, pke_Cell, false);
            AddParameter(ref pcd, fmGlobalParameter.pc_d, pcd_Cell, false);
            AddParameter(ref rcd, fmGlobalParameter.rc_d, rcd_Cell, false);
            AddParameter(ref alphad, fmGlobalParameter.alpha_d, alphad_Cell, false);
            AddConstantParameter(ref Dp, fmGlobalParameter.Dp);
            AddConstantParameter(ref Dpd, fmGlobalParameter.Dp_d);
            AddConstantParameter(ref nc, fmGlobalParameter.nc);
            AddConstantParameter(ref eps_d, fmGlobalParameter.eps_d);
            AddConstantParameter(ref rho_s, fmGlobalParameter.rho_s);
            AddConstantParameter(ref Pc0, fmGlobalParameter.Pc0);

            sigma.group = sigma_group;
            pke0.group = pke0_group;

            pke.cell.ReadOnly = true;
            pcd.cell.ReadOnly = true;
            rcd.cell.ReadOnly = true;
            alphad.cell.ReadOnly = true;

            processOnChange = true;
        }

        public fmSigmaPke0PkePcdRcdAlphadBlock() : this(null, null, null, null, null, null) { }
    }
}
