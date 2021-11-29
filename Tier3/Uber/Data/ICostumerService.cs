using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uber.Models;

namespace Uber.Data
{
    public interface ICostumerService
    {
        Task<Costumer> AddCostumerAsync(Costumer costumer);
        Task<IList<Costumer>> GetCostumersAsync();
    }
}
