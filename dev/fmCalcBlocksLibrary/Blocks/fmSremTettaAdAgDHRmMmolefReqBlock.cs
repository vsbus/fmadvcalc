using System;
using System.Collections.Generic;
using System.Text;
using fmCalcBlocksLibrary.BlockParameter;
using System.Windows.Forms;
using fmCalculationLibrary;

namespace fmCalcBlocksLibrary.Blocks
{
    public class fmSremTettaAdAgDHRmMmolefReqBlock : fmBaseBlock
    {
        private readonly fmBlockVariableParameter Srem;
        private readonly fmBlockVariableParameter ad1;
        private readonly fmBlockVariableParameter ad2;
        private readonly fmBlockVariableParameter Tetta;
        private readonly fmBlockVariableParameter eta_g;
        private readonly fmBlockVariableParameter ag1;
        private readonly fmBlockVariableParameter ag2;
        private readonly fmBlockVariableParameter ag3;
        private readonly fmBlockVariableParameter Tetta_boil;
        private readonly fmBlockVariableParameter DH;
        private readonly fmBlockVariableParameter Mmole;
        private readonly fmBlockVariableParameter f;
        private readonly fmBlockVariableParameter peq;

        override public void DoCalculations()
        {
            //var fmSremTettaAdAgDHRmMmolefReqCalculator = new fmSremTettaAdAgDHRmMmolefReqCalculator(AllParameters);
            //fmSremTettaAdAgDHRmMmolefReqCalculator.DoCalculations();
        }

        // ReSharper disable InconsistentNaming
        public fmSremTettaAdAgDHRmMmolefReqBlock(
            DataGridViewCell Srem_Cell,
            DataGridViewCell ad1_Cell,
            DataGridViewCell ad2_Cell,
            DataGridViewCell Tetta_Cell,
            DataGridViewCell eta_g_Cell,
            DataGridViewCell ag1_Cell,
            DataGridViewCell ag2_Cell,
            DataGridViewCell ag3_Cell,
            DataGridViewCell Tetta_boil_Cell,
            DataGridViewCell DH_Cell,
            DataGridViewCell Mmole_Cell,
            DataGridViewCell f_Cell,
            DataGridViewCell peq_Cell)
        // ReSharper restore InconsistentNaming
        {
            AddParameter(ref Srem, fmGlobalParameter.Srem, Srem_Cell, true);
            AddParameter(ref ad1, fmGlobalParameter.ad1, ad1_Cell, true);
            AddParameter(ref ad2, fmGlobalParameter.ad2, ad2_Cell, true);
            AddParameter(ref Tetta, fmGlobalParameter.Tetta, Tetta_Cell, true);
            AddParameter(ref eta_g, fmGlobalParameter.eta_g, eta_g_Cell, true);
            AddParameter(ref ag1, fmGlobalParameter.ag1, ag1_Cell, true);
            AddParameter(ref ag2, fmGlobalParameter.ag2, ag2_Cell, true);
            AddParameter(ref ag3, fmGlobalParameter.ag3, ag3_Cell, true);
            AddParameter(ref Tetta_boil, fmGlobalParameter.Tetta_boil, Tetta_boil_Cell, true);
            AddParameter(ref DH, fmGlobalParameter.DH, DH_Cell, true);
            AddParameter(ref Mmole, fmGlobalParameter.Mmole, Mmole_Cell, true);
            AddParameter(ref f, fmGlobalParameter.f, f_Cell, true);
            AddParameter(ref peq, fmGlobalParameter.peq, peq_Cell, true);

            processOnChange = true;
        }
        public fmSremTettaAdAgDHRmMmolefReqBlock() : this(null, null, null, null, null, null, null, null, null, null, null, null, null) { }
    }
}
