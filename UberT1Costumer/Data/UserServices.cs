using System.Threading.Tasks;
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

        public async Task<string> Register(string username, string password)
        {
            return await ClientController.getInstance().Register(username,password);
        }

        public async Task<Costumer> Login(string username, string password)
        {
            return await ClientController.getInstance().Login(username,password);
        }

        public async Task Logout(Costumer costumer)
        {
            await ClientController.getInstance().Logout(costumer);
        }
        
        public async Task<Costumer> GetCostumer(string username)
        {
            return await ClientController.getInstance().GetCostumer(username);
        }

        public async Task<Costumer> EditCostumer(Costumer costumer)
        {
            return await ClientController.getInstance().EditCostumer(costumer);
        }
        
    }
}