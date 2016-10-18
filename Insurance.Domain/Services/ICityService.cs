using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Services
{
    public interface ICityService : IDisposable
    {
        City GetById(int id);
        List<City> GetAll(int stateId);
    }
}
