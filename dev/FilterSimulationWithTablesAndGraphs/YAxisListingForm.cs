using System;
using System.Collections.Generic;
using System.Windows.Forms;
using fmCalculationLibrary;
using fmControls;
using FilterSimulation.fmFilterObjects;

namespace FilterSimulationWithTablesAndGraphs
{
    public partial class fmYAxisListingForm : Form
    {
        private readonly Dictionary<fmGlobalParameter, fmControls.fmCheckedListBoxWithCheckboxes> m_parameterBox = new Dictionary<fmGlobalParameter, fmCheckedListBoxWithCheckboxes>();
        public string currentSerieMachineName = "";

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

            AddParameter(materialDeliqouringBox, fmGlobalParameter.eps_d);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.eta_d);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.rho_d);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.sigma);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.pke0);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.pke);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.pc_d);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.rc_d);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.alpha_d);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.Srem);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.ad1);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.ad2);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.Tetta);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.eta_g);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.ag1);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.ag2);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.ag3);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.Tetta_boil);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.DH);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.Mmole);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.f);
            AddParameter(materialDeliqouringBox, fmGlobalParameter.peq);

            AddParameter(gasParameters, fmGlobalParameter.Qgi);
            AddParameter(gasParameters, fmGlobalParameter.Qg);
            AddParameter(gasParameters, fmGlobalParameter.vg);
            AddParameter(gasParameters, fmGlobalParameter.Qgt);
            AddParameter(gasParameters, fmGlobalParameter.Vg);

            AddParameter(evaporationsParameters, fmGlobalParameter.Qmevi);
            AddParameter(evaporationsParameters, fmGlobalParameter.Qmevt);
            AddParameter(evaporationsParameters, fmGlobalParameter.Qmev);
            AddParameter(evaporationsParameters, fmGlobalParameter.Qevi);
            AddParameter(evaporationsParameters, fmGlobalParameter.Qevt);
            AddParameter(evaporationsParameters, fmGlobalParameter.Qev);
            AddParameter(evaporationsParameters, fmGlobalParameter.Mev);
            AddParameter(evaporationsParameters, fmGlobalParameter.Vev);
            AddParameter(evaporationsParameters, fmGlobalParameter.qmevi);
            AddParameter(evaporationsParameters, fmGlobalParameter.qmevt);
            AddParameter(evaporationsParameters, fmGlobalParameter.qmev);
            AddParameter(evaporationsParameters, fmGlobalParameter.qevi);
            AddParameter(evaporationsParameters, fmGlobalParameter.qevt);
            AddParameter(evaporationsParameters, fmGlobalParameter.qev);

            AddParameter(deliquoringBox, fmGlobalParameter.Dp_d);
            AddParameter(deliquoringBox, fmGlobalParameter.hcd);
            AddParameter(deliquoringBox, fmGlobalParameter.sd);
            AddParameter(deliquoringBox, fmGlobalParameter.td);
            AddParameter(deliquoringBox, fmGlobalParameter.K);
            AddParameter(deliquoringBox, fmGlobalParameter.Smech);
            AddParameter(deliquoringBox, fmGlobalParameter.S);
            AddParameter(deliquoringBox, fmGlobalParameter.Rfmech);
            AddParameter(deliquoringBox, fmGlobalParameter.Rf);
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
            AddParameter(deliquoringBox, fmGlobalParameter.Qmftd);
            AddParameter(deliquoringBox, fmGlobalParameter.Qmfd);
            AddParameter(deliquoringBox, fmGlobalParameter.Qftd);
            AddParameter(deliquoringBox, fmGlobalParameter.Qfd);
            AddParameter(deliquoringBox, fmGlobalParameter.qmftd);
            AddParameter(deliquoringBox, fmGlobalParameter.qmfd);
            AddParameter(deliquoringBox, fmGlobalParameter.qftd);
            AddParameter(deliquoringBox, fmGlobalParameter.qfd);
        }

        private void AddParameter(fmControls.fmCheckedListBoxWithCheckboxes box, fmGlobalParameter parameter)
        {
            m_parameterBox[parameter] = box;
            box.Items.Add(parameter.Name);
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
                if (box.Items[i].ToString() == p.Name)
                {
                    box.SetItemChecked(i, true);
                }
            }
        }

        private bool GetItemCheckedInBox(fmCheckedListBoxWithCheckboxes box, fmGlobalParameter p)
        {
            for (int i = 0; i < box.Items.Count; ++i)
            {
                if (box.Items[i].ToString() == p.Name)
                {
                    return box.GetItemChecked(i);
                }
            }

            throw new Exception("item was not found in box");
        }

        public List<fmCalculationLibrary.fmGlobalParameter> GetCheckedItems()
        {
            var result = new List<fmCalculationLibrary.fmGlobalParameter>();
            foreach (fmGlobalParameter p in fmGlobalParameter.Parameters)
            {
                if (m_parameterBox.ContainsKey(p) && GetItemCheckedInBox(m_parameterBox[p], p))
                {
                    result.Add(p);
                }
            }
            return result;
        }
        
        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void fmYAxisListingForm_Load(object sender, EventArgs e)
        {
            int selecedIdx = 0;
            foreach (fmFilterSimMachineType filterType in fmFilterSimMachineType.filterTypesList)
            {
                int idx = machinesComboBox.Items.Add(filterType.name);
                if (filterType.name == currentSerieMachineName)
                {
                    selecedIdx = idx;
                }
            }
            machinesComboBox.SelectedIndex = selecedIdx;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                @"Are you sure you want to assign new show/hide configuration for the selected machine type?",
                @"Confirm",
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                
            }
        }
    }
}