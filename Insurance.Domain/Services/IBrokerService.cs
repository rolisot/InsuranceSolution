using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Services
{
    public interface IBrokerService : IDisposable
    {
        Broker GetById(int id);
        List<Broker> GetAll();
        void Create(string name, string cnpj, int cityId);
    }
}
