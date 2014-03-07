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
            DeleteCurveTemplate();
            CheckIfRootNodesAreEmpty();
        }

        private void DeleteCurveTemplate()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesFilename);
            foreach (XmlNode xn in doc.GetElementsByTagName(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesSavingTags.CurveTemplateName))
            {
                if (xn.Attributes["id"].Value == tvTemplatesTreeView.SelectedNode.Text )
                {
                    xn.ParentNode.RemoveChild(xn);
                    break;
                }
            }
            doc.Save(FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.DiagramTemplatesFilename);
            tvTemplatesTreeView.SelectedNode.Remove();
        }
        
        private void DiagramTemplatesForm_Load(object sender, EventArgs e)
        {
            SelectedCurveName = null;
            InitTreeView();
            tvTemplatesTreeView.ExpandAll();
            CheckCurrentDiagramTemplate(e);
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
                btnDeleteCurveTemplate.Enabled = false;
            else
                btnDeleteCurveTemplate.Enabled = true;
        }

        private void tvTemplatesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvTemplatesTreeView.SelectedNode == null)
                btnDeleteCurveTemplate.Enabled = false;
            else
            {
                btnDeleteCurveTemplate.Enabled = true;
                
                SelectedCurveName=tvTemplatesTreeView.SelectedNode.Text;

                fmFilterSimulationWithTablesAndGraphs.SelfRef.LoadParametersFromDiagramTemplate(SelectedCurveName);          
            }
        }

        public void GetCurrentDiagramTemplateName(string DiagramTemplateName)
        {
            currentDiagramTemplateName = DiagramTemplateName;
        }
    }
}
