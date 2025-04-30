using mythicalbeasts_api.Controllers;
using mythicalbeasts_api.Models;

namespace mythicalbeasts_api.Utils
{
    public class Http
    {
        private readonly ILogger<MythicalBeastsController> _logger;

        public Http(ILogger<MythicalBeastsController> logger)
        {
            _logger = logger;
        }

        public async Task<List<MythicalBeasts>> Get(int? id)
        {
            string baseUrl = Environment.GetEnvironmentVariable("BASE_DATA_API_ENDPOINT");
            string fullUrl = baseUrl + "/MythicalBeasts/" + id;

            _logger.LogInformation("API Endpoint: " + fullUrl);


            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetFromJsonAsync<List<MythicalBeasts>>(fullUrl);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<MythicalBeasts>();
            }
            
        }
    }
}
