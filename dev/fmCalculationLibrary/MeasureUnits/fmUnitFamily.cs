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
        public static fmUnitFamily GasVolumeInMassFamily = new fmUnitFamily();
        public static fmUnitFamily GasVolumeFamily = new fmUnitFamily();
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
            const double InchFactor = 0.0254;
            const double FootFactor = InchFactor * 12;
            const double YardFactor = FootFactor * 3;
            const double PoundFactor = 0.45359237;
            const double mmHgFactor = 133.3224;
            const double PsiFactor = 6894.8;

            InitializeFamily(NoUnitFamily, "No Unit Family",
                new fmUnit("-", 1));

            InitializeFamily(MassFamily, "Mass (M)",
                new fmUnit("t", 1e3),
                new fmUnit("kg", 1), 
                new fmUnit("g", .001),
                new fmUnit("mg", .000001),
                new fmUnit("lb", PoundFactor, true));

            InitializeFamily(VolumeFamily, "Volume (V)",
                new fmUnit("l", .001),
                new fmUnit("m3", 1),
                new fmUnit("cm3", 1e-6),
                new fmUnit("ft3", Math.Pow(FootFactor, 3), true),
                new fmUnit("yd3", Math.Pow(YardFactor, 3), true));

            InitializeFamily(AreaFamily, "Area (A)",
                new fmUnit("m2", 1),
                new fmUnit("cm2", 1e-4),
                new fmUnit("ft2", Math.Pow(FootFactor, 2), true));

            InitializeFamily(LengthFamily, "Length",
                new fmUnit("mm", .001),
                new fmUnit("cm", .01),
                new fmUnit("m", 1.0),
                new fmUnit("in", InchFactor, true),
                new fmUnit("ft", FootFactor, true),
                new fmUnit("yd", YardFactor, true)
                );

            InitializeFamily(FrequencyFamily, "Frequency (n)", 
                new fmUnit("h-1", 1.0/60/60),
                new fmUnit("min-1", 1.0/60),
                new fmUnit("s-1", 1));

            InitializeFamily(ConcentrationFamily, "Concentration",
                new fmUnit("%", 0.01),
                new fmUnit("-", 1));

            InitializeFamily(ConcentrationCFamily, "ConcentrationC",
                new fmUnit("g/l", 1));
            
            InitializeFamily(DensityFamily, "Density (rho)",
                new fmUnit("kg/m3", 1),
                new fmUnit("g/cm3", 1e3));

            InitializeFamily(ViscosityFamily, "Viscosity (eta)", 
                new fmUnit("mPa s", 1e-3),
                new fmUnit("cP", 1e-3));

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

            InitializeFamily(PressureFamily, "Pressure (Dp)", 
                new fmUnit("bar", 1e5),
                new fmUnit("Pa", 1),
                new fmUnit("mmHg", mmHgFactor, true),
                new fmUnit("Torr", mmHgFactor, true),
                new fmUnit("inHg", mmHgFactor * 1000 * InchFactor, true),
                new fmUnit("psi", PsiFactor, true));

            InitializeFamily(TimeFamily, "Time (t)", 
                new fmUnit("s", 1),
                new fmUnit("min", 60),
                new fmUnit("h", 3600));

            InitializeFamily(FlowRateVolume, "Flowrate Volume (Q)", 
                new fmUnit("l/h", 1e-3/(60 * 60)),
                new fmUnit("l/min", 1e-3/(60)),
                new fmUnit("l/s", 1e-3),
                new fmUnit("m3/s", 1),
                new fmUnit("m3/min", 1.0 / 60),
                new fmUnit("m3/h", 1.0 / 60 / 60),
                new fmUnit("ft3/s", Math.Pow(FootFactor, 3), true),
                new fmUnit("ft3/min", Math.Pow(FootFactor, 3) / 60, true),
                new fmUnit("ft3/h", Math.Pow(FootFactor, 3) / 3600, true),
                new fmUnit("yd3/s", Math.Pow(YardFactor, 3), true),
                new fmUnit("yd3/min", Math.Pow(YardFactor, 3)/60, true),
                new fmUnit("yd3/h", Math.Pow(YardFactor, 3)/3600, true));

            InitializeFamily(FlowRateMass, "Flowrate Mass (Qm)", 
                new fmUnit("t/h", 1000.0 / (60 * 60)),
                new fmUnit("kg/h", 1.0 / (60 * 60)),
                new fmUnit("kg/min", 1.0 / (60)),
                new fmUnit("kg/s", 1),
                new fmUnit("lb/s", PoundFactor, true),
                new fmUnit("lb/min", PoundFactor/60, true),
                new fmUnit("lb/h", PoundFactor/3600, true));

            InitializeFamily(GasFlowRateVolume, "Gas Flowrate Volume (Qg)", 
                new fmUnit("l/h", 1e-3 / (60 * 60)),
                new fmUnit("l/min", 1e-3 / (60)),
                new fmUnit("l/s", 1e-3),
                new fmUnit("m3/s", 1),
                new fmUnit("m3/min", 1.0 / 60),
                new fmUnit("m3/h", 1.0 / 60 / 60),
                new fmUnit("ft3/s", Math.Pow(FootFactor, 3), true),
                new fmUnit("ft3/min", Math.Pow(FootFactor, 3) / 60, true),
                new fmUnit("ft3/h", Math.Pow(FootFactor, 3) / 3600, true),
                new fmUnit("yd3/s", Math.Pow(YardFactor, 3), true),
                new fmUnit("yd3/min", Math.Pow(YardFactor, 3) / 60, true),
                new fmUnit("yd3/h", Math.Pow(YardFactor, 3) / 3600, true));

            InitializeFamily(GasVolumeInMassFamily, "Gas Volume In Mass (vg)",
                new fmUnit("l/kg", 1e-3),
                new fmUnit("m3/kg", 1),
                new fmUnit("m3/t", 1e-3),
                new fmUnit("l/lb", 1e-3 / PoundFactor, true),
                new fmUnit("ft3/kg", Math.Pow(FootFactor, 3), true),
                new fmUnit("ft3/lb", Math.Pow(FootFactor, 3) / PoundFactor, true),
                new fmUnit("ft3/t", Math.Pow(FootFactor, 3) / 1000, true),
                new fmUnit("yd3/kg", Math.Pow(YardFactor, 3), true),
                new fmUnit("yd3/t", Math.Pow(YardFactor, 3) / 1000, true));

            InitializeFamily(GasVolumeFamily, "Gas Volume (Vg)",
                new fmUnit("ml", 1e-6),
                new fmUnit("l", 1e-3),
                new fmUnit("m3", 1),
                new fmUnit("ft3", Math.Pow(FootFactor, 3), true),
                new fmUnit("yd3", Math.Pow(YardFactor, 3), true));

            InitializeFamily(SpeedFamily, "Speed",
                new fmUnit("mm/min", 1e-3/60),
                new fmUnit("m/s", 1));

            InitializeFamily(SpecificMassFamily, "Specific Mass (m)",
                new fmUnit("kg/m2", 1),
                new fmUnit("t/m2", 1000),
                new fmUnit("lb/m2", PoundFactor, true),
                new fmUnit("lb/ft2", PoundFactor/Math.Pow(FootFactor,2), true));

            InitializeFamily(VolumeInAreaFamily, "Volume In Area (v)",
                new fmUnit("l/m2", 1e-3),
                new fmUnit("m3/m2", 1),
                new fmUnit("ft3/m2", Math.Pow(FootFactor,3), true),
                new fmUnit("ft3/ft2", FootFactor, true),
                new fmUnit("yd3/m2", Math.Pow(YardFactor,3), true));

            InitializeFamily(VolumeInMassFamily, "VolumeInMass",
                new fmUnit("l/kg", 1e-3),
                new fmUnit("m3/kg", 1));

            InitializeFamily(SpecificFlowRateVolume, "Specific Flowrate Volume (q)",
                new fmUnit("l/m2s", 1e-3),
                new fmUnit("l/m2min", 1e-3/60),
                new fmUnit("l/m2h", 1e-3/60/60),
                new fmUnit("m3/m2s", 1),
                new fmUnit("m3/m2min", 1.0/60),
                new fmUnit("m3/m2h", 1.0/60/60),
                new fmUnit("ft3/m2h", Math.Pow(FootFactor,3)/3600, true),
                new fmUnit("ft3/m2min", Math.Pow(FootFactor,3)/60, true),
                new fmUnit("ft3/m2s", Math.Pow(FootFactor,3), true),
                new fmUnit("ft3/ft2h", FootFactor/3600, true),
                new fmUnit("ft3/ft2min", FootFactor/60, true),
                new fmUnit("ft3/ft2s", FootFactor, true),
                new fmUnit("yd3/m2h", Math.Pow(YardFactor,3)/3600, true),
                new fmUnit("yd3/m2min", Math.Pow(YardFactor,3)/60, true),
                new fmUnit("yd3/m2s", Math.Pow(YardFactor,3), true),
                new fmUnit("yd3/ft2h", Math.Pow(YardFactor,3)/Math.Pow(FootFactor, 2)/3600, true),
                new fmUnit("yd3/ft2min", Math.Pow(YardFactor,3)/Math.Pow(FootFactor, 2)/60, true),
                new fmUnit("yd3/ft2s", Math.Pow(YardFactor,3)/Math.Pow(FootFactor, 2), true));

            InitializeFamily(SpecificFlowRateMass, "Specific Flowrate Mass (qm)",
                new fmUnit("t/m2h", 1000.0/60/60),
                new fmUnit("kg/m2h", 1.0/60/60),
                new fmUnit("kg/m2min", 1.0/60),
                new fmUnit("kg/m2s", 1),
                new fmUnit("lb/m2h", PoundFactor / 3600, true),
                new fmUnit("lb/m2min", PoundFactor/60, true),
                new fmUnit("lb/m2s", PoundFactor, true),
                new fmUnit("lb/ft2h", PoundFactor/Math.Pow(FootFactor, 2)/3600, true),
                new fmUnit("lb/ft2min", PoundFactor/Math.Pow(FootFactor, 2)/60, true),
                new fmUnit("lb/ft2s", PoundFactor/Math.Pow(FootFactor, 2), true));

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

        public fmUnit GetUnitByName(string name)
        {
            for (int i = 0; i < units.Count; ++i)
            {
                if (units[i].Name == name)
                {
                    return units[i];
                }
            }

            throw new Exception("No " + name + " units in unit family " + ToString());
        }

        public static fmUnitFamily GetFamilyByName(string unitFamilyName)
        {
            foreach (fmUnitFamily family in families)
            {
                if (family.Name == unitFamilyName)
                {
                    return family;
                }
            }
            throw new Exception("No unit family with name " + unitFamilyName + " found.");
        }
    }
}
