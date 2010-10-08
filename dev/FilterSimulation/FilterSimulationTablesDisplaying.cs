using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FilterSimulation.fmFilterObjects;
using System.ComponentModel;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Blocks;
using fmCalculationLibrary.MeasureUnits;
using fmCalculationLibrary;

namespace FilterSimulation
{
    public partial class fmFilterSimulationControl
    {
        static void SetRowBackColor(DataGridViewRow row, Color col)
        {
            if (row.Cells[0].Style.BackColor != col)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = col;
                }
            }
        }

        static DataGridViewRow FindRowByGuid(DataGridViewRowCollection collection, Guid guid, int guidColumnIndex)
        {
            foreach (DataGridViewRow row in collection)
            {
                if (row.Cells[guidColumnIndex].Value != null && guid == (Guid)row.Cells[guidColumnIndex].Value)
                {
                    return row;
                }
            }

            DataGridViewCell currentCell = collection.Count > 0 ? collection[0].DataGridView.CurrentCell : null;
            int insertionIndex = (currentCell != null) ? currentCell.RowIndex + 1 : collection.Count;
            collection.Insert(insertionIndex, 1);
            return collection[insertionIndex];
        }

        static DataGridViewColumn FindColumnByGuid(DataGridViewColumnCollection collection, Guid guid, int guidRowIndex)
        {
            foreach (DataGridViewColumn col in collection)
            {
                DataGridViewCell cell = col.DataGridView.Rows[guidRowIndex].Cells[col.Index];
                if (cell != null
                    && cell.Value != null
                    && guid == (Guid)cell.Value)
                {
                    return col;
                }
            }

            var ret = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn { Visible = false };
            collection.Add(ret);
            ret.DataGridView.Rows[guidRowIndex].Cells[ret.Index].Value = guid;
            ret.Width = 60;

            return ret;
        }

        void HideExtraRows(DataGridView grid, int guidColumnIndex)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                object cellValue = row.Cells[guidColumnIndex].Value;
                if (cellValue != null)
                {
                    var guid = (Guid)cellValue;
                    if (m_fSolution.FindProject(guid) == null
                        && m_fSolution.FindSerie(guid) == null
                        && m_fSolution.FindSuspension(guid) == null
                        && m_fSolution.FindSimulation(guid) == null)
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        void HideExtraRowsInTables(bool project, bool suspension, bool simSeries, bool simulation)
        {
            if (project)
                HideExtraRows(projectDataGrid, projectGuidColumn.Index);
            if (suspension)
                HideExtraRows(suspensionDataGrid, suspensionGuidColumn.Index);
            if (simSeries)
                HideExtraRows(simSeriesDataGrid, simSeriesGuidColumn.Index);
            if (simulation)
                HideExtraRows(simulationDataGrid, simulationGuidColumn.Index);
        }

        void AddHideRowsForSolution(fmFilterSimSolution sol)
        {
            foreach (fmFilterSimProject prj in sol.projects)
            {
                AddHideRowsForProject(prj, true);
            }

            DataGridViewColumn liquidCol = m_fSolution.currentObjects.Simulation == null ? null : FindColumnByGuid(liquidDataGrid.Columns, m_fSolution.currentObjects.Simulation.Guid, 0);
            DataGridViewColumn epsKappaCol = m_fSolution.currentObjects.Simulation == null ? null : FindColumnByGuid(eps0Kappa0Pc0Rc0Alpha0DataGrid.Columns, m_fSolution.currentObjects.Simulation.Guid, 0);
            HideExtraMaterialColumns(liquidDataGrid, liquidCol);
            HideExtraMaterialColumns(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaCol);

            HideExtraRowsInTables(true, true, true, true);
        }
        void AddHideRowsForProject(fmFilterSimProject proj, bool visible)
        {
            DataGridViewRow row = FindRowByGuid(projectDataGrid.Rows, proj.Guid, projectGuidColumn.Index);
            row.Cells[projectGuidColumn.Index].Value = proj.Guid;
            row.Visible = visible;

            bool itIsCurrentProject = proj == m_fSolution.currentObjects.Project;

            foreach (fmFilterSimSuspension sus in proj.SuspensionList)
            {
                AddHideRowsForSuspension(sus, !m_byCheckingProjects ? (visible && proj.Checked) : itIsCurrentProject);
            }
        }
        void AddHideRowsForSuspension(fmFilterSimSuspension sus, bool visible)
        {
            DataGridViewRow row = FindRowByGuid(suspensionDataGrid.Rows, sus.Guid, suspensionGuidColumn.Index);
            row.Cells[suspensionGuidColumn.Index].Value = sus.Guid;
            row.Visible = visible;

            bool itIsCurrentSuspension = sus == m_fSolution.currentObjects.Suspension;

            foreach (fmFilterSimSerie serie in sus.SimSeriesList)
            {
                AddHideRowsForSerie(serie, !m_byCheckingSuspensions ? (visible && sus.Checked) : itIsCurrentSuspension);
            }
        }
        void AddHideRowsForSerie(fmFilterSimSerie serie, bool visible)
        {
            DataGridViewRow row = FindRowByGuid(simSeriesDataGrid.Rows, serie.Guid, simSeriesGuidColumn.Index);
            row.Cells[simSeriesGuidColumn.Index].Value = serie.Guid;
            row.Visible = visible;

            bool itIsCurrentSimSerie = serie == m_fSolution.currentObjects.Serie;

            foreach (fmFilterSimulation sim in serie.SimulationsList)
            {
                AddHideRowsForSimulation(sim, !m_byCheckingSimSeries ? (visible && serie.Checked) : itIsCurrentSimSerie);
            }
        }
        void AddHideRowsForSimulation(fmFilterSimulation sim, bool visible)
        {
            DataGridViewRow row = FindRowByGuid(simulationDataGrid.Rows, sim.Guid, simulationGuidColumn.Index);
            row.Cells[simulationGuidColumn.Index].Value = sim.Guid;
            row.Visible = visible;
            AddHideColumnsForMaterialParameters(sim);
        }
        void AddHideColumnsForMaterialParameters(fmFilterSimulation sim)
        {
            if (sim != null)
            {
                FindColumnByGuid(liquidDataGrid.Columns, sim.Guid, 0);
                FindColumnByGuid(eps0Kappa0Pc0Rc0Alpha0DataGrid.Columns, sim.Guid, 0);
            }
        }

        void WriteDataForSolution(fmFilterSimSolution sol)
        {
            foreach (DataGridViewRow row in projectDataGrid.Rows)
            {
                var guid = (Guid)row.Cells[projectGuidColumn.Index].Value;
                fmFilterSimProject proj = sol.FindProject(guid);
                if (proj == null) continue;

                row.Cells[projectCheckedColumn.Index].Value = proj.Checked;
                row.Cells[projectNameColumn.Index].Value = proj.Name;
            }

            foreach (DataGridViewRow row in suspensionDataGrid.Rows)
            {
                var guid = (Guid)row.Cells[suspensionGuidColumn.Index].Value;
                fmFilterSimSuspension sus = sol.FindSuspension(guid);
                if (sus == null) continue;

                row.Cells[suspensionCheckedColumn.Index].Value = sus.Checked;
                row.Cells[suspensionNameColumn.Index].Value = sus.Name;
                row.Cells[suspensionMaterialColumn.Index].Value = sus.Material;
                row.Cells[suspensionCustomerColumn.Index].Value = sus.Customer;
            }

            foreach (DataGridViewRow row in simSeriesDataGrid.Rows)
            {
                var guid = (Guid)row.Cells[simSeriesGuidColumn.Index].Value;
                fmFilterSimSerie serie = sol.FindSerie(guid);
                if (serie == null) continue;

                row.Cells[simSeriesCheckedColumn.Index].Value = serie.Checked;
                row.Cells[simSeriesNameColumn.Index].Value = serie.Name;
                row.Cells[simSeriesProjectColumn.Index].Value = serie.Parent.Parent.Name;
                row.Cells[simSeriesSuspensionNameColumn.Index].Value = serie.Parent.Material + " - " + serie.Parent.Customer + " - " + serie.Parent.Name;
                row.Cells[simSeriesFilterMediumColumn.Index].Value = serie.FilterMedium;
                row.Cells[simSeriesMachineTypeNameColumn.Index].Value = serie.MachineType.name;
                row.Cells[simSeriesMachineNameColumn.Index].Value = serie.MachineName;
                row.Cells[simSeriesLastModifiedDateColumn.Index].Value = Convert.ToString(serie.LastModifiedDate);
            }

            foreach (DataGridViewRow row in simulationDataGrid.Rows)
            {
                var guid = (Guid)row.Cells[simulationGuidColumn.Index].Value;
                fmFilterSimulation sim = sol.FindSimulation(guid);
                if (sim == null) continue;

                row.Cells[simulationCheckedColumn.Index].Value = sim.Checked;
                row.Cells[simulationProjectColumn.Index].Value = sim.Parent.Parent.Parent.Name;
                row.Cells[simulationSuspensionNameColumn.Index].Value = sim.Parent.Parent.Material + " - " + sim.Parent.Parent.Customer + " - " + sim.Parent.Parent.Name;
                row.Cells[simulationFilterMediumColumn.Index].Value = sim.Parent.FilterMedium;
                row.Cells[simulationMachineTypeColumn.Index].Value = sim.Parent.MachineType.name;
                row.Cells[simulationMachineNameColumn.Index].Value = sim.Parent.MachineName;
                row.Cells[simulationSimSeriesNameColumn.Index].Value = sim.Parent.Name;
                row.Cells[simulationNameColumn.Index].Value = sim.Name;

                sim.filterMachiningBlock.CalculateAndDisplay();
            }
        }

        void AssignNewCellsWithCalculationEngine(fmFilterSimSolution sol)
        {
            foreach (fmFilterSimulation sim in sol.GetAllSimulations())
            {
                DataGridViewColumn liquidCol = FindColumnByGuid(liquidDataGrid.Columns, sim.Guid, 0);
                if (sim.susBlock == null)
                {
                    sim.susBlock = new fmSuspensionWithEtafBlock(
                        FindRowByValueInColumn(liquidDataGrid, liquidParameterName.Index, "eta_f").Cells[liquidCol.Index],
                        FindRowByValueInColumn(liquidDataGrid, liquidParameterName.Index, "rho_f").Cells[liquidCol.Index],
                        FindRowByValueInColumn(liquidDataGrid, liquidParameterName.Index, "rho_s").Cells[liquidCol.Index],
                        FindRowByValueInColumn(liquidDataGrid, liquidParameterName.Index, "rho_sus").Cells[liquidCol.Index],
                        FindRowByValueInColumn(liquidDataGrid, liquidParameterName.Index, "Cm").Cells[liquidCol.Index],
                        FindRowByValueInColumn(liquidDataGrid, liquidParameterName.Index, "Cv").Cells[liquidCol.Index],
                        FindRowByValueInColumn(liquidDataGrid, liquidParameterName.Index, "C").Cells[liquidCol.Index]);

                    sim.susBlock.ValuesChanged += susBlock_ValuesChanged;
                    sim.susBlock.ValuesChangedByUser += susBlock_ValuesChangedByUser;
                }

                DataGridViewColumn epsKappaCol = FindColumnByGuid(eps0Kappa0Pc0Rc0Alpha0DataGrid.Columns, sim.Guid, 0);
                if (sim.eps0Kappa0Block == null)
                {
                    sim.eps0Kappa0Block = new fmEps0Kappa0WithneBlock(
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "eps0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "kappa0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "ne").Cells[epsKappaCol.Index]);

                    sim.eps0Kappa0Block.ValuesChanged += epsKappaBlock_ValuesChanged;
                    sim.eps0Kappa0Block.ValuesChangedByUser += eps0Kappa0Block_ValuesChangedByUser;
                }

                if (sim.pc0Rc0A0Block == null)
                {
                    sim.pc0Rc0A0Block = new fmPc0Rc0A0WithncBlock(
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "Pc0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "rc0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "a0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "nc").Cells[epsKappaCol.Index]);

                    sim.pc0Rc0A0Block.ValuesChanged += pcrcaBlock_ValuesChanged;
                    sim.pc0Rc0A0Block.ValuesChangedByUser += pc0rc0a0Block_ValuesChangedByUser;
                }

                if (sim.rm0HceBlock == null)
                {
                    sim.rm0HceBlock = new fmRm0HceBlock(
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "Rm0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "hce0").Cells[epsKappaCol.Index]);

                    sim.rm0HceBlock.ValuesChanged += rmHceBlock_ValuesChanged;
                    sim.rm0HceBlock.ValuesChangedByUser += rm0HceBlock_ValuesChangedByUser;
                }

                DataGridViewRow row = FindRowByGuid(simulationDataGrid.Rows, sim.Guid, simulationGuidColumn.Index);
                if (sim.filterMachiningBlock == null)
                {
                    sim.filterMachiningBlock = new fmFilterMachiningBlock(
                        row.Cells[simulationFilterAreaColumn.Index],
                        row.Cells[simulation_DpColumn.Index],
                        row.Cells[simulation_sfColumn.Index],
                        row.Cells[simulation_srColumn.Index],
                        row.Cells[simulation_nColumn.Index],
                        row.Cells[simulation_tcColumn.Index],
                        row.Cells[simulation_tfColumn.Index],
                        row.Cells[simulation_trColumn.Index],
                        row.Cells[simulation_hc_over_tfColumn.Index],
                        row.Cells[simulation_dhc_over_dtColumn.Index],
                        row.Cells[simulation_hcColumn.Index],
                        row.Cells[simulation_MfColumn.Index],
                        row.Cells[simulation_VfColumn.Index],
                        row.Cells[simulation_mf_Column.Index],
                        row.Cells[simulation_vf_Column.Index],
                        row.Cells[simulation_ms_Column.Index],
                        row.Cells[simulation_vs_Column.Index],
                        row.Cells[simulation_msus_Column.Index],
                        row.Cells[simulation_vsus_Column.Index],
                        row.Cells[simulation_mc_Column.Index],
                        row.Cells[simulation_vc_Column.Index],
                        row.Cells[simulation_MsusColumn.Index],
                        row.Cells[simulation_VsusColumn.Index],
                        row.Cells[simulation_VcColumn.Index],
                        row.Cells[simulation_McColumn.Index],
                        row.Cells[simulation_MsColumn.Index],
                        row.Cells[simulation_VsColumn.Index],
                        row.Cells[simulation_QfColumn.Index],
                        row.Cells[simulation_Qf_dColumn.Index],
                        row.Cells[simulation_QsColumn.Index],
                        row.Cells[simulation_Qs_dColumn.Index],
                        row.Cells[simulation_QcColumn.Index],
                        row.Cells[simulation_Qc_dColumn.Index],
                        row.Cells[simulation_QsusColumn.Index],
                        row.Cells[simulation_Qsus_dColumn.Index],
                        row.Cells[simulation_QmsusColumn.Index],
                        row.Cells[simulation_Qmsus_dColumn.Index],
                        row.Cells[simulation_QmsColumn.Index],
                        row.Cells[simulation_Qms_dColumn.Index],
                        row.Cells[simulation_QmfColumn.Index],
                        row.Cells[simulation_Qmf_dColumn.Index],
                        row.Cells[simulation_QmcColumn.Index],
                        row.Cells[simulation_Qmc_dColumn.Index],
                        row.Cells[simulation_qf_Column.Index],
                        row.Cells[simulation_qf_d_Column.Index],
                        row.Cells[simulation_qs_Column.Index],
                        row.Cells[simulation_qs_d_Column.Index],
                        row.Cells[simulation_qc_Column.Index],
                        row.Cells[simulation_qc_d_Column.Index],
                        row.Cells[simulation_qsus_Column.Index],
                        row.Cells[simulation_qsus_d_Column.Index],
                        row.Cells[simulation_qmsus_Column.Index],
                        row.Cells[simulation_qmsus_d_Column.Index],
                        row.Cells[simulation_qms_Column.Index],
                        row.Cells[simulation_qms_d_Column.Index],
                        row.Cells[simulation_qmf_Column.Index],
                        row.Cells[simulation_qmf_d_Column.Index],
                        row.Cells[simulation_qmc_Column.Index],
                        row.Cells[simulation_qmc_d_Column.Index],
                        row.Cells[simulation_epsColumn.Index],
                        row.Cells[simulation_kappaColumn.Index],
                        row.Cells[simulation_PcColumn.Index],
                        row.Cells[simulation_rcColumn.Index],
                        row.Cells[simulation_aColumn.Index]);

                    sim.filterMachiningBlock.ValuesChanged += filterMachiningBlock_ValuesChanged;
                }

                CopySimulationValuesToSusBlock(sim);
                CopySimulationValuesToEps0Kappa0neBlock(sim);
                CopySimulationValuesToPc0rc0a0ncBlock(sim);
                CopySimulationValuesToRmHceBlock(sim);
                CopySimulationValuesToFilterMachining(sim);

                if (sim == sol.currentObjects.Simulation)
                {
                    sim.filterMachiningBlock.CalculateAndDisplay();
                    sim.rm0HceBlock.CalculateAndDisplay();
                    sim.pc0Rc0A0Block.CalculateAndDisplay();
                    sim.eps0Kappa0Block.CalculateAndDisplay();
                    sim.susBlock.CalculateAndDisplay();
                }
            }
        }

        // ReSharper disable InconsistentNaming
        void rm0HceBlock_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in m_fSolution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == m_fSolution.currentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == m_fSolution.currentObjects.Simulation.Parent.Parent)
                    CopyBlockParameters(sim.rm0HceBlock, m_fSolution.currentObjects.Simulation.rm0HceBlock);
            displayingSolution = false;
        }

        // ReSharper disable InconsistentNaming
        void pc0rc0a0Block_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in m_fSolution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == m_fSolution.currentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == m_fSolution.currentObjects.Simulation.Parent.Parent)
                    CopyBlockParameters(sim.pc0Rc0A0Block, m_fSolution.currentObjects.Simulation.pc0Rc0A0Block);
            displayingSolution = false;
        }

// ReSharper disable InconsistentNaming
        void eps0Kappa0Block_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
// ReSharper restore InconsistentNaming
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in m_fSolution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == m_fSolution.currentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == m_fSolution.currentObjects.Simulation.Parent.Parent)
                    CopyBlockParameters(sim.eps0Kappa0Block, m_fSolution.currentObjects.Simulation.eps0Kappa0Block);
            displayingSolution = false;
        }

        static void CopyBlockParameters(fmBaseBlock dst, fmBaseBlock src)
        {
            src.DoCalculations();
            for (int parameterIndex = 0; parameterIndex < dst.Parameters.Count; ++parameterIndex)
            {
                dst.Parameters[parameterIndex].value = src.Parameters[parameterIndex].value;
            }
            dst.CalculateAndDisplay();
        }

// ReSharper disable InconsistentNaming
        void susBlock_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
// ReSharper restore InconsistentNaming
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in m_fSolution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == m_fSolution.currentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == m_fSolution.currentObjects.Simulation.Parent.Parent)
                    CopyBlockParameters(sim.susBlock, m_fSolution.currentObjects.Simulation.susBlock);
            displayingSolution = false;
        }

        private static void CopySimulationValuesToFilterMachining(fmFilterSimulation sim)
        {
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.filterMachiningBlock);
            if (sim.filterMachiningBlock.calculationOption != sim.FilterMachiningCalculationOption)
                sim.filterMachiningBlock.SetCalculationOptionAndUpdateCellsStyle(sim.FilterMachiningCalculationOption);
        }
        private static void CopySimulationValuesToRmHceBlock(fmFilterSimulation sim)
        {
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.rm0HceBlock);
        }
// ReSharper disable InconsistentNaming
        private static void CopySimulationValuesToPc0rc0a0ncBlock(fmFilterSimulation sim)
// ReSharper restore InconsistentNaming
        {
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.pc0Rc0A0Block);
        }
// ReSharper disable InconsistentNaming
        private static void CopySimulationValuesToEps0Kappa0neBlock(fmFilterSimulation sim)
// ReSharper restore InconsistentNaming
        {
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.eps0Kappa0Block);
        }

        private static void CopySimulationValuesToSusBlock(fmFilterSimulation sim)
        {
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.susBlock);
        }

        void UpdateColorsAndFontForSolution(fmFilterSimSolution sol)
        {
            foreach (DataGridViewRow row in projectDataGrid.Rows)
            {
                var guid = (Guid)row.Cells[projectGuidColumn.Index].Value;
                fmFilterSimProject proj = sol.FindProject(guid);
                if (proj != null)
                {
                    SetRowFontBoldOrRegular(row, proj.Modified ? FontStyle.Bold : FontStyle.Regular);
                }
            }

            foreach (DataGridViewRow row in suspensionDataGrid.Rows) if (row.Visible)
                {
                    var guid = (Guid)row.Cells[suspensionGuidColumn.Index].Value;
                    fmFilterSimSuspension sus = sol.FindSuspension(guid);

                    SetRowFontBoldOrRegular(row, sus.Modified ? FontStyle.Bold : FontStyle.Regular);
                }

            string prevVal = "";
            bool cID = false;

            foreach (DataGridViewRow row in simSeriesDataGrid.Rows) if (row.Visible)
                {
                    var guid = (Guid)row.Cells[simSeriesGuidColumn.Index].Value;
                    fmFilterSimSerie serie = sol.FindSerie(guid);

                    if (row.Cells[row.DataGridView.SortedColumn.Index].Value == null)
                    {
                        row.Cells[row.DataGridView.SortedColumn.Index].Value = "";
                    }

                    string val = row.Cells[row.DataGridView.SortedColumn.Index].Value.ToString();
                    cID ^= (prevVal == "" || prevVal != val);
                    prevVal = val;

                    Color rowColor = cID ? Color.White : Color.LightGray;
                    SetRowFontBoldOrRegular(row, serie.Modified ? FontStyle.Bold : FontStyle.Regular);
                    SetRowBackColor(row, rowColor);
                }

            prevVal = "";
            cID = false;
            foreach (DataGridViewRow row in simulationDataGrid.Rows) if (row.Visible)
                {
                    var guid = (Guid)row.Cells[simulationGuidColumn.Index].Value;
                    fmFilterSimulation sim = sol.FindSimulation(guid);

                    if (row.Cells[row.DataGridView.SortedColumn.Index].Value == null)
                    {
                        row.Cells[row.DataGridView.SortedColumn.Index].Value = new fmValue();
                    }

                    string val = row.Cells[row.DataGridView.SortedColumn.Index].Value.ToString();
                    cID ^= (prevVal == "" || prevVal != val);
                    prevVal = val;

                    SetRowFontBoldOrRegular(row, sim.Modified ? FontStyle.Bold : FontStyle.Regular);
                }
        }
        void SortTables()
        {
            m_sortingTables = true;
            simSeriesDataGrid.Sort(simSeriesDataGrid.SortedColumn, ListSortDirection.Ascending);
            simulationDataGrid.Sort(simulationDataGrid.SortedColumn, ListSortDirection.Ascending);
            m_sortingTables = false;
        }

        void SelectCurrentItemsInSolution(fmFilterSimSolution sol)
        {
            if (sol.currentObjects.Project != null)
            {
                foreach (DataGridViewRow row in projectDataGrid.Rows)
                    if (row.Visible)
                    {
                        var guid = (Guid)row.Cells[projectGuidColumn.Index].Value;
                        int colIndex = projectDataGrid.Columns[m_fSolution.currentColumns.project].Index;
                        if (guid == sol.currentObjects.Project.Guid)
                        {
                            if (row.Cells[colIndex].Visible)
                            {
                                projectDataGrid.CurrentCell = row.Cells[colIndex];
                            }
                        }
                    }
            }
            else
            {
                projectDataGrid.CurrentCell = null;
            }

            if (sol.currentObjects.Suspension != null)
            {
                foreach (DataGridViewRow row in suspensionDataGrid.Rows)
                    if (row.Visible)
                    {
                        var guid = (Guid)row.Cells[suspensionGuidColumn.Index].Value;
                        int colIndex = suspensionDataGrid.Columns[m_fSolution.currentColumns.suspension].Index;
                        if (guid == sol.currentObjects.Suspension.Guid)
                        {
                            if (row.Cells[colIndex].Visible)
                            {
                                suspensionDataGrid.CurrentCell = row.Cells[colIndex];
                            }
                        }
                    }
            }
            else
            {
                suspensionDataGrid.CurrentCell = null;
            }

            if (sol.currentObjects.Serie != null)
            {
                foreach (DataGridViewRow row in simSeriesDataGrid.Rows)
                    if (row.Visible)
                    {
                        var guid = (Guid)row.Cells[simSeriesGuidColumn.Index].Value;
                        int colIndex = simSeriesDataGrid.Columns[m_fSolution.currentColumns.simSerie].Index;
                        if (guid == sol.currentObjects.Serie.Guid)
                        {
                            simSeriesDataGrid.CurrentCell = row.Cells[colIndex];
                        }
                    }

                foreach (DataGridViewRow row in machineTypesDataGrid.Rows)
                    if (row.Visible)
                    {
                        string mName = sol.currentObjects.Serie.MachineType.name;
                        int colIndex = machineTypesDataGrid.Columns[machineTypeNameColumn.Index].Index;
                        if (mName == row.Cells[colIndex].Value.ToString())
                        {
                            machineTypesDataGrid.CurrentCell = row.Cells[colIndex];
                        }
                    }
            }
            else
            {
                simSeriesDataGrid.CurrentCell = null;
            }

            if (sol.currentObjects.Simulation != null)
            {
                foreach (DataGridViewRow row in simulationDataGrid.Rows)
                    if (row.Visible)
                    {
                        var guid = (Guid)row.Cells[simulationGuidColumn.Index].Value;
                        int colIndex = simulationDataGrid.Columns[m_fSolution.currentColumns.simulation].Index;
                        if (guid == sol.currentObjects.Simulation.Guid)
                        {
                            if (row.Cells[colIndex].Visible)
                            {
                                simulationDataGrid.CurrentCell = row.Cells[colIndex];
                            }
                        }
                    }
            }
            else
            {
                simulationDataGrid.CurrentCell = null;
            }
        }

        /* Adds and hides rows in all tables
         * Writes Data to cells of the table
         * Changes color of rows
         * Changes font of rows
         * */
        virtual protected void DisplaySolution(fmFilterSimSolution sol)
        {
            if (displayingSolution == false)
            {
                displayingSolution = true;

                AddHideRowsForSolution(sol);
                AssignNewCellsWithCalculationEngine(sol);
                WriteDataForSolution(sol);

                UpdateColorsAndFontForSolution(sol);
                SelectCurrentItemsInSolution(sol);

                CopySimToCommonFilterMachiningBlock(sol.currentObjects.Simulation);

                ShowHideSelectedParametersInSimulationDataGrid();

                displayingSolution = false;
            }
        }

        private void ShowHideSelectedParametersInSimulationDataGrid()
        {
            foreach (DataGridViewColumn col in simulationDataGrid.Columns)
            {
                string pName = GetParameterNameFromHeader(col.HeaderText);
                if (fmGlobalParameter.parametersByName.ContainsKey(pName))
                {
                    var p = fmGlobalParameter.parametersByName[pName];
                    col.Visible = parametersToDisplay.Contains(p);
                }
            }
        }

        protected static string GetParameterNameFromHeader(string headerText)
        {
            string[] s = headerText.Split('(');
            return s[0].Trim();
        }

        private void CopySimToCommonFilterMachiningBlock(fmFilterSimulation sim)
        {
            if (sim != null)
            {
                if (m_commonFilterMachiningBlock == null)
                {
                    InitCommonFilterMachiningBlock();
                }

                if (m_commonFilterMachiningBlock != null)
                {
                    m_commonFilterMachiningBlock.SetCalculationOptionAndUpdateCellsStyle(sim.filterMachiningBlock.calculationOption);

                    for (int i = 0; i < m_commonFilterMachiningBlock.Parameters.Count; ++i)
                    {
                        commonCalcBlockDataGrid.Rows[i].Visible = m_commonFilterMachiningBlock.Parameters[i].group != null
                            && parametersToDisplay.Contains(m_commonFilterMachiningBlock.Parameters[i].globalParameter);
                    }

                    for (int i = 0; i < m_commonFilterMachiningBlock.ConstantParameters.Count; ++i)
                    {
                        m_commonFilterMachiningBlock.ConstantParameters[i].value = sim.filterMachiningBlock.ConstantParameters[i].value;
                    }
                    for (int i = 0; i < m_commonFilterMachiningBlock.Parameters.Count; ++i)
                    {
                        m_commonFilterMachiningBlock.Parameters[i].value = sim.filterMachiningBlock.Parameters[i].value;
                        m_commonFilterMachiningBlock.Parameters[i].IsInputed = sim.filterMachiningBlock.Parameters[i].IsInputed;
                    }
                    m_commonFilterMachiningBlock.CalculateAndDisplay();
                }
            }
        }

        private void InitCommonFilterMachiningBlock()
        {
            var voidBlock = new fmFilterMachiningBlock();
            commonCalcBlockDataGrid.RowCount = voidBlock.Parameters.Count;
            var parToCell = new Dictionary<fmGlobalParameter, DataGridViewCell>();
            for (int i = 0; i < voidBlock.Parameters.Count; ++i)
            {
                commonCalcBlockDataGrid[commonCalcBlockParameterNameColumn.Index, i].Value = voidBlock.Parameters[i].globalParameter.name;
                parToCell[voidBlock.Parameters[i].globalParameter] = commonCalcBlockDataGrid[commonCalcBlockParameterValueColumn.Index, i];
            }

            m_commonFilterMachiningBlock = new fmFilterMachiningBlockWithLimits();
            foreach (var p in m_commonFilterMachiningBlock.Parameters)
            {
                m_commonFilterMachiningBlock.AssignCell(p, parToCell[p.globalParameter]);
            }

            m_commonFilterMachiningBlock.ValuesChangedByUser += commonFilterMachiningBlock_ValuesChangedByUser;

            UpdateUnitsOfCommonFilterMachiningBlock();
        }

// ReSharper disable InconsistentNaming
        void commonFilterMachiningBlock_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
// ReSharper restore InconsistentNaming
        {
            foreach (fmBlockVariableParameter p in m_commonFilterMachiningBlock.Parameters)
            {
                fmBlockVariableParameter p2 = m_fSolution.currentObjects.Simulation.filterMachiningBlock.GetParameterByName(p.globalParameter.name);
                p2.value = p.value;
                p2.IsInputed = p.IsInputed;
            }

            m_fSolution.currentObjects.Simulation.filterMachiningBlock.CalculateAndDisplay();
        }

        static void HideExtraMaterialColumns(DataGridView dataGrid, DataGridViewColumn columnToLeave)
        {
            int rowIndex = dataGrid.CurrentCell == null ? -1 : dataGrid.CurrentCell.RowIndex;

            for (int i = 2; i < dataGrid.ColumnCount; ++i)
            {
                if (dataGrid.Columns[i] != columnToLeave)
                {
                    dataGrid.Columns[i].Visible = false;
                }
            }

            for (int i = 2; i < dataGrid.ColumnCount; ++i)
            {
                if (dataGrid.Columns[i] == columnToLeave)
                {
                    dataGrid.Columns[i].Visible = true;
                    dataGrid.CurrentCell = rowIndex == -1 ? null : dataGrid.Rows[rowIndex].Cells[i];
                }
            }
        }

        static void WriteUnitToHeader(DataGridViewCell cell, fmUnitFamily unitFamily)
        {
            string parName = cell.Value.ToString().Split('(')[0];
            for (int i = parName.Length - 1; ; --i)
            {
                if (i < 0 || parName[i] != ' ')
                {
                    parName = parName.Substring(0, i + 1);
                    break;
                }
            }
            cell.Value = parName + " (" + unitFamily.CurrentUnit.Name + ")";
        }

        static void WriteUnitsToTable(DataGridView dg, int parameterColumnNameIndex, string parameterName, int unitColumnNameIndex, fmUnitFamily unitFamily)
        {
            FindRowByValueInColumn(dg, parameterColumnNameIndex, parameterName).Cells[unitColumnNameIndex].Value = unitFamily.CurrentUnit.Name;
        }

        static DataGridViewRow FindRowByValueInColumn(DataGridView dg, int columnIndex, string stringValue)
        {
            foreach (DataGridViewRow row in dg.Rows)
            {
                object value = row.Cells[columnIndex].Value;
                if (value != null && value.ToString() == stringValue)
                    return row;
            }
            return null;
        }

        virtual protected void UpdateUnitsAndData()
        {
            StopAllBlockProcessing();
            {
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, "eta_f", liquidParameterUnits.Index, fmGlobalParameter.eta_f.unitFamily);
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, "rho_f", liquidParameterUnits.Index, fmGlobalParameter.rho_f.unitFamily);
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, "rho_s", liquidParameterUnits.Index, fmGlobalParameter.rho_s.unitFamily);
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, "rho_sus", liquidParameterUnits.Index, fmGlobalParameter.rho_sus.unitFamily);
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, "Cm", liquidParameterUnits.Index, fmGlobalParameter.Cm.unitFamily);
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, "Cv", liquidParameterUnits.Index, fmGlobalParameter.Cv.unitFamily);
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, "C", liquidParameterUnits.Index, fmGlobalParameter.C.unitFamily);

                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "eps0", epsKappaUnits.Index, fmGlobalParameter.eps.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "kappa0", epsKappaUnits.Index, fmGlobalParameter.kappa.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "ne", epsKappaUnits.Index, fmGlobalParameter.ne.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "Pc0", epsKappaUnits.Index, fmGlobalParameter.Pc.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "rc0", epsKappaUnits.Index, fmGlobalParameter.rc.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "a0", epsKappaUnits.Index, fmGlobalParameter.a.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "nc", epsKappaUnits.Index, fmGlobalParameter.nc.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "Rm0", epsKappaUnits.Index, fmGlobalParameter.Rm.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "hce0", epsKappaUnits.Index, fmGlobalParameter.hce0.unitFamily);

                WriteUnitToHeader(simulationDataGrid.Columns[simulationFilterAreaColumn.Index].HeaderCell, fmGlobalParameter.A.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_DpColumn.Index].HeaderCell, fmGlobalParameter.Dp.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_nColumn.Index].HeaderCell, fmGlobalParameter.n.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_tcColumn.Index].HeaderCell, fmGlobalParameter.tc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_tfColumn.Index].HeaderCell, fmGlobalParameter.tf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_trColumn.Index].HeaderCell, fmGlobalParameter.tr.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_hc_over_tfColumn.Index].HeaderCell, fmGlobalParameter.hc_over_tf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_dhc_over_dtColumn.Index].HeaderCell, fmGlobalParameter.dhc_over_dt.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_hcColumn.Index].HeaderCell, fmGlobalParameter.hc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_MfColumn.Index].HeaderCell, fmGlobalParameter.Mf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_VfColumn.Index].HeaderCell, fmGlobalParameter.Vf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_mf_Column.Index].HeaderCell, fmGlobalParameter.mf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_vf_Column.Index].HeaderCell, fmGlobalParameter.vf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_ms_Column.Index].HeaderCell, fmGlobalParameter.ms.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_vs_Column.Index].HeaderCell, fmGlobalParameter.vs.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_msus_Column.Index].HeaderCell, fmGlobalParameter.msus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_vsus_Column.Index].HeaderCell, fmGlobalParameter.vsus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_mc_Column.Index].HeaderCell, fmGlobalParameter.mc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_vc_Column.Index].HeaderCell, fmGlobalParameter.vc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_MsusColumn.Index].HeaderCell, fmGlobalParameter.Msus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_VsusColumn.Index].HeaderCell, fmGlobalParameter.Vsus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_VsColumn.Index].HeaderCell, fmGlobalParameter.Vs.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_VcColumn.Index].HeaderCell, fmGlobalParameter.Vc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_McColumn.Index].HeaderCell, fmGlobalParameter.Mc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_MsColumn.Index].HeaderCell, fmGlobalParameter.Ms.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QfColumn.Index].HeaderCell, fmGlobalParameter.Qf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qf_dColumn.Index].HeaderCell, fmGlobalParameter.Qf_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qs_dColumn.Index].HeaderCell, fmGlobalParameter.Qs_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qc_dColumn.Index].HeaderCell, fmGlobalParameter.Qc_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qsus_dColumn.Index].HeaderCell, fmGlobalParameter.Qsus_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QsColumn.Index].HeaderCell, fmGlobalParameter.Qs.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QcColumn.Index].HeaderCell, fmGlobalParameter.Qc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QsusColumn.Index].HeaderCell, fmGlobalParameter.Qsus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QmsusColumn.Index].HeaderCell, fmGlobalParameter.Qmsus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qmsus_dColumn.Index].HeaderCell, fmGlobalParameter.Qmsus_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QmsColumn.Index].HeaderCell, fmGlobalParameter.Qms.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qms_dColumn.Index].HeaderCell, fmGlobalParameter.Qms_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QmfColumn.Index].HeaderCell, fmGlobalParameter.Qmf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qmf_dColumn.Index].HeaderCell, fmGlobalParameter.Qmf_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QmcColumn.Index].HeaderCell, fmGlobalParameter.Qmc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qmc_dColumn.Index].HeaderCell, fmGlobalParameter.Qmc_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qf_Column.Index].HeaderCell, fmGlobalParameter.qf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qf_d_Column.Index].HeaderCell, fmGlobalParameter.qf_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qs_d_Column.Index].HeaderCell, fmGlobalParameter.qs_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qc_d_Column.Index].HeaderCell, fmGlobalParameter.qc_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qsus_d_Column.Index].HeaderCell, fmGlobalParameter.qsus_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qs_Column.Index].HeaderCell, fmGlobalParameter.qs.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qc_Column.Index].HeaderCell, fmGlobalParameter.qc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qsus_Column.Index].HeaderCell, fmGlobalParameter.qsus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qmsus_Column.Index].HeaderCell, fmGlobalParameter.qmsus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qmsus_d_Column.Index].HeaderCell, fmGlobalParameter.qmsus_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qms_Column.Index].HeaderCell, fmGlobalParameter.qms.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qms_d_Column.Index].HeaderCell, fmGlobalParameter.qms_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qmf_Column.Index].HeaderCell, fmGlobalParameter.qmf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qmf_d_Column.Index].HeaderCell, fmGlobalParameter.qmf_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qmc_Column.Index].HeaderCell, fmGlobalParameter.qmc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qmc_d_Column.Index].HeaderCell, fmGlobalParameter.qmc_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_sfColumn.Index].HeaderCell, fmGlobalParameter.sf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_srColumn.Index].HeaderCell, fmGlobalParameter.sr.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_epsColumn.Index].HeaderCell, fmGlobalParameter.eps.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_kappaColumn.Index].HeaderCell, fmGlobalParameter.kappa.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_PcColumn.Index].HeaderCell, fmGlobalParameter.Pc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_rcColumn.Index].HeaderCell, fmGlobalParameter.rc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_aColumn.Index].HeaderCell, fmGlobalParameter.a.unitFamily);

                UpdateUnitsOfCommonFilterMachiningBlock();
            }
            ResumeAllBlockProcessing();
            RewriteDataForAllBlocks();
        }

        private void UpdateUnitsOfCommonFilterMachiningBlock()
        {
            if (m_commonFilterMachiningBlock != null)
            {
                for (int i = 0; i < m_commonFilterMachiningBlock.Parameters.Count; ++i)
                {
                    commonCalcBlockDataGrid[commonCalcBlockUnitColumn.Index, i].Value = m_commonFilterMachiningBlock.Parameters[i].globalParameter.UnitName;
                }
            }
        }

        private void RewriteDataForAllBlocks()
        {
            foreach (fmFilterSimulation sim in m_fSolution.GetAllSimulations())
            {
                sim.susBlock.CalculateAndDisplay();
                sim.eps0Kappa0Block.CalculateAndDisplay();
                sim.filterMachiningBlock.CalculateAndDisplay();
                sim.pc0Rc0A0Block.CalculateAndDisplay();
                sim.rm0HceBlock.CalculateAndDisplay();
            }
        }

        private void ResumeAllBlockProcessing()
        {
            foreach (fmFilterSimulation sim in m_fSolution.GetAllSimulations())
            {
                sim.susBlock.ResumeProcessing();
                sim.eps0Kappa0Block.ResumeProcessing();
                sim.filterMachiningBlock.ResumeProcessing();
                sim.pc0Rc0A0Block.ResumeProcessing();
                sim.rm0HceBlock.ResumeProcessing();
            }
        }

        private void StopAllBlockProcessing()
        {
            foreach (fmFilterSimulation sim in m_fSolution.GetAllSimulations())
            {
                sim.susBlock.StopProcessing();
                sim.eps0Kappa0Block.StopProcessing();
                sim.filterMachiningBlock.StopProcessing();
                sim.pc0Rc0A0Block.StopProcessing();
                sim.rm0HceBlock.StopProcessing();
            }
        }

// ReSharper disable InconsistentNaming
        void susBlock_ValuesChanged(object sender)
// ReSharper restore InconsistentNaming
        {
            var susBlock = sender as fmSuspensionWithEtafBlock;
            fmFilterSimulation sim = m_fSolution.FindSimulation(susBlock);

            if (sim == null) // when we keep or restore simulations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                if (susBlock != null)
                {
                    liquidDataGrid.CellValueChanged -= susBlock.CellValueChanged;
                    susBlock.ValuesChanged -= susBlock_ValuesChanged;
                }
                return;
            }
            fmFilterSimulation.CopyAllParametersFromBlockToSimulation(sim.susBlock, sim);
            sim.Data.suspensionCalculationOption = sim.susBlock.calculationOption;

            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.eps0Kappa0Block);

            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.pc0Rc0A0Block);

            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.filterMachiningBlock);

            sim.eps0Kappa0Block.CalculateAndDisplay();
        }

        // ReSharper disable InconsistentNaming
        void epsKappaBlock_ValuesChanged(object sender)
        // ReSharper restore InconsistentNaming
        {
            var epsKappaBlock = sender as fmEps0Kappa0Block;
            fmFilterSimulation sim = m_fSolution.FindSimulation(epsKappaBlock);

            if (sim == null) // when we keep or restore simukations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                if (epsKappaBlock != null)
                {
                    eps0Kappa0Pc0Rc0Alpha0DataGrid.CellValueChanged -= epsKappaBlock.CellValueChanged;
                    epsKappaBlock.ValuesChanged -= epsKappaBlock_ValuesChanged;
                }
                return;
            }
            fmFilterSimulation.CopyAllParametersFromBlockToSimulation(sim.eps0Kappa0Block, sim);
            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.pc0Rc0A0Block);
            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.filterMachiningBlock);
            sim.pc0Rc0A0Block.CalculateAndDisplay();
        }
// ReSharper disable InconsistentNaming
        void rmHceBlock_ValuesChanged(object sender)
// ReSharper restore InconsistentNaming
        {
            var rmHceBlock = sender as fmRm0HceBlock;
            fmFilterSimulation sim = m_fSolution.FindSimulation(rmHceBlock);

            if (sim == null) // when we keep or restore simukations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                if (rmHceBlock != null)
                {
                    eps0Kappa0Pc0Rc0Alpha0DataGrid.CellValueChanged -= rmHceBlock.CellValueChanged;
                    rmHceBlock.ValuesChanged -= rmHceBlock_ValuesChanged;
                }
                return;
            }
            fmFilterSimulation.CopyAllParametersFromBlockToSimulation(sim.rm0HceBlock, sim);
            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.filterMachiningBlock);
            sim.filterMachiningBlock.CalculateAndDisplay();
        }
        // ReSharper disable InconsistentNaming
        void pcrcaBlock_ValuesChanged(object sender)
        // ReSharper restore InconsistentNaming
        {
            var pcrcaBlock = sender as fmPc0Rc0A0Block;
            fmFilterSimulation sim = m_fSolution.FindSimulation(pcrcaBlock);

            if (sim == null) // when we keep or restore simukations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                if (pcrcaBlock != null)
                {
                    eps0Kappa0Pc0Rc0Alpha0DataGrid.CellValueChanged -= pcrcaBlock.CellValueChanged;
                    pcrcaBlock.ValuesChanged -= pcrcaBlock_ValuesChanged;
                }
                return;
            }
            fmFilterSimulation.CopyAllParametersFromBlockToSimulation(sim.pc0Rc0A0Block, sim);
            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.rm0HceBlock);
            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.filterMachiningBlock);
            sim.rm0HceBlock.CalculateAndDisplay();
        }

        // ReSharper disable InconsistentNaming
        void filterMachiningBlock_ValuesChanged(object sender)
        // ReSharper restore InconsistentNaming
        {
            var filterMachiningBlock = sender as fmFilterMachiningBlock;
            fmFilterSimulation sim = m_fSolution.FindSimulation(filterMachiningBlock);

            if (sim == null) // when we keep or restore simukations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                if (filterMachiningBlock != null)
                {
                    simulationDataGrid.CellValueChanged -= filterMachiningBlock.CellValueChanged;
                    filterMachiningBlock.ValuesChanged -= filterMachiningBlock_ValuesChanged;
                }
                return;
            }

            if (filterMachiningBlock != null)
            {
                sim.FilterMachiningCalculationOption = filterMachiningBlock.calculationOption;
                fmFilterSimulation.CopyAllParametersFromBlockToSimulation(filterMachiningBlock, sim);
            }

            DisplaySolution(m_fSolution);
        }
    }
}