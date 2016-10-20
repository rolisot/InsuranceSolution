using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface IPlanRepository : IDisposable
    {
        Plan GetById(int id);
        List<Plan> GetAll();
        void Create(Plan plan);
        void Update(Plan plan);
        void Delete(Plan plan);
    }
}
