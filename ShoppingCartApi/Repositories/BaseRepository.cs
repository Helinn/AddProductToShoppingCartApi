using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ShoppingCartApi.Models;

namespace ShoppingCartApi.Repositories{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ShoppingCartDatabaseSettings databaseSettings;
        protected IMongoCollection<T> _dbCollection;

        protected BaseRepository(IOptions<ShoppingCartDatabaseSettings> options)
        {
            this.databaseSettings = options.Value;
            var client = new MongoClient(this.databaseSettings.ConnectionString);
            var db = client.GetDatabase(this.databaseSettings.DatabaseName);
            _dbCollection = db.GetCollection<T>(typeof(T).Name);
        }

        public IMongoCollection<T> GetCollection(string name)
        {
            return  _dbCollection;
        }

        public void Create(T obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(typeof(T).Name + " object is null");
            }
            _dbCollection.InsertOneAsync(obj);
        }

        public void Delete(string id)
        {
            //ex. 5dc1039a1521eaa36835e541

            var objectId = new ObjectId(id);
            _dbCollection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", objectId));

        }
        public virtual void Update(T obj)
        {
            throw new NotImplementedException();
           // _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()), obj);
        }

        public T Get(string id)
        {
            //ex. 5dc1039a1521eaa36835e541

            var objectId = new ObjectId(id);

            FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", objectId);

            return  _dbCollection.Find(filter).FirstOrDefault();

        }


        public IEnumerable<T> Get()
        {
            var all =  _dbCollection.Find(Builders<T>.Filter.Empty);
            return  all.ToList();
        }
    } 
}