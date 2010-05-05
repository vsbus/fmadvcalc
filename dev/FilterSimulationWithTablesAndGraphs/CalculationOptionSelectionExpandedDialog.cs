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
        private CalculationOptionDialogExpandedItemSelection m_CalculationOptionDialogExpandedItemSelection;
        private CalculationOptionDialogExpandedCalculationOptionKind m_CalculationOptionKind;

        public CalculationOptionDialogExpandedItemSelection ItemSelection
        {
            get
            {
                return m_CalculationOptionDialogExpandedItemSelection;
            }
        }

        public CalculationOptionDialogExpandedCalculationOptionKind CalculationOptionKind
        {
            get
            {
                return m_CalculationOptionKind;
            }
        }

        public CalculationOptionSelectionExpandedDialog()
        {
            InitializeComponent();
            UpdateCalculationOptionKind();
            UpdateItemSelection();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCalculationOptionKind();
        }

        private void UpdateCalculationOptionKind()
        {
            m_CalculationOptionKind = radioButton1.Checked
                                          ? CalculationOptionDialogExpandedCalculationOptionKind.New
                                          : CalculationOptionDialogExpandedCalculationOptionKind.MotherInitial;
            panel1.Enabled = m_CalculationOptionKind == CalculationOptionDialogExpandedCalculationOptionKind.New;
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
                m_CalculationOptionDialogExpandedItemSelection = CalculationOptionDialogExpandedItemSelection.Current;
            }
            else if (checkedItemsRadioButton.Checked)
            {
                m_CalculationOptionDialogExpandedItemSelection = CalculationOptionDialogExpandedItemSelection.Checked;
            }
            else if (allItemsRadioButton.Checked)
            {
                m_CalculationOptionDialogExpandedItemSelection = CalculationOptionDialogExpandedItemSelection.All;
            }
            else
            {
                throw new Exception("no item radio button selected");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCalculationOptionKind();
        }
    }

    public enum CalculationOptionDialogExpandedCalculationOptionKind
    {
        MotherInitial,
        New
    }

    public enum CalculationOptionDialogExpandedItemSelection
    {
        Current,
        Checked,
        All
    }
}

