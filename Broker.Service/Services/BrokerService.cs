using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System.Collections.Generic;

namespace Brokers.Service.Services
{
    public class BrokerService : IBrokerService
    {
        private IBrokerRepository repository;
        private ICityRepository cityRepository;

        public BrokerService(IBrokerRepository context, ICityRepository cityContext)
        {
            this.repository = context;
            this.cityRepository = cityContext;
        }

        public void Create(string name, string cnpj, int cityId)
        {
            var city = this.cityRepository.GetById(cityId);
            var broker = new Broker(name, cnpj, city);
            this.repository.Create(broker);
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }

        public List<Broker> GetAll()
        {
            return this.repository.GetAll();
        }

        public Broker GetById(int id)
        {
            return this.repository.Get(id);
        }
    }
}
