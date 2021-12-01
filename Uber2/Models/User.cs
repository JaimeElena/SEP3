using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Uber2.Models
{
    public class User
    {
        [Key] public int id { get; set; }
        
        [Required] public string username { get; set; }
        [Required] public string password { get; set; }
        
         public bool isLogged { get; set; }

    }
}