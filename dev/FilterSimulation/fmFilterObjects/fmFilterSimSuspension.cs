using System;
using System.Collections.Generic;
using System.Xml;
using FilterSimulation.fmFilterObjects.Interfaces;

namespace FilterSimulation.fmFilterObjects
{
    struct fmFilterSimSuspensionData
    {
        public string name;
        public string material;
        public string customer;
        public string comments;
        public List<fmFilterSimSerie> seriesList;

        public void CopyFrom(fmFilterSimSuspensionData from, fmFilterSimSuspension ownerSuspension)
        {
            name = from.name;
            material = from.material;
            customer = from.customer;
            comments = from.comments;
            seriesList = new List<fmFilterSimSerie>();
            foreach (fmFilterSimSerie serie in from.seriesList)
            {
                var newSerie = new fmFilterSimSerie { Parent = ownerSuspension };

                seriesList.Add(newSerie);

                newSerie.CopyFrom(serie);
            }
        }

        public static class fmSuspensionDataSerializeTags
        {
            public const string SuspensionData = "SuspensionData";
            public const string Name = "name";
            public const string Material = "material";
            public const string Customer = "customer";
        }

        internal void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement(fmSuspensionDataSerializeTags.SuspensionData);
            writer.WriteElementString(fmSuspensionDataSerializeTags.Name, name);
            writer.WriteElementString(fmSuspensionDataSerializeTags.Material, material);
            writer.WriteElementString(fmSuspensionDataSerializeTags.Customer, customer);
            foreach (var p in seriesList)
            {
                p.Serialize(writer);
            }
            writer.WriteEndElement();
        }

        internal static fmFilterSimSuspensionData Deserialize(XmlNode xmlNode, fmFilterSimSuspension parentSuspension)
        {
            var susData = new fmFilterSimSuspensionData();
            susData.name = xmlNode.SelectSingleNode(fmSuspensionDataSerializeTags.Name).InnerText;
            susData.material = xmlNode.SelectSingleNode(fmSuspensionDataSerializeTags.Material).InnerText;
            susData.customer = xmlNode.SelectSingleNode(fmSuspensionDataSerializeTags.Customer).InnerText;
            XmlNodeList seriesList = xmlNode.SelectNodes(fmFilterSimSerie.fmSimSerieSerializeTags.SimSerie);
            foreach (XmlNode serieNode in seriesList)
            {
                fmFilterSimSerie serie = fmFilterSimSerie.Deserialize(serieNode, parentSuspension);
            }
            return susData;
        }
    }

    public class fmFilterSimSuspension : IComments
    {
        private Guid m_guid;
        private fmFilterSimProject m_parentProject;
        private fmFilterSimSuspensionData m_data;
#pragma warning disable 649
        private fmFilterSimSuspensionData m_backupData;
#pragma warning restore 649
        private bool m_modified;
        private bool m_kidsmodified;
        private bool m_checked = true;

        public List<fmFilterSimSerie> SimSeriesList
        {
            get { return m_data.seriesList; }
        }
        public Guid Guid
        {
            get { return m_guid; }
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
                m_parentProject.KidsModified |= value;
            }
        }
        public bool KidsModified
        {
            get { return m_kidsmodified; }
            set
            {
                m_kidsmodified = value;

                if (value)
                {
                    m_parentProject.KidsModified |= true;
                }
                else
                {
                    bool tmpModified = false;
                    foreach (fmFilterSimSuspension susp in Parent.SuspensionList)
                    {
                        if (susp.Modified || susp.KidsModified)
                            tmpModified = true;
                    }

                    Parent.KidsModified = tmpModified;
                }

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

        public fmFilterSimSuspension(fmFilterSimProject parentProject, fmFilterSimSuspension toCopy)
        {
            m_guid = Guid.NewGuid();
            if (parentProject != null)
            {
                m_parentProject = parentProject;
                parentProject.AddSuspension(this);
            }

            m_data.name = toCopy.GetName();
            m_data.material = toCopy.Material;
            m_data.customer = toCopy.Customer;
            m_data.seriesList = new List<fmFilterSimSerie>();
            foreach (fmFilterSimSerie serie in toCopy.SimSeriesList)
            {
                new fmFilterSimSerie(this, serie);
            }
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
            KidsModified = false;
        }
        public void Restore()
        {
            m_data.CopyFrom(m_backupData, this);
            Modified = false;

            KidsModified = false;
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

        public static class fmSuspensionSerializeTags
        {
            public const string Suspension = "Suspension";
            public const string Checked = "m_checked";
            public const string Comments = "Comments";
        }

        internal void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement(fmSuspensionSerializeTags.Suspension);
            writer.WriteElementString(fmSuspensionSerializeTags.Checked, m_checked.ToString());
            writer.WriteElementString(fmSuspensionSerializeTags.Comments, GetComments());
            m_data.Serialize(writer);
            writer.WriteEndElement();
        }

        internal static fmFilterSimSuspension Deserialize(XmlNode suspensionNode, fmFilterSimProject parentProject)
        {
            bool m_checked = false;
            fmSerializeTools.DeserializeBoolProperty(ref m_checked, suspensionNode, fmSuspensionSerializeTags.Checked);

            var sus = new fmFilterSimSuspension(parentProject, "_noname", "_unknown_material", "_unknown_customer");
            fmFilterSimSuspensionData data =
                fmFilterSimSuspensionData.Deserialize(
                    suspensionNode.SelectSingleNode(
                        fmFilterSimSuspensionData.fmSuspensionDataSerializeTags.SuspensionData), sus);
            sus.SetName(data.name);

            string comments = "";
            fmSerializeTools.DeserializeStringProperty(ref comments, suspensionNode, fmSuspensionSerializeTags.Comments);
            sus.SetComments(comments);

            sus.Material = data.material;
            sus.Customer = data.customer;
            return sus;
        }

        #region IComments Members

        public string GetComments()
        {
            return m_data.comments;
        }

        public void SetComments(string comments)
        {
            Modified |= m_data.comments != comments;
            m_data.comments = comments;
        }

        #endregion

        #region IName Members

        public string GetName()
        {
             return m_data.name;
        }
        
        public void SetName(string name)
        {
            Modified |= m_data.name != name;
            m_data.name = name;
        }

        #endregion
    }
}