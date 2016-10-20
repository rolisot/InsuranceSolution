using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface IBrokerInsuranceRepository : IDisposable
    {
        BrokerInsurance GetById(int id);
        List<BrokerInsurance> GetAllByBrokerId(int brokerId);
        void Create(BrokerInsurance brokerInsurance);
        void Delete(BrokerInsurance brokerInsurance);
    }
}
