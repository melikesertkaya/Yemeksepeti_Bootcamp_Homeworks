using Soru__4.IServices;
using Soru__4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__4.Services
{
    public class StudentService : IStudentService
    {
        List<Student> _students = new List<Student>();
        public StudentService()
        {
            for (int i = 0; i<=9; i++)
            {
                _students.Add(new Student()
                {
                    StudentId = i,
                    Name="Stu"+i,
                    Roll="100"+i

                });
            }
        }
        public List<Student> Delete(int studentId)
        {
            _students.RemoveAll(x => x.StudentId == studentId);
            return _students;
        }

        public Student Get(int studentId)
        {
            return _students.SingleOrDefault(x => x.StudentId == studentId);
        }

        public List<Student> Gets()
        {
            return _students;
        }

        public List<Student> Save(Student student)
        {
            _students.Add(student);
            return _students;
        }
    }
}
