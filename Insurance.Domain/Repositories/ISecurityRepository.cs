using Insurance.Domain.Models;
using System;

namespace Insurance.Domain.Repositories
{
    public interface ISecurityRepository : IDisposable
    {
        User Get(string email);
        void Update(User user);
    }
}
