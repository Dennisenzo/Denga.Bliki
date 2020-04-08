using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Denga.Bwiki.Data.ModelBuilders;
using Denga.Bwiki.Data.Services;
using Denga.Bwiki.Web.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Denga.Bwiki.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PageController : ControllerBase
    {
        private readonly ILogger<PageController> logger;
        private readonly PageService pageService;

        public PageController(ILogger<PageController> logger, PageService pageService)
        {
            this.logger = logger;
            this.pageService = pageService;
        }

        [HttpGet]
        public async Task<PageModel> Get(string urlTitle)
        {
            return (await pageService.GetPageByUrlTitle(urlTitle)).ToModel();
        }

        [HttpGet("new")]
        public PageModel GetNew()
        {
            return pageService.GetEmptyPage().ToModel();
        }

        [HttpGet("recent")]
        public async Task<IEnumerable<PageModel>> GetRecentChanges()
        {
            var pages = (await pageService.GetRecentChanges(10)).Select(p => p.ToModel());

            return pages;
        }   
 
        [HttpGet("validate/urltitle")]
        public async Task<bool> ValidateUrlTitle(string title,int? pageId)
        {
            return await pageService.ValidateUrlTitle(title, pageId);
        }

        [HttpPost]
        public async Task<PageModel> Post(PageModel model)
        {
            return (await pageService.SavePage(model)).ToModel();
        }

        [HttpGet("search")]
        public async Task<IEnumerable<PageModel>> Search(string searchString)
        {
            var pages = (await pageService.SearchPage(searchString)).Select(p => p.ToModel());

            return pages;
        }
    }
}