using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;


namespace ShoppingCartApi.Services
{
    public class BaseMongoRepository<T>
    {
        private readonly IMongoCollection<T> mongoCollection;

        public BaseMongoRepository(string mongoDBConnectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(mongoDBConnectionString);
            var database = client.GetDatabase(dbName);
            mongoCollection = database.GetCollection<T>(collectionName);
        }

        public IMongoCollection<T> GetmongoCollection()
        {
            return mongoCollection;
        }
        // public virtual List<T> GetList()
        // {
        //     return mongoCollection.Find(book => true).ToList();
        // }

        // public virtual T GetById(string id)
        // {
        //     var docId = new ObjectId(id);
        //     return mongoCollection.Find<T>(m => m.Id == docId).FirstOrDefault();
        // }

        // public virtual TModel Create(TModel model)
        // {
        //     mongoCollection.InsertOne(model);
        //     return model;
        // }

        // public virtual void Update(string id, TModel model)
        // {
        //     var docId = new ObjectId(id);
        //     mongoCollection.ReplaceOne(m => m.Id == docId, model);
        // }

        // public virtual void Delete(TModel model)
        // {
        //     mongoCollection.DeleteOne(m => m.Id == model.Id);
        // }

        // public virtual void Delete(string id)
        // {
        //     var docId = new ObjectId(id);
        //     mongoCollection.DeleteOne(m => m.Id == docId);
        // }
    }
}