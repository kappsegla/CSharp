using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsoleApp.Exercise4.Models
{
    public class Product
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }  //Don't use float or double for money
        public Manufacturer Manufacturer { get; set; }
        public List<Shop> Shops { get; set; } = new List<Shop>();

        public void RemoveShop(Shop shop)
        {
            Shops.Remove(shop);
        }
        
        
    }
}