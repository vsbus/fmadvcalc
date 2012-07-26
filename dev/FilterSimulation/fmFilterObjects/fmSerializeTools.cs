﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace FilterSimulation.fmFilterObjects
{
    public class fmSerializeTools
    {
        internal static object DeserializeProperty(System.IO.TextReader input, string tag)
        {
            var a = input.ReadLine().Split('=');
            if (a[0].Trim() != tag)
            {
                throw new Exception("Expected Tag was <" + tag + "> but recieved <" + a[0].Trim() + ">");
            }
            object value = a[1].Trim();
            return value;
        }

        public static double ToDouble(object p)
        {
            string s = p.ToString();
            s = s.Replace(',', System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator[0]);
            s = s.Replace('.', System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator[0]);
            return Convert.ToDouble(s);
        }
    }
}
