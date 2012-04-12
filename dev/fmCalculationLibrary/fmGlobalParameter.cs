using System.Collections.Generic;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalculationLibrary
{
    public class fmGlobalParameter
    {
        public string name;
        public fmUnitFamily unitFamily;

        //
        // Summary:
        //     Return name of current unit for parameter
        public string UnitName
        {
            get { return unitFamily.CurrentUnit.Name; }
        }

        public fmDefaultParameterRange specifiedRange;
        public fmDefaultParameterRange validRange;
        public fmRange chartCurretXRange;

        // ReSharper disable InconsistentNaming
        #region CakeFormation
        public static fmGlobalParameter A;
        public static fmGlobalParameter d0;
        public static fmGlobalParameter Dp;
        public static fmGlobalParameter sf;
        public static fmGlobalParameter sr;
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
        public static fmGlobalParameter eps0;
        public static fmGlobalParameter kappa0;
        public static fmGlobalParameter Pc;
        public static fmGlobalParameter rc;
        public static fmGlobalParameter a;
        public static fmGlobalParameter Pc0;
        public static fmGlobalParameter rc0;
        public static fmGlobalParameter a0;
        public static fmGlobalParameter Rm;
        public static fmGlobalParameter Rm0;
        public static fmGlobalParameter hce0;
        public static fmGlobalParameter ne;
        public static fmGlobalParameter rho_f;
        public static fmGlobalParameter rho_d;
        public static fmGlobalParameter rho_s;
        public static fmGlobalParameter rho_sus;
        public static fmGlobalParameter Cm;
        public static fmGlobalParameter Cv;
        public static fmGlobalParameter C;
        public static fmGlobalParameter eta_f;
        public static fmGlobalParameter eta_d;
        public static fmGlobalParameter nc;
        #endregion
        #region Deliquoring
        public static fmGlobalParameter Dp_d;
        public static fmGlobalParameter eps_d;
        public static fmGlobalParameter sigma;
        public static fmGlobalParameter pke0;
        public static fmGlobalParameter pke;
        public static fmGlobalParameter pc_d;
        public static fmGlobalParameter rc_d;
        public static fmGlobalParameter alpha_d;
        public static fmGlobalParameter Srem;
        public static fmGlobalParameter ad1;
        public static fmGlobalParameter ad2;
        public static fmGlobalParameter Tetta;
        public static fmGlobalParameter eta_g;
        public static fmGlobalParameter ag1;
        public static fmGlobalParameter ag2;
        public static fmGlobalParameter ag3;
        public static fmGlobalParameter Tetta_boil;
        public static fmGlobalParameter DH;
        public static fmGlobalParameter Mmole;
        public static fmGlobalParameter f;
        public static fmGlobalParameter peq;

        public static fmGlobalParameter hcd;
        public static fmGlobalParameter sd;
        public static fmGlobalParameter td;
        public static fmGlobalParameter K;
        public static fmGlobalParameter Smech;
        public static fmGlobalParameter S;
        public static fmGlobalParameter Rfmech;
        public static fmGlobalParameter Rf;
        public static fmGlobalParameter Qgi;
        public static fmGlobalParameter Qg;
        public static fmGlobalParameter vg;
        public static fmGlobalParameter Mfd;
        public static fmGlobalParameter Vfd;
        public static fmGlobalParameter Mlcd;
        public static fmGlobalParameter Vlcd;
        public static fmGlobalParameter Mcd;
        public static fmGlobalParameter Vcd;
        public static fmGlobalParameter rho_bulk;
        public static fmGlobalParameter Qmfid;
        public static fmGlobalParameter Qfid;
        public static fmGlobalParameter Qmcd;
        public static fmGlobalParameter Qcd;
        public static fmGlobalParameter qmfid;
        public static fmGlobalParameter qfid;
        public static fmGlobalParameter qmcd;
        public static fmGlobalParameter qcd;

        public static fmGlobalParameter Qgt;
        public static fmGlobalParameter Vg;
        public static fmGlobalParameter Mev;
        public static fmGlobalParameter Vev;
        public static fmGlobalParameter Qmftd;
        public static fmGlobalParameter Qmfd;
        public static fmGlobalParameter Qftd;
        public static fmGlobalParameter Qfd;
        public static fmGlobalParameter Qmevi;
        public static fmGlobalParameter Qmevt;
        public static fmGlobalParameter Qmev;
        public static fmGlobalParameter Qevi;
        public static fmGlobalParameter Qevt;
        public static fmGlobalParameter Qev;
        public static fmGlobalParameter qmftd;
        public static fmGlobalParameter qmfd;
        public static fmGlobalParameter qftd;
        public static fmGlobalParameter qfd;
        public static fmGlobalParameter qmevi;
        public static fmGlobalParameter qmevt;
        public static fmGlobalParameter qmev;
        public static fmGlobalParameter qevi;
        public static fmGlobalParameter qevt;
        public static fmGlobalParameter qev;
        #endregion
        // ReSharper restore InconsistentNaming

        public static List<fmGlobalParameter> parameters = new List<fmGlobalParameter>();
        public static Dictionary<string, fmGlobalParameter> parametersByName = new Dictionary<string, fmGlobalParameter>();

        static void AddParameter(ref fmGlobalParameter p1, fmGlobalParameter p2)
        {
            p1 = p2;
            parameters.Add(p1);
            parametersByName[p1.name] = p1;
        }

        static fmGlobalParameter()
        {
            #region Material Data
            AddParameter(ref eta_f, new fmGlobalParameter("eta_f", fmUnitFamily.ViscosityFamily, new fmRange(0, 1)));
            AddParameter(ref eta_d, new fmGlobalParameter("eta_d", fmUnitFamily.ViscosityFamily, new fmRange(0, 1)));
            
            AddParameter(ref rho_f, new fmGlobalParameter("rho_f", fmUnitFamily.DensityFamily, new fmRange(600, 2500)));
            AddParameter(ref rho_d, new fmGlobalParameter("rho_d", fmUnitFamily.DensityFamily, new fmRange(600, 2500)));
            AddParameter(ref rho_s, new fmGlobalParameter("rho_s", fmUnitFamily.DensityFamily, new fmRange(1500, 5000)));
            AddParameter(ref rho_sus, new fmGlobalParameter("rho_sus", fmUnitFamily.DensityFamily, new fmRange(1000, 3000)));
            AddParameter(ref Cm, new fmGlobalParameter("Cm", fmUnitFamily.ConcentrationFamily, new fmRange(0, 1)));
            AddParameter(ref Cv, new fmGlobalParameter("Cv", fmUnitFamily.ConcentrationFamily, new fmRange(0, 1)));
            AddParameter(ref C, new fmGlobalParameter("C", fmUnitFamily.ConcentrationCFamily, new fmRange(0, 1000)));

            AddParameter(ref eps0, new fmGlobalParameter("eps0", fmUnitFamily.ConcentrationFamily, new fmRange(0, 1)));
            AddParameter(ref kappa0, new fmGlobalParameter("kappa0", fmUnitFamily.NoUnitFamily, new fmRange(0, 5)));

            AddParameter(ref ne, new fmGlobalParameter("ne", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            
            AddParameter(ref Pc0, new fmGlobalParameter("Pc0", fmUnitFamily.PermeabilityFamily, new fmRange(1e-13, 30e-13)));
            AddParameter(ref rc0, new fmGlobalParameter("rc0", fmUnitFamily.CakeResistanceRcFamily, new fmRange(0.03e+13, 1000e+13)));
            AddParameter(ref a0, new fmGlobalParameter("a0", fmUnitFamily.CakeResistanceAFamily, new fmRange(0.03e+10, 1000e+10)));

            AddParameter(ref nc, new fmGlobalParameter("nc", fmUnitFamily.NoUnitFamily, new fmRange(0, 2)));
            
            AddParameter(ref hce0, new fmGlobalParameter("hce0", fmUnitFamily.LengthFamily, new fmRange(0, 40)));
            AddParameter(ref Rm0, new fmGlobalParameter("Rm0", fmUnitFamily.FilterMediumResistanceFamily, new fmRange(0, 10e10)));
            #endregion
            #region Cake Formation Data
            AddParameter(ref A, new fmGlobalParameter("A", fmUnitFamily.AreaFamily, new fmRange(0.01, 200)));
            AddParameter(ref d0, new fmGlobalParameter("d0", fmUnitFamily.LengthFamily, new fmRange(0.01, 200)));
            AddParameter(ref Dp, new fmGlobalParameter("Dp", fmUnitFamily.PressureFamily, new fmRange(0.1 * 1e5, 6 * 1e5)));
            AddParameter(ref sf, new fmGlobalParameter("sf", fmUnitFamily.ConcentrationFamily, new fmRange(0.05, 1)));
            AddParameter(ref sr, new fmGlobalParameter("sr", fmUnitFamily.ConcentrationFamily, new fmRange(0.05, 1)));
            AddParameter(ref n, new fmGlobalParameter("n", fmUnitFamily.FrequencyFamily, new fmRange(0.1 / 60, 6.0 / 60)));
            AddParameter(ref tc, new fmGlobalParameter("tc", fmUnitFamily.TimeFamily, new fmRange(60, 36000)));
            AddParameter(ref tf, new fmGlobalParameter("tf", fmUnitFamily.TimeFamily, new fmRange(1, 12000)));
            AddParameter(ref tr, new fmGlobalParameter("tr", fmUnitFamily.TimeFamily, new fmRange(5, 1000)));
            AddParameter(ref hc_over_tf, new fmGlobalParameter("hc/tf", fmUnitFamily.SpeedFamily, new fmRange(1.0e-3 / 60, 1000.0e-3 / 60)));
            AddParameter(ref dhc_over_dt, new fmGlobalParameter("dhc/dt", fmUnitFamily.SpeedFamily, new fmRange(1.0e-3 / 60, 1000.0e-3 / 60)));
            AddParameter(ref hc, new fmGlobalParameter("hc", fmUnitFamily.LengthFamily, new fmRange(3 * 1e-3, 1000e-3)));
            AddParameter(ref Mf, new fmGlobalParameter("Mf", fmUnitFamily.MassFamily, new fmRange(0.01, 10000)));
            AddParameter(ref Vf, new fmGlobalParameter("Vf", fmUnitFamily.VolumeFamily, new fmRange(0.01e-3, 10000e-3)));
            AddParameter(ref mf, new fmGlobalParameter("mf", fmUnitFamily.SpecificMassFamily, new fmRange(1, 100)));
            AddParameter(ref vf, new fmGlobalParameter("vf", fmUnitFamily.VolumeInAreaFamily, new fmRange(1e-3, 100e-3)));
            AddParameter(ref ms, new fmGlobalParameter("ms", fmUnitFamily.SpecificMassFamily, new fmRange(1, 20)));
            AddParameter(ref vs, new fmGlobalParameter("vs", fmUnitFamily.VolumeInAreaFamily, new fmRange(1e-3, 20e-3)));
            AddParameter(ref msus, new fmGlobalParameter("msus", fmUnitFamily.SpecificMassFamily, new fmRange(1, 100)));
            AddParameter(ref vsus, new fmGlobalParameter("vsus", fmUnitFamily.VolumeInAreaFamily, new fmRange(1e-3, 100e-3)));
            AddParameter(ref mc, new fmGlobalParameter("mc", fmUnitFamily.SpecificMassFamily, new fmRange(1, 50)));
            AddParameter(ref vc, new fmGlobalParameter("vc", fmUnitFamily.VolumeInAreaFamily, new fmRange(1e-3, 50e-3)));
            AddParameter(ref Msus, new fmGlobalParameter("Msus", fmUnitFamily.MassFamily, new fmRange(0.1, 20000)));
            AddParameter(ref Vsus, new fmGlobalParameter("Vsus", fmUnitFamily.VolumeFamily, new fmRange(0.1e-3, 20000e-3)));
            AddParameter(ref Vc, new fmGlobalParameter("Vc", fmUnitFamily.VolumeFamily, new fmRange(0.01e-3, 10000e-3)));
            AddParameter(ref Mc, new fmGlobalParameter("Mc", fmUnitFamily.MassFamily, new fmRange(0.01, 10000)));
            AddParameter(ref Ms, new fmGlobalParameter("Ms", fmUnitFamily.MassFamily, new fmRange(0.01, 5000)));
            AddParameter(ref Vs, new fmGlobalParameter("Vs", fmUnitFamily.VolumeFamily, new fmRange(0.01e-3, 5000e-3)));
            AddParameter(ref Qf, new fmGlobalParameter("Qf", fmUnitFamily.FlowRateVolume, new fmRange(1e-3 / 3600, 5000000e-3 / 3600)));
            AddParameter(ref Qf_d, new fmGlobalParameter("Qf,d", fmUnitFamily.FlowRateVolume, new fmRange(1e-3 / 3600, 5000000e-3 / 3600)));
            AddParameter(ref Qs, new fmGlobalParameter("Qs", fmUnitFamily.FlowRateVolume, new fmRange(0.1e-3 / 3600, 1000000e-3 / 3600)));
            AddParameter(ref Qs_d, new fmGlobalParameter("Qs,d", fmUnitFamily.FlowRateVolume, new fmRange(0.1e-3 / 3600, 1000000e-3 / 3600)));
            AddParameter(ref Qc, new fmGlobalParameter("Qc", fmUnitFamily.FlowRateVolume, new fmRange(0.1e-3 / 3600, 1000000e-3 / 3600)));
            AddParameter(ref Qc_d, new fmGlobalParameter("Qc,d", fmUnitFamily.FlowRateVolume, new fmRange(0.1e-3 / 3600, 1000000e-3 / 3600)));
            AddParameter(ref Qsus, new fmGlobalParameter("Qsus", fmUnitFamily.FlowRateVolume, new fmRange(0.1e-3 / 3600, 5000000e-3 / 3600)));
            AddParameter(ref Qsus_d, new fmGlobalParameter("Qsus,d", fmUnitFamily.FlowRateVolume, new fmRange(0.1e-3 / 3600, 5000000e-3 / 3600)));
            AddParameter(ref Qmsus, new fmGlobalParameter("Qmsus", fmUnitFamily.FlowRateMass, new fmRange(0.1 / 3600, 5000000.0 / 3600)));
            AddParameter(ref Qmsus_d, new fmGlobalParameter("Qmsus,d", fmUnitFamily.FlowRateMass, new fmRange(0.1 / 3600, 5000000.0 / 3600)));
            AddParameter(ref Qms, new fmGlobalParameter("Qms", fmUnitFamily.FlowRateMass, new fmRange(0.1 / 3600, 1000000.0 / 3600)));
            AddParameter(ref Qms_d, new fmGlobalParameter("Qms,d", fmUnitFamily.FlowRateMass, new fmRange(0.1 / 3600, 1000000.0 / 3600)));
            AddParameter(ref Qmf, new fmGlobalParameter("Qmf", fmUnitFamily.FlowRateMass, new fmRange(0.1 / 3600, 5000000.0 / 3600)));
            AddParameter(ref Qmf_d, new fmGlobalParameter("Qmf,d", fmUnitFamily.FlowRateMass, new fmRange(0.1 / 3600, 5000000.0 / 3600)));
            AddParameter(ref Qmc, new fmGlobalParameter("Qmc", fmUnitFamily.FlowRateMass, new fmRange(0.1 / 3600, 5000000.0 / 3600)));
            AddParameter(ref Qmc_d, new fmGlobalParameter("Qmc,d", fmUnitFamily.FlowRateMass, new fmRange(0.1 / 3600, 5000000.0 / 3600)));
            AddParameter(ref qf, new fmGlobalParameter("qf", fmUnitFamily.SpecificFlowRateVolume, new fmRange(1.0e-3 / 60, 500.0e-3 / 60)));
            AddParameter(ref qf_d, new fmGlobalParameter("qf,d", fmUnitFamily.SpecificFlowRateVolume, new fmRange(1.0e-3 / 60, 500.0e-3 / 60)));
            AddParameter(ref qs, new fmGlobalParameter("qs", fmUnitFamily.SpecificFlowRateVolume, new fmRange(0.1e-3 / 60, 100.0e-3 / 60)));
            AddParameter(ref qs_d, new fmGlobalParameter("qs,d", fmUnitFamily.SpecificFlowRateVolume, new fmRange(0.1e-3 / 60, 100.0e-3 / 60)));
            AddParameter(ref qc, new fmGlobalParameter("qc", fmUnitFamily.SpecificFlowRateVolume, new fmRange(0.1e-3 / 60, 100.0e-3 / 60)));
            AddParameter(ref qc_d, new fmGlobalParameter("qc,d", fmUnitFamily.SpecificFlowRateVolume, new fmRange(0.1e-3 / 60, 100.0e-3 / 60)));
            AddParameter(ref qsus, new fmGlobalParameter("qsus", fmUnitFamily.SpecificFlowRateVolume, new fmRange(1.0e-3 / 60, 500.0e-3 / 60)));
            AddParameter(ref qsus_d, new fmGlobalParameter("qsus,d", fmUnitFamily.SpecificFlowRateVolume, new fmRange(1.0e-3 / 60, 500.0e-3 / 60)));
            AddParameter(ref qmsus, new fmGlobalParameter("qmsus", fmUnitFamily.SpecificFlowRateMass, new fmRange(1.0 / 60, 500.0 / 60)));
            AddParameter(ref qmsus_d, new fmGlobalParameter("qmsus,d", fmUnitFamily.SpecificFlowRateMass, new fmRange(1.0 / 60, 500.0 / 60)));
            AddParameter(ref qms, new fmGlobalParameter("qms", fmUnitFamily.SpecificFlowRateMass, new fmRange(0.1 / 60, 100.0 / 60)));
            AddParameter(ref qms_d, new fmGlobalParameter("qms,d", fmUnitFamily.SpecificFlowRateMass, new fmRange(0.1 / 60, 100.0 / 60)));
            AddParameter(ref qmf, new fmGlobalParameter("qmf", fmUnitFamily.SpecificFlowRateMass, new fmRange(1.0 / 60, 500.0 / 60)));
            AddParameter(ref qmf_d, new fmGlobalParameter("qmf,d", fmUnitFamily.SpecificFlowRateMass, new fmRange(1.0 / 60, 500.0 / 60)));
            AddParameter(ref qmc, new fmGlobalParameter("qmc", fmUnitFamily.SpecificFlowRateMass, new fmRange(0.1 / 60, 100.0 / 60)));
            AddParameter(ref qmc_d, new fmGlobalParameter("qmc,d", fmUnitFamily.SpecificFlowRateMass, new fmRange(0.1 / 60, 100.0 / 60)));
            AddParameter(ref eps, new fmGlobalParameter("eps", fmUnitFamily.ConcentrationFamily, new fmRange(0.3, 0.9)));
            AddParameter(ref kappa, new fmGlobalParameter("kappa", fmUnitFamily.NoUnitFamily, new fmRange(0.001, 3)));
            AddParameter(ref Pc, new fmGlobalParameter("Pc", fmUnitFamily.PermeabilityFamily, new fmRange(0.001e-13, 30e-13)));
            AddParameter(ref rc, new fmGlobalParameter("rc", fmUnitFamily.CakeResistanceRcFamily, new fmRange(0.03e+13, 1000e+13)));
            AddParameter(ref a, new fmGlobalParameter("a", fmUnitFamily.CakeResistanceAFamily, new fmRange(0.03e+10, 1000e+10)));
            AddParameter(ref Rm, new fmGlobalParameter("Rm", fmUnitFamily.FilterMediumResistanceFamily));
            #endregion
            #region Deliquoring
            AddParameter(ref Dp_d, new fmGlobalParameter("Dpd", fmUnitFamily.PressureFamily));
            AddParameter(ref eps_d, new fmGlobalParameter("epsd", fmUnitFamily.ConcentrationFamily));
            AddParameter(ref sigma, new fmGlobalParameter("sigma", fmUnitFamily.SurfaceTensionFamily));
            AddParameter(ref pke0, new fmGlobalParameter("pke0", fmUnitFamily.PressureFamily));
            AddParameter(ref pke, new fmGlobalParameter("pke", fmUnitFamily.PressureFamily));
            AddParameter(ref pc_d, new fmGlobalParameter("pcd", fmUnitFamily.PermeabilityFamily));
            AddParameter(ref rc_d, new fmGlobalParameter("rcd", fmUnitFamily.CakeResistanceRcFamily));
            AddParameter(ref alpha_d, new fmGlobalParameter("alphad", fmUnitFamily.CakeResistanceAFamily));
            AddParameter(ref Srem, new fmGlobalParameter("Srem", fmUnitFamily.ConcentrationFamily));
            AddParameter(ref ad1, new fmGlobalParameter("ad1", fmUnitFamily.NoUnitFamily));
            AddParameter(ref ad2, new fmGlobalParameter("ad2", fmUnitFamily.NoUnitFamily));
            AddParameter(ref Tetta, new fmGlobalParameter("Tetta", fmUnitFamily.TemperatureCelsius));
            AddParameter(ref eta_g, new fmGlobalParameter("eta_g", fmUnitFamily.ViscosityFamily));
            AddParameter(ref ag1, new fmGlobalParameter("ag1", fmUnitFamily.NoUnitFamily));
            AddParameter(ref ag2, new fmGlobalParameter("ag2", fmUnitFamily.NoUnitFamily));
            AddParameter(ref ag3, new fmGlobalParameter("ag3", fmUnitFamily.NoUnitFamily));
            AddParameter(ref Tetta_boil, new fmGlobalParameter("Tetta_boil", fmUnitFamily.TemperatureCelsius));
            AddParameter(ref DH, new fmGlobalParameter("DH", fmUnitFamily.EvaporationEnthalpyFamily));
            AddParameter(ref Mmole, new fmGlobalParameter("Mmole", fmUnitFamily.MolarMassFamily));
            AddParameter(ref f, new fmGlobalParameter("f", fmUnitFamily.NoUnitFamily));
            AddParameter(ref peq, new fmGlobalParameter("peq", fmUnitFamily.PressureFamily));

            AddParameter(ref hcd, new fmGlobalParameter("hcd", fmUnitFamily.LengthFamily));
            AddParameter(ref sd, new fmGlobalParameter("sd", fmUnitFamily.ConcentrationFamily, new fmRange(0.01, 0.99)));
            AddParameter(ref td, new fmGlobalParameter("td", fmUnitFamily.TimeFamily, new fmRange(1, 1000)));
            AddParameter(ref K, new fmGlobalParameter("K", fmUnitFamily.NoUnitFamily, new fmRange(0.01, 0.99)));
            AddParameter(ref Smech, new fmGlobalParameter("Smech", fmUnitFamily.ConcentrationFamily, new fmRange(0.01, 0.99)));
            AddParameter(ref S, new fmGlobalParameter("S", fmUnitFamily.ConcentrationFamily, new fmRange(0.01, 0.99)));
            AddParameter(ref Rfmech, new fmGlobalParameter("Rfmech", fmUnitFamily.ConcentrationFamily, new fmRange(0.01, 0.99)));
            AddParameter(ref Rf, new fmGlobalParameter("Rf", fmUnitFamily.ConcentrationFamily, new fmRange(0.01, 0.99)));
            AddParameter(ref Qgi, new fmGlobalParameter("Qgi", fmUnitFamily.GasFlowRateVolume, new fmRange(0.1e-3 / 3600, 5000000e-3 / 3600)));
            AddParameter(ref Qg, new fmGlobalParameter("Qg", fmUnitFamily.GasFlowRateVolume, new fmRange(0.1e-3 / 3600, 5000000e-3 / 3600)));
            AddParameter(ref vg, new fmGlobalParameter("vg", fmUnitFamily.VolumeInMassFamily, new fmRange(1e-3, 50e-3)));
            AddParameter(ref Mfd, new fmGlobalParameter("Mfd", fmUnitFamily.MassFamily, new fmRange(0.01, 5000)));
            AddParameter(ref Vfd, new fmGlobalParameter("Vfd", fmUnitFamily.VolumeFamily, new fmRange(0.01e-3, 10000e-3)));
            AddParameter(ref Mlcd, new fmGlobalParameter("Mlcd", fmUnitFamily.MassFamily, new fmRange(0.01, 5000)));
            AddParameter(ref Vlcd, new fmGlobalParameter("Vlcd", fmUnitFamily.VolumeFamily, new fmRange(0.01e-3, 10000e-3)));
            AddParameter(ref Mcd, new fmGlobalParameter("Mcd", fmUnitFamily.MassFamily, new fmRange(0.01, 5000)));
            AddParameter(ref Vcd, new fmGlobalParameter("Vcd", fmUnitFamily.VolumeFamily, new fmRange(0.01e-3, 10000e-3)));
            AddParameter(ref rho_bulk, new fmGlobalParameter("rho_bulk", fmUnitFamily.DensityFamily, new fmRange(1000, 3000)));
            AddParameter(ref Qmfid, new fmGlobalParameter("Qmfid", fmUnitFamily.FlowRateMass, new fmRange(0.1 / 3600, 1000000.0 / 3600)));
            AddParameter(ref Qfid, new fmGlobalParameter("Qfid", fmUnitFamily.FlowRateMass, new fmRange(0.1e-3 / 3600, 5000000e-3 / 3600)));
            AddParameter(ref Qmcd, new fmGlobalParameter("Qmcd", fmUnitFamily.FlowRateMass, new fmRange(0.1 / 3600, 1000000.0 / 3600)));
            AddParameter(ref Qcd, new fmGlobalParameter("Qcd", fmUnitFamily.FlowRateMass, new fmRange(0.1e-3 / 3600, 5000000e-3 / 3600)));
            AddParameter(ref qmfid, new fmGlobalParameter("qmfid", fmUnitFamily.SpecificFlowRateMass, new fmRange(0.1 / 60, 100.0 / 60)));
            AddParameter(ref qfid, new fmGlobalParameter("qfid", fmUnitFamily.SpecificFlowRateVolume, new fmRange(1.0e-3 / 60, 500.0e-3 / 60)));
            AddParameter(ref qmcd, new fmGlobalParameter("qmcd", fmUnitFamily.SpecificFlowRateMass, new fmRange(0.1 / 60, 100.0 / 60)));
            AddParameter(ref qcd, new fmGlobalParameter("qcd", fmUnitFamily.SpecificFlowRateVolume, new fmRange(1.0e-3 / 60, 500.0e-3 / 60)));

            AddParameter(ref Qgt, new fmGlobalParameter("Qgt", fmUnitFamily.GasFlowRateVolume));
            AddParameter(ref Vg, new fmGlobalParameter("Vg", fmUnitFamily.VolumeFamily));
            AddParameter(ref Mev, new fmGlobalParameter("Mev", fmUnitFamily.MassFamily));
            AddParameter(ref Vev, new fmGlobalParameter("Vev", fmUnitFamily.VolumeFamily));
            AddParameter(ref Qmftd, new fmGlobalParameter("Qmftd", fmUnitFamily.FlowRateMass));
            AddParameter(ref Qmfd, new fmGlobalParameter("Qmfd", fmUnitFamily.FlowRateMass));
            AddParameter(ref Qftd, new fmGlobalParameter("Qftd", fmUnitFamily.FlowRateVolume));
            AddParameter(ref Qfd, new fmGlobalParameter("Qfd", fmUnitFamily.FlowRateVolume));
            AddParameter(ref Qmevi, new fmGlobalParameter("Qmevi", fmUnitFamily.FlowRateMass));
            AddParameter(ref Qmevt, new fmGlobalParameter("Qmevt", fmUnitFamily.FlowRateMass));
            AddParameter(ref Qmev, new fmGlobalParameter("Qmev", fmUnitFamily.FlowRateMass));
            AddParameter(ref Qevi, new fmGlobalParameter("Qevi", fmUnitFamily.FlowRateVolume));
            AddParameter(ref Qevt, new fmGlobalParameter("Qevt", fmUnitFamily.FlowRateVolume));
            AddParameter(ref Qev, new fmGlobalParameter("Qev", fmUnitFamily.FlowRateVolume));
            AddParameter(ref qmftd, new fmGlobalParameter("qmftd", fmUnitFamily.SpecificFlowRateMass));
            AddParameter(ref qmfd, new fmGlobalParameter("qmfd", fmUnitFamily.SpecificFlowRateMass));
            AddParameter(ref qftd, new fmGlobalParameter("qftd", fmUnitFamily.SpecificFlowRateVolume));
            AddParameter(ref qfd, new fmGlobalParameter("qfd", fmUnitFamily.SpecificFlowRateVolume));
            AddParameter(ref qmevi, new fmGlobalParameter("qmevi", fmUnitFamily.SpecificFlowRateMass));
            AddParameter(ref qmevt, new fmGlobalParameter("qmevt", fmUnitFamily.SpecificFlowRateMass));
            AddParameter(ref qmev, new fmGlobalParameter("qmev", fmUnitFamily.SpecificFlowRateMass));
            AddParameter(ref qevi, new fmGlobalParameter("qevi", fmUnitFamily.SpecificFlowRateVolume));
            AddParameter(ref qevt, new fmGlobalParameter("qevt", fmUnitFamily.SpecificFlowRateVolume));
            AddParameter(ref qev, new fmGlobalParameter("qev", fmUnitFamily.SpecificFlowRateVolume));
            #endregion

            A.specifiedRange.IsInputed = true;
            Dp.specifiedRange.IsInputed = true;
            sf.specifiedRange.IsInputed = true;
            tc.specifiedRange.IsInputed = true;
        }

        public fmGlobalParameter(string name, fmUnitFamily unitFamily, fmRange minMaxRange)
        {
            this.name = name;
            this.unitFamily = unitFamily;
            specifiedRange = minMaxRange.isUnlimited ? new fmDefaultParameterRange() : new fmDefaultParameterRange(minMaxRange.MinValue, minMaxRange.MaxValue);
            validRange = minMaxRange.isUnlimited ? new fmDefaultParameterRange() : new fmDefaultParameterRange(minMaxRange.MinValue, minMaxRange.MaxValue);
            chartCurretXRange = minMaxRange.isUnlimited ? new fmRange() : new fmRange(minMaxRange.MinValue, minMaxRange.MaxValue);
        }

        public fmGlobalParameter(string name, fmUnitFamily unitFamily) : this(name, unitFamily, new fmDefaultParameterRange()) { }
    }


}
