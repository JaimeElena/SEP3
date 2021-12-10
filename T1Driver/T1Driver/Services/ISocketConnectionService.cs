using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using T1Driver.Models;

namespace T1Driver.Services
{
    public interface ISocketConnectionService
    {
        void Connect();
        Task<string> RequestReply(Request request);
        Task<string> Register(Driver driver);
        Task<string> Login(string username, string password);
        Task Logout(Driver driver);
        Task<Driver> GetDriver(string username);
        Task<Driver> EditDriver(Driver driver);
        Task<IList<Order>> GetOrders();
        Task<Order> AcceptOrder(Order order);

    }
}