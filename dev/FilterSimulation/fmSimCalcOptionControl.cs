using System;
using System.Windows.Forms;
using fmCalculatorsLibrary;

namespace FilterSimulation
{
    class fmSimCalcOptionControl
    {
        public Guid guidOfOwnedSimulation;
        public GroupBox groupBox;
        public RadioButton standart1;
        public RadioButton standart2;
        public RadioButton standart3;
        public RadioButton standart4;
        public RadioButton standart7;
        public RadioButton standart8;
        public RadioButton design1;
        public RadioButton optimization1;

        public bool Visible
        {
            set
            {
                groupBox.Visible = value;
            }
        }

        private int radioButtonCount;
        private const int top = 22;
        private const int left = 10;
        private const int step = 18;

        RadioButton AddRadioButton(string caption)
        {
            RadioButton ret = new RadioButton();
            ret.Parent = groupBox;
            ret.Top = top + step * (radioButtonCount++);
            ret.Left = left;
            ret.Text = caption;
            ret.AutoSize = true;
            return ret;
        }

        public fmSimCalcOptionControl(Guid simGuid, Control parentControl, int leftPos, int topPos, fmFilterMachiningCalculator.FilterMachiningCalculationOption cOption)
        {
            guidOfOwnedSimulation = simGuid;

            groupBox = new GroupBox();
            groupBox.Parent = parentControl;
            groupBox.Left = leftPos;
            groupBox.Top = topPos;
            groupBox.Visible = false;
            groupBox.Text = "CalculationalOption";

            radioButtonCount = 0;

            standart3 = AddRadioButton("Standart 3: A, Dp, (n/tc), tf");
            standart4 = AddRadioButton("Standart 4: A, hc, sf, (n/tc)");
            standart8 = AddRadioButton("Standart 8: A, Dp, hc, (n/tc)");
            design1 = AddRadioButton("Design 1: Q, Dp, hc, (n/tc)");
            optimization1 = AddRadioButton("Optimization 1: A, Q, Dp, sf");

            standart3.Checked = cOption == fmFilterMachiningCalculator.FilterMachiningCalculationOption.Standart3;
            standart4.Checked = cOption == fmFilterMachiningCalculator.FilterMachiningCalculationOption.Standart4;
            standart8.Checked = cOption == fmFilterMachiningCalculator.FilterMachiningCalculationOption.Standart8;
            design1.Checked = cOption == fmFilterMachiningCalculator.FilterMachiningCalculationOption.Design1;
            optimization1.Checked = cOption == fmFilterMachiningCalculator.FilterMachiningCalculationOption.Optimization1;

            groupBox.Height = top + step * (radioButtonCount + 1);
        }
    }
}
