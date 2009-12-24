using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace fmDataGrid
{
    public class DataGridViewNumericalTextBoxColumn : DataGridViewColumn
    {
        public DataGridViewNumericalTextBoxColumn() : base(new DataGridViewNumericalTextBoxCell()) { }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewNumericalTextBoxCell)))
                    throw new InvalidCastException("Cell must be a NumericalTextBoxCell");
                base.CellTemplate = value;
            }
        }
    }
}
