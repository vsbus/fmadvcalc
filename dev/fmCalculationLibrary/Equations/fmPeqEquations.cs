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

        public static fmValue Eval_peq_From_DH_Mmole_T_Tboil_pke_rhof(fmValue DH, fmValue Mmole, fmValue T, fmValue Tboil, fmValue pke, fmValue rhof)
        {
            fmValue p0 = new fmValue(1e5);
            fmValue R0 = new fmValue(8.314);
            fmValue v0 = new fmValue(0.0224);
            fmValue deg1 = -DH / R0 * (1 / T - 1 / Tboil);
            fmValue deg2 = -pke * v0 / (R0 * T);
            return p0 * fmValue.Exp(deg1 + deg2);
        }

        public static fmValue Eval_peq_From_DH_Mmole_T_Tboil_pke_rhof(fmValue Mmole, fmValue T, fmValue Tboil, fmValue pke, fmValue rhof)
        {
            fmValue p0 = new fmValue(1e5);
            fmValue R0 = new fmValue(8.314);
            fmValue v0 = new fmValue(0.0224);
            fmValue deg1 = -1000000 / R0 * (1 / T - 1 / Tboil);
            fmValue deg2 = -pke * v0 / (R0 * T);
            return p0 * fmValue.Exp(deg1 + deg2);
        }

        public static fmValue Eval_Rm_From_Mmole(fmValue Mmole)
        {
            throw new Exception("not implemented.");
            // !!!   Make R0 global constant before implementing
//             fmValue R0 = new fmValue(8.314);
//             return R0 / Mmole;
        }
    }
}
