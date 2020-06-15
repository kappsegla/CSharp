using ConsoleApp.Exercise4.Models;
using ConsoleApp.Exercise4.Repositories;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace TestConsoleApp
{
    public class MongoDBProductRepositoryTest
    {
        [Fact]
        public void InsertProductCallsInsertOneOnCollection()
        {
            //Arrange
            var collectionMock = new Mock<IMongoCollection<Product>>();
            collectionMock.Setup(p => p.InsertOne(It.IsAny<Product>(),
                null, default(CancellationToken))).Verifiable();
            var repo = new MongoDbProductRepository(collectionMock.Object);
            var product = new Product();
            
            //Act
            repo.Insert(product);
            
            //Assert
            collectionMock.Verify(collection => collection.InsertOne(It.IsAny<Product>(),
                null, default(CancellationToken)), Times.Once );
        }
    }
}