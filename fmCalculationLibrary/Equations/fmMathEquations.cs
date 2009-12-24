using System.Collections.Generic;
using fmCalculationLibrary.NumericalMethods;

namespace fmCalculationLibrary.Equations
{
    public class fmMathEquations
    {
        private class FunctionC1xp1C2xp2C3 : fmFunction
        {
            private readonly fmValue c1;
            private readonly fmValue p1;
            private readonly fmValue c2;
            private readonly fmValue p2;
            private readonly fmValue c3;

            public FunctionC1xp1C2xp2C3(fmValue c1, fmValue p1, fmValue c2, fmValue p2, fmValue c3)
            {
                this.c1 = c1;
                this.p1 = p1;
                this.c2 = c2;
                this.p2 = p2;
                this.c3 = c3;
            }

            public override fmValue Eval(fmValue x)
            {
                return c1 * fmValue.Pow(x, p1) + c2 * fmValue.Pow(x, p2) + c3;
            }
        }

        static public List<fmValue> SolveC1xp1C2xp2C3(fmValue c1, fmValue p1, fmValue c2, fmValue p2, fmValue c3)
        {
            List<fmValue> result = new List<fmValue>();
            if (!c1.Defined || !p1.Defined || !c2.Defined || !p2.Defined || !c3.Defined)
            {
                result.Add(new fmValue());
                return result;
            }

            fmValue zero = new fmValue(0);

            if (c1 == zero)
            {
                result.Add(SolveC1xp1C2(c2, p2, c3));
                return result;
            }
            if (c2 == zero)
            {
                result.Add(SolveC1xp1C2(c1, p1, c3));
                return result;
            }
            if (c3 == zero)
            {
                result.Add(SolveC1xp1C2xp2(c1, p1, c2, p2));
                return result;
            }
            if (p1 == zero)
            {
                result.Add(SolveC1xp1C2(c2, p2, c1 + c3));
                return result;
            }
            if (p2 == zero)
            {
                result.Add(SolveC1xp1C2(c1, p1, c2 + c3));
                return result;
            }
            if (p1 == p2)
            {
                result.Add(SolveC1xp1C2(c1 + c2, p1, c3));
                return result;
            }

            fmValue x0 = SolveC1xp1C2xp2(c1 * p1, p1 - 1, c2 * p2, p2 - 1);

            fmValue inf = new fmValue(1e20);
            const int interations = 100;  // precision is 1e20 / 2^100 ~~ 1e-11

            if (!x0.Defined)
            {
                result.Add(fmNewtonMethod.FindRoot(new FunctionC1xp1C2xp2C3(c1, p1, c2, p2, c3), zero, inf, interations));
                return result;
            }

            result.Add(fmNewtonMethod.FindRoot(new FunctionC1xp1C2xp2C3(c1, p1, c2, p2, c3), zero, x0, interations));
            result.Add(fmNewtonMethod.FindRoot(new FunctionC1xp1C2xp2C3(c1, p1, c2, p2, c3), x0, inf, interations));

            if (!result[1].Defined)
            {
                result.RemoveAt(1);
            }
            else if (!result[0].Defined)
            {
                result.RemoveAt(0);
            }

            result.Sort();
            return result;
        }

        static public fmValue SolveC1xp1C2(fmValue c1, fmValue p1, fmValue c2)
        {
            if (!c1.Defined || !p1.Defined || !c2.Defined)
                return new fmValue();

            fmValue zero = new fmValue(0);

            if (c2 == zero)
                return SolveC1xp1(c1, p1);
            if (c1 == zero)
                return new fmValue();
            return fmValue.Pow(-c2 / c1, 1 / p1);
        }

        static public fmValue SolveC1xp1C2xp2(fmValue c1, fmValue p1, fmValue c2, fmValue p2)
        {
            if (!c1.Defined || !p1.Defined || !c2.Defined || !p2.Defined)
                return new fmValue();

            fmValue zero = new fmValue(0);

            if (c1 == zero)
                return SolveC1xp1(c2, p2);
            if (c2 == zero)
                return SolveC1xp1(c1, p1);
            if (p1 == zero)
                return SolveC1xp1C2(c2, p2, c1);
            if (p2 == zero)
                return SolveC1xp1C2(c1, p1, c2);
            if (p1 == p2)
                return SolveC1xp1(c1 + c2, p1);

            return fmValue.Pow(-c1 / c2, 1 / (p2 - p1));
        }

        static public fmValue SolveC1xp1(fmValue c1, fmValue p1)
        {
            if (!c1.Defined || !p1.Defined)
                return new fmValue();

            fmValue zero = new fmValue(0);

            if (c1 == zero)
                return zero;

            if (p1 < zero)
                return new fmValue();

            return zero;
        }
    }
}