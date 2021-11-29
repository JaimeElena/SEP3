using T1Driver.Models;
using T1Driver.Services;

namespace T1Driver.Data
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

        public Driver Login(string username, string password)
        {
            return ClientController.getInstance().Login(username,password);
        }

        public void Logout()
        {
            ClientController.getInstance().Logout();
        }
    }
}