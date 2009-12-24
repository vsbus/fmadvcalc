using System;
using System.Collections.Generic;
using FilterSimulation.fmFilterObjects;

namespace FilterSimulation.fmFilterObjects
{
    struct fmFilterSimProjectData
    {
        public string Name;
        public List<fmFilterSimSuspension> SusList;
        public void CopyFrom(fmFilterSimProjectData from, fmFilterSimProject ownerProject)
        {
            Name = from.Name;
            SusList = new List<fmFilterSimSuspension>();
            foreach (fmFilterSimSuspension sus in from.SusList)
            {
                fmFilterSimSuspension newSus = new fmFilterSimSuspension();

                newSus.Parent = ownerProject;
                SusList.Add(newSus);

                newSus.CopyFrom(sus);
            }
        }
    }

    public class fmFilterSimProject
    {
        private Guid m_Guid;
        private fmFilterSimSolution m_ParentSolution;
        private fmFilterSimProjectData Data, BackupData;
        private bool m_Modified;
        private bool m_Checked = true;

        public List<fmFilterSimSuspension> SuspensionList
        {
            get { return Data.SusList; }
        }
        public Guid Guid
        {
            get { return m_Guid; }
        }
        public string Name
        {
            get { return Data.Name; }
            set
            {
                Modified |= Data.Name != value;
                Data.Name = value;
            }
        }
        public bool Modified
        {
            get { return m_Modified; }
            set
            {
                m_Modified = value;
                //m_ParentSolution.Modified |= value;
            }
        }
        public fmFilterSimSolution Parent
        {
            get { return m_ParentSolution; }
        }
        public bool Checked
        {
            get { return m_Checked; }
            set { m_Checked = value; }
        }

        public fmFilterSimProject(fmFilterSimSolution parentSolution, string Name)
        {
            m_Guid = Guid.NewGuid();
            if (parentSolution != null)
            {
                m_ParentSolution = parentSolution;
                parentSolution.AddProject(this);
            }
            Data.Name = Name;
            Data.SusList = new List<fmFilterSimSuspension>();
            Keep();
        }
        public void Keep()
        {
            foreach (fmFilterSimSuspension sus in Data.SusList)
            {
                sus.Keep();
            }
            BackupData.CopyFrom(Data, this);
            Modified = false;
        }
        public void Restore()
        {
            Data.CopyFrom(BackupData, this);
            Modified = false;
            //m_Checked = true;
        }
        public void Delete()
        {
            foreach (fmFilterSimSuspension sus in Data.SusList.GetRange(0, Data.SusList.Count))
                sus.Delete();
            m_ParentSolution.RemoveProject(this);
        }
        public void AddSuspension(fmFilterSimSuspension sus)
        {
            Data.SusList.Add(sus);
            Modified = true;
        }
        public void RemoveSuspension(fmFilterSimSuspension sus)
        {
            Data.SusList.Remove(sus);
            Modified = true;
        }

        public List<fmFilterSimulation> GetAllSimulations()
        {
            List<fmFilterSimulation> ret = new List<fmFilterSimulation>();
            foreach (fmFilterSimSuspension sus in SuspensionList)
            {
                ret.AddRange(sus.GetAllSimulations());
            }
            return ret;
        }

        public List<fmFilterSimSerie> GetAllSeries()
        {
            List<fmFilterSimSerie> ret = new List<fmFilterSimSerie>();
            foreach (fmFilterSimSuspension sus in SuspensionList)
            {
                ret.AddRange(sus.SimSeriesList);
            }
            return ret;
        }
        public fmFilterSimSuspension FindSuspension(Guid guid)
        {
            foreach (fmFilterSimSuspension sus in Data.SusList)
            {
                if (guid == sus.Guid)
                    return sus;
            }
            return null;
        }
        public fmFilterSimulation FindSimulation(Guid guid)
        {
            foreach (fmFilterSimSuspension sus in Data.SusList)
            {
                fmFilterSimulation sim = sus.FindSimulation(guid);
                if (sim != null)
                    return sim;
            }
            return null;
        }

        //public fmFilterSimSerie FindSerie(Guid guid)
        //{
        //    foreach (fmFilterSimSuspension sus in Data.SusList)
        //    {
        //        fmFilterSimSerie ser = sus.FindSerie(guid);
        //        if (ser != null)
        //            return ser;
        //    }
        //    return null;
        //}
    }
}