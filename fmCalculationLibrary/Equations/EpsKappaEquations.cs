namespace fmCalculationLibrary.Equations
{
    public class EpsKappaEquations
    {
        static public fmValue Eval_eps_From_kappa_Cv(fmValue kappa, fmValue Cv)
        {
            return 1 - Cv * (kappa + 1) / kappa;
        }

        static public fmValue Eval_kappa_From_eps_Cv(fmValue eps, fmValue Cv)
        {
            return Cv / (1 - eps - Cv);
        }
    }
}