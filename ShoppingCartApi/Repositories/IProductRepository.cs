using System.Collections.Generic;
using ShoppingCartApi.Models;

namespace ShoppingCartApi.Repositories
{
    public interface IProductRepository
    {
        void Add(Product item);
        Product GetByProductId(string productId);
        ICollection<Product> GetAll();
    }
}