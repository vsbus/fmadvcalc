using System;
namespace AdvancedCalculator
{
// ReSharper disable InconsistentNaming
 public class Config
// ReSharper restore InconsistentNaming
 {
     public static Version Version
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            }
        }
 }
}