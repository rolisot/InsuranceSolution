using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface ICityRepository : IDisposable
    {
        City GetById(int id);
        List<City> GetAll(int stateId);
    }
}
