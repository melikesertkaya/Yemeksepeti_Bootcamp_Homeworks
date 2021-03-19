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
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName ="v1")]
    [ApiController]
    public class StudentsController:ControllerBase
    {
        IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]

        public List<Student> Gets()
        {
            return _studentService.Gets();
        }

        [HttpGet("{id}",Name ="Get")]
        public Student Get(int id)
        {
            return _studentService.Get(id);
        }

        [HttpPost]
        public List<Student>Post([FromBody] Student student)
        {
            return _studentService.Save(student);
        }

        [HttpDelete("{id}")]
        public List<Student> Delete(int id)
        {
            return _studentService.Delete(id);
        }


    }
}
