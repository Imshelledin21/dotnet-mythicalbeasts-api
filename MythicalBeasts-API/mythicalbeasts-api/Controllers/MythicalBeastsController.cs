using Microsoft.AspNetCore.Mvc;
using mythicalbeasts_api.Models;
using System.Diagnostics;

namespace mythicalbeasts_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MythicalBeastsController : ControllerBase
    {
        [HttpGet(Name = "GetMythicalBeasts")]
        public MythicalBeasts Get()
        {
            Console.WriteLine(Activity.Current.Id);
            return new MythicalBeasts()
            {
                Name = "George",
                Type = "Centaur",
                Description = "A stalwart defender of butterflies and chess pieces.",
                Job = "Cooper",
                Id = 1
            };
        }
    }
}
