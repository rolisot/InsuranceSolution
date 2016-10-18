using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System.Collections.Generic;

namespace InsuranceService.Services
{
    public class CityService : ICityService
    {
        private ICityRepository _repository;

        public CityService(ICityRepository repository)
        {
            this._repository = repository;
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }

        public List<City> GetAll(int stateId)
        {
            return this._repository.GetAll(stateId);
        }

        public City GetById(int id)
        {
            return this._repository.GetById(id);
        }
    }
}
