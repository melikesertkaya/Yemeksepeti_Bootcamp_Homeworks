using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KargoTakip.DataAccsess.RequestModel
{

    public class Product
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int SellCount { get; set; }

        public Tuple<bool, List<string>> Validate()
        {

            List<string> validateList = new List<string>();

            if (Id > 0)
                validateList.Add("invalid id");

            if (Price > 0)
                validateList.Add("invalid price");

            return new Tuple<bool, List<string>>(validateList.Count <= 0, validateList);
        }

        public (bool isValid, List<string> validationErrors) Validate2()
        {

            List<string> validateList = new List<string>();

            if (Id > 0)
                validateList.Add("invalid id");

            if (Price > 0)
                validateList.Add("invalid price");

            return (validateList.Count <= 0, validateList);
        }
    }
}



