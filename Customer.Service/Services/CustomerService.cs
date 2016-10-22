using Insurance.Domain.Contracts;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System;
using System.Collections.Generic;

namespace Customers.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository repository)
        {
            this.customerRepository = repository;
        }

        public void Delete(int id)
        {
            var customer = this.GetById(id);

            if (customer != null)
            {
                this.customerRepository.Delete(customer);
            }
        }

        public void Dispose()
        {
            customerRepository.Dispose();
        }

        public List<Customer> GetAll()
        {
            return this.customerRepository.GetAll();
        }

        public Customer GetByCpf(string cpf)
        {
            return this.customerRepository.GetByCpf(cpf);
        }

        public Customer GetById(int id)
        {
            return this.customerRepository.GetById(id);
        }

        public Customer GetByName(string name)
        {
            return this.customerRepository.GetByName(name);
        }

        public List<Customer> GetByRange(int skip, int take)
        {
            return this.customerRepository.Get(skip, take);
        }

        public Customer GetByUserId(Guid userId)
        {
            return this.customerRepository.GetByUserId(userId);
        }

        public void Create(CustomerContract contract)
        {
            var customer = new Customer(
                Guid.Parse(contract.UserId), 
                contract.Name, 
                contract.Cpf, 
                contract.Phone, 
                contract.CityId, 
                DateTime.Parse(contract.BirthDate));

            this.customerRepository.Create(customer);
        }

        public void Update(Customer customer)
        {
            this.customerRepository.Update(customer);
        }
    }
}
