using Insurance.Domain.Models;
using System;

namespace Insurance.Domain.Services
{
    public interface ICustomerUserService : IDisposable
    {
        CustomerUser GetByEmail(string email);
        void Create(string email, string password, string confirmPassword);
    }
}
