using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksDapper.Models
{
    public class Employee
    {
        public int BusinessEntityID { get; set; }
        public int LoginID { get; set; }
        public string JobTitle { get; set; }
        public SalesPerson SalesPerson { get; set; }
    }
}
