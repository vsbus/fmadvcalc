using System;
using System.Collections.Generic;
using System.Text;
using fmCalcBlocksLibrary.Blocks;
using fmCalcBlocksLibrary.Controls;
using System.Windows.Forms;

namespace FilterSimulationWithTablesAndGraphs
{
    public class fmAdditionalFilterMachiningBlock: fmFilterMachiningBlock
    {
        public bool IsDrawn = true;
        
        public fmAdditionalFilterMachiningBlock(bool isDrawn, fmCalculationOptionView calculationOptionView,
                                                DataGridViewCell A_Cell,
                                                DataGridViewCell Dp_Cell,
                                                DataGridViewCell sf_Cell,
                                                DataGridViewCell n_Cell,
                                                DataGridViewCell tc_Cell,
                                                DataGridViewCell tf_Cell,
                                                DataGridViewCell tr_Cell,
                                                DataGridViewCell hc_tf_Cell,
                                                DataGridViewCell dhc_dt_Cell,
                                                DataGridViewCell hc_Cell,
                                                DataGridViewCell Mf_Cell,
                                                DataGridViewCell Vf_Cell,
                                                DataGridViewCell mf_Cell,
                                                DataGridViewCell vf_Cell,
                                                DataGridViewCell ms_Cell,
                                                DataGridViewCell vs_Cell,
                                                DataGridViewCell msus_Cell,
                                                DataGridViewCell vsus_Cell,
                                                DataGridViewCell mc_Cell,
                                                DataGridViewCell vc_Cell,
                                                DataGridViewCell Msus_Cell,
                                                DataGridViewCell Vsus_Cell,
                                                DataGridViewCell Vc_Cell,
                                                DataGridViewCell Mc_Cell,
                                                DataGridViewCell Ms_Cell,
                                                DataGridViewCell Vs_Cell,
                                                DataGridViewCell Qsus_Cell,
                                                DataGridViewCell Qmsus_Cell,
                                                DataGridViewCell Qms_Cell,
                                                DataGridViewCell eps_Cell,
                                                DataGridViewCell kappa_Cell,
                                                DataGridViewCell Pc_Cell,
                                                DataGridViewCell rc_Cell,
                                                DataGridViewCell a_Cell) : base(calculationOptionView, A_Cell, Dp_Cell, sf_Cell, n_Cell, tc_Cell, tf_Cell, tr_Cell, hc_tf_Cell, dhc_dt_Cell, hc_Cell, Mf_Cell, Vf_Cell, mf_Cell, vf_Cell, ms_Cell, vs_Cell, msus_Cell, vsus_Cell, mc_Cell, vc_Cell,
                                                                                Msus_Cell, Vsus_Cell, Vc_Cell, Mc_Cell, Ms_Cell, Vs_Cell, Qsus_Cell, Qmsus_Cell, Qms_Cell, eps_Cell, kappa_Cell, Pc_Cell,
                                                                                rc_Cell, a_Cell)
        {
            IsDrawn = isDrawn;
        }

        public fmAdditionalFilterMachiningBlock(bool isDrawn, fmCalculationOptionView calculationOptionView)
            : base(calculationOptionView)
        {
            IsDrawn = isDrawn;
        }
    }

    public class fmSelectedFilterMachiningBlock
    {
        public bool IsChecked = true;
        public fmFilterMachiningBlock filterMachiningBlock;
    }
}