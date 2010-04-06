using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace fmControls
{
    public partial class fmCheckedListBoxWithListiongOfSelectedItems : UserControl
    {
        public CheckedListBox.ObjectCollection CheckedItems
        {
            get
            {
                //return mainCheckedListBox.CheckedItems;
                return selectedItemsCheckedListBox.Items;
            }
        }

        public event EventHandler SelectedItemsChanged;

        public fmCheckedListBoxWithListiongOfSelectedItems()
        {
            InitializeComponent();
            mainCheckedListBox.CheckOnClick = true;
            mainCheckedListBox.ItemCheck += new ItemCheckEventHandler(mainCheckedListBox_ItemCheck);
            selectedItemsCheckedListBox.ItemCheck += new ItemCheckEventHandler(selectedItemsCheckedListBox_ItemCheck);
        }

        void selectedItemsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                CheckedListBox clb = sender as CheckedListBox;
                object item = clb.Items[e.Index];
                mainCheckedListBox.SetItemChecked(mainCheckedListBox.Items.IndexOf(item), false);
                e.NewValue = CheckState.Checked;
            }
        }

        void mainCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<object> items = new List<object>();

            CheckedListBox clb = sender as CheckedListBox;
            for (int i = 0; i < clb.Items.Count; ++i)
            {
                if (clb.GetItemChecked(i) ^ (e.Index == i))
                    items.Add(clb.Items[i]);
            }

            BindSelectedItemsCheckedListBox(items);
            if (SelectedItemsChanged != null)
                SelectedItemsChanged(this, new EventArgs());
        }

        private void BindSelectedItemsCheckedListBox(List<object> items)
        {
            selectedItemsCheckedListBox.Items.Clear();
            foreach (object item in items)
            {
                selectedItemsCheckedListBox.Items.Add(item, true);
            }
        }

        public void AddItem(object item)
        {
            mainCheckedListBox.Items.Add(item);
        }

        private void FillListBox(ListBox listBox, List<object> items)
        {
            for (int i = listBox.Items.Count - 1; i >= 0; --i)
                if (!items.Contains(listBox.Items[i]))
                    listBox.Items.RemoveAt(i);

            for (int i = 0, j = 0; j < items.Count; ++i, ++j)
            {
                if (i == listBox.Items.Count
                    || listBox.Items[i] != items[j])
                {
                    listBox.Items.Insert(i, items[j]);
                }
            }
        }

        public void FillWithItems(List<object> items)
        {
            FillListBox(mainCheckedListBox, items);
        }

        public void RemoveItem(object item)
        {
            mainCheckedListBox.Items.Remove(item);
            selectedItemsCheckedListBox.Items.Remove(item);
        }
    }
}
