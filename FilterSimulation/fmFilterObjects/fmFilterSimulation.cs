using System;
using fmCalcBlocksLibrary.Blocks;
using fmCalculationLibrary;
using System.Collections.Generic;
using fmCalculatorsLibrary;

namespace FilterSimulation.fmFilterObjects
{
    class fmFilterSimulationData
    {
        public string Name;
        public Dictionary<fmGlobalParameter, fmCalculationBaseParameter> parameters = new Dictionary<fmGlobalParameter, fmCalculationBaseParameter>();
        public fmFilterMachiningCalculator.FilterMachiningCalculationOption filterMachiningCalculationOption;

        public void CopyFrom(fmFilterSimulationData from)
        {
            Name = from.Name;
            foreach (fmGlobalParameter p in from.parameters.Keys)
            {
                parameters[p] = from.parameters[p];
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
    }

    public class fmFilterSimulation
    {
        private Guid m_Guid;
        private fmFilterSimSerie m_ParentSerie;
        private fmFilterSimulationData Data = new fmFilterSimulationData();
        private fmFilterSimulationData BackupData = new fmFilterSimulationData();
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
            get { return Data.Name; }
            set 
            {
                if (Data.Name != value)
                {
                    Modified = true;
                }
                Data.Name = value;
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

        public Dictionary<fmGlobalParameter, fmCalculationBaseParameter> Parameters
        {
            get { return Data.parameters; }
        }

        //public fmValue eta_f
        //{
        //    get { return Data.eta_f; }
        //    set 
        //    {
        //        if (Data.eta_f != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.eta_f = value; 
        //    }
        //}
        //public fmValue rho_f
        //{
        //    get { return Data.rho_f; }
        //    set 
        //    {
        //        if (Data.rho_f != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.rho_f = value; 
        //    }
        //}
        //public fmValue rho_s
        //{
        //    get { return Data.rho_s; }
        //    set 
        //    {
        //        if (Data.rho_s != value)
        //        {
        //            Modified = true;
        //        }
                
        //        Data.rho_s = value; 
        //    }
        //}
        //public fmValue rho_sus
        //{
        //    get { return Data.rho_sus; }
        //    set 
        //    {
        //        if (Data.rho_sus != value)
        //        {
        //            Modified = true;
        //        }
                
        //        Data.rho_sus = value; 
        //    }
        //}
        //public fmValue Cm
        //{
        //    get { return Data.Cm; }
        //    set
        //    {
        //        if (Data.Cm != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.Cm = value; 
        //    }
        //}
        //public fmValue Cv
        //{
        //    get { return Data.Cv; }
        //    set
        //    {
        //        if (Data.Cv != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.Cv = value; 
        //    }
        //}
        //public fmValue C
        //{
        //    get { return Data.C; }
        //    set
        //    {
        //        if (Data.C != value)
        //        {
        //            Modified = true;
        //        } 
        //        Data.C = value; 
        //    }
        //}
        //public fmValue eps0
        //{
        //    get { return Data.eps0; }
        //    set
        //    {
        //        if (Data.eps0 != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.eps0 = value;
        //    }
        //}
        //public fmValue kappa0
        //{
        //    get { return Data.kappa0; }
        //    set
        //    {
        //        if (Data.kappa0 != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.kappa0 = value;
        //    }
        //}
        //public fmValue ne
        //{
        //    get { return Data.ne; }
        //    set
        //    {
        //        if (Data.ne != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.ne = value;
        //    }
        //}
        //public fmValue Pc0
        //{
        //    get { return Data.Pc0; }
        //    set
        //    {
        //        if (Data.Pc0 != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.Pc0 = value;
        //    }
        //}
        //public fmValue rc0
        //{
        //    get { return Data.rc0; }
        //    set
        //    {
        //        if (Data.rc0 != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.rc0 = value;
        //    }
        //}
        //public fmValue a0
        //{
        //    get { return Data.a0; }
        //    set
        //    {
        //        if (Data.a0 != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.a0 = value;
        //    }
        //}
        //public fmValue nc
        //{
        //    get { return Data.nc; }
        //    set
        //    {
        //        if (Data.nc != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.nc = value;
        //    }
        //}
        //public fmValue hce
        //{
        //    get { return Data.hce; }
        //    set
        //    {
        //        if (Data.hce != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.hce = value;
        //    }
        //}
        //public fmValue Rm0
        //{
        //    get { return Data.Rm0; }
        //    set
        //    {
        //        if (Data.Rm0 != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.Rm0 = value;
        //    }
        //}
        //public fmValue A
        //{
        //    get { return Data.A; }
        //    set
        //    {
        //        if (Data.A != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.A = value;
        //    }
        //}
        //public fmValue Dp
        //{
        //    get { return Data.Dp; }
        //    set
        //    {
        //        if (Data.Dp != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.Dp = value;
        //    }
        //}
        //public fmValue hc
        //{
        //    get { return Data.hc; }
        //    set
        //    {
        //        if (Data.hc != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.hc = value;
        //    }
        //}
        //public fmValue Mf
        //{
        //    get { return Data.Mf; }
        //    set
        //    {
        //        if (Data.Mf != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.Mf = value;
        //    }
        //}        
        //public fmValue Ms
        //{
        //    get { return Data.Ms; }
        //    set
        //    {
        //        if (Data.Ms != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.Ms = value;
        //    }
        //}
        //public fmValue Msus
        //{
        //    get { return Data.Msus; }
        //    set
        //    {
        //        if (Data.Msus != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.Msus = value;
        //    }
        //}
        //public fmValue n
        //{
        //    get { return Data.n; }
        //    set
        //    {
        //        if (Data.n != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.n = value;
        //    }
        //}
        //public fmValue Qms
        //{
        //    get { return Data.Qms; }
        //    set
        //    {
        //        if (Data.Qms != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.Qms = value;
        //    }
        //}
        //public fmValue Qmsus
        //{
        //    get { return Data.Qmsus; }
        //    set
        //    {
        //        if (Data.Qmsus != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.Qmsus = value;
        //    }
        //}
        //public fmValue Qsus
        //{
        //    get { return Data.Qsus; }
        //    set
        //    {
        //        if (Data.Qsus != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.Qsus = value;
        //    }
        //}
        //public fmValue sf
        //{
        //    get { return Data.sf; }
        //    set
        //    {
        //        if (Data.sf != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.sf = value;
        //    }
        //}
        //public fmValue tc
        //{
        //    get { return Data.tc; }
        //    set
        //    {
        //        if (Data.tc != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.tc = value;
        //    }
        //}
        //public fmValue tf
        //{
        //    get { return Data.tf; }
        //    set
        //    {
        //        if (Data.tf != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.tf = value;
        //    }
        //}
        //public fmValue Vsus
        //{
        //    get { return Data.Vsus; }
        //    set
        //    {
        //        if (Data.Vsus != value)
        //        {
        //            Modified = true;
        //        }
        //        Data.Vsus = value;
        //    }
        //}
        public fmFilterMachiningCalculator.FilterMachiningCalculationOption FilterMachiningCalculationOption
        {
            get { return Data.filterMachiningCalculationOption; }
            set 
            {
                if (Data.filterMachiningCalculationOption != value)
                {
                    Modified = true;
                }
                Data.filterMachiningCalculationOption = value; 
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
            Data.Name = Name;
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
            BackupData.CopyFrom(Data);
            Modified = false;
        }
        public void Restore()
        {
            Data.CopyFrom(BackupData);
            Modified = false;
        }
        public void Delete()
        {
            filterMachiningBlock.calculationOptionView.Dispose();
            m_ParentSerie.RemoveSimulation(this);
        }
        public void CopyFrom(fmFilterSimulation sim)
        {
            Data.CopyFrom(sim.Data);
            BackupData.CopyFrom(sim.BackupData);
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