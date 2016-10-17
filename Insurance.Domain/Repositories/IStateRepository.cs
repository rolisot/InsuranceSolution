using Insurance.Domain.Models;
using System.Collections.Generic;

namespace Insurance.Domain.Repositories
{
    public interface IStateRepository
    {
        State GetById(int id);
        List<State> GetAll();
    }
}
