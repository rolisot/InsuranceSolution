using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System.Collections.Generic;

namespace InsuranceService.Services
{
    public class StateService : IStateService
    {
        private IStateRepository _repository;

        public StateService(IStateRepository repository)
        {
            this._repository = repository;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public List<State> GetAll()
        {
            return this._repository.GetAll();
        }

        public State GetById(int id)
        {
            return this._repository.GetById(id);
        }
    }
}
