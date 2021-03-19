using KargoTakip.DataAccsess.Data.Context;
using KargoTakip.DataAccsess.Data.Entity;
using KargoTakip.DataAccsess.Interface.Example1;
using KargoTakip.DataAccsess.RequestModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakip.DataAccsess.Abstract.Example1
{
    public class KargoRepository : IKargoRepository
    {
        public Kargo CreateKargo(Kargo kargo)
        {
            using (var kargoDbContext = new KargoDbContext())
            {
                kargoDbContext.Kargolar.Add(kargo);
                kargoDbContext.SaveChanges();// kaydolan veriyi veritabanında gösteriyor
                return kargo;
            }
        }

        public void DeleteKargo(int id)
        {
            using (var kargoDbContext = new KargoDbContext())
            {
                var deletedKargo = GetKargoById(id);
                kargoDbContext.Kargolar.Remove(deletedKargo);
                kargoDbContext.SaveChanges();
            }
        }

        public List<Kargo> GetAllKargolar()
        {
            using (var kargoDbContext = new KargoDbContext())
            {
                return kargoDbContext.Kargolar.ToList();
            }
        }

        public Kargo GetKargoById(int id)
        {
            using (var kargoDbContext = new KargoDbContext())
            {
                return kargoDbContext.Kargolar.Find(id);
            }
        }

        public Kargo GetKargoByName(string name)
        {
            using (var kargoDbContext = new KargoDbContext())
            {
                return kargoDbContext.Kargolar.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            }
        }

        public Kargo Post(Product product)
        {
            using (var kargoDbContext = new KargoDbContext())
            {
                return kargoDbContext.Kargolar.Find(product);
            }
        }

        public Kargo UpdateKargo(Kargo kargo)
        {
            using (var kargoDbContext = new KargoDbContext())
            {
                kargoDbContext.Kargolar.Update(kargo);
                kargoDbContext.SaveChanges();
                return kargo;
            }
        }
    }
}