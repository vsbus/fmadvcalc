using System;

namespace fmCalcBlocksLibrary.BlockParameter
{
    public class fmBlockParameterEvetArgs : EventArgs
    {
        private readonly int parameterIndex;

        public fmBlockParameterEvetArgs(int parameterIndex)
        {
            this.parameterIndex = parameterIndex;
        }

        public int ParameterIndex 
        { 
            get
            {
                return parameterIndex;
            }
        }
    }
}