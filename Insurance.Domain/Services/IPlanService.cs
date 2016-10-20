using Insurance.Domain.Contracts;
using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Services
{
    public interface IPlanService : IDisposable
    {
        Plan GetById(int id);
        List<Plan> GetAll();
        void Create(PlanContract contract);
        void Signature(SignatureContract contract);
    }
}
