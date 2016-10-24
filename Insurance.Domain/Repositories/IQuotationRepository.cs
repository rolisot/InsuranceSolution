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
        Quotation GetByStatus(QuotationStatusType status);
        List<Quotation> GetAll();
        void Create(Quotation quotation);
        void Update(Quotation quotation);
        void Delete(Quotation quotation);
    }
}
