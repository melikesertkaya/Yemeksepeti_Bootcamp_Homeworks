using Soru__4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__4.IServices
{
    public interface IStudentService
    {
        List<Student> Gets();
        Student Get(int studentId);
        List<Student> Save(Student student);
        List<Student> Delete(int studentId);
    }
    
}
