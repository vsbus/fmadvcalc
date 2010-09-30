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
    }
}