using Denga.Bliki.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Denga.Bliki.Web.Shared
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
                UrlTitle = page.UrlTitle
            };
        }
    }
}