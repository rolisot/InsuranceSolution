using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface IBrokerRepository : IDisposable
    {
        Broker Get(int id);
        List<Broker> GetAll();
        void Create(Broker broker);
        void Update(Broker broker);
        void Delete(Broker broker);
    }
}
