using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Exercise4.Models;

namespace ConsoleApp.Exercise4.Repositories
{
    public class FileProductRepository : IProductRepository
    {
        private List<Product> _products;

        public FileProductRepository()
        {
            //Open file and
            //Read all products and put into _products
            //Only works if you have few products.....
            
        }
        
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(long id)
        {
            return _products.First(p => p.Id == id);
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
            //Save _products to file
        }
    }
}