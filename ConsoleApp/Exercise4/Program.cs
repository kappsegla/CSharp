﻿using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Exercise4.Filters;
using ConsoleApp.Exercise4.Helpers;
using ConsoleApp.Exercise4.Models;
using ConsoleApp.Exercise4.Repositories;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

//https://garywoodfine.com/configuration-api-net-core-console-application/
namespace ConsoleApp.Exercise4
{
    public class Program
    {
        public static void PrintList<T>(string header, IEnumerable<T> items)
        {
            Console.WriteLine(header);
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        //public static void Main(string[] args)
        public static void Run()
        {
            //Read configuration file
            //Change connection string for database in file appsettings.json or appsettings.dev.json for a special developer
            //database.
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.dev.json", true, true)
                .Build();
            var con = configuration["ConnectionStrings:DefaultConnection"];

            //Composition Root. Create all objects we need.
            var _client = new MongoClient(con);
            var _database = _client.GetDatabase("Warehouse");
            var _collection = _database.GetCollection<Product>("Products");

            IProductRepository
                productRepository = new MongoDbProductRepository(_collection); //new FileProductRepository();
            IShopRepository shopRepository = new FileShopRepository();
            ManufacturerService manufacturerService = new ManufacturerService();

            ProductFilter productFilter = new ProductFilter(productRepository, shopRepository);

            var shop = new Shop() {Id = "1", Name = "Ica Maxi"};
            var shop1 = new Shop() {Id = "2", Name = "Coop"};

            //Create new product
            var product = ConsoleHelper.NewProduct();
            //Add shops to product
            shopRepository.Insert(shop);
            shopRepository.Insert(shop1);

            product.AddShop(shop);
            product.AddShop(shop1);

            //Insert new product into repository
            productRepository.Insert(product);

            PrintList("Products for each Manufacturer", productFilter.ListOfManufacturersWithProductCount());
            PrintList("Products costing less than 20", productFilter.ProductsCostingLessThan(20));

            //Do some changes
            // PrintList("All products", productRepository.GetAll().Select(p => p.Price));
            //
            // product.Price = (decimal) 123.45;
            // ((MongoDbProductRepository) productRepository).Update(product);
            //
            // PrintList("All products", productRepository.GetAll().Select(p => p.Price));
        }
    }
}