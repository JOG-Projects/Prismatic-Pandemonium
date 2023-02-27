using Prismatic.Core.Domain;

namespace Prismatic.Domain.Entities
{
    public class Player : Entity
    {
        public required string Username { get; set; }
        public required Status Status { get; set; }
        public string? ConnectionId { get; set; }
        public Guid? CurrentLobby { get; set; }
    }
}