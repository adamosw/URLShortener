using System.Text.RegularExpressions;

namespace Abat.URLShortener.Core.Extensions
{
    public static class UrlValidator
    {
        public static bool IsUrl(this string input)
        {
            var regexPattern = @"[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b([-a-zA-Z0-9()@:%_\\+.~#?&//=]*)\r\n";

            return Regex.IsMatch(input, regexPattern);
        }
    }
}
