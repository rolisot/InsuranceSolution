using Insurance.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Domain.Models;
using Insurance.Infraestructure.Data;

namespace Insurance.Infraestructure.Repositories
{
    public class BrokerInsuranceRepository : IBrokerInsuranceRepository
    {
        private AppDataContext context;

        public BrokerInsuranceRepository(AppDataContext ctx)
        {
            this.context = ctx;
        }

        public void Create(BrokerInsurance brokerInsurance)
        {
            throw new NotImplementedException();
        }

        public void Delete(BrokerInsurance brokerInsurance)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public List<BrokerInsurance> GetAllByBrokerId(int brokerId)
        {
            return this.context.BrokerInsurances
                .Include("Broker")
                .Where(x => x.Broker.BrokerId == brokerId)
                .ToList();
        }

        public BrokerInsurance GetById(int id)
        {
            return this.context.BrokerInsurances
                .Where(x => x.BrokerInsuranceId == id)
                .FirstOrDefault();
        }
    }
}
