﻿using System;
using System.Collections.Generic;
using System.Text;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using System.Windows.Forms;
using fmCalculatorsLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmEps0dNedEpsdBlock : fmBaseBlock
    {
        // ReSharper disable InconsistentNaming
        private readonly fmBlockVariableParameter epsd;
        private readonly fmBlockVariableParameter Dpd;
        private readonly fmBlockVariableParameter hcd;

        private readonly fmBlockConstantParameter Dpf;
        private readonly fmBlockConstantParameter hc;
        private readonly fmBlockConstantParameter eps0;
        private readonly fmBlockConstantParameter ne;
        private readonly fmBlockConstantParameter eps;

        private readonly fmBlockParameterGroup Dpd_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup hcd_epsd_group = new fmBlockParameterGroup();

        public fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption calculationOption;

        public fmValue epsd_Value
        {
            get { return epsd.value; }
            set { epsd.value = value; }
        }
        public fmValue Dp_Value
        {
            get { return Dpd.value; }
            set { Dpd.value = value; }
        }
        public fmValue hcd_Value
        {
            get { return hcd.value; }
            set { hcd.value = value; }
        }
        // ReSharper restore InconsistentNaming

        override public void DoCalculations()
        {
            var eps0dNedEpsdCalculator = new fmEps0dNedEpsdCalculator(AllParameters);
            eps0dNedEpsdCalculator.calculationOption = calculationOption;
            eps0dNedEpsdCalculator.DoCalculations();
        }

        // ReSharper disable InconsistentNaming
        public fmEps0dNedEpsdBlock(
            DataGridViewCell Dpd_Cell,
            DataGridViewCell hcd_Cell,
            DataGridViewCell epsd_Cell)
        // ReSharper restore InconsistentNaming
        {
            AddParameter(ref Dpd, fmGlobalParameter.Dp_d, Dpd_Cell, true);
            AddParameter(ref hcd, fmGlobalParameter.hcd, hcd_Cell, false);
            AddParameter(ref epsd, fmGlobalParameter.eps_d, epsd_Cell, false);

            AddConstantParameter(ref Dpf, fmGlobalParameter.Dp);
            AddConstantParameter(ref hc, fmGlobalParameter.hc);
            AddConstantParameter(ref eps0, fmGlobalParameter.eps0);
            AddConstantParameter(ref ne, fmGlobalParameter.ne);
            AddConstantParameter(ref eps, fmGlobalParameter.eps);

            calculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.CalculatedFromCakeFormation;

            Dpd.group = Dpd_group;

            hcd.group = null;
            hcd.cell.ReadOnly = true;

            epsd.group = null;
            epsd.cell.ReadOnly = true;

            processOnChange = true;
        }
        public fmEps0dNedEpsdBlock() : this(null, null, null) { }

        public void SetCalculationOptionAndUpdateCellsStyle(fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption newCalculationOption)
        {
            calculationOption = newCalculationOption;
            UpdateCellsColorsAndReadOnly();
        }

        private void UpdateCellsColorsAndReadOnly()
        {
            if (calculationOption == fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.InputedByUser)
            {
                epsd.IsInputed = true;
                hcd.isInputed = false;
                hcd.cell.ReadOnly = false;
                hcd.group = hcd_epsd_group;
                epsd.cell.ReadOnly = false;
                epsd.group = hcd_epsd_group;
            }
            else
            {
                epsd.IsInputed = false;
                hcd.isInputed = false;
                hcd.cell.ReadOnly = true;
                hcd.group = null;
                epsd.cell.ReadOnly = true;
                epsd.group = null;
            }
            CallValuesChanged();
        }
    }
}
