using Denga.Bliki.Web.Shared.Models;

namespace Denga.Bliki.Data.ModelBuilders
{
    public static class BlikiPageModelBuilder
    {
        public static BlikiPageModel ToModel(this BlikiPageMetaData page)
        {
            return new BlikiPageModel
            {
                Id = page.Id,
                Title = page.LatestVersion.Title,
                HtmlContent = page.LatestVersion.HtmlContent,
                UrlTitle = page.UrlTitle,
                CreatedAt = page.CreatedAt,
                ModifiedAt = page.LatestVersion.CreatedAt
            };
        }
    }
}