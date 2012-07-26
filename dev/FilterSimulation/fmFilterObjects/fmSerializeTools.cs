using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace FilterSimulation.fmFilterObjects
{
    public class fmSerializeTools
    {
        public static double ToDouble(object p)
        {
            string s = p.ToString();
            s = s.Replace(',', System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator[0]);
            s = s.Replace('.', System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator[0]);
            return Convert.ToDouble(s);
        }
    }
}
