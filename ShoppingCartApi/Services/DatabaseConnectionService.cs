// using Microsoft.Extensions.Configuration;
// using System.Collections.Generic;
// using MongoDB.Driver;
// using ShoppingCartApi.Models;
// using ShoppingCartApi.Requests;
// using System.Configuration;

// namespace ShoppingCartApi.Services
// {
//     public class DatabaseConnectionService : IDatabaseConnectionService
//     {
//         private readonly IConfiguration Configuration;

//         public IShoppingCartDatabaseSettings SetDbConnection(){
//             var connectionString = Configuration.GetValue<string>("ShoppingCartDatabaseSettings:ConnectionString");
//             var databaseName = Configuration.GetValue<string>("ShoppingCartDatabaseSettings:DatabaseName");
//             var client = new MongoClient(connectionString);
//             var database = client.GetDatabase(databaseName);
//             return database;
//         }
//     }
// }