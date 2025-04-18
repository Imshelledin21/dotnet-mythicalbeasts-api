using Microsoft.AspNetCore.Mvc;
using mythicalbeasts_api.Models;

namespace mythicalbeasts_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MythicalBeastsController : ControllerBase
    {
        [HttpGet(Name = "GetMythicalBeasts")]
        public MythicalBeasts Get()
        {
            return new MythicalBeasts()
            {
                Name = "George",
                Type = "Centaur",
                Description = "A stalwart defender of butterflies and chess pieces.",
                Job = "Cooper",
                Id = 1,
                JobId = 1,
            };
        }
    }
}
