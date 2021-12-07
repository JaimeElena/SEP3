using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UberT1Costumer.Models
{
    public class Request
    {
        public string Type { get; set; }
        public Object Body { get; set; }
        public string RequestEntity = "costumer";
    }
}
