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
        private ICityRepository cityRepository;
        private IUserRepository userRepository;

        public CustomerService(ICustomerRepository customerContext, ICityRepository cityContext, IUserRepository userContext)
        {
            this.customerRepository = customerContext;
            this.cityRepository = cityContext;
            this.userRepository = userContext;
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
            this.customerRepository.Dispose();
            this.cityRepository.Dispose();
            this.userRepository.Dispose();
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
            var city = this.cityRepository.GetById(contract.CityId);
            var user = this.userRepository.GetById(Guid.Parse(contract.UserId));

            var customer = new Customer(
                user, 
                contract.Name, 
                contract.Cpf, 
                contract.Phone,
                city, 
                DateTime.Parse(contract.BirthDate));

            this.customerRepository.Create(customer);
        }

        public void Update(Customer customer)
        {
            this.customerRepository.Update(customer);
        }
    }
}
