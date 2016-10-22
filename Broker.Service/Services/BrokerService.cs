using Insurance.Domain.Contracts;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System.Collections.Generic;

namespace Brokers.Service.Services
{
    public class BrokerService : IBrokerService
    {
        private IBrokerRepository brokerRepository;
        private ICityRepository cityRepository;
        private IInsuranceCompanyRepository insuranceRepository;

        public BrokerService(IBrokerRepository brokerContext, ICityRepository cityContext, IInsuranceCompanyRepository insuranceContext)
        {
            this.brokerRepository = brokerContext;
            this.cityRepository = cityContext;
            this.insuranceRepository = insuranceContext;
        }

        public void Create(BrokerContract contract)
        {
            var city = this.cityRepository.GetById(contract.CityId);
            var broker = new Broker(contract.Name, contract.Cnpj, city);
            
            if(contract.Parameters != null)
            {
                broker.BrokerParameter = new List<BrokerParameter>();
                broker.BrokerParameter.Add(new BrokerParameter(broker, contract.Parameters.Commission));
            }

            if (contract.Insurances != null && contract.Insurances.Count > 0)
            {
                broker.BrokerInsurance = new List<BrokerInsurance>();

                foreach (BrokerInsuranceContract bi in contract.Insurances)
                {
                    var insurance = this.insuranceRepository.GetById(bi.InsuranceId);
                    broker.BrokerInsurance.Add(new BrokerInsurance(broker, insurance, bi.Login, bi.Password));
                }
            }

            this.brokerRepository.Create(broker);
        }

        public void Dispose()
        {
            this.brokerRepository.Dispose();
            this.cityRepository.Dispose();
            this.insuranceRepository.Dispose();
        }

        public List<Broker> GetAll()
        {
            return this.brokerRepository.GetAll();
        }

        public Broker GetById(int id)
        {
            return this.brokerRepository.GetById(id);
        }
    }
}
