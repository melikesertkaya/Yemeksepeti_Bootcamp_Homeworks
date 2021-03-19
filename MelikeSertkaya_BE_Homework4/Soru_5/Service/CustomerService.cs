using Soru_5.IService;
using Soru_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soru_5.Service
{
    public class CustomerService : IGenericService<Customer>
    {
        List<Customer> _customers = new List<Customer>();
        public CustomerService()
        {
            for (int i = 0; i <=9; i++)
            {
                _customers.Add(new Customer()
                {
                    CustomerId=i,
                    Name="Cus"+i,
                    Roll="100"+i
                }); 
            }}

        public List<Customer> Delete(int CustomerId)
        {
            _customers.RemoveAll(x => x.CustomerId == CustomerId);
            return _customers;
        }

        public List<Customer> GetAll()
        {
            return _customers;
        }

        public Customer GetById(int id)
        {
            return _customers.Where(x => x.CustomerId == id).SingleOrDefault();
        }

        public List<Customer> Insert(Customer item)
        {
            _customers.Add(item);
            return _customers;
        }
    }
}
