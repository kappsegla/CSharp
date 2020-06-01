using System;
using System.Collections.Generic;

namespace ConsoleApp.Exercise4.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }  //Don't use float or double for money
        public Producer Producer { get; set; }
        public List<Shop> Shops { get; }

        public void RemoveShop(Shop shop)
        {
            Shops.Remove(shop);
        }
        
        
    }
}