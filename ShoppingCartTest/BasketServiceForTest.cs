using System.Collections.Generic;
using ShoppingCartApi.Models;
using ShoppingCartApi.Requests;
using ShoppingCartApi.Services;

namespace ShoppingCartTest
{
    public class BasketServiceForTest : IShoppingCartService
    {
        private readonly List<Product> Products;

        private readonly List<ShoppingCart> ShoppingCart;

        public BasketServiceForTest()
        {
            ShoppingCart = new List<ShoppingCart>(){
                new ShoppingCart() { Id = "p1" , ProductId = "1", Amount = 2},
                new ShoppingCart() { Id = "p2" , ProductId = "2", Amount = 1},
                new ShoppingCart() { Id = "p3" , ProductId = "3", Amount = 3},
            };

            Products = new List<Product>()
            {
                new Product() { Id = "1", Name = "Rose", Price = 5.00, AvailableQuantity = 5 },
                new Product() { Id = "2", Name = "Terrarium", Price = 4.00, AvailableQuantity = 10  },
                new Product() { Id = "3", Name = "Orchid", Price = 12.00, AvailableQuantity = 8  }
            };

        }

        public Product GetProductById(string Id)
        {
            return Products.Find(x => x.Id == Id);
        }

        public ICollection<Product> GetProducts()
        {
            return Products;
        }

        public bool AddProductToShoppingCart(AddToShoppingCartRequest request)
        {
            string productId = request.ProductId;
            int amount = request.Amount;
            var product = GetProductById(productId);
            if(product != null){
                //ShoppingCart.Add(request);
                return true;
            }
            return false;
        }
    }
}