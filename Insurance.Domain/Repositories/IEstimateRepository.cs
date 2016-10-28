using Insurance.Domain.Enumerators;
using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface IEstimateRepository : IDisposable
    {
        Estimate GetById(int id);
        List<Estimate> GetByStatus(EstimateStatusType status);
        List<Estimate> GetAll();
        void Create(Estimate estimate);
        void Update(Estimate estimate);
        void Delete(Estimate estimate);
    }
}
