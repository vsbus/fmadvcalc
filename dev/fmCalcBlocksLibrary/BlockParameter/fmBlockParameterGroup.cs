using System.Drawing;

namespace fmCalcBlocksLibrary.BlockParameter
{
    public class fmBlockParameterGroup
    {
        public bool transparent;
        public Color color;
        public fmBlockParameterGroup()
        {
            color = Color.White;
            transparent = true;
        }
        public fmBlockParameterGroup(Color cellBackColor)
        {
            color = cellBackColor;
            transparent = false;
        }
        public fmBlockParameterGroup(Color cellBackColor, bool transtarent)
        {
            color = cellBackColor;
            this.transparent = transtarent;
        }
    }
}
