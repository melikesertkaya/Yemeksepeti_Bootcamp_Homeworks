using Soru__4.IServices;
using Soru__4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__4.Services
{
    public class TeacherService : ITeacherService
    {
        List<Teacher> _Teachers = new List<Teacher>();
        public TeacherService()
        {
            for (int i = 0; i <= 9; i++)
            {
                _Teachers.Add(new Teacher()
                {
                    TeacherId = i,
                    Name = "Teacher" + i,
                    Subject = "Subject" + i

                });
            }
        }
        public List<Teacher> Delete(int TeacherId)
        {
            _Teachers.RemoveAll(x => x.TeacherId == TeacherId);
            return _Teachers;
        }

        public List<Teacher> Gets()
        {
            return _Teachers;
        }

        public List<Teacher> Save(Teacher Teacher)
        {
            _Teachers.Add(Teacher);
            return _Teachers;
        }
    }
}
