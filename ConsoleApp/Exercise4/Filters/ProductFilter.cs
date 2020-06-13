using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Exercise4.Models;
using ConsoleApp.Exercise4.Repositories;

namespace ConsoleApp.Exercise4.Filters
{
    public class ProductFilter
    {
        // Vi vill hantera Produkter och Butiker med Repository klasser.
        //     Vi vill kunna skapa, ta bort och ändra produkter och butiker.
        //     Vi vill kunna lägga till eller ta bort en produkt från en viss butik.
        //     Vi vill kunna söka efter produkter med följande villkor:
        // Hela eller delar av produktens namn.
        //     Produkter som kostar mindre än angivet pris, visa max 10 produkter.


        //     Vi vill kunna se vilka butiker som har en produkt i lager.
        public IEnumerable<Shop> ListShopsWithProduct(Product product)
        {
            throw new NotImplementedException();
        }

        //     Vi vill kunna visa en lista över alla tillverkare och hur många produkter varje tillverkare har.
        public IEnumerable<ProductCount> ListOfManufacturersWithProductCount(IProductRepository products)
        {
            return products.GetAll()
                .GroupBy(p => p.Producer).Select(g =>
                    new ProductCount(g.Key, g.Count()));
        }
    }

    public class ProductCount
    {
        public ProductCount(Producer producer, int count)
        {
            Producer = producer;
            Count = count;
        }

        public Producer Producer { get; }
        public int Count { get; }
    }
}