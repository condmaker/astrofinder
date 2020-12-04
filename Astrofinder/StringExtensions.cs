using System;
using System.Text;

namespace Astrofinder
{
    /// <summary>
    /// A class with a extension method to limit string size.
    /// If the string surpasses the limit, it indicates it with '...' (not 
    /// implemented yet)
    /// https://stackoverflow.com/questions/4105386/can-maximum-number-of-characters-be-defined-in-c-sharp-format-strings-like-in-c
    /// </summary>
    public static class StringExtensions
    {
        public static string MaxLength(this string input, int length)
        {
            StringBuilder sB = new StringBuilder();
            string sR;

            if (input == null) return null;
            
            sR = input.Substring(0, Math.Min(length, input.Length));
            sB.Append(sR);

            if (sR.Length >= length)
            {
                sB.Clear();
                sR = sR.Substring(0, length - 3);
                sB.Append(sR);
                sB.Append("...");
            }

            return sB.ToString();
        }
    }
}