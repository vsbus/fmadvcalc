using System.Drawing;

namespace fmCalcBlocksLibrary.BlockParameter
{
    public class fmBlockParameterGroup
    {
        public Color color;
        public fmBlockParameterGroup()
        {
            color = Color.White;
        }
        public fmBlockParameterGroup(Color cellBackColor)
        {
            color = cellBackColor;
        }
    }
}
