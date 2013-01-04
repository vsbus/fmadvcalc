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

            fmValue beginValue = function.Eval(beginArg);
            if (!beginValue.defined)
            {
                beginValue = function.Eval(beginArg + eps);
            }
            fmValue endValue = function.Eval(endArg);
            if (!endValue.defined)
            {
                endValue = function.Eval(endArg - eps);
            }
            if (beginValue.defined == false || endValue.defined == false)
            {
                return false;
            }
            if (beginValue == endValue)
            {
                if (beginValue.value == 0)
                {
                    if (function.Eval(beginArg).value == 0)
                    {
                        beginRes = endRes = endArg;
                        return true;
                    }
                    beginRes = beginArg + eps;
                    endRes = beginArg + eps;
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
                if (middle == left || middle == right)
                {
                    break;
                }
                fmValue value = function.Eval(middle);

                if (!value.defined)
                    return false;

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
                fmValue mid = 0.5*(beginRes + endRes);
                if (mid == beginRes)
                {
                    mid = endRes;
                }
                return mid;
            }
            return new fmValue();
        }
        public static bool FindBreakInUnimodalFunction(
            fmFunction function, 
            fmValue beginArg, 
            fmValue endArg, 
            int iterationsCount, 
            out fmValue beginRes, 
            out fmValue endRes)
        {
            if (beginArg.defined == false || endArg.defined == false)
            {
                beginRes = new fmValue();
                endRes = new fmValue();
                return false;
            }

            var eps = new fmValue(1e-8);
            fmValue len = endArg - beginArg;
            if (len.value < 0)
            {
                throw new Exception("FindBreakInUnimodalFunction got degenerate interval as input.");
            }

            fmValue beginValue = function.Eval(beginArg);
            fmValue endValue = function.Eval(endArg);
            if (fmValue.Sign(beginValue) * fmValue.Sign(endValue) == new fmValue(-1))
                throw new Exception("Search limits represent different signs of values already");            

            beginValue = function.Eval(beginArg + eps);
            endValue = function.Eval(endArg - eps);
            if (fmValue.Sign(beginValue) * fmValue.Sign(endValue) == new fmValue(-1))
                throw new Exception("Search limits represent different signs of values already");            

            if (beginValue.defined == false || endValue.defined == false)
            {
                beginRes = new fmValue();
                endRes = new fmValue();
                return false;
            }

            fmValue initialSign = fmValue.Sign(beginValue);
            fmValue left = beginArg;
            fmValue right = endArg;
            for (int i = 0; i < iterationsCount; ++i)
            {
                fmValue middle = 0.5 * (left + right);
                if (middle == left || middle == right)
                {
                    break;
                }
                fmValue mid1 = middle - eps * (right - left);
                fmValue mid2 = middle + eps * (right - left);
                fmValue val1 = function.Eval(mid1);
                fmValue val2 = function.Eval(mid2);

                if (!val1.defined || !val2.defined)
                {
                    beginRes = new fmValue();
                    endRes = new fmValue();
                    return false;
                }

                if (fmValue.Sign(val1) != initialSign)
                {
                    beginRes = mid1;
                    endRes = mid1;
                    return true;
                }

                if (fmValue.Sign(val2) != initialSign)
                {
                    beginRes = mid2;
                    endRes = mid2;
                    return true;
                }


                if (fmValue.Sign(val1 - val2) == initialSign)
                    left = middle;
                else
                    right = middle;
            }

            beginRes = left;
            endRes = right;
            return false;
        }
    }
}