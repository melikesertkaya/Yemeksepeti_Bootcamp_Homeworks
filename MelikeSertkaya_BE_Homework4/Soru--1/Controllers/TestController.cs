using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soru__1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ISingletonService singletonService;
        private readonly IScopedService scopedService;
        private readonly ITransientService transientService;

        public TestController(ISingletonService SingletonService, IScopedService ScopedService, ITransientService TransientService)
        {
            singletonService = SingletonService;
            scopedService = ScopedService;
            transientService = TransientService;
        }

        [HttpGet]
        public string Get()
        {
            string result =
                 $"Singelton1:{singletonService.RandomValue.ToString()} {Environment.NewLine}" +
                 $"Scoped2: :{scopedService.RandomValue.ToString()} {Environment.NewLine}" +
                 $"Transient3: :{transientService.RandomValue.ToString()} {Environment.NewLine}";

            return result;
        }
    }
}