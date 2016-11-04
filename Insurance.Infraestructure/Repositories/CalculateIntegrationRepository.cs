using Insurance.Domain.Enumerators;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Infraestructure.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter("QuotationId", ci.Quotation.QuotationId),
            new SqlParameter("BrokerId", ci.Broker.BrokerId),
            new SqlParameter("SendText", ci.SendText),
            new SqlParameter("Status", (int) ci.Status )};

            context.Database.ExecuteSqlCommand(@"
                INSERT INTO CalculateIntegration 
                (QuotationId,BrokerId,SendText,Status)VALUES
                (@QuotationId, @BrokerId, @SendText, @Status)",
                parameters);
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
