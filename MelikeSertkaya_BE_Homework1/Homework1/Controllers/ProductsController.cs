using Homework1.Data;
using Homework1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DummySingleton _dummySingleton;
        public ProductsController()
        {
            _dummySingleton = DummySingleton.Instance;
        }
        [HttpGet]
        public List<ProductsModel> Get()
        {
            return _dummySingleton.Products.ToList();
        }

        [HttpGet("{id}")]
        public ProductsModel Get(int id)
        {
            var data = _dummySingleton.Products.FirstOrDefault(c => c.Id == id);
            return data;
        }

        [HttpPost]
        public void Post([FromBody] ProductsModel product)
        {
            _dummySingleton.Products.Add(product);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedProduct = _dummySingleton.Products.FirstOrDefault(x => x.Id == id);
            _dummySingleton.Products.Remove(deletedProduct);
        }
    }
}