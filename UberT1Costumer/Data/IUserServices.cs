using System.Threading.Tasks;
using UberT1Costumer.Models;
using UberT1Costumer.Models;

namespace UberT1Costumer.Data
{
    public interface IUserServices
    {
        void Connect();
        Task<string> Register(string username, string password);
        Task<Costumer> Login(string username, string password);
        Task Logout(Costumer costumer);
        Task<Costumer> GetCostumer(string username);
        Task<Costumer> EditCostumer(Costumer costumer);
        Task<Order> GetOrder(Costumer costumer);
    }
}