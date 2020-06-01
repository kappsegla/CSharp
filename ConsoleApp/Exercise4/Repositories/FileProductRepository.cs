using System.Collections.Generic;
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
            
        }

        public void Delete(Product person)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Product person)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}