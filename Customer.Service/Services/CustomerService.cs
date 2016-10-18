using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System;
using System.Collections.Generic;

namespace Customers.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            this._repository = repository;
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetByCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetByRange(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public void Register(string name, string email, string cpf, string birthDate, string phone, int cityId)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
