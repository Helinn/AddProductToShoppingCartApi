using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using ShoppingCartApi.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace ShoppingCartApi.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IOptions<ShoppingCartDatabaseSettings> options) : base(options)
        {
        }

        public void Add(Product item)
        {
            _dbCollection.InsertOne(item);
        }

        public Product GetByProductId(string productId)
        {
            return _dbCollection.Find<Product>(product => product.Id == productId).FirstOrDefault();
        }

        public ICollection<Product> GetAll()
        {
            return _dbCollection.Find(product => true).ToList();
        }

        
    }
}