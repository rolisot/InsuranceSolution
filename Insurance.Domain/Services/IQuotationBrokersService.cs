using System;

namespace Insurance.Domain.Services
{
    public interface IQuotationBrokersService : IDisposable
    {
        void AddQuotationBrokers();
    }
}
