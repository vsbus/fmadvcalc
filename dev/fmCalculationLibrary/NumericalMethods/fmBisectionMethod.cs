using System;

namespace fmCalculationLibrary.NumericalMethods
{
    public class fmBisectionMethod
    {
        public static bool FindRootRange(fmFunction function, fmValue beginArg, fmValue endArg, int iterationsCount, out fmValue beginRes, out fmValue endRes)
        {
            beginRes = new fmValue();
            endRes = new fmValue();

            if (beginArg.defined == false || endArg.defined == false)
            {
                return false;
            }
            
            fmValue len = endArg - beginArg;
            fmValue eps = new fmValue(1e-8);
            if (len.value < 0)
            {
                eps = -eps;
            }
            if (fmValue.Abs(len) < new fmValue(1))
            {
                eps = eps * fmValue.Abs(len);
            }

            fmValue beginValue = function.Eval(beginArg + eps);
            fmValue endValue = function.Eval(endArg - eps);
            if (beginValue.defined == false || endValue.defined == false)
            {
                return false;
            }
            if (beginValue == endValue)
            {
                if (beginValue.value == 0)
                {
                    beginRes = beginArg;
                    endRes = endArg;
                    return true;
                }
                else
                {
                    if (function.Eval(endArg).value == 0)
                    {
                        beginRes = endRes = endArg;
                        return true;
                    }

                    return false;
                }
            }
            
            fmValue beginSign = fmValue.Sign(beginValue, eps);
            fmValue endSign = fmValue.Sign(endValue, eps);
            if ((beginSign * endSign).value > 0)
                return false;

            fmValue left = beginArg;
            fmValue right = endArg;
            for (int i = 0; i < iterationsCount; ++i)
            {
                fmValue middle = 0.5 * (left + right);
                fmValue value = function.Eval(middle);

                if (!value.defined)
                    throw new Exception("Function given to NewtonMethod not defind in point " + middle.value);

                fmValue midSign = fmValue.Sign(value, eps);
                if (midSign.value == 0 || midSign == endSign)
                    right = middle;
                else
                    left = middle;
            }

            beginRes = left;
            endRes = right;
            return true;
        }

        public static fmValue FindRoot(fmFunction function, fmValue beginArg, fmValue endArg, int iterationsCount)
        {
            fmValue beginRes;
            fmValue endRes;
            if (FindRootRange(function, beginArg, endArg, iterationsCount, out beginRes, out endRes) == true)
            {
                return 0.5 * (beginRes + endRes);
            }
            else
            {
                return new fmValue();
            }
        }
    }
}