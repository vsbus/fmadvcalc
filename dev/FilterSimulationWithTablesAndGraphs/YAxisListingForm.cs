using System;
using System.Collections.Generic;
using System.Windows.Forms;
using fmCalculationLibrary;
using fmControls;

namespace FilterSimulationWithTablesAndGraphs
{
    public partial class fmYAxisListingForm : Form
    {
        private readonly Dictionary<fmGlobalParameter, fmControls.fmCheckedListBoxWithCheckboxes> m_parameterBox = new Dictionary<fmGlobalParameter, fmCheckedListBoxWithCheckboxes>();

        public fmYAxisListingForm()
        {
            InitializeComponent();

            AddParameter(massBox, fmGlobalParameter.Mf);
            AddParameter(massBox, fmGlobalParameter.Ms);
            AddParameter(massBox, fmGlobalParameter.Msus);
            AddParameter(massBox, fmGlobalParameter.Mc);

            AddParameter(volumeBox, fmGlobalParameter.Vf);
            AddParameter(volumeBox, fmGlobalParameter.Vs);
            AddParameter(volumeBox, fmGlobalParameter.Vsus);
            AddParameter(volumeBox, fmGlobalParameter.Vc);

            AddParameter(mBox, fmGlobalParameter.mf);
            AddParameter(mBox, fmGlobalParameter.ms);
            AddParameter(mBox, fmGlobalParameter.msus);
            AddParameter(mBox, fmGlobalParameter.mc);

            AddParameter(vBox, fmGlobalParameter.vf);
            AddParameter(vBox, fmGlobalParameter.vs);
            AddParameter(vBox, fmGlobalParameter.vsus);
            AddParameter(vBox, fmGlobalParameter.vc);

            AddParameter(qmBigBox, fmGlobalParameter.Qmf);
            AddParameter(qmBigBox, fmGlobalParameter.Qms);
            AddParameter(qmBigBox, fmGlobalParameter.Qmsus);
            AddParameter(qmBigBox, fmGlobalParameter.Qmc);

            AddParameter(qBigBox, fmGlobalParameter.Qf);
            AddParameter(qBigBox, fmGlobalParameter.Qs);
            AddParameter(qBigBox, fmGlobalParameter.Qsus);
            AddParameter(qBigBox, fmGlobalParameter.Qc);

            AddParameter(qmSmallBox, fmGlobalParameter.qmf);
            AddParameter(qmSmallBox, fmGlobalParameter.qms);
            AddParameter(qmSmallBox, fmGlobalParameter.qmsus);
            AddParameter(qmSmallBox, fmGlobalParameter.qmc);

            AddParameter(qSmallBox, fmGlobalParameter.qf);
            AddParameter(qSmallBox, fmGlobalParameter.qs);
            AddParameter(qSmallBox, fmGlobalParameter.qsus);
            AddParameter(qSmallBox, fmGlobalParameter.qc);

            AddParameter(qmBigBox_dif, fmGlobalParameter.Qmf_d);
            AddParameter(qmBigBox_dif, fmGlobalParameter.Qms_d);
            AddParameter(qmBigBox_dif, fmGlobalParameter.Qmsus_d);
            AddParameter(qmBigBox_dif, fmGlobalParameter.Qmc_d);

            AddParameter(qBigBox_dif, fmGlobalParameter.Qf_d);
            AddParameter(qBigBox_dif, fmGlobalParameter.Qs_d);
            AddParameter(qBigBox_dif, fmGlobalParameter.Qsus_d);
            AddParameter(qBigBox_dif, fmGlobalParameter.Qc_d);

            AddParameter(qmSmallBox_dif, fmGlobalParameter.qmf_d);
            AddParameter(qmSmallBox_dif, fmGlobalParameter.qms_d);
            AddParameter(qmSmallBox_dif, fmGlobalParameter.qmsus_d);
            AddParameter(qmSmallBox_dif, fmGlobalParameter.qmc_d);

            AddParameter(qSmallBox_dif, fmGlobalParameter.qf_d);
            AddParameter(qSmallBox_dif, fmGlobalParameter.qs_d);
            AddParameter(qSmallBox_dif, fmGlobalParameter.qsus_d);
            AddParameter(qSmallBox_dif, fmGlobalParameter.qc_d);

            AddParameter(ad0DpBox, fmGlobalParameter.A);
            AddParameter(ad0DpBox, fmGlobalParameter.d0);
            AddParameter(ad0DpBox, fmGlobalParameter.Dp);

            AddParameter(sfSrTrBox, fmGlobalParameter.sf);
            AddParameter(sfSrTrBox, fmGlobalParameter.sr);
            AddParameter(sfSrTrBox, fmGlobalParameter.tr);

            AddParameter(nTcTfBox, fmGlobalParameter.n);
            AddParameter(nTcTfBox, fmGlobalParameter.tc);
            AddParameter(nTcTfBox, fmGlobalParameter.tf);

            AddParameter(hcBox, fmGlobalParameter.hc);
            AddParameter(hcBox, fmGlobalParameter.hc_over_tf);
            AddParameter(hcBox, fmGlobalParameter.dhc_over_dt);

            AddParameter(epsKappaBox, fmGlobalParameter.eps);
            AddParameter(epsKappaBox, fmGlobalParameter.kappa);
            AddParameter(epsKappaBox, fmGlobalParameter.Pc);
            AddParameter(epsKappaBox, fmGlobalParameter.rc);
            AddParameter(epsKappaBox, fmGlobalParameter.a);
            AddParameter(epsKappaBox, fmGlobalParameter.Rm);

            AddParameter(DpQpConstBox, fmGlobalParameter.t1);
            AddParameter(DpQpConstBox, fmGlobalParameter.h1);
            AddParameter(DpQpConstBox, fmGlobalParameter.t1_over_tf);
            AddParameter(DpQpConstBox, fmGlobalParameter.h1_over_hc);

            AddParameter(deliquoringBox, fmGlobalParameter.Dp_d);
            AddParameter(deliquoringBox, fmGlobalParameter.hcd);
            AddParameter(deliquoringBox, fmGlobalParameter.eps_d);
            AddParameter(deliquoringBox, fmGlobalParameter.eta_d);
            AddParameter(deliquoringBox, fmGlobalParameter.rho_d);
            AddParameter(deliquoringBox, fmGlobalParameter.sigma);
            AddParameter(deliquoringBox, fmGlobalParameter.pke0);
            AddParameter(deliquoringBox, fmGlobalParameter.pke);
            AddParameter(deliquoringBox, fmGlobalParameter.pc_d);
            AddParameter(deliquoringBox, fmGlobalParameter.rc_d);
            AddParameter(deliquoringBox, fmGlobalParameter.alpha_d);
            AddParameter(deliquoringBox, fmGlobalParameter.Srem);
            AddParameter(deliquoringBox, fmGlobalParameter.ad1);
            AddParameter(deliquoringBox, fmGlobalParameter.ad2);
            AddParameter(deliquoringBox, fmGlobalParameter.Tetta);
            AddParameter(deliquoringBox, fmGlobalParameter.eta_g);
            AddParameter(deliquoringBox, fmGlobalParameter.ag1);
            AddParameter(deliquoringBox, fmGlobalParameter.ag2);
            AddParameter(deliquoringBox, fmGlobalParameter.ag3);
            AddParameter(deliquoringBox, fmGlobalParameter.Tetta_boil);
            AddParameter(deliquoringBox, fmGlobalParameter.DH);
            AddParameter(deliquoringBox, fmGlobalParameter.Mmole);
            AddParameter(deliquoringBox, fmGlobalParameter.f);
            AddParameter(deliquoringBox, fmGlobalParameter.peq);

            AddParameter(deliquoringBox, fmGlobalParameter.hcd);
            AddParameter(deliquoringBox, fmGlobalParameter.sd);
            AddParameter(deliquoringBox, fmGlobalParameter.td);
            AddParameter(deliquoringBox, fmGlobalParameter.K);
            AddParameter(deliquoringBox, fmGlobalParameter.Smech);
            AddParameter(deliquoringBox, fmGlobalParameter.S);
            AddParameter(deliquoringBox, fmGlobalParameter.Rfmech);
            AddParameter(deliquoringBox, fmGlobalParameter.Rf);
            AddParameter(deliquoringBox, fmGlobalParameter.Qgi);
            AddParameter(deliquoringBox, fmGlobalParameter.Qg);
            AddParameter(deliquoringBox, fmGlobalParameter.vg);
            AddParameter(deliquoringBox, fmGlobalParameter.Mfd);
            AddParameter(deliquoringBox, fmGlobalParameter.Vfd);
            AddParameter(deliquoringBox, fmGlobalParameter.Mlcd);
            AddParameter(deliquoringBox, fmGlobalParameter.Vlcd);
            AddParameter(deliquoringBox, fmGlobalParameter.Mcd);
            AddParameter(deliquoringBox, fmGlobalParameter.Vcd);
            AddParameter(deliquoringBox, fmGlobalParameter.rho_bulk);
            AddParameter(deliquoringBox, fmGlobalParameter.Qmfid);
            AddParameter(deliquoringBox, fmGlobalParameter.Qfid);
            AddParameter(deliquoringBox, fmGlobalParameter.Qmcd);
            AddParameter(deliquoringBox, fmGlobalParameter.Qcd);
            AddParameter(deliquoringBox, fmGlobalParameter.qmfid);
            AddParameter(deliquoringBox, fmGlobalParameter.qfid);
            AddParameter(deliquoringBox, fmGlobalParameter.qmcd);
            AddParameter(deliquoringBox, fmGlobalParameter.qcd);
            AddParameter(deliquoringBox, fmGlobalParameter.Qgt);
            AddParameter(deliquoringBox, fmGlobalParameter.Vg);
            AddParameter(deliquoringBox, fmGlobalParameter.Mev);
            AddParameter(deliquoringBox, fmGlobalParameter.Vev);
            AddParameter(deliquoringBox, fmGlobalParameter.Qmftd);
            AddParameter(deliquoringBox, fmGlobalParameter.Qmfd);
            AddParameter(deliquoringBox, fmGlobalParameter.Qftd);
            AddParameter(deliquoringBox, fmGlobalParameter.Qfd);
            AddParameter(deliquoringBox, fmGlobalParameter.Qmevi);
            AddParameter(deliquoringBox, fmGlobalParameter.Qmevt);
            AddParameter(deliquoringBox, fmGlobalParameter.Qmev);
            AddParameter(deliquoringBox, fmGlobalParameter.Qevi);
            AddParameter(deliquoringBox, fmGlobalParameter.Qevt);
            AddParameter(deliquoringBox, fmGlobalParameter.Qev);
            AddParameter(deliquoringBox, fmGlobalParameter.qmftd);
            AddParameter(deliquoringBox, fmGlobalParameter.qmfd);
            AddParameter(deliquoringBox, fmGlobalParameter.qftd);
            AddParameter(deliquoringBox, fmGlobalParameter.qfd);
            AddParameter(deliquoringBox, fmGlobalParameter.qmevi);
            AddParameter(deliquoringBox, fmGlobalParameter.qmevt);
            AddParameter(deliquoringBox, fmGlobalParameter.qmev);
            AddParameter(deliquoringBox, fmGlobalParameter.qevi);
            AddParameter(deliquoringBox, fmGlobalParameter.qevt);
            AddParameter(deliquoringBox, fmGlobalParameter.qev);
        }

        private void AddParameter(fmControls.fmCheckedListBoxWithCheckboxes box, fmGlobalParameter parameter)
        {
            m_parameterBox[parameter] = box;
            box.Items.Add(parameter.name);
        }

        public void CheckItems(List<fmCalculationLibrary.fmGlobalParameter> list)
        {
            foreach (fmGlobalParameter p in list)
            {
                CheckItemInBox(m_parameterBox[p], p);
            }
        }

        private void CheckItemInBox(fmCheckedListBoxWithCheckboxes box, fmGlobalParameter p)
        {
            for (int i = 0; i < box.Items.Count; ++i)
            {
                if (box.Items[i].ToString() == p.name)
                {
                    box.SetItemChecked(i, true);
                }
            }
        }

        private bool GetItemCheckedInBox(fmCheckedListBoxWithCheckboxes box, fmGlobalParameter p)
        {
            for (int i = 0; i < box.Items.Count; ++i)
            {
                if (box.Items[i].ToString() == p.name)
                {
                    return box.GetItemChecked(i);
                }
            }

            throw new Exception("item was not found in box");
        }

        public List<fmCalculationLibrary.fmGlobalParameter> GetCheckedItems()
        {
            var result = new List<fmCalculationLibrary.fmGlobalParameter>();
            foreach (fmGlobalParameter p in fmGlobalParameter.parameters)
            {
                if (m_parameterBox.ContainsKey(p) && GetItemCheckedInBox(m_parameterBox[p], p))
                {
                    result.Add(p);
                }
            }
            return result;
        }
        
        // ReSharper disable InconsistentNaming
        private void okButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}