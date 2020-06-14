using System;
using ConsoleApp.Exercise4.Models;

namespace ConsoleApp.Exercise4.Helpers
{
    public class ConsoleHelper
    {
        public static Product NewProduct()
        {
            Console.WriteLine("Please enter product name : ");
            var name = Console.ReadLine();

            Console.WriteLine("Please enter Price (,): ");
            var price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Please enter Manufacturer id : ");
            var mID = int.Parse(Console.ReadLine());
            Manufacturer manufacturer = ManufacturerService.GetManufacturer(mID);

            Product product = new Product()
            {
                Name = name,
                Manufacturer = manufacturer,
                Price = price
            };
            return product;
        }
    }
}