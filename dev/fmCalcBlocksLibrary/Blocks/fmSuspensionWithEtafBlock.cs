using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmSuspensionWithEtafBlock : fmSuspensionBlock
    {
        // ReSharper disable InconsistentNaming
        private readonly fmBlockVariableParameter eta_f;

        public fmValue eta_f_Value
        {
            get { return eta_f.value; }
            set { eta_f.value = value; }
        }

        public fmSuspensionWithEtafBlock(
            DataGridViewCell eta_f_Cell,
            DataGridViewCell rho_f_Cell,
            DataGridViewCell rho_s_Cell,
            DataGridViewCell rho_sus_Cell,
            DataGridViewCell Cm_Cell,
            DataGridViewCell Cv_Cell,
            DataGridViewCell C_Cell)
            : base(rho_f_Cell, rho_s_Cell, rho_sus_Cell, Cm_Cell, Cv_Cell, C_Cell)
        {
            AddParameter(ref eta_f, fmGlobalParameter.eta_f, eta_f_Cell, true);
        }
        // ReSharper restore InconsistentNaming
    }
}