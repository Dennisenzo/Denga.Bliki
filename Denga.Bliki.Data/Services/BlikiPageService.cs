using Denga.Bliki.Web.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Denga.Bliki.Web.Shared.Models;

namespace Denga.Bliki.Data.Services
{
    public class BlikiPageService
    {
        private readonly BlikiContext db;

        public BlikiPageService(BlikiContext db)
        {
            this.db = db;
        }

        public async Task<BlikiPageMetaData> GetPageByUrlTitle(string urlTitle)
        {
            urlTitle = urlTitle?.Trim().Replace(" ", "_");
            var page = await db.BlikiPageMetaDatas.Include(bp => bp.LatestVersion).SingleOrDefaultAsync(bp => bp.UrlTitle == urlTitle);

            return page ?? GetEmptyPage();
        }

        public async Task<BlikiPageMetaData> GetPageById(int id)
        {
            var page = await db.BlikiPageMetaDatas.Include(bp => bp.LatestVersion).SingleOrDefaultAsync(bp => bp.Id == id);

            return page;
        }

        public BlikiPageMetaData GetEmptyPage()
        {
            return new BlikiPageMetaData()
            {
                LatestVersion = new BlikiPageContent()
                {
                    Version = 1,
                    Title = "New Page",
                    HtmlContent = "<h1>Titel</h1><p>Add your content here...</p>",
                    CreatedAt = DateTime.Now
                }
            };
        }

        public async Task<IEnumerable<BlikiPageMetaData>> GetRecentChanges(int amount)
        {
            var pages = await db.BlikiPageMetaDatas
                .Include(bp => bp.LatestVersion)
                .OrderByDescending(bp => bp.LatestVersion.CreatedAt)
                .Take(amount)
                .ToListAsync();

            return pages;
        }

        public async Task<BlikiPageMetaData> SavePage(BlikiPageModel model)
        {
            BlikiPageMetaData page;

            if (model.Id.HasValue)
            {
                page = await GetPageById(model.Id.Value);
            }
            else
            {
                page = new BlikiPageMetaData()
                {
                    UrlTitle = UrlTitleHelper.ToUrlTitle(model.UrlTitle),
                    CreatedAt = DateTime.Now
                };
                db.Add(page);
                await db.SaveChangesAsync();
            }

            var latestVersion = new BlikiPageContent()
            {
                HtmlContent = model.HtmlContent,
                MetaData = page,
                Title = model.Title,
                Version = page.LatestVersion?.Version + 1 ?? 1,
                CreatedAt = DateTime.Now
            };

            db.Add(latestVersion);

            page.LatestVersion = latestVersion;

            await db.SaveChangesAsync();

            return page;
        }

        public async Task<IEnumerable<BlikiPageMetaData>> SearchPage(string searchString)
        {
            var pages = await db.BlikiPageMetaDatas.Include(bp => bp.LatestVersion)
                .Where(bp => EF.Functions.Like(bp.LatestVersion.Title, $"%{searchString}%")).ToListAsync();

            return pages;
        }

        public async Task<bool> ValidateUrlTitle(string urlTitle, int? pageId)
        {
            if (pageId.HasValue)
            {
                return await db.BlikiPageMetaDatas.AnyAsync(md => md.Id != pageId.Value && md.UrlTitle == urlTitle) == false;
            }
            else
            {
                return await db.BlikiPageMetaDatas.AnyAsync(md =>  md.UrlTitle == urlTitle) == false;
            }
        }
    }
}