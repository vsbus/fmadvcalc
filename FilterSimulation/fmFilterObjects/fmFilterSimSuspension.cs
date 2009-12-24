using System;
using System.Collections.Generic;
using FilterSimulation.fmFilterObjects;

namespace FilterSimulation.fmFilterObjects
{
    struct fmFilterSimSuspensionData
    {
        public string Name;
        public string Material;
        public string Customer;
        public List<fmFilterSimSerie> SeriesList;

        public void CopyFrom(fmFilterSimSuspensionData from, fmFilterSimSuspension ownerSuspension)
        {
            Name = from.Name;
            Material = from.Material;
            Customer = from.Customer;
            SeriesList = new List<fmFilterSimSerie>();
            foreach (fmFilterSimSerie serie in from.SeriesList)
            {
                fmFilterSimSerie newSerie = new fmFilterSimSerie();
                
                newSerie.Parent = ownerSuspension;
                SeriesList.Add(newSerie);

                newSerie.CopyFrom(serie);
            }
        }
    }

    public class fmFilterSimSuspension
    {
        private Guid m_Guid;
        private fmFilterSimProject m_ParentProject;
        private fmFilterSimSuspensionData Data, BackupData;
        private bool m_Modified;
        private bool m_Checked = true;

        public List<fmFilterSimSerie> SimSeriesList
        {
            get { return Data.SeriesList; }
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
        public string Customer
        {
            get { return Data.Customer; }
            set
            {
                Modified |= Data.Customer != value;
                Data.Customer = value;
            }
        }
        public string Material
        {
            get { return Data.Material; }
            set 
            {
                Modified |= Data.Material != value;
                Data.Material = value; 
            }
        }
        public bool Modified
        {
            get { return m_Modified; }
            set
            {
                m_Modified = value;
                m_ParentProject.Modified |= value;
            }
        }
        public fmFilterSimProject Parent
        {
            get { return m_ParentProject; }
            set { m_ParentProject = value; }
        }
        
        
        public bool Checked
        {
            get { return m_Checked; }
            set { m_Checked = value; }
        }


        public fmFilterSimSuspension() { }
        public fmFilterSimSuspension(fmFilterSimProject parentProject, string Name, string Material, string Customer)
        {
            m_Guid = Guid.NewGuid();
            if (parentProject != null)
            {
                m_ParentProject = parentProject;
                parentProject.AddSuspension(this);
            }
            Data.Name = Name;
            Data.Material = Material;
            Data.Customer = Customer;
            Data.SeriesList = new List<fmFilterSimSerie>();
            //m_Checked = true;
            Keep();
        }

        public void Keep()
        {
            foreach (fmFilterSimSerie ser in Data.SeriesList)
            {
                ser.Keep();
            }
            BackupData.CopyFrom(Data, this);
            Modified = false;
        }
        public void Restore()
        {
            Data.CopyFrom(BackupData, this);
            Modified = false;
        }
        public void Delete()
        {
            foreach (fmFilterSimSerie serie in Data.SeriesList.GetRange(0, Data.SeriesList.Count))
                serie.Delete();
            m_ParentProject.RemoveSuspension(this);
        }
        public void CopyFrom(fmFilterSimSuspension sus)
        {
            m_Guid = sus.m_Guid;
            //m_ParentProject = sus.m_ParentProject;
            Modified = sus.Modified;
            Data.CopyFrom(sus.Data, this);
            BackupData.CopyFrom(sus.BackupData, this);
        }
        public void AddSerie(fmFilterSimSerie serie)
        {
            Data.SeriesList.Add(serie);
            Modified = true;
        }
        public void RemoveSerie(fmFilterSimSerie serie)
        {
            Data.SeriesList.Remove(serie);
            Modified = true;
        }

        public List<fmFilterSimulation> GetAllSimulations()
        {
            List<fmFilterSimulation> ret = new List<fmFilterSimulation>();
            foreach (fmFilterSimSerie serie in SimSeriesList)
            {
                ret.AddRange(serie.SimulationsList);
            }
            return ret;
        }

        public fmFilterSimSerie FindSerie(Guid guid)
        {
            foreach (fmFilterSimSerie ser in Data.SeriesList)
            {
                if (ser.Guid == guid)
                    return ser;
            }
            return null;
        }

        public fmFilterSimulation FindSimulation(Guid guid)
        {
            foreach (fmFilterSimSerie ser in Data.SeriesList)
            {
                fmFilterSimulation sim = ser.FindSimulation(guid);
                if (sim != null)
                    return sim;
            }
            return null;
        }
    }
}