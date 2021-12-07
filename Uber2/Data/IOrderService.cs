using System.Collections.Generic;
using System.Threading.Tasks;
using Uber2.Models;

namespace Uber2.Data
{
    public interface IOrderService
    {
        Task<IList<Order>> GetOrdersAsync();

        Task<Order> AddOrder(Order order);
        
        Task<Order> SearchOrder(int id);

        Task<Location> GetDriverLocation(int orderId);

        Task<Location> GetCustomerLocation(int orderId);

        Task<Order> EditOrderStatus(Order order);
    }
}
