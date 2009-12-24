using System;
using System.Collections.Generic;

namespace fmCalculationLibrary.MeasureUnits
{
    public class fmUnitFamily
    {
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
        
        private int CurrentIndex;
        public List<fmUnit> Units = new List<fmUnit>();

        static fmUnitFamily()
        {
            NoUnitFamily.Units.Add(new fmUnit("-", 1));

            MassFamily.Units.Add(new fmUnit("kg", 1));
            MassFamily.Units.Add(new fmUnit("g", .001));
            MassFamily.Units.Add(new fmUnit("mg", .000001));

            VolumeFamily.Units.Add(new fmUnit("l", .001));
            VolumeFamily.Units.Add(new fmUnit("m3", 1));
            VolumeFamily.Units.Add(new fmUnit("cm3", 1e-6));

            AreaFamily.Units.Add(new fmUnit("m2", 1));
            AreaFamily.Units.Add(new fmUnit("cm2", 1e-4));
            
            LengthFamily.Units.Add(new fmUnit("mm", .001));
            LengthFamily.Units.Add(new fmUnit("cm", .01));
            LengthFamily.Units.Add(new fmUnit("m", 1.0));

            FrequencyFamily.Units.Add(new fmUnit("min-1", 1.0/60));
            FrequencyFamily.Units.Add(new fmUnit("s-1", 1));

            ConcentrationFamily.Units.Add(new fmUnit("%", 0.01)); 
            ConcentrationFamily.Units.Add(new fmUnit("-", 1));

            ConcentrationCFamily.Units.Add(new fmUnit("g/l", 1));
            
            DensityFamily.Units.Add(new fmUnit("kg/m3", 1));

            ViscosityFamily.Units.Add(new fmUnit("mPa s", 1e-3));

            PermeabilityFamily.Units.Add(new fmUnit("10-13m2", 1e-13));
            PermeabilityFamily.Units.Add(new fmUnit("m2", 1));

            CakeResistanceRcFamily.Units.Add(new fmUnit("10+13m-2", 1e13));
            CakeResistanceRcFamily.Units.Add(new fmUnit("m-2", 1));

            CakeResistanceAFamily.Units.Add(new fmUnit("10+10m/kg", 1e10));
            CakeResistanceAFamily.Units.Add(new fmUnit("m/kg", 1));

            FilterMediumResistanceFamily.Units.Add(new fmUnit("10+10m-1", 1e10));
            FilterMediumResistanceFamily.Units.Add(new fmUnit("m-1", 1));

            PressureFamily.Units.Add(new fmUnit("bar", 1e5)); 
            PressureFamily.Units.Add(new fmUnit("Pa", 1));

            TimeFamily.Units.Add(new fmUnit("s", 1));
            TimeFamily.Units.Add(new fmUnit("min", 60));

            FlowRateVolume.Units.Add(new fmUnit("l/h", 1e-3/(60*60)));
            FlowRateVolume.Units.Add(new fmUnit("m3/s", 1));

            FlowRateMass.Units.Add(new fmUnit("kg/h", 1.0 / (60 * 60)));
            FlowRateMass.Units.Add(new fmUnit("kg/s", 1));
        }

        public fmUnit CurrentUnit
        {
            get { return Units[CurrentIndex]; }
        }

        public void SetCurrentUnit(string name)
        {
            for (int i = 0; i < Units.Count; ++i)
            {
                if (Units[i].Name == name)
                {
                    CurrentIndex = i;
                    return;
                }
            }

            throw new Exception("No " + name + " units in unit family " + ToString());
        }
    }
}