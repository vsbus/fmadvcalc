using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FilterSimulation.fmFilterObjects;
using System.ComponentModel;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Blocks;
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

            int insertionIndex = collection.Count;
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
                    if (Solution.FindProject(guid) == null
                        && Solution.FindSerie(guid) == null
                        && Solution.FindSuspension(guid) == null
                        && Solution.FindSimulation(guid) == null)
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

            DataGridViewColumn liquidCol = Solution.currentObjects.Simulation == null ? null : FindColumnByGuid(liquidDataGrid.Columns, Solution.currentObjects.Simulation.Guid, 0);
            HideExtraMaterialColumns(liquidDataGrid, liquidCol);
            DataGridViewColumn epsKappaCol = Solution.currentObjects.Simulation == null ? null : FindColumnByGuid(eps0Kappa0Pc0Rc0Alpha0DataGrid.Columns, Solution.currentObjects.Simulation.Guid, 0);
            HideExtraMaterialColumns(eps0Kappa0Pc0Rc0Alpha0DataGrid, epsKappaCol);
            DataGridViewColumn deliqMaterialCol = Solution.currentObjects.Simulation == null ? null : FindColumnByGuid(deliquoringMaterialParametersDataGrid.Columns, Solution.currentObjects.Simulation.Guid, 0);
            HideExtraMaterialColumns(deliquoringMaterialParametersDataGrid, deliqMaterialCol);

            HideExtraRowsInTables(true, true, true, true);
        }
        void AddHideRowsForProject(fmFilterSimProject proj, bool visible)
        {
            DataGridViewRow row = FindRowByGuid(projectDataGrid.Rows, proj.Guid, projectGuidColumn.Index);
            row.Cells[projectGuidColumn.Index].Value = proj.Guid;
            row.Visible = visible;

            bool itIsCurrentProject = proj == Solution.currentObjects.Project;

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

            bool itIsCurrentSuspension = sus == Solution.currentObjects.Suspension;

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

            bool itIsCurrentSimSerie = serie == Solution.currentObjects.Serie;

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
                row.Cells[projectNameColumn.Index].Value = proj.GetName();
            }

            foreach (DataGridViewRow row in suspensionDataGrid.Rows)
            {
                var guid = (Guid)row.Cells[suspensionGuidColumn.Index].Value;
                fmFilterSimSuspension sus = sol.FindSuspension(guid);
                if (sus == null) continue;

                row.Cells[suspensionCheckedColumn.Index].Value = sus.Checked;
                row.Cells[suspensionNameColumn.Index].Value = sus.GetName();
                row.Cells[suspensionMaterialColumn.Index].Value = sus.Material;
                row.Cells[suspensionCustomerColumn.Index].Value = sus.Customer;
            }

            foreach (DataGridViewRow row in simSeriesDataGrid.Rows)
            {
                var guid = (Guid)row.Cells[simSeriesGuidColumn.Index].Value;
                fmFilterSimSerie serie = sol.FindSerie(guid);
                if (serie == null) continue;

                row.Cells[simSeriesCheckedColumn.Index].Value = serie.Checked;
                row.Cells[simSeriesNameColumn.Index].Value = serie.GetName();
                row.Cells[simSeriesProjectColumn.Index].Value = serie.Parent.Parent.GetName();
                row.Cells[simSeriesSuspensionNameColumn.Index].Value = serie.Parent.Material + " - " + serie.Parent.Customer + " - " + serie.Parent.GetName();
                row.Cells[simSeriesFilterMediumColumn.Index].Value = serie.FilterMedium;
                row.Cells[simSeriesMachineTypeNameColumn.Index].Value = serie.MachineType.name;
                row.Cells[simSeriesMachineNameColumn.Index].Value = serie.MachineName;
            }

            foreach (DataGridViewRow row in simulationDataGrid.Rows)
            {
                var guid = (Guid)row.Cells[simulationGuidColumn.Index].Value;
                fmFilterSimulation sim = sol.FindSimulation(guid);
                if (sim == null) continue;

                row.Cells[simulationCheckedColumn.Index].Value = sim.Checked;
                row.Cells[simulationProjectColumn.Index].Value = sim.Parent.Parent.Parent.GetName();
                row.Cells[simulationSuspensionNameColumn.Index].Value = sim.Parent.Parent.Material + " - " + sim.Parent.Parent.Customer + " - " + sim.Parent.Parent.GetName();
                row.Cells[simulationFilterMediumColumn.Index].Value = sim.Parent.FilterMedium;
                row.Cells[simulationMachineTypeColumn.Index].Value = sim.Parent.MachineType.name;
                row.Cells[simulationMachineNameColumn.Index].Value = sim.Parent.MachineName;
                row.Cells[simulationSimSeriesNameColumn.Index].Value = sim.Parent.GetName();
                row.Cells[simulationNameColumn.Index].Value = sim.GetName();

                sim.filterMachiningBlock.CalculateAndDisplay();

                Dictionary<fmGlobalParameter, bool> visibleCakeFormationParams = GetVisibleCakeFormationParamsDependingOnCalculationOptions(sim);

                foreach (fmGlobalParameter parameter in fmGlobalParameter.GetMachineSettingsCakeFormationParameters())
                {
                    DataGridViewCell cell = row.Cells[simulationGridColumns[parameter].Index];
                    cell.Style.ForeColor = Color.Black;
                    if (visibleCakeFormationParams[parameter])
                    {
                        if (!sim.Parameters.ContainsKey(parameter))
                            continue;

                        cell.Value = sim.Parameters[parameter].ValueInUnits.ToString();
                        fmCalculationBaseParameter blockParameter = sim.Parameters[parameter];
                        if (blockParameter is fmCalculationVariableParameter)
                        {
                            if ((blockParameter as fmCalculationVariableParameter).isInputed)
                            {
                                cell.Style.ForeColor = Color.Blue;
                            }
                        }
                    }
                    else
                    {
                        cell.Value = "-";
                    }
                }


                Dictionary<fmGlobalParameter, bool> visibleDeliqParams = GetVisibleDeliquoringParamsDependingOnCalculationOptions(sim);

                foreach (fmGlobalParameter parameter in fmGlobalParameter.GetMachineSettingsDeliquoringParameters())
                {
                    DataGridViewCell cell = row.Cells[simulationGridColumns[parameter].Index];
                    cell.Style.ForeColor = Color.Black;
                    if (visibleDeliqParams[parameter])
                    {
                        cell.Value = sim.Parameters[parameter].ValueInUnits.ToString();
                        fmCalculationBaseParameter blockParameter = sim.Parameters[parameter];
                        if (blockParameter is fmCalculationVariableParameter)
                        {
                            if ((blockParameter as fmCalculationVariableParameter).isInputed)
                            {
                                cell.Style.ForeColor = Color.Blue;
                            }
                        }
                    }
                    else
                    {
                        cell.Value = "-";
                    }
                }
            }
        }

        private Dictionary<fmGlobalParameter, bool> GetVisibleCakeFormationParamsDependingOnCalculationOptions(fmFilterSimulation sim)
        {
            var isVisibleParameters = new Dictionary<fmGlobalParameter, bool>();

            var cakeFormationParameters = new List<fmGlobalParameter>();
            cakeFormationParameters.AddRange(fmGlobalParameter.GetMachineSettingsCakeFormationParameters());
            foreach (fmGlobalParameter parameter in cakeFormationParameters)
            {
                isVisibleParameters[parameter] = true;
            }

            fmFilterMachiningCalculator.fmFilterMachiningCalculationOption filterMachiningCalculationOption = sim.FilterMachiningCalculationOption;
            bool candleOption = filterMachiningCalculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.CYLINDRICAL_DP_CONST
                    || filterMachiningCalculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.CYLINDRICAL_QP_CONST
                    || filterMachiningCalculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.CYLINDRICAL_CENTRIPETAL_PUMP_QP_DP_CONST
                    || filterMachiningCalculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.CYLINDRICAL_VOLUMETRIC_PUMP_QP_CONST;
            if (!candleOption)
            {
                MakeInvisibleParameters(isVisibleParameters, fmGlobalParameter.d0);
            }

            bool isDpConst = filterMachiningCalculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_DP_CONST
                    || filterMachiningCalculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.CYLINDRICAL_DP_CONST;
            if (isDpConst)
            {
                MakeInvisibleParameters(isVisibleParameters,
                                        fmGlobalParameter.Qp,
                                        fmGlobalParameter.qp,
                                        fmGlobalParameter.h1,
                                        fmGlobalParameter.t1,
                                        fmGlobalParameter.h1_over_hc,
                                        fmGlobalParameter.t1_over_tf);
            }

            return isVisibleParameters;
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

                if (sim == sol.currentObjects.Simulation)
                {
                    bool isUsedDeliquoring = sim.DeliquoringUsedCalculationOption ==
                                             fmFilterMachiningCalculator.
                                                 fmDeliquoringUsedCalculationOption.Used;
                    deliquoringMaterialParametersDataGrid.Visible = isUsedDeliquoring;
                    commonDeliquoringSimulationBlockDataGrid.Visible = isUsedDeliquoring;
                }

                DataGridViewColumn deliquoringMaterialCol = FindColumnByGuid(deliquoringMaterialParametersDataGrid.Columns, sim.Guid, 0);
                if (sim.deliquoringEps0NeEpsBlock == null)
                {
                    sim.deliquoringEps0NeEpsBlock = new fmEps0dNedEpsdBlock(
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.Dp_d.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.hcd.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.eps_d.Name).Cells[deliquoringMaterialCol.Index]);

                    sim.deliquoringEps0NeEpsBlock.ValuesChanged += deliquoringEps0dNedEpsdBlock_ValuesChanged;
                    sim.deliquoringEps0NeEpsBlock.ValuesChangedByUser += deliquoringEps0dNedEpsdBlock_ValuesChangedByUser;
                }
                if (sim.deliquoringSigmaPkeBlock == null)
                {
                    sim.deliquoringSigmaPkeBlock = new fmSigmaPke0PkePcdRcdAlphadBlock(
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.eta_d.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.rho_d.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.sigma.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.pke0.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.pke.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.pc_d.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.rc_d.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.alpha_d.Name).Cells[deliquoringMaterialCol.Index]);


                    sim.deliquoringSigmaPkeBlock.ValuesChanged += DeliquoringSigmaPkeBlockValuesChanged;
                    sim.deliquoringSigmaPkeBlock.ValuesChangedByUser += deliquoringSigmaPkeBlock_ValuesChangedByUser;
                }
                if (sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock == null)
                {
                    sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock = new fmSremTettaAdAgDHRmMmoleFPeqBlock(
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.Srem.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.ad1.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.ad2.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.Tetta.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.eta_g.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.ag1.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.ag2.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.ag3.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.Tetta_boil.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.DH.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.Mmole.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.f.Name).Cells[deliquoringMaterialCol.Index],
                        FindRowByValueInColumn(deliquoringMaterialParametersDataGrid, deliquoringMaterialParametersParameterNameColumn.Index, fmGlobalParameter.peq.Name).Cells[deliquoringMaterialCol.Index]);


                    sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock.ValuesChanged += deliquoringSremTettaAdAgDHMmoleFPeqBlock_ValuesChanged;
                    sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock.ValuesChangedByUser += deliquoringSremTettaAdAgDHMmoleFPeqBlock_ValuesChangedByUser;
                }

                DataGridViewRow row = FindRowByGuid(simulationDataGrid.Rows, sim.Guid, simulationGuidColumn.Index);
                if (sim.filterMachiningBlock == null)
                {
                    sim.filterMachiningBlock = new fmFilterMachiningBlock(
                        row.Cells[simulationGridColumns[fmGlobalParameter.A].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.d0].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Dp].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.sf].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.sr].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.n].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.tc].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.tf].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.tr].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.hc_over_tf].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.dhc_over_dt].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.hc].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Mf].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Vf].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.mf].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.vf].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.ms].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.vs].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.msus].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.vsus].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.mc].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.vc].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Msus].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Vsus].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Vc].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Mc].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Ms].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Vs].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qf].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qf_i].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qs].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qs_i].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qc].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qc_i].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qsus].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qp].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qmsus].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qmsus_i].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qms].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qms_i].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qmf].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qmf_i].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qmc].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Qmc_i].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qf].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qf_i].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qs].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qs_i].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qc].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qc_i].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qsus].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qp].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qmsus].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qmsus_i].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qms].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qms_i].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qmf].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qmf_i].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qmc].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.qmc_i].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.eps].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.kappa].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.Pc].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.rc].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.a].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.t1].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.h1].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.t1_over_tf].Index],
                        row.Cells[simulationGridColumns[fmGlobalParameter.h1_over_hc].Index]);

                    sim.filterMachiningBlock.ValuesChanged += filterMachiningBlock_ValuesChanged;
                }

                CopySimulationValuesToSusBlock(sim);
                CopySimulationValuesToEps0Kappa0neBlock(sim);
                CopySimulationValuesToPc0rc0a0ncBlock(sim);
                CopySimulationValuesToRmHceBlock(sim);
                CopySimulationValuesToFilterMachining(sim);
                CopySimulationValuesToDeliquoringEps0DNedEpsdBlock(sim);
                CopySimulationValuesToDeliquoringSigmaBlock(sim);
                CopySimulationValuesToDeliquoringSremBlock(sim);

                if (sim == sol.currentObjects.Simulation)
                {
                    ShowHideRowsDependingOnCalculationOptions(sim);

                    sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock.CalculateAndDisplay();
                    sim.deliquoringSigmaPkeBlock.CalculateAndDisplay();
                    
                    sim.deliquoringEps0NeEpsBlock.isPlainArea =
                        fmFilterMachiningCalculator.IsPlainAreaCalculationOption(
                            sim.filterMachiningBlock.filterMachiningCalculationOption);
                    sim.deliquoringEps0NeEpsBlock.CalculateAndDisplay();
                    
                    sim.filterMachiningBlock.CalculateAndDisplay();
                    sim.rm0HceBlock.CalculateAndDisplay();
                    sim.pc0Rc0A0Block.CalculateAndDisplay();
                    sim.eps0Kappa0Block.CalculateAndDisplay();
                    sim.susBlock.CalculateAndDisplay();
                }
            }
        }

        private void ShowHideRowsDependingOnCalculationOptions(fmFilterSimulation sim)
        {
            Dictionary<fmGlobalParameter, bool> isVisibleParameters = GetVisibleDeliquoringParamsDependingOnCalculationOptions(sim);
            var visibleParametersList = new List<fmGlobalParameter>();
            foreach (KeyValuePair<fmGlobalParameter, bool> pair in isVisibleParameters)
            {
                if (pair.Value)
                {
                    visibleParametersList.Add(pair.Key);
                }
            }
            foreach (fmGlobalParameter parameter in visibleParametersList)
            {
                if (!sim.Parent.ParametersToDisplay.ParametersList.Contains(parameter))
                {
                    isVisibleParameters[parameter] = false;
                }
            }

            ShowHideRows(commonDeliquoringSimulationBlockDataGrid,
                commonDeliquoringSimulationBlockParameterNameColumn.Index,
                isVisibleParameters);

            ShowHideRows(deliquoringMaterialParametersDataGrid,
                deliquoringMaterialParametersParameterNameColumn.Index,
                isVisibleParameters);
        }

        private static Dictionary<fmGlobalParameter, bool> GetVisibleDeliquoringParamsDependingOnCalculationOptions(fmFilterSimulation sim)
        {
            var isVisibleParameters = new Dictionary<fmGlobalParameter, bool>();

            var deliquoringParameters = new List<fmGlobalParameter>();
            deliquoringParameters.AddRange(fmGlobalParameter.GetMaterialDeliquoringParameters());
            deliquoringParameters.AddRange(fmGlobalParameter.GetMachineSettingsDeliquoringParameters());
            foreach (fmGlobalParameter parameter in deliquoringParameters)
            {
                isVisibleParameters[parameter] = sim.DeliquoringUsedCalculationOption == fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption.Used;
            }

            bool isGas = sim.filterMachiningBlock.gasFlowrateUsedCalculationOption ==
                         fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption.Consider;
            if (!isGas)
            {
                MakeInvisibleGasParameters(isVisibleParameters);
            }

            bool isEvaporation = sim.filterMachiningBlock.evaporationUsedCalculationOption ==
                         fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption.Consider;
            if (!(isGas && isEvaporation))
            {
                MakeInvisibleEvaporationParameters(isVisibleParameters);
            }

            bool isRhoDEtaDInput = sim.RhoDetaDCalculationOption ==
                                   fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption.InputedByUser;
            if (!isRhoDEtaDInput)
            {
                isVisibleParameters[fmGlobalParameter.rho_d] = false;
                isVisibleParameters[fmGlobalParameter.eta_d] = false;
            }
            return isVisibleParameters;
        }

        private static void MakeInvisibleEvaporationParameters(Dictionary<fmGlobalParameter, bool> isVisibleParameters)
        {
            MakeInvisibleParameters(isVisibleParameters,
                                    fmGlobalParameter.Tetta_boil,
                                    fmGlobalParameter.DH,
                                    fmGlobalParameter.Mmole,
                                    fmGlobalParameter.f,
                                    fmGlobalParameter.peq);
            MakeInvisibleParameters(isVisibleParameters,
                                    fmGlobalParameter.Smech,
                                    fmGlobalParameter.Rfmech,
                                    fmGlobalParameter.Mev,
                                    fmGlobalParameter.Vev,
                                    fmGlobalParameter.Qmevi,
                                    fmGlobalParameter.Qmevi,
                                    fmGlobalParameter.Qmevt,
                                    fmGlobalParameter.Qmev,
                                    fmGlobalParameter.Qevi,
                                    fmGlobalParameter.Qevt,
                                    fmGlobalParameter.Qev,
                                    fmGlobalParameter.qmevi,
                                    fmGlobalParameter.qmevt,
                                    fmGlobalParameter.qmev,
                                    fmGlobalParameter.qevi,
                                    fmGlobalParameter.qevt,
                                    fmGlobalParameter.qev);
        }

        private static void MakeInvisibleGasParameters(Dictionary<fmGlobalParameter, bool> isVisibleParameters)
        {
            MakeInvisibleParameters(isVisibleParameters,
                                    fmGlobalParameter.Tetta,
                                    fmGlobalParameter.eta_g,
                                    fmGlobalParameter.ag1,
                                    fmGlobalParameter.ag2,
                                    fmGlobalParameter.ag3);
            MakeInvisibleParameters(isVisibleParameters,
                                    fmGlobalParameter.Qgi,
                                    fmGlobalParameter.Qg,
                                    fmGlobalParameter.vg,
                                    fmGlobalParameter.Qgt,
                                    fmGlobalParameter.Vg);
        }

        private static void MakeInvisibleParameters(Dictionary<fmGlobalParameter, bool> isVisibleParameters,
                                 params fmGlobalParameter[] parameters)
        {
            foreach (fmGlobalParameter p in parameters)
            {
                isVisibleParameters[p] = false;
            }
        }

        private static void ShowHideRows(
            DataGridView dataGrid,
            int parameterColumnIndex,
            Dictionary<fmGlobalParameter, bool> isVisibleParameters)
        {
            foreach (fmGlobalParameter p in isVisibleParameters.Keys)
            {
                DataGridViewRow row = FindRowByValueInColumn(dataGrid, parameterColumnIndex, p.Name);
                if (row != null)
                {
                    row.Visible = isVisibleParameters[p];
                }
            }
        }

        private static void CopySimulationValuesToDeliquoringSremBlock(fmFilterSimulation sim)
        {
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock);
        }

        private static void CopySimulationValuesToDeliquoringSigmaBlock(fmFilterSimulation sim)
        {
            if (sim.deliquoringSigmaPkeBlock.rhoDetaDCalculationOption != sim.RhoDetaDCalculationOption)
            {
                sim.deliquoringSigmaPkeBlock.SetCalculationOptionAndUpdateCellsStyle(sim.RhoDetaDCalculationOption);
            }
            if (sim.deliquoringSigmaPkeBlock.PcDCalculationOption != sim.PcDCalculationOption)
            {
                sim.deliquoringSigmaPkeBlock.SetCalculationOptionAndUpdateCellsStyle(sim.PcDCalculationOption);
            }
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.deliquoringSigmaPkeBlock);
        }

        private static void CopySimulationValuesToDeliquoringEps0DNedEpsdBlock(fmFilterSimulation sim)
        {
            if (sim.deliquoringEps0NeEpsBlock.hcdCalculationOption != sim.HcdEpsdCalculationOption)
            {
                sim.deliquoringEps0NeEpsBlock.SetCalculationOptionAndUpdateCellsStyle(sim.HcdEpsdCalculationOption);
            }
            if (sim.deliquoringEps0NeEpsBlock.dpdInputCalculationOption != sim.DpdInputCalculationOption)
            {
                sim.deliquoringEps0NeEpsBlock.SetCalculationOptionAndUpdateCellsStyle(sim.DpdInputCalculationOption);
            }
            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.deliquoringEps0NeEpsBlock);
        }

        // ReSharper disable InconsistentNaming
        void deliquoringSremTettaAdAgDHMmoleFPeqBlock_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in Solution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == Solution.currentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == Solution.currentObjects.Simulation.Parent.Parent)
                    CopyBlockParameters(sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock, Solution.currentObjects.Simulation.deliquoringSremTettaAdAgDHMmoleFPeqBlock);
            displayingSolution = false;
        }

        // ReSharper disable InconsistentNaming
        void deliquoringSigmaPkeBlock_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in Solution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == Solution.currentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == Solution.currentObjects.Simulation.Parent.Parent)
                    CopyBlockParameters(sim.deliquoringSigmaPkeBlock, Solution.currentObjects.Simulation.deliquoringSigmaPkeBlock);
            displayingSolution = false;
        }

        // ReSharper disable InconsistentNaming
        void deliquoringEps0dNedEpsdBlock_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in Solution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == Solution.currentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == Solution.currentObjects.Simulation.Parent.Parent)
                    CopyBlockParameters(sim.deliquoringEps0NeEpsBlock, Solution.currentObjects.Simulation.deliquoringEps0NeEpsBlock);
            displayingSolution = false;
        }

        // ReSharper disable InconsistentNaming
        void rm0HceBlock_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in Solution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == Solution.currentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == Solution.currentObjects.Simulation.Parent.Parent)
                    CopyBlockParameters(sim.rm0HceBlock, Solution.currentObjects.Simulation.rm0HceBlock);
            displayingSolution = false;
        }

        // ReSharper disable InconsistentNaming
        void pc0rc0a0Block_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in Solution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == Solution.currentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == Solution.currentObjects.Simulation.Parent.Parent)
                    CopyBlockParameters(sim.pc0Rc0A0Block, Solution.currentObjects.Simulation.pc0Rc0A0Block);
            displayingSolution = false;
        }

// ReSharper disable InconsistentNaming
        void eps0Kappa0Block_ValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
// ReSharper restore InconsistentNaming
        {
            displayingSolution = true;
            foreach (fmFilterSimulation sim in Solution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == Solution.currentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == Solution.currentObjects.Simulation.Parent.Parent)
                    CopyBlockParameters(sim.eps0Kappa0Block, Solution.currentObjects.Simulation.eps0Kappa0Block);
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
            foreach (fmFilterSimulation sim in Solution.GetAllSimulations())
                if (meterialInputSerieRadioButton.Checked && sim.Parent == Solution.currentObjects.Simulation.Parent
                    || meterialInputSuspensionRadioButton.Checked && sim.Parent.Parent == Solution.currentObjects.Simulation.Parent.Parent)
                    CopyBlockParameters(sim.susBlock, Solution.currentObjects.Simulation.susBlock);
            displayingSolution = false;
        }

        private static void CopySimulationValuesToFilterMachining(fmFilterSimulation sim)
        {
            if (sim.filterMachiningBlock.filterMachiningCalculationOption != sim.FilterMachiningCalculationOption)
            {
                sim.filterMachiningBlock.SetCalculationOptionAndUpdateCellsStyle(sim.FilterMachiningCalculationOption);
            }
            
            if (sim.filterMachiningBlock.deliquoringUsedCalculationOption != sim.DeliquoringUsedCalculationOption)
            {
                sim.filterMachiningBlock.SetCalculationOptionAndUpdateCellsStyle(sim.DeliquoringUsedCalculationOption);
            }

            if (sim.filterMachiningBlock.gasFlowrateUsedCalculationOption != sim.GasFlowrateUsedCalculationOption)
            {
                sim.filterMachiningBlock.SetCalculationOptionAndUpdateCellsStyle(sim.GasFlowrateUsedCalculationOption);
            }

            if (sim.filterMachiningBlock.evaporationUsedCalculationOption != sim.EvaporationUsedCalculationOption)
            {
                sim.filterMachiningBlock.SetCalculationOptionAndUpdateCellsStyle(sim.EvaporationUsedCalculationOption);
            }

            fmFilterSimulation.CopyAllParametersFromSimulationToBlock(sim, sim.filterMachiningBlock);
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
            if (sim.susBlock.calculationOption != sim.SuspensionCalculationOption)
            {
                sim.susBlock.SetCalculationOptionAndUpdateCellsStyle(sim.SuspensionCalculationOption);
            }

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
            bool cId = false;

            foreach (DataGridViewRow row in simSeriesDataGrid.Rows) if (row.Visible)
                {
                    var guid = (Guid)row.Cells[simSeriesGuidColumn.Index].Value;
                    fmFilterSimSerie serie = sol.FindSerie(guid);

                    if (row.Cells[row.DataGridView.SortedColumn.Index].Value == null)
                    {
                        row.Cells[row.DataGridView.SortedColumn.Index].Value = "";
                    }

                    string val = row.Cells[row.DataGridView.SortedColumn.Index].Value.ToString();
                    cId ^= (prevVal == "" || prevVal != val);
                    prevVal = val;

                    Color rowColor = cId ? Color.White : Color.LightGray;
                    SetRowFontBoldOrRegular(row, serie.Modified ? FontStyle.Bold : FontStyle.Regular);
                    SetRowBackColor(row, rowColor);
                }

            prevVal = "";
            cId = false;
            foreach (DataGridViewRow row in simulationDataGrid.Rows) if (row.Visible)
                {
                    var guid = (Guid)row.Cells[simulationGuidColumn.Index].Value;
                    fmFilterSimulation sim = sol.FindSimulation(guid);

                    if (row.Cells[row.DataGridView.SortedColumn.Index].Value == null)
                    {
                        row.Cells[row.DataGridView.SortedColumn.Index].Value = new fmValue();
                    }

                    string val = row.Cells[row.DataGridView.SortedColumn.Index].Value.ToString();
                    cId ^= (prevVal == "" || prevVal != val);
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
                        int colIndex = projectDataGrid.Columns[Solution.currentColumns.project].Index;
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
                        int colIndex = suspensionDataGrid.Columns[Solution.currentColumns.suspension].Index;
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
                        int colIndex = simSeriesDataGrid.Columns[Solution.currentColumns.simSerie].Index;
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
                        int colIndex = simulationDataGrid.Columns[Solution.currentColumns.simulation].Index;
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

                ApplyCurrentSerieParametersToDisplay(sol);
                ApplyCurrentSerieRanges(sol);

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

        private static void ApplyCurrentSerieRanges(fmFilterSimSolution sol)
        {
            if (sol.currentObjects.Serie != null)
            {
                foreach (KeyValuePair<fmGlobalParameter, fmDefaultParameterRange> range in sol.currentObjects.Serie.Ranges.Ranges)
                {
                    range.Key.SpecifiedRange = range.Value;
                }
            }
        }

        private void ApplyCurrentSerieParametersToDisplay(fmFilterSimSolution sol)
        {
            if (sol.currentObjects.Serie != null)
            {
                ParametersToDisplay = sol.currentObjects.Serie.ParametersToDisplay;
            }
        }

        private void ShowHideSelectedParametersInSimulationDataGrid()
        {
            var whatToDisplayNow = new fmParametersToDisplay();
            if (Solution.currentObjects.Suspension != null)
            {
                foreach (fmFilterSimSerie serie in Solution.currentObjects.Suspension.SimSeriesList)
                {
                    if (m_byCheckingSimSeries && serie == Solution.currentObjects.Serie
                        || !m_byCheckingSimSeries && serie.Checked)
                    {
                        foreach (fmGlobalParameter parameter in serie.ParametersToDisplay.ParametersList)
                        {
                            if (!whatToDisplayNow.ParametersList.Contains(parameter))
                            {
                                whatToDisplayNow.ParametersList.Add(parameter);
                            }
                        }
                    }
                }
            }
            foreach (DataGridViewColumn col in simulationDataGrid.Columns)
            {
                string pName = GetParameterNameFromHeader(col.HeaderText);
                if (fmGlobalParameter.ParametersByName.ContainsKey(pName))
                {
                    var p = fmGlobalParameter.ParametersByName[pName];
                    bool isVisible = false;
                    if (whatToDisplayNow.ParametersList.Contains(p))
                    {
                        bool isAllDashes = true;
                        for (int rowIdx = 0; rowIdx < simulationDataGrid.RowCount; ++rowIdx)
                        {
                            if (simulationDataGrid.Rows[rowIdx].Visible
                                && simulationDataGrid[col.Index, rowIdx].Value.ToString() != "-")
                            {
                                isAllDashes = false;
                            }
                        }
                        isVisible = !isAllDashes;
                    }
                    col.Visible = isVisible;
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
                    m_commonDeliquoringSimulationBlock.deliquoringCalculatorOptions =
                        new fmDeliquoringSimualtionCalculator.DeliquoringCalculatorOptions(
                            fmFilterMachiningCalculator.IsPlainAreaCalculationOption(sim.FilterMachiningCalculationOption),
                            fmFilterSimMachineType.IsVacuumFilter(sim.Parent.MachineType),
                            fmFilterSimMachineType.GetHcdCoefficient(sim.Parent.MachineType));
                    m_commonDeliquoringSimulationBlock.SetCalculationOptionAndRewriteData(sim.DeliquoringUsedCalculationOption);
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
                    commonCalcBlockParameterValueColumn.Visible = true;
                    commonDeliquoringSimulationBlockParameterValueColumn.Visible = true;
                    m_commonFilterMachiningBlock.SetCalculationOptionAndRewriteData(sim.filterMachiningBlock.filterMachiningCalculationOption);
                    m_commonFilterMachiningBlock.SetCalculationOptionAndRewriteData(sim.filterMachiningBlock.deliquoringUsedCalculationOption);
                    m_commonFilterMachiningBlock.SetCalculationOptionAndRewriteData(sim.filterMachiningBlock.gasFlowrateUsedCalculationOption);
                    m_commonFilterMachiningBlock.SetCalculationOptionAndRewriteData(sim.filterMachiningBlock.evaporationUsedCalculationOption);

                    for (int i = 0; i < m_commonFilterMachiningBlock.Parameters.Count; ++i)
                    {
                        commonCalcBlockDataGrid.Rows[i].Visible = m_commonFilterMachiningBlock.Parameters[i].group != null
                            && ParametersToDisplay.ParametersList.Contains(m_commonFilterMachiningBlock.Parameters[i].globalParameter);
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
            else
            {
                commonCalcBlockParameterValueColumn.Visible = false;
                commonDeliquoringSimulationBlockParameterValueColumn.Visible = false;
            }
        }


        private void InitCommonDeliquoringSimulationBlock()
        {
            var voidBlock = new fmDeliquoringSimualtionBlock();
            commonDeliquoringSimulationBlockDataGrid.RowCount = voidBlock.Parameters.Count;
            var parToCell = new Dictionary<fmGlobalParameter, DataGridViewCell>();
            for (int i = 0; i < voidBlock.Parameters.Count; ++i)
            {
                commonDeliquoringSimulationBlockDataGrid[commonDeliquoringSimulationBlockParameterNameColumn.Index, i].Value = voidBlock.Parameters[i].globalParameter.Name;
                parToCell[voidBlock.Parameters[i].globalParameter] = commonDeliquoringSimulationBlockDataGrid[commonDeliquoringSimulationBlockParameterValueColumn.Index, i];
            }

            m_commonDeliquoringSimulationBlock = new fmDeliquoringSimualtionBlockWithLimits();
            foreach (var p in m_commonDeliquoringSimulationBlock.Parameters)
            {
                m_commonDeliquoringSimulationBlock.AssignCell(p, parToCell[p.globalParameter]);
            }
            m_commonDeliquoringSimulationBlock.deliquoringCalculatorOptions = new fmDeliquoringSimualtionCalculator.
                DeliquoringCalculatorOptions(
                Solution.currentObjects.Simulation == null
                    ? true
                    : fmFilterMachiningCalculator.
                          IsPlainAreaCalculationOption(
                              Solution.currentObjects.Simulation.
                                  FilterMachiningCalculationOption),
                Solution.currentObjects.Serie == null
                    ? true
                    : fmFilterSimMachineType.IsVacuumFilter(Solution.currentObjects.Serie.MachineType),
                Solution.currentObjects.Serie == null
                    ? 1
                    : fmFilterSimMachineType.GetHcdCoefficient(Solution.currentObjects.Serie.MachineType));
            if (Solution.currentObjects.Simulation != null)
            {
                m_commonDeliquoringSimulationBlock.SetCalculationOptionAndRewriteData(
                    Solution.currentObjects.Simulation.DeliquoringUsedCalculationOption);
            }
            m_commonDeliquoringSimulationBlock.UpdateCellsStyle();

            m_commonDeliquoringSimulationBlock.ValuesChangedByUser += CommonDeliquoringSimulationBlockValuesChangedByUser;

            UpdateUnitsOfCommonDeliquoringSimulationBlock();
        }

        private void CommonDeliquoringSimulationBlockValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
        {
            fmFilterSimulation sim = Solution.currentObjects.Simulation;
            fmFilterSimulation.CopyVariableParametersFromBlockToSimulation(m_commonDeliquoringSimulationBlock, sim);
            DisplaySolution(Solution);
        }

        private void InitCommonFilterMachiningBlock()
        {
            var voidBlock = new fmFilterMachiningBlock();
            commonCalcBlockDataGrid.RowCount = voidBlock.Parameters.Count;
            var parToCell = new Dictionary<fmGlobalParameter, DataGridViewCell>();
            for (int i = 0; i < voidBlock.Parameters.Count; ++i)
            {
                commonCalcBlockDataGrid[commonCalcBlockParameterNameColumn.Index, i].Value = voidBlock.Parameters[i].globalParameter.Name;
                parToCell[voidBlock.Parameters[i].globalParameter] = commonCalcBlockDataGrid[commonCalcBlockParameterValueColumn.Index, i];
            }

            m_commonFilterMachiningBlock = new fmFilterMachiningBlockWithLimits();
            foreach (var p in m_commonFilterMachiningBlock.Parameters)
            {
                m_commonFilterMachiningBlock.AssignCell(p, parToCell[p.globalParameter]);
            }

            m_commonFilterMachiningBlock.ValuesChangedByUser += CommonFilterMachiningBlockValuesChangedByUser;

            UpdateUnitsOfCommonFilterMachiningBlock();
        }

        void CommonFilterMachiningBlockValuesChangedByUser(object sender, fmBlockParameterEventArgs e)
        {
            foreach (fmBlockVariableParameter p in m_commonFilterMachiningBlock.Parameters)
            {
                fmBlockVariableParameter p2 = Solution.currentObjects.Simulation.filterMachiningBlock.GetParameterByName(p.globalParameter.Name);
                p2.value = p.value;
                p2.IsInputed = p.IsInputed;
            }

            Solution.currentObjects.Simulation.filterMachiningBlock.CalculateAndDisplay();
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
                    if (fmGlobalParameter.ParametersByName.ContainsKey(parName))
                    {
                        fmGlobalParameter p = fmGlobalParameter.ParametersByName[parName];
                        col.HeaderCell.Value = p.Name + " (" + p.UnitFamily.CurrentUnit.Name + ")";
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
                    fmGlobalParameter p = fmGlobalParameter.ParametersByName[obj.ToString()];
                    if (p != null)
                    {
                        row.Cells[unitColumnNameIndex].Value = p.UnitFamily.CurrentUnit.Name;
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
                UpdateUnitsOfCommonDeliquoringSimulationBlock();
                RewriteDataForAllBlocks();
            }
            ResumeAllBlockProcessing();
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
            foreach (fmFilterSimulation sim in Solution.GetAllSimulations())
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
            foreach (fmFilterSimulation sim in Solution.GetAllSimulations())
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
            foreach (fmFilterSimulation sim in Solution.GetAllSimulations())
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
            fmFilterSimulation sim = Solution.FindSimulation(susBlock);

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
            sim.SuspensionCalculationOption = sim.susBlock.calculationOption;

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
            fmFilterSimulation sim = Solution.FindSimulation(epsKappaBlock);

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
            var deliquoringSremTettaAdAgDhRmMmoleFPeqBlock = sender as fmSremTettaAdAgDHRmMmoleFPeqBlock;
            fmFilterSimulation sim = Solution.FindSimulation(deliquoringSremTettaAdAgDhRmMmoleFPeqBlock);

            if (sim == null) // when we keep or restore simulations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                if (deliquoringSremTettaAdAgDhRmMmoleFPeqBlock != null)
                {
                    deliquoringMaterialParametersDataGrid.CellValueChanged -= deliquoringSremTettaAdAgDhRmMmoleFPeqBlock.CellValueChanged;
                    deliquoringSremTettaAdAgDhRmMmoleFPeqBlock.ValuesChanged -= deliquoringSremTettaAdAgDHMmoleFPeqBlock_ValuesChanged;
                }
                return;
            }
            fmFilterSimulation.CopyAllParametersFromBlockToSimulation(sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock, sim);

            if (m_commonDeliquoringSimulationBlock != null)
            {
                foreach (fmFilterSimulation simulation in Solution.GetAllSimulations())
                {
                    fmFilterSimulation.CopyAllParametersFromSimulationToBlock(simulation, m_commonDeliquoringSimulationBlock);
                    m_commonDeliquoringSimulationBlock.deliquoringCalculatorOptions =
                        new fmDeliquoringSimualtionCalculator.DeliquoringCalculatorOptions(
                            fmFilterMachiningCalculator.IsPlainAreaCalculationOption(
                                simulation.FilterMachiningCalculationOption),
                            fmFilterSimMachineType.IsVacuumFilter(simulation.Parent.MachineType),
                            fmFilterSimMachineType.GetHcdCoefficient(simulation.Parent.MachineType));
                    m_commonDeliquoringSimulationBlock.CalculateAndDisplay();
                    fmFilterSimulation.CopyAllParametersFromBlockToSimulation(m_commonDeliquoringSimulationBlock, simulation);
                }

                if (Solution.currentObjects.Simulation != null)
                {
                    fmFilterSimulation.CopyAllParametersFromSimulationToBlock(
                        Solution.currentObjects.Simulation, m_commonDeliquoringSimulationBlock);
                    m_commonDeliquoringSimulationBlock.deliquoringCalculatorOptions = new fmDeliquoringSimualtionCalculator
                        .DeliquoringCalculatorOptions(
                        fmFilterMachiningCalculator.IsPlainAreaCalculationOption(
                            Solution.currentObjects.Simulation.FilterMachiningCalculationOption),
                        fmFilterSimMachineType.IsVacuumFilter(Solution.currentObjects.Serie.MachineType),
                        fmFilterSimMachineType.GetHcdCoefficient(Solution.currentObjects.Serie.MachineType));
                    m_commonDeliquoringSimulationBlock.SetCalculationOptionAndRewriteData(Solution.currentObjects.Simulation.DeliquoringUsedCalculationOption);
                    m_commonDeliquoringSimulationBlock.CalculateAndDisplay();
                }
            }
			DisplaySolution(Solution);
        }

        void DeliquoringSigmaPkeBlockValuesChanged(object sender)
        {
            var deliquoringSigmaPkeBlock = sender as fmSigmaPke0PkePcdRcdAlphadBlock;
            fmFilterSimulation sim = Solution.FindSimulation(deliquoringSigmaPkeBlock);

            if (sim == null) // when we keep or restore simulations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                if (deliquoringSigmaPkeBlock != null)
                {
                    deliquoringMaterialParametersDataGrid.CellValueChanged -= deliquoringSigmaPkeBlock.CellValueChanged;
                    deliquoringSigmaPkeBlock.ValuesChanged -= DeliquoringSigmaPkeBlockValuesChanged;
                }
                return;
            }

            sim.RhoDetaDCalculationOption = deliquoringSigmaPkeBlock.rhoDetaDCalculationOption;
            sim.PcDCalculationOption = deliquoringSigmaPkeBlock.PcDCalculationOption;

            fmFilterSimulation.CopyAllParametersFromBlockToSimulation(sim.deliquoringSigmaPkeBlock, sim);

            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock);
            sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock.CalculateAndDisplay();
        }

        // ReSharper disable InconsistentNaming
        void deliquoringEps0dNedEpsdBlock_ValuesChanged(object sender)
        // ReSharper restore InconsistentNaming
        {
            var deliquoringEps0NeEpsBlock = sender as fmEps0dNedEpsdBlock;
            fmFilterSimulation sim = Solution.FindSimulation(deliquoringEps0NeEpsBlock);

            if (sim == null) // when we keep or restore simulations we create new objects with new Guid, so susBlocks sometimes link to dead objects and we must to delete such links
            {
                if (deliquoringEps0NeEpsBlock != null)
                {
                    deliquoringMaterialParametersDataGrid.CellValueChanged -= deliquoringEps0NeEpsBlock.CellValueChanged;
                    deliquoringEps0NeEpsBlock.ValuesChanged -= deliquoringEps0dNedEpsdBlock_ValuesChanged;
                }
                return;
            }

            sim.HcdEpsdCalculationOption = deliquoringEps0NeEpsBlock.hcdCalculationOption;
            sim.DpdInputCalculationOption = deliquoringEps0NeEpsBlock.dpdInputCalculationOption;

            fmFilterSimulation.CopyAllParametersFromBlockToSimulation(sim.deliquoringEps0NeEpsBlock, sim);

            fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.deliquoringSigmaPkeBlock);
            sim.deliquoringSigmaPkeBlock.CalculateAndDisplay();
        }

// ReSharper disable InconsistentNaming
        void rmHceBlock_ValuesChanged(object sender)
// ReSharper restore InconsistentNaming
        {
            var rmHceBlock = sender as fmRm0HceBlock;
            fmFilterSimulation sim = Solution.FindSimulation(rmHceBlock);

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
            fmFilterSimulation sim = Solution.FindSimulation(pcrcaBlock);

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
            fmFilterSimulation sim = Solution.FindSimulation(filterMachiningBlock);

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
                sim.FilterMachiningCalculationOption = filterMachiningBlock.filterMachiningCalculationOption;
                sim.DeliquoringUsedCalculationOption = filterMachiningBlock.deliquoringUsedCalculationOption;
                sim.GasFlowrateUsedCalculationOption = filterMachiningBlock.gasFlowrateUsedCalculationOption;
                sim.EvaporationUsedCalculationOption = filterMachiningBlock.evaporationUsedCalculationOption;
                fmFilterSimulation.CopyAllParametersFromBlockToSimulation(filterMachiningBlock, sim);

                fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.deliquoringEps0NeEpsBlock);
                fmFilterSimulation.CopyConstantParametersFromSimulationToBlock(sim, sim.deliquoringSigmaPkeBlock);
            }

            sim.deliquoringEps0NeEpsBlock.isPlainArea =
                fmFilterMachiningCalculator.IsPlainAreaCalculationOption(
                    filterMachiningBlock.filterMachiningCalculationOption);
            sim.deliquoringEps0NeEpsBlock.CalculateAndDisplay();
        }
    }
}