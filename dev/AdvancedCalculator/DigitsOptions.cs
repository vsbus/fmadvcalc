using System;
using System.Windows.Forms;
using fmCalculationLibrary;

namespace AdvancedCalculator
{
    public partial class fmDigitsOptions : Form
    {
        public fmDigitsOptions()
        {
            InitializeComponent();
            precisionUpDown.Value = fmValue.outputPrecision;
        }

        // ReSharper disable InconsistentNaming
        private void OKbutton_Click(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            fmValue.outputPrecision = (int)precisionUpDown.Value;
            Close();
        }
    }
}