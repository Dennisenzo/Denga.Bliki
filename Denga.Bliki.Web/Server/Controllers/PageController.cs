using Denga.Bliki.Web.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Denga.Bliki.Data.Services;

namespace Denga.Bliki.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PageController : ControllerBase
    {
        private readonly ILogger<PageController> logger;
        private readonly BlikiPageService pageService;

        public PageController(ILogger<PageController> logger, BlikiPageService pageService)
        {
            this.logger = logger;
            this.pageService = pageService;
        }

        [HttpGet]
        public async Task<BlikiPageModel> Get(string urlTitle)
        {
            return (await pageService.GetPageByUrlTitle(urlTitle)).ToModel();
        }

        [HttpGet("new")]
        public async Task<BlikiPageModel> GetNew()
        {
            return pageService.GetEmptyPage().ToModel();
        }

        [HttpPost]
        public async Task<BlikiPageModel> Post(BlikiPageModel model)
        {
            return (await pageService.SavePage(model)).ToModel();
        }

        [HttpGet("search")]
        public async Task<IEnumerable<BlikiPageModel>> Search(string searchString)
        {
            var pages = (await pageService.SearchPage(searchString)).Select(p => p.ToModel());

            return pages;
        }
    }
}