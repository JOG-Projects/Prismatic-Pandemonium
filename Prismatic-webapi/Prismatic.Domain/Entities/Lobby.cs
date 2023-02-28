using Prismatic.Core.Domain;

namespace Prismatic.Domain.Entities
{
    public class Lobby : Entity
    {
        public List<Player> Players { get; set; } = new();
        public required Guid OwnerId { get; set; }

        public required GameStatus Status { get; set; }
    }

    public enum GameStatus 
    {
        Open,
        Playing,
        Closed
    }
}
