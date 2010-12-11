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
            var eps = new fmValue(1e-8);
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
                if (function.Eval(endArg).value == 0)
                {
                    beginRes = endRes = endArg;
                    return true;
                }

                return false;
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
                    throw new Exception("Function given to BisectionMethod not defind in point " + middle.value);

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
            if (FindRootRange(function, beginArg, endArg, iterationsCount, out beginRes, out endRes))
            {
                return 0.5 * (beginRes + endRes);
            }
            return new fmValue();
        }
        public static fmValue FindBreakInUnimodalFunction(fmFunction function, fmValue beginArg, fmValue endArg, int iterationsCount)
        {
            if (beginArg.defined == false || endArg.defined == false)
                return new fmValue();
            
            fmValue len = endArg - beginArg;
            var eps = new fmValue(1e-8);
            if (len.value < 0)
            {
                eps = -eps;
            }

            fmValue beginValue = function.Eval(beginArg);
            fmValue endValue = function.Eval(endArg);
            if (fmValue.Sign(beginValue, eps) * fmValue.Sign(endValue, eps) == new fmValue(-1))
                throw new Exception("Search limits represent different signs of values already");            

            beginValue = function.Eval(beginArg + eps);
            endValue = function.Eval(endArg - eps);
            if (fmValue.Sign(beginValue, eps) * fmValue.Sign(endValue, eps) == new fmValue(-1))
                throw new Exception("Search limits represent different signs of values already");            

            if (beginValue.defined == false || endValue.defined == false)
                return new fmValue();

            fmValue initialSign = fmValue.Sign(beginValue, eps);
            fmValue left = beginArg;
            fmValue right = endArg;
            for (int i = 0; i < iterationsCount; ++i)
            {
                fmValue middle = 0.5 * (left + right);
                fmValue mid1 = middle - eps * (right - left);
                fmValue mid2 = middle + eps * (right - left);
                fmValue val1 = function.Eval(mid1);
                fmValue val2 = function.Eval(mid2);

                if (!val1.defined)
                    throw new Exception("Function given to FindBreakInUnimodalFunction not defind in point " + mid1.value);
                if (!val2.defined)
                    throw new Exception("Function given to FindBreakInUnimodalFunction not defind in point " + mid2.value);

                if (fmValue.Sign(val1, eps) != initialSign)
                    return mid1;

                if (fmValue.Sign(val2, eps) != initialSign)
                    return mid2;


                if (fmValue.Sign(val1 - val2, eps) == initialSign)
                    left = middle;
                else
                    right = middle;
            }

            return new fmValue();
        }
    }
}