using System;
using System.ComponentModel.DataAnnotations;

namespace Uber2.Models
{
    public class Order
    {
        [Key] public int id { get; set; }
        public double clat { get; set; }
        
        public double clng { get; set; }
        
        public double dlat { get; set; }
        
        public double dlng { get; set; }
        public string customer { get; set; }
        
        public string driver { get; set; }
        public string status { get; set; }
    }
}
