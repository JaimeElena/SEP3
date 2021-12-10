using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using T1Driver.Models;

namespace T1Driver.Data
{
    public interface IUserServices
    {
        void Connect();
        Task<string> Register(Driver driver);
        Task<Driver> Login(string username, string password);
        Task Logout(Driver driver);
        Task<Driver> GetDriver(string username);
        Task<Driver> EditDriver(Driver driver);
        Task<IList<Order>> GetOrders();
        Task<Order> AcceptOrder(Order order);
        Order GetCacheOrder();
    }
}