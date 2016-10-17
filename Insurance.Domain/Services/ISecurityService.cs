using Insurance.Domain.Models;
using System;

namespace Insurance.Domain.Services
{
    public interface ISecurityService : IDisposable
    {
        User Authenticate(string email, string password);
        User GetByEmail(string email);
    }
}
