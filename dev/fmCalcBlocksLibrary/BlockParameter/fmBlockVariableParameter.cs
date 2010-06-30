using System.Windows.Forms;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary.BlockParameter
{
    public class fmBlockVariableParameter : fmCalculatorsLibrary.fmCalculationVariableParameter
    {
        /// <summary>
        /// cell where user can see a value of parameter or 
        /// enter a new value
        /// </summary>
        public DataGridViewCell cell;

        /// <summary>
        /// group containes several parameters where 
        /// one of them must be inputed and all others
        /// are calculated
        /// </summary>
        public fmBlockParameterGroup group;


        //private bool m_isInputed;
        public bool isInputed
        {
            get
            {
                return base.isInputed;
            }
            set
            {
                base.isInputed = value;
                if (cell != null)
                {
                    cell.Style.ForeColor = value ? System.Drawing.Color.Blue : System.Drawing.Color.Black;
                }
            }
        }

        public fmBlockVariableParameter(fmGlobalParameter globalParameter,
                                bool isInputedDefault) : base (globalParameter)
        {
            this.group = null;
            this.cell = null;
            isInputed = isInputedDefault;
        }
    }
}