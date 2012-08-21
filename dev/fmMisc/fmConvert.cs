using System;
using System.Collections.Generic;
using System.Text;

namespace fmMisc
{
    public class fmConvert
    {
        public static double ToDouble(string s)
        {
            string decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            s = s.Replace('.', decimalSeparator[0]);
            s = s.Replace(',', decimalSeparator[0]);
            return Convert.ToDouble(s);
        }
    }
}
