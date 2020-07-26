using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using ShoppingCartApi.Models;
using MongoDB.Driver;

namespace ShoppingCartApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _product;
        public ProductRepository()
        {
            
        }
        public ProductRepository(IShoppingCartDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _product = database.GetCollection<Product>(settings.ProductCollectionName);
        }

        public void Add(Product item)
        {
            _product.InsertOne(item);
        }

        public Product GetByProductId(string productId)
        {
            return _product.Find<Product>(product => product.Id == productId).FirstOrDefault();
        }

        public ICollection<Product> GetAll()
        {
            return _product.Find(product => true).ToList();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Delete(string productId)
        {
            throw new NotImplementedException();
        }
    }
}