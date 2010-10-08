using System;
using System.Collections.Generic;

namespace FilterSimulation.fmFilterObjects
{
    struct fmFilterSimSerieData
    {
        public string name;
        public fmFilterSimMachineType machine;
        public string filterMedium;
        public List<fmFilterSimulation> simList;
        public DateTime lastModifiedDate;
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
            lastModifiedDate = from.lastModifiedDate;
        }

        private static class fmSimSerieDataSerializeTags
        {
            public const string Begin = "SimSerieData Begin";
            public const string End = "SimSerieData End";
            // ReSharper disable InconsistentNaming
            public const string name = "name";
            public const string machineName = "machineName";
            public const string filterMedium = "filterMedium";
            public const string simListSize = "simListSize";
            // ReSharper restore InconsistentNaming
        }

        internal void Serialize(System.IO.TextWriter output)
        {
            output.WriteLine("                    " + fmSimSerieDataSerializeTags.Begin);
            fmSerializeTools.SerializeProperty(output, fmSimSerieDataSerializeTags.name, name, 6);
            fmSerializeTools.SerializeProperty(output, fmSimSerieDataSerializeTags.machineName, machineName, 6);
            machine.Serialize(output);
            fmSerializeTools.SerializeProperty(output, fmSimSerieDataSerializeTags.filterMedium, filterMedium, 6);
            fmSerializeTools.SerializeProperty(output, fmSimSerieDataSerializeTags.simListSize, simList.Count, 6);
            foreach (var p in simList)
            {
                p.Serialize(output);
            }
            output.WriteLine("                    " + fmSimSerieDataSerializeTags.End);
        }

        internal static fmFilterSimSerieData Deserialize(System.IO.TextReader input, fmFilterSimSuspension parentSuspension, fmFilterSimSerie parentSerie)
        {
            input.ReadLine();
            fmFilterSimSerieData serieData = new fmFilterSimSerieData();
            serieData.name = Convert.ToString(fmSerializeTools.DeserializeProperty(input, fmSimSerieDataSerializeTags.name));
            serieData.machineName = Convert.ToString(fmSerializeTools.DeserializeProperty(input, fmSimSerieDataSerializeTags.machineName));
            serieData.machine = fmFilterSimMachineType.Deserialize(input);
            serieData.filterMedium = Convert.ToString(fmSerializeTools.DeserializeProperty(input, fmSimSerieDataSerializeTags.filterMedium));
            int simListSize = Convert.ToInt32(fmSerializeTools.DeserializeProperty(input, fmSimSerieDataSerializeTags.simListSize));
            for (int i = 0; i < simListSize; ++i)
            {
                fmFilterSimulation sim = fmFilterSimulation.Deserialize(input, parentSerie);
            }
            input.ReadLine();
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
                    m_data.lastModifiedDate = DateTime.Now;
                    m_parentSuspension.Modified |= true;
                }
            }
        }
        public bool Checked
        {
            get { return m_checked; }
            set { m_checked = value; }
        }
        public DateTime LastModifiedDate
        {
            get { return m_data.lastModifiedDate; }
            set 
            {
                m_data.lastModifiedDate = value; 
            }
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
            m_data.lastModifiedDate = DateTime.Now;
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
            LastModifiedDate = serie.LastModifiedDate;
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

        private static class fmSimSerieSerializeTags
        {
            public const string Begin = "SimSerie Begin";
            public const string End = "SimSerie End";
            // ReSharper disable InconsistentNaming
            public const string m_checked = "m_checked";
            // ReSharper restore InconsistentNaming
        }

        internal void Serialize(System.IO.TextWriter output)
        {
            output.WriteLine("                " + fmSimSerieSerializeTags.Begin);
            fmSerializeTools.SerializeProperty(output, fmSimSerieSerializeTags.m_checked, m_checked, 5);
            m_data.Serialize(output);
            output.WriteLine("                " + fmSimSerieSerializeTags.End);
        }

        internal static fmFilterSimSerie Deserialize(System.IO.TextReader input, fmFilterSimSuspension parentSuspension)
        {
            input.ReadLine();
            bool m_checked = Convert.ToBoolean(fmSerializeTools.DeserializeProperty(input, fmSimSerieSerializeTags.m_checked));
            fmFilterSimSerie serie = new fmFilterSimSerie(parentSuspension, "_noname", null, "_no_fiter_medium", "_noname_machine");
            fmFilterSimSerieData m_data = fmFilterSimSerieData.Deserialize(input, parentSuspension, serie);
            serie.Name = m_data.name;
            serie.MachineType = m_data.machine;
            serie.MachineName = m_data.machineName;
            serie.FilterMedium = m_data.filterMedium;
            input.ReadLine();
            return serie;
        }
    }
}