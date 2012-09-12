using System;
using System.Collections.Generic;
using System.Xml;
using System.Drawing;
using System.ComponentModel;

namespace FilterSimulation.fmFilterObjects
{
    public class fmFilterSimMachineType
    {
        public enum FilterPressureType
        {
            [Description("Vacuum")]
            Vacuum,
            [Description("Pressure")]
            Pressure
        }

        public enum FilterCycleType
        {
            [Description("Continuous")]
            Continuous,
            [Description("Batch")]
            Batch
        }

        public string name;
        private FilterPressureType m_filterPressureType;
        private FilterCycleType m_filterCycleType;
        private fmMachineGroup m_machineGroup;

        static private fmFilterSimMachineType AddFilter(
            string name,
            bool isVacuum,
            FilterCycleType filterCycleType,
            fmMachineGroup machineGroup)
        {
            var mahineType = new fmFilterSimMachineType(
                name,
                isVacuum ? FilterPressureType.Vacuum : FilterPressureType.Pressure,
                filterCycleType,
                machineGroup);
            filterTypesList.Add(mahineType);
            return mahineType;
        }

        public static fmFilterSimMachineType VacuumNutche;
        public static fmFilterSimMachineType BeltFilter;
        public static fmFilterSimMachineType VacuumDrumFilter;
        public static fmFilterSimMachineType FilterPress;

        static fmFilterSimMachineType()
        {
            filterTypesList = new List<fmFilterSimMachineType>();

            var firstGroup = new fmMachineGroup(Color.LightBlue);
            VacuumDrumFilter = AddFilter("Vacuum Drum Filter", true, FilterCycleType.Continuous, firstGroup);
            AddFilter("Vacuum Disc Filter", true, FilterCycleType.Continuous, firstGroup);
            AddFilter("Vacuum Pan Filter", true, FilterCycleType.Continuous, firstGroup);
            BeltFilter = AddFilter("Vacuum Belt Filter", true, FilterCycleType.Continuous, firstGroup);

            AddFilter("Rotary Pressure Filter", false, FilterCycleType.Continuous, new fmMachineGroup(Color.LightPink));

            var thirdGroup = new fmMachineGroup(Color.LightSeaGreen);
            VacuumNutche = AddFilter("Vacuum Nutche", true, FilterCycleType.Batch, thirdGroup);
            AddFilter("Pressure Nutche", false, FilterCycleType.Batch, thirdGroup);
            AddFilter("Pneuma Press", false, FilterCycleType.Batch, thirdGroup);

            var fourthGroup = new fmMachineGroup(Color.LemonChiffon);
            AddFilter("Pressure Leaf Filter", false, FilterCycleType.Batch, fourthGroup);
            AddFilter("Candle Filter", false, FilterCycleType.Batch, fourthGroup);

            var fifthGroup = new fmMachineGroup(Color.Coral);
            FilterPress = AddFilter("Filter Press", false, FilterCycleType.Batch, fifthGroup);
            AddFilter("Filter Press Automat", false, FilterCycleType.Batch, fifthGroup);

            var sixthGroup = new fmMachineGroup(Color.Goldenrod);
            AddFilter("Lab Vacuum Filter", true, FilterCycleType.Batch, sixthGroup);
            AddFilter("Lab Pressure Filter", false, FilterCycleType.Batch, sixthGroup);
        }

        public fmFilterSimMachineType(
            string name,
            FilterPressureType filterPressureType,
            FilterCycleType filterCycleType,
            fmMachineGroup machineGroup)
        {
            this.name = name;
            m_filterPressureType = filterPressureType;
            m_filterCycleType = filterCycleType;
            m_machineGroup = machineGroup;
        }

        public static List<fmFilterSimMachineType> filterTypesList;

        public static class fmMachineSerializeTags
        {
            public const string Machine = "Machine";
            public const string Name = "name";
        }

        internal void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement(fmMachineSerializeTags.Machine);
            writer.WriteElementString(fmMachineSerializeTags.Name, name);
            writer.WriteEndElement();
        }

        internal static fmFilterSimMachineType Deserialize(XmlNode xmlNode)
        {
            string name = xmlNode.SelectSingleNode(fmMachineSerializeTags.Name).InnerText;
            foreach (var mt in filterTypesList)
            {
                if (mt.name == name)
                {
                    return mt;
                }
            }
            return filterTypesList[0];
        }

        internal static fmFilterSimMachineType GetFilterTypeByName(string p)
        {
            foreach (fmFilterSimMachineType machineType in filterTypesList)
            {
                if (machineType.name == p)
                {
                    return machineType;
                }
            }
            return null;
        }

        public static double GetHcdCoefficient(fmFilterSimMachineType machineType)
        {
            return machineType == FilterPress ? 2 : 1;
        }

        public bool IsVacuum()
        {
            return m_filterPressureType == FilterPressureType.Vacuum;
        }
    }

    public class fmMachineGroup
    {
        private Color m_color;
        public fmMachineGroup(Color color)
        {
            m_color = color;
        }
        public Color GetColor()
        {
            return m_color;
        }
    }
}