using System.Collections.Generic;
using System.Drawing;
using ZedGraph;

namespace fmZedGraph
{
    public partial class fmZedGraphControl : ZedGraphControl
    {

        private RectangleF rect;
        Point pnt, cPnt;
        private bool isClick = false;
        List<fmCurvePoint> selectedPoints = new List<fmCurvePoint>();
        List<CurveItem> selectedCurves = new List<CurveItem>();
        private bool IsCancelSelections = true;
        private int originalCurvesCount;
       
        public List<fmCurvePoint> SelectedPoints
        {
            get { return selectedPoints;}
        }
        public  List<CurveItem> SelectedCurves
        {
            get { return selectedCurves;}
        }
        
        public fmZedGraphControl()
        {
            InitializeComponent();
        }
    }
}
