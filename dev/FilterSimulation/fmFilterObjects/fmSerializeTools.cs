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

        public static bool DeserializeBoolProperty(
            ref bool property,
            XmlNode currentNode,
            string propertyKey)
        {
            XmlNode propertyNode = currentNode.SelectSingleNode(propertyKey);
            if (propertyNode != null)
            {
                property = Convert.ToBoolean(propertyNode.InnerText);
                return true;
            }
            return false;
        }

        public static bool DeserializeStringProperty(
            ref string property,
            XmlNode currentNode,
            string propertyKey)
        {
            XmlNode propertyNode = currentNode.SelectSingleNode(propertyKey);
            if (propertyNode != null)
            {
                property = propertyNode.InnerText;
                return true;
            }
            return false;
        }

        public static void DeserializeIntProperty(
            ref int property,
            XmlNode currentNode,
            string propertyKey)
        {
            XmlNode propertyNode = currentNode.SelectSingleNode(propertyKey);
            if (propertyNode != null)
            {
                property = Convert.ToInt32(propertyNode.InnerText);
            }
        }
    }
}
