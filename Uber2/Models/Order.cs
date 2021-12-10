using System;
using System.ComponentModel.DataAnnotations;

namespace Uber2.Models
{
    public class Order
    {
        [Key] public int id { get; set; }
        public string streetName { get; set; }
        public string customer { get; set; }
        
        public string driver { get; set; }
        public string status { get; set; }
    }
}
