namespace fmControls
{
    partial class fmCheckedListBoxWithListiongOfSelectedItems
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.selectedItemsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.SuspendLayout();
            // 
            // mainCheckedListBox
            // 
            this.mainCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainCheckedListBox.FormattingEnabled = true;
            this.mainCheckedListBox.Location = new System.Drawing.Point(0, 0);
            this.mainCheckedListBox.Name = "mainCheckedListBox";
            this.mainCheckedListBox.Size = new System.Drawing.Size(109, 109);
            this.mainCheckedListBox.TabIndex = 0;
            // 
            // selectedItemsCheckedListBox
            // 
            this.selectedItemsCheckedListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.selectedItemsCheckedListBox.FormattingEnabled = true;
            this.selectedItemsCheckedListBox.Location = new System.Drawing.Point(0, 124);
            this.selectedItemsCheckedListBox.Name = "selectedItemsCheckedListBox";
            this.selectedItemsCheckedListBox.Size = new System.Drawing.Size(109, 49);
            this.selectedItemsCheckedListBox.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 121);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(109, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // fmCheckedListBoxWithListiongOfSelectedItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainCheckedListBox);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.selectedItemsCheckedListBox);
            this.Name = "fmCheckedListBoxWithListiongOfSelectedItems";
            this.Size = new System.Drawing.Size(109, 173);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox mainCheckedListBox;
        private System.Windows.Forms.CheckedListBox selectedItemsCheckedListBox;
        private System.Windows.Forms.Splitter splitter1;
    }
}
