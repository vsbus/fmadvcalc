using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using fmFilterSimulationControl;
using fmCalculationLibrary.MeasureUnits;

namespace AdvancedCalculator
{
    public partial class fmUnitsOptions : Form
    {
        public fmUnitsOptions()
        {
            InitializeComponent();
        }

        //  ReSharper disable InconsistentNaming
        private void UnitsOptions_Load(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            BindAllUnitFamilies();
        }

        private void BindAllUnitFamilies()
        {
            var families = new[]
                               {
                                   fmUnitFamily.LengthFamily,
                                   fmUnitFamily.AreaFamily,
                                   fmUnitFamily.MassFamily,
                                   fmUnitFamily.VolumeFamily,
                                   fmUnitFamily.SpecificMassFamily,
                                   fmUnitFamily.VolumeInAreaFamily,
                                   fmUnitFamily.FlowRateMass,
                                   fmUnitFamily.FlowRateVolume,
                                   fmUnitFamily.SpecificFlowRateMass,
                                   fmUnitFamily.SpecificFlowRateVolume,
                                   fmUnitFamily.GasFlowRateVolume,
                                   fmUnitFamily.ViscosityFamily,
                                   fmUnitFamily.DensityFamily,
                                   fmUnitFamily.PressureFamily,
                                   fmUnitFamily.FrequencyFamily,
                                   fmUnitFamily.TimeFamily
                               };
            foreach (KeyValuePair<fmUnitFamily, fmUnitItem> pair in m_famityToItem)
            {
                pair.Value.Parent = null;
            }
            m_famityToItem.Clear();
            foreach (fmUnitFamily unitFamily in families)
            {
                BindUnitComboBox(unitFamily);
            }
            panel1.AutoScroll = true;
        }

        private Dictionary<fmUnitFamily, fmUnitItem> m_famityToItem = new Dictionary<fmUnitFamily, fmUnitItem>();

        private void BindUnitComboBox(fmUnitFamily dataSource)
        {
            const int heightStep = 32;
            var unitItem = new fmUnitItem
                               {
                                   Location = new Point(16, 16 + m_famityToItem.Count * heightStep),
                                   Parent = panel1,
                                   Size = new Size(panel1.Width - 32, heightStep)
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
    }
}