using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Infraestructure.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Insurance.Infraestructure.Repositories
{
    public class BrokerRepository : IBrokerRepository
    {
        private AppDataContext context;

        public BrokerRepository(AppDataContext ctx)
        {
            this.context = ctx;
        }

        public void Create(Broker broker)
        {
            context.Brokers.Add(broker);
            context.SaveChanges();
        }

        public void Delete(Broker broker)
        {
            context.Brokers.Remove(broker);
            context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public Broker GetById(int id)
        {
            return context.Brokers
                .Include("Address")
                .Include("BrokerParameter")
                .Include("BrokerPlan")
                .Include("BrokerInsurance")
                .Include("BrokerInsurance.Insurance")
                .Where(x => x.BrokerId == id)
                .FirstOrDefault();
        }

        public List<Broker> GetAll()
        {
            return context.Brokers
                .Include("Address")
                .OrderBy(x => x.Name).ToList();
        }

        public void Update(Broker broker)
        {
            context.Entry<Broker>(broker).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Broker GetByCnpj(string cnpj)
        {
            return context.Brokers
                .Include("Address")
                .Include("BrokerParameter")
                .Include("BrokerPlan")
                .Include("BrokerInsurance")
                .Include("BrokerInsurance.Insurance")
                .Where(x => x.Cnpj.Equals(cnpj))
                .FirstOrDefault();
        }

        public Broker GetByName(string name)
        {
            return context.Brokers
                .Include("Address")
                .Include("BrokerParameter")
                .Include("BrokerPlan")
                .Include("BrokerInsurance")
                .Include("BrokerInsurance.Insurance")
                .Where(x => x.Name.Equals(name))
                .FirstOrDefault();
        }

        public List<BrokerInsurance> GetBrokersByCoordinates(decimal latitude, decimal longitude)
        {
            SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter( "@Latitude", latitude),
            new SqlParameter("@Longitude", longitude) };

            return context.BrokerInsurances
                .SqlQuery("GetBrokersByCoordinates @Latitude, @Longitude", parameters)
                .ToList();
        }
    }
}
