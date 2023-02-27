﻿using MongoDB.Driver;
using Prismatic.Core.Domain;

namespace Prismatic.Core.Infra
{
    public abstract class MongoRepository<T> : IRepository<T> where T : Entity
    {
        protected IMongoCollection<T> Collection { get; }

        protected abstract string CollectionName { get; }

        public MongoRepository(IMongoClient mongoClient)
        {
            var db = mongoClient.GetDatabase("Prismatic");
            Collection = db.GetCollection<T>(CollectionName);
        }

        public async Task<Guid> Add(T entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity.Id;
        }

        public async Task<T> Get(Guid id)
        {
            return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }
    }
}
