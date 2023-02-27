using Prismatic.Core.Domain;
using Prismatic.Domain.Entities;

namespace Prismatic.Domain.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        public Task ChangeStatus(string userName, string? connectionId = null);
        public Task<Player> GetByUsername(string username);
        public Task SetCurrentLobby(Guid playerId, Lobby lobby);
    }
}