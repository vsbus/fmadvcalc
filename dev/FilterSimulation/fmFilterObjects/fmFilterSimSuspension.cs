using System;
using System.Collections.Generic;

namespace FilterSimulation.fmFilterObjects
{
    struct fmFilterSimSuspensionData
    {
        public string name;
        public string material;
        public string customer;
        public List<fmFilterSimSerie> seriesList;

        public void CopyFrom(fmFilterSimSuspensionData from, fmFilterSimSuspension ownerSuspension)
        {
            name = from.name;
            material = from.material;
            customer = from.customer;
            seriesList = new List<fmFilterSimSerie>();
            foreach (fmFilterSimSerie serie in from.seriesList)
            {
                var newSerie = new fmFilterSimSerie { Parent = ownerSuspension };

                seriesList.Add(newSerie);

                newSerie.CopyFrom(serie);
            }
        }

        private static class fmSuspensionDataSerializeTags
        {
            public const string Begin = "SuspensionData Begin";
            public const string End = "SuspensionData End";
            // ReSharper disable InconsistentNaming
            public const string name = "name";
            public const string material = "material";
            public const string customer = "customer";
            public const string seriesListSize = "seriesListSize";
            // ReSharper restore InconsistentNaming
        }

        internal void Serialize(System.IO.TextWriter output)
        {
            output.WriteLine("            " + fmSuspensionDataSerializeTags.Begin);
            fmSerializeTools.SerializeProperty(output, fmSuspensionDataSerializeTags.name, name, 4);
            fmSerializeTools.SerializeProperty(output, fmSuspensionDataSerializeTags.material, material, 4);
            fmSerializeTools.SerializeProperty(output, fmSuspensionDataSerializeTags.customer, customer, 4);
            fmSerializeTools.SerializeProperty(output, fmSuspensionDataSerializeTags.seriesListSize, seriesList.Count, 4);
            foreach (var p in seriesList)
            {
                p.Serialize(output);
            }
            output.WriteLine("            " + fmSuspensionDataSerializeTags.End);
        }

        internal static fmFilterSimSuspensionData Deserialize(System.IO.TextReader input, fmFilterSimSuspension parentSuspension)
        {
            input.ReadLine();
            fmFilterSimSuspensionData susData = new fmFilterSimSuspensionData();
            susData.name = Convert.ToString(fmSerializeTools.DeserializeProperty(input, fmSuspensionDataSerializeTags.name));
            susData.material = Convert.ToString(fmSerializeTools.DeserializeProperty(input, fmSuspensionDataSerializeTags.material));
            susData.customer = Convert.ToString(fmSerializeTools.DeserializeProperty(input, fmSuspensionDataSerializeTags.customer));
            int seriesListSize = Convert.ToInt32(fmSerializeTools.DeserializeProperty(input, fmSuspensionDataSerializeTags.seriesListSize));
            for (int i = 0; i < seriesListSize; ++i)
            {
                fmFilterSimSerie serie = fmFilterSimSerie.Deserialize(input, parentSuspension);
            }
            input.ReadLine();
            return susData;
        }
    }

    public class fmFilterSimSuspension
    {
        private Guid m_guid;
        private fmFilterSimProject m_parentProject;
        private fmFilterSimSuspensionData m_data;
#pragma warning disable 649
        private fmFilterSimSuspensionData m_backupData;
#pragma warning restore 649
        private bool m_modified;
        private bool m_checked = true;

        public List<fmFilterSimSerie> SimSeriesList
        {
            get { return m_data.seriesList; }
        }
        public Guid Guid
        {
            get { return m_guid; }
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
        public string Customer
        {
            get { return m_data.customer; }
            set
            {
                Modified |= m_data.customer != value;
                m_data.customer = value;
            }
        }
        public string Material
        {
            get { return m_data.material; }
            set
            {
                Modified |= m_data.material != value;
                m_data.material = value;
            }
        }
        public bool Modified
        {
            get { return m_modified; }
            set
            {
                m_modified = value;
                m_parentProject.Modified |= value;
            }
        }
        public fmFilterSimProject Parent
        {
            get { return m_parentProject; }
            set { m_parentProject = value; }
        }


        public bool Checked
        {
            get { return m_checked; }
            set { m_checked = value; }
        }


        public fmFilterSimSuspension() { }
        public fmFilterSimSuspension(fmFilterSimProject parentProject, string name, string material, string customer)
        {
            m_guid = Guid.NewGuid();
            if (parentProject != null)
            {
                m_parentProject = parentProject;
                parentProject.AddSuspension(this);
            }
            m_data.name = name;
            m_data.material = material;
            m_data.customer = customer;
            m_data.seriesList = new List<fmFilterSimSerie>();
            Keep();
        }

        public void Keep()
        {
            foreach (fmFilterSimSerie ser in m_data.seriesList)
            {
                ser.Keep();
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
            foreach (fmFilterSimSerie serie in m_data.seriesList.GetRange(0, m_data.seriesList.Count))
                serie.Delete();
            m_parentProject.RemoveSuspension(this);
        }
        public void CopyFrom(fmFilterSimSuspension sus)
        {
            m_guid = sus.m_guid;
            Modified = sus.Modified;
            m_data.CopyFrom(sus.m_data, this);
            m_backupData.CopyFrom(sus.m_backupData, this);
        }
        public void AddSerie(fmFilterSimSerie serie)
        {
            m_data.seriesList.Add(serie);
            Modified = true;
        }
        public void RemoveSerie(fmFilterSimSerie serie)
        {
            m_data.seriesList.Remove(serie);
            Modified = true;
        }

        public List<fmFilterSimulation> GetAllSimulations()
        {
            var ret = new List<fmFilterSimulation>();
            foreach (fmFilterSimSerie serie in SimSeriesList)
            {
                ret.AddRange(serie.SimulationsList);
            }
            return ret;
        }

        public fmFilterSimSerie FindSerie(Guid guid)
        {
            foreach (fmFilterSimSerie ser in m_data.seriesList)
            {
                if (ser.Guid == guid)
                    return ser;
            }
            return null;
        }

        public fmFilterSimulation FindSimulation(Guid guid)
        {
            foreach (fmFilterSimSerie ser in m_data.seriesList)
            {
                fmFilterSimulation sim = ser.FindSimulation(guid);
                if (sim != null)
                    return sim;
            }
            return null;
        }

        private static class fmSuspensionSerializeTags
        {
            public const string Begin = "Suspension Begin";
            public const string End = "Suspension End";
            // ReSharper disable InconsistentNaming
            public const string m_checked = "m_checked";
            // ReSharper restore InconsistentNaming
        }

        internal void Serialize(System.IO.TextWriter output)
        {
            output.WriteLine("        " + fmSuspensionSerializeTags.Begin);
            fmSerializeTools.SerializeProperty(output, fmSuspensionSerializeTags.m_checked, m_checked, 3);
            m_data.Serialize(output);
            output.WriteLine("        " + fmSuspensionSerializeTags.End);
        }

        internal static fmFilterSimSuspension Deserialize(System.IO.TextReader input, fmFilterSimProject parentProject)
        {
            input.ReadLine();
            bool m_checked = Convert.ToBoolean(fmSerializeTools.DeserializeProperty(input, fmSuspensionSerializeTags.m_checked));
            fmFilterSimSuspension sus = new fmFilterSimSuspension(parentProject, "_noname", "_unknown_material", "_unknown_customer");
            fmFilterSimSuspensionData data = fmFilterSimSuspensionData.Deserialize(input, sus);
            sus.Name = data.name;
            sus.Material = data.material;
            sus.Customer = data.customer;
            input.ReadLine();
            return sus;
        }
    }
}