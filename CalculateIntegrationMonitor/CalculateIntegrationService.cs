using Insurance.Domain.Enumerators;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System.Collections.Generic;

namespace CalculateIntegrationMonitor
{
    public class CalculateIntegrationService : ICalculateIntegrationService
    {

        private ICalculateIntegrationRepository repository;
        private IQuotationRepository quotationRepository;

        public CalculateIntegrationService(ICalculateIntegrationRepository context, IQuotationRepository quotationContext)
        {
            this.repository = context;
            this.quotationRepository = quotationContext;
        }

        public void Create(CalculateIntegration ci)
        {
            this.repository.Create(ci);
        }

        public void Dispose()
        {
            this.repository.Dispose();
            this.quotationRepository.Dispose();
        }

        public List<CalculateIntegration> GetAllNew()
        {
            return this.repository.GetAllNew();
        }

        public List<CalculateIntegration> GetAllReceived()
        {
            return this.repository.GetAllReceived();
        }

        public CalculateIntegration GetById(int id)
        {
            return this.repository.GetById(id);
        }

        public void Update(CalculateIntegration ci)
        {
            this.repository.Update(ci);
        }

        public void PrepareQuotationsToCalculate()
        {
            List<Quotation> quotations = this.quotationRepository.GetByStatus(QuotationStatusType.WaitCalculate);

            if (quotations != null)
            {
                foreach (Quotation quotation in quotations)
                {
                    foreach (QuotationBroker qb in quotation.QuotationBroker)
                    {
                        CalculateIntegration ci = new CalculateIntegration(quotation, qb.BrokerInsurance.Broker,"XML");
                        this.repository.Create(ci);
                    }

                    quotation.SetProcessingCalculateStatus();
                    this.quotationRepository.Update(quotation);
                }
            }
        }
    }
}
