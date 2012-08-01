using System;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using System.Collections.Generic;
using System.Drawing;
using fmCalculatorsLibrary;
using fmCalcBlocksLibrary.Blocks.LimitsCalcs;

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

        override public void DoCalculationsLimitsClue()
        {
            var filterMachinigCalculator =
                new fmFilterMachiningCalculator(AllParameters) {calculationOption = filterMachiningCalculationOption};
            filterMachinigCalculator.DoCalculationsLimitsClue();
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
                                ? new fmValue(naInputs[j].globalParameter.ValidRange.MaxValue)
                                : new fmValue(naInputs[j].globalParameter.ValidRange.MinValue));
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
                double coef = parameter.globalParameter.UnitFamily.CurrentUnit.Coef;

                dataGrid[colIndex - 2, rowIndex].Value = parameter.globalParameter.ValidRange.MinValue / coef;
                dataGrid[colIndex + 2, rowIndex].Value = parameter.globalParameter.ValidRange.MaxValue / coef;

                DataGridViewCell minLimitCell = dataGrid[colIndex - 1, rowIndex];
                DataGridViewCell maxLimitCell = dataGrid[colIndex + 1, rowIndex];

                if (parameter.group == null)
                {
                    minLimitCell.Value = "";
                    maxLimitCell.Value = "";

                    if (fmValue.Greater(new fmValue(parameter.globalParameter.ValidRange.MinValue), parameter.value)
                        || fmValue.Less(new fmValue(parameter.globalParameter.ValidRange.MaxValue), parameter.value))
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

        private void GetMinMaxLimitsOfIncompleteInputs(fmBlockVariableParameter parameter, out fmValue minValue, out fmValue maxValue)
        {
            if (filterMachiningCalculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_DP_CONST
                || filterMachiningCalculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_QP_CONST
                || filterMachiningCalculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_CENTRIPETAL_PUMP_QP_DP_CONST
                || filterMachiningCalculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_VOLUMETRIC_PUMP_QP_CONST
                || filterMachiningCalculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.CYLINDRICAL_DP_CONST
                || filterMachiningCalculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.CYLINDRICAL_QP_CONST
                || filterMachiningCalculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.CYLINDRICAL_CENTRIPETAL_PUMP_QP_DP_CONST
                || filterMachiningCalculationOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.CYLINDRICAL_VOLUMETRIC_PUMP_QP_CONST)
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
                        double minVal = p.globalParameter.ValidRange.MinValue;
                        double maxVal = p.globalParameter.ValidRange.MaxValue;
                        const double eps = 1e-8;
                        minVal = minVal == 0 ? Math.Min(maxVal, 1) * eps : minVal * (1 + eps);
                        maxVal = maxVal * (1 - eps);
                        p.value = new fmValue((mask & (1 << i)) == 0 ? minVal : maxVal);
                    }

                    fmValue curMin, curMax;
                    if (fmLimitsBlockCalcs.GetMinMaxLimits(parameter, out curMin, out curMax, this))
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
                naInputs.Remove(fmLimitsBlockCalcs.FindGroupRepresetator(parameters, parameter.group));
                bool result = false;
                minValue = maxValue = new fmValue();

                for (int mask = 0; mask < (1 << naInputs.Count); ++mask)
                {
                    for (int i = 0; i < naInputs.Count; ++i)
                    {
                        fmBlockVariableParameter p = naInputs[i];
                        double minVal = p.globalParameter.ValidRange.MinValue;
                        double maxVal = p.globalParameter.ValidRange.MaxValue;
                        const double eps = 1e-8;
                        minVal = minVal == 0 ? Math.Min(maxVal, 1) * eps : minVal * (1 + eps);
                        maxVal = maxVal * (1 - eps);
                        p.value = new fmValue((mask & (1 << i)) == 0 ? minVal : maxVal);
                    }

                    fmValue curMin, curMax;
                    if (fmLimitsBlockCalcs.GetMinMaxLimits(parameter, out curMin, out curMax, this))
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
        override public List<fmBlockVariableParameter> GetClueParamsList()
        {
            var clueParams = new List<fmBlockVariableParameter>(new fmBlockVariableParameter[] {
                    GetParameterByName(fmGlobalParameter.A.Name),
                    GetParameterByName(fmGlobalParameter.Dp.Name),
                    GetParameterByName(fmGlobalParameter.hc.Name),
                    GetParameterByName(fmGlobalParameter.tc.Name),
                    GetParameterByName(fmGlobalParameter.n.Name),
                    GetParameterByName(fmGlobalParameter.tf.Name),
                    GetParameterByName(fmGlobalParameter.sf.Name),
                    GetParameterByName(fmGlobalParameter.sr.Name),
                    GetParameterByName(fmGlobalParameter.tr.Name)
                });
            
            var d0 = GetParameterByName(fmGlobalParameter.d0.Name);
            if (d0.group != null)
            {
                clueParams.Add(d0);
            }
            
            var t1 = GetParameterByName(fmGlobalParameter.t1.Name);
            if (t1.group != null)
            {
                clueParams.Add(t1);
            }
            
            return clueParams;
        }
        private void CalculateAbsRanges()
        {
            var varList = new List<fmGlobalParameter>();
            foreach (var p in fmGlobalParameter.Parameters)
            {
                if (p.SpecifiedRange.IsInputed)
                {
                    p.ValidRange.MinValue = p.SpecifiedRange.MinValue;
                    p.ValidRange.MaxValue = p.SpecifiedRange.MaxValue;
                    if (GetParameterByName(p.Name) != null)
                    {
                        varList.Add(p);
                    }
                }
            }
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
                        p.globalParameter.ValidRange.MinValue = 1e100;
                        p.globalParameter.ValidRange.MaxValue = -1e100;
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
                        ? new fmValue(varList[i].ValidRange.MaxValue) 
                        : new fmValue(varList[i].ValidRange.MinValue);
                }
                calc.DoCalculations();
                foreach (fmCalculationBaseParameter p in pList)
                {
                    if (p is fmCalculationVariableParameter 
                        && machineAdditionalParams.Contains(p.globalParameter) == false)
                    {
                        if (p.value.defined && p.globalParameter.ValidRange.MaxValue < p.value.value)
                            p.globalParameter.ValidRange.MaxValue = p.value.value;
                        if (p.value.defined && p.globalParameter.ValidRange.MinValue > p.value.value)
                            p.globalParameter.ValidRange.MinValue = Math.Max(0, p.value.value);
                    }
                }
            }
        }

        private List<fmBlockVariableParameter> GetNAInputsList(fmBlockVariableParameter parameter)
        {
            var naInputs = new List<fmBlockVariableParameter>();
            CheckNAAndAdd(GetParameterByName(fmGlobalParameter.A.Name), naInputs);
            CheckNAAndAdd(GetParameterByName(fmGlobalParameter.Dp.Name), naInputs);
            CheckNAAndAdd(GetParameterByName(fmGlobalParameter.sf.Name), naInputs);
            CheckNAAndAdd(GetParameterByName(fmGlobalParameter.tc.Name), naInputs);
            var d0 = GetParameterByName(fmGlobalParameter.d0.Name);
            if (d0.group != null)
            {
                CheckNAAndAdd(d0, naInputs);
            }
            naInputs.Remove(fmLimitsBlockCalcs.FindGroupRepresetator(parameters, parameter.group));
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
            if (p.group != null && fmLimitsBlockCalcs.FindGroupRepresetator(parameters, p.group).value.defined == false)
            {
                naInputs.Add(p);
                UpdateIsInputed(p);
            }
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
    }
}
