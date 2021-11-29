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

        public void Register(string username, string password)
        {
            Driver driver = new Driver()
            {
                username = username,
                password = password
            };
            WebInstance.Register(username, password);
        }

        public Driver Login(string username, string password)
        {
            Driver driver = new Driver()
            {
                username = username,
                password = password
            };
            WebInstance.Login(username, password);
            return driver;
        }

        public void Logout()
        {
            WebInstance.Logout();
        }
    }
}