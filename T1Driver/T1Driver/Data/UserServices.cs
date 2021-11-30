using System;
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

        public void Register(string username, string password, int id)
        {
            ClientController.getInstance().Register(username,password,id);
        }

        public Driver Login(string username, string password)
        {
            return ClientController.getInstance().Login(username,password);
        }

        public void Logout()
        {
            ClientController.getInstance().Logout();
        }

        public Driver GetDriver(string username)
        {
            return ClientController.getInstance().GetDriver(username);
        }

        public Driver EditDriver(int id, string username, string password, string firstName, string lastName,
            DateTime birthday, string sex)
        {
            return ClientController.getInstance().EditDriver(id, username, password, firstName, lastName, birthday, sex);
        }

    }
}