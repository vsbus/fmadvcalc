using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using fmCalculatorsLibrary;
using FontStyle=System.Drawing.FontStyle;
using System.Reflection;

namespace fmCalcBlocksLibrary.Controls
{
    public partial class fmCalculationOptionView : TreeView
    {
        private TreeNode m_selectedLeaf;
        private TreeNode SelectedLeaf
        {
            get { return m_selectedLeaf; }
            set
            {
                bool valueIsNew = value != m_selectedLeaf;
                m_selectedLeaf = value;

                bool runCheckedChangedForUpdatingCalculationOptions = valueIsNew && CheckedChangedForUpdatingCalculationOptions != null;
                if (runCheckedChangedForUpdatingCalculationOptions)
                {
                    CheckedChangedForUpdatingCalculationOptions(this, new EventArgs());
                }

                bool runCheckedChanged = valueIsNew && CheckedChanged != null;
                if (runCheckedChanged)
                {
                    CheckedChanged(this, new EventArgs());
                }
            }
        }

        private static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            string result = value.ToString();
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                result = attributes[0].Description;

            return result;
        }

        private void CreateTree()
        {
            var globalNode = new TreeNode("Global");
            globalNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART_AND_DESIGN_GLOBAL_DP_CONST));
            globalNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART_AND_DESIGN_GLOBAL_QP_CONST));
            Nodes.Add(globalNode);
            
            var standartNode = new TreeNode("Standart");
            standartNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART3));
            standartNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART4));
            standartNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART8));
            Nodes.Add(standartNode);

            var designNode = new TreeNode("Design");
            designNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.DESIGN1));
            Nodes.Add(designNode);

            var optimizationNode = new TreeNode("Optimization");
            optimizationNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.OPTIMIZATION1));
            Nodes.Add(optimizationNode);

            SetSelectedOption(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.STANDART_AND_DESIGN_GLOBAL_DP_CONST);

            TreeView_AfterSelect(this, new TreeViewEventArgs(SelectedLeaf));
        }

        public fmCalculationOptionView()
        {
            InitializeComponent();
        }

// ReSharper disable InconsistentNaming
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
// ReSharper restore InconsistentNaming
        {
            if (e.Node.FirstNode == null)
            {
                for (TreeNode node = e.Node; node != null; node = node.Parent)
                {
                    SetNodeFontStyle(node, FontStyle.Bold);
                }

                if (SelectedLeaf != null && SelectedLeaf != e.Node)
                {
                    SelectedLeaf = e.Node;
                }
            }
        }

        private static void SetNodeFontStyle(TreeNode node, FontStyle fontStyle)
        {
            node.NodeFont = new Font("Microsoft Sans Serif", 8, fontStyle);
            node.Text = node.Text;
        }

// ReSharper disable InconsistentNaming
        private void TreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
// ReSharper restore InconsistentNaming
        {
            if (e.Node.FirstNode == null && SelectedLeaf != null)
            {
                for (TreeNode node = SelectedLeaf; node != null; node = node.Parent)
                {
                    SetNodeFontStyle(node, FontStyle.Regular);
                }
            }
        }

        public fmFilterMachiningCalculator.fmFilterMachiningCalculationOption GetSelectedOption()
        {
            if (SelectedLeaf == null)
            {
                throw new Exception("No calculation selected in fmCalculationOptionView");
            }

            foreach (fmFilterMachiningCalculator.fmFilterMachiningCalculationOption option in Enum.GetValues(typeof(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption)))
                if (GetEnumDescription(option) == SelectedLeaf.Text)
                    return option;

            throw new Exception("Calculation option for description [" + SelectedLeaf.Text + "] not found");
        }

        private static IEnumerable<TreeNode> GetNodes(TreeNodeCollection list)
        {
            var result = new List<TreeNode>();
            foreach (TreeNode node in list)
            {
                result.Add(node);
                result.AddRange(GetLeafs(node.Nodes));
            }
            return result;
        }
        private static IEnumerable<TreeNode> GetLeafs(TreeNodeCollection list)
        {
            var result = new List<TreeNode>();
            foreach (TreeNode node in list)
            {
                if (node.Nodes.Count == 0)
                    result.Add(node);
                else
                    result.AddRange(GetLeafs(node.Nodes));
            }
            return result;
        }

        public void SetSelectedOption(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption option)
        {
            foreach (TreeNode node in GetNodes(Nodes))
            {
                SetNodeFontStyle(node, FontStyle.Regular);
            }

            foreach (TreeNode leaf in GetLeafs(Nodes))
                if (GetEnumDescription(option) == leaf.Text)
                {
                    SelectedNode = SelectedLeaf = leaf;
                    for (TreeNode node = leaf; node != null; node = node.Parent)
                    {
                        SetNodeFontStyle(node, FontStyle.Bold);
                    }
                    return;
                }
        }

        public event EventHandler CheckedChangedForUpdatingCalculationOptions;
        public event EventHandler CheckedChanged;
    }
}