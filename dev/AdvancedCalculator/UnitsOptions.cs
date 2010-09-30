using System;
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

        // ReSharper disable InconsistentNaming
        private void UnitsOptions_Load(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            BindUnitComboBox(AreaUnitItem, fmUnitFamily.AreaFamily);
            BindUnitComboBox(TimeUnitItem, fmUnitFamily.TimeFamily);
            BindUnitComboBox(LengthUnitItem, fmUnitFamily.LengthFamily);
            BindUnitComboBox(ConcentrationUnitItem, fmUnitFamily.ConcentrationFamily);
            BindUnitComboBox(TimeUnitItem, fmUnitFamily.TimeFamily);
            BindUnitComboBox(PressureUnitItem, fmUnitFamily.PressureFamily);
            BindUnitComboBox(ViscosityUnitItem, fmUnitFamily.ViscosityFamily);
            BindUnitComboBox(DensityUnitItem, fmUnitFamily.DensityFamily);
            BindUnitComboBox(FrequencyUnitItem, fmUnitFamily.FrequencyFamily);
            BindUnitComboBox(VolumeUnitItem, fmUnitFamily.VolumeFamily);
            BindUnitComboBox(MassUnitItem, fmUnitFamily.MassFamily);
        }

        private static void BindUnitComboBox(fmUnitItem unitItem, fmUnitFamily dataSource)
        {
            unitItem.UnitComboBox.DataSource = dataSource.units;
            unitItem.UnitComboBox.ValueMember = "Name";
            unitItem.UnitComboBox.SelectedItem = dataSource.CurrentUnit;
        }

        // ReSharper disable InconsistentNaming
        private void OKButton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            fmUnitFamily.AreaFamily.SetCurrentUnit(AreaUnitItem.UnitComboBox.Text);
            fmUnitFamily.LengthFamily.SetCurrentUnit(LengthUnitItem.UnitComboBox.Text);
            fmUnitFamily.ConcentrationFamily.SetCurrentUnit(ConcentrationUnitItem.UnitComboBox.Text);
            fmUnitFamily.TimeFamily.SetCurrentUnit(TimeUnitItem.UnitComboBox.Text);
            fmUnitFamily.PressureFamily.SetCurrentUnit(PressureUnitItem.UnitComboBox.Text);
            fmUnitFamily.ViscosityFamily.SetCurrentUnit(ViscosityUnitItem.UnitComboBox.Text);
            fmUnitFamily.DensityFamily.SetCurrentUnit(DensityUnitItem.UnitComboBox.Text);
            fmUnitFamily.FrequencyFamily.SetCurrentUnit(FrequencyUnitItem.UnitComboBox.Text);
            fmUnitFamily.VolumeFamily.SetCurrentUnit(VolumeUnitItem.UnitComboBox.Text);
            fmUnitFamily.MassFamily.SetCurrentUnit(MassUnitItem.UnitComboBox.Text);
            Close();
        }
    }
}