using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilterSimulationWithTablesAndGraphs
{  
    public partial class ColumnsOrderForm : Form
    {
        private DataGridView m_grid;        

        public ColumnsOrderForm()
        {
            InitializeComponent();
        }

        public ColumnsOrderForm(DataGridView grid)
        {
            InitializeComponent();
            m_grid = grid;
        }

        class ParameterFromTable
        {
            public string Caption;
            public int DisplayIndex;
            public bool Visible;
        }

        List<ParameterFromTable> parametersFromTableForCancelation=new List<ParameterFromTable>();
        private void ColumnsOrderForm_Load(object sender, EventArgs e)
        {
            var parametersFromTable =new List<ParameterFromTable>();
            foreach (DataGridViewColumn col in m_grid.Columns)
            {
                if (col.Visible == true && col.HeaderText != "" && col.HeaderText != "SimSeries" && col.HeaderText != "Simulation Name" && col.HeaderText != "Calculation Option")
                {
                    var newParam = new ParameterFromTable { Caption = col.HeaderText, DisplayIndex = col.DisplayIndex };
                    parametersFromTable.Add(newParam);
                }

                parametersFromTableForCancelation.Add(new ParameterFromTable { Caption = col.HeaderText, DisplayIndex = col.DisplayIndex });
            }

            ListViewItem[] parametrsForListview = new ListViewItem[parametersFromTable.Count];

            parametersFromTable.Sort((a,b)=>a.DisplayIndex.CompareTo(b.DisplayIndex));

            listViewExReorder1.Columns[0].Width = 105;

            int i = 0;
            foreach (ParameterFromTable param in parametersFromTable)
            {
                parametrsForListview[i] = new ListViewItem(param.Caption);
                parametrsForListview[i].BackColor = FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.SelfRef.getParamKindColor(param.Caption.Remove(param.Caption.IndexOf(" (")));
                parametrsForListview[i].BackColor = ControlPaint.LightLight(parametrsForListview[i].BackColor);
                parametrsForListview[i].BackColor = ControlPaint.LightLight(parametrsForListview[i].BackColor);
                ++i;
            }

            listViewExReorder1.Items.AddRange(parametrsForListview);
        }
        // The LVItem being dragged
        private ListViewItem _itemDnD = null;        

        private void listViewExReorder1_MouseDown(object sender, MouseEventArgs e)
        {
            _itemDnD = listViewExReorder1.GetItemAt(e.X, e.Y);
            // if the LV is still empty, no item will be found anyway, so we don't have to consider this case
        }

        private void listViewExReorder1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_itemDnD == null)
                return;

            // Show the user that a drag operation is happening
            Cursor = Cursors.Hand;

            // calculate the bottom of the last item in the LV so that you don't have to stop your drag at the last item
            int lastItemBottom = Math.Min(e.Y, listViewExReorder1.Items[listViewExReorder1.Items.Count - 1].GetBounds(ItemBoundsPortion.Entire).Bottom - 1);

            // use 0 instead of e.X so that you don't have to keep inside the columns while dragging
            ListViewItem itemOver = listViewExReorder1.GetItemAt(0, lastItemBottom);

            if (itemOver == null)
                return;

            Rectangle rc = itemOver.GetBounds(ItemBoundsPortion.Entire);
            if (e.Y < rc.Top + (rc.Height / 2))
            {
                listViewExReorder1.LineBefore = itemOver.Index;
                listViewExReorder1.LineAfter = -1;
            }
            else
            {
                listViewExReorder1.LineBefore = -1;
                listViewExReorder1.LineAfter = itemOver.Index;
            }

            // invalidate the LV so that the insertion line is shown
            listViewExReorder1.Invalidate();
        }

        private void listViewExReorder1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_itemDnD == null)
                return;

            try
            {
                // calculate the bottom of the last item in the LV so that you don't have to stop your drag at the last item
                int lastItemBottom = Math.Min(e.Y, listViewExReorder1.Items[listViewExReorder1.Items.Count - 1].GetBounds(ItemBoundsPortion.Entire).Bottom - 1);

                // use 0 instead of e.X so that you don't have to keep inside the columns while dragging
                ListViewItem itemOver = listViewExReorder1.GetItemAt(0, lastItemBottom);

                if (itemOver == null)
                    return;

                Rectangle rc = itemOver.GetBounds(ItemBoundsPortion.Entire);

                // find out if we insert before or after the item the mouse is over
                bool insertBefore;
                if (e.Y < rc.Top + (rc.Height / 2))
                {
                    insertBefore = true;
                }
                else
                {
                    insertBefore = false;
                }

                if (_itemDnD != itemOver) // if we dropped the item on itself, nothing is to be done
                {
                    if (insertBefore)
                    {
                        if (itemOver.Index < _itemDnD.Index)                        
                            moveColumnUp(_itemDnD, itemOver);
                        else
                            moveColumnDown(_itemDnD, listViewExReorder1.Items[itemOver.Index -1]);

                        listViewExReorder1.Items.Remove(_itemDnD);
                        listViewExReorder1.Items.Insert(itemOver.Index, _itemDnD);
                        
                    }
                    else
                    {
                        if (itemOver.Index < _itemDnD.Index)
                            moveColumnUp(_itemDnD, listViewExReorder1.Items[itemOver.Index + 1]);
                        else
                            moveColumnDown(_itemDnD, itemOver);

                        listViewExReorder1.Items.Remove(_itemDnD);
                        listViewExReorder1.Items.Insert(itemOver.Index + 1, _itemDnD);
                    }
                }

                // clear the insertion line
                listViewExReorder1.LineAfter =
                listViewExReorder1.LineBefore = -1;

                listViewExReorder1.Invalidate();

            }
            finally
            {
                // finish drag&drop operation
                _itemDnD = null;
                Cursor = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listViewExReorder1.SelectedItems.Count == 0 || listViewExReorder1.SelectedItems[0].Index == 0)
                return;

            var currentIndex = listViewExReorder1.SelectedItems[0].Index;
            var itemToMoveUp = listViewExReorder1.Items[currentIndex];
            
            if (currentIndex > 0)
            {
                listViewExReorder1.Items.RemoveAt(currentIndex);
                listViewExReorder1.Items.Insert(currentIndex - 1, itemToMoveUp);                
            }

            moveColumnUp(itemToMoveUp);

            listViewExReorder1.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listViewExReorder1.SelectedItems.Count == 0)
                return;

            var currentIndex = listViewExReorder1.SelectedItems[0].Index;
            var itemToMoveDown = listViewExReorder1.Items[currentIndex];

            if (currentIndex < listViewExReorder1.Items.Count-1)
            {
                listViewExReorder1.Items.RemoveAt(currentIndex);
                listViewExReorder1.Items.Insert(currentIndex + 1, itemToMoveDown);
            }

            moveColumnDown(itemToMoveDown);

            listViewExReorder1.Select();
        }

        private void moveColumnUp(ListViewItem itemToMoveUp)
        {
            var parametersFromTable = new List<ParameterFromTable>();

            foreach (DataGridViewColumn col in m_grid.Columns)
            {
                parametersFromTable.Add(new ParameterFromTable { Caption = col.HeaderText, DisplayIndex = col.DisplayIndex, Visible = col.Visible });
            }

            parametersFromTable.Sort((a, b) => a.DisplayIndex.CompareTo(b.DisplayIndex));

            for (int i = 0; i < parametersFromTable.Count; i++)
            {
                if (parametersFromTable[i].Caption == itemToMoveUp.Text)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (parametersFromTable[j].Visible == true)
                        {
                            var tmp = parametersFromTable[i].Caption;
                            parametersFromTable[i].Caption = parametersFromTable[j].Caption;
                            parametersFromTable[j].Caption = tmp;
                            break;
                        }
                    }
                    break;
                }                
            }
            refreshGridColumnsOrder(parametersFromTable);
        }

        private void moveColumnDown(ListViewItem itemToMoveDown)
        {
            var parametersFromTable = new List<ParameterFromTable>();

            foreach (DataGridViewColumn col in m_grid.Columns)
            {
                parametersFromTable.Add(new ParameterFromTable { Caption = col.HeaderText, DisplayIndex = col.DisplayIndex, Visible = col.Visible });
            }

            parametersFromTable.Sort((a, b) => a.DisplayIndex.CompareTo(b.DisplayIndex));

            for (int i = 0; i < parametersFromTable.Count; i++)
            {
                if (parametersFromTable[i].Caption == itemToMoveDown.Text)
                {
                    for (int j = i + 1; j < parametersFromTable.Count; j++)
                    {
                        if (parametersFromTable[j].Visible == true)
                        {
                            var tmp = parametersFromTable[i].Caption;
                            parametersFromTable[i].Caption = parametersFromTable[j].Caption;
                            parametersFromTable[j].Caption = tmp;
                            break;
                        }
                    }
                    break;
                }
            }
            refreshGridColumnsOrder(parametersFromTable);
        }

        private void moveColumnUp(ListViewItem itemToMoveUp, ListViewItem itemToMoveDown)
        {
            var parametersFromTable = new List<ParameterFromTable>();

            foreach (DataGridViewColumn col in m_grid.Columns)
            {
                parametersFromTable.Add(new ParameterFromTable { Caption = col.HeaderText, DisplayIndex = col.DisplayIndex, Visible = col.Visible });
            }

            parametersFromTable.Sort((a, b) => a.DisplayIndex.CompareTo(b.DisplayIndex));

            for (int i = 0; i < parametersFromTable.Count; i++)
            {
                if (parametersFromTable[i].Caption == itemToMoveUp.Text)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (parametersFromTable[j].Caption == itemToMoveDown.Text)
                        {
                            parametersFromTable[i].DisplayIndex = parametersFromTable[j].DisplayIndex;
                            for (int k = j; k < i; k++)
                            {
                                parametersFromTable[k].DisplayIndex++;
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            refreshGridColumnsOrder(parametersFromTable);
        }

        private void moveColumnDown(ListViewItem itemToMoveDown, ListViewItem itemToMoveUp)
        {
            var parametersFromTable = new List<ParameterFromTable>();

            foreach (DataGridViewColumn col in m_grid.Columns)
            {
                parametersFromTable.Add(new ParameterFromTable { Caption = col.HeaderText, DisplayIndex = col.DisplayIndex, Visible = col.Visible });
            }

            parametersFromTable.Sort((a, b) => a.DisplayIndex.CompareTo(b.DisplayIndex));

            for (int i = 0; i < parametersFromTable.Count; i++)
            {
                if (parametersFromTable[i].Caption == itemToMoveDown.Text)
                {
                    for (int j = i + 1; j < parametersFromTable.Count; j++)
                    {
                        if (parametersFromTable[j].Caption == itemToMoveUp.Text)
                        {
                            parametersFromTable[i].DisplayIndex = parametersFromTable[j].DisplayIndex;
                            for (int k = i+1; k <= j; k++)
                            {
                                parametersFromTable[k].DisplayIndex--;
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            refreshGridColumnsOrder(parametersFromTable);
        }

        private void refreshGridColumnsOrder(List<ParameterFromTable> parametersFromTable)
        {
            parametersFromTable.Sort((a, b) => a.DisplayIndex.CompareTo(b.DisplayIndex));

            foreach (var param in parametersFromTable)
            {
                foreach (DataGridViewColumn col in m_grid.Columns)
                {
                    if (col.HeaderText == param.Caption)
                    {
                        col.DisplayIndex = param.DisplayIndex;
                        break;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refreshGridColumnsOrder(parametersFromTableForCancelation);
            Close();
        }

        private void btnGroupParams_Click(object sender, EventArgs e)
        {
            if (listViewExReorder1.Items.Count == 0)
                return;

            var usedColors = new List<Color>();
            var newItems = new List<ListViewItem>();

            foreach (ListViewItem item in listViewExReorder1.Items)
            {
                if (!usedColors.Contains(item.BackColor))
                    usedColors.Add(item.BackColor);
            }

            foreach (var color in usedColors)
            {
                foreach (ListViewItem item in listViewExReorder1.Items)
                {
                    if (item.BackColor == color)
                    {
                        newItems.Add(item);
                    }
                }
            }
            listViewExReorder1.Items.Clear();
            listViewExReorder1.Items.AddRange(newItems.ToArray());

            var parametersFromTable = new List<ParameterFromTable>();

            foreach (DataGridViewColumn col in m_grid.Columns)
            {
                parametersFromTable.Add(new ParameterFromTable { Caption = col.HeaderText, DisplayIndex = col.DisplayIndex, Visible = col.Visible });
            }

            ParameterFromTable[] newParametersList = new ParameterFromTable[parametersFromTable.Count];

            parametersFromTable.Sort((a, b) => a.DisplayIndex.CompareTo(b.DisplayIndex));

            for (int i = 0; i < parametersFromTable.Count; i++)
            {
                bool isFound = false;
                foreach (ListViewItem item in listViewExReorder1.Items)
                {
                    if (item.Text == parametersFromTable[i].Caption)
                    {
                        isFound = true;
                        break;
                    }                    
                }
                if (!isFound)
                {
                    newParametersList[i] = parametersFromTable[i];
                    isFound = false;
                }
            }
            
            int j = 0;
            for (int i = 0; i < newParametersList.Length; i++)
            {
                if (newParametersList[i] == null)
                {
                    newParametersList[i] = new ParameterFromTable { Caption = listViewExReorder1.Items[j].Text,DisplayIndex=i };
                    ++j;
                }
            }

            refreshGridColumnsOrder(newParametersList.ToList());
        }
    }
}
