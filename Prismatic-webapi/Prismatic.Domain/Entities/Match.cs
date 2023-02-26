using Prismatic.Core.Domain;

namespace Prismatic.Domain.Entities
{
    public class Match : Entity
    {
        public required string Name { get; set; }
    }
}
