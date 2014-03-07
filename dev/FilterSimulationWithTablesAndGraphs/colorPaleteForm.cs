using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilterSimulationWithTablesAndGraphs
{
    public partial class colorPaleteForm : Form
    {
        private ColorButton colorButton;

        public Color Color;
        private Color ColorForCancelation;

        public List<PictureBox> picturesList = new List<PictureBox>();

        public static Color[] colorList = new Color[48]
        {
            Color.FromArgb(255, 255, 128, 128),
                Color.FromArgb(255, 255, 255, 128),
                Color.FromArgb(255, 128, 255, 128),
                Color.FromArgb(255, 0, 255, 128),
                Color.FromArgb(255, 128, 255, 255),
                Color.FromArgb(255, 0, 128, 255),
                Color.FromArgb(255, 255, 128, 192),
                Color.FromArgb(255, 255, 128, 255),
                Color.FromArgb(255, 255, 0, 0),
                Color.FromArgb(255, 255, 255, 0),
                Color.FromArgb(255, 128, 255, 0),
                Color.FromArgb(255, 0, 255, 64),
                Color.FromArgb(255, 0, 255, 255),
                Color.FromArgb(255, 0, 128, 192),
                Color.FromArgb(255, 128, 128, 192),
                Color.FromArgb(255, 255, 0, 255),
                Color.FromArgb(255, 128, 64, 64),
                Color.FromArgb(255, 255, 128, 64),
                Color.FromArgb(255, 0, 255, 0),
                Color.FromArgb(255, 0, 128, 128),
                Color.FromArgb(255, 0, 64, 128),
                Color.FromArgb(255, 128, 128, 255),
                Color.FromArgb(255, 128, 0, 64),
                Color.FromArgb(255, 255, 0, 128),
                Color.FromArgb(255, 128, 0, 0),
                Color.FromArgb(255, 255, 128, 0),
                Color.FromArgb(255, 0, 128, 0),
                Color.FromArgb(255, 0, 128, 64),
                Color.FromArgb(255, 0, 0, 255),
                Color.FromArgb(255, 0, 0, 160),
                Color.FromArgb(255, 128, 0, 128),
                Color.FromArgb(255, 128, 0, 255),
                Color.FromArgb(255, 64, 0, 0),
                Color.FromArgb(255, 128, 64, 0),
                Color.FromArgb(255, 0, 64, 0),
                Color.FromArgb(255, 0, 64, 64),
                Color.FromArgb(255, 0, 0, 128),
                Color.FromArgb(255, 0, 0, 64),
                Color.FromArgb(255, 64, 0, 64),
                Color.FromArgb(255, 64, 0, 128),
                Color.FromArgb(255, 0, 0, 0),
                Color.FromArgb(255, 128, 128, 0),
                Color.FromArgb(255, 128, 128, 64),
                Color.FromArgb(255, 128, 128, 128),
                Color.FromArgb(255, 64, 128, 128),
                Color.FromArgb(255, 192, 192, 192),
                Color.FromArgb(255, 64, 0, 16),
                Color.FromArgb(255, 255, 255, 255)
        };

        public colorPaleteForm(ColorButton cb)
        {
            InitializeComponent();
            colorButton = cb;
        }

        PictureBox indexPic = new PictureBox();

        private void colorPaleteForm_Load(object sender, EventArgs e)
        {
            LocateForm();

            int x = 6, y = 5;

            for (int i = 0; i < 48; ++i)
            {
                picturesList.Add(new PictureBox());
                this.Controls.Add(picturesList[i]);

                picturesList[i].Width = 18;
                picturesList[i].Height = 18;

                picturesList[i].Top = y - 3;
                picturesList[i].Left = x - 3;

                picturesList[i].BackColor = colorList[i];
                picturesList[i].BorderStyle = BorderStyle.Fixed3D;

                if ((i + 1) % 8 == 0)
                {
                    y += 25;
                    x = 6;
                }
                else
                    x += 25;

                picturesList[i].MouseDown += new MouseEventHandler(color_Click);
            }

            this.Controls.Add(indexPic);
            indexPic.BorderStyle = BorderStyle.FixedSingle;
            indexPic.Width = picturesList[1].Width + 4;
            indexPic.Height = picturesList[1].Height + 4;

            ColorForCancelation = Color;

            SetCurrentColor(Color);
        }

        private void LocateForm()
        {
            int X = 0, Y = 0;
            StartPosition = FormStartPosition.Manual;

            X = Cursor.Position.X;
            Y = Cursor.Position.Y + colorButton.Height;

            if (X + Width > Screen.PrimaryScreen.Bounds.Right)
                X = Screen.PrimaryScreen.Bounds.Right - Width;

            if (Y + Height > Screen.PrimaryScreen.Bounds.Bottom)
                Y = Screen.PrimaryScreen.Bounds.Bottom - Height;

            Location = new Point(X, Y);

        }

        public void color_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pb = sender as PictureBox;
                SetCurrentColor(pb.BackColor);
            }
        }

        private void SetCurrentColor(Color newColor)
        {
            indexPic.Visible = false;
            Color = newColor;
            curColor.BackColor = Color;

            for (int i = 0; i < 48; ++i)
            {
                if (picturesList[i].BackColor.ToArgb() == Color.ToArgb())
                {
                    indexPic.Top = picturesList[i].Top - 2;
                    indexPic.Left = picturesList[i].Left - 2;
                    indexPic.Visible = true;
                }
            }

            colorButton.Color = Color;
            colorButton.Refresh();
            FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.SelfRef.AddCurveTemplate(colorButton.Name, Color);
            FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.SelfRef.BindCurvesColorsToCurves();
        }

        ColorDialog colorDialog = new ColorDialog();
        private void moreColorsButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Color;
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SetCurrentColor(colorDialog.Color);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Color = ColorForCancelation;
            colorButton.Color = Color;
            FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.SelfRef.AddCurveTemplate(colorButton.Name, Color);
            FilterSimulationWithTablesAndGraphs.fmFilterSimulationWithTablesAndGraphs.SelfRef.BindCurvesColorsToCurves();
            Close();
        }
    }
}
