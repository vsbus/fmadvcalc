using System;
using System.ComponentModel;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Controls;
using fmCalculationLibrary;
using System.Collections.Generic;
using System.Drawing;
using fmCalculatorsLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmFilterMachiningBlockWithLimits : fmFilterMachiningBlock
    {
        public void DoCalculationsLimitsClue()
        {
            fmFilterMachiningCalculator filterMachinigCalculator =
                new fmFilterMachiningCalculator(AllParameters);
            filterMachinigCalculator.calculationOption = calculationOption;
            filterMachinigCalculator.DoCalculationsLimitsClue();
        }

        override public void DoCalculations()
        {
            base.DoCalculations();
        }

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

        private class fmIsAllDefined : fmCalculationLibrary.NumericalMethods.fmFunction
        {
            private fmFilterMachiningBlockWithLimits m_block;
            private fmBlockVariableParameter m_xParameter;
            public fmIsAllDefined(fmFilterMachiningBlockWithLimits block, fmBlockVariableParameter xParameter) 
            {
                m_block = block;
                m_xParameter = xParameter;
            }

            public override fmValue Eval(fmValue x)
            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultStatus = m_block.GetResultStatus(m_xParameter, x.Value);
                fmValue result = new fmValue(1);
                foreach (fmResultCheckStatus status in resultStatus.Values)
                    if (status == fmResultCheckStatus.N_A)
                        result.Value = 0;

                return result;
            }
        }

        private class fmIsAllDefinedAndNotNegative : fmCalculationLibrary.NumericalMethods.fmFunction
        {
            private fmFilterMachiningBlockWithLimits m_block;
            private fmBlockVariableParameter m_xParameter;
            public fmIsAllDefinedAndNotNegative(fmFilterMachiningBlockWithLimits block, fmBlockVariableParameter xParameter)
            {
                m_block = block;
                m_xParameter = xParameter;
            }

            public override fmValue Eval(fmValue x)
            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultStatus = m_block.GetResultStatus(m_xParameter, x.Value);
                fmValue result = new fmValue(1);
                foreach (fmResultCheckStatus status in resultStatus.Values)
                    if (status == fmResultCheckStatus.N_A || status == fmResultCheckStatus.NEGATIVE)
                        result.Value = 0;

                return result;
            }
        }

        
        private class fmIsOutOfRanges : fmCalculationLibrary.NumericalMethods.fmFunction
        {
            private fmFilterMachiningBlockWithLimits m_block;
            private fmBlockVariableParameter m_xParameter;
            public fmIsOutOfRanges(fmFilterMachiningBlockWithLimits block, fmBlockVariableParameter xParameter) 
            {
                m_block = block;
                m_xParameter = xParameter;
            }

            public override fmValue Eval(fmValue x)
            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultStatus = m_block.GetResultStatus(m_xParameter, x.Value);
                foreach (fmResultCheckStatus status in resultStatus.Values)
                    if (status != fmResultCheckStatus.INSIDE_RANGE)
                        return new fmValue(1);

                return new fmValue(0);
            }
        }

        override protected void ReWriteParameters()
        {
            base.ReWriteParameters();

            if (processOnChange)
            {
                processOnChange = false;

                CalculateAbsRanges();

                for (int i = 0; i < parameters.Count; ++i)
                {
                    if (parameters[i].cell == null)
                    {
                        continue;
                    }

                    DataGridView dataGrid = parameters[i].cell.DataGridView;
                    int rowIndex = parameters[i].cell.RowIndex;
                    int colIndex = parameters[i].cell.ColumnIndex;
                    double coef = parameters[i].globalParameter.unitFamily.CurrentUnit.Coef;

                    dataGrid[colIndex - 2, rowIndex].Value = parameters[i].globalParameter.chartDefaultXRange.minValue / coef;
                    dataGrid[colIndex + 2, rowIndex].Value = parameters[i].globalParameter.chartDefaultXRange.maxValue / coef;

                    DataGridViewCell minLimitCell = dataGrid[colIndex - 1, rowIndex];
                    DataGridViewCell maxLimitCell = dataGrid[colIndex + 1, rowIndex];

                    if (parameters[i].group == null)
                    {
                        minLimitCell.Value = "";
                        maxLimitCell.Value = "";

                        if (fmValue.Greater(new fmValue(parameters[i].globalParameter.chartDefaultXRange.minValue), parameters[i].value)
                            || fmValue.Less(new fmValue(parameters[i].globalParameter.chartDefaultXRange.maxValue), parameters[i].value))
                        {
                            minLimitCell.Style.ForeColor = Color.Black;
                            maxLimitCell.Style.ForeColor = Color.Black;
                            minLimitCell.Style.BackColor = Color.Pink;
                            maxLimitCell.Style.BackColor = Color.Pink;
                        }
                        else
                        {
                            minLimitCell.Style.ForeColor = Color.Black;
                            maxLimitCell.Style.ForeColor = Color.Black;
                            minLimitCell.Style.BackColor = Color.White;
                            maxLimitCell.Style.BackColor = Color.White;
                        }
                    }
                    else
                    {
                        fmValue minValue, maxValue;

                        GetMinMaxLimitsOfIncompleteInputs(parameters[i], out minValue, out maxValue);
                        //minValue = maxValue = new fmValue();

                        if (minValue.Value > maxValue.Value)
                        {
                            minValue = maxValue = new fmValue();
                        }

                        minLimitCell.Value = (minValue / coef).ToString();
                        maxLimitCell.Value = (maxValue / coef).ToString();

                        if (minValue.Defined 
                            && parameters[i].value.Defined 
                            && minValue > parameters[i].value)
                        {
                            minLimitCell.Style.ForeColor = Color.Black;
                            minLimitCell.Style.BackColor = Color.Red;
                        }
                        else
                        {
                            minLimitCell.Style.ForeColor = Color.Black;
                            minLimitCell.Style.BackColor = Color.White;
                        }

                        if (maxValue.Defined
                            && parameters[i].value.Defined
                            && maxValue < parameters[i].value)
                        {
                            maxLimitCell.Style.ForeColor = Color.Black;
                            maxLimitCell.Style.BackColor = Color.Red;
                        }
                        else
                        {
                            maxLimitCell.Style.ForeColor = Color.Black;
                            maxLimitCell.Style.BackColor = Color.White;
                        }
                    }
                }

                processOnChange = true;
            }
        }

        private void CalculateAbsRanges()
        {
            List<fmGlobalParameter> varList = new List<fmGlobalParameter>();
            varList.Add(fmGlobalParameter.A);
            varList.Add(fmGlobalParameter.Dp);
            varList.Add(fmGlobalParameter.sf);
            varList.Add(fmGlobalParameter.tc);

            Dictionary<fmGlobalParameter, int> index = new Dictionary<fmGlobalParameter,int>();

            List<fmCalculationBaseParameter> pList = new List<fmCalculationBaseParameter>();
            for (int i = 0; i < AllParameters.Count; ++i)
            {
                fmCalculationBaseParameter p = AllParameters[i];

                if (p is fmBlockVariableParameter)
                {
                    bool isInputed = varList.Contains(p.globalParameter);
                    pList.Add(new fmCalculationVariableParameter(p.globalParameter, p.value, isInputed));
                    index[p.globalParameter] = i;
                    if (isInputed == false)
                    {
                        p.globalParameter.chartDefaultXRange.minValue = 1e100;
                        p.globalParameter.chartDefaultXRange.maxValue = -1e100;
                    }
                }
                else
                {
                    pList.Add(new fmCalculationConstantParameter(p.globalParameter, p.value));
                }
            }

            fmCalculatorsLibrary.fmFilterMachiningCalculator calc = new fmFilterMachiningCalculator(pList);

            for (int mask = 0; mask < (1 << varList.Count); ++mask)
            {
                for (int i = 0; i < varList.Count; ++i)
                {
                    if ((mask & (1 << i)) != 0)
                    {
                        pList[index[varList[i]]].value = new fmValue(varList[i].chartDefaultXRange.maxValue);
                    }
                    else
                    {
                        pList[index[varList[i]]].value = new fmValue(varList[i].chartDefaultXRange.minValue);
                    }
                }

                calc.DoCalculations();

                foreach (fmCalculationBaseParameter p in pList)
                {
                    if (p is fmCalculationVariableParameter)
                    {
                        if (p.value.Defined && p.globalParameter.chartDefaultXRange.maxValue < p.value.Value)
                        {
                            p.globalParameter.chartDefaultXRange.maxValue = p.value.Value;
                        }

                        if (p.value.Defined && p.globalParameter.chartDefaultXRange.minValue > p.value.Value)
                        {
                            p.globalParameter.chartDefaultXRange.minValue = Math.Max(0, p.value.Value);
                        }
                    }
                }
            }
        }

        private bool GetMinMaxLimitsOfIncompleteInputs(fmBlockVariableParameter parameter, out fmValue minValue, out fmValue maxValue)
        {
            if (calculationOption == fmFilterMachiningCalculator.FilterMachiningCalculationOption.StandartAndDesignGlobal)
            {
                List<fmValue> keepedValues = new List<fmValue>();
                for (int i = 0; i < parameters.Count; ++i)
                {
                    keepedValues.Add(parameters[i].value);
                }

                List<fmBlockVariableParameter> keepedInputInfo = new List<fmBlockVariableParameter>();
                foreach (fmBlockVariableParameter p in parameters)
                {
                    if (p.IsInputed)
                    {
                        keepedInputInfo.Add(p);
                    }
                }

                UpdateIsInputed(parameter);
                parameter.value = new fmValue();

                List<fmBlockVariableParameter> naInputs = new List<fmBlockVariableParameter>();
                CheckNAAndAdd(GetParameterByName(fmGlobalParameter.A.name), naInputs);
                CheckNAAndAdd(GetParameterByName(fmGlobalParameter.Dp.name), naInputs);
                CheckNAAndAdd(GetParameterByName(fmGlobalParameter.sf.name), naInputs);
                CheckNAAndAdd(GetParameterByName(fmGlobalParameter.tc.name), naInputs);

                naInputs.Remove(FindGroupRepresetator(parameter.group));
                bool result = false;
                minValue = maxValue = new fmValue();

                for (int mask = 0; mask < (1 << naInputs.Count); ++mask)
                {
                    for (int i = 0; i < naInputs.Count; ++i)
                    {
                        fmBlockVariableParameter p = naInputs[i];
                        double minVal = p.globalParameter.chartDefaultXRange.minValue;
                        double maxVal = p.globalParameter.chartDefaultXRange.maxValue;
                        double eps = 1e-8;
                        minVal = minVal == 0 ? Math.Min(maxVal, 1) * eps : minVal * (1 + eps);
                        maxVal = maxVal * (1 - eps);
                        p.value = new fmValue((mask & (1 << i)) == 0 ? minVal : maxVal);
                    }

                    fmValue curMin, curMax;
                    if (GetMinMaxLimits(parameter, out curMin, out curMax))
                    {
                        if (result == false)
                        {
                            result = true;
                            minValue = curMin;
                            maxValue = curMax;
                        }
                        else
                        {
                            minValue = fmValue.Min(minValue, curMin);
                            maxValue = fmValue.Max(maxValue, curMax);
                        }
                    }
                }

                for (int i = 0; i < Parameters.Count; ++i)
                {
                    parameters[i].value = keepedValues[i];
                }

                foreach (fmBlockVariableParameter p in keepedInputInfo)
                {
                    UpdateIsInputed(p);
                }

                return result;
            }
            else
            {
                List<fmBlockVariableParameter> naInputs = GetNAInputsList();
                naInputs.Remove(FindGroupRepresetator(parameter.group));
                bool result = false;
                minValue = maxValue = new fmValue();

                for (int mask = 0; mask < (1 << naInputs.Count); ++mask)
                {
                    for (int i = 0; i < naInputs.Count; ++i)
                    {
                        fmBlockVariableParameter p = naInputs[i];
                        double minVal = p.globalParameter.chartDefaultXRange.minValue;
                        double maxVal = p.globalParameter.chartDefaultXRange.maxValue;
                        double eps = 1e-8;
                        minVal = minVal == 0 ? Math.Min(maxVal, 1)*eps : minVal*(1 + eps);
                        maxVal = maxVal*(1 - eps);
                        p.value = new fmValue((mask & (1 << i)) == 0 ? minVal : maxVal);
                    }

                    fmValue curMin, curMax;
                    if (GetMinMaxLimits(parameter, out curMin, out curMax))
                    {
                        if (result == false)
                        {
                            result = true;
                            minValue = curMin;
                            maxValue = curMax;
                        }
                        else
                        {
                            minValue = fmValue.Min(minValue, curMin);
                            maxValue = fmValue.Max(maxValue, curMax);
                        }
                    }
                }

                foreach (fmBlockVariableParameter p in naInputs)
                {
                    p.value = new fmValue();
                }
                DoCalculations();

                return result;
            }
        }

        private void CheckNAAndAdd(fmBlockVariableParameter p, List<fmBlockVariableParameter> naInputs)
        {
            if (FindGroupRepresetator(p.group).value.Defined == false)
            {
                naInputs.Add(p);
                UpdateIsInputed(p);
            }
        }

        private bool GetMinMaxLimits(fmBlockVariableParameter parameter, out fmValue minValue, out fmValue maxValue)
        {
            fmValue left, right;
            if (GetRangeWithDefinedResult(parameter, out left, out right) == false)
            {
                minValue = new fmValue();
                maxValue = new fmValue();
                return false;
            }

            if (GetRangeWithMeaningfulResult(parameter, left, right, out minValue, out maxValue) == false)
            {
                minValue = new fmValue();
                maxValue = new fmValue();
                return false;
            }

            fmValue eps = new fmValue(1e-10);// *(maxValue - minValue);
            minValue = minValue * (1 - eps);
            maxValue = maxValue * (1 + eps);

            return true;
        }

        private bool GetRangeWithMeaningfulResult(fmBlockVariableParameter parameter, fmValue left, fmValue right, out fmValue minValue, out fmValue maxValue)
        {
            fmValue point = FindPointWithMeaningfulResult(parameter, left, right);
            if (point.Defined == false)
            {
                minValue = new fmValue();
                maxValue = new fmValue();
                return false;
            }

            fmIsOutOfRanges isOutOfRanges = new fmIsOutOfRanges(this, parameter);
            fmValue falseValue = new fmValue(0);
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

        bool isGoodResultStatus(Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus)
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

        private fmValue FindPointWithMeaningfulResult(fmBlockVariableParameter parameter, fmValue left, fmValue right)
        {
            fmIsOutOfRanges isAllInRanges = new fmIsOutOfRanges(this, parameter);

            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus1 = GetResultStatus(parameter, left.Value);
                if (isGoodResultStatus(resultSatus1))
                {
                    return left;
                }

                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus2 = GetResultStatus(parameter, right.Value);
                if (isGoodResultStatus(resultSatus2))
                {
                    return right;
                }
            }

            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus1 = GetResultStatus(parameter, left.Value);
                bool ok = true;
                foreach (fmResultCheckStatus status in resultSatus1.Values)
                    if (status == fmResultCheckStatus.N_A)
                        ok = false;

                if (!ok)
                {
                    left += 1e-9 * (right - left);
                    resultSatus1 = GetResultStatus(parameter, left.Value);
                    foreach (fmResultCheckStatus status in resultSatus1.Values)
                        if (status == fmResultCheckStatus.N_A)
                            return new fmValue();
                }


                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus2 = GetResultStatus(parameter, right.Value);
                ok = true;
                foreach (fmResultCheckStatus status in resultSatus2.Values)
                    if (status == fmResultCheckStatus.N_A)
                        ok = false;

                if (!ok)
                {
                    right -= 1e-9 * (right - left);
                    resultSatus2 = GetResultStatus(parameter, right.Value);
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

                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus1 = GetResultStatus(parameter, mid1.Value);
                foreach (fmResultCheckStatus status in resultSatus1.Values)
                    if (status == fmResultCheckStatus.N_A)
                        throw new Exception("resultSatus1 contains n/a in FindPointWithMeaningfulResult");

                if (isGoodResultStatus(resultSatus1))
                {
                    return mid1;
                }

                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus2 = GetResultStatus(parameter, mid2.Value);
                foreach (fmResultCheckStatus status in resultSatus2.Values)
                    if (status == fmResultCheckStatus.N_A)
                        throw new Exception("resultSatus2 contains n/a in FindPointWithMeaningfulResult");

                Dictionary<fmGlobalParameter, fmResultBehaviorStatus> resultBehavior = GetResultBehavior(parameter, mid1.Value, mid2.Value);

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

                if (needToGoRight == true && needToGoLeft == false)
                {
                    left = mid1;
                }
                else if (needToGoRight == false && needToGoLeft == true)
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

        private bool GetRangeWithDefinedResult(fmBlockVariableParameter parameter, out fmValue left, out fmValue right)
        {
            // We use a fact that all results with min value of parameter are defined, otherwise we assume that there are no solution
            
            fmIsAllDefinedAndNotNegative isAllDefinedAndNotNegative = new fmIsAllDefinedAndNotNegative(this, parameter);
            fmValue trueValue = new fmValue(1);
            fmValue minValue = new fmValue(parameter.globalParameter.chartDefaultXRange.minValue);
            fmValue maxValue = new fmValue(parameter.globalParameter.chartDefaultXRange.maxValue);

            if (isAllDefinedAndNotNegative.Eval(minValue) != trueValue)
            {
                double eps = 1e-9;
                if (minValue.Value == 0)
                {
                    minValue.Value += maxValue.Value * eps;
                }
                else
                {
                    minValue.Value *= 1 + eps;
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

        private List<fmBlockVariableParameter> GetNAInputsList()
        {
            List<fmBlockVariableParameter> result = new List<fmBlockVariableParameter>();
            foreach (fmBlockVariableParameter p in parameters)
            {
                if (p.group != null && p.IsInputed && p.value.Defined == false)
                {
                    result.Add(p);
                }
            }
            return result;
        }
        
        private fmValue GetFirstValidArgument(fmBlockVariableParameter parameter, double a, double b)
        {
            Dictionary<fmGlobalParameter, fmResultCheckStatus> startStatus = GetResultStatus(parameter, a);
            double lo = a;
            double hi = b;
            for (int i = 0; i < 40; ++i)
            {
                double mid = 0.5*(lo + hi);
                Dictionary<fmGlobalParameter, fmResultCheckStatus> midStatus = GetResultStatus(parameter, mid);
                bool validValue = true;
                foreach(fmGlobalParameter p in midStatus.Keys)
                {
                    if (startStatus[p] != fmResultCheckStatus.INSIDE_RANGE
                        && startStatus[p] == midStatus[p])
                    {
                        validValue = false;
                        break;
                    }
                }
                if (validValue)
                {
                    hi = mid;
                }
                else
                {
                    lo = mid;
                }
            }

            fmValue res = new fmValue(lo);
            return res;
        }

        private Dictionary<fmGlobalParameter, fmValue> GetClueResultsWithSpecialParameterValue(fmBlockVariableParameter parameter, double paramValue)
        {
            Dictionary<fmGlobalParameter, fmValue> result = new Dictionary<fmGlobalParameter, fmValue>();

            List<fmValue> keepedValues = new List<fmValue>();
            for (int i = 0; i < parameters.Count; ++i)
            {
                keepedValues.Add(parameters[i].value);
            }

            fmBlockVariableParameter groupInput = FindGroupRepresetator(parameter.group);
            fmValue groupInputInitialValue = groupInput.value;
            groupInput.IsInputed = false;
            parameter.IsInputed = true;

            parameter.value = new fmValue(paramValue);

            DoCalculationsLimitsClue();

            result[fmGlobalParameter.A] = GetParameterByName(fmGlobalParameter.A.name).value;
            result[fmGlobalParameter.Dp] = GetParameterByName(fmGlobalParameter.Dp.name).value;
            result[fmGlobalParameter.sf] = GetParameterByName(fmGlobalParameter.sf.name).value;
            result[fmGlobalParameter.tc] = GetParameterByName(fmGlobalParameter.tc.name).value;

            parameter.IsInputed = false;
            groupInput.value = groupInputInitialValue;
            groupInput.IsInputed = true;

            for (int i = 0; i < Parameters.Count; ++i)
            {
                parameters[i].value = keepedValues[i];
            }

            return result;
        }

        private Dictionary<fmGlobalParameter, fmResultCheckStatus> GetResultStatus(fmBlockVariableParameter parameter, double valueToCheck)
        {
            Dictionary<fmGlobalParameter, fmValue> resultValues = GetClueResultsWithSpecialParameterValue(parameter, valueToCheck);
            Dictionary<fmGlobalParameter, fmResultCheckStatus> result = new Dictionary<fmGlobalParameter, fmResultCheckStatus>();

            foreach (fmGlobalParameter p in resultValues.Keys)
            {
                fmValue curValue = resultValues[p];
                if (curValue.Defined == false)
                {
                    result[p] = fmResultCheckStatus.N_A;
                }
                else
                {
                    double eps = 1e-9;
                    if (fmValue.epsCompare(curValue.Value, 0, eps) < 0)
                    {
                        result[p] = fmResultCheckStatus.NEGATIVE;
                    }
                    else if (fmValue.epsCompare(curValue.Value, p.chartDefaultXRange.maxValue, eps) > 0)
                    {
                        result[p] = fmResultCheckStatus.GREATER_THAN_MAXIMUM;
                    }
                    else if (fmValue.epsCompare(curValue.Value, p.chartDefaultXRange.minValue, eps) < 0)
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

        private Dictionary<fmGlobalParameter, fmResultBehaviorStatus> GetResultBehavior(fmBlockVariableParameter parameter, double x1, double x2)
        {
            Dictionary<fmGlobalParameter, fmValue> result1 = GetClueResultsWithSpecialParameterValue(parameter, x1);
            Dictionary<fmGlobalParameter, fmValue> result2 = GetClueResultsWithSpecialParameterValue(parameter, x2);
            Dictionary<fmGlobalParameter, fmResultBehaviorStatus> result = new Dictionary<fmGlobalParameter, fmResultBehaviorStatus>();
            foreach (fmGlobalParameter p in result1.Keys)
            {
                fmValue val1 = result1[p];
                fmValue val2 = result2[p];
                if (val1.Defined == false || val2.Defined == false)
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

        private bool IsInRange(double p, double a, double b)
        {
            return a <= p && p <= b
                || b <= p && p <= a;
        }

        private static List<fmValue> GetNodesList(double a, double b, int n)
        {
            List<fmValue> valuesToCheck = new List<fmValue>();

            for (int i = 0; i < n; ++i)
            {
                valuesToCheck.Add(new fmValue(a + (b - a) * i / (n - 1)));
            }
            return valuesToCheck;
        }

        private fmValue GetMaxLimit(fmBlockVariableParameter parameter)
        {
            return GetFirstValidArgument(parameter,
                parameter.globalParameter.chartDefaultXRange.maxValue,
                parameter.globalParameter.chartDefaultXRange.minValue);
        }

        private fmValue GetMinLimit(fmBlockVariableParameter parameter)
        {
            return GetFirstValidArgument(parameter,
                parameter.globalParameter.chartDefaultXRange.minValue,
                parameter.globalParameter.chartDefaultXRange.maxValue);
        }

        private fmBlockVariableParameter FindGroupRepresetator(fmBlockParameterGroup group)
        {
            foreach (fmBlockVariableParameter p in parameters)
            {
                if (p.group == group && p.IsInputed == true)
                {
                    return p;
                }
            }
            return null;
        }

        //private bool IsParametersInRanges()
        //{
        //    foreach (fmCalcBlocksLibrary.BlockParameter.fmBlockVariableParameter p in parameters)
        //    {
        //        if (p.value.Defined == false
        //            || fmValue.Less(p.value, new fmValue(p.globalParameter.chartDefaultXRange.minValue))
        //            || fmValue.Greater(p.value, new fmValue(p.globalParameter.chartDefaultXRange.maxValue)))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //internal bool IsParametersDefined()
        //{
        //    foreach (fmBlockVariableParameter p in parameters)
        //    {
        //        if (p.value.Defined == false)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
    }
}
