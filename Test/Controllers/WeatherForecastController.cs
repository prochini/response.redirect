using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {
            var rng = new Random();
                      

            var option = new CookieOptions();
            option.Expires = DateTime.Now.AddMonths(6);
            option.Domain = "mobii";
            option.Path = "/";
            option.Expires = DateTime.Now.AddHours(3);
            option.SameSite = SameSiteMode.None;
            option.Secure = false;
            Response.Cookies.Append("token", "123", option);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Redirect("http://localhost:46972/test");
        }

        [HttpOptions("/find")]
        public IActionResult FindOptions()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)Request.Headers["Origin"] });
            Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept" });
            Response.Headers.Add("Access-Control-Allow-Methods", new[] { "POST, OPTIONS" }); // new[] { "GET, POST, PUT, DELETE, OPTIONS" }
            Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
            return NoContent();
        }
    }
}
