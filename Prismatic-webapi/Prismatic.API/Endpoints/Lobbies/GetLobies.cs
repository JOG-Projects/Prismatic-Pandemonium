using MediatR;
using Prismatic.Application.Lobbies;
using Prismatic.Core.Api;
using Prismatic.Domain.Entities;

namespace Prismatic.API.Endpoints.Lobbies
{
    public class GetLobbies : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("lobby", Handler).WithOpenApi();
        }

        public async Task<List<Lobby>> Handler(IMediator mediator)
        {
            return await mediator.Send(new GetLobbiesRequest());
        }
    }
}
