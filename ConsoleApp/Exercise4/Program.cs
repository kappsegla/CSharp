using System.Linq;
using ConsoleApp.Exercise4.Models;
using ConsoleApp.Exercise4.Repositories;

namespace ConsoleApp.Exercise4
{
    public class Program
    {
        //public static void Main(string[] args)
        public static void Run()
        {
            FileProductRepository products = new FileProductRepository();

            var product = new Product();
            var producer = new Producer();
            product.Producer = producer;
            //producer.Products.Add(product);

            //Insert new product into repository
            products.Insert(product);
        }
    }
}