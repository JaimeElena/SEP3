using T1Driver.Models;

namespace T1Driver.Services
{
    public interface IWebServices
    {
        void Connect();
        string RequestReply(Request request);
        string Register(string username, string password);
        string Login(string username, string password);
        void Logout();
    }
}