using System;
using fmCalculationLibrary;
using CalculationOption=fmCalcBlocksLibrary.Blocks.CalculationOption;
using fmEpsKappaWithneBlock=fmCalcBlocksLibrary.Blocks.fmEpsKappaWithneBlock;
using fmFilterMachiningBlock=fmCalcBlocksLibrary.Blocks.fmFilterMachiningBlock;
using fmPcrcaWithncBlock=fmCalcBlocksLibrary.Blocks.fmPcrcaWithncBlock;
using fmRmhceBlock=fmCalcBlocksLibrary.Blocks.fmRmhceBlock;
using fmSuspensionWithEtafBlock=fmCalcBlocksLibrary.Blocks.fmSuspensionWithEtafBlock;

namespace FilterSimulation.fmFilterObjects
{
    struct fmFilterSimulationData
    {
        public string Name;
        
        public fmValue eta_f;
        public fmValue rho_f;
        public fmValue rho_s;
        public fmValue rho_sus;
        public fmValue Cm;
        public fmValue Cv;
        public fmValue C;

        public fmValue eps0;
        public fmValue kappa0;
        public fmValue ne;

        public fmValue Pc0;
        public fmValue rc0;
        public fmValue a0;
        public fmValue nc;
        
        public fmValue hce;
        public fmValue Rm0;
        
        public fmValue A;
        public fmValue Dp;
        public fmValue hc;
        public fmValue Mf;
        public fmValue Ms;
        public fmValue Msus;
        public fmValue n;
        public fmValue Qms;
        public fmValue Qmsus;
        public fmValue Qsus;
        public fmValue sf;
        public fmValue tc;
        public fmValue tf;
        public fmValue Vsus;

        public CalculationOption calculationOption;
        
        public void CopyFrom(fmFilterSimulationData from)
        {
            this = from;
        }
    }

    public class fmFilterSimulation
    {
        private Guid m_Guid;
        private fmFilterSimSerie m_ParentSerie;
        private fmFilterSimulationData Data, BackupData;
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

        public fmValue eta_f
        {
            get { return Data.eta_f; }
            set 
            {
                if (Data.eta_f != value)
                {
                    Modified = true;
                }
                Data.eta_f = value; 
            }
        }
        public fmValue rho_f
        {
            get { return Data.rho_f; }
            set 
            {
                if (Data.rho_f != value)
                {
                    Modified = true;
                }
                Data.rho_f = value; 
            }
        }
        public fmValue rho_s
        {
            get { return Data.rho_s; }
            set 
            {
                if (Data.rho_s != value)
                {
                    Modified = true;
                }
                
                Data.rho_s = value; 
            }
        }
        public fmValue rho_sus
        {
            get { return Data.rho_sus; }
            set 
            {
                if (Data.rho_sus != value)
                {
                    Modified = true;
                }
                
                Data.rho_sus = value; 
            }
        }
        public fmValue Cm
        {
            get { return Data.Cm; }
            set
            {
                if (Data.Cm != value)
                {
                    Modified = true;
                }
                Data.Cm = value; 
            }
        }
        public fmValue Cv
        {
            get { return Data.Cv; }
            set
            {
                if (Data.Cv != value)
                {
                    Modified = true;
                }
                Data.Cv = value; 
            }
        }
        public fmValue C
        {
            get { return Data.C; }
            set
            {
                if (Data.C != value)
                {
                    Modified = true;
                } 
                Data.C = value; 
            }
        }
        public fmValue eps0
        {
            get { return Data.eps0; }
            set
            {
                if (Data.eps0 != value)
                {
                    Modified = true;
                }
                Data.eps0 = value;
            }
        }
        public fmValue kappa0
        {
            get { return Data.kappa0; }
            set
            {
                if (Data.kappa0 != value)
                {
                    Modified = true;
                }
                Data.kappa0 = value;
            }
        }
        public fmValue ne
        {
            get { return Data.ne; }
            set
            {
                if (Data.ne != value)
                {
                    Modified = true;
                }
                Data.ne = value;
            }
        }
        public fmValue Pc0
        {
            get { return Data.Pc0; }
            set
            {
                if (Data.Pc0 != value)
                {
                    Modified = true;
                }
                Data.Pc0 = value;
            }
        }
        public fmValue rc0
        {
            get { return Data.rc0; }
            set
            {
                if (Data.rc0 != value)
                {
                    Modified = true;
                }
                Data.rc0 = value;
            }
        }
        public fmValue a0
        {
            get { return Data.a0; }
            set
            {
                if (Data.a0 != value)
                {
                    Modified = true;
                }
                Data.a0 = value;
            }
        }
        public fmValue nc
        {
            get { return Data.nc; }
            set
            {
                if (Data.nc != value)
                {
                    Modified = true;
                }
                Data.nc = value;
            }
        }
        public fmValue hce
        {
            get { return Data.hce; }
            set
            {
                if (Data.hce != value)
                {
                    Modified = true;
                }
                Data.hce = value;
            }
        }
        public fmValue Rm0
        {
            get { return Data.Rm0; }
            set
            {
                if (Data.Rm0 != value)
                {
                    Modified = true;
                }
                Data.Rm0 = value;
            }
        }
        public fmValue A
        {
            get { return Data.A; }
            set
            {
                if (Data.A != value)
                {
                    Modified = true;
                }
                Data.A = value;
            }
        }
        public fmValue Dp
        {
            get { return Data.Dp; }
            set
            {
                if (Data.Dp != value)
                {
                    Modified = true;
                }
                Data.Dp = value;
            }
        }
        public fmValue hc
        {
            get { return Data.hc; }
            set
            {
                if (Data.hc != value)
                {
                    Modified = true;
                }
                Data.hc = value;
            }
        }
        public fmValue Mf
        {
            get { return Data.Mf; }
            set
            {
                if (Data.Mf != value)
                {
                    Modified = true;
                }
                Data.Mf = value;
            }
        }        
        public fmValue Ms
        {
            get { return Data.Ms; }
            set
            {
                if (Data.Ms != value)
                {
                    Modified = true;
                }
                Data.Ms = value;
            }
        }
        public fmValue Msus
        {
            get { return Data.Msus; }
            set
            {
                if (Data.Msus != value)
                {
                    Modified = true;
                }
                Data.Msus = value;
            }
        }
        public fmValue n
        {
            get { return Data.n; }
            set
            {
                if (Data.n != value)
                {
                    Modified = true;
                }
                Data.n = value;
            }
        }
        public fmValue Qms
        {
            get { return Data.Qms; }
            set
            {
                if (Data.Qms != value)
                {
                    Modified = true;
                }
                Data.Qms = value;
            }
        }
        public fmValue Qmsus
        {
            get { return Data.Qmsus; }
            set
            {
                if (Data.Qmsus != value)
                {
                    Modified = true;
                }
                Data.Qmsus = value;
            }
        }
        public fmValue Qsus
        {
            get { return Data.Qsus; }
            set
            {
                if (Data.Qsus != value)
                {
                    Modified = true;
                }
                Data.Qsus = value;
            }
        }
        public fmValue sf
        {
            get { return Data.sf; }
            set
            {
                if (Data.sf != value)
                {
                    Modified = true;
                }
                Data.sf = value;
            }
        }
        public fmValue tc
        {
            get { return Data.tc; }
            set
            {
                if (Data.tc != value)
                {
                    Modified = true;
                }
                Data.tc = value;
            }
        }
        public fmValue tf
        {
            get { return Data.tf; }
            set
            {
                if (Data.tf != value)
                {
                    Modified = true;
                }
                Data.tf = value;
            }
        }
        public fmValue Vsus
        {
            get { return Data.Vsus; }
            set
            {
                if (Data.Vsus != value)
                {
                    Modified = true;
                }
                Data.Vsus = value;
            }
        }
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
    }
}