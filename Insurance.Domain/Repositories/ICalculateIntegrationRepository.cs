using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface ICalculateIntegrationRepository : IDisposable
    {
        CalculateIntegration GetById(int id);
        List<CalculateIntegration> GetAllNew();
        List<CalculateIntegration> GetAllReceived();
        List<CalculateIntegration> GetAllFinished();
        List<CalculateIntegration> GetAllOnEstimate();
        List<CalculateIntegration> GetAllSended();
        void Create(CalculateIntegration ci);
        void Update(CalculateIntegration ci);
    }
}
