using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface ICustomerRepository : IDisposable
    {
        Customer Get(int id);
        List<Customer> Get(int skip, int take);
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
