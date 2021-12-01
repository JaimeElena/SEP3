using System;
using System.Text.Json;
using T1Driver.Models;

namespace T1Driver.Services
{
    public class ClientController
    {
        private static ClientController instance;
        private IWebServices WebInstance = new WebServices();

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

        public void Register(string username, string password, int id)
        {
            Driver driver = new Driver()
            {
                username = username,
                password = password
            };
            WebInstance.Register(username, password, id);
        }

        public Driver Login(string username, string password)
        {

            Driver driver = WebInstance.Login(username, password);
            return driver;
        }

        public void Logout()
        {
            WebInstance.Logout();
        }

        public Driver GetDriver(string username)
        {
            Driver driver = WebInstance.GetDriver(username);
            return driver;
        }

        public Driver EditDriver(int id, string username, string password, string firstName, string lastName,
            DateTime birthday, string sex)
        {
            Driver driver = WebInstance.EditDriver(id, username, password, firstName, lastName, birthday, sex);
            return driver;
        }
    }
}