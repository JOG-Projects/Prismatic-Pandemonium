using Prismatic.Core.Domain;

namespace Prismatic.Domain.Entities
{
    public class Player : Entity
    {
        public string Username { get; set; }
        public string ConnectionId { get; set; }
        public Status Status { get; set; }
        public Guid CurrentLobby { get; set; }
    }
}