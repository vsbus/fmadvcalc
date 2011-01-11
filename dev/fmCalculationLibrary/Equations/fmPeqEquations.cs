using System;
using System.Collections.Generic;
using System.Text;

namespace fmCalculationLibrary.Equations
{
    public class fmPeqEquations
    {
        public static fmValue Eval_T_From_Tetta(fmValue Tetta)
        {
            return Tetta + new fmValue(273);
        }

        public static fmValue Eval_peq_From_p0_DH_Mmole_T_Tboil_pke_rhof_Rm(fmValue p0, fmValue DH, fmValue Mmole, fmValue T, fmValue Tboil, fmValue pke, fmValue rhof, fmValue Rm)
        {
            fmValue deg1 = DH / Mmole * (1 / T - 1 / Tboil);
            fmValue deg2 = -pke / (rhof * Rm * T);
            return p0 * fmValue.Exp(deg1 + deg2);
        }

        public static fmValue Eval_Rm_From_Mmole(fmValue Mmole)
        {
            fmValue R0 = new fmValue(8.314);
            return R0 / Mmole;
        }
    }
}
