using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Soru__6.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__6.Controllers
{
    [ServiceFilter(typeof(ClientIdCheckFilter))]
    [Route("api/[controller]")]

    public class ValuesController : Controller
    {
        private ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogDebug("successful get.");

            string result = $"192.168.1.1:{ " "} {ToString()}";

            return result;

        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
