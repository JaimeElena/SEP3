using System.ComponentModel.DataAnnotations;

namespace Uber2.Models
{
    public class Location
    {
        [Key] public int id { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }
}