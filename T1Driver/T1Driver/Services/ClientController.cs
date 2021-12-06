using System;
using System.Text.Json;
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

        public string Register(string username, string password)
        {
            Driver driver = new Driver()
            {
                username = username,
                password = password
            };
            return WebInstance.Register(username, password);
        }

        public Driver Login(string username, string password)
        {

            String returnCode = WebInstance.Login(username, password);
            Driver driver = JsonSerializer.Deserialize<Driver>(returnCode);
            return driver;
        }

        public void Logout(Driver driver)
        {
            WebInstance.Logout(driver);
        }

        public Driver GetDriver(string username)
        {
            Driver driver = WebInstance.GetDriver(username);
            return driver;
        }

        public Driver EditDriver(Driver driver)
        {
            Driver apidriver = WebInstance.EditDriver(driver);
            return apidriver;
        }
    }
}