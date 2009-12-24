using System.Windows.Forms;
using System;

namespace fmDataGrid
{
    public partial class fmDataGrid : DataGridView
    {
        private bool m_HighLightCurrentRow = false;

        public bool HighLightCurrentRow
        {
            set
            {
                m_HighLightCurrentRow = value;
            }
            get
            {
                return m_HighLightCurrentRow;
            }
        }

        public fmDataGrid()
        {
            InitializeComponent();
        }

        #region MouseWheel
        public bool MoveCursor(int deltaRow)
        {
            int rowIndex = CurrentCell.RowIndex + deltaRow;

            while (0 <= rowIndex
                && rowIndex < Rows.Count
                && Rows[rowIndex].Visible == false)
            {
                rowIndex += deltaRow;
            }

            if (0 <= rowIndex
                && rowIndex < Rows.Count)
            {
                CurrentCell = Rows[rowIndex].Cells[CurrentCell.ColumnIndex];
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x20a)
            {
                if (CurrentCell != null
                    && CurrentCell.RowIndex != -1
                    && CurrentCell.ColumnIndex != -1)
                {
                    int delta = (int)(m.WParam) >> 16;
                    int deltaRow = delta > 0 ? -1 : delta < 0 ? 1 : 0;

                    if (delta > 0)
                    {
                        MoveCursor(-1);
                    }
                    else if (delta < 0)
                    {
                        MoveCursor(1);
                    }

                    return;
                }
            }
            base.WndProc(ref m);
        }
        #endregion

        public T AddColumn<T>(string headerText) where T : DataGridViewColumn, new()
        {
            T column = new T();
            column.HeaderText = headerText;
            this.Columns.Add(column);
            return column;
        }
    }
}

