using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using fmCalculationLibrary;
using FilterSimulation;

namespace SampleForBlocks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        fmCalcBlocksLibrary.Blocks.fmFilterMachiningBlockWithLimits fmBlock;

        private void Form1_Load(object sender, EventArgs e)
        {
            fmValue.outputPrecision = 3;

            fmBlock = new fmCalcBlocksLibrary.Blocks.fmFilterMachiningBlockWithLimits();
            foreach (fmCalcBlocksLibrary.BlockParameter.fmBlockVariableParameter p in fmBlock.Parameters)
            {
                int i = fmDataGrid1.Rows.Add();
                fmDataGrid1["parameterNameColumn", i].Value = p.globalParameter.name;
                fmDataGrid1["unitsColumn", i].Value = p.globalParameter.UnitName;
                fmBlock.AssignCell(p, fmDataGrid1["valueColumn", i]);
            }

            
            fmBlock.hce_Value = new fmValue(0.005);
            fmBlock.Pc0_Value = new fmValue(1e-13);
            fmBlock.nc_Value = new fmValue(0.3);
            fmBlock.eps0_Value = new fmValue(0.5);
            fmBlock.kappa0_Value = new fmValue(0.4);
            fmBlock.ne_Value = new fmValue(0.02);
            fmBlock.etaf_Value = new fmValue(1e-3);
            fmBlock.rho_f_Value = new fmValue(1000);
            fmBlock.rho_s_Value = new fmValue(1500);
            fmBlock.rho_sus_Value = new fmValue(1070);
            fmBlock.Cm_Value = new fmValue(0.2);
            fmBlock.Cv_Value = new fmValue(0.143);

            fmBlock.SetCalculationOptionAndUpdateCellsStyle(fmCalculatorsLibrary.fmFilterMachiningCalculator.FilterMachiningCalculationOption.Standart1);
            
        }

        private void rangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterSimulation.ParameterIntervalOption proForm = new FilterSimulation.ParameterIntervalOption();
            proForm.ShowDialog();
            fmBlock.CalculateAndDisplay();
        }

        private void calculationOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalculationOptionSelectionDialog cosd = new CalculationOptionSelectionDialog();
            //cosd.suspensionCalculationOption = ;
            cosd.filterMachiningCalculationOption = fmBlock.calculationOption;
            if (cosd.ShowDialog() == DialogResult.OK)
            {
                fmBlock.SetCalculationOptionAndUpdateCellsStyle(cosd.filterMachiningCalculationOption);
                fmBlock.CalculateAndDisplay();
            }
        }

        private void precisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvancedCalculator.DigitsOptions doForm = new AdvancedCalculator.DigitsOptions();
            doForm.ShowDialog();
            fmBlock.CalculateAndDisplay();
        }

        private void resetInputsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (fmCalcBlocksLibrary.BlockParameter.fmBlockVariableParameter p in fmBlock.Parameters)
            {
                p.value = new fmValue();
            }
            fmBlock.CalculateAndDisplay();
        }
    }
}