using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface IInsuranceCompanyRepository : IDisposable
    {
        InsuranceCompany GetById(int id);
        List<InsuranceCompany> GetAll();
    }
}
