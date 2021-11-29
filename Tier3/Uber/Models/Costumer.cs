using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Uber.Models
{
    public class Costumer
    {
        [Required]
        [NotNull, Range(1, int.MaxValue, ErrorMessage = "Enter a value bigger than {1}")]
        [JsonPropertyName("UserId")]
        public int id { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("password")]
        public string password { get; set; }
    }
}
