using System.ComponentModel.DataAnnotations;

namespace Uber2.Models
{
    public class Customer:User
    {
        [Required]
        public string birthday { get; set; }
        [Required]
        public string firstname{ get; set; }
        [Required]
        public string secondname{ get; set; }
        [Required]
        public string sex{ get; set; }
    }
}