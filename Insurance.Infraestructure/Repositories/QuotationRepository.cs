using Insurance.Domain.Enumerators;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Insurance.Infraestructure.Repositories
{
    public class QuotationRepository : IQuotationRepository
    {
        private AppDataContext context;

        public QuotationRepository(AppDataContext ctx)
        {
            this.context = ctx;
        }

        public void Create(Quotation quotation)
        {
            context.Quotations.Add(quotation);
            context.SaveChanges();
        }

        public void Delete(Quotation quotation)
        {
            context.Quotations.Remove(quotation);
            context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public List<Quotation> GetAll()
        {
            return context.Quotations.OrderBy(x => x.RegisterDate).ToList();
        }

        public Quotation GetByCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Quotation GetById(int id)
        {
            return context.Quotations
                .Include("City")
                .Include("Customer")
                .Include("Customer.Address")
                .Where(x => x.QuotationId == id)
                .FirstOrDefault();
        }

        public Quotation GetByStatus(QuotationStatusType status)
        {
            return context.Quotations
                .Include("City")
                .Include("Customer")
                .Where(x => x.Status == status)
                .FirstOrDefault();
        }

        public Customer GetCustomerByQuotationId(int quotationId)
        {
            var quotation = context.Quotations
                .Include("City")
                .Include("Customer")
                .Where(x => x.QuotationId == quotationId)
                .FirstOrDefault();

            return quotation.Customer;
        }

        public void Update(Quotation quotation)
        {
            context.Entry<Quotation>(quotation).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
