using System.Text.RegularExpressions;

namespace Denga.Bwiki.Web.Shared
{
    public static class UrlTitleHelper
    {
        public static string ToUrlTitle(string title)
        {
            string urlTitle = Regex.Replace(title, "[^a-zA-Z0-9]", "_");
            urlTitle = Regex.Replace(urlTitle, "_+", "_").ToLowerInvariant();

            return urlTitle;
        }
    }
}