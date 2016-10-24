using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface IUserRepository : IDisposable
    {
        User GetById(Guid id);
        User GetByEmail(string email);
        List<User> GetByRange(int skip, int take);
        List<User> GetAll();
        void Create(User user);
        void Update(User user);
        void Delete(User user);
    }
}
