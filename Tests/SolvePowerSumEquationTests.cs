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

        [Test]
        public void SolvePowerSumEquationTest()
        {
            const int MAXCOEF = 20;
            double eps =  Math.Exp(-10);
            Random ran = new Random();
            for (int n =1 ; n < 5; n++)
            {
                List<fmValue> coefs = new List<fmValue>(n+1);
                List<fmValue> pow = new List<fmValue>(n);
                for (int j = 1; j< n+1; j++)
                {
                    coefs.Add(new fmValue(ran.Next(MAXCOEF)-MAXCOEF/2));
                }
                for (int j = 0; j< n; j++)
                {
                    pow.Add(new fmValue(ran.Next(1) == 0 ? 0: j));
                }

                double answer = ran.Next(5);
                coefs.Insert(0, new fmValue(0));
                for (int j = 0; j < n; j++)
                {
                    coefs[0] -= coefs[j + 1]*Math.Pow(answer, pow[j].Value);
                }

                List<fmValue> result = fmMathEquations.SolvePowerSumEquation(coefs, pow);
                Assert.Greater(result.Count, 0, "Unexpected SolvePowerSumEquation result. (count = 0)");
                bool isContainsAnswer = false;
                foreach(fmValue val in result)
                {
                    fmValue res = -coefs[0];
                    for (int j = 0; j < n; j++)
                    {
                        res += coefs[j + 1]*Math.Pow(val.Value, pow[j].Value);
                    }
                    if (Math.Abs(res.Value - answer) < eps) isContainsAnswer = true;
                    Assert.LessOrEqual(Math.Abs(res.Value), eps, "Wrong SolvePowerSumEquation result for polynom degree {3}", n);
                }
                Assert.IsTrue(isContainsAnswer, "Wrong SolvePowerSumEquation result:  result does not contain expected  answer {1}", answer);
            }
        }

    }
}
