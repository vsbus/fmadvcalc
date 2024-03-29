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
        private readonly fmBlockConstantParameter d0;

        private readonly fmBlockParameterGroup Dpd_group = new fmBlockParameterGroup();
        private readonly fmBlockParameterGroup hcd_epsd_group = new fmBlockParameterGroup();


        public fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption deliquoringUsedCalculationOption;
        public fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption hcdCalculationOption;
        public fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption dpdInputCalculationOption;
        public object isPlainArea;

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
            var eps0dNedEpsdCalculator = new fmEps0dNedEpsdCalculator(AllParameters)
                                             {
                                                 hcdCalculationOption = hcdCalculationOption,
                                                 dpdInputCalculationOption = dpdInputCalculationOption,
                                                 isPlainArea = isPlainArea
                                             };
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
            AddConstantParameter(ref d0, fmGlobalParameter.d0);

            hcdCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.CalculatedFromCakeFormation;
            dpdInputCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption.CalculatedFromCakeFormation;

            UpdateCellsColorsAndReadOnly();

            processOnChange = true;
        }
        public fmEps0dNedEpsdBlock() : this(null, null, null) { }

        public void SetCalculationOptionAndRewrite(fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption newCalculationOption)
        {
            SetCalculationOptionAndUpdateCellsStyle(newCalculationOption);
            CallValuesChanged();
        }

        public void SetCalculationOptionAndRewrite(fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption newCalculationOption)
        {
            SetCalculationOptionAndUpdateCellsStyle(newCalculationOption);
            CallValuesChanged();
        }

        public void SetCalculationOptionAndRewrite(fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption newCalculationOption)
        {
            SetCalculationOptionAndUpdateCellsStyle(newCalculationOption);
            CallValuesChanged();
        }

        public void SetCalculationOptionAndUpdateCellsStyle(fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption newCalculationOption)
        {
            deliquoringUsedCalculationOption = newCalculationOption;
            UpdateCellsColorsAndReadOnly();
        }

        public void SetCalculationOptionAndUpdateCellsStyle(fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption newCalculationOption)
        {
            hcdCalculationOption = newCalculationOption;
            UpdateCellsColorsAndReadOnly();
        }

        public void SetCalculationOptionAndUpdateCellsStyle(fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption newCalculationOption)
        {
            dpdInputCalculationOption = newCalculationOption;
            UpdateCellsColorsAndReadOnly();
        }

        private void UpdateCellsColorsAndReadOnly()
        {
            if (deliquoringUsedCalculationOption == fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption.NotUsed)
            {
                hcd.isInputed = false;
                if (hcd.cell != null)
                {
                    hcd.cell.ReadOnly = true;
                }
                hcd.group = null;
                
                epsd.isInputed = false;
                if (epsd.cell != null)
                {
                    epsd.cell.ReadOnly = true;
                }
                epsd.group = null;

                Dpd.IsInputed = false;
                if (Dpd.cell != null)
                {
                    Dpd.cell.ReadOnly = true;
                }
                Dpd.group = null;
                return;
            }

            if (hcdCalculationOption == fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.InputedByUser)
            {
                epsd.IsInputed = true;
                hcd.isInputed = false;
                if (hcd.cell != null)
                {
                    hcd.cell.ReadOnly = false;
                }
                hcd.group = hcd_epsd_group;
                if (epsd.cell != null)
                {
                    epsd.cell.ReadOnly = false;
                }
                epsd.group = hcd_epsd_group;
            }
            else
            {
                epsd.IsInputed = false;
                hcd.isInputed = false;
                if (hcd.cell != null)
                {
                    hcd.cell.ReadOnly = true;
                }
                hcd.group = null;
                if (epsd.cell != null)
                {
                    epsd.cell.ReadOnly = true;
                }
                epsd.group = null;
            }

            if (dpdInputCalculationOption == fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption.InputedByUser)
            {
                Dpd.IsInputed = true;
                if (Dpd.cell != null)
                {
                    Dpd.cell.ReadOnly = false;
                }
                Dpd.group = Dpd_group;
            }
            else
            {
                Dpd.IsInputed = false;
                if (Dpd.cell != null)
                {
                    Dpd.cell.ReadOnly = true;
                }
                Dpd.group = null;
            }
        }
    }
}
