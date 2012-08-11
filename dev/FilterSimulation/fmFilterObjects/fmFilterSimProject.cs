using System;
using System.Collections.Generic;
using System.Xml;
using FilterSimulation.fmFilterObjects.Interfaces;

namespace FilterSimulation.fmFilterObjects
{
    struct fmFilterSimProjectData
    {
        public string name;
        public string comments;
        public List<fmFilterSimSuspension> susList;
        public void CopyFrom(fmFilterSimProjectData from, fmFilterSimProject ownerProject)
        {
            name = from.name;
            comments = from.comments;
            susList = new List<fmFilterSimSuspension>();
            foreach (fmFilterSimSuspension sus in from.susList)
            {
                var newSus = new fmFilterSimSuspension {Parent = ownerProject};

                susList.Add(newSus);

                newSus.CopyFrom(sus);
            }
        }

        private static class fmProjectDataSerializeTags
        {
            public const string Begin = "ProjectData Begin";
            public const string End = "ProjectData End";
            // ReSharper disable InconsistentNaming
            public const string name = "name";
            public const string susListSize = "susListSize";
            // ReSharper restore InconsistentNaming
        }

        internal void Serialize(XmlWriter writer)
        {
            writer.WriteElementString(fmProjectDataSerializeTags.name, name);
            foreach (var filterSimSuspension in susList)
            {
                filterSimSuspension.Serialize(writer);
            }
        }

        internal static fmFilterSimProjectData Deserialize(XmlNode projectNode, fmFilterSimProject parentProject)
        {
            var projectData = new fmFilterSimProjectData();
            fmSerializeTools.DeserializeStringProperty(ref projectData.name, projectNode, fmProjectDataSerializeTags.name);
            XmlNodeList suspensionList = projectNode.SelectNodes(fmFilterSimSuspension.fmSuspensionSerializeTags.Suspension);
            foreach (XmlNode suspensionNode in suspensionList)
            {
                fmFilterSimSuspension sus = fmFilterSimSuspension.Deserialize(suspensionNode, parentProject);
            }
            return projectData;
        }
    }

    public class fmFilterSimProject : IComments
    {
        private readonly Guid m_guid;
        private readonly fmFilterSimSolution m_parentSolution;
        private fmFilterSimProjectData m_data;
#pragma warning disable 649
        private fmFilterSimProjectData m_backupData;
#pragma warning restore 649
        private bool m_checked = true;

        public List<fmFilterSimSuspension> SuspensionList
        {
            get { return m_data.susList; }
        }

        public Guid Guid
        {
            get { return m_guid; }
        }

      

        public bool Modified { get; set; }

        public fmFilterSimSolution Parent
        {
            get { return m_parentSolution; }
        }

        public bool Checked
        {
            get { return m_checked; }
            set { m_checked = value; }
        }

        public fmFilterSimProject(fmFilterSimSolution parentSolution, string name)
        {
            m_guid = Guid.NewGuid();
            if (parentSolution != null)
            {
                m_parentSolution = parentSolution;
                parentSolution.AddProject(this);
            }
            m_data.name = name;
            m_data.susList = new List<fmFilterSimSuspension>();
            Keep();
        }

        public void Keep()
        {
            foreach (fmFilterSimSuspension sus in m_data.susList)
            {
                sus.Keep();
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
            foreach (fmFilterSimSuspension sus in m_data.susList.GetRange(0, m_data.susList.Count))
                sus.Delete();
            m_parentSolution.RemoveProject(this);
        }

        public void AddSuspension(fmFilterSimSuspension sus)
        {
            m_data.susList.Add(sus);
            Modified = true;
        }

        public void RemoveSuspension(fmFilterSimSuspension sus)
        {
            m_data.susList.Remove(sus);
            Modified = true;
        }

        public List<fmFilterSimulation> GetAllSimulations()
        {
            var ret = new List<fmFilterSimulation>();
            foreach (fmFilterSimSuspension sus in SuspensionList)
            {
                ret.AddRange(sus.GetAllSimulations());
            }
            return ret;
        }

        public List<fmFilterSimSerie> GetAllSeries()
        {
            var ret = new List<fmFilterSimSerie>();
            foreach (fmFilterSimSuspension sus in SuspensionList)
            {
                ret.AddRange(sus.SimSeriesList);
            }
            return ret;
        }

        public fmFilterSimSuspension FindSuspension(Guid guid)
        {
            foreach (fmFilterSimSuspension sus in m_data.susList)
            {
                if (guid == sus.Guid)
                    return sus;
            }
            return null;
        }

        public fmFilterSimulation FindSimulation(Guid guid)
        {
            foreach (fmFilterSimSuspension sus in m_data.susList)
            {
                fmFilterSimulation sim = sus.FindSimulation(guid);
                if (sim != null)
                    return sim;
            }
            return null;
        }

        public static class fmProjectSerializeTags
        {
            public const string Project = "Project";
            public const string Checked = "m_checked";
            public const string Comments = "Comments";
        }

        internal void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement(fmProjectSerializeTags.Project);
            writer.WriteElementString(fmProjectSerializeTags.Checked, m_checked.ToString());
            writer.WriteElementString(fmProjectSerializeTags.Comments, GetComments());
            m_data.Serialize(writer);
            writer.WriteEndElement();
        }

        internal static fmFilterSimProject Deserialize(XmlNode projectNode, fmFilterSimSolution parentSolution)
        {
            bool m_checked = false;
            fmSerializeTools.DeserializeBoolProperty(ref m_checked, projectNode, fmProjectSerializeTags.Checked);
            var project = new fmFilterSimProject(parentSolution, "_noname");
            fmFilterSimProjectData projectData = fmFilterSimProjectData.Deserialize(projectNode, project);
            project.Checked = m_checked;
            project.Modified = false;
            project.SetName(projectData.name);
            project.SetComments(projectNode.SelectSingleNode(fmProjectSerializeTags.Comments).InnerText);
            return project;
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