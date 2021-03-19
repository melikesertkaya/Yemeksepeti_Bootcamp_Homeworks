using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Soru__1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ISingletonService singletonService;
        private readonly IScopedService scopedService;
        private readonly ITransientService transientService;

        public WeatherForecastController(ISingletonService SingletonService, IScopedService ScopedService, ITransientService TransientService)
        {
            singletonService = SingletonService;
            scopedService = ScopedService;
            transientService = TransientService;
        }

        [HttpGet]
        public string Get()
        {
            int random1 = singletonService.RandomValue;
            int random2 = scopedService.RandomValue;
            int random3 = transientService.RandomValue;


            return $"Singleton.RandomValue1:{random1} Scoped.RandomValue2:{random2} Transient.RandomValue3:{random3}";
        }
    }
}