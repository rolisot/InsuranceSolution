using Insurance.Domain.Enumerators;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Insurance.Infraestructure.Repositories
{
    public class EstimateRepository : IEstimateRepository
    {
        private AppDataContext context;

        public EstimateRepository(AppDataContext ctx)
        {
            this.context = ctx;
        }

        public void Create(Estimate estimate)
        {
            this.context.Estimates.Add(estimate);
            this.context.SaveChanges();
        }

        public void Delete(Estimate estimate)
        {
            this.context.Estimates.Remove(estimate);
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public List<Estimate> GetAll()
        {
            return context.Estimates.ToList();
        }

        public Estimate GetById(int id)
        {
            return context.Estimates
                .Include("QuotationBroker")
                .Where(x => x.EstimateId == id)
                .FirstOrDefault();
        }

        public List<Estimate> GetByStatus(EstimateStatusType status)
        {
            return context.Estimates
               .Include("QuotationBroker")
               .Include("QuotationBroker.BrokerInsurance")
               .Include("QuotationBroker.BrokerInsurance.Broker")
               .Include("QuotationBroker.BrokerInsurance.Insurance")
               .Where(x => x.Status == status)
               .ToList();
        }

        public void Update(Estimate estimate)
        {
            context.Entry<Estimate>(estimate).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
