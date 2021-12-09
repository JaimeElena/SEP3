using System;
using System.Collections.Generic;
using T1Driver.Models;
using T1Driver.Services;

namespace T1Driver.Data
{
    public class UserServices:IUserServices
    {
        private Order cacheOrder;
        
        public void Connect()
        {
            ClientController.getInstance().Connect();
        }

        public string Register(Driver driver)
        {
            return ClientController.getInstance().Register(driver);
        }

        public Driver Login(string username, string password)
        {
            return ClientController.getInstance().Login(username,password);
        }

        public void Logout(Driver driver)
        {
            ClientController.getInstance().Logout(driver);
        }

        public Driver GetDriver(string username)
        {
            return ClientController.getInstance().GetDriver(username);
        }

        public Driver EditDriver(Driver driver)
        {
            return ClientController.getInstance().EditDriver(driver);
        }

        public IList<Order> GetOrders()
        {
            return ClientController.getInstance().GetOrders();
        }

        public Order AcceptOrder(Order order)
        { 
            cacheOrder = ClientController.getInstance().AcceptOrder(order);
            return cacheOrder;
        }

        public Order GetCacheOrder()
        {
            return cacheOrder;
        }

    }
}