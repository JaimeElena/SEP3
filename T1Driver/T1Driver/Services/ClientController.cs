using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using T1Driver.Models;

namespace T1Driver.Services
{
    public class ClientController
    {
        private static ClientController instance;
        private ISocketConnectionService WebInstance = new SocketConnectionService();

        private ClientController() 
        {
        
        }

        public static ClientController getInstance()
        {
            if(instance == null)
            {
                instance = new ClientController();
            }
            return instance;
        }

        public void Connect()
        {
            WebInstance.Connect();
        }

        public async Task<string> Register(Driver driver)
        {
            return await WebInstance.Register(driver);
        }

        public async Task<Driver> Login(string username, string password)
        {

            String returnCode = await WebInstance.Login(username, password);
            Driver driver = JsonSerializer.Deserialize<Driver>(returnCode);
            return driver;
        }

        public async Task Logout(Driver driver)
        {
            await WebInstance.Logout(driver);
        }

        public async Task<Driver> GetDriver(string username)
        {
            Driver driver = await WebInstance.GetDriver(username);
            return driver;
        }

        public async Task<Driver> EditDriver(Driver driver)
        {
            Driver apidriver = await WebInstance.EditDriver(driver);
            return apidriver;
        }

        public async Task<IList<Order>> GetOrders()
        {
            return await WebInstance.GetOrders();
        }

        public async Task<Order> AcceptOrder(Order order)
        {
            Order apiorder = await WebInstance.AcceptOrder(order);
            return apiorder;
        }

    }
}