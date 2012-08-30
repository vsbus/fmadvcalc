using System;
using System.Collections.Generic;

namespace fmCalculationLibrary.MeasureUnits
{
    public class fmUnitFamily
    {
        // ReSharper disable InconsistentNaming
        public static fmUnitFamily AreaFamily = new fmUnitFamily();
        public static fmUnitFamily LengthFamily = new fmUnitFamily();
        public static fmUnitFamily MassFamily = new fmUnitFamily();
        public static fmUnitFamily NoUnitFamily = new fmUnitFamily();
        public static fmUnitFamily VolumeFamily = new fmUnitFamily();
        public static fmUnitFamily FrequencyFamily = new fmUnitFamily();
        public static fmUnitFamily ConcentrationFamily = new fmUnitFamily();
        public static fmUnitFamily ConcentrationCFamily = new fmUnitFamily();
        public static fmUnitFamily DensityFamily = new fmUnitFamily();
        public static fmUnitFamily ViscosityFamily = new fmUnitFamily();
        public static fmUnitFamily PermeabilityFamily = new fmUnitFamily();
        public static fmUnitFamily CakeResistanceRcFamily = new fmUnitFamily();
        public static fmUnitFamily CakeResistanceAFamily = new fmUnitFamily();
        public static fmUnitFamily FilterMediumResistanceFamily = new fmUnitFamily();
        public static fmUnitFamily PressureFamily = new fmUnitFamily();
        public static fmUnitFamily TimeFamily = new fmUnitFamily();
        public static fmUnitFamily FlowRateVolume = new fmUnitFamily();
        public static fmUnitFamily FlowRateMass = new fmUnitFamily();
        public static fmUnitFamily GasFlowRateVolume = new fmUnitFamily();
        public static fmUnitFamily SpeedFamily = new fmUnitFamily();
        public static fmUnitFamily SpecificMassFamily = new fmUnitFamily();
        public static fmUnitFamily VolumeInAreaFamily = new fmUnitFamily();
        public static fmUnitFamily VolumeInMassFamily = new fmUnitFamily();
        public static fmUnitFamily SpecificFlowRateVolume = new fmUnitFamily();
        public static fmUnitFamily SpecificFlowRateMass = new fmUnitFamily();
        public static fmUnitFamily SurfaceTensionFamily = new fmUnitFamily();
        public static fmUnitFamily TemperatureCelsius = new fmUnitFamily();
        public static fmUnitFamily EvaporationEnthalpyFamily = new fmUnitFamily();
        public static fmUnitFamily MolarMassFamily = new fmUnitFamily();

        public static List<fmUnitFamily> families = new List<fmUnitFamily>();
        // ReSharper restore InconsistentNaming
        
        private int m_currentIndex;
        public List<fmUnit> units = new List<fmUnit>();
        public string Name;

        static fmUnitFamily()
        {
            InitializeFamily(NoUnitFamily, "No Unit Family",
                new fmUnit("-", 1));

            InitializeFamily(MassFamily, "Mass",
                new fmUnit("kg", 1), 
                new fmUnit("g", .001),
                new fmUnit("mg", .000001));

            InitializeFamily(VolumeFamily, "Volume",
                new fmUnit("l", .001),
                new fmUnit("m3", 1),
                new fmUnit("cm3", 1e-6));

            InitializeFamily(AreaFamily, "Area",
                new fmUnit("m2", 1),
                new fmUnit("cm2", 1e-4));

            InitializeFamily(LengthFamily, "Length",
                new fmUnit("mm", .001),
                new fmUnit("cm", .01),
                new fmUnit("m", 1.0));

            InitializeFamily(FrequencyFamily, "Frequency", 
                new fmUnit("min-1", 1.0/60),
                new fmUnit("s-1", 1));

            InitializeFamily(ConcentrationFamily, "Concentration",
                new fmUnit("%", 0.01),
                new fmUnit("-", 1));

            InitializeFamily(ConcentrationCFamily, "ConcentrationC",
                new fmUnit("g/l", 1));
            
            InitializeFamily(DensityFamily, "Density",
                new fmUnit("kg/m3", 1));

            InitializeFamily(ViscosityFamily, "Viscosity", 
                new fmUnit("mPa s", 1e-3));

            InitializeFamily(PermeabilityFamily, "Permeability",
                new fmUnit("10-13m2", 1e-13),
                new fmUnit("m2", 1));

            InitializeFamily(CakeResistanceRcFamily, "CakeResistanceRc", 
                new fmUnit("10+13m-2", 1e13),
                new fmUnit("m-2", 1));

            InitializeFamily(CakeResistanceAFamily, "CakeResistanceA",
                new fmUnit("10+10m/kg", 1e10),
                new fmUnit("m/kg", 1));

            InitializeFamily(FilterMediumResistanceFamily, "FilterMediumResistance", 
                new fmUnit("10+10m-1", 1e10),
                new fmUnit("m-1", 1));

            InitializeFamily(PressureFamily, "Pressure", 
                new fmUnit("bar", 1e5),
                new fmUnit("Pa", 1));

            InitializeFamily(TimeFamily, "Time", 
                new fmUnit("s", 1),
                new fmUnit("min", 60));

            InitializeFamily(FlowRateVolume, "FlowRateVolume", 
                new fmUnit("l/h", 1e-3/(60 * 60)),
                new fmUnit("m3/s", 1));

            InitializeFamily(FlowRateMass, "FlowRateMass", 
                new fmUnit("kg/h", 1.0 / (60 * 60)),
                new fmUnit("kg/s", 1));

            InitializeFamily(GasFlowRateVolume, "GasFlowRateVolume", 
                new fmUnit("m3/h", 1.0 / (60 * 60)));

            InitializeFamily(SpeedFamily, "Speed",
                new fmUnit("mm/min", 1e-3/60),
                new fmUnit("m/s", 1));

            InitializeFamily(SpecificMassFamily, "SpecificMass",
                new fmUnit("kg/m2", 1));

            InitializeFamily(VolumeInAreaFamily, "VolumeInArea",
                new fmUnit("l/m2", 1e-3),
                new fmUnit("m3/m2", 1));

            InitializeFamily(VolumeInMassFamily, "VolumeInMass",
                new fmUnit("l/kg", 1e-3),
                new fmUnit("m3/kg", 1));

            InitializeFamily(SpecificFlowRateVolume, "SpecificFlowRateVolume",
                new fmUnit("l/m2min", 1e-3/60),
                new fmUnit("m3/m2s", 1));

            InitializeFamily(SpecificFlowRateMass, "Specific FlowRate Mass",
                new fmUnit("kg/m2min", 1.0/60),
                new fmUnit("kg/m2s", 1));

            InitializeFamily(SurfaceTensionFamily, "Surface Tension",
                new fmUnit("miliN/m", 1e-3),
                new fmUnit("N/m", 1));

            InitializeFamily(TemperatureCelsius, "Temperature",
                new fmUnit("C°", 1));

            InitializeFamily(EvaporationEnthalpyFamily, "EvaporationEnthalpy",
                new fmUnit("KJ/mole", 1000));
            
            InitializeFamily(MolarMassFamily, "Molar Mass",
                new fmUnit("g/mole", 1e-3));
        }

        private static void InitializeFamily(fmUnitFamily family, string name, params fmUnit [] units)
        {
            family.Name = name;
            foreach (fmUnit unit in units)
            {
                family.units.Add(unit);
            }
            families.Add(family);
        }

        public fmUnit CurrentUnit
        {
            get { return units[m_currentIndex]; }
        }

        public void SetCurrentUnit(string name)
        {
            for (int i = 0; i < units.Count; ++i)
            {
                if (units[i].Name == name)
                {
                    m_currentIndex = i;
                    return;
                }
            }

            throw new Exception("No " + name + " units in unit family " + ToString());
        }
    }
}