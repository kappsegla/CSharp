using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Exercise4.Entities
{
    public class WareHouseContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql("Server=192.168.1.109;Database=Warehouse;User=root;Password=vmlsunyf;");
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<Shop> Shops { get; set; }
    }

    public class Shop
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}