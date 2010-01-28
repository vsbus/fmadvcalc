using System.Collections.Generic;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary
{
    public class fmGlobalParameter
    {
        public string name;

        public string Name
        {
            get { return name; }
        }
        public fmUnitFamily unitFamily;
        public string Unit
        {
            get { return unitFamily.CurrentUnit.Name; }
        }
       
        public fmRange chartXRange;
        
        public double MinValue
        {
            get { return chartXRange.minValue; }
        }
        public double MaxValue
        {
            get { return chartXRange.maxValue; }
        }
        
        
        public static fmGlobalParameter A;
        public static fmGlobalParameter Dp;
        public static fmGlobalParameter sf;
        public static fmGlobalParameter n;
        public static fmGlobalParameter tc;
        public static fmGlobalParameter tf;
        public static fmGlobalParameter tr;
        public static fmGlobalParameter hc_over_tf;
        public static fmGlobalParameter dhc_over_dt;
        public static fmGlobalParameter hc;
        public static fmGlobalParameter Qsus;
        public static fmGlobalParameter Qmsus;
        public static fmGlobalParameter Qms;
        public static fmGlobalParameter Vsus;
        public static fmGlobalParameter Mf;
        public static fmGlobalParameter Vf;
        public static fmGlobalParameter mf;
        public static fmGlobalParameter vf;
        public static fmGlobalParameter ms;
        public static fmGlobalParameter vs;
        public static fmGlobalParameter msus;
        public static fmGlobalParameter vsus;
        public static fmGlobalParameter mc;
        public static fmGlobalParameter vc;
        public static fmGlobalParameter Vc;
        public static fmGlobalParameter Mc;
        public static fmGlobalParameter Ms;
        public static fmGlobalParameter Vs;
        public static fmGlobalParameter Msus;
        public static fmGlobalParameter eps;
        public static fmGlobalParameter kappa;
        public static fmGlobalParameter Pc;
        public static fmGlobalParameter rc;
        public static fmGlobalParameter a;
        public static fmGlobalParameter Rm;
        public static fmGlobalParameter hce;
        public static fmGlobalParameter ne;
        public static fmGlobalParameter rho_f;
        public static fmGlobalParameter rho_s;
        public static fmGlobalParameter rho_sus;
        public static fmGlobalParameter Cm;
        public static fmGlobalParameter Cv;
        public static fmGlobalParameter C;
        public static fmGlobalParameter eta_f;
        public static fmGlobalParameter nc;
        public static List<fmGlobalParameter> Parameters = new List<fmGlobalParameter>();

        static void AddParameter( ref fmGlobalParameter p1, fmGlobalParameter p2)
        {
            p1 = p2;
            Parameters.Add(p1);
        }

        static fmGlobalParameter()
        {
            AddParameter(ref A, new fmGlobalParameter("A", fmUnitFamily.AreaFamily, new fmRange(0, 2)));
            AddParameter(ref Dp, new fmGlobalParameter("Dp", fmUnitFamily.PressureFamily, new fmRange(0, 500000)));
            AddParameter(ref sf, new fmGlobalParameter("sf", fmUnitFamily.ConcentrationFamily, new fmRange(0, 1)));
            AddParameter(ref n, new fmGlobalParameter("n", fmUnitFamily.FrequencyFamily, new fmRange(0, 1)));
            AddParameter(ref tc, new fmGlobalParameter("tc", fmUnitFamily.TimeFamily, new fmRange(0, 1000)));
            AddParameter(ref tf, new fmGlobalParameter("tf", fmUnitFamily.TimeFamily, new fmRange(0, 1000)));
            AddParameter(ref tr, new fmGlobalParameter("tr", fmUnitFamily.TimeFamily, new fmRange(0, 1000)));
            AddParameter(ref hc_over_tf, new fmGlobalParameter("hc_over_tf", fmUnitFamily.NoUnitFamily, new fmRange(0, 1)));
            AddParameter(ref dhc_over_dt, new fmGlobalParameter("dhc_over_dt", fmUnitFamily.NoUnitFamily, new fmRange(0, 1)));
            AddParameter(ref hc, new fmGlobalParameter("hc", fmUnitFamily.LengthFamily, new fmRange(0, 1)));
            AddParameter(ref Mf, new fmGlobalParameter("Mf", fmUnitFamily.MassFamily, new fmRange(0, 10)));
            AddParameter(ref Vf, new fmGlobalParameter("Vf", fmUnitFamily.VolumeFamily, new fmRange(0, 10)));
            AddParameter(ref mf, new fmGlobalParameter("mf", fmUnitFamily.NoUnitFamily, new fmRange(0, 10)));
            AddParameter(ref vf, new fmGlobalParameter("vf", fmUnitFamily.NoUnitFamily, new fmRange(0, 10)));
            AddParameter(ref ms, new fmGlobalParameter("ms", fmUnitFamily.NoUnitFamily, new fmRange(0, 10)));
            AddParameter(ref vs, new fmGlobalParameter("vs", fmUnitFamily.NoUnitFamily, new fmRange(0, 10)));
            AddParameter(ref msus, new fmGlobalParameter("msus", fmUnitFamily.NoUnitFamily, new fmRange(0, 10)));
            AddParameter(ref vsus, new fmGlobalParameter("vsus", fmUnitFamily.NoUnitFamily, new fmRange(0, 10)));
            AddParameter(ref mc, new fmGlobalParameter("mc", fmUnitFamily.NoUnitFamily, new fmRange(0, 10)));
            AddParameter(ref vc, new fmGlobalParameter("vc", fmUnitFamily.NoUnitFamily, new fmRange(0, 10)));
            AddParameter(ref Msus, new fmGlobalParameter("Msus", fmUnitFamily.MassFamily, new fmRange(0, 10)));
            AddParameter(ref Vsus, new fmGlobalParameter("Vsus", fmUnitFamily.VolumeFamily, new fmRange(0, 20)));
            AddParameter(ref Vc, new fmGlobalParameter("Vc", fmUnitFamily.VolumeFamily, new fmRange(0, 20)));
            AddParameter(ref Mc, new fmGlobalParameter("Mc", fmUnitFamily.MassFamily, new fmRange(0, 10)));
            AddParameter(ref Ms, new fmGlobalParameter("Ms", fmUnitFamily.MassFamily, new fmRange(0, 10)));
            AddParameter(ref Vs, new fmGlobalParameter("Vs", fmUnitFamily.VolumeFamily, new fmRange(0, 20)));
            AddParameter(ref Qsus, new fmGlobalParameter("Qsus", fmUnitFamily.FlowRateVolume, new fmRange(0, 0.002)));
            AddParameter(ref Qmsus, new fmGlobalParameter("Qmsus", fmUnitFamily.FlowRateMass, new fmRange(0, 2)));
            AddParameter(ref Qms, new fmGlobalParameter("Qms", fmUnitFamily.FlowRateMass, new fmRange(0, 2)));
            AddParameter(ref eps, new fmGlobalParameter("eps", fmUnitFamily.ConcentrationFamily));
            AddParameter(ref kappa, new fmGlobalParameter("kappa", fmUnitFamily.NoUnitFamily));
            AddParameter(ref Pc, new fmGlobalParameter("Pc", fmUnitFamily.PermeabilityFamily));
            AddParameter(ref rc, new fmGlobalParameter("rc", fmUnitFamily.CakeResistanceRcFamily));
            AddParameter(ref a, new fmGlobalParameter("a", fmUnitFamily.CakeResistanceAFamily));
            AddParameter(ref Rm, new fmGlobalParameter("Rm", fmUnitFamily.FilterMediumResistanceFamily));
            AddParameter(ref hce, new fmGlobalParameter("hce", fmUnitFamily.LengthFamily));
            AddParameter(ref ne, new fmGlobalParameter("ne", fmUnitFamily.NoUnitFamily));
            AddParameter(ref rho_f, new fmGlobalParameter("rho_f", fmUnitFamily.DensityFamily));
            AddParameter(ref rho_s, new fmGlobalParameter("rho_s", fmUnitFamily.DensityFamily));
            AddParameter(ref rho_sus, new fmGlobalParameter("rho_sus", fmUnitFamily.DensityFamily));
            AddParameter(ref Cm, new fmGlobalParameter("Cm", fmUnitFamily.ConcentrationFamily));
            AddParameter(ref Cv, new fmGlobalParameter("Cv", fmUnitFamily.ConcentrationFamily));
            AddParameter(ref C, new fmGlobalParameter("C", fmUnitFamily.ConcentrationCFamily));
            AddParameter(ref eta_f, new fmGlobalParameter("eta_f", fmUnitFamily.ViscosityFamily));
            AddParameter(ref nc, new fmGlobalParameter("nc", fmUnitFamily.NoUnitFamily));
        }

        public fmGlobalParameter(string name, fmUnitFamily unitFamily)
        {
            this.name = name;           
            this.unitFamily = unitFamily;
        }

        public fmGlobalParameter(string name, fmUnitFamily unitFamily, fmRange minMaxRange):this(name, unitFamily)
        {
            chartXRange = new fmRange(minMaxRange.minValue, minMaxRange.maxValue);
        }
    }
}
