using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Denga.Bwiki.Data.Entities;
using Denga.Bwiki.Web.Shared;
using Denga.Bwiki.Web.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Denga.Bwiki.Data.Services
{
    public class PageService
    {
        private readonly BwikiContext db;

        public PageService(BwikiContext db)
        {
            this.db = db;
        }

        public async Task<PageMetaData> GetPageByUrlTitle(string urlTitle)
        {
            urlTitle = urlTitle?.Trim().Replace(" ", "_");
            var page = await db.PageMetaDatas.Include(bp => bp.LatestVersion).SingleOrDefaultAsync(bp => bp.UrlTitle == urlTitle);

            return page ?? GetEmptyPage();
        }

        public async Task<PageMetaData> GetPageById(int id)
        {
            var page = await db.PageMetaDatas.Include(bp => bp.LatestVersion).SingleOrDefaultAsync(bp => bp.Id == id);

            return page;
        }

        public PageMetaData GetEmptyPage()
        {
            return new PageMetaData()
            {
                LatestVersion = new PageContent()
                {
                    Version = 1,
                    Title = "New Page",
                    HtmlContent = "<h1>Titel</h1><p>Add your content here...</p>",
                    CreatedAt = DateTime.Now
                }
            };
        }

        public async Task<IEnumerable<PageMetaData>> GetRecentChanges(int amount)
        {
            var pages = await db.PageMetaDatas
                .Include(bp => bp.LatestVersion)
                .OrderByDescending(bp => bp.LatestVersion.CreatedAt)
                .Take(amount)
                .ToListAsync();

            return pages;
        }

        public async Task<PageMetaData> SavePage(BlikiPageModel model)
        {
            PageMetaData page;

            if (model.Id.HasValue)
            {
                page = await GetPageById(model.Id.Value);
            }
            else
            {
                page = new PageMetaData()
                {
                    UrlTitle = UrlTitleHelper.ToUrlTitle(model.UrlTitle),
                    CreatedAt = DateTime.Now
                };
                db.Add(page);
                await db.SaveChangesAsync();
            }

            var latestVersion = new PageContent()
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

        public async Task<IEnumerable<PageMetaData>> SearchPage(string searchString)
        {
            var pages = await db.PageMetaDatas.Include(bp => bp.LatestVersion)
                .Where(bp => EF.Functions.Like(bp.LatestVersion.Title, $"%{searchString}%")).ToListAsync();

            return pages;
        }

        public async Task<bool> ValidateUrlTitle(string urlTitle, int? pageId)
        {
            if (pageId.HasValue)
            {
                return await db.PageMetaDatas.AnyAsync(md => md.Id != pageId.Value && md.UrlTitle == urlTitle) == false;
            }
            else
            {
                return await db.PageMetaDatas.AnyAsync(md =>  md.UrlTitle == urlTitle) == false;
            }
        }
    }
}