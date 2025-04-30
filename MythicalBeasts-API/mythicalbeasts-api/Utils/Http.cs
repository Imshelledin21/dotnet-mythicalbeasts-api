using mythicalbeasts_api.Models;

namespace mythicalbeasts_api.Utils
{
    public class Http
    {
        private readonly ILogger<Http> _logger;


        public async Task<List<MythicalBeasts>> Get(int? id)
        {
            string baseUrl = Environment.GetEnvironmentVariable("BASE_DATA_API_ENDPOINT");
            string fullUrl = baseUrl + "/MythicalBeasts/" + id;


            var httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<List<MythicalBeasts>>(fullUrl);

            return response;
        }
    }
}
