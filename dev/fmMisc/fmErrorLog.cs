using System.Collections.Generic;

namespace fmMisc
{
    static public class fmErrorLog
    {
        private const int LogSize = 1000;
        static readonly List<string> Log = new List<string>();

        static public void AddError(string errorMessage)
        {
            if (Log.Count == LogSize)
            {
                Log.RemoveAt(0);
            }
            Log.Add(errorMessage);
        }

        static public List<string> GetLog()
        {
            var result = new List<string>(Log);
            result.Reverse();
            return result;
        }
    }
}
