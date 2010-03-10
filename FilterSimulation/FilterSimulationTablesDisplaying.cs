using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FilterSimulation.fmFilterObjects;
using System.ComponentModel;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Blocks;
using fmCalcBlocksLibrary.Controls;
using fmCalculationLibrary.MeasureUnits;

namespace FilterSimulation
{
    public partial class FilterSimulation
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

            fmDataGrid.DataGridViewNumericalTextBoxColumn ret = new fmDataGrid.DataGridViewNumericalTextBoxColumn();
            ret.Visible = false;
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
                    Guid guid = (Guid)cellValue;
                    if (fSolution.FindProject(guid) == null
                        && fSolution.FindSerie(guid) == null
                        && fSolution.FindSuspension(guid) == null
                        && fSolution.FindSimulation(guid) == null)
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

        void ShowHideCalcOptionControls()
        {
            if (fSolution.CurrentObjects.Simulation != null)
            {
                fSolution.CurrentObjects.Simulation.filterMachiningBlock.calculationOptionView.Visible = true;

                foreach (fmFilterSimulation sim in fSolution.GetAllSimulations())
                    if (sim != fSolution.CurrentObjects.Simulation)
                        sim.filterMachiningBlock.calculationOptionView.Visible = false;
            }
        }

        void AddHideRowsForSolution(fmFilterSimSolution sol)
        {
            foreach (fmFilterSimProject prj in sol.Projects)
            {
                AddHideRowsForProject(prj, true);
            }

            DataGridViewColumn liquidCol = fSolution.CurrentObjects.Simulation == null ? null : FindColumnByGuid(liquidDataGrid.Columns, fSolution.CurrentObjects.Simulation.Guid, 0);
            DataGridViewColumn epsKappaCol = fSolution.CurrentObjects.Simulation == null ? null : FindColumnByGuid(eps0Kappa0Pc0Rc0Alpha0DataGrid.Columns, fSolution.CurrentObjects.Simulation.Guid, 0);
            HideExtraMaterialColumns(liquidDataGrid, liquidCol);
            HideExtraMaterialColumns(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaCol);

            HideExtraRowsInTables(true, true, true, true);
        }
        void AddHideRowsForProject(fmFilterSimProject proj, bool visible)
        {
            DataGridViewRow row = FindRowByGuid(projectDataGrid.Rows, proj.Guid, projectGuidColumn.Index);
            row.Cells[projectGuidColumn.Index].Value = proj.Guid;
            row.Visible = visible;

            bool itIsCurrentProject = proj == fSolution.CurrentObjects.Project;

            foreach (fmFilterSimSuspension sus in proj.SuspensionList)
            {
                AddHideRowsForSuspension(sus, !byCheckingProjects ? (visible && proj.Checked) : itIsCurrentProject);
            }
        }
        void AddHideRowsForSuspension(fmFilterSimSuspension sus, bool visible)
        {
            DataGridViewRow row = FindRowByGuid(suspensionDataGrid.Rows, sus.Guid, suspensionGuidColumn.Index);
            row.Cells[suspensionGuidColumn.Index].Value = sus.Guid;
            row.Visible = visible;

            bool itIsCurrentSuspension = sus == fSolution.CurrentObjects.Suspension;

            foreach (fmFilterSimSerie serie in sus.SimSeriesList)
            {
                AddHideRowsForSerie(serie, !byCheckingSuspensions ? (visible && sus.Checked) : itIsCurrentSuspension);
            }
        }
        void AddHideRowsForSerie(fmFilterSimSerie serie, bool visible)
        {
            DataGridViewRow row = FindRowByGuid(simSeriesDataGrid.Rows, serie.Guid, simSeriesGuidColumn.Index);
            row.Cells[simSeriesGuidColumn.Index].Value = serie.Guid;
            row.Visible = visible;

            bool itIsCurrentSimSerie = serie == fSolution.CurrentObjects.Serie;

            foreach (fmFilterSimulation sim in serie.SimulationsList)
            {
                AddHideRowsForSimulation(sim, !byCheckingSimSeries ? (visible && serie.Checked) : itIsCurrentSimSerie);
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
                Guid guid = (Guid)row.Cells[projectGuidColumn.Index].Value;
                fmFilterSimProject proj = sol.FindProject(guid);
                if (proj == null) continue;

                row.Cells[projectCheckedColumn.Index].Value = proj.Checked;
                row.Cells[projectNameColumn.Index].Value = proj.Name;
            }

            foreach (DataGridViewRow row in suspensionDataGrid.Rows)
            {
                Guid guid = (Guid)row.Cells[suspensionGuidColumn.Index].Value;
                fmFilterSimSuspension sus = sol.FindSuspension(guid);
                if (sus == null) continue;

                row.Cells[suspensionCheckedColumn.Index].Value = sus.Checked;
                row.Cells[suspensionNameColumn.Index].Value = sus.Name;
                row.Cells[suspensionMaterialColumn.Index].Value = sus.Material;
                row.Cells[suspensionCustomerColumn.Index].Value = sus.Customer;
            }

            foreach (DataGridViewRow row in simSeriesDataGrid.Rows)
            {
                Guid guid = (Guid)row.Cells[simSeriesGuidColumn.Index].Value;
                fmFilterSimSerie serie = sol.FindSerie(guid);
                if (serie == null) continue;

                row.Cells[simSeriesCheckedColumn.Index].Value = serie.Checked;
                row.Cells[simSeriesNameColumn.Index].Value = serie.Name;
                row.Cells[simSeriesProjectColumn.Index].Value = serie.Parent.Parent.Name;
                row.Cells[simSeriesSuspensionNameColumn.Index].Value = serie.Parent.Material + " - " + serie.Parent.Customer + " - " + serie.Parent.Name;
                row.Cells[simSeriesFilterMediumColumn.Index].Value = serie.FilterMedium;
                row.Cells[simSeriesMachineTypeNameColumn.Index].Value = serie.MachineType.Name;
                row.Cells[simSeriesMachineNameColumn.Index].Value = serie.MachineName;
                row.Cells[simSeriesLastModifiedDateColumn.Index].Value = Convert.ToString(serie.LastModifiedDate);
            }

            foreach (DataGridViewRow row in simulationDataGrid.Rows)
            {
                Guid guid = (Guid)row.Cells[simulationGuidColumn.Index].Value;
                fmFilterSimulation sim = sol.FindSimulation(guid);
                if (sim == null) continue;

                row.Cells[simulationCheckedColumn.Index].Value = sim.Checked;
                row.Cells[simulationProjectColumn.Index].Value = sim.Parent.Parent.Parent.Name;
                row.Cells[simulationSuspensionNameColumn.Index].Value = sim.Parent.Parent.Material + " - " + sim.Parent.Parent.Customer + " - " + sim.Parent.Parent.Name;
                row.Cells[simulationFilterMediumColumn.Index].Value = sim.Parent.FilterMedium;
                row.Cells[simulationMachineTypeColumn.Index].Value = sim.Parent.MachineType.Name;
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
                        radioButton_rho_f, radioButton_rho_s, radioButton_rho_sus, radioButton_C,
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

                if (sim.pc0rc0a0Block == null)
                {
                    sim.pc0rc0a0Block = new fmPc0rc0a0WithncBlock(
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "Pc0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "rc0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "a0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "nc").Cells[epsKappaCol.Index]);

                    sim.pc0rc0a0Block.ValuesChanged += pcrcaBlock_ValuesChanged;
                    sim.pc0rc0a0Block.ValuesChangedByUser += pc0rc0a0Block_ValuesChangedByUser;
                }

                if (sim.rm0HceBlock == null)
                {
                    sim.rm0HceBlock = new fmRm0hceBlock(
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "Rm0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "hce").Cells[epsKappaCol.Index]);

                    sim.rm0HceBlock.ValuesChanged += rmHceBlock_ValuesChanged;
                    sim.rm0HceBlock.ValuesChangedByUser += rm0HceBlock_ValuesChangedByUser;
                }

                DataGridViewRow row = FindRowByGuid(simulationDataGrid.Rows, sim.Guid, simulationGuidColumn.Index);
                if (sim.filterMachiningBlock == null)
                {
                    fmCalculationOptionView cow = CreateNewCalculationOptionView(suspensionParametersPanel, 450, 3, 180, 160);

                    sim.filterMachiningBlock = new fmFilterMachiningBlock(
                        cow,
                        row.Cells[simulationFilterAreaColumn.Index],
                        row.Cells[simulation_DpColumn.Index],
                        row.Cells[simulation_sfColumn.Index],
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

                if (sim == sol.CurrentObjects.Simulation)
                {
                    sim.filterMachiningBlock.CalculateAndDisplay();
                    sim.rm0HceBlock.CalculateAndDisplay();
                    sim.pc0rc0a0Block.CalculateAndDisplay();
                    sim.eps0Kappa0Block.CalculateAndDisplay();
                    sim.susBlock.CalculateAndDisplay();
                }
            }
        }

        private static fmCalculationOptionView CreateNewCalculationOptionView(Control parentControl, int left, int top, int width, int height)
        {
            fmCalculationOptionView cow = new fmCalculationOptionView();
            cow.Parent = parentControl;
            cow.Left = left;
            cow.Top = top;
            cow.Width = width;
            cow.Height = height;

            return cow;
        }

        void rm0HceBlock_ValuesChangedByUser(object sender, fmBlockParameterEvetArgs e)
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in fSolution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == fSolution.CurrentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == fSolution.CurrentObjects.Simulation.Parent.Parent)
                    CopyParameterToSimulations(sim.rm0HceBlock, fSolution.CurrentObjects.Simulation.rm0HceBlock, e.ParameterIndex);
            displayingSolution = false;
        }

        void pc0rc0a0Block_ValuesChangedByUser(object sender, fmBlockParameterEvetArgs e)
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in fSolution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == fSolution.CurrentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == fSolution.CurrentObjects.Simulation.Parent.Parent)
                    CopyParameterToSimulations(sim.pc0rc0a0Block, fSolution.CurrentObjects.Simulation.pc0rc0a0Block, e.ParameterIndex);
            displayingSolution = false;
        }

        void eps0Kappa0Block_ValuesChangedByUser(object sender, fmBlockParameterEvetArgs e)
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in fSolution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == fSolution.CurrentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == fSolution.CurrentObjects.Simulation.Parent.Parent)
                    CopyParameterToSimulations(sim.eps0Kappa0Block, fSolution.CurrentObjects.Simulation.eps0Kappa0Block, e.ParameterIndex);
            displayingSolution = false;
        }

        static void CopyParameterToSimulations(fmBaseBlock dst, fmBaseBlock src, int parameterIndex)
        {
            dst.Parameters[parameterIndex].value = src.Parameters[parameterIndex].value;
            dst.UpdateIsInputed(dst.Parameters[parameterIndex]);
            dst.CalculateAndDisplay();
        }

        void susBlock_ValuesChangedByUser(object sender, fmBlockParameterEvetArgs e)
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in fSolution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == fSolution.CurrentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == fSolution.CurrentObjects.Simulation.Parent.Parent)
                    CopyParameterToSimulations(sim.susBlock, fSolution.CurrentObjects.Simulation.susBlock, e.ParameterIndex);
            displayingSolution = false;
        }

        private static void CopySimulationValuesToFilterMachining(fmFilterSimulation sim)
        {
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.filterMachiningBlock);
            //foreach (fmBlockParameter p in sim.filterMachiningBlock.Parameters)
            //{
            //    p.value = sim.Parameters[p.globalParameter];
            //}
            //sim.filterMachiningBlock.etaf_Value = sim.eta_f;
            //sim.filterMachiningBlock.rho_f_Value = sim.rho_f;
            //sim.filterMachiningBlock.rho_s_Value = sim.rho_s;
            //sim.filterMachiningBlock.rho_sus_Value = sim.rho_sus;
            //sim.filterMachiningBlock.Cm_Value = sim.Cm;
            //sim.filterMachiningBlock.Cv_Value = sim.Cv;

            //sim.filterMachiningBlock.eps0_Value = sim.eps0;
            //sim.filterMachiningBlock.kappa0_Value = sim.kappa0;
            //sim.filterMachiningBlock.ne_Value = sim.ne;

            //sim.filterMachiningBlock.Pc0_Value = sim.Pc0;
            //sim.filterMachiningBlock.nc_Value = sim.nc;

            //sim.filterMachiningBlock.A_Value = sim.A;
            //sim.filterMachiningBlock.Dp_Value = sim.Dp;
            //sim.filterMachiningBlock.hc_Value = sim.hc;
            //sim.filterMachiningBlock.hce_Value = sim.hce;
            //sim.filterMachiningBlock.Mf_Value = sim.Mf;
            //sim.filterMachiningBlock.Ms_Value = sim.Ms;
            //sim.filterMachiningBlock.Msus_Value = sim.Msus;
            //sim.filterMachiningBlock.n_Value = sim.n;
            //sim.filterMachiningBlock.Qms_Value = sim.Qms;
            //sim.filterMachiningBlock.Qmsus_Value = sim.Qmsus;
            //sim.filterMachiningBlock.Qsus_Value = sim.Qsus;
            //sim.filterMachiningBlock.sf_Value = sim.sf;
            //sim.filterMachiningBlock.tc_Value = sim.tc;
            //sim.filterMachiningBlock.tf_Value = sim.tf;
            //sim.filterMachiningBlock.Vsus_Value = sim.Vsus;
        }
        private static void CopySimulationValuesToRmHceBlock(fmFilterSimulation sim)
        {
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.rm0HceBlock);
            //foreach (fmBlockParameter p in sim.rm0HceBlock.Parameters)
            //{
            //    p.value = sim.Parameters[p.globalParameter];
            //}
            //sim.rm0HceBlock.hce_Value = sim.hce;
            //sim.rm0HceBlock.Rm_Value = sim.Rm0;
            //sim.rm0HceBlock.Pc_Value = sim.Pc0;
        }
        private static void CopySimulationValuesToPc0rc0a0ncBlock(fmFilterSimulation sim)
        {
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.pc0rc0a0Block);
            //foreach (fmBlockParameter p in sim.pc0rc0a0Block.Parameters)
            //{
            //    p.value = sim.Parameters[p.globalParameter];
            //}
            //sim.pc0rc0a0Block.rho_s_Value = sim.rho_s;
            //sim.pc0rc0a0Block.eps_Value = sim.eps0;
            //sim.pc0rc0a0Block.Pc_Value = sim.Pc0;
            //sim.pc0rc0a0Block.rc_Value = sim.rc0;
            //sim.pc0rc0a0Block.a_Value = sim.a0;
            //sim.pc0rc0a0Block.nc_Value = sim.nc;
        }
        private static void CopySimulationValuesToEps0Kappa0neBlock(fmFilterSimulation sim)
        {
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.eps0Kappa0Block);
            //foreach (fmBlockParameter p in sim.eps0Kappa0Block.Parameters)
            //{
            //    p.value = sim.Parameters[p.globalParameter];
            //}
            //sim.eps0Kappa0Block.Cv_Value = sim.Cv;
            //sim.eps0Kappa0Block.eps_Value = sim.eps0;
            //sim.eps0Kappa0Block.kappa_Value = sim.kappa0;
            //sim.eps0Kappa0Block.ne_Value = sim.ne;
        }

        private static void CopySimulationValuesToSusBlock(fmFilterSimulation sim)
        {
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.susBlock);
            //foreach (fmBlockParameter p in sim.susBlock.Parameters)
            //{
            //    p.value = sim.Parameters[p.globalParameter];
            //}
            //sim.susBlock.eta_f_Value = sim.eta_f;
            //sim.susBlock.rho_f_Value = sim.rho_f;
            //sim.susBlock.rho_s_Value = sim.rho_s;
            //sim.susBlock.rho_sus_Value = sim.rho_sus;
            //sim.susBlock.Cm_Value = sim.Cm;
            //sim.susBlock.Cv_Value = sim.Cv;
            //sim.susBlock.C_Value = sim.C;
        }

        void UpdateColorsAndFontForSolution(fmFilterSimSolution sol)
        {
            foreach (DataGridViewRow row in projectDataGrid.Rows)
            {
                Guid guid = (Guid)row.Cells[projectGuidColumn.Index].Value;
                fmFilterSimProject proj = sol.FindProject(guid);
                if (proj != null)
                {
                    SetRowFontStyle(row, proj.Modified ? FontStyle.Bold : FontStyle.Regular);
                }
            }

            foreach (DataGridViewRow row in suspensionDataGrid.Rows) if (row.Visible)
                {
                    Guid guid = (Guid)row.Cells[suspensionGuidColumn.Index].Value;
                    fmFilterSimSuspension sus = sol.FindSuspension(guid);

                    SetRowFontStyle(row, sus.Modified ? FontStyle.Bold : FontStyle.Regular);
                }

            string prevVal = "";
            bool cID = false;

            foreach (DataGridViewRow row in simSeriesDataGrid.Rows) if (row.Visible)
                {
                    Guid guid = (Guid)row.Cells[simSeriesGuidColumn.Index].Value;
                    fmFilterSimSerie serie = sol.FindSerie(guid);

                    if (row.Cells[row.DataGridView.SortedColumn.Index].Value == null)
                    {
                        row.Cells[row.DataGridView.SortedColumn.Index].Value = "";
                    }

                    string val = row.Cells[row.DataGridView.SortedColumn.Index].Value.ToString();
                    cID ^= (prevVal == "" || prevVal != val);
                    prevVal = val;

                    Color rowColor = cID ? Color.White : Color.LightGray;
                    SetRowFontStyle(row, serie.Modified ? FontStyle.Bold : FontStyle.Regular);
                    SetRowBackColor(row, rowColor);
                }

            prevVal = "";
            cID = false;
            foreach (DataGridViewRow row in simulationDataGrid.Rows) if (row.Visible)
                {
                    Guid guid = (Guid)row.Cells[simulationGuidColumn.Index].Value;
                    fmFilterSimulation sim = sol.FindSimulation(guid);

                    if (row.Cells[row.DataGridView.SortedColumn.Index].Value == null)
                    {
                        row.Cells[row.DataGridView.SortedColumn.Index].Value = new fmCalculationLibrary.fmValue();
                    }

                    string val = row.Cells[row.DataGridView.SortedColumn.Index].Value.ToString();
                    cID ^= (prevVal == "" || prevVal != val);
                    prevVal = val;

                    SetRowFontStyle(row, sim.Modified ? FontStyle.Bold : FontStyle.Regular);
                }
        }
        void SortTables()
        {
            sortingTables = true;
            simSeriesDataGrid.Sort(simSeriesDataGrid.SortedColumn, ListSortDirection.Ascending);
            simulationDataGrid.Sort(simulationDataGrid.SortedColumn, ListSortDirection.Ascending);
            sortingTables = false;
        }

        void SelectCurrentItemsInSolution(fmFilterSimSolution sol)
        {
            if (sol.CurrentObjects.Project != null)
            {
                foreach (DataGridViewRow row in projectDataGrid.Rows)
                    if (row.Visible)
                    {
                        Guid guid = (Guid)row.Cells[projectGuidColumn.Index].Value;
                        int colIndex = projectDataGrid.Columns[fSolution.CurrentColumns.Project].Index;
                        if (guid == sol.CurrentObjects.Project.Guid)
                        {
                            projectDataGrid.CurrentCell = row.Cells[colIndex];
                        }
                    }
            }
            else
            {
                projectDataGrid.CurrentCell = null;
            }

            if (sol.CurrentObjects.Suspension != null)
            {
                foreach (DataGridViewRow row in suspensionDataGrid.Rows)
                    if (row.Visible)
                    {
                        Guid guid = (Guid)row.Cells[suspensionGuidColumn.Index].Value;
                        int colIndex = suspensionDataGrid.Columns[fSolution.CurrentColumns.Suspension].Index;
                        if (guid == sol.CurrentObjects.Suspension.Guid)
                        {
                            suspensionDataGrid.CurrentCell = row.Cells[colIndex];
                        }
                    }
            }
            else
            {
                suspensionDataGrid.CurrentCell = null;
            }

            if (sol.CurrentObjects.Serie != null)
            {
                foreach (DataGridViewRow row in simSeriesDataGrid.Rows)
                    if (row.Visible)
                    {
                        Guid guid = (Guid)row.Cells[simSeriesGuidColumn.Index].Value;
                        int colIndex = simSeriesDataGrid.Columns[fSolution.CurrentColumns.SimSerie].Index;
                        if (guid == sol.CurrentObjects.Serie.Guid)
                        {
                            simSeriesDataGrid.CurrentCell = row.Cells[colIndex];
                        }
                    }

                foreach (DataGridViewRow row in machineTypesDataGrid.Rows)
                    if (row.Visible)
                    {
                        string mName = sol.CurrentObjects.Serie.MachineType.Name;
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

            if (sol.CurrentObjects.Simulation != null)
            {
                foreach (DataGridViewRow row in simulationDataGrid.Rows)
                    if (row.Visible)
                    {
                        Guid guid = (Guid)row.Cells[simulationGuidColumn.Index].Value;
                        int colIndex = simulationDataGrid.Columns[fSolution.CurrentColumns.Simulation].Index;
                        if (guid == sol.CurrentObjects.Simulation.Guid)
                        {
                            simulationDataGrid.CurrentCell = row.Cells[colIndex];
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
                ShowHideCalcOptionControls();
                WriteDataForSolution(sol);

                UpdateColorsAndFontForSolution(sol);
                SelectCurrentItemsInSolution(sol);

                displayingSolution = false;
            }
        }

        static Color CreateColorFromString(string s)
        {
            ulong key = 0;
            const ulong X = 113;
            for (int i = 0; i < s.Length; ++i)
            {
                key = key * X + s[i];
            }
            Random rnd = new Random((int)key);
            const int grad = 4;
            const int light = 3;
            int r = (rnd.Next(grad) + grad * (light - 1)) * 255 / (grad * light);
            int g = (rnd.Next(grad) + grad * (light - 1)) * 255 / (grad * light);
            int b = (rnd.Next(grad) + grad * (light - 1)) * 255 / (grad * light);
            return Color.FromArgb(r, g, b);
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
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, "eta_f", liquidParameterUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.eta_f.unitFamily);
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, "rho_f", liquidParameterUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.rho_f.unitFamily);
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, "rho_s", liquidParameterUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.rho_s.unitFamily);
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, "rho_sus", liquidParameterUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.rho_sus.unitFamily);
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, "Cm", liquidParameterUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.Cm.unitFamily);
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, "Cv", liquidParameterUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.Cv.unitFamily);
                WriteUnitsToTable(liquidDataGrid, liquidParameterName.Index, "C", liquidParameterUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.C.unitFamily);

                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "eps0", epsKappaUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.eps.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "kappa0", epsKappaUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.kappa.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "ne", epsKappaUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.ne.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "Pc0", epsKappaUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.Pc.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "rc0", epsKappaUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.rc.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "a0", epsKappaUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.a.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "nc", epsKappaUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.nc.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "Rm0", epsKappaUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.Rm.unitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaParameterName.Index, "hce", epsKappaUnits.Index, fmCalcBlocksLibrary.fmGlobalParameter.hce.unitFamily);

                WriteUnitToHeader(simulationDataGrid.Columns[simulationFilterAreaColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.A.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_DpColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Dp.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_nColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.n.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_tcColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.tc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_tfColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.tf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_trColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.tr.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_hc_over_tfColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.hc_over_tf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_dhc_over_dtColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.dhc_over_dt.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_hcColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.hc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_MfColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Mf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_VfColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Vf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_mf_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.mf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_vf_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.vf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_ms_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.ms.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_vs_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.vs.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_msus_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.msus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_vsus_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.vsus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_mc_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.mc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_vc_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.vc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_MsusColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Msus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_VsusColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Vsus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_VsColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Vs.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_VcColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Vc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_McColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Mc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_MsColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Ms.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QfColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qf_dColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qf_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qs_dColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qs_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qc_dColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qc_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qsus_dColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qsus_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QsColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qs.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QcColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QsusColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qsus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QmsusColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qmsus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qmsus_dColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qmsus_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QmsColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qms.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qms_dColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qms_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QmfColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qmf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qmf_dColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qmf_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_QmcColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qmc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_Qmc_dColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Qmc_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qf_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qf_d_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qf_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qs_d_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qs_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qc_d_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qc_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qsus_d_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qsus_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qs_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qs.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qc_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qsus_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qsus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qmsus_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qmsus.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qmsus_d_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qmsus_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qms_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qms.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qms_d_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qms_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qmf_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qmf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qmf_d_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qmf_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qmc_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qmc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_qmc_d_Column.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.qmc_d.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_sfColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.sf.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_epsColumn.Index].HeaderCell,fmCalcBlocksLibrary.fmGlobalParameter.eps.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_kappaColumn.Index].HeaderCell,fmCalcBlocksLibrary.fmGlobalParameter.kappa.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_PcColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.Pc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_rcColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.rc.unitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns[simulation_aColumn.Index].HeaderCell, fmCalcBlocksLibrary.fmGlobalParameter.a.unitFamily);
            }
            ResumeAllBlockProcessing();
            RewriteDataForAllBlocks();
        }

        private void RewriteDataForAllBlocks()
        {
            foreach (fmFilterSimulation sim in fSolution.GetAllSimulations())
            {
                sim.susBlock.CalculateAndDisplay();
                sim.eps0Kappa0Block.CalculateAndDisplay();
                sim.filterMachiningBlock.CalculateAndDisplay();
                sim.pc0rc0a0Block.CalculateAndDisplay();
                sim.rm0HceBlock.CalculateAndDisplay();
            }
        }

        private void ResumeAllBlockProcessing()
        {
            foreach (fmFilterSimulation sim in fSolution.GetAllSimulations())
            {
                sim.susBlock.ResumeProcessing();
                sim.eps0Kappa0Block.ResumeProcessing();
                sim.filterMachiningBlock.ResumeProcessing();
                sim.pc0rc0a0Block.ResumeProcessing();
                sim.rm0HceBlock.ResumeProcessing();
            }
        }

        private void StopAllBlockProcessing()
        {
            foreach (fmFilterSimulation sim in fSolution.GetAllSimulations())
            {
                sim.susBlock.StopProcessing();
                sim.eps0Kappa0Block.StopProcessing();
                sim.filterMachiningBlock.StopProcessing();
                sim.pc0rc0a0Block.StopProcessing();
                sim.rm0HceBlock.StopProcessing();
            }
        }

        void susBlock_ValuesChanged(object sender)
        {
            fmSuspensionWithEtafBlock susBlock = sender as fmSuspensionWithEtafBlock;
            fmFilterSimulation sim = fSolution.FindSimulation(susBlock);

            if (sim == null) // when we keep or restore simulations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                liquidDataGrid.CellValueChanged -= susBlock.CellValueChanged;
                susBlock.ValuesChanged -= susBlock_ValuesChanged;
                return;
            }
            else
            {
                fmFilterSimulation.CopyAllParametersFromBlockToSimulation(sim.susBlock, sim);
                //foreach (fmBlockParameter p in sim.susBlock.Parameters)
                //{
                //    sim.Parameters[p.globalParameter] = p.value;
                //} 
                //sim.eta_f = sim.susBlock.eta_f_Value;
                //sim.rho_f = sim.susBlock.rho_f_Value;
                //sim.rho_s = sim.susBlock.rho_s_Value;
                //sim.rho_sus = sim.susBlock.rho_sus_Value;
                //sim.Cm = sim.susBlock.Cm_Value;
                //sim.Cv = sim.susBlock.Cv_Value;
                //sim.C = sim.susBlock.C_Value;

                fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.eps0Kappa0Block);
                //foreach (fmBlockConstantParameter c in sim.eps0Kappa0Block.ConstantParameters)
                //{
                //    sim.Parameters[c.globalParameter] = c.value;
                //} 
                //sim.eps0Kappa0Block.Cv_Value = sim.Cv;

                fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.pc0rc0a0Block);
                //foreach (fmBlockConstantParameter c in sim.pc0rc0a0Block.ConstantParameters)
                //{
                //    sim.Parameters[c.globalParameter] = c.value;
                //}
                //sim.pc0rc0a0Block.rho_s_Value = sim.rho_s;

                fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.filterMachiningBlock);
                //sim.filterMachiningBlock.etaf_Value = sim.eta_f;
                //sim.filterMachiningBlock.rho_f_Value = sim.rho_f;
                //sim.filterMachiningBlock.rho_s_Value = sim.rho_s;
                //sim.filterMachiningBlock.rho_sus_Value = sim.rho_sus;
                //sim.filterMachiningBlock.Cm_Value = sim.Cm;
                //sim.filterMachiningBlock.Cv_Value = sim.Cv;

                sim.eps0Kappa0Block.CalculateAndDisplay();
            }
        }

        void epsKappaBlock_ValuesChanged(object sender)
        {
            fmEps0Kappa0Block epsKappaBlock = sender as fmEps0Kappa0Block;
            fmFilterSimulation sim = fSolution.FindSimulation(epsKappaBlock);

            if (sim == null) // when we keep or restore simukations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                eps0Kappa0Pc0Rc0Alpha0DataGrid.CellValueChanged -= epsKappaBlock.CellValueChanged;
                epsKappaBlock.ValuesChanged -= epsKappaBlock_ValuesChanged;
                return;
            }
            else
            {
                //sim.eps0 = sim.eps0Kappa0Block.eps_Value;
                //sim.kappa0 = sim.eps0Kappa0Block.kappa_Value;
                //sim.ne = sim.eps0Kappa0Block.ne_Value;
                fmFilterSimulation.CopyAllParametersFromBlockToSimulation(sim.eps0Kappa0Block, sim);

                //sim.pc0rc0a0Block.eps_Value = sim.eps0;
                fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.pc0rc0a0Block);
                //sim.filterMachiningBlock.eps0_Value = sim.eps0;
                //sim.filterMachiningBlock.kappa0_Value = sim.kappa0;
                //sim.filterMachiningBlock.ne_Value = sim.ne;
                fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.filterMachiningBlock);
                sim.pc0rc0a0Block.CalculateAndDisplay();
            }
        }
        void rmHceBlock_ValuesChanged(object sender)
        {
            fmRm0hceBlock rmHceBlock = sender as fmRm0hceBlock;
            fmFilterSimulation sim = fSolution.FindSimulation(rmHceBlock);

            if (sim == null) // when we keep or restore simukations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                eps0Kappa0Pc0Rc0Alpha0DataGrid.CellValueChanged -= rmHceBlock.CellValueChanged;
                rmHceBlock.ValuesChanged -= rmHceBlock_ValuesChanged;
                return;
            }
            else
            {
                //sim.Rm0 = sim.rm0HceBlock.Rm_Value;
                //sim.hce = sim.rm0HceBlock.hce_Value;
                fmFilterSimulation.CopyAllParametersFromBlockToSimulation(sim.rm0HceBlock, sim);
                //sim.filterMachiningBlock.hce_Value = sim.hce;
                fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.filterMachiningBlock);
                sim.filterMachiningBlock.CalculateAndDisplay();
            }
        }
        void pcrcaBlock_ValuesChanged(object sender)
        {
            fmPc0rc0a0Block pcrcaBlock = sender as fmPc0rc0a0Block;
            fmFilterSimulation sim = fSolution.FindSimulation(pcrcaBlock);

            if (sim == null) // when we keep or restore simukations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                eps0Kappa0Pc0Rc0Alpha0DataGrid.CellValueChanged -= pcrcaBlock.CellValueChanged;
                pcrcaBlock.ValuesChanged -= pcrcaBlock_ValuesChanged;
                return;
            }
            else
            {
                //sim.Pc0 = sim.pc0rc0a0Block.Pc_Value;
                //sim.rc0 = sim.pc0rc0a0Block.rc_Value;
                //sim.a0 = sim.pc0rc0a0Block.a_Value;
                //sim.nc = sim.pc0rc0a0Block.nc_Value;
                fmFilterSimulation.CopyAllParametersFromBlockToSimulation(sim.pc0rc0a0Block, sim);

                //sim.rm0HceBlock.Pc_Value = sim.Pc0;
                fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.rm0HceBlock);
                //sim.filterMachiningBlock.Pc0_Value = sim.Pc0;
                //sim.filterMachiningBlock.nc_Value = sim.nc;
                fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.filterMachiningBlock);
                sim.rm0HceBlock.CalculateAndDisplay();
            }
        }

        void filterMachiningBlock_ValuesChanged(object sender)
        {
            fmFilterMachiningBlock filterMachiningBlock = sender as fmFilterMachiningBlock;
            fmFilterSimulation sim = fSolution.FindSimulation(filterMachiningBlock);

            if (sim == null) // when we keep or restore simukations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                simulationDataGrid.CellValueChanged -= filterMachiningBlock.CellValueChanged;
                filterMachiningBlock.ValuesChanged -= filterMachiningBlock_ValuesChanged;
                return;
            }

            //bool wasChanged = sim.A != filterMachiningBlock.A_Value || sim.Dp != filterMachiningBlock.Dp_Value ||
            //                  sim.sf != filterMachiningBlock.sf_Value || sim.n != filterMachiningBlock.n_Value ||
            //                  sim.tc != filterMachiningBlock.tc_Value || sim.tf != filterMachiningBlock.tf_Value ||
            //                  sim.hc != filterMachiningBlock.hc_Value || sim.Mf != filterMachiningBlock.Mf_Value ||
            //                  sim.Msus != filterMachiningBlock.Msus_Value || sim.Vsus != filterMachiningBlock.Vsus_Value ||
            //                  sim.Ms != filterMachiningBlock.Ms_Value || sim.Qsus != filterMachiningBlock.Qsus_Value ||
            //                  sim.Qmsus != filterMachiningBlock.Qmsus_Value || sim.Qms != filterMachiningBlock.Qms_Value;
            bool wasChanged = false;
            foreach (fmBlockParameter p in filterMachiningBlock.Parameters)
            {
                wasChanged |= (p.value != sim.Parameters[p.globalParameter]);
            }

            sim.CalculationOption = filterMachiningBlock.CalculationOption;

            //sim.A = filterMachiningBlock.A_Value;
            //sim.Dp = filterMachiningBlock.Dp_Value;
            //sim.sf = filterMachiningBlock.sf_Value;
            //sim.n = filterMachiningBlock.n_Value;
            //sim.tc = filterMachiningBlock.tc_Value;
            //sim.tf = filterMachiningBlock.tf_Value;
            //sim.hc = filterMachiningBlock.hc_Value;
            //sim.Mf = filterMachiningBlock.Mf_Value;
            //sim.Msus = filterMachiningBlock.Msus_Value;
            //sim.Vsus = filterMachiningBlock.Vsus_Value;
            //sim.Ms = filterMachiningBlock.Ms_Value;
            //sim.Qsus = filterMachiningBlock.Qsus_Value;
            //sim.Qmsus = filterMachiningBlock.Qmsus_Value;
            //sim.Qms = filterMachiningBlock.Qms_Value;
            fmFilterSimulation.CopyAllParametersFromBlockToSimulation(filterMachiningBlock, sim);

            DisplaySolution(fSolution);
        }
    }
}