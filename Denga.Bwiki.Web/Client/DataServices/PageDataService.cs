using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Denga.Bwiki.Web.Shared.Models;
using System.Net.Http.Json;

namespace Denga.Bwiki.Web.Client.DataServices
{
    public class PageDataService : DataServiceBase
    {
        public PageDataService(HttpClient httpClient) : base(httpClient, "api/page")
        {
        }

        public async Task<PageModel> GetPageModel(string urlTitle)
        {
            return await Get<PageModel>($"?urlTitle={urlTitle}");
        }


        public async Task<PageModel> GetNewPageModel()
        {
            return await Get<PageModel>($"new");
        }

        
        public async Task<IEnumerable<PageModel>> GetRecentChanges()
        {
            return await Get<IEnumerable<PageModel>>($"recent");
        }

        public async Task<bool> ValidateUrlTitle(string title, int? pageId)
        {
            return await Get<bool>($"validate/urltitle?title={WebUtility.UrlEncode(title)}&pageId={pageId}");
        }

        public async Task<PageModel> SavePageModel(PageModel model)
        {
            return await Post<PageModel>("", model);
        }

        public async Task<IEnumerable<PageModel>> SearchPageModel(string searchString)
        {
            return await Get<IEnumerable<PageModel>>($"search?searchString={WebUtility.UrlEncode(searchString)}");
        }
    }

    public abstract class DataServiceBase
    {
        protected HttpClient HttpClient { get; }
        protected string BaseUrl { get; }

        public DataServiceBase(HttpClient httpClient, string baseUrl)
        {
            if (!baseUrl.EndsWith("/"))
            {
                baseUrl += "/";
            }

            HttpClient = httpClient;
            BaseUrl = baseUrl;
        }

        protected async Task<TOUT> Get<TOUT>(string url)
        {
            return await HttpClient.GetFromJsonAsync<TOUT>($"{BaseUrl}{url}");
        }

        protected async Task<TOUT> Post<TOUT>(string url, object content)
        {
            var response= await HttpClient.PostAsJsonAsync($"{BaseUrl}{url}", content);

            return await response.Content.ReadFromJsonAsync<TOUT>();
        }
    }
}