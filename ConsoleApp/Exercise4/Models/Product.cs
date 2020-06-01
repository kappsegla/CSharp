using System;

namespace ConsoleApp.Exercise4.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Producer Producer { get; set; }
    }
}