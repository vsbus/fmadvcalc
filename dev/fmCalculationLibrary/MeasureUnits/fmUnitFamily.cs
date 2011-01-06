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
        public static fmUnitFamily SpeedFamily = new fmUnitFamily();
        public static fmUnitFamily SpecificMassFamily = new fmUnitFamily();
        public static fmUnitFamily SpecificVolumeFamily = new fmUnitFamily();
        public static fmUnitFamily SpecificFlowRateVolume = new fmUnitFamily();
        public static fmUnitFamily SpecificFlowRateMass = new fmUnitFamily();
        public static fmUnitFamily SurfaceTensionFamily = new fmUnitFamily();
        public static fmUnitFamily TemperatureCelsius = new fmUnitFamily();
        public static fmUnitFamily EvaporationEnthalpyFamily = new fmUnitFamily();
        public static fmUnitFamily MolarMassFamily = new fmUnitFamily();
        // ReSharper restore InconsistentNaming
        
        private int m_currentIndex;
        public List<fmUnit> units = new List<fmUnit>();

        static fmUnitFamily()
        {
            NoUnitFamily.units.Add(new fmUnit("-", 1));

            MassFamily.units.Add(new fmUnit("kg", 1));
            MassFamily.units.Add(new fmUnit("g", .001));
            MassFamily.units.Add(new fmUnit("mg", .000001));

            VolumeFamily.units.Add(new fmUnit("l", .001));
            VolumeFamily.units.Add(new fmUnit("m3", 1));
            VolumeFamily.units.Add(new fmUnit("cm3", 1e-6));

            AreaFamily.units.Add(new fmUnit("m2", 1));
            AreaFamily.units.Add(new fmUnit("cm2", 1e-4));
            
            LengthFamily.units.Add(new fmUnit("mm", .001));
            LengthFamily.units.Add(new fmUnit("cm", .01));
            LengthFamily.units.Add(new fmUnit("m", 1.0));

            FrequencyFamily.units.Add(new fmUnit("min-1", 1.0/60));
            FrequencyFamily.units.Add(new fmUnit("s-1", 1));

            ConcentrationFamily.units.Add(new fmUnit("%", 0.01)); 
            ConcentrationFamily.units.Add(new fmUnit("-", 1));

            ConcentrationCFamily.units.Add(new fmUnit("g/l", 1));
            
            DensityFamily.units.Add(new fmUnit("kg/m3", 1));

            ViscosityFamily.units.Add(new fmUnit("mPa s", 1e-3));

            PermeabilityFamily.units.Add(new fmUnit("10-13m2", 1e-13));
            PermeabilityFamily.units.Add(new fmUnit("m2", 1));

            CakeResistanceRcFamily.units.Add(new fmUnit("10+13m-2", 1e13));
            CakeResistanceRcFamily.units.Add(new fmUnit("m-2", 1));

            CakeResistanceAFamily.units.Add(new fmUnit("10+10m/kg", 1e10));
            CakeResistanceAFamily.units.Add(new fmUnit("m/kg", 1));

            FilterMediumResistanceFamily.units.Add(new fmUnit("10+10m-1", 1e10));
            FilterMediumResistanceFamily.units.Add(new fmUnit("m-1", 1));

            PressureFamily.units.Add(new fmUnit("bar", 1e5)); 
            PressureFamily.units.Add(new fmUnit("Pa", 1));

            TimeFamily.units.Add(new fmUnit("s", 1));
            TimeFamily.units.Add(new fmUnit("min", 60));

            FlowRateVolume.units.Add(new fmUnit("l/h", 1e-3/(60*60)));
            FlowRateVolume.units.Add(new fmUnit("m3/s", 1));

            FlowRateMass.units.Add(new fmUnit("kg/h", 1.0 / (60 * 60)));
            FlowRateMass.units.Add(new fmUnit("kg/s", 1));

            SpeedFamily.units.Add(new fmUnit("mm/min", 1e-3/60));
            SpeedFamily.units.Add(new fmUnit("m/s", 1));

            SpecificMassFamily.units.Add(new fmUnit("kg/m2", 1));

            SpecificVolumeFamily.units.Add(new fmUnit("l/m2", 1e-3));
            SpecificVolumeFamily.units.Add(new fmUnit("m3/m2", 1));

            SpecificFlowRateVolume.units.Add(new fmUnit("l/m2min", 1e-3/60));
            SpecificFlowRateVolume.units.Add(new fmUnit("m3/m2s", 1));

            SpecificFlowRateMass.units.Add(new fmUnit("kg/m2min", 1.0/60));
            SpecificFlowRateMass.units.Add(new fmUnit("kg/m2s", 1));

            SurfaceTensionFamily.units.Add(new fmUnit("N/m", 1));
            SurfaceTensionFamily.units.Add(new fmUnit("10-3 N/m", 1e-3));

            TemperatureCelsius.units.Add(new fmUnit("C°", 1));

            EvaporationEnthalpyFamily.units.Add(new fmUnit("KJ/mole", 1e3));
            
            MolarMassFamily.units.Add(new fmUnit("g/mole", 1e-3));
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