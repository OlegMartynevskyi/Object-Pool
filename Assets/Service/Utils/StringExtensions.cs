using System;

namespace Service.Utils
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string target, StringComparison comparsion)
        {
            return source != null ? source.IndexOf(target, comparsion) >= 0 : false;
        }
    }
}