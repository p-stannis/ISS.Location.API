using System;
using System.Net.Http;
using System.Threading.Tasks;
using ISS.Location.API.Contracts;
using ISS.Location.API.Entities;
using ISS.Location.API.Repositories.Utils;

namespace ISS.Location.API.Repositories
{
    public class LocationApiRepository : ILocationApiRepository
    {
        private readonly HttpClient _httpClient;

        public LocationApiRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IssLocationApi> GetLocation()
        {
            var request = new HttpRequestMessage();

            return await HttpClientHelper.SendRequestAndGetResponseAsync<IssLocationApi>(_httpClient, request);
        }
    }
}
