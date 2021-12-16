using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using T1Driver.Models;
using T1Driver.Services;

namespace T1Driver.Data
{
    public class UserServices:IUserServices
    {
        private Order cacheOrder;
        private bool haveOrder;
        
        public void Connect()
        {
            ClientController.getInstance().Connect();
        }

        public async Task<string> Register(Driver driver)
        {
            return await ClientController.getInstance().Register(driver);
        }

        public async Task<Driver> Login(string username, string password)
        {
            return await ClientController.getInstance().Login(username,password);
        }

        public async Task Logout(Driver driver)
        {
            await ClientController.getInstance().Logout(driver);
        }

        public async Task<Driver> GetDriver(string username)
        {
            return await ClientController.getInstance().GetDriver(username);
        }

        public async Task<Driver> EditDriver(Driver driver)
        {
            return await ClientController.getInstance().EditDriver(driver);
        }

        public async Task<IList<Order>> GetOrders()
        {
            return await ClientController.getInstance().GetOrders();
        }

        public async Task<Order> AcceptOrder(Order order)
        { 
            cacheOrder = await ClientController.getInstance().AcceptOrder(order);
            haveOrder = true;
            return cacheOrder;
        }

        public Order GetCacheOrder()
        {
            return cacheOrder;
        }

        public async Task<Order> FinishOrder(Order order)
        {
            cacheOrder = await ClientController.getInstance().FinishOrder(order);
            haveOrder = false;
            return cacheOrder;
        }

        public bool getHaveOrder()
        {
            return haveOrder;
        }
    }
}