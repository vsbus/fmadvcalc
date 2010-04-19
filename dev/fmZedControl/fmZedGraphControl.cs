using System.Collections.Generic;
using System.Drawing;
using ZedGraph;
using System;

namespace fmZedGraph
{
    public delegate void HighlightPointsEventHandler(object sender, HighlighPointsEventArgs e);
    public partial class fmZedGraphControl : ZedGraphControl
    {
        private RectangleF rect;
        Point pnt, cPnt;
        private bool isClick = false;
        List<fmCurvePoint> selectedPoints = new List<fmCurvePoint>();
        List<CurveItem> selectedCurves = new List<CurveItem>();
        private bool IsCancelSelections = true;
        private int originalCurvesCount;
        List<CurveItem> highLightedPoints;
        public event HighlightPointsEventHandler HighLightedPointsChanged;
       
        public List<fmCurvePoint> SelectedPoints
        {
            get { return selectedPoints;}
        }
        public List<CurveItem> SelectedCurves
        {
            get { return selectedCurves;}
        }
        
        public fmZedGraphControl()
        {
            InitializeComponent();

            GraphPane.XAxis.MajorGrid.Color = Color.LightGray;
            GraphPane.XAxis.MajorGrid.IsVisible = true;
            GraphPane.XAxis.MajorGrid.DashOff = 0;
            GraphPane.XAxis.MajorGrid.DashOn = 15;

            GraphPane.YAxis.MajorGrid.Color = Color.LightGray;
            GraphPane.YAxis.MajorGrid.IsVisible = true;
            GraphPane.YAxis.MajorGrid.DashOff = 0;
            GraphPane.YAxis.MajorGrid.DashOn = 15;

            
        }
    }
}
