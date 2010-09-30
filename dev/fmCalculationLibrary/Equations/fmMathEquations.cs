using System;
using System.Collections.Generic;
using fmCalculationLibrary.NumericalMethods;

namespace fmCalculationLibrary.Equations
{
    public class fmMathEquations
    {
        private class fmFunctionPowerSum : fmFunction
        {
            private readonly fmValue m_freeCoeff;
            private readonly fmValue[,] m_coeffsAndPowers;

            public fmFunctionPowerSum(fmValue freeCoeff, fmValue[,] coeffsAndPowers)
            {
                m_freeCoeff = freeCoeff;
                m_coeffsAndPowers = coeffsAndPowers;
            }

            public override fmValue Eval(fmValue x)
            {
                fmValue result = m_freeCoeff;
                for (int i = 0; i < m_coeffsAndPowers.GetLength(0); ++i)
                {
                    result += m_coeffsAndPowers[i, 0]*fmValue.Pow(x, m_coeffsAndPowers[i, 1]);
                }
                return result;
            }
        }

        private class fmFunctionC1Xp1C2Xp2C3 : fmFunction
        {
            private readonly fmValue m_c1;
            private readonly fmValue m_p1;
            private readonly fmValue m_c2;
            private readonly fmValue m_p2;
            private readonly fmValue m_c3;

            public fmFunctionC1Xp1C2Xp2C3(fmValue c1, fmValue p1, fmValue c2, fmValue p2, fmValue c3)
            {
                m_c1 = c1;
                m_p1 = p1;
                m_c2 = c2;
                m_p2 = p2;
                m_c3 = c3;
            }

            public override fmValue Eval(fmValue x)
            {
                return m_c1 * fmValue.Pow(x, m_p1) + m_c2 * fmValue.Pow(x, m_p2) + m_c3;
            }
        }

        private class fmFunctionC1Xp1C2Xp2C3P3C4 : fmFunction
        {
            private readonly fmValue m_c1;
            private readonly fmValue m_p1;
            private readonly fmValue m_c2;
            private readonly fmValue m_p2;
            private readonly fmValue m_c3;
            private readonly fmValue m_p3;
            private readonly fmValue m_c4;

            public fmFunctionC1Xp1C2Xp2C3P3C4(fmValue c1, fmValue p1, fmValue c2, fmValue p2, fmValue c3, fmValue p3, fmValue c4)
            {
                m_c1 = c1;
                m_p1 = p1;
                m_c2 = c2;
                m_p2 = p2;
                m_c3 = c3;
                m_p3 = p3;
                m_c4 = c4;
            }

            public override fmValue Eval(fmValue x)
            {
                return m_c1 * fmValue.Pow(x, m_p1) + m_c2 * fmValue.Pow(x, m_p2) + m_c3 * fmValue.Pow(x, m_p3) + m_c4;
            }
        }

        private static readonly fmValue Infinity = new fmValue(1e20);
        private static readonly fmValue Zero = new fmValue(0);

        static public List<fmValue> SolveC1Xp1C2Xp2C3(fmValue c1, fmValue p1, fmValue c2, fmValue p2, fmValue c3, fmValue upperBoundForBisection)
        {
            //return SolvePowerSumEquation(c3, new fmValue[,] {{c1, p1}, {c2, p2}});
            var result = new List<fmValue>();
            if (!c1.defined || !p1.defined || !c2.defined || !p2.defined || !c3.defined)
            {
                result.Add(new fmValue());
                return result;
            }

            if (c1 == Zero)
            {
                result.Add(SolveC1Xp1C2(c2, p2, c3));
                return result;
            }
            if (c2 == Zero)
            {
                result.Add(SolveC1Xp1C2(c1, p1, c3));
                return result;
            }
            if (c3 == Zero)
            {
                result.Add(SolveC1Xp1C2Xp2(c1, p1, c2, p2));
                return result;
            }
            if (p1 == Zero)
            {
                result.Add(SolveC1Xp1C2(c2, p2, c1 + c3));
                return result;
            }
            if (p2 == Zero)
            {
                result.Add(SolveC1Xp1C2(c1, p1, c2 + c3));
                return result;
            }
            if (p1 == p2)
            {
                result.Add(SolveC1Xp1C2(c1 + c2, p1, c3));
                return result;
            }

            fmValue x0 = SolveC1Xp1C2Xp2(c1 * p1, p1 - 1, c2 * p2, p2 - 1);

            const int iterations = 100;  // precision is 1e20 / 2^100 ~~ 1e-11

            if (!x0.defined)
            {
                result.Add(fmBisectionMethod.FindRoot(new fmFunctionC1Xp1C2Xp2C3(c1, p1, c2, p2, c3), Zero, upperBoundForBisection, iterations));
                return result;
            }

            result.Add(fmBisectionMethod.FindRoot(new fmFunctionC1Xp1C2Xp2C3(c1, p1, c2, p2, c3), Zero, x0, iterations));
            result.Add(fmBisectionMethod.FindRoot(new fmFunctionC1Xp1C2Xp2C3(c1, p1, c2, p2, c3), x0, upperBoundForBisection, iterations));

            if (!result[1].defined)
            {
                result.RemoveAt(1);
            }
            else if (!result[0].defined)
            {
                result.RemoveAt(0);
            }

            result.Sort();
            return result;
        }

        static public fmValue SolveC1Xp1C2(fmValue c1, fmValue p1, fmValue c2)
        {
            if (!c1.defined || !p1.defined || !c2.defined)
                return new fmValue();

            if (c2 == Zero)
                return SolveC1Xp1(c1, p1);
            if (c1 == Zero)
                return new fmValue();
            return fmValue.Pow(-c2 / c1, 1 / p1);
        }

        static public fmValue SolveC1Xp1C2Xp2(fmValue c1, fmValue p1, fmValue c2, fmValue p2)
        {
            if (!c1.defined || !p1.defined || !c2.defined || !p2.defined)
                return new fmValue();

            if (c1 == Zero)
                return SolveC1Xp1(c2, p2);
            if (c2 == Zero)
                return SolveC1Xp1(c1, p1);
            if (p1 == Zero)
                return SolveC1Xp1C2(c2, p2, c1);
            if (p2 == Zero)
                return SolveC1Xp1C2(c1, p1, c2);
            if (p1 == p2)
                return SolveC1Xp1(c1 + c2, p1);

            return fmValue.Pow(-c1 / c2, 1 / (p2 - p1));
        }

        static public fmValue SolveC1Xp1(fmValue c1, fmValue p1)
        {
            if (!c1.defined || !p1.defined)
                return new fmValue();

            if (c1 == Zero)
                return Zero;

            if (p1 < Zero)
                return new fmValue();

            return Zero;
        }

        internal static List<fmValue> SolveC1Xp1C2Xp2C3Xp3C4(fmValue c1, fmValue p1, fmValue c2, fmValue p2, fmValue c3, fmValue p3, fmValue c4)
        {
            List<fmValue> breakPoints = SolveC1Xp1C2Xp2C3(c1*p1, p1 - p3, c2*p2, p2 - p3, c3*p3, Infinity);
            while (breakPoints.Count > 0 && breakPoints[0] == Zero)
                breakPoints.RemoveAt(0);
            breakPoints.Insert(0, Zero);
            breakPoints.Add(Infinity);

            const int interations = 100;  // precision is 1e20 / 2^100 ~~ 1e-11

            var result = new List<fmValue>();

            for (int i = 1; i < breakPoints.Count; ++i)
            {
                fmValue localRoot = fmBisectionMethod.FindRoot(
                    new fmFunctionC1Xp1C2Xp2C3P3C4(c1, p1, c2, p2, c3, p3, c4),
                    breakPoints[i - 1], breakPoints[i], interations);
                if (localRoot.defined)
                    result.Add(localRoot);
            }
                
            result.Sort();
            return result;
        }

        static public List<fmValue> SolvePowerSumEquation(fmValue freeCoeff, fmValue[,] coeffsAndPowers)
        {
            var compressing = new SortedList<fmValue, fmValue>();
            for (int i = 0; i < coeffsAndPowers.GetLength(0); ++i)
            {
                fmValue c = coeffsAndPowers[i, 0];
                fmValue p = coeffsAndPowers[i, 1];
                if (!compressing.ContainsKey(p))
                {
                    compressing.Add(p, Zero);
                }

                compressing[p] += c;
            }
            
            var compressing2 = new SortedList<fmValue, fmValue>();
            foreach (KeyValuePair<fmValue, fmValue> cp in compressing)
            {
                if (cp.Value != Zero)
                    compressing2.Add(cp.Key, cp.Value);
            }
            compressing = compressing2;

            {
                var compressedCoeffsAndPowers = new fmValue[compressing.Count - (compressing.ContainsKey(Zero) ? 1 : 0), 2];
                int i = 0;
                foreach (KeyValuePair<fmValue, fmValue> cp in compressing)
                {
                    if (cp.Key == Zero)
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

            var result = new List<fmValue>();

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
            if (coeffsAndPowers.GetLength(0) == 1)
            {
                fmValue resVal = fmValue.Pow(-freeCoeff/coeffsAndPowers[0, 0], 1/coeffsAndPowers[0, 1]);
                if (resVal.defined)
                {
                    result.Add(resVal);
                }
                return result;
            }
            if (freeCoeff == Zero)
                result.Add(Zero);

            var newFreeCoeff = new fmValue(coeffsAndPowers[0, 0] * coeffsAndPowers[0, 1]);
            var newCoeffsAndPowers = new fmValue[coeffsAndPowers.GetLength(0) - 1, 2];
            for (int i = 0; i < newCoeffsAndPowers.GetLength(0); ++i)
            {
                newCoeffsAndPowers[i, 0] = coeffsAndPowers[i + 1, 0] * coeffsAndPowers[i + 1, 1];
                newCoeffsAndPowers[i, 1] = coeffsAndPowers[i + 1, 1] - coeffsAndPowers[0, 1];
            }

            var changingPoints = new List<fmValue> {Zero};
            changingPoints.AddRange(SolvePowerSumEquation(newFreeCoeff, newCoeffsAndPowers));
            changingPoints.Add(Infinity);

            const int iterations = 100;  // precision is 1e20 / 2^100 ~~ 1e-11

            for (int i = 1; i < changingPoints.Count; ++i)
            {
                fmValue localSolution = fmBisectionMethod.FindRoot(new fmFunctionPowerSum(freeCoeff, coeffsAndPowers),
                                                                   changingPoints[i - 1],
                                                                   changingPoints[i], iterations);
                if (localSolution.defined)
                {
                    result.Add(localSolution);
                }
            }

            var eps = new fmValue(1e-12);
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