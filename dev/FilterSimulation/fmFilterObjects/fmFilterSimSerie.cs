using System;
using System.Collections.Generic;
using System.Xml;
using FilterSimulation.fmFilterObjects.Interfaces;
using fmCalculationLibrary;
using fmMisc;

namespace FilterSimulation.fmFilterObjects
{
    class fmFilterSimSerieData
    {
        public string name;
        public fmFilterSimMachineType machine;
        public string filterMedium;
        public string machineName;
        public string comments;

        public fmParametersToDisplay parametersToDisplay = new fmParametersToDisplay();

        public fmRangesConfiguration ranges = new fmRangesConfiguration();
        public List<fmFilterSimulation> simList;


        public void CopyFrom(fmFilterSimSerieData from, fmFilterSimSerie ownerSimSerie)
        {
            name = from.name;
            machine = from.machine;
            machineName = from.machineName;
            filterMedium = from.filterMedium;
            comments = from.comments;
            parametersToDisplay = new fmParametersToDisplay(from.parametersToDisplay);

            ranges = new fmRangesConfiguration();
            foreach (KeyValuePair<fmGlobalParameter, fmDefaultParameterRange> range in from.ranges.Ranges)
            {
                ranges.Ranges.Add(range.Key, range.Value);
            }

            simList = new List<fmFilterSimulation>();
            foreach (fmFilterSimulation sim in from.simList)
            {
                var newSim = new fmFilterSimulation {Parent = ownerSimSerie};

                simList.Add(newSim);
                newSim.CopyFrom(sim);
            }
        }

        #region Serialization

        public static class fmSimSerieDataSerializeTags
        {
            public const string Serie = "Serie";
            public const string Name = "name";
            public const string MachineName = "machineName";
            public const string FilterMedium = "filterMedium";
            public const string ParametersToDisplay = "ParametersToDisplay";
            public const string AssignedShowHideSchema = "AssignedShowHideSchema";
            public const string Ranges = "Ranges";
            public const string GlobalParameter = "GlobalParameter";
            public const string ParameterRange = "ParameterRange";
            public const string RangeIsInputed = "RangeIsInputed";
            public const string RangeMinValue = "RangeMinValue";
            public const string RangeMaxValue = "RangeMaxValue";
        }

        internal void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement(fmSimSerieDataSerializeTags.Serie);
            writer.WriteElementString(fmSimSerieDataSerializeTags.Name, name);
            writer.WriteElementString(fmSimSerieDataSerializeTags.MachineName, machineName);
            machine.Serialize(writer);
            writer.WriteElementString(fmSimSerieDataSerializeTags.FilterMedium, filterMedium);
            
            writer.WriteStartElement(fmSimSerieDataSerializeTags.ParametersToDisplay);
            writer.WriteElementString(fmSimSerieDataSerializeTags.AssignedShowHideSchema, fmEnumUtils.GetEnumDescription(parametersToDisplay.AssignedSchema));
            foreach (var p in parametersToDisplay.ParametersList)
            {
                writer.WriteElementString(fmSimSerieDataSerializeTags.GlobalParameter, p.Name);
            }
            writer.WriteEndElement();

            writer.WriteStartElement(fmSimSerieDataSerializeTags.Ranges);
            foreach (var p in ranges.Ranges)
            {
                writer.WriteStartElement(fmSimSerieDataSerializeTags.ParameterRange);
                writer.WriteElementString(fmSimSerieDataSerializeTags.GlobalParameter, p.Key.Name);
                writer.WriteElementString(fmSimSerieDataSerializeTags.RangeIsInputed, p.Value.IsInputed.ToString());
                writer.WriteElementString(fmSimSerieDataSerializeTags.RangeMinValue, p.Value.MinValue.ToString());
                writer.WriteElementString(fmSimSerieDataSerializeTags.RangeMaxValue, p.Value.MaxValue.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            foreach (var p in simList)
            {
                p.Serialize(writer);
            }
            writer.WriteEndElement();
        }

        internal static fmFilterSimSerieData Deserialize(XmlNode xmlNode, fmFilterSimSuspension parentSuspension, fmFilterSimSerie parentSerie)
        {
            var serieData = new fmFilterSimSerieData
                                {
                                    name = xmlNode.SelectSingleNode(fmSimSerieDataSerializeTags.Name).InnerText,
                                    machineName =
                                        xmlNode.SelectSingleNode(fmSimSerieDataSerializeTags.MachineName).InnerText,
                                    machine =
                                        fmFilterSimMachineType.Deserialize(
                                            xmlNode.SelectSingleNode(
                                                fmFilterSimMachineType.fmMachineSerializeTags.Machine)),
                                    filterMedium =
                                        xmlNode.SelectSingleNode(fmSimSerieDataSerializeTags.FilterMedium).InnerText,
                                    parametersToDisplay = new fmParametersToDisplay()
                                };

            XmlNode parametersToDisplayNode = xmlNode.SelectSingleNode(fmSimSerieDataSerializeTags.ParametersToDisplay);
            if (parametersToDisplayNode != null)
            {
                XmlNode schemaNode = parametersToDisplayNode.SelectSingleNode(fmSimSerieDataSerializeTags.AssignedShowHideSchema);
                if (schemaNode != null)
                {
                    serieData.parametersToDisplay.AssignedSchema =
                        (fmShowHideSchema) fmEnumUtils.GetEnum(typeof (fmShowHideSchema), schemaNode.InnerText);
                }
                XmlNodeList parameterNodeList =
                    parametersToDisplayNode.SelectNodes(fmSimSerieDataSerializeTags.GlobalParameter);
                foreach (XmlNode p in parameterNodeList)
                {
                    serieData.parametersToDisplay.ParametersList.Add(fmGlobalParameter.ParametersByName[p.InnerText]);
                }
            }

            serieData.ranges = new fmRangesConfiguration();
            XmlNode rangesNode = xmlNode.SelectSingleNode(fmSimSerieDataSerializeTags.Ranges);
            if (rangesNode != null)
            {
                XmlNodeList rangesParametersNodes = rangesNode.SelectNodes(fmSimSerieDataSerializeTags.ParameterRange);
                foreach (XmlNode rangeNode in rangesParametersNodes)
                {
                    XmlNode parameterNameNode = rangeNode.SelectSingleNode(fmSimSerieDataSerializeTags.GlobalParameter);
                    if (parameterNameNode != null)
                    {
                        var range = new fmDefaultParameterRange();
                        XmlNode isInputedNode = rangeNode.SelectSingleNode(fmSimSerieDataSerializeTags.RangeIsInputed);
                        if (isInputedNode != null)
                        {
                            range.IsInputed = Convert.ToBoolean(isInputedNode.InnerText);
                        }
                        XmlNode minValueNode = rangeNode.SelectSingleNode(fmSimSerieDataSerializeTags.RangeMinValue);
                        if (minValueNode != null)
                        {
                            range.MinValue = fmConvert.ToDouble(minValueNode.InnerText);
                        }
                        XmlNode maxValueNode = rangeNode.SelectSingleNode(fmSimSerieDataSerializeTags.RangeMaxValue);
                        if (maxValueNode != null)
                        {
                            range.MaxValue = fmConvert.ToDouble(maxValueNode.InnerText);
                        }
                        if (fmGlobalParameter.ParametersByName.ContainsKey(parameterNameNode.InnerText))
                        {
                            serieData.ranges.Ranges.Add(fmGlobalParameter.ParametersByName[parameterNameNode.InnerText], range);
                        }
                    }
                }
            }

            XmlNodeList simList = xmlNode.SelectNodes(fmFilterSimulation.fmFilterSimulationSerializeTags.Simulation);
            foreach (XmlNode simNode in simList)
            {
                fmFilterSimulation sim = fmFilterSimulation.Deserialize(simNode, parentSerie);
            }
            return serieData;
        }
        #endregion
    }

    public class fmFilterSimSerie : IComments
    {
        private Guid m_guid;
        private fmFilterSimSuspension m_parentSuspension;
        private fmFilterSimSerieData m_data = new fmFilterSimSerieData();
        private fmFilterSimSerieData m_backupData = new fmFilterSimSerieData();
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
        public fmFilterSimMachineType MachineType
        {
            get { return m_data.machine; }
            set
            {
                Modified |= m_data.machine != value;
                m_data.machine = value;
            }
        }

        public fmParametersToDisplay ParametersToDisplay
        {
            get { return m_data.parametersToDisplay; }
            set
            {
                Modified |= m_data.parametersToDisplay != value;
                m_data.parametersToDisplay = value;
            }
        }

        public fmRangesConfiguration Ranges
        {
            get { return m_data.ranges; }
            set
            {
                Modified |= m_data.ranges != value;
                m_data.ranges = value;
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

            m_data.name = toCopy.GetName();
            m_data.machine = toCopy.MachineType;
            m_data.filterMedium = toCopy.FilterMedium;
            m_data.machineName = toCopy.MachineName;
            m_data.simList = new List<fmFilterSimulation>();
            m_data.comments = toCopy.GetComments();
            m_data.parametersToDisplay = new fmParametersToDisplay(toCopy.ParametersToDisplay);
            m_data.ranges = new fmRangesConfiguration(toCopy.Ranges);

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
            public const string Comments = "Comments";
        }

        internal void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement(fmSimSerieSerializeTags.SimSerie);
            writer.WriteElementString(fmSimSerieSerializeTags.Checked, m_checked.ToString());
            writer.WriteElementString(fmSimSerieSerializeTags.Comments, GetComments());
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
            serie.SetName(m_data.name);

            string comments = "";
            fmSerializeTools.DeserializeStringProperty(ref comments, xmlNode, fmSimSerieSerializeTags.Comments);
            serie.SetComments(comments);

            serie.MachineType = m_data.machine;
            serie.MachineName = m_data.machineName;
            serie.FilterMedium = m_data.filterMedium;
            serie.ParametersToDisplay = m_data.parametersToDisplay;
            serie.Ranges = m_data.ranges;
            return serie;
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