using Prismatic.Core.Api;
using Prismatic.Domain.Entities;
using Prismatic.Domain.Interfaces;

namespace Prismatic.API.Endpoints
{
    public class CreateMatch : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("match/create", Handler).WithOpenApi();
        }

        public async Task Handler(IMatchRepository matchRepository)
        {
            await matchRepository.Add(new Match { Name = "sexo" });
        }
    }
}