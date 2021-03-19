using Homework1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.Data
{
    public class DummySingleton
    {
        private static volatile DummySingleton _instance = null;
        private static readonly object padLock = new object();

        public static DummySingleton Instance
        {
            get
            {
                lock (padLock)
                {
                    if (_instance == null)
                    {
                        _instance = new DummySingleton();
                    }
                }
                return _instance;
            }
        }

        private DummySingleton()
        {
            FillData();
        }

        private void FillData()
        {
            for (int i = 1; i <= 10; i++)
            {
                Products.Add(new ProductsModel {
                    Id = i, 
                    Name = "Product_" + i, 
                    Price = 100 + (i * 10) });
            }
        }

        public List<ProductsModel> Products = new List<ProductsModel>();
    }
}