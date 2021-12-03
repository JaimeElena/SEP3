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

        public Costumer EditCostumer(int id, string username, string password, string firstName, string secondName,
            string birthday, string sex)
        {
            return ClientController.getInstance().EditCostumer(id, username, password, firstName, secondName, birthday, sex);
        }
    }
}