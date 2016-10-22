using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface ICustomerRepository : IDisposable
    {
        List<Customer> GetAll();
        List<Customer> Get(int skip, int take);
        Customer GetById(int id);
        Customer GetByUserId(Guid id);
        Customer GetByCpf(string cpf);
        Customer GetByName(string name);
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
