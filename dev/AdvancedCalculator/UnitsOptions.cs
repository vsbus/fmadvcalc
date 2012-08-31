using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using fmFilterSimulationControl;
using fmCalculationLibrary.MeasureUnits;
using FilterSimulation;
using fmMisc;

namespace AdvancedCalculator
{
    public partial class fmUnitsOptions : Form
    {
        private Dictionary<fmUnitFamily, fmUnitItem> m_famityToItem = new Dictionary<fmUnitFamily, fmUnitItem>();
        private Dictionary<fmUnitsSchema, Dictionary<fmUnitFamily, fmUnit>> m_unitsSchemas;
        private fmUnitsSchema m_currentSchema;

        public fmUnitsOptions()
        {
            InitializeComponent();
        }

        private void UnitsOptions_Load(object sender, EventArgs e)
        {
            foreach (Enum element in Enum.GetValues(typeof(fmUnitsSchema)))
            {
                unitSchemaComboBox.Items.Add(fmEnumUtils.GetEnumDescription(element));
            }
            unitSchemaComboBox.Text = fmEnumUtils.GetEnumDescription(m_currentSchema);
            BindAllUnitFamilies();
        }

        private void BindAllUnitFamilies()
        {
            foreach (KeyValuePair<fmUnitFamily, fmUnitItem> pair in m_famityToItem)
            {
                pair.Value.Parent = null;
            }
            m_famityToItem.Clear();

            BindUnitsGroup(LengthAreaTimePanel,
                fmUnitFamily.LengthFamily,
                fmUnitFamily.AreaFamily,
                fmUnitFamily.TimeFamily,
                fmUnitFamily.FrequencyFamily);

            BindUnitsGroup(massAndVolumePanel,
                fmUnitFamily.MassFamily,
                fmUnitFamily.VolumeFamily,
                fmUnitFamily.SpecificMassFamily,
                fmUnitFamily.VolumeInAreaFamily);

            BindUnitsGroup(QPanel,
                fmUnitFamily.FlowRateMass,
                fmUnitFamily.FlowRateVolume,
                fmUnitFamily.SpecificFlowRateMass,
                fmUnitFamily.SpecificFlowRateVolume);

            BindUnitsGroup(GasPanel,
                fmUnitFamily.GasVolumeFamily,
                fmUnitFamily.GasVolumeInMassFamily,
                fmUnitFamily.GasFlowRateVolume);

            BindUnitsGroup(RhoEtaPanel,
                fmUnitFamily.DensityFamily,
                fmUnitFamily.ViscosityFamily,
                fmUnitFamily.PressureFamily);
        }

        private void BindUnitsGroup(Control parentControl, params fmUnitFamily[] families)
        {
            for (int idx = 0; idx < families.Length; ++idx)
            {
                BindUnitComboBox(families[idx], parentControl, idx);
            }
            QPanel.AutoScroll = true;
        }

        private void BindUnitComboBox(fmUnitFamily dataSource, Control parentControl, int yIdx)
        {
            const int heightStep = 24;
            var unitItem = new fmUnitItem
                               {
                                   Location = new Point(16, 8 + yIdx * heightStep),
                                   Parent = parentControl,
                                   Size = new Size(280, heightStep)
                               };
            unitItem.UnitComboBox.Items.Clear();
            bool isSelected = false;
            foreach (fmUnit unit in dataSource.units)
            {
                if (unit.IsUs && !showUSUnitsCheckBox.Checked)
                {
                    continue;
                }
                unitItem.UnitComboBox.Items.Add(unit.Name);
                if (unit.Name == dataSource.CurrentUnit.Name)
                {
                    unitItem.UnitComboBox.SelectedIndex = unitItem.UnitComboBox.Items.Count - 1;
                    isSelected = true;
                }
            }
            if (!isSelected)
            {
                unitItem.UnitComboBox.Items.Add(dataSource.CurrentUnit.Name);
                unitItem.UnitComboBox.SelectedIndex = unitItem.UnitComboBox.Items.Count - 1;
            }
            unitItem.UnitName = dataSource.Name;
            m_famityToItem.Add(dataSource, unitItem);
        }

        // ReSharper disable InconsistentNaming
        private void OKButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            foreach (KeyValuePair<fmUnitFamily, fmUnitItem> pair in m_famityToItem)
            {
                pair.Key.SetCurrentUnit(pair.Value.UnitComboBox.Text);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showUSUnitsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BindAllUnitFamilies();
        }

        internal void SetUsChecked(bool isUsChecked)
        {
            showUSUnitsCheckBox.Checked = isUsChecked;
        }

        internal bool GetUsChecked()
        {
            return showUSUnitsCheckBox.Checked;
        }

        internal void SetUnitsSchemas(Dictionary<FilterSimulation.fmUnitsSchema, Dictionary<fmUnitFamily, fmUnit>> unitsSchemas)
        {
            m_unitsSchemas = new Dictionary<FilterSimulation.fmUnitsSchema,Dictionary<fmUnitFamily,fmUnit>>(unitsSchemas);
        }

        internal void CheckScheme(fmUnitsSchema unitsSchema)
        {
            m_currentSchema = unitsSchema;
        }

        internal fmUnitsSchema GetCheckedUnitsSchema()
        {
            return m_currentSchema;
        }

        internal Dictionary<fmUnitsSchema, Dictionary<fmUnitFamily, fmUnit>> GetUnitsSchemas()
        {
            return m_unitsSchemas;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var unitSchema = (fmUnitsSchema)fmEnumUtils.GetEnum(typeof(fmUnitsSchema), unitSchemaComboBox.Text);
            if (!m_unitsSchemas.ContainsKey(unitSchema))
            {
                MessageBox.Show("Nothing assigned to scheme " + unitSchemaComboBox.Text + " yet.");
                return;
            }
            Dictionary<fmUnitFamily, fmUnit> schema = m_unitsSchemas[unitSchema];
            foreach (fmUnitFamily unitFamily in schema.Keys)
            {
                m_famityToItem[unitFamily].UnitComboBox.Text = schema[unitFamily].Name;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var unitSchema = (fmUnitsSchema)fmEnumUtils.GetEnum(typeof(fmUnitsSchema), unitSchemaComboBox.Text);
            var schema = new Dictionary<fmUnitFamily, fmUnit>();
            foreach (fmUnitFamily unitFamily in m_famityToItem.Keys)
            {
                schema[unitFamily] = unitFamily.GetUnitByName(m_famityToItem[unitFamily].UnitComboBox.Text);
            }
            m_unitsSchemas[unitSchema] = schema;
        }

        private void unitSchemaComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            m_currentSchema = (fmUnitsSchema)fmEnumUtils.GetEnum(typeof(fmUnitsSchema), unitSchemaComboBox.Text);
        }
    }
}