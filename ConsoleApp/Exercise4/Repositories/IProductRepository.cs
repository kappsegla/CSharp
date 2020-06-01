using System.Collections.Generic;
using ConsoleApp.Exercise4.Models;

namespace ConsoleApp.Exercise4.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(long id);
        void Delete(Product person);
        void Insert(Product person);
        void Save();
    }
}