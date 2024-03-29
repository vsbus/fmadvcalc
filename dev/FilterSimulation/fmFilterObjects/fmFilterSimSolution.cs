using System;
using System.Collections.Generic;
using fmCalcBlocksLibrary.Blocks;
using System.Xml;

namespace FilterSimulation.fmFilterObjects
{
    public struct fmCurrentObjectsStruct
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

        private fmFilterSimProject m_project;
        private fmFilterSimSuspension m_suspension;
        private fmFilterSimSerie m_serie;
        private fmFilterSimulation m_simulation;

        public fmFilterSimProject Project
        {
            get { return m_project; }
            set
            {
                m_project = value;
                m_suspension = GetFirstChild(m_project);
                m_serie = GetFirstChild(m_suspension);
                m_simulation = GetFirstChild(m_serie);
            }
        }
        public fmFilterSimSuspension Suspension
        {
            get { return m_suspension; }
            set
            {
                m_suspension = value;
                m_project = m_suspension.Parent;
                m_serie = GetFirstChild(m_suspension);
                m_simulation = GetFirstChild(m_serie);
            }
        }
        public fmFilterSimSerie Serie
        {
            get { return m_serie; }
            set
            {
                m_serie = value;
                m_suspension = m_serie.Parent;
                m_project = m_suspension.Parent;
                m_simulation = GetFirstChild(m_serie);
            }
        }
        public fmFilterSimulation Simulation
        {
            get { return m_simulation; }
            set
            {
                m_simulation = value;
                m_serie = m_simulation.Parent;
                m_suspension = m_serie.Parent;
                m_project = m_suspension.Parent;
            }
        }
    }

    public struct fmCurrentColumnsStruct
    {
        public int project;
        public int suspension;
        public int simSerie;
        public int simulation;
    }

    public class fmFilterSimSolution
    {
        public List<fmFilterSimProject> projects = new List<fmFilterSimProject>();
        public fmCurrentObjectsStruct currentObjects;
        public fmCurrentColumnsStruct currentColumns;

        public void AddProject(fmFilterSimProject prj)
        {
            projects.Add(prj);
        }
        public void RemoveProject(fmFilterSimProject prj)
        {
            projects.Remove(prj);
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
                if (serie.GetName() == serieName)
                {
                    return serie;
                }
            }
            return null;
        }
        
        public fmFilterSimProject FindProject(Guid guid)
        {
            foreach (fmFilterSimProject prj in projects)
            {
                if (guid == prj.Guid)
                    return prj;
            }
            return null;
        }
        public fmFilterSimSuspension FindSuspension(Guid guid)
        {
            foreach (fmFilterSimProject prj in projects)
            {
                fmFilterSimSuspension sus = prj.FindSuspension(guid);
                if (sus != null)
                    return sus;
            }
            return null;
        }

        public List<fmFilterSimulation> GetAllSimulations()
        {
            var ret = new List<fmFilterSimulation>();
            foreach (fmFilterSimProject prj in projects)
            {
                ret.AddRange(prj.GetAllSimulations());
            }
            return ret;
        }
        public List<fmFilterSimSerie> GetAllSeries()
        {
            var ret = new List<fmFilterSimSerie>();
            foreach (fmFilterSimProject prj in projects)
            {
                ret.AddRange(prj.GetAllSeries());
            }
            return ret;
        }

        public fmFilterSimulation FindSimulation(string simName)
        {
            foreach (fmFilterSimulation sim in GetAllSimulations())
                if (sim.GetName() == simName)
                    return sim;
            return null;
        }

        public fmFilterSimulation FindSimulation(Guid guid)
        {
            foreach (fmFilterSimProject prj in projects)
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

        public fmFilterSimulation FindSimulation(fmRm0HceBlock rm0HceBlock)
        {
            foreach (fmFilterSimulation sim in GetAllSimulations())
                if (sim.rm0HceBlock == rm0HceBlock)
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

        public fmFilterSimulation FindSimulation(fmPc0Rc0A0Block pc0Rc0A0Block)
        {
            foreach (fmFilterSimulation sim in GetAllSimulations())
                if (sim.pc0Rc0A0Block == pc0Rc0A0Block)
                    return sim;
            return null;
        }

        public void Keep()
        {
            foreach (fmFilterSimProject prj in projects)
            {
                prj.Keep();
            }
        }

        private static class fmSolutionSerializeTags
        {
            public const string ProjectsData = "Projects_Data";
            public const string Version = "Version";

            public const string CurrentSelectedSimulation = "CurrentSelectedSimulation";
            public const string CurrentProject = "CurrentProject";
            public const string CurrentSuspension = "CurrentSuspension";
            public const string CurrentSimSerie = "CurrentSimSerie";
            public const string CurrentSimulation = "CurrentSimulation";

            public const string LastSelectedSimulation = "LastSelectedSimulation";

            public const string LastDataCheckings = "LastDataCheckings";
            public const string Project = "Project";
            public const string Suspension = "Suspension";
            public const string Serie = "Serie";
            public const string Simulation = "Simulation";

            public const string FileName = "FileName";
        }

        public void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement(fmSolutionSerializeTags.ProjectsData);
            foreach (var project in projects)
            {
                project.Serialize(writer);
            }
            SerializeCurrentSimulationSelection(writer);
            writer.WriteEndElement();
        }

        private void SerializeCurrentSimulationSelection(XmlWriter writer)
        {
            writer.WriteStartElement(fmSolutionSerializeTags.CurrentSelectedSimulation);
            writer.WriteElementString(fmSolutionSerializeTags.CurrentProject, currentObjects.Project.GetName());
            writer.WriteElementString(fmSolutionSerializeTags.CurrentSuspension, currentObjects.Suspension.GetName());
            writer.WriteElementString(fmSolutionSerializeTags.CurrentSimSerie, currentObjects.Serie.GetName());
            writer.WriteElementString(fmSolutionSerializeTags.CurrentSimulation, currentObjects.Simulation.GetName());
            writer.WriteEndElement();
        }

        public void SerializeLastSelectedSimulation(XmlWriter writer)
        {
            writer.WriteStartElement(fmSolutionSerializeTags.LastSelectedSimulation);
            SerializeCurrentSimulationSelection(writer);
            writer.WriteEndElement();
        }

        public void SerializeLastDataCheckings(XmlWriter writer)
        {
            writer.WriteStartElement(fmSolutionSerializeTags.LastDataCheckings);

            foreach (fmFilterSimProject project in projects)
            {
                if (project.Checked)
                    writer.WriteElementString(fmSolutionSerializeTags.Project, project.GetName());

                foreach (fmFilterSimSuspension susp in project.SuspensionList)
                {
                    if(susp.Checked)
                        writer.WriteElementString(fmSolutionSerializeTags.Suspension, susp.GetName());

                    foreach (fmFilterSimSerie serie in susp.SimSeriesList)
                    {
                        if (serie.Checked)
                            writer.WriteElementString(fmSolutionSerializeTags.Serie, serie.GetName());

                        foreach (fmFilterSimulation sim in serie.SimulationsList)
                        {
                            if(sim.Checked)
                                writer.WriteElementString(fmSolutionSerializeTags.Simulation, sim.GetName());
                        }
                    }
                }
            }

            writer.WriteEndElement();
        }

        public static fmFilterSimSolution Deserialize(XmlNode node)
        {
            var solution = new fmFilterSimSolution();
            node = node.SelectSingleNode(fmSolutionSerializeTags.ProjectsData);
            if (node != null)
            {
                XmlNodeList projectNodes = node.SelectNodes(fmFilterSimProject.fmProjectSerializeTags.Project);
                foreach (XmlNode projectNode in projectNodes)
                {
                    fmFilterSimProject.Deserialize(projectNode, solution);
                }
            }
            DeserializeCurrentSimulationSelection(node, solution);
            return solution;
        }

        public static void DeserializeDefaultData(XmlNode node, fmFilterSimulation sim)
        {
            node = node.SelectSingleNode(fmSolutionSerializeTags.ProjectsData);
            fmFilterSimulationData simData = new fmFilterSimulationData();
            if (node != null)
            {                
                node = node.SelectSingleNode("Project");
                node = node.SelectSingleNode("Suspension");
                node = node.SelectSingleNode("SuspensionData");
                XmlNodeList nodes = node.SelectNodes("SimSerie");

                foreach (XmlNode n in nodes)
                {
                    var sn = n.SelectSingleNode("Serie");
                    if (sn.InnerText == "Pneuma Press")
                    {
                        node = node.SelectSingleNode("Simulation");

                        simData = fmFilterSimulationData.Deserialize(
                            node.SelectSingleNode(
                                fmFilterSimulationData.fmFilterSimulationDataSerializeTags.FilterSimulationData));
                    }
                }               
                
            }
            foreach (var p in simData.parameters.Values)
            {
                sim.Parameters[p.globalParameter] = p;
            }
            sim.Data.CopyFrom(simData);
        }

        private static void DeserializeCurrentSimulationSelection(XmlNode node, fmFilterSimSolution solution)
        {
            node = node.SelectSingleNode(fmSolutionSerializeTags.CurrentSelectedSimulation);
            if (node == null)
            {
                return;
            }
            string projectName = node.SelectSingleNode(fmSolutionSerializeTags.CurrentProject).InnerText;
            string suspensionName = node.SelectSingleNode(fmSolutionSerializeTags.CurrentSuspension).InnerText;
            string serieName = node.SelectSingleNode(fmSolutionSerializeTags.CurrentSimSerie).InnerText;
            string simulationName = node.SelectSingleNode(fmSolutionSerializeTags.CurrentSimulation).InnerText;
            foreach (fmFilterSimulation simulation in solution.GetAllSimulations())
            {
                fmFilterSimSerie serie = simulation.Parent;
                fmFilterSimSuspension suspension = serie.Parent;
                fmFilterSimProject project = suspension.Parent;
                if (simulation.GetName() == simulationName
                    && serie.GetName() == serieName
                    && suspension.GetName() == suspensionName
                    && project.GetName() == projectName)
                {
                    solution.currentObjects.Project = project;
                    solution.currentObjects.Suspension = suspension;
                    solution.currentObjects.Serie = serie;
                    solution.currentObjects.Simulation = simulation;
                    break;
                }
            }
        }

        public fmFilterSimSolution DeserializeLastSelectedSimulation(XmlNode node, fmFilterSimSolution solution) 
        {
            node = node.SelectSingleNode(fmSolutionSerializeTags.LastSelectedSimulation);
            if (node == null)
                return solution;
            DeserializeCurrentSimulationSelection(node, solution);

            return solution;
        }

        public void DeserializeLastDataCheckings(XmlNode node)
        {
            node = node.SelectSingleNode(fmSolutionSerializeTags.LastDataCheckings);
            if (node == null)
                return;

            var projectNodes = node.SelectNodes(fmSolutionSerializeTags.Project);
            var suspensionNodes = node.SelectNodes(fmSolutionSerializeTags.Suspension);
            var seriesNodes = node.SelectNodes(fmSolutionSerializeTags.Serie);
            var simulationNodes = node.SelectNodes(fmSolutionSerializeTags.Simulation);


            foreach (fmFilterSimProject project in projects)
            {
                project.Checked = false;
                foreach (XmlNode projNode in projectNodes)
                {
                    if (project.GetName() == projNode.InnerText)
                        project.Checked = true;
                }
                foreach (fmFilterSimSuspension susp in project.SuspensionList)
                {
                    susp.Checked = false;
                    foreach (XmlNode suspNode in suspensionNodes)
                    {
                        if (susp.GetName() == suspNode.InnerText)
                            susp.Checked = true;
                    }
                    foreach (fmFilterSimSerie serie in susp.SimSeriesList)
                    {
                        serie.Checked = false;
                        foreach (XmlNode serieNode in seriesNodes)
                        {
                            if (serie.GetName() == serieNode.InnerText)
                                serie.Checked = true;
                        }
                        foreach (fmFilterSimulation sim in serie.SimulationsList)
                        {
                            sim.Checked = false;
                            foreach (XmlNode simNode in simulationNodes)
                            {
                                if (sim.GetName() == simNode.InnerText)
                                    sim.Checked = true;
                            }
                        }
                    }
                }
            }        
        }

        internal fmFilterSimulation FindSimulation(fmSigmaPke0PkePcdRcdAlphadBlock deliquoringSigmaPkeBlock)
        {
            foreach (fmFilterSimulation sim in GetAllSimulations())
                if (sim.deliquoringSigmaPkeBlock == deliquoringSigmaPkeBlock)
                    return sim;
            return null;
        }

        internal fmFilterSimulation FindSimulation(fmEps0dNedEpsdBlock deliquoringEps0NeEpsBlock)
        {
            foreach (fmFilterSimulation sim in GetAllSimulations())
                if (sim.deliquoringEps0NeEpsBlock == deliquoringEps0NeEpsBlock)
                    return sim;
            return null;
        }

        internal fmFilterSimulation FindSimulation(fmSremTettaAdAgDHRmMmoleFPeqBlock deliquoringSremTettaAdAgDHRmMmoleFPeqBlock)
        {
            foreach (fmFilterSimulation sim in GetAllSimulations())
                if (sim.deliquoringSremTettaAdAgDHMmoleFPeqBlock == deliquoringSremTettaAdAgDHRmMmoleFPeqBlock)
                    return sim;
            return null;
        }
    }
}