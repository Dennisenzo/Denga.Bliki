using Denga.Bwiki.Data.Entities;
using Denga.Bwiki.Web.Shared.Models;

namespace Denga.Bwiki.Data.ModelBuilders
{
    public static class PageModelBuilder
    {
        public static PageModel ToModel(this PageMetaData page)
        {
            return new PageModel
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