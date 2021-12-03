﻿using System;
using T1Driver.Models;

namespace T1Driver.Data
{
    public interface IUserServices
    {
        void Connect();
        string Register(string username, string password);
        Driver Login(string username, string password);
        void Logout(Driver driver);
        Driver GetDriver(string username);

        Driver EditDriver(int id, string username, string password, string firstName, string secondName,
            string birthday, string sex);
    }
}