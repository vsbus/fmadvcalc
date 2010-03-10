using System;
using fmCalculationLibrary;
using CalculationOption=fmCalcBlocksLibrary.Blocks.CalculationOption;
using fmEpsKappaWithneBlock=fmCalcBlocksLibrary.Blocks.fmEps0Kappa0WithneBlock;
using fmFilterMachiningBlock=fmCalcBlocksLibrary.Blocks.fmFilterMachiningBlock;
using fmPcrcaWithncBlock=fmCalcBlocksLibrary.Blocks.fmPc0rc0a0WithncBlock;
using fmRmhceBlock=fmCalcBlocksLibrary.Blocks.fmRm0hceBlock;
using fmSuspensionWithEtafBlock=fmCalcBlocksLibrary.Blocks.fmSuspensionWithEtafBlock;
using System.Collections.Generic;

namespace FilterSimulation.fmFilterObjects
{
    class fmFilterSimulationData
    {
        public string Name;
        public Dictionary<fmCalcBlocksLibrary.fmGlobalParameter, fmValue> parameters = new Dictionary<fmCalcBlocksLibrary.fmGlobalParameter, fmValue>();

        //public fmValue eta_f
        //{
        //    get { return parameters[fmCalcBlocksLibrary.fmGlobalParameter.eta_f]; }
        //    set { parameters[fmCalcBlocksLibrary.fmGlobalParameter.eta_f]
        //}
        //public fmValue rho_f;
        //public fmValue rho_s;
        //public fmValue rho_sus;
        //public fmValue Cm;
        //public fmValue Cv;
        //public fmValue C;

        //public fmValue eps0;
        //public fmValue kappa0;
        //public fmValue ne;

        //public fmValue Pc0;
        //public fmValue rc0;
        //public fmValue a0;
        //public fmValue nc;
        
        //public fmValue hce;
        //public fmValue Rm0;
        
        //public fmValue A;
        //public fmValue Dp;
        //public fmValue hc;
        //public fmValue Mf;
        //public fmValue Ms;
        //public fmValue Msus;
        //public fmValue n;
        //public fmValue Qms;
        //public fmValue Qmsus;
        //public fmValue Qsus;
        //public fmValue sf;
        //public fmValue tc;
        //public fmValue tf;
        //public fmValue Vsus;

        public CalculationOption calculationOption;

        public void CopyFrom(fmFilterSimulationData from)
        {
            foreach (fmCalcBlocksLibrary.fmGlobalParameter p in from.parameters.Keys)
            {
                parameters[p] = from.parameters[p];
            }
        }

        public fmFilterSimulationData()
        {
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.eta_f] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.rho_f] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.rho_s] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.rho_sus] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Cm] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Cv] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.C] = new fmValue();

            parameters[fmCalcBlocksLibrary.fmGlobalParameter.eps0] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.kappa0] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.ne] = new fmValue();

            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Pc0] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.rc0] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.a0] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.nc] = new fmValue();

            parameters[fmCalcBlocksLibrary.fmGlobalParameter.eta_f] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.eta_f] = new fmValue();

            parameters[fmCalcBlocksLibrary.fmGlobalParameter.hce] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Rm0] = new fmValue();
            


            parameters[fmCalcBlocksLibrary.fmGlobalParameter.A] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Dp] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.hc] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Mf] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Ms] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Msus] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.n] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qms] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qmsus] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qsus] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.sf] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.tc] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.tf] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Vsus] = new fmValue();

            parameters[fmCalcBlocksLibrary.fmGlobalParameter.eps] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.kappa] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Pc] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.rc] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.a] = new fmValue();

            parameters[fmCalcBlocksLibrary.fmGlobalParameter.tr] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.hc_over_tf] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.dhc_over_dt] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qf] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qf_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qs] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qs_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qc] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qc_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qsus_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qmsus_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qms_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qmf] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qmf_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qmc] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Qmc_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qf] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qf_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qs] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qs_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qc] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qc_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qsus] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qsus_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qmsus] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qmsus_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qms] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qms_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qmf] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qmf_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qmc] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.qmc_d] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Vf] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.mf] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.vf] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.ms] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.vs] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.msus] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.vsus] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.mc] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.vc] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Vc] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Mc] = new fmValue();
            parameters[fmCalcBlocksLibrary.fmGlobalParameter.Vs] = new fmValue();
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
        public fmEpsKappaWithneBlock eps0Kappa0Block;
        public fmPcrcaWithncBlock pc0rc0a0Block;
        public fmRmhceBlock rm0HceBlock;
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
                if (value)
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

        public Dictionary<fmCalcBlocksLibrary.fmGlobalParameter, fmValue> Parameters
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
        public CalculationOption CalculationOption
        {
            get { return Data.calculationOption; }
            set 
            {
                if (Data.calculationOption != value)
                {
                    Modified = true;
                }
                Data.calculationOption = value; 
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
            //Data.Guid = sim.Data.Guid;
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

            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.eta_f] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.eta_f];

            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.rho_f] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.rho_f];
            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.rho_s] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.rho_s];
            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.rho_sus] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.rho_sus];

            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.Cm] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.Cm];
            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.Cv] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.Cv];
            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.C] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.C];
            
            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.eps0] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.eps0];
            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.kappa0] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.kappa0];
            
            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.nc] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.nc];
            
            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.Pc0] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.Pc0];
            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.rc0] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.rc0];
            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.a0] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.a0];
            
            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.ne] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.ne];
            
            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.hce] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.hce];
            Parameters[fmCalcBlocksLibrary.fmGlobalParameter.Rm0] = simulation.Parameters[fmCalcBlocksLibrary.fmGlobalParameter.Rm0];
            
            //foreach (fmCalcBlocksLibrary.fmGlobalParameter p in Parameters.Keys)
            //{
            //    if (p.Kind == fmCalcBlocksLibrary.fmGlobalParameter.fmGlobalParameterKind.SuspensionParameterKind)
            //    {
            //        Parameters[p] = simulation.Parameters[p];
            //    }
            //}

        }

        public static void CopyVariableParametersFromSimulationToBlock(fmFilterSimulation sim, fmCalcBlocksLibrary.Blocks.fmBaseBlock block)
        {
            foreach (fmCalcBlocksLibrary.BlockParameter.fmBlockParameter p in block.Parameters)
            {
                p.value = sim.Parameters[p.globalParameter];
            }
        }

        public static void CopyConstantParametersFromSimulationToBlock(fmFilterSimulation sim, fmCalcBlocksLibrary.Blocks.fmBaseBlock block)
        {
            foreach (fmCalcBlocksLibrary.BlockParameter.fmBlockConstantParameter p in block.ConstantParameters)
            {
                p.value = sim.Parameters[p.globalParameter];
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
                sim.Parameters[p.globalParameter] = p.value;
            }
        }

        public static void CopyVariableParametersFromBlockToSimulation(fmCalcBlocksLibrary.Blocks.fmBaseBlock block, fmFilterSimulation sim)
        {
            foreach (fmCalcBlocksLibrary.BlockParameter.fmBlockParameter p in block.Parameters)
            {
                sim.Parameters[p.globalParameter] = p.value;
            }
        }
    }
}