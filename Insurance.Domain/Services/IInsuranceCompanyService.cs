using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Services
{
    public interface IInsuranceCompanyService : IDisposable
    {
        InsuranceCompany GetById(int id);
        List<InsuranceCompany> GetAll();
    }
}
