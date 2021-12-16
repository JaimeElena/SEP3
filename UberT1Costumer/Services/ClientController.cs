using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UberT1Costumer.Models;
using System.Text.Json;

namespace UberT1Costumer.Services
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

        public async Task<string> Register(string username, string password)
        {
            Costumer costumer = new Costumer()
            {
                username = username,
                password = password
            };
            return await WebInstance.Register(username, password);
        }

        public async Task<Costumer> Login(string username, string password)
        {
           String returnCode = await WebInstance.Login(username, password);
           Costumer costumer = JsonSerializer.Deserialize<Costumer>(returnCode);
           return costumer;
        }

        public async Task Logout(Costumer costumer)
        {
            await WebInstance.Logout(costumer);
        }
        
        public async Task<Costumer> GetCostumer(string username)
        {
            return await WebInstance.GetCostumer(username);
        }

        public async Task<Costumer> EditCostumer(Costumer costumer)
        {
            return await WebInstance.EditCostumer(costumer);
            
        }

        public async Task<Order> RequestVehicle(Order order)
        {
            return await WebInstance.RequestVehicle(order);
        }

        public async Task<string> CancelRequest(Order order)
        {
            return await WebInstance.CancelRequest(order);
        }

        public async Task<Order> CheckProcess(Order order)
        {
            return await WebInstance.CheckProcess(order);
        }

        public async Task<IList<Order>> GetHistory(Costumer costumer)
        {
            return await WebInstance.GetHistory(costumer);
        }
    }
}
