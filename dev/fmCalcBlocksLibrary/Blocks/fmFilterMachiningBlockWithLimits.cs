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
            LESS_THAN_MINIMUM,
            GREATER_THAN_MAXIMUM,
            INSIDE_RANGE
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
                        fmValue minValue = GetMinLimit(parameters[i]);
                        fmValue maxValue = GetMaxLimit(parameters[i]);
                        if (minValue.Value > maxValue.Value)
                        {
                            minValue = maxValue = new fmValue();
                        }
                        string newValLeft = parameters[i].group == null ? "" : (minValue / coef).ToString();
                        string newValRight = parameters[i].group == null ? "" : (maxValue / coef).ToString();

                        minLimitCell.Value = newValLeft;
                        maxLimitCell.Value = newValRight;

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

                processOnChange = true;
            }
        }

        private fmValue GetFirstOKValue(fmBlockVariableParameter parameter,
            List<fmValue> valuesToCheck)
        {
            fmBlockVariableParameter groupInput = FindGroupRepresetator(parameter.group);
            fmValue groupInputInitialValue = groupInput.value;
            groupInput.isInputed = false;
            parameter.isInputed = true;

            fmValue result = new fmValue();
            for (int i = 0; i < valuesToCheck.Count; ++i)
            {
                parameter.value = valuesToCheck[i];


                List<fmBlockVariableParameter> listOfNAInputs = GetNAInputsList();
                listOfNAInputs.Remove(parameter);

                if (listOfNAInputs.Count != 0)
                {
                    for (int mask = 0; mask < (1 << listOfNAInputs.Count); ++mask)
                    {
                        for (int t = 0; t < listOfNAInputs.Count; ++t)
                        {
                            double a = listOfNAInputs[t].globalParameter.chartDefaultXRange.minValue;
                            double b = listOfNAInputs[t].globalParameter.chartDefaultXRange.maxValue;
                            double eps = 1e-9 * (b - a);

                            if ((mask & (1 << t)) == 0)
                            {
                                listOfNAInputs[t].value = new fmValue(a + eps);
                            }
                            else
                            {
                                listOfNAInputs[t].value = new fmValue(b - eps);
                            }
                        }

                        DoCalculations();
                        if (IsParametersInRanges())
                        {
                            result = parameter.value;
                            break;
                        }
                    }
                }
                else
                {
                    DoCalculations();
                    if (IsParametersInRanges())
                    {
                        result = parameter.value;
                        break;
                    }
                }

                foreach (fmBlockVariableParameter p in listOfNAInputs)
                {
                    p.value = new fmValue();
                }

                if (result.Defined == true)
                {
                    break;
                }
            }

            parameter.isInputed = false;
            groupInput.value = groupInputInitialValue;
            groupInput.isInputed = true;

            DoCalculations();

            return result;
        }

        private List<fmBlockVariableParameter> GetNAInputsList()
        {
            List<fmBlockVariableParameter> result = new List<fmBlockVariableParameter>();
            foreach (fmBlockVariableParameter p in parameters)
            {
                if (p.group != null && p.isInputed && p.value.Defined == false)
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

        private Dictionary<fmGlobalParameter, fmResultCheckStatus> GetResultStatus(fmBlockVariableParameter parameter, double valueToCheck)
        {
            Dictionary<fmGlobalParameter, fmResultCheckStatus> result = new Dictionary<fmGlobalParameter, fmResultCheckStatus>();

            fmBlockVariableParameter groupInput = FindGroupRepresetator(parameter.group);
            fmValue groupInputInitialValue = groupInput.value;
            groupInput.isInputed = false;
            parameter.isInputed = true;

            parameter.value = new fmValue(valueToCheck);

            DoCalculations();

            foreach (fmBlockVariableParameter p in parameters)
            {
                fmGlobalParameter gParam = p.globalParameter;
                if (p.value.Defined == false)
                {
                    result[gParam] = fmResultCheckStatus.N_A;
                }
                else
                {
                    if (p.value.Value > gParam.chartDefaultXRange.maxValue)
                    {
                        result[gParam] = fmResultCheckStatus.GREATER_THAN_MAXIMUM;
                    }
                    else if (p.value.Value < gParam.chartDefaultXRange.minValue)
                    {
                        result[gParam] = fmResultCheckStatus.LESS_THAN_MINIMUM;
                    }
                    else
                    {
                        result[gParam] = fmResultCheckStatus.INSIDE_RANGE;
                    }
                }
            }
            
            parameter.isInputed = false;
            groupInput.value = groupInputInitialValue;
            groupInput.isInputed = true;

            DoCalculations();

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
                if (p.group == group && p.isInputed == true)
                {
                    return p;
                }
            }
            return null;
        }

        private bool IsParametersInRanges()
        {
            foreach (fmCalcBlocksLibrary.BlockParameter.fmBlockVariableParameter p in parameters)
            {
                if (p.value.Defined == false
                    || fmValue.Less(p.value, new fmValue(p.globalParameter.chartDefaultXRange.minValue))
                    || fmValue.Greater(p.value, new fmValue(p.globalParameter.chartDefaultXRange.maxValue)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
