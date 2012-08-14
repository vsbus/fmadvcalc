using System;
using System.Collections.Generic;
using System.Xml;

namespace FilterSimulation.fmFilterObjects
{
    public class fmFilterSimMachineType
    {
        public string symbol;
        public string name;

        static private void AddFilter(ref fmFilterSimMachineType fmt, string symbol, string name)
        {
            fmt = new fmFilterSimMachineType(symbol, name);
            filterTypesList.Add(fmt);
        }

        static fmFilterSimMachineType()
        {
            filterTypesList = new List<fmFilterSimMachineType>();
            AddFilter(ref RotaryVacuumFilter, "RVF", "Rotary Vacuum Filter");
            AddFilter(ref RotaryPressureFilter, "RPF", "Rotary Pressure Filter");
            AddFilter(ref BeltFilter, "BE", "Belt Filter");
            AddFilter(ref VacuumNutche, "VN", "Vacuum Nutche");
            AddFilter(ref PressureNutche, "PN", "Pressure Nutche");
            AddFilter(ref CandleFilter, "CAF", "Candle Filter");
            AddFilter(ref PressureLeaf, "PLF", "Pressure Leaf Filter");
            AddFilter(ref FilterPress, "FPRESS", "Filter Press");
            AddFilter(ref LabVacuumFilter, "LVF", "Lab Vacuum Filter");
            AddFilter(ref LabPressureFilter, "LPF", "Lab Pressure Filter");
        }

        public fmFilterSimMachineType(string symbol, string name)
        {
            this.symbol = symbol;
            this.name = name;
        }

        public static List<fmFilterSimMachineType> filterTypesList;
        public static fmFilterSimMachineType RotaryVacuumFilter;
        public static fmFilterSimMachineType BeltFilter;
        public static fmFilterSimMachineType PressureLeaf;
        public static fmFilterSimMachineType CandleFilter;
        public static fmFilterSimMachineType FilterPress;
        public static fmFilterSimMachineType RotaryPressureFilter;
        public static fmFilterSimMachineType VacuumNutche;
        public static fmFilterSimMachineType PressureNutche;
        public static fmFilterSimMachineType LabVacuumFilter;
        public static fmFilterSimMachineType LabPressureFilter;
            

        public static class fmMachineSerializeTags
        {
            public const string Machine = "Machine";
            public const string Symbol = "symbol";
            public const string Name = "name";
        }

        internal void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement(fmMachineSerializeTags.Machine);
            writer.WriteElementString(fmMachineSerializeTags.Symbol, symbol);
            writer.WriteElementString(fmMachineSerializeTags.Name, name);
            writer.WriteEndElement();
        }

        internal static fmFilterSimMachineType Deserialize(XmlNode xmlNode)
        {
            string symbol = xmlNode.SelectSingleNode(fmMachineSerializeTags.Symbol).InnerText;
            string name = xmlNode.SelectSingleNode(fmMachineSerializeTags.Name).InnerText;
            foreach (var mt in filterTypesList)
            {
                if (mt.symbol == symbol && mt.name == name)
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
    }
}