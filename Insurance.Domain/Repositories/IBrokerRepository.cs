using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface IBrokerRepository : IDisposable
    {
        Broker GetById(int id);
        Broker GetByCnpj(string cnpj);
        Broker GetByName(string name);
        //BrokerInsurance GetByBrokerInsuranceId(int brokerInsuranceId);
        List<Broker> GetAll();
        void Create(Broker broker);
        void Update(Broker broker);
        void Delete(Broker broker);
        List<BrokerInsurance> GetBrokersByCoordinates(decimal latitude, decimal longitude);
    }
}
