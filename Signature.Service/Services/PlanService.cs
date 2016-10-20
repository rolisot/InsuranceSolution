using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System.Collections.Generic;
using System;

namespace Signatures.Service.Services
{
    public class PlanService : IPlanService
    {
        private IPlanRepository _repository;

        public PlanService(IPlanRepository repository)
        {
            this._repository = repository;
        }

        public void Create(string description, decimal price, int days)
        {
            var plan = new Plan(description, price, days);
            _repository.Create(plan);
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }

        public List<Plan> GetAll()
        {
            return this._repository.GetAll();
        }

        public Plan GetById(int id)
        {
            return this._repository.GetById(id);
        }
    }
}
