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

        static DataGridViewRow FindRowByGuid(DataGridViewRowCollection collection, Guid guid, string guidColumnName)
        {
            foreach (DataGridViewRow row in collection)
            {
                if (row.Cells[guidColumnName].Value != null && guid == (Guid)row.Cells[guidColumnName].Value)
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

        void HideExtraRows(DataGridView grid, string guidColumnName)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                object cellValue = row.Cells[guidColumnName].Value;
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
                HideExtraRows(projectDataGrid, "projectGuidColumn");
            if (suspension)
                HideExtraRows(suspensionDataGrid, "suspensionGuidColumn");
            if (simSeries)
                HideExtraRows(simSeriesDataGrid, "simSeriesGuidColumn");
            if (simulation)
                HideExtraRows(simulationDataGrid, "simulationGuidColumn");
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
            DataGridViewRow row = FindRowByGuid(projectDataGrid.Rows, proj.Guid, "projectGuidColumn");
            row.Cells["projectGuidColumn"].Value = proj.Guid;
            row.Visible = visible;

            bool itIsCurrentProject = proj == fSolution.CurrentObjects.Project;

            foreach (fmFilterSimSuspension sus in proj.SuspensionList)
            {
                AddHideRowsForSuspension(sus, !byCheckingProjects ? (visible && proj.Checked) : itIsCurrentProject);
            }
        }
        void AddHideRowsForSuspension(fmFilterSimSuspension sus, bool visible)
        {
            DataGridViewRow row = FindRowByGuid(suspensionDataGrid.Rows, sus.Guid, "suspensionGuidColumn"/*, "suspensionCheckedColumn"*/);
            row.Cells["suspensionGuidColumn"].Value = sus.Guid;
            row.Visible = visible;

            bool itIsCurrentSuspension = sus == fSolution.CurrentObjects.Suspension;

            foreach (fmFilterSimSerie serie in sus.SimSeriesList)
            {
                AddHideRowsForSerie(serie, !byCheckingSuspensions ? (visible && sus.Checked) : itIsCurrentSuspension);
            }
        }
        void AddHideRowsForSerie(fmFilterSimSerie serie, bool visible)
        {
            DataGridViewRow row = FindRowByGuid(simSeriesDataGrid.Rows, serie.Guid, "simSeriesGuidColumn"/*, "simSeriesCheckedColumn"*/);
            row.Cells["simSeriesGuidColumn"].Value = serie.Guid;
            row.Visible = visible;

            bool itIsCurrentSimSerie = serie == fSolution.CurrentObjects.Serie;

            foreach (fmFilterSimulation sim in serie.SimulationsList)
            {
                AddHideRowsForSimulation(sim, !byCheckingSimSeries ? (visible && serie.Checked) : itIsCurrentSimSerie);
            }
        }
        void AddHideRowsForSimulation(fmFilterSimulation sim, bool visible)
        {
            DataGridViewRow row = FindRowByGuid(simulationDataGrid.Rows, sim.Guid, "simulationGuidColumn"/*, "simulationCheckedColumn"*/);
            row.Cells["simulationGuidColumn"].Value = sim.Guid;
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
                Guid guid = (Guid)row.Cells["projectGuidColumn"].Value;
                fmFilterSimProject proj = sol.FindProject(guid);
                if (proj == null) continue;

                row.Cells["projectCheckedColumn"].Value = proj.Checked;
                row.Cells["projectNameColumn"].Value = proj.Name;
            }

            foreach (DataGridViewRow row in suspensionDataGrid.Rows)
            {
                Guid guid = (Guid)row.Cells["suspensionGuidColumn"].Value;
                fmFilterSimSuspension sus = sol.FindSuspension(guid);
                if (sus == null) continue;

                row.Cells["suspensionCheckedColumn"].Value = sus.Checked;
                row.Cells["suspensionNameColumn"].Value = sus.Name;
                row.Cells["suspensionMaterialColumn"].Value = sus.Material;
                row.Cells["suspensionCustomerColumn"].Value = sus.Customer;
            }

            foreach (DataGridViewRow row in simSeriesDataGrid.Rows)
            {
                Guid guid = (Guid)row.Cells["simSeriesGuidColumn"].Value;
                fmFilterSimSerie serie = sol.FindSerie(guid);
                if (serie == null) continue;

                row.Cells["simSeriesCheckedColumn"].Value = serie.Checked;
                row.Cells["simSeriesNameColumn"].Value = serie.Name;
                row.Cells["simSeriesProjectColumn"].Value = serie.Parent.Parent.Name;
                //row.Cells["simSeriesMaterialNameColumn"].Value = serie.Parent.Material;
                //row.Cells["simSeriesCustomerNameColumn"].Value = serie.Parent.Customer;
                row.Cells["simSeriesSuspensionNameColumn"].Value = serie.Parent.Material + " - " + serie.Parent.Customer + " - " + serie.Parent.Name;
                row.Cells["simSeriesFilterMediumColumn"].Value = serie.FilterMedium;
                row.Cells["simSeriesMachineTypeNameColumn"].Value = serie.MachineType.Name;
                row.Cells["simSeriesMachineNameColumn"].Value = serie.MachineName;
                row.Cells["simSeriesLastModifiedDateColumn"].Value = Convert.ToString(serie.LastModifiedDate);
            }

            foreach (DataGridViewRow row in simulationDataGrid.Rows)
            {
                Guid guid = (Guid)row.Cells["simulationGuidColumn"].Value;
                fmFilterSimulation sim = sol.FindSimulation(guid);
                if (sim == null) continue;

                row.Cells["simulationCheckedColumn"].Value = sim.Checked;
                row.Cells["simulationProjectColumn"].Value = sim.Parent.Parent.Parent.Name;
                //row.Cells["simulationMaterialColumn"].Value = sim.Parent.Parent.Material;
                //row.Cells["simulationCustomerColumn"].Value = sim.Parent.Parent.Customer;
                row.Cells["simulationSuspensionNameColumn"].Value = sim.Parent.Parent.Material + " - " + sim.Parent.Parent.Customer + " - " + sim.Parent.Parent.Name;
                row.Cells["simulationFilterMediumColumn"].Value = sim.Parent.FilterMedium;
                row.Cells["simulationMachineTypeColumn"].Value = sim.Parent.MachineType.Name;
                row.Cells["simulationMachineNameColumn"].Value = sim.Parent.MachineName;
                row.Cells["simulationSimSeriesNameColumn"].Value = sim.Parent.Name;
                row.Cells["simulationNameColumn"].Value = sim.Name;

                sim.filterMachiningBlock.CalculateAndDisplay();
            }
        }

        //fmSimCalcOptionControl FindCalcOptionCntrlBySim(fmFilterSimulation sim)
        //{
        //    Guid guid = sim.Guid;
        //    foreach (fmSimCalcOptionControl scoc in simCalcOptionViewList)
        //    {
        //        if (scoc.guidOfOwnedSimulation == guid)
        //            return scoc;
        //    }

        //    simCalcOptionViewList.Add(new fmSimCalcOptionControl(guid, simulationPanel, 437, 3, sim.CalculationOption));
        //    return simCalcOptionViewList[simCalcOptionViewList.Count - 1];
        //}

        void AssignNewCellsWithCalculationEngine(fmFilterSimSolution sol)
        {
            foreach (fmFilterSimulation sim in sol.GetAllSimulations())
            {
                DataGridViewColumn liquidCol = FindColumnByGuid(liquidDataGrid.Columns, sim.Guid, 0);
                if (sim.susBlock == null)
                {
                    sim.susBlock = new fmSuspensionWithEtafBlock(
                        radioButton_rho_f, radioButton_rho_s, radioButton_rho_sus, radioButton_C,
                        FindRowByValueInColumn(liquidDataGrid, "liquidParameterName", "eta_f").Cells[liquidCol.Index],
                        FindRowByValueInColumn(liquidDataGrid, "liquidParameterName", "rho_f").Cells[liquidCol.Index],
                        FindRowByValueInColumn(liquidDataGrid, "liquidParameterName", "rho_s").Cells[liquidCol.Index],
                        FindRowByValueInColumn(liquidDataGrid, "liquidParameterName", "rho_sus").Cells[liquidCol.Index],
                        FindRowByValueInColumn(liquidDataGrid, "liquidParameterName", "Cm").Cells[liquidCol.Index],
                        FindRowByValueInColumn(liquidDataGrid, "liquidParameterName", "Cv").Cells[liquidCol.Index],
                        FindRowByValueInColumn(liquidDataGrid, "liquidParameterName", "C").Cells[liquidCol.Index]);

                    sim.susBlock.ValuesChanged += susBlock_ValuesChanged;
                    sim.susBlock.ValuesChangedByUser += susBlock_ValuesChangedByUser;
                }

                DataGridViewColumn epsKappaCol = FindColumnByGuid(eps0Kappa0Pc0Rc0Alpha0DataGrid.Columns, sim.Guid, 0);
                if (sim.eps0Kappa0Block == null)
                {
                    sim.eps0Kappa0Block = new fmEpsKappaWithneBlock(
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "eps0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "kappa0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "ne").Cells[epsKappaCol.Index]);

                    sim.eps0Kappa0Block.ValuesChanged += epsKappaBlock_ValuesChanged;
                    sim.eps0Kappa0Block.ValuesChangedByUser += eps0Kappa0Block_ValuesChangedByUser;
                }

                if (sim.pc0rc0a0Block == null)
                {
                    sim.pc0rc0a0Block = new fmPcrcaWithncBlock(
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "Pc0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "rc0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "a0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "nc").Cells[epsKappaCol.Index]);

                    sim.pc0rc0a0Block.ValuesChanged += pcrcaBlock_ValuesChanged;
                    sim.pc0rc0a0Block.ValuesChangedByUser += pc0rc0a0Block_ValuesChangedByUser;
                }

                if (sim.rm0HceBlock == null)
                {
                    sim.rm0HceBlock = new fmRmhceBlock(
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "Rm0").Cells[epsKappaCol.Index],
                        FindRowByValueInColumn(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "hce").Cells[epsKappaCol.Index]);

                    sim.rm0HceBlock.ValuesChanged += rmHceBlock_ValuesChanged;
                    sim.rm0HceBlock.ValuesChangedByUser += rm0HceBlock_ValuesChangedByUser;
                }

                DataGridViewRow row = FindRowByGuid(simulationDataGrid.Rows, sim.Guid, "simulationGuidColumn");
                if (sim.filterMachiningBlock == null)
                {
                    fmCalculationOptionView cow = CreateNewCalculationOptionView(suspensionParametersPanel, 450, 3, 180, 160);

                    sim.filterMachiningBlock = new fmFilterMachiningBlock(
                        cow,
                        row.Cells["simulationFilterAreaColumn"],
                        row.Cells["simulation_DpColumn"],
                        row.Cells["simulation_sfColumn"],
                        row.Cells["simulation_nColumn"],
                        row.Cells["simulation_tcColumn"],
                        row.Cells["simulation_tfColumn"],
                        row.Cells["simulation_trColumn"],
                        row.Cells["simulation_hcColumn"],
                        row.Cells["simulation_MfColumn"],
                        row.Cells["simulation_MsusColumn"],
                        row.Cells["simulation_VsusColumn"],
                        row.Cells["simulation_MsColumn"],
                        row.Cells["simulation_QsusColumn"],
                        row.Cells["simulation_QmsusColumn"],
                        row.Cells["simulation_QmsColumn"],
                        row.Cells["simulation_epsColumn"],
                        row.Cells["simulation_kappaColumn"],
                        row.Cells["simulation_PcColumn"],
                        row.Cells["simulation_rcColumn"],
                        row.Cells["simulation_aColumn"]);

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
            sim.filterMachiningBlock.etaf_Value = sim.eta_f;
            sim.filterMachiningBlock.rho_f_Value = sim.rho_f;
            sim.filterMachiningBlock.rho_s_Value = sim.rho_s;
            sim.filterMachiningBlock.rho_sus_Value = sim.rho_sus;
            sim.filterMachiningBlock.Cm_Value = sim.Cm;
            sim.filterMachiningBlock.Cv_Value = sim.Cv;

            sim.filterMachiningBlock.eps0_Value = sim.eps0;
            sim.filterMachiningBlock.kappa0_Value = sim.kappa0;
            sim.filterMachiningBlock.ne_Value = sim.ne;

            sim.filterMachiningBlock.Pc0_Value = sim.Pc0;
            sim.filterMachiningBlock.nc_Value = sim.nc;

            sim.filterMachiningBlock.A_Value = sim.A;
            sim.filterMachiningBlock.Dp_Value = sim.Dp;
            sim.filterMachiningBlock.hc_Value = sim.hc;
            sim.filterMachiningBlock.hce_Value = sim.hce;
            sim.filterMachiningBlock.Mf_Value = sim.Mf;
            sim.filterMachiningBlock.Ms_Value = sim.Ms;
            sim.filterMachiningBlock.Msus_Value = sim.Msus;
            sim.filterMachiningBlock.n_Value = sim.n;
            sim.filterMachiningBlock.Qms_Value = sim.Qms;
            sim.filterMachiningBlock.Qmsus_Value = sim.Qmsus;
            sim.filterMachiningBlock.Qsus_Value = sim.Qsus;
            sim.filterMachiningBlock.sf_Value = sim.sf;
            sim.filterMachiningBlock.tc_Value = sim.tc;
            sim.filterMachiningBlock.tf_Value = sim.tf;
            sim.filterMachiningBlock.Vsus_Value = sim.Vsus;
        }
        private static void CopySimulationValuesToRmHceBlock(fmFilterSimulation sim)
        {
            sim.rm0HceBlock.hce_Value = sim.hce;
            sim.rm0HceBlock.Rm_Value = sim.Rm0;
            sim.rm0HceBlock.Pc_Value = sim.Pc0;
        }
        private static void CopySimulationValuesToPc0rc0a0ncBlock(fmFilterSimulation sim)
        {
            sim.pc0rc0a0Block.rho_s_Value = sim.rho_s;
            sim.pc0rc0a0Block.eps_Value = sim.eps0;
            sim.pc0rc0a0Block.Pc_Value = sim.Pc0;
            sim.pc0rc0a0Block.rc_Value = sim.rc0;
            sim.pc0rc0a0Block.a_Value = sim.a0;
            sim.pc0rc0a0Block.nc_Value = sim.nc;
        }
        private static void CopySimulationValuesToEps0Kappa0neBlock(fmFilterSimulation sim)
        {
            sim.eps0Kappa0Block.Cv_Value = sim.Cv;
            sim.eps0Kappa0Block.eps_Value = sim.eps0;
            sim.eps0Kappa0Block.kappa_Value = sim.kappa0;
            sim.eps0Kappa0Block.ne_Value = sim.ne;
        }
        private static void CopySimulationValuesToSusBlock(fmFilterSimulation sim)
        {
            sim.susBlock.eta_f_Value = sim.eta_f;
            sim.susBlock.rho_f_Value = sim.rho_f;
            sim.susBlock.rho_s_Value = sim.rho_s;
            sim.susBlock.rho_sus_Value = sim.rho_sus;
            sim.susBlock.Cm_Value = sim.Cm;
            sim.susBlock.Cv_Value = sim.Cv;
            sim.susBlock.C_Value = sim.C;
        }

        void UpdateColorsAndFontForSolution(fmFilterSimSolution sol)
        {
            foreach (DataGridViewRow row in projectDataGrid.Rows)
            {
                Guid guid = (Guid)row.Cells["projectGuidColumn"].Value;
                fmFilterSimProject proj = sol.FindProject(guid);
                if (proj != null)
                {
                    SetRowFontStyle(row, proj.Modified ? FontStyle.Bold : FontStyle.Regular);
                }
            }

            foreach (DataGridViewRow row in suspensionDataGrid.Rows) if (row.Visible)
                {
                    Guid guid = (Guid)row.Cells["suspensionGuidColumn"].Value;
                    fmFilterSimSuspension sus = sol.FindSuspension(guid);

                    //Color rowColor = CreateColorFromString(sus.Parent.Guid.ToString());
                    SetRowFontStyle(row, sus.Modified ? FontStyle.Bold : FontStyle.Regular);
                    //SetRowBackColor(row, rowColor);
                }

            string prevVal = "";
            bool cID = false;

            foreach (DataGridViewRow row in simSeriesDataGrid.Rows) if (row.Visible)
                {
                    Guid guid = (Guid)row.Cells["simSeriesGuidColumn"].Value;
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
                    Guid guid = (Guid)row.Cells["simulationGuidColumn"].Value;
                    fmFilterSimulation sim = sol.FindSimulation(guid);

                    if (row.Cells[row.DataGridView.SortedColumn.Index].Value == null)
                    {
                        row.Cells[row.DataGridView.SortedColumn.Index].Value = new fmCalculationLibrary.fmValue();
                    }

                    string val = row.Cells[row.DataGridView.SortedColumn.Index].Value.ToString();
                    cID ^= (prevVal == "" || prevVal != val);
                    prevVal = val;

                    Color rowColor = cID ? Color.White : Color.LightGray;
                    SetRowFontStyle(row, sim.Modified ? FontStyle.Bold : FontStyle.Regular);
                    SetRowBackColor(row, rowColor);
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
                        Guid guid = (Guid)row.Cells["projectGuidColumn"].Value;
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
                        Guid guid = (Guid)row.Cells["suspensionGuidColumn"].Value;
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
                        Guid guid = (Guid)row.Cells["simSeriesGuidColumn"].Value;
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
                        int colIndex = machineTypesDataGrid.Columns["machineTypeNameColumn"].Index;
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
                        Guid guid = (Guid)row.Cells["simulationGuidColumn"].Value;
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
        void DisplaySolution(fmFilterSimSolution sol)
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

                DisplayCharts(sol);
                
                displayingSolution = false;
            }
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

            ChartsView.currentSimFMB = sol.CurrentObjects.Simulation == null ? null : sol.CurrentObjects.Simulation.filterMachiningBlock;
            ChartsView.BuildCurves(fmbList);
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

        //DataGridViewColumn FindColumnByGuidAndHideExtraColumns(fmDataGrid.fmDataGrid dataGrid, Guid guid)
        //{
        //    DataGridViewColumn col = FindColumnByGuid(dataGrid.Columns, guid, 0);
        //    HideExtraMaterialColumns(dataGrid, col);
        //    return col;
        //}

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

        static void WriteUnitsToTable(DataGridView dg, string parameterColumnName, string parameterName, string unitColumnName, fmUnitFamily unitFamily)
        {
            FindRowByValueInColumn(dg, parameterColumnName, parameterName).Cells[unitColumnName].Value = unitFamily.CurrentUnit.Name;
        }

        static DataGridViewRow FindRowByValueInColumn(DataGridView dg, string columnName, string stringValue)
        {
            foreach (DataGridViewRow row in dg.Rows)
            {
                object value = row.Cells[columnName].Value;
                if (value != null && value.ToString() == stringValue)
                    return row;
            }
            return null;
        }

        private void UpdateUnitsAndData()
        {
            StopAllBlockProcessing();
            {
                WriteUnitsToTable(liquidDataGrid, "liquidParameterName", "eta_f", "liquidParameterUnits", fmUnitFamily.ViscosityFamily);
                WriteUnitsToTable(liquidDataGrid, "liquidParameterName", "rho_f", "liquidParameterUnits", fmUnitFamily.DensityFamily);
                WriteUnitsToTable(liquidDataGrid, "liquidParameterName", "rho_s", "liquidParameterUnits", fmUnitFamily.DensityFamily);
                WriteUnitsToTable(liquidDataGrid, "liquidParameterName", "rho_sus", "liquidParameterUnits", fmUnitFamily.DensityFamily);
                WriteUnitsToTable(liquidDataGrid, "liquidParameterName", "Cm", "liquidParameterUnits", fmUnitFamily.ConcentrationFamily);
                WriteUnitsToTable(liquidDataGrid, "liquidParameterName", "Cv", "liquidParameterUnits", fmUnitFamily.ConcentrationFamily);
                WriteUnitsToTable(liquidDataGrid, "liquidParameterName", "C", "liquidParameterUnits", fmUnitFamily.ConcentrationCFamily);

                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "eps0", "epsKappaUnits", fmUnitFamily.ConcentrationFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "kappa0", "epsKappaUnits", fmUnitFamily.NoUnitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "ne", "epsKappaUnits", fmUnitFamily.NoUnitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "Pc0", "epsKappaUnits", fmUnitFamily.PermeabilityFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "rc0", "epsKappaUnits", fmUnitFamily.CakeResistanceRcFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "a0", "epsKappaUnits", fmUnitFamily.CakeResistanceAFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "nc", "epsKappaUnits", fmUnitFamily.NoUnitFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "Rm0", "epsKappaUnits", fmUnitFamily.FilterMediumResistanceFamily);
                WriteUnitsToTable(eps0Kappa0Pc0Rc0Alpha0DataGrid, "epsKappaParameterName", "hce", "epsKappaUnits", fmUnitFamily.LengthFamily);

                WriteUnitToHeader(simulationDataGrid.Columns["simulationFilterAreaColumn"].HeaderCell, fmUnitFamily.AreaFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_DpColumn"].HeaderCell, fmUnitFamily.PressureFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_nColumn"].HeaderCell, fmUnitFamily.FrequencyFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_tcColumn"].HeaderCell, fmUnitFamily.TimeFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_tfColumn"].HeaderCell, fmUnitFamily.TimeFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_trColumn"].HeaderCell, fmUnitFamily.TimeFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_hcColumn"].HeaderCell, fmUnitFamily.LengthFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_MfColumn"].HeaderCell, fmUnitFamily.MassFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_MsusColumn"].HeaderCell, fmUnitFamily.MassFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_VsusColumn"].HeaderCell, fmUnitFamily.VolumeFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_MsColumn"].HeaderCell, fmUnitFamily.MassFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_QsusColumn"].HeaderCell, fmUnitFamily.FlowRateVolume);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_QmsusColumn"].HeaderCell, fmUnitFamily.FlowRateMass);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_QmsColumn"].HeaderCell, fmUnitFamily.FlowRateMass);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_sfColumn"].HeaderCell, fmUnitFamily.ConcentrationFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_epsColumn"].HeaderCell,fmUnitFamily.ConcentrationFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_kappaColumn"].HeaderCell,fmUnitFamily.NoUnitFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_PcColumn"].HeaderCell, fmUnitFamily.PermeabilityFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_rcColumn"].HeaderCell, fmUnitFamily.CakeResistanceRcFamily);
                WriteUnitToHeader(simulationDataGrid.Columns["simulation_aColumn"].HeaderCell, fmUnitFamily.CakeResistanceAFamily);


                ChartsView.UpdateUnits();
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

            if (sim == null) // when we keep or restore simukations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                liquidDataGrid.CellValueChanged -= susBlock.CellValueChanged;
                susBlock.ValuesChanged -= susBlock_ValuesChanged;
                return;
            }
            else
            {
                sim.eta_f = sim.susBlock.eta_f_Value;
                sim.rho_f = sim.susBlock.rho_f_Value;
                sim.rho_s = sim.susBlock.rho_s_Value;
                sim.rho_sus = sim.susBlock.rho_sus_Value;
                sim.Cm = sim.susBlock.Cm_Value;
                sim.Cv = sim.susBlock.Cv_Value;
                sim.C = sim.susBlock.C_Value;

                sim.eps0Kappa0Block.Cv_Value = sim.Cv;
                sim.pc0rc0a0Block.rho_s_Value = sim.rho_s;
                sim.filterMachiningBlock.etaf_Value = sim.eta_f;
                sim.filterMachiningBlock.rho_f_Value = sim.rho_f;
                sim.filterMachiningBlock.rho_sus_Value = sim.rho_sus;
                sim.filterMachiningBlock.Cm_Value = sim.Cm;
                sim.filterMachiningBlock.Cv_Value = sim.Cv;
                sim.eps0Kappa0Block.CalculateAndDisplay();
            }
        }
        void epsKappaBlock_ValuesChanged(object sender)
        {
            fmEpsKappaBlock epsKappaBlock = sender as fmEpsKappaBlock;
            fmFilterSimulation sim = fSolution.FindSimulation(epsKappaBlock);

            if (sim == null) // when we keep or restore simukations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                eps0Kappa0Pc0Rc0Alpha0DataGrid.CellValueChanged -= epsKappaBlock.CellValueChanged;
                epsKappaBlock.ValuesChanged -= epsKappaBlock_ValuesChanged;
                return;
            }
            else
            {
                sim.eps0 = sim.eps0Kappa0Block.eps_Value;
                sim.kappa0 = sim.eps0Kappa0Block.kappa_Value;
                sim.ne = sim.eps0Kappa0Block.ne_Value;

                sim.pc0rc0a0Block.eps_Value = sim.eps0;
                sim.filterMachiningBlock.eps0_Value = sim.eps0;
                sim.filterMachiningBlock.kappa0_Value = sim.kappa0;
                sim.filterMachiningBlock.ne_Value = sim.ne;
                sim.pc0rc0a0Block.CalculateAndDisplay();
            }
        }
        void rmHceBlock_ValuesChanged(object sender)
        {
            fmRmhceBlock rmHceBlock = sender as fmRmhceBlock;
            fmFilterSimulation sim = fSolution.FindSimulation(rmHceBlock);

            if (sim == null) // when we keep or restore simukations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                eps0Kappa0Pc0Rc0Alpha0DataGrid.CellValueChanged -= rmHceBlock.CellValueChanged;
                rmHceBlock.ValuesChanged -= rmHceBlock_ValuesChanged;
                return;
            }
            else
            {
                sim.Rm0 = sim.rm0HceBlock.Rm_Value;
                sim.hce = sim.rm0HceBlock.hce_Value;
                sim.filterMachiningBlock.hce_Value = sim.hce;
                sim.filterMachiningBlock.CalculateAndDisplay();
            }
        }
        void pcrcaBlock_ValuesChanged(object sender)
        {
            fmPcrcaBlock pcrcaBlock = sender as fmPcrcaBlock;
            fmFilterSimulation sim = fSolution.FindSimulation(pcrcaBlock);

            if (sim == null) // when we keep or restore simukations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                eps0Kappa0Pc0Rc0Alpha0DataGrid.CellValueChanged -= pcrcaBlock.CellValueChanged;
                pcrcaBlock.ValuesChanged -= pcrcaBlock_ValuesChanged;
                return;
            }
            else
            {
                sim.Pc0 = sim.pc0rc0a0Block.Pc_Value;
                sim.rc0 = sim.pc0rc0a0Block.rc_Value;
                sim.a0 = sim.pc0rc0a0Block.a_Value;
                sim.nc = sim.pc0rc0a0Block.nc_Value;

                sim.rm0HceBlock.Pc_Value = sim.Pc0;
                sim.filterMachiningBlock.Pc0_Value = sim.Pc0;
                sim.filterMachiningBlock.nc_Value = sim.nc;
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

            bool wasChanged = sim.A != filterMachiningBlock.A_Value || sim.Dp != filterMachiningBlock.Dp_Value ||
                              sim.sf != filterMachiningBlock.sf_Value || sim.n != filterMachiningBlock.n_Value ||
                              sim.tc != filterMachiningBlock.tc_Value || sim.tf != filterMachiningBlock.tf_Value ||
                              sim.hc != filterMachiningBlock.hc_Value || sim.Mf != filterMachiningBlock.Mf_Value ||
                              sim.Msus != filterMachiningBlock.Msus_Value || sim.Vsus != filterMachiningBlock.Vsus_Value ||
                              sim.Ms != filterMachiningBlock.Ms_Value || sim.Qsus != filterMachiningBlock.Qsus_Value ||
                              sim.Qmsus != filterMachiningBlock.Qmsus_Value || sim.Qms != filterMachiningBlock.Qms_Value;

            sim.CalculationOption = filterMachiningBlock.CalculationOption;

            sim.A = filterMachiningBlock.A_Value;
            sim.Dp = filterMachiningBlock.Dp_Value;
            sim.sf = filterMachiningBlock.sf_Value;
            sim.n = filterMachiningBlock.n_Value;
            sim.tc = filterMachiningBlock.tc_Value;
            sim.tf = filterMachiningBlock.tf_Value;
            sim.hc = filterMachiningBlock.hc_Value;
            sim.Mf = filterMachiningBlock.Mf_Value;
            sim.Msus = filterMachiningBlock.Msus_Value;
            sim.Vsus = filterMachiningBlock.Vsus_Value;
            sim.Ms = filterMachiningBlock.Ms_Value;
            sim.Qsus = filterMachiningBlock.Qsus_Value;
            sim.Qmsus = filterMachiningBlock.Qmsus_Value;
            sim.Qms = filterMachiningBlock.Qms_Value;

            if (wasChanged)
            {
                WriteDataForSolution(fSolution);
            }

            UpdateColorsAndFontForSolution(fSolution);
            
            if (wasChanged)
            {
                DisplayCharts(fSolution);
            }
        }
    }
}