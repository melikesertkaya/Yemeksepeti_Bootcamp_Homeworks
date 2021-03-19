using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__1.Services
{
    public class SingletonService : ISingletonService
    {
        public int RandomValue { get; }

        public SingletonService()
        {
            RandomValue = new Random().Next(1000);
        }
    }
    public interface ISingletonService
    {
        public int RandomValue { get; }
    }
}
