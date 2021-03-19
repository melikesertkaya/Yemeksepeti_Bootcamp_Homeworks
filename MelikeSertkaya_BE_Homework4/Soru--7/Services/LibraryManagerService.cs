using Soru__7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__7.Services
{
    public class LibraryManagerService
    {
        List<LibraryManager> _LibraryManagers = new List<LibraryManager>();
        public LibraryManagerService()
        {
            for (int i = 0; i <= 9; i++)
            {
                _LibraryManagers.Add(new LibraryManager()
                {
                    LibraryManagerId = i,
                    Name = "LibraryManager" + i,
                    Subject = "Subject" + i

                });
            }
        }


        public List<LibraryManager> Gets()
        {
            return _LibraryManagers;
        }


    }
}