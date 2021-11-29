using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Uber.Models
{
    public class User
    {
        [Key] public int id { get; set; }
        [Required] public string username { get; set; }
        [Required] public string password { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}