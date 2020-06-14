using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Exercise4.Filters;
using ConsoleApp.Exercise4.Helpers;
using ConsoleApp.Exercise4.Models;
using ConsoleApp.Exercise4.Repositories;

namespace ConsoleApp.Exercise4
{
    public class Program
    {
        //public static void Main(string[] args)
        public static void Run()
        {
            //Composition Root. Create all objects we need.
            IProductRepository productRepository = new MongoDbProductRepository();//new FileProductRepository();
            IShopRepository shopRepository = new FileShopRepository();    
            ManufacturerService manufacturerService= new ManufacturerService();
            
            ProductFilter productFilter = new ProductFilter(productRepository,shopRepository);
            
            var shop = new Shop(){Id="1",Name="Ica Maxi"};
            var shop1 = new Shop(){Id="2",Name="Coop"};

            //Create new product
            var product = ConsoleHelper.NewProduct();
            //Add shops to product
            shopRepository.Insert(shop);
            shopRepository.Insert(shop1);
            
            product.AddShop(shop);
            product.AddShop(shop1);
            
            //Insert new product into repository
            productRepository.Insert(product);

            
            PrintList("Products for each Manufacturer",productFilter.ListOfManufacturersWithProductCount());
            PrintList("Products costing less than 20",productFilter.ProductsCostingLessThan(20));
            }

        public static void PrintList<T>(string header, IEnumerable<T> items)
        {
            Console.WriteLine(header);
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}