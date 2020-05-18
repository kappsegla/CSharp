using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Regexes
{
    public class StringSearchExample
    {
        public void Run()
        {
            var text = "This is a string";
            
            bool contains = text.Contains("is");
            
            // Console.WriteLine(contains);
            // Console.WriteLine(text.IndexOf("is"));

            var products = new List<Product>()
            {
                new Product(){Name = "Apple"},
                new Product(){Name = "Banana"},
                new Product(){Name = "Apple Juice"},
                new Product(){Name = "Apple Pie"}
            };

            var searchTerm = "apple";
            
            foreach (var product in products)
            {
                if( product.Name.Contains(searchTerm,StringComparison.CurrentCultureIgnoreCase) )
                    Console.WriteLine(product.Name);
            }

            int count  = products.Where(p => p.Name.Contains(searchTerm)).Count();
            }
    }

    public class Product
    {
        public string Name { get; set; }
    }
}