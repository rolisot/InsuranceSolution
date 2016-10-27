using Insurance.Domain.Enumerators;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Insurance.Infraestructure.Repositories
{
    public class CalculateIntegrationRepository : ICalculateIntegrationRepository
    {
        private AppDataContext context;

        public CalculateIntegrationRepository(AppDataContext ctx)
        {
            this.context = ctx;
        }

        public void Create(CalculateIntegration ci)
        {
            context.CalculateIntegrations.Add(ci);
            context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public List<CalculateIntegration> GetAllFinished()
        {
            return this.GetByStatus(CalculatingIntegrationStatusType.Finished);
        }

        public List<CalculateIntegration> GetAllOnEstimate()
        {
            return this.GetByStatus(CalculatingIntegrationStatusType.OnEstimate);
        }

        public List<CalculateIntegration> GetAllSended()
        {
            return this.GetByStatus(CalculatingIntegrationStatusType.Sended);
        }

        public List<CalculateIntegration> GetAllNew()
        {
            return this.GetByStatus(CalculatingIntegrationStatusType.New);
        }

        public List<CalculateIntegration> GetAllReceived()
        {
            return this.GetByStatus(CalculatingIntegrationStatusType.Received);
        }

        private List<CalculateIntegration> GetByStatus(CalculatingIntegrationStatusType status)
        {
            return context.CalculateIntegrations
                .Include("Quotation")
                .Include("Broker")
                .Where(x => x.Status == status)
                .ToList();
        }

        public CalculateIntegration GetById(int id)
        {
            return context.CalculateIntegrations
                .Include("Quotation")
                .Include("Broker")
                .Where(x => x.CalculateIntegrationId == id)
                .FirstOrDefault();
        }

        public void Update(CalculateIntegration ci)
        {
            context.Entry<CalculateIntegration>(ci).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
