using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using ShoppingCartApi.Models;
using ShoppingCartApi.Repositories;
using ShoppingCartApi.Requests;

namespace ShoppingCartApi.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository shoppingCartRepository;

        private readonly IProductRepository productRepository;

        public ShoppingCartService()
        {
            productRepository = new ProductRepository();
            shoppingCartRepository = new ShoppingCartRepository();
        }
        public ShoppingCartService(IShoppingCartDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
    
            //_product = database.GetCollection<Product>(settings.ProductCollectionName);
            productRepository = new ProductRepository(settings);
            shoppingCartRepository = new ShoppingCartRepository(settings);
        }
        
        public bool AddProductToShoppingCart(AddToShoppingCartRequest request)
        {
            string productId = request.ProductId;
            int amount = request.Amount;
            var product = productRepository.GetByProductId(productId);
            var isAdded = true;
            if(product == null || product.AvailableQuantity == 0 || amount == 0){
                return false;
            }

            var shoppingCartItem = shoppingCartRepository.GetShoppingCartByProductId(productId);
            //if this product is not in shopping cart
            if(shoppingCartItem == null){
               shoppingCartItem = new ShoppingCart{
                   ProductId = product.Id,
                   Amount = Math.Min(product.AvailableQuantity, amount)
               };
               //adds the product to the shopping cart as much as the amount available in stock
                shoppingCartRepository.Add(shoppingCartItem);
            }else{
                if(product.AvailableQuantity - shoppingCartItem.Amount - amount >= 0){
                    shoppingCartItem.Amount += amount;
                }else {
                    shoppingCartItem.Amount += (product.AvailableQuantity - shoppingCartItem.Amount);
                    isAdded = false;
                }
                shoppingCartRepository.UpdateShoppingCart(shoppingCartItem);
            }
            return isAdded;
        }

        public ICollection<Product> GetProducts()
        {
            return productRepository.GetAll();
        }
    }
}