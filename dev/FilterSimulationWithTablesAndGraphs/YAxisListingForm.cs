using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FilterSimulation;
using fmCalculationLibrary;
using fmControls;
using fmMisc;
using FilterSimulation.fmFilterObjects;

namespace FilterSimulationWithTablesAndGraphs
{
    public partial class fmYAxisListingForm : Form
    {
        private readonly Dictionary<fmGlobalParameter, fmCheckedListBoxWithCheckboxes> m_parameterBox = new Dictionary<fmGlobalParameter, fmCheckedListBoxWithCheckboxes>();
        public string CurrentSerieMachineName = "";

        private Dictionary<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>> m_schemas = new Dictionary<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>>();

        private readonly fmFilterSimMachineType[] m_machines = fmFilterSimMachineType.filterTypesList.ToArray();
        private Dictionary<string, List<fmGlobalParameter>> m_ShowHideSchemasForEachFilterMachine = new Dictionary<string, List<fmGlobalParameter>>();

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

            AddParameter(qmBigBox_dif, fmGlobalParameter.Qmf_i);
            AddParameter(qmBigBox_dif, fmGlobalParameter.Qms_i);
            AddParameter(qmBigBox_dif, fmGlobalParameter.Qmsus_i);
            AddParameter(qmBigBox_dif, fmGlobalParameter.Qmc_i);

            AddParameter(qBigBox_dif, fmGlobalParameter.Qf_i);
            AddParameter(qBigBox_dif, fmGlobalParameter.Qs_i);
            AddParameter(qBigBox_dif, fmGlobalParameter.Qc_i);

            AddParameter(qmSmallBox_dif, fmGlobalParameter.qmf_i);
            AddParameter(qmSmallBox_dif, fmGlobalParameter.qms_i);
            AddParameter(qmSmallBox_dif, fmGlobalParameter.qmsus_i);
            AddParameter(qmSmallBox_dif, fmGlobalParameter.qmc_i);

            AddParameter(qSmallBox_dif, fmGlobalParameter.qf_i);
            AddParameter(qSmallBox_dif, fmGlobalParameter.qs_i);
            AddParameter(qSmallBox_dif, fmGlobalParameter.qc_i);

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

            AddParameter(DpQpConstBox, fmGlobalParameter.Qp);
            AddParameter(DpQpConstBox, fmGlobalParameter.qp);
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

            AddParameter(mainDeliquoringBox, fmGlobalParameter.Dp_d);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.hcd);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.sd);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.td);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.K);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.Smech);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.S);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.Rfmech);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.Rf);
            AddParameter(mainDeliquoringBox, fmGlobalParameter.rho_bulk);

            AddParameter(volumeDeliquoringBox, fmGlobalParameter.Vfd);
            AddParameter(volumeDeliquoringBox, fmGlobalParameter.Vlcd);
            AddParameter(volumeDeliquoringBox, fmGlobalParameter.Vcd);
            
            AddParameter(massDeliquoringBox, fmGlobalParameter.Mfd);
            AddParameter(massDeliquoringBox, fmGlobalParameter.Mlcd);
            AddParameter(massDeliquoringBox, fmGlobalParameter.Mcd);

            AddParameter(volumeFlowrateDeliquoringBox, fmGlobalParameter.Qfd);
            AddParameter(volumeFlowrateDeliquoringBox, fmGlobalParameter.Qftd);
            AddParameter(volumeFlowrateDeliquoringBox, fmGlobalParameter.Qfid);
            AddParameter(volumeFlowrateDeliquoringBox, fmGlobalParameter.Qcd);

            AddParameter(massFlowrateDeliquoringBox, fmGlobalParameter.Qmfd);
            AddParameter(massFlowrateDeliquoringBox, fmGlobalParameter.Qmftd);
            AddParameter(massFlowrateDeliquoringBox, fmGlobalParameter.Qmfid);
            AddParameter(massFlowrateDeliquoringBox, fmGlobalParameter.Qmcd);
            
            AddParameter(qDeliquoringBox, fmGlobalParameter.qcd);
            AddParameter(qDeliquoringBox, fmGlobalParameter.qfid);
            AddParameter(qDeliquoringBox, fmGlobalParameter.qftd);
            AddParameter(qDeliquoringBox, fmGlobalParameter.qfd); 
            
            AddParameter(qmDeliquoringBox, fmGlobalParameter.qmcd);
            AddParameter(qmDeliquoringBox, fmGlobalParameter.qmfid);
            AddParameter(qmDeliquoringBox, fmGlobalParameter.qmftd);
            AddParameter(qmDeliquoringBox, fmGlobalParameter.qmfd);

            FillFilterTypeCombobox();
            InitCombobox();
        }

        private void FillFilterTypeCombobox()
        {
            foreach (Enum element in Enum.GetValues(typeof(fmFilterSimMachineType.FilterCycleType)))
            {
                filterTypeGroupComboBox.Items.Add(fmEnumUtils.GetEnumDescription(element));
            }
            filterTypeGroupComboBox.SelectedIndex = 0;
        }

        private void AddParameter(fmCheckedListBoxWithCheckboxes box, fmGlobalParameter parameter)
        {
            m_parameterBox[parameter] = box;
            box.Items.Add(parameter.Name);
        }

        public void UncheckAll()
        {
            foreach (fmCheckedListBoxWithCheckboxes box in m_parameterBox.Values)
            {
                for (int i = 0; i < box.Items.Count; ++i)
                {
                    box.SetItemChecked(i, false);
                }
            }
        }

        public void CheckItems(List<fmGlobalParameter> list)
        {
            foreach (fmGlobalParameter p in list)
            {
                CheckItemInBox(m_parameterBox[p], p);
            }
        }

        private static void CheckItemInBox(fmCheckedListBoxWithCheckboxes box, fmGlobalParameter p)
        {
            for (int i = 0; i < box.Items.Count; ++i)
            {
                if (box.Items[i].ToString() == p.Name)
                {
                    box.SetItemChecked(i, true);
                }
            }
        }

        private static bool GetItemCheckedInBox(fmCheckedListBoxWithCheckboxes box, fmGlobalParameter p)
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

        public List<fmGlobalParameter> GetCheckedItems()
        {
            var result = new List<fmGlobalParameter>();
            foreach (fmGlobalParameter p in fmGlobalParameter.Parameters)
            {
                if (m_parameterBox.ContainsKey(p) && GetItemCheckedInBox(m_parameterBox[p], p))
                {
                    result.Add(p);
                }
            }
            return result;
        }
        
        private void OkButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Button1Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Button3Click(object sender, EventArgs e)
        {
            if (filterTypeGroupComboBox.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show(
                    @"Are you sure you want to assign new show/hide configuration for the selected Filter Type?",
                    @"Confirm",
                    MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    var value = (fmFilterSimMachineType.FilterCycleType) fmEnumUtils.GetEnum(typeof (fmFilterSimMachineType.FilterCycleType), filterTypeGroupComboBox.Text);
                    m_schemas[value] = GetCheckedItems();

                    var selectedFilter = filterTypeByMachineComboBox.Text;
                    m_ShowHideSchemasForEachFilterMachine[selectedFilter] = GetCheckedItems();
                }
            }
        }

        private void takeButton_Click(object sender, EventArgs e)
        {
            if (filterTypeGroupComboBox.Text != "")
            {
                var value = (fmFilterSimMachineType.FilterCycleType)fmEnumUtils.GetEnum(typeof(fmFilterSimMachineType.FilterCycleType), filterTypeGroupComboBox.Text);
                var selecteFilter = filterTypeByMachineComboBox.Text;
                if (m_schemas.ContainsKey(value))
                {
                    UncheckAll();
                    CheckItems(m_schemas[value]);
                }
                if (m_ShowHideSchemasForEachFilterMachine.ContainsKey(selecteFilter))
                {
                    UncheckAll();
                    CheckItems(m_ShowHideSchemasForEachFilterMachine[selecteFilter]);
                }
                else
                {
                    MessageBox.Show(@"Nothing assigned to the selected type.");
                }
            }
        }

        public Dictionary<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>> GetShowHideSchemas()
        {
            return m_schemas;
        }

        public Dictionary<string, List<fmGlobalParameter>> GetFiltersShowHideSchemas()
        {
            return m_ShowHideSchemasForEachFilterMachine;
        }

        public void SetShowHideSchemas(Dictionary<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>> dictionary, Dictionary<string, List<fmGlobalParameter>> filtersDictionary)
        {
            m_schemas = new Dictionary<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>>();
            foreach (KeyValuePair<fmFilterSimMachineType.FilterCycleType, List<fmGlobalParameter>> pair in dictionary)
            {
                m_schemas.Add(pair.Key, pair.Value);
            }

            m_ShowHideSchemasForEachFilterMachine = new Dictionary<string, List<fmGlobalParameter>>();
            foreach (KeyValuePair<string, List<fmGlobalParameter>> pair in filtersDictionary)
            {
                m_ShowHideSchemasForEachFilterMachine.Add(pair.Key, pair.Value);
            }
        }

        public void CheckScheme(fmFilterSimMachineType.FilterCycleType schema, string serieMachineName)
        {
            for (int i = 0; i < filterTypeGroupComboBox.Items.Count; ++i)
            {
                if (filterTypeGroupComboBox.Items[i].ToString() == fmEnumUtils.GetEnumDescription(schema))
                {
                    filterTypeGroupComboBox.SelectedIndex = i;
                    break;
                }
            }

            foreach (var item in filterTypeByMachineComboBox.Items)
            {
                if (item.ToString() == serieMachineName)
                {
                    filterTypeByMachineComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        public fmFilterSimMachineType.FilterCycleType GetCheckedSchema()
        {
            return (fmFilterSimMachineType.FilterCycleType) fmEnumUtils.GetEnum(typeof (fmFilterSimMachineType.FilterCycleType), filterTypeGroupComboBox.Text);
        }

        private void InitCombobox()
        {
            foreach (fmFilterSimMachineType machine in m_machines)
            {
                filterTypeByMachineComboBox.Items.Add(machine.name);
            }

            filterTypeByMachineComboBox.SelectedIndex = 0;
        }        

        private void filterTypeByMachineComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedFilter = filterTypeByMachineComboBox.SelectedItem;
            foreach (fmFilterSimMachineType filterType in m_machines)
            {
                if (filterType.name == selectedFilter.ToString())
                {
                    for (int i = 0; i < filterTypeGroupComboBox.Items.Count; ++i)
                    {
                        var value = (fmFilterSimMachineType.FilterCycleType)fmEnumUtils.GetEnum(typeof(fmFilterSimMachineType.FilterCycleType), filterTypeGroupComboBox.Items[i].ToString());
                        if ( value == filterType.GetFilterCycleType())
                        {
                            filterTypeGroupComboBox.SelectedIndex = i;
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}