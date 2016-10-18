using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface IStateRepository : IDisposable
    {
        State GetById(int id);
        List<State> GetAll();
    }
}
