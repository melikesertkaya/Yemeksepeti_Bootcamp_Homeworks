using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__1.Services
{
    public class ScopedService : IScopedService
    {
        public int RandomValue { get; }
        private readonly ISingletonService singletonService;

        public ScopedService(ISingletonService SingletonService)
        {
            singletonService = SingletonService;
            RandomValue = new Random().Next(1000);
        }
        public int GetNumberGeneratorRandomnumber()
        {
            return singletonService.RandomValue;
        }
    }
    public interface IScopedService
    {
        public int RandomValue { get; }

        public int GetNumberGeneratorRandomnumber();
    }
}