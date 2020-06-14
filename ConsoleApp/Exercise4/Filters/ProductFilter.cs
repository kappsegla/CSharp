using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Exercise4.Extensions;
using ConsoleApp.Exercise4.Models;
using ConsoleApp.Exercise4.Repositories;
using ConsoleApp.Repository;

namespace ConsoleApp.Exercise4.Filters
{
    public class ProductFilter
    {
        private IProductRepository ProductRepository { get; }
        private IShopRepository ShopRepository { get; }
        
        public ProductFilter(IProductRepository productRepository, IShopRepository shopRepository)
        {
            ProductRepository = productRepository;
            ShopRepository = shopRepository;
        }
        
        // Vi vill hantera Produkter och Butiker med Repository klasser.
        //     Vi vill kunna skapa, ta bort och ändra produkter och butiker.
        //     Vi vill kunna lägga till eller ta bort en produkt från en viss butik.
     
        // Sök på produktens namn.
        public IEnumerable<Product> SearchProductByName(string name)
        {
            return ProductRepository.GetAll().Where(p => p.Name.Contains(name));
        }
        
        //Produkter som kostar mindre än angivet pris, visa max 10 produkter.
        public IEnumerable<Product> ProductsCostingLessThan(decimal price)
        {
            return ProductRepository.GetAll().Where(p => p.Price < price).Take(10);
        }
        
        //Vi vill kunna se vilka butiker som har en produkt i lager.
        public IEnumerable<Shop> ListShopsWithProduct(Product product)
        {
            return product.Shops;
        }

        //Vi vill kunna visa en lista över alla tillverkare och hur många produkter varje tillverkare har.
        public IEnumerable<ProductCount> ListOfManufacturersWithProductCount()
        {
            return ProductRepository.GetAll()
                .GroupBy(p => p.Manufacturer).Select(g =>
                    new ProductCount(g.Key, g.Count()));
        }
    }

    public class ProductCount
    {
        public ProductCount(Manufacturer manufacturer, int count)
        {
            Manufacturer = manufacturer;
            Count = count;
        }

        public Manufacturer Manufacturer { get; }
        public int Count { get; }

        public override string ToString()
        {
            return "Manufacturer " + " " + Manufacturer.Name + " " + Count.Pluralize("product");
        }
    }
}