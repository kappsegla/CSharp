using System.Linq;
using ConsoleApp.Exercise4.Models;
using ConsoleApp.Exercise4.Repositories;

namespace ConsoleApp.Exercise4
{
    public class Program
    {
        public static void Run()
            //public static void Main(string[] args)
        {
            FileProductRepository products = new FileProductRepository();

            var product = new Product();
            var producer = new Producer();
            product.Producer = producer;
            //producer.Products.Add(product);

            //Insert new product into repository
            products.Insert(product);


            //Vi vill kunna visa en lista över alla tillverkare och hur många produkter varje tillverkare har.
            var numberOfProductForEachProducer = products.GetAll()
                .GroupBy(p => p.Producer).Select(g =>
                    new {Producer = g.Key, Count = g.Count()}).ToList();
            


        }
    }
}