using System;

namespace T1Driver.Models
{
    public class Driver

    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string birthday { get; set; }
        public string sex { get; set; }
        public Boolean isLogged { get; set; }
    }
}