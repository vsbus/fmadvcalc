using System;
using System.Collections.Generic;
using System.Text;
using fmCalculatorsLibrary;
using fmCalculationLibrary;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //fmEpsKappaCalculator epsKappaCalc = new fmEpsKappaCalculator(fmEpsKappaCalculator.CalculationOptions.EPS_IS_INPUT);
            //epsKappaCalc.constants.Cv = new fmValue(0.5);

            //for (double e = 0.1; e < 1; e += 0.1)
            //{
            //    epsKappaCalc.variables.eps = new fmValue(e);
            //    epsKappaCalc.DoCalculations();
            //    System.Console.WriteLine("eps = " + epsKappaCalc.variables.eps.ToString() + ",  kappa = " + epsKappaCalc.variables.kappa.ToString());
            //}

            fmSuspensionCalculator sc = new fmSuspensionCalculator(fmSuspensionCalculator.CalculationOptions.CM_CV_C_CALCULATED);
            sc.variables.rho_f = new fmValue(1000);
            sc.variables.rho_s = new fmValue(2250);
            sc.variables.rho_sus = new fmValue(1200);
            for (double x = 2000; x < 3000; x += 50)
            {
                sc.variables.rho_s = new fmValue(x);
                sc.DoCalculations();
                System.Console.WriteLine("rho_s = " + sc.variables.rho_s.ToString() + ",  Cm = " + sc.variables.Cm.ToString(6));
            }
        }
    }
}
