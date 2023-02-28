using MongoDB.Driver;
using Prismatic.Core.Infra;
using Prismatic.Domain.Entities;
using Prismatic.Domain.Repositories;

namespace Prismatic.Infra.Repositories
{
    public class LobbyRepository : MongoRepository<Lobby>, ILobbyRepository
    {
        public LobbyRepository(IMongoClient mongoClient) : base(mongoClient)
        {
        }
    }
}
