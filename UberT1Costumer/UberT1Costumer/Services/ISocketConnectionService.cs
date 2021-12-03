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
        string RequestReply(Request request);
        string Register(string username, string password);
        string Login(string username, string password);
        void Logout(Costumer costumer);
        Costumer GetCostumer(string username);
        Costumer EditCostumer(int id, string username, string password, string firstName, string secondName,
            string birthday,string sex);
    }
}
