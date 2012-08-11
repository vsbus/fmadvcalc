using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FilterSimulation
{
    public partial class TableWithParameterRanges : UserControl
    {
        public int RowCount { get { return fmDataGrid1.RowCount; } }

        public TableWithParameterRanges()
        {
            InitializeComponent();
        }

        internal int AddRow(fmCalculationLibrary.fmGlobalParameter p)
        {
            return fmDataGrid1.Rows.Add(new[] { p.Name, p.UnitFamily.CurrentUnit.Name });
        }

        internal void SetRawBackColor(int rowIndex, Color color)
        {
            fmFilterSimulationControl.SetRowBackColor(fmDataGrid1.Rows[rowIndex], color);
        }

        public DataGridViewCell RangeMinValueCell(int rowIndex)
        {
            return fmDataGrid1["MinValueColumn", rowIndex];
        }

        public DataGridViewCell RangeMaxValueCell(int rowIndex)
        {
            return fmDataGrid1["MaxValueColumn", rowIndex];
        }

        internal DataGridViewCell ParameterCell(int rowIndex)
        {
            return fmDataGrid1["ParameterColumn", rowIndex];
        }

        internal void ClearRows()
        {
            fmDataGrid1.Rows.Clear();
        }
    }
}
