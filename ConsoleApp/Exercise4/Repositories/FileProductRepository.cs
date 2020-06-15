using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApp.Exercise4.Models;
using ConsoleApp.Exercise4.Helpers;

namespace ConsoleApp.Exercise4.Repositories
{
    public class FileProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public FileProductRepository()
        {
            var path = Path.Combine(FileHelper.GetUserHomePath(), ".DemoApp2020", "products.json");
            _products = File.Exists(path) ? FileHelper.LoadFromJson<Product>(path).ToList() : new List<Product>();
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(string id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(Product product)
        {
            _products.Remove(product);
            Save();
        }

        public void Insert(Product product)
        {
            _products.Add(product);
            Save();
        }

        public void Save()
        {
            var path = Path.Combine(FileHelper.GetUserHomePath(), ".DemoApp2020", "products.json");
            FileHelper.SaveToJson(path, _products);
        }
    }
}