using System;
using System.Collections.Generic;
using System.Text;

namespace fmCalculationLibrary.Equations
{
    public class fmBasicEquations
    {
        public static fmValue Eval_Volume_From_rho_Mass(fmValue rho, fmValue M)
        {
            return M / rho;
        }

        public static fmValue Eval_Mass_From_rho_Volume(fmValue rho, fmValue V)
        {
            return rho * V;
        }
    }
}
