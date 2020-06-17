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
        
        //Update method, needed for MongoDB implementation
        //Not part of IRepository at the moment.
        //This code will actually replace an existing document with the new data.
        //All fields will be overwritten. Use UpdateOne to change just part of object.
        public void Update(Product product)
        {
            _collection.ReplaceOne(p => p.Id == product.Id, product);
        }
        

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}