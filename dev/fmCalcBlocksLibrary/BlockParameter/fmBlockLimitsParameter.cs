using System;
using System.Collections.Generic;
using System.Text;
using fmCalculationLibrary;

namespace fmCalcBlocksLibrary.BlockParameter
{
    public class fmBlockLimitsParameter
    {
        public fmGlobalParameter globalParameter;
        public fmBlockLimitParameter pMin;
        public fmBlockLimitParameter pMax;
        private bool isInputed;
        public fmBlockParameterGroup group;

        public bool IsInputed
        {
            get
            {
                return isInputed;
            }
            set
            {
                isInputed = value;
                if (pMin != null && pMin.cell != null)
                {
                    pMin.cell.Style.ForeColor = value ? System.Drawing.Color.Blue : System.Drawing.Color.Black;
                }
                if (pMax != null && pMax.cell != null)
                {
                    pMax.cell.Style.ForeColor = value ? System.Drawing.Color.Blue : System.Drawing.Color.Black;
                }
            }
        }

        public fmBlockLimitsParameter(fmGlobalParameter globalParameter)
        {
            this.globalParameter = globalParameter;
            isInputed = false;
            pMin = new fmBlockLimitParameter();
            pMax = new fmBlockLimitParameter();
        }
    }
}
