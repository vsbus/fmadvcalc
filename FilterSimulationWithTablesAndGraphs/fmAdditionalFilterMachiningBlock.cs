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
                                                DataGridViewCell hc_over_tf_Cell,
                                                DataGridViewCell dhc_over_dt_Cell,
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
                                                DataGridViewCell Qf_Cell,
                                                DataGridViewCell Qf_d_Cell,
                                                DataGridViewCell Qs_Cell,
                                                DataGridViewCell Qs_d_Cell,
                                                DataGridViewCell Qc_Cell,
                                                DataGridViewCell Qc_d_Cell,
                                                DataGridViewCell Qsus_Cell,
                                                DataGridViewCell Qsus_d_Cell,
                                                DataGridViewCell Qmsus_Cell,
                                                DataGridViewCell Qmsus_d_Cell,
                                                DataGridViewCell Qms_Cell,
                                                DataGridViewCell Qms_d_Cell,
                                                DataGridViewCell Qmf_Cell,
                                                DataGridViewCell Qmf_d_Cell,
                                                DataGridViewCell Qmc_Cell,
                                                DataGridViewCell Qmc_d_Cell,
                                                DataGridViewCell qf_Cell,
                                                DataGridViewCell qf_d_Cell,
                                                DataGridViewCell qs_Cell,
                                                DataGridViewCell qs_d_Cell,
                                                DataGridViewCell qc_Cell,
                                                DataGridViewCell qc_d_Cell,
                                                DataGridViewCell qsus_Cell,
                                                DataGridViewCell qsus_d_Cell,
                                                DataGridViewCell qmsus_Cell,
                                                DataGridViewCell qmsus_d_Cell,
                                                DataGridViewCell qms_Cell,
                                                DataGridViewCell qms_d_Cell,
                                                DataGridViewCell qmf_Cell,
                                                DataGridViewCell qmf_d_Cell,
                                                DataGridViewCell qmc_Cell,
                                                DataGridViewCell qmc_d_Cell,
                                                DataGridViewCell eps_Cell,
                                                DataGridViewCell kappa_Cell,
                                                DataGridViewCell Pc_Cell,
                                                DataGridViewCell rc_Cell,
                                                DataGridViewCell a_Cell) : base(calculationOptionView, A_Cell, Dp_Cell, sf_Cell, n_Cell, tc_Cell, tf_Cell, tr_Cell, hc_over_tf_Cell, dhc_over_dt_Cell, hc_Cell, Mf_Cell, Vf_Cell, mf_Cell, vf_Cell, ms_Cell, vs_Cell, msus_Cell, vsus_Cell, mc_Cell, vc_Cell,
                                                                                Msus_Cell, Vsus_Cell, Vc_Cell, Mc_Cell, Ms_Cell, Vs_Cell, Qf_Cell, Qf_d_Cell, Qs_Cell, Qs_d_Cell, Qc_Cell, Qc_d_Cell, Qsus_Cell, Qsus_d_Cell, Qmsus_Cell, Qmsus_d_Cell, Qms_Cell, Qms_d_Cell, Qmf_Cell, Qmf_d_Cell, Qmc_Cell, 
                                                                                Qmc_d_Cell, qf_Cell, qf_d_Cell, qs_Cell, qs_d_Cell, qc_Cell, qc_d_Cell, qsus_Cell, qsus_d_Cell, qmsus_Cell, qmsus_d_Cell, qms_Cell, qms_d_Cell, qmf_Cell, qmf_d_Cell, qmc_Cell, qmc_d_Cell, eps_Cell, kappa_Cell, Pc_Cell, rc_Cell, a_Cell)
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