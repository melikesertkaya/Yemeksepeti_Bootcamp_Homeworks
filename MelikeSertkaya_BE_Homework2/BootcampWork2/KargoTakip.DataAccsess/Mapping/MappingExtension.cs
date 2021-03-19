using KargoTakip.DataAccsess.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;


namespace KargoTakip.DataAccsess.Mapping
{
   public static class MappingExtension
    {
        public static List<Product> ToKargoResponse(this List<Customer> kargolar)
        {
            List<Product> result = new List<Product>();

            for (int i = 0; i < kargolar.Count; i++)
            {
                result.Add(new Product
                {
                    Id = kargolar[i].Id,
                    Name = kargolar[i].Name,
                    Price = kargolar[i].Price,
                    SellCount = 100 + (kargolar[i].SellCount * 5)
                });
            }

            return result;
        }
    }
}
