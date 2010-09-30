using System.Windows.Forms;

namespace fmFilterSimulationControl
{
    partial class fmUnitItem
    {

        public string UnitName
        {
            get { return unitName.Text;}
            set {unitName.Text = value;}
        }
        
        public ComboBox UnitComboBox
        {
            get { return unitComboBox;}
        }

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
            this.unitName = new System.Windows.Forms.Label();
            this.unitComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // unitName
            // 
            this.unitName.AutoSize = true;
            this.unitName.Dock = System.Windows.Forms.DockStyle.Left;
            this.unitName.Location = new System.Drawing.Point(0, 0);
            this.unitName.Name = "unitName";
            this.unitName.Size = new System.Drawing.Size(54, 13);
            this.unitName.TabIndex = 0;
            this.unitName.Text = "UnitName";
            // 
            // unitComboBox
            // 
            this.unitComboBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.unitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitComboBox.FormattingEnabled = true;
            this.unitComboBox.Location = new System.Drawing.Point(69, 0);
            this.unitComboBox.Name = "unitComboBox";
            this.unitComboBox.Size = new System.Drawing.Size(121, 21);
            this.unitComboBox.TabIndex = 1;
            // 
            // fmUnitItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.unitComboBox);
            this.Controls.Add(this.unitName);
            this.Name = "fmUnitItem";
            this.Size = new System.Drawing.Size(190, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label unitName;
        private ComboBox unitComboBox;
    }
}
