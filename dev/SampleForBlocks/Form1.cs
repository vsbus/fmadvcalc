using System;
using System.Drawing;
using System.Windows.Forms;
using FilterSimulation;
using fmCalculationLibrary;

namespace SampleForBlocks
{
// ReSharper disable InconsistentNaming
    public partial class Form1 : Form
// ReSharper restore InconsistentNaming
    {
        public Form1()
        {
            InitializeComponent();
        }

        fmCalcBlocksLibrary.Blocks.fmFilterMachiningBlockWithLimits m_fmBlock;

        private void Form1Load(object sender, EventArgs e)
        {
            fmValue.outputPrecision = 3;

            m_fmBlock = new fmCalcBlocksLibrary.Blocks.fmFilterMachiningBlockWithLimits();
            foreach (fmCalcBlocksLibrary.BlockParameter.fmBlockVariableParameter p in m_fmBlock.Parameters)
            {
                int i = fmDataGrid1.Rows.Add();
                fmDataGrid1["parameterNameColumn", i].Value = p.globalParameter.name;
                fmDataGrid1["unitsColumn", i].Value = p.globalParameter.UnitName;
                m_fmBlock.AssignCell(p, fmDataGrid1["valueColumn", i]);
            }

            m_fmBlock.hce_Value = new fmValue(0.005);
            m_fmBlock.Pc0_Value = new fmValue(1e-13);
            m_fmBlock.nc_Value = new fmValue(0.3);
            m_fmBlock.eps0_Value = new fmValue(0.5);
            m_fmBlock.kappa0_Value = new fmValue(0.4);
            m_fmBlock.ne_Value = new fmValue(0.02);
            m_fmBlock.etaf_Value = new fmValue(1e-3);
            m_fmBlock.rho_f_Value = new fmValue(1000);
            m_fmBlock.rho_s_Value = new fmValue(1500);
            m_fmBlock.Cm_Value = new fmValue(0.2);
            m_fmBlock.rho_sus_Value = fmCalculationLibrary.Equations.fmSuspensionEquations.Eval_rho_sus_From_rho_f_rho_s_Cm(m_fmBlock.rho_f_Value, m_fmBlock.rho_s_Value, m_fmBlock.Cm_Value);
            m_fmBlock.Cv_Value = fmCalculationLibrary.Equations.fmSuspensionEquations.Eval_Cv_From_rho(m_fmBlock.rho_f_Value, m_fmBlock.rho_s_Value, m_fmBlock.rho_sus_Value);
            
            m_fmBlock.SetCalculationOptionAndRewriteData(fmCalculatorsLibrary.fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_DP_CONST);
            
        }

        private void CopyDataToSecondTable()
        {
            for (int i = 0; i < m_fmBlock.Parameters.Count; ++i)
            {
                if (fmDataGrid2.RowCount < i + 1)
                {
                    fmDataGrid2.RowCount = i + 1;
                }
                fmDataGrid2.Rows[i].Cells[0].Value = m_fmBlock.Parameters[i].globalParameter.name;
                fmDataGrid2.Rows[i].Cells[1].Value = m_fmBlock.Parameters[i].globalParameter.UnitName;
                double coef = m_fmBlock.Parameters[i].globalParameter.unitFamily.CurrentUnit.Coef;
                fmDataGrid2.Rows[i].Cells[2].Value = m_fmBlock.Parameters[i].globalParameter.validRange.MinValue / coef;
                fmDataGrid2.Rows[i].Cells[3].Value = m_fmBlock.Parameters[i].ValueInUnits;
                fmDataGrid2.Rows[i].Cells[4].Value = m_fmBlock.Parameters[i].globalParameter.validRange.MaxValue / coef;
                Color colorMin = m_fmBlock.Parameters[i].value.defined == false
                    || m_fmBlock.Parameters[i].value.value < m_fmBlock.Parameters[i].globalParameter.validRange.MinValue
                        ? Color.Pink
                        : Color.White;
                Color colorMax = m_fmBlock.Parameters[i].value.defined == false
                    || m_fmBlock.Parameters[i].value.value > m_fmBlock.Parameters[i].globalParameter.validRange.MaxValue
                        ? Color.Pink
                        : Color.White;
                Color colorValue = colorMin != Color.White || colorMax != Color.White ? Color.Pink : Color.White;
                fmDataGrid2.Rows[i].Cells[2].Style.BackColor = colorMin;
                fmDataGrid2.Rows[i].Cells[3].Style.BackColor = colorValue;
                fmDataGrid2.Rows[i].Cells[4].Style.BackColor = colorMax;

                m_fmBlock.Parameters[i].cell.DataGridView.Rows[m_fmBlock.Parameters[i].cell.RowIndex].Visible = m_fmBlock.Parameters[i].group != null;
                fmDataGrid2.Rows[i].Visible = m_fmBlock.Parameters[i].group == null;
            }
        }

        private void RangesToolStripMenuItemClick(object sender, EventArgs e)
        {
            var proForm = new fmParameterIntervalOption();
            proForm.ShowDialog();
            m_fmBlock.CalculateAndDisplay();
        }

        private void CalculationOptionToolStripMenuItemClick(object sender, EventArgs e)
        {
            var cosd = new fmCalculationOptionSelectionDialog
                           {
                               filterMachiningCalculationOption = m_fmBlock.filterMachiningCalculationOption,
                               deliquoringUsedCalculationOption = m_fmBlock.deliquoringUsedCalculationOption
                           };
            //cosd.suspensionCalculationOption = ;
            if (cosd.ShowDialog() == DialogResult.OK)
            {
                m_fmBlock.SetCalculationOptionAndRewriteData(cosd.filterMachiningCalculationOption);
                m_fmBlock.CalculateAndDisplay();
            }
        }

        private void PrecisionToolStripMenuItemClick(object sender, EventArgs e)
        {
            var doForm = new AdvancedCalculator.fmDigitsOptions();
            doForm.ShowDialog();
            m_fmBlock.CalculateAndDisplay();
        }

        private void ResetInputsToolStripMenuItemClick(object sender, EventArgs e)
        {
            foreach (fmCalcBlocksLibrary.BlockParameter.fmBlockVariableParameter p in m_fmBlock.Parameters)
            {
                p.value = new fmValue();
            }
            m_fmBlock.CalculateAndDisplay();
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            CopyDataToSecondTable();
        }
    }
}