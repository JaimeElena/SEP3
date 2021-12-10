using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UberT1Costumer.Models;

namespace UberT1Costumer.Services
{
    interface ISocketConnectionService
    {
        void Connect();
        Task<string> RequestReply(Request request);
        Task<string> Register(string username, string password);
        Task<string> Login(string username, string password);
        Task Logout(Costumer costumer);
        Task<Costumer> GetCostumer(string username);
        Task<Costumer> EditCostumer(Costumer costumer);
        Task<Order> GetOrder(Costumer costumer);
        Task<Order> RequestVehicle(Order order);
        Task<string> CancelRequest(Order order);
        Task<string> CheckProcess(Order order);

    }
}
