using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soru_5.IService;
using Soru_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : GenericController<Seller>
    {
        public SellersController(IGenericService<Seller> genericService) : base(genericService)
        {

        }
    }
}