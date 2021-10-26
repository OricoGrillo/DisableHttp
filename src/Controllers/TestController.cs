using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace cart_api_gcp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private IConfiguration _configuration;
        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_configuration.GetSection("Messages")["Message"]);
        }
    }
}
