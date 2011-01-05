using System;
using System.Collections.Generic;
using System.Text;

namespace fmCalculationLibrary.Equations
{
    public class fmEpsPcFrom0Equations
    {
        public static fmValue Eval_eps_From_eps0_Dp_ne(fmValue eps0, fmValue Dp, fmValue ne)
        {
            return eps0 * fmValue.Pow(Dp / 1e5, -ne);
        }

        public static fmValue Eval_Pc_From_Pc0_Dp_nc(fmValue Pc0, fmValue Dp, fmValue nc)
        {
            return Pc0 * fmValue.Pow(Dp / 1e5, -nc);
        }
    }
}
