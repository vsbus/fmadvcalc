using System;

namespace fmCalcBlocksLibrary.BlockParameter
{
    public class fmBlockParameterEventArgs : EventArgs
    {
        private readonly int m_parameterIndex;

        public fmBlockParameterEventArgs(int parameterIndex)
        {
            this.m_parameterIndex = parameterIndex;
        }

        public int ParameterIndex 
        { 
            get
            {
                return m_parameterIndex;
            }
        }
    }
}