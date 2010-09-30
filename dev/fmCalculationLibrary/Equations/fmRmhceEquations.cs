namespace fmCalculationLibrary.Equations
{
    public class fmRmhceEquations
    {
        // ReSharper disable InconsistentNaming
        static public fmValue Eval_Rm_From_hce_Pc(fmValue hce, fmValue Pc)
        {
            return hce / Pc;
        }
        static public fmValue Eval_hce_From_Rm_Pc(fmValue Rm, fmValue Pc)
        {
            return Rm * Pc;
        }
        // ReSharper restore InconsistentNaming
    }
}