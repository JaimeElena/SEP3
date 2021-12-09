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

        public string Register(string username, string password)
        {
            return ClientController.getInstance().Register(username,password);
        }

        public Costumer Login(string username, string password)
        {
            return ClientController.getInstance().Login(username,password);
        }

        public void Logout(Costumer costumer)
        {
            ClientController.getInstance().Logout(costumer);
        }
        
        public Costumer GetCostumer(string username)
        {
            return ClientController.getInstance().GetCostumer(username);
        }

        public Costumer EditCostumer(Costumer costumer)
        {
            return ClientController.getInstance().EditCostumer(costumer);
        }

        public Order GetOrder(Costumer costumer)
        {
            return ClientController.getInstance().GetOrder(costumer);
        }
    }
}