using System.ComponentModel.DataAnnotations;

namespace UberDB.Models
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