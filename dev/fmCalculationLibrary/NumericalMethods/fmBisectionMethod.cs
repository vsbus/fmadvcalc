using System;

namespace fmCalculationLibrary.NumericalMethods
{
    public class fmBisectionMethod
    {
        public static bool FindRootRange(fmFunction function, fmValue beginArg, fmValue endArg, int iterationsCount, out fmValue beginRes, out fmValue endRes)
        {
            beginRes = new fmValue();
            endRes = new fmValue();

            if (beginArg.Defined == false || endArg.Defined == false)
            {
                return false;
            }
            
            fmValue eps = new fmValue(1e-6);
            fmValue len = fmValue.Abs(endArg - beginArg);
            if (len < new fmValue(1))
            {
                eps = eps * len;
            }
            fmValue beginValue = function.Eval(beginArg + eps);
            fmValue endValue = function.Eval(endArg - eps);
            if (beginValue.Defined == false || endValue.Defined == false)
            {
                return false;
            }
            if (beginValue == endValue)
            {
                if (beginValue.Value == 0)
                {
                    beginRes = beginArg;
                    endRes = endArg;
                    return true;
                }
                else
                    return false;
            }
            
            fmValue beginSign = fmValue.Sign(beginValue, eps);
            fmValue endSign = fmValue.Sign(endValue, eps);
            if ((beginSign * endSign).Value > 0)
                return false;

            fmValue left = beginArg;
            fmValue right = endArg;
            for (int i = 0; i < iterationsCount; ++i)
            {
                fmValue middle = 0.5 * (left + right);
                fmValue value = function.Eval(middle);

                if (!value.Defined)
                    throw new Exception("Function given to NewtonMethod not defind in point " + middle.Value);

                fmValue midSign = fmValue.Sign(value, eps);
                if (midSign.Value == 0 || midSign == endSign)
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