using System;
using System.ComponentModel.DataAnnotations;

namespace Uber2.Models
{
    public class Order
    {
        [Key]public int id { get; set; }
        public Location from { get; set; }
        public Location to { get; set; }
        public DateTime orderdate { get; set; }
    }
}