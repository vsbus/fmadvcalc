namespace fmCalculationLibrary.Equations
{
    public class PcrcaEquations
    {
        static public fmValue Eval_rc_From_Pc(fmValue Pc)
        {
            return 1 / Pc;
        }

        static public fmValue Eval_a_From_Pc_eps_rho_s(fmValue Pc, fmValue eps, fmValue rho_s)
        {
            return 1 / (Pc * (1 - eps) * rho_s);
        }

        public static fmValue Eval_Pc_From_rc(fmValue rc)
        {
            return 1 / rc;
        }

        public static fmValue Eval_Pc_From_a_eps_rho_s(fmValue a, fmValue eps, fmValue rho_s)
        {
            return 1 / (a * (1 - eps) * rho_s);
        }
    }
}