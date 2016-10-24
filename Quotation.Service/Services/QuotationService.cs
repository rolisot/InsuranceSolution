using Insurance.Domain.Contracts;
using Insurance.Domain.Enumerators;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System.Collections.Generic;

namespace Quotations.Service.Services
{
    public class QuotationService : IQuotationService
    {
        private IQuotationRepository quotationRepository;
        private ICityRepository cityRepostitory;
        private ICustomerRepository customerRepository;

        public QuotationService(IQuotationRepository quotationContext, ICityRepository cityContext, ICustomerRepository customerContext)
        {
            this.quotationRepository = quotationContext;
            this.cityRepostitory = cityContext;
            this.customerRepository = customerContext;
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
            var quo = this.GetById(id);

            if (quo != null)
            {
                this.quotationRepository.Delete(quo);
            }
        }

        public void Dispose()
        {
            this.quotationRepository.Dispose();
            this.cityRepostitory.Dispose();
            this.customerRepository.Dispose();
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
    }
}
