using System;
using System.Net;
using System.Net.Http;
using ISS.Location.API.Contracts;
using ISS.Location.API.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ISS.Location.API.Extensions
{
    public static class HttpClientConfigurations
    {
        public static void AddHttpClients(this IServiceCollection services, IConfiguration config)
        {
            services.AddIssClient(config);
        }
        

        private static void AddIssClient(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<ILocationApiRepository, LocationApiRepository>(client =>
            {
                client.BaseAddress = new Uri(config["Iss:BaseUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                UseCookies = false
            });
        }
    }
}
