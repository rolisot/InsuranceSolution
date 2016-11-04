using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Services
{
    public interface ICalculateIntegrationService : IDisposable
    {
        CalculateIntegration GetById(int id);
        List<CalculateIntegration> GetAllNew();
        List<CalculateIntegration> GetAllReceived();
        void Create(CalculateIntegration ci);
        void Update(CalculateIntegration ci);
        void PrepareQuotationsToCalculate();
        void CalculateQuotations();
        void GenerateEstimates();
    }
}
