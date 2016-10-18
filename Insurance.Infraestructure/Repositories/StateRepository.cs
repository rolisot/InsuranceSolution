using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Insurance.Infraestructure.Repositories
{
    public class StateRepository : IStateRepository
    {
        private AppDataContext _context;

        public StateRepository(AppDataContext context)
        {
            this._context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<State> GetAll()
        {
            return _context.States.OrderBy(x => x.Abbreviation).ToList();
        }

        public State GetById(int id)
        {
            return _context.States.Where(x => x.StateId == id).FirstOrDefault();
        }
    }
}
