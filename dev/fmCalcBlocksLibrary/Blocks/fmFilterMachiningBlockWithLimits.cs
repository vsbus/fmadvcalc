using System;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using System.Collections.Generic;
using System.Drawing;
using fmCalculatorsLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmFilterMachiningBlockWithLimits : fmFilterMachiningBlock
    {
        private bool m_isLimitsDisplaying = true;

        public bool IsLimitsDisplaying
        {
            get { return m_isLimitsDisplaying; }
            set { m_isLimitsDisplaying = value; }
        }

        public void DoCalculationsLimitsClue()
        {
            var filterMachinigCalculator =
                new fmFilterMachiningCalculator(AllParameters) {calculationOption = calculationOption};
            filterMachinigCalculator.DoCalculationsLimitsClue();
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

        private class fmIsAllDefinedAndNotNegative : fmCalculationLibrary.NumericalMethods.fmFunction
        {
            private readonly fmFilterMachiningBlockWithLimits m_block;
            private readonly fmBlockVariableParameter m_xParameter;
            public fmIsAllDefinedAndNotNegative(fmFilterMachiningBlockWithLimits block, fmBlockVariableParameter xParameter)
            {
                m_block = block;
                m_xParameter = xParameter;
            }

            public override fmValue Eval(fmValue x)
            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultStatus = m_block.GetResultStatus(m_xParameter, x.value);
                var result = new fmValue(1);
                foreach (fmResultCheckStatus status in resultStatus.Values)
                    if (status == fmResultCheckStatus.N_A || status == fmResultCheckStatus.NEGATIVE)
                        result.value = 0;

                return result;
            }
        }

        private class fmIsOutOfRanges : fmCalculationLibrary.NumericalMethods.fmFunction
        {
            private readonly fmFilterMachiningBlockWithLimits m_block;
            private readonly fmBlockVariableParameter m_xParameter;
            public fmIsOutOfRanges(fmFilterMachiningBlockWithLimits block, fmBlockVariableParameter xParameter) 
            {
                m_block = block;
                m_xParameter = xParameter;
            }

            public override fmValue Eval(fmValue x)
            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultStatus = m_block.GetResultStatus(m_xParameter, x.value);
                foreach (fmResultCheckStatus status in resultStatus.Values)
                    if (status != fmResultCheckStatus.INSIDE_RANGE)
                        return new fmValue(1);

                return new fmValue(0);
            }
        }

        override protected void ReWriteParameters()
        {
            base.ReWriteParameters();

            if (processOnChange && m_isLimitsDisplaying)
            {
                processOnChange = false;

                CalculateAbsRanges();
                
                Dictionary<fmGlobalParameter, fmValue> minValue = new Dictionary<fmGlobalParameter, fmValue>();
                Dictionary<fmGlobalParameter, fmValue> maxValue = new Dictionary<fmGlobalParameter, fmValue>();
                
                List<fmBlockVariableParameter> clueParams = GetClueParamsList();
                
                CalculateClueParamsLimits(clueParams, minValue, maxValue);
                CalculateAllParamsLimits(clueParams, minValue, maxValue);
                
                WriteLimitsToUI(minValue, maxValue);

                processOnChange = true;
            }
        }

        private void CalculateAllParamsLimits(List<fmBlockVariableParameter> clueParams, Dictionary<fmGlobalParameter, fmValue> minValue, Dictionary<fmGlobalParameter, fmValue> maxValue)
        {
            foreach (fmBlockVariableParameter clueParameter in clueParams)
            {
                List<fmValue> keepedValues;
                List<fmBlockVariableParameter> keepedInputInfo;
                KeepValuesAndInputInfo(out keepedValues, out keepedInputInfo);
                UpdateIsInputed(clueParameter);

                var naInputs = GetNAInputsList(clueParameter);

                for (int i = 0; i < 2; ++i)
                {
                    clueParameter.value = (i == 0 ? minValue : maxValue)[clueParameter.globalParameter];
                    for (int mask = 0; mask < (1 << naInputs.Count); ++mask)
                    {
                        for (int j = 0; j < naInputs.Count; ++j)
                        {
                            naInputs[j].value = ((mask & (1 << j)) != 0
                                ? new fmValue(naInputs[j].globalParameter.defaultXRange.MaxValue)
                                : new fmValue(naInputs[j].globalParameter.defaultXRange.MinValue));
                        }
                        DoCalculations();
                        foreach (fmBlockVariableParameter parameter in parameters)
                        {
                            if (parameter.group == clueParameter.group)
                            {
                                fmGlobalParameter p = parameter.globalParameter;
                                if (minValue.ContainsKey(p) == false)
                                {
                                    minValue[p] = new fmValue();
                                }
                                if (maxValue.ContainsKey(p) == false)
                                {
                                    maxValue[p] = new fmValue();
                                }
                                if (minValue[p].defined == false || minValue[p] > parameter.value)
                                {
                                    minValue[p] = parameter.value;
                                }
                                if (maxValue[p].defined == false || maxValue[p] < parameter.value)
                                {
                                    maxValue[p] = parameter.value;
                                }
                            }
                        }
                    }
                }
                RestoreValuesAndInputInfo(keepedValues, keepedInputInfo);
            }
        }

        private void WriteLimitsToUI(Dictionary<fmGlobalParameter, fmValue> minValue, Dictionary<fmGlobalParameter, fmValue> maxValue)
        {
            foreach (var parameter in parameters)
            {
                if (parameter.cell == null)
                {
                    continue;
                }
                DataGridView dataGrid = parameter.cell.DataGridView;
                int rowIndex = parameter.cell.RowIndex;
                int colIndex = parameter.cell.ColumnIndex;
                double coef = parameter.globalParameter.unitFamily.CurrentUnit.Coef;

                dataGrid[colIndex - 2, rowIndex].Value = parameter.globalParameter.defaultXRange.MinValue / coef;
                dataGrid[colIndex + 2, rowIndex].Value = parameter.globalParameter.defaultXRange.MaxValue / coef;

                DataGridViewCell minLimitCell = dataGrid[colIndex - 1, rowIndex];
                DataGridViewCell maxLimitCell = dataGrid[colIndex + 1, rowIndex];

                if (parameter.group == null)
                {
                    minLimitCell.Value = "";
                    maxLimitCell.Value = "";

                    if (fmValue.Greater(new fmValue(parameter.globalParameter.defaultXRange.MinValue), parameter.value)
                        || fmValue.Less(new fmValue(parameter.globalParameter.defaultXRange.MaxValue), parameter.value))
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
                    if (minValue.ContainsKey(parameter.globalParameter) == false)
                    {
                        minValue[parameter.globalParameter] = new fmValue();
                    }
                    if (maxValue.ContainsKey(parameter.globalParameter) == false)
                    {
                        maxValue[parameter.globalParameter] = new fmValue();
                    }
                    minLimitCell.Value = (minValue[parameter.globalParameter] / coef).ToString();
                    maxLimitCell.Value = (maxValue[parameter.globalParameter] / coef).ToString();

                    if (minValue[parameter.globalParameter].defined
                        && parameter.value.defined
                        && minValue[parameter.globalParameter] > parameter.value)
                    {
                        minLimitCell.Style.ForeColor = Color.Black;
                        minLimitCell.Style.BackColor = Color.Red;
                    }
                    else
                    {
                        minLimitCell.Style.ForeColor = Color.Black;
                        minLimitCell.Style.BackColor = Color.White;
                    }

                    if (maxValue[parameter.globalParameter].defined
                        && parameter.value.defined
                        && maxValue[parameter.globalParameter] < parameter.value)
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
        }
        private void CalculateClueParamsLimits(List<fmBlockVariableParameter> clueParams, Dictionary<fmGlobalParameter, fmValue> minValue, Dictionary<fmGlobalParameter, fmValue> maxValue)
        {
            foreach (var parameter in clueParams)
            {
                if (parameter.cell == null)
                {
                    continue;
                }
                if (parameter.group != null)
                {
                    fmValue minVal, maxVal;
                    GetMinMaxLimitsOfIncompleteInputs(parameter, out minVal, out maxVal);
                    if (minVal.value > maxVal.value)
                    {
                        minVal = maxVal = new fmValue();
                    }
                    minValue[parameter.globalParameter] = minVal;
                    maxValue[parameter.globalParameter] = maxVal;
                }
            }
        }
        private List<fmBlockVariableParameter> GetClueParamsList()
        {
            List<fmBlockVariableParameter> clueParams = new List<fmBlockVariableParameter>(new fmBlockVariableParameter[] {
                    GetParameterByName(fmGlobalParameter.A.name),
                    GetParameterByName(fmGlobalParameter.Dp.name),
                    GetParameterByName(fmGlobalParameter.hc.name),
                    GetParameterByName(fmGlobalParameter.sf.name)
                });
            var d0 = GetParameterByName(fmGlobalParameter.d0.name);
            if (d0.group != null)
            {
                clueParams.Add(GetParameterByName(fmGlobalParameter.d0.name));
            }
            return clueParams;
        }
        private void CalculateAbsRanges()
        {
            var varList = new List<fmGlobalParameter>
            {
              fmGlobalParameter.A,
              fmGlobalParameter.Dp,
              fmGlobalParameter.sf,
              fmGlobalParameter.tc
            };
            var machineAdditionalParams = new List<fmGlobalParameter>
            {
                fmGlobalParameter.d0
            };
            var index = new Dictionary<fmGlobalParameter,int>();
            var pList = new List<fmCalculationBaseParameter>();
            for (int i = 0; i < AllParameters.Count; ++i)
            {
                fmCalculationBaseParameter p = AllParameters[i];
                if (p is fmBlockVariableParameter)
                {
                    bool isInputed = varList.Contains(p.globalParameter);
                    pList.Add(new fmCalculationVariableParameter(p.globalParameter, p.value, isInputed));
                    index[p.globalParameter] = i;
                    if (machineAdditionalParams.Contains(p.globalParameter) == false && isInputed == false)
                    {
                        p.globalParameter.defaultXRange.MinValue = 1e100;
                        p.globalParameter.defaultXRange.MaxValue = -1e100;
                    }
                }
                else
                {
                    pList.Add(new fmCalculationConstantParameter(p.globalParameter, p.value));
                }
            }

            var calc = new fmFilterMachiningCalculator(pList);
            for (int mask = 0; mask < (1 << varList.Count); ++mask)
            {
                for (int i = 0; i < varList.Count; ++i)
                {
                    pList[index[varList[i]]].value = (mask & (1 << i)) != 0 
                        ? new fmValue(varList[i].defaultXRange.MaxValue) 
                        : new fmValue(varList[i].defaultXRange.MinValue);
                }
                calc.DoCalculations();
                foreach (fmCalculationBaseParameter p in pList)
                {
                    if (p is fmCalculationVariableParameter 
                        && machineAdditionalParams.Contains(p.globalParameter) == false)
                    {
                        if (p.value.defined && p.globalParameter.defaultXRange.MaxValue < p.value.value)
                            p.globalParameter.defaultXRange.MaxValue = p.value.value;
                        if (p.value.defined && p.globalParameter.defaultXRange.MinValue > p.value.value)
                            p.globalParameter.defaultXRange.MinValue = Math.Max(0, p.value.value);
                    }
                }
            }
        }

        private void GetMinMaxLimitsOfIncompleteInputs(fmBlockVariableParameter parameter, out fmValue minValue, out fmValue maxValue)
        {
            if (calculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_DP_CONST
                || calculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_QP_CONST
                || calculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_QP_CONST_VOLUMETRIC_PUMP
                || calculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.CYLINDRICAL_DP_CONST
                || calculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.CYLINDRICAL_QP_CONST
                || calculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.CYLINDRICAL_QP_CONST_VOLUMETRIC_PUMP)
            {
                List<fmValue> keepedValues;
                List<fmBlockVariableParameter> keepedInputInfo;
                KeepValuesAndInputInfo(out keepedValues, out keepedInputInfo);

                UpdateIsInputed(parameter);
                parameter.value = new fmValue();

                var naInputs = GetNAInputsList(parameter);

                bool result = false;
                minValue = maxValue = new fmValue();

                for (int mask = 0; mask < (1 << naInputs.Count); ++mask)
                {
                    for (int i = 0; i < naInputs.Count; ++i)
                    {
                        fmBlockVariableParameter p = naInputs[i];
                        double minVal = p.globalParameter.defaultXRange.MinValue;
                        double maxVal = p.globalParameter.defaultXRange.MaxValue;
                        const double eps = 1e-8;
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

                RestoreValuesAndInputInfo(keepedValues, keepedInputInfo);
                return;
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
                        double minVal = p.globalParameter.defaultXRange.MinValue;
                        double maxVal = p.globalParameter.defaultXRange.MaxValue;
                        const double eps = 1e-8;
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

                return;
            }
        }

        private List<fmBlockVariableParameter> GetNAInputsList(fmBlockVariableParameter parameter)
        {
            var naInputs = new List<fmBlockVariableParameter>();
            CheckNAAndAdd(GetParameterByName(fmGlobalParameter.A.name), naInputs);
            CheckNAAndAdd(GetParameterByName(fmGlobalParameter.Dp.name), naInputs);
            CheckNAAndAdd(GetParameterByName(fmGlobalParameter.sf.name), naInputs);
            CheckNAAndAdd(GetParameterByName(fmGlobalParameter.tc.name), naInputs);
            var d0 = GetParameterByName(fmGlobalParameter.d0.name);
            if (d0.group != null)
            {
                CheckNAAndAdd(d0, naInputs);
            }
            naInputs.Remove(FindGroupRepresetator(parameter.group));
            return naInputs;
        }
        private void KeepValuesAndInputInfo(out List<fmValue> keepedValues, out List<fmBlockVariableParameter> keepedInputInfo)
        {
            keepedValues = new List<fmValue>();
            for (int i = 0; i < parameters.Count; ++i)
            {
                keepedValues.Add(parameters[i].value);
            }

            keepedInputInfo = new List<fmBlockVariableParameter>();
            foreach (fmBlockVariableParameter p in parameters)
            {
                if (p.IsInputed)
                {
                    keepedInputInfo.Add(p);
                }
            }
        }

        private void RestoreValuesAndInputInfo(List<fmValue> keepedValues, List<fmBlockVariableParameter> keepedInputInfo)
        {
            for (int i = 0; i < Parameters.Count; ++i)
            {
                parameters[i].value = keepedValues[i];
            }

            foreach (fmBlockVariableParameter p in keepedInputInfo)
            {
                UpdateIsInputed(p);
            }
        }

        private void CheckNAAndAdd(fmBlockVariableParameter p, List<fmBlockVariableParameter> naInputs)
        {
            if (p.group != null && FindGroupRepresetator(p.group).value.defined == false)
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

            var eps = new fmValue(1e-10);// *(maxValue - minValue);
            minValue = minValue * (1 - eps);
            maxValue = maxValue * (1 + eps);

            return true;
        }

        private bool GetRangeWithMeaningfulResult(fmBlockVariableParameter parameter, fmValue left, fmValue right, out fmValue minValue, out fmValue maxValue)
        {
            fmValue point = FindPointWithMeaningfulResult(parameter, left, right);
            if (point.defined == false)
            {
                minValue = new fmValue();
                maxValue = new fmValue();
                return false;
            }

            var isOutOfRanges = new fmIsOutOfRanges(this, parameter);
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

        static bool IsGoodResultStatus(Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus)
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

            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus1 = GetResultStatus(parameter, left.value);
                if (IsGoodResultStatus(resultSatus1))
                {
                    return left;
                }

                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus2 = GetResultStatus(parameter, right.value);
                if (IsGoodResultStatus(resultSatus2))
                {
                    return right;
                }
            }

            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus1 = GetResultStatus(parameter, left.value);
                bool ok = true;
                foreach (fmResultCheckStatus status in resultSatus1.Values)
                    if (status == fmResultCheckStatus.N_A)
                        ok = false;

                if (!ok)
                {
                    left += 1e-9 * (right - left);
                    resultSatus1 = GetResultStatus(parameter, left.value);
                    foreach (fmResultCheckStatus status in resultSatus1.Values)
                        if (status == fmResultCheckStatus.N_A)
                            return new fmValue();
                }


                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus2 = GetResultStatus(parameter, right.value);
                ok = true;
                foreach (fmResultCheckStatus status in resultSatus2.Values)
                    if (status == fmResultCheckStatus.N_A)
                        ok = false;

                if (!ok)
                {
                    right -= 1e-9 * (right - left);
                    resultSatus2 = GetResultStatus(parameter, right.value);
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

                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus1 = GetResultStatus(parameter, mid1.value);
                foreach (fmResultCheckStatus status in resultSatus1.Values)
                    if (status == fmResultCheckStatus.N_A)
                        throw new Exception("resultSatus1 contains n/a in FindPointWithMeaningfulResult");

                if (IsGoodResultStatus(resultSatus1))
                {
                    return mid1;
                }

                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus2 = GetResultStatus(parameter, mid2.value);
                foreach (fmResultCheckStatus status in resultSatus2.Values)
                    if (status == fmResultCheckStatus.N_A)
                        throw new Exception("resultSatus2 contains n/a in FindPointWithMeaningfulResult");

                Dictionary<fmGlobalParameter, fmResultBehaviorStatus> resultBehavior = GetResultBehavior(parameter, mid1.value, mid2.value);

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

        private bool GetRangeWithDefinedResult(fmBlockVariableParameter parameter, out fmValue left, out fmValue right)
        {
            // We use a fact that all results with min value of parameter are defined, otherwise we assume that there are no solution
            
            var isAllDefinedAndNotNegative = new fmIsAllDefinedAndNotNegative(this, parameter);
            var trueValue = new fmValue(1);
            var minValue = new fmValue(parameter.globalParameter.defaultXRange.MinValue);
            var maxValue = new fmValue(parameter.globalParameter.defaultXRange.MaxValue);

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

        private List<fmBlockVariableParameter> GetNAInputsList()
        {
            var result = new List<fmBlockVariableParameter>();
            foreach (fmBlockVariableParameter p in parameters)
            {
                if (p.group != null && p.IsInputed && p.value.defined == false)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        private Dictionary<fmGlobalParameter, fmValue> GetClueResultsWithSpecialParameterValue(fmBlockVariableParameter parameter, double paramValue)
        {
            var result = new Dictionary<fmGlobalParameter, fmValue>();

            var keepedValues = new List<fmValue>();
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
                    else if (fmValue.EpsCompare(curValue.value, p.defaultXRange.MaxValue, eps) > 0)
                    {
                        result[p] = fmResultCheckStatus.GREATER_THAN_MAXIMUM;
                    }
                    else if (fmValue.EpsCompare(curValue.value, p.defaultXRange.MinValue, eps) < 0)
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

        private fmBlockVariableParameter FindGroupRepresetator(fmBlockParameterGroup group)
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
    }
}
