using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FilterSimulationWithTablesAndGraphs
{
    public partial class CalculationOptionSelectionExpandedDialog : FilterSimulation.CalculationOptionSelectionDialog
    {
        private CalculationDialogExpandedItemSelection m_CalculationDialogExpandedItemSelection;

        public CalculationDialogExpandedItemSelection ItemSelection
        {
            get
            {
                return m_CalculationDialogExpandedItemSelection;
            }
        }

        public CalculationOptionSelectionExpandedDialog()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = !radioButton2.Checked;
        }

        private void currentItemRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateItemSelection();
        }

        private void checkedItemsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateItemSelection();
        }

        private void allItemsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateItemSelection();
        }

        private void UpdateItemSelection()
        {
            if (currentItemRadioButton.Checked)
            {
                m_CalculationDialogExpandedItemSelection = CalculationDialogExpandedItemSelection.Current;
            }
            else if (checkedItemsRadioButton.Checked)
            {
                m_CalculationDialogExpandedItemSelection = CalculationDialogExpandedItemSelection.Checked;
            }
            else if (allItemsRadioButton.Checked)
            {
                m_CalculationDialogExpandedItemSelection = CalculationDialogExpandedItemSelection.All;
            }
            else
            {
                throw new Exception("no item radio button selected");
            }
        }
    }

    public enum CalculationDialogExpandedItemSelection
    {
        Current,
        Checked,
        All
    }
}

