using System;
using System.Collections.Generic;
using System.Text;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;

namespace fmCalcBlocksLibrary.Blocks.LimitsCalcs
{
    public class fmParametersLimitsCalculator
    {
        static public fmValue GetEdgeValue(double minVal, double maxVal, bool calculateMin)
        {
            return new fmValue(calculateMin ? minVal : maxVal);
        }

        static public fmValue GetEdgeValue(fmBlockVariableParameter p, bool calculateMin)
        {
            double minVal = p.globalParameter.ValidRange.MinValue;
            double maxVal = p.globalParameter.ValidRange.MaxValue;
            return GetEdgeValue(minVal, maxVal, calculateMin);
        }

        static public void Calculate(
            fmIBlockWithLimits iBlock,
            IEnumerable<fmBlockVariableParameter> clueParams,
            Dictionary<fmGlobalParameter, fmValue> minValue,
            Dictionary<fmGlobalParameter, fmValue> maxValue)
        {
            foreach (fmBlockVariableParameter clueParameter in clueParams)
            {
                List<fmValue> keepedValues;
                List<fmBlockVariableParameter> keepedInputInfo;
                iBlock.KeepValuesAndInputInfo(out keepedValues, out keepedInputInfo);
                iBlock.UpdateIsInputed(clueParameter);

                var naInputs = iBlock.GetNAInputsList(clueParameter);

                for (int i = 0; i < 2; ++i)
                {
                    clueParameter.value = GetEdgeValue(minValue[clueParameter.globalParameter].value,
                                                       maxValue[clueParameter.globalParameter].value,
                                                       i == 0);
                    for (int mask = 0; mask < (1 << naInputs.Count); ++mask)
                    {
                        for (int j = 0; j < naInputs.Count; ++j)
                        {
                            naInputs[j].value = GetEdgeValue(naInputs[j], (mask & (1 << j)) == 0);
                        }

                        iBlock.DoCalculations();

                        var valuesOfClueParameters = new Dictionary<fmGlobalParameter, fmValue>();
                        foreach (fmBlockVariableParameter parameter in clueParams)
                        {
                            valuesOfClueParameters.Add(parameter.globalParameter, parameter.value);
                        }
                        if (!fmLimitsBlockCalcs.IsGoodResultStatus(fmLimitsBlockCalcs.GetResultStatus(valuesOfClueParameters)))
                        {
                            continue;
                        }

                        foreach (fmBlockVariableParameter parameter in iBlock.GetParameters())
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
                                if (!minValue[p].defined
                                    || parameter.value.defined && minValue[p] > parameter.value)
                                {
                                    minValue[p] = parameter.value;
                                }
                                if (!maxValue[p].defined
                                    || parameter.value.defined && maxValue[p] < parameter.value)
                                {
                                    maxValue[p] = parameter.value;
                                }
                            }
                        }
                    }
                }
                iBlock.RestoreValuesAndInputInfo(keepedValues, keepedInputInfo);
            }
        }
    }
}
