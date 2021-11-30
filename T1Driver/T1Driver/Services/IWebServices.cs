using System;
using T1Driver.Models;

namespace T1Driver.Services
{
    public interface IWebServices
    {
        void Connect();
        string RequestReply(Request request);
        string Register(string username, string password, int id);
        string Login(string username, string password);
        void Logout();
        Driver GetDriver(string username);

        Driver EditDriver(int id, string username, string password, string firstName, string lastName,
            DateTime birthday,string sex);
    }
}