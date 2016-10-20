using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Insurance.Infraestructure.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private AppDataContext _context;

        public PlanRepository(AppDataContext context)
        {
            this._context = context;
        }

        public void Create(Plan plan)
        {
            _context.Plans.Add(plan);
            _context.SaveChanges();
        }

        public void Delete(Plan plan)
        {
            _context.Plans.Remove(plan);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public List<Plan> GetAll()
        {
            return _context.Plans.Where(x => x.Active == true).OrderBy(x => x.Description).ToList();
        }

        public Plan GetById(int id)
        {
            return _context.Plans.Where(x => x.PlanId == id).FirstOrDefault();
        }

        public void Update(Plan plan)
        {
            _context.Entry<Plan>(plan).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
