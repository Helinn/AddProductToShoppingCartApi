using System.Collections.Generic;
using ShoppingCartApi.Models;

namespace ShoppingCartApi.Repositories
{
    public interface IShoppingCartRepository
    {
        void Add(ShoppingCart item);
        ICollection<ShoppingCart> GetAll();

        ShoppingCart GetShoppingCartByProductId(string productId);

        void UpdateShoppingCart(ShoppingCart item);
    }
}