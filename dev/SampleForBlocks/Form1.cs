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
            fmBlock.Cm_Value = new fmValue(0.2);
            fmBlock.rho_sus_Value = fmCalculationLibrary.Equations.SuspensionEquations.Eval_rho_sus_From_rho_f_rho_s_Cm(fmBlock.rho_f_Value, fmBlock.rho_s_Value, fmBlock.Cm_Value);
            fmBlock.Cv_Value = fmCalculationLibrary.Equations.SuspensionEquations.Eval_Cv_From_rho(fmBlock.rho_f_Value, fmBlock.rho_s_Value, fmBlock.rho_sus_Value);
            
            fmBlock.SetCalculationOptionAndUpdateCellsStyle(fmCalculatorsLibrary.fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART_AND_DESIGN_GLOBAL);
            
        }

        private void CopyDataToSecondTable()
        {
            for (int i = 0; i < fmBlock.Parameters.Count; ++i)
            {
                if (fmDataGrid2.RowCount < i + 1)
                {
                    fmDataGrid2.RowCount = i + 1;
                }
                fmDataGrid2.Rows[i].Cells[0].Value = fmBlock.Parameters[i].globalParameter.name;
                fmDataGrid2.Rows[i].Cells[1].Value = fmBlock.Parameters[i].globalParameter.UnitName;
                double coef = fmBlock.Parameters[i].globalParameter.unitFamily.CurrentUnit.Coef;
                fmDataGrid2.Rows[i].Cells[2].Value = fmBlock.Parameters[i].globalParameter.chartDefaultXRange.minValue / coef;
                fmDataGrid2.Rows[i].Cells[3].Value = fmBlock.Parameters[i].ValueInUnits;
                fmDataGrid2.Rows[i].Cells[4].Value = fmBlock.Parameters[i].globalParameter.chartDefaultXRange.maxValue / coef;
                Color colorMin = fmBlock.Parameters[i].value.Defined == false
                    || fmBlock.Parameters[i].value.Value < fmBlock.Parameters[i].globalParameter.chartDefaultXRange.minValue
                        ? Color.Pink
                        : Color.White;
                Color colorMax = fmBlock.Parameters[i].value.Defined == false
                    || fmBlock.Parameters[i].value.Value > fmBlock.Parameters[i].globalParameter.chartDefaultXRange.maxValue
                        ? Color.Pink
                        : Color.White;
                Color colorValue = colorMin != Color.White || colorMax != Color.White ? Color.Pink : Color.White;
                fmDataGrid2.Rows[i].Cells[2].Style.BackColor = colorMin;
                fmDataGrid2.Rows[i].Cells[3].Style.BackColor = colorValue;
                fmDataGrid2.Rows[i].Cells[4].Style.BackColor = colorMax;

                fmBlock.Parameters[i].cell.DataGridView.Rows[fmBlock.Parameters[i].cell.RowIndex].Visible = fmBlock.Parameters[i].group != null;
                fmDataGrid2.Rows[i].Visible = fmBlock.Parameters[i].group == null;
            }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            CopyDataToSecondTable();
        }
    }
}