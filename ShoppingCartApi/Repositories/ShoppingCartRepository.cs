using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ShoppingCartApi.Models;

namespace ShoppingCartApi.Repositories
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(IOptions<ShoppingCartDatabaseSettings> options) : base(options)
        {
        }
        
        public void Add(ShoppingCart item)
        {
            _dbCollection.InsertOne(item);
        }

        public ICollection<ShoppingCart> GetAll()
        {
            return _dbCollection.Find<ShoppingCart>(item => true).ToList();
        }

        public ShoppingCart GetShoppingCartByProductId(string productId)
        {
            return _dbCollection.Find<ShoppingCart>(item => item.ProductId.Equals(productId)).SingleOrDefault();        
        }

        public void UpdateShoppingCart(ShoppingCart shoppingCartItem)
        {
            var filter = Builders<ShoppingCart>.Filter.Eq("Id", shoppingCartItem.Id);
            var update = Builders<ShoppingCart>.Update.Set("Amount", shoppingCartItem.Amount);
            _dbCollection.UpdateOne(filter,update);
        }
    }
}