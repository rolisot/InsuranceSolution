using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Insurance.Infraestructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private AppDataContext context;

        public CustomerRepository(AppDataContext ctx)
        {
            this.context = ctx;
        }

        public void Create(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public Customer GetById(int id)
        {
            return context.Customers
               .Include("Address")
               .Where(x => x.CustomerId == id)
               .FirstOrDefault();
        }

        public List<Customer> Get(int skip, int take)
        {
            return context.Customers.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
        }

        public List<Customer> GetAll()
        {
            return context.Customers.Include("Address").OrderBy(x => x.Name).ToList();
        }

        public void Update(Customer customer)
        {
            context.Entry<Customer>(customer).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Customer GetByUserId(Guid id)
        {
            return context.Customers
              .Include("Address")
              .Where(x => x.User.UserId == id)
              .FirstOrDefault();
        }

        public Customer GetByCpf(string cpf)
        {
            return context.Customers
              .Include("Address")
              .Where(x => x.Cpf == cpf)
              .FirstOrDefault();
        }

        public Customer GetByName(string name)
        {
            return context.Customers
              .Include("Address")
              .Where(x => x.Name == name)
              .FirstOrDefault();
        }

        //public Customer GetByQuotationId(int quotationId)
        //{
        //    var result = context.Customers
        //      .Include("Address")
        //      .Include("Quotation")
        //      .Select(x => x.Quotations.Where(q => q.QuotationId == quotationId))
        //      .ToList()
        //      .FirstOrDefault();

        //    return result.Single().Customer;
        //}
    }
}
