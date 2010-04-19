using System;
using System.Collections.Generic;
using fmCalculationLibrary.NumericalMethods;

namespace fmCalculationLibrary.Equations
{
    public class fmMathEquations
    {
        private class FunctionPowerSum : fmFunction
        {
            private readonly fmValue freeCoeff;
            private readonly fmValue[,] coeffsAndPowers;

            public FunctionPowerSum(fmValue freeCoeff, fmValue[,] coeffsAndPowers)
            {
                this.freeCoeff = freeCoeff;
                this.coeffsAndPowers = coeffsAndPowers;
            }

            public override fmValue Eval(fmValue x)
            {
                fmValue result = freeCoeff;
                for (int i = 0; i < coeffsAndPowers.GetLength(0); ++i)
                {
                    result += coeffsAndPowers[i, 0]*fmValue.Pow(x, coeffsAndPowers[i, 1]);
                }
                return result;
            }
        }

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

        private class FunctionC1xp1C2xp2C3p3C4 : fmFunction
        {
            private readonly fmValue c1;
            private readonly fmValue p1;
            private readonly fmValue c2;
            private readonly fmValue p2;
            private readonly fmValue c3;
            private readonly fmValue p3;
            private readonly fmValue c4;

            public FunctionC1xp1C2xp2C3p3C4(fmValue c1, fmValue p1, fmValue c2, fmValue p2, fmValue c3, fmValue p3, fmValue c4)
            {
                this.c1 = c1;
                this.p1 = p1;
                this.c2 = c2;
                this.p2 = p2;
                this.c3 = c3;
                this.p3 = p3;
                this.c4 = c4;
            }

            public override fmValue Eval(fmValue x)
            {
                return c1 * fmValue.Pow(x, p1) + c2 * fmValue.Pow(x, p2) + c3 * fmValue.Pow(x, p3) + c4;
            }
        }

        private static fmValue _infinity = new fmValue(1e20);
        private static fmValue _zero = new fmValue(0);
        private static fmValue _one= new fmValue(1);
        
       

        static public List<fmValue> SolveC1xp1C2xp2C3(fmValue c1, fmValue p1, fmValue c2, fmValue p2, fmValue c3)
        {
            //return SolvePowerSumEquation(c3, new fmValue[,] {{c1, p1}, {c2, p2}});
            List<fmValue> result = new List<fmValue>();
            if (!c1.Defined || !p1.Defined || !c2.Defined || !p2.Defined || !c3.Defined)
            {
                result.Add(new fmValue());
                return result;
            }

            if (c1 == _zero)
            {
                result.Add(SolveC1xp1C2(c2, p2, c3));
                return result;
            }
            if (c2 == _zero)
            {
                result.Add(SolveC1xp1C2(c1, p1, c3));
                return result;
            }
            if (c3 == _zero)
            {
                result.Add(SolveC1xp1C2xp2(c1, p1, c2, p2));
                return result;
            }
            if (p1 == _zero)
            {
                result.Add(SolveC1xp1C2(c2, p2, c1 + c3));
                return result;
            }
            if (p2 == _zero)
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

            const int iterations = 100;  // precision is 1e20 / 2^100 ~~ 1e-11

            if (!x0.Defined)
            {
                result.Add(fmNewtonMethod.FindRoot(new FunctionC1xp1C2xp2C3(c1, p1, c2, p2, c3), _zero, _infinity, iterations));
                return result;
            }

            result.Add(fmNewtonMethod.FindRoot(new FunctionC1xp1C2xp2C3(c1, p1, c2, p2, c3), _zero, x0, iterations));
            result.Add(fmNewtonMethod.FindRoot(new FunctionC1xp1C2xp2C3(c1, p1, c2, p2, c3), x0, _infinity, iterations));

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

            if (c2 == _zero)
                return SolveC1xp1(c1, p1);
            if (c1 == _zero)
                return new fmValue();
            return fmValue.Pow(-c2 / c1, 1 / p1);
        }

        static public fmValue SolveC1xp1C2xp2(fmValue c1, fmValue p1, fmValue c2, fmValue p2)
        {
            if (!c1.Defined || !p1.Defined || !c2.Defined || !p2.Defined)
                return new fmValue();

            if (c1 == _zero)
                return SolveC1xp1(c2, p2);
            if (c2 == _zero)
                return SolveC1xp1(c1, p1);
            if (p1 == _zero)
                return SolveC1xp1C2(c2, p2, c1);
            if (p2 == _zero)
                return SolveC1xp1C2(c1, p1, c2);
            if (p1 == p2)
                return SolveC1xp1(c1 + c2, p1);

            return fmValue.Pow(-c1 / c2, 1 / (p2 - p1));
        }

        static public fmValue SolveC1xp1(fmValue c1, fmValue p1)
        {
            if (!c1.Defined || !p1.Defined)
                return new fmValue();

            if (c1 == _zero)
                return _zero;

            if (p1 < _zero)
                return new fmValue();

            return _zero;
        }

        internal static List<fmValue> SolveC1xp1C2xp2C3xp3C4(fmValue c1, fmValue p1, fmValue c2, fmValue p2, fmValue c3, fmValue p3, fmValue c4)
        {
            List<fmValue> breakPoints = SolveC1xp1C2xp2C3(c1*p1, p1 - p3, c2*p2, p2 - p3, c3*p3);
            while (breakPoints.Count > 0 && breakPoints[0] == _zero)
                breakPoints.RemoveAt(0);
            breakPoints.Insert(0, _zero);
            breakPoints.Add(_infinity);

            const int interations = 100;  // precision is 1e20 / 2^100 ~~ 1e-11

            List<fmValue> result = new List<fmValue>();

            for (int i = 1; i < breakPoints.Count; ++i)
            {
                fmValue localRoot = fmNewtonMethod.FindRoot(
                    new FunctionC1xp1C2xp2C3p3C4(c1, p1, c2, p2, c3, p3, c4),
                    breakPoints[i - 1], breakPoints[i], interations);
                if (localRoot.Defined)
                    result.Add(localRoot);
            }
                
            result.Sort();
            return result;
        }

        static public List<fmValue> SolvePowerSumEquation(fmValue freeCoeff, fmValue[,] coeffsAndPowers)
        {
            SortedList<fmValue, fmValue> compressing = new SortedList<fmValue, fmValue>();
            for (int i = 0; i < coeffsAndPowers.GetLength(0); ++i)
            {
                fmValue c = coeffsAndPowers[i, 0];
                fmValue p = coeffsAndPowers[i, 1];
                if (!compressing.ContainsKey(p))
                {
                    compressing.Add(p, _zero);
                }

                compressing[p] += c;
            }
            
            SortedList<fmValue, fmValue> compressing2 = new SortedList<fmValue, fmValue>();
            foreach (KeyValuePair<fmValue, fmValue> cp in compressing)
            {
                if (cp.Value != _zero)
                    compressing2.Add(cp.Key, cp.Value);
            }
            compressing = compressing2;

            {
                fmValue[,] compressedCoeffsAndPowers = new fmValue[compressing.Count - (compressing.ContainsKey(_zero) ? 1 : 0), 2];
                int i = 0;
                foreach (KeyValuePair<fmValue, fmValue> cp in compressing)
                {
                    if (cp.Key == _zero)
                    {
                        freeCoeff += cp.Value;
                    }
                    else
                    {
                        compressedCoeffsAndPowers[i, 0] = cp.Value;
                        compressedCoeffsAndPowers[i, 1] = cp.Key;
                        ++i;
                    }
                }

                coeffsAndPowers = compressedCoeffsAndPowers;
            }

            List<fmValue> result = new List<fmValue>();

            for (int i = 0; i < coeffsAndPowers.GetLength(0); ++i)
            {
                if (coeffsAndPowers[i, 1] == new fmValue(0))
                {
                    throw new Exception(
                        "SolvePowerSumEquation: Powers must be non-zero values. Move such elemets to freeCoeff");
                }
            }

            for (int i = 1; i < coeffsAndPowers.GetLength(0); ++i)
            {
                if (coeffsAndPowers[i - 1, 1] >= coeffsAndPowers[i, 1])
                {
                    throw new Exception("SolvePowerSumEquation: Powers must be sorted in increasing order");
                }
            }

            if (coeffsAndPowers.GetLength(0) == 0)
            {
                return result;
            }
            else if (coeffsAndPowers.GetLength(0) == 1)
            {
                fmValue resVal = fmValue.Pow(-freeCoeff/coeffsAndPowers[0, 0], 1/coeffsAndPowers[0, 1]);
                if (resVal.Defined)
                {
                    result.Add(resVal);
                }
                return result;
            }
            else
            {
                if (freeCoeff == _zero)
                    result.Add(_zero);

                fmValue newFreeCoeff = new fmValue(coeffsAndPowers[0, 0] * coeffsAndPowers[0, 1]);
                fmValue[,] newCoeffsAndPowers = new fmValue[coeffsAndPowers.GetLength(0) - 1, 2];
                for (int i = 0; i < newCoeffsAndPowers.GetLength(0); ++i)
                {
                    newCoeffsAndPowers[i, 0] = coeffsAndPowers[i + 1, 0] * coeffsAndPowers[i + 1, 1];
                    newCoeffsAndPowers[i, 1] = coeffsAndPowers[i + 1, 1] - coeffsAndPowers[0, 1];
                }

                List<fmValue> changingPoints = new List<fmValue>();
                changingPoints.Add(_zero);
                changingPoints.AddRange(SolvePowerSumEquation(newFreeCoeff, newCoeffsAndPowers));
                changingPoints.Add(_infinity);

                const int iterations = 100;  // precision is 1e20 / 2^100 ~~ 1e-11

                for (int i = 1; i < changingPoints.Count; ++i)
                {
                    fmValue localSolution = fmNewtonMethod.FindRoot(new FunctionPowerSum(freeCoeff, coeffsAndPowers),
                                                                    changingPoints[i - 1],
                                                                    changingPoints[i], iterations);
                    if (localSolution.Defined)
                    {
                        result.Add(localSolution);
                    }
                }

                fmValue eps = new fmValue(1e-12);
                result.Sort();
                for (int i = result.Count - 1; i > 0; --i)
                {
                    if (result[i] <= (1 + eps) * result[i - 1]
                        || result[i] - result[i - 1] <= eps)
                        result.RemoveAt(i);
                }

                return result;
            }
        }
    }
}