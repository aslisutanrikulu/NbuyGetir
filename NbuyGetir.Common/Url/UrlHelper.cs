using System;
using System.Text.RegularExpressions;

namespace NbuyGetir.Common
{
    public class UrlHelper
    {
        public static bool IsUrl(string url)
        {
            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";

            var regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return regex.IsMatch(url);
        }
    }
}
