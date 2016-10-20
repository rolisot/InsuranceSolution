using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Infraestructure.Data;
using System.Collections.Generic;
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

        public Broker Get(int id)
        {
            return context.Brokers.Include("City").Where(x => x.BrokerId == id).FirstOrDefault();
        }

        public List<Broker> GetAll()
        {
            return context.Brokers.Include("City").OrderBy(x => x.Name).ToList();
        }

        public void Update(Broker broker)
        {
            context.Entry<Broker>(broker).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
