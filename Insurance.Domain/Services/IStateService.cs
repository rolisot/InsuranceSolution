using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Services
{
    public interface IStateService : IDisposable
    {
        State GetById(int id);
        List<State> GetAll();
    }
}
