using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Denga.Bwiki.Web.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Denga.Bwiki.Web.Client.DataServices
{
    public class PageDataService : DataServiceBase
    {
        public PageDataService(HttpClient httpClient) : base(httpClient, "api/page")
        {
        }

        public async Task<BlikiPageModel> GetPageModel(string urlTitle)
        {
            return await Get<BlikiPageModel>($"?urlTitle={urlTitle}");
        }


        public async Task<BlikiPageModel> GetNewPageModel()
        {
            return await Get<BlikiPageModel>($"new");
        }

        
        public async Task<IEnumerable<BlikiPageModel>> GetRecentChanges()
        {
            return await Get<IEnumerable<BlikiPageModel>>($"recent");
        }

        public async Task<bool> ValidateUrlTitle(string title, int? pageId)
        {
            return await Get<bool>($"validate/urltitle?title={WebUtility.UrlEncode(title)}&pageId={pageId}");
        }

        public async Task<BlikiPageModel> SavePageModel(BlikiPageModel model)
        {
            return await Post<BlikiPageModel>("", model);
        }

        public async Task<IEnumerable<BlikiPageModel>> SearchPageModel(string searchString)
        {
            return await Get<IEnumerable<BlikiPageModel>>($"search?searchString={WebUtility.UrlEncode(searchString)}");
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
            return await HttpClient.GetJsonAsync<TOUT>($"{BaseUrl}{url}");
        }

        protected async Task<TOUT> Post<TOUT>(string url, object content)
        {
            return await HttpClient.PostJsonAsync<TOUT>($"{BaseUrl}{url}", content);
        }
    }
}