using System;

namespace FilterSimulationWithTablesAndGraphs
{
    public partial class fmCalculationOptionSelectionExpandedDialog : FilterSimulation.CalculationOptionSelectionDialog
    {
        private fmCalculationOptionDialogExpandedItemSelection m_calculationOptionDialogExpandedItemSelection;
        private fmCalculationOptionDialogExpandedCalculationOptionKind m_calculationOptionKind;

        public fmCalculationOptionDialogExpandedItemSelection ItemSelection
        {
            get
            {
                return m_calculationOptionDialogExpandedItemSelection;
            }
        }

        public fmCalculationOptionDialogExpandedCalculationOptionKind CalculationOptionKind
        {
            get
            {
                return m_calculationOptionKind;
            }
        }

        public fmCalculationOptionSelectionExpandedDialog()
        {
            InitializeComponent();
            UpdateCalculationOptionKind();
            UpdateItemSelection();
        }

        // ReSharper disable InconsistentNaming
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            UpdateCalculationOptionKind();
        }

        private void UpdateCalculationOptionKind()
        {
            m_calculationOptionKind = radioButton1.Checked
                                          ? fmCalculationOptionDialogExpandedCalculationOptionKind.NEW
                                          : fmCalculationOptionDialogExpandedCalculationOptionKind.MOTHER_INITIAL;
            panel1.Enabled = m_calculationOptionKind == fmCalculationOptionDialogExpandedCalculationOptionKind.NEW;
        }

        // ReSharper disable InconsistentNaming
        private void currentItemRadioButton_CheckedChanged(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            UpdateItemSelection();
        }

        // ReSharper disable InconsistentNaming
        private void checkedItemsRadioButton_CheckedChanged(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            UpdateItemSelection();
        }

        // ReSharper disable InconsistentNaming
        private void allItemsRadioButton_CheckedChanged(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            UpdateItemSelection();
        }

        private void UpdateItemSelection()
        {
            if (currentItemRadioButton.Checked)
            {
                m_calculationOptionDialogExpandedItemSelection = fmCalculationOptionDialogExpandedItemSelection.CURRENT;
            }
            else if (checkedItemsRadioButton.Checked)
            {
                m_calculationOptionDialogExpandedItemSelection = fmCalculationOptionDialogExpandedItemSelection.CHECKED;
            }
            else if (allItemsRadioButton.Checked)
            {
                m_calculationOptionDialogExpandedItemSelection = fmCalculationOptionDialogExpandedItemSelection.ALL;
            }
            else
            {
                throw new Exception("no item radio button selected");
            }
        }

        // ReSharper disable InconsistentNaming
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            UpdateCalculationOptionKind();
        }
    }

    public enum fmCalculationOptionDialogExpandedCalculationOptionKind
    {
        MOTHER_INITIAL,
        NEW
    }

    public enum fmCalculationOptionDialogExpandedItemSelection
    {
        CURRENT,
        CHECKED,
        ALL
    }
}
