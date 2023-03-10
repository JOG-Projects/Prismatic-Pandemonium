using MongoDB.Driver;
using Prismatic.Core.Domain;
using System.Linq.Expressions;

namespace Prismatic.Core.Infra
{
    public abstract class MongoRepository<T> : IRepository<T> where T : Entity
    {
        protected IMongoCollection<T> Collection { get; }

        protected string CollectionName { get; }

        public MongoRepository(IMongoClient mongoClient)
        {
            CollectionName = typeof(T).Name;
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

        public async Task<List<T>> Get(Func<T, bool> filter)
        {
            return await Collection.Find(x => filter(x)).ToListAsync();
        }

        public async Task Replace(Guid id, T newEntity)
        {
            await Collection.ReplaceOneAsync(x => x.Id == id, newEntity);
        }
    }
}
