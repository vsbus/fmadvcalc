using System;
using System.Windows.Forms;
using fmCalculatorsLibrary;

namespace FilterSimulation
{
    class fmSimCalcOptionControl
    {
        public Guid guidOfOwnedSimulation;
        public GroupBox groupBox;
        public RadioButton standart3;
        public RadioButton standart4;
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

        private int m_radioButtonCount;
        private const int Top = 22;
        private const int Left = 10;
        private const int Step = 18;

        RadioButton AddRadioButton(string caption)
        {
            var ret = new RadioButton
                          {
                              Parent = groupBox,
                              Top = Top + Step*(m_radioButtonCount++),
                              Left = Left,
                              Text = caption,
                              AutoSize = true
                          };
            return ret;
        }

        public fmSimCalcOptionControl(Guid simGuid, Control parentControl, int leftPos, int topPos, fmFilterMachiningCalculator.fmFilterMachiningCalculationOption cOption)
        {
            guidOfOwnedSimulation = simGuid;

            groupBox = new GroupBox
                           {
                               Parent = parentControl,
                               Left = leftPos,
                               Top = topPos,
                               Visible = false,
                               Text = @"CalculationalOption"
                           };

            m_radioButtonCount = 0;

            standart3 = AddRadioButton("Standart 3: A, Dp, (n/tc), tf");
            standart4 = AddRadioButton("Standart 4: A, hc, sf, (n/tc)");
            standart8 = AddRadioButton("Standart 8: A, Dp, hc, (n/tc)");
            design1 = AddRadioButton("Design 1: Q, Dp, hc, (n/tc)");
            optimization1 = AddRadioButton("Optimization 1: A, Q, Dp, sf");

            standart3.Checked = cOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART3;
            standart4.Checked = cOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART4;
            standart8.Checked = cOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART8;
            design1.Checked = cOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.DESIGN1;
            optimization1.Checked = cOption == fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.OPTIMIZATION1;

            groupBox.Height = Top + Step * (m_radioButtonCount + 1);
        }
    }
}
