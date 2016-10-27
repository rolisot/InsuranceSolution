using Insurance.Domain.Enumerators;
using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface IQuotationRepository : IDisposable
    {
        Quotation GetById(int id);
        Quotation GetByCustomer(int customerId);
        List<Quotation> GetByStatus(QuotationStatusType status);
        Customer GetCustomerByQuotationId(int quotationId);
        List<Quotation> GetAll();
        void Create(Quotation quotation);
        void Update(Quotation quotation);
        void Delete(Quotation quotation);
        void AddBrokersByCoordinates(Quotation quotation);
        void AddQuotationBrokerParameter();
    }
}
