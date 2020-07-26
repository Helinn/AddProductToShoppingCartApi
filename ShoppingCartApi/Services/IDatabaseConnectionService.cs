
using System.Collections.Generic;
using MongoDB.Driver;
using ShoppingCartApi.Models;
using ShoppingCartApi.Requests;

namespace ShoppingCartApi.Services
{
    public interface IDatabaseConnectionService
    {
        IMongoDatabase SetDbConnection();
    }
}