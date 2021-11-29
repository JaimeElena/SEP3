using UberT1Costumer.Models;
using UberT1Costumer.Services;

namespace UberT1Costumer.Data
{
    public class UserServices:IUserServices
    {
        public void Connect()
        {
            ClientController.getInstance().Connect();
        }

        public void Register(string username, string password)
        {
            ClientController.getInstance().Register(username,password);
        }

        public Costumer Login(string username, string password)
        {
            return ClientController.getInstance().Login(username,password);
        }

        public void Logout()
        {
            ClientController.getInstance().Logout();
        }
    }
}