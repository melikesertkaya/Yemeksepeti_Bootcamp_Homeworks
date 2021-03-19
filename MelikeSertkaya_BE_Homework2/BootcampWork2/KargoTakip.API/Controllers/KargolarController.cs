using KargoTakip.DataAccsess.Bussiness.Interface;
using KargoTakip.DataAccsess.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KargoTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KargolarController : ControllerBase
    {
        private IKargoTeslim _kargoTeslim;
        public KargolarController(IKargoTeslim kargoTeslim)
        {
            _kargoTeslim = kargoTeslim;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var kargolar = _kargoTeslim.GetAllKargolar();
            return Ok(kargolar);//Repsonse 200 + body kısmına ekle
        }

        [HttpGet]
        [Route("[action]/{id}")] // api/Kargolar/getkargobytid/2
        public IActionResult GetKargoById(int id)
        {
            var kargo = _kargoTeslim.GetKargoById(id);
            if (kargo != null)
            {
                return Ok(kargo);
            }
            return NotFound();//404
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetKargoByName(string name)
        {
            var kargo = _kargoTeslim.GetKargoByName(name);
            if (kargo != null)
            {
                return Ok(kargo); //200+data
            }
            return NotFound();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateKargo([FromBody] Kargo kargo)
        {

            var createdKargo = _kargoTeslim.CreateKargo(kargo);
            return CreatedAtAction("Get", new { id = createdKargo.Id }, createdKargo); //201  +data

        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateKargo([FromBody] Kargo kargo)
        {
            if (_kargoTeslim.GetKargoById(kargo.Id) != null)
            {
                return Ok(_kargoTeslim.UpdateKargo(kargo));
            }
            return NotFound();
        }


        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult DeleteKargo(int id)
        {
            if (_kargoTeslim.GetKargoById(id) != null)
            {
                _kargoTeslim.DeleteKargo(id);
                return Ok();
            }
            return NotFound();
        }
    }
}