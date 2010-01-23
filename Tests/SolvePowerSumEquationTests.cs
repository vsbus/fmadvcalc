using System;
using System.Collections.Generic;
using System.Text;
using fmCalculationLibrary;
using fmCalculationLibrary.Equations;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class SolvePowerSumEquationTests
    {
        private bool EqualLists(List<fmValue> l1, List<fmValue> l2)
        {
            if (l1.Count != l2.Count)
                return false;
            for (int i = 0; i < l1.Count; ++i)
                if (l1[i] != l2[i])
                    return false;
            return true;
        }

        [Test]
        public void LinearEquationTest()
        {
            List<fmValue> result = fmMathEquations.SolvePowerSumEquation(new fmValue(-20),
                                                                         new fmValue[1,2]
                                                                             {{new fmValue(5), new fmValue(1)}});
            List<fmValue> expectedResult = new List<fmValue>(new fmValue[] {new fmValue(4)});

            Assert.IsTrue(EqualLists(result, expectedResult));
        }

        [Test]
        public void SquareRootEquation()
        {
            List<fmValue> result = fmMathEquations.SolvePowerSumEquation(new fmValue(-16),
                                                                         new fmValue[1, 2] { { new fmValue(1), new fmValue(2) } });
            List<fmValue> expectedResult = new List<fmValue>(new fmValue[] { new fmValue(-4), new fmValue(4) });

            Assert.IsTrue(EqualLists(result, expectedResult));
            
            // x^2*C1 +C2*x^4 =0;
            fmValue c1 = new fmValue(16);
            
            fmValue c2 = new fmValue(4);
            result = fmMathEquations.SolvePowerSumEquation(new fmValue(0),
                                                           new fmValue[2,2] {{c1, new fmValue(2)}, {c2, new fmValue(4)}});
            expectedResult = new List<fmValue>(new fmValue[] { new fmValue(-2), new fmValue(0), new fmValue(2) });
            Assert.IsTrue(EqualLists(result, expectedResult));
        }

        //[Test]
        //public void SolvePowerSumEquationTest()
        //{
        //    const int MAXCOEF = 20;
        //    double eps = Math.Exp(-10);
        //    Random ran = new Random();

        //    for (int n = 1; n < 5; n++)
        //    {
        //        fmValue freeCoeff;
        //        fmValue [,] coeffAndPow = new fmValue[n, 2];
        //        for (int j = 0; j < n; j++)
        //        {
        //            coeffAndPow[j, 0] = new fmValue(ran.Next(MAXCOEF) - MAXCOEF/2);
        //            coeffAndPow[j, 1] = new fmValue(ran.Next(1) == 0 ? 0 : j);
        //        }

        //        //double answer = ran.Next(5);
        //        fmValue answer = new fmValue(ran.Next(5));
        //        //coefs.Insert(0, new fmValue(0));
        //        freeCoeff = new fmValue(0);
        //        for (int j = 0; j < n; j++)
        //        {
        //            freeCoeff -= coeffAndPow[j, 0] * fmValue.Pow(answer, coeffAndPow[j, 1]);
        //        }

        //        List<fmValue> result = fmMathEquations.SolvePowerSumEquation(freeCoeff, coeffAndPow);
        //        Assert.Greater(result.Count, 0, "Unexpected SolvePowerSumEquation result. (count = 0)");
        //        bool isContainsAnswer = false;
        //        foreach (fmValue val in result)
        //        {
        //            fmValue res = -freeCoeff;
        //            for (int j = 0; j < n; j++)
        //            {
        //                //res += coefs[j + 1] * Math.Pow(val.Value, pow[j].Value);
        //                res += coeffAndPow[j, 0] * fmValue.Pow(val, coeffAndPow[j, 1]);
        //            }
        //            if (Math.Abs(res.Value - answer.Value) < eps) isContainsAnswer = true;
        //            Assert.LessOrEqual(Math.Abs(res.Value), eps, "Wrong SolvePowerSumEquation result for polynom degree {3}", n);
        //        }
        //        Assert.IsTrue(isContainsAnswer, "Wrong SolvePowerSumEquation result:  result does not contain expected  answer {1}", answer);
        //    }
        //}

    }
}
