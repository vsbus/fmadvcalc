using System;

namespace fmCalculationLibrary.NumericalMethods
{
    public class fmNewtonMethod
    {
        private static bool IsIncreasing(fmFunction function, fmValue beginValue, fmValue endValue)
        {
            fmValue eps = new fmValue(0.1);
            fmValue val1 = function.Eval(beginValue + (endValue - beginValue) * eps);
            fmValue val2 = function.Eval(beginValue + (endValue - beginValue) * (1 - eps));

            if (!val1.Defined || !val2.Defined)
            {
                return false;
            }

            return val1 < val2;
        }

        private static bool IsDecreasing(fmFunction function, fmValue beginValue, fmValue endValue)
        {
            fmValue eps = new fmValue(0.1);
            fmValue val1 = function.Eval(beginValue + (endValue - beginValue) * eps);
            fmValue val2 = function.Eval(beginValue + (endValue - beginValue) * (1 - eps));

            if (!val1.Defined || !val2.Defined)
            {
                return false;
            }

            return val1 > val2;
        }

        public static fmValue FindRoot(fmFunction function, fmValue beginValue, fmValue endValue, int iterationsCount)
        {
            bool isIncreasing = IsIncreasing(function, beginValue, endValue);
            bool isDecreasing = IsDecreasing(function, beginValue, endValue);

            if (!isIncreasing && !isDecreasing)
            {
                throw new Exception("Function given to Newton method is not increasing and not decreasing.");
            }

            fmValue left = beginValue;
            fmValue right = endValue;
            for (int i = 0; i < iterationsCount; ++i)
            {
                fmValue middle = 0.5 * (left + right);
                fmValue value = function.Eval(middle);

                if (!value.Defined)
                {
                    throw new Exception("Function given to NewtonMethod not defind in point " + middle.Value);
                }

                if (isIncreasing && value.Value > 0
                    || isDecreasing && value.Value < 0)
                {
                    right = middle;
                }
                else
                {
                    left = middle;
                }
            }

            fmValue res = 0.5 * (left + right);
            fmValue eps = new fmValue(1e-8);

            if (fmValue.Abs(function.Eval(res)) > eps)
                return new fmValue();

            return res;
        }
    }
}