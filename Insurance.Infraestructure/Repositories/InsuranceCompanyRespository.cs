using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Insurance.Infraestructure.Repositories
{
    public class InsuranceCompanyRespository : IInsuranceCompanyRepository
    {
        private AppDataContext _context;

        public InsuranceCompanyRespository(AppDataContext context)
        {
            this._context = context;
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public List<InsuranceCompany> GetAll()
        {
            return _context.InsuranceCompanies.OrderBy(x => x.Name).ToList();
        }

        public InsuranceCompany GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
