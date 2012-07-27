using System;
using System.Collections.Generic;
using System.Xml;

namespace FilterSimulation.fmFilterObjects
{
    struct fmFilterSimSerieData
    {
        public string name;
        public fmFilterSimMachineType machine;
        public string filterMedium;
        public List<fmFilterSimulation> simList;
        public string machineName;

        public void CopyFrom(fmFilterSimSerieData from, fmFilterSimSerie ownerSimSerie)
        {
            name = from.name;
            machine = from.machine;
            machineName = from.machineName;
            filterMedium = from.filterMedium;
            simList = new List<fmFilterSimulation>();
            foreach (fmFilterSimulation sim in from.simList)
            {
                var newSim = new fmFilterSimulation {Parent = ownerSimSerie};

                simList.Add(newSim);
                newSim.CopyFrom(sim);
            }
        }

        public static class fmSimSerieDataSerializeTags
        {
            public const string Serie = "Serie";
            public const string Name = "name";
            public const string MachineName = "machineName";
            public const string FilterMedium = "filterMedium";
        }

        internal void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement(fmSimSerieDataSerializeTags.Serie);
            writer.WriteElementString(fmSimSerieDataSerializeTags.Name, name);
            writer.WriteElementString(fmSimSerieDataSerializeTags.MachineName, machineName);
            machine.Serialize(writer);
            writer.WriteElementString(fmSimSerieDataSerializeTags.FilterMedium, filterMedium);
            foreach (var p in simList)
            {
                p.Serialize(writer);
            }
            writer.WriteEndElement();
        }

        internal static fmFilterSimSerieData Deserialize(XmlNode xmlNode, fmFilterSimSuspension parentSuspension, fmFilterSimSerie parentSerie)
        {
            var serieData = new fmFilterSimSerieData();
            serieData.name = xmlNode.SelectSingleNode(fmSimSerieDataSerializeTags.Name).InnerText;
            serieData.machineName = xmlNode.SelectSingleNode(fmSimSerieDataSerializeTags.MachineName).InnerText;
            serieData.machine = fmFilterSimMachineType.Deserialize(xmlNode.SelectSingleNode(fmFilterSimMachineType.fmMachineSerializeTags.Machine));
            serieData.filterMedium = xmlNode.SelectSingleNode(fmSimSerieDataSerializeTags.FilterMedium).InnerText;
            XmlNodeList simList = xmlNode.SelectNodes(fmFilterSimulation.fmFilterSimulationSerializeTags.Simulation);
            foreach (XmlNode simNode in simList)
            {
                fmFilterSimulation sim = fmFilterSimulation.Deserialize(simNode, parentSerie);
            }
            return serieData;
        }
    }

    public class fmFilterSimSerie
    {
        private Guid m_guid;
        private fmFilterSimSuspension m_parentSuspension;
        private fmFilterSimSerieData m_data;
#pragma warning disable 649
        private fmFilterSimSerieData m_backupData;
#pragma warning restore 649
        private bool m_modified;
        private bool m_checked = true;

        public List<fmFilterSimulation> SimulationsList
        {
            get { return m_data.simList; }
        }
        public Guid Guid
        {
            get { return m_guid; }
        }
        public fmFilterSimSuspension Parent
        {
            get { return m_parentSuspension; }
            set { m_parentSuspension = value; }
        }
        public string Name
        {
            get { return m_data.name; }
            set 
            {
                Modified |= m_data.name != value;
                m_data.name = value; 
            }
        }
        public fmFilterSimMachineType MachineType
        {
            get { return m_data.machine; }
            set
            {
                Modified |= m_data.machine != value;
                m_data.machine = value;
            }
        }
        
        public string FilterMedium
        {
            get { return m_data.filterMedium; }
            set
            {
                Modified |= m_data.filterMedium != value;
                m_data.filterMedium = value;
            }
        }
        public bool Modified
        {
            get { return m_modified; }
            set
            {
                m_modified = value;
                if (value)
                {
                    m_parentSuspension.Modified |= true;
                }
            }
        }
        public bool Checked
        {
            get { return m_checked; }
            set { m_checked = value; }
        }
        public string MachineName
        {
            get { return m_data.machineName; }
            set
            {
                Modified |= m_data.machineName != value;
                m_data.machineName = value;
            }
        }


        public fmFilterSimSerie() 
        {
        }

        public fmFilterSimSerie(fmFilterSimSuspension parentSuspension, string name, fmFilterSimMachineType machine, string filterMedium, string machineName)
        {
            m_guid = Guid.NewGuid();
            if (parentSuspension != null)
            {
                m_parentSuspension = parentSuspension;
                parentSuspension.AddSerie(this);
            }
            m_data.name = name;
            m_data.machine = machine;
            m_data.filterMedium = filterMedium;
            m_data.machineName = machineName;
            m_data.simList = new List<fmFilterSimulation>();
            Keep();
        }

        public fmFilterSimSerie(fmFilterSimSuspension parentSuspension, fmFilterSimSerie toCopy)
        {
            m_guid = Guid.NewGuid();
            if (parentSuspension != null)
            {
                m_parentSuspension = parentSuspension;
                parentSuspension.AddSerie(this);
            }

            m_data.name = toCopy.Name;
            m_data.machine = toCopy.MachineType;
            m_data.filterMedium = toCopy.FilterMedium;
            m_data.machineName = toCopy.MachineName;
            m_data.simList = new List<fmFilterSimulation>();
            foreach (fmFilterSimulation sim in toCopy.SimulationsList)
            {
                new fmFilterSimulation(this, sim);
            }
                        
            Keep();
        }

        public void Keep()
        {
            foreach (fmFilterSimulation sim in m_data.simList)
            {
                sim.Keep();
            }

            m_backupData.CopyFrom(m_data, this);
            Modified = false;
        }
        public void Restore()
        {
            m_data.CopyFrom(m_backupData, this);
            Modified = false;
        }
        public void Delete()
        {
            foreach (fmFilterSimulation sim in m_data.simList.GetRange(0, m_data.simList.Count))
                sim.Delete();
            m_parentSuspension.RemoveSerie(this);
        }
        public void CopyFrom(fmFilterSimSerie serie)
        {
            m_guid = serie.m_guid;
            m_data.CopyFrom(serie.m_data, this);
            m_backupData.CopyFrom(serie.m_backupData, this);
            Modified = serie.Modified;
        }
        public void AddSimulation(fmFilterSimulation sim)
        {
            m_data.simList.Add(sim);
            Modified = true;
        }
        public void RemoveSimulation(fmFilterSimulation sim)
        {
            m_data.simList.Remove(sim);
            Modified = true;
        }
        public fmFilterSimulation FindSimulation(Guid guid)
        {
            foreach (fmFilterSimulation sim in m_data.simList)
            {
                if (sim.Guid == guid)
                    return sim;
            }
            return null;
        }

        public static class fmSimSerieSerializeTags
        {
            public const string SimSerie = "SimSerie";
            public const string Checked = "m_checked";
        }

        internal void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement(fmSimSerieSerializeTags.SimSerie);
            writer.WriteElementString(fmSimSerieSerializeTags.Checked, m_checked.ToString());
            m_data.Serialize(writer);
            writer.WriteEndElement();
        }

        internal static fmFilterSimSerie Deserialize(XmlNode xmlNode, fmFilterSimSuspension parentSuspension)
        {
            bool m_checked = false;
            fmSerializeTools.DeserializeBoolProperty(ref m_checked, xmlNode, fmSimSerieSerializeTags.Checked);

            var serie = new fmFilterSimSerie(parentSuspension, "_noname", null, "_no_fiter_medium", "_noname_machine");
            fmFilterSimSerieData m_data =
                fmFilterSimSerieData.Deserialize(
                    xmlNode.SelectSingleNode(fmFilterSimSerieData.fmSimSerieDataSerializeTags.Serie), parentSuspension,
                    serie);
            serie.Name = m_data.name;
            serie.MachineType = m_data.machine;
            serie.MachineName = m_data.machineName;
            serie.FilterMedium = m_data.filterMedium;
            return serie;
        }
    }
}