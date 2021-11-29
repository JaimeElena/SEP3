using T1Driver.Models;

namespace T1Driver.Data
{
    public interface IUserServices
    {
        void Connect();
        void Register(string username, string password);
        Driver Login(string username, string password);
        void Logout();
    }
}