using Soru__4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__4.IServices
{
    public interface ITeacherService
    {
        List<Teacher> Gets();
        List<Teacher> Save(Teacher Teacher);
        List<Teacher> Delete(int TeacherId);
    }
}
