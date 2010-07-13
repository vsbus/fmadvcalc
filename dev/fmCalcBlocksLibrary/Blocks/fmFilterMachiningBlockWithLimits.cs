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

        
        private class fmIsAllInRanges : fmCalculationLibrary.NumericalMethods.fmFunction
        {
            private fmFilterMachiningBlockWithLimits m_block;
            private fmBlockVariableParameter m_xParameter;
            public fmIsAllInRanges(fmFilterMachiningBlockWithLimits block, fmBlockVariableParameter xParameter) 
            {
                m_block = block;
                m_xParameter = xParameter;
            }

            public override fmValue Eval(fmValue x)
            {
                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultStatus = m_block.GetResultStatus(m_xParameter, x.Value);
                fmValue result = new fmValue(1);
                foreach (fmResultCheckStatus status in resultStatus.Values)
                    if (status != fmResultCheckStatus.INSIDE_RANGE)
                        result.Value = 0;

                return result;
            }
        }

        override protected void ReWriteParameters()
        {
            base.ReWriteParameters();

            if (processOnChange)
            {
                processOnChange = false;

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
                            
                        if (parameters[i].group == null)
                        {
                            minLimitCell.Value = "";
                            maxLimitCell.Value = "";

                            minLimitCell.Style.ForeColor = Color.Black;
                            maxLimitCell.Style.ForeColor = Color.Black;
                            minLimitCell.Style.BackColor = Color.White;
                            maxLimitCell.Style.BackColor = Color.White;
                        }
                        else
                        {
                            //GetMinMaxLimits(parameters[i], out minValue, out maxValue);
                            GetMinMaxLimitsOfIncompleteInputs(parameters[i], out minValue, out maxValue);
                            
                            if (minValue.Value > maxValue.Value)
                            {
                                minValue = maxValue = new fmValue();
                            }

                            //minLimitCell.Value = minValue.RoundUp(minValue / coef, fmValue.outputPrecision).ToString();
                            //maxLimitCell.Value = minValue.RoundDown(maxValue / coef, fmValue.outputPrecision).ToString();
                            minLimitCell.Value = (minValue / coef).ToString();
                            maxLimitCell.Value = (maxValue / coef).ToString();

                            if (minValue.Defined && maxValue.Defined
                            && (minValue > parameters[i].value || maxValue < parameters[i].value))
                            {
                                minLimitCell.Style.ForeColor = Color.Black;
                                maxLimitCell.Style.ForeColor = Color.Black;
                                minLimitCell.Style.BackColor = Color.Red;
                                maxLimitCell.Style.BackColor = Color.Red;
                            }
                            else
                            {
                                minLimitCell.Style.ForeColor = Color.Black;
                                maxLimitCell.Style.ForeColor = Color.Black;
                                minLimitCell.Style.BackColor = Color.White;
                                maxLimitCell.Style.BackColor = Color.White;
                            }
                        }
                    }
                }

                processOnChange = true;
            }
        }

        private bool GetMinMaxLimitsOfIncompleteInputs(fmBlockVariableParameter parameter, out fmValue minValue, out fmValue maxValue)
        {
            List<fmBlockVariableParameter> naInputs = GetNAInputsList();
            naInputs.Remove(parameter);
            bool result = false;
            minValue = maxValue = new fmValue();

            for (int mask = 0; mask < (1 << naInputs.Count); ++mask)
            {
                for (int i = 0; i < naInputs.Count; ++i)
                {
                    fmBlockVariableParameter p = naInputs[i];
                    p.value = new fmValue((mask & (1 << i)) == 0
                                              ? p.globalParameter.chartDefaultXRange.minValue
                                              : p.globalParameter.chartDefaultXRange.maxValue);
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

            return result;
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

            fmValue eps = 1e-8 * (maxValue - minValue);
            minValue = minValue - eps;
            maxValue = maxValue + eps;

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

            fmIsAllInRanges isAllInRanges = new fmIsAllInRanges(this, parameter);
            fmValue trueValue = new fmValue(1);
            if (isAllInRanges.Eval(left) == trueValue)
            {
                minValue = left;
            }
            else
            {
                fmValue temp;
                fmCalculationLibrary.NumericalMethods.fmBisectionMethod.FindRootRange(isAllInRanges, point, left, 30, out temp, out minValue);
            }

            if (isAllInRanges.Eval(right) == trueValue)
            {
                maxValue = right;
            }
            else
            {
                fmValue temp;
                fmCalculationLibrary.NumericalMethods.fmBisectionMethod.FindRootRange(isAllInRanges, point, right, 30, out temp, out maxValue);
            }

            return true;
        }

        private fmValue FindPointWithMeaningfulResult(fmBlockVariableParameter parameter, fmValue left, fmValue right)
        {
            fmIsAllInRanges isAllInRanges = new fmIsAllInRanges(this, parameter);

            for (int it = 0; it < 30; ++it)
            {
                fmValue mid = 0.5 * (left + right);
                fmValue eps = (right - left) * 1e-8;
                fmValue mid1 = mid - eps;
                fmValue mid2 = mid + eps;

                Dictionary<fmGlobalParameter, fmResultCheckStatus> resultSatus1 = GetResultStatus(parameter, mid1.Value);
                foreach (fmResultCheckStatus status in resultSatus1.Values)
                    if (status == fmResultCheckStatus.N_A)
                        throw new Exception("resultSatus1 contains n/a in FindPointWithMeaningfulResult");

                bool goodPoint = true;
                foreach (fmResultCheckStatus status in resultSatus1.Values)
                {
                    if (status != fmResultCheckStatus.INSIDE_RANGE)
                    {
                        goodPoint = false;
                        break;
                    }
                }
                if (goodPoint)
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


            //fmValue trueValue = new fmValue(1);
            //for (int i = 0; i <= 100; ++i)
            //{
            //    fmValue p = left + (right - left) * i / 100;
            //    if (isAllInRanges.Eval(p) == trueValue)
            //    {
            //        return p;
            //    }
            //}
            //return new fmValue();
        }

        private bool GetRangeWithDefinedResult(fmBlockVariableParameter parameter, out fmValue left, out fmValue right)
        {
            // We use a fact that all results with min value of parameter are defined, otherwise we assume that there are no solution
            
            fmIsAllDefinedAndNotNegative isAllDefinedAndNotNegative = new fmIsAllDefinedAndNotNegative(this, parameter);
            fmValue trueValue = new fmValue(1);
            fmValue minValue = new fmValue(parameter.globalParameter.chartDefaultXRange.minValue);
            fmValue maxValue = new fmValue(parameter.globalParameter.chartDefaultXRange.maxValue);

            if (isAllDefinedAndNotNegative.Eval(minValue) == trueValue)
            {
                left = minValue;
                
                if (isAllDefinedAndNotNegative.Eval(maxValue) == trueValue)
                {
                    right = maxValue;
                }
                else
                {
                    right = fmCalculationLibrary.NumericalMethods.fmBisectionMethod.FindRoot(
                        isAllDefinedAndNotNegative, left, maxValue, 30);
                }

                return true;
            }
            if (isAllDefinedAndNotNegative.Eval(maxValue) == trueValue)
            {
                right = maxValue;
                left = fmCalculationLibrary.NumericalMethods.fmBisectionMethod.FindRoot(
                    isAllDefinedAndNotNegative, right, minValue, 30);
                return true;
            }
            left = new fmValue();
            right = new fmValue();
            return false;
        }

        //private fmValue GetFirstOKValue(fmBlockVariableParameter parameter,
        //    List<fmValue> valuesToCheck)
        //{
        //    fmBlockVariableParameter groupInput = FindGroupRepresetator(parameter.group);
        //    fmValue groupInputInitialValue = groupInput.value;
        //    groupInput.IsInputed = false;
        //    parameter.IsInputed = true;

        //    fmValue result = new fmValue();
        //    for (int i = 0; i < valuesToCheck.Count; ++i)
        //    {
        //        parameter.value = valuesToCheck[i];


        //        List<fmBlockVariableParameter> listOfNAInputs = GetNAInputsList();
        //        listOfNAInputs.Remove(parameter);

        //        if (listOfNAInputs.Count != 0)
        //        {
        //            for (int mask = 0; mask < (1 << listOfNAInputs.Count); ++mask)
        //            {
        //                for (int t = 0; t < listOfNAInputs.Count; ++t)
        //                {
        //                    double a = listOfNAInputs[t].globalParameter.chartDefaultXRange.minValue;
        //                    double b = listOfNAInputs[t].globalParameter.chartDefaultXRange.maxValue;
        //                    double eps = 1e-9 * (b - a);

        //                    if ((mask & (1 << t)) == 0)
        //                    {
        //                        listOfNAInputs[t].value = new fmValue(a + eps);
        //                    }
        //                    else
        //                    {
        //                        listOfNAInputs[t].value = new fmValue(b - eps);
        //                    }
        //                }

        //                DoCalculations();
        //                if (IsParametersInRanges())
        //                {
        //                    result = parameter.value;
        //                    break;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            DoCalculations();
        //            if (IsParametersInRanges())
        //            {
        //                result = parameter.value;
        //                break;
        //            }
        //        }

        //        foreach (fmBlockVariableParameter p in listOfNAInputs)
        //        {
        //            p.value = new fmValue();
        //        }

        //        if (result.Defined == true)
        //        {
        //            break;
        //        }
        //    }

        //    parameter.IsInputed = false;
        //    groupInput.value = groupInputInitialValue;
        //    groupInput.IsInputed = true;

        //    DoCalculations();

        //    return result;
        //}

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
            /*
             * Dictionary<fmGlobalParameter, fmResultCheckStatus> endStatus = GetResultStatus(parameter, hi);
            foreach(fmResultCheckStatus status in endStatus.Values)
            {
                if (status != fmResultCheckStatus.INSIDE_RANGE)
                {
                    res = new fmValue();
                    break;
                }
            }
             */
            return res;

            /*
            int n = 100 + 1;

            List<fmValue> valuesToCheck = GetNodesList(a, b, n);
            fmValue best = GetFirstOKValue(parameter, valuesToCheck);

            //if (best.Defined == false)
            //{
            //    n = 1000 + 1;
            //    valuesToCheck = GetNodesList(a, b, n);
            //    best = GetFirstOKValue(parameter, valuesToCheck);
            //}

            if (best.Defined == false)
            {
                return new fmValue();
            }

            for (int it = 0; it < 10; ++it)
            {
                double d = (b - a) / (n - 1);
                a = IsInRange(best.Value - d, a, b) ? best.Value - d : a;
                b = IsInRange(best.Value + d, a, b) ? best.Value + d : b;
                n = 20 + 1;

                valuesToCheck = GetNodesList(a, b, n);
                best = GetFirstOKValue(parameter, valuesToCheck);
            }

            return best;
            */
        }

        private Dictionary<fmGlobalParameter, fmValue> GetResultsWithSpecialParameterValue(fmBlockVariableParameter parameter, double paramValue)
        {
            Dictionary<fmGlobalParameter, fmValue> result = new Dictionary<fmGlobalParameter, fmValue>();

            fmBlockVariableParameter groupInput = FindGroupRepresetator(parameter.group);
            fmValue groupInputInitialValue = groupInput.value;
            groupInput.IsInputed = false;
            parameter.IsInputed = true;

            parameter.value = new fmValue(paramValue);

            DoCalculations();

            foreach (fmBlockVariableParameter p in parameters)
                result[p.globalParameter] = p.value;

            parameter.IsInputed = false;
            groupInput.value = groupInputInitialValue;
            groupInput.IsInputed = true;

            DoCalculations();

            return result;
        }

        private Dictionary<fmGlobalParameter, fmResultCheckStatus> GetResultStatus(fmBlockVariableParameter parameter, double valueToCheck)
        {
            Dictionary<fmGlobalParameter, fmValue> resultValues = GetResultsWithSpecialParameterValue(parameter, valueToCheck);
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
                    if (curValue.Value < 0)
                    {
                        result[p] = fmResultCheckStatus.NEGATIVE;
                    }
                    else if (curValue.Value > p.chartDefaultXRange.maxValue)
                    {
                        result[p] = fmResultCheckStatus.GREATER_THAN_MAXIMUM;
                    }
                    else if (curValue.Value < p.chartDefaultXRange.minValue)
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
            Dictionary<fmGlobalParameter, fmValue> result1 = GetResultsWithSpecialParameterValue(parameter, x1);
            Dictionary<fmGlobalParameter, fmValue> result2 = GetResultsWithSpecialParameterValue(parameter, x2);
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
