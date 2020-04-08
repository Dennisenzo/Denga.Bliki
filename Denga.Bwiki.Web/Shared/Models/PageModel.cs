using System;

namespace Denga.Bwiki.Web.Shared.Models
{
    public class PageModel
    {
        public int? Id { get; set; }
        public int Version { get; set; }
        public string Title { get; set; }
        public string UrlTitle { get; set; }
        public string HtmlContent { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}