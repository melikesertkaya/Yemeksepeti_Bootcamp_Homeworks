using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__1.Services
{
    public class TransientService : ITransientService
    {
        public int RandomValue { get; }
        private readonly IScopedService scopedService;
        public TransientService(IScopedService ScopedService)
        {
            scopedService = ScopedService;
            RandomValue = new Random().Next(1000);
        }
        public int GetNumberGeneratorRandomnumber()
        {
            return scopedService.RandomValue;
        }
    }
    public interface ITransientService
    {
        public int RandomValue { get; }

        public int GetNumberGeneratorRandomnumber();
    }
}
