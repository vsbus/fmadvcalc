using System;
using System.Collections.Generic;
using System.Text;

namespace fmMisc
{
    static public class fmArrayUtils<T>
    {
        public static T MinElement(List<T> list)
        {
            T result = list[0];
            Comparer<T> comparer = Comparer<T>.Default;
            for (int i = 1; i < list.Count; ++i)
            {
                if (comparer.Compare(result, list[i]) > 0)
                {
                    result = list[i];
                }
            }
            return result;
        }

        public static T MaxElement(List<T> list)
        {
            T result = list[0];
            Comparer<T> comparer = Comparer<T>.Default;
            for (int i = 1; i < list.Count; ++i)
            {
                if (comparer.Compare(result, list[i]) < 0)
                {
                    result = list[i];
                }
            }
            return result;
        }
    }
}
