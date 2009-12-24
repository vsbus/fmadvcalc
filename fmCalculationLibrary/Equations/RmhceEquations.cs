namespace fmCalculationLibrary.Equations
{
    public class RmhceEquations
    {
        static public fmValue Eval_Rm_From_hce_Pc(fmValue hce, fmValue Pc)
        {
            return hce / Pc;
        }

        static public fmValue Eval_hce_From_Rm_Pc(fmValue Rm, fmValue Pc)
        {
            return Rm * Pc;
        }
    }
}