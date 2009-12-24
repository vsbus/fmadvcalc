using System;
using System.Windows.Forms;
using fmCalculationLibrary;

namespace AdvancedCalculator
{
    public partial class DigitsOptions : Form
    {
        public DigitsOptions()
        {
            InitializeComponent();
            precisionUpDown.Value = fmValue.outputPrecision;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            fmValue.outputPrecision = (int)precisionUpDown.Value;
            Close();
        }
    }
}