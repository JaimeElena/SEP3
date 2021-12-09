using System;

namespace T1Driver.Models
{
    public class Driver

    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string secondname { get; set; }
        public string birthday { get; set; }
        public string sex { get; set; }
        public Boolean isLogged { get; set; }
        public string numberplate { get; set; }
    }
}