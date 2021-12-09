using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Uber2.Models
{
    public class User
    {
        [Key] public int id { get; set; }
        
        [Required] public string username { get; set; }
        
        [Required] public string password { get; set; }
        
         [Required,DefaultValue(false)]public bool isLogged { get; set; }
         
         public string birthday { get; set; }
        
         public string firstname{ get; set; }
        
         public string secondname{ get; set; }
        
         public string sex{ get; set; }
    }
}