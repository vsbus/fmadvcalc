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
            AddFilter(ref belt,             "BE",       "Belt Filters");
            AddFilter(ref rotary,           "RO",       "Rotary Filters");
            AddFilter(ref nutche,           "NU",       "Nutche Filters");
            AddFilter(ref pressureLeaf,     "PLF",      "Pressure Leaf Filters");
            AddFilter(ref filterPresses,    "FPRESS",   "Filter Presses");
            AddFilter(ref candle,           "CAF",      "Candle Filters");
        }

        public fmFilterSimMachineType(string symbol, string name)
        {
            this.symbol = symbol;
            this.name = name;
        }

        public static List<fmFilterSimMachineType> filterTypesList;
        public static fmFilterSimMachineType nutche;
        public static fmFilterSimMachineType rotary;
        public static fmFilterSimMachineType belt;
        public static fmFilterSimMachineType pressureLeaf;
        public static fmFilterSimMachineType candle;
        public static fmFilterSimMachineType filterPresses;

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
            throw new Exception("Deserialization failed: unknown machine type.");
        }
    }
}