using System;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Blocks;
using fmCalculationLibrary;
using System.Collections.Generic;
using fmCalculatorsLibrary;

namespace FilterSimulation.fmFilterObjects
{
    public class fmFilterSimulationData
    {
        public string name;
        public Dictionary<fmGlobalParameter, fmCalculationBaseParameter> parameters = new Dictionary<fmGlobalParameter, fmCalculationBaseParameter>();
        public fmFilterMachiningCalculator.fmFilterMachiningCalculationOption filterMachiningCalculationOption = fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART_AND_DESIGN_GLOBAL;
        public fmSuspensionCalculator.fmSuspensionCalculationOptions suspensionCalculationOption;

        public void CopyFrom(fmFilterSimulationData from)
        {
            name = from.name;
            filterMachiningCalculationOption = from.filterMachiningCalculationOption;
            suspensionCalculationOption = from.suspensionCalculationOption;
            CopyValuesFrom(from);
            CopyIsInputedFrom(from);
        }

        public void CopyValuesFrom(fmFilterSimulationData from)
        {
            foreach (fmGlobalParameter p in from.parameters.Keys)
            {
                parameters[p].value = from.parameters[p].value;
            }
        }

        public void CopyMaterialParametersValuesFrom(fmFilterSimulationData from)
        {
            var materialParametersList = new[]
                                                             {
                                                                 fmGlobalParameter.eta_f, fmGlobalParameter.rho_f,
                                                                 fmGlobalParameter.rho_s, fmGlobalParameter.rho_sus,
                                                                 fmGlobalParameter.Cm, fmGlobalParameter.Cv,
                                                                 fmGlobalParameter.C, fmGlobalParameter.eps0,
                                                                 fmGlobalParameter.kappa0, fmGlobalParameter.ne,
                                                                 fmGlobalParameter.Pc0, fmGlobalParameter.rc0,
                                                                 fmGlobalParameter.a0, fmGlobalParameter.nc,
                                                                 fmGlobalParameter.hce, fmGlobalParameter.Rm0
                                                             };
            foreach (fmGlobalParameter p in materialParametersList)
            {
                parameters[p].value = from.parameters[p].value;
            }
        }

        public void CopyIsInputedFrom(fmFilterSimulationData from)
        {
            foreach (fmGlobalParameter p in from.parameters.Keys)
            {
                if (parameters[p] is fmCalculationVariableParameter)
                {
                    ((fmCalculationVariableParameter) parameters[p]).isInputed =
                        ((fmCalculationVariableParameter) from.parameters[p]).isInputed;
                }
            }
        }

        private void AddParameter(fmCalculationBaseParameter parameter)
        {
            parameters[parameter.globalParameter] = parameter;
        }

        public fmFilterSimulationData()
        {
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.eta_f));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.rho_f));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.rho_s));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.rho_sus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Cm));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Cv));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.C));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.eps0));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.kappa0));
            
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.ne));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Pc0));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.rc0));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.a0));
            
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.nc));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.hce));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Rm0));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.A));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Dp));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.sf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.sr));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.n));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.tc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.tf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.tr));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.hc));
            
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Mf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Ms));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Msus));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qms));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmsus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qsus));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.eps));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.kappa));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Pc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.rc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.a));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Vsus));
            
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.hc_over_tf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.dhc_over_dt));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qf_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qs));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qs_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qc_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qsus_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmsus_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qms_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmf_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmc_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qf_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qs));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qs_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qc_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qsus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qsus_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmsus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmsus_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qms));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qms_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmf_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmc_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Vf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.mf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.vf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.ms));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.vs));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.msus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.vsus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.mc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.vc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Vc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Mc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Vs));
        }

        public List<fmGlobalParameter> GetParametersThatCanBeInputedList()
        {
            var result = new List<fmGlobalParameter> {fmGlobalParameter.eta_f};

            var suspensionParametersList = new List<fmGlobalParameter>();
            if (suspensionCalculationOption != fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOF_CALCULATED)
                suspensionParametersList.Add(fmGlobalParameter.rho_f);
            if (suspensionCalculationOption != fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOS_CALCULATED)
                suspensionParametersList.Add(fmGlobalParameter.rho_s);
            if (suspensionCalculationOption != fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOSUS_CALCULATED)
                suspensionParametersList.Add(fmGlobalParameter.rho_sus);
            if (suspensionCalculationOption != fmSuspensionCalculator.fmSuspensionCalculationOptions.CM_CV_C_CALCULATED)
            {
                suspensionParametersList.Add(fmGlobalParameter.Cm);
                suspensionParametersList.Add(fmGlobalParameter.Cv);
                suspensionParametersList.Add(fmGlobalParameter.C);
            }
            result.AddRange(suspensionParametersList);
            
            result.Add(fmGlobalParameter.eps0);
            result.Add(fmGlobalParameter.kappa0);
            result.Add(fmGlobalParameter.ne);

            result.Add(fmGlobalParameter.Pc0);
            result.Add(fmGlobalParameter.rc0);
            result.Add(fmGlobalParameter.a0);
            result.Add(fmGlobalParameter.nc);

            result.Add(fmGlobalParameter.Rm0);
            result.Add(fmGlobalParameter.hce);
            
            List<fmGlobalParameter> filterMachiningParametersList = fmCalculationOptionHelper.GetParametersListThatCanBeInput(filterMachiningCalculationOption);
            result.AddRange(filterMachiningParametersList);

            return result;
        }

        public static void CopyVariableParametersFromSimulationToBlock(fmFilterSimulationData simData, fmBaseBlock block)
        {
            foreach (fmBlockVariableParameter p in block.Parameters)
            {
                p.value = simData.parameters[p.globalParameter].value;
                p.IsInputed = ((fmCalculationVariableParameter) simData.parameters[p.globalParameter]).isInputed;
            }
        }

        public static void CopyConstantParametersFromSimulationToBlock(fmFilterSimulationData simData, fmBaseBlock block)
        {
            foreach (fmBlockConstantParameter p in block.ConstantParameters)
            {
                p.value = simData.parameters[p.globalParameter].value;
            }
        }

        public static void CopyAllParametersFromSimulationToBlock(fmFilterSimulationData simData, fmBaseBlock block)
        {
            CopyVariableParametersFromSimulationToBlock(simData, block);
            CopyConstantParametersFromSimulationToBlock(simData, block);
        }

        public static void CopyAllParametersFromBlockToSimulation(fmBaseBlock block, fmFilterSimulationData simData)
        {
            CopyConstantParametersFromBlockToSimulation(block, simData);
            CopyVariableParametersFromBlockToSimulation(block, simData);
        }

        public static void CopyConstantParametersFromBlockToSimulation(fmBaseBlock block, fmFilterSimulationData simData)
        {
            foreach (fmBlockConstantParameter p in block.ConstantParameters)
            {
                simData.parameters[p.globalParameter].value = p.value;
            }
        }

        public static void CopyVariableParametersFromBlockToSimulation(fmBaseBlock block, fmFilterSimulationData simData)
        {
            foreach (fmBlockVariableParameter p in block.Parameters)
            {
                simData.parameters[p.globalParameter].value = p.value;
                ((fmCalculationVariableParameter) simData.parameters[p.globalParameter]).isInputed = p.IsInputed;
            }
        }

        private void UpdateIsInputedInParametersFromBlock(fmBaseBlock block, fmGlobalParameter inputedParameter)
        {
            CopyAllParametersFromSimulationToBlock(this, block);
            block.UpdateIsInputed(block.GetParameterByName(inputedParameter.name));
            CopyAllParametersFromBlockToSimulation(block, this);
        }

        public void UpdateIsInputed(fmGlobalParameter inputedParameter)
        {
            var fmb = new fmFilterMachiningBlock
                          {
                              calculationOption = filterMachiningCalculationOption
                          };
            fmb.UpdateGroups();
            UpdateIsInputedInParametersFromBlock(fmb, inputedParameter);

            var susb = new fmSuspensionBlock
                           {
                               calculationOption = suspensionCalculationOption
                           };
            UpdateIsInputedInParametersFromBlock(susb, inputedParameter);

            var epskappab = new fmEps0Kappa0Block();
            UpdateIsInputedInParametersFromBlock(epskappab, inputedParameter);

            var pcrcab = new fmPc0Rc0A0Block();
            UpdateIsInputedInParametersFromBlock(pcrcab, inputedParameter);

            var rmhceb = new fmRm0HceBlock();
            UpdateIsInputedInParametersFromBlock(rmhceb, inputedParameter);
        }
    }

    public class fmFilterSimulation
    {
        private fmFilterSimSerie m_parentSerie;
        private readonly fmFilterSimulationData m_data = new fmFilterSimulationData();
        private readonly fmFilterSimulationData m_backupData = new fmFilterSimulationData();
        private bool m_modified;
        private bool m_checked = true;

        public fmSuspensionWithEtafBlock susBlock;
        public fmEps0Kappa0WithneBlock eps0Kappa0Block;
        public fmPc0Rc0A0WithncBlock pc0Rc0A0Block;
        public fmRm0HceBlock rm0HceBlock;
        public fmFilterMachiningBlock filterMachiningBlock;

        public Guid Guid { get; set; }

        public string Name
        {
            get { return m_data.name; }
            set 
            {
                if (m_data.name != value)
                {
                    Modified = true;
                }
                m_data.name = value;
            }
        }
        public bool Modified
        {
            get { return m_modified; }
            set
            {
                m_modified = value;
                if (value && m_parentSerie != null)
                {
                    m_parentSerie.Modified = true;
                }
            }
        }
        public bool Checked
        {
            get { return m_checked; }
            set { m_checked = value; }
        }
        public fmFilterSimSerie Parent
        {
            get { return m_parentSerie; }
            set { m_parentSerie = value; }
        }
        public fmFilterSimulationData Data
        {
            get { return m_data; }
        }

        public Dictionary<fmGlobalParameter, fmCalculationBaseParameter> Parameters
        {
            get { return m_data.parameters; }
        }

        public fmFilterMachiningCalculator.fmFilterMachiningCalculationOption FilterMachiningCalculationOption
        {
            get { return m_data.filterMachiningCalculationOption; }
            set 
            {
                if (m_data.filterMachiningCalculationOption != value)
                {
                    Modified = true;
                }
                m_data.filterMachiningCalculationOption = value; 
            }
        }

        public fmSuspensionCalculator.fmSuspensionCalculationOptions SuspensionCalculationOption
        {
            get { return m_data.suspensionCalculationOption; }
            set
            {
                if (m_data.suspensionCalculationOption != value)
                {
                    Modified = true;
                }
                m_data.suspensionCalculationOption = value;
            }
        }

        public fmFilterSimulation()
        {
            Guid = Guid.NewGuid();
        }
        public fmFilterSimulation(fmFilterSimSerie parentSerie, string name)
        {
            Guid = Guid.NewGuid();
            if (parentSerie != null)
            {
                m_parentSerie = parentSerie;
                parentSerie.AddSimulation(this);
            }
            m_data.name = name;

            var voidBlock = new fmFilterMachiningBlock();
            voidBlock.SetCalculationOptionAndUpdateCellsStyle(Data.filterMachiningCalculationOption);
            foreach (fmBlockVariableParameter var in voidBlock.Parameters)
            {
                ((fmCalculationVariableParameter) Data.parameters[var.globalParameter]).isInputed = var.isInputed;
            }

            Keep();
        }

        public fmFilterSimulation(fmFilterSimSerie parentSerie, fmFilterSimulation toCopy)
        {
            if (parentSerie != null)
            {
                m_parentSerie = parentSerie;
                parentSerie.AddSimulation(this);
            }
            
            CopyFrom(toCopy);
            Guid = Guid.NewGuid();
            Keep();
        }
        
        public void Keep()
        {
            m_backupData.CopyFrom(m_data);
            Modified = false;
        }
        public void Restore()
        {
            m_data.CopyFrom(m_backupData);
            Modified = false;
        }
        public void Delete()
        {
            //filterMachiningBlock.calculationOptionView.Dispose();
            m_parentSerie.RemoveSimulation(this);
        }
        public void CopyFrom(fmFilterSimulation sim)
        {
            m_data.CopyFrom(sim.m_data);
            m_backupData.CopyFrom(sim.m_backupData);
            Modified = sim.Modified;
        }

        internal void CopySuspensionParameters(fmFilterSimulation simulation)
        {
            Parameters[fmGlobalParameter.eta_f] = simulation.Parameters[fmGlobalParameter.eta_f];

            Parameters[fmGlobalParameter.rho_f] = simulation.Parameters[fmGlobalParameter.rho_f];
            Parameters[fmGlobalParameter.rho_s] = simulation.Parameters[fmGlobalParameter.rho_s];
            Parameters[fmGlobalParameter.rho_sus] = simulation.Parameters[fmGlobalParameter.rho_sus];

            Parameters[fmGlobalParameter.Cm] = simulation.Parameters[fmGlobalParameter.Cm];
            Parameters[fmGlobalParameter.Cv] = simulation.Parameters[fmGlobalParameter.Cv];
            Parameters[fmGlobalParameter.C] = simulation.Parameters[fmGlobalParameter.C];
            
            Parameters[fmGlobalParameter.eps0] = simulation.Parameters[fmGlobalParameter.eps0];
            Parameters[fmGlobalParameter.kappa0] = simulation.Parameters[fmGlobalParameter.kappa0];
            
            Parameters[fmGlobalParameter.nc] = simulation.Parameters[fmGlobalParameter.nc];
            
            Parameters[fmGlobalParameter.Pc0] = simulation.Parameters[fmGlobalParameter.Pc0];
            Parameters[fmGlobalParameter.rc0] = simulation.Parameters[fmGlobalParameter.rc0];
            Parameters[fmGlobalParameter.a0] = simulation.Parameters[fmGlobalParameter.a0];
            
            Parameters[fmGlobalParameter.ne] = simulation.Parameters[fmGlobalParameter.ne];
            
            Parameters[fmGlobalParameter.hce] = simulation.Parameters[fmGlobalParameter.hce];
            Parameters[fmGlobalParameter.Rm0] = simulation.Parameters[fmGlobalParameter.Rm0];
        }

        public static void CopyVariableParametersFromSimulationToBlock(fmFilterSimulation sim, fmBaseBlock block)
        {
            foreach (fmBlockVariableParameter p in block.Parameters)
            {
                p.value = sim.Parameters[p.globalParameter].value;
                p.IsInputed = ((fmCalculationVariableParameter) sim.Parameters[p.globalParameter]).isInputed;
            }
        }

        public static void CopyConstantParametersFromSimulationToBlock(fmFilterSimulation sim, fmBaseBlock block)
        {
            foreach (fmBlockConstantParameter p in block.ConstantParameters)
            {
                p.value = sim.Parameters[p.globalParameter].value;
            }
        }

        public static void CopyAllParametersFromSimulationToBlock(fmFilterSimulation sim, fmBaseBlock block)
        {
            CopyVariableParametersFromSimulationToBlock(sim, block);
            CopyConstantParametersFromSimulationToBlock(sim, block);
        }

        public static void CopyAllParametersFromBlockToSimulation(fmBaseBlock block, fmFilterSimulation sim)
        {
            CopyConstantParametersFromBlockToSimulation(block, sim);
            CopyVariableParametersFromBlockToSimulation(block, sim);
        }

        public static void CopyConstantParametersFromBlockToSimulation(fmBaseBlock block, fmFilterSimulation sim)
        {
            foreach (fmBlockConstantParameter p in block.ConstantParameters)
            {
                if (sim.Parameters[p.globalParameter].value != p.value)
                {
                    sim.Modified = true;
                }
                sim.Parameters[p.globalParameter].value = p.value;
            }
        }

        public static void CopyVariableParametersFromBlockToSimulation(fmBaseBlock block, fmFilterSimulation sim)
        {
            foreach (fmBlockVariableParameter p in block.Parameters)
            {
                if (sim.Parameters[p.globalParameter].value != p.value
                    || ((fmCalculationVariableParameter) sim.Parameters[p.globalParameter]).isInputed != p.IsInputed)
                {
                    sim.Modified = true;
                }
                sim.Parameters[p.globalParameter].value = p.value;
                ((fmCalculationVariableParameter) sim.Parameters[p.globalParameter]).isInputed = p.IsInputed;
            }
        }
    }
}