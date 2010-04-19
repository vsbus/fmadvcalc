using System;
namespace AdvancedCalculator
{
 public class Config
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