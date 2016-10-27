using Insurance.Domain.Enumerators;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;

namespace Quotations.Service.Services
{
    public class QuotationBrokersService : IQuotationBrokersService
    {
        private IQuotationRepository repository;
        private IBrokerRepository brokerRepository;

        public QuotationBrokersService(IQuotationRepository context, IBrokerRepository brokerContext)
        {
            repository = context;
            brokerRepository = brokerContext;
        }

        public void AddQuotationBrokers()
        {
            var quotations = this.repository.GetByStatus(QuotationStatusType.New);

            if (quotations != null)
            {
                foreach (Quotation quotation in quotations)
                {
                    this.repository.AddBrokersByCoordinates(quotation);
                }
            }
        }


        public void AddQuotationBrokerParameters()
        {
            this.repository.AddQuotationBrokerParameter();
        }

        public void Dispose()
        {
            repository.Dispose();
            brokerRepository.Dispose();
        }
    }
}
