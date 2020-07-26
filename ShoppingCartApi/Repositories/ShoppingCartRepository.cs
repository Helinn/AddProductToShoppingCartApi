using System.Collections.Generic;
using MongoDB.Driver;
using ShoppingCartApi.Models;

namespace ShoppingCartApi.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IMongoCollection<ShoppingCart> _shoppingCart;
        public ShoppingCartRepository()
        {
            
        }
        public ShoppingCartRepository(IShoppingCartDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _shoppingCart = database.GetCollection<ShoppingCart>(settings.ShoppingCartCollectionName);
        }

        public void Add(ShoppingCart item)
        {
            _shoppingCart.InsertOne(item);
        }

        public ICollection<ShoppingCart> GetAll()
        {
            return _shoppingCart.Find<ShoppingCart>(item => true).ToList();
        }

        public ShoppingCart GetShoppingCartByProductId(string productId)
        {
            return _shoppingCart.Find<ShoppingCart>(item => item.ProductId.Equals(productId)).SingleOrDefault();        
        }

        public void UpdateShoppingCart(ShoppingCart shoppingCartItem)
        {
            var filter = Builders<ShoppingCart>.Filter.Eq("Id", shoppingCartItem.Id);
            var update = Builders<ShoppingCart>.Update.Set("Amount", shoppingCartItem.Amount);
            _shoppingCart.UpdateOne(filter,update);
        }
    }
}