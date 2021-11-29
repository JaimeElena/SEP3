using UberT1Costumer.Models;
using UberT1Costumer.Models;

namespace UberT1Costumer.Data
{
    public interface IUserServices
    {
        void Connect();
        void Register(string username, string password);
        Costumer Login(string username, string password);
        void Logout();
    }
}