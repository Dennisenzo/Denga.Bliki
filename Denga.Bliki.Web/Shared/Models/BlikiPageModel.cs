namespace Denga.Bliki.Web.Shared
{
    public class BlikiPageModel
    {
        public int? Id { get; set; }
        public int Version { get; set; }
        public string Title { get; set; }
        public string UrlTitle { get; set; }
        public string HtmlContent { get; set; }
    }
}