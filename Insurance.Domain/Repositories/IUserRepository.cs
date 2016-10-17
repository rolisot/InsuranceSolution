﻿using Insurance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Repositories
{
    public interface IUserRepository : IDisposable
    {
        User Get(string email);
        User Get(Guid id);
        List<User> Get(int skip, int take);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
    }
}
