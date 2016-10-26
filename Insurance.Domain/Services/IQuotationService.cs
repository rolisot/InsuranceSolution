using Insurance.Domain.Contracts;
using Insurance.Domain.Enumerators;
using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Services
{
    public interface IQuotationService : IDisposable
    {
        Quotation GetById(int id);
        Quotation GetByCustomer(int customerId);
        List<Quotation> GetByStatus(QuotationStatusType status);
        List<Quotation> GetAll();
        void Create(QuotationContract contract);
        void Update(Quotation quotation);
        void Delete(int id);
        void AddQuotationBrokers();
        void AddQuotationBroker(Quotation quotation);
    }
}
