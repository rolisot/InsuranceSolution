using Insurance.Domain.Enumerators;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System.Collections.Generic;

namespace Estimates.Service.Services
{
    public class EstimateService : IEstimateService
    {
        private IEstimateRepository repository;

        public EstimateService(IEstimateRepository context)
        {
            this.repository = context;
        }

        public void Create(Estimate estimate)
        {
            this.repository.Create(estimate);
        }

        public void Delete(Estimate estimate)
        {
            this.repository.Delete(estimate);
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }

        public List<Estimate> GetAll()
        {
            return this.repository.GetAll();
        }

        public Estimate GetById(int id)
        {
            return this.repository.GetById(id);
        }

        public List<Estimate> GetByStatus(EstimateStatusType status)
        {
            return this.repository.GetByStatus(status);
        }

        public void Update(Estimate estimate)
        {
            this.repository.Update(estimate);
        }
    }
}
