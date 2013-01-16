using System;
using System.Collections.Generic;
using fmCalculationLibrary;
using fmCalcBlocksLibrary.BlockParameter;

namespace fmCalcBlocksLibrary.Blocks.LimitsCalcs
{
    public class fmLimitsBlockCalcs
    {
        public enum fmResultCheckStatus
        {
            N_A,
            NEGATIVE,
            LESS_THAN_MINIMUM,
            GREATER_THAN_MAXIMUM,
            INSIDE_RANGE
        }

        private enum fmResultBehaviorStatus
        {
            INCREASING,
            DECREASING,
            CONST,
            N_A
        }

        public static bool IsGoodResultStatus(Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus)
        {
            bool goodPoint = true;
            foreach (fmResultCheckStatus status in resultSatus.Values)
            {
                if (status != fmResultCheckStatus.INSIDE_RANGE)
                {
                    goodPoint = false;
                    break;
                }
            }
            return goodPoint;
        }

        static private Dictionary<fmGlobalParameter, fmResultCheckStatus> GetResultStatus(fmBlockVariableParameter parameter, double valueToCheck, fmBaseBlock block)
        {
            Dictionary<fmGlobalParameter, fmValue> resultValues = GetResultsWithSpecialParameterValue(parameter, valueToCheck, block);
            return GetResultStatus(resultValues);
        }

        public static Dictionary<fmGlobalParameter, fmResultCheckStatus> GetResultStatus(Dictionary<fmGlobalParameter, fmValue> resultValues)
        {
            var result = new Dictionary<fmGlobalParameter, fmResultCheckStatus>();

            foreach (fmGlobalParameter p in resultValues.Keys)
            {
                fmValue curValue = resultValues[p];
                if (curValue.defined == false)
                {
                    result[p] = fmResultCheckStatus.N_A;
                }
                else
                {
                    if (curValue.value < 0)
                    {
                        result[p] = fmResultCheckStatus.NEGATIVE;
                    }
                    else if (curValue.value > p.ValidRange.MaxValue)
                    {
                        result[p] = fmResultCheckStatus.GREATER_THAN_MAXIMUM;
                    }
                    else if (curValue.value < p.ValidRange.MinValue)
                    {
                        result[p] = fmResultCheckStatus.LESS_THAN_MINIMUM;
                    }
                    else
                    {
                        result[p] = fmResultCheckStatus.INSIDE_RANGE;
                    }
                }
            }

            return result;
        }

        static private Dictionary<fmGlobalParameter, fmResultBehaviorStatus> GetResultBehavior(fmBlockVariableParameter parameter, double x1, double x2, fmBaseBlock block)
        {
            Dictionary<fmGlobalParameter, fmValue> result1 = GetResultsWithSpecialParameterValue(parameter, x1, block);
            Dictionary<fmGlobalParameter, fmValue> result2 = GetResultsWithSpecialParameterValue(parameter, x2, block);
            var result = new Dictionary<fmGlobalParameter, fmResultBehaviorStatus>();
            foreach (fmGlobalParameter p in result1.Keys)
            {
                fmValue val1 = result1[p];
                fmValue val2 = result2[p];
                if (val1.defined == false || val2.defined == false)
                {
                    result[p] = fmResultBehaviorStatus.N_A;
                }
                else
                {
                    if (val1 == val2)
                    {
                        result[p] = fmResultBehaviorStatus.CONST;
                    }
                    else
                    {
                        result[p] = val1 > val2 ? fmResultBehaviorStatus.DECREASING : fmResultBehaviorStatus.INCREASING;
                    }
                }
            }
            return result;
        }

        static public fmBlockVariableParameter FindGroupRepresetator(List<fmBlockVariableParameter> parameters, fmBlockParameterGroup group)
        {
            foreach (fmBlockVariableParameter p in parameters)
            {
                if (p.group == group && p.IsInputed)
                {
                    return p;
                }
            }
            return null;
        }

        static private Dictionary<fmGlobalParameter, fmValue> GetResultsWithSpecialParameterValue(fmBlockVariableParameter parameter, double paramValue, fmBaseBlock block)
        {
            var result = new Dictionary<fmGlobalParameter, fmValue>();
            var parameters = block.Parameters;

            var keepedValues = new List<fmValue>();
            for (int i = 0; i < parameters.Count; ++i)
            {
                keepedValues.Add(parameters[i].value);
            }

            fmBlockVariableParameter groupInput = FindGroupRepresetator(parameters, parameter.group);
            fmValue groupInputInitialValue = groupInput.value;
            groupInput.IsInputed = false;
            parameter.IsInputed = true;

            parameter.value = new fmValue(paramValue);

            block.DoCalculations();

            var clueList = block.GetClueParamsList();
            foreach (fmBlockVariableParameter p in clueList)
            {
                result[p.globalParameter] = block.GetParameterByName(p.globalParameter.Name).value;
            }

            parameter.IsInputed = false;
            groupInput.value = groupInputInitialValue;
            groupInput.IsInputed = true;

            for (int i = 0; i < block.Parameters.Count; ++i)
            {
                parameters[i].value = keepedValues[i];
            }

            return result;
        }

        static private bool GetRangeWithMeaningfulResult(fmBlockVariableParameter parameter, fmValue left, fmValue right, out fmValue minValue, out fmValue maxValue, fmBaseBlock block)
        {
            fmValue point = FindPointWithMeaningfulResult(parameter, left, right, block);
            if (point.defined == false)
            {
                minValue = new fmValue();
                maxValue = new fmValue();
                return false;
            }

            var isOutOfRanges = new fmIsOutOfRanges(block, parameter);
            if (isOutOfRanges.Eval(left) == fmIsOutOfRanges.FalseValue)
            {
                minValue = left;
            }
            else
            {
                fmValue temp;
                fmCalculationLibrary.NumericalMethods.fmBisectionMethod.
                    FindRootRange(isOutOfRanges, left, point, 40, out temp, out minValue);
            }

            if (isOutOfRanges.Eval(right) == fmIsOutOfRanges.FalseValue)
            {
                maxValue = right;
            }
            else
            {
                fmValue temp;
                fmCalculationLibrary.NumericalMethods.fmBisectionMethod.
                    FindRootRange(isOutOfRanges, point, right, 40, out maxValue, out temp);
            }

            return true;
        }

        static public bool GetMinMaxLimits(
            fmBlockVariableParameter parameter, 
            out fmValue minValue, 
            out fmValue maxValue, 
            fmBaseBlock block)
        {
            if (FindGroupRepresetator(block.Parameters, parameter.group) == null)
            {
                minValue = new fmValue();
                maxValue = new fmValue();
                return false;
            }

            fmValue left, right;
            if (GetRangeWithDefinedResult(parameter, out left, out right, block) == false)
            {
                minValue = new fmValue();
                maxValue = new fmValue();
                return false;
            }

            if (GetRangeWithMeaningfulResult(parameter, left, right, out minValue, out maxValue, block) == false)
            {
                minValue = new fmValue();
                maxValue = new fmValue();
                return false;
            }

            return true;
        }

        private class fmIsAllDefinedAndNotNegative : fmCalculationLibrary.NumericalMethods.fmFunction
        {
            static public fmValue FalseValue = new fmValue(-1);
            static public fmValue TrueValue = new fmValue(1);

            private readonly fmBaseBlock m_block;
            private readonly fmBlockVariableParameter m_xParameter;
            public fmIsAllDefinedAndNotNegative(fmBaseBlock block, fmBlockVariableParameter xParameter)
            {
                m_block = block;
                m_xParameter = xParameter;
            }

            public override fmValue Eval(fmValue x)
            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultStatus = GetResultStatus(m_xParameter, x.value, m_block);
                foreach (fmResultCheckStatus status in resultStatus.Values)
                {
                    if (status == fmResultCheckStatus.N_A || status == fmResultCheckStatus.NEGATIVE)
                    {
                        return FalseValue;
                    }
                }
                return TrueValue;
            }
        }

        private class fmIsOutOfRanges : fmCalculationLibrary.NumericalMethods.fmFunction
        {
            static public fmValue FalseValue = new fmValue(-1);
            static public fmValue TrueValue = new fmValue(1);

            private readonly fmBaseBlock m_block;
            private readonly fmBlockVariableParameter m_xParameter;
            public fmIsOutOfRanges(fmBaseBlock block, fmBlockVariableParameter xParameter)
            {
                m_block = block;
                m_xParameter = xParameter;
            }

            public override fmValue Eval(fmValue x)
            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultStatus = fmLimitsBlockCalcs.GetResultStatus(m_xParameter, x.value, m_block);
                foreach (fmResultCheckStatus status in resultStatus.Values)
                {
                    if (status != fmResultCheckStatus.INSIDE_RANGE)
                    {
                        return TrueValue;
                    }
                }
                return FalseValue;
            }
        }

        static private fmValue FindPointWithMeaningfulResult(fmBlockVariableParameter parameter, fmValue left, fmValue right, fmBaseBlock block)
        {

            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus1 = GetResultStatus(parameter, left.value, block);
                if (IsGoodResultStatus(resultSatus1))
                {
                    return left;
                }

                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus2 = GetResultStatus(parameter, right.value, block);
                if (IsGoodResultStatus(resultSatus2))
                {
                    return right;
                }
            }

            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus1 = GetResultStatus(parameter, left.value, block);
                bool ok = true;
                foreach (fmResultCheckStatus status in resultSatus1.Values)
                    if (status == fmResultCheckStatus.N_A)
                        ok = false;

                if (!ok)
                {
                    left += 1e-9 * (right - left);
                    resultSatus1 = GetResultStatus(parameter, left.value, block);
                    foreach (fmResultCheckStatus status in resultSatus1.Values)
                        if (status == fmResultCheckStatus.N_A)
                            return new fmValue();
                }


                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus2 = GetResultStatus(parameter, right.value, block);
                ok = true;
                foreach (fmResultCheckStatus status in resultSatus2.Values)
                    if (status == fmResultCheckStatus.N_A)
                        ok = false;

                if (!ok)
                {
                    right -= 1e-9 * (right - left);
                    resultSatus2 = GetResultStatus(parameter, right.value, block);
                    foreach (fmResultCheckStatus status in resultSatus2.Values)
                        if (status == fmResultCheckStatus.N_A)
                            return new fmValue();
                }
            }

            for (int it = 0; it < 30; ++it)
            {
                if (right - left <= right * 1e-9)
                {
                    break;
                }
                fmValue mid = 0.5 * (left + right);
                fmValue eps = (right - left) * 1e-8;
                fmValue mid1 = mid - eps;
                fmValue mid2 = mid + eps;

                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus1 = GetResultStatus(parameter, mid1.value, block);
                foreach (fmResultCheckStatus status in resultSatus1.Values)
                {
                    if (status == fmResultCheckStatus.N_A)
                    {
                        fmMisc.fmErrorLog.AddError("resultSatus1 contains n/a in FindPointWithMeaningfulResult");
                        return new fmValue();
                    }
                }

                if (IsGoodResultStatus(resultSatus1))
                {
                    return mid1;
                }

                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus2 = GetResultStatus(parameter, mid2.value, block);
                foreach (fmResultCheckStatus status in resultSatus2.Values)
                {
                    if (status == fmResultCheckStatus.N_A)
                    {
                        fmMisc.fmErrorLog.AddError("resultSatus2 contains n/a in FindPointWithMeaningfulResult");
                        return new fmValue();
                    }
                }

                Dictionary<fmGlobalParameter, fmResultBehaviorStatus> resultBehavior = GetResultBehavior(parameter, mid1.value, mid2.value, block);

                bool needToGoLeft = false;
                bool needToGoRight = false;
                foreach (fmGlobalParameter p in resultSatus1.Keys)
                {
                    fmResultCheckStatus curStatus = resultSatus1[p] == fmResultCheckStatus.INSIDE_RANGE ? resultSatus2[p] : resultSatus1[p];
                    fmResultBehaviorStatus curBehavior = resultBehavior[p];
                    if (curStatus == fmResultCheckStatus.LESS_THAN_MINIMUM && curBehavior == fmResultBehaviorStatus.INCREASING
                        || curStatus == fmResultCheckStatus.GREATER_THAN_MAXIMUM && curBehavior == fmResultBehaviorStatus.DECREASING)
                    {
                        needToGoRight = true;
                    }

                    if (curStatus == fmResultCheckStatus.LESS_THAN_MINIMUM && curBehavior == fmResultBehaviorStatus.DECREASING
                        || curStatus == fmResultCheckStatus.GREATER_THAN_MAXIMUM && curBehavior == fmResultBehaviorStatus.INCREASING)
                    {
                        needToGoLeft = true;
                    }
                }

                if (needToGoRight && needToGoLeft == false)
                {
                    left = mid1;
                }
                else if (needToGoRight == false && needToGoLeft)
                {
                    right = mid2;
                }
                else
                {
                    return new fmValue();
                }
            }

            return new fmValue();
        }

        static private bool GetRangeWithDefinedResult(fmBlockVariableParameter parameter, out fmValue left, out fmValue right, fmBaseBlock block)
        {
            // We use a fact that all results with min value of parameter are defined, otherwise we assume that there are no solution

            var isAllDefinedAndNotNegative = new fmIsAllDefinedAndNotNegative(block, parameter);
            var minValue = new fmValue(parameter.globalParameter.ValidRange.MinValue);
            var maxValue = new fmValue(parameter.globalParameter.ValidRange.MaxValue);

            if (isAllDefinedAndNotNegative.Eval(minValue) != fmIsAllDefinedAndNotNegative.TrueValue)
            {
                const double eps = 1e-9;
                if (minValue.value == 0)
                {
                    minValue.value += maxValue.value * eps;
                }
                else
                {
                    minValue.value *= 1 + eps;
                }
            }

            if (isAllDefinedAndNotNegative.Eval(minValue) == fmIsAllDefinedAndNotNegative.TrueValue)
            {
                left = minValue;

                if (isAllDefinedAndNotNegative.Eval(maxValue) == fmIsAllDefinedAndNotNegative.TrueValue)
                {
                    right = maxValue;
                }
                else
                {
                    fmValue temp;
                    fmCalculationLibrary.NumericalMethods.fmBisectionMethod.
                        FindRootRange(isAllDefinedAndNotNegative, left, maxValue, 30, out right, out temp);
                }

                return true;
            }

            if (isAllDefinedAndNotNegative.Eval(maxValue) == fmIsAllDefinedAndNotNegative.TrueValue)
            {
                right = maxValue;
                fmValue temp;
                fmCalculationLibrary.NumericalMethods.fmBisectionMethod.
                    FindRootRange(isAllDefinedAndNotNegative, minValue, right, 30, out temp, out left);

                return true;
            }

            left = new fmValue();
            right = new fmValue();
            return false;
        }
    }
}
