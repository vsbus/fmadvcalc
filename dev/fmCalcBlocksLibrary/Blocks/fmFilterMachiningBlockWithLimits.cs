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

                    double coef = parameters[i].globalParameter.unitFamily.CurrentUnit.Coef;
                    DataGridViewCell minLimitCell = parameters[i].cell.DataGridView[parameters[i].cell.ColumnIndex - 1, parameters[i].cell.RowIndex];
                    DataGridViewCell maxLimitCell = parameters[i].cell.DataGridView[parameters[i].cell.ColumnIndex + 1, parameters[i].cell.RowIndex];

                    if (parameters[i].group == null)
                    {
                        string LimitsString = (parameters[i].globalParameter.chartDefaultXRange.minValue / coef).ToString() + " " + (parameters[i].globalParameter.chartDefaultXRange.maxValue / coef).ToString();
                        parameters[i].cell.DataGridView[parameters[i].cell.ColumnIndex + 2, parameters[i].cell.RowIndex].Value = LimitsString;
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
                        string newValLeft = parameters[i].group == null ? "" : (minValue / coef).ToString();
                        string newValRight = parameters[i].group == null ? "" : (maxValue / coef).ToString();

                        parameters[i].cell.DataGridView[parameters[i].cell.ColumnIndex + 2, parameters[i].cell.RowIndex].Value = "";
                        minLimitCell.Value = newValLeft;
                        maxLimitCell.Value = newValRight;

                        if (minValue > parameters[i].value
                            || maxValue < parameters[i].value)
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
