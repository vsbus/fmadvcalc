using System;
using System.Collections.Generic;
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
            mainCheckedListBox.ItemCheck += mainCheckedListBox_ItemCheck;
            selectedItemsCheckedListBox.ItemCheck += selectedItemsCheckedListBox_ItemCheck;
        }

        // ReSharper disable InconsistentNaming
        void selectedItemsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                var clb = sender as CheckedListBox;
                // ReSharper disable PossibleNullReferenceException
                object item = clb.Items[e.Index];
                // ReSharper restore PossibleNullReferenceException
                mainCheckedListBox.SetItemChecked(mainCheckedListBox.Items.IndexOf(item), false);
                e.NewValue = CheckState.Checked;
            }
        }

        // ReSharper disable InconsistentNaming
        void mainCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            var items = new List<object>();

            var clb = sender as CheckedListBox;
            // ReSharper disable PossibleNullReferenceException
            for (int i = 0; i < clb.Items.Count; ++i)
            // ReSharper restore PossibleNullReferenceException
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

        private static void FillListBox(ListBox listBox, List<object> items)
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
