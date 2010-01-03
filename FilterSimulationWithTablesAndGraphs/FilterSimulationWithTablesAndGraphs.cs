using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
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
                //if (sol.CurrentObjects.Serie != null)
                //{
                //    for (int i = 0; i < sol.CurrentObjects.Serie.SimulationsList.Count; i++)
                //    {
                //        if (sol.CurrentObjects.Serie.SimulationsList[i].Checked)
                //        {
                //            fmbList.Add(sol.CurrentObjects.Serie.SimulationsList[i].filterMachiningBlock);
                //        }
                //    }
                //}
                foreach (fmFilterSimulation sim in sol.GetAllSimulations())
                {
                    if (sim.Checked)
                    {
                        fmbList.Add(sim.filterMachiningBlock);
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
    }
}