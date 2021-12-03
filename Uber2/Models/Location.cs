using System.ComponentModel.DataAnnotations;

namespace Uber2.Models
{
    public class Location
    {
        [Key]public int id;
        public long lat { get; set; }
        public long lng { get; set; }
    }
}