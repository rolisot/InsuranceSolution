using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Services
{
    public interface IBrokerInsuranceService : IDisposable
    {
        BrokerInsurance GetById(int id);
        List<BrokerInsurance> GetAllByBrokerId(int brokerId);
        void Create(int brokerId, int insuranceId, string login, string password);
    }
}
