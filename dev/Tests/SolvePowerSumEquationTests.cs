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
        private static void AssertAreEqual (List<fmValue> expected, List<fmValue> actual, string prefix )
        {
            double eps = Math.Exp(-10);
        
            if (expected!= null)
            {
                Assert.IsNotNull(actual, prefix + ": actual list is null");
                
                Assert.AreEqual(expected.Count, actual.Count, prefix + ": different list's counts  (result{0})", ListToString(actual));

                for (int i = 0; i < expected.Count; ++i)
                {
                    Assert.LessOrEqual(Math.Abs(expected[i].value - actual[i].value), eps,
                                       prefix + ": unexpected value in result ({0})", ListToString(actual));
                    Assert.GreaterOrEqual(actual[i].value, 0, prefix+ ": negative value");
                }
            }
            else
            {
                   Assert.IsNull(actual, prefix + ": actual list is not null");
            }

        }

        private static string ListToString(List<fmValue> list)
        {
            string result = "{";
            for(int i =0; i < list.Count; i++ )
                result += " " + list[i].value.ToString() + ",";
            result += "}";
            return result;
        }

        public string GetEquation(fmValue freeCoeff, fmValue[,] coeffAndPow)
        {
            string result = freeCoeff.ToString();
            for (int  i = 0; i < coeffAndPow.Length/coeffAndPow.Rank; i++)
            {
                result += string.Format(" {0}*x^{1}",
                                        ((coeffAndPow[i, 0].value >= 0 ? "+" : "-") +
                                         fmValue.Abs(coeffAndPow[i, 0]).ToString()),
                                        fmValue.Abs(coeffAndPow[i, 1]).ToString());
            }
            result += " = 0";
            return result;
        }
        

        [Test]
        public void LinearEquationTest()
        {
            List<fmValue> result = fmMathEquations.SolvePowerSumEquation(new fmValue(-20),
                                                                         new fmValue[1,2]
                                                                             {{new fmValue(5), new fmValue(1)}});
            List<fmValue> expectedResult = new List<fmValue>(new fmValue[] {new fmValue(4)});

            AssertAreEqual(expectedResult, result, "LinearEquationTest -20 + 5*x=0");
        }

        [Test]
        public void SquareRootEquation()
        {
            List<fmValue> result = fmMathEquations.SolvePowerSumEquation(new fmValue(-16),
                                                                         new fmValue[1, 2] { { new fmValue(1), new fmValue(2) } });
            List<fmValue> expectedResult = new List<fmValue>(new fmValue[] {new fmValue(4) });

            AssertAreEqual(expectedResult, result, "SquareRootEquation -16+x^2 =0");
            
            // x^2*C1 +C2*x^4 =0;
            fmValue c1 = new fmValue(20);
            
            fmValue c2 = new fmValue(-5);
            result = fmMathEquations.SolvePowerSumEquation(new fmValue(0),
                                                           new fmValue[2,2] {{c1, new fmValue(2)}, {c2, new fmValue(4)}});
            expectedResult = new List<fmValue>(new fmValue[] {new fmValue(0), new fmValue(2) });
            AssertAreEqual(expectedResult, result, "SquareRootEquation x^2*C1 +C2*x^4 =0;");


        }
        
        [Test]
        public void NoSolutionTest()
        {   
            // 4 + x^2 =0;
            fmValue c1 = new fmValue(4);
            
            fmValue c2 = new fmValue(1);
            fmValue p2 = new fmValue(2);
            List<fmValue> result = fmMathEquations.SolvePowerSumEquation(c1,
                                                           new fmValue[1,2] {{c2, p2}});
            List<fmValue>  expectedResult = new List<fmValue>();
            AssertAreEqual(expectedResult, result, "NoSolutionTest 4 + x^2 =0;");


            // 4 + x =0;
             c1 = new fmValue(4);
            
            c2 = new fmValue(1);
            result = fmMathEquations.SolvePowerSumEquation(c1,
                                                           new fmValue[1,2] {{c2, new fmValue(1)}});
            expectedResult = new List<fmValue>();
            AssertAreEqual(expectedResult, result, "NoSolutionTest 4 + x = 0;");
        }

        [Test]
        public void SolvePowerSumEquationTest()
        {
            const int MAXCOEF = 20;
            const int MAXPOW = 3;
            double eps = Math.Exp(-10);
            Random ran = new Random();

            for (int iter = 0; iter < 100; ++iter)
            {
                for (int n = 1; n < 5; n++)
                {
                    fmValue freeCoeff;
                    fmValue[,] coeffAndPow = new fmValue[n,2];
                    for (int j = 0; j < n; j++)
                    {
                        coeffAndPow[j, 0] = new fmValue(ran.Next(MAXCOEF) - MAXCOEF/2);
                        coeffAndPow[j, 1] = new fmValue(ran.Next(MAXPOW) + 1);
                    }

                    fmValue answer = new fmValue(ran.Next(5));
                    freeCoeff = new fmValue(0);
                    for (int j = 0; j < n; j++)
                    {
                        freeCoeff -= coeffAndPow[j, 0]*fmValue.Pow(answer, coeffAndPow[j, 1]);
                    }

                    List<fmValue> result = fmMathEquations.SolvePowerSumEquation(freeCoeff, coeffAndPow);
                    Assert.Greater(result.Count, 0,
                                   "Unexpected SolvePowerSumEquation result count for equation :{0}; expected answer is {1}",
                                   GetEquation(freeCoeff, coeffAndPow), answer.value);
                    bool isContainsAnswer = false;
                    foreach (fmValue val in result)
                    {
                        fmValue res = freeCoeff;
                        for (int j = 0; j < n; j++)
                        {
                            res += coeffAndPow[j, 0]*fmValue.Pow(val, coeffAndPow[j, 1]);
                        }
                        Assert.GreaterOrEqual(val.value, 0, "negative answer returned");
                        if (Math.Abs(val.value - answer.value) < eps) isContainsAnswer = true;
                        Assert.LessOrEqual(Math.Abs(res.value), eps,
                                           "Wrong SolvePowerSumEquation result {2}  item {3} for polynom degree {0} for equation :{1}, expected answer {4}",
                                           n, GetEquation(freeCoeff, coeffAndPow), ListToString(result),
                                           val.value.ToString(), answer.value.ToString());
                    }
                    Assert.IsTrue(isContainsAnswer,
                                  "Wrong SolvePowerSumEquation result:  result {2} does not contain expected  answer {0} for equation :{1}",
                                  answer, GetEquation(freeCoeff, coeffAndPow), ListToString(result));
                }
            }
        }

        // 0 +0*x^3 +8*x^1 -9*x^1 = 0; expected answer is 0
        [Test]
        public void Test1()
        {
            fmValue c1= new fmValue(0);
            fmValue c2= new fmValue(8);
            fmValue c3= new fmValue(-9);

            List<fmValue> result = fmMathEquations.SolvePowerSumEquation(new fmValue(0),
                                                                         new fmValue[3, 2] { { c1, new fmValue(3) }, { c2, new fmValue(1) }, { c3, new fmValue(1) } });
            List<fmValue> expectedResult = new List<fmValue>(new fmValue[] {new fmValue(0) });

            AssertAreEqual(expectedResult, result, "Test1 0 +0*x^3 +8*x^1 -9*x^1 = 0; expected answer is 0");
        }
        
        [Test]
        public void Test2()
        {
            // 58 +2*x^1 -6*x^3 -7*x^1 = 0; expected answer is 2
            fmValue c1= new fmValue(2);
            fmValue p1 = new fmValue(1);
            
            fmValue c2= new fmValue(-6);
            fmValue p2 = new fmValue(3);

            fmValue c3= new fmValue(-7);
            fmValue p3 = new fmValue(1);

            List<fmValue> result = fmMathEquations.SolvePowerSumEquation(new fmValue(58),
                                                                         new fmValue[3, 2] { { c1, p1}, {c2, p2}, {c3, p3} });
            List<fmValue> expectedResult = new List<fmValue>(new fmValue[] {new fmValue(2) });

            AssertAreEqual(expectedResult, result, "govno");
        }
        
        [Test]
        public void Test3()
        {
            //63 +2*x^2 -3*x^3 = 0 expected answer is 3
            fmValue c1= new fmValue(2);
            fmValue p1 = new fmValue(2);
            
            fmValue c2= new fmValue(-3);
            fmValue p2 = new fmValue(3);

            List<fmValue> result = fmMathEquations.SolvePowerSumEquation(new fmValue(63),
                                                                         new fmValue[2, 2] { { c1, p1}, {c2, p2}});
            List<fmValue> expectedResult = new List<fmValue>(new fmValue[] {new fmValue(3) });

            AssertAreEqual(expectedResult, result, "Test1 63 +2*x^2 -3*x^3 = 0; expected answer is 3");
        }
       //(count = 0) for equation : 58 +2*x^1 -6*x^3 -7*x^1 = 0; expected answer is 2
       
       // { 0, 3.99999999999876,}  item 0 for polynom  :560 +1*x^2 -9*x^3 = 0  expected value : 4



        [Test]
        public void Test4()
        {
            fmValue c1 = new fmValue(1);
            fmValue p1 = new fmValue(1);

            List<fmValue> result = fmMathEquations.SolvePowerSumEquation(new fmValue(0),
                                                                         new fmValue[1,2] {{c1, p1}});
            List<fmValue> expectedResult = new List<fmValue>(new fmValue[] { new fmValue(0) });

            AssertAreEqual(expectedResult, result, "Test4 x = 0; expected answer is 0");
        }

        [Test]
        public void Test5()
        {
            fmValue c1 = new fmValue(1);
            fmValue p1 = new fmValue(-1);

            List<fmValue> result = fmMathEquations.SolvePowerSumEquation(new fmValue(0),
                                                                         new fmValue[1, 2] { { c1, p1 } });
            List<fmValue> expectedResult = new List<fmValue>();

            AssertAreEqual(expectedResult, result, "Test4 1/x = 0; expected answer is empty solution");
        }

        [Test]
        public void Test6()
        {
            fmValue c1 = new fmValue(0);
            fmValue p1 = new fmValue(1);

            List<fmValue> result = fmMathEquations.SolvePowerSumEquation(new fmValue(0),
                                                                         new fmValue[1, 2] { { c1, p1 } });
            List<fmValue> expectedResult = new List<fmValue>();

            AssertAreEqual(expectedResult, result, "Test4 0 * x = 0; expected answer is empty solution");
        }

    }
}
