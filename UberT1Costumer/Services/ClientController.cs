﻿using System;
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

        public void DisConnect()
        {
            
        }

        public string Register(string username, string password)
        {
            Costumer costumer = new Costumer()
            {
                username = username,
                password = password
            };
            return WebInstance.Register(username, password);
        }

        public Costumer Login(string username, string password)
        {
           String returnCode = WebInstance.Login(username, password);
           Costumer costumer = JsonSerializer.Deserialize<Costumer>(returnCode);
           return costumer;
        }

        public void Logout(Costumer costumer)
        {
            WebInstance.Logout(costumer);
        }
        
        public Costumer GetCostumer(string username)
        {
            Costumer costumer = WebInstance.GetCostumer(username);
            return costumer;
        }

        public Costumer EditCostumer(Costumer costumer)
        {
            Costumer apiCostumer = WebInstance.EditCostumer(costumer);
            return apiCostumer;
        }
    }
}
