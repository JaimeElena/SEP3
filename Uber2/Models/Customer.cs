using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace Uber2.Models
{
    public class Customer:User
    {
        public string birthday { get; set; }
        
        public string firstname{ get; set; }
        
        public string secondname{ get; set; }
        
        public string sex{ get; set; }
    }
}