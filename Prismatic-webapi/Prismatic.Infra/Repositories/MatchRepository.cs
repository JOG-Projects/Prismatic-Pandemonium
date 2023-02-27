using MongoDB.Driver;
using Prismatic.Core.Infra;
using Prismatic.Domain.Entities;
using Prismatic.Domain.Interfaces;

namespace Prismatic.Infra.Repositories
{
    public class MatchRepository : MongoRepository<Match>, IMatchRepository
    {
        protected override string CollectionName => "MatchCollection";

        public MatchRepository(IMongoClient mongoClient) : base(mongoClient)
        {

        }
    }
}
