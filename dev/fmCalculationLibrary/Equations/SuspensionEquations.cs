namespace fmCalculationLibrary.Equations
{
    public class SuspensionEquations
    {
        static public fmValue Eval_rho_f_From_rho_s_rho_sus_Cm(fmValue rho_s, fmValue rho_sus, fmValue Cm)
        {
            return rho_s * rho_sus * (Cm - 1) / (-rho_s + Cm * rho_sus);
        }
        static public fmValue Eval_rho_f_From_rho_s_rho_sus_Cv(fmValue rho_s, fmValue rho_sus, fmValue Cv)
        {
            return (-rho_s * Cv + rho_sus) / (1 - Cv);
        }
        static public fmValue Eval_rho_f_From_rho_s_rho_sus_C(fmValue rho_s, fmValue rho_sus, fmValue C)
        {
            return rho_s * (-C + rho_sus) / (rho_s - C);
        }

        static public fmValue Eval_rho_s_From_rho_f_rho_sus_Cm(fmValue rho_f, fmValue rho_sus, fmValue Cm)
        {
            return Cm * rho_sus * rho_f / (Cm * rho_sus + rho_f - rho_sus);
        }
        static public fmValue Eval_rho_s_From_rho_f_rho_sus_Cv(fmValue rho_f, fmValue rho_sus, fmValue Cv)
        {
            return (Cv * rho_f - rho_f + rho_sus) / Cv;
        }
        static public fmValue Eval_rho_s_From_rho_f_rho_sus_C(fmValue rho_f, fmValue rho_sus, fmValue C)
        {
            return -C * rho_f / (-C - rho_f + rho_sus);
        }

        static public fmValue Eval_rho_sus_From_rho_f_rho_s_Cm(fmValue rho_f, fmValue rho_s, fmValue Cm)
        {
            return -rho_s * rho_f / (-Cm * rho_f + Cm * rho_s - rho_s);
        }
        static public fmValue Eval_rho_sus_From_rho_f_rho_s_Cv(fmValue rho_f, fmValue rho_s, fmValue Cv)
        {
            return -Cv * rho_f + Cv * rho_s + rho_f;
        }
        static public fmValue Eval_rho_sus_From_rho_f_rho_s_C(fmValue rho_f, fmValue rho_s, fmValue C)
        {
            return (-C * rho_f + C * rho_s + rho_s * rho_f) / rho_s;
        }

        
        static public fmValue Eval_Cm_From_rho(fmValue rho_f, fmValue rho_s, fmValue rho_sus)
        {
            return rho_s * (rho_f - rho_sus) / rho_sus / (rho_f - rho_s);
        }
        static public fmValue Eval_Cv_From_rho(fmValue rho_f, fmValue rho_s, fmValue rho_sus)
        {
            return (rho_f - rho_sus) / (rho_f - rho_s);
        }
        static public fmValue Eval_C_From_rho(fmValue rho_f, fmValue rho_s, fmValue rho_sus)
        {
            return rho_s * (rho_f - rho_sus) / (rho_f - rho_s);
        }
    }
}