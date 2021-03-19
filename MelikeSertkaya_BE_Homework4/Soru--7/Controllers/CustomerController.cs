using Microsoft.AspNetCore.Mvc;
using Soru__7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__7.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class CustomerController:ControllerBase
    {
        List<Customer> _customerService = new List<Customer>() {
           new Customer() { CustomerId=1,Name="Melike",Roll="10001"},
           new Customer() { CustomerId=2,Name="Deniz",Roll="1002"},
           new Customer() { CustomerId=2,Name="Arzu",Roll="1003"}
        };

        [HttpGet]

        public IActionResult Gets()
        {
            if (_customerService.Count == 0)
            {
                return NotFound("No list found");
            }
            return Ok(_customerService);
        }



    }
}