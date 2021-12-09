using System;
using System.Collections.Generic;
using T1Driver.Models;

namespace T1Driver.Data
{
    public interface IUserServices
    {
        void Connect();
        string Register(string username, string password);
        Driver Login(string username, string password);
        void Logout(Driver driver);
        Driver GetDriver(string username);
        Driver EditDriver(Driver driver);
        public IList<Order> GetOrders();
        public Order AcceptOrder(Order order);
        public Order GetCacheOrder();
    }
}