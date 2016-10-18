using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Insurance.Infraestructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private AppDataContext _context;

        public CityRepository(AppDataContext context)
        {
            this._context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<City> GetAll(int stateId)
        {
            return _context.Cities.Include("State").Where(x => x.State.StateId == stateId).ToList();
        }

        public City GetById(int id)
        {
            return _context.Cities.Include("State").Where(x => x.CityId == id).FirstOrDefault();
        }
    }
}
