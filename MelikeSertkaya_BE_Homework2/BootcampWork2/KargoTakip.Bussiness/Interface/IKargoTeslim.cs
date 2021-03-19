using System;
using System.Collections.Generic;
using System.Text;

namespace KargoTakip.Bussiness.Interface
{
    public interface IKargoTeslim
    {
        List<Kargo> GetAllKargolar();
        Kargo GetKargoById(int id);
        Kargo GetKargoByName(string name);
        Kargo CreateKargo(Kargo kargo);
        Kargo UpdateKargo(Kargo kargo);
        void DeleteKargo(int id);

    }
}
