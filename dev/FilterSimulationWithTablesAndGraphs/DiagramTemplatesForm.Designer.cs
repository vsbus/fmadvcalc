namespace FilterSimulationWithTablesAndGraphs
{
    partial class DiagramTemplatesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Filtration Curves");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Deliquering Curves");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Mixed Curves");
            this.tvTemplatesTreeView = new System.Windows.Forms.TreeView();
            this.btnDeleteCurveTemplate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tvTemplatesTreeView
            // 
            this.tvTemplatesTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvTemplatesTreeView.Location = new System.Drawing.Point(12, 5);
            this.tvTemplatesTreeView.Name = "tvTemplatesTreeView";
            treeNode1.Name = "FiltrationNode";
            treeNode1.Text = "Filtration Curves";
            treeNode2.Name = "DeliqNode";
            treeNode2.Text = "Deliquering Curves";
            treeNode3.Name = "MixedNode";
            treeNode3.Text = "Mixed Curves";
            this.tvTemplatesTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.tvTemplatesTreeView.Size = new System.Drawing.Size(281, 233);
            this.tvTemplatesTreeView.TabIndex = 0;
            this.tvTemplatesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTemplatesTreeView_AfterSelect);
            this.tvTemplatesTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvTemplatesTreeView_BeforeSelect);
            // 
            // btnDeleteCurveTemplate
            // 
            this.btnDeleteCurveTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCurveTemplate.Location = new System.Drawing.Point(12, 245);
            this.btnDeleteCurveTemplate.Name = "btnDeleteCurveTemplate";
            this.btnDeleteCurveTemplate.Size = new System.Drawing.Size(96, 25);
            this.btnDeleteCurveTemplate.TabIndex = 1;
            this.btnDeleteCurveTemplate.Text = "Delete Template";
            this.btnDeleteCurveTemplate.UseVisualStyleBackColor = true;
            this.btnDeleteCurveTemplate.Click += new System.EventHandler(this.btnDeleteCurveTemplate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(218, 245);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(133, 245);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // DiagramTemplatesForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(305, 278);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDeleteCurveTemplate);
            this.Controls.Add(this.tvTemplatesTreeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DiagramTemplatesForm";
            this.Text = "Curves Templates";
            this.Load += new System.EventHandler(this.DiagramTemplatesForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvTemplatesTreeView;
        private System.Windows.Forms.Button btnDeleteCurveTemplate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}