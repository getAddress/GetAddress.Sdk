using System.Text.RegularExpressions;

namespace System
{
    public static class StringExtensions
    {
        public static bool ContainsTab(this string text)
        {
            return new Regex("\t").IsMatch(text);
        }
    }
}
