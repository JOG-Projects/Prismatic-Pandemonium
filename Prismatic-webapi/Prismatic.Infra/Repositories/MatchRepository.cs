using MongoDB.Driver;
using Prismatic.Core.Infra;
using Prismatic.Domain.Entities;
using Prismatic.Domain.Interfaces;

namespace Prismatic.Infra.Repositories
{
    public class MatchRepository : MongoRepository<Match>, IMatchRepository
    {
        public MatchRepository(IMongoClient mongoClient) : base(mongoClient)
        {

        }
    }
}