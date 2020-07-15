using System;
using System.Net.Http;
using System.Threading.Tasks;
using Denga.Bwiki.Web.Client.DataServices;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Denga.Bwiki.Web.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddTransient<PageDataService>();

            builder.Services.AddTransient(sp =>
            new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
