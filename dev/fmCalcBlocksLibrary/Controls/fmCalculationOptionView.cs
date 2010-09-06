using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using fmCalcBlocksLibrary.Blocks;
using fmCalculatorsLibrary;
using FontStyle=System.Drawing.FontStyle;
using System.Reflection;

namespace fmCalcBlocksLibrary.Controls
{
    public partial class fmCalculationOptionView : TreeView
    {
        private TreeNode m_SelectedLeaf;
        private TreeNode SelectedLeaf
        {
            get { return m_SelectedLeaf; }
            set
            {
                bool valueIsNew = value != m_SelectedLeaf;
                m_SelectedLeaf = value;

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
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                result = attributes[0].Description;

            return result;
        }

        private void CreateTree()
        {
            TreeNode standartNode = new TreeNode("Standart");
            standartNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.FilterMachiningCalculationOption.Standart1));
            standartNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.FilterMachiningCalculationOption.Standart2));
            standartNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.FilterMachiningCalculationOption.Standart3));
            standartNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.FilterMachiningCalculationOption.Standart4));
            standartNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.FilterMachiningCalculationOption.Standart7));
            standartNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.FilterMachiningCalculationOption.Standart8));
            standartNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.FilterMachiningCalculationOption.StandartForRanges));
            standartNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.FilterMachiningCalculationOption.StandartGlobal));
            Nodes.Add(standartNode);

            TreeNode designNode = new TreeNode("Design");
            designNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.FilterMachiningCalculationOption.Design1));
            designNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.FilterMachiningCalculationOption.DesignGlobal));
            Nodes.Add(designNode);

            TreeNode optimizationNode = new TreeNode("Optimization");
            optimizationNode.Nodes.Add(GetEnumDescription(fmFilterMachiningCalculator.FilterMachiningCalculationOption.Optimization1));
            Nodes.Add(optimizationNode);

            SetSelectedOption(fmFilterMachiningCalculator.FilterMachiningCalculationOption.Standart1);

            TreeView_AfterSelect(this, new TreeViewEventArgs(SelectedLeaf));
        }

        public fmCalculationOptionView()
            : base()
        {
            InitializeComponent();
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.FirstNode == null)
            {
                for (TreeNode node = e.Node; node != null; node = node.Parent)
                {
                    SetNodeFontStyle(node, FontStyle.Bold);
                }

                if (SelectedLeaf != e.Node)
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

        private void TreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.FirstNode == null && SelectedLeaf != null)
            {
                for (TreeNode node = SelectedLeaf; node != null; node = node.Parent)
                {
                    SetNodeFontStyle(node, FontStyle.Regular);
                }
            }
        }

        public fmFilterMachiningCalculator.FilterMachiningCalculationOption GetSelectedOption()
        {
            if (SelectedLeaf == null)
            {
                throw new Exception("No calculation selected in fmCalculationOptionView");
            }

            foreach (fmFilterMachiningCalculator.FilterMachiningCalculationOption option in Enum.GetValues(typeof(fmFilterMachiningCalculator.FilterMachiningCalculationOption)))
                if (GetEnumDescription(option) == SelectedLeaf.Text)
                    return option;

            throw new Exception("Calculation option for description [" + SelectedLeaf.Text + "] not found");
        }

        private static List<TreeNode> GetNodes(TreeNodeCollection list)
        {
            List<TreeNode> result = new List<TreeNode>();
            foreach (TreeNode node in list)
            {
                result.Add(node);
                result.AddRange(GetLeafs(node.Nodes));
            }
            return result;
        }
        private static List<TreeNode> GetLeafs(TreeNodeCollection list)
        {
            List<TreeNode> result = new List<TreeNode>();
            foreach (TreeNode node in list)
            {
                if (node.Nodes == null || node.Nodes.Count == 0)
                    result.Add(node);
                else
                    result.AddRange(GetLeafs(node.Nodes));
            }
            return result;
        }

        public void SetSelectedOption(fmFilterMachiningCalculator.FilterMachiningCalculationOption option)
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