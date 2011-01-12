using System;
using System.Collections.Generic;
using System.Text;

namespace fmCalculationLibrary.Equations
{
    public class fmDeliquoringEquations
    {
        public static fmValue Eval_pke_From_pke0_sigma_Pc(fmValue pke0, fmValue sigma, fmValue Pc)
        {
            fmValue sigma0 = new fmValue(72 * 1e-3);
            fmValue Pc0 = new fmValue(1e-13);
            return pke0 * sigma / sigma0 * fmValue.Sqrt(Pc0 / Pc);
        }

        public static fmValue Eval_hcd_from_hcf_epsf_epsd(fmValue hcf, fmValue epsf, fmValue epsd)
        {
            return (1 - epsf) / (1 - epsd) * hcf;
        }
    }
}
