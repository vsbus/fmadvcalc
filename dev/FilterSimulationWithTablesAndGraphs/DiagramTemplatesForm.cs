using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FilterSimulation;
using fmCalculationLibrary;
using FilterSimulation.fmFilterObjects;
using fmCalculationLibrary.MeasureUnits;
using System.Xml;

namespace FilterSimulationWithTablesAndGraphs
{
    public partial class DiagramTemplatesForm : Form 
    {
        public string SelectedCurveName;
        private string currentDiagramTemplateName;
        private List<string> curvesTemplatesNamesToDelete;

        public DiagramTemplatesForm()
        {
            InitializeComponent();       
        }

        private void InitTreeView()
        {
            tvTemplatesTreeView.Nodes["FiltrationNode"].Nodes.Clear();
            tvTemplatesTreeView.Nodes["DeliqNode"].Nodes.Clear();
            tvTemplatesTreeView.Nodes["MixedNode"].Nodes.Clear();
            
            if (System.IO.File.Exists(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesFilename))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesFilename);

                foreach (XmlNode xn in doc.GetElementsByTagName(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesSavingTags.FiltrationCurves))
                {
                    XmlNodeList NamesNodes = xn.SelectNodes(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesSavingTags.CurveTemplateName);
                    foreach (XmlNode name in NamesNodes)
                    {
                        tvTemplatesTreeView.Nodes["FiltrationNode"].Nodes.Add(name.Attributes["id"].Value);
                    }
                }

                foreach (XmlNode xn in doc.GetElementsByTagName(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesSavingTags.DeliqCurves ))
                {
                    XmlNodeList NamesNodes = xn.SelectNodes(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesSavingTags.CurveTemplateName);
                    foreach (XmlNode name in NamesNodes)
                    {
                        tvTemplatesTreeView.Nodes["DeliqNode"].Nodes.Add(name.Attributes["id"].Value);
                    }
                }

                foreach (XmlNode xn in doc.GetElementsByTagName(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesSavingTags.MixedCurves ))
                {
                    XmlNodeList NamesNodes = xn.SelectNodes(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesSavingTags.CurveTemplateName);
                    foreach (XmlNode name in NamesNodes)
                    {
                        tvTemplatesTreeView.Nodes["MixedNode"].Nodes.Add(name.Attributes["id"].Value);
                    }
                }
                doc.Save(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesFilename);                               
            }
            CheckIfRootNodesAreEmpty();
        }

        private void CheckIfRootNodesAreEmpty() 
        {
            foreach (TreeNode node in tvTemplatesTreeView.Nodes)
            {
                if (node.FirstNode == null)
                    node.ForeColor = Color.Gray;
                else
                    node.ForeColor = Color.Black;
            }
        }

        private void btnDeleteCurveTemplate_Click(object sender, EventArgs e)
        {
            addCurveTemplateToDelete();
            CheckIfRootNodesAreEmpty();            
        }

        private void addCurveTemplateToDelete()
        {
            curvesTemplatesNamesToDelete.Add(tvTemplatesTreeView.SelectedNode.Text);
            selectNewNodeAfterDelete();
        }

        private void selectNewNodeAfterDelete() // After tree node deleting we select next node or the first existing from the top
        {
            TreeNode tmpNode = tvTemplatesTreeView.SelectedNode;
            if (tmpNode.NextNode != null)
            {
                tvTemplatesTreeView.SelectedNode = tmpNode.NextNode;
                tmpNode.Remove();
                tvTemplatesTreeView.Select();
                return;
            }
            else
            {
                for (int i = 0; i < tvTemplatesTreeView.Nodes.Count; ++i)
                {
                    if (tvTemplatesTreeView.Nodes[i].FirstNode != null)
                        if (tvTemplatesTreeView.Nodes[i].FirstNode != tmpNode)
                        {
                            tvTemplatesTreeView.SelectedNode = tvTemplatesTreeView.Nodes[i].FirstNode;
                            tmpNode.Remove();
                            tvTemplatesTreeView.Select();
                            return;
                        }
                }
            }
            tmpNode.Remove();
            // if all templates were deleted we load default curve
            fmFilterSimulationWithTablesAndGraphs.SelfRef.LoadParametersFromDiagramTemplate(fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesSavingTags.TempCurve);
        }

        private void DeleteCurveTemplate()
        {
            foreach (string templateName in curvesTemplatesNamesToDelete)
            {
                bool flag = false;
                XmlDocument doc = new XmlDocument();
                doc.Load(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesFilename);

                List<XmlNode> templatesNodes = new List<XmlNode>();

                foreach (XmlNode xn in doc.GetElementsByTagName(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesSavingTags.CurveTemplateName))
                {

                    if (xn.Attributes["id"].Value == templateName)
                    {
                        xn.ParentNode.RemoveChild(xn);
                        flag = true;
                        break;
                    }

                }
                doc.Save(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesFilename);
                if (flag)
                    DeleteCurveTemplate();
            }
        }
        
        private void DiagramTemplatesForm_Load(object sender, EventArgs e)
        {
            SelectedCurveName = null;
            InitTreeView();
            tvTemplatesTreeView.ExpandAll();
            CheckCurrentDiagramTemplate(e);
            HideOrShowMixedAndDeliqTemplates();
            curvesTemplatesNamesToDelete = new List<string>();
        }

        private void CheckCurrentDiagramTemplate(EventArgs e)
        {
            foreach (TreeNode node in tvTemplatesTreeView.Nodes) 
            {
                if (node.Nodes.Count != 0)
                    foreach (TreeNode childnode in node.Nodes)
                    {
                        if (childnode.Text == currentDiagramTemplateName)
                        {
                            tvTemplatesTreeView.SelectedNode = childnode;
                            tvTemplatesTreeView.Select();
                        }
                    }                
            }
        }

        private void tvTemplatesTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Name !="")
                e.Cancel = true;
            if (tvTemplatesTreeView.SelectedNode == null)
            {
                btnDeleteCurveTemplate.Enabled = false;                
            }
            else
            {
                btnDeleteCurveTemplate.Enabled = true;                
            }
        }

        private void tvTemplatesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvTemplatesTreeView.SelectedNode == null)
            {
                btnDeleteCurveTemplate.Enabled = false;
            }
            else
            {
                btnDeleteCurveTemplate.Enabled = true;                

                SelectedCurveName = tvTemplatesTreeView.SelectedNode.Text;

                if (tvTemplatesTreeView.SelectedNode.ForeColor == Color.Gray)
                {
                    DialogResult diagresult = MessageBox.Show("Current simulation(s) has no deliquring. This template will be loaded, but deliquoring parameters will be neglected", "Warning", MessageBoxButtons.OK);
                }

                fmFilterSimulationWithTablesAndGraphs.SelfRef.LoadParametersFromDiagramTemplate(SelectedCurveName);
            }
        }

        public void GetCurrentDiagramTemplateName(string DiagramTemplateName)
        {
            currentDiagramTemplateName = DiagramTemplateName;
        }

        private void HideOrShowMixedAndDeliqTemplates()
        {
            if (fmFilterSimulationWithTablesAndGraphs.SelfRef.isDeliqParametersHidden())
            {
                tvTemplatesTreeView.Nodes["DeliqNode"].ForeColor = Color.Gray;
                tvTemplatesTreeView.Nodes["MixedNode"].ForeColor = Color.Gray;
                foreach (TreeNode node in tvTemplatesTreeView.Nodes["DeliqNode"].Nodes)
                {
                    node.ForeColor = Color.Gray;
                }
                foreach (TreeNode node in tvTemplatesTreeView.Nodes["MixedNode"].Nodes)
                {
                    node.ForeColor = Color.Gray;
                }
                tvTemplatesTreeView.Nodes["DeliqNode"].Collapse();
                tvTemplatesTreeView.Nodes["MixedNode"].Collapse();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DeleteCurveTemplate();
        }
    }
}
