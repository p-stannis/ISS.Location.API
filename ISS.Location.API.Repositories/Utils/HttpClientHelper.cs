using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ISS.Location.API.Repositories.Utils
{
    public static class HttpClientHelper
    {
        public static async Task<HttpResponseMessage> SendRequestAsync(HttpClient client, HttpRequestMessage requestMessage)
        {
            var response = await client.SendAsync(requestMessage);

            return response;
        }

        public static async Task<T> SendRequestAndGetResponseAsync<T>(
            HttpClient client,
            HttpRequestMessage requestMessage,
            JsonSerializerOptions jsonOptions = null)
        {
            var response = await SendRequestAsync(client, requestMessage);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return default(T);

            response.EnsureSuccessStatusCode();

            jsonOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                IgnoreNullValues = true
            };

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                return await JsonSerializer.DeserializeAsync<T>(responseStream, jsonOptions);
            }
        }
    }
}
