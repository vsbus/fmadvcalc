using System.Windows.Forms;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace fmCalcBlocksLibrary.BlockParameter
{
    public class fmBlockParameter
    {
        public string name;
        public DataGridViewCell cell;
        public fmUnitFamily unitFamily;
        public fmGlobalParameter globalParameter;
        public fmValue value;
        public fmBlockParameterGroup group;
        private bool m_isInputed;
        public bool isInputed
        {
            get
            {
                return m_isInputed;
            }
            set
            {
                m_isInputed = value;
                if (cell != null)
                {
                    cell.Style.ForeColor = value ? System.Drawing.Color.Blue : System.Drawing.Color.Black;
                }
            }
        }

        public fmBlockParameter(fmGlobalParameter globalParameter,
                                DataGridViewCell cell,
                                bool isInputedDefault)
        {
            name = globalParameter.Name;
            this.group = null;
            this.cell = cell;
            unitFamily = globalParameter.unitFamily;
            this.globalParameter = globalParameter;
            isInputed = isInputedDefault;
        }
    }
}