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
        public static fmGlobalParameter Qf;
        public static fmGlobalParameter Qf_d;
        public static fmGlobalParameter Qs;
        public static fmGlobalParameter Qs_d;
        public static fmGlobalParameter Qc;
        public static fmGlobalParameter Qc_d;
        public static fmGlobalParameter Qsus;
        public static fmGlobalParameter Qsus_d;
        public static fmGlobalParameter Qmsus;
        public static fmGlobalParameter Qmsus_d;
        public static fmGlobalParameter Qms;
        public static fmGlobalParameter Qms_d;
        public static fmGlobalParameter Qmf;
        public static fmGlobalParameter Qmf_d;
        public static fmGlobalParameter Qmc;
        public static fmGlobalParameter Qmc_d;
        public static fmGlobalParameter qf;
        public static fmGlobalParameter qf_d;
        public static fmGlobalParameter qs;
        public static fmGlobalParameter qs_d;
        public static fmGlobalParameter qc;
        public static fmGlobalParameter qc_d;
        public static fmGlobalParameter qsus;
        public static fmGlobalParameter qsus_d;
        public static fmGlobalParameter qmsus;
        public static fmGlobalParameter qmsus_d;
        public static fmGlobalParameter qms;
        public static fmGlobalParameter qms_d;
        public static fmGlobalParameter qmf;
        public static fmGlobalParameter qmf_d;
        public static fmGlobalParameter qmc;
        public static fmGlobalParameter qmc_d;
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
            AddParameter(ref hc_over_tf, new fmGlobalParameter("hc/tf", fmUnitFamily.NoUnitFamily, new fmRange(0, 1)));
            AddParameter(ref dhc_over_dt, new fmGlobalParameter("dhc/dt", fmUnitFamily.NoUnitFamily, new fmRange(0, 1)));
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
            AddParameter(ref Qf, new fmGlobalParameter("Qf", fmUnitFamily.NoUnitFamily, new fmRange(0, 0.002)));
            AddParameter(ref Qf_d, new fmGlobalParameter("Qf,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 0.002)));
            AddParameter(ref Qs, new fmGlobalParameter("Qs", fmUnitFamily.NoUnitFamily, new fmRange(0, 0.002)));
            AddParameter(ref Qs_d, new fmGlobalParameter("Qs,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 0.002)));
            AddParameter(ref Qc, new fmGlobalParameter("Qc", fmUnitFamily.NoUnitFamily, new fmRange(0, 0.002)));
            AddParameter(ref Qc_d, new fmGlobalParameter("Qc,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 0.002)));
            AddParameter(ref Qsus, new fmGlobalParameter("Qsus", fmUnitFamily.FlowRateVolume, new fmRange(0, 0.002)));
            AddParameter(ref Qsus_d, new fmGlobalParameter("Qsus,d", fmUnitFamily.FlowRateVolume, new fmRange(0, 0.002)));
            AddParameter(ref Qmsus, new fmGlobalParameter("Qmsus", fmUnitFamily.FlowRateMass, new fmRange(0, 2)));
            AddParameter(ref Qmsus_d, new fmGlobalParameter("Qmsus,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            AddParameter(ref Qms, new fmGlobalParameter("Qms", fmUnitFamily.FlowRateMass, new fmRange(0, 2)));
            AddParameter(ref Qms_d, new fmGlobalParameter("Qms,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            AddParameter(ref Qmf, new fmGlobalParameter("Qmf", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            AddParameter(ref Qmf_d, new fmGlobalParameter("Qmf,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            AddParameter(ref Qmc, new fmGlobalParameter("Qmc", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            AddParameter(ref Qmc_d, new fmGlobalParameter("Qmc,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            AddParameter(ref qf, new fmGlobalParameter("qf", fmUnitFamily.NoUnitFamily, new fmRange(0, 0.002)));
            AddParameter(ref qf_d, new fmGlobalParameter("qf,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 0.002)));
            AddParameter(ref qs, new fmGlobalParameter("qs", fmUnitFamily.NoUnitFamily, new fmRange(0, 0.002)));
            AddParameter(ref qs_d, new fmGlobalParameter("qs,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 0.002)));
            AddParameter(ref qc, new fmGlobalParameter("qc", fmUnitFamily.NoUnitFamily, new fmRange(0, 0.002)));
            AddParameter(ref qc_d, new fmGlobalParameter("qc,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 0.002)));
            AddParameter(ref qsus, new fmGlobalParameter("qsus", fmUnitFamily.NoUnitFamily, new fmRange(0, 0.002)));
            AddParameter(ref qsus_d, new fmGlobalParameter("qsus,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 0.002)));
            AddParameter(ref qmsus, new fmGlobalParameter("qmsus", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            AddParameter(ref qmsus_d, new fmGlobalParameter("qmsus,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            AddParameter(ref qms, new fmGlobalParameter("qms", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            AddParameter(ref qms_d, new fmGlobalParameter("qms,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            AddParameter(ref qmf, new fmGlobalParameter("qmf", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            AddParameter(ref qmf_d, new fmGlobalParameter("qmf,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            AddParameter(ref qmc, new fmGlobalParameter("qmc", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            AddParameter(ref qmc_d, new fmGlobalParameter("qmc,d", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
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
