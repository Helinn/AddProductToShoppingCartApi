using System.Collections.Generic;
using ShoppingCartApi.Models;
using ShoppingCartApi.Requests;

namespace ShoppingCartApi.Services
{
    public interface IShoppingCartService
    {
        bool AddProductToShoppingCart(AddToShoppingCartRequest request);

        ICollection<Product> GetProducts();
    }
}