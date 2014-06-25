namespace FilterSimulationWithTablesAndGraphs
{
    partial class ColumnsOrderForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listViewExReorder1 = new ListViewCustomReorder.ListViewExReorder();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btnGroupParams = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Move Up";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(116, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "Move Down";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button3.Location = new System.Drawing.Point(116, 627);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 25);
            this.button3.TabIndex = 4;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.Location = new System.Drawing.Point(197, 627);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 25);
            this.button4.TabIndex = 5;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listViewExReorder1
            // 
            this.listViewExReorder1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewExReorder1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listViewExReorder1.FullRowSelect = true;
            this.listViewExReorder1.LineAfter = -1;
            this.listViewExReorder1.LineBefore = -1;
            this.listViewExReorder1.Location = new System.Drawing.Point(0, 0);
            this.listViewExReorder1.MultiSelect = false;
            this.listViewExReorder1.Name = "listViewExReorder1";
            this.listViewExReorder1.Size = new System.Drawing.Size(109, 664);
            this.listViewExReorder1.TabIndex = 1;
            this.listViewExReorder1.UseCompatibleStateImageBehavior = false;
            this.listViewExReorder1.View = System.Windows.Forms.View.Details;
            this.listViewExReorder1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewExReorder1_MouseUp);
            this.listViewExReorder1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listViewExReorder1_MouseMove);
            this.listViewExReorder1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewExReorder1_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Parameter Name";
            this.columnHeader1.Width = 115;
            // 
            // btnGroupParams
            // 
            this.btnGroupParams.Location = new System.Drawing.Point(116, 81);
            this.btnGroupParams.Name = "btnGroupParams";
            this.btnGroupParams.Size = new System.Drawing.Size(75, 63);
            this.btnGroupParams.TabIndex = 6;
            this.btnGroupParams.Text = "Group Parameters";
            this.btnGroupParams.UseVisualStyleBackColor = true;
            this.btnGroupParams.Click += new System.EventHandler(this.btnGroupParams_Click);
            // 
            // ColumnsOrderForm
            // 
            this.AcceptButton = this.button3;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button4;
            this.ClientSize = new System.Drawing.Size(284, 664);
            this.Controls.Add(this.btnGroupParams);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listViewExReorder1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ColumnsOrderForm";
            this.Text = "Parameters Order";
            this.Load += new System.EventHandler(this.ColumnsOrderForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListViewCustomReorder.ListViewExReorder listViewExReorder1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnGroupParams;

    }
}