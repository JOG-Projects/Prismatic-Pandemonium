using Prismatic.Core.Api;
using Prismatic.Domain.Interfaces;

namespace Prismatic.API.Endpoints.Matches
{
    public class CreateMatch : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
        }

        public Task Handler(IMatchRepository matchRepository)
        {
            throw new NotImplementedException();
        }
    }
}