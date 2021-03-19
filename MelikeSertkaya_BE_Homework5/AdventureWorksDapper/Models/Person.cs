﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksDapper.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Id is required.")]
        public int BusinessEntityID { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public List<Employee> Employees { get; internal set; }
    }
}
