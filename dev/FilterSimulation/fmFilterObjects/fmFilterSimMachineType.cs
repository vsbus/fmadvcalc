using System;
using System.Collections.Generic;
using System.Xml;
using System.Drawing;

namespace FilterSimulation.fmFilterObjects
{
    public class fmFilterSimMachineType
    {
        public string name;
        private bool m_isVacuum;
        private fmMachineGroup m_machineGroup;

        static private fmFilterSimMachineType AddFilter(
            string name,
            bool isVacuum,
            fmMachineGroup machineGroup)
        {
            var mahineType = new fmFilterSimMachineType(name, isVacuum, machineGroup);
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
            VacuumDrumFilter = AddFilter("Vacuum Drum Filter", true, firstGroup);
            AddFilter("Vacuum Disc Filter", true, firstGroup);
            AddFilter("Vacuum Pan Filter", true, firstGroup);
            BeltFilter = AddFilter("Vacuum Belt Filter", true, firstGroup);

            AddFilter("Rotary Pressure Filter", false, new fmMachineGroup(Color.LightPink));

            var thirdGroup = new fmMachineGroup(Color.LightSeaGreen);
            VacuumNutche = AddFilter("Vacuum Nutche", true, thirdGroup);
            AddFilter("Pressure Nutche", false, thirdGroup);
            AddFilter("Pneuma Press", false, thirdGroup);

            var fourthGroup = new fmMachineGroup(Color.LemonChiffon);
            AddFilter("Pressure Leaf Filter", false, fourthGroup);
            AddFilter("Candle Filter", false, fourthGroup);

            var fifthGroup = new fmMachineGroup(Color.Coral);
            FilterPress = AddFilter("Filter Press", false, fifthGroup);
            AddFilter("Filter Press Automat", false, fifthGroup);

            var sixthGroup = new fmMachineGroup(Color.Goldenrod);
            AddFilter("Lab Vacuum Filter", true, sixthGroup);
            AddFilter("Lab Pressure Filter", false, sixthGroup);
        }

        public fmFilterSimMachineType(string name, bool isVacuum, fmMachineGroup machineGroup)
        {
            this.name = name;
            m_isVacuum = isVacuum;
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
            return m_isVacuum;
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