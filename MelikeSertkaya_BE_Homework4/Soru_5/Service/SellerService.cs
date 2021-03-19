using Soru_5.IService;
using Soru_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru_5.Service
{
    public class SellerService : IGenericService<Seller>
    {
        List<Seller> _sellers = new List<Seller>();

        public SellerService()
        {
            for (int i = 0; i <= 9; i++)
            {
                _sellers.Add(new Seller()
                {
                    SellerId = i,
                    Name = "Slr" + i,
                    Subject = "Sub" + i
                });
            }}

        public List<Seller> Delete(int SellerId)
        {
            _sellers.RemoveAll(x => x.SellerId == SellerId);
            return _sellers;
        }

        public List<Seller> GetAll()
        {
            return _sellers;
        }

        public Seller GetById(int id)
        {
            return _sellers.Where(x => x.SellerId == id).SingleOrDefault();
        }

        public List<Seller> Insert(Seller item)
        {
            _sellers.Add(item);
            return _sellers;
        }
    }
}
