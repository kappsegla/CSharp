using System.Collections.Generic;
using ConsoleApp.Exercise4.Models;
using MongoDB.Driver;

namespace ConsoleApp.Exercise4.Repositories
{
    public class MongoDbProductRepository : IProductRepository
    {
        private IMongoCollection<Product> _collection;

        public MongoDbProductRepository(IMongoCollection<Product> collection)
        {
            _collection = collection;
        }

        public IEnumerable<Product> GetAll()
        {
            var all = _collection.Find(Builders<Product>.Filter.Empty);
            return all.ToEnumerable();
        }

        public Product GetById(string id)
        {
            return _collection.Find(Builders<Product>.Filter.Eq(x => x.Id, id)).FirstOrDefault();
        }

        public void Delete(Product product)
        {
            //Builders<Product>.Filter.Eq(x => x.Id, id)
            _collection.DeleteOne(s => s.Id == product.Id);
        }

        public void Insert(Product product)
        {
            _collection.InsertOne(product);
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}