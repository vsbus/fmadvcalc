using System;
using System.Collections.Generic;

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
            AddFilter(ref nutche, "NU", "Nutche");
            AddFilter(ref rotary, "RO", "Rotary");
            AddFilter(ref belt, "BE", "Belt");
            AddFilter(ref pressureLeaf, "PLF", "Pressure Leaf");
            AddFilter(ref candle, "CAF", "Candle");
            AddFilter(ref filterPresses, "FPRESS", "Filter Presses");
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

        private static class fmMachineSerializeTags
        {
            public const string Begin = "Machine Begin";
            public const string End = "Machine End";
            // ReSharper disable InconsistentNaming
            public const string symbol = "symbol";
            public const string name = "name";
            // ReSharper restore InconsistentNaming
        }

        internal void Serialize(System.IO.TextWriter output)
        {
            output.WriteLine("                        " + fmMachineSerializeTags.Begin);
            fmSerializeTools.SerializeProperty(output, fmMachineSerializeTags.symbol, symbol, 7);
            fmSerializeTools.SerializeProperty(output, fmMachineSerializeTags.name, name, 7);
            output.WriteLine("                        " + fmMachineSerializeTags.End);
        }

        internal static fmFilterSimMachineType Deserialize(System.IO.TextReader input)
        {
            input.ReadLine();
            string symbol = Convert.ToString(fmSerializeTools.DeserializeProperty(input, fmMachineSerializeTags.symbol));
            string name = Convert.ToString(fmSerializeTools.DeserializeProperty(input, fmMachineSerializeTags.name));
            input.ReadLine();
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