using Soru__7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru__7.Services
{
    public class CustomerService
    {
        List<Customer> _customers = new List<Customer>();
        public CustomerService()
        {
            for (int i = 0; i <= 9; i++)
            {
                _customers.Add(new Customer()
                {
                    CustomerId = i,
                    Name = "Customer" + i,
                    Roll = "100" + i

                });
            }
        }


        public Customer Get(int customerId)
        {
            return _customers.SingleOrDefault(x => x.CustomerId == customerId);
        }

        public List<Customer> Gets()
        {
            return _customers;
        }


    }
}


