using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApp.Exercise4.Files;
using ConsoleApp.Exercise4.Models;

namespace ConsoleApp.Exercise4.Repositories
{
    public class FileProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public FileProductRepository()
        {
            var path = Path.Combine(FileHandler.GetUserHomePath(), ".DemoApp2020", "products.json");
            _products = File.Exists(path) ? FileHandler.LoadFromJson<Product>("").ToList() : new List<Product>();
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(long id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(Product person)
        {
            _products.Remove(person);
            Save();
        }

        public void Insert(Product person)
        {
            _products.Add(person);
            Save();
        }

        public void Save()
        {
            var path = Path.Combine(FileHandler.GetUserHomePath(), ".DemoApp2020", "products.json");
            FileHandler.SaveToJson(path, _products);
        }
    }
}