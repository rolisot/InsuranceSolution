using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System.Collections.Generic;

namespace InsuranceService.Services
{
    public class InsuranceCompanyService : IInsuranceCompanyService
    {
        private IInsuranceCompanyRepository _repository;

        public InsuranceCompanyService(IInsuranceCompanyRepository repository)
        {
            this._repository = repository;
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }

        public List<InsuranceCompany> GetAll()
        {
            return this._repository.GetAll();
        }

        public InsuranceCompany GetById(int id)
        {
            return this._repository.GetById(id);
        }
    }
}
