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
using fmCalculatorsLibrary;

namespace FilterSimulation
{
    public partial class fmFilterSimulationControl
    {
        public static void SetRowBackColor(DataGridViewRow row, Color col)
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
            HideExtraMaterialColumns(liquidDataGrid, liquidCol);
            DataGridViewColumn epsKappaCol = m_fSolution.currentObjects.Simulation == null ? null : FindColumnByGuid(eps0Kappa0Pc0Rc0Alpha0DataGrid.Columns, m_fSolution.currentObjects.Simulation.Guid, 0);
            HideExtraMaterialColumns(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaCol);
            DataGridViewColumn deliqMaterialCol = m_fSolution.currentObjects.Simulation == null ? null : FindColumnByGuid(deliquoringMaterialParametersDataGrid.Columns, m_fSolution.currentObjects.Simulation.Guid, 0);
            HideExtraMaterialColumns(deliquoringMaterialParametersDataGrid, deliqMaterialCol);

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
                FindColumnByGuid(deliquoringMaterialParametersDataGrid.Columns, sim.Guid, 0);
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

                DataGridViewColumn deliquoringMaterialCol = FindColumnByGuid(deliquoringMaterialParametersDataGrid.Columns, sim.Guid, 0);
                if (sim.deliquoringEps0NeEpsBlock == null)
                {
                    sim.deliquoringEps0NeEpsBlock = new fmEps0dNedEpsdBlock(
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.Dp_d.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.hcd.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.eps_d.name).Cells[deliquoringMaterialCol.Index]);

                    sim.deliquoringEps0NeEpsBlock.ValuesChanged += deliquoringEps0dNedEpsdBlock_ValuesChanged;
                    sim.deliquoringEps0NeEpsBlock.ValuesChangedByUser += deliquoringEps0dNedEpsdBlock_ValuesChangedByUser;
                }
                if (sim.deliquoringSigmaPkeBlock == null)
                {
                    sim.deliquoringSigmaPkeBlock = new fmSigmaPke0PkePcdRcdAlphadBlock(
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.eta_d.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.rho_d.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.sigma.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.pke0.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.pke.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.pc_d.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.rc_d.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.alpha_d.name).Cells[deliquoringMaterialCol.Index]);


                    sim.deliquoringSigmaPkeBlock.ValuesChanged += deliquoringSigmaPkeBlock_ValuesChanged;
                    sim.deliquoringSigmaPkeBlock.ValuesChangedByUser += deliquoringSigmaPkeBlock_ValuesChangedByUser;
                }
                if (sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock == null)
                {
                    sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock = new fmSremTettaAdAgDHRmMmoleFPeqBlock(
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.Srem.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.ad1.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.ad2.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.Tetta.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.eta_g.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.ag1.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.ag2.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.ag3.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.Tetta_boil.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.DH.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.Mmole.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.f.name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.peq.name).Cells[deliquoringMaterialCol.Index]);


                    sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock.ValuesChanged += deliquoringSremTettaAdAgDHMmoleFPeqBlock_ValuesChanged;
                    sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock.ValuesChangedByUser += deliquoringSremTettaAdAgDHMmoleFPeqBlock_ValuesChangedByUser;
                }

                DataGridViewRow row = FindRowByGuid(simulationDataGrid.Rows, sim.Guid, simulationGuidColumn.Index);
                if (sim.filterMachiningBlock == null)
                {
                    sim.filterMachiningBlock = new fmFilterMachiningBlock(
                        row.Cells[simulationFilterAreaColumn.Index],
                        row.Cells[simulationFilterDiameterColumn.Index],
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
                CopySimulationValuesToDeliquoringEps0dNedEpsdBlock(sim);
                CopySimulationValuesToDeliquoringSigmaBlock(sim);
                CopySimulationValuesToDeliquoringSremBlock(sim);

                if (sim == sol.currentObjects.Simulation)
                {
                    sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock.CalculateAndDisplay();
                    sim.deliquoringSigmaPkeBlock.CalculateAndDisplay();
                    sim.deliquoringEps0NeEpsBlock.CalculateAndDisplay();
                    sim.filterMachiningBlock.CalculateAndDisplay();
                    sim.rm0HceBlock.CalculateAndDisplay();
                    sim.pc0Rc0A0Block.CalculateAndDisplay();
                    sim.eps0Kappa0Block.CalculateAndDisplay();
                    sim.susBlock.CalculateAndDisplay();
                }
            }
        }

        private void CopySimulationValuesToDeliquoringSremBlock(fmFilterSimulation sim)
        {
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock);
        }

        private void CopySimulationValuesToDeliquoringSigmaBlock(fmFilterSimulation sim)
        {
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.deliquoringSigmaPkeBlock);
        }

        private void CopySimulationValuesToDeliquoringEps0dNedEpsdBlock(fmFilterSimulation sim)
        {
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.deliquoringEps0NeEpsBlock);
        }

        // ReSharper disable InconsistentNaming
        void deliquoringSremTettaAdAgDHMmoleFPeqBlock_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in m_fSolution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == m_fSolution.currentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == m_fSolution.currentObjects.Simulation.Parent.Parent)
                    CopyBlockParameters(sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock, m_fSolution.currentObjects.Simulation.deliquoringSremTettaAdAgDHMmoleFPeqBlock);
            displayingSolution = false;
        }

        // ReSharper disable InconsistentNaming
        void deliquoringSigmaPkeBlock_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in m_fSolution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == m_fSolution.currentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == m_fSolution.currentObjects.Simulation.Parent.Parent)
                    CopyBlockParameters(sim.deliquoringSigmaPkeBlock, m_fSolution.currentObjects.Simulation.deliquoringSigmaPkeBlock);
            displayingSolution = false;
        }

        // ReSharper disable InconsistentNaming
        void deliquoringEps0dNedEpsdBlock_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in m_fSolution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == m_fSolution.currentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == m_fSolution.currentObjects.Simulation.Parent.Parent)
                    CopyBlockParameters(sim.deliquoringEps0NeEpsBlock, m_fSolution.currentObjects.Simulation.deliquoringEps0NeEpsBlock);
            displayingSolution = false;
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
                CopySimToCommonDeliquoringSimulationBlock(sol.currentObjects.Simulation);

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

        private void CopySimToCommonDeliquoringSimulationBlock(fmFilterSimulation sim)
        {
            if (sim != null)
            {
                if (m_commonDeliquoringSimulationBlock == null)
                {
                    InitCommonDeliquoringSimulationBlock();
                }

                if (m_commonDeliquoringSimulationBlock != null)
                {
                    //m_commonDeliquoringSimulationBlock.SetCalculationOptionAndUpdateCellsStyle(sim.filterMachiningBlock.calculationOption);

                    //for (int i = 0; i < m_commonDeliquoringSimulationBlock.Parameters.Count; ++i)
                    //{
                    //    commonDeliquoringSimulationBlockDataGrid.Rows[i].Visible = m_commonDeliquoringSimulationBlock.Parameters[i].group != null
                    //        && parametersToDisplay.Contains(m_commonDeliquoringSimulationBlock.Parameters[i].globalParameter);
                    //}

                    for (int i = 0; i < m_commonDeliquoringSimulationBlock.ConstantParameters.Count; ++i)
                    {
                        fmBlockConstantParameter par = m_commonDeliquoringSimulationBlock.ConstantParameters[i];
                        par.value = sim.Parameters[par.globalParameter].value;
                    }
                    for (int i = 0; i < m_commonDeliquoringSimulationBlock.Parameters.Count; ++i)
                    {
                        fmBlockVariableParameter par = m_commonDeliquoringSimulationBlock.Parameters[i];
                        par.value = sim.Parameters[par.globalParameter].value;
                        par.isInputed = (sim.Parameters[par.globalParameter] as fmCalculationVariableParameter).isInputed;
                    }
                    m_commonDeliquoringSimulationBlock.CalculateAndDisplay();
                }
            }
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


        private void InitCommonDeliquoringSimulationBlock()
        {
            var voidBlock = new fmDeliquoringSimualtionBlock();
            commonDeliquoringSimulationBlockDataGrid.RowCount = voidBlock.Parameters.Count;
            var parToCell = new Dictionary<fmGlobalParameter, DataGridViewCell>();
            for (int i = 0; i < voidBlock.Parameters.Count; ++i)
            {
                commonDeliquoringSimulationBlockDataGrid[commonDeliquoringSimulationBlockParameterNameColumn.Index, i].Value = voidBlock.Parameters[i].globalParameter.name;
                parToCell[voidBlock.Parameters[i].globalParameter] = commonDeliquoringSimulationBlockDataGrid[commonDeliquoringSimulationBlockParameterValueColumn.Index, i];
            }

            m_commonDeliquoringSimulationBlock = new fmDeliquoringSimualtionBlockWithLimits();
            foreach (var p in m_commonDeliquoringSimulationBlock.Parameters)
            {
                m_commonDeliquoringSimulationBlock.AssignCell(p, parToCell[p.globalParameter]);
            }
            m_commonDeliquoringSimulationBlock.UpdateCellsStyle();

            m_commonDeliquoringSimulationBlock.ValuesChangedByUser += commonDeliquoringSimulationBlock_ValuesChangedByUser;

            UpdateUnitsOfCommonDeliquoringSimulationBlock();
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
        void commonDeliquoringSimulationBlock_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
// ReSharper restore InconsistentNaming
        {
            foreach (fmBlockVariableParameter p in m_commonDeliquoringSimulationBlock.Parameters)
            {
                fmCalculationVariableParameter p2 = m_fSolution.currentObjects.Simulation.Parameters[p.globalParameter] as fmCalculationVariableParameter;
                p2.value = p.value;
                p2.isInputed = p.IsInputed;
            }

            //m_fSolution.currentObjects.Simulation.filterMachiningBlock.CalculateAndDisplay();
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

        static void WriteUnitToHeader(DataGridView dg)
        {
            foreach (DataGridViewColumn col in dg.Columns)
            {
                object obj = col.HeaderCell.Value;
                if (obj != null)
                {
                    string parName = obj.ToString().Split('(')[0].Trim();
                    if (fmGlobalParameter.parametersByName.ContainsKey(parName))
                    {
                        fmGlobalParameter p = fmGlobalParameter.parametersByName[parName];
                        col.HeaderCell.Value = p.name + " (" + p.unitFamily.CurrentUnit.Name + ")";
                    }
                }
            }
        }

        static void WriteUnitsToTable(DataGridView dg, int parameterColumnNameIndex, int unitColumnNameIndex)
        {
            foreach (DataGridViewRow row in dg.Rows)
            {
                object obj = row.Cells[parameterColumnNameIndex].Value;
                if (obj != null)
                {
                    fmGlobalParameter p = fmGlobalParameter.parametersByName[obj.ToString()];
                    if (p != null)
                    {
                        row.Cells[unitColumnNameIndex].Value = p.unitFamily.CurrentUnit.Name;
                    }
                }
            }
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
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, liquidParameterUnits.Index);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, epsKappaUnits.Index);
                WriteUnitsToTable(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, deliquoringMaterialParametersUnitsColumn.Index);
                WriteUnitToHeader(simulationDataGrid);
                
                UpdateUnitsOfCommonFilterMachiningBlock();
            }
            ResumeAllBlockProcessing();
            RewriteDataForAllBlocks();
        }

        private void UpdateUnitsOfCommonDeliquoringSimulationBlock()
        {
            if (m_commonDeliquoringSimulationBlock != null)
            {
                for (int i = 0; i < m_commonDeliquoringSimulationBlock.Parameters.Count; ++i)
                {
                    commonDeliquoringSimulationBlockDataGrid[commonDeliquoringSimulationBlockUnitColumn.Index, i].Value = m_commonDeliquoringSimulationBlock.Parameters[i].globalParameter.UnitName;
                }
            }
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
                sim.deliquoringEps0NeEpsBlock.CalculateAndDisplay();
                sim.deliquoringSigmaPkeBlock.CalculateAndDisplay();
                sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock.CalculateAndDisplay();
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
                sim.deliquoringEps0NeEpsBlock.ResumeProcessing();
                sim.deliquoringSigmaPkeBlock.ResumeProcessing();
                sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock.ResumeProcessing();
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
                sim.deliquoringEps0NeEpsBlock.StopProcessing();
                sim.deliquoringSigmaPkeBlock.StopProcessing();
                sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock.StopProcessing();
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
            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.deliquoringEps0NeEpsBlock);
            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.deliquoringSigmaPkeBlock);
            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock);

            sim.eps0Kappa0Block.CalculateAndDisplay();
        }

        // ReSharper disable InconsistentNaming
        void epsKappaBlock_ValuesChanged(object sender)
        // ReSharper restore InconsistentNaming
        {
            var epsKappaBlock = sender as fmEps0Kappa0Block;
            fmFilterSimulation sim = m_fSolution.FindSimulation(epsKappaBlock);

            if (sim == null) // when we keep or restore simulations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
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
        void deliquoringSremTettaAdAgDHMmoleFPeqBlock_ValuesChanged(object sender)
        // ReSharper restore InconsistentNaming
        {
            var deliquoringSremTettaAdAgDHRmMmoleFPeqBlock = sender as fmSremTettaAdAgDHRmMmoleFPeqBlock;
            fmFilterSimulation sim = m_fSolution.FindSimulation(deliquoringSremTettaAdAgDHRmMmoleFPeqBlock);

            if (sim == null) // when we keep or restore simulations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                if (deliquoringSremTettaAdAgDHRmMmoleFPeqBlock != null)
                {
                    deliquoringMaterialParametersDataGrid.CellValueChanged -= deliquoringSremTettaAdAgDHRmMmoleFPeqBlock.CellValueChanged;
                    deliquoringSremTettaAdAgDHRmMmoleFPeqBlock.ValuesChanged -= deliquoringSremTettaAdAgDHMmoleFPeqBlock_ValuesChanged;
                }
                return;
            }
            fmFilterSimulation.CopyAllParametersFromBlockToSimulation(sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock, sim);

            //fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock);
            //sm.deliquoringSremTettaAdAgDHMmoleFPeqBlock.CalculateAndDisplay();
            DisplaySolution(m_fSolution);
        }

        // ReSharper disable InconsistentNaming
        void deliquoringSigmaPkeBlock_ValuesChanged(object sender)
        // ReSharper restore InconsistentNaming
        {
            var deliquoringSigmaPkeBlock = sender as fmSigmaPke0PkePcdRcdAlphadBlock;
            fmFilterSimulation sim = m_fSolution.FindSimulation(deliquoringSigmaPkeBlock);

            if (sim == null) // when we keep or restore simulations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                if (deliquoringSigmaPkeBlock != null)
                {
                    deliquoringMaterialParametersDataGrid.CellValueChanged -= deliquoringSigmaPkeBlock.CellValueChanged;
                    deliquoringSigmaPkeBlock.ValuesChanged -= deliquoringSigmaPkeBlock_ValuesChanged;
                }
                return;
            }

            sim.RhoDCalculationOption = deliquoringSigmaPkeBlock.rhoDCalculationOption;

            fmFilterSimulation.CopyAllParametersFromBlockToSimulation(sim.deliquoringSigmaPkeBlock, sim);

            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock);
            sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock.CalculateAndDisplay();
        }

        // ReSharper disable InconsistentNaming
        void deliquoringEps0dNedEpsdBlock_ValuesChanged(object sender)
        // ReSharper restore InconsistentNaming
        {
            var deliquoringEps0NeEpsBlock = sender as fmEps0dNedEpsdBlock;
            fmFilterSimulation sim = m_fSolution.FindSimulation(deliquoringEps0NeEpsBlock);

            if (sim == null) // when we keep or restore simulations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                if (deliquoringEps0NeEpsBlock != null)
                {
                    deliquoringMaterialParametersDataGrid.CellValueChanged -= deliquoringEps0NeEpsBlock.CellValueChanged;
                    deliquoringEps0NeEpsBlock.ValuesChanged -= deliquoringEps0dNedEpsdBlock_ValuesChanged;
                }
                return;
            }

            sim.HcdEpsdCalculationOption = deliquoringEps0NeEpsBlock.calculationOption;

            fmFilterSimulation.CopyAllParametersFromBlockToSimulation(sim.deliquoringEps0NeEpsBlock, sim);

            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.deliquoringSigmaPkeBlock);
            sim.deliquoringSigmaPkeBlock.CalculateAndDisplay();
        }

// ReSharper disable InconsistentNaming
        void rmHceBlock_ValuesChanged(object sender)
// ReSharper restore InconsistentNaming
        {
            var rmHceBlock = sender as fmRm0HceBlock;
            fmFilterSimulation sim = m_fSolution.FindSimulation(rmHceBlock);

            if (sim == null) // when we keep or restore simulations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
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
            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock);
            sim.filterMachiningBlock.CalculateAndDisplay();
        }
        // ReSharper disable InconsistentNaming
        void pcrcaBlock_ValuesChanged(object sender)
        // ReSharper restore InconsistentNaming
        {
            var pcrcaBlock = sender as fmPc0Rc0A0Block;
            fmFilterSimulation sim = m_fSolution.FindSimulation(pcrcaBlock);

            if (sim == null) // when we keep or restore simulations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
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

            if (sim == null) // when we keep or restore simulations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
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

                fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.deliquoringEps0NeEpsBlock);
                fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.deliquoringSigmaPkeBlock);
            }

            sim.deliquoringEps0NeEpsBlock.CalculateAndDisplay();
        }
    }
}