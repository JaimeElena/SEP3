using System;
using System.ComponentModel.DataAnnotations;

namespace Uber2.Models
{
    public class Order
    {
        [Key] public int id { get; set; }
        public Location driverLocation { get; set; }
        public Location customerLocation { get; set; }
        public Customer customer { get; set; }
        public Driver driver { get; set; }
        public string status { get; set; }
    }
}
