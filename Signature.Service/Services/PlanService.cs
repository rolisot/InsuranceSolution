using Insurance.Domain.Contracts;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System.Collections.Generic;

namespace Signatures.Service.Services
{
    public class PlanService : IPlanService
    {
        private IPlanRepository planRepository;
        private IBrokerRepository brokerRepository;

        public PlanService(IPlanRepository planContext, IBrokerRepository brokerContext)
        {
            this.planRepository = planContext;
            this.brokerRepository = brokerContext;
        }

        public void Create(PlanContract contract)
        {
            var plan = new Plan(contract.Description, contract.Price, contract.Days);
            planRepository.Create(plan);
        }

        public void Dispose()
        {
            this.planRepository.Dispose();
            this.brokerRepository.Dispose();
        }

        public List<Plan> GetAll()
        {
            return this.planRepository.GetAll();
        }

        public Plan GetById(int id)
        {
            return this.planRepository.GetById(id);
        }

        public void Signature(SignatureContract contract)
        {
            var plan = this.GetById(contract.PlanId);
            var broker = this.brokerRepository.GetById(contract.BrokerId);

            plan.BrokerPlan = new List<BrokerPlan>();
            plan.BrokerPlan.Add(new BrokerPlan(broker, plan));

            planRepository.Create(plan);
        }
    }
}
