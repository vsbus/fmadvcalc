using System;
using System.Collections.Generic;
using System.Text;

namespace fmCalculationLibrary.NumericalMethods
{
    public class fmTernaryMethod
    {
        public static bool FindMinimum(fmFunction function, fmValue beginArg, fmValue endArg, int iterationsCount, out fmValue beginRes, out fmValue endRes)
        {
            beginRes = new fmValue();
            endRes = new fmValue();

            if (beginArg.defined == false || endArg.defined == false)
            {
                return false;
            }

            fmValue len = endArg - beginArg;
            if (len <= new fmValue(0))
                throw new Exception("Wrong interval for ternary search");

            var eps = new fmValue(1e-8);
            
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
                    throw new Exception("Function given to TernaryMethod not defind in point " + mid1.value);
                if (!val2.defined)
                    throw new Exception("Function given to TernaryMethod not defind in point " + mid2.value);

                if (val1 > val2)
                    left = mid1;
                else
                    right = mid2;
            }

            beginRes = left;
            endRes = right;
            return true;
        }

        public static fmValue FindMinimum(fmFunction function, fmValue beginArg, fmValue endArg, int iterationsCount)
        {
            fmValue beginRes;
            fmValue endRes;
            if (FindMinimum(function, beginArg, endArg, iterationsCount, out beginRes, out endRes))
            {
                return 0.5 * (beginRes + endRes);
            }
            return new fmValue();
        }
    }
}
