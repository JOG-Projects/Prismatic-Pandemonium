using MongoDB.Driver;
using Prismatic.Core.Infra;
using Prismatic.Domain.Entities;
using Prismatic.Domain.Repositories;

namespace Prismatic.Infra.Repositories
{
    public class PlayerRepository : MongoRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(IMongoClient mongoClient) : base(mongoClient)
        {
        }

        public async Task ChangeStatus(string userName, string? connectionId = null)
        {
            var filter = Builders<Player>.Filter.Eq(x => x.Username, userName);

            var updateConnectionId = Builders<Player>.Update.Set(x => x.ConnectionId, connectionId);
            await Collection.UpdateOneAsync(filter, updateConnectionId);

            var newStatus = connectionId is not null ? Status.Online : Status.Offline;
            var updateStatus = Builders<Player>.Update.Set(x => x.Status, newStatus);
            await Collection.UpdateOneAsync(filter, updateStatus);
        }

        public async Task<Player> GetByUsername(string username)
        {
            return await Collection.Find(x => x.Username == username).FirstOrDefaultAsync();
        }

        public async Task SetCurrentLobby(Guid playerId, Lobby lobby)
        {
            var filter = Builders<Player>.Filter.Eq(x => x.Id, playerId);

            var updateLobby = Builders<Player>.Update.Set(x => x.CurrentLobby, lobby.Id);
            await Collection.UpdateOneAsync(filter, updateLobby);
        }
    }
}