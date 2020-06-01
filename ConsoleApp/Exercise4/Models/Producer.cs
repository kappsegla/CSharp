using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConsoleApp.Exercise4.Models
{
    public class Producer
    {
        public string Name { get; set; }
        // [JsonIgnore]
        // public List<Product> Products { get; set; }
    }
}