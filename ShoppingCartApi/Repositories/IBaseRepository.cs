
using System.Collections.Generic;

namespace ShoppingCartApi.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(string id);
        T Get(string id);
        IEnumerable<T> Get();
    }
}