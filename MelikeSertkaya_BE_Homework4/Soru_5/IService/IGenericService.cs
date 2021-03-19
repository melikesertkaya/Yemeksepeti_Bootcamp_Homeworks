using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru_5.IService
{
    public interface IGenericService<T>
    {
        List<T> GetAll();

        T GetById(int id);

        List<T> Insert(T item);

        List<T> Delete(int id);
    }
}
