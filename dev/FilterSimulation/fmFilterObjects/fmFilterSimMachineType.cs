using System;
using System.Collections.Generic;
using System.Xml;
using System.Drawing;
using System.ComponentModel;

namespace FilterSimulation.fmFilterObjects
{
    public class fmFilterSimMachineType
    {
        public static class FilterTypeNamesList
        {
            public const string VacuumDrumFilter = "Vacuum Drum Filter";
            public const string VacuumDiscFilter = "Vacuum Disc Filter";
            public const string VacuumPanFilter = "Vacuum Pan Filter";
            public const string VacuumBeltFilter = "Vacuum Belt Filter";
            public const string RotaryPressureFilter = "Rotary Pressure Filter";
            public const string VacuumNutche = "Vacuum Nutche";
            public const string PressureNutche = "Pressure Nutche";
            public const string PneumaPress = "Pneuma Press";
            public const string PressureLeafFilter ="Pressure Leaf Filter";
            public const string CandleFilter = "Candle Filter";
            public const string FilterPress ="Filter Press";
            public const string FilterPressAutomat = "Filter Press Automat";
            public const string LabVacuumFilter = "Lab Vacuum Filter";
            public const string LabPressureFilter = "Lab Pressure Filter";
        }

        public enum FilterPressureType
        {
            [Description("Vacuum")]
            Vacuum,
            [Description("Pressure")]
            Pressure
        }

        public enum FilterCycleType
        {
            [Description("Continuous Filters")]
            ContinuousFilters,
            [Description("Batch Filters")]
            BatchFilters
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
            VacuumDrumFilter = AddFilter(
                FilterTypeNamesList.VacuumDrumFilter,
                true,
                FilterCycleType.ContinuousFilters,
                firstGroup);
            AddFilter(
                FilterTypeNamesList.VacuumDiscFilter,
                true,
                FilterCycleType.ContinuousFilters,
                firstGroup);
            AddFilter(FilterTypeNamesList.VacuumPanFilter,
                true,
                FilterCycleType.ContinuousFilters,
                firstGroup);
            BeltFilter = AddFilter(
                FilterTypeNamesList.VacuumBeltFilter,
                true,
                FilterCycleType.ContinuousFilters,
                firstGroup);

            AddFilter(FilterTypeNamesList.RotaryPressureFilter, false, FilterCycleType.ContinuousFilters, new fmMachineGroup(Color.LightPink));

            var thirdGroup = new fmMachineGroup(Color.LightSeaGreen);
            VacuumNutche = AddFilter(FilterTypeNamesList.VacuumNutche, true, FilterCycleType.BatchFilters, thirdGroup);
            AddFilter(FilterTypeNamesList.PressureNutche, false, FilterCycleType.BatchFilters, thirdGroup);
            AddFilter(FilterTypeNamesList.PneumaPress, false, FilterCycleType.BatchFilters, thirdGroup);

            var fourthGroup = new fmMachineGroup(Color.LemonChiffon);
            AddFilter(FilterTypeNamesList.PressureLeafFilter, false, FilterCycleType.BatchFilters, fourthGroup);
            AddFilter(FilterTypeNamesList.CandleFilter, false, FilterCycleType.BatchFilters, fourthGroup);

            var fifthGroup = new fmMachineGroup(Color.Coral);
            FilterPress = AddFilter(FilterTypeNamesList.FilterPress, false, FilterCycleType.BatchFilters, fifthGroup);
            AddFilter(FilterTypeNamesList.FilterPressAutomat, false, FilterCycleType.BatchFilters, fifthGroup);

            var sixthGroup = new fmMachineGroup(Color.Goldenrod);
            AddFilter(FilterTypeNamesList.LabVacuumFilter, true, FilterCycleType.BatchFilters, sixthGroup);
            AddFilter(FilterTypeNamesList.LabPressureFilter, false, FilterCycleType.BatchFilters, sixthGroup);
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

        public FilterCycleType GetFilterCycleType()
        {
            return m_filterCycleType;
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