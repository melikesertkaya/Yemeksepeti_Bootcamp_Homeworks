using Microsoft.AspNetCore.Mvc;
using Soru__4.IServices;
using Soru__4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__4.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    public class TeachersController:ControllerBase
    {
        ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]

        public List<Teacher> Gets()
        {
            return _teacherService.Gets();
        }

        [HttpPost]
        public List<Teacher> Post([FromBody] Teacher Teacher)
        {
            return _teacherService.Save(Teacher);
        }

        [HttpDelete("{id}")]
        public List<Teacher> Delete(int id)
        {
            return _teacherService.Delete(id);
        }

    }
}
