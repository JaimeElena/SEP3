using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UberT1Costumer.Models;

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

        public void Register(string username, string password)
        {
            Costumer costumer = new Costumer()
            {
                username = username,
                password = password
            };
            WebInstance.Register(username, password);
        }

        public Costumer Login(string username, string password)
        {
            Costumer costumer = new Costumer()
            {
                username = username,
                password = password
            };
            WebInstance.Login(username, password);
            return costumer;
        }

        public void Logout()
        {
            WebInstance.Logout();
        }
    }
}
