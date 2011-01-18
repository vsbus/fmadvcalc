using System;
using System.Collections.Generic;
using System.Text;
using fmCalculationLibrary;
using fmCalcBlocksLibrary.BlockParameter;

namespace fmCalcBlocksLibrary.Blocks.LimitsCalcs
{
    public class fmLimitsBlockCalcs
    {
        private enum fmResultCheckStatus
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

        static private bool IsGoodResultStatus(Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus)
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
            Dictionary<fmGlobalParameter, fmValue> resultValues = GetClueResultsWithSpecialParameterValue(parameter, valueToCheck, block);
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
                    const double eps = 1e-9;
                    if (fmValue.EpsCompare(curValue.value, 0, eps) < 0)
                    {
                        result[p] = fmResultCheckStatus.NEGATIVE;
                    }
                    else if (fmValue.EpsCompare(curValue.value, p.validRange.MaxValue, eps) > 0)
                    {
                        result[p] = fmResultCheckStatus.GREATER_THAN_MAXIMUM;
                    }
                    else if (fmValue.EpsCompare(curValue.value, p.validRange.MinValue, eps) < 0)
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
            Dictionary<fmGlobalParameter, fmValue> result1 = GetClueResultsWithSpecialParameterValue(parameter, x1, block);
            Dictionary<fmGlobalParameter, fmValue> result2 = GetClueResultsWithSpecialParameterValue(parameter, x2, block);
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

        static private Dictionary<fmGlobalParameter, fmValue> GetClueResultsWithSpecialParameterValue(fmBlockVariableParameter parameter, double paramValue, fmBaseBlock block)
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

            block.DoCalculationsLimitsClue();

            result[fmGlobalParameter.A] = block.GetParameterByName(fmGlobalParameter.A.name).value;
            result[fmGlobalParameter.Dp] = block.GetParameterByName(fmGlobalParameter.Dp.name).value;
            result[fmGlobalParameter.sf] = block.GetParameterByName(fmGlobalParameter.sf.name).value;
            result[fmGlobalParameter.tc] = block.GetParameterByName(fmGlobalParameter.tc.name).value;

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
            var falseValue = new fmValue(0);
            if (isOutOfRanges.Eval(left) == falseValue)
            {
                minValue = left;
            }
            else
            {
                fmValue temp;
                fmCalculationLibrary.NumericalMethods.fmBisectionMethod.FindRootRange(isOutOfRanges, left, point, 40, out minValue, out temp);
            }

            if (isOutOfRanges.Eval(right) == falseValue)
            {
                maxValue = right;
            }
            else
            {
                fmValue temp;
                fmCalculationLibrary.NumericalMethods.fmBisectionMethod.FindRootRange(isOutOfRanges, right, point, 40, out maxValue, out temp);
            }

            return true;
        }

        static public bool GetMinMaxLimits(fmBlockVariableParameter parameter, out fmValue minValue, out fmValue maxValue, fmBaseBlock block)
        {
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

            var eps = new fmValue(1e-10);// *(maxValue - minValue);
            minValue = minValue * (1 - eps);
            maxValue = maxValue * (1 + eps);

            return true;
        }

        private class fmIsAllDefinedAndNotNegative : fmCalculationLibrary.NumericalMethods.fmFunction
        {
            private readonly fmBaseBlock m_block;
            private readonly fmBlockVariableParameter m_xParameter;
            public fmIsAllDefinedAndNotNegative(fmBaseBlock block, fmBlockVariableParameter xParameter)
            {
                m_block = block;
                m_xParameter = xParameter;
            }

            public override fmValue Eval(fmValue x)
            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultStatus = fmLimitsBlockCalcs.GetResultStatus(m_xParameter, x.value, m_block);
                var result = new fmValue(1);
                foreach (fmResultCheckStatus status in resultStatus.Values)
                    if (status == fmResultCheckStatus.N_A || status == fmResultCheckStatus.NEGATIVE)
                        result.value = 0;

                return result;
            }
        }

        private class fmIsOutOfRanges : fmCalculationLibrary.NumericalMethods.fmFunction
        {
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
                    if (status != fmResultCheckStatus.INSIDE_RANGE)
                        return new fmValue(1);

                return new fmValue(0);
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
                    if (status == fmResultCheckStatus.N_A)
                        throw new Exception("resultSatus1 contains n/a in FindPointWithMeaningfulResult");

                if (IsGoodResultStatus(resultSatus1))
                {
                    return mid1;
                }

                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus2 = GetResultStatus(parameter, mid2.value, block);
                foreach (fmResultCheckStatus status in resultSatus2.Values)
                    if (status == fmResultCheckStatus.N_A)
                        throw new Exception("resultSatus2 contains n/a in FindPointWithMeaningfulResult");

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
            var trueValue = new fmValue(1);
            var minValue = new fmValue(parameter.globalParameter.validRange.MinValue);
            var maxValue = new fmValue(parameter.globalParameter.validRange.MaxValue);

            if (isAllDefinedAndNotNegative.Eval(minValue) != trueValue)
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

            if (isAllDefinedAndNotNegative.Eval(minValue) == trueValue)
            {
                left = minValue;

                if (isAllDefinedAndNotNegative.Eval(maxValue) == trueValue)
                {
                    right = maxValue;
                }
                else
                {
                    fmValue temp;
                    fmCalculationLibrary.NumericalMethods.fmBisectionMethod.FindRootRange(isAllDefinedAndNotNegative, left, maxValue, 30, out temp, out right);
                }

                return true;
            }
            if (isAllDefinedAndNotNegative.Eval(maxValue) == trueValue)
            {
                right = maxValue;
                fmValue temp;
                fmCalculationLibrary.NumericalMethods.fmBisectionMethod.FindRootRange(isAllDefinedAndNotNegative, right, minValue, 30, out temp, out left);
                return true;
            }
            left = new fmValue();
            right = new fmValue();
            return false;
        }
    }
}
