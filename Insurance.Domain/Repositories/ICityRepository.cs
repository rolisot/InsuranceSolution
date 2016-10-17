using Insurance.Domain.Models;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface ICityRepository
    {
        City GetById(int id);
        List<City> GetAll(int stateId);
    }
}
