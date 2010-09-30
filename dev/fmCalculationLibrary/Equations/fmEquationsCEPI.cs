using System;

namespace fmCalculationLibrary.Equations
{
    // ReSharper disable InconsistentNaming
    public class fmEquationsCEPI
    // ReSharper restore InconsistentNaming
    {
        // ReSharper disable InconsistentNaming
        private const double g = 9.80665;

        public static fmValue Eval_A_From_b_D(fmValue b, fmValue D)
        {
            return b * Math.PI * D;
        }

        public static fmValue Eval_bOverD_From_b_D(fmValue b, fmValue D)
        {
            return b / D;
        }

        public static fmValue Eval_b_From_A_D(fmValue A, fmValue D)
        {
            return A / (Math.PI * D);
        }

        public static fmValue Eval_nmax_From_D_Gmax(fmValue D, fmValue Gmax)
        {
            return fmValue.Sqrt(g * Gmax / (2 * Math.PI * Math.PI * D));
        }

        public static fmValue Eval_b_From_bOverD_D(fmValue bOverD, fmValue D)
        {
            return bOverD * D;
        }

        public static fmValue Eval_hb_From_b_D_Vb(fmValue b, fmValue D, fmValue Vb)
        {
            fmValue descrim = fmValue.Sqr(D * Math.PI * b) - 4.0 * Math.PI * b * Vb;
            return 0.5 * (D * Math.PI * b - fmValue.Sqrt(descrim)) / (Math.PI * b);
        }

        public static fmValue Eval_hbOverR_From_D_hb(fmValue D, fmValue hb)
        {
            return 2.0 * hb / D;
        }

        public static fmValue Eval_Vb_From_b_D_hb(fmValue b, fmValue D, fmValue hb)
        {
            return Math.PI * b * hb * (D - hb);
        }

        public static fmValue Eval_hb_From_D_hbOverR(fmValue D, fmValue hbOverR)
        {
            return 0.5 * hbOverR * D;
        }

        public static fmValue Eval_Gmax_From_D_nmax(fmValue D, fmValue nmax)
        {
            return 2.0 * fmValue.Sqr(Math.PI * nmax) * D / g;
        }

        public static fmValue Eval_D_From_A_b(fmValue A, fmValue b)
        {
            return A / (Math.PI * b);
        }

        public static fmValue Eval_D_From_A_bOverD(fmValue A, fmValue bOverD)
        {
            return fmValue.Sqrt(A / (bOverD * Math.PI));
        }

        public static fmValue Eval_A_From_b_hb_Vb(fmValue b, fmValue hb, fmValue Vb)
        {
            return (Vb + Math.PI * b * fmValue.Sqr(hb)) / hb;
        }

        public static fmValue Eval_D_From_bOverD_hb_Vb(fmValue bOverD, fmValue hb, fmValue Vb)
        {
            fmValue X = Math.PI * bOverD * hb;
            return hb / 2 + fmValue.Sqrt(fmValue.Sqr(hb / 2) + Vb / X);
        }

        public static fmValue Eval_b_From_A_hb_Vb(fmValue A, fmValue hb, fmValue Vb)
        {
            return (A * hb - Vb) / (Math.PI * hb);
        }

        public static fmValue Eval_D_From_b_hbOverR_Vb(fmValue b, fmValue hbOverR, fmValue Vb)
        {
            return fmValue.Sqrt(2 * Vb / (Math.PI * b * hbOverR * (1 - hbOverR / 2)));
        }

        public static fmValue Eval_D_From_bOverD_hbOverR_Vb(fmValue bOverD, fmValue hbOverR, fmValue Vb)
        {
            return fmValue.Pow(2 * Vb / (Math.PI * bOverD * hbOverR * (1 - hbOverR / 2)), 1.0 / 3);
        }

        public static fmValue Eval_D_From_A_hbOverR_Vb(fmValue A, fmValue hbOverR, fmValue Vb)
        {
            return 2 * Vb / (A * hbOverR * (1 - hbOverR / 2));
        }

        public static fmValue Eval_D_From_Gmax_nmax(fmValue Gmax, fmValue nmax)
        {
            return .5 * Gmax * g / (fmValue.Sqr(Math.PI * nmax));
        }
        // ReSharper restore InconsistentNaming
    }
}