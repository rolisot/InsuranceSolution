using Insurance.Domain.Contracts;
using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Services
{
    public interface IBrokerService : IDisposable
    {
        Broker GetById(int id);
        Broker GetByName(string name);
        Broker GetByCnpj(string cnpj);
        List<Broker> GetAll();
        void Create(BrokerContract contract);
        void Delete(int id);
        void Update(Broker broker);
    }
}
