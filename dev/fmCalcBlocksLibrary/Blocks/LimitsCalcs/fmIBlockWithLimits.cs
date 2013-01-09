using System;
using System.Collections.Generic;
using System.Text;
using fmCalcBlocksLibrary.BlockParameter;

namespace fmCalcBlocksLibrary.Blocks.LimitsCalcs
{
    public interface fmIBlockWithLimits
    {
        void KeepValuesAndInputInfo(
            out List<fmCalculationLibrary.fmValue> keepedValues,
            out List<BlockParameter.fmBlockVariableParameter> keepedInputInfo);

        void UpdateIsInputed(BlockParameter.fmBlockVariableParameter clueParameter);

        List<fmBlockVariableParameter> GetNAInputsList(BlockParameter.fmBlockVariableParameter clueParameter);

        void RestoreValuesAndInputInfo(List<fmCalculationLibrary.fmValue> keepedValues, List<fmCalcBlocksLibrary.BlockParameter.fmBlockVariableParameter> keepedInputInfo);

        void DoCalculations();

        IEnumerable<fmBlockVariableParameter> GetParameters();
    }
}
