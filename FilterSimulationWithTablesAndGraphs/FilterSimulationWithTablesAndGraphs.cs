using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using fmCalcBlocksLibrary;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;
using FilterSimulation.fmFilterObjects;
using fmCalcBlocksLibrary.Blocks;

namespace FilterSimulationWithTablesAndGraphs
{
    public partial class FilterSimulationWithTablesAndGraphs : FilterSimulation.FilterSimulation
    {
        public FilterSimulationWithTablesAndGraphs()
        {
            InitializeComponent();

            CreateColumnsInParametersTables();
            rowsQuantity.Text = RowsQuantity.ToString();

            calculationOptionViewInTablesAndGraphs_CheckedChanged(null, new EventArgs());

            // BEGIN DEBUG CODE
            AddRow();
            fmLocalBlocks[0].A_Value = new fmValue(1 * fmUnitFamily.AreaFamily.CurrentUnit.Coef);
            fmLocalBlocks[0].Dp_Value = new fmValue(1 * fmUnitFamily.PressureFamily.CurrentUnit.Coef);
            fmLocalBlocks[0].sf_Value = new fmValue(30 * fmUnitFamily.ConcentrationFamily.CurrentUnit.Coef);
            fmLocalBlocks[0].n_Value = new fmValue(1 * fmUnitFamily.FrequencyFamily.CurrentUnit.Coef);
            // END DEBUG CODE
        }

        private void DisplayCharts(fmFilterSimSolution sol)
        {
            List<fmFilterMachiningBlock> fmbList = new List<fmFilterMachiningBlock>();

            if (byCheckingSimulations)
            {
                if (sol.CurrentObjects.Simulation != null)
                {
                    fmbList.Add(sol.CurrentObjects.Simulation.filterMachiningBlock);
                }
            }
            else
            {
                foreach( DataGridViewRow row in simulationDataGrid.Rows)
                {
                    if(row.Visible)
                    {
                        fmFilterSimulation sim = sol.FindSimulation(new Guid(row.Cells[simulationGuidColumn.Name].Value.ToString()));
                        if(sim.Checked)
                        {
                            fmbList.Add(sim.filterMachiningBlock);
                        }
                    }
                }
            }

            
            currentSimFMB = sol.CurrentObjects.Simulation == null ? null : sol.CurrentObjects.Simulation.filterMachiningBlock;
            BuildCurves(fmbList);
        }

        override protected void DisplaySolution(fmFilterSimSolution sol)
        {
            base.DisplaySolution(sol);
            if (displayingSolution == false)
            {
                displayingSolution = true;
                DisplayCharts(sol);
                displayingSolution = false;
            }
        }
        override protected void UpdateUnitsAndData()
        {
            base.UpdateUnitsAndData();
            UpdateUnitsInTablesAndGraphs();
        }

        private void ReadMinMaxXValues()
        {
            if (loadingXRange == false)
            {
                double minXValue = fmValue.StringToValue(minXValueTextBox.Text).Value;
                double maxXValue = fmValue.StringToValue(maxXValueTextBox.Text).Value;

                int xAxisParameterIndex = GetFilterMachiningBlockParameterIndexByName(listBoxXAxis.Text);
                fmFilterMachiningBlock tmpFMB = new fmFilterMachiningBlock(null);
                double coef = tmpFMB.Parameters[xAxisParameterIndex].globalParameter.unitFamily.CurrentUnit.Coef;
                fmRange range = tmpFMB.Parameters[xAxisParameterIndex].globalParameter.chartCurretXRange;
                range.minValue = minXValue * coef;
                range.maxValue = maxXValue * coef;
            }
        }

        private void minMaxXValueTextBox_TextChanged(object sender, EventArgs e)
        {
            ReadMinMaxXValues();
            DrawChartAndTable();
        }

    }
}