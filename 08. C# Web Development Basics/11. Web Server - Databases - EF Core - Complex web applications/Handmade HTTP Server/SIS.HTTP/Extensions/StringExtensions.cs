using System;

namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this String str)
        {
            ////return str.First().ToString().ToUpper() + str.Substring(1);
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());

            ////char[] strArray = str.ToCharArray();
            ////strArray[0] = char.ToUpper(strArray[0]);
            ////return new string(strArray);
        }
    }
}