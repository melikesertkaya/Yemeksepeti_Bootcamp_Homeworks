using KargoTakip.DataAccsess.Data.Entity;
using KargoTakip.DataAccsess.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakip.DataAccsess.Interface.Example1
{
    public interface IKargoRepository
    {
        List<Kargo> GetAllKargolar();
        Kargo GetKargoById(int id);
        Kargo GetKargoByName(string name);
        Kargo CreateKargo(Kargo kargo);
        Kargo Post(Product product);
        Kargo UpdateKargo(Kargo kargo);
        void DeleteKargo(int id);

    }
}