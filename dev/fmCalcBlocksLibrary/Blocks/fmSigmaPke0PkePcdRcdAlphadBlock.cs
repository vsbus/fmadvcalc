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
        private readonly fmBlockVariableParameter etad;
        private readonly fmBlockVariableParameter rhod;
        private readonly fmBlockVariableParameter sigma;
        private readonly fmBlockVariableParameter pke0;
        private readonly fmBlockVariableParameter pke;
        private readonly fmBlockVariableParameter pcd;
        private readonly fmBlockVariableParameter rcd;
        private readonly fmBlockVariableParameter alphad;

        private readonly fmBlockConstantParameter eta_f;
        private readonly fmBlockConstantParameter rho_f;
        private readonly fmBlockConstantParameter Dp;
        private readonly fmBlockConstantParameter Dpd;
        private readonly fmBlockConstantParameter nc;
        private readonly fmBlockConstantParameter eps_d;
        private readonly fmBlockConstantParameter rho_s;
        private readonly fmBlockConstantParameter Pc0;

        public fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption rhoDetaDCalculationOption;
        public fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption PcDCalculationOption;
        
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
        private readonly fmBlockParameterGroup pke_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup pc_rc_alpha_group = new fmBlockParameterGroup();

        override public void DoCalculations()
        {
            var fmSigmaPke0PkePcdRcdAlphadCalculator = new fmSigmaPke0PkePcdRcdAlphadCalculator(AllParameters)
                                                           {
                                                               rhoDetaDCalculationOption = rhoDetaDCalculationOption,
                                                               PcDCalculationOption = PcDCalculationOption
                                                           };
            fmSigmaPke0PkePcdRcdAlphadCalculator.DoCalculations();
        }

        // ReSharper disable InconsistentNaming
        public fmSigmaPke0PkePcdRcdAlphadBlock(
            DataGridViewCell etad_Cell,
            DataGridViewCell rhod_Cell,
            DataGridViewCell sigma_Cell,
            DataGridViewCell pke0_Cell,
            DataGridViewCell pke_Cell,
            DataGridViewCell pcd_Cell,
            DataGridViewCell rcd_Cell,
            DataGridViewCell alphad_Cell)
        // ReSharper restore InconsistentNaming
        {
            AddParameter(ref etad, fmGlobalParameter.eta_d, etad_Cell, false);
            AddParameter(ref rhod, fmGlobalParameter.rho_d, rhod_Cell, false);
            AddParameter(ref sigma, fmGlobalParameter.sigma, sigma_Cell, true);
            AddParameter(ref pke0, fmGlobalParameter.pke0, pke0_Cell, true);
            AddParameter(ref pke, fmGlobalParameter.pke, pke_Cell, false);
            AddParameter(ref pcd, fmGlobalParameter.pc_d, pcd_Cell, false);
            AddParameter(ref rcd, fmGlobalParameter.rc_d, rcd_Cell, false);
            AddParameter(ref alphad, fmGlobalParameter.alpha_d, alphad_Cell, false);
            
            AddConstantParameter(ref eta_f, fmGlobalParameter.eta_f);
            AddConstantParameter(ref rho_f, fmGlobalParameter.rho_f);
            AddConstantParameter(ref Dp, fmGlobalParameter.Dp);
            AddConstantParameter(ref Dpd, fmGlobalParameter.Dp_d);
            AddConstantParameter(ref nc, fmGlobalParameter.nc);
            AddConstantParameter(ref eps_d, fmGlobalParameter.eps_d);
            AddConstantParameter(ref rho_s, fmGlobalParameter.rho_s);
            AddConstantParameter(ref Pc0, fmGlobalParameter.Pc0);

            rhoDetaDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption.EqualToRhoF;
            PcDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption.Calculated;

            sigma.group = sigma_group;
            pke0.group = pke_group;
            pke.group = pke_group;

            pcd.group = pc_rc_alpha_group;
            rcd.group = pc_rc_alpha_group;
            alphad.group = pc_rc_alpha_group;

            etad.cell.ReadOnly = true;
            rhod.cell.ReadOnly = true;
            pcd.cell.ReadOnly = true;
            rcd.cell.ReadOnly = true;
            alphad.cell.ReadOnly = true;

            processOnChange = true;
        }

        public void SetCalculationOptionAndRewrite(fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption newCalculationOption)
        {
            SetCalculationOptionAndUpdateCellsStyle(newCalculationOption);
            CallValuesChanged();
        }

        public void SetCalculationOptionAndRewrite(fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption newCalculationOption)
        {
            SetCalculationOptionAndUpdateCellsStyle(newCalculationOption);
            CallValuesChanged();
        }

        public void SetCalculationOptionAndUpdateCellsStyle(fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption newCalculationOption)
        {
            rhoDetaDCalculationOption = newCalculationOption;
            UpdateCellsColorsAndReadOnly();
        }

        public void SetCalculationOptionAndUpdateCellsStyle(fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption newCalculationOption)
        {
            PcDCalculationOption = newCalculationOption;
            UpdateCellsColorsAndReadOnly();
        }

        private void UpdateCellsColorsAndReadOnly()
        {
            if (rhoDetaDCalculationOption == fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption.InputedByUser)
            {
                rhod.IsInputed = true;
                rhod.cell.ReadOnly = false;
                etad.IsInputed = true;
                etad.cell.ReadOnly = false;
            }
            else
            {
                rhod.IsInputed = false;
                rhod.cell.ReadOnly = true;
                etad.IsInputed = false;
                etad.cell.ReadOnly = true;
            }

            if (PcDCalculationOption == fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption.InputedByUser)
            {
                pcd.IsInputed = true;
                rcd.IsInputed = false;
                alphad.IsInputed = false;
                pcd.cell.ReadOnly = false;
                rcd.cell.ReadOnly = false;
                alphad.cell.ReadOnly = false;
            }
            else
            {
                pcd.IsInputed = false;
                rcd.IsInputed = false;
                alphad.IsInputed = false;
                pcd.cell.ReadOnly = true;
                rcd.cell.ReadOnly = true;
                alphad.cell.ReadOnly = true;
            }
        }

        public fmSigmaPke0PkePcdRcdAlphadBlock() : this(null, null, null, null, null, null, null, null) { }
    }
}
