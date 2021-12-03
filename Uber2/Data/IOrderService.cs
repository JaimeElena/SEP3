using System.Collections.Generic;
using System.Threading.Tasks;
using Uber2.Models;

namespace Uber2.Data
{
    public interface IOrderService
    {
        Task<IList<Order>> GetOrdersAsync();
        
        Task<Order> SearchOrder(int id);
    }
}