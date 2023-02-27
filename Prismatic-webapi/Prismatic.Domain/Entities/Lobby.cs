using Prismatic.Core.Domain;

namespace Prismatic.Domain.Entities
{
    public class Lobby : Entity
    {
        public List<Player> Players { get; set; } = new();
        public Guid OwnerId { get; set; }
    }
}
