using System;
using System.Collections.Generic;
using FilterSimulation.fmFilterObjects;
using fmCalcBlocksLibrary.Blocks;

namespace FilterSimulation.fmFilterObjects
{
    public struct CurrentObjectsStruct
    {
        static public fmFilterSimSuspension GetFirstChild(fmFilterSimProject prj)
        {
            return prj != null && prj.SuspensionList.Count > 0 ? prj.SuspensionList[0] : null;
        }

        static public fmFilterSimSerie GetFirstChild(fmFilterSimSuspension sus)
        {
            return sus != null && sus.SimSeriesList.Count > 0 ? sus.SimSeriesList[0] : null;
        }

        static public fmFilterSimulation GetFirstChild(fmFilterSimSerie serie)
        {
            return serie != null && serie.SimulationsList.Count > 0 ? serie.SimulationsList[0] : null;
        }

        private fmFilterSimProject m_Project;
        private fmFilterSimSuspension m_Suspension;
        private fmFilterSimSerie m_Serie;
        private fmFilterSimulation m_Simulation;

        public fmFilterSimProject Project
        {
            get { return m_Project; }
            set
            {
                m_Project = value;
                m_Suspension = GetFirstChild(m_Project);
                m_Serie = GetFirstChild(m_Suspension);
                m_Simulation = GetFirstChild(m_Serie);
            }
        }
        public fmFilterSimSuspension Suspension
        {
            get { return m_Suspension; }
            set
            {
                m_Suspension = value;
                m_Project = m_Suspension.Parent;
                m_Serie = GetFirstChild(m_Suspension);
                m_Simulation = GetFirstChild(m_Serie);
            }
        }
        public fmFilterSimSerie Serie
        {
            get { return m_Serie; }
            set
            {
                m_Serie = value;
                m_Suspension = m_Serie.Parent;
                m_Project = m_Suspension.Parent;
                m_Simulation = GetFirstChild(m_Serie);
            }
        }
        public fmFilterSimulation Simulation
        {
            get { return m_Simulation; }
            set
            {
                m_Simulation = value;
                m_Serie = m_Simulation.Parent;
                m_Suspension = m_Serie.Parent;
                m_Project = m_Suspension.Parent;
            }
        }
    }

    public struct CurrentColumnsStruct
    {
        public int Project;
        public int Suspension;
        public int SimSerie;
        public int Simulation;
    }

    public class fmFilterSimSolution
    {
        public List<fmFilterSimProject> Projects = new List<fmFilterSimProject>();
        public CurrentObjectsStruct CurrentObjects;
        public CurrentColumnsStruct CurrentColumns;

        public void AddProject(fmFilterSimProject prj)
        {
            Projects.Add(prj);
        }
        public void RemoveProject(fmFilterSimProject prj)
        {
            Projects.Remove(prj);
        }
        public fmFilterSimSerie FindSerie(Guid guid)
        {
            foreach (fmFilterSimSerie serie in GetAllSeries())
            {
                if (serie.Guid == guid)
                {
                    return serie;
                }
            }
            return null;
        }

        public fmFilterSimSerie FindSerie(string serieName)
        {
            foreach (fmFilterSimSerie serie in GetAllSeries())
            {
                if (serie.Name == serieName)
                {
                    return serie;
                }
            }
            return null;
        }
        
        public fmFilterSimProject FindProject(Guid guid)
        {
            foreach (fmFilterSimProject prj in Projects)
            {
                if (guid == prj.Guid)
                    return prj;
            }
            return null;
        }
        public fmFilterSimSuspension FindSuspension(Guid guid)
        {
            foreach (fmFilterSimProject prj in Projects)
            {
                fmFilterSimSuspension sus = prj.FindSuspension(guid);
                if (sus != null)
                    return sus;
            }
            return null;
        }

        public List<fmFilterSimulation> GetAllSimulations()
        {
            List<fmFilterSimulation> ret = new List<fmFilterSimulation>();
            foreach (fmFilterSimProject prj in Projects)
            {
                ret.AddRange(prj.GetAllSimulations());
            }
            return ret;
        }
        public List<fmFilterSimSerie> GetAllSeries()
        {
            List<fmFilterSimSerie> ret = new List<fmFilterSimSerie>();
            foreach (fmFilterSimProject prj in Projects)
            {
                ret.AddRange(prj.GetAllSeries());
            }
            return ret;
        }

        public fmFilterSimulation FindSimulation(string simName)
        {
            foreach (fmFilterSimulation sim in GetAllSimulations())
                if (sim.Name == simName)
                    return sim;
            return null;
        }

        public fmFilterSimulation FindSimulation(Guid guid)
        {
            foreach (fmFilterSimProject prj in Projects)
            {
                fmFilterSimulation sim = prj.FindSimulation(guid);
                if (sim != null)
                    return sim;
            }
            return null;
        }

        public fmFilterSimulation FindSimulation(fmSuspensionBlock susBlock)
        {
            foreach (fmFilterSimulation sim in GetAllSimulations())
                if (sim.susBlock == susBlock)
                    return sim;
            return null;
        }

        public fmFilterSimulation FindSimulation(fmFilterMachiningBlock filterMachBlock)
        {
            foreach (fmFilterSimulation sim in GetAllSimulations())
                if (sim.filterMachiningBlock == filterMachBlock)
                    return sim;
            return null;
        }

        public fmFilterSimulation FindSimulation(fmRm0hceBlock Rm0hceBlock)
        {
            foreach (fmFilterSimulation sim in GetAllSimulations())
                if (sim.rm0HceBlock == Rm0hceBlock)
                    return sim;
            return null;
        }

        public fmFilterSimulation FindSimulation(fmEps0Kappa0Block eps0Kappa0Block)
        {
            foreach (fmFilterSimulation sim in GetAllSimulations())
                if (sim.eps0Kappa0Block == eps0Kappa0Block)
                    return sim;
            return null;
        }

        public fmFilterSimulation FindSimulation(fmPc0rc0a0Block pc0rc0a0Block)
        {
            foreach (fmFilterSimulation sim in GetAllSimulations())
                if (sim.pc0rc0a0Block == pc0rc0a0Block)
                    return sim;
            return null;
        }

        public fmFilterSimMachineType FindMachineType(string typeSymbol)
        {
            foreach (fmFilterSimMachineType fmt in fmFilterSimMachineType.filterTypesList)
            {
                if (fmt.Symbol == typeSymbol)
                {
                    return fmt;
                }
            }
            return null;
        }

        public void Keep()
        {
            foreach (fmFilterSimProject prj in Projects)
            {
                prj.Keep();
            }
        }
    }
}