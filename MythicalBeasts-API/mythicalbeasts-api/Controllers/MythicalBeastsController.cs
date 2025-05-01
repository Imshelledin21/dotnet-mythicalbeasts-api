using Microsoft.AspNetCore.Mvc;
using mythicalbeasts_api.Models;
using mythicalbeasts_api.Utils;
using System.Diagnostics;

namespace mythicalbeasts_api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MythicalBeastsController : ControllerBase
    {
        private readonly ILogger<MythicalBeastsController> _logger;

        public MythicalBeastsController(ILogger<MythicalBeastsController> logger)
        {
            _logger = logger;
        }
        

        [HttpGet("/MythicalBeasts", Name = "GetMythicalBeasts")]
        public async Task<List<MythicalBeasts>> Get()
        {
            _logger.LogInformation("New Request to get all Mythical Beasts.");

            var http = new Utils.Http(_logger);

            var beasts = await http.Get(null);
            return beasts;
        }

        [HttpGet("/Random", Name = "Get a random Mythical Beast")]
        public async Task<MythicalBeasts> GetRandom()
        {
            _logger.LogInformation("New Request to get a Random Mythical Beast.");

            var http = new Utils.Http(_logger);

            var beasts = await http.Get(null);
            var beastCount = beasts.Count();

            var rand = new Random();
            var id = rand.Next(1, beastCount);

            var beast = await http.Get(id);

            return beast.First<MythicalBeasts>();
        }
    }
}
