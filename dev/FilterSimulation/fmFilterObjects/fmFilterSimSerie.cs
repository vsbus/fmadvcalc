using System;
using System.Collections.Generic;
using FilterSimulation.fmFilterObjects;

namespace FilterSimulation.fmFilterObjects
{
    struct fmFilterSimSerieData
    {
        public string Name;
        public fmFilterSimMachineType Machine;
        public string FilterMedium;
        public List<fmFilterSimulation> SimList;
        public DateTime LastModifiedDate;
        public string MachineName;

        public void CopyFrom(fmFilterSimSerieData from, fmFilterSimSerie ownerSimSerie)
        {
            Name = from.Name;
            Machine = from.Machine;
            MachineName = from.MachineName;
            FilterMedium = from.FilterMedium;
            SimList = new List<fmFilterSimulation>();
            foreach (fmFilterSimulation sim in from.SimList)
            {
                fmFilterSimulation newSim = new fmFilterSimulation();
                
                newSim.Parent = ownerSimSerie;
                SimList.Add(newSim);
                newSim.CopyFrom(sim);
            }
            LastModifiedDate = from.LastModifiedDate;
        }
    }

    public class fmFilterSimSerie
    {
        private Guid m_Guid;
        private fmFilterSimSuspension m_ParentSuspension;
        private fmFilterSimSerieData Data, BackupData;
        private bool m_Modified;
        private bool m_Checked = true;

        public List<fmFilterSimulation> SimulationsList
        {
            get { return Data.SimList; }
        }
        public Guid Guid
        {
            get { return m_Guid; }
        }
        public fmFilterSimSuspension Parent
        {
            get { return m_ParentSuspension; }
            set { m_ParentSuspension = value; }
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
        public fmFilterSimMachineType MachineType
        {
            get { return Data.Machine; }
        }
        
        public string FilterMedium
        {
            get { return Data.FilterMedium; }
            set
            {
                Modified |= Data.FilterMedium != value;
                Data.FilterMedium = value;
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
                    Data.LastModifiedDate = DateTime.Now;
                    m_ParentSuspension.Modified |= value;
                }
            }
        }
        public bool Checked
        {
            get { return m_Checked; }
            set { m_Checked = value; }
        }
        public DateTime LastModifiedDate
        {
            get { return Data.LastModifiedDate; }
            set 
            {
                Data.LastModifiedDate = value; 
            }
        }
        public string MachineName
        {
            get { return Data.MachineName; }
            set
            {
                Modified |= Data.MachineName != value;
                Data.MachineName = value;
            }
        }


        public fmFilterSimSerie() 
        {
        }

        public fmFilterSimSerie(fmFilterSimSuspension parentSuspension, string Name, fmFilterSimMachineType machine, string filterMedium, string machineName)
        {
            m_Guid = Guid.NewGuid();
            if (parentSuspension != null)
            {
                m_ParentSuspension = parentSuspension;
                parentSuspension.AddSerie(this);
            }
            Data.Name = Name;
            Data.Machine = machine;
            Data.FilterMedium = filterMedium;
            Data.MachineName = machineName;
            Data.SimList = new List<fmFilterSimulation>();
            Data.LastModifiedDate = DateTime.Now;
            Keep();
        }

        public fmFilterSimSerie(fmFilterSimSuspension parentSuspension, fmFilterSimSerie toCopy)
        {
            m_Guid = Guid.NewGuid();
            if (parentSuspension != null)
            {
                m_ParentSuspension = parentSuspension;
                parentSuspension.AddSerie(this);
            }

            Data.Name = toCopy.Name;
            Data.Machine = toCopy.MachineType;
            Data.FilterMedium = toCopy.FilterMedium;
            Data.MachineName = toCopy.MachineName;
            Data.SimList = new List<fmFilterSimulation>();
            foreach (fmFilterSimulation sim in toCopy.SimulationsList)
            {
                new fmFilterSimulation(this, sim);
            }
                        
            Keep();
        }

        public void Keep()
        {
            foreach (fmFilterSimulation sim in Data.SimList)
            {
                sim.Keep();
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
            foreach (fmFilterSimulation sim in Data.SimList.GetRange(0, Data.SimList.Count))
                sim.Delete();
            m_ParentSuspension.RemoveSerie(this);
        }
        public void CopyFrom(fmFilterSimSerie serie)
        {
            m_Guid = serie.m_Guid;
            Data.CopyFrom(serie.Data, this);
            BackupData.CopyFrom(serie.BackupData, this);
            Modified = serie.Modified;
            LastModifiedDate = serie.LastModifiedDate;
        }
        public void AddSimulation(fmFilterSimulation sim)
        {
            Data.SimList.Add(sim);
            Modified = true;
        }
        public void RemoveSimulation(fmFilterSimulation sim)
        {
            Data.SimList.Remove(sim);
            Modified = true;
        }
        public fmFilterSimulation FindSimulation(Guid guid)
        {
            foreach (fmFilterSimulation sim in Data.SimList)
            {
                if (sim.Guid == guid)
                    return sim;
            }
            return null;
        }
    }
}