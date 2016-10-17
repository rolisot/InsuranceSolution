using Insurance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Services
{
    public interface IStateService : IDisposable
    {
        State GetById(string id);
        List<State> GetAll();
    }
}
