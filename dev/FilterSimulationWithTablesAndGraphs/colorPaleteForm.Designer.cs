﻿namespace FilterSimulationWithTablesAndGraphs
{
    partial class colorPaleteForm
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
            this.moreColorsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.curColor = new System.Windows.Forms.PictureBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.curColor)).BeginInit();
            this.SuspendLayout();
            // 
            // moreColorsButton
            // 
            this.moreColorsButton.Location = new System.Drawing.Point(12, 233);
            this.moreColorsButton.Name = "moreColorsButton";
            this.moreColorsButton.Size = new System.Drawing.Size(176, 25);
            this.moreColorsButton.TabIndex = 0;
            this.moreColorsButton.Text = "More colors";
            this.moreColorsButton.UseVisualStyleBackColor = true;
            this.moreColorsButton.Click += new System.EventHandler(this.moreColorsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Picked color";
            // 
            // curColor
            // 
            this.curColor.Location = new System.Drawing.Point(65, 157);
            this.curColor.Name = "curColor";
            this.curColor.Size = new System.Drawing.Size(66, 46);
            this.curColor.TabIndex = 2;
            this.curColor.TabStop = false;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(12, 280);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 25);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(113, 280);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // colorPaleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 315);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.curColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moreColorsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "colorPaleteForm";
            this.Text = "Color";
            this.Load += new System.EventHandler(this.colorPaleteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.curColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button moreColorsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox curColor;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}