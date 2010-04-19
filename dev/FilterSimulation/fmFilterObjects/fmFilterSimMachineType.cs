using System.Collections.Generic;

namespace FilterSimulation.fmFilterObjects
{
    public class fmFilterSimMachineType
    {
        public string Symbol;
        public string Name;

        static private void AddFilter(ref fmFilterSimMachineType fmt, string symbol, string name)
        {
            fmt = new fmFilterSimMachineType(symbol, name);
            filterTypesList.Add(fmt);
        }

        static fmFilterSimMachineType()
        {
            filterTypesList = new List<fmFilterSimMachineType>();
            AddFilter(ref Nutche, "NU", "Nutche");
            AddFilter(ref Rotary, "RO", "Rotary");
            AddFilter(ref Belt, "BE", "Belt");
            AddFilter(ref Pressure_Leaf, "PLF", "Pressure Leaf");
            AddFilter(ref Candle, "CAF", "Candle");
            AddFilter(ref Filter_Presses, "FPRESS", "Filter Presses");
        }

        public fmFilterSimMachineType(string symbol, string name)
        {
            Symbol = symbol;
            Name = name;
        }

        public static List<fmFilterSimMachineType> filterTypesList;
        public static fmFilterSimMachineType Nutche;
        public static fmFilterSimMachineType Rotary;
        public static fmFilterSimMachineType Belt;
        public static fmFilterSimMachineType Pressure_Leaf;
        public static fmFilterSimMachineType Candle;
        public static fmFilterSimMachineType Filter_Presses;
    }
}