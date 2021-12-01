using System;

namespace T1Driver.Models
{
    public class Driver:User

    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthday { get; set; }
        public string sex { get; set; }
    }
}