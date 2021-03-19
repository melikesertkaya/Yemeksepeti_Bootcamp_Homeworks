using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            //return "OK";
            string result = $"request:{("request.txt")} {Environment.NewLine}" +
                            $"response: :{"response.txt"} {Environment.NewLine}";
            return result;
        }

        [HttpGet("Request")]
        public Request GetRequest()
        {
            return new Request()
            {
                Id=1,
                Name="Deneme"
            };
        }

        [HttpPost("Request")]
        public string CreateRequest([FromBody] Request Request)
        {
            return "Request oluşturuldu";
        }
    }
    public class Request
    {
        public int Id { get; set; }
        public string Name{ get; set; }
    }
}
