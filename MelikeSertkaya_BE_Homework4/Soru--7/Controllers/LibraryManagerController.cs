using Microsoft.AspNetCore.Mvc;
using Soru__7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__7.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    public class LibraryManagerController : ControllerBase
    {
        List<LibraryManager> _libraryManagerService = new List<LibraryManager>() {
           new LibraryManager() { LibraryManagerId=1,Name="Melike",Subject="yok1"},
           new LibraryManager() { LibraryManagerId=2,Name="Deniz",Subject="yok2"},
           new LibraryManager() { LibraryManagerId=2,Name="Arzu",Subject="yok3"}
        };

        [HttpGet]

        public IActionResult Gets()
        {
            if (_libraryManagerService.Count == 0)
            {
                return NotFound("No list found");
            }
            return Ok(_libraryManagerService);
        }

    }
}