using Insurance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Services
{
    public interface ICityService : IDisposable
    {
        City GetById(string id);
        List<City> GetAll(string stateId);
    }
}
