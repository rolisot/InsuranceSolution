using Insurance.Domain.Contracts;
using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Services
{
    public interface ICustomerService : IDisposable
    {
        Customer GetById(int id);
        Customer GetByName(string name);
        Customer GetByCpf(string cpf);
        Customer GetByUserId(Guid userId);
        void Create(CustomerContract contract);
        List<Customer> GetByRange(int skip, int take);
        List<Customer> GetAll();
        void Delete(int id);
        void Update(Customer customer);
    }
}
