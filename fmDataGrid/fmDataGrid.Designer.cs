using System;
using System.Drawing;
using System.Windows.Forms;

namespace fmDataGrid
{
    partial class fmDataGrid
    {
        //private Color m_currentRowColor = Color.Cyan;

        private void CopyEditedValueToCellValue()
        {
            CurrentCell.Value = CurrentCell.EditedFormattedValue;
        }

        private void fmDataGridTextChanged(object sender, EventArgs e)
        {
            //CopyEditedValueToCellValue();   STRANGE, BUT THIS LEAD TO BLACK CELLS
            CurrentCell.Value = (sender as TextBox).Text;
            if (CellValueChangedByUser != null)
            {
                CellValueChangedByUser(this, new DataGridViewCellEventArgs(CurrentCell.ColumnIndex, CurrentCell.RowIndex));
            }
        }

        private void fmCheckBoxClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((sender as fmDataGrid).Columns[e.ColumnIndex].GetType() == (new DataGridViewCheckBoxColumn()).GetType())
            {
                CopyEditedValueToCellValue();
            }
        }
        
        private void fmDataGridEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.TextChanged -= fmDataGridTextChanged;
            e.Control.TextChanged += fmDataGridTextChanged;
        }

        private void fmDataGridSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.GetType() == typeof(DataGridViewNumericalTextBoxColumn))
            {
                fmCalculationLibrary.fmValue val1 = fmCalculationLibrary.fmValue.ObjectToValue(e.CellValue1);
                fmCalculationLibrary.fmValue val2 = fmCalculationLibrary.fmValue.ObjectToValue(e.CellValue2);
                e.SortResult = val1 < val2 ? -1 : val1 > val2 ? 1 : 0;
                e.Handled = true;
            }
        }

        
        //public void SetRowColor(DataGridViewRow row, Color color)
        //{
        //    foreach(DataGridViewCell c in row.Cells)
        //    {
        //        c.Style.BackColor = color;
        //    }
        //}

        private void InitializeComponent()
        {
            #region Activate Immediate Writing text to cells
            EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(fmDataGridEditingControlShowing);
            #endregion

            #region Activate Immediate Writing checkBoxes to cells
            CellContentClick += fmCheckBoxClick;
            CellContentDoubleClick += fmCheckBoxClick;
            #endregion
            
            #region Setup font and row heights
            RowTemplate.Height = 18;
            Font = new Font(Font.FontFamily, 8.25f, FontStyle.Regular);
            #endregion

            SortCompare += fmDataGridSortCompare;
        }

        override protected void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (HighLightCurrentRow == true
                && CurrentCell != null 
                && e.RowIndex == CurrentCell.RowIndex)
            {
                //Color newColor = Color.LightGreen;
                Color newColor = Color.FromArgb(200, 255, 200);
                Color oldColor = e.CellStyle.BackColor;
                newColor = Color.FromArgb(oldColor.R * newColor.R / 255, 
                    oldColor.G * newColor.G / 255, 
                    oldColor.B * newColor.B / 255);
                e.CellStyle.BackColor = newColor;
            }
            base.OnCellPainting(e);
        }

        override protected void OnCurrentCellChanged(EventArgs e)
        {
            foreach (DataGridViewRow row in Rows)
                InvalidateRow(row.Index);
            base.OnCurrentCellChanged(e);
        }

        public event DataGridViewCellEventHandler CellValueChangedByUser;
    }
}
