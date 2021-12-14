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

        Task<Order> EditOrderStatus(Order order,string status);

        Task<IList<Order>> GetCompletedOrders(string customer);

        Task<IList<Order>> GetPendingOrders();

        Task<Order> EditOrderDriver(Order order);

        Task<string> GetCustomerStreetName(Order order);

        Task<string> GetDestinationStreetName(Order order);

        Task DeleteOrder(int id);
    }
}
