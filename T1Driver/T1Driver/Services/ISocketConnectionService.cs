using System;
using T1Driver.Models;

namespace T1Driver.Services
{
    public interface ISocketConnectionService
    {
        void Connect();
        string RequestReply(Request request);
        string Register(string username, string password);
        string Login(string username, string password);
        void Logout(Driver driver);
        Driver GetDriver(string username);
        Driver EditDriver(int id, string username, string password, string firstName, string secondName,
            string birthday,string sex);
    }
}