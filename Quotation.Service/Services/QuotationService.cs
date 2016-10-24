using Insurance.Domain.Contracts;
using Insurance.Domain.Enumerators;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System.Collections.Generic;
using System;

namespace Quotations.Service.Services
{
    public class QuotationService : IQuotationService
    {
        private IQuotationRepository quotationRepository;
        private ICityRepository cityRepostitory;
        private ICustomerRepository customerRepository;
        private IBrokerInsuranceRepository brokerRepository;

        public QuotationService(IQuotationRepository quotationContext, 
            ICityRepository cityContext, 
            ICustomerRepository customerContext,
            IBrokerInsuranceRepository brokerContext)
        {
            this.quotationRepository = quotationContext;
            this.cityRepostitory = cityContext;
            this.customerRepository = customerContext;
            this.brokerRepository = brokerContext;
        }

        public void Create(QuotationContract contract)
        {
            var city = this.cityRepostitory.GetById(contract.CityId);
            var customer = this.customerRepository.GetById(contract.CustomerId);
            var quotation = new Quotation(customer, city);

            this.quotationRepository.Create(quotation);
        }

        public void Delete(int id)
        {
            var quotation = this.GetById(id);

            if (quotation != null)
            {
                this.quotationRepository.Delete(quotation);
            }
        }

        public void Dispose()
        {
            this.quotationRepository.Dispose();
            this.cityRepostitory.Dispose();
            this.customerRepository.Dispose();
            this.brokerRepository.Dispose();
        }

        public List<Quotation> GetAll()
        {
            return this.quotationRepository.GetAll();
        }

        public Quotation GetByCustomer(int customerId)
        {
            return this.quotationRepository.GetByCustomer(customerId);
        }

        public Quotation GetById(int id)
        {
            return this.quotationRepository.GetById(id);
        }

        public Quotation GetByStatus(QuotationStatusType status)
        {
            return this.quotationRepository.GetByStatus(status);
        }

        public void Update(Quotation quotation)
        {
            this.quotationRepository.Update(quotation);
        }

        public void AddQuotationBroker(int quotationId, int brokerInsuranceId)
        {
            var quotation = this.GetById(quotationId);
            var brokerInsurance = this.brokerRepository.GetById(brokerInsuranceId);

            if ((quotation != null) && (brokerInsurance != null))
            {
                quotation.QuotationBroker = new List<QuotationBroker>();

                var quotationBroker = new QuotationBroker(quotation, brokerInsurance);
                quotation.QuotationBroker.Add(quotationBroker);

                this.Update(quotation);
            }
        }
    }
}
