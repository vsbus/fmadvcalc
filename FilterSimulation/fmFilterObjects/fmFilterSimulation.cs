using System;
using fmCalcBlocksLibrary.Blocks;
using fmCalculationLibrary;
using System.Collections.Generic;
using fmCalculatorsLibrary;

namespace FilterSimulation.fmFilterObjects
{
    public class fmFilterSimulationData
    {
        public string Name;
        public Dictionary<fmGlobalParameter, fmCalculationBaseParameter> parameters = new Dictionary<fmGlobalParameter, fmCalculationBaseParameter>();
        public fmFilterMachiningCalculator.FilterMachiningCalculationOption filterMachinigCalculationOption;
        public fmSuspensionCalculator.SuspensionCalculationOptions suspensionCalculationOption;

        public void CopyFrom(fmFilterSimulationData from)
        {
            Name = from.Name;
            filterMachinigCalculationOption = from.filterMachinigCalculationOption;
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

        public void CopyIsInputedFrom(fmFilterSimulationData from)
        {
            foreach (fmGlobalParameter p in from.parameters.Keys)
            {
                if (parameters[p] is fmCalculationVariableParameter)
                {
                    (parameters[p] as fmCalculationVariableParameter).isInputed =
                        (from.parameters[p] as fmCalculationVariableParameter).isInputed;
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

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.eta_f));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.eta_f));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.hce));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Rm0));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.A));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Dp));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.hc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Mf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Ms));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Msus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.n));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qms));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmsus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qsus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.sf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.tc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.tf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Vsus));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.eps));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.kappa));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Pc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.rc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.a));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.tr));
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
            List<fmGlobalParameter> result = new List<fmGlobalParameter>();

            result.Add(fmGlobalParameter.eta_f);
            List<fmGlobalParameter> suspensionParametersList = new List<fmGlobalParameter>();
            if (suspensionCalculationOption != fmSuspensionCalculator.SuspensionCalculationOptions.RHOF_CALCULATED)
                suspensionParametersList.Add(fmGlobalParameter.rho_f);
            if (suspensionCalculationOption != fmSuspensionCalculator.SuspensionCalculationOptions.RHOS_CALCULATED)
                suspensionParametersList.Add(fmGlobalParameter.rho_s);
            if (suspensionCalculationOption != fmSuspensionCalculator.SuspensionCalculationOptions.RHOSUS_CALCULATED)
                suspensionParametersList.Add(fmGlobalParameter.rho_sus);
            if (suspensionCalculationOption != fmSuspensionCalculator.SuspensionCalculationOptions.CM_CV_C_CALCULATED)
            {
                suspensionParametersList.Add(fmGlobalParameter.Cm);
                suspensionParametersList.Add(fmGlobalParameter.Cv);
                suspensionParametersList.Add(fmGlobalParameter.C);
            }
            result.AddRange(suspensionParametersList);
            
            
            result.AddRange(new fmEps0Kappa0Calculator(null).variables.Keys);
            result.Add(fmGlobalParameter.ne);


            result.AddRange(new fmPc0rc0a0Calculator(null).variables.Keys);
            result.Add(fmGlobalParameter.nc);


            result.AddRange(new fmRm0hceCalculator(null).variables.Keys);
            
            
            List<fmGlobalParameter> filterMachiningParametersList = CalculationOptionHelper.GetParametersListThatCanBeInput(filterMachinigCalculationOption);
            result.AddRange(filterMachiningParametersList);

            return result;
        }
    }

    public class fmFilterSimulation
    {
        private Guid m_Guid;
        private fmFilterSimSerie m_ParentSerie;
        private fmFilterSimulationData m_Data = new fmFilterSimulationData();
        private fmFilterSimulationData m_BackupData = new fmFilterSimulationData();
        private bool m_Modified;
        private bool m_Checked = true;

        public fmSuspensionWithEtafBlock susBlock;
        public fmEps0Kappa0WithneBlock eps0Kappa0Block;
        public fmPc0rc0a0WithncBlock pc0rc0a0Block;
        public fmRm0hceBlock rm0HceBlock;
        public fmFilterMachiningBlock filterMachiningBlock;

        public Guid Guid
        {
            get { return m_Guid; }
            set { m_Guid = value; }
        }
        public string Name
        {
            get { return m_Data.Name; }
            set 
            {
                if (m_Data.Name != value)
                {
                    Modified = true;
                }
                m_Data.Name = value;
            }
        }
        public bool Modified
        {
            get { return m_Modified; }
            set
            {
                m_Modified = value;
                if (value && m_ParentSerie != null)
                {
                    m_ParentSerie.Modified = true;
                }
            }
        }
        public bool Checked
        {
            get { return m_Checked; }
            set { m_Checked = value; }
        }
        public fmFilterSimSerie Parent
        {
            get { return m_ParentSerie; }
            set { m_ParentSerie = value; }
        }
        public fmFilterSimulationData Data
        {
            get { return m_Data; }
        }

        public Dictionary<fmGlobalParameter, fmCalculationBaseParameter> Parameters
        {
            get { return m_Data.parameters; }
        }

        //public fmValue eta_f
        //{
        //    get { return m_Data.eta_f; }
        //    set 
        //    {
        //        if (m_Data.eta_f != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.eta_f = value; 
        //    }
        //}
        //public fmValue rho_f
        //{
        //    get { return m_Data.rho_f; }
        //    set 
        //    {
        //        if (m_Data.rho_f != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.rho_f = value; 
        //    }
        //}
        //public fmValue rho_s
        //{
        //    get { return m_Data.rho_s; }
        //    set 
        //    {
        //        if (m_Data.rho_s != value)
        //        {
        //            Modified = true;
        //        }
                
        //        m_Data.rho_s = value; 
        //    }
        //}
        //public fmValue rho_sus
        //{
        //    get { return m_Data.rho_sus; }
        //    set 
        //    {
        //        if (m_Data.rho_sus != value)
        //        {
        //            Modified = true;
        //        }
                
        //        m_Data.rho_sus = value; 
        //    }
        //}
        //public fmValue Cm
        //{
        //    get { return m_Data.Cm; }
        //    set
        //    {
        //        if (m_Data.Cm != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.Cm = value; 
        //    }
        //}
        //public fmValue Cv
        //{
        //    get { return m_Data.Cv; }
        //    set
        //    {
        //        if (m_Data.Cv != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.Cv = value; 
        //    }
        //}
        //public fmValue C
        //{
        //    get { return m_Data.C; }
        //    set
        //    {
        //        if (m_Data.C != value)
        //        {
        //            Modified = true;
        //        } 
        //        m_Data.C = value; 
        //    }
        //}
        //public fmValue eps0
        //{
        //    get { return m_Data.eps0; }
        //    set
        //    {
        //        if (m_Data.eps0 != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.eps0 = value;
        //    }
        //}
        //public fmValue kappa0
        //{
        //    get { return m_Data.kappa0; }
        //    set
        //    {
        //        if (m_Data.kappa0 != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.kappa0 = value;
        //    }
        //}
        //public fmValue ne
        //{
        //    get { return m_Data.ne; }
        //    set
        //    {
        //        if (m_Data.ne != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.ne = value;
        //    }
        //}
        //public fmValue Pc0
        //{
        //    get { return m_Data.Pc0; }
        //    set
        //    {
        //        if (m_Data.Pc0 != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.Pc0 = value;
        //    }
        //}
        //public fmValue rc0
        //{
        //    get { return m_Data.rc0; }
        //    set
        //    {
        //        if (m_Data.rc0 != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.rc0 = value;
        //    }
        //}
        //public fmValue a0
        //{
        //    get { return m_Data.a0; }
        //    set
        //    {
        //        if (m_Data.a0 != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.a0 = value;
        //    }
        //}
        //public fmValue nc
        //{
        //    get { return m_Data.nc; }
        //    set
        //    {
        //        if (m_Data.nc != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.nc = value;
        //    }
        //}
        //public fmValue hce
        //{
        //    get { return m_Data.hce; }
        //    set
        //    {
        //        if (m_Data.hce != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.hce = value;
        //    }
        //}
        //public fmValue Rm0
        //{
        //    get { return m_Data.Rm0; }
        //    set
        //    {
        //        if (m_Data.Rm0 != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.Rm0 = value;
        //    }
        //}
        //public fmValue A
        //{
        //    get { return m_Data.A; }
        //    set
        //    {
        //        if (m_Data.A != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.A = value;
        //    }
        //}
        //public fmValue Dp
        //{
        //    get { return m_Data.Dp; }
        //    set
        //    {
        //        if (m_Data.Dp != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.Dp = value;
        //    }
        //}
        //public fmValue hc
        //{
        //    get { return m_Data.hc; }
        //    set
        //    {
        //        if (m_Data.hc != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.hc = value;
        //    }
        //}
        //public fmValue Mf
        //{
        //    get { return m_Data.Mf; }
        //    set
        //    {
        //        if (m_Data.Mf != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.Mf = value;
        //    }
        //}        
        //public fmValue Ms
        //{
        //    get { return m_Data.Ms; }
        //    set
        //    {
        //        if (m_Data.Ms != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.Ms = value;
        //    }
        //}
        //public fmValue Msus
        //{
        //    get { return m_Data.Msus; }
        //    set
        //    {
        //        if (m_Data.Msus != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.Msus = value;
        //    }
        //}
        //public fmValue n
        //{
        //    get { return m_Data.n; }
        //    set
        //    {
        //        if (m_Data.n != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.n = value;
        //    }
        //}
        //public fmValue Qms
        //{
        //    get { return m_Data.Qms; }
        //    set
        //    {
        //        if (m_Data.Qms != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.Qms = value;
        //    }
        //}
        //public fmValue Qmsus
        //{
        //    get { return m_Data.Qmsus; }
        //    set
        //    {
        //        if (m_Data.Qmsus != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.Qmsus = value;
        //    }
        //}
        //public fmValue Qsus
        //{
        //    get { return m_Data.Qsus; }
        //    set
        //    {
        //        if (m_Data.Qsus != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.Qsus = value;
        //    }
        //}
        //public fmValue sf
        //{
        //    get { return m_Data.sf; }
        //    set
        //    {
        //        if (m_Data.sf != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.sf = value;
        //    }
        //}
        //public fmValue tc
        //{
        //    get { return m_Data.tc; }
        //    set
        //    {
        //        if (m_Data.tc != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.tc = value;
        //    }
        //}
        //public fmValue tf
        //{
        //    get { return m_Data.tf; }
        //    set
        //    {
        //        if (m_Data.tf != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.tf = value;
        //    }
        //}
        //public fmValue Vsus
        //{
        //    get { return m_Data.Vsus; }
        //    set
        //    {
        //        if (m_Data.Vsus != value)
        //        {
        //            Modified = true;
        //        }
        //        m_Data.Vsus = value;
        //    }
        //}
        public fmFilterMachiningCalculator.FilterMachiningCalculationOption FilterMachiningCalculationOption
        {
            get { return m_Data.filterMachinigCalculationOption; }
            set 
            {
                if (m_Data.filterMachinigCalculationOption != value)
                {
                    Modified = true;
                }
                m_Data.filterMachinigCalculationOption = value; 
            }
        }

        public fmFilterSimulation()
        {
            m_Guid = Guid.NewGuid();
        }
        public fmFilterSimulation(fmFilterSimSerie parentSerie, string Name)
        {
            m_Guid = Guid.NewGuid();
            if (parentSerie != null)
            {
                m_ParentSerie = parentSerie;
                parentSerie.AddSimulation(this);
            }
            m_Data.Name = Name;
            Keep();
        }

        public fmFilterSimulation(fmFilterSimSerie parentSerie, fmFilterSimulation toCopy)
        {
            if (parentSerie != null)
            {
                m_ParentSerie = parentSerie;
                parentSerie.AddSimulation(this);
            }
            
            CopyFrom(toCopy);
            m_Guid = Guid.NewGuid();
            Keep();
        }
        
        public void Keep()
        {
            m_BackupData.CopyFrom(m_Data);
            Modified = false;
        }
        public void Restore()
        {
            m_Data.CopyFrom(m_BackupData);
            Modified = false;
        }
        public void Delete()
        {
            //filterMachiningBlock.calculationOptionView.Dispose();
            m_ParentSerie.RemoveSimulation(this);
        }
        public void CopyFrom(fmFilterSimulation sim)
        {
            m_Data.CopyFrom(sim.m_Data);
            m_BackupData.CopyFrom(sim.m_BackupData);
            Modified = sim.Modified;
        }

        internal void CopySuspensionParameters(fmFilterSimulation simulation)
        {
            //eta_f = simulation.eta_f;

            //rho_f = simulation.rho_f;
            //rho_s = simulation.rho_s;
            //rho_sus = simulation.rho_sus;

            //Cm = simulation.Cm;
            //Cv = simulation.Cv;
            //C = simulation.C;

            //eps0 = simulation.eps0;
            //kappa0 = simulation.kappa0;

            //nc = simulation.nc;

            //Pc0 = simulation.Pc0;
            //rc0 = simulation.rc0;
            //a0 = simulation.a0;

            //ne = simulation.ne;

            //hce = simulation.hce;
            //Rm0 = simulation.Rm0;

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
            
            //foreach (fmGlobalParameter p in Parameters.Keys)
            //{
            //    if (p.Kind == fmGlobalParameter.fmGlobalParameterKind.SuspensionParameterKind)
            //    {
            //        Parameters[p] = simulation.Parameters[p];
            //    }
            //}

        }

        public static void CopyVariableParametersFromSimulationToBlock(fmFilterSimulation sim, fmCalcBlocksLibrary.Blocks.fmBaseBlock block)
        {
            foreach (fmCalcBlocksLibrary.BlockParameter.fmBlockVariableParameter p in block.Parameters)
            {
                p.value = sim.Parameters[p.globalParameter].value;
                p.isInputed = (sim.Parameters[p.globalParameter] as fmCalculationVariableParameter).isInputed;
            }
        }

        public static void CopyConstantParametersFromSimulationToBlock(fmFilterSimulation sim, fmCalcBlocksLibrary.Blocks.fmBaseBlock block)
        {
            foreach (fmCalcBlocksLibrary.BlockParameter.fmBlockConstantParameter p in block.ConstantParameters)
            {
                p.value = sim.Parameters[p.globalParameter].value;
            }
        }

        public static void CopyAllParametersFromSimulationToBlock(fmFilterSimulation sim, fmCalcBlocksLibrary.Blocks.fmBaseBlock block)
        {
            CopyVariableParametersFromSimulationToBlock(sim, block);
            CopyConstantParametersFromSimulationToBlock(sim, block);
        }

        public static void CopyAllParametersFromBlockToSimulation(fmCalcBlocksLibrary.Blocks.fmBaseBlock block, fmFilterSimulation sim)
        {
            CopyConstantParametersFromBlockToSimulation(block, sim);
            CopyVariableParametersFromBlockToSimulation(block, sim);
        }

        public static void CopyConstantParametersFromBlockToSimulation(fmCalcBlocksLibrary.Blocks.fmBaseBlock block, fmFilterSimulation sim)
        {
            foreach (fmCalcBlocksLibrary.BlockParameter.fmBlockConstantParameter p in block.ConstantParameters)
            {
                if (sim.Parameters[p.globalParameter].value != p.value)
                {
                    sim.Modified = true;
                }
                sim.Parameters[p.globalParameter].value = p.value;
            }
        }

        public static void CopyVariableParametersFromBlockToSimulation(fmCalcBlocksLibrary.Blocks.fmBaseBlock block, fmFilterSimulation sim)
        {
            foreach (fmCalcBlocksLibrary.BlockParameter.fmBlockVariableParameter p in block.Parameters)
            {
                if (sim.Parameters[p.globalParameter].value != p.value
                    || (sim.Parameters[p.globalParameter] as fmCalculationVariableParameter).isInputed != p.isInputed)
                {
                    sim.Modified = true;
                }
                sim.Parameters[p.globalParameter].value = p.value;
                (sim.Parameters[p.globalParameter] as fmCalculationVariableParameter).isInputed = p.isInputed;
            }
        }
    }
}