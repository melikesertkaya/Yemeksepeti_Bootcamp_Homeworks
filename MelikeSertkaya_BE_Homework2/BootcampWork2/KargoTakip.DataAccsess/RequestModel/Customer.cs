using KargoTakip.DataAccsess.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace KargoTakip.DataAccsess.RequestModel
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string City { get; set; }
        public int SellCount { get; set; }
       
        }

    }

