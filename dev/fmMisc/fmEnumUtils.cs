using System;
using System.ComponentModel;
using System.Reflection;

namespace fmMisc
{
    public static class fmEnumUtils
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            string result = value.ToString();
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                result = attributes[0].Description;

            return result;
        }

        public static Enum GetEnum(Type enumType, string description)
        {
            foreach (Enum element in Enum.GetValues(enumType))
            {
                if (GetEnumDescription(element) == description)
                    return element;
            }
            throw new Exception("Desired description not found in given enum type.");
        }
    }
}
